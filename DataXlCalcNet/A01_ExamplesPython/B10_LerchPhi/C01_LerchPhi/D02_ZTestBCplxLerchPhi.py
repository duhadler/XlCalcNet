

import math
from xlcalcnet import mp, mpm

from xlcalcnet import FixedPrecNet, ArbPrecNet
from FixedPrecNet import FReal, FRealFlint, FRealBoost
from ArbPrecNet import ArbPrec, BCplx, BReal, BRealFlint, BCplxFlint

ArbPrec.SetDps(30)
mpm.dps = 30



def testlerchzeta():
    lambda1 = 0.5
    alpha = 0.2
    s = 0.7
    e = BCplx.Exp(2*BReal.ConstPi()*BCplx.Onei()*lambda1)
    lz = BCplxFlint.LerchPhi(e, s, alpha)
    print(f"lz = BCplxFlint.LerchPhi(e, s, alpha): {lz}")
    lz = mpm.lerch_zeta(lambda1, alpha, s)
    print(f"lz = mpm.lerch_zeta(lambda1, alpha, s): {lz}")
    lz = BCplxFlint.LerchZeta(lambda1, alpha, s)
    print(f"lz = BCplxFlint.LerchZeta(lambda1, alpha, s): {lz}")



def testpolygamma():
    m = 10
    z = 5.0

    res = BCplxFlint.Polygamma(m, z)
    print(f"res = BCplxFlint.Polygamma(m, z): {res}")
    res = mpm.polygamma(m, z)
    print(f"res = mpm.polygamma(m, z): {res}")

    print()

    res = BCplxFlint.Digamma(z)
    print(f"res = BCplxFlint.Digamma(z): {res}")
    res = mpm.digamma(z)
    print(f"res = mpm.digamma(z): {res}")

    print()

    print("Trigamma")
    res = BCplxFlint.Polygamma(1.0, z)
    print(f"res = BCplxFlint.Polygamma(1.0, z): {res}")
    res = mpm.trigamma(z)
    print(f"res = mpm.trigamma(z): {res}")
    res = BCplxFlint.Trigamma(z)
    print(f"res = BCplxFlint.Trigamma(z): {res}")



