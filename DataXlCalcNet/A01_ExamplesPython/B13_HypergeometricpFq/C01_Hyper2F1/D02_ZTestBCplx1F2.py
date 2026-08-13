
import math
from xlcalcnet import mpm, apm

from xlcalcnet import FixedPrecNet, ArbPrecNet
from ArbPrecNet import ArbPrec, BReal, BRealFlint, BCplxFlint

ArbPrec.SetDps(30)
mpm.dps = 30


def test1F2():
    a1 = 11
    b1 = 12
    b2 = 32
    x = 0.3

    res = mpm.hyp1f2(a1, b1, b2, x)
    print(f"res = mpm.hyp1f2(a1, b1, b2, x): {res}")

    res = BCplxFlint.Hypgeom1F2(a1, b1, b2, x)
    print(f"res = BCplxFlint.Hypgeom1F2(a, b1, b2, x): {res}")

    res = apm.hyp1f2(a1, b1, b2, x)
    print(f"res = apm.hyp1f2(a1, b1, b2, x): {res}")
    print()

    a1 = 11+2j
    b1 = 12+3j
    b2 = 42+3j
    z = 3+4j

    res = mpm.hyp1f2(a1, b1, b2, z)
    print(f"res = mpm.hyp1f2(a1, b1, b2, z): {res}")

    res = BCplxFlint.Hypgeom1F2(a1, b1, b2, z)
    print(f"res = BCplxFlint.Hypgeom1F2(a, b1, b2, z): {res}")

    res = apm.hyp1f2(a1, b1, b2, z)
    print(f"res = apm.hyp1f2(a1, b1, b2, z): {res}")
    print()



def test1F2r():
    a1 = 11
    b1 = 12
    b2 = 32
    x = 0.3

    res = mpm.hyp1f2r(a1, b1, b2, x)
    print(f"res = mpm.hyp1f2(a1, b1, b2, x): {res}")

    res = BCplxFlint.Hypgeom1F2r(a1, b1, b2, x)
    print(f"res = BCplxFlint.Hypgeom1F2(a1, b1, b2, x): {res}")

    res = apm.hyp1f2r(a1, b1, b2, x)
    print(f"res = apm.hyp1f2(a1, b1, b2, x): {res}")
    print()


    a1 = 11+2j
    b1 = 12+3j
    b2 = 42+3j
    z = 3+4j

    res = mpm.hyp1f2r(a1, b1, b2, z)
    print(f"res = mpm.hyp1f2r(a1, b1, b2, z): {res}")

    res = BCplxFlint.Hypgeom1F2r(a1, b1, b2, z)
    print(f"res = BCplxFlint.Hypgeom1F2r(a, b1, b2, z): {res}")

    res = apm.hyp1f2r(a1, b1, b2, z)
    print(f"res = apm.hyp1f2r(a1, b1, b2, z): {res}")
    print()




def testscorergi():
    x = -3

    res = mpm.scorergi(x)
    print(f"res = mpm.scorergi(x): {res}")

    res = apm.scorergi(x)
    print(f"res = apm.scorergi(x): {res}")
    print()

    z = 3+4j

    res = mpm.scorergi(z)
    print(f"res = mpm.scorergi(z): {res}")

    res = apm.scorergi(z)
    print(f"res = apm.scorergi(z): {res}")
    print()




def testscorerhi():
    x = -3

    res = mpm.scorerhi(x)
    print(f"res = mpm.scorerhi(x): {res}")

    res = apm.scorerhi(x)
    print(f"res = apm.scorerhi(x): {res}")
    print()

    z = 3+4j

    res = mpm.scorerhi(z)
    print(f"res = mpm.scorerhi(z): {res}")

    res = apm.scorerhi(z)
    print(f"res = apm.scorerhi(z): {res}")
    print()



def teststruveh():
    n = 10
    x = -3

    res = mpm.struveh(n, x)
    print(f"res = mpm.struveh(n, x): {res}")

    res = apm.struveh(n, x)
    print(f"res = apm.struveh(n, x): {res}")
    print()

    n = 10+1j
    z = 3+4j

    res = mpm.struveh(n, z)
    print(f"res = mpm.struveh(n, z): {res}")

    res = apm.struveh(n, z)
    print(f"res = apm.struveh(n, z): {res}")
    print()



