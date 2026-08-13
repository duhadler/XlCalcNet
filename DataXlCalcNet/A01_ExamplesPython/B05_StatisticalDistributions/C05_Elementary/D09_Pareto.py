# -*- coding: utf-8 -*-

from xlcalcnet import mpm



def demo_rv_pareto():
    print("Test demo_rv_pareto")
    mpm.dps = 30

    k = 0.5
    a = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_pareto(k, a)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.pareto_pdf(x, k, a)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.pareto_cdf(x, k, a, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.pareto_cdf(x, k, a, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.pareto_qtf(q, k, a, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.pareto_qtf(q, k, a, False)
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







demo_rv_pareto()





