# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

import gmpy2
from gmpy2 import get_context as gmp_context
gmp = gmp_context()


from xlcalcnet import mathstr

def convert(x, y=None):
    return mathstr.t_gmp(x, y)

def t(x, y=None):
    return mathstr.t_gmp(x, y)

def show(items, aligned=True):
    mathstr.show(items, aligned)

def name():
    return "gmp2"

def get_gmp():
    return gmp



def get_dps(): return max(1, int(round(int(gmp.precision)/3.3219280948873626)-1))
def get_eps(): return gmpy2.next_above(gmpy2.mpfr(1)) - gmpy2.mpfr(1)
def get_log10(): return gmpy2.log(10)
def get_phi(): return 0.5*(1+gmpy2.sqrt(5))
def get_e(): return gmpy2.exp(1)
def get_apery(): return gmpy2.zeta(3)
def get_degree(): return gmpy2.const_pi() / 180
def get_khinchin(): return gmpy2.mpfr(mathstr.str_khinchin(get_dps()))
def get_glaisher(): return gmpy2.mpfr(mathstr.str_glaisher(get_dps()))
def get_twinprime(): return gmpy2.mpfr(mathstr.str_twinprime(get_dps()))
def get_mertens(): return gmpy2.mpfr(mathstr.str_mertens(get_dps()))


