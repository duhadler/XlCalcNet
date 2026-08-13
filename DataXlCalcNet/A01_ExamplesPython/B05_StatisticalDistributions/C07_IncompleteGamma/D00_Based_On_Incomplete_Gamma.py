# -*- coding: utf-8 -*-

from xlcalcnet import mpm


def demo_rv_amoroso_MISSING():
    print("Test demo_rv_amoroso_MISSING")



def demo_rv_chi():
    print("Test demo_rv_chi")
    mpm.dps = 30

    nu = 10
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_chi(nu)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.chi_pdf(x, nu)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.chi_cdf(x, nu, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.chi_cdf(x, nu, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.chi_qtf(q, nu, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.chi_qtf(q, nu, False)
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



def demo_rv_chi2():
    print("Test demo_rv_chi2")
    mpm.dps = 30

    nu = 10
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_chi2(nu)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.chi2_pdf(x, nu)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.chi2_cdf(x, nu, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.chi2_cdf(x, nu, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.chi2_qtf(q, nu, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.chi2_qtf(q, nu, False)
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



def demo_rv_logrv_chisquared():
    print("Test demo_rv_chi2")
    mpm.dps = 30

    nu = 10
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_logrv_chisquared(nu)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.logchisquare_pdf(x, nu)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.logchisquare_cdf(x, nu, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.logchisquare_sf(x, nu, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.logchisquare_qtf(q, nu, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.logchisquare_isf(q, nu, False)
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



def demo_rv_gamma():
    print("Test demo_rv_gamma")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_gamma(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.gamma_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.gamma_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.gamma_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.gamma_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.gamma_qtf(q, a, b, False)
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




def demo_rv_hypoexp():
    print("Test demo_rv_hypoexp")
    mpm.dps = 30

    n = 10
    l = 5
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_hypoexp(n, l)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.hypoexp_pdf(x, n, l)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.hypoexp_cdf(x, n, l, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.hypoexp_cdf(x, n, l, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.hypoexp_qtf(q, n, l, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.hypoexp_qtf(q, n, l, False)
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


def demo_rv_invchisquared_MISSING():
    print("Test demo_rv_invchisquared_MISSING")


def demo_rv_invgamma():
    print("Test demo_rv_invgamma")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_invgamma(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.invgamma_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.invgamma_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.invgamma_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.invgamma_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.invgamma_qtf(q, a, b, False)
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


def demo_rv_maxwell():
    print("Test demo_rv_maxwell")
    mpm.dps = 30

    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_maxwell(b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.maxwell_pdf(x, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.maxwell_cdf(x, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.maxwell_cdf(x, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.maxwell_qtf(q, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.maxwell_qtf(q, b, False)
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


def demo_rv_lindley_MISSING():
    print("Test demo_rv_lindley_MISSING")



def demo_rv_nakagami():
    print("Test demo_rv_nakagami")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_nakagami(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nakagami_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nakagami_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.nakagami_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.nakagami_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.nakagami_qtf(q, a, b, False)
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



def demo_rv_skew_exp_power_MISSING():
    print("Test demo_rv_skew_exp_power_MISSING")



def demo_rv_stacy_MISSING():
    print("Test demo_rv_stacy_MISSING")




#demo_rv_amoroso_MISSING()
#demo_rv_chi()
demo_rv_chi2()
#demo_rv_logrv_chisquared()
#demo_rv_gamma()
#demo_rv_hypoexp()
#demo_rv_invchisquared_MISSING()
#demo_rv_invgamma()
#demo_rv_maxwell()
#demo_rv_lindley_MISSING()
#demo_rv_nakagami()
#demo_rv_skew_exp_power_MISSING()
#demo_rv_stacy_MISSING()




