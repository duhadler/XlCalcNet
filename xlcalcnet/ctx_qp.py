

from fractions import Fraction as Q
from xlcalcnet import mathqp

from xlcalcnet.mpmath.ctx_base import StandardBaseContext
from xlcalcnet.mpmath import libmp

class _constant():

    def __new__(cls, func, name='', docname=''):
        a = object.__new__(cls)
        a.func = func
        return a

# we provide our own operator overloading
    def __call__(self): return self.func()
    def __pos__(self): return self.func()
    def __neg__(self): return -self.func()
    def __add__(self, b): return self.func() + mathqp.t(b)
    def __radd__(self, b): return self.func() + mathqp.t(b)
    def __iadd__(self, b): return self.func() + mathqp.t(b)
    def __sub__(self, b): return self.func() - mathqp.t(b)
    def __rsub__(self, b): return mathqp.t(b) - self.func()
    def __isub__(self, b): return self.func() - mathqp.t(b)
    def __mul__(self, b): return self.func() * mathqp.t(b)
    def __rmul__(self, b): return self.func() * mathqp.t(b)
    def __imul__(self, b): return self.func() * mathqp.t(b)
    def __div__(self, b): return self.func() / mathqp.t(b)
    def __rdiv__(self, b): return mathqp.t(b) / self.func()
    def __idiv__(self, b): return self.func() / mathqp.t(b)
    def __truediv__(self, b): return self.func() / mathqp.t(b)
    def __rtruediv__(self, b): return mathqp.t(b) / self.func()
    def __itruediv__(self, b): return self.func() / mathqp.t(b)
    def __pow__(self, b): return self.func() ** mathqp.t(b)
    def __rpow__(self, b): return mathqp.t(b) ** self.func()
    def __ipow__(self, b): return self.func() ** mathqp.t(b)
    def __eq__(self, b): return self.func() == mathqp.t(b)
    def __ne__(self, b): return self.func() != mathqp.t(b)
    def __le__(self, b): return self.func() <= mathqp.t(b)
    def __lt__(self, b): return self.func() < mathqp.t(b)
    def __ge__(self, b): return self.func() >= mathqp.t(b)
    def __gt__(self, b): return self.func() > mathqp.t(b)
    def __str__(self): return str(+self.func())


class QPContext(StandardBaseContext):

    def __init__(ctx):
        StandardBaseContext.__init__(ctx)

        ctx.dps = 15
        ctx.pretty = True
        ctx.constant = type('constant', (_constant,), {})
        ctx.types = [ctx.mpf, ctx.constant]
        ctx.init_builtins()
        ctx._init_aliases()


    def init_builtins(ctx):

        # Exact constants
        ctx.zero = Q(0)
        ctx.one = Q(1)
##        ctx.j = mathqp.t(0, 1)
##        ctx.inf = Q('1/0')
##        ctx.ninf = -Q('1/0')
##        ctx.nan = Q('0/0')


        # Elementary Functions
        ctx.conj = mathqp.get_conj

        ctx.sign = mathqp.get_sign
        ctx.fabs = mathqp.get_fabs

        ctx.frac = mathqp.get_frac
        ctx.nint = mathqp.get_nint
        ctx.floor = mathqp.get_floor
        ctx.ceil = mathqp.get_ceil
        ctx.ldexp = mathqp.get_ldexp


    def ismpf(self, z):
        return isinstance(z, Q)

    def ismpc(self, z):
        return False


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
        if isinstance(z, Q):
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

    mpf = Q
    #mpc = mathqp.QCplx
    def _mpq(cls, x): return Q(x[0])/x[1]

    NoConvergence = libmp.NoConvergence
    _fixed_precision = False
    absmin = absmax = abs



    def isnan(ctx, x):
        return False

    def is_special(ctx, x):
        return not(ctx.isnormal(x))

    def isnormal(ctx, x):
        return mathqp.is_normal(x)

    def _is_real_type(ctx, x):
        return True

    def _is_complex_type(ctx, x):
        return False

    def iszero(ctx, x):
        return mathqp.is_zero(x)

    def isinf(ctx, x):
        return False

    def isfinite(ctx, x):
        return True

    def isint(ctx, z):
        z = ctx.convert(z)
        return mathqp.is_integer(z.real)

    def isnpint(ctx, z):
        z = ctx.convert(z)
        return z.real <= 0.0 and mathqp.is_integer(z.real)

#    def fraction(ctx, p, q):
#        return ctx.constant(lambda: mathqp.get_from_rational(p, q), '%s/%s' % (p, q))

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
        return mathqp.t(x)

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
        z = mathqp.t(z)
        s = f.format(z)
        return s

    def nstr(ctx, x, n=6, **kwargs):
        if isinstance(x, list):
            return "[%s]" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, tuple):
            return "(%s)" % (", ".join(ctx.nstr(c, n, **kwargs) for c in x))
        if isinstance(x, Q):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, QC):
            return ctx._nstr(x, n, **kwargs)
        if isinstance(x, str):
            return repr(x)
        if isinstance(x, ctx.matrix):
            return x.__nstr__(n, **kwargs)
        return str(x)



    def fadd(ctx, x, y, **kwargs):
        x = ctx.convert(x)
        y = ctx.convert(y)
        try:
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
        x = ctx.convert(x)
        y = ctx.convert(y)
        try:
            res = x * y
            return res
        except (ValueError, OverflowError):
            raise OverflowError("the exact result does not fit in memory")
        raise ValueError("Arguments need to be mpf or mpc compatible numbers")

    def fneg(ctx, x, **kwargs):
        return ctx.fmul(x, -1,  **kwargs)

    def fdiv(ctx, x, y, **kwargs):
        x = ctx.convert(x)
        y = ctx.convert(y)
        try:
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
