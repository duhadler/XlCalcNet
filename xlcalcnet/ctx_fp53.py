from xlcalcnet.mpmath.ctx_base import StandardBaseContext

import math
#import cmath
from xlcalcnet import mathfp

from xlcalcnet.mpmath import function_docs

from xlcalcnet.mpmath.libmp import mpf_bernoulli, to_float, int_types
from xlcalcnet.mpmath import libmp

class FP53Context(StandardBaseContext):
    """
    Context for fast low-precision arithmetic (53-bit precision, giving at most
    about 15-digit accuracy), using Python's builtin float and complex.
    """

    def __init__(ctx):
        StandardBaseContext.__init__(ctx)

        # Override SpecialFunctions implementation
        ctx.loggamma = mathfp.loggamma
        ctx._bernoulli_cache = {}
        ctx.pretty = False

        ctx._init_aliases()

    _mpq = lambda cls, x: float(x[0])/x[1]

    NoConvergence = libmp.NoConvergence

    def _get_prec(ctx): return 53
    def _set_prec(ctx, p): return
    def _get_dps(ctx): return 15
    def _set_dps(ctx, p): return

    _fixed_precision = True

    prec = property(_get_prec, _set_prec)
    dps = property(_get_dps, _set_dps)

    zero = 0.0
    one = 1.0
    eps = mathfp.EPS
    inf = mathfp.INF
    ninf = mathfp.NINF
    nan = mathfp.NAN
    j = 1j

    # Called by SpecialFunctions.__init__()
    @classmethod
    def _wrap_specfun(cls, name, f, wrap):
        if wrap:
            def f_wrapped(ctx, *args, **kwargs):
                convert = ctx.convert
                args = [convert(a) for a in args]
                return f(ctx, *args, **kwargs)
        else:
            f_wrapped = f
        f_wrapped.__doc__ = function_docs.__dict__.get(name, f.__doc__)
        setattr(cls, name, f_wrapped)

    def bernoulli(ctx, n):
        cache = ctx._bernoulli_cache
        if n in cache:
            return cache[n]
        cache[n] = to_float(mpf_bernoulli(n, 53, 'n'), strict=True)
        return cache[n]

    pi = mathfp.pi
    e = mathfp.e
    euler = mathfp.euler
    sqrt2 = 1.4142135623730950488
    sqrt5 = 2.2360679774997896964
    phi = 1.6180339887498948482
    ln2 = 0.69314718055994530942
    ln10 = 2.302585092994045684
    euler = 0.57721566490153286061
    catalan = 0.91596559417721901505
    khinchin = 2.6854520010653064453
    apery = 1.2020569031595942854
    glaisher = 1.2824271291006226369
    degree = 1.745329251994329576923691E-02

    absmin = absmax = abs

    def is_special(ctx, x):
        return x - x != 0.0

    def isnan(ctx, x):
        return x != x

    def isinf(ctx, x):
        return abs(x) == mathfp.INF

    def isnormal(ctx, x):
        if x:
            return x - x == 0.0
        return False

    def isnpint(ctx, x):
        if type(x) is complex:
            if x.imag:
                return False
            x = x.real
        return x <= 0.0 and round(x) == x

    mpf = float
    mpc = complex

    def convert(ctx, x, y):
        try:
            return float(x)
        except:
            return complex(x)

    power = staticmethod(mathfp.pow)
    sqrt = staticmethod(mathfp.sqrt)
    exp = staticmethod(mathfp.exp)
    ln = log = staticmethod(mathfp.log)
    cos = staticmethod(mathfp.cos)
    sin = staticmethod(mathfp.sin)
    tan = staticmethod(mathfp.tan)
    cos_sin = staticmethod(mathfp.cos_sin)
    acos = staticmethod(mathfp.acos)
    asin = staticmethod(mathfp.asin)
    atan = staticmethod(mathfp.atan)
    cosh = staticmethod(mathfp.cosh)
    sinh = staticmethod(mathfp.sinh)
    tanh = staticmethod(mathfp.tanh)
    gamma = staticmethod(mathfp.gamma)
    rgamma = staticmethod(mathfp.rgamma)
    fac = factorial = staticmethod(mathfp.factorial)
    floor = staticmethod(mathfp.floor)
    ceil = staticmethod(mathfp.ceil)
    cospi = staticmethod(mathfp.cospi)
    sinpi = staticmethod(mathfp.sinpi)
    cbrt = staticmethod(mathfp.cbrt)
    _nthroot = staticmethod(mathfp.nthroot)
    _ei = staticmethod(mathfp.ei)
    _e1 = staticmethod(mathfp.e1)
    _zeta = _zeta_int = staticmethod(mathfp.zeta)


