# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

import numpy as np


class npm():


    def __init__(self):
        pass


# 5.1 Numpy array creation from shape or value



    def eye(self, N, M=None, k=0, dtype=float, order='C', *, device=None, \
        like=None):
        """
        Returns a 2-D array with ones on the diagonal and zeros elsewhere.
        """
        try:
            if dtype is not None:
                x = np.eye(N, M, k, None, order, device=device, like=like)
                return self.t(dtype, x)
        except:
            return np.eye(N, M, k, dtype, order, device=device, like=like)


    def identity(self, n, dtype=None, *, like=None):
        """
        Returns the identity array. The identity array is a square array with
        ones on the main diagonal.
        """
        try:
            if dtype is not None:
                x = np.identity(n, None, like=like)
                return self.t(dtype, x)
        except:
            return np.identity(n, dtype, like=like)


    def ones(self, shape, dtype=None, order='C', *, device=None, like=None):
        """
        Returns a new array of given shape and type, filled with ones.
        """
        try:
            if dtype is not None:
                x = np.ones(shape, None, order, device=device, like=like)
                return self.t(dtype, x)
        except:
            return np.ones(shape, dtype, order, device=device, like=like)


    def ones_like(self, a, dtype=None, order='K', subok=True, shape=None, *, \
        device=None):
        """
        Returns an array of ones with the same shape and type as a given array
        """
        try:
            if dtype is not None:
                x = np.ones_like(a, None, order, subok, shape, device=device)
                return self.t(dtype, x)
        except:
            return np.ones_like(a, dtype, order, subok, shape, device=device)


    def zeros(self, shape, dtype=None, order='C', *, device=None, like=None):
        """
        Returns a new array of given shape and type, filled with zeros.
        """
        try:
            if dtype is not None:
                x = np.zeros(shape, None, order, device=device, like=like)
                return self.t(dtype, x)
        except:
            return np.zeros(shape, dtype, order, device=device, like=like)


    def zeros_like(self, a, dtype=None, order='K', subok=True, shape=None, *, \
        device=None):
        """
        Returns an array of zeros with the same shape and type as a given array
        """
        try:
            if dtype is not None:
                x = np.zeros_like(a, None, order, subok, shape, device=device)
                return self.t(dtype, x)
        except:
            return np.ones_like(a, dtype, order, subok, shape, device=device)


    def full(self, shape, fill_value, dtype=None, order='C', *, device=None, \
        like=None):
        """
        Returns  a new array of given shape and type, filled with fill_value
        """
        return np.full(shape, fill_value, dtype, order, device=device, \
            like=like)


    def full_like(self, a, fill_value, dtype=None, order='K', subok=True, \
        shape=None, *, device=None):
        """
        Returns Return a full array with the same shape and type as a given
        array
        """
        try:
            if dtype is not None:
                x = np.full_like(a, fill_value, None, order, subok, shape, \
                    device=device)
                return self.t(dtype, x)
        except:
            return np.full_like(a, fill_value, dtype, order, subok, shape, \
                device=device)


    def tri(self, N, M=None, k=0, dtype=float, *, like=None):
        """
        Create an array with ones at and below the given diagonal and zeros
        elsewhere.
        """
        try:
            if dtype is not None:
                x = np.tri(N, M, k, float, like=like)
                return self.t(dtype, x)
        except:
            return np.tri(N, M, k, dtype, like=like)




