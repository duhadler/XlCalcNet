# -*- coding: utf-8 -*-
"""
Spyder Editor
"""

import string

from xlcalcnet.mpmath.libmp.libmpi import mpi_to_str
from xlcalcnet.mpmath import mp, iv
from decimal import Decimal as D
has_gmpy2 = True
try:
    import gmpy2
except:
    has_gmpy2 = False
has_flint = True
try:
    import flint
except:
    has_flint = False

# Complex Decimal Class


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
            raise Exception(
                "Malformed string: expected 'j' or 'J' at the end")
        else:
            x = s[:pos]
            y = s[pos:-1]
    return x, y


def reverse_order_if_needed(x):
    if x.a > x.b:
        temp_a = mp.mpf(x.b)
        temp_b = mp.mpf(x.a)
        res = iv.mpf([temp_a, temp_b])
        return res
    else:
        return x



def s_fpm(z, mantissa_dps=None):
    if mantissa_dps is None:
        mantissa_dps = 15
        if mp.dps < 15:
            mantissa_dps = mp.dps
    f = "{0:." + str(mantissa_dps-1) + "E}"
    s = f.format(z)
    return s



def s_mpm(z, mantissa_dps=None, strip_zeros=False):
    if mantissa_dps is None:
        mantissa_dps = mp.dps
    if not(isinstance(z, mp.mpc)) and not(isinstance(z, mp.mpf)):
        z = t_mpm(z)
    if isinstance(z, mp.mpc):
        y = mp.im(z)
        sy = mp.nstr(y, mantissa_dps, min_fixed=1, max_fixed=0,
                     show_zero_exponent=True, strip_zeros=strip_zeros)
        x = mp.re(z)
        sx = mp.nstr(x, mantissa_dps, min_fixed=1, max_fixed=0,
                     show_zero_exponent=True, strip_zeros=strip_zeros)
        p = " + "
        if sx[0] == '-':
            p = " - "
            sy = sy[1:]
        return "(" + sx + p + sy + "j)"
    if isinstance(z, mp.mpf):
        s = mp.nstr(z, mantissa_dps, min_fixed=1, max_fixed=0,
                    show_zero_exponent=True, strip_zeros=strip_zeros)
        return s


def s_ivm(z, mantissa_dps=None, use_spaces=True, brackets='[]', mode='percent', error_dps=4, strip_zeros=False):
    if mantissa_dps is None:
        mantissa_dps = iv.dps
    if not(isinstance(z, iv.mpc)) and not(isinstance(z, iv.mpf)):
        z = t_ivm(z)
    if isinstance(z, iv.mpc):
        y = (iv.im(z))._mpi_
        sy = mpi_to_str(y, mantissa_dps, use_spaces=use_spaces, brackets=brackets, error_dps=error_dps,
                        mode=mode, min_fixed=1, max_fixed=0, show_zero_exponent=True, strip_zeros=strip_zeros)
        x = (iv.re(z))._mpi_
        sx = mpi_to_str(x, mantissa_dps, use_spaces=use_spaces, brackets=brackets, error_dps=error_dps,
                        mode=mode, min_fixed=1, max_fixed=0, show_zero_exponent=True, strip_zeros=strip_zeros)
        p = " + "
        if sy[0] == '-':
            p = " - "
            sy = sy[1:]
        return "(" + sx + p + sy + "j)"
    if isinstance(z, iv.mpf):
        x = z._mpi_
        s = mpi_to_str(x, mantissa_dps, use_spaces=use_spaces, brackets=brackets, error_dps=error_dps,
                       mode=mode, min_fixed=1, max_fixed=0, show_zero_exponent=True, strip_zeros=strip_zeros)
        return s



def s_gmp(z, mantissa_dps=None):
    from gmpy2 import mpfr, mpc as mpfc #, get_context as gmp_context

    if mantissa_dps is None:
        mantissa_dps = mp.dps
    f = "{0:." + str(mantissa_dps-1) + "E}"
    s = f.format(z)
    return s

def s_dec(z, mantissa_dps=None):
    if mantissa_dps is None:
        mantissa_dps = mp.dps
    f = "{0:." + str(mantissa_dps-1) + "E}"
    if not((str(type(z)) == "<class 'xlcalcnet.mathdp.DecCplx'>") or isinstance(z, D)):
        z = t_dec(z)
    if isinstance(z, D):
        return f.format(z)
    else:
        y = z.imag
        sy = f.format(y)
        x = z.real
        sx = f.format(x)
        p = " + "
        if sx[0] == '-':
            p = " - "
            sy = sy[1:]
        return "(" + sx + p + sy + "j)"




