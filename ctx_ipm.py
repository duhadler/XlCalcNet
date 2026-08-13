# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

from xlcalcnet import mathip
from xlcalcnet.mpmath import mp, iv, mpi
from xlcalcnet import ctx_ip
ip = ctx_ip.IPContext()

from xlcalcnet.ctx_mpm import mpm

from xlcalcnet import ctx_shared
from xlcalcnet import ctx07StatDataAnalysis

ctxm = ctx_shared.ctxUtil()
stat = ctx07StatDataAnalysis.inferential_statistics()



class ipm():

    # %% General functions


    def __init__(self):
        pass



# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.2 Obtaining the name of a context

    @property
    def name(self):
        return "ipm"

    @property
    def fmtname(self):
        return "    ipm"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        z = self.t(z)
        if self.ismpf(z):
            s0 = str(z)
            s = s0.replace(",", ",\n         ")
            return s
        else:
            s1 = str(z.real)
            s2 = str(z.imag)
            return "(" + s1 + ", " + s2 + ")"



    @property
    def realtype(self):
        return ip.mpf

    @property
    def complextype(self):
        return ip.mpc
        #return ip.convert2


# 2.1.2 Creating a real number
    def mpf(self, x):
        return ip.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        return ip.convert2(x, y)

# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return iv.prec

    @prec.setter
    def prec(self, value):
        iv.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)
    @property
    def dps(self):
        return iv.dps

    @dps.setter
    def dps(self, value):
        iv.dps = int(value)

# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return iv.pretty

    @pretty.setter
    def pretty(self, value):
        iv.pretty = bool(value)





# %%%  2.2 Arithmetic operations

# This is implemented in fp, mp, iv, dp, gp, ap


    def fadd(self, x, y, **kwargs):
        return ip.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return ip.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return ip.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return ip.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return ip.fdiv(x, y, **kwargs)

    def fmod(self, x, y):
        return ip.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return ip.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return ip.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return ip.fdot(A, B, conjugate)



# %%% 2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball
    def mid(self, z):
        z = self.t(z)
        return z.mid

# 2.3.2 Radius of an interval or ball
    def radius(self, z):
        z = self.t(z)
        return z.delta

# 2.3.3 Left border of an interval or ball
    def left(self, z):
        z = self.t(z)
        return z.a

# 2.3.4 Left border of an interval or ball
    def right(self, z):
        z = self.t(z)
        return z.b

# 2.3.5 Absolute value of the left end of an interval
    def absmin(self, z):
        return ip.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        return ip.absmax(z)



# %%%  2.4 Complex components


    def abs(self, z):
        z = self.t(z)
        return iv.fabs(z)

    def fabs(self, z):
        z = self.t(z)
        return iv.fabs(z)

    def sign(self, z):
        z = self.t(z)
        return iv.sign(z)


    def re(self, z):
        z = self.t(z)
        return iv.re(z)

    def real(self, z):
        z = self.t(z)
        return iv.re(z)

    def im(self, z):
        z = self.t(z)
        return iv.im(z)

    def imag(self, z):
        z = self.t(z)
        return iv.im(z)

    def arg(self, z):
        z = self.t(z)
        return iv.arg(z)

    def phase(self, z):
        z = self.t(z)
        return iv.arg(z)

    def conj(self, z):
        z = self.t(z)
        if isinstance(z, iv.mpf):
            return z
        else:
            x = self.real(z)
            y = -self.imag(z)
            return iv.mpc(x, y)

    def polar(self, z):
        return mp.polar(z)

    def rect(self, r, phi):
        return mp.rect(r, phi)





# %%%  2.5 Integer and fractional parts

    def floor(self, z):
        z = self.t(z)
        t = mp.floor(mp.mpf(z.a))
        return iv.mpf(t)

    def ceil(self, z):
        z = self.t(z)
        t = mp.ceil(mp.mpf(z.b))
        return iv.mpf(t)


    def nint(self, z):
        return ip.nint(z)

    def frac(self, z):
        return ip.frac(z)


# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return ip.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return ip.almosteq(s, t, rel_eps, abs_eps)



# %%%  2.7 Properties of numbers

    def ismpf(self, z):
        return isinstance(z, iv.mpf)

    def ismpc(self, z):
        return isinstance(z, iv.mpc)


    def isinf(self, z):
        z = self.t(z)
        return ip.isinf(z)

    def isnan(self, z):
        z = self.t(z)
        return ip.isnan(z)

    def isnormal(self, z):
        z = self.t(z)
        return ip.isnormal(z)

    def isfinite(self, z):
        z = self.t(z)
        return ip.isfinite(z)

    def isint(self, z):
        z = self.t(z)
        return ip.isint(z)

    def ldexp(self, x, n):
        x = self.t(x)
        return ip.ldexp(x, n)

    def frexp(self, x):
        x = self.t(x)
        return ip.frexp(x)

    def mag(self, x):
        x = self.t(x)
        return ip.mag(x)

    def nint_distance(self, x):
        x = self.t(x)
        return ip.nint_distance(x)



# %%%  2.8 Number generation


    def fraction(self, p, q):
        return ip.fraction(p, q)

    def rand(self):
        return ip.rand()

    def arange(self, *args):
        return ip.arange(*args)

    def linspace(self, *args, **kwargs):
        return ip.arange(*args, **kwargs)





# %%%  2.9 Exact mathematical constants

    @property
    def zero(self):
        return ip.zero

    @property
    def one(self):
        return ip.one

    @property
    def j(self):
        return ip.j

    @property
    def inf(self):
        return ip.inf

    @property
    def ninf(self):
        return ip.ninf

    @property
    def nan(self):
        return ip.nan




# %%%  2.10 Mathematical Constants




    @property
    def eps(self):
        return +ip.eps

    @property
    def ln2(self):
        return +ip.ln2

    @property
    def ln10(self):
        return +ip.ln10

    @property
    def pi(self):
        return +ip.pi

    @property
    def e(self):
        return +ip.e

    @property
    def euler(self):
        return +ip.euler

    @property
    def phi(self):
        return +ip.phi

    @property
    def catalan(self):
        return +ip.catalan

    @property
    def khinchin(self):
        return +ip.khinchin

    @property
    def glaisher(self):
        return +ip.glaisher

    @property
    def apery(self):
        return +ip.apery()

    @property
    def degree(self):
        return +ip.degree()






# %%%  2.11 Utility functions


    def t(self, x, y=None):
        return mathip.convert(x, y)


    def convert(self, x, y=None):
        return mathip.convert(x, y)


    def mpmathify(self, x, y=None):
        return mathip.convert(x, y)


    def union(self, x, y):
        xa = x.a
        xb = x.b
        ya = y.a
        yb = y.b
        l = xa
        if l > xb:
            l = xb
        if l > ya:
            l = ya
        if l > yb:
            l = yb
        r = xa
        if r < xb:
            r = xb
        if r < ya:
            r = ya
        if r < yb:
            r = yb
        return iv.mpf([l, r])





    def nstr(self, x, n=6, **kwargs):
        return ip.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return ip.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(mp.mpf(self.t(z).mid))

    def to_mpf(self, z):
        return mp.mpf(self.t(z).mid)

    def from_mpf(self, z):
        return mpi(z)



# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return ip.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return ip.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return ip.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return ip.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return ip.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return ip.memoize(f)

    def maxcalls(self, f, N):
        return ip.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None, dpi=None, singularities=[], axes=None):
        res = mp.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res








# %% 3 Scalar elementary functions

# %%%  3.1 Exponential and related functions

    def exp(self, z):
        z = self.t(z)
        return iv.exp(z)

    def expj(self, z):
        z = self.t(z)
        return iv.cos(z) + iv.sin(z) * 1j

    def expjpi(self, z):
        z = self.t(z) * self.pi
        return iv.cos(z) + iv.sin(z) * 1j

    def exp10(self, z):
        z = self.t(z)
        return iv.exp(z * iv.log(10))

    def exp2(self, z):
        z = self.t(z)
        return iv.exp(z * iv.log(2))

    def expm1(self, z):
        z = self.t(z)
        return iv.expm1(z)

    def exp10m1(self, z):
        z = self.t(z)
        return iv.expm1(z * iv.log(10))

    def exp2m1(self, z):
        z = self.t(z)
        return iv.expm1(z * iv.log(2))

    def exprel(self, z):
        z = self.t(z)
        if (z == 0):
            return self.t(1)
        else:
            return iv.expm1(z)/z

    def logistic(self, z):
        z = self.t(z)
        return 1 / (1 + iv.exp(-z))


# %%%  3.2 Logarithms and related functions

    def logb(self, z, b):
        z = self.t(z)
        b = self.t(b)
        return iv.log(z, b)

    def ln(self, z):
        z = self.t(z)
        return iv.ln(z)

    def log(self, z):
        z = self.t(z)
        return iv.ln(z)

    def log1p(self, z):
        z = self.t(z)
        return iv.log1p(z)

    def log10(self, z):
        z = self.t(z)
        return iv.log10(z)

    def log2(self, z):
        z = self.t(z)
        return iv.log(z, 2)

    def log1mexp(self, z):
        z = self.t(z)
        x = iv.fabs(z)
        xc = mp.mpf(x.mid)
        if (mp.fabs(xc) < 0.693):
            return iv.ln(-iv.expm1(-x))
        else:
            return iv.log1p(-iv.exp(-x))

    def log2p1(self, z):
        z = self.t(z)
        return iv.log1p(z) / iv.ln(2)

    def log10p1(self, z):
        z = self.t(z)
        return iv.log1p(z) / iv.ln(10)

    def ln1mexp(self, z):
        z = self.t(z)  # ComplexResult: logarithm of a negative number
        #return iv.ln(-iv.expm1(z))
        return z

    def ln1pexp(self, z):
        z = self.t(z)
        return iv.log1p(iv.exp(z))

    def ln1pmx(self, z):
        z = self.t(z)
        return iv.log1p(z) - z

    def logit(self, z):
        z = self.t(z)  # ComplexResult: logarithm of a negative number
        #return iv.ln(z/(1-z))
        return z

    def lambertw(self, z, k=0):
        #raise Exception("NOT IMPLEMENTED")
        return z

    def agm(self, a, b=1):
        #raise Exception("NOT IMPLEMENTED")
        return a


