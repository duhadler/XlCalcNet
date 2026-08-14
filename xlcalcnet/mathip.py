

from xlcalcnet import mathstr


from xlcalcnet.mpmath import mp, iv, mpi

def convert(x, y=None):
    return mathstr.t_ivm(x, y)


def t(x, y=None):
    return mathstr.t_ivm(x, y)



def s(z, n=6):
    return mathstr.s_ivm(z, n)


def show(items, aligned=True):
    mathstr.show(items, aligned)


def name():
    return "ivm2"



# Constants


def get_apery():
    s = str(mp.apery())
    return mpi(s)


def get_degree():
    s = str(mp.degree())
    return mpi(s)


def get_mertens():
    s = str(mp.mertens())
    return mpi(s)


# Basic functions


def get_conj(z):
    z = t(z)
    return iv.mpc(z.real, -z.imag)


def get_from_rational(p, q):
    p = t(p)
    q = t(q)
    return p/q


def get_frac(z):
    z = t(z)
    return


def get_nint(z):
    z = t(z)
    return


def get_floor(z):
    z = t(z)
    t2 = mp.floor(mp.mpf(z.a))
    return iv.mpf(t2)


def get_ceil(z):
    z = t(z)
    t2 = mp.ceil(mp.mpf(z.b))
    return iv.mpf(t2)


def get_ldexp(z, n):
    n = int(n)
    z = t(z)
    p = 2**n
    return z * p


def get_frexp(z):
    z = t(z)
    y, n = mp.frexp(mp.mpf(z.mid))
    return mpi(y, n)


# Transzendental functions


def get_cos(z):
    z = t(z)
    return iv.cos(z)


def get_sin(z):
    z = t(z)
    return iv.sin(z)


def get_tan(z):
    z = t(z)
    return iv.sin(z)/iv.cos(z)


def get_acos(z):
    z = t(z)
    res = 0.5 * mp.pi() + 1j * iv.ln(1j * z + get_sqrt(1 - z*z))
    if isinstance(z, iv.mpf):
        if z in iv.mpf([-1, 1]):
            res = iv.re(res)
    return res


def get_asin(z):
    z = t(z)
    res = -1j * iv.ln(1j * z + get_sqrt(1 - z*z))
    if isinstance(z, iv.mpf):
        if z in iv.mpf([-1, 1]):
            res = iv.re(res)
    return res


def get_atan(z):
    z = t(z)
    res = 0.5j * (iv.ln(1 - 1j * z) - iv.ln(1 + 1j * z))
    if isinstance(z, iv.mpf):
        res = iv.re(res)
    return res


def get_atan2(x, y):
    x = t(x)
    y = t(y)
    return iv.atan2(x, y)


def get_cosh(z):
    z = t(z)
    res = iv.cos(1j * z)
    if isinstance(z, iv.mpf):
        res = iv.re(res)
    return res


def get_sinh(z):
    z = t(z)
    res = -1j * iv.sin(1j * z)
    if isinstance(z, iv.mpf):
        res = iv.re(res)
    return res


def get_tanh(z):
    z = t(z)
    res = -1j * get_tan(1j * z)
    if isinstance(z, iv.mpf):
        res = iv.re(res)
    return res


def get_acosh(z):
    z = t(z)
    res = iv.ln(z + get_sqrt(z+1) * get_sqrt(z-1))
    if isinstance(z, iv.mpf):
        if z in iv.mpf([+1, +mp.inf]):
            res = iv.re(res)
    return res


def get_asinh(z):
    z = t(z)
    res = get_asin(1j * z) / (1j)
    if isinstance(z, iv.mpf):
        res = iv.re(res)
    return res


def get_atanh(z):
    z = t(z)
    res = get_atan(1j * z) / (1j)
    if isinstance(z, iv.mpf):
        if z in iv.mpf([-1, +1]):
            res = iv.re(res)
    return res


def get_exp(z):
    z = t(z)
    return iv.exp(z)


def get_ln(z):
    z = t(z)
    return iv.ln(z)


def get_sqrt(z):
    z = t(z)
    if isinstance(z, iv.mpf):
        return iv.sqrt(z)
    else:
        return iv.power(z, 0.5)


def get_cbrt(z):
    z = t(z)
    d = 1/mpi('3.0', '3.0')
    return iv.power(z, d)


# Special functions


def get_nthroot(z, n):
    z = t(z)
    n = int(n)
    return z**(t(1)/n)


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
    return
#    if isinstance(z, D): return #_cospi_real(z)
#    else: return #_cospi_complex(z)


def get_sinpi(z):
    z = t(z)
    return
#    if isinstance(z, D): return #_sinpi_real(z)
#    else: return #_sinpi_complex(z)


def get_gamma(z):
    z = t(z)
    return iv.gamma(z)


def get_rgamma(z):
    z = t(z)
    return 1/iv.gamma(z)


def get_factorial(z):
    z = t(z)
    return iv.gamma(z+1)


def get_loggamma(z):
    z = t(z)
    return iv.loggamma(z)


