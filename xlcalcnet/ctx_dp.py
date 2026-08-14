

from decimal import Decimal as D
from decimal import localcontext
from decimal import ROUND_FLOOR, ROUND_CEILING, ROUND_UP, ROUND_DOWN, ROUND_HALF_EVEN
from xlcalcnet.mathdp import DecCplx as DC
from xlcalcnet import mathdp

from xlcalcnet.mpmath.ctx_base import StandardBaseContext
from xlcalcnet.mpmath import function_docs, rational #, mp as _mp
from xlcalcnet.mpmath.libmp import int_types
from xlcalcnet.mpmath import libmp

dec = mathdp.get_dec()


class _constant():

    def __new__(cls, func, name='', docname=''):
        a = object.__new__(cls)
        a.func = func
        return a

# we provide our own operator overloading
    def __call__(self): return self.func()
    def __pos__(self): return self.func()
    def __neg__(self): return -self.func()
    def __add__(self, b): return self.func() + mathdp.t(b)
    def __radd__(self, b): return self.func() + mathdp.t(b)
    def __iadd__(self, b): return self.func() + mathdp.t(b)
    def __sub__(self, b): return self.func() - mathdp.t(b)
    def __rsub__(self, b): return mathdp.t(b) - self.func()
    def __isub__(self, b): return self.func() - mathdp.t(b)
    def __mul__(self, b): return self.func() * mathdp.t(b)
    def __rmul__(self, b): return self.func() * mathdp.t(b)
    def __imul__(self, b): return self.func() * mathdp.t(b)
    def __div__(self, b): return self.func() / mathdp.t(b)
    def __rdiv__(self, b): return mathdp.t(b) / self.func()
    def __idiv__(self, b): return self.func() / mathdp.t(b)
    def __truediv__(self, b): return self.func() / mathdp.t(b)
    def __rtruediv__(self, b): return mathdp.t(b) / self.func()
    def __itruediv__(self, b): return self.func() / mathdp.t(b)
    def __pow__(self, b): return self.func() ** mathdp.t(b)
    def __rpow__(self, b): return mathdp.t(b) ** self.func()
    def __ipow__(self, b): return self.func() ** mathdp.t(b)
    def __eq__(self, b): return self.func() == mathdp.t(b)
    def __ne__(self, b): return self.func() != mathdp.t(b)
    def __le__(self, b): return self.func() <= mathdp.t(b)
    def __lt__(self, b): return self.func() < mathdp.t(b)
    def __ge__(self, b): return self.func() >= mathdp.t(b)
    def __gt__(self, b): return self.func() > mathdp.t(b)
    def __str__(self): return str(+self.func())


class DPContext(StandardBaseContext):

    def __init__(ctx):
        StandardBaseContext.__init__(ctx)

        ctx.dps = 15
        ctx.pretty = True
        ctx.constant = type('constant', (_constant,), {})
        ctx.types = [ctx.mpf, ctx.mpc, ctx.constant]
