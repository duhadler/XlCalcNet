# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

import string
from fractions import Fraction as Q
#from fractions import *

from xlcalcnet import ctx_qp
qp = ctx_qp.QPContext()

from xlcalcnet import mathqp


class qpm():

    # %% General functions


    def __init__(self):
        pass

    def t(self, x):
        if isinstance(x, Q):
            return x
        elif (str(type(x)) == "<class 'xlcalcnet.mathqp.QCplx'>"):
            return 1*x
        elif isinstance(x, float) or isinstance(x, int):
            return Q(str(x))
        # elif mpm.ismpf(x):
        #     return Q(str(x))
        elif isinstance(x, str):
            return Q(x)



    def s(self, z, mantissa_dps=None):
        if mantissa_dps is None:
            mantissa_dps = 15
        f = "{0:." + str(mantissa_dps-1) + "E}"
        if not((str(type(z)) == "<class 'xlcalcnet.mathqp.QCplx'>") or isinstance(z, Q)):
            z = self.t(z)
        if isinstance(z, Q):
            return f.format(z)
        else:
            #print("z: ", z)
            y = z.imag
            sy = f.format(y)
            x = z.real
            sx = f.format(x)
            p = " + "
            if sx[0] == '-':
                p = " - "
                sy = sy[1:]
            return "(" + sx + p + sy + "j)"


# %% 2 Contexts and a minimal set of context functions




# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.2 Obtaining the name of a context
    @property
    def name(self):
        return "qpm"

    @property
    def realtype(self):
        return qp.mpf

    @property
    def complextype(self):
        return qp.mpf


# 2.1.2 Creating a real number
    def mpf(self, x):
        return qp.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        return qp.mpc(x, y)

### 2.1.4 Getting and setting the current precision (in bits)
##    @property
##    def prec(self):
##        return qp.prec
##
##    @prec.setter
##    def prec(self, value):
##        qp.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)
    @property
    def dps(self):
        return qp.dps

    @dps.setter
    def dps(self, value):
        qp.dps = int(value)

# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return qp.pretty

    @pretty.setter
    def pretty(self, value):
        qp.pretty = bool(value)




# %%%  2.2 Arithmetic operations

# This is implemented in fp, mp, iv, dp, gp, ap


    def fadd(self, x, y, **kwargs):
        return qp.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return qp.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return qp.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return qp.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return qp.fdiv(x, y, **kwargs)

    def fmod(self, x, y):
        return qp.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return qp.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return qp.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return qp.fdot(A, B, conjugate)




# %%%  2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball
    def mid(self, z):
        z = self.t(z)
        return z

# 2.3.2 Radius of an interval or ball
    def radius(self, z):
        return self.t(0)

# 2.3.3 Left border of an interval or ball
    def left(self, z):
        z = self.t(z)
        return z

# 2.3.4 Left border of an interval or ball
    def right(self, z):
        z = self.t(z)
        return z

# 2.3.5 Absolute value of the left end of an interval
    def absmin(self, z):
        return qp.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        return qp.absmax(z)




# %%%  2.4 Complex components


    def fabs(self, z):
        z = self.t(z)
        if isinstance(z, Q):
            if z < 0:
                return -z
            else:
                return +z
        else:
            return NotImplemented


    def sign(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(0)
        if isinstance(z, Q):
            if z < 0:
                return self.t(-1)
            else:
                return self.t(+1)
        else:
            return NotImplemented

    def re(self, z):
        z = self.t(z)
        return z.real

    def real(self, z):
        z = self.t(z)
        return z.real

    def im(self, z):
        z = self.t(z)
        return z.imag

    def imag(self, z):
        z = self.t(z)
        return z.imag

    def arg(self, z):
        z = self.t(z)
        if isinstance(z, Q):
            return self.t(0)
        else:
            return NotImplemented

    def phase(self, z):
        z = self.t(z)
        if isinstance(z, Q):
            return self.t(0)
        else:
            return NotImplemented

    def conj(self, z):
        z = self.t(z)
        if isinstance(z, Q):
            return +z
        else:
            return NotImplemented

##    def polar(self, z):
##        return qp.polar(z)
##
##    def rect(self, r, phi):
##        return qp.rect(r, phi)



# %%%  2.5 Integer and fractional parts

    # def floor(self, z):
    #     z = self.t(z)
    #     return z.to_integral_value(rounding=ROUND_FLOOR)

    # def ceil(self, z):
    #     z = self.t(z)
    #     return z.to_integral_value(rounding=ROUND_CEILING)

    def nint(self, z):
        return qp.nint(z)

    def frac(self, z):
        return qp.frac(z)




# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return qp.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return qp.almosteq(s, t, rel_eps, abs_eps)


# %%%  2.7 Properties of numbers

    def ismpf(self, z):
        return qp.ismpf(z)

    def ismpc(self, z):
        return qp.ismpc(z)


    def isinf(self, z):
        return qp.isinf(z)

    def isnan(self, z):
        return qp.isnan(z)

    def isnormal(self, z):
        return qp.isnormal(z)

    def isfinite(self, z):
        return qp.isfinite(z)

    def isint(self, z):
        return qp.isint(z)

    def ldexp(self, x, n):
        return qp.ldexp(x, n)

    def frexp(self, x):
        return qp.frexp(x)

    def mag(self, x):
        return qp.mag(x)

    def nint_distance(self, x):
        return qp.nint_distance(x)


# %%%  2.8 Number generation


    def fraction(self, p, q):
        return qp.fraction(p, q)

    def rand(self):
        return qp.rand()

    def arange(self, *args):
        return qp.arange(*args)

    def linspace(self, *args, **kwargs):
        return qp.arange(*args, **kwargs)




# %%%  2.9 Exact mathematical constants

    @property
    def zero(self):
        return qp.zero

    @property
    def one(self):
        return qp.one

##    @property
##    def j(self):
##        return qp.j

##    @property
##    def inf(self):
##        return qp.inf
##
##    @property
##    def ninf(self):
##        return qp.ninf
##
##    @property
##    def nan(self):
##        return qp.nan





# %%%  2.10 Mathematical Constants

    @property
    def eps(self):
        return +qp.zero





# %%%  2.11 Utility functions


    def convert(self, z):
        return self.t(z)

    def mpmathify(self, z):
        return self.t(z)


    def nstr(self, x, n=6, **kwargs):
        return qp.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return qp.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(z)

    # def to_mpf(self, z):
    #     return mpm.t(str(z))

    def from_mpf(self, z):
        return Q(str(z))




# %%%  3.3 Square, roots and power functions

# 3.3.1 Square, x^2

    def square(self, z):
        '''Returns square(z) = z * z.'''
        z = self.t(z)
        return z * z