# %%%  3.3 Square, roots and power functions

    def square(self, z):
        z = self.t(z)
        return z * z  # add special case for real

    def sqrt(self, z):
        z = self.t(z)
        if isinstance(z, iv.mpf):
            # return iv.sqrt(z) needs check for z>=0
            return iv.power(z, 0.5)
        else:
            return iv.power(z, 0.5)

    # !!NEW!!
    def rsqrt(self, z):
        z = self.t(z)
        return 1/self.sqrt(z)


    def sqrt1pm1(self, z):
        z = self.t(z)
        return self.expm1(self.log1p(z)/2)

    def cuberoot(self, z):
        z = self.t(z)
        d = 1/mpi('3.0', '3.0')
        return iv.power(z, d)

    def cbrt(self, z):
        z = self.t(z)
        d = 1/mpi('3.0', '3.0')
        return iv.power(z, d)

    def nthroot(self, z, n):
        z = self.t(z)
        n = int(n)
        return iv.exp(iv.log(z)/n)

    def unitroot(self, k, n):
        return self.exp((2j*k*self.pi)/n)

    def hypot(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.sqrt(a*a + b*b)

    def power(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.power(a, b)

    def pow(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.power(a, b)


    def powm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.powm1(a, b)

    def pow1p(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.exp(b * iv.log1p(a))

    def pow1pm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.expm1(b * iv.log1p(a))

    def fibonacci(self, n):
        n = self.t(n)
        phi = self.phi
        return (phi**n - (-phi)**(-n))/(2*phi-1)

    def fibpoly(self, n, z):
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (1/w) * (((z+w)/2)**n - ((z-w)/2)**n)

    def lucas(self, n):
        n = self.t(n)
        phi = self.phi
        return phi**n + (-phi)**(-n)

    def lucaspoly(self, n, z):
        n = self.t(n)
        z = self.t(z)
        w = self.sqrt(z*z+4)
        return (((z+w)/2)**n + ((z-w)/2)**n)


# %%%  3.4 Trigonometric functions

    def radians(self, z):
        z = self.t(z)
        return z * self.degree

    def degrees(self, z):
        z = self.t(z)
        return z * 180 / self.pi

    def sin(self, z):
        z = self.t(z)
        return iv.sin(z)

    def cos(self, z):
        z = self.t(z)
        return iv.cos(z)

    def tan(self, z):
        z = self.t(z)
        return iv.sin(z)/iv.cos(z)

    def sec(self, z):
        z = self.t(z)
        return iv.sec(z)

    def csc(self, z):
        z = self.t(z)
        return iv.csc(z)

    def cot(self, z):
        z = self.t(z)
        return iv.cos(z)/iv.sin(z)

    def hav(self, z):
        z = self.t(z)
        t = iv.sin(0.5 * z)
        return t*t

    def sinpi(self, z):
        z = self.t(z)
        return iv.sin(z * self.pi)

    def cospi(self, z):
        z = self.t(z)
        return iv.cos(z * self.pi)

    def tanpi(self, z):
        z = self.t(z)
        return self.tan(z * self.pi)

    def cotpi(self, z):
        z = self.t(z)
        return self.cot(z * self.pi)

    def cscpi(self, z):
        z = self.t(z)
        return self.csc(z * self.pi)

    def secpi(self, z):
        z = self.t(z)
        return self.sec(z * self.pi)



    def sinc(self, z):
        z = self.t(z)
        if z == 0:
            return self.t(1)
        else:
            return iv.sin(z) / z

    def sincpi(self, z):
        z = self.t(z)
        return self.sinc(z * self.pi)



# %%%  3.5 Hyperbolic functions

    def sinh(self, z):
        z = self.t(z)
        res = -1j * iv.sin(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def cosh(self, z):
        z = self.t(z)
        res = iv.cos(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def tanh(self, z):
        z = self.t(z)
        res = -1j * self.tan(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def sech(self, z):
        z = self.t(z)
        res = iv.sec(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def csch(self, z):
        z = self.t(z)
        res = 1j * iv.csc(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def coth(self, z):
        z = self.t(z)
        res = 1j * self.cot(1j * z)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res


# %%%  3.6 Inverse trigonometric functions

    def asin(self, z):
        z = self.t(z)
        res = -1j * iv.ln(1j * z + self.sqrt(1 - z*z))
        if isinstance(z, iv.mpf):
            if z in iv.mpf([-1, 1]):
                res = iv.re(res)
        return res

    def acos(self, z):
        z = self.t(z)
        res = 0.5 * mp.pi() + 1j * iv.ln(1j * z + self.sqrt(1 - z*z))
        if isinstance(z, iv.mpf):
            if z in iv.mpf([-1, 1]):
                res = iv.re(res)
        return res

    def atan(self, z):
        z = self.t(z)
        res = 0.5j * (iv.ln(1 - 1j * z) - iv.ln(1 + 1j * z))
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def atan2(self, x, y):
        return iv.atan2(x, y)

    def asec(self, z):
        z = self.t(z)
        return self.acos(1/z)

    def acsc(self, z):
        z = self.t(z)
        return self.asin(1/z)

    def acot(self, z):
        z = self.t(z)
        return self.atan(1/z)

    def gd(self, z):
        z = self.t(z)
        return self.asin(self.tanh(z))

    def archav(self, z):
        z = self.t(z)
        return 2*self.asin(self.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

    def asinh(self, z):
        z = self.t(z)
        res = self.asin(1j * z) / (1j)
        if isinstance(z, iv.mpf):
            res = iv.re(res)
        return res

    def acosh(self, z):
        z = self.t(z)
        res = iv.ln(z + self.sqrt(z+1) * self.sqrt(z-1))
        if isinstance(z, iv.mpf):
            if z in iv.mpf([+1, +mp.inf]):
                res = iv.re(res)
        return res

    def atanh(self, z):
        z = self.t(z)
        res = self.atan(1j * z) / (1j)
        if isinstance(z, iv.mpf):
            if z in iv.mpf([-1, +1]):
                res = iv.re(res)
        return res

    def asech(self, z):
        z = self.t(z)
        return self.acosh(1/z)

    def acsch(self, z):
        z = self.t(z)
        return self.asinh(1/z)

    def acoth(self, z):
        z = self.t(z)
        res = self.acot(-1j * z) / (1j)
        if isinstance(z, iv.mpf):
            if (z in iv.mpf([-mp.inf, -1])) or (z in iv.mpf([+1, +mp.inf])):
                res = iv.re(res)
        return res

    def arcgd(self, z):
        z = self.t(z)
        return self.atanh(iv.sin(z))


# %%%  3.8 Factorials and related functions

    def factorial(self, z):
        z = self.t(z)
        return iv.gamma(z+1)

    def binomial(self, n, k):
        n = self.t(n)
        k = self.t(k)
        return iv.gamma(n+1) / (iv.gamma(k+1) * iv.gamma(n-k+1))

    def multinomial(self, n, k):
        raise Exception("NOT IMPLEMENTED")

    def rf(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return iv.gamma(z+n) / iv.gamma(z)

    def ff(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return iv.gamma(z+1) / iv.gamma(z-n+1)

    def fac2(self, z):
        z = self.t(z)
        w = 0.25*(self.cospi(z)-1)
        return 2**(0.5*z) * (0.5*self.pi)**w * iv.gamma(0.5*z+1)


# %%%  3.9 Gamma function and related functions

    def gamma(self, z):
        z = self.t(z)
        return iv.gamma(z)

    def rgamma(self, z):
        z = self.t(z)
        return 1/iv.gamma(z)

    def loggamma(self, z):
        z = self.t(z)
        return iv.loggamma(z)

    def beta(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.gamma(a) * iv.gamma(b) / iv.gamma(a + b)

    def gamma_ratio(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return iv.gamma(a) / iv.gamma(b)

    def gamma_delta_ratio(self, a, delta):
        a = self.t(a)
        delta = self.t(delta)
        return iv.gamma(a) / iv.gamma(a + delta)

    def catalan_c(self, z):
        z = self.t(z)
        t = iv.gamma(z+1)
        return iv.gamma(2*z+1) / ((z+1)*t*t)


# %% 4 Real scalar functions


# %%% 4.1 Error functions for real arguments

    def real_erf(self, x):
        x = mp.mpf(self.t(x).mid)
        s = str(mp.erf(x))
        return mpi(s)

    def real_erfc(self, x):
        x = mp.mpf(self.t(x).mid)
        s = str(mp.erfc(x))
        return mpi(s)

    def real_erfinv(self, prob):
        prob = mp.mpf(self.t(prob).mid)
        s = str(mp.erfinv(prob))
        return mpi(s)

    def real_erfcinv(self, prob):
        prob = mp.mpf(self.t(prob).mid)
        s = str(mp.erfinv(1-prob))
        return mpi(s)


# %%% 4.2 Incomplete gamma functions for non-negative real arguments and parameters

    # Real lower non-normalised incomplete gamma function

    def real_gamma_lower(self, a, x, **kwargs):
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.gamma(a)

    # Real upper non-normalised incomplete gamma function

    def real_gamma_upper(self, a, x, **kwargs):
        res = self.real_gamma_q(a, x, **kwargs)
        return res * self.gamma(a)

    # Real lower normalised incomplete gamma function

    def real_gamma_p(self, a, x, **kwargs):
        a = mp.mpf(self.t(a).mid)
        x = mp.mpf(self.t(x).mid)
        s = str(ctxm.real_gamma_p(self, a, x, **kwargs))
        return self.t(s)

    # Real upper normalised incomplete gamma function

    def real_gamma_q(self, a, x, **kwargs):
        a = mp.mpf(self.t(a).mid)
        x = mp.mpf(self.t(x).mid)
        s = str(ctxm.real_gamma_q(self, a, x, **kwargs))
        return self.t(s)

    def real_gamma_tricomi(self, a, x, **kwargs):
        res = self.real_gamma_p(a, x, **kwargs)
        return res * self.power(x, -self.t(a))

    def real_gamma_p_inv(self, a, prob, **kwargs):
        a = mp.mpf(self.t(a).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_gamma_p_inv(self, a, prob, **kwargs))
        return self.t(s)

    def real_gamma_q_inv(self, a, prob, **kwargs):
        a = mp.mpf(self.t(a).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_gamma_q_inv(self, a, prob, **kwargs))
        return self.t(s)

    def real_gamma_p_inva(self, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_gamma_p_inva(self, x, prob, **kwargs))
        return self.t(s)

    def real_gamma_q_inva(self, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_gamma_q_inva(self, x, prob, **kwargs))
        return self.t(s)

    def real_gamma_derivative(self, a, x):
        a = self.t(a)
        x = self.t(x)
        return self.exp(-x) * self.power(x, a-1) / self.gamma(a)

 # %%%  4.3 Incomplete beta functions for non-negative real arguments and parameters

    def real_beta3(self, a, b, x, **kwargs):
        res = self.real_ibeta(a, b, x, **kwargs)
        return res * self.beta(a, b)

    def real_betac(self, a, b, x, **kwargs):
        res = self.real_ibetac(a, b, x, **kwargs)
        return res * self.beta(a, b)

    def real_ibeta(self, a, b, x, **kwargs):
        a = mp.mpf(self.t(a).mid)
        b = mp.mpf(self.t(b).mid)
        x = mp.mpf(self.t(x).mid)
        s = str(ctxm.real_ibeta(self, a, b, x, **kwargs))
        return self.t(s)

    def real_ibetac(self, a, b, x, **kwargs):
        a = mp.mpf(self.t(a).mid)
        b = mp.mpf(self.t(b).mid)
        x = mp.mpf(self.t(x).mid)
        s = str(ctxm.real_ibetac(self, a, b, x, **kwargs))
        return self.t(s)

    def real_ibeta_inv(self, a, b, prob, **kwargs):
        a = mp.mpf(self.t(a).mid)
        b = mp.mpf(self.t(b).mid)
        prob = mp.mpf(self.t(prob).mid)
        #s = str(ctxm.real_ibeta_inv(self, a, b, prob, **kwargs))
        s = str(mpm.real_ibeta_inv(self, a, b, prob, **kwargs))
        return self.t(s)

    def real_ibetac_inv(self, a, b, prob, **kwargs):
        a = mp.mpf(self.t(a).mid)
        b = mp.mpf(self.t(b).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_ibetac_inv(self, a, b, prob, **kwargs))
        return self.t(s)

    def real_ibeta_inva(self, b, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        b = mp.mpf(self.t(b).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_ibeta_inva(self, b, x, prob, **kwargs))
        return self.t(s)

    def real_ibetac_inva(self, b, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        b = mp.mpf(self.t(b).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_ibetac_inva(self, b, x, prob, **kwargs))
        return self.t(s)

    def real_ibeta_invb(self, a, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        a = mp.mpf(self.t(a).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_ibeta_invb(self, a, x, prob, **kwargs))
        return self.t(s)

    def real_ibetac_invb(self, a, x, prob, **kwargs):
        x = mp.mpf(self.t(x).mid)
        a = mp.mpf(self.t(a).mid)
        prob = mp.mpf(self.t(prob).mid)
        s = str(ctxm.real_ibetac_invb(self, a, x, prob, **kwargs))
        return self.t(s)

    def real_ibeta_derivative(self, a, b, x):
        a = self.t(a)
        b = self.t(b)
        x = self.t(x)
        return self.power(x, a-1) * self.power(1-x, b-1) / self.beta(a, b)


# %% 5 Basic continuous distribution functions


# %%%  5.1 Closed form distributions, based on elementary functions


# 5.1.1 Arcsine distribution, pdf

    def arcsine_pdf(self, x, a=0, b=1):
        return ctxm.arcsine_pdf(self, x, a, b)

# 5.1.2 Arcsine distribution, cdf and sf
    def arcsine_cdf(self, x, a=0, b=1, cdf=True):
        return ctxm.arcsine_cdf(self, x, a, b, cdf)

# 5.1.3 Arcsine distribution, qtf and isf
    def arcsine_qtf(self, prob, a=0, b=1, qtf=True):
        return ctxm.arcsine_qtf(self, prob, a, b, qtf)


# 5.1.4 Cauchy distribution, pdf

    def cauchy_pdf(self, x, a, b):
        return ctxm.cauchy_pdf(self, x, a, b)

# 5.1.5 Cauchy distribution, cdf and sf
    def cauchy_cdf(self, x, a, b, cdf=True):
        return ctxm.cauchy_cdf(self, x, a, b, cdf)

# 5.1.6 Cauchy distribution, qtf and isf
    def cauchy_qtf(self, prob, a, b, qtf=True):
        return ctxm.cauchy_qtf(self, prob, a, b, qtf)


# 5.1.7 Dagum distribution, pdf

    def dagum_pdf(self, x, a, b):
        return ctxm.dagum_pdf(self, x, a, b)

# 5.1.8 Dagum distribution, cdf and sf
    def dagum_cdf(self, x, a, b, cdf=True):
        return ctxm.dagum_cdf(self, x, a, b, cdf)

# 5.1.9 Dagum distribution, qtf and isf
    def dagum_qtf(self, prob, a, b, qtf=True):
        return ctxm.dagum_qtf(self, prob, a, b, qtf)


# 5.1.10 Exponential distribution, pdf

    def exponential_pdf(self, x, lambda1):
        return ctxm.exponential_pdf(self, x, lambda1)

# 5.1.11 Exponential distribution, cdf and sf
    def exponential_cdf(self, x, lambda1, cdf=True):
        return ctxm.exponential_cdf(self, x, lambda1, cdf)

# 5.1.12 Exponential distribution, qtf and isf
    def exponential_qtf(self, prob, lambda1, qtf=True):
        return ctxm.exponential_qtf(self, prob, lambda1, qtf)


# 5.1.13 Fisk distribution, pdf

    def fisk_pdf(self, x, a, b):
        return ctxm.fisk_pdf(self, x, a, b)

# 5.1.14 Fisk distribution, cdf and sf
    def fisk_cdf(self, x, a, b, cdf=True):
        return ctxm.fisk_cdf(self, x, a, b, cdf)

# 5.1.15 Fisk distribution, qtf and isf
    def fisk_qtf(self, prob, a, b, qtf=True):
        return ctxm.fisk_qtf(self, prob, a, b, qtf)


# 5.1.16 Frechet distribution, pdf

    def frechet_pdf(self, x, a, b):
        return ctxm.frechet_pdf(self, x, a, b)

# 5.1.17 Frechet distribution, cdf and sf
    def frechet_cdf(self, x, a, b, cdf=True):
        return ctxm.frechet_cdf(self, x, a, b, cdf)

# 5.1.18 Frechet distribution, qtf and isf
    def frechet_qtf(self, prob, a, b, qtf=True):
        return ctxm.frechet_qtf(self, prob, a, b, qtf)


# 5.1.19 Generalized Extreme Value (GEV), pdf

    def gev_pdf(self, x, a, b):
        return ctxm.gev_pdf(self, x, a, b)

# 5.1.20 Generalized Extreme Value (GEV), cdf and sf
    def gev_cdf(self, x, a, b, cdf=True):
        return ctxm.gev_cdf(self, x, a, b, cdf)

# 5.1.21 Generalized Extreme Value (GEV), qtf and isf
    def gev_qtf(self, prob, a, b, qtf=True):
        return ctxm.gev_qtf(self, prob, a, b, qtf)


# 5.1.22 Gompertz distribution, pdf

    def gompertz_pdf(self, x, a, b):
        return ctxm.gompertz_pdf(self, x, a, b)

# 5.1.23 Gompertz distribution, cdf and sf
    def gompertz_cdf(self, x, a, b, cdf=True):
        return ctxm.gompertz_cdf(self, x, a, b, cdf)

# 5.1.24 Gompertz distribution, qtf and isf
    def gompertz_qtf(self, prob, a, b, qtf=True):
        return ctxm.gompertz_qtf(self, prob, a, b, qtf)


# 5.1.25 Gumbel (Extreme Value) distribution, pdf

    def gumbel_pdf(self, x, a, b):
        return ctxm.gumbel_pdf(self, x, a, b)

# 5.1.26 Gumbel (Extreme Value) distribution, cdf and sf
    def gumbel_cdf(self, x, a, b, cdf=True):
        return ctxm.gumbel_cdf(self, x, a, b, cdf)

# 5.1.27 Gumbel (Extreme Value) distribution, qtf and isf
    def gumbel_qtf(self, prob, a, b, qtf=True):
        return ctxm.gumbel_qtf(self, prob, a, b, qtf)


# 5.1.28 Hyperexponential distribution, pdf

    def hyperexp_pdf(self, x, a, b):
        return ctxm.hyperexp_pdf(self, x, a, b)

# 5.1.29 Hyperexponential distribution, cdf and sf
    def hyperexp_cdf(self, x, a, b, cdf=True):
        return ctxm.hyperexp_cdf(self, x, a, b, cdf)

# 5.1.30 Hyperexponential distribution, qtf and isf
    def hyperexp_qtf(self, prob, a, b, qtf=True):
        return ctxm.hyperexp_qtf(self, prob, a, b, qtf)


# 5.1.31 Kumaraswamy distribution, pdf

    def kumaraswamy_pdf(self, x, a, b):
        return ctxm.kumaraswamy_pdf(self, x, a, b)

# 5.1.32 Kumaraswamy distribution, cdf and sf
    def kumaraswamy_cdf(self, x, a, b, cdf=True):
        return ctxm.kumaraswamy_cdf(self, x, a, b, cdf)

# 5.1.33 Kumaraswamy distribution, qtf and isf
    def kumaraswamy_qtf(self, prob, a, b, qtf=True):
        return ctxm.kumaraswamy_qtf(self, prob, a, b, qtf)


# 5.1.34 Laplace distribution, pdf

    def laplace_pdf(self, x, a, b):
        return ctxm.laplace_pdf(self, x, a, b)

# 5.1.35 Laplace distribution, cdf and sf
    def laplace_cdf(self, x, a, b, cdf=True):
        return ctxm.laplace_cdf(self, x, a, b, cdf)

# 5.1.36 Laplace distribution, qtf and isf
    def laplace_qtf(self, prob, a, b, qtf=True):
        return ctxm.laplace_qtf(self, prob, a, b, qtf)


# 5.1.37 Logistic distribution, pdf

    def logistic_pdf(self, x, a, b):
        return ctxm.logistic_pdf(self, x, a, b)

# 5.1.38 Logistic distribution, cdf and sf
    def logistic_cdf(self, x, a, b, cdf=True):
        return ctxm.logistic_cdf(self, x, a, b, cdf)

# 5.1.39 Logistic distribution, qtf and isf
    def logistic_qtf(self, prob, a, b, qtf=True):
        return ctxm.logistic_qtf(self, prob, a, b, qtf)


# 5.1.40 Lomax distribution, pdf

    def lomax_pdf(self, x, a, b):
        return ctxm.lomax_pdf(self, x, a, b)

# 5.1.41 Lomax distribution, cdf and sf
    def lomax_cdf(self, x, a, b, cdf=True):
        return ctxm.lomax_cdf(self, x, a, b, cdf)

# 5.1.42 Lomax distribution, qtf and isf
    def lomax_qtf(self, prob, a, b, qtf=True):
        return ctxm.lomax_qtf(self, prob, a, b, qtf)


# 5.1.43 Pareto distribution, pdf

    def pareto_pdf(self, x, a, b):
        return ctxm.pareto_pdf(self, x, a, b)

# 5.1.44 Pareto distribution, cdf and sf
    def pareto_cdf(self, x, a, b, cdf=True):
        return ctxm.pareto_cdf(self, x, a, b, cdf)

# 5.1.45 Pareto distribution, qtf and isf
    def pareto_qtf(self, prob, a, b, qtf=True):
        return ctxm.pareto_qtf(self, prob, a, b, qtf)


# 5.1.46 Rayleigh distribution, pdf

    def rayleigh_pdf(self, x, b):
        return ctxm.rayleigh_pdf(self, x, b)

# 5.1.47 Rayleigh distribution, cdf and sf
    def rayleigh_cdf(self, x, b, cdf=True):
        return ctxm.rayleigh_cdf(self, x, b, cdf)

# 5.1.48 Rayleigh distribution, qtf and isf
    def rayleigh_qtf(self, prob, b, qtf=True):
        return ctxm.rayleigh_qtf(self, prob, b, qtf)


# 5.1.49 Singh-Maddala (Burr Type XII) distribution, pdf

    def singh_maddala_pdf(self, x, b):
        return ctxm.singh_maddala_pdf(self, x, b)

# 5.1.50 Singh-Maddala (Burr Type XII) distribution, cdf and sf
    def singh_maddala_cdf(self, x, b, cdf=True):
        return ctxm.singh_maddala_cdf(self, x, b, cdf)

# 5.1.51 Singh-Maddala (Burr Type XII) distribution, qtf and isf
    def singh_maddala_qtf(self, prob, b, qtf=True):
        return ctxm.singh_maddala_qtf(self, prob, b, qtf)


# 5.1.52 Triangular distribution, pdf

    def triangular_pdf(self, x, lower, upper, mode):
        return ctxm.triangular_pdf(self, x, lower, upper, mode)

# 5.1.53 Triangular distribution, cdf and sf
    def triangular_cdf(self, x, lower, mode, upper, cdf=True):
        return ctxm.triangular_cdf(self, x, lower, mode, upper, cdf)


# 5.1.54 Triangular distribution, qtf and isf

    def triangular_qtf(self, prob, lower, mode, upper, qtf=True):
        return ctxm.triangular_qtf(self, prob, lower, mode, upper, qtf)


# 5.1.55 Uniform distribution, pdf

    def uniform_pdf(self, x, a, b):
        return ctxm.uniform_pdf(self, x, a, b)

# 5.1.56 Uniform distribution, cdf and sf
    def uniform_cdf(self, x, a, b, cdf=True):
        return ctxm.uniform_cdf(self, x, a, b, cdf)


# 5.1.57 Uniform distribution, qtf and isf

    def uniform_qtf(self, prob, a, b, qtf=True):
        return ctxm.uniform_qtf(self, prob, a, b, qtf)


# 5.1.58 Weibull distribution, pdf

    def weibull_pdf(self, x, a, b):
        return ctxm.weibull_pdf(self, x, a, b)

# 5.1.59 Weibull distribution, cdf and sf
    def weibull_cdf(self, x, a, b, cdf=True):
        return ctxm.weibull_cdf(self, x, a, b, cdf)

# 5.1.60 Weibull distribution, qtf and isf
    def weibull_qtf(self, prob, a, b, qtf=True):
        return ctxm.weibull_qtf(self, prob, a, b, qtf)


# %%%  5.2 Closed form distributions, based on the error function


# 5.2.1 Birnbaum-Saunders distribution, pdf

    def birnb_saunders_pdf(self, x, mu, sigma):
        return ctxm.birnb_saunders_pdf(self, x, mu, sigma)

# 5.2.2 Birnbaum-Saunders distribution, cdf and sf
    def birnb_saunders_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.birnb_saunders_cdf(self, x, mu, sigma, cdf)

# 5.2.3 Birnbaum-Saunders distribution distribution, qtf and isf
    def birnb_saunders_qtff(self, x, mu, sigma, qtf=True):
        return ctxm.birnb_saunders_qtff(self, x, mu, sigma, qtf)


# 5.2.4 Exponentially Modified Gaussian (EMG) distribution, pdf

    def emg_pdf(self, x, mu, sigma):
        return ctxm.emg_pdf(self, x, mu, sigma)

# 5.2.5 Exponentially Modified Gaussian (EMG) distribution, cdf and sf
    def emg_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.emg_cdf(self, x, mu, sigma, cdf)

# 5.2.6 Exponentially Modified Gaussian (EMG) distribution, qtf and isf
    def emg_qtff(self, x, mu, sigma, qtf=True):
        return ctxm.emg_qtff(self, x, mu, sigma, qtf)


# 5.2.7 Folded normal distribution, pdf

    def folded_normal_pdf(self, x, sigma):
        return ctxm.folded_normal_pdf(self, x, sigma)

# 5.2.8 Folded normal distribution, cdf and sf
    def folded_normal_cdf(self, x, sigma, cdf=True):
        return ctxm.folded_normal_cdf(self, x, sigma, cdf)

# 5.2.9 Folded normal distribution, qtf and isf
    def folded_normal_qtff(self, x, sigma, qtf=True):
        return ctxm.folded_normal_qtff(self, x, sigma, qtf)


# 5.2.10 Half-normal distribution, pdf

    def half_normal_pdf(self, x, sigma):
        return ctxm.half_normal_pdf(self, x, sigma)

# 5.2.11 Half_normal distribution, cdf and sf
    def half_normal_cdf(self, x, sigma, cdf=True):
        return ctxm.half_normal_cdf(self, x, sigma, cdf)

# 5.2.12 Half_normal distribution, qtf and isf
    def half_normal_qtff(self, x, sigma, qtf=True):
        return ctxm.half_normal_qtff(self, x, sigma, qtf)


# 5.2.13 Johnson 𝑆𝐵 distribution, pdf

    def johnson_sb_pdf(self, x, sigma):
        return ctxm.johnson_sb_pdf(self, x, sigma)

# 5.2.14 Johnson 𝑆𝐵 distribution, cdf and sf
    def johnson_sb_cdf(self, x, sigma, cdf=True):
        return ctxm.johnson_sb_cdf(self, x, sigma, cdf)

# 5.2.15 Johnson 𝑆𝐵 distribution, qtf and isf
    def johnson_sb_qtff(self, x, sigma, qtf=True):
        return ctxm.johnson_sb_qtff(self, x, sigma, qtf)


# 5.2.16 Johnson 𝑆𝑈 distribution, pdf

    def johnson_su_pdf(self, x, sigma):
        return ctxm.johnson_su_pdf(self, x, sigma)

# 5.2.17 Johnson 𝑆𝑈 distribution, cdf and sf
    def johnson_su_cdf(self, x, sigma, cdf=True):
        return ctxm.johnson_su_cdf(self, x, sigma, cdf)

# 5.2.18 Johnson 𝑆𝑈 distribution, qtf and isf
    def johnson_su_qtff(self, x, sigma, qtf=True):
        return ctxm.johnson_su_qtff(self, x, sigma, qtf)


# 5.2.19 Lévy distribution, pdf

    def levy_pdf(self, x, a, b):
        return ctxm.levy_pdf(self, x, a, b)

# 5.2.20 Lévy distribution, cdf and sf
    def levy_cdf(self, x, a, b, cdf=True):
        return ctxm.levy_cdf(self, x, a, b, cdf)

# 5.2.21 Lévy distribution, qtf and isf
    def levy_qtf(self, prob, a, b, qtf=True):
        return ctxm.levy_qtf(self, prob, a, b, qtf)


# 5.2.22 Lognormal distribution, pdf

    def lognormal_pdf(self, x, mu, sigma):
        return ctxm.lognormal_pdf(self, x, mu, sigma)

# 5.2.23 Lognormal distribution, cdf and sf
    def lognormal_cdf(self, x, mu, sigma, cdf=True):
        return ctxm.lognormal_cdf(self, x, mu, sigma, cdf)

# 5.2.24 Lognormal distribution, qtf and isf
    def lognormal_qtf(self, prob, mu, sigma, qtf=True):
        return ctxm.lognormal_qtf(self, prob, mu, sigma, qtf)


# 5.2.25 Moyal distribution, pdf

    def moyal_pdf(self, x, a, b):
        return ctxm.moyal_pdf(self, x, a, b)

# 5.2.26 Moyal distribution, cdf and sf
    def moyal_cdf(self, x, a, b, cdf=True):
        return ctxm.moyal_cdf(self, x, a, b, cdf)

# 5.2.27 Moyal distribution, qtf and isf
    def moyal_qtf(self, prob, a, b, qtf=True):
        return ctxm.moyal_qtf(self, prob, a, b, qtf)


# 5.2.28 Normal distribution, pdf

    def normal_pdf(self, x, mu=0, sigma=1):
        return ctxm.normal_pdf(self, x, mu, sigma)

# 5.2.29 Normal distribution, cdf and sf
    def normal_cdf(self, x, mu=0, sigma=1, cdf=True):
        return ctxm.normal_cdf(self, x, mu, sigma, cdf)

# 5.2.30 Normal distribution, qtf and isf
    def normal_qtf(self, prob, mu=0, sigma=1, qtf=True):
        return ctxm.normal_qtf(self, prob, mu, sigma, qtf)


# 5.2.31 Skew normal distribution, pdf

    def skewnormal_pdf(self, x, a, b, c):
        return ctxm.skewnormal_pdf(self, x, a, b, c)

# 5.2.32 Skew normal distribution, cdf and sf
    def skewnormal_cdf(self, x, a, b, c, cdf=True):
        return ctxm.skewnormal_cdf(self, x, a, b, c, cdf)

# 5.2.33 Skew normal distribution, qtf and isf
    def skewnormal_qtf(self, prob, a, b, c, qtf=True):
        return ctxm.skewnormal_qtf(self, prob, a, b, c, qtf)


# 5.2.34 Truncated normal distribution, pdf

    def trunc_normal_pdf(self, x, a, b, c):
        return ctxm.trunc_normal_pdf(self, x, a, b, c)

# 5.2.35 Truncated normal distribution, cdf and sf
    def trunc_normal_cdf(self, x, a, b, c, cdf=True):
        return ctxm.trunc_normal_cdf(self, x, a, b, c, cdf)

# 5.2.36 Truncated normal distribution, qtf and isf
    def trunc_normal_qtf(self, prob, a, b, c, qtf=True):
        return ctxm.trunc_normal_qtf(self, prob, a, b, c, qtf)


# 5.2.37 Wald distribution, pdf

    def wald_pdf(self, x, mu, b):
        return ctxm.wald_pdf(self, x, mu, b)

# 5.2.38 Wald distribution, cdf and sf
    def wald_cdf(self, x, mu, b, cdf=True):
        return ctxm.wald_cdf(self, x, mu, b, cdf)

# 5.2.39 Wald distribution, qtf and isf
    def wald_qtf(self, prob, mu, b, qtf=True):
        return ctxm.wald_qtf(self, prob, mu, b, qtf)


# %%%  5.3 Closed form distributions, based on the incomplete gamma function


# 5.3.1 Amoroso distribution, pdf

    def amoroso_pdf(self, x, nu):
        return ctxm.amoroso_pdf(self, x, nu)

# 5.3.2 Amoroso distribution, cdf and sf
    def amoroso_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.amoroso_cdf(self, x, nu, cdf, **kwargs)

# 5.3.3 Amoroso distribution, qtf and isf
    def amoroso_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.amoroso_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.4 𝜒-distribution, pdf

    def chi_pdf(self, x, nu):
        return ctxm.chi_pdf(self, x, nu)

# 5.3.5 𝜒-distribution, cdf and sf
    def chi_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.chi_cdf(self, x, nu, cdf, **kwargs)

# 5.3.6 𝜒-distribution, qtf and isf
    def chi_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.chi_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.7 𝜒2-distribution, pdf

    def chi_squared_pdf(self, x, nu):
        return ctxm.chi_squared_pdf(self, x, nu)

# 5.3.8 𝜒2-distribution, cdf and sf
    def chi_squared_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.chi_squared_cdf(self, x, nu, cdf, **kwargs)

# 5.3.9 𝜒2-distribution, qtf and isf
    def chi_squared_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.chi_squared_qtf(self, prob, nu, qtf, **kwargs)


# 5.3.10 Distribution of the logarithm of a 𝜒2 random variable, pdf

    def logchisquare_pdf(self, x, nu):
        return ctxm.logchisquare_pdf(self, x, nu)

# 5.3.11 Distribution of the logarithm of a 𝜒2 random variable, cdf and sf
    def logchisquare_cdf(self, x, nu, cdf=True, **kwargs):
        return ctxm.logchisquare_cdf(self, x, nu, cdf, **kwargs)

    def logchisquare_sf(self, x, nu, cdf=True, **kwargs):
        return ctxm.logchisquare_sf(self, x, nu, cdf, **kwargs)

# 5.3.12 Distribution of the logarithm of a 𝜒2 random variable, qtf and isf
    def logchisquare_qtf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.logchisquare_qtf(self, prob, nu, qtf, **kwargs)

    def logchisquare_isf(self, prob, nu, qtf=True, **kwargs):
        return ctxm.logchisquare_isf(self, prob, nu, qtf, **kwargs)


# 5.3.13 Gamma distribution, pdf

    def gamma_pdf(self, x, a, b):
        return ctxm.gamma_pdf(self, x, a, b)

# 5.3.14 Gamma distribution, cdf and sf
    def gamma_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.gamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.15 Gamma distribution, qtf and isf
    def gamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.gamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.16 Inverse 𝜒2-distribution, pdf

    def invchisquared_pdf(self, x, a, b):
        return ctxm.invchisquared_pdf(self, x, a, b)

# 5.3.17 Inverse 𝜒2-distribution, cdf and sf
    def invchisquared_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.invchisquared_cdf(self, x, a, b, cdf)

# 5.3.18 Inverse 𝜒2-distribution, qtf and isf
    def invchisquared_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.invchisquared_qtf(self, prob, a, b, qtf)


# 5.3.19 Inverse Gamma distribution, pdf

    def invgamma_pdf(self, x, a, b):
        return ctxm.invgamma_pdf(self, x, a, b)

# 5.3.20 Inverse Gamma distribution, cdf and sf
    def invgamma_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.invgamma_cdf(self, x, a, b, cdf, **kwargs)

# 5.3.21 Inverse Gamma distribution, qtf and isf
    def invgamma_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.invgamma_qtf(self, prob, a, b, qtf, **kwargs)


# 5.3.22 Maxwell distribution, pdf

    def maxwell_pdf(self, x, b):
        return ctxm.maxwell_pdf(self, x, b)

# 5.3.23 Maxwell distribution, cdf and sf
    def maxwell_cdf(self, x, b, cdf=True, **kwargs):
        return ctxm.maxwell_cdf(self, x, b, cdf, **kwargs)

# 5.3.24 Maxwell distribution, qtf and isf
    def maxwell_qtf(self, prob, b, qtf=True, **kwargs):
        return ctxm.maxwell_qtf(self, prob, b, qtf, **kwargs)


# 5.3.25 Nakagami distribution, pdf

    def nakagami_pdf(self, x, m, w):
        return ctxm.nakagami_pdf(self, x, m, w)

# 5.3.26 Nakagami distribution, cdf and sf
    def nakagami_cdf(self, x, m, w, cdf=True, **kwargs):
        return ctxm.nakagami_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.27 Nakagami distribution, qtf and isf
    def nakagami_qtf(self, prob, m, w, qtf=True, **kwargs):
        return ctxm.nakagami_qtf(self, prob, m, w, qtf, **kwargs)


# 5.3.28 Stacy (generalized gamma) distribution, pdf

    def stacy_pdf(self, x, m, w):
        return ctxm.stacy_pdf(self, x, m, w)

# 5.3.29 Stacy (generalized gamma) distribution, cdf and sf
    def stacy_cdf(self, x, m, w, cdf=True, **kwargs):
        return ctxm.stacy_cdf(self, x, m, w, cdf, **kwargs)

# 5.3.30 Stacy (generalized gamma) distribution, qtf and isf
    def stacy_qtf(self, prob, m, w, qtf=True, **kwargs):
        return ctxm.stacy_qtf(self, prob, m, w, qtf, **kwargs)


# %%%  5.4 Closed form distributions, based on the incomplete beta function


# 5.4.1 Beta distribution, pdf

    def beta_pdf(self, x, a, b):
        return ctxm.beta_pdf(self, x, a, b)

# 5.4.2 Beta distribution, cdf and sf
    def beta_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.beta_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.3 Beta distribution, qtf and isf
    def beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.beta_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.4 Distribution of the negative logarithm of a beta variable, pdf

    def logrv_beta_pdf(self, x, a, b):
        return ctxm.logbeta_pdf(self, x, a, b)

# 5.4.5 Distribution of the negative logarithm of a beta variable, cdf and sf
    def logrv_beta_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.logbeta_cdf(self, x, a, b, cdf, **kwargs)

    def logrv_beta_sf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.logbeta_sf(self, x, a, b, cdf, **kwargs)

# 5.4.6 Distribution of the negative logarithm of a beta variable, qtf and isf
    def logrv_beta_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.logbeta_qtf(self, prob, a, b, qtf, **kwargs)

    def logrv_beta_isf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.logbeta_isf(self, prob, a, b, qtf, **kwargs)


# 5.4.7 Beta-prime distribution, pdf

    def beta_prime_pdf(self, x, a, b):
        return ctxm.beta_prime_pdf(self, x, a, b)

# 5.4.8 Beta-prime distribution, cdf and sf
    def beta_prime_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.beta_prime_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.9 Beta-prime distribution, qtf and isf
    def beta_prime_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.beta_prime_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.10 Generalized Beta (Type 1) distribution, pdf

    def genbeta1_pdf(self, x, a, b):
        return ctxm.genbeta1_pdf(self, x, a, b)

# 5.4.11 Generalized Beta (Type 1) distribution, cdf and sf
    def genbeta1_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genbeta1_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.12 Generalized Beta (Type 1) distribution, qtf and isf
    def genbeta1_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genbeta1_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.13 Generalized Beta (Type 2) distribution, pdf

    def genbeta2_pdf(self, x, a, b):
        return ctxm.genbeta2_pdf(self, x, a, b)

# 5.4.14 Generalized Beta (Type 2) distribution, cdf and sf
    def genbeta2_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genbeta2_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.15 Generalized Beta (Type 2) distribution, qtf and isf
    def genbeta2_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genbeta2_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.16 Generalized logistic distribution, pdf

    def genlogistic_pdf(self, x, a, b):
        return ctxm.genlogistic_pdf(self, x, a, b)

# 5.4.17 Generalized logistic distribution, cdf and sf
    def genlogistic_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.genlogistic_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.18 Generalized logistic distribution, qtf and isf
    def genlogistic_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.genlogistic_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.19 Generalized beta-exponential distribution, pdf

    def gen_beta_exp_pdf(self, x, a, b):
        return ctxm.gen_beta_exp_pdf(self, x, a, b)

# 5.4.20 Generalized beta-exponential distribution, cdf and sf
    def gen_beta_exp_cdf(self, x, a, b, cdf=True, **kwargs):
        return ctxm.gen_beta_exp_cdf(self, x, a, b, cdf, **kwargs)

# 5.4.21 Generalized beta-exponential distribution, qtf and isf
    def gen_beta_exp_qtf(self, prob, a, b, qtf=True, **kwargs):
        return ctxm.gen_beta_exp_qtf(self, prob, a, b, qtf, **kwargs)


# 5.4.22 Fisher 𝐹 distribution, pdf

    def fisher_f_pdf(self, x, df1, df2, **kwargs):
        return ctxm.fisher_f_pdf(self, x, df1, df2)

# 5.4.23 Fisher 𝐹 distribution, cdf and sf
    def fisher_f_cdf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_f_cdf(self, x, df1, df2, cdf, **kwargs)

# 5.4.24 Fisher 𝐹 distribution, qtf and isf
    def fisher_f_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_f_qtf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.25 Fisher 𝑧 distribution, pdf

    def fisher_z_pdf(self, x, df1, df2, **kwargs):
        return ctxm.fisher_z_pdf(self, x, df1, df2)

# 5.4.26 Fisher 𝑧 distribution, cdf and sf
    def fisher_z_cdf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_z_cdf(self, x, df1, df2, cdf, **kwargs)

    def fisher_z_sf(self, x, df1, df2, cdf=True, **kwargs):
        return ctxm.fisher_z_sf(self, x, df1, df2, cdf, **kwargs)

# 5.4.27 Fisher 𝑧 distribution, qtf and isf
    def fisher_z_qtf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_z_qtf(self, prob, df1, df2, qtf, **kwargs)

    def fisher_z_isf(self, prob, df1, df2, qtf=True, **kwargs):
        return ctxm.fisher_z_isf(self, prob, df1, df2, qtf, **kwargs)


# 5.4.28 Student 𝑡 distribution, pdf

    def student_t_pdf(self, x, df):
        return ctxm.student_t_pdf(self, x, df)

# 5.4.29 Student 𝑡 distribution, cdf and sf
    def student_t_cdf(self, x, df, cdf=True, **kwargs):
        return ctxm.student_t_cdf(self, x, df, cdf, **kwargs)

# 5.4.30 Student 𝑡 distribution, qtf and isf
    def student_t_qtf(self, prob, df, qtf=True, **kwargs):
        return ctxm.student_t_qtf(self, prob, df, qtf, **kwargs)


# 5.4.31 Pearson’s rho distribution (under 𝐻0): pdf

    def pearson_rho_pdf(self, r, N):
        return ctxm.pearson_rho_pdf(self, r, N)

# 5.4.32 Pearson’s rho distribution (under 𝐻0): cdf and sf
    def pearson_rho_cdf(self, r, N, cdf=True, **kwargs):
        return ctxm.pearson_rho_cdf(self, r, N, cdf)

# 5.4.33 Pearson’s rho distribution (under 𝐻0): qtf and isf
    def pearson_rho_qtf(self, q, N, qtf=True, **kwargs):
        return ctxm.pearson_rho_qtf(self, q, N, qtf)


# %% 6 Advanced continuous distribution functions


# %%%  6.1 Closed form distributions, based on the distribution of the product of beta variables


# 6.1.2 Distribution of the product of independent beta variables, pdf

    def beta_product_pdf(self, x, p, bi, ci, method='default'):
        return ctxm.beta_product_pdf(self, x, p, bi, ci, method)


# 6.1.3 Distribution of the product of independent beta variables, cdf and sf

    def beta_product_cdf(self, x, p, bi, ci, cdf=True, method='default'):
        return ctxm.beta_product_cdf(self, x, p, bi, ci, cdf, method)


# 6.1.4 Distribution of the product of independent beta variables, qtf and isf

    def beta_product_qtf(self, q, p, bi, ci, qtf=True, method='default'):
        return ctxm.beta_product_qtf(self, q, p, bi, ci, qtf, method)


# %%%  6.2 Distribution functions related to multivariate statistical analysis


# 6.2.1 Roy’s largest root distribution, pdf, cdf and sf

    def roy_pdf_cdf_sf(self, x, p, n1, n2):
        return ctxm.roy_pdf_cdf_sf(self, x, p, n1, n2)


# 6.2.2 Roy’s largest root distribution, pdf

    def roy_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.roy_pdf(self, x, p, n1, n2, method)


# 6.2.3 Roy’s largest root distribution, cdf and sf

    def roy_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.roy_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.4 Roy’s largest root distribution, qtf and isf

    def roy_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.roy_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.5 Wilks’ Λ distribution, pdf

    def wilks_lambda_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.wilks_lambda_pdf(self, x, p, n1, n2, method)


# 6.2.6 Wilks’ Λ distribution, cdf and sf

    def wilks_lambda_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.wilks_lambda_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.7 Wilks’ Λ distribution, qtf and isf

    def wilks_lambda_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.wilks_lambda_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.8 Pillai’s 𝑉 distribution, pdf

    def pillai_v_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.pillai_v_pdf(self, x, p, n1, n2, method)


# 6.2.9 Pillai’s 𝑉 distribution, cdf and sf

    def pillai_v_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.pillai_v_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.10 Pillai’s 𝑉 distribution, qtf and isf

    def pillai_v_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.pillai_v_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.11 Hotelling’s 𝑇2 distribution, pdf

    def hotelling_t2_pdf(self, x, p, n1, n2, method='default'):
        return ctxm.hotelling_t2_pdf(self, x, p, n1, n2, method)


# 6.2.12 Hotelling’s 𝑇2 distribution, cdf and sf

    def hotelling_t2_cdf(self, x, p, n1, n2, cdf=True, method='default'):
        return ctxm.hotelling_t2_cdf(self, x, p, n1, n2, cdf, method)


# 6.2.13 Hotelling’s 𝑇2 distribution, qtf and isf

    def hotelling_t2_qtf(self, q, p, n1, n2, qtf=True, method='default'):
        return ctxm.hotelling_t2_qtf(self, q, p, n1, n2, qtf, method)


# 6.2.14 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, pdf

    def box_cov_pdf(self, x, p, ni, method='default'):
        return ctxm.box_cov_pdf(self, x, p, ni, method)


# 6.2.15 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, cdf and sf

    def box_cov_cdf(self, x, p, ni, cdf=True, method='default'):
        return ctxm.box_cov_cdf(self, x, p, ni, cdf, method)


# 6.2.16 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes, qtf and isf

    def box_cov_qtf(self, q, p, ni, qtf=True, method='default'):
        return ctxm.box_cov_qtf(self, q, p, ni, qtf, method)


# 6.2.17 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, pdf

    def box_means_cov_pdf(self, x, p, ni, method='default'):
        return ctxm.box_means_cov_pdf(self, x, p, ni, method)


# 6.2.18 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, cdf and sf

    def box_means_cov_cdf(self, x, p, ni, cdf=True, method='default'):
        return ctxm.box_means_cov_cdf(self, x, p, ni, cdf, method)


# 6.2.19 Distribution of Box’s test for same multivariate normal distributions,, unequal sample sizes, qtf and isf

    def box_means_cov_qtf(self, q, p, ni, qtf=True, method='default'):
        return ctxm.box_means_cov_qtf(self, q, p, ni, qtf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, pdf

    def lrt_vc0_pdf(self, x, p, n, method='default'):
        return ctxm.lrt_vc0_pdf(self, x, p, n, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, cdf and sf

    def lrt_vc0_cdf(self, x, p, n, cdf=True, method='default'):
        return ctxm.lrt_vc0_cdf(self, x, p, n, cdf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix, qtf and isf

    def lrt_vc0_qtf(self, q, p, n, qtf=True, method='default'):
        return ctxm.lrt_vc0_qtf(self, q, p, n, qtf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, pdf

    def lrt_x0_vc0_pdf(self, x, p, n, method='default'):
        return ctxm.lrt_x0_vc0_pdf(self, x, p, n, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, cdf and sf

    def lrt_x0_vc0_cdf(self, x, p, n, cdf=True, method='default'):
        return ctxm.lrt_x0_vc0_cdf(self, x, p, n, cdf, method)


# 6.2.20 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean, qtf and isf

    def lrt_x0_vc0_qtf(self, q, p, n, qtf=True, method='default'):
        return ctxm.lrt_x0_vc0_qtf(self, q, p, n, qtf, method)


# %%%  6.3 Distributions related to the multivariate normal distribution


# 6.3.3 Normal maximum distribution: pdf

    def nmax_pdf(self, x, k):
        return ctxm.nmax_pdf(self, x, k)

# 6.3.4 Normal maximum distribution: cdf and sf
    def nmax_cdf(self, x, k):
        return ctxm.nmax_cdf(self, x, k)

# 6.3.5 Normal maximum distribution: qtf and isf
    def nmax_qtf(self, q, k):
        return ctxm.nmax_qtf(self, q, k)


# 6.3.6 Normal maximum modulus distribution: pdf

    def nmm_pdf(self, x, k):
        return ctxm.nmm_pdf(self, x, k)

# 6.3.7 Normal maximum modulus distribution: cdf and sf
    def nmm_cdf(self, x, k):
        return ctxm.nmm_cdf(self, x, k)

# 6.3.8 Normal maximum modulus distribution: qtf and isf
    def nmm_qtf(self, q, k):
        return ctxm.nmm_qtf(self, q, k)


# 6.3.9 Normal maximum distribution, equicorrelated case: pdf

    def nmax_corr_pdf(self, x, k, rho):
        return ctxm.nmax_corr_pdf(self, x, k, rho)

# 6.3.10 Normal maximum distribution, equicorrelated case:: cdf and sf
    def nmax_corr_cdf(self, x, k, rho, cdf=True):
        return ctxm.nmax_corr_cdf(self, x, k, rho)

# 6.3.11 Normal maximum distribution, equicorrelated case: qtf and isf
    def nmax_corr_qtf(self, q, k, rho, qtf=True):
        return ctxm.nmax_corr_qtf(self, q, k, rho, qtf=True)


# 6.3.12 Normal maximum modulus distribution, equicorrelated case: pdf

    def nmm_corr_pdf(self, x, k, rho):
        return ctxm.nmm_corr_pdf(self, x, k, rho)

# 6.3.13 Normal maximum modulus distribution, equicorrelated case: cdf and sf
    def nmm_corr_cdf(self, x, k, rho, cdf=True):
        return ctxm.nmm_corr_cdf(self, x, k, rho)

# 6.3.14 Normal maximum modulus distribution, equicorrelated case: qtf and isf
    def nmm_corr_qtf(self, q, k, rho, qtf=True):
        return ctxm.nmm_corr_qtf(self, q, k, rho, qtf)


# 6.3.15 Normal range distribution: pdf

    def nrange_pdf(self, x, k):
        return ctxm.nrange_pdf(self, x, k)

# 6.3.16 Normal range distribution: cdf and sf
    def nrange_cdf(self, x, k, cdf=True):
        return ctxm.nrange_cdf(self, x, k)

# 6.3.17 Normal range distribution: qtf and isf
    def nrange_qtf(self, q, k, qtf=True):
        return ctxm.nrange_qtf(self, q, k, qtf)


# %%%  6.4 Distributions related to multiple comparisons of means


# 6.4.3 Studentized maximum distribution: pdf

    def smax_pdf(self, x, k, n):
        return ctxm.smax_pdf(self, x, k, n)


# 6.4.4 Studentized maximum distribution: cdf and sf

    def smax_cdf(self, x, k, n, cdf=True):
        return ctxm.smax_cdf(self, x, k, n)


# 6.4.5 Studentized maximum distribution: qtf and isf

    def smax_qtf(self, q, k, n, qtf=True):
        return ctxm.smax_qtf(self, q, k, n, qtf)


# 6.4.7 Studentized maximum modulus distribution: pdf

    def smm_pdf(self, x, k, n):
        return ctxm.smm_pdf(self, x, k, n)


# 6.4.8 Studentized maximum modulus distribution: cdf and sf

    def smm_cdf(self, x, k, n, cdf=True):
        return ctxm.smm_cdf(self, x, k, n)


# 6.4.9 Studentized maximum modulus distribution: cdf and sf

    def smm_qtf(self, q, k, n, qtf=True):
        return ctxm.smm_qtf(self, q, k, n, qtf)


# 6.4.11 Dunnett’s 𝑡-distribution, 1-sided: pdf

    def dunnett1_pdf(self, x, k, n, rho):
        return ctxm.dunnett1_pdf(self, x, k, n, rho)

# 6.4.12 Dunnett’s 𝑡-distribution, 1-sided: cdf and sf
    def dunnett1_cdf(self, x, k, n, rho, cdf=True):
        return ctxm.dunnett1_cdf(self, x, k, n, rho)

# 6.4.13 Dunnett’s 𝑡-distribution, 1-sided: qtf and isf
    def dunnett1_qtf(self, q, k, n, rho, qtf=True):
        return ctxm.dunnett1_qtf(self, q, k, n, rho, qtf)


# 6.4.15 Dunnett’s t-distribution, 2-sided: pdf

    def dunnett2_pdf(self, x, k, n, rho):
        return ctxm.dunnett2_pdf(self, x, k, n, rho)

# 6.4.16 Dunnett’s 𝑡-distribution, 2-sided: cdf and sf
    def dunnett2_cdf(self, x, k, n, rho, cdf=True):
        return ctxm.dunnett2_cdf(self, x, k, n, rho)

# 6.4.17 Dunnett’s 𝑡-distribution, 2-sided: qtf and isf
    def dunnett2_qtf(self, q, k, n, rho, qtf=True):
        return ctxm.dunnett2_qtf(self, q, k, n, rho, qtf)


# 6.4.19 Studentized range distribution: pdf

    def srange_pdf(self, x, k, n):
        return ctxm.srange_pdf(self, x, k, n)

# 6.4.20 Studentized range distribution: cdf and isf
    def srange_cdf(self, x, k, n, cdf=True):
        return ctxm.srange_cdf(self, x, k, n)


# 6.4.21 Studentized range distribution: qtf and isf

    def srange_qtf(self, q, k, n, qtf=True):
        return ctxm.srange_qtf(self, q, k, n, qtf)


# %%%  6.5 Noncentral distribution functions


# 6.5.1 Non-central 𝜒2-distribution, pdf

    def chi_squared_nc_pdf(self, x, n, lambda1, method='default'):
        return ctxm.chi_squared_nc_pdf(self, x, n, lambda1, method)

# 6.5.2 Non-central 𝜒2-distribution, cdf and sf
    def chi_squared_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        return ctxm.chi_squared_nc_cdf(self, x, n, lambda1, cdf, method)

    # Noncentral ch^2-distribution, cdf (Chou1985)
    def chi2nc_cdf(self, x, n, lambda1):
        return ctxm.chi2nc_cdf(self, x, n, lambda1)

# 6.5.3 Non-central 𝜒2-distribution, qtf and isf
    def chi_squared_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        return ctxm.chi_squared_nc_qtf(self, q, n, lambda1, qtf, method)

# 6.5.4 Non-central 𝜒2-distribution: confidence limit for lambda1
    def chi_squared_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        return ctxm.chi_squared_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.5.5 Generalized Marcum 𝑄 function

    def marcumq(self, alpha, beta, n):
        return ctxm.marcumq(self, alpha, beta, n)


# 6.5.6 Noncentral Chi-distribution, pdf

    def chi_nc_pdf(self, x, n, lambda1, method='default'):
        return ctxm.chi_nc_pdf(self, x, n, lambda1, method)

# 6.5.7 Noncentral Chi-distribution, cdf and sf
    def chi_nc_cdf(self, x, n, lambda1, cdf=True, method='default'):
        return ctxm.chi_nc_cdf(self, x, n, lambda1, cdf, method)

# 6.5.8 Noncentral Chi-distribution, qtf and isf
    def chi_nc_qtf(self, q, n, lambda1, qtf=True, method='default'):
        return ctxm.chi_nc_qtf(self, q, n, lambda1, qtf, method)


# 6.5.9 Rice distribution, pdf

    def rice_pdf(self, x, nu, sigma, method='default'):
        return ctxm.rice_pdf(self, x, nu, sigma, method)

# 6.5.10 Rice distribution, cdf and sf
    def rice_cdf(self, x, nu, sigma, cdf=True, method='default'):
        return ctxm.rice_cdf(self, x, nu, sigma, cdf, method)

# 6.5.11 Rice distribution, qtf and isf
    def rice_qtf(self, q, nu, sigma, qtf=True, method='default'):
        return ctxm.rice_qtf(self, q, nu, sigma, qtf, qtf, method)


# 6.5.12 Non-central Student 𝑡 distribution: pdf

    def student_t_nc_pdf(self, x, n, delta, method='default'):
        return ctxm.student_t_nc_pdf(self, x, n, delta, method)

##    # Singly Noncentral t-distribution, sf (Witkovsky2013)
##    def Tdisnc_pdf(self, x, n, delta):
##        return ctxm.Tdisnc_pdf(self, x, n, delta)


# 6.5.13 Non-central Student 𝑡 distribution: cdf and sf

    def student_t_nc_cdf(self, x, n, delta, method='default'):
        return ctxm.student_t_nc_cdf(self, x, n, delta, method)

    # Singly Noncentral t-distribution, cdf (Witkovsky2013)
    def tdisnc_cdf(self, x, n, delta):
        return ctxm.tdisnc_cdf(self, x, n, delta)

    # Singly Noncentral t-distribution, sf (Witkovsky2013)
    def tdisnc_sf(self, x, n, delta):
        return ctxm.tdisnc_sf(self, x, n, delta)


# 6.5.14 Non-central Student 𝑡 distribution, qtf and isf

    def student_t_nc_qtf(self, q, n, delta, qtf=True, method='default'):
        return ctxm.student_t_nc_qtf(self, q, n, delta, qtf, method)


# 6.5.15 Non-central Student 𝑡 distribution,: confidence limit for 𝛿

    def student_t_nc_cl(self, alpha, beta, n, cdfmethod='default'):
        return ctxm.student_t_nc_cl(self, alpha, beta, n, cdfmethod)


# 6.5.16 Non-central Pearson’s rho distribution: pdf

    def pearson_rho_nc_pdf(self, r, N, rho, method='default'):
        return ctxm.pearson_rho_nc_pdf(self, r, N, rho, method)


# 6.5.17 Non-central Pearson’s rho distribution: cdf and sf

    def pearson_rho_nc_cdf(self, r, N, rho, cdf=True, method='default'):
        return ctxm.pearson_rho_nc_cdf(self, r, N, rho, cdf, method)


# 6.5.18 Non-central Pearson’s rho distribution: qtf and isf

    def pearson_rho_nc_qtf(self, q, N, rho, qtf=True, method='default'):
        return ctxm.pearson_rho_nc_qtf(self, q, N, rho, qtf, method)


# 6.5.19 Non-central Pearson’s rho distribution: confidence limit for 𝜌

    def pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod='default'):
        return ctxm.pearson_rho_nc_cl(self, alpha, beta, N, cdfmethod)


# 6.5.20 Pearson’s rho: unbiased estimate of 𝜌

    def pearson_rho_nc_unbiased_estimate(self, r, N):
        return ctxm.pearson_rho_nc_unbiased_estimate(self, r, N)


# 6.5.21 Non-central Fisher 𝐹 distribution: pdf

    def fisher_f_nc_pdf(self, x, m, n, lambda1, method='default'):
        return ctxm.fisher_f_nc_pdf(self, x, m, n, lambda1, method)

    # Singly Noncentral F-distribution, pdf (Chou1985)

    def fdisnc_pdf(self, x, m, n, lambda1):
        return ctxm.fdisnc_pdf(self, x, m, n, lambda1)


# 6.5.22 Non-central Fisher 𝐹 distribution: cdf and sf

    def fisher_f_nc_cdf(self, x, m, n, lambda1, cdf=True, method='default'):
        return ctxm.fisher_f_nc_cdf(self, x, m, n, lambda1, cdf, method)

    # Singly Noncentral F-distribution, cdf (Chou1985)
    def fdisnc_cdf(self, x, m, n, lambda1):
        return ctxm.fdisnc_cdf(self, x, m, n, lambda1)

    # Singly Noncentral F-distribution, cdf2 (Chou1985)
    def fdisnc_cdf2(self, x, m, n, lambda1):
        return ctxm.fdisnc_cdf2(self, x, m, n, lambda1)

    # Singly Noncentral F-distribution, sf (Chou1985)

    def fdisnc_sf(self, x, m, n, lambda1):
        return ctxm.fdisnc_sf(self, x, m, n, lambda1)


# 6.5.23 Non-central Fisher 𝐹 distribution: qtf and isf

    def fisher_f_nc_qtf(self, q, m, n, lambda1, qtf=True, method='default'):
        return ctxm.fisher_f_nc_qtf(self, q, m, n, lambda1, qtf, method)


# 6.5.24 Non-central Fisher 𝐹 distribution: confidence limit for 𝜆1

    def fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod='default'):
        return ctxm.fisher_f_nc_cl(self, alpha, beta, m, n, cdfmethod)


# 6.5.25 Non-central Beta distribution: pdf

    def beta_nc_pdf(self, x, a, b, lambda1, method='default'):
        return ctxm.beta_nc_pdf(self, x, a, b, lambda1, method)


# 6.5.26 Non-central Beta distribution: cdf and sf

    def beta_nc_cdf(self, x, a, b, lambda1, cdf=True, method='default'):
        return ctxm.beta_nc_cdf(self, x, a, b, lambda1, cdf, method)


# 6.5.27 Non-central Beta distribution: qtf and isf

    def beta_nc_qtf(self, q, a, b, lambda1, cdf=True, method='default'):
        return ctxm.beta_nc_qtf(self, q, a, b, lambda1, cdf, method)


# 6.5.28 Non-central Beta distribution: confidence limit for 𝜆1

    def beta_nc_cl(self, alpha, beta, a, b, cdfmethod='default'):
        return ctxm.beta_nc_cl(self, alpha, beta, a, b, cdfmethod)


# 6.5.29 Fisher’s 𝑅2 distribution: pdf

    def fisher_r2_pdf(self, x, p, N, rho2, typeI=True, method='default'):
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2, typeI, method)

    # Singly Noncentral Fisher R2-distribution, pdf (Chou1985)
    def fisher_r2_pdf2_(self, x, p, N, rho2):
        return ctxm.fisher_r2_pdf(self, x, p, N, rho2)


# 6.5.30 Fisher’s 𝑅2 distribution: cdf and sf

    def fisher_r2_cdf(self, x, p, N, rho2, cdf=True, typeI=True, method='default'):
        return ctxm.fisher_r2_cdf(self, x, p, N, rho2, cdf, typeI, method)


# 6.5.31 Fisher’s 𝑅2 distribution: qtf and isf

    def fisher_r2_qtf(self, q, p, N, rho2, qtf=True, typeI=True, method='default'):
        return ctxm.fisher_r2_qtf(self, q, p, N, rho2, qtf, typeI, method)


# 6.5.32 Fisher’s 𝑅2 distribution: confidence limit for 𝜌2

    def fisher_r2_cl(self, alpha, beta, p, N, cdfmethod='default'):
        return ctxm.fisher_r2_cl(self, alpha, beta, p, N, cdfmethod)


# 6.5.33 Fisher’s 𝑅2: unbiased estimate of rho^2

    def fisher_r2_unbiased_estimate(self, R, p, N):
        return ctxm.fisher_r2_unbiased_estimate(self, R, p, N)


# 6.5.34 Doubly non-central Student 𝑡 distribution: pdf

    def student_t_nc2_pdf(self, x, n, delta, theta, method='default'):
        return ctxm.student_t_nc2_pdf(self, x, n, delta, theta, method)

    # Doubly Noncentral t-distribution, pdf (Witkovsky2013)
    def tdisnc2_pdf(self, x, n, delta, theta):
        return ctxm.tdisnc2_pdf(self, x, n, delta, theta)


# 6.5.35 Doubly non-central Student 𝑡 distribution: cdf and sf

    def student_t_nc2_cdf(self, x, n, delta, theta, cdf=True, method='default'):
        return ctxm.student_t_nc2_cdf(self, x, n, delta, theta, cdf, method)

    # Doubly Noncentral t-distribution, cdf (Witkovsky2013)
    def tdisnc2_cdf(self, x, n, delta, theta):
        return ctxm.tdisnc2_cdf(self, x, n, delta, theta)


# 6.5.36 Doubly noncentral Student 𝑡 distribution, qtf and isf

    def student_t_nc2_qtf(self, x, n, delta, theta, qtf=True, method='default'):
        return ctxm.student_t_nc2_qtf(self, x, n, delta, theta, qtf, method)


# 6.5.37 Doubly noncentral Student 𝑡 distribution,: confidence limit for 𝛿

    def student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod='default'):
        return ctxm.student_t_nc2_cl(self, alpha, beta, n, theta, cdfmethod)


# 6.5.38 Doubly non-central Fisher 𝐹 distribution: pdf

    def fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method='default'):
        return ctxm.fisher_f_nc2_pdf(self, x, m, n, lambda1, lambda2, method)

    # Doubly Noncentral F-distribution, cdf (Chou1985)
    def fdisnc2_pdf(self, x, m, n, lambda1, lambda2):
        return ctxm.fdisnc2_pdf(self, x, m, n, lambda1, lambda2)


# 6.5.39 Doubly non-central Fisher 𝐹 distribution: cdf and sf

    def fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf=True, method='default'):
        return ctxm.fisher_f_nc2_cdf(self, x, m, n, lambda1, lambda2, cdf, method)

    # Doubly Noncentral F-distribution, cdf (Chou1985)
    def fdisnc2_cdf(self, x, m, n, lambda1, lambda2):
        return ctxm.fdisnc2_cdf(self, x, m, n, lambda1, lambda2)


# 6.5.40 Doubly noncentral Fisher 𝐹 distribution, qtf and isf

    def fisher_f_nc2_qtf(self, q, m, n, lambda1, lambda2, qtf=True, method='default'):
        return ctxm.fisher_f_nc2_qtf(self, q, m, n, lambda1, lambda2, qtf, method)


# 6.5.41 Doubly noncentral Fisher 𝐹 distribution: confidence limit for lambda1

    def fisher_f_nc2_cl(self, alpha, beta, m, n, lambda2, cdfmethod='default'):
        return ctxm.fisher_f_nc2_cl(self, alpha, beta, m, n, lambda2, cdfmethod)


# 6.5.42 Non-central Wilks’ Λ distribution: MANOVA, pdf

    def wilks_lambda_glm_pdf(self, x, p, m, n, Omega, method='default'):
        return ctxm.wilks_lambda_glm_pdf(self, x, p, m, n, Omega, method)


# 6.5.43 Non-central Wilks’ Λ distribution: MANOVA, cdf and sf

    def wilks_lambda_glm_cdf(self, x, p, m, n, Omega, cdf=True, method='default'):
        return ctxm.wilks_lambda_glm_cdf(self, x, p, m, n, Omega, cdf, method)


# 6.5.44 Non-central Wilks’ Λ distribution: MANOVA, cdf and sf

    def wilks_lambda_glm_qtf(self, x, p, m, n, Omega, qtf=True, method='default'):
        return ctxm.wilks_lambda_glm_qtf(self, x, p, m, n, Omega, qtf, method)


# 6.5.45 Non-central Wilks’ Λ distribution: Independence, pdf

    def wilks_lambda_ind_pdf(self, x, p1, p2, n, Rho2, method='default'):
        return ctxm.wilks_lambda_ind_pdf(self, x, p1, p2, n, Rho2, method)


# 6.5.46 Non-central Wilks’ Λ distribution: Independence, cdf and sf

    def wilks_lambda_ind_cdf(self, x, p1, p2, n, Rho2, cdf=True, method='default'):
        return ctxm.wilks_lambda_ind_cdf(self, x, p1, p2, n, Rho2, cdf, method)


# 6.5.47 Non-central Wilks’ Λ distribution: Independence, cdf and sf

    def wilks_lambda_ind_qtf(self, x, p1, p2, n, Rho2, qtf=True, method='default'):
        return ctxm.wilks_lambda_ind_qtf(self, x, p1, p2, n, Rho2, qtf, method)


# %%%  6.6 Miscellaneous continuous distributions


# 6.6.1 Lévy alpha-stable distribution, pdf

    def levy_alphastable_pdf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.6.2 Lévy alpha-stable distribution, cdf and sf
    def levy_alphastable_cdf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)

# 6.6.3 Lévy alpha-stable distribution, qtf and isf
    def levy_alphastable_qtf(self, a, b, n):
        return ctxm.levy_alphastable_pdf(self, a, b, n)


# 6.6.4 Landau distribution, pdf

    def landau_pdf(self, a, b, n):
        return ctxm.landau_pdf(self, a, b, n)

# 6.6.5 Landau distribution, cdf and sf
    def landau_cdf(self, a, b, n):
        return ctxm.landau_cdf(self, a, b, n)

# 6.6.6 Landau distribution, qtf and isf
    def landau_qtf(self, a, b, n):
        return ctxm.landau_qtf(self, a, b, n)


# 6.6.7 Voigt Profile distribution, pdf

    def voigt_profile_pdf(self, a, b, n):
        return ctxm.voigt_profile_pdf(self, a, b, n)

# 6.6.8 Voigt Profile distribution, cdf and sf
    def voigt_profile_cdf(self, a, b, n):
        return ctxm.voigt_profile_cdf(self, a, b, n)

# 6.6.9 Voigt Profile distribution, qtf and isf
    def voigt_profile_qtf(self, a, b, n):
        return ctxm.voigt_profile_qtf(self, a, b, n)


# 6.6.10 Pearson Type IV distribution, pdf

    def pearson_type4_pdf(self, a, b, n):
        return ctxm.pearson_type4_pdf(self, a, b, n)

# 6.6.11 Pearson Type IV distribution, cdf and sf
    def pearson_type4_cdf(self, a, b, n):
        return ctxm.pearson_type4_cdf(self, a, b, n)

# 6.6.12 Pearson Type IV distribution, qtf and isf
    def pearson_type4_qtf(self, a, b, n):
        return ctxm.pearson_type4_qtf(self, a, b, n)


# 6.6.13 von Mises distribution, pdf

    def von_mises_pdf(self, a, b, n):
        return ctxm.von_mises_pdf(self, a, b, n)

# 6.6.14 von Mises distribution, cdf and sf
    def von_mises_cdf(self, a, b, n):
        return ctxm.von_mises_cdf(self, a, b, n)

# 6.6.15 von Mises distribution, qtf and isf
    def von_mises_qtf(self, a, b, n):
        return ctxm.von_mises_qtf(self, a, b, n)


# 6.6.16 Generalized inverse Gaussian distribution, pdf

    def gen_inv_gaussian_pdf(self, a, b, n):
        return ctxm.gen_inv_gaussian_pdf(self, a, b, n)

# 6.6.17 Generalized inverse Gaussian distribution, cdf and sf
    def gen_inv_gaussian_cdf(self, a, b, n):
        return ctxm.gen_inv_gaussian_cdf(self, a, b, n)

# 6.6.18 Generalized inverse Gaussian distribution, qtf and isf
    def gen_inv_gaussian_qtf(self, a, b, n):
        return ctxm.gen_inv_gaussian_qtf(self, a, b, n)


# 6.6.19 Harmonic distribution, pdf

    def harmonic_pdf(self, a, b, n):
        return ctxm.harmonic_pdf(self, a, b, n)

# 6.6.20 Harmonic distribution, cdf and sf
    def harmonic_cdf(self, a, b, n):
        return ctxm.harmonic_cdf(self, a, b, n)

# 6.6.21 Harmonic distribution, qtf and isf
    def harmonic_qtf(self, a, b, n):
        return ctxm.harmonic_qtf(self, a, b, n)


# 6.6.22 Halphen A distribution, pdf

    def halphen_a_pdf(self, a, b, n):
        return ctxm.halphen_a_pdf(self, a, b, n)

# 6.6.23 Halphen A distribution, cdf and sf
    def halphen_a_cdf(self, a, b, n):
        return ctxm.halphen_a_cdf(self, a, b, n)

# 6.6.24 Halphen A distribution, qtf and isf
    def halphen_a_qtf(self, a, b, n):
        return ctxm.halphen_a_qtf(self, a, b, n)


# 6.6.25 Halphen B distribution, pdf

    def halphen_b_pdf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.6.26 Halphen B distribution, cdf and sf
    def halphen_b_cdf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)

# 6.6.27 Halphen B distribution, qtf and isf
    def halphen_b_qtf(self, a, b, n):
        return ctxm.halphen_b_qtf(self, a, b, n)


# 6.6.28 Halphen IB distribution, pdf

    def halphen_ib_pdf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.6.29 Halphen IB distribution, cdf and sf
    def halphen_ib_cdf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)

# 6.6.30 Halphen IB distribution, qtf and isf
    def halphen_ib_qtf(self, a, b, n):
        return ctxm.halphen_ib_qtf(self, a, b, n)


# 6.6.31 Generalized hyperbolic distribution, pdf

    def gen_hyperbolic_pdf(self, a, b, n):
        return ctxm.gen_hyperbolic_pdf(self, a, b, n)

# 6.6.32 Generalized hyperbolic distribution, cdf and sf
    def gen_hyperbolic_cdf(self, a, b, n):
        return ctxm.gen_hyperbolic_cdf(self, a, b, n)

# 6.6.33 Generalized hyperbolic distribution, qtf and isf
    def gen_hyperbolic_qtf(self, a, b, n):
        return ctxm.gen_hyperbolic_qtf(self, a, b, n)


# 6.6.34 Hyperbolic distribution, pdf

    def hyperbolic_pdf(self, a, b, n):
        return ctxm.hyperbolic_pdf(self, a, b, n)

# 6.6.35 Hyperbolic distribution, cdf and sf
    def hyperbolic_cdf(self, a, b, n):
        return ctxm.hyperbolic_cdf(self, a, b, n)

# 6.6.36 Hyperbolic distribution, qtf and isf
    def hyperbolic_qtf(self, a, b, n):
        return ctxm.hyperbolic_qtf(self, a, b, n)


# 6.6.37 Variance-gamma distribution, pdf

    def variance_gamma_pdf(self, a, b, n):
        return ctxm.variance_gamma_pdf(self, a, b, n)

# 6.6.38 Variance-gamma distribution, cdf and sf
    def variance_gamma_cdf(self, a, b, n):
        return ctxm.variance_gamma_cdf(self, a, b, n)

# 6.6.39 Variance-gamma distribution, qtf and isf
    def variance_gamma_qtf(self, a, b, n):
        return ctxm.variance_gamma_qtf(self, a, b, n)


# %% 7 Discrete distribution functions

# %%%  7.1 Elementary discrete (lattice) distribution functions


# 7.1.1 Geometric distribution, pmf

    def geometric_pmf(self, k, p):
        return ctxm.geometric_pmf(self, k, p)

# 7.1.2 Geometric distribution, cdf and sf
    def geometric_cdf(self, k, p, cdf=True):
        return ctxm.geometric_cdf(self, k, p, cdf)

# 7.1.3 Geometric distribution, qtf and isf
    def geometric_qtf(self, prob, p, qtf=True):
        return ctxm.geometric_qtf(self, prob, p, qtf)


# 7.1.4 Log-series distribution, pmf

    def logseries_pmf(self, k, lambda1):
        return ctxm.logseries_pmf(self, k, lambda1)

# 7.1.5 Log-series distribution, cdf and sf
    def logseries_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.logseries_cdf(self, k, lambda1, cdf)

# 7.1.6 Log-series distribution, qtf and isf
    def logseries_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.logseries_qtf(self, prob, lambda1, qtf)


# 7.1.7 Poisson distribution, pmf

    def poisson_pmf(self, k, lambda1):
        return ctxm.poisson_pmf(self, k, lambda1)

# 7.1.8 Poisson distribution, cdf and sf
    def poisson_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.poisson_cdf(self, k, lambda1, cdf, **kwargs)

# 7.1.9 Poisson distribution, qtf and isf
    def poisson_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.poisson_qtf(self, prob, lambda1, qtf, **kwargs)


# 7.1.10 Skellam distribution, pmf

    def skellam_pmf(self, k, lambda1):
        return ctxm.skellam_pmf(self, k, lambda1)

# 7.1.11 Skellam distribution, cdf and sf
    def skellam_cdf(self, k, lambda1, cdf=True, **kwargs):
        return ctxm.skellam_cdf(self, k, lambda1, cdf)

# 7.1.12 Skellam distribution, qtf and isf
    def skellam_qtf(self, prob, lambda1, qtf=True, **kwargs):
        return ctxm.skellam_qtf(self, prob, lambda1, qtf)


# 7.1.13 Binomial distribution, pmf

    def binomial_pmf(self, k, n, p):
        return ctxm.binomial_pmf(self, k, n, p)

# 7.1.14 Binomial distribution, cdf and sf
    def binomial_cdf(self, k, n, p, cdf=True, **kwargs):
        return ctxm.binomial_cdf(self, k, n, p, cdf, **kwargs)

# 7.1.15 Binomial distribution, qtf and isf
    def binomial_qtf(self, prob, n, p, qtf=True, **kwargs):
        return ctxm.binomial_qtf(self, prob, n, p, qtf, **kwargs)


# 7.1.16 Negative binomial (gamma-Poisson) distribution, pmf

    def negbinom_pmf(self, k, r, p):
        return ctxm.negbinom_pmf(self, k, r, p)

# 7.1.17 Negative binomial (gamma-Poisson) distribution, cdf and sf
    def negbinom_cdf(self, k, r, p, cdf=True, **kwargs):
        return ctxm.negbinom_cdf(self, k, r, p, cdf, **kwargs)

# 7.1.18 Negative binomial (gamma-Poisson) distribution, qtf and isf
    def negbinom_qtf(self, prob, r, p, qtf=True, **kwargs):
        return ctxm.negbinom_qtf(self, prob, r, p, qtf, **kwargs)


# 7.1.19 Delaporte distribution, pmf

    def delaporte_pmf(self, x, r, n, NN):
        return ctxm.delaporte_pmf(self, x, r, n, NN)

# 7.1.20 Delaporte distribution, cdf and sf
    def delaporte_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.delaporte_cdf(self, x, r, n, NN, cdf)

# 7.1.21 Delaporte distribution, qtf and isf
    def delaporte_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.delaporte_qtf(self, prob, r, n, NN, qtf)


# 7.1.22 Beta-Poisson distribution (Quinkert), pmf

    def betapoisson_pmf(self, x, r, n, NN):
        return ctxm.betapoisson_pmf(self, x, r, n, NN)

# 7.1.23 Beta-Poisson distribution (Quinkert), cdf and sf
    def betapoisson_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.betapoisson_cdf(self, x, r, n, NN, cdf)

# 7.1.24 Beta-Poisson distribution (Quinkert), qtf and isf
    def betapoisson_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.betapoisson_qtf(self, prob, r, n, NN, qtf)


# 7.1.25 Beta-binomial distribution, pmf

    def betabinom_pmf(self, x, r, n, NN):
        return ctxm.betabinom_pmf(self, x, r, n, NN)

# 7.1.26 Beta-binomial distribution, cdf and sf
    def betabinom_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.betabinom_cdf(self, x, r, n, NN, cdf)

# 7.1.27 Beta-binomial distribution, qtf and isf
    def betabinom_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.betabinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.28 Beta-negative binomial distribution (Waring), pmf

    def beta_negbinom_pmf(self, x, r, n, NN):
        return ctxm.beta_negbinom_pmf(self, x, r, n, NN)

# 7.1.29 Beta-negative binomial distribution (Waring), cdf and sf
    def beta_negbinom_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.beta_negbinom_cdf(self, x, r, n, NN, cdf)

# 7.1.30 Beta-negative binomial distribution (Waring), qtf and isf
    def beta_negbinom_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.beta_negbinom_qtf(self, prob, r, n, NN, qtf)


# 7.1.31 Classical hypergeometric distribution, pmf

    def hypergeo_pmf(self, x, r, n, NN):
        return ctxm.hypergeo_pmf(self, x, r, n, NN)

# 7.1.32 Classical hypergeometric distribution, cdf and sf
    def hypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.hypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.33 Classical hypergeometric distribution, qtf and isf
    def hypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.hypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.34 Negative hypergeometric distribution, pmf

    def neghypergeo_pmf(self, x, r, n, NN):
        return ctxm.neghypergeo_pmf(self, x, r, n, NN)

# 7.1.35 Negative hypergeometric distribution, cdf and sf
    def neghypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.neghypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.36 Negative hypergeometric distribution, qtf and isf
    def neghypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.neghypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.37 Pólya-Eggenberger distribution, pmf

    def polya_pmf(self, x, r, n, NN):
        return ctxm.polya_pmf(self, x, r, n, NN)

# 7.1.38 Pólya-Eggenberger distribution, cdf and sf
    def polya_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.polya_cdf(self, x, r, n, NN, cdf)

# 7.1.39 Pólya-Eggenberger distribution, qtf and isf
    def polya_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.polya_qtf(self, prob, r, n, NN, qtf)


# 7.1.40 General hypergeometric distribution, pmf

    def genhypergeo_pmf(self, x, r, n, NN):
        return ctxm.genhypergeo_pmf(self, x, r, n, NN)

# 7.1.41 General hypergeometric distribution, cdf and sf
    def genhypergeo_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.genhypergeo_cdf(self, x, r, n, NN, cdf)

# 7.1.42 General hypergeometric distribution, qtf and isf
    def genhypergeo_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.genhypergeo_qtf(self, prob, r, n, NN, qtf)


# 7.1.43 Noncentral hypergeometric distribution (Fisher alternatives), pmf

    def hypergeo_nc_pmf(self, x, r, n, NN):
        return ctxm.hypergeo_nc_pmf(self, x, r, n, NN)

# 7.1.44 Noncentral hypergeometric distribution (Fisher alternatives), cdf and sf
    def hypergeo_nc_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.hypergeo_nc_cdf(self, x, r, n, NN, cdf)

# 7.1.45 Noncentral hypergeometric distribution (Fisher alternatives), qtf and isf
    def hypergeo_nc_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.hypergeo_nc_qtf(self, prob, r, n, NN, qtf)


# 7.1.46 Zeta distribution, pmf

    def zeta_pmf(self, k, p):
        return ctxm.zeta_pmf(self, k, p)

# 7.1.47 Zeta distribution, cdf and sf
    def zeta_cdf(self,  k, p, cdf=True):
        return ctxm.zeta_cdf(self,  k, p, cdf)

# 7.1.48 Zeta distribution, qtf and isf
    def zeta_qtf(self, prob, p, qtf=True):
        return ctxm.zeta_qtf(self, prob, p, qtf)


# %%%  7.2 Discrete (lattice) distribution functions related to (stratified) rank tests


# 7.2.1 Wilcoxon 𝑇 distribution, pmf

    def wilcoxon_pmf(self, x, N):
        return ctxm.wilcoxon_pmf(self, x, N)

# 7.2.2 Wilcoxon 𝑇 distribution, cdf and sf
    def wilcoxon_cdf(self, x, N, cdf=True):
        return ctxm.wilcoxon_cdf(self, x, N, cdf)

# 7.2.3 Wilcoxon 𝑇 distribution, qtf and isf
    def wilcoxon_qtf(self, prob, N, qtf=True):
        return ctxm.wilcoxon_qtf(self, prob, N, qtf)


# 7.2.4 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, pmf

    def wilcoxon_nc_bennett_pmf(self, x, r, n, NN):
        return ctxm.wilcoxon_nc_bennett_pmf(self, x, r, n, NN)

# 7.2.5 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, cdf and sf
    def wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.wilcoxon_nc_bennett_cdf(self, x, r, n, NN, cdf)

# 7.2.6 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, qtf and isf
    def wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.wilcoxon_nc_bennett_qtf(self, prob, r, n, NN, qtf)


# 7.2.7 Mann-Whitney 𝑈 distribution, pmf

    def mannwhitney_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_pmf(self, x, r, n, NN)

# 7.2.8 Mann-Whitney 𝑈 distribution, cdf and sf
    def mannwhitney_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_cdf(self, x, r, n, NN, cdf)

# 7.2.9 Mann-Whitney 𝑈 distribution, qtf and isf
    def mannwhitney_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_qtf(self, prob, r, n, NN, qtf)


# 7.2.10 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, pmf

    def mannwhitney_nc_lehmann_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_nc_lehmann_pmf(self, x, r, n, NN)

# 7.2.11 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, cdf and sf
    def mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_nc_lehmann_cdf(self, x, r, n, NN, cdf)

# 7.2.12 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, qtf and isf
    def mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_nc_lehmann_qtf(self, prob, r, n, NN, qtf)


# 7.2.13 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, pmf

    def mannwhitney_nc_milton_pmf(self, x, r, n, NN):
        return ctxm.mannwhitney_nc_milton_pmf(self, x, r, n, NN)

# 7.2.14 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, cdf and sf
    def mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.mannwhitney_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.15 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, qtf and isf
    def mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.mannwhitney_nc_milton_qtf(self, prob, r, n, NN, qtf)


# 7.2.16 Kendall’s 𝑆 (or 𝜏 ) distribution, pmf

    def kendall_tau_pmf(self, x, r, n, NN):
        return ctxm.kendall_tau_pmf(self, x, r, n, NN)

# 7.2.17 Kendall’s 𝑆 (or 𝜏 ) distribution, cdf and sf
    def kendall_tau_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.kendall_tau_cdf(self, x, r, n, NN, cdf)

# 7.2.18 Kendall’s 𝑆 (or 𝜏 ) distribution, qtf and isf
    def kendall_tau_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.kendall_tau_qtf(self, prob, r, n, NN, qtf)


# 7.2.19 Jonckheere-Terpsta 𝑆 distribution, pmf

    def jterpsta_s_pmf(self, x, r, n, NN):
        return ctxm.jterpsta_s_pmf(self, x, r, n, NN)

# 7.2.20 Jonckheere-Terpsta 𝑆 distribution, cdf and sf
    def jterpsta_s_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.jterpsta_s_cdf(self, x, r, n, NN, cdf)

# 7.2.21 Jonckheere-Terpsta 𝑆 distribution, qtf and isf
    def jterpsta_s_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.jterpsta_s_qtf(self, prob, r, n, NN, qtf)


# 7.2.22 Generalized Page 𝐿 distribution, pmf

    def page_l_pmf(self, x, r, n, NN):
        return ctxm.page_l_pmf(self, x, r, n, NN)

# 7.2.23 Generalized Page 𝐿 distribution, cdf and sf
    def page_l_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.page_l_cdf(self, x, r, n, NN, cdf)

# 7.2.24 Generalized Page 𝐿 distribution, qtf and isf
    def page_l_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.page_l_qtf(self, prob, r, n, NN, qtf)


# 7.2.25 Noncentral generalized Page 𝐿 distribution, Milton alternatives, pmf

    def page_l_nc_milton_pmf(self, x, r, n, NN):
        return ctxm.page_l_nc_milton_pmf(self, x, r, n, NN)

# 7.2.26 Noncentral generalized Page 𝐿 distribution, Milton alternatives, cdf and sf
    def page_l_nc_milton_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.page_l_nc_milton_cdf(self, x, r, n, NN, cdf)

# 7.2.27 Noncentral generalized Page 𝐿 distribution, Milton alternatives, qtf and isf
    def page_l_nc_milton_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.page_l_nc_milton_qtf(self, prob, r, n, NN, qtf)


# %%%  7.3 Discrete (non-lattice) distribution functions related to rank tests


# 7.3.1 Cochran-Friedman-Quade distribution, pmf

    def friedman_pmf(self, x, r, n, NN):
        return ctxm.friedman_pmf(self, x, r, n, NN)

# 7.3.2 Cochran-Friedman-Quade distribution, cdf and sf
    def friedman_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.friedman_cdf(self, x, r, n, NN, cdf)

# 7.3.3 Cochran-Friedman-Quade distribution, qtf and isf
    def friedman_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.friedman_qtf(self, prob, r, n, NN, qtf)


# 7.3.4 Kruskal-Wallis distribution, pmf

    def kruskal_wallis_pmf(self, x, r, n, NN):
        return ctxm.kruskal_wallis_pmf(self, x, r, n, NN)

# 7.3.5 Kruskal-Wallis distribution, cdf and sf
    def kruskal_wallis_cdf(self, x, r, n, NN, cdf=True):
        return ctxm.kruskal_wallis_cdf(self, x, r, n, NN, cdf)

# 7.3.6 Kruskal-Wallis distribution, qtf and isf
    def kruskal_wallis_qtf(self, prob, r, n, NN, qtf=True):
        return ctxm.kruskal_wallis_qtf(self, prob, r, n, NN, qtf)


# %% 8 Pmf vectors, sums and integrals


# %%%  8.1 Recursive generation of pmf vectors for selected discrete distributions


# 8.1.1 Poisson distribution, pmf vector

    def poisson_pmf_vector(self, N):
        return ctxm.poisson_pmf_vector(self, N)

# 8.1.2 Binomial distribution, pmf vector
    def binomial_pmf_vector(self, N):
        return ctxm.binomial_pmf_vector(self, N)

# 8.1.3 Negative binomial distribution, pmf vector
    def negbinom_pmf_vector(self, N):
        return ctxm.negbinom_pmf_vector(self, N)

# 8.1.4 Hypergeometric distribution, pmf vector
    def hypergeometric_pmf_vector(self, N):
        return ctxm.hypergeometric_pmf_vector(self, N)


# 8.1.5 Noncentral hypergeometric distribution (Fisher), pmf vector

    def hypergeo_nc_pmf_vector(self, N):
        return ctxm.hypergeo_nc_pmf_vector(self, N)


# 8.1.6 Sign test distribution (under 𝐻0), pmf vector

    def signtest_pmf_vector(self, N):
        return ctxm.signtest_pmf_vector(self, N)


# 8.1.7 Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector

    def wilcoxon_pmf_vector(self, N):
        return ctxm.wilcoxon_pmf_vector(self, N)

    def wilcoxon_full_vector(self, N, cdf=False, show=False, start=None, stop=None):
        return ctxm.wilcoxon_full_vector(self, N, cdf, show, start, stop)


# 8.1.8 Wilcoxon 𝑇 distribution (under Bennett alternatives), pmf vector

    def wilcoxon_bennett_pmf_vector(self, N):
        return ctxm.poisson_pmf_vector(self, N)


# 8.1.9 Kendall 𝑆 (or tau) distribution (under 𝐻0), pmf vector

    def kendall_tau_pmf_vector(self, n):
        return ctxm.kendall_tau_pmf_vector(self, n)

    def kendall_full_vector(self, N, cdf=False, show=False, start=None, stop=None):
        return ctxm.kendall_full_vector(self, N, cdf, show, start, stop)


# 8.1.10 Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector

    def mann_whitney_u_pmf_vector(self, m, n):
        return ctxm.mann_whitney_u_pmf_vector(self, m, n)


# 8.1.11 Mann-Whitney 𝑈 distribution (under Lehmann alternatives), pmf vector

    def mannwhitney_u_lehmann_pmf_vector(self, m, n):
        return ctxm.mannwhitney_u_lehmann_pmf_vector(self, m, n)


# 8.1.12 Mann-Whitney 𝑈 distribution (under Milton alternatives), pmf vector

    def mannwhitney_u_milton_pmf_vector(self, m, n):
        return ctxm.mannwhitney_u_milton_pmf_vector(self, m, n)


# 8.1.13 Jonckheere-Terpsta 𝑆 distribution (under 𝐻0), pmf vector

    def jterpsta_s_pmf_vector(self, k, n):
        return ctxm.jterpsta_s_pmf_vector(self, k, n)


# 8.1.14 Spearman 𝜌 distribution (under 𝐻0), pmf vector

    def spearman_rho_pmf_vector(self, k, Order):
        return ctxm.spearman_rho_pmf_vector(self, k, Order)


# 8.1.15 Page 𝐿 distribution (under 𝐻0), pmf vector

    def page_l_pmf_vector(self, k, n):
        return ctxm.page_l_pmf_vector(self, k, n)


# 8.1.16 Quade 𝐿 distribution (under 𝐻0), pmf vector

    def quade_l_pmf_vector(self, k, n):
        return ctxm.quade_l_pmf_vector(self, k, n)


# 8.1.17 Cochran 𝑆 distribution (under 𝐻0), pmf vector

    def cochran_s_pmf_vector(self, m, n):
        return ctxm.cochran_s_pmf_vector(self, m, n)


# 8.1.18 Friedman 𝑆 distribution (under 𝐻0), pmf vector

    def friedman_s_pmf_vector(self, m, n):
        return ctxm.friedman_s_pmf_vector(self, m, n)


# 8.1.19 Quade 𝑆 distribution (under 𝐻0), pmf vector

    def quade_s_pmf_vector(self, m, n):
        return ctxm.quade_s_pmf_vector(self, m, n)


# 8.1.20 Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector

    def kruskal_wallis_h_pmf_vector(self, m, n):
        return ctxm.kruskal_wallis_h_pmf_vector(self, m, n)


# %%% 8.2 Finite sums algorithms for selected distributions


# 8.2.1 Central 𝜒2 distribution, cdf (integer degrees of freedom)

    def int_df_chi_squared_cdf(self, x, nu, cdf=True):
        if cdf:
            return ctxm.int_df_chi_squared_cdf(self, x, nu)
        else:
            return 1-ctxm.int_df_chi_squared_cdf(self, x, nu)


# 8.2.2 Central Student 𝑡 distribution, cdf (integer degrees of freedom)

    def int_df_student_t_cdf(self, x, nu, cdf=True):
        if cdf:
            return ctxm.int_df_student_t_cdf(self, x, nu)
        else:
            return 1-ctxm.int_df_student_t_cdf(self, x, nu)


# 8.2.3 Central Fisher 𝐹 distribution, cdf (integer degrees of freedom)

    def int_df_fisher_f_cdf(self, x, m, n, cdf=True):
        if cdf:
            return ctxm.int_df_fisher_f_cdf(self, x, m, n)
        else:
            return 1-ctxm.int_df_fisher_f_cdf(self, x, m, n)


# 8.2.4 Central Beta distribution, cdf (2𝑎 an integer, 2𝑏 an integer)

    def int_df_beta_cdf(self, x, a, b, cdf=True):
        if cdf:
            return ctxm.int_df_beta_cdf(self, x, a, b)
        else:
            return 1-ctxm.int_df_beta_cdf(self, x, a, b)


# 8.2.5 Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)

    def int_df_chi_squared_nc_cdf(self, x, nu, nc, cdf=True):
        if cdf:
            return ctxm.int_df_chi_squared_nc_cdf(self, x, nu, nc)
        else:
            return 1-ctxm.int_df_chi_squared_nc_cdf(self, x, nu, nc)


# 8.2.6 Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)

    def int_df_student_t_nc_cdf(self, x, nu, nc, cdf=True):
        if cdf:
            return ctxm.int_df_student_t_nc_cdf(self, nu, x, nc)
        else:
            return 1-ctxm.int_df_student_t_nc_cdf(self, nu, x, nc)


# 8.2.7 Noncentral Fisher 𝐹 distribution, cdf (𝑚 an even integer)

    def int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc, cdf=True):
        if cdf:
            return ctxm.int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc)
        else:
            return 1-ctxm.int_df_fisher_f_nc_cdf(self, x, nu1, nu2, nc)


# 8.2.8 Noncentral Beta distribution, cdf (𝑏 an integer)

    def int_df_beta_nc_cdf(self, x, a, b, nc, cdf=True):
        if cdf:
            return ctxm.int_df_beta_nc_cdf(self, x, a, b, nc)
        else:
            return 1-ctxm.int_df_beta_nc_cdf(self, x, a, b, nc)


# 8.2.9 Pearson’s 𝜌 distribution, pdf (integer N)

    def int_df_pearson_rho_pdf(self, r, N, rho):
        return ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)


# 8.2.10 Pearson’s 𝜌 distribution, cdf (integer N)

    def int_df_pearson_rho_cdf(self, r, N, rho, cdf=True):
        if cdf:
            return ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)
        else:
            return 1-ctxm.int_df_pearson_rho_cdf(self, r, N, rho,)


# 8.2.11 Fisher’s 𝑅2 distribution, cdf (finite sum for odd 𝑁 − 𝑝)

    def int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2, cdf=True):
        if cdf:
            return ctxm.int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2)
        else:
            return 1-ctxm.int_df_rsquare_gurland_nc_cdf(self, ctx, x, p, N, Rho2)


# %%% 8.3 Infinite sums algorithms for selected functions and distributions


# 8.3.1 Incomplete gamma function, continued fractions (Peizer)

    def real_gamma_p_q_peizer(self, a, x):
        return ctxm.real_gamma_p_q_peizer(self, a, x)


# 8.3.2 Incomplete gamma function, asymptotic expansion (Paris)

    def real_gamma_p_q_paris(self, a, x):
        return ctxm.real_gamma_p_q_paris(self, a, x)


# 8.3.3 Incomplete beta function, continued fractions (Peizer)

    def real_betadis_peizer(self, a, b, q, p):
        return ctxm.real_betadis_peizer(self, a, b, q, p)


# 8.3.4 Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)

    def chi_squared_nc_boost(self, x, n, lambda1, cdf=True, **options):
        return ctxm.chi_squared_nc_boost(self, x, n, lambda1, cdf)


# 8.3.5 Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)

    def student_t_nc_boost(self, x, nu, delta, cdf=True, **options):
        return ctxm.student_t_nc_boost(self, x, nu, delta, cdf=True)


# 8.3.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)

    def beta_nc_boost(self, x, a, b, lambda1):
        return ctxm.beta_nc_boost(self, x, a, b, lambda1)


# 8.3.7 Pearson’s 𝜌 distribution, cdf and sf (Hotelling’s series)

    def pearson_rho_hotelling_cdf(self, r, N, rho):
        return ctxm.pearson_rho_hotelling_cdf(self, r, N, rho)


# 8.3.8 Pearson’s 𝜌 distribution, cdf and sf (Guenther’s series)

    def pearson_rho_guenther_cdf(self, r, N, rho):
        return ctxm.pearson_rho_guenther_cdf(self, r, N, rho)


# 8.3.9 Fisher’s 𝑅2 distribution, pdf (Boost, Benton)

    def fisher_r2_boost_pdf(self, x, p, N, rho2, **options):
        return ctxm.fisher_r2_boost_pdf(self, x, p, N, rho2)


# 8.3.10 Fisher’s 𝑅2 distribution, cdf and sf (Boost, Benton)

    def fisher_r2_boost_cdf(self, x, p, N, rho2, **options):
        return ctxm.fisher_r2_boost_cdf(self, x, p, N, rho2)


# %%% 8.5 Verified numerical integration


# 8.5.1 Verified Integration


    def quad_verified(self, f, a, b, epsabsStart, alpha=1, beta=1, verbose=False):
        return ctxm.quad_verified(self, f, a, b, epsabsStart, alpha, beta, verbose)


# 8.5.2 Error function

    def real_quad_erf(self, x):
        return ctxm.real_quad_erf(self, x)


# 8.5.3 Lower non-normalised incomplete gamma function,

    def real_quad_gamma_lower(self, a, x):
        return ctxm.real_quad_gamma_lower(self, a, x)


# 8.5.4 Real upper non-normalised incomplete gamma function,

    def real_quad_gamma_upper(self, a, x):
        return ctxm.real_quad_gamma_upper(self, a, x)


# 8.5.5 Normalised incomplete beta function,

    def real_quad_ibeta(self, a, b, x):
        return ctxm.real_quad_ibeta(self, a, b, x)


# 8.5.6 Non-central chi-square cdf and sf (Chow)

    def chi_squared_nc_quad_cdf(self, n, x, l):
        return ctxm.chi_squared_nc_quad_cdf(self, n, x, l)


# 8.5.7 Marcum Q function

    def marcumq_quad(self, a, b):
        b = self.t(b)
        a = self.t(a)
        res = ctxm.marcumq_quad(self, a, b)
        return res


# 8.5.8 Owen’s T function

    def owent(self, h, a):
        h = self.t(h)
        a = self.t(a)
        res = ctxm.owent_quad(self, h, a)
        return res


# %%% 8.6 Numerical Fourier transform and its inverse: continuous distributions


# 8.6.1 Central Chi-square: pdf, cdf, sf

    def chi_squared_gp(self):
        return ctxm.chi_squared_gp(self)


# 8.6.2 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_gp(self):
        return ctxm.wilks_lambda_gp(self)


# 8.6.3 Distribution of the product of independent beta variates: pdf, cdf and sf

    def log_beta_prod_gp(self):
        return ctxm.log_beta_prod_gp(self)


# 8.6.4 Box-Davis distribution: pdf, cdf and sf

    def log_box_davis_gp(self):
        return ctxm.log_box_davis_gp(self)


# 8.6.5 Noncentral Chi-square: pdf, cdf, sf

    def chi_squared_nc_gp(self):
        return ctxm.chi_squared_nc_gp(self)


# 8.6.6 Non-central Beta distribution: pdf, cdf and sf

    def log1mbeta_nc_gp(self):
        return ctxm.log1mbeta_nc_gp(self)


# 8.6.7 Fisher’s 𝑅2 distribution: pdf, cdf and sf

    def fisher_log1mr2_gp(self):
        return ctxm.fisher_log1mr2_gp(self)


# 8.6.8 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf and sf

    def wilks_lambda_glm_gp(self):
        return ctxm.wilks_lambda_glm_gp(self)


# 8.6.9 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf and sf

    def wilks_lambda_ind_gp(self):
        return ctxm.wilks_lambda_ind_gp(self)


# %%% 8.6 Numerical Fourier transform and its inverse: discrete distributions


# 8.6.1 Binomial distribution: pmf, cdf, sf

    def binomial_ft(self):
        return ctxm.binomial_ft(self)


# 8.6.2 Wilcoxon distribution: pmf, cdf, sf

    def wilcoxon_ft(self):
        return ctxm.wilcoxon_ft(self)


# %% 9 Asymptotic expansions

# %%% 9.1 Edgeworth and Cornish-Fisher expansions: continuous distributions


#   9.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf

    def edgeworth(self, x, order, kappa):
        return ctxm.edgeworth(self, x, order, kappa)


#   9.1.2 Cornish-Fisher expansion: general approximation to the qtf and isf

    def cornish_fisher(self, LeftTail, RightTail, kappa, nord):
        result = ctxm.cornish_fisher(self, LeftTail, RightTail, kappa, nord)
        return result

##    def CalcCornish(self, LeftTail, RightTail, mean, sigma, kappa, nord):
##        result = ctxm.CalcCornish(
##            self, LeftTail, RightTail, mean, sigma, kappa, nord)
##        return result


#   9.1.3 Central Chi-square

    def chi_squared_ecf(self, x, n, order, verbose):
        return ctxm.chi_squared_ecf(self, x, n, order, verbose)


#   9.1.4 Chi-squared distribution: qtf and isf

    def chi_squared_ecf_inv(self, L1, R1, n, order, verbose):
        return ctxm.chi_squared_ecf_inv(self, L1, R1, n, order, verbose)

    def chi_squared_cumulants(self, k, df):
        return ctxm.chi_squared_cumulants(self, k, df)


#  9.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf and sf

    def logrv_chisquared_ecf(self):
        return ctxm.logrv_chisquared_ecf(self)

#  9.1.6 Distribution of the logarithm of a 𝜒2 random variable: qtf and isf
    def logrv_chisquared_ecf_inv(self):
        return ctxm.logrv_chisquared_ecf_inv(self)


#  9.1.7 Fisher 𝑧 distribution: pdf, cdf and sf

    def fisher_z_ecf(self):
        return ctxm.fisher_z_ecf(self)

#  9.1.8 Fisher 𝑧 distribution: qtf and isf
    def fisher_z_ecf_inv(self):
        return ctxm.fisher_z_ecf_inv(self)


#  9.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf and sf

    def logrv_beta_ecf_pdf(self):
        return ctxm.logrv_beta_ecf_pdf(self)

#  9.1.10 Distribution of the negative logarithm of a beta variable: qtf and isf
    def logrv_beta_ecf_qtf(self):
        return ctxm.logrv_beta_ecf_qtf(self)


#  9.1.11 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_ecf(self):
        return ctxm.wilks_lambda_ecf(self)

#  9.1.12 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_ecf_inv(self):
        return ctxm.wilks_lambda_ecf_inv(self)


#  9.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_ecf(self):
        return ctxm.pillai_v_ecf(self)

#  9.1.14 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_ecf_inv(self):
        return ctxm.pillai_v_ecf_inv(self)

    def pillai_v_moments(self, k, p, n1, n2):
        return ctxm.pillai_v_moments(self, k, p, n1, n2)


#  9.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_ecf(self):
        return ctxm.hotelling_t2_ecf(self)

#  9.1.16 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_ecf_inv(self):
        return ctxm.hotelling_t2_ecf_inv(self)

    def hotelling_t2_moments(self, k, p, n1, n2):
        return ctxm.hotelling_t2_moments(self, k, p, n1, n2)


#  9.1.17 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_ecf(self):
        return ctxm.beta_product_ecf(self)

#  9.1.18 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_ecf_inv(self):
        return ctxm.beta_product_ecf_inv(self)


#  9.1.19 Box-Davis distribution (covariance matrices): pdf, cdf and sf

    def box_davis_ecf(self):
        return ctxm.box_davis_ecf(self)

#  9.1.20 Box-Davis distribution (covariance matrices): qtf and isf
    def box_davis_ecf_inv(self):
        return ctxm.box_davis_ecf_inv(self)


#  9.1.21 Noncentral chi-squared distribution: pdf, cdf and sf

    def chi_squared_nc_ecf(self):
        return ctxm.chi_squared_nc_ecf(self)

#  9.1.22 Noncentral chi-squared distribution: qtf and isf
    def chi_squared_nc_ecf_inv(self):
        return ctxm.chi_squared_nc_ecf_inv(self)


#  9.1.23 Noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc_ecf(self):
        return ctxm.student_t_nc_ecf(self)

#  9.1.24 Noncentral 𝑡-distribution: qtf and isf
    def student_t_nc_ecf_inv(self):
        return ctxm.student_t_nc_ecf_inv(self)


#  9.1.25 Noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc_ecf(self):
        return ctxm.fisher_f_nc_ecf(self)

#  9.1.26 Noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc_ecf_inv(self):
        return ctxm.fisher_f_nc_ecf_inv(self)

    def fisher_f_nc_moments(self, k, n1, n2, lambda1):
        return ctxm.fisher_f_nc_moments(self, k, n1, n2, lambda1)


#  9.1.27 Doubly noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc2_ecf(self):
        return ctxm.student_t_nc2_ecf(self)

#  9.1.28 Doubly noncentral 𝑡-distribution: qtf and isf
    def student_t_nc2_ecf_inv(self):
        return ctxm.student_t_nc2_ecf_inv(self)

    def student_t_nc2_moments(self, k, n, delta, theta):
        return ctxm.student_t_nc2_moments(self, k, n, delta, theta)


#  9.1.29 Doubly noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc2_ecf(self):
        return ctxm.fisher_f_nc2_ecf(self)

#  9.1.30 Doubly noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc2_ecf_inv(self):
        return ctxm.fisher_f_nc2_ecf_inv(self)

    def fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2):
        return ctxm.fisher_f_nc2_moments(self, k, n1, n2, lambda1, lambda2)


# %%% 9.2 Edgeworth and Cornish-Fisher expansions: discrete (“lattice”) distributions

#   9.2.1 The Sheppard correction

    def sheppard_correction(self, kappa, show=False):
        return ctxm.sheppard_correction(self, kappa, show)


#   9.2.2 Poisson distribution: pdf, cdf and sf

    def poisson_ecf(self):
        return ctxm.poisson_ecf(self)

#   9.2.3 Poisson distribution: qtf and isf
    def poisson_ecf_inv(self):
        return ctxm.poisson_ecf_inv(self)

    def poisson_cumulants(self, mu, maxcum):
        return ctxm.poisson_cumulants(self, mu, maxcum)


#   9.2.4 Binomial distribution: pdf, cdf and sf

    def binomial_ecf(self):
        return ctxm.binomial_ecf(self)

#   9.2.5 Binomial distribution: qtf and isf
    def binomial_ecf_inv(self):
        return ctxm.binomial_ecf_inv(self)

    def binomial_cumulants(self, n, p, rmax):
        return ctxm.binomial_cumulants(self, n, p, rmax)


#   9.2.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_ecf(self):
        return ctxm.negbinom_ecf(self)

#   9.2.7 Negative binomial distribution: qtf and isf
    def negbinom_ecf_inv(self):
        return ctxm.negbinom_ecf_inv(self)

    def negbinom_cumulants(self, r, p, jmax):
        return ctxm.negbinom_cumulants(self, r, p, jmax)


#   9.2.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_ecf(self):
        return ctxm.hypergeo_ecf(self)

#   9.2.9 Hypergeometric distribution: qtf and isf
    def hypergeo_ecf_inv(self):
        return ctxm.hypergeo_ecf_inv(self)

    def hypergeo_rawmoments(self, M, n, NN, rmax):
        return ctxm.hypergeo_rawmoments(self, M, n, NN, rmax)

    def hypergeo_cumulants(self, M, n, NN, rmax):
        return ctxm.hypergeo_cumulants(self, M, n, NN, rmax)


#   9.2.10 Wilcoxon Signed Rank distribution: pdf, cdf and sf

    def wilcoxon_ecf(self, x, N, order):
        return ctxm.wilcoxon_ecf(self, x, N, order)

#   9.2.11 Wilcoxon Signed Rank distribution: qtf and isf
    def wilcoxon_ecf_inv(self, L1, R1, N, order):
        return ctxm.wilcoxon_ecf_inv(self, L1, R1, N, order)

    def wilcoxon_cumulants(self, n, maxcum):
        return ctxm.wilcoxon_cumulants(self, n, maxcum)


#   9.2.12 Kendall’s 𝑆 (or 𝜏 ) distribution: pdf, cdf and sf

    def kendall_ecf(self, x, N, order):
        return ctxm.kendall_ecf(self, x, N, order)

#   9.2.13 Kendall’s 𝑆 (or 𝜏 ) distribution: qtf and isf
    def kendall_ecf_inv(self, L1, R1, N, order):
        return ctxm.kendall_ecf_inv(self, L1, R1, N, order)

    def kendall_cumulants(self, n, maxcum):
        return ctxm.kendall_cumulants(self, n, maxcum)


#   9.2.14 Mann-Whitney 𝑈 distribution: pdf, cdf and sf

    def mannwhitney_ecf(self):
        return ctxm.mannwhitney_ecf(self)

#   9.2.15 Mann-Whitney 𝑈 distribution: qtf and isf
    def mannwhitney_ecf_inv(self):
        return ctxm.mannwhitney_ecf_inv(self)


#   9.2.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf and sf

    def jterpsta_ecf(self):
        return ctxm.jterpsta_ecf(self)

#   9.2.17 Jonckheere-Terpsta 𝑆 distribution: qtf and isf
    def jterpsta_ecf_inv(self):
        return ctxm.jterpsta_ecf_inv(self)

##    def TerpstaCum(self, k, n, maxcum):
##        return ctxm.TerpstaCum(self, k, n, maxcum)


#   9.2.18 Page 𝐿 distribution: pdf, cdf and sf

    def page_ecf(self):
        return ctxm.page_ecf(self)

#   9.2.19 Page 𝐿 distribution: qtf and isf
    def page_ecf_inv(self):
        return ctxm.page_ecf_inv(self)


# %%%  9.3 Luggannini-Rice and Jensen saddle point expansions: continuous distributions


#   9.3.1 Luggannini-Rice expansion: general approximation to the pdf, cdf, and sf

    def lugannani_rice(self, order, kderiv, s, verbose=True):
        return ctxm.lugannani_rice(self, order, kderiv, s, verbose)


#   9.3.2a jensen expansion: general approximation to the qtf and isf

    def jensen(self, kderiv, s):
        return ctxm.jensen(self, kderiv, s)


#   9.3.2b jensen expansion: general approximation to the qtf and isf

    def jensen_inverse(self, n0, lambda0_, za_):
        return ctxm.jensen_inverse(self, n0, lambda0_, za_)

##    def JensenDemo(self):
##        return ctxm.JensenDemo(self)


#   9.3.3 Central Chi-square: pdf, cdf, sf

    def chi_squared_spa(self):
        return ctxm.chi_squared_spa(self)

#   9.3.4 Central Chi-square: qtf, isf
    def chi_squared_spa_inv(self):
        return ctxm.chi_squared_spa_inv(self)


#   9.3.5 Fisher 𝑧 distribution: pdf, cdf, sf

    def fisher_z_spa(self):
        return ctxm.fisher_z_spa(self)

#   9.3.6 Fisher 𝑧 distribution: qtf, isf
    def fisher_z_spa_inv(self):
        return ctxm.fisher_z_spa_inv(self)


#   9.3.7 Noncentral Chi-square: pdf, cdf, sf

    def chi_squared_nc_spa(self, x0, n0, lambda0_, Order=10, verbose=False):
        return ctxm.chi_squared_nc_spa(self, x0, n0, lambda0_, Order, verbose)


#   9.3.8 Noncentral Chi-square: qtf, isf

    def chi_squared_nc_spa_inv(self):
        return ctxm.chi_squared_nc_spa_inv(self)

##    def CdisnJensen(self, x0, n0, lambda0_, Order=10, verbose=False):
##        return ctxm.CdisnJensen(self, x0, n0, lambda0_)


#  9.3.9 Doubly Non-central Fisher F

    def fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2):
        return ctxm.fisher_f_nc2_spa(self, x, n1, n2, lambda1, lambda2)


#  9.3.10 Doubly Non-central Fisher F: qtf, isf

    def fisher_f_nc2_spa_inv(self):
        return ctxm.fisher_f_nc2_spa_inv(self)

##    def FdisnJensen(self, N1, n2, F, t1, t2):
##        return ctxm.FdisnJensen(self, N1, n2, F, t1, t2)


#  9.3.11 Wilks’ Λ distribution, pdf, cdf, sf

    def wilks_lambda_spa(self):
        return ctxm.wilks_lambda_spa(self)

#  9.3.12 Wilks’ Λ distribution, cdf and sf
    def wilks_lambda_spa_inv(self):
        return ctxm.wilks_lambda_spa_inv(self)


#  9.3.13 Distribution of the product of independent beta variables, pdf, cdf, sf

    def beta_prod_spa(self):
        return ctxm.beta_prod_spa(self)

#  9.3.14 Distribution of the product of independent beta variables : qtf, isf
    def beta_prod_spa_inv(self):
        return ctxm.beta_prod_spa_inv(self)


#  9.3.15 Box distribution: pdf, cdf, sf

    def box_spa(self):
        return ctxm.box_spa(self)

#  9.3.16 Box distribution : qtf, isf
    def box_spa_inv(self):
        return ctxm.box_spa_inv(self)


#  9.3.17 Non-central Beta distribution: pdf, cdf, sf

    def beta_nc_spa(self):
        return ctxm.beta_nc_spa(self)

#  9.3.18 Non-central Beta distribution : qtf, isf
    def beta_nc_spa_inv(self):
        return ctxm.beta_nc_spa_inv(self)


#  9.3.19 Fisher’s 𝑅2 distribution: pdf, cdf, sf

    def fisher_r2_spa(self):
        return ctxm.fisher_r2_spa(self)

#  9.3.20 Fisher’s 𝑅2 distribution : qtf, isf
    def fisher_r2_spa_inv(self):
        return ctxm.fisher_r2_spa_inv(self)


#  9.3.21 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf, sf

    def wilks_lambda_glm_spa(self):
        return ctxm.wilks_lambda_glm_spa(self)

#  9.3.22 Noncentral Wilks’ Λ distribution: MANOVA, qtf, isf
    def wilks_lambda_glm_inv(self):
        return ctxm.wilks_lambda_glm_inv(self)


#  9.3.23 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf, sf

    def wilks_lambda_ind_spa(self):
        return ctxm.wilks_lambda_ind_spa(self)

#  9.3.24 Noncentral Wilks’ Λ distribution: Independence, : qtf, isf
    def wilks_lambda_ind_spa_inv(self):
        return ctxm.wilks_lambda_ind_spa_inv(self)


# %%% 9.4 Luggannini-Rice and Jensen saddle point expansions: discrete (“lattice”) distributions


#  9.4.1 The Sheppard correction

    def sheppard_per_cgf(self):
        return ctxm.sheppard_per_cgf(self)


#  9.4.2 Poisson distribution: pdf, cdf, sf

    def poisson_spa(self):
        return ctxm.poisson_spa(self)

#  9.4.3 Poisson distribution: qtf, isf
    def poisson_spa_inv(self):
        return ctxm.poisson_spa_inv(self)


#  9.4.4 Binomial distribution: pdf, cdf and sf

    def binomial_spa(self):
        return ctxm.binomial_spa(self)

#  9.4.5 Binomial distribution: qtf and isf
    def binomial_spa_inv(self):
        return ctxm.binomial_spa_inv(self)

    def binomial_kderiv(self, order, t, n, p):
        return ctxm.binomial_kderiv(self, order, t, n, p)


#  9.4.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_spa(self):
        return ctxm.negbinom_spa(self)

#  9.4.7 Negative binomial distribution: qtf and isf
    def negbinom_spa_inv(self):
        return ctxm.negbinom_spa_inv(self)

    def negbinomial_kderiv(self, order, t, r, p):
        return ctxm.negbinomial_kderiv(self, order, t, r, p)


#  9.4.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_spa(self):
        return ctxm.hypergeo_spa(self)

#  9.4.9 Hypergeometric distribution: qtf and isf
    def hypergeo_spa_inv(self):
        return ctxm.hypergeo_spa_inv(self)


#  9.4.10 Wilcoxon distribution: pdf, cdf, sf

    def wilcoxon_spa(self):
        return ctxm.wilcoxon_spa(self)

#  9.4.11 Wilcoxon distribution: qtf, isf
    def wilcoxon_spa_inv(self):
        return ctxm.wilcoxon_spa_inv(self)


#  9.4.12 Mann-Whitney’s U distribution: pdf, cdf, sf

    def mannwhitney_spa(self):
        return ctxm.mannwhitney_spa(self)

#  9.4.13 Mann-Whitney’s U distribution: qtf, isf
    def mannwhitney_spa_inv(self):
        return ctxm.mannwhitney_spa_inv(self)


#  9.4.14 Kendall’s Tau distribution: pdf, cdf, sf

    def kendall_tau_spa(self):
        return ctxm.kendall_tau_spa(self)

#  9.4.15 Kendall’s Tau distribution: qtf, isf
    def kendall_tau_spa_inv(self):
        return ctxm.kendall_tau_spa_inv(self)


#  9.4.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf, sf

    def jterpsta_spa(self):
        return ctxm.jterpsta_spa(self)

#  9.4.17 Jonckheere-Terpsta 𝑆 distribution: qtf, isf
    def jterpsta_spa_inv(self):
        return ctxm.jterpsta_spa_inv(self)


#  9.4.18 Page 𝐿 distribution: pdf, cdf, sf

    def page_spa(self):
        return ctxm.page_spa(self)

#  9.4.19 Page 𝐿 distribution: qtf, isf
    def page_spa_inv(self):
        return ctxm.page_spa_inv(self)


# %%%  9.5 Box-Davis expansions and their inverses


#  9.5.1 Box-Davis expansion: general approximation to the pdf, cdf and sf

    def box_davis_expansion(self, x, f, rho, omega):
        return ctxm.box_davis_expansion(self, x, f, rho, omega)

#  9.5.2 Box-Davis expansion: general approximation to the qtf and isf
    def box_davis_expansion_inv(self, q, f, rho, omega):
        return ctxm.box_davis_expansion_inv(self, q, f, rho, omega)

##    def NewTestWilksUArb(self):
##        result = ctxm.NewTestWilksUArb(self)
##        return result


#  9.5.3 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_bd(self, x, f, rho, omega):
        return ctxm.wilks_lambda_bd(self, x, f, rho, omega)

#  9.5.4 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_bd_inv(self, q, f, rho, omega):
        return ctxm.wilks_lambda_bd_inv(self, q, f, rho, omega)


#  9.5.5 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_bd(self, x, f, rho, omega):
        return ctxm.beta_product_bd(self, x, f, rho, omega)

# 9.5.6 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_bd_inv(self, q, f, rho, omega):
        return ctxm.beta_product_bd_inv(self, q, f, rho, omega)


#  9.5.7 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_cov_bd(self, x, f, rho, omega):
        return ctxm.box_cov_bd(self, x, f, rho, omega)

#  9.5.8 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_cov_bd_inv(self, q, f, rho, omega):
        return ctxm.box_cov_bd_inv(self, q, f, rho, omega)


#  9.5.9 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_means_cov_bd(self, x, f, rho, omega):
        return ctxm.box_means_cov_bd(self, x, f, rho, omega)

#  9.5.10 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_means_cov_bd_inv(self, q, f, rho, omega):
        return ctxm.box_means_cov_bd_inv(self, q, f, rho, omega)


#  9.5.11 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: pdf, cdf and sf

    def lrt_vc0_bd(self, x, f, rho, omega):
        return ctxm.lrt_vc0_bd(self, x, f, rho, omega)

#  9.5.12 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: qtf and isf
    def lrt_vc0_bd_inv(self, q, f, rho, omega):
        return ctxm.lrt_vc0_bd_inv(self, q, f, rho, omega)


#  9.5.13 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: pdf, cdf and sf

    def lrt_x0_vc0_bd(self, x, f, rho, omega):
        return ctxm.lrt_x0_vc0_bd(self, x, f, rho, omega)

#  9.5.14 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: qtf and isf
    def lrt_x0_vc0_bd_inv(self, q, f, rho, omega):
        return ctxm.lrt_x0_vc0_bd_inv(self, q, f, rho, omega)


#  9.5.15 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_bd(self, x, f, rho, omega):
        return ctxm.pillai_v_bd(self, x, f, rho, omega)

#  9.5.16 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_bd_inv(self, q, f, rho, omega):
        return ctxm.pillai_v_bd_inv(self, q, f, rho, omega)


#  9.5.17 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_bd(self, x, f, rho, omega):
        return ctxm.hotelling_t2_bd(self, x, f, rho, omega)

#  9.5.18 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_bd_inv(self, q, f, rho, omega):
        return ctxm.hotelling_t2_bd_inv(self, q, f, rho, omega)


# %% 10 Fast approximations, without error estimates

# %%%  10.1 Approximations based on the normal distribution


# 10.1.1 Non-central chi-squared distribution: cdf and sf (Penev)


    def chi_squared_nc_penev_cdf(self, x, nu, nc):
        # def cdisn_penev(self, x, nu, nc):
        x = self.t(x)
        nu = self.t(nu)
        nc = self.t(nc)
        res = ctxm.cdisn_penev(self, x, nu, nc)
        return res


# 10.1.2 (Non-central) chi-squared distribution: qtf and isf (Canal)


    def chi_squared_nc_canal_qtf(self, L, R, n):
        # def cdisx_approx(self, L, R, n):
        L = self.t(L)
        R = self.t(R)
        n = self.t(n)
        res = ctxm.cdisx_approx(self, L, R, n)
        return res


# 10.1.3 Gamma distribution: qtf and isf (Canal)


    def gamma_canal_qtf(self, L, R, a):
        # def gammainv_approx(self, L, R, a):
        L = self.t(L)
        R = self.t(R)
        a = self.t(a)
        res = ctxm.gammainv_approx(self, L, R, a)
        return res


# 10.1.4 F distribution: qtf and isf (Davis)

    def fisher_f_davis_qtf(self, l, r, m, n):
        # def fdisx_approx(self, l, r, m, n):
        l = self.t(l)
        r = self.t(r)
        m = self.t(m)
        n = self.t(n)
        res = ctxm.fdisx_approx(self, l, r, m, n)
        return res


# 10.1.5 Beta distribution: qtf and isf (Davis)

    def beta_davis_qtf(self, l, r, a, b):
        # def betadisx_approx(self, l, r, a, b):
        l = self.t(l)
        r = self.t(r)
        a = self.t(a)
        b = self.t(b)
        res = ctxm.fdisx_approx(self, l, r, a, b)
        return res


# 10.1.6 Pearson’s rho distribution: pdf (Winterbottom)

    def pearson_rho_winterbottom_pdf(self):
        return ctxm.pearson_rho_winterbottom_pdf(self)


# 10.1.7 Pearson’s rho distribution: cdf and sf (Winterbottom)

##    def Rhodis_DH(self, N, r, rho):
##        # def Rhodis_DH(self, N, r, rho):
##        N = self.t(N)
##        r = self.t(r)
##        rho = self.t(rho)
##        res = ctxm.Rhodis_DH(self, N, r, rho)
##        return res


    def pearson_rho_wb_cdf(self, N, r, rho):
        N = self.t(N)
        r = self.t(r)
        rho = self.t(rho)
        res = ctxm.Rhodis_DH(self, N, r, rho)
        return res


# 10.1.8 Pearson’s rho distribution: qtf and isf (Winterbottom)

    def pearson_rho_wb_qtf(self, l, r, n, rho):
        # def Rhodisx_W(self, l, r, n, rho):
        l = self.t(l)
        r = self.t(r)
        n = self.t(n)
        rho = self.t(rho)
        res = ctxm.Rhodisx_W(self, l, r, n, rho)
        return res


# 10.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)

    def pearson_rho_wb_cl(self, l, r, N, x):
        l = self.t(l)
        r = self.t(r)
        N = self.t(N)
        x = self.t(x)
        res = ctxm.Rhodisx_W(self, l, r, N, x)
        return res


# 10.1.10 Singly noncentral t: pdf (Broda)

    def student_t_nc_broda_pdf(self):
        return ctxm.student_t_nc_broda_pdf(self)


# 10.1.11 Singly noncentral t: cdf, sf (Broda)

    def student_t_nc_broda_cdf(self):
        return ctxm.student_t_nc_broda_cdf(self)

##    def TDistNC_Broda(self, n, x, mu):
##        L, R = ctxm.TDistDoublyNC_Broda_Combined(self, n, x, mu, 0)
##        return L, R

    def student_t_nc_broda_cdf(self, x, n, delta):
        '''Returns the singly noncentral t distribution: cdf, sf (Broda)'''
        return ctxm.student_t_nc_broda_cdf(self, x, n, delta)


# 10.1.12 Singly noncentral t: qtf, isf (Harley)

    def student_t_nc_qtf_harley(self, alpha, df, delta):
        return ctxm.student_t_nc_qtf_harley(self, alpha, df, delta)


# 10.1.13 Singly noncentral t: confidence limit for 𝛿 (Akahira)

    def student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta):
        return ctxm.student_t_nc_akahira_cl(self, IsGLM, Df2, t, beta)


# 10.1.14 Doubly noncentral t: cdf, sf (Broda)

##    def student_t_nc2_broda_cdf(self):
##        return ctxm.student_t_nc2_broda_cdf(self)

##    def TDistDoublyNC_Broda(self, n, x, mu, theta):
##        L, R = ctxm.TDistDoublyNC_Broda_Combined(self, n, x, mu, theta)
##        return L, R

    def student_t_nc2_broda_cdf(self, alpha, n, delta, theta):
        '''Returns the doubly noncentral t distribution: cdf, sf (Broda)'''
        return ctxm.student_t_nc2_broda_cdf(self, alpha, n, delta, theta)


# 10.1.15 Doubly noncentral t: qtf, isf (Broda)

    def student_t_nc2_broda_qtf(self):
        return ctxm.student_t_nc2_broda_qtf(self)


# 10.1.16 Spearman’s rho, first 8 cumulants

    def spearman_mu8(self, x, n, lambda1):
        return ctxm.spearman_mu8(self, x, n, lambda1)


# 10.1.17 Mann-Whitney U distribution: general alternatives specified by rank order probabilities

    def mannwhitney_nc_mu4(self, x, n, lambda1):
        return ctxm.mannwhitney_nc_mu4(self, x, n, lambda1)


# 10.1.18 First 4 moments of Kendalls 𝜏 in the general case

    def kendall_tau_nc_mu4(self, x, n, lambda1):
        return ctxm.kendall_tau_nc_mu4(self, x, n, lambda1)


# %%%  10.2 Approximations based on the chi-squared distribution


# 10.2.1 Non-Central chi-squared : cdf, sf (Patnaik)

    def chi_squared_nc_mu2_cdf(self, x, n, lambda1):
        return ctxm.chi_squared_nc_mu2_cdf(self, x, n, lambda1)


# 10.2.2 Non-Central chi-squared: qtf, isf (Patnaik)

    def chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail, RightTail):
        return ctxm.chi_squared_nc_mu2_qtf(self, n, lambda1, LeftTail, RightTail)


# 10.2.3 Non-Central chi-squared: confidence limit for 𝜆 (Winterbottom)

    def chi_squared_nc_wb_cl(self, F, alpha, Beta):
        return ctxm.chi_squared_nc_wb_cl(self, F, alpha, Beta)


# 10.2.4 Roy’s largest root 𝜃: pdf (Chiani)

    def roy_chiani_pdf(self, t1, p, n1, n2):
        return ctxm.roy_chiani_pdf(self, t1, p, n1, n2)


# 10.2.5 Roy’s largest root: cdf and sf (Chiani)

    def roy_chiani_cdf(self, t1, p, n1, n2):
        return ctxm.roy_chiani_cdf(self, t1, p, n1, n2)


# 10.2.6 Roy’s largest root: qtf and isf (Chiani)

    def roy_chiani_qtf(self, LeftTail, p, n1, n2):
        return ctxm.roy_chiani_qtf(self, LeftTail, p, n1, n2)


# %%%  10.3 Approximations based on the central F or beta distribution

# 10.3.1 Dunn-Šidák percentage points

    def dunn_sidak_qtf(self, LeftTail, RightTail, f1):
        return ctxm.dunn_sidak_qtf(self, LeftTail, RightTail, f1)


# 10.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)

    def fisher_f_nc_mu2_cdf(self, IsGLM, X, f1, f2, L):
        return ctxm.fisher_f_nc_mu2_cdf(self, IsGLM, X, f1, f2, L)


# 10.3.3 Singly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc_mu2_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L):
        return ctxm.fisher_f_nc_mu2_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L)


# 10.3.4 Singly non-central F: confidence interval for the noncentrality parameter 𝜆

    def fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        return ctxm.fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail)


# 10.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)

    def fisher_f_nc2_mu2_cdf(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        return ctxm.fisher_f_nc2_mu2_cdf(self, f1, f2,  X, l1, l2, LeftTail, RightTail)


# 10.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)

    def fisher_f_nc2_mu2_qtf(self, LeftTail, RightTail, f1, f2, l1, l2):
        return ctxm.fisher_f_nc2_mu2_qtf(self, LeftTail, RightTail, f1, f2, l1, l2)


# 10.3.7 Multiple correlation coefficient: cdf, sf (Lee and Gurland)

    def fisher_r2_lee_cdf(self, IsGLM, X, f1, f2, L):
        return ctxm.fisher_r2_lee_cdf(self, IsGLM, X, f1, f2, L)


# 10.3.8 Multiple correlation coefficient: qtf, isf (Lee and Gurland)

    def fisher_r2_lee_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L):
        return ctxm.fisher_r2_lee_qtf(self, IsGLM, LeftTail, RightTail, f1, f2, L)


# 10.3.9 Fisher 𝑅2,: confidence limit for rho^2

    def fisher_r2_lee_cl(self):
        return ctxm.fisher_r2_lee_cl(self)


# 10.3.10 Central Wilks’ Lambda: cdf, sf (Rao)

    def wilks_lambda_rao_cdf(self, p, f1, f2, l, LeftTail, Righttail):
        return ctxm.wilks_lambda_rao_cdf(self, p, f1, f2, l, LeftTail, Righttail)


# 10.3.11 Central Wilks’ Lambda: qtf, isf (Rao)

    def wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, f1, f2):
        return ctxm.wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, f1, f2)


