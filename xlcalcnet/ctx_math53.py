# -*- coding: utf-8 -*-
"""
Spyder Editor
"""


# https://github.com/pythonnet/pythonnet/issues/514#issuecomment-350375105
# https://stackoverflow.com/questions/43910749/efficiently-convert-system-single-to-numpy-array

import numpy as np
import ctypes
import clr, System
from System import Array, Int32, Double
from System.Runtime.InteropServices import GCHandle, GCHandleType


_MAP_NP_NET = {
    np.dtype('float32'): System.Single,
    np.dtype('float64'): System.Double,
    np.dtype('int8')   : System.SByte,
    np.dtype('int16')  : System.Int16,
    np.dtype('int32')  : System.Int32,
    np.dtype('int64')  : System.Int64,
    np.dtype('uint8')  : System.Byte,
    np.dtype('uint16') : System.UInt16,
    np.dtype('uint32') : System.UInt32,
    np.dtype('uint64') : System.UInt64,
    np.dtype('bool')   : System.Boolean,
}
_MAP_NET_NP = {
    'Single' : np.dtype('float32'),
    'Double' : np.dtype('float64'),
    'SByte'  : np.dtype('int8'),
    'Int16'  : np.dtype('int16'),
    'Int32'  : np.dtype('int32'),
    'Int64'  : np.dtype('int64'),
    'Byte'   : np.dtype('uint8'),
    'UInt16' : np.dtype('uint16'),
    'UInt32' : np.dtype('uint32'),
    'UInt64' : np.dtype('uint64'),
    'Boolean': np.dtype('bool'),
}


def asNumpyArray(netArray):
    '''
    Given a CLR `System.Array` returns a `numpy.ndarray`.  See _MAP_NET_NP for
    the mapping of CLR types to Numpy dtypes.
    '''
    dims = np.empty(netArray.Rank, dtype=int)
    for I in range(netArray.Rank):
        dims[I] = netArray.GetLength(I)
    netType = netArray.GetType().GetElementType().Name

    try:
        npArray = np.empty(dims, order='C', dtype=_MAP_NET_NP[netType])
    except KeyError:
        raise NotImplementedError("asNumpyArray does not support System type {}".format(netType) )

    try: # Memmove
        sourceHandle = GCHandle.Alloc(netArray, GCHandleType.Pinned)
        sourcePtr = sourceHandle.AddrOfPinnedObject().ToInt64()
        destPtr = npArray.__array_interface__['data'][0]
        ctypes.memmove(destPtr, sourcePtr, npArray.nbytes)
    finally:
        if sourceHandle.IsAllocated: sourceHandle.Free()
    return npArray


def asNetArray(npArray):
    '''
    Given a `numpy.ndarray` returns a CLR `System.Array`.  See _MAP_NP_NET for
    the mapping of Numpy dtypes to CLR types.
    '''
    dims = npArray.shape
    dtype = npArray.dtype

    netDims = Array.CreateInstance(Int32, npArray.ndim)
    for I in range(npArray.ndim):
        netDims[I] = Int32(dims[I])

    if not npArray.flags.c_contiguous:
        npArray = npArray.copy(order='C')
    assert npArray.flags.c_contiguous

    try:
        netArray = Array.CreateInstance(_MAP_NP_NET[dtype], netDims)
    except KeyError:
        raise NotImplementedError("asNetArray does not support dtype {}".format(dtype))

    try: # Memmove
        destHandle = GCHandle.Alloc(netArray, GCHandleType.Pinned)
        sourcePtr = npArray.__array_interface__['data'][0]
        destPtr = destHandle.AddrOfPinnedObject().ToInt64()
        ctypes.memmove(destPtr, sourcePtr, npArray.nbytes)
    finally:
        if destHandle.IsAllocated: destHandle.Free()
    return netArray





class NumpyMath53():


    def __init__(self, FixedPrecNet):
        self.FP = FixedPrecNet
        self.M53 = FixedPrecNet.math53



    def p1(self, func, a):
        if isinstance(a, np.ndarray):
            a_ = asNetArray(a)
            if a.ndim == 1:
                res_ = Array[Double](a.shape[0])
                netfunc = self.M53.vec_p1
            if a.ndim == 2:
                res_ = Array[Double](a.shape[0], a.shape[1])
                netfunc = self.M53.mat_p1
            netfunc(self.FP.cb1SDouble1S(func), a_, res_)
            return asNumpyArray(res_)
        else:
            return func(a)


    def p2(self, func, a, b):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_ = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p2
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_ = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p2
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, float(a), dtype='float64')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, float(b), dtype='float64')
            a_ = asNetArray(a)
            b_ = asNetArray(b)
            netfunc(self.FP.cb2SDouble1S(func), a_, b_, res_)
            return asNumpyArray(res_)
        else:
            return func(a, b)


    def p3(self, func, a, b, c):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b), np.shape(c))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_ = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p3
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_ = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p3
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, float(a), dtype='float64')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, float(b), dtype='float64')
            if isinstance(c, np.ndarray):
                if c.shape != maxshape: c = np.broadcast_to(c, maxshape)
            else: c = np.full(scalarshape, float(c), dtype='float64')
            a_ = asNetArray(a)
            b_ = asNetArray(b)
            c_ = asNetArray(c)
            netfunc(self.FP.cb3SDouble1S(func), a_, b_, c_, res_)
            return asNumpyArray(res_)
        else:
            return func(a, b, c)


    def p4(self, func, a, b, c, d):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b), np.shape(c), np.shape(d))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_ = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p4
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_ = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p4
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, float(a), dtype='float64')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, float(b), dtype='float64')
            if isinstance(c, np.ndarray):
                if c.shape != maxshape: c = np.broadcast_to(c, maxshape)
            else: c = np.full(scalarshape, float(c), dtype='float64')
            if isinstance(d, np.ndarray):
                if d.shape != maxshape: d = np.broadcast_to(d, maxshape)
            else: d = np.full(scalarshape, float(d), dtype='float64')
            a_ = asNetArray(a)
            b_ = asNetArray(b)
            c_ = asNetArray(c)
            d_ = asNetArray(d)
            netfunc(self.FP.cb4SDouble1S(func), a_, b_, c_, d_, res_)
            return asNumpyArray(res_)
        else:
            return func(a, b, c, d)




