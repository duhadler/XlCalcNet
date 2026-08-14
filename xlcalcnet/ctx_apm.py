# -*- coding: utf-8 -*-
"""
Spyder Editor
"""


from flint import arb, acb
from xlcalcnet import ctx_ap , mathap
ap = ctx_ap.APContext()

from xlcalcnet import ctx_shared
ctxm = ctx_shared.ctxUtil()


class apm():

    # %% General functions


    def __init__(self):
        pass


# %% 2 Contexts and a minimal set of context functions


# %%%  2.1 Contexts in xlcalcnet: common interface


# 2.1.1 A minimal set of context functions


    @property
    def name(self):
        return "apm"

    @property
    def fmtname(self):
        return "    apm"

    @property
    def realctx(self):
        return self

    def fmt(self, z):
        z = self.t(z)
        s1 = str(z.real)
        if self.ismpf(z):
            return s1
        else:
            s2 = str(z.imag)
            return "(" + s1 + ", " + s2 + ")"



    @property
    def realtype(self):
        return ap.mpf

    @property
    def complextype(self):
        return ap.mpc




# 2.1.2 Creating a real number
    def mpf(self, x):
        return ap.mpf(x)

# 2.1.3 Creating a complex number
    def mpc(self, x, y=None):
        return ap.mpc(x, y)


# 2.1.4 Getting and setting the current precision (in bits)
    @property
    def prec(self):
        return ap.prec

    @prec.setter
    def prec(self, value):
        ap.prec = int(value)

# 2.1.5 Getting and setting the current decimal precision (in digits)
    @property
    def dps(self):
        return ap.dps

    @dps.setter
    def dps(self, value):
        ap.dps = int(value)


# 2.1.6 Getting and setting the current decimal precision (in digits)
    @property
    def pretty(self):
        return ap.pretty

    @pretty.setter
    def pretty(self, value):
        ap.pretty = bool(value)




# %%%  2.2 Arithmetic operations




    def fadd(self, x, y, **kwargs):
        return ap.fadd(x, y, **kwargs)

    def fsub(self, x, y, **kwargs):
        return ap.fsub(x, y, **kwargs)

    def fneg(self, x, **kwargs):
        return ap.fneg(x, **kwargs)

    def fmul(self, x, y, **kwargs):
        return ap.fmul(x, y, **kwargs)

    def fdiv(self, x, y, **kwargs):
        return ap.fdiv(x, y, **kwargs)

    def fmod(self, x, y):
        return ap.fdiv(x, y)

    def fsum(self, terms, absolute=False, squared=False):
        return ap.fsum(terms, absolute, squared)

    def fprod(self, factors):
        return ap.fprod(factors)

    def fdot(self, A, B=None, conjugate=False):
        return ap.fdot(A, B, conjugate)




# %%%  2.3 Functions related to intervals and balls

# 2.3.1 Middle value of an interval or ball
    def mid(self, z):
        z = self.t(z)
        return z.mid()

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
        return ap.absmin(z)

# 2.3.6 Absolute value of the right end of an interval
    def absmax(self, z):
        return ap.absmax(z)



# %%%  2.4 Complex components


    def abs(self, z):
        z = self.t(z)
        return abs(z)


    def fabs(self, z):
        z = self.t(z)
        return abs(z)

    def sign(self, z):
        z = self.t(z)
        if z == 0: return z
        else: return z / abs(z)

    def re(self, z):
        z = self.t(z)
        return z.real

    def real(self, z):
        return self.re(z)

    def im(self, z):
        z = self.t(z)
        return z.imag

    def imag(self, z):
        return self.im(z)

    def arg(self, z):
        z = self.t(z)
        return acb(z).arg()

    def phase(self, z):
        z = self.t(z)
        return acb(z).arg()

    def conj(self, z):
        z = self.t(z)
        if z.imag.is_zero(): return z
        else: return z.conjugate()

    def polar(self, z):
        z = self.t(z)
        return ap.polar(z)

    def rect(self, r, phi):
        r = self.t(r)
        phi = self.t(phi)
        return ap.rect(r, phi)



# %%%  2.5 Integer and fractional parts


    def floor(self, x):
        x = self.t(x)
        return x.floor()

    def ceil(self, x):
        x = self.t(x)
        return x.floor()

    def nint(self, z):
        return ap.nint(z)

    def frac(self, z):
        return ap.frac(z)


# %%%  2.6 Tolerances and approximate comparisons

    def chop(self, x, tol=None):
        return ap.chop(x, tol)

    def almosteq(self, s, t, rel_eps=None, abs_eps=None):
        return ap.almosteq(s, t, rel_eps, abs_eps)



# %%%  2.7 Properties of numbers

    def ismpf(self, z):
        return ap.ismpf(z)

    def ismpc(self, z):
        return ap.ismpc(z)

#Extra
    def isreal(self, z):
        z = self.t(z)
        return ap.ismpf(z)

#Extra
    def iscomplex(self, z):
        z = self.t(z)
        return ap.ismpc(z)

#Extra
    def iszero(self, z):
        z = self.t(z)
        return ap.iszero(z)


    def isinf(self, z):
        z = self.t(z)
        return ap.isinf(z)

    def isnan(self, z):
        z = self.t(z)
        return ap.isnan(z)

    def isnormal(self, z):
        z = self.t(z)
        return ap.isnormal(z)

    def isfinite(self, z):
        z = self.t(z)
        return ap.isfinite(z)

    def isint(self, z):
        z = self.t(z)
        return ap.isint(z)

#Extra
    def isnpint(self, z):
        z = self.convert(z)
        return ap.isnpint(z)


    def ldexp(self, z, k):
        z = self.t(z)
        return ap.ldexp(z, k)

    def frexp(self, z):
        z = self.t(z)
        return ap.frexp(z)

    def mag(self, z):
        z = self.t(z)
        return ap.mag(z)

    def nint_distance(self, z):
        z = self.t(z)
        return ap.nint_distance(z)




# %%%  2.8 Number generation


    def fraction(self, p, q):
        return ap.fraction(p, q)

    def rand(self):
        return ap.rand()

    def arange(self, *args):
        return ap.arange(*args)

    def linspace(self, *args, **kwargs):
        return ap.arange(*args, **kwargs)





# %%%  2.9 Exact Mathematical Constants


    @property
    def zero(self):
        return ap.zero

    @property
    def one(self):
        return ap.one

    @property
    def j(self):
        return ap.j

    @property
    def inf(self):
        return ap.inf

    @property
    def ninf(self):
        return ap.ninf

    @property
    def nan(self):
        return ap.nan



# %%%  2.10 Approximate Mathematical Constants



    @property
    def eps(self):
        return arb((2,-self.prec))

    @property
    def ln2(self):
        return arb.const_log2()

    @property
    def ln10(self):
        return arb.const_log10()

    @property
    def pi(self):
        return arb.pi()

    @property
    def e(self):
        return arb.const_e()

    @property
    def euler(self):
        return arb.const_euler()

    @property
    def phi(self):
        return (1+arb(5).sqrt())/2

    @property
    def catalan(self):
        return arb.const_catalan()

    @property
    def khinchin(self):
        return arb.const_khinchin()

    @property
    def glaisher(self):
        return arb.const_glaisher()

    @property
    def apery(self):
        return arb(3).zeta()

    @property
    def degree(self):
        return arb.pi() / arb(180)








# %%%  2.11 Utility functions


    def force_complex(self, z):
        return acb(z)


    def t(self, x, y=None):
        return mathap.convert(x, y)


    def convert(self, z):
        return self.t(z)

    def mpmathify(self, z):
        return self.t(z)


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
        #return iv.mpf([l, r])





    def nstr(self, x, n=6, **kwargs):
        return ap.nstr(x, n, **kwargs)

    def nprint(self, x, n=6, **kwargs):
        return ap.nprint(x, n, **kwargs)


# dispose later

    def to_float(self, z):
        return float(z)

    def from_mpf(self, z):
        return self.t(str(z))