# 10.3.12 Central Hotelling’s 𝑇2: cdf, sf (Pillai and Young)

    def hotelling_t2_mu3_cdf(self, ctx, p, m, n, x):
        return ctxm.hotelling_t2_mu3_cdf(self, ctx, p, m, n, x)


# 10.3.13 Central Hotelling’s 𝑇2: qtf, isf (Pillai and Young)

    def hotelling_t2_mu3_qtf(self, ctx, p, m, n, x, LeftTail, Righttail):
        return ctxm.hotelling_t2_mu3_qtf(self, ctx, p, m, n, x, LeftTail, Righttail)


# 10.3.14 Central Pillai’s 𝑉 : cdf, sf (Ginzberg)

    def pillai_v_mu3_cdf(self, ctx, p, N1, n2, x):
        return ctxm.pillai_v_mu3_cdf(self, ctx, p, N1, n2, x)


# 10.3.15 Central Pillai’s 𝑉 : qtf, isf (Ginzberg)

    def pillai_v_mu3_qtf(self, ctx, p, n1, n2, LeftTail, Righttail):
        return ctxm.pillai_v_mu3_qtf(self, ctx, p, n1, n2, LeftTail, Righttail)


# 10.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)

    def beta_product_mu3_cdf(self, ctx, p, b, c, x):
        return ctxm.beta_product_mu3_cdf(self, ctx, p, b, c, x)


