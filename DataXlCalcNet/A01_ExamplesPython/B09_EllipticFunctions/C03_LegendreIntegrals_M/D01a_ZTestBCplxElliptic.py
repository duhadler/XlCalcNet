

import math
from xlcalcnet import mp, mpm

from xlcalcnet import FixedPrecNet, ArbPrecNet
from FixedPrecNet import dreal
from ArbPrecNet import ArbPrec, dflint, aflint, aflintc

ArbPrec.SetDps(30)
mpm.dps = 30



def qfromk(k):
    kc = BCplx.Sqrt(1-k*k)
    e1 = BCplxFlint.EllipticK(k)
    e2 = BCplxFlint.EllipticK(kc)
    q = BCplx.Exp(-BReal.ConstPi()*e2/e1)
    return q




def jacobitheta():
    q = 0.2+0.1j
    t = 0.35+0.2j
    t1 = mp.jtheta(1, t, q)
    print(f"t1 = mp.jtheta(1, t, q): {t1}")

    t1 = FCplxFlint.JacobiTheta1(t, q)
    print(f"t1 = FCplxFlint.JacobiTheta1(t, q): {t1}")

    t1 = BCplxFlint.JacobiTheta1(t, q)
    print(f"t1 = BCplxFlint.JacobiTheta1(t, q): {t1}")

    print()

    t2 = mp.jtheta(2, t, q)
    print(f"t2 = mp.jtheta(2, t, q): {t2}")

    t2 = FCplxFlint.JacobiTheta2(t, q)
    print(f"t2 = FCplxFlint.JacobiTheta2(t, q): {t2}")

    t2 = BCplxFlint.JacobiTheta2(t, q)
    print(f"t2 = BCplxFlint.JacobiTheta2(t, q): {t2}")

    print()

    t3 = mp.jtheta(3, t, q)
    print(f"t3 = mp.jtheta(3, t, q): {t3}")

    t3 = FCplxFlint.JacobiTheta3(t, q)
    print(f"t3 = FCplxFlint.JacobiTheta3(t, q): {t3}")

    t3 = BCplxFlint.JacobiTheta3(t, q)
    print(f"t3 = BCplxFlint.JacobiTheta3(t, q): {t3}")

    print()

    t4 = mp.jtheta(4, t, q)
    print(f"t4 = mp.jtheta(4, t, q): {t4}")

    t4 = FCplxFlint.JacobiTheta4(t, q)
    print(f"t4 = FCplxFlint.JacobiTheta4(t, q): {t4}")

    t4 = BCplxFlint.JacobiTheta4(t, q)
    print(f"t4 = BCplxFlint.JacobiTheta4(t, q): {t4}")




def qfromk(k):
    kc = BCplx.Sqrt(1-k*k)
    e1 = BCplxFlint.EllipticK(k)
    e2 = BCplxFlint.EllipticK(kc)
    q = BCplx.Exp(-BReal.ConstPi()*e2/e1)
    return q



def tfrom_u_q(u, q):
    t3 = BCplxFlint.JacobiTheta3(0.0, q)
    t = u / (t3*t3)
    return t


def jacobi_elliptic():
    print()
    print("jacobi_elliptic():")

    u = 0.4+0.2j
    print(f"u = 0.4+0.2j: {u}")
    k = 0.6+1.1j
    print(f"k = 0.6+0.1j: {k}")


    q = qfromk(k)
    print(f"q = qfromk(k): {q}")

    q1 = BCplxFlint.QfromK(k)
    print(f"q1 = BCplxFlint.QfromK(k): {q1}")

    t = tfrom_u_q(u, q)
    print(f"t = tfrom_u_q(u, q): {t}")

    t1a = BCplxFlint.TfromUQ(u, q)
    print(f"t1a = BCplxFlint.TfromUQ(u, q): {t1a}")


    x = mpm.jacobi_sn(u, k)
    print(f"x = mpm.jacobi_sn(u, k): {x}")


    x = BCplxFlint.SnTQ(t1a, q1)
    print(f"x = BCplxFlint.SnTQ(t1a, q1): {x}")


    t2 = BCplxFlint.JacobiTheta2(0.0, q1)
    t3 = BCplxFlint.JacobiTheta3(0.0, q1)
    tt1 = BCplxFlint.JacobiTheta1(t, q1)
    tt4 = BCplxFlint.JacobiTheta4(t, q1)
    sn = (t3*tt1) / (t2*tt4)
    print(f"sn = (t3*t1) / (t2*t4): {sn}")

    print()

    x = mpm.jacobi_cn(u, k)
    print(f"x = mpm.jacobi_cn(u, k): {x}")

    x = BCplxFlint.CnTQ(t1a, q1)
    print(f"x = BCplxFlint.CnTQ(t1a, q1): {x}")


    t2 = BCplxFlint.JacobiTheta2(0.0, q)
    t4 = BCplxFlint.JacobiTheta4(0.0, q)
    tt2 = BCplxFlint.JacobiTheta2(t, q)
    tt4 = BCplxFlint.JacobiTheta4(t, q)
    cn = (t4*tt2) / (t2*tt4)
    print(f"cn = (t4*tt2) / (t2*tt4): {cn}")

    print()

    x = mpm.jacobi_dn(u, k)
    print(f"x = mpm.jacobi_dn(u, k): {x}")

    x = BCplxFlint.DnTQ(t1a, q1)
    print(f"x = BCplxFlint.DnTQ(t1a, q1): {x}")


    t3 = BCplxFlint.JacobiTheta3(0.0, q)
    t4 = BCplxFlint.JacobiTheta4(0.0, q)
    tt3 = BCplxFlint.JacobiTheta3(t, q)
    tt4 = BCplxFlint.JacobiTheta4(t, q)
    dn = (t4*tt3) / (t3*tt4)
    print(f"dn = (t4*tt3) / (t3*tt4): {dn}")




