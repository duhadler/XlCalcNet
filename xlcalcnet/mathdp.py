

from xlcalcnet import mathstr

from decimal import ROUND_FLOOR, ROUND_CEILING,  Decimal as D, getcontext as dec_context


import string

dec = dec_context()


def get_dec():
    return dec


def scancomplexstring(s):
    s = ''.join(s.split())
    pos = 0
    for i in range(1, len(s)-1):
        if s[i] in ['+', '-']:
            if s[i-1] in string.digits:
                if s[i+1] in string.digits:
                    pos = i
                    break
    if (pos == 0):
        x = s
        y = None
    else:
        if s[-1] not in ['j', 'J']:
            raise Exception("Malformed string: expected 'j' or 'J' at the end")
        else:
            x = s[:pos]
            y = s[pos:-1]
    return x, y


def t(x=None, y=None):
    if y is None:
        #        print("in mathdp.t; y is None")
        #        print("y: ", y)
        if isinstance(x, D):
            return x
        if (str(type(x)) == "<class 'xlcalcnet.ctx_dp.constant'>"):
            return 1 * x
        elif (str(type(x)) == "<class 'xlcalcnet.mathdp.DecCplx'>"):
            return x
        elif isinstance(x, (float, int)):
            return D(str(x))
        elif isinstance(x, complex):
            y = x.imag
            x = x.real
#        elif isinstance(x, mp.mpf):
#            return D(str(x))
#        elif isinstance(x, mp.mpc):
#            y = D(str(mp.im(x)))
#            x = D(str(mp.re(x)))
#            return DecCplx(x, y)
        elif isinstance(x, str):
            x, y1 = scancomplexstring(x)
            if y1 is None and y is None:
                return D(x)
            if y1 is not None and y is None:
                y = y1
    if y is not None:
        #        print("in mathdp.t; x ,y")
        return DecCplx(x, y)
    raise TypeError



# Complex Decimal Class

class DecCplx():

    __real = D(0)
    __imag = D(0)

    @property
    def real(self):
        return self.__real

    @real.setter
    def real(self, value):
        self.__real = value

    @property
    def imag(self):
        return self.__imag

    @imag.setter
    def imag(self, value):
        self.__imag = value

    def __init__(self, x=None, y=None):
        if (x is not None):
            if isinstance(x, D):
                self.__real = x
            elif isinstance(x, (DecCplx, complex, float, int)):
                self.__real = D(x.real)
                self.__imag = D(x.imag)
            elif isinstance(x, str):
                x, y1 = scancomplexstring(x)
                if y1 is not None and y is None:
                    y = y1
                self.__real = D(x)
            else:
                self.__real = D(str(x))
        if (y is not None):
            if isinstance(y, D):
                self.__imag = y
            elif isinstance(y, str):
                self.__imag = D(y)
            else:
                self.__imag = D(str(y))

    def __bool__(self):
        return (self != 0)

    def __complex__(self):
        return complex(float(self.real), float(self.imag))

    def __str__(self):
        sx = str(self.__real)
        sy = str(self.__imag)
        p = " + "
        if sy[0] == '-':
            p = " - "
            sy = sy[1:]
        return "" + sx + p + sy + "j"

    def __repr__(self):
        return "DecCplx('" + str(self) + "')"

    def __pos__(self):
        res = DecCplx(0, 0)
        res.__real = self.__real
        res.__imag = self.__imag
        return res

    def __neg__(self):
        res = DecCplx(0, 0)
        res.__real = -self.__real
        res.__imag = -self.__imag
        return res

    def __abs__(self):
        return D(self.__real*self.__real + self.__imag*self.__imag).sqrt()

    def conjugate(self):
        res = DecCplx(0, 0)
        res.__real = self.__real
        res.__imag = -self.__imag
        return res


    def __add__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        res = DecCplx(0, 0)
        b = t(b)
        if isinstance(b, D):
            res.__real = self.__real + b
            res.__imag = self.__imag
        else:
            res.__real = self.__real + b.__real
            res.__imag = self.__imag + b.__imag
        return res

    def __radd__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return b + self

    def __iadd__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return self + b


    def __sub__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        res = DecCplx(0, 0)
        b = t(b)
        if isinstance(b, D):
            res.__real = self.__real - b
            res.__imag = self.__imag
        else:
            res.__real = self.__real - b.__real
            res.__imag = self.__imag - b.__imag
        return res

    def __rsub__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return b - self

    def __isub__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return self - b


    def __mul__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        res = DecCplx(0, 0)
        b = t(b)
        if isinstance(b, D):
            res.__real = self.__real * b
            res.__imag = self.__imag * b
        else:
            res.__real = self.__real * b.__real - self.__imag * b.__imag
            res.__imag = (self.__real * b.__imag + self.__imag * b.__real)
        if (res.__imag == D(0)): return res.__real
        return res

    def __rmul__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return b * self

    def __imul__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return self * b


    def __truediv__(self, b):
