

import math
from xlcalcnet import mp, mpm

from xlcalcnet import FixedPrecNet, ArbPrecNet
from FixedPrecNet import dreal
from ArbPrecNet import ArbPrec, dflint, aflint, aflintc

ArbPrec.SetDps(30)
mpm.dps = 30





def jacobitheta():
    q = 0.2
    t = 0.35
    t1 = mp.jtheta(1, t, q)
    print(f"t1 = mp.jtheta(1, t, q): {t1}")

    t1 = FRealFlint.JacobiTheta1(t, q)
    print(f"t1 = FCplxFlint.JacobiTheta1(t, q): {t1}")

    t1 = BRealFlint.JacobiTheta1(t, q)
    print(f"t1 = BRealFlint.JacobiTheta1(t, q): {t1}")

    print()

    t2 = mp.jtheta(2, t, q)
    print(f"t2 = mp.jtheta(2, t, q): {t2}")

    t2 = FRealFlint.JacobiTheta2(t, q)
    print(f"t2 = FCplxFlint.JacobiTheta2(t, q): {t2}")

    t2 = BRealFlint.JacobiTheta2(t, q)
    print(f"t2 = BRealFlint.JacobiTheta2(t, q): {t2}")

    print()

    t3 = mp.jtheta(3, t, q)
    print(f"t3 = mp.jtheta(3, t, q): {t3}")

    t3 = FRealFlint.JacobiTheta3(t, q)
    print(f"t3 = FCplxFlint.JacobiTheta3(t, q): {t3}")

    t3 = BRealFlint.JacobiTheta3(t, q)
    print(f"t3 = BRealFlint.JacobiTheta3(t, q): {t3}")

    print()

    t4 = mp.jtheta(4, t, q)
    print(f"t4 = mp.jtheta(4, t, q): {t4}")

    t4 = FRealFlint.JacobiTheta4(t, q)
    print(f"t4 = FCplxFlint.JacobiTheta4(t, q): {t4}")

    t4 = BRealFlint.JacobiTheta4(t, q)
    print(f"t4 = BRealFlint.JacobiTheta4(t, q): {t4}")







def qfromk(k):
    kc = BReal.Sqrt(1-k*k)
    e1 = BRealFlint.EllipticK(k)
    e2 = BRealFlint.EllipticK(kc)
    q = BReal.Exp(-BReal.ConstPi()*e2/e1)
    return q



def tfrom_u_q(u, q):
    t3 = BRealFlint.JacobiTheta3(0.0, q)
    t = u / (t3*t3)
    return t


def jacobi_elliptic():
    print()
    print("jacobi_elliptic():")


    u = 0.4
    print(f"u = 0.4: {u}")
    k = 0.6
    print(f"k = 0.6: {k}")


    q = qfromk(k)
    t = tfrom_u_q(u, q)


    x = mpm.jacobi_sn(u, k)
    print(f"x = mpm.jacobi_sn(u, k): {x}")

    t2 = BRealFlint.JacobiTheta2(0.0, q)
    t3 = BRealFlint.JacobiTheta3(0.0, q)
    tt1 = BRealFlint.JacobiTheta1(t, q)
    tt4 = BRealFlint.JacobiTheta4(t, q)
    sn = (t3*tt1) / (t2*tt4)
    print(f"sn = (t3*t1) / (t2*t4): {sn}")


    x = mpm.jacobi_cn(u, k)
    print(f"x = mpm.jacobi_cn(u, k): {x}")

    t2 = BRealFlint.JacobiTheta2(0.0, q)
    t4 = BRealFlint.JacobiTheta4(0.0, q)
    tt2 = BRealFlint.JacobiTheta2(t, q)
    tt4 = BRealFlint.JacobiTheta4(t, q)
    cn = (t4*tt2) / (t2*tt4)
    print(f"cn = (t4*tt2) / (t2*tt4): {cn}")


    x = mpm.jacobi_dn(u, k)
    print(f"x = mpm.jacobi_dn(u, k): {x}")

    t3 = BRealFlint.JacobiTheta3(0.0, q)
    t4 = BRealFlint.JacobiTheta4(0.0, q)
    tt3 = BRealFlint.JacobiTheta3(t, q)
    tt4 = BRealFlint.JacobiTheta4(t, q)
    dn = (t4*tt3) / (t3*tt4)
    print(f"dn = (t4*tt3) / (t3*tt4): {dn}")






