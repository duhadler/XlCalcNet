


from xlcalcnet.mpmath.ctx_base import StandardBaseContext
from xlcalcnet.mpmath import function_docs
from xlcalcnet.mpmath import libmp

from xlcalcnet import mathap
import flint
from flint import arb, acb




class APContext(StandardBaseContext):

    def __init__(ctx):
        StandardBaseContext.__init__(ctx)

        #ctx.dps = 15
        ctx.pretty = True
        ctx.types = [ctx.mpf, ctx.mpc]
        ctx.init_builtins()
        ctx._init_aliases()
        ctx._prec_rounding = [53, None]


    def init_builtins(ctx):

        # Exact constants
        ctx.zero = arb(0)
        ctx.one = arb(1)
        ctx.j = acb(1j)
        ctx.inf = arb.pos_inf()
        ctx.ninf = arb.neg_inf()
        ctx.nan = arb.nan()



        # Elementary Functions
        # (this function is broken in gmpy2.version 2.08)
        ctx.conj = mathap.get_conj

        ctx.ldexp = mathap.get_ldexp
        ctx.frexp = mathap.get_frexp



    def ismpf(ctx, x):
        return isinstance(x, arb)

    def ismpc(ctx, x):
        return isinstance(x, acb)



    def mag(ctx, z):
        if z:
            return ctx.frexp(abs(z))[1]
        return ctx.ninf

    def expj(ctx, x): return ctx.exp(ctx.j*x)

    def expjpi(ctx, x): return ctx.exp(ctx.j*ctx.pi*x)

    mpf = arb
    mpc = acb
    def _mpq(cls, x): return mathap.convert(x[0])/x[1]

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


    def _get_prec(ctx): return flint.ctx.prec
    def _set_prec(ctx, p): flint.ctx.prec = int(p)
    def _get_dps(ctx): return flint.ctx.dps
    def _set_dps(ctx, p): flint.ctx.dps = int(p)

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
        z = ctx.convert(x)
        return arb(z.real).is_nan() or arb(z.imag).is_nan()


    def is_special(ctx, x):
        return (ctx.isinf(x) or ctx.isnan(x))

    def isnormal(ctx, x):
        return not(ctx.is_special(x) or ctx.iszero(x))

    def _is_real_type(ctx, x):
        z = ctx.convert(x)
        return isinstance(z, arb)

    def _is_complex_type(ctx, x):
        z = ctx.convert(x)
        return isinstance(z, acb)

    def iszero(ctx, x):
        return (x == 0)

    def isinf(ctx, x):
        z = ctx.convert(x)
        return z.Real.IsInfinite() or z.Imag.IsInfinite()

    def isfinite(ctx, x):
        if ctx.isinf(x) or ctx.isnan(x):
            return False
        return True

    def isint(ctx, z):
        z = ctx.convert(z)
        return z.Real.IsInteger() and (z.Imag.IsZero())

    def isnpint(ctx, z):
        z = ctx.convert(z)
        return z.Real <= 0.0 and ctx.isint(z)


    def get_from_rational(ctx, p, q):
        p = ctx.t(p)
        q = ctx.t(q)
        return p/q

    def fraction(ctx, p, q):
        return ctx.constant(lambda: ctx.get_from_rational(p, q), '%s/%s' % (p, q))
        # return ctx.constant(lambda prec, rnd: mathip.get_from_rational(p,q), '%s/%s' % (p, q))
        # return ctx.constant(lambda prec, rnd: from_rational(p, q, prec, rnd), '%s/%s' % (p, q))

    def nint_distance(ctx, z):
        n = round(z.real)
        if n == z:
            return n, ctx.ninf
        return n, ctx.mag(abs(z-n))


    def convert(ctx, x):
        #print("x:", x)
        return mathap.t(x)



    def _convert_param(ctx, z):
        if type(z) is tuple:
            p, q = z
            return ctx.mpf(p) / q, 'R'
        intz = int(z.real)
        if z == intz:
            return intz, 'Z'
        return z, 'R'

#    def nstr(ctx, z, n=6, **kwargs):
#        print("dps:", ctx.dps)
#        print("z:", z)
#        f = "{0:." + str(n-1) + "E}"
#        #f = str(n-1)
#        print(f)
#        z = ctx.convert(z)
#        s = f.format(z)
#        return s

    def _nstr(ctx, z, n=6, **kwargs):
        #print("dps:", ctx.dps)
        #print("z:", z)
        f = "{0:." + str(n-1) + "E}"
        #f = str(n-1)
        #print(f)
        z = ctx.convert(z)
        s = f.format(z)
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
                #print("prec: ", prec, ctx.isinf(prec))
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

        x = ctx.convert(x)
        y = ctx.convert(y)

        #print("prec: ", prec)

        if prec == 0:
            print("Exact: still needs proper implementation")
            dps=100
#            s, d, e = x.as_tuple()
#            xdigits = len(d)
#            s, d, e = y.as_tuple()
#            ydigits = len(d)
#            digitsmin = min(xdigits, ydigits)
#            print("digitsmin: ", digitsmin)
#            magprec = abs(x.adjusted()-y.adjusted())
#            print("magprec: ", magprec)
#            dps = magprec + digitsmin
#            print("dps: ", dps)

        try:
            olddps = ctx.dps
            ctx.dps = dps
            res = x + y
            ctx.dps = olddps
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
            print("Exact: still needs proper implementation")
            dps=100
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
        return arb(random.random())

    def extrarbec(ctx, n, normalize_output=False):
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






