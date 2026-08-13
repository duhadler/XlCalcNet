import gmpy2
from xlcalcnet import gpm, dreal, dcplx, apm, mpm
gpm.dps = 20


def demo_lommel_s1():
    print("lommel_s1")
    mu = 11.3
    nu = 2.7
    x = 0.3
    res = mpm.lommels1(mu, nu, x)
    print("res:", res)

def demo_lommel_s2():
    print("lommel_s1")
    mu = 11.3
    nu = 2.7
    x = 0.3
    res = mpm.lommels2(mu, nu, x)
    print("res:", res)

def dreal_divmod(a, b):
    r = dreal.fmod(a, b)
    q = (a - r) / b
    return (q, r)



def dreal_sinpi_real(x):
    if x < 0:
        return -dreal_sinpi_real(-x)
    n, r = dreal_divmod(x, 0.5)
#    print("n, r = dreal_divmod(x, 0.5):", n, r)
    r *= dreal.pi()
    n = dreal.lrint(dreal.fmod(n, 4))
#    print("n = dreal.lrint(dreal.fmod(n, 4)):", n)
#    print("r:", r)
    if n == 0:
        return dreal.sin(r)
    if n == 1:
        return dreal.cos(r)
    if n == 2:
        return -dreal.sin(r)
    if n == 3:
        return -dreal.cos(r)


def dreal_cospi_real(x):
    if x < 0:
        x = -x
    n, r = dreal_divmod(x, 0.5)
#    print("n, r = dreal_divmod(x, 0.5):", n, r)
    r *= dreal.pi()
    n = dreal.lrint(dreal.fmod(n, 4))
#    print("n = dreal.lrint(dreal.fmod(n, 4)):", n)
#    print("r:", r)
    if n == 0:
        return dreal.cos(r)
    if n == 1:
        return -dreal.sin(r)
    if n == 2:
        return -dreal.cos(r)
    if n == 3:
        return dreal.sin(r)



def _sinpi_real(x):
    if x < 0:
        return -_sinpi_real(-x)
    n, r = divmod(x, 0.5)
#    print("n, r = divmod(x, 0.5):", n, r)
    n = int(n)
    r *= gmpy2.const_pi()
    n %= 4
#    print("n %= 4:", n)
#    print("r:", r)
    if n == 0:
        return gmpy2.sin(r)
    if n == 1:
        return gmpy2.cos(r)
    if n == 2:
        return -gmpy2.sin(r)
    if n == 3:
        return -gmpy2.cos(r)


def _cospi_real(x):
    x = gpm.t(x)
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



def dcplx_sinpi_complex(z):
    if z.real < 0:
        return -dcplx_sinpi_complex(-z)
    n, r = dreal_divmod(z.real, 0.5)
    pi = dcplx.t(dreal.pi())
    z = dcplx.t(r, z.imag)*pi
    n = dreal.lrint(dreal.fmod(n, 4))
    if n == 0:
        return dcplx.sin(z)
    if n == 1:
        return dcplx.cos(z)
    if n == 2:
        return -dcplx.sin(z)
    if n == 3:
        return -dcplx.cos(z)



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



def dcplx_cospi_complex(z):
    if z.real < 0:
        z = -z
    n, r = dreal_divmod(z.real, 0.5)
    pi = dcplx.t(dreal.pi())
    z = dcplx.t(r, z.imag)*pi
    n = dreal.lrint(dreal.fmod(n, 4))
    if n == 0:
        return dcplx.cos(z)
    if n == 1:
        return -dcplx.sin(z)
    if n == 2:
        return -dcplx.cos(z)
    if n == 3:
        return dcplx.sin(z)


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
    z = gpm.t(z)
    if hasattr(z, '__trunc__'):
        return _cospi_real(z)
    else:
        return _cospi_complex(z)


def get_sinpi(z):
    z = gpm.t(z)
    if hasattr(z, '__trunc__'):
        return _sinpi_real(z)
    else:
        return _sinpi_complex(z)



def demo_sinpi():
    print('hello demo_sinpi')
    x = -26.91
    res = get_sinpi(x)
    print('res = get_sinpi(0.5):', res)
    print()

    print('hello dreal_sinpi_real')
    res = dreal_sinpi_real(x)
    print('res = dreal_sinpi_real(0.5):', res)

#    for i in range(60):
#        x = 1.0 * (i-30) / 10.0
#        res1 = get_sinpi(x)
#        res2 = dreal_sinpi_real(x)
#        print("x: ", x, "res1: ", res1,  "res2:", res2)

    for i in range(60):
        x = 1.0 * (i-30) / 10.0
        res1 = get_cospi(x)
        res2 = dreal_cospi_real(x)
        print("x: ", x, "res1: ", res1,  "res2:", res2)



def demo_sinpi_cplx():
    print('hello demo_sinpi_cplx')
    x = -6.0 + 2.0j

    res = get_sinpi(x)
    print('x:', x, 'res = get_sinpi(x):', res)
    print()

    res = dcplx_sinpi_complex(x)
    print('x:', x, 'res = dcplx_sinpi_complex(x):', res)
    print()

#    for i in range(60):
#        x = 1.0 * (i-30) / 10.0
#        z1 = x + 2.0j
#        res1 = get_sinpi(z1)
#        res2 = dcplx_sinpi_complex(z1)
#        print("z1: ", z1, "res1: ", res1,  "res2:", res2)

    for i in range(60):
        x = 1.0 * (i-30) / 10.0
        z1 = x + 2.0j
        res1 = get_cospi(z1)
        res2 = dcplx_cospi_complex(z1)
        print("z1: ", z1, "res1: ", res1,  "res2:", res2)



try:
    #demo_sinpi()
    #demo_sinpi_cplx()
    demo_lommel_s2()


except Exception:
    import traceback
    print(traceback.format_exc())