# change DH #
    def ismpf(ctx, x):
        return isinstance(x, float)

# change DH #
    def ismpc(ctx, x):
        return isinstance(x, complex)

    # XXX: mathfp
    def arg(ctx, z):
        z = complex(z)
        return math.atan2(z.imag, z.real)

    def hypot(ctx, x, y):
        x = ctx.convert(x)
        y = ctx.convert(y)
        return ctx.sqrt(x*x+y*y)

    def expj(ctx, x):
        return ctx.exp(ctx.j*x)

    def expjpi(ctx, x):
        return ctx.exp(ctx.j*ctx.pi*x)

    ldexp = math.ldexp
    frexp = math.frexp

    def mag(ctx, z):
        if z:
            return ctx.frexp(abs(z))[1]
        return ctx.ninf

    def isint(ctx, z):
        if hasattr(z, "imag"):   # float/int don't have .real/.imag in py2.5
            if z.imag:
                return False
            z = z.real
        try:
            return z == int(z)
        except:
            return False

    def nint_distance(ctx, z):
        if hasattr(z, "imag"):   # float/int don't have .real/.imag in py2.5
            n = round(z.real)
        else:
            n = round(z)
        if n == z:
            return n, ctx.ninf
        return n, ctx.mag(abs(z-n))

    def _convert_param(ctx, z):
        if type(z) is tuple:
            p, q = z
            return ctx.mpf(p) / q, 'R'
        if hasattr(z, "imag"):    # float/int don't have .real/.imag in py2.5
            intz = int(z.real)
        else:
            intz = int(z)
        if z == intz:
            return intz, 'Z'
        return z, 'R'

    def _is_real_type(ctx, z):
        return isinstance(z, float) or isinstance(z, int_types)

    def _is_complex_type(ctx, z):
        return isinstance(z, complex)

    def hypsum(ctx, p, q, types, coeffs, z, maxterms=6000, **kwargs):
        coeffs = list(coeffs)
        num = range(p)
        den = range(p,p+q)
        tol = ctx.eps
        s = t = 1.0
        k = 0
        while 1:
            for i in num: t *= (coeffs[i]+k)
            for i in den: t /= (coeffs[i]+k)
            k += 1; t /= k; t *= z; s += t
            if abs(t) < tol:
                return s
            if k > maxterms:
                raise ctx.NoConvergence

    def atan2(ctx, x, y):
        return math.atan2(x, y)

    def psi(ctx, m, z):
        m = int(m)
        if m == 0:
            return ctx.digamma(z)
        return (-1)**(m+1) * ctx.fac(m) * ctx.zeta(m+1, z)

    digamma = staticmethod(mathfp.digamma)

    def harmonic(ctx, x):
        x = ctx.convert(x)
        if x == 0 or x == 1:
            return x
        return ctx.digamma(x+1) + ctx.euler

    #nstr = str

    def to_fixed(ctx, x, prec):
        return int(math.ldexp(x, prec))

    def rand(ctx):
        import random
        return random.random()

    _erf = staticmethod(mathfp.erf)
    _erfc = staticmethod(mathfp.erfc)

    def sum_accurately(ctx, terms, check_step=1):
        s = ctx.zero
        k = 0
        for term in terms():
            s += term
            if (not k % check_step) and term:
                if abs(term) <= 1e-18*abs(s):
                    break
            k += 1
        return s