class NumpyMath53c():


    def __init__(self, FixedPrecNet):
        self.FP = FixedPrecNet
        self.M53 = FixedPrecNet.cmath53



    def p1(self, func, a):
        if isinstance(a, np.ndarray):
            a_re = asNetArray(a.real)
            a_im = asNetArray(a.imag)
            if a.ndim == 1:
                res_re = Array[Double](a.shape[0])
                res_im = Array[Double](a.shape[0])
                netfunc = self.M53.vec_p1
            if a.ndim == 2:
                res_re = Array[Double](a.shape[0], a.shape[1])
                res_im = Array[Double](a.shape[0], a.shape[1])
                netfunc = self.M53.mat_p1
            netfunc(self.FP.cb1SComplex1S(func), a_re, a_im, res_re, res_im)
            return asNumpyArray(res_re) + 1j * asNumpyArray(res_im)
        else:
            return func(a)




    def p2(self, func, a, b):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_re = Array[Double](maxshape[0])
                res_im = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p2
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_re = Array[Double](maxshape[0], maxshape[1])
                res_im = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p2
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, complex(a), dtype='complex128')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, complex(b), dtype='complex128')
            a_re = asNetArray(a.real)
            a_im = asNetArray(a.imag)
            b_re = asNetArray(b.real)
            b_im = asNetArray(b.imag)
            netfunc(self.FP.cb2SComplex1S(func), a_re, a_im, b_re, b_im, res_re, res_im)
            return asNumpyArray(res_re) + 1j * asNumpyArray(res_im)
        else:
            return func(a, b)


    def p3(self, func, a, b, c):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b), np.shape(c))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_re = Array[Double](maxshape[0])
                res_im = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p3
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_re = Array[Double](maxshape[0], maxshape[1])
                res_im = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p3
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, complex(a), dtype='complex128')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, complex(b), dtype='complex128')
            if isinstance(c, np.ndarray):
                if c.shape != maxshape: c = np.broadcast_to(c, maxshape)
            else: c = np.full(scalarshape, complex(c), dtype='complex128')
            a_re = asNetArray(a.real)
            a_im = asNetArray(a.imag)
            b_re = asNetArray(b.real)
            b_im = asNetArray(b.imag)
            c_re = asNetArray(c.real)
            c_im = asNetArray(c.imag)
            netfunc(self.FP.cb3SComplex1S(func), a_re, a_im, b_re, b_im, c_re, c_im, \
                res_re, res_im)
            return asNumpyArray(res_re) + 1j * asNumpyArray(res_im)
        else:
            return func(a, b, c)


    def p4(self, func, a, b, c, d):
        maxshape = np.broadcast_shapes(np.shape(a), np.shape(b), np.shape(c), np.shape(d))
        if len(maxshape) != 0:
            if len(maxshape) > 2:
                raise NotImplementedError("only vectors and matrices are supported")
            if len(maxshape) == 1:
                scalarshape = [1]
                res_re = Array[Double](maxshape[0])
                res_im = Array[Double](maxshape[0])
                netfunc = self.M53.vec_p4
            if len(maxshape) == 2:
                scalarshape = [1, 1]
                res_re = Array[Double](maxshape[0], maxshape[1])
                res_im = Array[Double](maxshape[0], maxshape[1])
                netfunc = self.M53.mat_p4
            if isinstance(a, np.ndarray):
                if a.shape != maxshape: a = np.broadcast_to(a, maxshape)
            else: a = np.full(scalarshape, complex(a), dtype='complex128')
            if isinstance(b, np.ndarray):
                if b.shape != maxshape: b = np.broadcast_to(b, maxshape)
            else: b = np.full(scalarshape, complex(b), dtype='complex128')
            if isinstance(c, np.ndarray):
                if c.shape != maxshape: c = np.broadcast_to(c, maxshape)
            else: c = np.full(scalarshape, complex(c), dtype='complex128')
            if isinstance(d, np.ndarray):
                if d.shape != maxshape: d = np.broadcast_to(d, maxshape)
            else: d = np.full(scalarshape, complex(d), dtype='complex128')
            a_re = asNetArray(a.real)
            a_im = asNetArray(a.imag)
            b_re = asNetArray(b.real)
            b_im = asNetArray(b.imag)
            c_re = asNetArray(c.real)
            c_im = asNetArray(c.imag)
            d_re = asNetArray(d.real)
            d_im = asNetArray(d.imag)
            netfunc(self.FP.cb4SComplex1S(func), a_re, a_im, b_re, b_im, c_re, c_im, \
                d_re, d_im, res_re, res_im)
            return asNumpyArray(res_re) + 1j * asNumpyArray(res_im)
        else:
            return func(a, b, c, d)





