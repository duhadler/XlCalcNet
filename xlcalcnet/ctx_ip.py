

from xlcalcnet import mathip

from xlcalcnet.mpmath.ctx_base import StandardBaseContext
from xlcalcnet.mpmath import function_docs #, mp as _mp #, rational
from xlcalcnet.mpmath import libmp
from xlcalcnet.mpmath import iv, mp as _mp



class IPContext(StandardBaseContext):

    def __init__(ctx):
        StandardBaseContext.__init__(ctx)

        ctx.dps = 15
        ctx.pretty = True
        ctx.types = [ctx.mpf, ctx.mpc]
        ctx.init_builtins()
        ctx._init_aliases()
        ctx._prec_rounding = [53, None]


    def init_builtins(ctx):

        # Exact constants
        ctx.zero = iv.zero
        ctx.one = iv.one
        ctx.j = iv.j
        ctx.inf = iv.inf
        ctx.ninf = iv.ninf
        ctx.nan = iv.nan

        # Approximate constants
        ctx.eps = iv.eps
        ctx.pi = iv.pi
        ctx.ln2 = iv.ln2
        ctx.ln10 = iv.ln10
        ctx.phi = iv.phi
        ctx.e = iv.e
        ctx.euler = iv.euler
        ctx.catalan = iv.catalan
        ctx.apery = mathip.get_apery
        ctx.degree = mathip.get_degree

        ctx.khinchin = iv.khinchin
        ctx.glaisher = iv.glaisher
        ctx.twinprime = iv.twinprime
        ctx.mertens = mathip.get_mertens

        # Elementary Functions
        ctx.re = iv.re
        ctx.im = iv.im

        ctx.conj = mathip.get_conj

        ctx.frac = mathip.get_frac
        ctx.nint = mathip.get_nint
        ctx.floor = mathip.get_floor
        ctx.ceil = mathip.get_ceil
        ctx.ldexp = iv.ldexp
        ctx.frexp = mathip.get_frexp

        #ctx.agm = mathip.get_agm

        ctx.cos = mathip.get_cos
        ctx.sin = mathip.get_sin
        ctx.cospi = mathip.get_cospi
        ctx.sinpi = mathip.get_sinpi
        ctx.tan = mathip.get_tan
        ctx.acos = mathip.get_acos
        ctx.asin = mathip.get_asin
        ctx.atan = mathip.get_atan
        ctx.atan2 = mathip.get_atan2
        ctx.cosh = mathip.get_cosh
        ctx.sinh = mathip.get_sinh
        ctx.tanh = mathip.get_tanh
        ctx.acosh = mathip.get_acosh
        ctx.asinh = mathip.get_asinh
        ctx.atanh = mathip.get_atanh

        ctx.exp = mathip.get_exp
        ctx.ln = mathip.get_ln
        ctx.sqrt = mathip.get_sqrt
        ctx.cbrt = mathip.get_cbrt
        ctx._nthroot = mathip.get_nthroot

        ctx.gamma = mathip.get_gamma
        ctx.rgamma = mathip.get_rgamma
        ctx.fac = ctx.factorial = mathip.get_factorial
        ctx.loggamma = mathip.get_loggamma

        # Optional Functions (speedups)
#        ctxarg = staticmethod(mathip.phase)
#        ctx.fmod = staticmethod(mathip.fmod)