# %%%  2.12 Precision management


    def autoprec(self, f, maxprec=None, catch=(), verbose=False):
        return ap.autoprec(f, maxprec, catch, verbose)

    def workprec(self, n, normalize_output=False):
        return ap.workprec(n, normalize_output)

    def workdps(self, n, normalize_output=False):
        return ap.workdps(n, normalize_output)

    def extraprec(self, n, normalize_output=False):
        return ap.extraprec(n, normalize_output)

    def extradps(self, n, normalize_output=False):
        return ap.extradps(n, normalize_output)



# %%%  2.13 Performance and debugging


    def memoize(self, f):
        return ap.memoize(f)

    def maxcalls(self, f, N):
        return ap.maxcalls(f, N)

# monitor and timing are not ctx functions


# %%%  2.14 Additonal functionality


    def plot(self, f, xlim=[- 5, 5], ylim=None, points=200, file=None,
            dpi=None, singularities=[], axes=None):
        res = ap.plot(f, xlim, ylim, points, file, dpi, singularities, axes)
        return res





# %% 3 Scalar elementary functions

# %%%  3.1 Exponential and related functions

    def exp(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).exp()
        return acb(z).exp()

    def expj(self, z):
        z = self.t(z)
        return self.cos(z) + self.sin(z) * 1j


    def expjpi(self, z):
        z = self.t(z)
        return acb(z).exp_pi_i()


    def exp10(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).exp10()
        return acb(z).exp10()

    def exp2(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).exp2()
        return acb(z).exp2()

    def expm1(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).expm1()
        return acb(z).expm1()

    def exp10m1(self, z):
        z = self.t(z) * self.ln10
        return self.expm1(z)

    def exp2m1(self, z):
        z = self.t(z)
        return self.expm1(z * self.ln2)

    def exprel(self, z):
        z = self.t(z)
        if (z == 0):
            return self.t(1)
        else:
            return self.expm1(z)/z

    def logistic(self, z):
        z = self.t(z)
        return 1/(1 + self.exp(-z))


# %%%  3.2 Logarithms and related functions

    def logb(self, z, b):
        z = self.t(z)
        b = self.t(b)
        return self.log(z) / self.log(b)

    def ln(self, z):
        z = self.t(z)
        return self.log(z)

    def log(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).log()
        return acb(z).log()

    def log1p(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).log1p()
        return acb(z).log1p()

    def log10(self, z):
        z = self.t(z)
        return self.logb(z,10)

    def log2(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).log2()
        return acb(z).log2()

    def log1mexp(self, z):
        z = self.t(z)
        x = self.fabs(z)
        if x < self.ln2:
            return self.log(-self.expm1(-x))
        else:
            return self.log1p(-self.exp(-x))

    def log2p1(self, z):
        z = self.t(z)
        return self.log1p(z)/self.ln2

    def log10p1(self, z):
        z = self.t(z)
        return self.log1p(z)/self.ln10

    # real result only for z<0

    def ln1mexp(self, z):
        z = self.t(z)
        return self.log(-self.expm1(z))

    def ln1pexp(self, z):
        z = self.t(z)
        return self.log1p(self.exp(z))

    def ln1pmx(self, z):
        z = self.t(z)
        return self.log1p(z) - z

    def logit(self, z):
        z = self.t(z)
        return self.log(z/(1-z))

    def lambertw(self, z, k):
        z = self.t(z)
        k = int(k)
        if isinstance(z, arb): return arb(z).lambertw()
        return acb(z).lambertw(k)

    def agm(self, a, b=1):
        a = self.t(a)
        b = self.t(b)
        if isinstance(a, arb) and isinstance(b, arb) : return arb(a).agm(b)
        return acb(a).agm(b)