# 5.2 Numpy array creation from existing data


    def array(self, obj, dtype=None, *, copy=True, order='K', subok=False, \
        ndmin=0, like=None):
        """
        Returns an array from any object exposing the array interface, any
        object whose __array__ method returns an array, or any (nested)
        sequence. If object is a scalar, a 0-dimensional array containing
        object is returned.
        """
        try:
            if dtype is not None:
                x = np.array(obj, None, copy=copy, order=order, subok=subok, \
                    ndmin=ndmin, like=like)
                return self.t(dtype, x)
        except:
            return np.array(obj, dtype, copy=copy, order=order, subok=subok, \
            ndmin=ndmin, like=like)



    def asarray(self, a, dtype=None, order=None, *, device=None, copy=None, \
        like=None):
        """
        Returns an array from any object exposing the array interface, any
        object whose __array__ method returns an array, or any (nested)
        sequence. If object is a scalar, a 0-dimensional array containing
        object is returned.
        """
        return np.asarray(a, dtype, order, device=device, copy=copy, like=like)


    def asanyarray(self, a, dtype=None, order=None, *, device=None, copy=None, \
        like=None):
        """
        Convert the input to an ndarray, but pass ndarray subclasses through.
        Return an array from input data in any form that can be converted to an
        array. This includes lists, lists of tuples, tuples, tuples of tuples,
        tuples of lists and ndarrays.
        """
        return np.asanyarray(a, dtype, order, device=device, copy=copy, \
            like=like)


    def fromfile(self, file, dtype=float, count=-1, sep='', offset=0, *, \
        like=None):
        """
        Construct an array from data in a text or binary file. A highly efficient
        way of reading binary data with a known data-type, as well as parsing
        simply formatted text files. Data written using the tofile method can be
        read using this function.
        """
        return np.fromfile(file, dtype, count, sep, offset, like=like)


    def fromfunction(self, function, shape, *, dtype=float, like=None, \
        **kwargs):
        """
        Construct an array by executing a function over each coordinate. The
        resulting array therefore has a value fn(x, y, z) at coordinate (x, y, z).
        """
        return np.fromfunction(function, shape, dtype=dtype, like=like, \
            kwargs=kwargs)


    def fromiter(self, iter, dtype, count=-1, *, like=None):
        """
        Create a new 1-dimensional array from an iterable object.
        """
        return np.fromiter(iter, dtype, count, like=like)


    def fromstring(self, string, dtype=float, count=-1, *, sep, like=None):
        """
        Create a new 1-dimensional array initialized from text data in a string.
        """
        return np.fromstring(string, dtype, count, sep=sep, like=like)


    def loadtxt(self, fname, dtype=float, comments='#', delimiter=None, \
        converters=None, skiprows=0, usecols=None, unpack=False, ndmin=0, \
        encoding=None, max_rows=None, *, quotechar=None, like=None):
        """
        Load data from a text file. Each row in the input text file must have
        the same number of values to be able to read all values.
        """
        return np.loadtxt(fname, dtype, comments, delimiter, converters, \
          skiprows, usecols, unpack, ndmin, encoding, max_rows, \
          quotechar=quotechar, like=like)

    def genfromtxt(self, fname, dtype=float, comments='#', delimiter=None,
                   skip_header=0, skip_footer=0, converters=None,
                   missing_values=None, filling_values=None, usecols=None,
                   names=None, excludelist=None,
                   deletechars=" !#$%&'()*+, -./:;<=>?@[\\]^{|}~",
                   replace_space='_', autostrip=False, case_sensitive=True,
                   defaultfmt="f%i", unpack=None, usemask=False, loose=True,
                   invalid_raise=True, max_rows=None, encoding=None,
                   *, ndmin=0, like=None):
        """
        Load data from a text file. Each row in the input text file must have
        the same number of values to be able to read all values.
        """
        return np.genfromtxt(fname, dtype, comments, delimiter,
                   skip_header, skip_footer, converters,
                   missing_values, filling_values, usecols,
                   names, excludelist,
                   deletechars,
                   replace_space, autostrip, case_sensitive,
                   defaultfmt, unpack, usemask, loose,
                   invalid_raise, max_rows, encoding,
                   ndmin=ndmin, like=like)