def show(items, aligned=True):
    if not aligned:
        for item in items:
            if isinstance(item, mp.mpf) or isinstance(item, mp.mpc):
                print('mpm: ', s_mpm(item))

            elif isinstance(item, iv.mpf) or isinstance(item, iv.mpc):
                print('ipm: ', s_ivm(item))

            elif isinstance(item, D) or (str(type(item)) == "<class 'xlcalcnet.mathdp.DecCplx'>"):
                print('dec: ', s_dec(item))
            elif isinstance(item, float) or isinstance(item, complex):
                print('fpm: ', s_fpm(item))
            elif isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
                print('gmp: ', s_gmp(item))

    else:
        xitems = []
        xmax = 0
        for item in items:
            if isinstance(item, mp.mpf):
                xitems.append(['mpm: ' + s_mpm(item), None])
            elif isinstance(item, iv.mpf):
                xitems.append(['ipm: ' + s_ivm(item), None])
            elif isinstance(item, D):
                xitems.append(['dec: ' + s_dec(item), None])
            elif isinstance(item, gmpy2.mpfr):
                xitems.append(['gmp: ' + s_gmp(item), None])
            elif isinstance(item, float):
                xitems.append(['fpm: ' + s_fpm(item), None])

            elif isinstance(item, mp.mpc):
                s = 'mpm: ' + s_mpm(mp.re(item))
                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, s_mpm(mp.im(item))])

            elif isinstance(item, iv.mpc):
                s = 'ipm: ' + s_ivm(iv.re(item))
                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, s_ivm(iv.im(item))])

                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, str(item.imag)])

            elif (str(type(item)) == "<class 'xlcalcnet.mathdp.DecCplx'>"):
                s = 'dec: ' + s_dec(item.real)
                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, s_dec(item.imag)])

            elif isinstance(item, complex):
                s = 'fpm: ' + s_fpm(item.real)
                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, s_fpm(item.imag)])
            elif isinstance(item, gmpy2.mpc):
                s = 'gmp: ' + s_gmp(item.real)
                if len(s) > xmax:
                    xmax = len(s)
                xitems.append([s, s_gmp(item.imag)])

        for xitem in xitems:
            if xitem[1] is None:
                print(xitem[0])
            else:
                is_apm = "apm" in xitem[0]
                es = ''
                e = xmax - len(xitem[0])
                if e > 0:
                    es = ' ' * e
                p = " + "
                if is_apm: p = " +"
                sy = xitem[1]
                if sy[0] == '-':
                    p = " - "
                    if is_apm: p = " -"
                    sy = sy[1:]
                print(xitem[0] + es + p + sy + 'j')



def t_fpm(x, y=None):
    if y is None:
        if isinstance(x, int):
            return float(x)
        if isinstance(x, float) or isinstance(x, complex):
            return x
        elif isinstance(x, mp.mpf):
            return float(x)
        elif isinstance(x, mp.mpc):
            return complex(x)
        if isinstance(x, str):
            s = ''.join(x.split())
            if s[-1] not in ['j', 'J']:
                return float(s)
            else:
                return complex(s)
    x = float(x)
    y = float(y)
    return complex(x, y)





def t_mpm(x, y=None):
    if y is None:
        s = str(type(x))
        if (isinstance(x, mp.mpc)) or (isinstance(x, mp.mpf)):
            return x
        elif isinstance(x, float):
            return mp.mpf(format(x, '.14g'))
        elif isinstance(x, int):
            return mp.mpf(x)
        elif isinstance(x, iv.mpf):
            return mp.mpf(x.mid)
        elif isinstance(x, D):
            return mp.mpf(str(x))
        elif isinstance(x, str):
            x, y = scancomplexstring(x)
            if y is None:
                return mp.mpf(x)
        elif isinstance(x, complex):
            y = format(x.imag, '.14g')
            x = format(x.real, '.14g')
        elif (str(type(x)) == "<class 'xlcalcnet.ctx_dec.DecCplx'>"):
            y = str(x.imag)
            x = str(x.real)
        elif isinstance(x, iv.mpc):
            y = (iv.im(x)).mid
            x = (iv.re(x)).mid
        elif has_gmpy2:
            if isinstance(x, gmpy2.mpfr):
                return mp.mpf(str(x))
            elif isinstance(x, gmpy2.mpc):
                y = str(x.imag)
                x = str(x.real)
    if y is not None:
        if not isinstance(x, mp.mpf):
            x = mp.mpf(x)
        if not isinstance(y, mp.mpf):
            y = mp.mpf(y)
        return mp.mpc(x, y)
    raise TypeError



