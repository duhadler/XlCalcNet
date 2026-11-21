# -*- coding: utf-8 -*-

from xlcalcnet import mpm



def demo_rv_singh_maddala():
    print("Test demo_rv_singh_maddala")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    d = 1.3
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_singh_maddala(a, b, d)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.singh_maddala_pdf(x, a, b, d)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.singh_maddala_cdf(x, a, b, d, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.singh_maddala_cdf(x, a, b, d, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.singh_maddala_qtf(q, a, b, d, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.singh_maddala_qtf(q, a, b, d, False)
    print("isf:", res2)

    res = rv.c_x(t)
    print("c_x:", res)

    res = rv.m_x(t)
    print("m_x:", res)

    res = rv.k_x(t)
    print("k_x:", res)

    res = rv.saddleppoint(x)
    print("saddleppoint:", res)

    res = rv.moments(6)
    print("moments:", res)

    res = rv.support()
    print("support:", res)

    res = rv.range()
    print("range:", res)
    return






demo_rv_singh_maddala()




