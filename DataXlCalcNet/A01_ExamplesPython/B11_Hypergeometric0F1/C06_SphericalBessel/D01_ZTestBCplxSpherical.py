"""Spherical Bessel function algorithms implemented using mpmath.

Two different algorithms are implemented for each spherical Bessel function:
the exact formulas of http://dlmf.nist.gov/10.49 and the expressions in terms
of the ordinary Bessel functions, http://dlmf.nist.gov/10.47.ii .

"""


import math
from xlcalcnet import mp
from numpy import iscomplex



# Exact expressions #

def sph_jn_exact(n, z):
    """Return the value of j_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E1 .

    """
    zm = mp.mpmathify(z)
    s1 = sum((-1)**k*_a(2*k, n)/zm**(2*k+1) for k in range(0, int(n/2) + 1))
    s2 = sum((-1)**k*_a(2*k+1, n)/zm**(2*k+2) for k in range(0, int((n-1)/2) + 1))
    return mp.sin(zm - n*mp.pi/2)*s1 + mp.cos(zm - n*mp.pi/2)*s2


def sph_yn_exact(n, z):
    """Return the value of y_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E4 .

    """
    zm = mp.mpmathify(z)
    s1 = sum((-1)**k*_a(2*k, n)/zm**(2*k+1) for k in range(0, int(n/2) + 1))
    s2 = sum((-1)**k*_a(2*k+1, n)/zm**(2*k+2) for k in range(0, int((n-1)/2) + 1))
    return -mp.cos(zm - n*mp.pi/2)*s1 + mp.sin(zm - n*mp.pi/2)*s2


def sph_h1n_exact(n, z):
    """Return the value of h^{(1)}_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E6 .

    """
    zm = mp.mpmathify(z)
    s = sum(mp.mpc(0,1)**(k-n-1)*_a(k, n)/zm**(k+1) for k in range(n+1))
    return mp.exp(mpc(0,1)*zm)*s


def sph_h2n_exact(n, z):
    """Return the value of h^{(2)}_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E7 .

    """
    zm = mp.mpmathify(z)
    s = sum(mp.mpc(0,-1)**(k-n-1)*_a(k, n)/zm**(k+1) for k in range(n+1))
    return mp.exp(mp.mpc(0,-1)*zm)*s


def sph_i1n_exact(n, z):
    """Return the value of i^{(1)}_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E8 .

    """
    zm = mp.mpmathify(z)
    s1 = sum(mp.mpc(-1,0)**k * _a(k, n)/zm**(k+1) for k in range(n+1))
    s2 = sum(_a(k, n)/zm**(k+1) for k in xrange(n+1))
    return mp.exp(zm)/2 * s1 + mp.mpc(-1,0)**(n + 1)*mp.exp(-zm)/2 * s2


def sph_i2n_exact(n, z):
    """Return the value of i^{(2)}_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E10 .

    """
    zm = mp.mpmathify(z)
    s1 = sum(mpc(-1,0)**k * _a(k, n)/zm**(k+1) for k in range(n+1))
    s2 = sum(_a(k, n)/zm**(k+1) for k in xrange(n+1))
    return exp(zm)/2 * s1 + mpc(-1,0)**n*exp(-zm)/2 * s2


def sph_kn_exact(n, z):
    """Return the value of k_n computed using the exact formula.

    The expression used is http://dlmf.nist.gov/10.49.E12 .

    """
    zm = mp.mpmathify(z)
    s = sum(_a(k, n)/zm**(k+1) for k in range(n+1))
    return mp.pi*mp.exp(-zm)/2*s


A_CACHE = {}
def _a(k, n, dps=mp.dps):
    """Return the value of the Bessel asymptotic expansion coefficient.

    Defined as in http://dlmf.nist.gov/10.49#E1 , except I use the notation
    a(k, n) for their a(k, n + 1/2).  A simple cache is used to improve
    performance, since these coefficients must be computed many times.

    """
    if (k, n, dps) in A_CACHE:
        return A_CACHE[(k, n, dps)]
    else:
        if k <= n:
            f = mp.factorial # Abbreviation to make code more readable
            v = f(n + k)/( mp.mpf(2)**k * f(k) * f(n - k) )
            A_CACHE[(k, n, dps)] = v
            return v
        else:
            A_CACHE[(k, n, dps)] = 0
            return 0


# Ordinary Bessel function expressions #

def sph_jn_bessel(n, z):
    out = mp.besselj(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))
    if mp.mpmathify(z).imag == 0:
        return out.real # Small imaginary parts are spurious
    else:
        return out

def sph_yn_bessel(n, z):
    out = mp.bessely(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))
    if mp.mpmathify(z).imag == 0:
        return out.real
    else:
        return out

def sph_h1n_bessel(n, z):
    return mp.hankel1(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))

def sph_h2n_bessel(n, z):
    return mp.hankel2(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))

def sph_i1n_bessel(n, z):
    out = mp.besseli(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))
    if mp.mpmathify(z).imag == 0:
        return out.real
    else:
        return out

def sph_i2n_bessel(n, z):
    out = mp.besseli(- n - mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))
    return out

def sph_kn_bessel(n, z):
    out = mp.besselk(n + mp.mpf(1)/2, z)*mp.sqrt(mp.pi/(2*z))
    return out


# Power series (experimental)

def sph_jn_power(n, z, terms=100):
    zm = mpmathify(z)
    s = sum((-zm**2/2)**k/(factorial(k) * fac2(2*n + 2*k + 1)) for k in xrange(terms))
    return zm**n * s




def demo_sph_exact():
    n = 10
    z = 1+0j

    print(f"n, z: {n}, {z}")


    res = sph_jn_bessel(n, z)
    print(f"res = sph_jn_bessel(n, z): {res}")

    res = sph_yn_bessel(n, z)
    print(f"res = sph_yn_bessel(n, z): {res}")

    res = sph_h1n_bessel(n, z)
    print(f"res = sph_h1n_bessel(n, z): {res}")

    res = sph_h2n_bessel(n, z)
    print(f"res = sph_h2n_bessel(n, z): {res}")

    res = sph_i1n_bessel(n, z)
    print(f"res = sph_i1n_bessel(n, z): {res}")

    res = sph_i2n_bessel(n, z)
    print(f"res = sph_i2n_bessel(n, z): {res}")

    res = sph_kn_exact(n, z)
    print(f"res = sph_kn_exact(n, z): {res}")



def demo_sph():
    n = 10
    z = 1+0j

    res = sph_jn_bessel(n, z)
    print(f"res = sph_jn_bessel(n, z): {res}")

    res = sph_yn_bessel(n, z)
    print(f"res = sph_yn_bessel(n, z): {res}")

    res = sph_h1n_bessel(n, z)
    print(f"res = sph_h1n_bessel(n, z): {res}")

    res = sph_h2n_bessel(n, z)
    print(f"res = sph_h2n_bessel(n, z): {res}")

    res = sph_i1n_bessel(n, z)
    print(f"res = sph_i1n_bessel(n, z): {res}")

    res = sph_i2n_bessel(n, z)
    print(f"res = sph_i2n_bessel(n, z): {res}")

    res = sph_kn_bessel(n, z)
    print(f"res = sph_kn_bessel(n, z): {res}")



demo_sph_exact()

print()

demo_sph()