def teststruvel():
    n = 10
    x = -3

    res = mpm.struvel(n, x)
    print(f"res = mpm.struvel(n, x): {res}")

    res = apm.struvel(n, x)
    print(f"res = apm.struvel(n, x): {res}")
    print()

    n = 10+0j
    z = 3+4j

    res = mpm.struvel(n, z)
    print(f"res = mpm.struvel(n, z): {res}")

    res = apm.struvel(n, z)
    print(f"res = apm.struvel(n, z): {res}")
    print()





def teststruvek():
    n = 10
    x = 3


    res = mpm.bessely(n, x)
    print(f"res = mpm.bessely(n, x): {res}")


    res = apm.bessely(n, x)
    print(f"res = res = apm.bessely(n, x): {res}")


    res = mpm.struvek(n, x)
    print(f"res = mpm.struvek(n, x): {res}")

    res = apm.struvek(n, x)
    print(f"res = apm.struvek(n, x): {res}")
    print()

    n = 10
    z = 3+4j

    res = mpm.struvek(n, z)
    print(f"res = mpm.struvek(n, z): {res}")

    res = apm.struvek(n, z)
    print(f"res = apm.struvek(n, z): {res}")
    print()



def teststruvem():
    n = 10
    x = -3

    res = mpm.struvem(n, x)
    print(f"res = mpm.struvem(n, x): {res}")

    res = apm.struvem(n, x)
    print(f"res = apm.struvem(n, x): {res}")
    print()

    n = 10+0j
    z = 3+4j

    res = mpm.struvem(n, z)
    print(f"res = mpm.struvem(n, z): {res}")

    res = apm.struvem(n, z)
    print(f"res = apm.struvem(n, z): {res}")
    print()



def testangerj():
    n = 10
    x = -3

    res = mpm.angerj(n, x)
    print(f"res = mpm.angerj(n, x): {res}")

    res = apm.angerj(n, x)
    print(f"res = apm.angerj(n, x): {res}")
    print()

    n = 10+0j
    z = 3+4j

    res = mpm.angerj(n, z)
    print(f"res = mpm.angerj(n, z): {res}")

    res = apm.angerj(n, z)
    print(f"res = apm.angerj(n, z): {res}")
    print()



def testwebere():
    n = 10
    x = 3

    res = mpm.webere(n, x)
    print(f"res = mpm.webere(n, x): {res}")

    res = apm.webere(n, x)
    print(f"res = apm.webere(n, x): {res}")
    print()

    n = 10+0j
    z = 3+4j

    res = mpm.webere(n, z)
    print(f"res = mpm.webere(n, z): {res}")

    res = apm.webere(n, z)
    print(f"res = apm.webere(n, z): {res}")
    print()




def testlommels1():
    mu = 11.3
    nu = 2.7
    x = 0.3

    res = mpm.lommels1(nu, mu, x)
    print(f"res = mpm.lommels1(nu, mu, x): {res}")

    res = apm.lommels1(nu, mu, x)
    print(f"res = apm.lommels1(nu, mu, x): {res}")
    print()

    nu = 11+2j
    mu = 12+3j
    z = 3+4j

    res = mpm.lommels1(nu, mu, z)
    print(f"res = mpm.lommels1(mu, nu, z): {res}")

    res = apm.lommels1(nu, mu, z)
    print(f"res = apm.lommels1(mu, nu, z): {res}")
    print()




def testlommels2():
    mu = 11.3
    nu = 2.7
    x = 0.3

    res = mpm.lommels2(nu, mu, x)
    print(f"res = mpm.lommels2(nu, mu, x): {res}")

    res = apm.lommels2(nu, mu, x)
    print(f"res = apm.lommels2(nu, mu, x): {res}")
    print()

    nu = 11+2j
    mu = 12+3j
    z = 3+4j

    res = mpm.lommels2(nu, mu, z)
    print(f"res = mpm.lommels2(mu, nu, z): {res}")

    res = apm.lommels2(nu, mu, z)
    print(f"res = apm.lommels2(mu, nu, z): {res}")
    print()





test1F2()

#test1F2r()

#testscorergi()

#testscorerhi()

#teststruveh()

#teststruvel()

#teststruvek()

#teststruvem()

#testangerj()

#testwebere()

#testlommels1()

#testlommels2()






