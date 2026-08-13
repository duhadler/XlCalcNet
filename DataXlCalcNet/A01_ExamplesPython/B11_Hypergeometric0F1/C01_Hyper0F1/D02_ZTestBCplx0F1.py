

import math
from xlcalcnet import mp, mpm

from xlcalcnet import FixedPrecNet, ArbPrecNet
from FixedPrecNet import FReal, FRealFlint, FRealBoost
from ArbPrecNet import ArbPrec, BReal, BRealFlint, BCplxFlint

ArbPrec.SetDps(30)
mpm.dps = 30


def test0F1():
    a = 10
    x = 30
    res = FRealBoost.Hypergeo0F1(a, x)
    print(f"res = FRealBoost.Hypergeo0F1(a, x): {res}")

    res = BCplxFlint.Hypgeom0F1(a, x)
    print(f"res = BCplxFlint.Hypgeom0F1(a, x): {res}")

    res = mpm.hyp0f1(10,30)
    print(f"res = mpm.hyp0f1(10,30): {res}")

#    res = FRealBoost.Hypergeo0F1r(a, x)
#    print(f"res = FRealBoost.Hypergeo0F1r(a, x): {res}")

    res = BCplxFlint.Hypgeom0F1r(a, x)
    print(f"res = BCplxFlint.Hypgeom0F1r(a, x): {res}")

    res = mpm.hyp0f1r(10,30)
    print(f"res = mpm.hyp0f1r(10,30): {res}")




def testbessel():
    nu = 10
    x = 11.5

    res = FRealBoost.BesselJ(nu, x)
    print(f"res = FRealBoost.Hypergeo0F1(nu, x): {res}")

    res = BCplxFlint.BesselJ(nu, x)
    print(f"res = BCplxFlint.Hypgeom0F1(nu, x): {res}")

    res = mpm.besselj(nu,x)
    print(f"res = mpm.besselj(nu,x): {res}")








def testsphbessel():
    nu = 10
    x = 11.5

    res = FRealBoost.SphBessel(nu, x)
    print(f"res = FRealBoost.SphBessel(nu, x): {res}")

##    res = BCplxFlint.BesselJ(nu, x) print(f"res =
##    BCplxFlint.Hypgeom0F1(nu, x): {res}")

    res = mpm.sph_bessel_jn(nu,x)
    print(f"res = mpm.sph_bessel_jn(nu,x): {res}")





def testairy():
    x = 2.5

    res = FRealBoost.AiryAi(x)
    print(f"res = FRealBoost.AiryAi(x): {res}")

    res = BCplxFlint.AiryAi(x)
    print(f"res = BCplxFlint.AiryAi(x): {res}")

    res = mpm.airyai(x)
    print(f"res = mpm.airyai(x): {res}")

    print()





def testkelvin():
    n = 1
    z = 2.5

    res = mpm.ber(n, z)
    print(f"res = mpm.ber(n, z): {res}")

    res = mpm.kelvinber(n, z)
    print(f"res = mpm.kelvinber(n, z): {res}")

    print()



#test0F1()
testbessel()
#testsphbessel()
#testairy()
#testkelvin()