# 10.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)

    def beta_product_mu3_qtf(self, ctx, LeftTail, RightTail, p, b, c):
        return ctxm.beta_product_mu3_qtf(self, ctx, LeftTail, RightTail, p, b, c)


# %%%  10.4 Approximations based on the noncentral chi-squared distribution


# 10.4.1 Non-central Wilks’ Lambda (GLM): cdf and sf (Fujikoshi)

    def wilks_lambda_glm_chi2_cdf(self):
        return ctxm.wilks_lambda_glm_chi2_cdf(self)


# 10.4.2 Non-central Wilks’ Lambda (independence): cdf and sf (Lee)

    def wilks_lambda_ind_chi2_cdf(self):
        return ctxm.wilks_lambda_ind_chi2_cdf(self)


# 10.4.3 Non-central Pillai’s V (GLM): cdf and sf Fujikoshi

    def pillai_v_glm_chi2_cdf(self):
        return ctxm.pillai_v_glm_chi2_cdf(self)


# 10.4.4 Non-central Pillai’s V (independence): cdf and sf (Lee)

    def pillai_v_ind_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.4.5 Non-central Hotelling 𝑇2 (GLM): cdf and sf (Fujikoshi)

    def hotelling_t2_glm_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.4.6 Non-central Hotelling 𝑇2 (independence): cdf and sf (Lee)

    def hotelling_t2_ind_chi2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# %%%  10.5 Approximations based on the noncentral F or beta distribution