# 5.3 Building special arrays for numerical work


    def arange(self, *args, dtype=None, device=None, like=None):
        if not len(args) <= 3:
            raise TypeError('arange expected at most 3 arguments, got %i' % len(args))
        if not len(args) >= 1:
            raise TypeError('arange expected at least 1 argument, got %i' % len(args))
        # set default
        a = 0
        dt = 1
        # interpret arguments
        if len(args) == 1:
            b = args[0]
        elif len(args) >= 2:
            a = args[0]
            b = args[1]
        if len(args) == 3:
            dt = args[2]
        try:
            if dtype is not None:
                a, b, dt = dtype.t(a), dtype.t(b), dtype.t(dt)
                return np.arange(a, b, dt, dtype=None, device=device, like=like)
        except:
            return np.arange(a, b, dt, dtype=dtype, device=device, like=like)



    def linspace(self, start, stop, num=50, endpoint=True, retstep=False, \
        dtype=None, axis=0, *, device=None):
        """Return an array of evenly spaced multiprecision numbers over a
        specified interval.

        This behaves like the numpy version.
        """
        try:
            if dtype is not None:
                if endpoint:
                    if num == 1:
                        x = zeros(dtype, 1)
                    x = np.arange(num) / dtype.t(num - 1)
                else:
                    x = np.arange(num) / dtype.t(num)
                start, stop = dtype.t(start), dtype.t(stop)
                return (stop - start) * x + start
        except:
            return np.linspace(start, stop, num, endpoint, retstep, dtype, \
                axis, device=device)


    def logspace(self, start, stop, num=50, endpoint=True, base=10.0, \
        dtype=None, axis=0):
        """
        Return numbers spaced evenly on a log scale. In linear space, the
        sequence starts at base ** start (base to the power of start)
        and ends with base ** stop.
        """
        try:
            if dtype is not None:
                y = self.linspace(start, stop, num=num, dtype=dtype, endpoint=endpoint)
                f = np.vectorize(dtype.pow, otypes=[object])
                res=f(base, y)
                return f(base, y)
        except:
            return np.logspace(start, stop, num, endpoint, base, dtype, axis)



    def geomspace(self, start, stop, num=50, endpoint=True, dtype=None, axis=0):
        """
        Return numbers spaced evenly on a log scale (a geometric progression).
        This is similar to logspace, but with endpoints specified directly.
        """
        try:
            if dtype is not None:
                log_start = dtype.log10(start)
                log_stop = dtype.log10(stop)
                result = self.logspace(log_start, log_stop, num=num, \
                    endpoint=endpoint, base=10.0, dtype=dtype)
                return result
        except:
            return np.geomspace(start, stop, num, endpoint, dtype, axis)







    def diag(self, v, k=0):
        """
        Extract a diagonal or construct a diagonal array.
        """
        return np.diag(v, k)


    def diagonal(self, a, offset=0, axis1=0, axis2=1):
        """
        Extract a diagonal or construct a diagonal array.
        """
        return np.diagonal(a, offset, axis1, axis2)


    def diagflat(self, v, k=0):
        """
        Create a two-dimensional array with the flattened input as a diagonal.
        """
        return np.diagflat(v, k)


    def tril(self, m, k=0):
        """
        Returns the lower triangle of an array.
        """
        return np.tril(m, k)


    def triu(self, m, k=0):
        """
        Returns the upper triangle of an array.
        """
        return np.triu(m, k)


    def vander(self, x, N=None, increasing=False):
        """
        Generate a Vandermonde matrix.
        """
        return np.vander(x, N, increasing)





# 5.4 Numpy indexing


# 5.5 Numpy basic array manipulation routines



    def copyto(self, dst, src, casting='same_kind', where=True):
        """
        Copies values from one array to another, broadcasting as necessary.
        Raises a TypeError if the casting rule is violated, and if "where" is
        provided, it selects which elements to copy.
        """
        return np.copyto(dst, src, casting, where)


    def shape(self, a):
        """
        Return the shape of an array.
        """
        return np.shape(a)




    def reshape(self, a, /, shape=None, order='C', *, newshape=None, copy=None):
        """
        Gives a new shape to an array without changing its data.
        """
        return np.reshape(a, shape, order, newshape=newshape, copy=copy)


    def ravel(self, a, order='C'):
        """
        Return a contiguous flattened array.
        """
        return np.ravel(a, order)


    # note: flat is a property of a nparray.

    # note: flatten is a property of a nparray.




# 5.6 Numpy array manipulation: Transpose-like operations


    def moveaxis(self, a, source, destination):
        """
        Move axes of an array to new positions. Other axes remain in their
        original order.
        """
        return np.moveaxis(a, source, destination)


    def swapaxes(self, a, axis1, axis2):
        """
        Interchange two axes of an array.
        """
        return np.swapaxes(a, axis1, axis2)


    def transpose(self, a, axes=None):
        """
        Returns an array with axes transposed.
        """
        return np.transpose(a, axes)




