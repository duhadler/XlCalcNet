

from xlcalcnet.mpmath.ctx_base import StandardBaseContext

from xlcalcnet import mathgp

import gmpy2

from xlcalcnet.mpmath import function_docs, rational #, mp as _mp

from xlcalcnet.mpmath.libmp import int_types
from xlcalcnet.mpmath import libmp
#print("Before mathgp.get_gmp()")
gmp = mathgp.get_gmp()
#print("After mathgp.get_gmp()")

class _constant():

    def __new__(cls, func, name='', docname=''):
        a = object.__new__(cls)
        a.func = func
        return a

# up to gmpy2 version 2.08, we cannot subclass mpfr,
# so we need to provide our own operator overloading
    def __call__(self): return self.func()
    def __pos__(self): return +self.func()
    def __neg__(self): return -self.func()
    def __add__(self, b): return self.func() + mathgp.t(b)
    def __radd__(self, b): return self.func() + mathgp.t(b)
    def __iadd__(self, b): return self.func() + mathgp.t(b)
    def __sub__(self, b): return self.func() - mathgp.t(b)
    def __rsub__(self, b): return mathgp.t(b) - self.func()
    def __isub__(self, b): return self.func() - mathgp.t(b)
    def __mul__(self, b): return self.func() * mathgp.t(b)
    def __rmul__(self, b): return self.func() * mathgp.t(b)
    def __imul__(self, b): return self.func() * mathgp.t(b)
    def __div__(self, b): return self.func() / mathgp.t(b)
    def __rdiv__(self, b): return mathgp.t(b) / self.func()
    def __idiv__(self, b): return self.func() / mathgp.t(b)
    def __truediv__(self, b): return self.func() / mathgp.t(b)
    def __rtruediv__(self, b): return mathgp.t(b) / self.func()
    def __itruediv__(self, b): return self.func() / mathgp.t(b)
    def __pow__(self, b): return self.func() ** mathgp.t(b)
    def __rpow__(self, b): return mathgp.t(b) ** self.func()
    def __ipow__(self, b): return self.func() ** mathgp.t(b)
    def __eq__(self, b): return self.func() == mathgp.t(b)
    def __ne__(self, b): return self.func() != mathgp.t(b)
    def __le__(self, b): return self.func() <= mathgp.t(b)
    def __lt__(self, b): return self.func() < mathgp.t(b)
    def __ge__(self, b): return self.func() >= mathgp.t(b)
    def __gt__(self, b): return self.func() > mathgp.t(b)
    def __str__(self): return str(+self.func())


class GPContext(StandardBaseContext):

    mpf = gmpy2.mpfr
    mpc = gmpy2.mpc

    def __init__(ctx):

        StandardBaseContext.__init__(ctx)

        gmp.allow_complex = True
        gmp.trap_divzero = True
        ctx.dps = 15
        ctx.pretty = True

        ctx.constant = type('constant', (_constant,), {})
        ctx.types = [ctx.mpf, ctx.mpc, ctx.constant]
        ctx.init_builtins()
        ctx._init_aliases()
        ctx._prec_rounding = [53, gmpy2.RoundToNearest]


    def init_builtins(ctx):

        # Exact constants
        ctx.zero = gmpy2.mpfr(0)
        ctx.one = gmpy2.mpfr(1)
        ctx.j = gmpy2.mpc(0, 1)
        ctx.inf = gmpy2.inf()
        ctx.ninf = gmpy2.inf(-1)
        ctx.nan = gmpy2.nan()

        # Approximate constants
        ctx.eps = ctx.constant(mathgp.get_eps)
        ctx.pi = ctx.constant(gmpy2.const_pi)
        ctx.ln2 = ctx.constant(gmpy2.const_log2)
        ctx.ln10 = ctx.constant(mathgp.get_log10)
        ctx.phi = ctx.constant(mathgp.get_phi)
        ctx.e = ctx.constant(mathgp.get_e)
        ctx.euler = ctx.constant(gmpy2.const_euler)
        ctx.catalan = ctx.constant(gmpy2.const_catalan)
        ctx.apery = ctx.constant(mathgp.get_apery)
        ctx.degree = ctx.constant(mathgp.get_degree)

        ctx.khinchin = ctx.constant(mathgp.get_khinchin)
        ctx.glaisher = ctx.constant(mathgp.get_glaisher)
        ctx.twinprime = ctx.constant(mathgp.get_twinprime)
        ctx.mertens = ctx.constant(mathgp.get_mertens)

        # Elementary Functions
        # (this function is broken in gmpy2.version 2.08)
        ctx.conj = mathgp.get_conj

        ctx.sign = mathgp.get_sign
        ctx.fabs = mathgp.get_fabs

        ctx.frac = mathgp.get_frac
        ctx.nint = mathgp.get_nint
        ctx.floor = mathgp.get_floor
        ctx.ceil = mathgp.get_ceil
        ctx.ldexp = mathgp.get_ldexp
        ctx.frexp = mathgp.get_frexp

        ctx.agm = mathgp.get_agm
        ctx.cos = mathgp.get_cos
        ctx.sin = mathgp.get_sin
        ctx.cospi = mathgp.get_cospi
        ctx.sinpi = mathgp.get_sinpi
        ctx.tan = mathgp.get_tan
        ctx.acos = mathgp.get_acos
        ctx.asin = mathgp.get_asin
        ctx.atan = mathgp.get_atan
        ctx.atan2 = mathgp.get_atan2
        ctx.cosh = mathgp.get_cosh
        ctx.sinh = mathgp.get_sinh
        ctx.tanh = mathgp.get_tanh
        ctx.acosh = mathgp.get_acosh
        ctx.asinh = mathgp.get_asinh
        ctx.atanh = mathgp.get_atanh
        ctx.exp = mathgp.get_exp
        ctx.ln = mathgp.get_ln
        ctx.log = mathgp.get_ln
        # add log = logb, special cases log2 and log10
        ctx.sqrt = mathgp.get_sqrt
        ctx.cbrt = mathgp.get_cbrt
        ctx._nthroot = mathgp.get_nthroot

        ctx.gamma = mathgp.get_gamma
        ctx.rgamma = mathgp.get_rgamma
        ctx.fac = ctx.factorial = mathgp.get_factorial
        ctx.loggamma = mathgp.get_loggamma
        ctx.bernoulli = mathgp.get_bernoulli

        # Optional Functions (speedups)