#        ctx.types = [ctx.mpf, ctx.mpc]
        ctx.init_builtins()
        ctx._init_aliases()
        ctx._prec_rounding = [53, ROUND_HALF_EVEN]


    def init_builtins(ctx):

        # Exact constants
        ctx.zero = D(0)
        ctx.one = D(1)
        ctx.j = mathdp.t(0, 1)
        ctx.inf = D('inf')
        ctx.ninf = -D('inf')
        ctx.nan = D('nan')

        # Approximate constants
        ctx.eps = ctx.constant(mathdp.get_eps)
        ctx.pi = ctx.constant(mathdp.get_pi)
        ctx.ln2 = ctx.constant(mathdp.get_log2)
        ctx.ln10 = ctx.constant(mathdp.get_log10)
        ctx.phi = ctx.constant(mathdp.get_phi)
        ctx.e = ctx.constant(mathdp.get_e)
        ctx.euler = ctx.constant(mathdp.get_euler)
        ctx.catalan = ctx.constant(mathdp.get_catalan)
        ctx.apery = ctx.constant(mathdp.get_apery)
        ctx.degree = ctx.constant(mathdp.get_degree)

        ctx.khinchin = ctx.constant(mathdp.get_khinchin)
        ctx.glaisher = ctx.constant(mathdp.get_glaisher)
        ctx.twinprime = ctx.constant(mathdp.get_twinprime)
        ctx.mertens = ctx.constant(mathdp.get_mertens)



        # Elementary Functions
        ctx.conj = mathdp.get_conj

        ctx.sign = mathdp.get_sign
        ctx.fabs = mathdp.get_fabs

        ctx.frac = mathdp.get_frac
        ctx.nint = mathdp.get_nint
        ctx.floor = mathdp.get_floor
        ctx.ceil = mathdp.get_ceil
        ctx.ldexp = mathdp.get_ldexp
        ctx.frexp = mathdp.get_frexp

        ctx.agm = mathdp.get_agm

        ctx.cos = mathdp.get_cos
        ctx.sin = mathdp.get_sin
        ctx.cospi = mathdp.get_cospi
        ctx.sinpi = mathdp.get_sinpi
        ctx.tan = mathdp.get_tan
        ctx.cot = mathdp.get_cot
        ctx.acos = mathdp.get_acos
        ctx.asin = mathdp.get_asin
        ctx.atan = mathdp.get_atan
        ctx.atan2 = mathdp.get_atan2
        ctx.cosh = mathdp.get_cosh
        ctx.sinh = mathdp.get_sinh
        ctx.tanh = mathdp.get_tanh
        ctx.acosh = mathdp.get_acosh
        ctx.asinh = mathdp.get_asinh
        ctx.atanh = mathdp.get_atanh

        ctx.powm1 = mathdp.get_powm1
        ctx.exp = mathdp.get_exp
        ctx.ln = mathdp.get_ln
        ctx.log = mathdp.get_ln
        ctx.sqrt = mathdp.get_sqrt
        ctx.cbrt = mathdp.get_cbrt
        ctx._nthroot = mathdp.get_nthroot

        ctx.gamma = mathdp.get_gamma
        ctx.rgamma = mathdp.get_rgamma
        ctx.fac = ctx.factorial = mathdp.get_factorial
        ctx.loggamma = mathdp.get_loggamma

        ctx.bernoulli = mathdp.get_bernoulli


    def ismpf(self, z):
        return isinstance(z, D)

    def ismpc(self, z):
        return str(type(z)) == "<class 'xlcalcnet.mathdp.DecCplx'>"

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
        if isinstance(z, D):
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

    mpf = D
    mpc = mathdp.DecCplx
    def _mpq(cls, x): return D(x[0])/x[1]

    NoConvergence = libmp.NoConvergence
    _fixed_precision = False
    absmin = absmax = abs


    def expj(ctx, x): return ctx.exp(mathdp.DecCplx(ctx.j)*x)

    #def expjpi(ctx, x): return ctx.exp(ctx.j*ctx.pi*x)
    def expjpi(ctx, x):
        a = mathdp.DecCplx(0,1)
        #print("a:", a)
        b = ctx.pi*x
        #print("b:", b)
        res = ctx.exp(a*b)
        #print("res:", res)
        return res

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

    def _get_prec(ctx): return ctx.dps_to_prec(dec.prec)
    def _set_prec(ctx, p): dec.prec = int(ctx.prec_to_dps(p))
    def _get_dps(ctx): return dec.prec
    def _set_dps(ctx, p): dec.prec = int(p)

    prec = property(_get_prec, _set_prec)
    dps = property(_get_dps, _set_dps)

    # Called by SpecialFunctions.__init__()

    @classmethod
    def _wrap_specfun(cls, name, f, wrap):
        # if name=='conj':
        #print("NAME: ", name)
        #f = cls.conj2
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
        if isinstance(x, (D, DC)):
            return mathdp.is_nan(x)
        if isinstance(x, int_types) or isinstance(x, rational.mpq):
            return False
        x = ctx.convert(x)
        if isinstance(x, (D, DC)):
            return mathdp.is_nan(x)

    def is_special(ctx, x):
        return not(ctx.isnormal(x))

    def isnormal(ctx, x):
        return mathdp.is_normal(x)

    def _is_real_type(ctx, x):
        if isinstance(x, DC) or (type(x) is complex):
            return False
        return True

    def _is_complex_type(ctx, x):
        if isinstance(x, DC) or (type(x) is complex):
            return True
        return False

    def iszero(ctx, x):
        return mathdp.is_zero(x)

    def isinf(ctx, x):
        if isinstance(x, (D, DC)):
            return mathdp.is_inf(x)
        if isinstance(x, int_types) or isinstance(x, rational.mpq):
            return False
        x = ctx.convert(x)
        if isinstance(x, (D, DC)):
            return mathdp.is_inf(x)

    def isfinite(ctx, x):
        if ctx.isinf(x) or ctx.isnan(x):
            return False
        return True

    def isint(ctx, z):
        z = ctx.convert(z)
        if z.imag != 0:
            return False
        return mathdp.is_integer(z.real)

    def isnpint(ctx, z):
        z = ctx.convert(z)
        if z.imag:
            return False
        return z.real <= 0.0 and mathdp.is_integer(z.real)