##        print("In __truediv__")
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        res = DecCplx(0, 0)
        b = t(b)
        if isinstance(b, D):
            d = 1/(b*b)
            res.__real = d*(self.__real * b)
            res.__imag = d*(self.__imag * b)
        else:
            d = 1/(b.__real*b.__real + b.__imag*b.__imag)
            res.__real = d*( self.__real * b.__real + self.__imag * b.__imag)
            res.__imag = d*(-self.__real * b.__imag + self.__imag * b.__real)
        return res

    def __rtruediv__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return b / self

    def __itruediv__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return self / b

    def __pow__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        if isinstance(b, int):
            if b==2: return self*self
            if b==3: return self*self*self
        b = t(b)
        res1 = get_ln(self)
        res2 = res1 * b
        res = get_exp(res2)
        return res
        # TODO: identify real cases

    def __rpow__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return b**self

    def __ipow__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = DecCplx(b)
        return self**b

    def __eq__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = t(b)
        if isinstance(b, D):
            return (self.__real == b) and (self.__imag == 0)
        else:
            return (self.__real == b.__real) and (self.__imag == b.__imag)

    def __ne__(self, b):
        if (str(type(b)) == "<class 'numpy.ndarray'>"): return NotImplemented
        b = t(b)
        if isinstance(b, D):
            return (self.__real != b) or (self.__imag != 0)
        else:
            return (self.__real != b.__real) or (self.__imag != b.__imag)


# Constants


def get_eps(): return dec.next_plus(1) - 1


def get_pi(): return D(mathstr.str_pi(dec.prec))


def get_log2(): return dec.ln(2)


def get_log10(): return dec.ln(10)


def get_phi(): return (1+dec.sqrt(5)) / 2


def get_e(): return dec.exp(1)


def get_euler(): return D(mathstr.str_euler(dec.prec))


def get_catalan(): return D(mathstr.str_catalan(dec.prec))


def get_apery(): return D(mathstr.str_apery(dec.prec))


def get_degree(): return get_pi() / 180


def get_khinchin(): return D(mathstr.str_khinchin(dec.prec))


def get_glaisher(): return D(mathstr.str_glaisher(dec.prec))


def get_twinprime(): return D(mathstr.str_twinprime(dec.prec))


def get_mertens(): return D(mathstr.str_mertens(dec.prec))


def is_nan(z):
    z = t(z)
    if isinstance(z, D):
        return z.is_nan()
    return (z.real.is_nan() or z.imag.is_nan())


def is_zero(z):
    z = t(z)
    if isinstance(z, D):
        return z.is_zero()
    return (z.real.is_zero() and z.imag.is_zero())


def is_inf(z):
    z = t(z)
    if isinstance(z, D):
        return z.is_infinite()
    return (z.real.is_infinite() or z.imag.is_infinite())


def is_normal(z):
    z = t(z)
    if isinstance(z, D):
        return z.is_normal()
    return (z.real.is_normal() and z.imag.is_normal())


def is_integer(x):  # x is assumed to be of type D
    if is_zero(x):
        return True
    if not is_normal(x):
        return False
    d = x - int(x)
    return d.is_zero()


# Basic functions


def get_conj(z):
    z = t(z)
    if isinstance(z, D):
        return +z
    return DecCplx(z.real, -z.imag)


def get_sign(z):
    z = t(z)
    if z == 0:
        return t(0)
    if isinstance(z, D):
        if z < 0:
            return t(-1)
        else:
            return t(+1)
    return z / get_fabs(z)


def get_fabs(z):
    z = t(z)
    if isinstance(z, D):
        if z < 0:
            return -z
        else:
            return +z
    return get_hypot(z.real, z.imag)


def get_hypot(x, y):
    return dec.sqrt(x*x + y*y)


def get_arg(z):
    z = t(z)
    if isinstance(z, D):
        if z < 0:
            return get_pi()
        else:
            return t(0)
    return get_atan2(z.imag, z.real)


