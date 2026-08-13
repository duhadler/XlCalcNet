

from xlcalcnet import mathstr
from fractions import Fraction as Q
import string


def t(x):
    if isinstance(x, Q):
        return x
    if (str(type(x)) == "<class 'xlcalcnet.ctx_qp.constant'>"):
        return 1 * x
    elif isinstance(x, (float, int)):
        return Q(str(x))
#        elif isinstance(x, mp.mpf):
#            return Q(str(x))
    elif isinstance(x, str):
        x, y1 = scancomplexstring(x)
        if y1 is None and y is None:
            return Q(x)
        if y1 is not None and y is None:
            y = y1
    raise TypeError



# Constants



def is_nan(z):
    return False


def is_zero(z):
    z = t(z)
    return z.is_zero()


def is_inf(z):
    return False


def is_normal(z):
    z = t(z)
    return z.is_normal()


def is_integer(x):
    x = t(x)
    if is_zero(x):
        return True
    if not is_normal(x):
        return False
    d = x - int(x)
    return d.is_zero()


# Basic functions


def get_conj(z):
    z = t(z)
    return +z


def get_sign(z):
    z = t(z)
    if z == 0:
        return t(0)
    if z < 0:
        return t(-1)
    else:
        return t(+1)


def get_fabs(z):
    z = t(z)
    if z < 0:
        return -z
    else:
        return +z





def get_from_rational(p, q):
    p = t(p)
    q = t(q)
    return p/q


def get_real_frac(z):
    z = t(z)
    return z - get_real_floor(z)


def get_frac(z):
    z = t(z)
    return get_real_frac(z)


def get_real_nint(z):
    #res = (z + t('0.5')).to_integral_value(rounding=ROUND_FLOOR)
    res = get_floor(z + t('0.5'))
    if (get_real_frac(z) == t('1/2')) and (get_real_floor(z) % 2 == 0):
        res = res - 1
    return res


def get_nint(z):
    z = t(z)
    return get_real_nint(z)


def get_real_floor(z):
    z = t(z)
    return Fraction(math.floor(x))


def get_floor(z):
    z = t(z)
    return get_real_floor(z)


def get_real_ceil(z):
    z = t(z)
    return Fraction(math.ceil(x))


def get_ceil(z):
    z = t(z)
    return get_real_ceil(z)


def get_ldexp(z, n):
    z = t(z)
    n = int(n)
    return z * Q(2)**n


##def get_frexp(z):
##    z = t(z)
##    res, n = mathstr.str_frexp(dec.prec, str(z))
##    return Q(res), n