# %%%  3.3 Square, roots and power functions

    def square(self, z):
        z = self.t(z)
        return z * z

    def sqrt(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sqrt()
        return acb(z).sqrt()

    def rsqrt(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).rsqrt()
        return acb(z).rsqrt()

    def sqrt1pm1(self, z):
        z = self.t(z)
        return self.expm1(self.log1p(z)/2)

    def cbrt(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).root(3)
        return acb(z).root(3)

    def cuberoot(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).root(3)
        return acb(z).root(3)

    def nthroot(self, z, n):
        z = self.t(z)
        return self.exp(self.log(z)/n)

    def unitroot(self, k, n):
        return self.exp((2j*k*self.pi)/n)

    def hypot(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.sqrt(self.square(a) + self.square(b))

    def power(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return a**b

    def pow(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return a**b

    def powm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.expm1(b * self.log(a))

    def pow1p(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.exp(b * self.log1p(a))

    def pow1pm1(self, a, b):
        a = self.t(a)
        b = self.t(b)
        return self.expm1(b * self.log1p(a))

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
        if isinstance(z, arb):
            return arb(z).sin()
        else:
            return acb(z).sin()

    def cos(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cos()
        return acb(z).cos()

    def tan(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tan()
        return acb(z).tan()

    def sec(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sec()
        return acb(z).sec()

    def csc(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).csc()
        return acb(z).csc()

    def cot(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cot()
        return acb(z).cot()

    def hav(self, z):
        z = self.t(z)
        v = self.sin(0.5 * z)
        return v*v

    def sinpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sin_pi()
        return acb(z).sin_pi()

    def cospi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cos_pi()
        return acb(z).cos_pi()

    def tanpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tan_pi()
        return acb(z).tan_pi()

    def cotpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cot_pi()
        return acb(z).cot_pi()

    def cscpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return 1/arb(z).sin_pi()
        return 1/acb(z).sin_pi()

    def secpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return 1/arb(z).cos_pi()
        return 1/acb(z).cos_pi()



    def sinc(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinc()
        return acb(z).sinc()

    def sincpi(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinc_pi()
        return acb(z).sinc_pi()


# %%%  3.5 Hyperbolic functions

    def sinh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sinh()
        return acb(z).sinh()

    def cosh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).cosh()
        return acb(z).cosh()

    def tanh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).tanh()
        return acb(z).tanh()

    def sech(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).sech()
        return acb(z).sech()

    def csch(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).csch()
        return acb(z).csch()

    def coth(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).coth()
        return acb(z).coth()


# %%%  3.6 Inverse trigonometric functions

    def asin(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).asin()
        return acb(z).asin()

    def acos(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acos()
        return acb(z).acos()

    def atan(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).atan()
        return acb(z).atan()

    def atan2(self, x, y):
        x = self.t(x)
        y = self.t(y)
        if isinstance(x, arb) and isinstance(y, arb):
            return arb(x).atan2(y)
        raise Exception("NOT IMPLEMENTED")

    def asec(self, z):
        z = self.t(z)
        return self.acos(1/z)
##        if isinstance(z, arb): return arb(z).asec()
##        return acb(z).asec()

    def acsc(self, z):
        z = self.t(z)
        return self.asin(1/z)
##        if isinstance(z, arb): return arb(z).acsc()
##        return acb(z).acsc()

    def acot(self, z):
        z = self.t(z)
        return self.atan(1/z)
##        if isinstance(z, arb): return arb(z).acot()
##        return acb(z).acot()

    def gd(self, z):
        z = self.t(z)
        return self.asin(self.tanh(z))

    def archav(self, z):
        z = self.t(z)
        return 2*self.asin(self.sqrt(z))


# %%%  3.7 Inverse hyperbolic functions

    def asinh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).asinh()
        return acb(z).asinh()

    def acosh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acosh()
        return acb(z).acosh()

    def atanh(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).atanh()
        return acb(z).atanh()

    def asech(self, z):
        z = self.t(z)
        return self.acosh(1/z)
##        if isinstance(z, arb): return arb(z).asech()
##        return acb(z).asech()

    def acsch(self, z):
        z = self.t(z)
        return self.asinh(1/z)
##        if isinstance(z, arb): return arb(z).acsch()
##        return acb(z).acsch()

    def acoth(self, z):
        z = self.t(z)
        return self.atanh(1/z)
        if isinstance(z, arb): return arb(z).acoth()
        return acb(z).acoth()

    def arcgd(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).acoth()
        return acb(z).acoth()


# %%%  3.8 Factorials and related functions

    def factorial(self, z):
        z = self.t(z)
        return self.gamma(z+1)

    def binomial(self, n, k):
        n = self.t(n)
        k = self.t(k)
        return self.gamma(n+1) / (self.gamma(k+1) * self.gamma(n-k+1))

    def multinomial(self, n, k):
        raise Exception("NOT IMPLEMENTED")

    def rf(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+n) / self.gamma(z)

    def ff(self, z, n):
        z = self.t(z)
        n = self.t(n)
        return self.gamma(z+1) / self.gamma(z-n+1)

    def fac2(self, z):
        z = self.t(z)
        w = 0.25*(self.cospi(z)-1)
        return 2**(0.5*z) * (0.5*self.pi)**w * self.gamma(0.5*z+1)


# %%%  3.9 Gamma function and related functions

    def gamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).gamma()
        return acb(z).gamma()

    def rgamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).rgamma()
        return acb(z).rgamma()

    def loggamma(self, z):
        z = self.t(z)
        if isinstance(z, arb): return arb(z).loggamma()
        return acb(z).loggamma()

    def beta(self, a, b):
        a = self.t(a)
        b = self.t(b)
        if isinstance(a, arb) and isinstance(b, arb):
            return arb(a).beta(b)
        return acb(a).beta(b)

    def gamma_ratio(self, a, b):
        a = self.t(a)
        b = self.t(b)
        if isinstance(a, arb) and isinstance(b, arb):
            return arb(a).gammaratio(b)
        return acb(a).gammaratio(b)

    def gamma_delta_ratio(self, a, delta):
        a = self.t(a)
        delta = self.t(delta)
        return self.gamma(a) / self.gamma(a+delta)

    def catalan_c(self, z):
        z = self.t(z)
        w = self.gamma(z+1)
        return self.gamma(2*z+1) / ((z+1)*w*w)


# # %% 4 Real scalar functions


# # %%% 4.1 Error functions for real arguments

#     def real_erf(self, x):
#         x = self.t(x)
#         return Apr.Erf(x)

#     def real_erfc(self, x):
#         x = self.t(x)
#         return Apr.Erfc(x)

#     def real_erfinv(self, prob):
# # !!! Todo: implement Apr.ErfInv !!!
# #        prob = mp.mpf(self.t(prob).mid)
# #        s = str(mp.erfinv(prob))
#         return "mpi(s)"

#     def real_erfcinv(self, prob):
# # !!! Todo: implement Apr.ErfcInv !!!
# #        prob = mp.mpf(self.t(prob).mid)
# #        s = str(mp.erfinv(1-prob))
#         return "mpi(s)"


# # %%% 4.2 Incomplete gamma functions for non-negative real arguments and parameters

#     # Real lower non-normalised incomplete gamma function

#     def real_gamma_lower(self, a, x):
#         a = self.t(a)
#         x = self.t(x)
#         return Apr.GammaLower(a, x)

#     # Real upper non-normalised incomplete gamma function

#     def real_gamma_upper(self, a, x, ):
#         a = self.t(a)
#         x = self.t(x)
#         return Apr.GammaUpper(a, x)

#     # Real lower normalised incomplete gamma function

#     def real_gamma_p(self, a, x):
#         a = self.t(a)
#         x = self.t(x)
#         return Apr.GammaP(a, x)

#     # Real upper normalised incomplete gamma function

#     def real_gamma_q(self, a, x, **kwargs):
#         a = self.t(a)
#         x = self.t(x)
#         return Apr.GammaQ(a, x)

#     def real_gamma_tricomi(self, a, x, **kwargs):
#         res = self.real_gamma_p(a, x, **kwargs)
#         return res * self.power(x, -self.t(a))

#     def real_gamma_p_inv(self, a, prob, **kwargs):
#         a = self.t(a)
#         prob = self.t(prob)
#         return Apr.GammaPInv(a, prob)

#     def real_gamma_q_inv(self, a, prob, **kwargs):
#         a = self.t(a)
#         prob = self.t(prob)
#         return Apr.GammaQInv(a, prob)

#     def real_gamma_p_inva(self, x, prob, **kwargs):
#         x = self.t(x)
#         prob = self.t(prob)
#         return Apr.GammaPInva(x, prob)

#     def real_gamma_q_inva(self, x, prob, **kwargs):
#         x = self.t(x)
#         prob = self.t(prob)
#         return Apr.GammaQInva(x, prob)

#     def real_gamma_derivative(self, a, x):
#         a = self.t(a)
#         x = self.t(x)
#         return Apr.GammaPDerivative(a, x)

#  # %%%  4.3 Incomplete beta functions for non-negative real arguments and parameters

#     def real_beta3(self, a, b, x):
#         a = self.t(a)
#         b = self.t(b)
#         x = self.t(x)
#         return Apr.BetaLower(a, b, x)

#     def real_betac(self, a, b, x, **kwargs):
# # !!! Check if there is a equivalent of betac !!!
#         a = self.t(a)
#         b = self.t(b)
#         x = self.t(x)
#         return Apr.BetaLower(a, b, x)

#     def real_ibeta(self, a, b, x, **kwargs):
#         a = self.t(a)
#         b = self.t(b)
#         x = self.t(x)
#         return Apr.Ibeta(a, b, x)

#     def real_ibetac(self, a, b, x, **kwargs):
#         a = self.t(a)
#         b = self.t(b)
#         x = self.t(x)
#         return Apr.Ibetac(a, b, x)

#     def real_ibeta_inv(self, a, b, prob, **kwargs):
#         a = self.t(a)
#         b = self.t(b)
#         prob = self.t(prob)
#         return Apr.IbetaInv(a, b, prob)

#     def real_ibetac_inv(self, a, b, prob, **kwargs):
#         a = self.t(a)
#         b = self.t(b)
#         prob = self.t(prob)
#         return Apr.IbetacInv(a, b, prob)

#     def real_ibeta_inva(self, b, x, prob, **kwargs):
#         x = self.t(x)
#         b = self.t(b)
#         prob = self.t(prob)
#         return Apr.IbetaInva(x, b, prob)

#     def real_ibetac_inva(self, b, x, prob, **kwargs):
#         x = self.t(x)
#         b = self.t(b)
#         prob = self.t(prob)
#         return Apr.IbetacInva(x, b, prob)

#     # def real_ibeta_invb(self, a, x, prob, **kwargs):
#     #     x = self.t(x)
#     #     a = self.t(a)
#     #     prob = self.t(prob)
#     #     return Apr.IbetaInv(x, b, prob)

#     # def real_ibetac_invb(self, a, x, prob, **kwargs):
#     #     x = self.t(x)
#     #     a = self.t(a)
#     #     prob = self.t(prob)
#     #     return Apr.IbetacInv(x, b, prob)

#     def real_ibeta_derivative(self, a, b, x):
#         a = self.t(a)
#         b = self.t(b)
#         x = self.t(x)
#         return Apr.IbetaDerivative(a, b, x)


# %% 16 Elliptic functions and integrals

# %%%  16.1 Conversions of parameters of elliptic functions


    def nome(self, m):
        m = self.t(m)
        if not m:
            return m
        if m == self.t(1):
            return m
        if self.isnan(m):
            return m
        if self.isinf(m):
            if m == self.ninf:
                return self.t(-1)
            else:
                return self(-1)
        a = self.elliptic_k(self.one-m)
        b = self.elliptic_k(m)
        v = self.exp(-self.pi*a/b)
#        if not iv._im(m) and iv._re(m) < 1:
#            if iv._is_real_type(m):
        if not self.imag(m) and self.real(m) < 1:
            if self.is_real(m):
                return v.real
            else:
                return v.real + 0j
        elif m == 2:
            #v = iv.mpc(0, v.imag)
            v = self.t(0, v.imag)
        return v

    def qfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if q is not None:
            return self.t(q)
        if m is not None:
            return self.nome(m)
        if k is not None:
            return self.nome(self.t(k)**2)
        if tau is not None:
            return self.expjpi(tau)
        if qbar is not None:
            return self.sqrt(qbar)

    def qbarfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if qbar is not None:
            return self.t(qbar)
        if q is not None:
            return self.t(q) ** 2
        if m is not None:
            return self.nome(m) ** 2
        if k is not None:
            return self.nome(self.t(k)**2) ** 2
        if tau is not None:
            return self.expjpi(2*tau)

    def mfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if m is not None:
            return m
        if k is not None:
            return k**2
        if tau is not None:
            q = self.expjpi(tau)
        if qbar is not None:
            q = self.sqrt(qbar)
        if q == 1:
            return self.t(q)
        if q == -1:
            return q*self.inf
        v = (self.jtheta(2, 0, q)/self.jtheta(3, 0, q))**4
        #if iv._is_real_type(q) and q < 0:
        if self.isreal(q) and q < 0:
            v = v.real
        return v

    def kfrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if k is not None:
            return self.t(k)
        if m is not None:
            return self.sqrt(m)
        if tau is not None:
            q = self.expjpi(tau)
        if qbar is not None:
            q = self.sqrt(qbar)
        if q == 1:
            return q
        if q == -1:
            return self.t(0, 'inf')
        return (self.jtheta(2, 0, q)/self.jtheta(3, 0, q))**2

    def taufrom(self, q=None, m=None, k=None, tau=None, qbar=None):
        if tau is not None:
            return self.t(tau)
        if m is not None:
            m = self.t(m)
            return self.t(1j)*self.elliptic_k(1-m)/self.elliptic_k(m)
        if k is not None:
            k = self.t(k)
            return self.t(1j)*self.elliptic_k(1-k**2)/self.elliptic_k(k**2)
        if q is not None:
            return self.ln(q) / (self.pi*self.t(1j))
        if qbar is not None:
            qbar = self.t(qbar)
            return self.ln(qbar) / (2*self.pi*self.t(1j))


# %%%  16.2 Legendre elliptic integrals

    def elliptic_k(self, m):
        m = self.t(m)
        return acb(m).elliptic_k()

    def elliptic_e(self, m):
        m = self.t(m)
        return acb(m).elliptic_e()

    def elliptic_pi(self, n, m):
        n = self.t(n)
        m = self.t(m)
        return acb.elliptic_pi(n, m)

    def elliptic_f(self, phi, m):
        phi = self.t(phi)
        m = self.t(m)
        return acb.elliptic_f(phi, m)

    def elliptic_e_inc(self, phi, m):
        phi = self.t(phi)
        m = self.t(m)
        return acb.elliptic_e_inc(phi, m)

    def elliptic_pi_inc(self, n, phi, m):
        n = self.t(n)
        phi = self.t(phi)
        m = self.t(m)
        return acb.elliptic_pi_inc(n, phi, m)

    def jacobi_zeta(self, phi, m):
        phi = self.t(phi)
        m = self.t(m)
        return self.elliptic_e_inc(phi, m) - \
            (self.elliptic_e(m)*self.elliptic_f(phi, m)) / self.elliptic_k(m)

    def heuman_lambda(self, phi, m):
        phi = self.t(phi)
        m = self.t(m)
        res = self.elliptic_f(phi, 1-m)/self.elliptic_k(1-m)
        res = res + 2*self.elliptic_k(m) * \
            self.jacobi_zeta(phi, 1-m)/self.pi
        return res


# %%%  16.3 Carlson symmetric elliptic integrals

    def elliprf(self, x, y, z):
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return acb.elliptic_rf(x, y, z)


    def elliprg(self, x, y, z):
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return acb.elliptic_rg(x, y, z)


    def elliprj(self, x, y, z, p):
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        p = self.t(p)
        return acb.elliptic_rj(x, y, z, p)



    def elliprd(self, x, y, z):
        x = self.t(x)
        y = self.t(y)
        z = self.t(z)
        return acb.elliptic_rd(x, y, z)


    def elliprc(self, x, y):
        x = self.t(x)
        y = self.t(y)
        return acb.elliptic_rc(x, y)


# %%%  16.4 Jacobi elliptic functions


#    def ellipfun(self, kind, u=None, m=None, q=None, k=None, tau=None):
#        return mp.ellipfun(kind, u, m, q, k, tau)

    jacobi_spec = {
        'sn': ([3], [2], [1], [4], 'sin', 'tanh'),
        'cn': ([4], [2], [2], [4], 'cos', 'sech'),
        'dn': ([4], [3], [3], [4], '1', 'sech'),
        'ns': ([2], [3], [4], [1], 'csc', 'coth'),
        'nc': ([2], [4], [4], [2], 'sec', 'cosh'),
        'nd': ([3], [4], [4], [3], '1', 'cosh'),
        'sc': ([3], [4], [1], [2], 'tan', 'sinh'),
        'sd': ([3, 3], [2, 4], [1], [3], 'sin', 'sinh'),
        'cd': ([3], [2], [2], [3], 'cos', '1'),
        'cs': ([4], [3], [2], [1], 'cot', 'csch'),
        'dc': ([2], [3], [3], [2], 'sec', '1'),
        'ds': ([2, 4], [3, 3], [3], [1], 'csc', 'csch'),
        'cc': None,
        'ss': None,
        'nn': None,
        'dd': None
    }

    def ellipfun(self, kind, u, m=None, q=None, k=None, tau=None):
        try:
            S = self.jacobi_spec[kind]
        except KeyError:
            raise ValueError("First argument must be a two-character string "
                              "containing 's', 'c', 'd' or 'n', e.g.: 'sn'")
        dps = self.dps
        try:
            dpsplus = 40
            self.dps += dpsplus
            #mp.dps += dpsplus
            #arbclasses.mp2.setdps(mp4.dps)
            u = self.t(u)
            q = self.qfrom(m=m, q=q, k=k, tau=tau)
            if S is None:
                v = self.t(1) + 0*q*u
            elif q == self.t(0):
                if S[4] == '1':
                    v = self.t(1)
                else:
                    v = getattr(self, S[4])(u)
                v += 0*q*u
            elif q == self.t(1):
                if S[5] == '1':
                    v = self.t(1)
                else:
                    v = getattr(self, S[5])(u)
                v += 0*q*u
            else:
                t = u / self.jtheta(3, 0, q)**2
                #print("t: ", self.s(t))
                v = self.t(1)
                for a in S[0]:
                    v *= self.jtheta(a, 0, q)  # print("v: ", self.s(v))
                for b in S[1]:
                    v /= self.jtheta(b, 0, q)  # print("v: ", self.s(v))
                for c in S[2]:
                    v *= self.jtheta(c, t, q)  # print("v: ", self.s(v))
                for d in S[3]:
                    v /= self.jtheta(d, t, q)  # print("v: ", self.s(v))
        finally:
            self.dps = dps
            #mp.dps = dps
            #arbclasses.mp2.setdps(dps)
        return +v

    def jacobi_sn(self, u, m):
        return self.ellipfun('sn', u, m)

    def jacobi_cn(self, u, m):
        return self.ellipfun('cn', u, m)

    def jacobi_dn(self, u, m):
        return self.ellipfun('dn', u, m)

    def jacobi_ns(self, u, m):
        return self.ellipfun('ns', u, m)

    def jacobi_nc(self, u, m):
        return self.ellipfun('nc', u, m)

    def jacobi_nd(self, u, m):
        return self.ellipfun('nd', u, m)

    def jacobi_sc(self, u, m):
        return self.ellipfun('sc', u, m)

    def jacobi_sd(self, u, m):
        return self.ellipfun('sd', u, m)

    def jacobi_dc(self, u, m):
        return self.ellipfun('dc', u, m)

    def jacobi_ds(self, u, m):
        return self.ellipfun('ds', u, m)

    def jacobi_cs(self, u, m):
        return self.ellipfun('cs', u, m)

    def jacobi_cd(self, u, m):
        return self.ellipfun('cd', u, m)


# %%%  16.5 Weierstrass elliptic functions

    def weierstrass_p(self, z, tau):
# !!! use methods from ARB !!!

        z = self.t(z)
        tau = self.t(tau)
        return self.elliptic_p(z, tau)

    def weierstrass_p_prime(self, z, tau):
        z = self.t(z)
        tau = self.t(tau)
        return self.elliptic_p_prime(z, tau)

    def weierstrass_p_inv(self, z, tau):
        z = self.t(z)
        tau = self.t(tau)
        return self.elliptic_inv_p(z, tau)

    def weierstrass_zeta(self, z, tau):
        z = self.t(z)
        tau = self.t(tau)
        return self.elliptic_zeta(z, tau)

    def weierstrass_sigma(self, z, tau):
        z = self.t(z)
        tau = self.t(tau)
        return self.elliptic_sigma(z, tau)


# %%%  16.6 Jacobi theta functions and related functions


    def jtheta(self, n, z, q):
        n = int(n)
        z = self.t(z)
        q = self.t(q)
        # p = self.pi
        # tau = self.ln(q) / (1j*p)
        # z = z / p
        return acb(z).modular_theta(q)[n]

    def dedekind_eta(self, tau):
        tau = self.t(tau)
        return acb(tau).modular_eta()

    def modular_lambda(self, tau):
        tau = self.t(tau)
        return acb(tau).modular_lambda()

    def modular_delta(self, tau):
        tau = self.t(tau)
        return acb(tau).modular_delta()

    def kleinj(self, tau):
        tau = self.t(tau)
        return acb(tau).modular_j()/1728

    def elliptic_roots(self, tau):
        return acb(tau).elliptic_roots()


    def elliptic_invariants(self, tau):
        return acb(tau).elliptic_invariants()


# %% 17 Lerch’s transcendent and related functions

# %%%  17.1 Overview LERCH’S TRANSCENDENT, POLYGAMMA


    def lerchphi(self, z, s, a):
# !!! update with new version !!!
        z = self.t(z)
        s = self.t(s)
        a = self.t(a)
        if (s == self.t(0)):
            return 1/(1-z)
        elif (z == self.t(1)):
            return self.hurwitz(s, a)
        elif (a == self.t(0)):
            return self.polylog(s, z)
        elif (a == self.t(1)):
            return self.polylog(s, z) / z
        else:
            #res = iv.mpf('nan')
            res = self.nan()
            #if iv.im(a) == iv.mpf(0) and iv.re(a).delta == iv.mpf(0):
            if a.isreal() and a.delta == acb(0):
#                r = mp.mpf(a)
#                if mp.isint(r):
                r = self.t(a)
                if self.isint(r):
                    n = int(r)
                    Li = self.polylog(s, z) / z
                    if n >= 1:
                        sum1 = 0
                        for k in range(n-1):
                            zk = z**k
                            ks = (k+1)**s
                            sum1 = sum1 + (zk/ks)
                    res = (Li - sum1) / (z**(n-1))
            return res

    def lerch_zeta(self, lambda1, alpha, s):
        lambda1 = self.t(lambda1)
        alpha = self.t(alpha)
        s = self.t(s)
        return self.lerchphi(self.exp(2*self.pi*1j*lambda1), s, alpha)


# %%%  17.2 Polygamma functions


    def polygamma(self, m, z):
        m = self.t(m)
        z = self.t(z)
        return acb(z).polygamma(m)

    def trigamma(self, z):
        return self.polygamma(z, 1)

    def digamma(self, z):
        return self.polygamma(z, 0)


# %%%  17.3 Polylogarithms and related functions

    def polylog(self, s, z, real4real=True):
        s = self.t(s)
        z = self.t(z)
        return acb(z).polylog(s)

    def dilog(self, z):
        z = self.t(z)
        return self.polylog(2, z)

    def trilog(self, z):
        z = self.t(z)
        return self.polylog(3, z)

    def clsin(self, s, z):
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s, self.exp(1j*z))
        res = res - self.polylog(s, self.exp(-1j*z))
        res = res / (2j)
        if z.imag == self.t(0):
            res = res.real
        return res

    def clcos(self, s, z):
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s, self.exp(1j*z))
        res = res + self.polylog(s, self.exp(-1j*z))
        res = res / (2)
        if z.imag == self.t(0):
            res = res.real
        return res

    def cl2(self, z):
        z = self.t(z)
        return self.clsin(2, z)

    def debye(self, n, x):
        raise Exception("NOT IMPLEMENTED")

    def bose_einstein(self, s, z, real4real=True):
        s = self.t(s)
        z = self.t(z)
        res = self.polylog(s+1, self.exp(z))
        if z.imag == self.t(0) and real4real:
            res = res.real
        return res

    def fermi_dirac(self, s, z):
        s = self.t(s)
        z = self.t(z)
        res = -self.polylog(s+1, -self.exp(z))
        return res

    def legendre_chi(self, s, z, real4real=True):
        s = self.t(s)
        z = self.t(z)
        res = 0.5 * (self.polylog(s, z) - self.polylog(s, -z))
        if z.isreal and real4real:
            res = res.real
        return res

    def ti(self, s, z, real4real=True):
        s = self.t(s)
        z = self.t(z)
        res = (self.polylog(s, 1j*z) - self.polylog(s, -1j*z))
        res = res / (2j)
        if z.isreal() and real4real:
            res = res.real
        return res

    def ti2(self, z):
        z = self.t(z)
        return self.ti(2, z)


# %%%  17.4 Hurwitz zeta function and related functions

    def hurwitz(self, s, a):
        s = self.t(s)
        a = self.t(a)
        return acb(s).zeta(a)

    def stieltjes(self, n, a=1):
        n = int(n)
        a = self.t(a)
        return acb.stieltjes(n, a)

    def harmonic(self, z):
        z = self.t(z)
        return self.digamma(z+1)+self.const_euler_gamma()

    def harmonic2(self, z, r):
        z = self.t(z)
        r = self.t(r)
        if r == self.t(1):
            return self.harmonic(z)
        else:
            return self.zeta(r) - self.hurwitz_zeta(r, z + 1)

    def bernoulli(self, n):
        n = int(n)
        return arb.bernoulli(n)

    # def bernfrac(self, n):
    # !!! Missing !!!
    #     n = int(n)
    #     return flint.bernfrac(n)

    def bernpoly(self, n, z):
        n = int(n)
        z = self.t(z)
        if isinstance(z, arb): return arb(z).bernoulli_poly(n)
        return acb(z).bernoulli_poly(n)

    # def eulernum(self, n):
    # !!! Missing !!!
    #     n = int(n)
    #     return Apr.EulerNumberUi(n)

    def eulerpoly(self, n, z):
        n = int(n)
        z = self.t(z)
        n = n+1
        res = 2*(self.bernpoly(n, z) - (2**n)*self.bernpoly(n, z/2))/n
        return res

    def lnbarnesg(self, z):
        z = self.t(z)
        return acb(z).log_barnes_g()

    def barnesg(self, z):
        z = self.t(z)
        return acb(z).barnes_g

    def hyperfac(self, z):
        z = self.t(z)
        return (self.gamma(z+1)**z) / self.barnesg(z+1)

    def superfac(self, z):
        z = self.t(z)
        return self.barnesg(z+2)


# %%%  17.5 Dirichlet L series, Riemann zeta function and related functions

    def dirichlet_l(self, s, chi, derivative=0):
# !!! is missing !!!
        return #flint.dirichlet(s, chi, derivative)

    def zeta(self, s):
        s = self.t(s)
        return acb(s).zeta()

    def zetam1(self, s):
        s = self.t(s)
        return self.hurwitz_zeta(s, 2)

    # NEW  see acb_dirichlet_xi, p. 185

    def riemann_xi(self, s):
# !!! is missing !!!
        s = self.t(s)
        return #flint.dirichlet_xi(s)

    # NEW  see acb_dirichlet_eta, p. 185

    def dirichlet_eta(self, s):
        return acb(s).dirichlet_eta()

    def dirichlet_etam1(self, s):
        s = self.t(s)
        return self.dirichlet_eta(s) - 1

    def dirichlet_beta(self, s):
        s = self.t(s)
        return self.power(4, -s) * (self.hurwitz(s, 0.25) - self.hurwitz(s, 0.75))

    def dirichlet_lambda(self, s):
        s = self.t(s)
        # return (1 - self.power(2, -s)) * self.zeta(s)
        return -self.exp2m1(-s) * self.zeta(s)

    # NEW  see acb_dirichlet_hardy_z, p. 192
    def siegelz(self, t):
# !!! is missing !!!
        return #flint.dirichlet_hardy_z(t)

    # NEW  see acb_dirichlet_hardy_theta, p. 192

    # def siegeltheta(self, t):
# !!! is missing !!!
        # t = self.t(t)
        # return flint.dirichlet_hardy_theta(t)

    # NEW  see acb_dirichlet_backlund_s, p. 194

    def backlunds(self, t):
# !!! is missing !!!
        t = self.t(t)
        t = t.real
        return #flint.dirichlet_backlund_s(t)

    def grampoint(self, n):
# !!! is missing !!!
        n = int(n)
        return #flint.gram_point_ui(n)

    def zetazero(self, n):
# !!! is missing !!!
        n = int(n)
        return #flint.zeta_zero_ui(n)

    def nzeros(self, t):
# !!! is missing !!!
        t = self.t(t)
        t = t.real
        return #flint.dirichlet_zeta_nzeros(t)

#    def secondzeta(self, s, a=0.015):
#        return mp.secondzeta(s, a)


# %%%  17.6 Additional numbertheoretic functions


#    def riemannr(self, z):
#        #z = self.t(z)
#        return mp.riemannr(z)
#
#    def const_mertens(self):
#        return mp.mertens()
#
#    def const_twinprime(self):
#        return mp.twinprime()
#
#    def primepi(self, x):
#        return mp.primepi(x)
#
#    def primezeta(self, s):
#        return mp.primezeta(s)
#
#    def mangoldt(self, n):
#        return mp.mangoldt(n)
#
#    def cyclotomic(self, n, x):
#        return mp.cyclotomic(n, x)
#
#    def stirling1(self, n, k, exact=False):
#        return mp.stirling1(n, k, exact)
#
#    def stirling2(self, n, k, exact=False):
#        return mp.stirling2(n, k, exact)
#
#    def bell(self, n, x):
#        return mp.bell(n, x)
#
#    def polyexp(self, s, z):
#        return mp.polyexp(s, z)


# %% 18 Hypergeometric Function 0_F_1 and related functions

# %%%  18.1 Overview


    def hyp0f1(self, a, z):
        a = self.t(a)
        z = self.t(z)
        return acb(z).hypgeom_0f1(a)

    def hyp0f1r(self, a, z):
        a = self.t(a)
        z = self.t(z)
        return acb(z).hypgeom_0f1(a, True)



# %%%  18.2 Bessel functions and modified Bessel functions of real or complex order

    def besselj(self, n, z):
        n = self.t(n)
        z = self.t(z)
        return acb(z).bessel_i(z)

    def bessely(self, n, z):
        n = self.t(n)
        z = self.t(z)
        return acb(z).bessel_y(z)

#    def besseljzero(self, n, m, derivative=0):
#        n = self.t(n)
#        m = int(m)
#        res = mp.besseljzero(n, m, derivative)
#        return iv.mpf(res)
#
#    def besselyzero(self, n, m, derivative=0):
#        n = self.t(n)
#        m = int(m)
#        res = mp.besselyzero(n, m, derivative)
#        return iv.mpf(res)

    # TODO: scaled version

    def besseli(self, n, z):
        n = self.t(n)
        z = self.t(z)
        return acb(z).bessel_i(z)

    # TODO: scaled version

    def besselk(self, n, z):
        n = self.t(n)
        z = self.t(z)
        return acb(z).bessel_k(z)


    def hankel1(self, n, z):
        n = self.t(n)
        z = self.t(z)
        re1 = self.besselj(n, z)
        im1 = 1j * self.bessely(n, z)
        return re1 + im1

    def hankel2(self, n, z):
        n = self.t(n)
        z = self.t(z)
        re1 = self.besselj(n, z)
        im1 = -1j * self.bessely(n, z)
        return re1 + im1


# %%%  18.3 Spherical Bessel functions


    def sph_bessel_jn(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.besselj(n+0.5, z)
        return res

    def sph_bessel_yn(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.bessely(n+0.5, z)
        return res

    def sph_bessel_in(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.besseli(n+0.5, z)
        return res

    def sph_bessel_kn(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.besselk(n+0.5, z)
        return res

    def sph_hankel_h1(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.hankel1(n+0.5, z)
        return res

    def sph_hankel_h2(self, n, z, derivative=0):
        n = self.t(n)
        z = self.t(z)
        res = self.sqrt(self.pi/(2*z)) * self.hankel2(n+0.5, z)
        return res


# %%%  18.4 Airy functions, TODO: scaled functions

    def airyai(self, z, derivative=0):
        z = self.t(z)
        return acb(z).airy_ai()

    def airybi(self, z, derivative=0):
        return acb(z).airy_bi()

    def airyaizero(self, k, derivative=0):
        return arb.airy_ai_zero(k, derivative)

    def airybizero(self, k, derivative=0, complex=0):
        return arb.airy_bi_zero(k, derivative)

    def airy_aip(self, z):
        z = self.t(z)
        return acb(z).airy_ai(derivative=1)

    def airy_bip(self, z):
        z = self.t(z)
        return acb(z).airy_bi(derivative=1)


# %%%  18.5 Kelvin functions, TODO: scaled functions


    def kelvinber(self, n, z):
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * self.sqrt(2)
        j1 = self.besselj(n, z * (-a + 1j*a))
        j2 = self.besselj(n, z * (-a - 1j*a))
        res = 0.5 * (j1 + j2)
        if self.isreal(z,):
            res = res.real
        return res

    def kelvinbei(self, n, z):
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * self.sqrt(2)
        j1 = self.besselj(n, z * (-a + 1j*a))
        j2 = self.besselj(n, z * (-a - 1j*a))
        res = -0.5j * (j1 - j2)
        if self.isreal(z,):
            res = res.real
        return res

    def kelvinker(self, n, z):
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * self.sqrt(2)
        k1 = self.exp(-1j*n*self.pi/2) * self.besselk(n, z * (a + 1j*a))
        k2 = self.exp(1j*n*self.pi/2) * self.besselk(n, z * (a - 1j*a))
        res = 0.5 * (k1 + k2)
        if self.isreal(z,):
            res = res.real
        return res

    def kelvinkei(self, n, z):
        n = self.t(n)
        z = self.t(z)
        a = 0.5 * self.sqrt(2)
        k1 = self.exp(-1j*n*self.pi/2) * self.besselk(n, z * (a + 1j*a))
        k2 = self.exp(1j*n*self.pi/2) * self.besselk(n, z * (a - 1j*a))
        res = -0.5j * (k1 - k2)
        if self.isreal(z,):
            res = res.real
        return res


# %% 19 Hypergeometric Function 1_F_1 and related functions

# %%%  19.1 Overview

    def hyp1f1(self, a, b, z):
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return acb(z).hypgeom_0f1(a, b)

    def hyp1f1r(self, a, b, z):
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return acb(z).hypgeom_0f1(a, b, True)

    def hyperu(self, a, b, z):
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        return acb(z).hypgeom_u(a, b)


# %%%  19.2 Incomplete gamma functions

    def gammainc2(self, a, z1=0, z2=None, regularized=False):
        res = self.gammainc(a, z1, z2, regularized)
        res = self.t(res)
        return res

    def gammainc(self, a, z1=None, z2=None, regularized=False):
        if z1 is None: z1 = self.zero()
        if z2 is None: z2 = self.inf()
        a = self.t(a)
        z1 = self.t(z1)
        z2 = self.t(z2)
        res = self._gammainc(a, z1, z2, regularized)
        return res

    def _gammainc(self, z, a=0, b=None, regularized=False):
        regularized = bool(regularized)
        z = self.t(z)
        if a is None:
            a = self.zero()
            lower_modified = False
        else:
            a = self.t(a)
            lower_modified = a != self.zero()
        if b is None:
            b = self.inf()
            upper_modified = False
        else:
            b = self.t(b)
            upper_modified = b != self.inf()
        # Complete gamma function
        if not (upper_modified or lower_modified):
            if regularized:
                if z.real < 0:
                    return self.inf()
                elif z.real > 0:
                    return self.one()
                else:
                    return self.nan()
            return self.gamma(z)
        if a == b:
            return self.zero()
        # Standardize
        #if iv.re(a) > iv.re(b):
        if a.real > b.real:
            return -self._gammainc(z, b, a, regularized)
        # Generalized gamma
        if upper_modified and lower_modified:
            return +self._gamma3(z, a, b, regularized)
        # Upper gamma
        elif lower_modified:
            return self._upper_gamma(z, a, regularized)
        # Lower gamma
        elif upper_modified:
            return self._lower_gamma(z, b, regularized)

    def _lower_gamma(self, z, b, regularized=False):
        if regularized:
            return self.gamma_p(z, b)
        else:
            return self.gamma_lower(z, b)

    def _upper_gamma(self, z, a, regularized=False):
        if regularized:
            return self.gamma_q(z, a)
        else:
            return self.gamma_upper(z, a)

    def _gamma3(self, z, a, b, regularized=False):
        if regularized:
            T1 = self.gamma_p(z, a)
            T2 = self.gamma_p(z, b)
            T3 = self.gamma_p(z, a)
            T4 = self.gamma_p(z, b)
            # need code to choose best difference
        else:
            T1 = self.gamma_lower(z, a)
            T2 = self.gamma_lower(z, b)
            T3 = self.gamma_upper(z, a)
            T4 = self.gamma_upper(z, b)
            # need code to choose best difference
        return T1, T2, T3, T4

    def gamma_lower(self, a, z, regularized=0):
        a = self.t(a)
        z = self.t(z)
        return acb(z).gamma_lower(a, regularized)

    def gamma_upper(self, a, z, regularized=0):
        a = self.t(a)
        z = self.t(z)
        return acb(z).gamma_upper(a, regularized)

    def gamma_p(self, a, z):
        a = self.t(a)
        z = self.t(z)
        return self.gamma_lower(a, z, 1)

    def gamma_q(self, a, z):
        a = self.t(a)
        z = self.t(z)
        return self.gamma_upper(a, z, 1)

    def gamma_tricomi(self, a, z):
        return self.gamma_p(a, z) * self.power(z, -a)

    def gamma_derivative(self, a, z):
        # !!! Missing !!!
        a = self.t(a)
        z = self.t(z)
        return #Apc.GammaPDerivative(a, z)


# %%%  19.3 Error function and related functions


    def erf(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erf()
        return acb(z).erf()

    def erfc(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erfc()
        return acb(z).erfc()

    def inerfc(self, n, z):
        n = self.t(n)
        z = self.t(z)
        scaled = True
        res = 1/(2**n * self.sqrt(self.pi))
        res = res * self.hyperu(0.5*n+0.5, 0.5, z*z)
        if not(scaled):
            res = res * self.exp(-z*z)
        return res

    def erfi(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).erfi()
        return acb(z).erfi()

    def dawson(self, z):
        z = self.t(z)
        res = 0.5 * self.sqrt(self.pi) * self.exp(-z*z)
        res = res * self.erfi(z)
        return res

    def fresnels(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).fresnel_s()
        return acb(z).fresnel_s()

    def fresnelc(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).fresnel_c()
        return acb(z).fresnel_c()

    def faddeeva(self, z):
        z = self.t(z)
        res = self.exp(-z*z) * self.erfc(-1j * z)
        return res

    def voigt_u(self, x, t):
        z = (1-1j*x)/(2*self.sqrt(t))
        res = self.sqrt(self.pi/(4*t)) * self.faddeeva(1j * z)
        return res.real

    def voigt_v(self, x, t):
        z = (1-1j*x)/(2*self.sqrt(t))
        res = self.sqrt(self.pi/(4*t)) * self.faddeeva(1j * z)
        return res.imag

    def voigt_h(self, a, u):
        res = 1/(a*self.sqrt(self.pi))
        res = res * self.voigt_u(u/a, 1/(4*a*a))
        return res


# %%%  19.4 Exponential integrals and related functions

    def chi(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).chi()
        return acb(z).chi()

    def ci(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).ci()
        return acb(z).ci()

    def e1(self, z):
        return self.expint(1, z)

    def ei(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).ei()
        return acb(z).ei()

    def expint(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).expint(n)
        return acb(z).expint(n)

    def li(self, z, offset=False):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).li()
        return acb(z).li()

    def primepi2_upper(self, x):
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi)
        res = self.ceil(m+d)
        return res

    def primepi2_lower(self, x):
        x = self.t(x)
        m = self.li(x)
        d = self.sqrt(x) * self.ln(x)/(8*self.pi)
        res = self.floor(m-d)
        return res

    def shi(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).shi()
        return acb(z).shi()

    def si(self, z):
        z = self.t(z)
        if isinstance(z, arb):
            return arb(z).si()
        return acb(z).si()


# %%%  19.5 Orthogonal polynomials


    def hermite(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).hermite_h(n)
        return acb(z).hermite_h(n)

    def hermite_he(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res = 2**(-n/2) * self.hermite(n, z/self.sqrt(2))
        return res

    def laguerre_l(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).laguerre_l(n)
        return acb(z).laguerre_l(n)

    def laguerre(self, n, m, z):
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).laguerre_l(n, m)
        return acb(z).laguerre_l(n, m)


# %%%  19.6 Coulomb functions


    def coulombc(self, l, eta):
        l = self.t(l)
        eta = self.t(eta)
        res1 = 0.5*(self.loggamma(1+l+1j*eta) + self.loggamma(1+l-1j*eta))
        res2 = self.loggamma(2*l+2)
        res = 2**l * self.exp(-self.pi*eta/2 + res1 - res2)
        if self.iszero(l.imag) and self.iszero(eta.imag):
            res = res.real
        return res

    def coulombf(self, l, eta, z):
        # !!! Missing !!!
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return #Apc.CoulombF(l, eta, z)

    def coulombg(self, l, eta, z):
        # !!! Missing !!!
        l = self.t(l)
        eta = self.t(eta)
        z = self.t(z)
        return #Apc.CoulombG(l, eta, z)


# %%%  19.7 Whittaker functions

    def whitm(self, k, m, z):
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        if z == 0:
            if m.real > -0.5:
                return z
            elif m.real < -0.5:
                return self.inf() + z
            else:
                return self.nan() * z
        x = self.fmul(-0.5, z, exact=True)
        y = 0.5+m
        return self.exp(x) * z**y * self.hyp1f1(y-k, 1+2*m, z)

    def whitw(self, k, m, z):
        k = self.t(k)
        m = self.t(m)
        z = self.t(z)
        if z == 0:
            g = abs(m.real)
            if g < 0.5:
                return z
            elif g > 0.5:
                return self.inf() + z
            else:
                return self.nan() * z
        x = self.fmul(-0.5, z, exact=True)
        y = 0.5+m
        return self.exp(x) * z**y * self.hyperu(y-k, 1+2*m, z)


# %%%  19.8 Parabolic cylinder functions

    def pcfd(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res = self.pcfu(-n-0.5, z)
        return res

    def pcfu(self, a, z):
        a = self.t(a)
        z = self.t(z)

        dps = self.dps
        dpsplus = 40
        self.dps += dpsplus

        p = self.pi
        p = self.sqrt(p)
        U1 = p / (self.exp2(0.5*a+0.25) * self.gamma(0.75+0.5*a))
        U2 = -p / (self.exp2(0.5*a-0.25) * self.gamma(0.25+0.5*a))
        F1 = self.hyp1f1(-0.5*a+0.25, 0.5, -0.5*z*z)
        F2 = self.hyp1f1(-0.5*a+0.75, 1.5, -0.5*z*z)
        res = (U1*F1 + U2*z*F2) / self.exp(-0.25*z*z)

        self.dps = dps

        return +res

    def pcfv(self, a, z):
        a = self.t(a)
        z = self.t(z)
        p = self.pi
        res = self.gamma(a+0.5)*self.pcfu(a, -z)
        res = res - self.sin(p*a)*self.pcfu(a, z)
        res = res / p
        return res

    def pcfw(self, a, z):
        a = self.t(a)
        z = self.t(z)

        dps = self.dps
        dpsplus = 40
        self.dps += dpsplus

        W1a = self.gamma(0.25 + 0.5j*a) / self.gamma(0.75 + 0.5j*a)
        W1 = self.exp2(-0.75) * self.sqrt(self.fabs(W1a))
        W2a = self.gamma(0.75 + 0.5j*a) / self.gamma(0.25 + 0.5j*a)
        W2 = -self.exp2(-0.25) * self.sqrt(self.fabs(W2a))
        F1 = self.exp(-0.25j*z*z) * self.hyp1f1(0.25 - 0.5j*a, 0.5, 0.5j*z*z)
        F2 = self.exp(-0.25j*z*z) * self.hyp1f1(0.75 - 0.5j*a, 1.5, 0.5j*z*z)
        res = W1*F1 + W2*z*F2

        self.dps = dps
        if self.iszero(a.imag) and self.iszero(z.imag):
            res = res.real

        return +res


# %% 20 Hypergeometric Function 2_F_1 and related functions

# %%%  20.1 Overview


    def hyp2f1(self, a, b, c, z):
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return acb(z).Hyp2f1(a, b, c)

    def hyp2f1r(self, a, b, c, z):
        a = self.t(a)
        b = self.t(b)
        c = self.t(c)
        z = self.t(z)
        return acb(z).Hyp2f1(a, b, c, True)


# %%%  20.2 Orthogonal polynomials


    def chebyt(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).chebyshev_t(n)
        return acb(z).chebyshev_t(n)

    def chebyu(self, n, z):
        n = self.t(n)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(z, arb):
            return arb(z).chebyshev_u(n)
        return acb(z).chebyshev_u(n)

    def gegenbauer(self, n, a, z):
        n = self.t(n)
        a = self.t(a)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(a, arb) and isinstance(z, arb):
            return arb(z).gegenbauer_c(n, a)
        return acb(z).gegenbauer_c(n, a)


    def jacobi(self, n, a, b, z):
        n = self.t(n)
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(a, arb) and isinstance(z, arb)\
            and isinstance(z, arb): return arb(z).jacobi_p(n, a, b)
        return acb(z).jacobi_p(n, a, b)


    def legendre(self, n, z):
        return self.legenp(n, 0, z)

    def legenp(self, n, m, z):
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(m, arb) and isinstance(z, arb):
            return arb(z).legendre_p(n, m)
        return acb(z).legendre_p(n, m)

    def legenq(self, n, m, z):
        n = self.t(n)
        m = self.t(m)
        z = self.t(z)
        if isinstance(n, arb) and isinstance(m, arb) and isinstance(z, arb):
            return arb(z).legendre_q(n, m)
        return acb(z).legendre_q(n, m)


    def spherharm(self, l, m, theta, phi):
        return
        l = self.t(l)
        m = self.t(m)
        theta = self.t(theta)
        phi = self.t(phi)
        return acb.spherical_y(l, m, theta, phi)


# %%%  20.3 Incomplete Beta

    def betainc2(self, a, b, z1=0, z2=1, regularized=False):
        return self.betainc(a, b, z1, z2, regularized)

    def betainc(self, a, b, x1=0, x2=1, regularized=False):
        if x1 == x2:
            v = 0
        elif not x1:
            if x1 == 0 and x2 == 1:
                v = self.beta(a, b)
            else:
                v = x2**a * self.hyp2f1(a, 1-b, a+1, x2) / a
        else:
            m, d = self.nint_distance(a)
            if m <= 0:
                if d < -self.prec:
                    h = +self.eps
                    self.prec *= 2
                    a += h
                elif d < -4:
                    self.prec -= d
            s1 = x2**a * self.hyp2f1(a, 1-b, a+1, x2)
            s2 = x1**a * self.hyp2f1(a, 1-b, a+1, x1)
            v = (s1 - s2) / a
        if regularized:
            v /= self.beta(a, b)
        return v

    def ibeta(self, a, b, z):
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(a, arb) and isinstance(b, arb) and isinstance(z, arb):
            return arb(z).beta_lower(a, b, 1)
        return acb(z).beta_lower(a, b, 1)

    def beta3(self, a, b, z):
        a = self.t(a)
        b = self.t(b)
        z = self.t(z)
        if isinstance(a, arb) and isinstance(b, arb) and isinstance(z, arb):
            return arb(z).beta_lower(a, b, 0)
        return acb(z).beta_lower(a, b, 0)


# %% 21 Hypergeometric Function p_F_q and related functions


# %%%  21.1 Generalized hypergeometric functions


#    def hyper(self, a_s, b_s, z):
#        return mp.hyper(a_s, b_s, z)
#
#    def hyp2f3(self, a1, a2, b1, b2, b3, z):
#        return mp.hyp2f3(a1, a2, b1, b2, b3, z)
#
#    def hyp3f2(self, a1, a2, a3, b1, b2, z):
#        return mp.hyp3f2(a1, a2, a3, b1, b2, z)
#
#    def hyp2f2(self, a1, a2, b1, b2, z):
#        return mp.hyp2f2(a1, a2, b1, b2, z)



# %%%  21.2 Generalized hypergeometric function 1F2 and related functions


    def hyp1f2(self, a1, b1, b2, z):
        # !!! Missing !!!
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        # if isinstance(a1, AprT) and isinstance(b1, AprT) and \
        # isinstance(b2, AprT) and isinstance(z, AprT):
        #     return Apr.Hyp1f2(a1, b1, b2, z)
        return #Apc.Hyp1f2(a1, b1, b2, z)

    def hyp1f2r(self, a1, b1, b2, z):
        # !!! Missing !!!
        a1 = self.t(a1)
        b1 = self.t(b1)
        b2 = self.t(b2)
        z = self.t(z)
        # if isinstance(a1, AprT) and isinstance(b1, AprT) and \
        # isinstance(b2, AprT) and isinstance(z, AprT):
        #     return Apr.Hyp1f2r(a1, b1, b2, z)
        return #Apc.Hyp1f2r(a1, b1, b2, z)

    def scorergi(self, z):
        z = self.t(z)
        t = self.t(1)/self.t(3)
        res1 = self.airybi(z)/3
        res2 = (z*z)/(2*self.pi)
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 - res2*res3
        return res

    def scorerhi(self, z):
        z = self.t(z)
        t = self.t(1)/self.t(3)
        res1 = 2*self.airybi(z)/3
        res2 = (z*z)/(2*self.pi)
        res3 = self.hyp1f2(1, 4*t, 5*t, z*z*z/9)
        res = res1 + res2*res3
        return res

    def struveh(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res2 = (z/2)**(n+1)
        res3 = self.hyp1f2r(1, 1.5, n+1.5, -z*z/4)
        res = res2*res3
        return res

    def struvel(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res = -1j*self.expjpi(-n/2)*self.struveh(n, 1j*z)
        if self.iszero(res.imag):
            res = res.real
        return res

    def struvek(self, n, z):
        n = self.t(n)
        z = self.t(z)
        res1 = self.struveh(n, z)
        res2 = self.bessely(n, z)
        return res1 - res2

    def struvem(self, n, z):
        n = self.t(n)
        z = self.t(z)
        return self.struvel(n, z) - self.besseli(n, z)

    def webere(self, n, z):
        n = self.t(n)
        z = self.t(z)
        tau = self.pi * n / 2
        res2a = self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res2b = (z/2)*self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res = res2a*res3a - res2b*res3b
        return res

    def angerj(self, n, z):
        # if n is an integer, return besselj(n,z)
        n = self.t(n)
        z = self.t(z)
        tau = self.pi * n / 2
        res2a = (z/2)*self.sin(tau)
        res3a = self.hyp1f2r(1, 0.5*(3-n), 0.5*(3+n), -z*z/4)
        res2b = self.cos(tau)
        res3b = self.hyp1f2r(1, 0.5*(2-n), 0.5*(2+n), -z*z/4)
        res = res2a*res3a + res2b*res3b
        return res

    def lommels1(self, mu, nu, z):
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res2 = z**(mu+1)/((mu-nu+1)*(mu+nu+1))
        res3 = self.hyp1f2(1, (mu-nu+3)/2, (mu+nu+3)/2, -z*z/4)
        res = res2*res3
        return res

    def lommels2(self,  mu, nu, z):
        mu = self.t(mu)
        nu = self.t(nu)
        z = self.t(z)
        res1 = self.lommels1(mu, nu, z)
        res2 = 2**(mu-1) * self.gamma((mu-nu+1)/2) * self.gamma((mu+nu+1)/2)
        res3 = self.sin(self.pi*(mu-nu)/2) * self.besselj(nu, z)
        res4 = self.cos(self.pi*(mu-nu)/2) * self.bessely(nu, z)
        res = res1+res2*(res3-res4)
        return res


# %% 22 Generalizations of gamma and hypergeometric functions (without ARB support)


# Not implemented in ARB