def testpolylog():
    s = 10
    z = 0.5
    Mpfeb.SetDps(30)
    res = BCplxFlint.Polylog(s, z)
    print(f"res = BCplxFlint.Polylog(s, z): {res}")
    res = mpm.polylog(s, z)
    print(f"res = mpm.polylog(s, z): {res}")

    print()

    res = BCplxFlint.Polylog(2.0, z)
    print(f"res = BCplxFlint.Polylog(2.0, z): {res}")
    res = BCplxFlint.Dilog(z)
    print(f"res = BCplxFlint.Dilog(z): {res}")
    res = mpm.dilog(z)
    print(f"res = mpm.dilog(z): {res}")


    print()

    print("Trilog")
    res = BCplxFlint.Polylog(3.0, z)
    print(f"res = BCplxFlint.Polylog(3.0, z): {res}")
    res = mpm.trilog(z)
    print(f"res = mpm.trilog(z): {res}")
    res = BCplxFlint.Trilog(z)
    print(f"res = BCplxFlint.Trilog(z): {res}")


    print()

    print("ClausenSin(s, z)")
    res1 = BCplxFlint.Polylog(s, BCplx.Exp(z*1j))
    res2 = BCplxFlint.Polylog(s, BCplx.Exp(-z*1j))
    res = (res1 - res2) / 2j
    print(f"ClausenSin(s, z): {res}")
    res = mpm.clsin(s, z)
    print(f"res = mpm.clsin(s, z): {res}")
    res = BCplxFlint.ClausenSin(s, z)
    print(f"res = BCplxFlint.ClausenSin(s, z): {res}")

    print()

    print("ClausenCos(s, z)")
    res1 = BCplxFlint.Polylog(s, BCplx.Exp(z*1j))
    res2 = BCplxFlint.Polylog(s, BCplx.Exp(-z*1j))
    res = (res1 + res2) / 2
    print(f"ClausenCos(s, z): {res}")
    res = mpm.clcos(s, z)
    print(f"res = mpm.clcos(s, z): {res}")
    res = BCplxFlint.ClausenCos(s, z)
    print(f"res = BCplxFlint.ClausenCos(s, z): {res}")

    print()

    print("Clausen2(z)")
    res1 = BCplxFlint.Polylog(2, BCplx.Exp(z*1j))
    res = res1.Imag
    print(f"Clausen2(z): {res}")
    res = mpm.cl2(z)
    print(f"res = mpm.cl2(z): {res}")
    res = BCplxFlint.Clausen2(z)
    print(f"res = BCplxFlint.Clausen2(z): {res}")

    print()

    print("BoseEinstein(s, z)")
    res = BCplxFlint.Polylog(s+1, BCplx.Exp(z))
    print(f"BoseEinstein(s, z): {res}")
    res = mpm.bose_einstein(s, z)
    print(f"res = mpm.bose_einstein(s, z): {res}")
    res = BCplxFlint.BoseEinstein(s, z)
    print(f"res = BCplxFlint.BoseEinstein(s, z): {res}")

    print()

    print("FermiDirac(s, z)")
    res = -BCplxFlint.Polylog(s+1, -BCplx.Exp(z))
    print(f"FermiDirac(s, z): {res}")
    res = mpm.fermi_dirac(s, z)
    print(f"res = mpm.fermi_dirac(s, z): {res}")
    res = BCplxFlint.FermiDirac(s, z)
    print(f"res = BCplxFlint.FermiDirac(s, z): {res}")

    print()

    print("LegendreChi(s, z)")
    res1 = BCplxFlint.Polylog(s, z)
    res2 = BCplxFlint.Polylog(s, -z)
    res = (res1 - res2) / 2
    print(f"LegendreChi(s, z): {res}")
    res = mpm.legendre_chi(s, z)
    print(f"res = mpm.legendre_chi(s, z): {res}")
    res = BCplxFlint.LegendreChi(s, z)
    print(f"res = BCplxFlint.LegendreChi(s, z): {res}")

    print()

    print("Generalized inverse tangent integral Ti(s, z)")
    res1 = BCplxFlint.Polylog(s, z*1j)
    res2 = BCplxFlint.Polylog(s, -z*1j)
    res = (res1 - res2) / 2j
    print(f"Generalized inverse tangent integral Ti(s, z): {res}")
    res = mpm.ti(s, z)
    print(f"res = mpm.ti(s, z): {res}")
    res = BCplxFlint.InverseTanIntegral(s, z)
    print(f"res = BCplxFlint.InverseTanIntegral(s, z): {res}")

    print("Debye to be done")