def get_from_rational(p, q):
    p = t(p)
    q = t(q)
    return p/q


def get_real_frac(z):
    z = t(z)
    return z - z.to_integral_value(rounding=ROUND_FLOOR)


def get_frac(z):
    z = t(z)
    if isinstance(z, D):
        return get_real_frac(z)
    return DecCplx(get_real_frac(z.real), get_real_frac(z.imag))


def get_real_nint(z):
    res = (z + t('0.5')).to_integral_value(rounding=ROUND_FLOOR)
    if (get_real_frac(z) == t('0.5')) and (get_real_floor(z) % 2 == 0):
        res = res - 1
    return res


def get_nint(z):
    z = t(z)
    if isinstance(z, D):
        return get_real_nint(z)
    return DecCplx(get_real_nint(z.real), get_real_nint(z.imag))


def get_real_floor(z):
    z = t(z)
    return z.to_integral_value(rounding=ROUND_FLOOR)


def get_floor(z):
    z = t(z)
    if isinstance(z, D):
        return get_real_floor(z)
    return DecCplx(get_real_floor(z.real), get_real_floor(z.imag))


def get_real_ceil(z):
    z = t(z)
    return z.to_integral_value(rounding=ROUND_CEILING)


def get_ceil(z):
    z = t(z)
    if isinstance(z, D):
        return get_real_ceil(z)
    return DecCplx(get_real_ceil(z.real), get_real_ceil(z.imag))


def get_ldexp(z, n):
    z = t(z)
    n = int(n)
    return z * D(2)**n


def get_frexp(z):
    z = t(z)
    res, n = mathstr.str_frexp(dec.prec, str(z))
    return D(res), n


# Transzendental functions


def get_powm1(a, b):
    a = t(a)
    b = t(b)
    if isinstance(a, D) and isinstance(b, D):
        return D(mathstr.str_powm1(dec.prec, str(a), str(b)))
    s_re, s_im = mathstr.str_cplx_powm1(str(a.real), str(a.imag), str(b.real), str(b.imag))
    return DecCplx(s_re, s_im)


def get_cos(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_cos(dec.prec, str(z)))
    return  # gmpy2.cos(z)


def get_sin(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_sin(dec.prec, str(z)))
    return  # gmpy2.sin(z)


def get_tan(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_tan(dec.prec, str(z)))
    return  # gmpy2.tan(z)

def get_cot(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_cot(dec.prec, str(z)))
    return  # gmpy2.tan(z)


def get_acos(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_acos(dec.prec, str(z)))
    return  # gmpy2.acos(z)


def get_asin(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_asin(dec.prec, str(z)))
    return  # gmpy2.asin(z)


def get_atan(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_atan(dec.prec, str(z)))
    return  # gmpy2.atan(z)


def get_atan2(x, y):
    x = t(x)
    y = t(y)
    return D(mathstr.str_atan2(dec.prec, str(x), str(y)))


def get_cosh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_cosh(dec.prec, str(z)))
    return  # gmpy2.cosh(z)


def get_sinh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_sinh(dec.prec, str(z)))
    return  # gmpy2.sinh(z)


def get_tanh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_tanh(dec.prec, str(z)))
    return  # gmpy2.tanh(z)


def get_acosh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_acosh(dec.prec, str(z)))
    return  # gmpy2.acosh(z) (real only)


def get_asinh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_asinh(dec.prec, str(z)))
    return  # gmpy2.asinh(z) (real only)


def get_atanh(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_atanh(dec.prec, str(z)))
    return  # gmpy2.atanh(z) (real only)


def get_exp(z):
    z = t(z)
    if isinstance(z, D):
        return dec.exp(z)
    s_re, s_im = mathstr.str_cplx_exp(str(z.real), str(z.imag))
    return DecCplx(s_re, s_im)


def get_ln(z, prec=None):
    z = t(z)
    if prec is None:
        if isinstance(z, D):
            return dec.ln(z)
        s_re, s_im = mathstr.str_cplx_ln(str(z.real), str(z.imag))
        return DecCplx(s_re, s_im)

    if isinstance(z, D):
        return dec.ln(z)
    s_re, s_im = mathstr.str_cplx_ln(str(z.real), str(z.imag))
    return DecCplx(s_re, s_im)



def get_sqrt(z):
    z = t(z)
    if isinstance(z, D):
        return dec.sqrt(z)
    s_re, s_im = mathstr.str_cplx_sqrt(str(z.real), str(z.imag))
    return DecCplx(s_re, s_im)