# 5.7 Numpy array manipulation: Changing number of dimensions


    def atleast_1d(self, *arys):
        """
        Convert inputs to arrays with at least one dimension.
        """
        return np.atleast_1d(*arys)


    def atleast_2d(self, *arys):
        """
        Convert inputs to arrays with at least two dimensions.
        """
        return np.atleast_2d(*arys)


    def atleast_3d(self, *arys):
        """
        Convert inputs to arrays with at least three dimensions.
        """
        return np.atleast_3d(*arys)


    def broadcast_to(self, array, shape, subok=False):
        """
        Broadcast an array to a new shape.
        """
        return np.broadcast_to(array, shape, subok)


    def broadcast_arrays(self, *args, subok=False):
        """
        Broadcast any number of arrays against each other.
        """
        return np.broadcast_arrays(*args, subok)


    def expand_dims(self, a, axis):
        """
        Expand the shape of an array. Insert a new axis that will appear at the
        axis position in the expanded array shape.
        """
        return np.expand_dims(a, axis)


    def squeeze(self, a, axis=None):
        """
        Remove axes of length one from a.
        """
        return np.squeeze(a, axis)



# 5.8 Numpy array manipulation: Joining arrays


    def concatenate(self, arrays, axis=0, out=None, dtype=None, \
        casting="same_kind"):
        """
        Join a sequence of arrays along an existing axis.
        """
        return np.concatenate(arrays, axis, out, dtype=dtype, casting=casting)


    def stack(self, arrays, axis=0, out=None, *, dtype=None, \
        casting='same_kind'):
        """
        Join a sequence of arrays along a new axis.
        """
        return np.stack(arrays, axis, out, dtype=dtype, casting=casting)


    def block(self, arrays):
        """
        Assemble an nd-array from nested lists of blocks.
        """
        return np.block(arrays)


    def vstack(self, tup, *, dtype=None, casting='same_kind'):
        """
        Stack arrays in sequence vertically (row wise).
        """
        return np.vstack(tup, dtype=dtype, casting=casting)


    def hstack(self, tup, *, dtype=None, casting='same_kind'):
        """
        Stack arrays in sequence horizontally (column wise).
        """
        return np.hstack(tup, dtype=dtype, casting=casting)


    def dstack(self, tup):
        """
        Stack arrays in sequence depth wise (along third axis).
        """
        return np.dstack(tup)


    def column_stack(self, tup):
        """
        Stack 1-D arrays as columns into a 2-D array.
        """
        return np.column_stack(tup)



# 5.9 Numpy array manipulation: Splitting and tiling arrays


    def split(self, ary, indices_or_sections, axis=0):
        """
        Split an array into multiple sub-arrays as views.
        """
        return np.split(ary, indices_or_sections, axis)


    def array_split(self, ary, indices_or_sections, axis=0):
        """
        Split an array into multiple sub-arrays.
        """
        return np.array_split(ary, indices_or_sections, axis)


    def dsplit(self, ary, indices_or_sections):
        """
        Split array into multiple sub-arrays along the 3rd axis (depth).
        """
        return np.dsplit(ary, indices_or_sections)


    def hsplit(self, ary, indices_or_sections):
        """
        Split an array into multiple sub-arrays horizontally (column-wise).
        """
        return np.hsplit(ary, indices_or_sections)


    def vsplit(self, ary, indices_or_sections):
        """
        Split an array into multiple sub-arrays vertically (row-wise).
        """
        return np.vsplit(ary, indices_or_sections)



    def tile(self, A, reps):
        """
        Construct an array by repeating A the number of times given by reps.
        """
        return np.tile(A, reps)


    def repeat(self, a, repeats, axis=None):
        """
        Repeat each element of an array after themselves.
        """
        return np.repeat(a, repeats, axis)