def get_conj(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return z
    else:
        return gmpy2.mpc(z.real, -z.imag)


def get_from_rational(p, q):
    p = t(p)
    q = t(q)
    return p/q


def get_fabs(z):
    return abs(z)


def get_sign(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.sign(z)
    if z == 0:
        return 0
    return z/abs(z)


def get_real_frac(z):
    z = t(z)
    return z - gmpy2.floor(z)


def get_frac(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return get_real_frac(z)
    else:
        return gmpy2.mpc(get_real_frac(z.real), get_real_frac(z.imag))


def get_nint(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.mpfr(round(z))
    else:
        return gmpy2.mpc(round(z.real), round(z.imag))


def get_floor(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.floor(z)
    else:
        return gmpy2.mpc(gmpy2.floor(z.real), gmpy2.floor(z.imag))


def get_ceil(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.ceil(z)
    else:
        return gmpy2.mpc(gmpy2.ceil(z.real), gmpy2.ceil(z.imag))


def get_ldexp(z, n):
    z = t(z)
    n = int(n)
    na = abs(n)
    res = gmpy2.mul_2exp(z, na)
    if n < 0:
        res = 1/res
    return res


def get_frexp(z):
    z = t(z)
    n, y = gmpy2.frexp(z)
    return y, n


def get_cos(z):
    z = t(z)
    return gmpy2.cos(z)


def get_sin(z):
    z = t(z)
    return gmpy2.sin(z)


def get_tan(z):
    z = t(z)
    return gmpy2.tan(z)


def get_acos(z):
    z = t(z)
    return gmpy2.acos(z)


def get_asin(z):
    z = t(z)
    return gmpy2.asin(z)


def get_atan(z):
    z = t(z)
    return gmpy2.atan(z)


def get_atan2(x, y):
    x = t(x)
    y = t(y)
    return gmpy2.atan2(x, y)


def get_cosh(z):
    z = t(z)
    return gmpy2.cosh(z)


def get_sinh(z):
    z = t(z)
    return gmpy2.sinh(z)


def get_tanh(z):
    z = t(z)
    return gmpy2.tanh(z)


def get_acosh(z):
    z = t(z)
    return gmpy2.acosh(z)


def get_asinh(z):
    z = t(z)
    return gmpy2.asinh(z)


def get_atanh(z):
    z = t(z)
    return gmpy2.atanh(z)


def get_exp(z):
    z = t(z)
    return gmpy2.exp(z)


def get_ln(z, prec=None):
    z = t(z)
    if prec is None:
        return gmpy2.log(z)
    oldprec = gmp.precision
    gmp.precision = int(prec)
    res = gmpy2.log(z)
    gmp.precision = oldprec
    return res


def get_sqrt(z):
    z = t(z)
    return gmpy2.sqrt(z)


def get_cbrt(z):
    z = t(z)
    if hasattr(z, '__trunc__') and z >= 0:
        return gmpy2.cbrt(z)
    else:
        return z**(t(1)/3)


def get_nthroot(z, n):
    z = t(z)
    n = int(n)
    if n == 0:
        return t(1)
    if z == 0:
        return t(0)
    if hasattr(z, '__trunc__') and z > 0:
        res = gmpy2.root(z, abs(n))
        if n < 0:
            return 1/res
        return res
    else:
        return z**(t(1)/n)


def _sinpi_real(x):
    if x < 0:
        return -_sinpi_real(-x)
    n, r = divmod(x, 0.5)
    n = int(n)
    r *= gmpy2.const_pi()
    n %= 4
    if n == 0:
        return gmpy2.sin(r)
    if n == 1:
        return gmpy2.cos(r)
    if n == 2:
        return -gmpy2.sin(r)
    if n == 3:
        return -gmpy2.cos(r)


def _cospi_real(x):
    x = t(x)
    if x < 0:
        x = -x
    n, r = divmod(x, 0.5)
    n = int(n)
    r *= gmpy2.const_pi()
    n %= 4
    #print("n, r: ", n, r)
    if n == 0:
        return gmpy2.cos(r)
    if n == 1:
        return -gmpy2.sin(r)
    if n == 2:
        return -gmpy2.cos(r)
    if n == 3:
        return gmpy2.sin(r)


def _sinpi_complex(z):
    if z.real < 0:
        return -_sinpi_complex(-z)
    n, r = divmod(z.real, 0.5)
    n = int(n)
    z = gmpy2.const_pi()*gmpy2.mpc(r, z.imag)
    n %= 4
    if n == 0:
        return gmpy2.sin(z)
    if n == 1:
        return gmpy2.cos(z)
    if n == 2:
        return -gmpy2.sin(z)
    if n == 3:
        return -gmpy2.cos(z)


def _cospi_complex(z):
    if z.real < 0:
        z = -z
    n, r = divmod(z.real, 0.5)
    n = int(n)
    z = gmpy2.const_pi()*gmpy2.mpc(r, z.imag)
    n %= 4
    if n == 0:
        return gmpy2.cos(z)
    if n == 1:
        return -gmpy2.sin(z)
    if n == 2:
        return -gmpy2.cos(z)
    if n == 3:
        return gmpy2.sin(z)


def get_cospi(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return _cospi_real(z)
    else:
        return _cospi_complex(z)


def get_sinpi(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return _sinpi_real(z)
    else:
        return _sinpi_complex(z)


def get_gamma(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.gamma(z)
    s_re, s_im = mathstr.str_cplx_gamma(str(z.real), str(z.imag))
    return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_rgamma(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        if z.is_integer() and z <= 0:
            return gmpy2.zero()
        return 1/gmpy2.gamma(z)
    s_re, s_im = mathstr.str_cplx_rgamma(str(z.real), str(z.imag))
    return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_factorial(z):
    z = t(z)
    return get_gamma(z+1.0)


def get_loggamma(z):
    z = t(z)
    if hasattr(z, '__trunc__'):
        return gmpy2.lngamma(z)
    s_re, s_im = mathstr.str_cplx_loggamma(str(z.real), str(z.imag))
    return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


def get_bernoulli(n):
    n = int(n)
    s = mathstr.str_bernoulli(get_dps(), n)
    return gmpy2.mpfr(s)


def get_agm(x, y):
    x = t(x)
    y = t(y)
    if hasattr(x, '__trunc__') and hasattr(y, '__trunc__'):
        return gmpy2.agm(x, y)
    s_re, s_im = mathstr.str_cplx_agm(
        str(x.real), str(x.imag), str(y.real), str(y.imag))
    return gmpy2.mpc(gmpy2.mpfr(s_re), gmpy2.mpfr(s_im))


# only real arguments
def zeta(s):
    s = t(s)
    if isinstance(s, gmpy2.mpc):
        if not s.imag:
            return gmpy2.mfc(gmpy2.zeta(s.real), 0)
        raise NotImplementedError
    return gmpy2.zeta(s)


# def _digamma_real(x):
#    return gmpy2.digamma(x)
#
#
# Needs mpm
# def _digamma_complex(x):
#    return gmpy2.digamma(x)
#
#
#digamma = _mathfun_real(_digamma_real, _digamma_complex)


# def erf(x):
#    """
#    erf of a real number.
#    """
#    return ### Needs mpm.erf(x)
#
#
# def erfc(x):
#    """
#    erfc of a real number.
#    """
#    return ### Needs mpm.erfc(x)
#
#
# def ei(z):
#    if not isinstance(z, (float, int)):
#        try:
#            z = float(z)
#        except (ValueError, TypeError):
#            try:
#                z = complex(z)
#                if not z.imag:
#                    return complex(gmpy2.eint(z.real))
#            except (ValueError, TypeError):
#                pass
#            raise NotImplementedError
#    return gmpy2.eint(z)
#
#
#
# def e1(z):
#    if not isinstance(z, (float, int)):
#        try:
#            z = float(z)
#        except (ValueError, TypeError):
#            try:
#                z = complex(z)
#                if not z.imag:
#                    return complex(gmpy2.eint(z.real))
#            except (ValueError, TypeError):
#                pass
#            raise NotImplementedError
#    return gmpy2.eint(z)
#
#