# change DH #
    def ismpf(self, z):
        return isinstance(z, iv.mpf)

    def ismpc(self, z):
        return isinstance(z, iv.mpc)


    def expj(ctx, x): return ctx.exp(ctx.j*x)

    def expjpi(ctx, x): return ctx.exp(ctx.j*ctx.pi*x)

    mpf = iv.mpf
    mpc = iv.mpc
    def _mpq(cls, x): return mathip.t(x[0])/x[1]
    #_mpq = lambda cls, x: iv.mpf(x[0]) / iv.mpf(x[1])

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

    def _get_prec(ctx): return iv.prec
    def _set_prec(ctx, p): iv.prec = int(p)
    def _get_dps(ctx): return iv.dps
    def _set_dps(ctx, p): iv.dps = int(p)

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
        #print("x:", x)
        if iv._is_complex_type(x):
            return iv.isnan(x.real) or iv.isnan(x.imag)
        return iv.isnan(x)


    def _is_real_type(ctx, x):
        return iv._is_real_type(x)

    def _is_complex_type(ctx, x):
        return iv._is_complex_type(x)

    def iszero(ctx, x):
        return x == 0

    def isinf(ctx, x):
        if iv._is_complex_type(x):
            return  (iv.isinf(x.real) or iv.isinf(x.imag))
        #print("x:", x)
        return iv.isinf(x) or iv.isinf(-x)

    def isfinite(ctx, x):
        if ctx.isinf(x) or ctx.isnan(x):
            return False
        return True


    def isnormal(ctx, x):
        if ctx.iszero(x) or ctx.isinf(x) or ctx.isnan(x):
            return False
        return True


    def frexp(ctx, x):
        temp = _mp.mpf(x.mid)
        res = _mp.frexp(temp)
        return ctx.mpf(res)

    def mag(ctx, x):
        #rtemp = abs(x)
        #print("rtemp:", rtemp)
        temp = _mp.mpf((abs(x)).mid)
        res = _mp.mag(temp)
        return ctx.mpf(res)


    def nint_distance(ctx, x):
        temp = _mp.mpf(x.mid)
        n, d = _mp.nint_distance(temp)
        return n, ctx.mpf(d)


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
        return ctx.constant(lambda: mathip.get_from_rational(p, q), '%s/%s' % (p, q))
        # return ctx.constant(lambda prec, rnd: mathip.get_from_rational(p,q), '%s/%s' % (p, q))
        # return ctx.constant(lambda prec, rnd: from_rational(p, q, prec, rnd), '%s/%s' % (p, q))

#    def nint_distance(ctx, z):
#        n = round(z.real)
#        if n == z:
#            return n, ctx.ninf
#        return n, ctx.mag(abs(z-n))


#    def nint_distance(ctx, z):
#        if hasattr(z, "imag"):   # float/int don't have .real/.imag in py2.5
#            n = round(z.real)
#        else:
#            n = round(z)
#        if n == z:
#            return n, ctx.ninf
#        return n, ctx.mag(abs(z-n))

    def convert(ctx, x):
        return mathip.t(x)


    def convert2(ctx, x, y=None):
        return mathip.t(x, y)



    def _convert_param(ctx, z):
        if type(z) is tuple:
            p, q = z
            return ctx.mpf(p) / q, 'R'
        intz = int(z.real)
        if z == intz:
            return intz, 'Z'
        return z, 'R'



    def _nstr(ctx, z, n=6, **kwargs):
        z = ctx.convert(z)
        s = mathip.s(z, n)
        return s

    def nstr(ctx, x, n=6, **kwargs):
        if isinstance(x, list):
            return "[%s]" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, tuple):
            return "(%s)" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if ctx.ismpf(x):
            return ctx._nstr(x, n, **kwargs)
        if ctx.ismpc(x):
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
        print("dps: ", dps)

        x = ctx.convert(x)
        y = ctx.convert(y)

        #print("prec: ", prec)
        #print("rounding: ", rounding)

        if prec == 0:
            print("Exact: still needs proper implementation")
            dps=100
        try:
            olddps = ctx.dps
            ctx.dps = dps
            res = x + y
            ctx.dps = olddps
            return res
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
#            with localcontext(dec) as dctx:
#                dctx.prec = dps
#                dctx.rounding = rnd
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

        x = ctx.convert(x)
        y = ctx.convert(y)

        if prec == 0:
            raise ValueError("division is not an exact operation")

        try:
#            with localcontext(dec) as dctx:
#                dctx.prec = dps
#                dctx.rounding = rnd
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
            return sum((x*cf(y) for (x, y) in data), ctx.zero)
        else:
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
        s = t = 1.0
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
        return iv.mpf(random.random())



# change DH #


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