# 5.10 Numpy array manipulation: Adding and removing elements


    def pad(self, array, pad_width, mode='constant', **kwargs):
        """
        Pad an array.
        """
        return np.pad(array, pad_width, mode, **kwargs)


    def delete(self, arr, obj, axis=None):
        """
        Return a new array with sub-arrays along an axis deleted. For a one
        dimensional array, this returns those entries not returned by arr[obj].
        """
        return np.delete(arr, obj, axis)


    def insert(self, arr, obj, values, axis=None):
        """
        Insert values along the given axis before the given indices.
        """
        return np.insert(arr, obj, values, axis)


    def append(self, arr, values, axis=None):
        """
        Append values to the end of an array.
        """
        return np.append(arr, values, axis)


    def trim_zeros(self, filt, trim='fb', axis=None):
        """
        Trim the leading and/or trailing zeros from a 1-D array or sequence.
        """
        return np.trim_zeros(filt, trim, axis)


    def unique(self, ar, return_index=False, return_inverse=False, \
        return_counts=False, axis=None, *, equal_nan=True):
        """
        Find the unique elements of an array.
        """
        return np.unique(ar, return_index, return_inverse, return_counts, axis,\
            equal_nan=equal_nan)




# 5.11 Numpy array manipulation: Rearranging elements


    def flip(self, m, axis=None):
        """
        Reverse the order of elements in an array along the given axis.
        """
        return np.flip(m, axis)


    def fliplr(self, m):
        """
        Reverse the order of elements along axis 1 (left/right).
        """
        return np.fliplr(m)


    def flipud(self, m):
        """
        Reverse the order of elements along axis 0 (up/down).
        """
        return np.flipud(m)


    def roll(self, a, shift, axis=None):
        """
        Roll array elements along a given axis.
        """
        return np.roll(a, shift, axis)


    def rot90(self, m, k=1, axes=(0, 1)):
        """
        Rotate an array by 90 degrees in the plane specified by axes.
        """
        return np.rot90(m, k, axes)



# 5.12 Numpy array manipulation: Sorting


    def sort(self, a, axis=-1, kind=None, order=None, *, stable=None):
        """
        Return a sorted copy of an array.
        """
        return np.sort(a, axis, kind, order, stable=stable)


    def lexsort(self, keys, axis=-1):
        """
        Perform an indirect stable sort using a sequence of keys.
        """
        return np.lexsort(keys, axis)


    def argsort(self, a, axis=-1, kind=None, order=None, *, stable=None):
        """
        Returns the indices that would sort an array.
        """
        return np.argsort(a, axis, kind, order, stable=stable)


    def take_along_axis(self, arr, indices, axis=-1):
        """
        Take values from the input array by matching 1d index and data slices.
        """
        return np.take_along_axis(arr, indices=indices, axis=axis)




    def sort_complex(self, a):
        """
        Sort a complex array using the real part first, then the imaginary part.
        """
        return np.sort_complex(a)



# 5.13 Numpy array manipulation: Searching


    def argmax(self, a, axis=None, out=None, *, keepdims=np._NoValue):
        """
        Returns the indices of the maximum values along an axis.
        """
        return np.argmax(a, axis, out, keepdims=keepdims)


    def argmin(self, a, axis=None, out=None, *, keepdims=np._NoValue):
        """
        Returns the indices of the minimum values along an axis.
        """
        return np.argmin(a, axis, out, keepdims=keepdims)


    def argwhere(self, a):
        """
        Find the indices of array elements that are non-zero, grouped by
        element.
        """
        return np.argwhere(a)


    def nonzero(self, a):
        """
        Return the indices of the elements that are non-zero.
        """
        return np.nonzero(a)


    def where(self, condition, x, y, /):
        """
        Return elements chosen from x or y depending on condition.
        """
        return np.where(condition, x, y)


    def select(self, condlist, choicelist, default=0):
        """
        Return an array drawn from elements in choicelist, depending on
        conditions.
        """
        return np.select(condlist, choicelist, default)