#    def fraction(ctx, p, q):
#        return ctx.constant(lambda: mathdp.get_from_rational(p, q), '%s/%s' % (p, q))

    def fraction(ctx, p, q):
        p = ctx.convert(p)
        q = ctx.convert(q)
        return p/q

    def nint_distance(ctx, z):
        n = round(z.real)
        if n == z:
            return n, ctx.ninf
        return n, ctx.mag(abs(z-n))

    def convert(ctx, x):
        return mathdp.t(x)

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
        z = mathdp.t(z)
        s = f.format(z)
        return s

    def nstr(ctx, x, n=6, **kwargs):
        if isinstance(x, list):
            return "[%s]" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, tuple):
            return "(%s)" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, D):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, DC):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, str):
            return repr(x)
        if isinstance(x, ctx.matrix):
            return x.__nstr__(n, **kwargs)
        return str(x)


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
        dps = ctx.prec_to_dps(prec)  # for prec==0, dps==1
        #print("dps: ", dps)

        rnd = ROUND_HALF_EVEN  # rounding == 'n'
        if rounding == 'f':
            rnd = ROUND_DOWN
        elif rounding == 'c':
            rnd = ROUND_UP
        elif rounding == 'd':
            rnd = ROUND_FLOOR
        elif rounding == 'u':
            rnd = ROUND_CEILING

        x = ctx.convert(x)
        y = ctx.convert(y)

        #print("prec: ", prec)
        #print("rounding: ", rounding)
        # n: nearest; ROUND_HALF_EVEN; Round to nearest with ties going to nearest even integer.
        # f: floor; ROUND_DOWN;  Round towards zero.
        # c: ceiling; ROUND_UP;  Round away from zero.
        # d: down; ROUND_FLOOR; Round towards -Infinity.
        # u: up; ROUND_CEILING; Round towards Infinity.

        if prec == 0:
            s, d, e = x.as_tuple()
            xdigits = len(d)
            s, d, e = y.as_tuple()
            ydigits = len(d)
            digitsmin = min(xdigits, ydigits)
            #print("digitsmin: ", digitsmin)
            magprec = abs(x.adjusted()-y.adjusted())
            #print("magprec: ", magprec)
            dps = magprec + digitsmin
            #print("dps: ", dps)

        try:
            with localcontext(dec) as dctx:
                dctx.prec = dps
                dctx.rounding = rnd
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
        dps = ctx.prec_to_dps(prec)  # for prec==0, dps==1
        print("dps: ", dps)

        rnd = ROUND_HALF_EVEN  # rounding == 'n'
        if rounding == 'f':
            rnd = ROUND_DOWN
        elif rounding == 'c':
            rnd = ROUND_UP
        elif rounding == 'd':
            rnd = ROUND_FLOOR
        elif rounding == 'u':
            rnd = ROUND_CEILING

        x = ctx.convert(x)
        y = ctx.convert(y)

        if prec == 0:
            s, d, e = x.as_tuple()
            xdigits = len(d)
            s, d, e = y.as_tuple()
            ydigits = len(d)
            dps = xdigits + ydigits
            print("dps: ", dps)

        try:
            with localcontext(dec) as dctx:
                dctx.prec = dps
                dctx.rounding = rnd
                res = x * y
                return res
        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fneg(ctx, x, **kwargs):
        return ctx.fmul(x, -1,  **kwargs)

    def fdiv(ctx, x, y, **kwargs):
        prec, rounding = ctx._parse_prec(kwargs)
        dps = ctx.prec_to_dps(prec)  # for prec==0, dps==1
        print("dps: ", dps)

        rnd = ROUND_HALF_EVEN  # rounding == 'n'
        if rounding == 'f':
            rnd = ROUND_DOWN
        elif rounding == 'c':
            rnd = ROUND_UP
        elif rounding == 'd':
            rnd = ROUND_FLOOR
        elif rounding == 'u':
            rnd = ROUND_CEILING

        x = ctx.convert(x)
        y = ctx.convert(y)

        if prec == 0:
            raise ValueError("division is not an exact operation")

        try:
            with localcontext(dec) as dctx:
                dctx.prec = dps
                dctx.rounding = rnd
                res = x / y
                return res
        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fmod(ctx, x, y):
        return ctx.convert(x) % ctx.convert(y)

    def fsum(ctx, args, absolute=False, squared=False):
        data = []
        for x in args:
            x = ctx.convert(x)
            data.append(x)
        if absolute:
            if squared:
                return sum((abs(x)*abs(x) for x in data), ctx.zero)
            return sum((abs(x) for x in data), ctx.zero)
        if squared:
            return sum((x*x for x in data), ctx.zero)
        return sum(data, ctx.zero)

    def fdot(ctx, xs, ys=None, conjugate=False):
        if ys is not None:
            xs = zip(xs, ys)
        data = []
        for a, b in xs:
            a = ctx.convert(a)
            b = ctx.convert(b)
            #print([a, b])
            data.append((a, b))
        # print(data)
        if conjugate:
            cf = ctx.conj
            # return sum((x*cf(y) for (x,y) in xs), ctx.zero)
            return sum((x*cf(y) for (x, y) in data), ctx.zero)
        else:
            # return sum((x*y for (x,y) in xs), ctx.zero)
            return sum((x*y for (x, y) in data), ctx.zero)

    def fprod(ctx, args):
        prod = ctx.one
        for arg in args:
            prod *= ctx.convert(arg)
        return prod

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
        return mathdp.t(random.random())

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
