# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

#from xlcalcnet import fpclasses, fp_backend
#from xlcalcnet import mathfp
from xlcalcnet import ctx_shared
from xlcalcnet import ctx07StatDataAnalysis

from xlcalcnet.mpmath import mp
import math
import cmath
from xlcalcnet.ctx_mpm import mpm

from xlcalcnet import ctx_fp53
fp = ctx_fp53.FP53Context()

# from xlcalcnet import FRealBoost, Math53, Math53C
#from System import Numerics

ctxm = ctx_shared.ctxUtil()
stat = ctx07StatDataAnalysis.inferential_statistics()




class fpm():

    # %% General functions

    targetpdf = 1
    targetcdf = 2
    targetsf = 3
    targetqtf = 6
    targetisf = 7



    def __init__(self):
        pass


    def tc(self, z2):
        return complex(z2.Real, z2.Imaginary)

    # def nc(self, c2):
    #     return Numerics.Complex(c2.real, c2.imag)



    # def t(self, x, y=None):
    #     if y is None:
    #         if isinstance(x, int):
    #             return float(x)
    #         if isinstance(x, float) or isinstance(x, complex):
    #             return x
    #         elif isinstance(x, mp.mpf):
    #             return float(x)
    #         elif isinstance(x, mp.mpc):
    #             return complex(x)
    #         if isinstance(x, str):
    #             s = ''.join(x.split())
    #             if s[-1] not in ['j', 'J']:
    #                 return float(s)
    #             else:
    #                 return complex(s)
    #     x = float(x)
    #     y = float(y)
    #     return complex(x, y)



    def s(self, z, mantissa_dps=None):
        if mantissa_dps is None:
            mantissa_dps = 15
            if mp.dps < 15:
                mantissa_dps = mp.dps
        f = "{0:." + str(mantissa_dps-1) + "E}"
        # print(f)
        z = self.t(z)
        s = f.format(z)
        return s

    def _fm1(self, fun, fpm_z1):
        z1 = mpm().t(fpm_z1)
        res = fun(z1)
        return self.t(res)

    def _fm2(self, fun, fpm_z1, fpm_z2):
        z1 = mpm().t(fpm_z1)
        z2 = mpm().t(fpm_z2)
        res = fun(z1, z2)
        return self.t(res)

    def _fm3(self, fun, fpm_z1, fpm_z2, fpm_z3):
        z1 = mpm().t(fpm_z1)
        z2 = mpm().t(fpm_z2)
        z3 = mpm().t(fpm_z3)
        res = fun(z1, z2, z3)
        return self.t(res)

    def _fm3b(self, fun, fpm_z1, fpm_z2, fpm_z3, b):
        z1 = mpm().t(fpm_z1)
        z2 = mpm().t(fpm_z2)
        z3 = mpm().t(fpm_z3)
        res = fun(z1, z2, z3, b)
        return self.t(res)

    def _fm4(self, fun, fpm_z1, fpm_z2, fpm_z3, fpm_z4):
        z1 = mpm().t(fpm_z1)
        z2 = mpm().t(fpm_z2)
        z3 = mpm().t(fpm_z3)
        z4 = mpm().t(fpm_z4)
        res = fun(z1, z2, z3, z4)
        return self.t(res)




# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.2 Obtaining the name of a context

    @property
    def name(self):
        return "fpm"

    @property
    def fmtname(self):
        return "    fpm"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        z = self.t(z)
        s1 = "{:.15G}".format(z.real)
        if self.ismpf(z):
            return ' ' + s1
        else:
            s2 = "{:.15G}".format(z.imag)
            return " " + "(" + s1 + ", " + s2 + ")"


    @property
    def realtype(self):
        return fp.mpf

    @property
    def complextype(self):
        return fp.mpc



# 2.1.2 Creating a real number
    def mpf(self, x):
        return fp.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        if y is not None:
            y = float(y)
            x = float(x)
            return fp.mpc(x, y)
        else: return fp.mpc(x)

# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return fp.prec

    @prec.setter
    def prec(self, value):
        fp.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)

    @property
    def dps(self):
        return fp.dps

    @dps.setter
    def dps(self, value):
        fp.dps = int(value)

# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return fp.pretty

    @pretty.setter
    def pretty(self, value):
        fp.pretty = bool(value)



# %%%  2.2 Arithmetic operations

# This is implemented in fp, mp, iv, dp, gp, ap


    def fadd(self, x, y, **kwargs):
        return fp.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return fp.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return fp.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return fp.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return fp.fdiv(x, y, **kwargs)

    def fmod(self, x, y):
        return fp.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return fp.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return fp.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return fp.fdot(A, B, conjugate)



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
        z = self.t(z)
        return fp.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        z = self.t(z)
        return fp.absmax(z)



# %%%  2.4 Complex components


    def abs(self, z):
        z = self.t(z)
        return abs(z)

    def fabs(self, z):
        z = self.t(z)
        return abs(z)

    def sign(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(0)
        if isinstance(z, float):
            if z < 0:
                return self.t(-1)
            else:
                return self.t(+1)
        else:
            return z / self.fabs(z)

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
        if isinstance(z, float):
            return 0.0
        else:
            z = self.t(z)
            return cmath.phase(z)

    def phase(self, z):
        if isinstance(z, float):
            return 0.0
        else:
            z = self.t(z)
            return cmath.phase(z)

    def conj(self, z):
        z = self.t(z)
        return z.conjugate()

    def polar(self, z):
        return fp.polar(z)

    def rect(self, r, phi):
        return fp.rect(r, phi)



# %%%  2.5 Integer and fractional parts

    def floor(self, z):
        z = self.t(z)
        return float(math.floor(z))

    def ceil(self, z):
        z = self.t(z)
        return float(math.ceil(z))

    def nint(self, z):
        return fp.nint(z)

    def frac(self, z):
        return fp.frac(z)




# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return fp.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return fp.almosteq(s, t, rel_eps, abs_eps)


# %%%  2.7 Properties of numbers

    def ismpf(self, z):
        return isinstance(z, fp.mpf)

    def ismpc(self, z):
        return isinstance(z, fp.mpc)


    def isinf(self, z):
        return fp.isinf(z)

    def isnan(self, z):
        return fp.isnan(z)

    def isnormal(self, z):
        return fp.isnormal(z)

    def isfinite(self, z):
        return fp.isfinite(z)

    def isint(self, z):
        return fp.isint(z)

    def ldexp(self, x, n):
        return fp.ldexp(x, n)

    def frexp(self, x):
        return fp.frexp(x)

    def mag(self, x):
        return fp.mag(x)

    def nint_distance(self, x):
        return fp.nint_distance(x)


# %%%  2.8 Number generation


    def fraction(self, p, q):
        return fp.fraction(p, q)

    def rand(self):
        return fp.rand()

    def arange(self, *args):
        return fp.arange(*args)

    def linspace(self, *args, **kwargs):
        return fp.arange(*args, **kwargs)




# %%%  2.9 Exact mathematical constants

    @property
    def zero(self):
        return fp.zero

    @property
    def one(self):
        return fp.one

    @property
    def j(self):
        return fp.j

    @property
    def inf(self):
        return fp.inf

    @property
    def ninf(self):
        return fp.ninf

    @property
    def nan(self):
        return fp.nan



# %%%  2.10 Mathematical Constants



    @property
    def eps(self):
        return +fp.eps

    @property
    def ln2(self):
        return +fp.ln2

    @property
    def ln10(self):
        return +fp.ln10

    @property
    def pi(self):
        return +fp.pi

    @property
    def e(self):
        return +fp.e

    @property
    def euler(self):
        return +fp.euler

    @property
    def phi(self):
        return +fp.phi

    @property
    def catalan(self):
        return +fp.catalan

    @property
    def khinchin(self):
        return +fp.khinchin

    @property
    def glaisher(self):
        return +fp.glaisher

    @property
    def apery(self):
        return +fp.apery

    @property
    def degree(self):
        return +fp.degree






# %%%  2.11 Utility functions

    def t(self, x, y=None):
        return fp.convert(x, y)

    def convert(self, x, y=None):
        return fp.convert(x, y)

    def mpmathify(self, x, y=None):
        return fp.convert(x, y)


    def nstr(self, x, n=6, **kwargs):
        return fp.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return fp.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(z)

    def to_mpf(self, z):
        return mp.mpf(z)

    def from_mpf(self, z):
        return float(z)



# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return fp.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return fp.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return fp.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return fp.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return fp.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return fp.memoize(f)

    def maxcalls(self, f, N):
        return fp.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None, dpi=None, singularities=[], axes=None):
        res = mp.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res



# %% 03 Scalar elementary functions


# %%%  3.1 Exponential and related functions

# 3.1.1 Exponential function exp(x)

    def exp(self, z):
        '''Returns exp(z), the exponential function of z.'''
        z = self.t(z)
        return self.t(mp.exp(z))


# 3.1.2 Exponential function expj

    def expj(self, z):
        '''Returns expj(z) = cos(z) + i * sin(z).'''
        z = self.t(z)
        return self.t(mp.expj(z))


# 3.1.3 Exponential function expjpi

    def expjpi(self, z):
        '''Returns expjpi(z) = cos(pi*z) + i * sin(pi*z).'''
        z = self.t(z)
        return mp.expjpi(z)


# 3.1.4 Exponential function with base 10,

    def exp10(self, z):
        '''Returns exp10(z) = exp(z*ln(10)).'''
        z = self.t(z)
        return mp.exp(z * mp.log(10))


# 3.1.5 Exponential function with base 2,

    def exp2(self, z):
        '''Returns exp2(z) = exp(z*ln(2)).'''
        z = self.t(z)
        return mp.exp(z * mp.log(2))


# 3.1.6 Auxiliary function exp(z) - 1

    def expm1(self, z):
        '''Returns expm1(z) = exp(z)-1, computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z)


# 3.1.7 Auxiliary function 10^z - 1

    def exp10m1(self, z):
        '''Returns exp10m1(z) = exp10(z)-1,
        computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z * mp.log(10))


# 3.1.8 Auxiliary function 2^z - 1

    def exp2m1(self, z):
        '''Returns exp2m1(z) = exp2(z)-1,
        computed accurately also for small z.'''
        z = self.t(z)
        return mp.expm1(z * mp.log(2))


# 3.1.9 Relative error exponential (exp(z) - 1)/z

    def exprel(self, z):
        '''Returns exprel(z) = (exp(z) - 1)/z, 1 for z == 0.'''
        z = self.t(z)
        if (z == 0):
            return 1
        else:
            return mp.expm1(z)/z


# 3.1.10 Auxiliary function logistic(z) = 1/(1+exp(-z))

    def logistic(self, z):
        '''Returns logistic(z) = 1/(1+exp(-z)).'''
        z = self.t(z)
        return 1 / (1 + mp.exp(-z))


# %%%  3.2 Logarithms and related functions

# 3.2.1 Logarithm with base b, log_b(x)

    def logb(self, z, b):
        '''Returns the base b logarithm of z, logb(z,b) = ln(z)/ln(b).'''
        z = self.t(z)
        b = self.t(b)
        return mp.log(z, b)


# 3.2.2 Natural logarithm ln(z)

    def ln(self, z):
        '''Returns the natural logarithm of z, ln(z) = log(z).'''
        z = self.t(z)
        return mp.ln(z)

    def log(self, z):
        '''Returns the natural logarithm of z, log(z) = ln(z).'''
        z = self.t(z)
        return mp.ln(z)


# 3.2.3 Auxiliary function log(z+1)

    def log1p(self, z):
        '''Returns log1p(z) = log(1+z) = ln(1+z), accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z)


# 3.2.4 Logarithm with base 10, log_10(z)

    def log10(self, z):
        '''Returns the base 10 logarithm of z, log10(z) = ln(z)/ln(10).'''
        z = self.t(z)
        return mp.log10(z)


# 3.2.5 Logarithm with base 2, log_2(z)

    def log2(self, z):
        '''Returns the base 2 logarithm of z, log2(z) = ln(z)/ln(2).'''
        z = self.t(z)
        return mp.log(z, 2)


# 3.2.6 Auxiliary function log(1 - exp(−|z|))

    def log1mexp(self, z):
        '''
        Returns log1mexp(z) = log(1 - exp(−|z|)),
        calculated in an accurate and efficient way.
        '''
        z = self.t(z)
        x = mp.fabs(z)
        if (mp.fabs(x) < 0.693):
            return mp.ln(-mp.expm1(-x))
        else:
            return mp.log1p(-mp.exp(-x))

        if (mp.fabs(z) > 0):
            return mp.ln(-mp.expm1(-z))
        else:
            return mp.log1p(-mp.exp(-z))


# 3.2.7 Auxiliary function log_2(1 + x)

    def log2p1(self, z):
        '''Returns log2p1(z) = mp.log1p(z) / mp.ln(2),
        accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z) / mp.ln(2)


# 3.2.8 Auxiliary function log10(1 + x)

    def log10p1(self, z):
        '''Returns log10p1(z) = mp.log1p(z) / mp.ln(10),
        accurate also for small z.'''
        z = self.t(z)
        return mp.log1p(z) / mp.ln(10)


# 3.2.9 Auxiliary function ln(1 − exp(x))

    def ln1mexp(self, z):
        '''
        Returns ln1mexp(z) = ln(-expm1(z)).
        For real input, the result is real-valued only for z < 0.
        '''
        z = self.t(z)
        return mp.ln(-mp.expm1(z))


# 3.2.10 Auxiliary function ln(1 + exp(x))

    def ln1pexp(self, z):
        '''Returns ln1pexp(z) = log1p(exp(z)).'''
        z = self.t(z)
        return mp.log1p(mp.exp(z))


# 3.2.11 Auxiliary function ln(1 + x) − x

    def ln1pmx(self, z):
        '''
        Returns ln1pmx(z) = log1p(z) - z, accurate also for -0.5 <= z <= 0.5.
        '''
        z = self.t(z)
        return mp.log1p(z) - z


# 3.2.12 Auxiliary function logit(x) = ln(x/(1-x))

    def logit(self, z):
        '''Returns logit(z) = ln(z/(1-z)), accurate also near x = 0.5.'''
        z = self.t(z)
        return mp.ln(z/(1-z))


# 3.2.13 Lambert W

    def lambertw(self, z, k=0):
        '''Returns lambertw(z), the Lambert W function z.'''
        z = self.t(z)
        k = int(k)
        return mp.lambertw(z, k)


# 3.2.14 Arithmetic-geometric mean (AGM)

    def agm(self, a, b=1):
        '''Returns agm(a, b), the Arithmetic-geometric mean of a and b.'''
        a = self.t(a)
        b = self.t(b)
        return mp.agm(a, b)


# %%%  3.3 Square, roots and power functions

# 3.3.1 Square, x^2

    def square(self, z):
        '''Returns square(z) = z * z.'''
        z = self.t(z)
        return z * z


# 3.3.2 Square root

    def sqrt(self, z):
        '''Returns sqrt(z), the square root of z.'''
        z = self.t(z)
        return mp.sqrt(z)


# 3.3.3 Reciprocal of the square root

    def rsqrt(self, z):
        '''Returns rsqrt(z),the reciprocal of the principal square root of z.'''
        z = self.t(z)
        return 1/mp.sqrt(z)


# 3.3.4 Auxiliary function sqtz(1+z) - 1

    def sqrt1pm1(self, z):
        '''Returns sqrt1pm1(z) = expm1(log1p(z)/2),
        accurate also for z near 0.'''
        z = self.t(z)
        return mp.expm1(mp.log1p(z)/2)


# 3.3.5 Cube root

    def cbrt(self, z):
        '''Returns cbrt(z), the cube root of z.'''
        z = self.t(z)
        return mp.cbrt(z)


# 3.3.6 Returns the cube root in a way which gives a negative real number
# for negative input (like surd)

    def cuberoot(self, z):
        '''
        Returns cuberoot(z), the cube root of z,  in a way which gives a
        negative real number for negative input (like surd).
        '''
        z = self.t(z)
        return mp.cbrt(z)


# 3.3.7 Nth root,

    def nthroot(self, z, n):
        '''Returns nthroot(z, n), the nth root of z.'''
        z = self.t(z)
        n = int(n)
        return mp.nthroot(z, n)