def t_ivm(x, y=None):
    if y is None:
        if (isinstance(x, iv.mpc)) or (isinstance(x, iv.mpf)):
            return x
        elif isinstance(x, float):
            return iv.mpf(format(x, '.14g'))
        elif isinstance(x, int):
            return iv.mpf(x)
        elif isinstance(x, complex):
            y = format(x.imag, '.14g')
            x = format(x.real, '.14g')
        elif isinstance(x, mp.mpc):
            y = mp.im(x)
            x = mp.re(x)
        elif isinstance(x, str):
            x, y = scancomplexstring(x)
        x = iv.mpf(x)
        x = reverse_order_if_needed(x)
        if y is None: return x
    if y is not None:
        y = iv.mpf(y)
        y = reverse_order_if_needed(y)
        return iv.mpc(x, y)
    raise TypeError


def t_dec(x, y=None):
    if y is None:
        if isinstance(x, D):
            return x
        elif (str(type(x)) == "<class 'xlcalcnet.mathdp.DecCplx'>"):
            return x
        elif isinstance(x, float):
            return D(format(x, '.14g'))
        elif isinstance(x, int):
            return D(str(x))
        elif isinstance(x, complex):
            y = format(x.imag, '.14g')
            x = format(x.real, '.14g')

        elif isinstance(x, mp.t):
            return D(str(x))
        elif isinstance(x, mp.mpc):
            y = D(str(mp.im(x)))
            x = D(str(mp.re(x)))
            return DecCplx(x, y)

        elif mpm.ismpf(x):
            return D(str(x))
        elif mpm.ismpc(x):
            y = D(str(mpm.imag(x)))
            x = D(str(mpm.real(x)))
            return DecCplx(x, y)

        elif isinstance(x, str):
            x, y = scancomplexstring(x)
            if y is None:
                return D(x)
    if y is not None:
        return DecCplx(x, y)
    raise TypeError




def t_gmp(x, y=None):
    import gmpy2
    from gmpy2 import mpfr, mpc as mpfc
    if y is None:
        s = str(type(x))
        #print ("s: ", s, "x: ", x)
        if isinstance(x, gmpy2.mpfr) or isinstance(x, gmpy2.mpc):
            return x
        if (s == "<class 'xlcalcnet.ctx_gp.constant'>"):
            return 1 * x
        elif isinstance(x, float):
            return mpfr(format(x, '.14g'))
        elif isinstance(x, int):
            return mpfr(str(x))
        elif isinstance(x, mp.mpf):
            return mpfr(str(x))
        elif isinstance(x, mp.mpc):
            y = mpfr(str(mp.im(x)))
            x = mpfr(str(mp.re(x)))
            return mpfc(x, y)
        elif isinstance(x, D):
            return mpfr(str(x))
        elif (str(type(x)) == "<class 'xlcalcnet.mathdp.DecCplx'>"):
            y = mpfr(str(x.imag))
            x = mpfr(str(x.real))
            return mpfc(x, y)
            return x
        elif isinstance(x, complex):
            y = mpfr(format(x.imag, '.14g'))
            x = mpfr(format(x.real, '.14g'))
            return mpfc(x, y)
        elif isinstance(x, str):
            s = ''.join(x.split())
            if s[-1] not in ['j', 'J']:
                return mpfr(s)
            else:
                return mpfc(s)
    if y is not None:
        x = mpfr(x)
        y = mpfr(y)
        return mpfc(x, y)
    raise TypeError