def jacobi_elliptic_2():
    print()
    print("jacobi_elliptic():")

    u = 0.4
    print(f"u = 0.4: {u}")
    k = 0.6
    print(f"k = 0.6: {k}")
    print()

    x = mpm.jacobi_sn(u, k)
    print(f"x = mpm.jacobi_sn(u, k): {x}")

##    x = BRealFlint.JacobiSN(u, k)
##    print(f"x = BRealFlint.JacobiSN(u, k): {x}")


    print()

    x = mpm.jacobi_cn(u, k)
    print(f"x = mpm.jacobi_cn(u, k): {x}")

##    x = BRealFlint.JacobiCN(u, k)
##    print(f"x = BRealFlint.JacobiCN(u, k): {x}")

    print()

    x = mpm.jacobi_dn(u, k)
    print(f"x = mpm.jacobi_dn(u, k): {x}")

##    x = BRealFlint.JacobiDN(u, k)
##    print(f"x = BRealFlint.JacobiDN(u, k): {x}")


    print()

    x = mpm.jacobi_ns(u, k)
    print(f"x = mpm.jacobi_ns(u, k): {x}")

##    x = BRealFlint.JacobiNS(u, k)
##    print(f"x = BRealFlint.JacobiNS(u, k): {x}")


    print()

    x = mpm.jacobi_nc(u, k)
    print(f"x = mpm.jacobi_nc(u, k): {x}")

##    x = BRealFlint.JacobiNC(u, k)
##    print(f"x = BRealFlint.JacobiNC(u, k): {x}")

    print()

    x = mpm.jacobi_nd(u, k)
    print(f"x = mpm.jacobi_nd(u, k): {x}")

##    x = BRealFlint.JacobiND(u, k)
##    print(f"x = BRealFlint.JacobiND(u, k): {x}")

    print()



    x = mpm.jacobi_sc(u, k)
    print(f"x = mpm.jacobi_sc(u, k): {x}")

##    x = BRealFlint.JacobiSC(u, k)
##    print(f"x = BRealFlint.JacobiSC(u, k): {x}")

    print()


    x = mpm.jacobi_sd(u, k)
    print(f"x = mpm.jacobi_sd(u, k): {x}")

##    x = BRealFlint.JacobiSD(u, k)
##    print(f"x = BRealFlint.JacobiSD(u, k): {x}")

    print()



    x = mpm.jacobi_dc(u, k)
    print(f"x = mpm.jacobi_dc(u, k): {x}")

##    x = BRealFlint.JacobiDC(u, k)
##    print(f"x = BRealFlint.JacobiDC(u, k): {x}")

    print()


    x = mpm.jacobi_ds(u, k)
    print(f"x = mpm.jacobi_ds(u, k): {x}")

##    x = BRealFlint.JacobiDS(u, k)
##    print(f"x = BRealFlint.JacobiDS(u, k): {x}")

    print()




    x = mpm.jacobi_cs(u, k)
    print(f"x = mpm.jacobi_cs(u, k): {x}")

##    x = BRealFlint.JacobiCS(u, k)
##    print(f"x = BRealFlint.JacobiCS(u, k): {x}")

    print()


    x = mpm.jacobi_cd(u, k)
    print(f"x = mpm.jacobi_cd(u, k): {x}")

##    x = BRealFlint.JacobiCD(u, k)
##    print(f"x = BRealFlint.JacobiCD(u, k): {x}")

    print()









def real1():
    print()
    print("real1():")

    u = 0.4
    print(f"u = 0.4: {u}")
    k = 0.6
    print(f"k = 0.6: {k}")
    m = k * k
    print(f"m = k * k: {m}")

    x = mpm.jacobi_cd(u, k)
    print(f"x = mpm.jacobi_cd(u, k): {x}")

##    x = MRealBoost.JacobiCD(u, k)
##    print(f"x = MRealBoost.JacobiCD(u, k): {x}")





def real2():
    print()
    print("real2():")

    u = 0.4
    print(f"u = 0.4: {u}")
    k = 0.6
    print(f"k = 0.6: {k}")
    m = k * k
    print(f"m = k * k: {m}")

    x = mpm.melliptic_k(m)
    print(f"x = mpm.melliptic_k(m): {x}")

    x = mpm.elliptic_k(k)
    print(f"x = mpm.elliptic_k(k): {x}")

##    x = MRealBoost.Ellint_1_K(k)
##    print(f"x = MRealBoost.Ellint_1_K(k): {x}")
##
##    x = BRealFlint.EllipticK(k)
##    print(f"x = BRealFlint.EllipticK(k): {x}")


#jacobitheta()

#jacobi_elliptic()
jacobi_elliptic_2()

#real1()
#real2()