# 3.3.8 Unit roots

    def unitroot(self, k, n):
        '''Returns unitroot(z, n), the n unit roots of z.'''
        n = int(n)
        return mp.unitroots(n)


# 3.3.9 Hypotenuse

    def hypot(self, a, b):
        '''Returns hypot(a, b) = sqrt(a^2 + b^2).'''
        a = self.t(a)
        b = self.t(b)
        return mp.sqrt(a*a + b*b)


# 3.3.10 Power function


    def power(self, a, b):
        '''Returns power(a, b) = exp(b*log(a)).'''
        a = self.t(a)
        b = self.t(b)
        return mp.power(a, b)

    def pow(self, a, b):
        '''Returns pow(a, b) = exp(b*log(a)).'''
        a = self.t(a)
        b = self.t(b)
        return self.t(mp.power(a, b))
##        if isinstance(z, mp.mpf): return float(res)
##        return complex(res.real, res.imag)


# 3.3.11 Auxiliary function a^b - 1

    def powm1(self, a, b):
        '''
        Returns powm1(a, b) = a^b - 1 = exp(b*log(a)) - 1 = expm1(b*log(a)).,
        computed accurately also when a^b is very close to 1.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.powm1(a, b)


# 3.3.12 Auxiliary function (1+a)^b

    def pow1p(self, a, b):
        '''
        Returns pow1p(a, b) = (1+a)^b = exp(b*log(1+a)) = exp(b*logp1(a)).,
        computed accurately also when a is very close to 0.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.exp(b * mp.log1p(a))


# 3.3.13 Auxiliary function (1+a)^b - 1

    def pow1pm1(self, a, b):
        '''
        Returns pow1pm1(a, b) = (1+a)^b - 1 = expm1(b*logp1(a)).,
        computed accurately also when a is very close to 0
        or (1+a)^b is very close to 1.
        '''
        a = self.t(a)
        b = self.t(b)
        return mp.expm1(b * mp.log1p(a))


# 3.3.14 Fibonacci numbers

    def fibonacci(self, z):
        '''Returns fibonacci(z), the zth Fibonacci number, F(z).'''
        z = self.t(z)
        return mp.fibonacci(z)


# 3.3.15 Fibonacci polynomials

    def fibpoly(self, n, z):
        '''Returns fibpoly(n, z), the nth Fibonacci polynomial, F(n,z).'''
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (1/w) * (((z+w)/2)**n - ((z-w)/2)**n)


# 3.3.16 Lucas numbers

    def lucas(self, n):
        '''Returns lucas(z), the zth Lucas number, L(z).'''
        n = self.t(n)
        phi = self.phi
        return phi**n + (-phi)**(-n)


# 3.3.17 Lucas polynomials

    def lucaspoly(self, n, z):
        '''Returns lucaspoly(n, z), the nth Lucas polynomial, F(n,z).'''
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (((z+w)/2)**n + ((z-w)/2)**n)


# %%%  3.4 Trigonometric functions

# 3.4.1 Radians

    def radians(self, x):
        '''Converts the degree angle x to radians.'''
        return mp.radians(x)


# 3.4.2 Degrees

    def degrees(self, x):
        '''Converts the radian angle x to a degree angle.'''
        return mp.degrees(x)


# 3.4.3 Sine

    def sin(self, z):
        '''Returns the (circular) sine of z.'''
        z = self.t(z)
        return self.t(mp.sin(z))


# 3.4.4 Cosine

    def cos(self, z):
        '''Returns the (circular) cosine of z.'''
        z = self.t(z)
        return mp.cos(z)


# 3.4.5 Sine and cosine

    def sin_cos(self, z):
        '''Returns simultaneously the (circular) sine and cosine of z.'''
        z = self.t(z)
        return mp.sin(z), mp.cos(z)


# 3.4.6 Tangent

    def tan(self, z):
        '''Returns the (circular) tangent of z.'''
        z = self.t(z)
        return mp.tan(z)


# 3.4.7 Secant

    def sec(self, z):
        '''Returns the (circular) secant of z.'''
        z = self.t(z)
        return mp.sec(z)


# 3.4.8 Cosecant

    def csc(self, z):
        '''Returns the (circular) cosecant of z.'''
        z = self.t(z)
        return mp.csc(z)


# 3.4.9 Cotangent

    def cot(self, z):
        '''Returns the (circular) cotangent of z.'''
        z = self.t(z)
        return mp.cot(z)


# 3.4.10 Haversine function hav(z) = (1-cos(z))/2

    def hav(self, z):
        '''Returns the haversine function hav(z) = (1-cos(z))/2.'''
        z = self.t(z)
        t = mp.sin(0.5 * z)
        return t*t


# 3.4.11 Auxiliary function sinpi, sin(pi*x)

    def sinpi(self, z):
        '''Returns sinpi(z) = sin(pi*z).'''
        z = self.t(z)
        return mp.sinpi(z)


# 3.4.14 Auxiliary function cospi = cos(pi*z)

    def cospi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z)

    def tanpi(self, z):
        '''Returns tanpi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.sinpi(z)/mp.cospi(z)

    def cotpi(self, z):
        '''Returns cotpi(z) = cos(pi*z).'''
        z = self.t(z)
        return mp.cospi(z)/mp.sinpi(z)

    def cscpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / mp.sinpi(z)

    def secpi(self, z):
        '''Returns cospi(z) = cos(pi*z).'''
        z = self.t(z)
        return 1.0 / mp.cospi(z)


# 3.4.12 Cardinal sine, sinc(z) = sin(z)/z for z!=0; 1 for z==0

    def sinc(self, z):
        '''Returns the cardinal sine,
        sinc(z) = sin(z)/z for z!=0; 1 for z==0.'''
        z = self.t(z)
        return mp.sinc(z)


# 3.4.13 Auxiliary function sincpi(x) = sin(pi*z)/z for z!=0; 1 for z==0

    def sincpi(self, z):
        '''Returns sincpi(z) = sin(pi*z)/z for z!=0; 1 for z==0.'''
        z = self.t(z)
        return mp.sincpi(z)


# %%%  3.5 Hyperbolic functions

# 3.5.1 Hyperbolic Sine

    def sinh(self, z):
        '''Returns the hyperbolic sine of z, sinh(z).'''
        z = self.t(z)
        return mp.sinh(z)


# 3.5.2 Hyperbolic Cosine

    def cosh(self, z):
        '''Returns the hyperbolic cosine of z, cosh(z).'''
        z = self.t(z)
        return mp.cosh(z)


# 3.5.3 Hyperbolic Tangent

    def tanh(self, z):
        '''Returns the hyperbolic tangent of z, tanh(z).'''
        z = self.t(z)
        return mp.tanh(z)


# 3.5.4 Hyperbolic Secant

    def sech(self, z):
        '''Returns the hyperbolic secant of z, sech(z).'''
        z = self.t(z)
        return mp.sech(z)


# 3.5.5 Hyperbolic Cosecant

    def csch(self, z):
        '''Returns the hyperbolic cosecant of z, csch(z).'''
        z = self.t(z)
        return mp.csch(z)


# 3.5.6 Hyperbolic Cotangent

    def coth(self, z):
        '''Returns the hyperbolic cotangent of z, coth(z).'''
        z = self.t(z)
        return mp.coth(z)


# %%%  3.6 Inverse trigonometric functions

# 3.6.1 Inverse Sine

    def asin(self, z):
        '''Returns the inverse (circular) sine of z, asin(z).'''
        z = self.t(z)
        return mp.asin(z)


# 3.6.2 Inverse Cosine

    def acos(self, z):
        '''Returns the inverse (circular) cosine of z, acos(z).'''
        z = self.t(z)
        return mp.acos(z)


# 3.6.3 Inverse Tangent

    def atan(self, z):
        '''Returns the inverse (circular) tangent of z, atan(z).'''
        z = self.t(z)
        return mp.atan(z)


# 3.6.4 Inverse Tangent, 2 real arguments

    def atan2(self, x, y):
        '''
        Returns the inverse (circular) tangent of z, atan2(x,y),
        using to real arguments, x, and y.
        '''
        return mp.atan2(x, y)


# 3.6.5 Inverse Secant

    def asec(self, z):
        '''Returns the inverse (circular) secant of z, asec(z).'''
        z = self.t(z)
        return mp.asec(z)


# 3.6.6 Inverse Cosecant

    def acsc(self, z):
        '''Returns the inverse (circular) cosecant of z, acsc(z).'''
        z = self.t(z)
        return mp.acsc(z)


# 3.6.7 Inverse Cotangent

    def acot(self, z):
        '''Returns the inverse (circular) cosecant of z, acot(z).'''
        z = self.t(z)
        return mp.acot(z)


# 3.6.8 Gudermannian function gd(x) = asin(tanh(x))

    def gd(self, z):
        '''Returns the Gudermannian function gd(x) = asin(tanh(x)).'''
        z = self.t(z)
        return mp.asin(mp.tanh(z))


# 3.6.9 Inverse haversine function archav(z) = acos(1-2z) = 2*asin(sqrt(z))

    def archav(self, z):
        '''
        Returns the inverse haversine function
        archav(z) = acos(1-2z) = 2*asin(sqrt(z)).
        '''
        z = self.t(z)
        return 2*mp.asin(mp.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

# 3.7.1 Inverse Hyperbolic Sine

    def asinh(self, z):
        '''Returns the inverse hyperbolic sine of z, asinh(z).'''
        z = self.t(z)
        return mp.asinh(z)


# 3.7.2 Inverse Hyperbolic Cosine

    def acosh(self, z):
        '''Returns the inverse hyperbolic cosine of z, acosh(z).'''
        z = self.t(z)
        return mp.acosh(z)


# 3.7.3 Inverse Hyperbolic Tangent

    def atanh(self, z):
        '''Returns the inverse hyperbolic tangent of z, atanh(z).'''
        z = self.t(z)
        return mp.atanh(z)


# 3.7.4 Inverse Hyperbolic Secant

    def asech(self, z):
        '''Returns the inverse hyperbolic secant of z, asech(z).'''
        z = self.t(z)
        return mp.asech(z)


# 3.7.5 Inverse Hyperbolic Cosecant

    def acsch(self, z):
        '''Returns the inverse hyperbolic cosecant of z, acsch(z).'''
        z = self.t(z)
        return mp.acsch(z)


# 3.7.6 Inverse Hyperbolic Cotangent

    def acoth(self, z):
        '''Returns the inverse hyperbolic cotangent of z, acoth(z).'''
        z = self.t(z)
        return mp.acoth(z)


# 3.7.7 Inverse Gudermannian function arcgd(x) = atanh(sin(x))

    def arcgd(self, z):
        '''Returns the inverse Gudermannian function,
        arcgd(x) = atanh(sin(x)).'''
        z = self.t(z)
        return mp.atanh(mp.sin(z))


# %%%  3.8 Factorials and related functions

# 3.8.1 Factorial

    def factorial(self, z):
        '''Returns the factorial of z, z! = Gamma(z+1).'''
        z = self.t(z)
        return mp.factorial(z)


# 3.8.2 Binomial coefficient

    def binomial(self, n, k):
        '''Returns binomial(n, k), the binomial coefficient n!/(k!(n-k)!) .'''
        n = self.t(n)
        k = self.t(k)
        return mp.factorial(n) / (mp.factorial(k) * mp.factorial(n - k))

# 3.8.3 Multinomial coefficient
    def multinomial(self, n, k):
        '''NOT IMPLEMENTED.'''
        raise Exception("NOT IMPLEMENTED")


# 3.8.4 Rising factorial (Pochhammer symbol)

    def rf(self, z, n):
        '''Returns the rising factorial (or Pochhammer symbol).'''
        z = self.t(z)
        n = self.t(n)
        return mp.rf(z, n)


# 3.8.5 Falling factorial

    def ff(self, z, n):
        '''Returns the falling factorial.'''
        z = self.t(z)
        n = self.t(n)
        return mp.ff(z, n)


# 3.8.6 Double factorial

    def fac2(self, z):
        '''Returns the double factorial.'''
        z = self.t(z)
        return mp.fac2(z)


# %%%  3.9 Gamma function and related functions

# 3.9.1 Gamma function

    def gamma(self, z):
        '''Returns the Gamma function.'''
        z = self.t(z)
        return mp.gamma(z)


# 3.9.2 Reciprocal Gamma function

    def rgamma(self, z):
        '''Returns the Reciprocal Gamma function.'''
        z = self.t(z)
        return mp.rgamma(z)


# 3.9.3 Log-Gamma function

    def loggamma(self, z):
        '''Returns the Log-Gamma function.'''
        z = self.t(z)
        return mp.loggamma(z)


# 3.9.4 Beta function

    def beta(self, a, b):
        '''Returns the Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return mp.beta(a, b)


# 3.9.5 Log-Beta function

    def logbeta(self, a, b):
        '''Returns the Log-Beta function.'''
        a = self.t(a)
        b = self.t(b)
        return mp.ln(mp.beta(a, b))


# 3.9.6 Ratio of gamma functions

    def gamma_ratio(self, a, b):
        '''Returns the ratio of gamma functions.'''
        a = self.t(a)
        b = self.t(b)
        return mp.gamma(a) / mp.gamma(b)


# 3.9.7 Gamma-delta ratio

    def gamma_delta_ratio(self, a, delta):
        '''Returns the Gamma-delta ratio.'''
        a = self.t(a)
        delta = self.t(delta)
        return mp.gamma(a) / mp.gamma(a + delta)


# 3.9.8 Catalan function

    def catalan_c(self, z):
        '''Returns the Catalan function.'''
        z = self.t(z)
        t = mp.gamma(z+1)
        return mp.gamma(2*z+1) / ((z+1)*t*t)


# %% 04 Real scalar functions


# %%% 4.1 Error functions for real arguments

# 4.1.1 Error function erf

    def real_erf(self, x):
        '''Returns the Error function erf.'''
        x = self.t(x)
        return mp.erf(x)


# 4.1.2 Complementary error function erfc

    def real_erfc(self, x):
        '''Returns the Complementary error function erfc.'''
        x = self.t(x)
        return mp.erfc(x)


# 4.1.3 Inverse of the real error function

    def real_erfinv(self, prob):
        '''Returns the Inverse of the real error function.'''
        prob = self.t(prob)
        return mp.erfinv(prob)


# 4.1.4 Inverse of the real complementory error function

    def real_erfcinv(self, prob):
        '''Returns the Inverse of the real complementory error function.'''
        prob = self.t(prob)
        return mp.erfinv(1-prob)


# 4.1.5 Standard normal density function

    def ndens(self, z):
        '''Returns the Standard normal density function.'''
        z = self.t(z)
        a = mp.exp(-0.5*z*z)/mp.sqrt(2*mp.pi)
        return a


# 4.1.6 Standard normal cumulative distribution function

    def ndis(self, x):
        '''Returns the Standard normal cumulative distribution function.'''
        x = self.t(x)
        a = 0.5 * mp.erfc(-x/mp.sqrt(mp.mpf(2)))
        return a


# 4.1.7 Standard normal percentage point function

    def ndis_inv(self, q):
        '''Returns the Standard normal percentage point function.'''
        q = self.t(q)
        a = -mp.sqrt(2) * self.real_erfinv(2*q)
        return a

    def ndisx(self, L, R):
        '''Returns the Standard normal percentage point function.'''
        return ctxm.ndisx_erf(self, L, R)

    def cplxerfc(self, z):
        '''Returns the complex error function.'''
        z = self.t(z)
        x = self.real(z)
        if x < 0:
            y = -z
            return mp.erfc(y)
        else:
            return mp.erfc(z)

#    def cplxerfc2(self, z):
#        z = self.t(z)
#        res = arb().erfc(z)
#        res = self.t(res)
#        return res

    def cplxndis(self, z):
        '''Returns the complex standard normal percentage point function.'''
        # x = mp.mpf(x)
        z = self.t(z)
        a = 0.5 * self.cplxerfc(-z/mp.sqrt(mp.mpf(2)))
        return a

#    def cplxndis2(self, z):
#        #x = mp.mpf(x)
#        z = self.t(z)
#        x = 0.5 * arb().erfc(-z/mp.sqrt(mp.mpf(2)))
#        res = self.t(x)
#        return res


# %%% 4.2 Incomplete gamma functions for non-negative real arguments and
    # parameters