# 10.5.1 Multiple correlation coefficient (Lee and Gurland)

    def fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2):
        return ctxm.fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2)


# 10.5.2 Noncentral Wilks’ Lambda under the GLM or independence alternative

    def wilks_lambda_glm_mu2_cdf(self):
        return ctxm.wilks_lambda_glm_mu2_cdf(self)


# 10.5.3 Noncentral Hotelling’s T under the GLM or independence alternative

    def hotelling_t2_glm_mu2_cdf(self):
        return ctxm.hotelling_t2_glm_mu2_cdf(self)


# 10.5.4 Noncentral Pillai’s V under the GLM or independence alternative

    def pillai_v_glm_mu2_cdf(self):
        return ctxm.pillai_v_glm_mu2_cdf(self)


# 10.5.5 Noncentral Roy’s largest root under the GLM or independence alternative


    def roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega):
        return ctxm.roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega)


# %%% 10.6 Approximations based on hypergeometric functions of scalar argument


# 10.6.1 Hypergeometric function 1𝐹1 for matrix argument (Butler’s approximation)

    def hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2):
        return ctxm.hypergeom_matrix_1f1_butler(self, r2, f1, f2, Rho2)


# 10.6.3 Hypergeometric function 2𝐹1 for matrix argument (Butler’s approximation)

    def hypergeom_matrix_2f1_butler(self, a, b, c, x):
        return ctxm.hypergeom_matrix_2f1_butler(self, a, b, c, x)


