# -*- coding: utf-8 -*-

from xlcalcnet import mpm


def demo_rv_arcsine():
    print("Test demo_rv_arcsine")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_arcsine(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.arcsine_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.arcsine_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.arcsine_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.arcsine_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.arcsine_qtf(q, a, b, False)
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


def demo_rv_cauchy():
    print("Test demo_rv_cauchy")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_cauchy(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.cauchy_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.cauchy_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.cauchy_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.cauchy_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.cauchy_qtf(q, a, b, False)
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



def demo_rv_dagum():
    print("Test demo_rv_dagum")
    mpm.dps = 30

    a = 1.0
    b = 1.1
    p = 1.2
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_dagum(a, b, p)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.dagum_pdf(x, a, b, p)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.dagum_cdf(x, a, b, p, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.dagum_cdf(x, a, b, p, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.dagum_qtf(q, a, b, p, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.dagum_qtf(q, a, b, p, False)
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




def demo_rv_exponential():
    print("Test demo_rv_exponential")
    mpm.dps = 30

    lambda1 = 2
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_exponential(lambda1)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.exponential_pdf(x, lambda1)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.exponential_cdf(x, lambda1, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.exponential_cdf(x, lambda1, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.exponential_qtf(q, lambda1, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.exponential_qtf(q, lambda1, False)
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



def demo_rv_fisk():
    print("Test demo_rv_fisk")
    mpm.dps = 30

    a = 0.5
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_fisk(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.fisk_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.fisk_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.fisk_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.fisk_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.fisk_qtf(q, a, b, False)
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



def demo_rv_frechet():
    print("Test demo_rv_frechet")
    mpm.dps = 30

    a = 0.5
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_frechet(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.frechet_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.frechet_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.frechet_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.frechet_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.frechet_qtf(q, a, b, False)
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




def demo_rv_gev_MISSING():
    print("Test demo_rv_gev_MISSING")
    return



def demo_rv_genpareto():
    print("Test demo_rv_genpareto")
    mpm.dps = 30

    m = 0.5
    s = 1
    c = 2
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_genpareto(m, s, c)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.genpareto_pdf(x, m, s, c)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.genpareto_cdf(x, m, s, c, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.genpareto_cdf(x, m, s, c, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.genpareto_qtf(q, m, s, c, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.genpareto_qtf(q, m, s, c, False)
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



def demo_rv_gompertz():
    print("Test demo_rv_gompertz")
    mpm.dps = 30

    a = 0.5
    b = 1
    l = 2
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_gompertz(a, b, l)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.gompertz_pdf(x, a, b, l)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.gompertz_cdf(x, a, b, l, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.gompertz_cdf(x, a, b, l, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.gompertz_qtf(q, a, b, l, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.gompertz_qtf(q, a, b, l, False)
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



def demo_rv_gumbel():
    print("Test demo_rv_gumbel")
    mpm.dps = 30

    a = 0
    b = 1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_gumbel(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.gumbel_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.gumbel_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.gumbel_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.gumbel_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.gumbel_qtf(q, a, b, False)
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




def demo_rv_hyperexponential():
    print("Test demo_rv_hyperexponential")
    mpm.dps = 30

    k = 4
    w = [12, 5, 7, 8]
    l = [11.1,1,3,4]

    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_hyperexponential(k, w, l)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.hyperexp_pdf(x, k, w, l)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.hyperexp_cdf(x, k, w, l, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.hyperexp_cdf(x, k, w, l, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.hyperexp_qtf(q, k, w, l, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.hyperexp_qtf(q, k, w, l, False)
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



def demo_rv_kumaraswamy():
    print("Test demo_rv_kumaraswamy")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_kumaraswamy(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.kumaraswamy_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.kumaraswamy_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.kumaraswamy_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.kumaraswamy_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.kumaraswamy_qtf(q, a, b, False)
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



def demo_rv_laplace():
    print("Test demo_rv_laplace")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_laplace(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.laplace_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.laplace_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.laplace_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.laplace_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.laplace_qtf(q, a, b, False)
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



def demo_rv_logistic():
    print("Test demo_rv_logistic")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_logistic(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.logistic_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.logistic_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.logistic_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.logistic_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.logistic_qtf(q, a, b, False)
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





def demo_rv_lomax():
    print("Test demo_rv_lomax")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_lomax(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.lomax_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.lomax_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.lomax_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.lomax_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.lomax_qtf(q, a, b, False)
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




def demo_rv_rayleigh():
    print("Test demo_rv_rayleigh")
    mpm.dps = 30

    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_rayleigh(b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.rayleigh_pdf(x, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.rayleigh_cdf(x, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.rayleigh_cdf(x, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.rayleigh_qtf(q, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.rayleigh_qtf(q, b, False)
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




def demo_rv_shifted_gompertz():
    print("Test demo_rv_shifted_gompertz")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_shifted_gompertz(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.shifted_gompertz_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.shifted_gompertz_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.shifted_gompertz_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.shifted_gompertz_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.shifted_gompertz_qtf(q, a, b, False)
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



def demo_rv_triangular():
    print("Test demo_rv_triangular")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    c = 1.3
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_triangular(a, b, c)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.triangular_pdf(x, a, b, c)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.triangular_cdf(x, a, b, c, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.triangular_cdf(x, a, b, c, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.triangular_qtf(q, a, b, c, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.triangular_qtf(q, a, b, c, False)
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




def demo_rv_uniform():
    print("Test demo_rv_uniform")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_uniform(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.uniform_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.uniform_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.uniform_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.uniform_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.uniform_qtf(q, a, b, False)
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



def demo_rv_weibull():
    print("Test demo_rv_weibull")
    mpm.dps = 30

    a = 0.5
    b = 1.1
    x = 0.75
    q = 0.8
    t = 0.5

    rv = mpm.dist_weibull(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.weibull_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.weibull_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.weibull_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.weibull_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.weibull_qtf(q, a, b, False)
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


#demo_rv_arcsine()
#demo_rv_cauchy()
#demo_rv_dagum()
#demo_rv_exponential()
#demo_rv_fisk()
#demo_rv_frechet()
#demo_rv_gev_MISSING()
#demo_rv_genpareto()
#demo_rv_gompertz()
#demo_rv_gumbel()
#demo_rv_hyperexponential()
#demo_rv_kumaraswamy()
#demo_rv_laplace()
#demo_rv_logistic()
#demo_rv_lomax()
#demo_rv_pareto()
#demo_rv_rayleigh()
#demo_rv_shifted_gompertz()
#demo_rv_singh_maddala()
#demo_rv_triangular()
#demo_rv_uniform()
demo_rv_weibull()