# 4.2.1 Real lower non-normalised incomplete gamma function

    def real_gamma_lower(self, a, x, **kwargs):
        '''Returns the Real lower non-normalised incomplete gamma function.'''
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.gamma(a)


# 4.2.2 Real upper non-normalised incomplete gamma function

    def real_gamma_upper(self, a, x, **kwargs):
        '''Returns the Real upper non-normalised incomplete gamma function.'''
        res = self.real_gamma_q(a, x, **kwargs)
        return res * self.gamma(a)


# 4.2.3 Real lower normalised incomplete gamma function

    def real_gamma_p(self, a, x, **kwargs):
        '''Returns the Real lower normalised incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return ctxm.real_gamma_p(self, a, x, **kwargs)


# 4.2.4 Real upper normalised incomplete gamma function

    def real_gamma_q(self, a, x, **kwargs):
        '''Returns the Real upper normalised incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return ctxm.real_gamma_q(self, a, x, **kwargs)


# 4.2.5 Tricomi’s entire incomplete gamma function

    def real_gamma_tricomi(self, a, x, **kwargs):
        '''Returns Tricomi’s entire incomplete gamma function.'''
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.power(x, -self.t(a))


# 4.2.6 Inverse of the real lower normalised incomplete gamma function

    def real_gamma_p_inv(self, a, p, **kwargs):
        '''Returns the Inverse of the real lower normalised incomplete gamma
        function.'''
        a = self.t(a)
        p = self.t(p)
        return ctxm.real_gamma_p_inv(self, a, p, **kwargs)


# 4.2.7 Inverse of the real upper normalised incomplete gamma function

    def real_gamma_q_inv(self, a, q, **kwargs):
        '''Returns the Inverse of the real upper normalised incomplete gamma
        function.'''
        a = self.t(a)
        q = self.t(q)
        return ctxm.real_gamma_q_inv(self, a, q, **kwargs)


# 4.2.8 Inverse (on parameter a) of the real lower normalised incomplete
    # gamma function

    def real_gamma_p_inva(self, x, prob, **kwargs):
        '''Inverse (on parameter a) of the real lower normalised incomplete
        gamma function.'''
        x = self.t(x)
        prob = self.t(prob)
        return ctxm.real_gamma_p_inva(self, x, prob, **kwargs)


# 4.2.9 Inverse (on parameter a) of the real upper normalised incomplete
    # gamma function

    def real_gamma_q_inva(self, x, prob, **kwargs):
        '''Returns the Inverse (on parameter a) of the real upper normalised
        incomplete gamma function.'''
        x = self.t(x)
        prob = self.t(prob)
        return ctxm.real_gamma_q_inva(self, x, prob, **kwargs)


# 4.2.10 Derivative of the incomplete gamma function

    def real_gamma_derivative(self, a, x):
        '''Returns the Derivative of the incomplete gamma function.'''
        a = self.t(a)
        x = self.t(x)
        return self.exp(-x) * self.power(x, a-1) / self.gamma(a)


# %%%  4.3 Incomplete beta functions for non-negative real arguments and
    # parameters

# 4.3.1 Non-normalised incomplete beta function

    def real_beta3(self, a, b, x, **kwargs):
        '''Returns the Non-normalised incomplete beta function.'''
        res = self.real_ibeta(a, b, x, **kwargs)
        return res * self.beta(a, b)


# 4.3.2 Non-normalised complement of the incomplete beta function

    def real_betac(self, a, b, x, **kwargs):
        '''Returns the Non-normalised complement of the incomplete beta
        function.'''
        res = self.real_ibetac(a, b, x, **kwargs)
        return res * self.beta(a, b)


# 4.3.3 Normalised incomplete beta function

    def real_ibeta(self, a, b, x, **kwargs):
        '''Returns the Normalised incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return ctxm.real_ibeta(self, a, b, x, **kwargs)


# 4.3.4 Normalised complementory incomplete beta function

    def real_ibetac(self, a, b, x, **kwargs):
        '''Returns the Normalised complementory incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return ctxm.real_ibetac(self, a, b, x, **kwargs)


# 4.3.5 Inverse of the real normalised incomplete beta function

    def real_ibeta_inv(self, a, b, prob, **kwargs):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibeta_inv(self, a, b, prob, **kwargs)

    def betadisx(self, LeftTail, Righttail, a, b, **kwargs):
        '''Returns the Inverse of the real normalised incomplete beta
        function.'''
        a = self.t(a)
        b = self.t(b)
        LeftTail = self.t(LeftTail)
        x = ctxm.real_ibeta_inv(self, a, b, LeftTail, **kwargs)
        return x, 1-x


# 4.3.6 Inverse of the real normalised complementary incomplete beta function

    def real_ibetac_inv(self, a, b, prob, **kwargs):
        '''Returns the IInverse of the real normalised complementary incomplete
        beta function.'''
        a = self.t(a)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibetac_inv(self, a, b, prob, **kwargs)


# 4.3.7 Inverse (on parameter a) of the normalised incomplete beta function

    def real_ibeta_inva(self, b, x, prob, **kwargs):
        '''Returns the Inverse (on parameter a) of the normalised incomplete
        beta function.'''
        x = self.t(x)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibeta_inva(self, b, x, prob, **kwargs)


# 4.3.8 Inverse (on parameter a) of the normalised complementary incomplete
    # beta function

    def real_ibetac_inva(self, b, x, prob, **kwargs):
        '''Returns the Inverse (on parameter a) of the normalised complementary
        incomplete beta function.'''
        x = self.t(x)
        b = self.t(b)
        prob = self.t(prob)
        return ctxm.real_ibetac_inva(self, b, x, prob, **kwargs)


# 4.3.9 Inverse (on parameter b) of the normalised incomplete beta function

    def real_ibeta_invb(self, a, x, prob, **kwargs):
        '''Returns the Inverse (on parameter b) of the normalised incomplete
        beta function.'''
        x = self.t(x)
        a = self.t(a)
        prob = self.t(prob)
        return ctxm.real_ibeta_invb(self, a, x, prob, **kwargs)


# 4.3.10 Inverse (on parameter b) of the normalised complementary incomplete
    # beta function

    def real_ibetac_invb(self, a, x, prob, **kwargs):
        '''Returns the Inverse (on parameter b) of the normalised complementary
        incomplete beta function.'''
        x = self.t(x)
        a = self.t(a)
        prob = self.t(prob)
        return ctxm.real_ibetac_invb(self, a, x, prob, **kwargs)


# 4.3.11 Derivative of the incomplete beta function

    def real_ibeta_derivative(self, a, b, x):
        '''Returns the Derivative of the incomplete beta function.'''
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)

    def betadis(self, a, b, q, p):
        '''Returns the incomplete beta function (L, R).'''
        L, R = ctxm.betadis(self, a, b, q, p)
        return L, R

    def betadis3(self, a, b, q, p):
        '''Returns the incomplete beta function (L, R, density).'''
        L, R, density = ctxm.betadis3(self, a, b, q, p)
        return L, R, density



# %% 05 Numerical calculus

# %%%  14.1 Polynomials

# 14.1.1 Polynomial evaluation

    def polyval(self, coeffs, x, derivative=False):
        '''Returns the value of a polynomial with coefficients coeff at x'''
        res = mp.polyval(coeffs, x, derivative)
        return res

# 14.1.2 Polynomial roots
    def polyroots(self, coeffs, maxsteps=50, cleanup=True, extraprec=10,
                  error=False, roots_init=None):
        '''Computes all roots (real or complex) of a given polynomial'''
        res = mp.polyroots(coeffs, maxsteps, cleanup, extraprec, error,
                           roots_init)
        return res


# %%%  14.2 Rootfinder

# 14.2.1 Root-finding

    def findroot(self, f, x0, solver='secant', tol=None, verbose=False,
                 verify=True, **kwargs):
        '''Find a solution to 𝑓(𝑥) = 0, using x0 as starting point or
        interval for x.'''
        res = mp.findroot(f, x0, solver, tol, verbose, verify, **kwargs)
        return res


# 14.2.2 Newton

# 14.2.3 Secant

# 14.2.4 MNewton

# 14.2.5 Halley

# 14.2.6 Muller

# 14.2.7 Bisection

# 14.2.8 Illinois

# 14.2.9 Pegasus

# 14.2.10 Anderson

# 14.2.11 Ridder

# 14.2.12 MDNewton

# 14.2.13 Multiplicity of roots

# 14.2.14 Steffensen acceleration

# 14.2.15 Jacobian Matrix


# %%%  14.3 Sums, products, limits and extrapolation

# 14.3.1 Summation of infinite series

    def nsum(self, f, *intervals, **options):
        '''Summation of infinite series'''
        res = mp.nsum(f, *intervals, **options)
        return res


# 14.3.2 Summation using the Euler-Maclaurin formula

    def sumem(self, f, interval, tol=None, reject=10, integral=None,
              adiffs=None, bdiffs=None, verbose=False, error=False,
              _fast_abort=False):
        '''Summation using the Euler-Maclaurin formula'''
        res = mp.sumem(f, interval, tol, reject, integral, adiffs, bdiffs,
                       verbose, error, _fast_abort)
        return res


# 14.3.3 Summation using the Abel-Plana formula

    def sumap(self, f, interval, integral=None, error=False):
        '''Summation using the Abel-Plana formula'''
        res = mp.sumap(f, interval, integral, error)
        return res


# 14.3.4 Products

    def nprod(self, f, interval, nsum=False, **kwargs):
        '''Products'''
        res = mp.nprod(f, interval, nsum, **kwargs)
        return res


# 14.3.5 Limits, general

    def limit(self, f, x, direction=1, exp=False, **kwargs):
        '''Limits, general'''
        res = mp.limit(f, x, direction, exp, **kwargs)
        return res


# 14.3.6 Richardson extrapolation

    def richardson(self, seq):
        '''Richardson extrapolation'''
        res = mp.richardson(seq)
        return res


# 14.3.7 Shanks extrapolation

    def shanks(self, seq, table=None, randomized=False):
        '''Shanks extrapolation'''
        res = mp.shanks(seq, table, randomized)
        return res


# 14.3.8 Levin extrapolation

    def levin(self, method='levin', variant='u'):
        '''Levin extrapolation'''
        res = mp.levin(method, variant)
        return res


# 14.3.9 Cohan alternating extrapolation

    def cohen_alt(self):
        '''Cohan alternating extrapolation'''
        res = mp.cohen_alt()
        return res


# %%%  14.4 Numerical differentiation and ordinary differential equations

# 14.4.1 Numerical derivatives

    def diff(self, f, x, n=1, **options):
        '''Numerical derivatives'''
        res = mp.diff(f, x, n, **options)
        return res


# 14.4.2 Nth derivative

    def diffs(self, f, x, n=None, **options):
        '''Nth derivative'''
        res = mp.diffs(f, x, n, **options)
        return res


# 14.4.3 Forward difference

# 14.4.4 Generating a sequence of derivatives


# 14.4.5 Composition of derivatives

    def diffs_prod(self, factors):
        '''Composition of derivatives'''
        res = mp.diffs_prod(factors)
        return res


# 14.4.6 Composition of exponential of derivatives

    def diffs_exp(self, fdiffs):
        '''Composition of exponential of derivatives'''
        res = mp.diffs_exp(fdiffs)
        return res


# 14.4.7 Fractional derivatives / differintegration

    def differint(self, f, x, n=1, x0=0):
        '''Fractional derivatives / differintegration'''
        res = mp.differint(f, x, n, x0)
        return res


# 14.4.8 Solving the ODE initial value problem

    def odefun(self, F, x0, y0, tol=None, degree=None, method='taylor',
               verbose=False):
        '''Solving the ODE initial value problem'''
        res = mp.odefun(F, x0, y0, tol, degree, method, verbose)
        return res


# %%%  14.5 Numerical integration

# 14.5.1 Standard quadrature

    def quad(self, f, *points, **kwargs):
        '''Solving the ODE initial value problem'''
        res = mp.quad(f, *points, **kwargs)
        return res


# 14.5.2 Doubly exponential quadrature

# 14.5.3 Gauss-Legendre quadrature


# 14.5.4 Quadrature with subdivision

    def quadsubdiv(self, f, interval, tol=None, maxintervals=None,  **kwargs):
        '''Quadrature with subdivision'''
        res = mp.quadsubdiv(f, interval, tol, maxintervals, **kwargs)
        return res


# 14.5.5 Quadrature of oscillatory functions

    def quadosc(self, f, interval, omega=None, period=None, zeros=None):
        '''Quadrature of oscillatory functions'''
        res = mp.quadosc(f, interval, omega, period, zeros)
        return res


# %%%  14.6 Numerical inverse Laplace transform

# 14.6.1 Standard inverse Laplace transform

    def invertlaplace(self, f, t, **kwargs):
        '''Standard inverse Laplace transform'''
        res = mp.invertlaplace(f, t, **kwargs)
        return res


# 14.6.2 Talbot method: inverse Laplace transform


# 14.6.3 Stehfest method: inverse Laplace transform


# 14.6.4 de Hoog, Knight, and Stokes method: inverse Laplace transform


# %%%  14.7 Function approximation


# 14.7.1 Taylor series

    def taylor(self, f, x, n, **options):
        '''Taylor series'''
        res = mp.taylor(f, x, n, **options)
        return res


# 14.7.2 Pade approximation

    def pade(self, a, L, M):
        '''Taylor series'''
        res = mp.pade(a, L, M)
        return res


# 14.7.3 Chebyshev approximation

    def chebyfit(self, f, interval, N, error=False):
        '''Taylor series'''
        res = mp.chebyfit(f, interval, N, error)
        return res


# 14.7.4 Fourier series

    def fourier(self, f, interval, N):
        '''Fourier series'''
        res = mp.fourier(f, interval, N)
        return res

# 14.7.5 Fourier series evaluation
    def fourierval(self, series, interval, x):
        '''Fourier series evaluation'''
        res = mp.fourierval(series, interval, x)
        return res


# %%%  14.8 Number identification


# 14.8.1 Constant recognition

    def pslq(self, x, tol=None, maxcoeff=1000, maxsteps=100, verbose=False):
        '''Constant recognition'''
        res = mp.pslq(x, tol, maxcoeff, maxsteps, verbose)
        return res


# 14.8.2 Algebraic identification

    def findpoly(self, x, n=1, **kwargs):
        '''Algebraic identification'''
        res = mp.findpoly(x, n, **kwargs)
        return res


# 14.8.3 Integer relations (PSLQ)

    def identify(self, x, constants=[], tol=None, maxcoeff=1000, full=False,
                 verbose=False):
        '''Integer relations (PSLQ)'''
        res = mp.identify(x, constants, tol, maxcoeff, full, verbose)
        return res





# %% 06 Inferential statistics



# %%%  06.1 Tests for 1 sample


    def stats_tests_1sample(self):
        return ctx_stats_tests_1sample(self)



# %%%  06.2 Tests for 2 independent samples


    def stats_tests_2_independent_samples(self):
        return ctx_stats_tests_2_independent_samples(self)




# %%%  06.3 Tests for 2 correlated samples


    def stats_tests_2_correlated_samples(self):
        return ctx_stats_tests_2_correlated_samples(self)




# %%%  06.4 Anova and MCP


    def stats_tests_anova(self):
        return ctx_stats_tests_anova(self)



# %%%  06.5 Nonparametric tests


    def stats_nonparametric_tests(self):
        return ctx_stats_nonparametric_tests(self)



# %%%  06.6 Multivariate tests


    def stats_multivariate_tests(self):
        return ctx_stats_multivariate_tests(self)









# %% 13 Descriptive statistics and matrix algebra


# %%%  13.1 Matrix functions: decompositions for linear solving


# 13.1.4 Creating a matrix as a dictionary

    def matrix(self, r, c=1):
        '''Creates  a matrix as a dictionary'''
        return mp.matrix(r, c)

    def mat_t(self, m, n):
        '''Creates  a matrix as a dictionary'''
        matA = mp.matrix(m, n)
        return matA

    def mat_show(self, matA, title="mat"):
        '''Prints a matrix'''
        for i in range(matA.rows):
            for j in range(matA.cols):
                x = matA[i, j]
                print(title+"[" + str(i) + "," + str(j)+"]: ", x)
            print()