def get_cbrt(z):
    z = t(z)
    if isinstance(z, D) and z >= 0:
        return dec.power(z, t(1)/3)
    s_re, s_im = mathstr.str_cplx_cbrt(str(z.real), str(z.imag))
    return DecCplx(s_re, s_im)


# Special functions


def get_nthroot(z, n):
    z = t(z)
    n = int(n)
    if n == 0:
        return t(1)
    if z == 0:
        return t(0)
    if isinstance(z, D) and z > 0:
        res = dec.power(z, t(1)/abs(n))
        if n < 0:
            return 1/res
        return res
    # else: return z**(t(1)/n)


# def _sinpi_real(x):
#    if x < 0:
#        return -_sinpi_real(-x)
##    n, r = divmod(x, 0.5)
#    n, r = gmpy2.modf(t(x)*2)
#    r *= gmpy2.const_pi()
#    n %= 4
#    print("n, r: ", n, r)
#    if n == 0: return gmpy2.sin(r)
#    if n == 1: return gmpy2.cos(r)
#    if n == 2: return -gmpy2.sin(r)
#    if n == 3: return -gmpy2.cos(r)
#
# def _cospi_real(x):
#    if x < 0:
#        x = -x
##    n, r = divmod(x, 0.5)
#    n, r = gmpy2.modf(t(x)*2)
#    r *= gmpy2.const_pi()
#    n %= 4
#    print("n, r: ", n, r)
#    if n == 0: return gmpy2.cos(r)
#    if n == 1: return -gmpy2.sin(r)
#    if n == 2: return -gmpy2.cos(r)
#    if n == 3: return gmpy2.sin(r)
#
# def _sinpi_complex(z):
#    if z.real < 0:
#        return -_sinpi_complex(-z)
##    n, r = divmod(z.real, 0.5)
#    n, r = gmpy2.modf(t(z.real)*2)
#    z = gmpy2.const_pi()*gmpy2.mpc(r, z.imag)
#    n %= 4
#    if n == 0: return gmpy2.sin(z)
#    if n == 1: return gmpy2.cos(z)
#    if n == 2: return -gmpy2.sin(z)
#    if n == 3: return -gmpy2.cos(z)
#
# def _cospi_complex(z):
#    if z.real < 0:
#        z = -z
##    n, r = divmod(z.real, 0.5)
#    n, r = gmpy2.modf(t(z.real)*2)
#    z = gmpy2.const_pi()*gmpy2.mpc(r, z.imag)
#    n %= 4
#    if n == 0: return gmpy2.cos(z)
#    if n == 1: return -gmpy2.sin(z)
#    if n == 2: return -gmpy2.cos(z)
#    if n == 3: return gmpy2.sin(z)


def get_cospi(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_cospi(dec.prec, str(z)))
    s_re, s_im = mathstr.str_cplx_cospi(str(z.real), str(z.imag))
    return  DecCplx(s_re, s_im)


def get_sinpi(z):
    z = t(z)
    if isinstance(z, D):
        return  # _sinpi_real(z)
    else:
        return  # _sinpi_complex(z)


def get_gamma(z):
    z = t(z)
    if isinstance(z, D):
        return D(mathstr.str_gamma(dec.prec, str(z)))
    s_re, s_im = mathstr.str_cplx_gamma(str(z.real), str(z.imag))
    # return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_rgamma(z):
    z = t(z)
    if isinstance(z, D):
        if z.is_integer() and z <= 0:
            return t(0)
        return  # 1/gmpy2.gamma(z)
    s_re, s_im = mathstr.str_cplx_rgamma(str(z.real), str(z.imag))
    # return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_factorial(z):
    z = t(z)
    return get_gamma(z+1)



def get_bernoulli(k):
    return D(mathstr.str_bernoulli(dec.prec, k))


def get_loggamma(z):
    z = t(z)
    if isinstance(z, D):
        return  # gmpy2.lngamma(z)
    s_re, s_im = mathstr.str_cplx_loggamma(str(z.real), str(z.imag))
    # return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_agm(x, y):
    x = t(x)
    y = t(y)
    if isinstance(x, D) and isinstance(y, D):
        return  # gmpy2.agm(x, y)
    s_re, s_im = mathstr.str_cplx_agm(
        str(x.real), str(x.imag), str(y.real), str(y.imag))
    # return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))