def testhurwitz_zeta():
    s = 10
    z = 2.5

    print("Harmonic(z)")
    res = BCplxFlint.Digamma(z+1) + BReal.ConstEulerGamma()
    print(f"Harmonic(z): {res}")
    res = mpm.harmonic(z)
    print(f"res = mpm.harmonic(z): {res}")
    res = BCplxFlint.Harmonic(z)
    print(f"res = BCplxFlint.Harmonic(z): {res}")


    print()

    r = 3
    print("Harmonic2(z, r)")
    res = BCplxFlint.Zeta(r) - BCplxFlint.HurwitzZeta(r, z+1)
    print(f"Harmonic2(z, r): {res}")
    res = mpm.harmonic2(z, r)
    print(f"res = mpm.harmonic2(z, r): {res}")
    res = BCplxFlint.Harmonic2(z, r)
    print(f"res = BCplxFlint.Harmonic2(z, r): {res}")


    print()

    m=6
    n=m+1
    print("Eulerpoly(n, z)")
    res1 = BCplxFlint.BernoulliPoly(z, n)
    res2 = (2**n) * BCplxFlint.BernoulliPoly(z/2, n)
    res = 2*(res1 - res2)/n
    print(f"Eulerpoly(n, z): {res}")
    res = mpm.eulerpoly(m, z)
    print(f"res = mpm.eulerpoly(m, z): {res}")
    res = BCplxFlint.EulerPoly(z, m)
    print(f"res = BCplxFlint.EulerPoly(z, m): {res}")


    print()

    z=56
    print("Hyperfac(z)")
    res1 = BCplxFlint.Gamma(z+1)
    res2 = BCplx.Pow(res1, z)
    res3 = BCplxFlint.BarnesG(z+1)
    res = res2/res3
    print(f"Hyperfac(z): {res}")
    res = mpm.hyperfac(z)
    print(f"res = mpm.hyperfac(z): {res}")
    res = BCplxFlint.Hyperfactorial(z)
    print(f"res = BCplxFlint.Hyperfactorial(z): {res}")

    print()

    z=56
    print("Superfac(z)")
    res = BCplxFlint.BarnesG(z+2)
    print(f"Superfac(z): {res}")
    res = mpm.superfac(z)
    print(f"res = mpm.superfac(z): {res}")
    res = BCplxFlint.Superfactorial(z)
    print(f"res = BCplxFlint.Superfactorial(z): {res}")



def zetam1(s):
    return BCplxFlint.HurwitzZeta(s, 2)


def test_zeta():
    s = 60
    z = 2.5

    print("Zetam1(s)")
    res = BCplxFlint.Zeta(s) - 1
    print(f"BCplxFlint.Zeta(s): {res}")
    res = zetam1(s)
    print(f"Zetam1(s): {res}")
    res = mpm.zetam1(s)
    print(f"res = mpm.zetam1(s): {res}")
    res = BCplxFlint.Zetam1(s)
    print(f"res = BCplxFlint.Zetam1(s): {res}")

    print()

    print("DirichletEtam1(s)")
    ArbPrec.SetDps(60)
    res = BCplxFlint.DirichletEta(s) - 1
    print(f"res = BCplxFlint.DirichletEta(s) - 1: {res}")
    ArbPrec.SetDps(30)
    p = BCplx.Pow(2, 1-s)
    #p = BCplx.Exp2(1-s)

    a = zetam1(s)
    b = BCplxFlint.Zeta(s)
    res = a - p * b
    print(f"res = b - p * c: {res}")
    res = BCplxFlint.DirichletEtam1(s)
    print(f"res = BCplxFlint.DirichletEtam1(s): {res}")


    print()

    s=5
    print("DirichletBeta(s)")
    res1 = BCplxFlint.HurwitzZeta(s, 0.25)
    res2 = BCplxFlint.HurwitzZeta(s, 0.75)
    res3 = BCplx.Pow(4, -s)
    res = res3 * (res1 - res2)
    print(f"DirichletBeta(s): {res}")
    res = mpm.dirichlet_beta(s)
    print(f"res = mpm.dirichlet_beta(s): {res}")
    res = BCplxFlint.DirichletBeta(s)
    print(f"res = BCplxFlint.DirichletBeta(s): {res}")


    print()

    s=5
    print("DirichletLambda(s)")
    res1 = BCplxFlint.Zeta(s)
    res3 = -BCplxFlint.Exp2m1(-s)
    res = res3 * res1
    print(f"DirichletLambda(s): {res}")
    res = mpm.dirichlet_lambda(s)
    print(f"res = mpm.dirichlet_lambda(s): {res}")
    res = BCplxFlint.DirichletLambda(s)
    print(f"res = BCplxFlint.DirichletLambda(s): {res}")



#testlerchzeta()
#testpolygamma()
#testpolylog()
#testhurwitz_zeta()
test_zeta()