# %% 12 Numerical calculus (multiprecision floating point arithmetic)

### This is not available for the ipm data type




# %% 13 Algebra with random variables

# 13.1-13.2 is just text


# %%% 13.3 Probability density function (pdf)

# 13.3.1 Calculating the pdf from the cdf

    def pdf_from_cdf(self):
        return ctxm.pdf_from_cdf(self)

# 13.3.2 Calculating the pdf from the characteristic function
    def pdf_from_cf(self):
        return ctxm.pdf_from_cf(self)


# %%% 13.4 Probability mass function (pmf)

# 13.4.1 Calculating the pmf from the cdf

    def pmf_from_cdf(self):
        return ctxm.pmf_from_cdf(self)

# 13.4.2 Calculating the pmf from the characteristic function
    def pmf_from_cf(self):
        return ctxm.pmf_from_cf(self)

# 13.4.3 Calculating the pmf from the factorial moments
    def pmf_from_factorialmoments(self):
        return ctxm.pmf_from_factorialmoments(self)


# 13.4.4 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.5 Cumulative distribution function (cdf)

# 13.5.1 Calculating the cdf from the pdf

    def cdf_from_pdf(self):
        return ctxm.cdf_from_pdf(self)

# 13.5.2 Calculating the cdf from the pmf vector
    def cdf_from_pmf_vector(self):
        return ctxm.cdf_from_pmf_vector(self)