# 13.1.5 Creating an identity matrix as a dictionary

    def eye(self, m):
        '''Creates an identity matrix as a dictionary'''
        matA = mp.eye(m)
        return matA

    def mat_identity(self, m):
        '''Creates an identity matrix as a dictionary'''
        matA = mp.eye(m)
        return matA


# 13.1.6 Creating a diagonal matrix as a dictionary

    def diag(self, vecA):
        '''Creates a diagonal matrix as a dictionary'''
        return mp.diag(vecA)


# 13.1.7 Creating a matrix of zeros as a dictionary

    def mat_zeros(self, m, n):
        '''Creates a matrix of zeros as a dictionary'''
        matA = mp.zeros(m, n)
        return matA

    def zeros(self, *args, **kwargs):
        '''Creates a matrix of zeros as a dictionary'''
        matA = mp.zeros(*args, **kwargs)
        return matA


# 13.1.8 Creating a matrix of ones as a dictionary

    def mat_ones(self, m, n):
        '''Creates a matrix of ones as a dictionary'''
        matA = mp.ones(m, n)
        return matA

    def ones(self, *args, **kwargs):
        '''Creates a matrix of ones as a dictionary'''
        matA = mp.ones(*args, **kwargs)
        return matA

    def mat_constant(self, m, n, coeff):
        '''Creates a matrix of a constant as a dictionary'''
        matA = mp.ones(m, n)
        matA = matA * coeff
        return matA


# 13.1.9 Creating a Hilbert matrix as a dictionary

    def hilbert(self, n):
        '''Creates a Hilbert matrix as a dictionary'''
        matA = mp.hilbert(n)
        return matA


# 13.1.10 Creating a random matrix as a dictionary

    def randmatrix(self, m, n):
        '''Creates a random matrix as a dictionary'''
        return mp.randmatrix(m, n)

    def mat_random(self, m, n):
        '''Creates a random matrix as a dictionary'''
        matA = mp.randmatrix(m, n)
        matB = mp.zeros(m, n)
        for i in range(m):
            for j in range(n):
                matB[i, j] = mp.mpf(matA[i, j])
        return matB

    def mat_random_complex(self, m, n):
        '''Creates a random matrix as a dictionary'''
        matA = self.mat_random(m, n) + self.mat_random(m, n) * 1j
        return matA


# 13.1.11 Swap of rows in a mpmath matrix


# 13.1.12 Extending a mpmath matrix by another column


# 13.1.13 Unit vectors

    def unitvector(self, n, i):
        '''Creates a unit vector as a dictionary'''
        return mp.unitvector(n, i)


# %%%  13.2 Methods and arithmetic operators of a mpmath matrix

# this functionality is already built in


# %%%  13.3 Norms


# 13.3.1 Vector norm of a matrix

    def norm(self, x, p=2):
        '''Returns the vector norm of a matrix'''
        return mp.norm(x, p)


# 13.3.2 Matrix norm

    def mnorm(self, A, p=1):
        '''Returns the matrix norm of a matrix'''
        return mp.mnorm(A, p=1)


# %%%  13.4 Cholesky Decomposition without Pivoting


# 13.4.1 Cholesky decomposition

    def cholesky(self, A, tol=None):
        '''Returns the Cholesky decomposition of a matrix'''
        return mp.cholesky(A, tol=None)


# 13.4.2 Cholesky decomposition, solve

    def cholesky_solve(self, A, b, **kwargs):
        '''Returns the Cholesky decomposition of a matrix, with solve'''
        return mp.cholesky_solve(A, b, **kwargs)


# %%%  13.5 LU Decomposition with partial Pivoting


# 13.5.1 Matrix LU factorization

    def lu(ctx, A):
        '''Returns the LU factorization of a matrix'''
        return mp.lu(A)


# 13.5.2 Determinant of a matrix, using LU decomposition

    def det(self, matA):   # uses  lu decomposition
        '''Returns the determinant of a matrix, using LU decomposition'''
        return mp.det(matA)


# 13.5.3 Inverse of a matrix, using the LU factorization

    def inverse(self, A, **kwargs):   # uses  lu decomposition
        '''Returns Inverse of a matrix, using the LU factorization'''
        return mp.inverse(A, **kwargs)


# 13.5.4 Linear equations: LU solve

    def lu_solve(ctx, A, b, **kwargs):
        '''LU factorization of a matrix, Linear equations: LU solve'''
        return mp.lu_solve(A, b, **kwargs)

    def lu_solve_mat(self, a, b):   # uses  lu decomposition
        '''LU factorization of a matrix, Linear equations: LU solve'''
        return mp.lu_solve_mat(a, b)


# 13.5.5 Linear equations: residual of LU solve

    def residual(self, A, x, b, **kwargs):
        '''LU factorization of a matrix, Linear equations:
        residual of LU solve'''
        return mp.residual(A, x, b, **kwargs)


# 13.5.6 Linear equations: LU improve solution

    def improve_solution(ctx, A, x, b, maxsteps=1):
        '''LU factorization of a matrix, Linear equations:
        LU improve solution'''
        return mp.improve_solution(A, x, b, maxsteps=1)


# 13.5.7 Linear equations: LU condition number

    def cond(self, A, norm=None):   # uses  lu decomposition
        '''LU factorization of a matrix, Linear equations:
        LU improve solution'''
        return mp.cond(A, norm)


# %%%  13.6 QR Decomposition without Pivoting


# 13.6.1 QR factorization

    def qr(self, A, mode='full', edps=10):
        '''Returns the QR factorization of a matrix'''
        return mp.qr(A, mode, edps)

# 13.6.2 QR solve
    def qr_solve(self, A, b, norm=None, **kwargs):
        '''Returns the QR factorization of a matrix, solve'''
        return mp.qr_solve(A, b, norm, **kwargs)


# %%%  13.7 Singular Value Decomposition, singular values and full
    # singular vectors


# 13.7.1 Real singular value decomposition of a matrix A

    def svd_r(self, A, full_matrices=False, compute_uv=True,
              overwrite_a=False):
        '''Returns the singular value decomposition of a real matrix'''
        return mp.svd_r(A, full_matrices, compute_uv, overwrite_a)


# 13.7.2 Complex singular value decomposition of a matrix A

    def svd_c(self, A, full_matrices=False, compute_uv=True,
              overwrite_a=False):
        '''Returns the singular value decomposition of a complex matrix'''
        return mp.svd_c(A, full_matrices, compute_uv, overwrite_a)


# 13.7.3 Singular value decomposition of a matrix A (real or complex)

    def svd(self, A, full_matrices=False, compute_uv=True,
            overwrite_a=False):
        '''Returns the singular value decomposition of a real or
        complex matrix'''
        return mp.svd(A, full_matrices, compute_uv, overwrite_a)


# %%%  13.8 Symmetric/Hermitian Eigensystem