def jacobi_elliptic_2():
    print()
    print("jacobi_elliptic():")

    u = 0.4+0.2j
    print(f"u = 0.4+0.2j: {u}")
    k = 0.6+1.1j
    print(f"k = 0.6+0.1j: {k}")
    print()

    x = mpm.jacobi_sn(u, k)
    print(f"x = mpm.jacobi_sn(u, k): {x}")

##    x = BCplxFlint.JacobiSN(u, k)
##    print(f"x = BCplxFlint.JacobiSN(u, k): {x}")


    print()

    x = mpm.jacobi_cn(u, k)
    print(f"x = mpm.jacobi_cn(u, k): {x}")

##    x = BCplxFlint.JacobiCN(u, k)
##    print(f"x = BCplxFlint.JacobiCN(u, k): {x}")

    print()

    x = mpm.jacobi_dn(u, k)
    print(f"x = mpm.jacobi_dn(u, k): {x}")

##    x = BCplxFlint.JacobiDN(u, k)
##    print(f"x = BCplxFlint.JacobiDN(u, k): {x}")


    print()

    x = mpm.jacobi_ns(u, k)
    print(f"x = mpm.jacobi_ns(u, k): {x}")

##    x = BCplxFlint.JacobiNS(u, k)
##    print(f"x = BCplxFlint.JacobiNS(u, k): {x}")


    print()

    x = mpm.jacobi_nc(u, k)
    print(f"x = mpm.jacobi_nc(u, k): {x}")

##    x = BCplxFlint.JacobiNC(u, k)
##    print(f"x = BCplxFlint.JacobiNC(u, k): {x}")

    print()

    x = mpm.jacobi_nd(u, k)
    print(f"x = mpm.jacobi_nd(u, k): {x}")

##    x = BCplxFlint.JacobiND(u, k)
##    print(f"x = BCplxFlint.JacobiND(u, k): {x}")

    print()



    x = mpm.jacobi_sc(u, k)
    print(f"x = mpm.jacobi_sc(u, k): {x}")

##    x = BCplxFlint.JacobiSC(u, k)
##    print(f"x = BCplxFlint.JacobiSC(u, k): {x}")

    print()


    x = mpm.jacobi_sd(u, k)
    print(f"x = mpm.jacobi_sd(u, k): {x}")

##    x = BCplxFlint.JacobiSD(u, k)
##    print(f"x = BCplxFlint.JacobiSD(u, k): {x}")

    print()



    x = mpm.jacobi_dc(u, k)
    print(f"x = mpm.jacobi_dc(u, k): {x}")

##    x = BCplxFlint.JacobiDC(u, k)
##    print(f"x = BCplxFlint.JacobiDC(u, k): {x}")

    print()


    x = mpm.jacobi_ds(u, k)
    print(f"x = mpm.jacobi_ds(u, k): {x}")

##    x = BCplxFlint.JacobiDS(u, k)
##    print(f"x = BCplxFlint.JacobiDS(u, k): {x}")

    print()




    x = mpm.jacobi_cs(u, k)
    print(f"x = mpm.jacobi_cs(u, k): {x}")

##    x = BCplxFlint.JacobiCS(u, k)
##    print(f"x = BCplxFlint.JacobiCS(u, k): {x}")

    print()


    x = mpm.jacobi_cd(u, k)
    print(f"x = mpm.jacobi_cd(u, k): {x}")

##    x = BCplxFlint.JacobiCD(u, k)
##    print(f"x = BCplxFlint.JacobiCD(u, k): {x}")

    print()







def cplx2():
    print()
    print("cplx2():")

    k = 0.6+0.1j
    print(f"k = 0.6+0.1j: {k}")
    m = k * k
    print(f"m = k * k: {m}")

    x = mpm.melliptic_k(m)
    print(f"x = mpm.melliptic_k(m): {x}")

    x = mpm.elliptic_k(k)
    print(f"x = mpm.elliptic_k(k): {x}")

##    x = BCplxFlint.EllipticK(k)
##    print(f"x = BRealFlint.EllipticK(k): {x}")



#jacobitheta()

#jacobi_elliptic()

jacobi_elliptic_2()


#cplx2()






