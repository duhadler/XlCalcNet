# -*- coding: utf-8 -*-

from xlcalcnet import mpm


def demo_rv_birnb_saunders_MISSING():
    print("Test demo_rv_birnb_saunders_MISSING")


def demo_rv_emg_MISSING():
    print("Test demo_rv_emg_MISSING")


def demo_rv_folded_normal_MISSING():
    print("Test demo_rv_folded_normal_MISSING")


def demo_rv_half_normal_MISSING():
    print("Test demo_rv_half_normal_MISSING")


def demo_rv_johnson_sb_MISSING():
    print("Test demo_rv_johnson_sb_MISSING")


def demo_rv_johnson_su_MISSING():
    print("Test demo_rv_johnson_su_MISSING")


def demo_rv_levy():
    print("Test demo_rv_levy")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_levy(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.levy_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.levy_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.levy_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.levy_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.levy_qtf(q, a, b, False)
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



def demo_rv_lognormal():
    print("Test demo_rv_lognormal")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_lognormal(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.lognormal_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.lognormal_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.lognormal_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.lognormal_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.lognormal_qtf(q, a, b, False)
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



def demo_rv_moyal():
    print("Test demo_rv_moyal")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_moyal(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.moyal_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.moyal_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.moyal_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.moyal_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.moyal_qtf(q, a, b, False)
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



def demo_rv_normal():
    print("Test demo_rv_normal")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_normal(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.normal_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.normal_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.normal_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.normal_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.normal_qtf(q, a, b, False)
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




def demo_rv_normal_max():
    print("Test demo_rv_normal_max")
    mpm.dps = 30

    k = 3
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_normal_max(k)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nmax_pdf(x, k)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nmax_cdf(x, k, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.nmax_cdf(x, k, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.nmax_qtf(q, k, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.nmax_qtf(q, k, False)
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




def demo_rv_normal_maxmod():
    print("Test demo_rv_normal_maxmod")
    mpm.dps = 30

    k = 3
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_normal_maxmod(k)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nmm_pdf(x, k)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nmm_cdf(x, k, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.nmm_cdf(x, k, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.nmm_qtf(q, k, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.nmm_qtf(q, k, False)
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



def demo_rv_sasnormal_MISSING():
    print("Test demo_rv_sasnormal_MISSING")



def demo_rv_skewnormal():
    print("Test demo_rv_skewnormal")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    c = 1.3
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_skewnormal(a, b, c)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.skewnormal_pdf(x, a, b, c)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.skewnormal_cdf(x, a, b, c, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.skewnormal_cdf(x, a, b, c, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.skewnormal_qtf(q, a, b, c, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.skewnormal_qtf(q, a, b, c, False)
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



def demo_rv_trunc_normal_MISSING():
    print("Test demo_rv_trunc_normal_MISSING")




def demo_rv_wald():
    print("Test demo_rv_wald")
    mpm.dps = 30

    a = 1.0
    b = 2.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_wald(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.wald_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.wald_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.wald_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.wald_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.wald_qtf(q, a, b, False)
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




# demo_rv_birnb_saunders_MISSING()
# demo_rv_emg_MISSING()
# demo_rv_folded_normal_MISSING()
# demo_rv_half_normal_MISSING()
# demo_rv_johnson_sb_MISSING()
# demo_rv_johnson_su_MISSING()
#demo_rv_levy()
#demo_rv_lognormal()
#demo_rv_moyal()
#demo_rv_normal()
#demo_rv_normal_max()
#demo_rv_normal_maxmod()
#demo_rv_sasnormal_MISSING()
#demo_rv_skewnormal()
#demo_rv_trunc_normal_MISSING()
demo_rv_wald()