# 13.5.3 Calculating the cdf from the characteristic function, continuous cdf

    def cdf_from_cf_continuous(self):
        return ctxm.cdf_from_cf_continuous(self)


# 13.5.4 Calculating the cdf from the characteristic function (lattice distribution)

    def cdf_from_cf_lattice(self):
        return ctxm.cdf_from_cf_lattice(self)

# 13.5.5 Calculating the cdf from the factorial moments (lattice distributions)
    def cdf_from_factorial_moments_lattice(self):
        return ctxm.cdf_from_factorial_moments_lattice(self)


# %%% 13.6 Percentage point function

# 13.6.1 Calculating the percentage point function from the cdf

    def qtf_from_cdf(self):
        return ctxm.qtf_from_cdf(self)


# 13.6.2 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.7 Characteristic function

# 13.7.1 Calculating the characteristic function from the pdf

    def cf_from_pdf(self, cf):
        return ctxm.cf_from_pdf(self, cf)

# 13.7.2 Calculating the characteristic function from the pmf (lattice distribution)
    def cf_from_pmf(self, cf):
        return ctxm.cf_from_pmf(self, cf)

# 13.7.3 Calculating the characteristic function from the percentage point function
    def cf_from_qtf(self):
        return ctxm.cf_from_qtf(self)