# 5.14 Numpy mathematical functions: Sums, products, differences


    def prod(self, a, axis=None, dtype=None, out=None, keepdims=np._NoValue, \
        initial=np._NoValue, where=np._NoValue):
        """
        Return the product of array elements over a given axis.
        The product of an empty array is the neutral element 1.
        """
        return np.prod(a, axis, dtype, out, keepdims, initial, where)


    def sum(self, a, axis=None, dtype=None, out=None, keepdims=np._NoValue, \
        initial=np._NoValue, where=np._NoValue):
        """
        Sum of array elements over a given axis. The sum of an empty array is
        the neutral element 0.
        """
        return np.sum(a, axis, dtype, out, keepdims, initial, where)


    def cumprod(self, a, axis=None, dtype=None, out=None):
        """
        Return the cumulative product of elements along a given axis.
        """
        return np.cumprod(a, axis, dtype, out)


    def cumsum(self, a, axis=None, dtype=None, out=None):
        """
        Return the cumulative sum of the elements along a given axis.
        """
        return np.cumsum(a, axis, dtype, out)


    def diff(self, a, n=1, axis=-1, prepend=np._NoValue, append=np._NoValue):
        """
        Calculate the n-th discrete difference along the given axis.
        """
        return np.diff(a, n, axis, prepend, append)


    def ediff1d(self, ary, to_end=None, to_begin=None):
        """
        Calculate the differences between consecutive elements of an array.
        """
        return np.ediff1d(ary, to_end, to_begin)


    def gradient(self, f, *varargs, axis=None, edge_order=1):
        """
        Return the gradient of an N-dimensional array.
        """
        return np.gradient(f, *varargs, axis=axis, edge_order=edge_order)


    def cross(self, a, b, axisa=-1, axisb=-1, axisc=-1, axis=None):
        """
        Return the cross product of two (arrays of) vectors.
        """
        return np.cross(a, b, axisa, axisb, axisc, axis)


    def trapezoid(self, y, x=None, dx=1.0, axis=-1):
        """
        Integrate along the given axis using the composite trapezoidal rule.
        """
        return np.trapezoid(y, x, dx, axis)