def t_apm(x, y=None):
    if y is None:
        if (isinstance(x, flint.arb)) or (isinstance(x, flint.acb)):
            return x
        elif isinstance(x, float):
            return flint.arb(format(x, '.14g'))
        elif isinstance(x, int):
            return flint.arb(x)
        elif isinstance(x, complex):
            return flint.acb(format(x.real, '.14g'), format(x.imag, '.14g'))
        elif isinstance(x, str):
            x, y = scancomplexstring(x)
            if y is None:
                return flint.arb(x)
    if y is not None:
        x = flint.arb(x)
        y = flint.arb(y)
        z = flint.acb(x, y)
        return z
    raise TypeError








def str_pi(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.pi())
    mp.dps = dps0
    return res


def str_euler(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.euler())
    mp.dps = dps0
    return res


def str_catalan(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.catalan())
    mp.dps = dps0
    return res


def str_apery(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.apery())
    mp.dps = dps0
    return res


def str_khinchin(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.khinchin())
    mp.dps = dps0
    return res


def str_glaisher(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.glaisher())
    mp.dps = dps0
    return res


def str_twinprime(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.twinprime())
    mp.dps = dps0
    return res


def str_mertens(dps1):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.mertens())
    mp.dps = dps0
    return res


def str_bernoulli(dps1, k):
    dps0 = mp.dps
    mp.dps = dps1
    res = str(mp.bernoulli(k))
    mp.dps = dps0
    return res


def str_frexp(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    y, n = mp.frexp(x)
    res = str(y)
    mp.dps = dps0
    return res, n


def str_powm1(dps1, a, b):
    dps0 = mp.dps
    mp.dps = dps1
    xa = mp.mpf(a)
    xb = mp.mpf(b)
    res = str(mp.powm1(xa, xb))
    mp.dps = dps0
    return res


def str_cos(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.cos(x))
    mp.dps = dps0
    return res


def str_sin(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.sin(x))
    mp.dps = dps0
    return res


def str_tan(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.tan(x))
    mp.dps = dps0
    return res


def str_cot(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.cot(x))
    mp.dps = dps0
    return res


def str_acos(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.acos(x))
    mp.dps = dps0
    return res


def str_asin(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.asin(x))
    mp.dps = dps0
    return res


def str_atan(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.atan(x))
    mp.dps = dps0
    return res


def str_atan2(dps1, s, sy):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    y = mp.mpf(sy)
    res = str(mp.atan2(x, y))
    mp.dps = dps0
    return res


def str_cosh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.cosh(x))
    mp.dps = dps0
    return res


def str_sinh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.sinh(x))
    mp.dps = dps0
    return res


def str_tanh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.tanh(x))
    mp.dps = dps0
    return res


def str_acosh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.acosh(x))
    mp.dps = dps0
    return res


def str_asinh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.asinh(x))
    mp.dps = dps0
    return res


def str_atanh(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.atanh(x))
    mp.dps = dps0
    return res


def str_gamma(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.gamma(x))
    mp.dps = dps0
    return res

def str_cospi(dps1, s):
    dps0 = mp.dps
    mp.dps = dps1
    x = mp.mpf(s)
    res = str(mp.cospi(x))
    mp.dps = dps0
    return res



def str_cplx_exp(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.exp(z)
    return (str(res.real), str(res.imag))


def str_cplx_cospi(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.cospi(z)
    return (str(res.real), str(res.imag))


def str_cplx_powm1(a_re, a_im, b_re, b_im):
    a = mp.mpc(a_re, a_im)
    b = mp.mpc(b_re, b_im)
    res = mp.powm1(a, b)
    return (str(res.real), str(res.imag))


def str_cplx_ln(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.ln(z)
    return (str(res.real), str(res.imag))


def str_cplx_sqrt(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.sqrt(z)
    return (str(res.real), str(res.imag))


def str_cplx_cbrt(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.cbrt(z)
    return (str(res.real), str(res.imag))


def str_cplx_gamma(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.gamma(z)
    return (str(res.real), str(res.imag))


def str_cplx_rgamma(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.rgamma(z)
    return (str(res.real), str(res.imag))


def str_cplx_loggamma(s_re, s_im):
    z = mp.mpc(s_re, s_im)
    res = mp.loggamma(z)
    return (str(res.real), str(res.imag))


def str_cplx_agm(x_re, x_im, y_re, y_im):
    x = mp.mpc(x_re, x_im)
    y = mp.mpc(y_re, y_im)
    res = mp.agm(x, y)
    return (str(res.real), str(res.imag))