# from here change DH



    def isfinite(ctx, x):
        if ctx.isinf(x) or ctx.isnan(x):
            return False
        return True


    def _nstr(ctx, z, n=6, **kwargs):
        f = "{0:." + str(n-1) + "E}"
        # print(f)
        if z.imag == 0:
            z = float(z)
        else:
            z = complex(z)
        s = f.format(z)
        return s

    def nstr(ctx, x, n=6, **kwargs):
        if isinstance(x, list):
            return "[%s]" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, tuple):
            return "(%s)" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, float):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, complex):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, str):
            return repr(x)
        if isinstance(x, ctx.matrix):
            return x.__nstr__(n, **kwargs)
        return str(x)



    def extraprec(ctx, n, normalize_output=False):
        return PrecisionManager(ctx, lambda p: p + n, None, normalize_output)

    def extradps(ctx, n, normalize_output=False):
        return PrecisionManager(ctx, None, lambda d: d + n, normalize_output)

    def workprec(ctx, n, normalize_output=False):
        return PrecisionManager(ctx, lambda p: n, None, normalize_output)

    def workdps(ctx, n, normalize_output=False):
        return PrecisionManager(ctx, None, lambda d: n, normalize_output)

    def autoprec(ctx, f, maxprec=None, catch=(), verbose=False):
        def f_autoprec_wrapped(*args, **kwargs):
            prec = ctx.prec
            if maxprec is None:
                maxprec2 = ctx._default_hyper_maxprec(prec)
            else:
                maxprec2 = maxprec
            try:
                ctx.prec = prec + 10
                try:
                    v1 = f(*args, **kwargs)
                except catch:
                    v1 = ctx.nan
                prec2 = prec + 20
                while 1:
                    ctx.prec = prec2
                    try:
                        v2 = f(*args, **kwargs)
                    except catch:
                        v2 = ctx.nan
                    if v1 == v2:
                        break
                    err = ctx.mag(v2-v1) - ctx.mag(v2)
                    if err < (-prec):
                        break
                    if verbose:
                        print("autoprec: target=%s, prec=%s, accuracy=%s"
                              % (prec, prec2, -err))
                    v1 = v2
                    if prec2 >= maxprec2:
                        raise ctx.NoConvergence(
                            "autoprec: prec increased to %i without convergence"
                            % prec2)
                    prec2 += int(prec2*2)
                    prec2 = min(prec2, maxprec2)
            finally:
                ctx.prec = prec
            return +v2
        return f_autoprec_wrapped


class PrecisionManager:
    def __init__(self, ctx, precfun, dpsfun, normalize_output=False):
        self.ctx = ctx
        self.precfun = precfun
        self.dpsfun = dpsfun
        self.normalize_output = normalize_output

    def __call__(self, f):
        def g(*args, **kwargs):
            orig = self.ctx.prec
            try:
                if self.precfun:
                    self.ctx.prec = self.precfun(self.ctx.prec)
                else:
                    self.ctx.dps = self.dpsfun(self.ctx.dps)
                if self.normalize_output:
                    v = f(*args, **kwargs)
                    if type(v) is tuple:
                        return tuple([+a for a in v])
                    return +v
                else:
                    return f(*args, **kwargs)
            finally:
                self.ctx.prec = orig
        g.__name__ = f.__name__
        g.__doc__ = f.__doc__
        return g

    def __enter__(self):
        self.origp = self.ctx.prec
        if self.precfun:
            self.ctx.prec = self.precfun(self.ctx.prec)
        else:
            self.ctx.dps = self.dpsfun(self.ctx.dps)

    def __exit__(self, exc_type, exc_val, exc_tb):
        self.ctx.prec = self.origp
        return False