# 5.15 Numpy mathematical functions: Extrema Finding


    def maximum(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Element-wise maximum of array elements.
        """
        return np.maximum(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def minimum(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Element-wise minimum of array elements.
        """
        return np.minimum(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def max(self, a, axis=None, out=None, keepdims=np._NoValue, \
        initial=np._NoValue, where=np._NoValue):
        """
        Return the maximum of an array or maximum along an axis.
        """
        return np.max(a, axis, out, keepdims, initial, where)


    def min(self, a, axis=None, out=None, keepdims=np._NoValue, \
        initial=np._NoValue, where=np._NoValue):
        """
        Return the minimum of an array or minimum along an axis.
        """
        return np.min(a, axis, out, keepdims, initial, where)



# 5.16 Numpy mathematical functions: Arithmetic operations, elementwise



    def positive(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Numerical positive, element-wise. Equivalent to x.copy(), but only
        defined for types that support arithmetic.
        """
        return np.positive(x, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def negative(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Numerical negative, element-wise.
        """
        return np.negative(x, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def add(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Add arguments element-wise. Equivalent to x1 + x2 in terms of array
        broadcasting.
        """
        return np.add(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def subtract(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Subtract arguments, element-wise. Equivalent to x1 - x2 in terms of
        array broadcasting.
        """
        return np.subtract(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def multiply(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Multiply arguments element-wise. Equivalent to x1 * x2 in terms of array
        broadcasting.
        """
        return np.multiply(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def divide(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Divide arguments element-wise. Equivalent to x1 / x2 in terms of
        array-broadcasting.
        """
        return np.divide(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def floor_divide(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Return the largest integer smaller or equal to the division of the
        inputs. It is equivalent to the Python // operator and pairs with the
        Python % (remainder), function so that a = a % b + b * (a // b) up to
        roundoff.
        """
        return np.floor_divide(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def remainder(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Returns the element-wise remainder of division.
        """
        return np.remainder(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def square(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the fractional and integral parts of an array, element-wise.
        """
        return np.square(x, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def reciprocal(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the reciprocal of the argument, element-wise.
        """
        return np.reciprocal(x, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)





# 5.17 Numpy mathematical functions: Averages and variances


    def median(self, a, axis=None, out=None, overwrite_input=False, \
        keepdims=False):
        """
        Returns the median of the array elements.
        """
        return np.median(a, axis, out, overwrite_input, keepdims)


    def average(self, a, axis=None, weights=None, returned=False, *, \
        keepdims=np._NoValue):
        """
        Compute the weighted average along the specified axis.
        """
        return np.average(a, axis, weights, returned, keepdims=keepdims)


    def mean(self, a, axis=None, dtype=None, out=None, keepdims=np._NoValue, \
        *, where=np._NoValue):
        """
        Compute the weighted average along the specified axis.
        """
        return np.mean(a, axis, dtype, out, keepdims, where=where)


    def var_old(self, a, axis=None, dtype=None, out=None, ddof=0, \
        keepdims=np._NoValue, *, where=np._NoValue, mean=np._NoValue, \
        correction=np._NoValue):
        """
        Compute the variance along the specified axis.
        """
        return np.var(a, axis, dtype, out, ddof, keepdims, where=where, \
            mean=mean, correction=correction)



    def var(self, a, axis=None, dtype=None, out=None, ddof=0, \
        keepdims=np._NoValue, *, where=np._NoValue, mean=np._NoValue, \
        correction=np._NoValue):
        """
        Compute the variance along the specified axis.
        """
        scalar = a.item(0)
        if str(type(scalar)) == "<class 'flint.types.arb.arb'>":
            from flint import arb, acb
            def real(z): return z.real
            f = np.vectorize(acb, otypes=[object])
            acb_data = f(a)
            acb_var = np.var(acb_data, axis, dtype, out, ddof, keepdims, where=where, \
                mean=mean, correction=correction)
            f = np.vectorize(real, otypes=[object])
            arb_var = f(acb_var)
            return arb_var
        else:
            return np.var(a, axis, dtype, out, ddof, keepdims, where=where, \
                mean=mean, correction=correction)






# 5.18 Numpy mathematical functions: Matrix and vector products


    def dot(self, a, b, out=None):
        """
        Compute the dot product of two arrays.
        """
        return np.dot(a, b, out)


    def vdot(self, a, b):
        """
        Return the dot product of two vectors.
        """
        return np.vdot(a, b)


    def inner(self, a, b):
        """
        Return the inner product of two arrays.
        """
        return np.inner(a, b)


    def outer(self, a, b, out=None):
        """
        Compute the outer product of two vectors.
        """
        return np.outer(a, b, out)


    def matmul(self, x1, x2, /, out=None, *, casting='same_kind', order='K', \
        dtype=None, subok=True):
        """
        Matrix product of two arrays.
        """
        return np.matmul(x1, x2,out, casting=casting, order=order, dtype=dtype, \
            subok=subok)


    def tensordot(self, a, b, axes=2):
        """
        Compute tensor dot product along specified axes.
        """
        return np.tensordot(a, b, axes)


    def einsum(self, subscripts, *operands, out=None, dtype=None, order='K', \
        casting='safe', optimize=False):
        """
        Evaluates the Einstein summation convention on the operands.
        """
        return np.einsum(subscripts, *operands, out=out, dtype=dtype, \
            order=order, casting=casting, optimize=optimize)



    def kron(self, a, b):
        """
        Kronecker product of two arrays.
        """
        return np.kron(a=a, b=b)


    def convolve(self, a, v, mode='full'):
        """
        Kronecker product of two arrays.
        """
        return np.convolve(a=a, v=v, mode=mode)





# 5.19 Numpy logical functions: Truth value testing


    def all(self, a, axis=None, out=None, keepdims=np._NoValue, *, \
        where=np._NoValue):
        """
        Test whether all array elements along a given axis evaluate to True.
        """
        return np.all(a, axis, out, keepdims, where=where)


    def any(self, a, axis=None, out=None, keepdims=np._NoValue, *, \
        where=np._NoValue):
        """
        Test whether any array elements along a given axis evaluate to True.
        """
        return np.any(a, axis, out, keepdims, where=where)



    def logical_and(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Compute the truth value of x1 AND x2 element-wise.
        """
        return np.logical_and(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def logical_or(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Compute the truth value of x1 OR x2 element-wise.
        """
        return np.logical_or(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def logical_xor(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Compute the truth value of x1 XOR x2, element-wise.
        """
        return np.logical_xor(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def array_equal(self, a1, a2, equal_nan=False):
        """
        True if two arrays have the same shape and elements, False otherwise.
        """
        return np.array_equal(a1, a2, equal_nan)


    def array_equiv(self, a1, a2):
        """
        True if two arrays have the same shape and elements, False otherwise
        """
        return np.array_equiv(a1, a2)


    def greater(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 > x2) element-wise.
        """
        return np.greater(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def greater_equal(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 >= x2) element-wise.
        """
        return np.greater_equal(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def less(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 < x2) element-wise.
        """
        return np.less(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def less_equal(self, x1, x2, /, out=None, *, where=True, \
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 <= x2) element-wise.
        """
        return np.less_equal(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def equal(self, x1, x2, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 == x2) element-wise.
        """
        return np.equal(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)


    def not_equal(self, x1, x2, /, out=None, *, where=True,
        casting='same_kind', order='K', dtype=None, subok=True):
        """
        Return the truth value of (x1 != x2) element-wise.
        """
        return np.not_equal(x1, x2, out, where=where, casting=casting, \
            order=order, dtype=dtype, subok=subok)



# 5.20 Numpy mathematical functions: Integer and fractional


    def floor(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the floor of the input, element-wise.
        """
        return np.floor(x, out, where=where, casting=casting, order=order, \
            dtype=dtype, subok=subok)


    def ceil(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the ceiling of the input, element-wise.
        """
        return np.ceil(x, out, where=where, casting=casting, order=order, \
            dtype=dtype, subok=subok)


    def trunc(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Return the truncated value of the input, element-wise.
        """
        return np.trunc(x, out, where=where, casting=casting, order=order, \
            dtype=dtype, subok=subok)


    def rint(self, x, /, out=None, *, where=True, casting='same_kind', \
        order='K', dtype=None, subok=True):
        """
        Round elements of the array to the nearest integer.
        """
        return np.rint(x, out, where=where, casting=casting, order=order, \
            dtype=dtype, subok=subok)


    def fix(self, x, out=None):
        """
        Round to nearest integer towards zero.
        """
        return np.fix(x, out)




# 5.21 Numpy mathematical functions: Miscellaneous




    def vectorize(self, pyfunc=np._NoValue, otypes=None, doc=None,
                 excluded=None, cache=False, signature=None):
        """
        Returns an object that acts like pyfunc, but takes arrays as input.
        """
        return np.vectorize(pyfunc, otypes, doc, excluded, cache, signature)


    def t(self, ctx, ndarray):
        """
        Returns an array with all elements x = ctx.t(x)
        """
        to_ctx = np.vectorize(ctx.t, otypes=[object])
        return to_ctx(ndarray)


##    def force_complex(self, ctx, ndarray):
##        """
##        Returns an array with all elements x = ctx.t(x)
##        """
##        from flint import acb
##        print (ctx.name)
##        #f = np.vectorize(ctx.force_complex, otypes=[object])
##        f = np.vectorize(acb, otypes=[object])
##        acb_data = f(ndarray)
##        scalar = acb_data.item(0)
##        print ("scalar: ", scalar, type(scalar))
##        print (acb_data)
##        return acb_data
##
##        #return np.vectorize(ctx.force_complex, otypes=[object])



    def conj(self, ctx, a):
        """
        Returns an array with all elements x = np.conj(x)
        """
        scalar = a.item(0)
        if str(type(scalar)) == "<class 'flint.types.arb.arb'>":
            f = np.vectorize(ctx.conj, otypes=[object])
            data = f(a)
            return a * 1
        else:
            return np.conj(a)



    def sign(self, a):
        """
        Returns an array with all elements x = np.sign(x)
        """
        return np.sign(a)



    def absolute(self, a):
        """
        Returns an array with all elements x = np.sign(x)
        """
        return np.absolute(a)





























