#        ctx.arg = staticmethod(gmpy2.phase)
#        ctx.fmod = staticmethod(gmpy2.fmod)

#        ctx.expm1 = mathgp.expm1
#        ctx.lnp1 = mathgp.lnp1
#        ctx.hypot = gmpy2.hypot
#        ctx._erf = mathgp.erf
#        ctx._erfc = mathgp.erfc

#        ctx._ei = mathgp.ei
#        ctx._e1 = mathgp.e1
        ctx._zeta_int = mathgp.zeta

    def ismpf(ctx, x):
        return isinstance(x, gmpy2.mpfr)

    def ismpc(ctx, x):
        return isinstance(x, gmpy2.mpc)

    def hypot(ctx, x, y):
        x = ctx.convert(x)
        y = ctx.convert(y)
        return ctx.sqrt(x*x+y*y)

    def mag_real(ctx, z):
        if ctx.iszero(z):
            return ctx.ninf
        if ctx.isinf(z):
            return ctx.inf
        if ctx.isnan(z):
            return ctx.nan
        return ctx.frexp(abs(z))[1]

    def mag(ctx, z):
        z = ctx.convert(z)
        if isinstance(z, gmpy2.mpfr):
            return ctx.mag_real(z)
        if ctx.iszero(z.real):
            return ctx.mag_real(z.imag)
        if ctx.iszero(z.imag):
            return ctx.mag_real(z.real)
        r = ctx.mag_real(z.real)
        i = ctx.mag_real(z.imag)
        if r > i:
            return r + 1
        else:
            return i + 1

    def expj(ctx, x): return ctx.exp(ctx.j*x)

    def expjpi(ctx, x): return ctx.exp(ctx.j*ctx.pi*x)

    def _mpq(cls, x): return mathgp.t(x[0])/x[1]

    NoConvergence = libmp.NoConvergence
    _fixed_precision = False
    absmin = absmax = abs

    def prec_to_dps(ctx, n):
        """Return number of accurate decimals that can be represented
        with a precision of n bits."""
        return max(1, int(round(int(n)/3.3219280948873626)-1))

    def dps_to_prec(ctx, n):
        """Return the number of bits required to represent n decimals
        accurately."""
        return max(1, int(round((int(n)+1)*3.3219280948873626)))

    def repr_dps(ctx, n):
        """Return the number of decimal digits required to represent
        a number with n-bit precision so that it can be uniquely
        reconstructed from the representation."""
        dps = ctx.prec_to_dps(n)
        if dps == 15:
            return 17
        return dps + 3

    def _get_prec(ctx): return gmp.precision
    def _set_prec(ctx, p): gmp.precision = int(p)
    def _get_dps(ctx): return ctx.prec_to_dps(gmp.precision)
    def _set_dps(ctx, p): gmp.precision = int(ctx.dps_to_prec(p))

    prec = property(_get_prec, _set_prec)
    dps = property(_get_dps, _set_dps)

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


    def isnan(ctx, x):
        if isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
            return gmpy2.is_nan(x)
        if isinstance(x, int_types) or isinstance(x, rational.mpq):
            return False
        x = ctx.convert(x)
        if isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
            return gmpy2.is_nan(x)
        raise TypeError("isnan() needs a number as input")

    def is_special(ctx, x):
        return x - x != 0.0

    def isnormal(ctx, x):
        if x:
            return x - x == 0.0
        return False

    def _is_real_type(ctx, x):
        if (isinstance(x, gmpy2.mpc)) or (type(x) is complex):
            return False
        return True

    def _is_complex_type(ctx, x):
        if (isinstance(x, gmpy2.mpc)) or (type(x) is complex):
            return True
        return False

    def iszero(ctx, x):
        return gmpy2.is_zero(x)

    def isinf(ctx, x):
        s = str(type(x))
        if isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
            return gmpy2.is_infinite(x)
        if isinstance(x, int_types) or isinstance(x, rational.mpq):
            return False
        x = ctx.convert(x)
        if isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
            return gmpy2.is_infinite(x)
        raise TypeError("isnan() needs a number as input")

    def isfinite(ctx, x):
        if ctx.isinf(x) or ctx.isnan(x):
            return False
        return True

    def isint(ctx, z):
        z = ctx.convert(z)
        if z.imag:
            return False
        return z.real.is_integer()

    def isnpint(ctx, z):
        z = ctx.convert(z)
        if z.imag:
            return False
        return z.real <= 0.0 and z.real.is_integer()

    def fraction(ctx, p, q):
        return ctx.constant(lambda: mathgp.get_from_rational(p, q), '%s/%s' % (p, q))

    def nint_distance(ctx, z):
        n = round(z.real)
        if n == z:
            return n, ctx.ninf
        return n, ctx.mag(abs(z-n))

    def convert(ctx, x):
        return mathgp.t(x)

    def _convert_param(ctx, z):
        if type(z) is tuple:
            p, q = z
            return ctx.mpf(p) / q, 'R'
        intz = int(z.real)
        if z == intz:
            return intz, 'Z'
        return z, 'R'

    def _nstr(ctx, z, n=6, **kwargs):
        f = "{0:." + str(n-1) + "E}"
        # print(f)
        z = mathgp.t(z)
        s = f.format(z)
        return s

    def nstr(ctx, x, n=6, **kwargs):
        if isinstance(x, list):
            return "[%s]" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, tuple):
            return "(%s)" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, gmpy2.mpfr):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, gmpy2.mpc):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, str):
            return repr(x)
        if isinstance(x, ctx.matrix):
            return x.__nstr__(n, **kwargs)
        return str(x)

    def setinteger(ctx, x):
        x = int(x)
        prec = ctx.mag(x) + 4
        print("prec: ", prec)
        with gmpy2.local_context(gmp, precision=prec):  # as gmpctx:
            res = ctx.convert(x)
        return res

    def _parse_prec(ctx, kwargs):
        if kwargs:
            if kwargs.get('exact'):
                return 0, 'f'
            prec, rounding = ctx._prec_rounding
            if 'rounding' in kwargs:
                rounding = kwargs['rounding']
            if 'prec' in kwargs:
                prec = kwargs['prec']
                print("prec: ", prec, ctx.isinf(prec))
                if prec == ctx.inf:
                    return 0, 'f'
                else:
                    prec = int(prec)
            elif 'dps' in kwargs:
                dps = kwargs['dps']
                if dps == ctx.inf:
                    return 0, 'f'
                prec = ctx.dps_to_prec(dps)
            return prec, rounding
        return ctx._prec_rounding


    def fadd(ctx, x, y, **kwargs):
        prec, rounding = ctx._parse_prec(kwargs)

        rnd = gmpy2.RoundToNearest  # rounding == 'n'
        if rounding == 'f':
            rnd = gmpy2.RoundDown
        elif rounding == 'c':
            rnd = gmpy2.RoundUp
        elif rounding == 'd':
            rnd = gmpy2.RoundToZero
        elif rounding == 'u':
            rnd = gmpy2.RoundAwayZero

        x = ctx.convert(x)
        y = ctx.convert(y)

        #print("prec: ", prec)
        #print("rounding: ", rounding)
        # n: nearest; RoundToNearest; Round to the nearest value; ties are rounded to an even value.
        # f: floor; RoundDown; The result is rounded towards -Infinity.
        # c: ceiling; RoundUp; The result is rounded towards +Infinity.
        # d: down ; RoundToZero;  rounded towards zero
        # u: up; RoundAwayZero;  rounded away from zero

        # Note: RoundAwayZero is not a valid rounding mode for mpc.

        if prec == 0:
            valprecmin = min(x.precision, y.precision)

            magprec = abs(ctx.mag(x)-ctx.mag(y))
            #print("magprec: ", magprec)
            prec = magprec + valprecmin
            #print("prec: ", prec)

        try:
            with gmpy2.local_context(gmp, precision=prec, round=rnd):
                res = x + y
                return res

        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fsub(ctx, x, y, **kwargs):
        x = ctx.convert(x)
        y = ctx.convert(y)
        return ctx.fadd(x, -y, **kwargs)

    def fmul(ctx, x, y, **kwargs):
        prec, rounding = ctx._parse_prec(kwargs)
        print("prec:", prec)

        rnd = gmpy2.RoundToNearest  # rounding == 'n'
        if rounding == 'f':
            rnd = gmpy2.RoundToZero
        elif rounding == 'c':
            rnd = gmpy2.RoundAwayZero
        elif rounding == 'd':
            rnd = gmpy2.RoundDown
        elif rounding == 'u':
            rnd = gmpy2.RoundUp

        x = ctx.convert(x)
        y = ctx.convert(y)

        if prec == 0:
            print("x.precision:", x.precision)
            print("y.precision:", y.precision)
            prec = x.precision + y.precision
            print("prec: ", prec)

        try:
            with gmpy2.local_context(gmp, precision=prec, round=rnd):
                res = x * y
                return res

        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fneg(ctx, x, **kwargs):
        return ctx.fmul(x, -1,  **kwargs)

    def fdiv(ctx, x, y, **kwargs):
        prec, rounding = ctx._parse_prec(kwargs)

        rnd = gmpy2.RoundToNearest  # rounding == 'n'
        if rounding == 'f':
            rnd = gmpy2.RoundToZero
        elif rounding == 'c':
            rnd = gmpy2.RoundAwayZero
        elif rounding == 'd':
            rnd = gmpy2.RoundDown
        elif rounding == 'u':
            rnd = gmpy2.RoundUp

        x = ctx.convert(x)
        y = ctx.convert(y)

        try:
            with gmpy2.local_context(gmp, precision=prec, round=rnd):
                res = x / y
                return res

        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fmod(ctx, x, y):
        return ctx.convert(x) % ctx.convert(y)

    def fsum(ctx, args, absolute=False, squared=False):
        if absolute:
            if squared:
                return sum((abs(x)**2 for x in args), ctx.zero)
            return sum((abs(x) for x in args), ctx.zero)
        if squared:
            return sum((x**2 for x in args), ctx.zero)
        return sum(args, ctx.zero)

    def fdot(ctx, xs, ys=None, conjugate=False):
        if ys is not None:
            xs = zip(xs, ys)
        if conjugate:
            cf = ctx.conj
            return sum((x*cf(y) for (x, y) in xs), ctx.zero)
        else:
            return sum((x*y for (x, y) in xs), ctx.zero)

    def fprod(ctx, args):
        prod = ctx.one
        for arg in args:
            prod *= ctx.convert(arg)
        return prod

    def demo_conv_tupel(ctx):
        #x = ctx.convert('5.55555515555555551E-60'); x
        x = ctx.convert('5.55555515555555551e+60')
        x
        print("x: ", x)

        m, e = x.as_mantissa_exp()
        print("m: ", m, "e: ", e)
        m1 = gmpy2.mpfr(m)
        e1 = int(e)

        if e1 < 0:
            r = r = gmpy2.div_2exp(m1, -e1)
        else:
            r = r = gmpy2.mul_2exp(m1, e1)
        print("r: ", r)
        return

    def hypsum(ctx, p, q, types, coeffs, z, maxterms=6000, **kwargs):
        coeffs = list(coeffs)
        num = range(p)
        den = range(p, p+q)
        tol = ctx.eps
        s = t = ctx.convert(1)
        k = 0
        while 1:
            for i in num:
                t *= (coeffs[i]+k)
            for i in den:
                t /= (coeffs[i]+k)
            k += 1
            t /= k
            t *= z
            s += t
            if abs(t) < tol:
                return s
            if k > maxterms:
                raise ctx.NoConvergence

    def to_fixed(ctx, x, prec):
        return int(ctx.ldexp(x, prec))

    def rand(ctx):
        import random
        return mathgp.t(random.random())

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