# 13.8.1 Eigenvalue problem for a real symmetric square matrix A

    def eigsy(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a real symmetric
        square matrix'''
        return mp.eigsy(A, eigvals_only, overwrite_a)


# 13.8.2 Eigenvalue problem for a complex hermitian square matrix A

    def eighe(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a complex hermitian
        square matrix'''
        return mp.eighe(A, eigvals_only, overwrite_a)


# 13.8.3 mpmath: Eigenvalue problem for a selfadjoint square matrix A

    def eigh(self, A, eigvals_only=False, overwrite_a=False):
        '''Returns the eigen value decomposition of a complex hermitian
        square matrix'''
        return mp.eigh(A, eigvals_only, overwrite_a)


# %%%  13.9 TODO: Tridiagonalization


# 13.9.1 mpmath: tridiag_sym

    def r_sy_tridiag(self, A, D, E, calc_ev=True):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(A, D, E, calc_ev=True)


# 13.9.2 mpmath tridiag_her

    def c_he_tridiag_0(self, A, D, E, T):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(A, D, E, T)


# 13.9.3 mpmath: tridiag_eigen_sym

    def tridiag_eigen(self, d, e, z=False):
        '''Returns the tridiagonal decomposition of a selfadjoint matrix'''
        return mp.tridiag_eigen(d, e, z=False)


# %%%  13.10 Eigensystem of a general square matrix


# 13.10.1 Eigensystem decomposition of a matrix A (real or complex)

    def eig(self, A, left=False, right=True, overwrite_a=False):
        '''Returns the eigen value decomposition of a real or complex
        square matrix'''
        return mp.eig(A, left, right, overwrite_a)


# 13.10.2 Sorting Eigenvalues

    def eig_sort(self, E, EL=False, ER=False, f="real"):
        '''sorts the eigenvalues and eigenvectors delivered by eig.'''
        return mp.eig_sort(E, EL, ER, f)


# %%%  13.11 Hessenberg and Schur decompositions


# 13.11.1 Hessenberg decomposition of a matrix A (real or complex)

    def hessenberg(self, A, overwrite_a=False):
        '''Returns the Hessenberg decomposition of a real or complex
        square matrix'''
        return mp.hessenberg(A, overwrite_a)


# 13.11.2 Schur decomposition of a matrix A (real or complex)

    def schur(self, A, overwrite_a=False):
        '''Returns the Schur decomposition of a real or complex
        square matrix'''
        return mp.schur(A, overwrite_a)


# %%%  13.12 Analytic functions of a matrix (using mpmath or Arb)

# 13.12.1 Matrix Exponential

    def expm(self, A, method='taylor'):
        '''Returns the matrix exponential of a square matrix'''
        return mp.expm(A, method)


# 13.12.2 Matrix Sine

    def sinm(self, A):
        '''Returns the matrix sine of a square matrix'''
        return mp.sinm(A)


# 13.12.3 Matrix Cosine

    def cosm(self, A):
        '''Returns the matrix Cosine of a square matrix'''
        return mp.cosm(A)


# 13.12.6 Matrix Square Root

    def sqrtm(self, A, _may_rotate=2):
        '''Returns the matrix Square Root of a square matrix'''
        return mp.sqrtm(A, _may_rotate)


# 13.12.7 Matrix Logarithm

    def logm(self, A):
        '''Returns the matrix Logarithm of a square matrix'''
        return mp.logm(A)


# 13.12.8 Matrix power

    def powm(self, A, r):
        '''Returns the matrix power of a square matrix'''
        return mp.powm(A, r)


# %% 07 Inferential statistics

# %%%  15.1 Transformations of raw data

# %%%  15.2 Descriptive Statistics

# %%%  15.3 Descriptive statistical functions: real matrices

# %%%  15.4 Basic classical statistical tests (stratified)

# %%%  15.5 Nonparametric statistical tests

# %%%  15.6 Multivariate statistical tests




# %% 08 Elliptic functions and integrals

# %%%  16.1 Conversions of parameters of elliptic functions

# 16.1.1 Elliptic nome q

    def qfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic nome q'''
        return mp.qfrom(q, m, k, tau, qbar)

# 16.1.2 Number-theoretic nome qbar

    def qbarfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Number-theoretic nome qbar'''
        return mp.qbarfrom(q, m, k, tau, qbar)

# 16.1.3 Elliptic parameter m

    def mfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic parameter m'''
        return mp.mfrom(q, m, k, tau, qbar)

# 16.1.4 Elliptic modulus k

    def kfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''
        return mp.kfrom(q, m, k, tau, qbar)

# 16.1.5 Elliptic half-period ratio tau

    def taufrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        '''Elliptic modulus k'''
        return mp.taufrom(q, m, k, tau, qbar)

# 16.1.6 Elliptic lattice roots

# 16.1.7 Elliptic lattice invariants



# %%%  16.2 Legendre elliptic integrals

# 16.2.1 Elliptic integrals overview


# 16.2.2 Legendre complete elliptic integral of the first kind, 𝐾(m)

    def melliptic_k(self, m):
        '''Legendre complete elliptic integral of the first kind, 𝐾(m)'''
        m = self.t(m)
        return mp.ellipk(m)

# 16.2.3 Legendre complete elliptic integral of the second kind, 𝐸(m)

    def melliptic_e(self, m):
        '''Legendre complete elliptic integral of the second kind, 𝐸(m)'''
        m = self.t(m)
        return mp.ellipe(m)

# 16.2.4 Legendre complete elliptic integral of the third kind, Π(𝑛, m)

    def melliptic_pi(self, n, m):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, m)'''
        n = self.t(n)
        m = self.t(m)
        return mp.ellippi(n, m)

# 16.2.5 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)

    def melliptic_f(self, phi, m):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellipf(phi, m)

# 16.2.6 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)

    def melliptic_e_inc(self, phi, m):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, m)'''
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellipe(phi, m)

# 16.2.7 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, m)

    def melliptic_pi_inc(self, n, phi, m):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(m)
        return mp.ellippi(n, phi, m)


# 16.2.2 Legendre complete elliptic integral of the first kind, 𝐾(𝑘)

    def elliptic_k(self, k):
        '''Legendre complete elliptic integral of the first kind, 𝐾(𝑘)'''
        m = self.t(k); m = m*m
        return mp.ellipk(m)

# 16.2.3 Legendre complete elliptic integral of the second kind, 𝐸(𝑘)

    def elliptic_e(self, k):
        '''Legendre complete elliptic integral of the second kind, 𝐸(𝑘)'''
        m = self.t(k); m = m*m
        return mp.ellipe(m)

# 16.2.4 Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)

    def elliptic_pi(self, n, k):
        '''Legendre complete elliptic integral of the third kind, Π(𝑛, 𝑘)'''
        n = self.t(n)
        m = self.t(k); m = m*m
        return mp.ellippi(n, m)

# 16.2.5 Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)

    def elliptic_f(self, phi, k):
        '''Legendre incomplete elliptic integral of the first kind, 𝐹(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellipf(phi, m)

# 16.2.6 Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)

    def elliptic_e_inc(self, phi, k):
        '''Legendre incomplete elliptic integral of the second kind, 𝐸(𝜑, 𝑘)'''
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellipe(phi, m)

# 16.2.7 Legendre incomplete elliptic integral of the third kind, Π(𝑛, 𝜑, 𝑘)

    def elliptic_pi_inc(self, n, phi, k):
        '''Legendre incomplete elliptic integral of the third kind,
         Π(𝑛, 𝜑, 𝑘)'''
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(k); m = m*m
        return mp.ellippi(n, phi, m)


# 16.2.8 Incomplete elliptic integral D (Legendre Form), 𝐷(𝜑, 𝑘)


# 16.2.9 Jacobi Zeta function, 𝑍(𝜑, 𝑘)

    def jacobi_zeta(self, phi, k):
        '''Jacobi Zeta function, 𝑍(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k);
        return self.elliptic_e_inc(phi, k)
        - (self.elliptic_e(k)*self.elliptic_f(phi, k)) / self.elliptic_k(k)

# 16.2.10 Heuman’s Lambda function, Λ(𝜑, 𝑘)

    def heuman_lambda(self, phi, k):
        '''Heuman’s Lambda function, Λ(𝜑, 𝑘)'''
        phi = self.t(phi)
        k = self.t(k); k1 = self.sqrt(1-k*k)
        res = self.elliptic_f(phi, k1)/self.elliptic_k(k1)
        res = res + 2*self.elliptic_k(k) * self.jacobi_zeta(phi, k1)/self.pi()
        return res


# %%%  16.3 Carlson symmetric elliptic integrals

# 16.3.1 Carlson symmetric elliptic integral of the first kind, 𝑅𝐹 (𝑥, 𝑦, 𝑧)

    def elliprf(self, x, y, z):
        '''Carlson symmetric elliptic integral of the first kind,
        𝑅𝐹 (𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprf(x, y, z)

# 16.3.2 Carlson completely symmetric elliptic integral of the second kind,
    # 𝑅𝐺(𝑥, 𝑦, 𝑧)

    def elliprg(self, x, y, z):
        '''Carlson completely symmetric elliptic integral of the second kind,
        𝑅𝐺(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprg(x, y, z)

# 16.3.3 Carlson symmetric elliptic integral of the third kind, 𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)

    def elliprj(self, x, y, z, p):
        '''Carlson symmetric elliptic integral of the third kind,
        𝑅𝐽 (𝑥, 𝑦, 𝑧, 𝑝)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        p = self.t(p)
        return mp.elliprj(x, y, z, p)

# 16.3.4 Carlson symmetric elliptic integral of the second kind, 𝑅𝐷(𝑥, 𝑦, 𝑧)

    def elliprd(self, x, y, z):
        '''Carlson symmetric elliptic integral of the second kind,
        𝑅𝐷(𝑥, 𝑦, 𝑧)'''
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return mp.elliprd(x, y, z)

# 16.3.5 Carlson degenerate symmetric elliptic integral of the first kind,
    # 𝑅𝐶(𝑥, 𝑦)

    def elliprc(self, x, y):
        '''Carlson degenerate symmetric elliptic integral of the first kind,
        𝑅𝐶(𝑥, 𝑦)'''
        x = self.t(x)
        y = self.t(y)
        return mp.elliprc(x, y)


# %%%  16.4 Jacobi elliptic functions

# 16.4.1 Jacobi elliptic functions, general form

    def ellipfun(self, kind, u=None, m=None, q=None, k=None, tau=None):
        '''Jacobi elliptic functions, general form'''
        return mp.ellipfun(kind, u, m, q, k, tau)

# 16.4.2 Jacobi elliptic function sn

    def jacobi_sn(self, u, k):
        '''Jacobi elliptic function sn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sn', u, k=k)

# 16.4.3 Jacobi elliptic function cn

    def jacobi_cn(self, u, k):
        '''Jacobi elliptic function cn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cn', u, k=k)

# 16.4.4 Jacobi elliptic function dn

    def jacobi_dn(self, u, k):
        '''Jacobi elliptic function dn'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('dn', u, k=k)

# 16.4.5 Jacobi elliptic function ns

    def jacobi_ns(self, u, k):
        '''Jacobi elliptic function ns'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('ns', u, k=k)

# 16.4.6 Jacobi elliptic function nc

    def jacobi_nc(self, u, k):
        '''Jacobi elliptic function nc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('nc', u, k=k)

# 16.4.7 Jacobi elliptic function nd

    def jacobi_nd(self, u, k):
        '''Jacobi elliptic function nd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('nd', u, k=k)

# 16.4.8 Jacobi elliptic function sc

    def jacobi_sc(self, u, k):
        '''Jacobi elliptic function sc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sc', u, k=k)

# 16.4.9 Jacobi elliptic function sd

    def jacobi_sd(self, u, k):
        '''Jacobi elliptic function sd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('sd', u, k=k)

# 16.4.10 Jacobi elliptic function dc

    def jacobi_dc(self, u, k):
        '''Jacobi elliptic function dc'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('dc', u, k=k)

# 16.4.11 Jacobi elliptic function ds

    def jacobi_ds(self, u, k):
        '''Jacobi elliptic function ds'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('ds', u, k=k)

# 16.4.12 Jacobi elliptic function cs

    def jacobi_cs(self, u, k):
        '''Jacobi elliptic function cs'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cs', u, k=k)

# 16.4.13 Jacobi elliptic function cd

    def jacobi_cd(self, u, k):
        '''Jacobi elliptic function cd'''
        u = self.t(u)
        k = self.t(k)
        return mp.ellipfun('cd', u, k=k)


# %%%  16.5 Weierstrass elliptic functions

# 16.5.1 Weierstrass function ℘(𝑧, 𝜏 )

    def weierstrass_p(self, z, tau):
        '''Weierstrass function ℘(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t20 = self.jtheta(2, 0, q)
        t30 = self.jtheta(3, 0, q)
        t4z = self.jtheta(4, z, q)
        t1z = self.jtheta(1, z, q)
        res1 = p*p*t20*t20*t30*t30*t4z*t4z/(t1z*t1z)
        res2 = -p*p*(t20**4+t30**4)/3
        res = res1+res2
        res = mp.re(res)
        return res

# 16.5.2 Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )

    def weierstrass_p_prime(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        zp = z * p
        q = self.exp(1j * p * tau)
        t20 = self.jtheta(2, 0, q)
        t30 = self.jtheta(3, 0, q)
        res1 = p*p*t20*t20*t30*t30
        f = self.jtheta(4, zp, q)
        g = self.jtheta(1, zp, q)
        f1 = self.jtheta(4, zp, q, derivative=1)
        g1 = self.jtheta(1, zp, q, derivative=1)
        res2 = p*(2*f*(g*f1-f*g1))/(g*g*g)
        res = res1*res2
        res = mp.re(res)
        return res

    def weierstrass_p_prime_diff(self, z, tau):
        '''Weierstrass function, first derivative: ℘′(𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        res = mp.diff(lambda x: self.weierstrass_p(x, tau), z)
        return res


# 16.5.3 Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )

    def weierstrass_p_inv(self, z, tau):
        '''Inverse Weierstrass function ℘−1 (𝑧, 𝜏 )'''
        z = self.t(z)
        tau = self.t(tau)
        e1, e2, e3 = self.elliptic_roots(tau)
        res = self.elliprf(z-e1, z-e2, z-e3)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res


# 16.5.4 Weierstrass Zeta

    def weierstrass_zeta(self, z, tau):
        '''Weierstrass Zeta'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t10p1 = self.jtheta(1, 0, q, derivative=1)
        t10p3 = self.jtheta(1, 0, q, derivative=3)
        eta1 = -t10p3/t10p1 / 6
        t1zp1 = self.jtheta(1, z, q, derivative=1)
        t1z = self.jtheta(1, z, q)
        res = 2*eta1*z + t1zp1/t1z
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return p*res


# 16.5.5 Weierstrass Sigma

    def weierstrass_sigma(self, z, tau):
        '''Weierstrass Sigma'''
        z = self.t(z)
        tau = self.t(tau)
        p = self.pi()
        z = z * p
        q = self.exp(1j * p * tau)
        t10p1 = self.jtheta(1, 0, q, derivative=1)
        t10p3 = self.jtheta(1, 0, q, derivative=3)
        eta1 = -t10p3/t10p1 / 6
        t1z = self.jtheta(1, z, q)
        res = self.exp(eta1*z*z) * t1z/t10p1
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res/p


# %%%  16.6 Jacobi theta functions and related functions

# 16.6.1 Jacobi theta functions, general form

    def jtheta(self, n, z, q, derivative=0):
        '''Jacobi theta functions, general form'''
        n = int(n)
        z = self.t(z)
        q = self.t(q)
        return mp.jtheta(n, z, q, derivative)

# 16.6.2 Dedekind eta function

    def dedekind_eta(self, tau):
        '''Dedekind eta function'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        q = mp.qfrom(tau=tau)
        res = mp.jtheta(2, mp.pi()/6, pow(q*q, 1/6)) / mp.sqrt(3)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.3 Elliptic modular Lambda

    def modular_lambda(self, tau):
        '''Elliptic modular Lambda'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        q = mp.qfrom(tau=tau)
        t2 = self.jtheta(2, 0, q)
        t3 = self.jtheta(3, 0, q)
        res = (t2**4)/(t3**4)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.4 Elliptic modular Delta

    def modular_delta(self, tau):
        '''Elliptic modular Delta'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        res = (self.dedekind_eta(tau))**24
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.5 Klein j-invariant

    def kleinj(self, tau):
        '''Klein j-invariant'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        res = mp.kleinj(tau)
        if self.imag(res) == self.t(0):
            res = self.real(res)
        return res

# 16.6.6 Elliptic lattice roots in terms of Elliptic period ratio 𝜏

    def elliptic_roots(self, tau):
        '''Elliptic lattice roots in terms of Elliptic period ratio 𝜏'''
        tau = self.t(tau)
        if self.imag(tau) <= 0:
            raise Exception("imaginary part needs to be > 0")
        p = self.pi()
        q = self.exp(1j * p * tau)
        a = self.jtheta(2, 0, q)
        b = self.jtheta(3, 0, q)
        c = self.jtheta(4, 0, q)
        p = p*p/3
        a2 = a*a
        a4 = a2*a2
        b2 = b*b
        b4 = b2*b2
        c2 = c*c
        c4 = c2*c2
        e1 = p*(b4 + c4)
        e2 = p*(-a4 - b4)
        e3 = p*(a4 - c4)
        if self.imag(e1) == self.t(0):
            e1 = self.real(e1)
        if self.imag(e2) == self.t(0):
            e2 = self.real(e2)
        if self.imag(e3) == self.t(0):
            e3 = self.real(e3)
        return e1, e2, e3

# 16.6.7 Elliptic lattice invariants

    def elliptic_invariants(self, tau):
        '''Elliptic lattice invariants'''
        tau = self.t(tau)
        e1, e2, e3 = self.elliptic_roots(tau)
        g2 = 2*(e1*e1 + e2*e2 + e3*e3)
        g3 = 4*e1*e2*e3
        if self.imag(g2) == self.t(0):
            g2 = self.real(g2)
        if self.imag(g3) == self.t(0):
            g3 = self.real(g3)
        return g2, g3


# %% 09 Lerch’s transcendent and related functions

# %%%  17.1 Overview LERCH’S TRANSCENDENT, POLYGAMMA

# 17.1.1 Lerch’s transcendent

    def lerchphi(self, z, s, a):
        '''Lerch’s transcendent'''
        z = self.t(z)
        s = self.t(s)
        a = self.t(a)
        return mp.lerchphi(z, s, a)

# 17.1.2 Lerch’s zeta

    def lerch_zeta(self, lambda1, alpha, s):
        '''Lerch’s zeta'''
        lambda1 = self.t(lambda1)
        alpha = self.t(alpha)
        s = self.t(s)
        return mp.lerchphi(mp.exp(2*mp.pi()*1j*lambda1), s, alpha)


# %%%  17.2 Polygamma functions

# 17.2.1 Polygamma function 𝜓𝑚(𝑥)

    def psi(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        return mp.psi(m, z)

    def polygamma(self, m, z):
        '''Polygamma function 𝜓𝑚(𝑥)'''
        m = self.t(m)
        z = self.t(z)
        return mp.psi(m, z)

# 17.2.2 TriGamma function 𝜓′(𝑥)

    def trigamma(self, z):
        '''TriGamma function 𝜓′(𝑥)'''
        z = self.t(z)
        return mp.psi(1, z)

# 17.2.3 DiGamma function 𝜓(𝑥)

    def digamma(self, z):
        '''DiGamma function 𝜓(𝑥)'''
        z = self.t(z)
        return mp.psi(0, z)


# %%%  17.3 Polylogarithms and related functions

# 17.3.1 Polylogarithm, Li𝑠(𝑧)

    def polylog(self, s, z):
        '''Polylogarithm, Li𝑠(𝑧)'''
        s = self.t(s)
        z = self.t(z)
        return mp.polylog(s, z)

# 17.3.2 Trilogarithm Function, Li3(𝑧)

    def trilog(self, z):
        '''Trilogarithm Function, Li3(𝑧)'''
        z = self.t(z)
        return mp.polylog(3, z)

# 17.3.3 Dilogarithm Function, Li2(𝑧)

    def dilog(self, z):
        '''Dilogarithm Function, Li2(𝑧)'''
        z = self.t(z)
        return mp.polylog(2, z)

# 17.3.4 Generalized Clausen sine function
    def clsin(self, s, z):
        '''Generalized Clausen sine function'''
        s = self.t(s)
        z = self.t(z)
        return mp.clsin(s, z)

# 17.3.5 Generalized Clausen cosine function

    def clcos(self, s, z):
        '''Generalized Clausen cosine function'''
        s = self.t(s)
        z = self.t(z)
        return mp.clcos(s, z)

# 17.3.6 Classical Clausen function

    def cl2(self, z):
        '''Classical Clausen function'''
        z = self.t(z)
        return self.clsin(2, z)

# 17.3.7 Bose-Einstein integrals of real order

    def bose_einstein(self, s, z, real4real=True):
        '''Bose-Einstein integrals of real order'''
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s+1, self.exp(z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.8 Fermi-Dirac integrals

    def fermi_dirac(self, s, z, real4real=True):
        '''Fermi-Dirac integrals'''
        s = self.t(s)
        z = self.t(z)
        res = -self.polylog(s+1, -self.exp(z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.9 Legendre’s chi function

    def legendre_chi(self, s, z, real4real=True):
        '''Legendre’s chi function'''
        s = self.t(s)
        z = self.t(z)
        res = 0.5 * (self.polylog(s, z) - self.polylog(s, -z))
        if mp.im(z) == mp.mpf(0) and real4real:
            res = mp.re(res)
        return res

# 17.3.10 Inverse tangent integral

    def ti(self, s, z):
        '''Inverse tangent integral'''
        s = self.t(s)
        z = self.t(z)
        res = (self.polylog(s, 1j*z) - self.polylog(s, -1j*z))
        res = res / (2j)
        if mp.im(z) == mp.mpf(0):
            res = mp.re(res)
        return res

# !!! Missing in documentation !!!

    def ti2(self, z):
        z = self.t(z)
        return self.ti(2, z)

# 17.3.11 Debye functions
    def debye(self, n, x):
        '''Debye functions'''
        return ctxm.debye(self, n, x)


# %%%  17.4 Hurwitz zeta function and related functions

# 17.4.1 Hurwitz zeta function

    def hurwitz(self, s, a, derivative=0):
        '''Hurwitz zeta function'''
        s = self.t(s)
        a = self.t(a)
        return mp.zeta(s, a, derivative)

# 17.4.2 Stieltjes constant

    def stieltjes(self, n, a=1):
        '''Stieltjes constant'''
        n = int(n)
        a = self.t(a)
        return mp.stieltjes(n, a)

# 17.4.3 Harmonic numbers

    def harmonic(self, z):
        '''Harmonic numbers'''
        z = self.t(z)
        return mp.harmonic(z)

# 17.4.4 Generalized harmonic number function

    def harmonic2(self, z, r):
        '''Generalized harmonic number function'''
        z = self.t(z)
        r = self.t(r)
        if r == mp.mpf(1):
            return self.harmonic(z)
        else:
            return mp.zeta(r) - mp.zeta(r, z + 1)

# 17.4.5 Bernoulli numbers

    def bernoulli(self, n):
        '''Bernoulli numbers'''
        n = int(n)
        return mp.bernoulli(n)

# 17.4.6 Bernoulli number as fraction

    def bernfrac(self, n):
        '''Bernoulli number as fraction'''
        n = int(n)
        return mp.bernfrac(n)

# 17.4.7 Bernoulli polynomials

    def bernpoly(self, n, z):
        '''Bernoulli polynomials'''
        n = int(n)
        z = self.t(z)
        return mp.bernpoly(n, z)

# 17.4.8 Euler numbers

    def eulernum(self, n):
        '''Euler numbers'''
        n = int(n)
        return mp.eulernum(n)

# 17.4.9 Euler polynomials

    def eulerpoly(self, n, z):
        '''Euler polynomials'''
        n = int(n)
        z = self.t(z)
        return mp.eulerpoly(n, z)

# 17.4.10 Logarithm of Barnes G function

    def lnbarnesg(self, z):
        '''Logarithm of Barnes G function'''
        z = self.t(z)
        return mp.ln(mp.barnesg(z))

# 17.4.11 Barnes G-function

    def barnesg(self, z):
        '''Barnes G-function'''
        z = self.t(z)
        return mp.barnesg(z)

# 17.4.12 Hyperfactorial

    def hyperfac(self, z):
        '''Hyperfactorial'''
        z = self.t(z)
        return mp.hyperfac(z)

# 17.4.13 Superfactorial

    def superfac(self, z):
        '''Superfactorial'''
        z = self.t(z)
        return mp.superfac(z)


# %%%  17.5 Dirichlet L series, Riemann zeta function and related functions

# 17.5.1 Dirichlet L-Series

    def dirichlet_l(self, s, chi, derivative=0):
        '''Dirichlet L-Series'''
        s = self.t(s)
        return mp.dirichlet(s, chi, derivative)

# 17.5.2 Riemann zeta function

    def zeta(self, s, derivative=0):
        '''Riemann zeta function'''
        s = self.t(s)
        return mp.zeta(s, 1, derivative)

# 17.5.3 Riemann 𝜁(𝑠) − 1

    def zetam1(self, s):
        '''Riemann 𝜁(𝑠) − 1'''
        s = self.t(s)
        return mp.zeta(s, 2)

# 17.5.4 Riemann (Landau) function 𝜉(𝑠)

    def riemann_xi(self, s):
        '''Riemann (Landau) function 𝜉(𝑠)'''
        s = self.t(s)
        res = 0.5*s*(s-1)*self.pi()**(-s/2)*self.gamma(s/2)
        res = res * self.zeta(s)
        return res

# 17.5.5 Dirichlet eta function

    def dirichlet_eta(self, s):
        '''Dirichlet eta function'''
        s = self.t(s)
        return mp.altzeta(s)

# 17.5.6 Dirichlet 𝜂(𝑠) − 1: etam1(s)

    def dirichlet_etam1(self, s):
        '''Dirichlet 𝜂(𝑠) − 1: etam1(s)'''
        s = self.t(s)
        return self.dirichlet_eta(s) - 1

# 17.5.7 Dirichlet Beta function

    def dirichlet_beta(self, s):
        '''Dirichlet Beta function'''
        s = self.t(s)
        return mp.power(4, -s) * (mp.zeta(s, 0.25) - mp.zeta(s, 0.75))

# 17.5.8 Dirichlet Lambda function

    def dirichlet_lambda(self, s):
        '''Dirichlet Lambda function'''
        s = self.t(s)
        # return (1 - mp.power(2, -s)) * mp.zeta(s)
        return -self.exp2m1(-s) * self.zeta(s)

# 17.5.9 Riemann-Siegel Z function

    def siegelz(self, t):
        '''Riemann-Siegel Z function'''
        t = self.t(t)
        return mp.siegelz(t)

# 17.5.10 Riemann-Siegel theta function

    def siegeltheta(self, t):
        '''Riemann-Siegel theta function'''
        t = self.t(t)
        return mp.siegeltheta(t)

# 17.5.11 Backlund S function

    def backlunds(self, t):
        '''Backlund S function'''
        t = self.t(t)
        return mp.backlunds(t)

# 17.5.12 Gram points

    def grampoint(self, n):
        '''Gram points'''
        n = int(n)
        return mp.grampoint(n)

# 17.5.13 Number of zeros of the Riemann zeta function

    def zetazero(self, n, verbose=False):
        '''Number of zeros of the Riemann zeta function'''
        n = int(n)
        return mp.zetazero(n, verbose)

# 17.5.14 Zeros of the Riemann zeta function

    def nzeros(self, t):
        '''Zeros of the Riemann zeta function'''
        t = self.t(t)
        res = mp.nzeros(t)
        res = self.t(res)
        return res

# 17.5.15 Secondary zeta function

    def secondzeta(self, s, a=0.015):
        '''Secondary zeta function'''
        s = self.t(s)
        a = self.t(a)
        return mp.secondzeta(s, a)


# %%%  17.6 Additional numbertheoretic functions

# 17.6.1 Prime counting function

    def primepi(self, x):
        '''Prime counting function'''
        return mp.primepi(x)

# 17.6.2 Mangoldt function

    def mangoldt(self, n):
        '''Mangoldt function'''
        return mp.mangoldt(n)

# 17.6.3 Riemann R function

    def riemannr(self, z):
        '''Riemann R function'''
        z = self.t(z)
        return mp.riemannr(z)

# 17.6.4 Prime zeta function

    def primezeta(self, s):
        '''Prime zeta function'''
        s = self.t(s)
        return mp.primezeta(s)

# 17.6.5 Mertens constant

    def mertens(self):
        '''Mertens constant'''
        return mp.mertens()

# 17.6.6 Twin prime constant

    def twinprime(self):
        '''Twin prime constant'''
        return mp.twinprime()

# 17.6.7 Cyclotomic polynomial

    def cyclotomic(self, n, x):
        '''Cyclotomic polynomial'''
        return mp.cyclotomic(n, x)

# 17.6.8 Stirling number of the first kind

    def stirling1(self, n, k, exact=False):
        '''Stirling number of the first kind'''
        return mp.stirling1(n, k, exact)

# 17.6.9 Stirling number of the second kind

    def stirling2(self, n, k, exact=False):
        '''Stirling number of the second kind'''
        return mp.stirling2(n, k, exact)

# 17.6.10 Bell (Touchard) polynomials

    def bell(self, n, x):
        '''Bell (Touchard) polynomials'''
        return mp.bell(n, x)

# 17.6.11 Polyexponential function

    def polyexp(self, s, z):
        '''Polyexponential function'''
        return mp.polyexp(s, z)


# %% 10 Hypergeometric Function 0_F_1 and related functions

# %%%  18.1 Overview

# 18.1.1 Confluent Hypergeometric Limit Function 0𝐹1

    def hyp0f1(self, a, z):
        '''Confluent Hypergeometric Limit Function 0𝐹1'''
        a = self.t(a)
        z = self.t(z)
        return mp.hyp0f1(a, z)

# 18.1.2 Regularized Confluent Hypergeometric Limit Function 0𝐹1

    def hyp0f1r(self, a, z):
        '''Regularized Confluent Hypergeometric Limit Function 0𝐹1'''
        a = self.t(a)
        z = self.t(z)
        return mp.hyp0f1(a, z)/mp.gamma(a)

# !!! Missing in documentation, move to chi-squared !!!
    def chi_squared_nc_0f1_nc_pdf(self, x, nu, lambda1):
        x = self.t(x)
        nu = self.t(nu)
        res = self.exp(-lambda1/2) * self.chi2_pdf(x, nu)
        res = res * self.hyp0f1(nu/2, x * lambda1 / 4)
        return res


# %%%  18.2 Bessel functions and modified Bessel functions of real or
    # complex order

# !!! Missing in documentation, remove? !!!

    def j0(self, z):
        # return mp.j0(z)
        return self.besselj(0, z)

# 18.2.1 Bessel function of the 1st kind 𝐽𝜈(𝑥)

    def besselj(self, n, z, derivative=0):
        '''Bessel function of the 1st kind 𝐽𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besselj(n, z, derivative)

# 18.2.2 Bessel function of the 2nd kind 𝑌𝜈(𝑥)

    def bessely(self, n, z, derivative=0):
        '''Bessel function of the 2nd kind 𝑌𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.bessely(n, z, derivative)

# 18.2.3 Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0

    def besseljzero(self, n, m, derivative=0):
        '''Zeros 𝑥𝑖 of the Bessel function of the first kind, 𝐽𝜈(𝑥𝑖) = 0'''
        n = self.t(n)
        m = int(m)
        return mp.besseljzero(n, m, derivative)

# 18.2.4 Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0

    def besselyzero(self, n, m, derivative=0):
        '''Zeros 𝑥𝑖 of the Bessel function of the second kind, 𝑌𝜈(𝑥𝑖) = 0'''
        n = self.t(n)
        m = int(m)
        return mp.besselyzero(n, m, derivative)

    # TODO: scaled version

# 18.2.5 Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)

    def besseli(self, n, z, derivative=0):
        '''Modified Bessel function of the 1st kind 𝐼𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besseli(n, z, derivative)

    # TODO: scaled version

# 18.2.6 Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)

    def besselk(self, n, z):
        '''Modified Bessel function of the 2nd kind 𝐾𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.besselk(n, z)

# !!! Missing in documentation, move to t-distribution !!!
    def student_t_c_x(self, t, n):
        t = self.t(t)
        n = self.t(n)
        res = self.besselk(n/2, self.sqrt(n) * self.fabs(t))
        res = self.power(res, n/2)
        res = res / self.gamma(n/2) * self.power(2, n/2-1)
        return res

# 18.2.7 First derivative of the Bessel function of the first kind: 𝐽′𝜈(𝑥)

# 18.2.8 First derivative of the Bessel function of the second kind 𝑌′𝜈 (𝑥)

# 18.2.9 First derivative of the modified Bessel function of the first
    # kind 𝐼′𝜈(𝑥)

# 18.2.10 First derivative of the modified Bessel function of the second
    # kind 𝐾′𝜈(𝑥)


# 18.2.11 Hankel function of the first kind 𝐻1,𝜈(𝑥)

    def hankel1(self, n, z):
        '''Hankel function of the first kind 𝐻1,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hankel1(n, z)

# 18.2.12 Hankel function of the second kind 𝐻2,𝜈(𝑥)

    def hankel2(self, n, z):
        '''Hankel function of the second kind 𝐻2,𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hankel2(n, z)


# %%%  18.3 Spherical Bessel functions

    # See also: https://github.com/fredrik-johansson/mpmath/issues/319

# 18.3.1 Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)

    def sph_bessel_jn(self, n, z, derivative=0):
        '''Spherical Bessel function of the first kind, 𝑗𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besselj(n+0.5, z)
        return res

# 18.3.2 Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)

    def sph_bessel_yn(self, n, z, derivative=0):
        '''Spherical Bessel function of the second kind, 𝑦𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.bessely(n+0.5, z)
        return res

# 18.3.3 Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)

    def sph_bessel_in(self, n, z, derivative=0):
        '''Modified Spherical Bessel function of the first kind, 𝑖𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besseli(n+0.5, z)
        return res

# 18.3.4 Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)

    def sph_bessel_kn(self, n, z, derivative=0):
        '''Modified Spherical Bessel function of the second kind, 𝑘𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.besselk(n+0.5, z)
        return res


# 18.3.5 First derivative of the spherical Bessel function of the first
    # kind, 𝑗′𝑛(𝑥)

# 18.3.6 First derivative of the spherical Bessel function of the second
    # kind, 𝑦′𝑛(𝑥)


# Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)

    def sph_hankel_h1(self, n, z, derivative=0):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.hankel1(n+0.5, z)
        return res

# 18.3.8 Spherical Hankel function of the second kind, ℎ2,𝑛(𝑥)
    def sph_hankel_h2(self, n, z, derivative=0):
        '''Spherical Hankel function of the first kind, ℎ1,𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = mp.sqrt(mp.pi()/(2*z)) * mp.hankel2(n+0.5, z)
        return res


# %%%  18.4 Airy functions, TODO: scaled functions

# 18.4.1 Airy function Ai

    def airyai(self, z, derivative=0):
        '''Airy function Ai'''
        z = self.t(z)
        return mp.airyai(z, derivative)

# 18.4.2 Airy function Bi

    def airybi(self, z, derivative=0):
        '''Airy function Bi'''
        z = self.t(z)
        return mp.airybi(z, derivative)

# 18.4.3 Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0

    def airyaizero(self, k, derivative=0):
        '''Zeros 𝑥𝑖 of the Airy function Ai, Ai(𝑥𝑖) = 0'''
        k = int(k)
        return mp.airyaizero(k, derivative)

# 18.4.4 Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0

    def airybizero(self, k, derivative=0, complex=0):
        '''Zeros 𝑥𝑖 of the Airy function Bi, Bi(𝑥𝑖) = 0'''
        k = int(k)
        return mp.airybizero(k, derivative, complex)

# 18.4.5 Airy Ai'(x)

    def airy_aip(self, z):
        '''Airy Ai'(x)'''
        z = self.t(z)
        return mp.airyai(z, 1)

# 18.4.6 Airy Bi'(x)

    def airy_bip(self, z):
        '''Airy Bi'(x)'''
        z = self.t(z)
        return mp.airybi(z, 1)


# %%%  18.5 Kelvin functions, TODO: scaled functions

# 18.5.1 Kelvin function ber

    def ber(self, n, z):
        '''Kelvin function ber'''
        n = self.t(n)
        z = self.t(z)
        return mp.ber(n, z)

    def kelvinber(self, n, z):
        '''Kelvin function ber'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        j1 = mp.besselj(n, z * (-a + 1j*a))
        j2 = mp.besselj(n, z * (-a - 1j*a))
        res = 0.5 * (j1 + j2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.2 Kelvin function bei

    def bei(self, n, z):
        '''Kelvin function bei'''
        n = self.t(n)
        z = self.t(z)
        return mp.bei(n, z)

    def kelvinbei(self, n, z):
        '''Kelvin function bei'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        j1 = mp.besselj(n, z * (-a + 1j*a))
        j2 = mp.besselj(n, z * (-a - 1j*a))
        res = -0.5j * (j1 - j2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.3 Kelvin function ker

    def ker(self, n, z):
        '''Kelvin function ker'''
        n = self.t(n)
        z = self.t(z)
        return mp.ker(n, z)

    def kelvinker(self, n, z):
        '''Kelvin function ker'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        k1 = mp.exp(-1j*n*mp.pi()/2) * mp.besselk(n, z * (a + 1j*a))
        k2 = mp.exp(1j*n*mp.pi()/2) * mp.besselk(n, z * (a - 1j*a))
        res = 0.5 * (k1 + k2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 18.5.4 Kelvin function kei

    def kei(self, n, z):
        '''Kelvin function kei'''
        n = self.t(n)
        z = self.t(z)
        return mp.kei(n, z)

    def kelvinkei(self, n, z):
        '''Kelvin function kei'''
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * mp.sqrt(mp.mpf(2))
        k1 = mp.exp(-1j*n*mp.pi()/2) * mp.besselk(n, z * (a + 1j*a))
        k2 = mp.exp(1j*n*mp.pi()/2) * mp.besselk(n, z * (a - 1j*a))
        res = -0.5j * (k1 - k2)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# %% 11 Hypergeometric Function 1_F_1 and related functions

# %%%  19.1 Overview

# 19.1.1 Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyp1f1(self, a, b, z):
        '''Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp1f1(a, b, z)

# 19.1.2 Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1

    def hyp1f1r(self, a, b, z):
        '''Regularized Kummer’s Confluent Hypergeometric Function 1𝐹1'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp1f1(a, b, z) / mp.gamma(b)

# 19.1.3 Tricomi’s Confluent Hypergeometric Function 𝑈

    def hyperu(self, a, b, z):
        '''Tricomi’s Confluent Hypergeometric Function 𝑈'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyperu(a, b, z)


# %%%  19.2 Incomplete gamma functions

# 19.2.1 Incomplete gamma function, general form

    def gammainc(self, a, z1=0, z2=mp.inf, regularized=False):
        '''Incomplete gamma function, general form'''
        a = self.t(a)
        z1 = self.t(z1)
        z2 = self.t(z2)
        return mp.gammainc(a, z1, z2, regularized)

# 19.2.2 Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)

    def gamma_lower(self, a, z):
        '''Lower non-normalised incomplete gamma function, 𝛾(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, 0, z, False)

# 19.2.3 Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)

    def gamma_upper(self, a, z):
        '''Upper non-normalised incomplete gamma function, Γ(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, z, mp.inf, False)

# 19.2.4 Lower normalised incomplete gamma function

    def gamma_p(self, a, z):
        '''Lower normalised incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, 0, z, True)

# 19.2.5 Upper normalised incomplete gamma function

    def gamma_q(self, a, z):
        '''Upper normalised incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.gammainc(a, z, mp.inf, True)

# 19.2.6 Tricomi’s entire incomplete gamma function: 𝛾*(𝑎, 𝑥)

    def gamma_tricomi(self, a, z):
        '''Tricomi’s entire incomplete gamma function: 𝛾*(𝑎, 𝑥)'''
        a = self.t(a)
        z = self.t(z)
        return self.gamma_p(a, z) * mp.power(z, -a)

# 19.2.7 Derivative of the incomplete gamma function

    def gamma_derivative(self, a, z):
        '''Derivative of the incomplete gamma function'''
        a = self.t(a)
        z = self.t(z)
        return mp.exp(-z) * mp.power(z, a-1) / mp.gamma(a)


# %%%  19.3 Error function and related functions

    # Note: make correction for complex case

# 19.3.1 Error function erf

    def erf(self, z):
        '''Error function erf'''
        z = self.t(z)
        return mp.erf(z)

    # Note: make correction for complex case

# 19.3.2 Complementary error function erfc

    def erfc(self, z):
        '''Complementary error function erfc'''
        z = self.t(z)
        return mp.erfc(z)


# 19.3.3 Scaled repeated integrals of erfc

    def inerfc(self, n, z):
        '''Scaled repeated integrals of erfc'''
        n = self.t(n)
        z = self.t(z)
        scaled = True
        res = 1/(2**n * self.sqrt(self.pi()))
        res = res * self.hyperu(0.5*n+0.5, 0.5, z*z)
        if not (scaled):
            res = res * self.exp(-z*z)
        return res

# 19.3.4 Imaginary error function erfi

    def erfi(self, z):
        '''Imaginary error function erfi'''
        z = self.t(z)
        return mp.erfi(z)

# 19.3.5 Dawson’s integral

    def dawson(self, z):
        '''Dawson’s integral'''
        z = self.t(z)
        res = 0.5 * mp.sqrt(mp.pi()) * mp.exp(-z*z)
        res = res * mp.erfi(z)
        return res

# 19.3.6 Fresnel sine integral

    def fresnels(self, z):
        '''Fresnel sine integral'''
        z = self.t(z)
        return mp.fresnels(z)

# 19.3.7 Fresnel cosine integral

    def fresnelc(self, z):
        '''Fresnel cosine integral'''
        z = self.t(z)
        return mp.fresnelc(z)


# 19.3.8 Faddeeva function

    def faddeeva(self, z):
        '''Faddeeva function'''
        z = self.t(z)
        res = mp.exp(-z*z) * mp.erfc(-1j * z)
        return res

# 19.3.9 Voigt function U

    def voigt_u(self, x, t):
        '''Voigt function U'''
        x = self.t(x)
        t = self.t(t)
        z = (1-1j*x)/(2*mp.sqrt(t))
        res = mp.sqrt(mp.pi()/(4*t)) * self.faddeeva(1j * z)
        return mp.re(res)

# 19.3.10 Voigt function V

    def voigt_v(self, x, t):
        '''Voigt function V'''
        x = self.t(x)
        t = self.t(t)
        z = (1-1j*x)/(2*mp.sqrt(t))
        res = mp.sqrt(mp.pi()/(4*t)) * self.faddeeva(1j * z)
        return mp.im(res)

# 19.3.11 Voigt function H

    def voigt_h(self, a, u):
        '''Voigt function H'''
        a = self.t(a)
        u = self.t(u)
        res = 1/(a*mp.sqrt(mp.pi()))
        res = res * self.voigt_u(u/a, 1/(4*a*a))
        return res


# %%%  19.4 Exponential integrals and related functions

# 19.4.1 Hyperbolic cosine integral Chi

    def chi(self, z):
        '''Hyperbolic cosine integral Chi'''
        z = self.t(z)
        return mp.chi(z)

# 19.4.2 Cosine integral Ci

    def ci(self, z):
        '''Cosine integral Ci'''
        z = self.t(z)
        return mp.ci(z)

# 19.4.3 Exponential integral E1

    def e1(self, z):
        '''Exponential integral E1'''
        z = self.t(z)
        return mp.e1(z)

# 19.4.4 Exponential integral Ei

    def ei(self, z):
        '''Exponential integral Ei'''
        z = self.t(z)
        return mp.ei(z)

# 19.4.5 Exponential integral 𝐸𝑛

    def expint(self, n, z):
        '''Exponential integral 𝐸𝑛'''
        n = self.t(n)
        z = self.t(z)
        return mp.expint(n, z)

# 19.4.6 Logarithmic integral li

    def li(self, z, offset=False):
        '''Logarithmic integral li'''
        z = self.t(z)
        return mp.li(z, offset)

# 19.4.7 Bounds for the value of the prime counting function

    def primepi2_upper(self, x):
        '''Bounds for the value of the prime counting function'''
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi())
        res = self.ceil(m+d)
        return res

# 19.4.8 Bounds for the value of the prime counting function

    def primepi2_lower(self, x):
        '''Bounds for the value of the prime counting function'''
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi())
        res = self.floor(m-d)
        return res

# 19.4.9 Hyperbolic sine integral shi

    def shi(self, z):
        '''Hyperbolic sine integral shi'''
        z = self.t(z)
        return mp.shi(z)

# 19.4.10 Sine integral si
    def si(self, z):
        '''Sine integral si'''
        z = self.t(z)
        return mp.si(z)


# %%%  19.5 Orthogonal polynomials

# 19.5.1 Hermite polynomials (physicist)

    def hermite(self, n, z):
        '''Hermite polynomials (physicist)'''
        n = self.t(n)
        z = self.t(z)
        return mp.hermite(n, z)

# 19.5.2 Hermite polynomials (probabilist)

    def hermite_he(self, n, z):
        '''Hermite polynomials (probabilist)'''
        n = self.t(n)
        z = self.t(z)
        res = 2**(-n/2) * self.hermite(n, z/self.sqrt(2))
        return res

# 19.5.3 Laguerre Polynomials, 𝐿𝑛(𝑥)

    def laguerre_l(self, n, z):
        '''Laguerre Polynomials, 𝐿𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.laguerre(n, 0.0, z)

# 19.5.4 Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)

    def laguerre(self, n, a, z):
        '''Generalized Laguerre polynomials, 𝐿𝑚𝑛(𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        return mp.laguerre(n, a, z)


# %%%  19.6 Coulomb functions

# 19.6.1 Normalizing Gamow constant for Coulomb wave functions

    def coulombc(self, l, eta):
        '''Normalizing Gamow constant for Coulomb wave functions'''
        l = self.t(l)
        eta = self.t(eta)
        return mp.coulombc(l, eta)

# 19.6.2 Coulomb wave function F

    def coulombf(self, l, eta, z):
        '''Coulomb wave function F'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return mp.coulombf(l, eta, z)

# 19.6.3 Coulomb wave function G

    def coulombg(self, l, eta, z):
        '''Coulomb wave function G'''
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return mp.coulombg(l, eta, z)


# %%%  19.7 Whittaker functions

# 19.7.1 Whittaker function M

    def whitm(self, k, m, z):
        '''Whittaker function M'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return mp.whitm(k, m, z)

# 19.7.2 Whittaker function W

    def whitw(self, k, m, z):
        '''Whittaker function W'''
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        return mp.whitw(k, m, z)


# %%%  19.8 Parabolic cylinder functions

# 19.8.1 Parabolic cylinder function D

    def pcfd(self, n, z):
        '''Parabolic cylinder function D'''
        n = self.t(n)
        z = self.t(z)
        return mp.pcfd(n, z)

# 19.8.2 Parabolic cylinder function U

    def pcfu(self, a, z):
        '''Parabolic cylinder function U'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfu(a, z)

# 19.8.3 Parabolic cylinder function V

    def pcfv(self, a, z):
        '''Parabolic cylinder function V'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfv(a, z)

# 19.8.4 Parabolic cylinder function W

    def pcfw(self, a, z):
        '''Parabolic cylinder function W'''
        a = self.t(a)
        z = self.t(z)
        return mp.pcfw(a, z)


# %% 12 Hypergeometric Function 2_F_1 and related functions

# %%%  20.1 Overview


# 20.1.1 Gauss Hypergeometric Function 2𝐹1

    def hyp2f1(self, a, b, c, z):
        '''Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return mp.hyp2f1(a, b, c, z)

# 20.1.2 Regularized Gauss Hypergeometric Function 2𝐹1

    def hyp2f1r(self, a, b, c, z):
        '''Regularized Gauss Hypergeometric Function 2𝐹1'''
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return mp.hyp2f1(a, b, c, z) / mp.gamma(c)


# %%%  20.2 Orthogonal polynomials

# 20.2.1 Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)

    def chebyt(self, n, z):
        '''Chebyshev polynomial of the first kind, 𝑇𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.chebyt(n, z)

# 20.2.2 Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)

    def chebyu(self, n, z):
        '''Chebyshev polynomial of the second kind, 𝑈𝑛(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.chebyu(n, z)

# 20.2.3 Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)

    def gegenbauer(self, n, a, z):
        '''Gegenbauer polynomials, 𝐶𝛼𝑛 (𝑥)'''
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        return mp.gegenbauer(n, a, z)

# 20.2.4 Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛

    def jacobi(self, n, a, b, z):
        '''Jacobi polynomials, 𝑃(𝛼,𝛽)𝑛'''
        n = self.t(n)
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.jacobi(n, a, b, z)

# 20.2.5 Legendre polynomials / functions, 𝑃𝑙(𝑥)

    def legendre(self, n, z):
        '''Legendre polynomials / functions, 𝑃𝑙(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.legendre(n, z)

# 20.2.6 Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)

    def legenp(self, n, m, z, type=2):
        '''Associated Legendre polynomials / functions, 𝑃𝑚𝑙 (𝑥)'''
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        return mp.legenp(n, m, z, type)

# 20.2.7 Associated Legendre function of the second kind, 𝑄𝑙(𝑥)

    def legenq(self, n, m, z, type=2):
        '''Associated Legendre function of the second kind, 𝑄𝑙(𝑥)'''
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        return mp.legenq(n, m, z, type)

# 20.2.8 Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)

    def spherharm(self, l, m, theta, phi):
        '''Spherical harmonics, 𝑌 𝑚𝑛 (𝜃, 𝜑)'''
        l = self.t(l)
        m = self.t(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return mp.spherharm(l, m, theta, phi)


# %%%  20.3 Incomplete Beta

# 20.3.1 General incomplete beta function

    def betainc(self, a, b, z1=0, z2=1, regularized=False):
        '''General incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z1 = self.t(z1)
        z2 = self.t(z2)
        return mp.betainc(a, b, z1, z2, regularized)

# 20.3.2 Normalised incomplete beta function

    def ibeta(self, a, b, z):
        '''Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.betainc(a, b, 0, z, True)

# 20.3.3 Non-Normalised incomplete beta function

    def beta3(self, a, b, z):
        '''Non-Normalised incomplete beta function'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.betainc(a, b, 0, z, False)


# %% 13 Hypergeometric Function p_F_q and related functions


# %%%  21.1 Generalized hypergeometric functions

# 21.1.1 Generalized hypergeometric function 𝑝𝐹𝑞

    def hyper(self, a_s, b_s, z):
        '''Generalized hypergeometric function 𝑝𝐹𝑞'''
        return mp.hyper(a_s, b_s, z)

# 21.1.2 Generalized hypergeometric function 2𝐹3

    def hyp2f3(self, a1, a2, b1, b2, b3, z):
        '''Generalized hypergeometric function 2𝐹3'''
        return mp.hyp2f3(a1, a2, b1, b2, b3, z)

# 21.1.3 Generalized hypergeometric function 3𝐹2

    def hyp3f2(self, a1, a2, a3, b1, b2, z):
        '''Generalized hypergeometric function 3𝐹2'''
        return mp.hyp3f2(a1, a2, a3, b1, b2, z)

# 21.1.4 Generalized hypergeometric function 2𝐹2

    def hyp2f2(self, a1, a2, b1, b2, z):
        '''Generalized hypergeometric function 2𝐹2'''
        return mp.hyp2f2(a1, a2, b1, b2, z)


# 21.1.5 Generalized hypergeometric function 2𝐹0

    def hyp2f0(self, a, b, z):
        '''Generalized hypergeometric function 2𝐹0'''
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return mp.hyp2f0(a, b, z)


# %%%  21.2 Generalized hypergeometric function 1F2 and related functions

# 21.2.1 Non-regularized hypergeometric function 1𝐹2

    def hyp1f2(self, a1, b1, b2, z):
        '''Non-regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        return mp.hyp1f2(a1, b1, b2, z)

    # see  https://functions.wolfram.com/HypergeometricFunctions/
    # Hypergeometric1F2/25/01/

# 21.2.2 Regularized hypergeometric function 1𝐹2

    def hyp1f2r(self, a1, b1, b2, z):
        '''Regularized hypergeometric function 1𝐹2'''
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        res = mp.hyp1f2(a1, b1, b2, z)
        res = res / (mp.gamma(b1)*mp.gamma(b2))
        return res

# 21.2.3 Scorer function Gi

    def scorergi(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        return mp.scorergi(z)

    def scorergi2(self, z):
        '''Scorer function Gi'''
        z = self.t(z)
        t = mp.mpf(1)/mp.mpf(3)
        res1 = self.airybi(z)/3
        res2 = (z*z)/(2*self.pi())
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 - res2*res3
        return res


# 21.2.4 Scorer function Hi(x)

    def scorerhi(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        return mp.scorerhi(z)

    def scorerhi2(self, z):
        '''Scorer function Hi'''
        z = self.t(z)
        t = mp.mpf(1)/mp.mpf(3)
        res1 = 2*self.airybi(z)/3
        res2 = (z*z)/(2*self.pi())
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 + res2*res3
        return res


# 21.2.5 Struve function 𝐻𝜈(𝑥)

    def struveh(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.struveh(n, z)

    def struveh2(self, n, z):
        '''Struve function 𝐻𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res2 = (z/2)**(n+1)
        res3 = self.hyp1f2r(1, 1.5, n+1.5, -z*z/4)
        res = res2*res3
        return res


# 21.2.6 Struve function 𝐿𝜈(𝑥)

    def struvel(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        return mp.struvel(n, z)

    def struvel2(self, n, z):
        '''Struve function 𝐿𝜈(𝑥)'''
        n = self.t(n)
        z = self.t(z)
        res = -1j*self.expjpi(-n/2)*self.struveh(n, 1j*z)
        if mp.im(res) == mp.mpf(0):
            res = mp.re(res)
        return res


# 21.2.7 Struve function K

    def struvek(self, n, z):
        '''Struve function K'''
        n = self.t(n)
        z = self.t(z)
        return self.struveh(n, z) - self.bessely(n, z)

# 21.2.8 Struve function M

    def struvem(self, n, z):
        '''Struve function M'''
        n = self.t(n)
        z = self.t(z)
        return self.struvel(n, z) - self.besseli(n, z)

# 21.2.9 Anger function J

    def angerj(self, n, z):
        '''Anger function J'''
        n = self.t(n)
        z = self.t(z)
        return mp.angerj(n, z)

    def angerj2(self, n, z):
        '''Anger function J'''
        # if n is an integer, return besselj(n,z)
        n = self.t(n)
        z = self.t(z)
        tau = self.pi() * n / 2
        res2a = (z/2)*self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res2b = self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res = res2a*res3a + res2b*res3b
        return res


# 21.2.10 Weber function E

    def webere(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        return mp.webere(n, z)

    def webere2(self, n, z):
        '''Weber function E'''
        n = self.t(n)
        z = self.t(z)
        tau = self.pi() * n / 2
        res2a = self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res2b = (z/2)*self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res = res2a*res3a - res2b*res3b
        return res


# 21.2.11 Lommel function 𝑆1

    def lommels1(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return mp.lommels1(mu, nu, z)

    def lommels1_2(self, mu, nu, z):
        '''Lommel function 𝑆1'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res2 = z**(mu+1)/((mu-nu+1)*(mu+nu+1))
        res3 = self.hyp1f2(1, (mu-nu+3)/2, (mu+nu+3)/2, -z*z/4)
        res = res2*res3
        return res


# 21.2.12 Lommel function 𝑆2

    def lommels2(self, mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        return mp.lommels2(mu, nu, z)

    def lommels2_2(self,  mu, nu, z):
        '''Lommel function 𝑆2'''
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res1 = self.lommels1(mu, nu, z)
        res2 = 2**(mu-1) * self.gamma((mu-nu+1)/2) * self.gamma((mu+nu+1)/2)
        res3 = self.sin(self.pi()*(mu-nu)/2) * self.besselj(nu, z)
        res4 = self.cos(self.pi()*(mu-nu)/2) * self.bessely(nu, z)
        res = res1+res2*(res3-res4)
        return res


# %% 14 Generalizations of gamma and hypergeometric functions
    # (without ARB support)


# %%%  22.1 Appell Functions

# 22.1.1 Appell function 𝐹1

    def appellf1(self, a, b1, b2, c, x, y):
        '''Appell function 𝐹1'''
        return mp.appellf1(a, b1, b2, c, x, y)

# 22.1.2 Appell function 𝐹2

    def appellf2(self, a, b1, b2, c1, c2, x, y):
        '''Appell function 𝐹2'''
        return mp.appellf2(a, b1, b2, c1, c2, x, y)

# 22.1.3 Appell function 𝐹3

    def appellf3(self, a1, a2, b1, b2, c, x, y):
        '''Appell function 𝐹3'''
        return mp.appellf3(a1, a2, b1, b2, c, x, y)

# 22.1.4 Appell function 𝐹4

    def appellf4(self, a, b, c1, c2, x, y):
        '''Appell function 𝐹4'''
        return mp.appellf4(a, b, c1, c2, x, y)


# %%%  22.2 Q Functions

# 22.2.1 q-Pochhammer symbol

    def qp(self, a, q=None, n=None):
        '''q-Pochhammer symbol'''
        return mp.qp(a, q, n)

# 22.2.2 q-gamma function

    def qgamma(self, z, q):
        '''q-gamma function'''
        return mp.qgamma(z, q)

# 22.2.3 q-factorial

    def qfac(self, z, q):
        '''q-factorial'''
        return mp.qfac(z, q)

# 22.2.4 Hypergeometric q-series

    def qhyper(self, a_s, b_s, q, z):
        '''Hypergeometric q-series'''
        return mp.qhyper(a_s, b_s, q, z)


# %%%  22.3 Further generalizations of gamma and hypergeometric functions

# 22.3.1 Limit of the product of gamma functions

    def gammaprod(self, a, b):
        '''Limit of the product of gamma functions'''
        return mp.gammaprod(a, b)

# 22.3.2 Limit of a weighted combination of hypergeometric functions

    def hypercomb(self, function, params=[], discard_known_zeros=True):
        '''Limit of a weighted combination of hypergeometric functions'''
        return mp.hypercomb(function, params, discard_known_zeros)

# 22.3.3 Meijer G-function

    def meijerg(self, a_s, b_s, r, z):
        '''Meijer G-function'''
        return mp.meijerg(a_s, b_s, r, z)

# 22.3.4 Bilateral hypergeometric series

    def bihyper(self, a_s, b_s, z):
        '''Bilateral hypergeometric series'''
        return mp.bihyper(a_s, b_s, z)

# 22.3.5 Generalized 2D hypergeometric series

    def hyper2d(self, a, b, x, y):
        '''Generalized 2D hypergeometric series'''
        return mp.hyper2d(a, b, x, y)



# %% 15 Algebra with random variables

# 12.1-12.2 is just text


# %%% 12.3 Probability density function (pdf)


# 12.3.1 Calculating the pdf from the cdf

    def pdf_from_cdf(self):
        '''Calculates the pdf from the cdf'''
        return ctxm.pdf_from_cdf(self)

# 12.3.2 Calculating the pdf from the characteristic function

    def pdf_from_cf(self):
        '''Calculates the pdf from the characteristic function'''
        return ctxm.pdf_from_cf(self)


# %%% 12.4 Probability mass function (pmf)


# 12.4.1 Calculating the pmf from the cdf

    def pmf_from_cdf(self):
        '''Calculates the pmf from the cdf'''
        return ctxm.pmf_from_cdf(self)

# 12.4.2 Calculating the pmf from the characteristic function

    def pmf_from_cf(self):
        '''Calculates the pmf from the characteristic function'''
        return ctxm.pmf_from_cf(self)

# 12.4.3 Calculating the pmf from the factorial moments

    def pmf_from_factorialmoments(self):
        '''Calculates the pmf from the factorial moments'''
        return ctxm.pmf_from_factorialmoments(self)


# 12.4.4 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 12.5 Cumulative distribution function (cdf)


# 12.5.1 Calculating the cdf from the pdf

    def cdf_from_pdf(self):
        '''Calculates the cdf from the pdf'''
        return ctxm.cdf_from_pdf(self)

# 12.5.2 Calculating the cdf from the pmf vector

    def cdf_from_pmf_vector(self):
        '''Calculates the cdf from the pmf vector'''
        return ctxm.cdf_from_pmf_vector(self)


# 12.5.3 Calculating the cdf from the characteristic function, continuous cdf

    def cdf_from_cf_continuous(self):
        '''Calculates the cdf from the characteristic function,
        continuous distribution'''
        return ctxm.cdf_from_cf_continuous(self)


# 12.5.4 Calculating the cdf from the characteristic function
    # (lattice distribution)

    def cdf_from_cf_lattice(self):
        '''Calculates the cdf from the characteristic function,
        lattice distribution'''
        return ctxm.cdf_from_cf_lattice(self)

# 12.5.5 Calculating the cdf from the factorial moments (lattice distributions)

    def cdf_from_factorial_moments_lattice(self):
        '''Calculates the cdf from the factorial moments,
        lattice distribution'''
        return ctxm.cdf_from_factorial_moments_lattice(self)


# %%% 12.6 Percentage point function


# 12.6.1 Calculating the percentage point function from the cdf

    def qtf_from_cdf(self):
        '''Calculates the percentage point function from the cdf'''
        return ctxm.qtf_from_cdf(self)


# 12.6.2 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 12.7 Characteristic function


# 12.7.1 Calculating the characteristic function from the pdf

    def cf_from_pdf(self, cf):
        '''Calculates the characteristic function from the pdf,
        continuous distribution'''
        return ctxm.cf_from_pdf(self, cf)

# 12.7.2 Calculating the characteristic function from the pmf
    # (lattice distribution)

    def cf_from_pmf(self, cf):
        '''Calculates the characteristic function from the pmf,
        lattice distribution'''
        return ctxm.cf_from_pmf(self, cf)

# 12.7.3 Calculating the characteristic function from the percentage
    # point function

    def cf_from_qtf(self):
        '''Calculates the characteristic function from the percentage point
        function, continuous distribution'''
        return ctxm.cf_from_qtf(self)

# 12.7.4 Calculating the characteristic function from the raw moments

    def cf_from_rawmoments(self):
        '''Calculates the characteristic function from the raw moments,
        continuous distribution'''
        return ctxm.cf_from_rawmoments(self)


# %%% 12.8 Moment generating function


# 12.8.1 Calculating the moment-generating function from the pdf

    def mgf_from_pdf(self):
        '''Calculates the moment-generating function from the pdf,
        continuous distribution'''
        return ctxm.mgf_from_pdf(self)

# 12.8.2 Calculating the moment-generating function from the
    # characteristic function

    def mgf_from_cf(self):
        '''Calculates the moment-generating function from the characteristic
        function, continuous distribution'''
        return ctxm.mgf_from_cf(self)

# 12.8.3 Calculating the moment-generating function from the
    # cumulant-generating function

    def mgf_from_cgf(self):
        '''Calculates the moment-generating function from the
        cumulant-generating, continuous distribution'''
        return ctxm.mgf_from_cgf(self)

# 12.8.4 Calculating the moment-generating function from the
    # probability-generating function

    def mgf_from_pgf(self):
        '''Calculates the moment-generating function from the
        probability-generating, lattice distribution'''
        return ctxm.mgf_from_pgf(self)

# 12.8.5 Calculating the moment-generating function from the raw moments

    def mgf_from_rawmoments(self):
        '''Calculates the moment-generating function from the
        raw moments, continuous distribution'''
        return ctxm.mgf_from_rawmoments(self)

# 12.8.6 Calculating the moment-generating function from the pmf vector

    def mgf_from_pmf_vector(self, t, pmfvec):
        '''Calculates the moment-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.mgf_from_pmf_vector(self, t, pmfvec)


# %%% 12.9 Cumulant generating function


# 12.9.1 Calculating the cumulant-generating function from the
    # characteristic function

    def cgf_from_cf(self):
        '''Calculates the cumulant-generating function from the characteristic
        function, continuous distribution'''
        return ctxm.cgf_from_cf(self)

# 12.9.2 Calculating the cumulant-generating function from the
    # moment-generating function

    def cgf_from_mgf(self):
        '''Calculates the cumulant-generating function from the
        moment-generating function, continuous distribution'''
        return ctxm.cgf_from_mgf(self)

# 12.9.3 Calculating the cumulant-generating function from the
    # probability-generating function

    def cgf_from_pgf(self):
        '''Calculates the cumulant-generating function from the
        probability-generating function, continuous distribution'''
        return ctxm.cgf_from_pgf(self)

# 12.9.4 Calculating the cumulant-generating function from the cumulants

    def cgf_from_cumulants(self):
        '''Calculates the cumulant-generating function from the
        cumulants, continuous distribution'''
        return ctxm.cgf_from_cumulants(self)

# 12.9.5 Calculating the cumulant-generating function from the pmf vector

    def cgf_from_pmf_vector(self, t, pmfvec):
        '''Calculates the cumulant-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.cgf_from_pmf_vector(self, t, pmfvec)


# %%% 12.10 Probability generating function


# 12.10.1 Calculating the probability-generating function from the pmf vector

    def pgf_from_pmf_vector(self):
        '''Calculates the probability-generating function from the
        pmf vector, lattice distribution'''
        return ctxm.pgf_from_pmf_vector(self)

# 12.10.1 Calculating the probability-generating function from the
    # moment-generating function

    def pgf_from_mgf(self):
        '''Calculates the probability-generating function from the
        moment-generating function, lattice distribution'''
        return ctxm.pgf_from_mgf(self)


# %%% 12.11 Factorial Moments


# 12.11.1 Calculating the factorial moments from the raw moments

    def factorialmoments_from_rawmoments(self, mraw):
        '''Calculates the factorial moments from the raw moments,
        lattice distribution'''
        return ctxm.factorialmoments_from_rawmoments(self, mraw)

# 12.11.2 Calculating the factorial moments from the cumulants

    def factorialmoments_from_cumulants(self, mraw):
        '''Calculates the factorial moments from the raw moments,
        lattice distribution'''
        return ctxm.factorialmoments_from_cumulants(self, mraw)


# %%% 12.12 Raw Moments


# 12.12.1 Calculating the raw moments from the pdf

    def rawmoments_from_pdf(self, pdf):
        '''Calculates the raw moments from the pdf'''
        return ctxm.rawmoments_from_pdf(self, pdf)

# 12.12.2 Calculating the raw moments from the pmf vector

    def rawmoments_from_pmfvector(self, x, nl, order, show=False):
        '''Calculates the raw moments from the pmf vector'''
        return ctxm.rawmoments_from_pmfvector(self, x, nl, order, show)

# 12.12.3 Calculating the raw moments from the factorial moments

    def rawmoments_from_factorialmoments(self, mfac):
        '''Calculates the raw moments from the factorial moments'''
        return ctxm.rawmoments_from_factorialmoments(self, mfac)

# 12.12.4 Calculating the raw moments from the central moments
    def rawmoments_from_centralmoments(self, mu):
        '''Calculates the raw moments from the central moments'''
        return ctxm.rawmoments_from_centralmoments(self, mu)

# 12.12.5 Calculating the raw moments from the cumulants

    def rawmoments_from_cumulants(self, kappa):
        '''Calculates the raw moments from the cumulants'''
        return ctxm.rawmoments_from_cumulants(self, kappa)

# 12.12.6 Calculating the raw moments from the moment-generating function

    def rawmoments_from_mgf(self):
        '''Calculates the raw moments from the moment-generating function'''
        return ctxm.rawmoments_from_mgf(self)

# 12.12.7 Calculating the raw moments from the characteristic function

    def rawmoments_from_cf(self):
        '''Calculates the raw moments from the characteristic function'''
        return ctxm.rawmoments_from_cf(self)

# 12.12.8 Calculating the raw moments from the probability-generating function

    def rawmoments_from_pgf(self):
        '''Calculates the raw moments from the probability-generating
        function'''
        return ctxm.rawmoments_from_pgf(self)


# %%% 12.13 Central Moments

# 12.12.1 Calculating the central moments from the factorial moments

    def centralmoments_from_factorialmoments(self, mfac):
        '''Calculates the central moments from the factorial moments'''
        return ctxm.centralmoments_from_factorialmoments(self, mfac)

# 12.12.1 Calculating the central moments from the raw moments

    def centralmoments_from_rawmoments(self, mraw):
        '''Calculates the central moments from the raw moments'''
        return ctxm.centralmoments_from_rawmoments(self, mraw)

# 12.12.2 Calculating the central moments from the cumulants

    def centralmoments_from_cumulants(self):
        '''Calculates the central moments from the cumulants'''
        return ctxm.centralmoments_from_cumulants(self)


# %%% 12.14 Cumulants

# 12.14.1 Calculating the cumulants from the pmf vector

    def cumulants_from_pmfvector(self, x, nl, order, show=False):
        '''Calculates the cumulants from the pmf vector'''
        return ctxm.cumulants_from_pmfvector(self, x, nl, order, show)

# 12.14.2 Calculating the cumulants from the factorial moments

    def cumulants_from_factorialmoments(self, mfac):
        '''Calculates the cumulants from the factorial moments'''
        return ctxm.cumulants_from_factorialmoments(self, mfac)

# 12.14.3 Calculating the cumulants from the raw moments

    def cumulants_from_rawmoments(self, mu):
        '''Calculates the cumulants from the raw moments'''
        return ctxm.cumulants_from_rawmoments(self, mu)

# 12.14.4 Calculating the cumulants from the central moments

    def cumulants_from_centralmoments(self, mu):
        '''Calculates the cumulants from the central moments'''
        return ctxm.cumulants_from_centralmoments(self, mu)

# 12.14.5 Calculating the cumulants from the cumulant-generating function

    def cumulants_from_cgf(self, cgf):
        '''Calculates the cumulants from the cumulant-generating function'''
        return ctxm.cumulants_from_cgf(self, cgf)


# 12.15-12.18 is just text




# %% 16 Inferential statistics

# 16.1 Basic classical statistical tests for 1 sample

# 16.1.1 Student t-test for 1 sample: tests (p-values)

    def student_t_1sample_test(self, n, mean, mu0, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (tests and CI)'''
        return stat.student_t_1sample_test(self, n, mean, mu0, std, alpha, **kwargs)


    def student_t_1sample_power(self, n, mean, mu0, std, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_power(self, n, mean, mu0, std, alpha, **kwargs)


    def student_t_1sample_samplesize(self, mean, mu0, std, alpha=0.05, beta=0.10, **kwargs):
        '''Returns results for Student’s t-test for 1 sample (power)'''
        return stat.student_t_1sample_samplesize(self, mean, mu0, std, alpha, beta, **kwargs)



# 16.2 Basic classical statistical tests for 2 independent sample (stratified)

# 16.2.1 Student t-test for 2 independent samples: tests (p-values)

    def student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 2 independent samples'''
        return stat.student_t_2isamples_test(self, n1, n2, mean1, mean2, stdev1, stdev2, alpha, **kwargs)




# 16.3 Basic classical statistical tests for 2 correlated sample

# 16.3.1 Student t-test for 2 correlated samples: tests (p-values)

    def student_t_2csamples_test(self, n, mean1, mean2, stdev1, stdev2, rho, alpha=0.05, **kwargs):
        '''Returns results for Student’s t-test for 2 correlated samples'''
        return stat.student_t_2csamples_test(self, n, mean1, mean2, stdev1, stdev2, rho, alpha, **kwargs)




# 16.4 Anova, orthogonal polynomials, and AOM

# 16.4.1 Anova: tests (p-values)

    def anova_test(self, n, mean, stdev, alpha=0.05, **kwargs):
        '''Returns results for Anova'''
        return stat.anova_test(self, n, mean, stdev, alpha, **kwargs)



# 16.5 Multiple comparisons of means

# 16.5.1 Scheffe-test: tests (p-values)

    def scheffe_test(self, n, mean, stdev, alpha=0.05, **kwargs):
        '''Returns results for the Scheffe-test'''
        return stat.scheffe_test(self, n, mean, stdev, alpha, **kwargs)




# 16.6 Nonparametric statistical tests, 1 or 2 samples

# 16.6.1 sign-test: tests (p-values)

    def sign_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for the sign-test'''
        return stat.sign_test(self, n, mean1, mean2, std, alpha, **kwargs)




# 16.7 Nonparametric statistical tests, k samples

# 16.6.1 Jonckheere-Terpsta S test: tests (p-values)

    def jterpsta_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for the jterpsta_test'''
        return stat.jterpsta_test(self, n, mean1, mean2, std, alpha, **kwargs)




# 16.8 Multivariate statistical tests

# 16.8.1 Multiple linear regression: tests (p-values)

    def multlinreg_test(self, n, mean1, mean2, std, alpha=0.05, **kwargs):
        '''Returns results for multiple linear regression'''
        return stat.multlinreg_test(self, n, mean1, mean2, std, alpha, **kwargs)





# 5.4.31 Student t distribution, pdf

    def student_t_pdf(self, x, df):
        '''Returns the Student t distribution, pdf'''
        return ctxm.student_t_pdf(self, x, df)

# 5.4.32 Student t distribution, cdf and sf
    def student_t_cdf(self, x, df, cdf=True, **kwargs):
        '''Returns the Student t distribution, cdf and sf'''
        return ctxm.student_t_cdf(self, x, df, cdf, **kwargs)

# 5.4.33 Student t distribution, qtf and isf
    def student_t_qtf(self, prob, df, qtf=True, **kwargs):
        '''Returns the Student t distribution, qtf and isf'''
        return ctxm.student_t_qtf(self, prob, df, qtf, **kwargs)


