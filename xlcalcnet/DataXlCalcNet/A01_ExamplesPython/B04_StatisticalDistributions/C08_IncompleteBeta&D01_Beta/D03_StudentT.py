# -*- coding: utf-8 -*-

from xlcalcnet import mpm



def demo_rv_student_t():
    print("Test demo_rv_student_t")
    mpm.dps = 30

    n = 10
    x = 2.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_student_t(n)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.student_t_pdf(x, n)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.student_t_cdf(x, n, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.student_t_cdf(x, n, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.student_t_qtf(q, n, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.student_t_qtf(q, n, False)
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






demo_rv_student_t()