# 13.7.4 Calculating the characteristic function from the raw moments
    def cf_from_rawmoments(self):
        return ctxm.cf_from_rawmoments(self)


# %%% 13.8 Moment generating function

# 13.8.1 Calculating the moment-generating function from the pdf

    def mgf_from_pdf(self):
        return ctxm.mgf_from_pdf(self)

# 13.8.2 Calculating the moment-generating function from the characteristic function
    def mgf_from_cf(self):
        return ctxm.mgf_from_cf(self)

# 13.8.3 Calculating the moment-generating function from the cumulant-generating function
    def mgf_from_cgf(self):
        return ctxm.mgf_from_cgf(self)

# 13.8.4 Calculating the moment-generating function from the probability-generating function
    def mgf_from_pgf(self):
        return ctxm.mgf_from_pgf(self)

# 13.8.5 Calculating the moment-generating function from the raw moments
    def mgf_from_rawmoments(self):
        return ctxm.mgf_from_rawmoments(self)

# 13.8.6 Calculating the moment-generating function from the pmf vector
    def mgf_from_pmf_vector(self, t, pmfvec):
        return ctxm.mgf_from_pmf_vector(self, t, pmfvec)


# %%% 13.9 Cumulant generating function

# 13.9.1 Calculating the cumulant-generating function from the characteristic function

    def cgf_from_cf(self):
        return ctxm.cgf_from_cf(self)

# 13.9.2 Calculating the cumulant-generating function from the moment-generating function
    def cgf_from_mgf(self):
        return ctxm.cgf_from_mgf(self)

# 13.9.3 Calculating the cumulant-generating function from the probability-generating function
    def cgf_from_pgf(self):
        return ctxm.cgf_from_pgf(self)

# 13.9.4 Calculating the cumulant-generating function from the cumulants
    def cgf_from_cumulants(self):
        return ctxm.cgf_from_cumulants(self)

# 13.9.5 Calculating the cumulant-generating function from the the pmf vector
    def cgf_from_pmf_vector(self, t, pmfvec):
        return ctxm.cgf_from_pmf_vector(self, t, pmfvec)


# %%% 13.10 Probability generating function

# 13.10.1 Calculating the probability-generating function from the pmf vector

    def pgf_from_pmf_vector(self):
        return ctxm.pgf_from_pmf_vector(self)

# 13.10.1 Calculating the probability-generating function from the pmf vector
    def pgf_from_mgf(self):
        return ctxm.pgf_from_mgf(self)


# %%% 13.11 Factorial Moments

# 13.11.1 Calculating the factorial moments from the raw moments

    def factorialmoments_from_rawmoments(self, mraw):
        return ctxm.factorialmoments_from_rawmoments(self, mraw)

# 13.11.2 Calculating the factorial moments from the cumulants
    def factorialmoments_from_cumulants(self, mraw):
        return ctxm.factorialmoments_from_cumulants(self, mraw)


# %%% 13.12 Raw Moments

# 13.13.1 Calculating the raw moments from the pdf

    def rawmoments_from_pdf(self, pdf):
        return ctxm.rawmoments_from_pdf(self, pdf)

# 13.13.2 Calculating the raw moments from the pmf vector
    def rawmoments_from_pmfvector(self, x, nl, order, show=False):
        return ctxm.rawmoments_from_pmfvector(self, x, nl, order, show)

# 13.13.3 Calculating the raw moments from the factorial moments
    def rawmoments_from_factorialmoments(self, mfac):
        return ctxm.rawmoments_from_factorialmoments(self, mfac)

# 13.13.4 Calculating the raw moments from the central moments
    def rawmoments_from_centralmoments(self, mu):
        return ctxm.rawmoments_from_centralmoments(self, mu)

# 13.13.5 Calculating the raw moments from the cumulants
    def rawmoments_from_cumulants(self, kappa):
        return ctxm.rawmoments_from_cumulants(self, kappa)

# 13.13.6 Calculating the raw moments from the moment-generating function
    def rawmoments_from_mgf(self):
        return ctxm.rawmoments_from_mgf(self)

# 13.13.7 Calculating the raw moments from the characteristic function
    def rawmoments_from_cf(self):
        return ctxm.rawmoments_from_cf(self)

# 13.13.8 Calculating the raw moments from the probability-generating function
    def rawmoments_from_pgf(self):
        return ctxm.rawmoments_from_pgf(self)


# %%% 13.13 Central Moments

# 13.13.1 Calculating the central moments from the factorial moments

    def centralmoments_from_factorialmoments(self, mfac):
        return ctxm.centralmoments_from_factorialmoments(self, mfac)

# 13.13.1 Calculating the central moments from the raw moments
    def centralmoments_from_rawmoments(self, mraw):
        return ctxm.centralmoments_from_rawmoments(self, mraw)

# 13.13.2 Calculating the central moments from the cumulants
    def centralmoments_from_cumulants(self):
        return ctxm.centralmoments_from_cumulants(self)


# %%% 13.14 Cumulants

# 13.14.1 Calculating the cumulants from the pmf vector

    def cumulants_from_pmfvector(self, x, nl, order, show=False):
        return ctxm.cumulants_from_pmfvector(self, x, nl, order, show)

# 13.14.2 Calculating the cumulants from the factorial moments
    def cumulants_from_factorialmoments(self, mfac):
        return ctxm.cumulants_from_factorialmoments(self, mfac)

# 13.14.3 Calculating the cumulants from the raw moments
    def cumulants_from_rawmoments(self, mu):
        return ctxm.cumulants_from_rawmoments(self, mu)

# 13.14.4 Calculating the cumulants from the central moments
    def cumulants_from_centralmoments(self, mu):
        return ctxm.cumulants_from_centralmoments(self, mu)

# 13.14.5 Calculating the cumulants from the cumulant-generating function
    def cumulants_from_cgf(self, cgf):
        return ctxm.cumulants_from_cgf(self, cgf)


# 13.15-13.18 is just text


# %% 14 Matrix as dictionaries (mpmath)


# %%%  14.1 Matrix functions: decompositions for linear solving


# 14.1.4 Creating a matrix as a dictionary (mpmath matrix)
    def matrix(self, r, c=1):
        return ip.matrix(r, c)


    def mat_t(self, m, n):
        matA = ip.matrix(m, n)
        return matA

    def mat_show(self, matA, title="mat"):
        for i in range(matA.rows):
            for j in range(matA.cols):
                x = matA[i, j]
                print(title+"[" + str(i) + "," + str(j)+"]: ", x)
            print()



# 14.1.5 Creating an identity matrix as a dictionary (mpmath matrix)
    def eye(self, m):
        matA = ip.eye(m)
        return matA

    def mat_identity(self, m):
        matA = ip.eye(m)
        return matA


# 14.1.6 Creating a diagonal matrix as a dictionary (mpmath matrix)
    def diag(self, vecA):
        return ip.diag(vecA)


# 14.1.7 Creating a matrix of zeros as a dictionary (mpmath matrix)
    def mat_zeros(self, m, n):
        matA = ip.zeros(m, n)
        return matA

    def zeros(self, *args, **kwargs):
        matA = ip.zeros(*args, **kwargs)
        return matA


# 14.1.8 Creating a matrix of ones as a dictionary (mpmath matrix)
    def mat_ones(self, m, n):
        matA = ip.ones(m, n)
        return matA

    def ones(self, *args, **kwargs):
        matA = ip.ones(*args, **kwargs)
        return matA


    def mat_constant(self, m, n, coeff):
        matA = ip.ones(m, n)
        matA = matA * coeff
        return matA


# 14.1.9 Creating a Hilbert matrix as a dictionary (mpmath matrix)
    def hilbert(self, n):
        matA = ip.hilbert(n)
        return matA


# 14.1.10 Creating a random matrix as a dictionary (mpmath matrix)
    def randmatrix(self, m, n):
        return ip.randmatrix(m, n)


    def mat_random(self, m, n):
        matA = ip.randmatrix(m, n)
        matB = ip.zeros(m, n)
        for i in range(m):
            for j in range(n):
                matB[i, j] = ip.mpf(matA[i, j])
        return matB

    def mat_random_complex(self, m, n):
        matA = self.mat_random(m, n) + self.mat_random(m, n) * 1j
        return matA



# 14.1.11 Swap of rows in a mpmath matrix


# 14.1.12 Extending a mpmath matrix by another column


# 14.1.13 Unit vectors

    def unitvector(self, n, i):
        return ip.unitvector(n, i)



# %%%  14.2 Methods and arithmetic operators of a mpmath matrix

# this functionality is already built in



# %%%  14.3 Norms


# 14.3.1 Vector norm of a matrix
    def norm(self, x, p=2):
        return ip.norm(x, p)


# 14.3.2 Matrix norm
    def mnorm(self, A, p=1):
        return ip.mnorm(A, p=1)



# %%%  14.4 Cholesky Decomposition without Pivoting


# 14.4.1 Cholesky decomposition
    def cholesky(self, A, tol=None):
        return ip.cholesky(A, tol=None)


# 14.4.2 Cholesky decomposition, solve
    def cholesky_solve(self, A, b, **kwargs):
        return ip.cholesky_solve(A, b, **kwargs)




# %%%  14.5 LU Decomposition with partial Pivoting


# 14.5.1 Matrix LU factorization
    def lu(ctx, A):
        return ip.lu(A)


# 14.5.2 Determinant of a matrix, using LU decomposition
    def det(self, matA):   # uses  lu decomposition
        return ip.det(matA)


# 14.5.3 Inverse of a matrix, using the LU factorization
    def inverse(self, A, **kwargs):   # uses  lu decomposition
        return ip.inverse(A, **kwargs)


# 14.5.4 Linear equations: LU solve
    def lu_solve(ctx, A, b, **kwargs):
        return ip.lu_solve(A, b, **kwargs)

    def lu_solve_mat(self, a, b):   # uses  lu decomposition
        return ip.lu_solve_mat(a, b)


# 14.5.5 Linear equations: residual of LU solve
    def residual(self, A, x, b, **kwargs):
        return ip.residual(A, x, b, **kwargs)


# 14.5.6 ??? LU improve solution
    def improve_solution(ctx, A, x, b, maxsteps=1):
        return ip.improve_solution(A, x, b, maxsteps=1)


# 14.5.7 mpmath: LU condition number
    def cond(self, A, norm=None):   # uses  lu decomposition
        return ip.cond(A, norm)




# %%%  14.6 QR Decomposition without Pivoting


# 14.6.1 QR factorization
    def qr(self, A, mode = 'full', edps = 10):
        return ip.qr(A, mode, edps)

# 14.6.2 QR solve
    def qr_solve(self, A, b, norm=None, **kwargs):
        return ip.qr_solve(A, b, norm, **kwargs)


# %%%  14.7 Singular Value Decomposition, singular values and full singular vectors


# 14.7.1 Real singular value decomposition of a matrix A
    def svd_r(self, A, full_matrices = False, compute_uv = True, overwrite_a = False):
        return ip.svd_r(A, full_matrices, compute_uv, overwrite_a)


# 14.7.2 Complex singular value decomposition of a matrix A
    def svd_c(self, A, full_matrices = False, compute_uv = True, overwrite_a = False):
        return ip.svd_c(A, full_matrices, compute_uv, overwrite_a)


# 14.7.3 mpmath: Singular value decomposition of a matrix A (real or complex)
    def svd(self, A, full_matrices = False, compute_uv = True, overwrite_a = False):
        return ip.svd(A, full_matrices, compute_uv, overwrite_a)






# %%%  14.8 Symmetric/Hermitian Eigensystem


# 14.8.1 Eigenvalue problem for a real symmetric square matrix A
    def eigsy(self, A, eigvals_only = False, overwrite_a = False):
        return ip.eigsy(A, eigvals_only, overwrite_a)


# 14.8.2 Eigenvalue problem for a complex hermitian square matrix A
    def eighe(self, A, eigvals_only = False, overwrite_a = False):
        return ip.eighe(A, eigvals_only, overwrite_a)


# 14.8.3 mpmath: Eigenvalue problem for a selfadjoint square matrix A
    def eigh(self, A, eigvals_only = False, overwrite_a = False):
        return ip.eigh(A, eigvals_only, overwrite_a)






# %%%  14.9 TODO: Tridiagonalization


# 14.9.1 mpmath: tridiag_sym
    def r_sy_tridiag(self, A, D, E, calc_ev = True):
        return ip.tridiag_eigen(A, D, E, calc_ev = True)


# 14.9.2 mpmath tridiag_her
    def c_he_tridiag_0(self, A, D, E, T):
        return ip.tridiag_eigen(A, D, E, T)


# 14.9.3 mpmath: tridiag_eigen_sym
    def tridiag_eigen(self, d, e, z = False):
        return ip.tridiag_eigen(d, e, z = False)




# %%%  14.10 Eigensystem of a general square matrix


# 14.10.1 Eigensystem decomposition of a matrix A (real or complex)
    def eig(self, A, left = False, right = True, overwrite_a = False):
        return ip.eig(A, left, right, overwrite_a)


# 14.10.2 Sorting Eigenvalues
    def eig_sort(self, E, EL = False, ER = False, f = "real"):
        return ip.eig_sort(E, EL, ER, f)



# %%%  14.11 Hessenberg and Schur decompositions


# 14.11.1 mpmath: Hessenberg decomposition of a matrix A (real or complex)
    def hessenberg(self, A, overwrite_a = False):
        return ip.hessenberg(A, overwrite_a)


# 14.11.2 Schur decomposition of a matrix A (real or complex)
    def schur(self, A, overwrite_a = False):
        return ip.schur(A, overwrite_a)



# %%%  14.12 Analytic functions of a matrix (using mpmath or Arb)


# 14.12.1 Matrix Exponential
    def expm(self, A, method='taylor'):
        return ip.expm(A, method)


# 14.12.2 Matrix Sine
    def sinm(self, A):
        return ip.sinm(A)


# 14.12.3 Matrix Cosine
    def cosm(self, A):
        return ip.cosm(A)


# 14.12.6 Matrix Square Root
    def sqrtm(self, A, _may_rotate=2):
        return ip.sqrtm(A, _may_rotate)


# 14.12.7 Matrix Logarithm
    def logm(self, A):
        return ip.logm(A)


# 14.12.8 Matrix power
    def powm(self, A, r):
        return ip.powm(A, r)






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
        #return ctxm.student_t_pdf(self, x, df)
        res =  mpm.student_t_pdf(self, mpm.t(mpm, x), mpm.t(mpm, df))
        return self.t(res)



# 5.4.32 Student t distribution, cdf and sf
    def student_t_cdf(self, x, df, cdf=True, **kwargs):
        '''Returns the Student t distribution, cdf and sf'''
        #return ctxm.student_t_cdf(self, x, df, cdf, **kwargs)
        res = ctxm.student_t_cdf(self, mpm.t(mpm, x), mpm.t(mpm, df), cdf, **kwargs)
        return self.t(res)


# 5.4.33 Student t distribution, qtf and isf
    def student_t_qtf(self, prob, df, qtf=True, **kwargs):
        '''Returns the Student t distribution, qtf and isf'''
        res = ctxm.student_t_qtf(self, mpm.t(mpm, prob), mpm.t(mpm, df), qtf, **kwargs)
        return self.t(res)






