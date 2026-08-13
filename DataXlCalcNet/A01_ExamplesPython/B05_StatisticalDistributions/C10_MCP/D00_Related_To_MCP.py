# -*- coding: utf-8 -*-

from xlcalcnet import mpm



##def demo_chidens(ctx):
##    mpm.dps = 30
##    x = mpm.mpf("2.462")
##    n = 400
##    res1 = mpm.sqrt(n)*mpm.chi_pdf(mpm.sqrt(n)*x, n)
##    print("res1: ", res1)
##    res2 = mpm.chidens(x, n)
##    print("res2: ", res2)
##    return



def demo_rv_nmax_neg_corr_nair():
    print("Test demo_rv_nmax_neg_corr_nair")
    # Nair 1948, Table 1.
    # Grubbs 1950, TABLE II, page 31 - 37
    # Grubbs 1950, TABLE III, page 45

    mpm.dps = 15
    k = 6
    x = 2.18 * mpm.sqrt((k)/(k-1))
    rho = -mpm.t(1)/(k-1)
    print("rho: ", rho)

    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.negative_rho_cdf(x)
    print("cdf, rv:", res)
    res2 = mpm.nmax_corr_negative_rho_cdf(x, k, rho)
    print("cdf, mpm:", res2)




def demo_rv_nmax_neg_corr():
    print("Test demo_rv_nmax_neg_corr")

    mpm.dps = 15
    k = 5
    x = 2.08
    rho = -mpm.t(1)/(k-1)
    print("rho: ", rho)

    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.negative_rho_cdf(x)
    print("cdf, rv:", res)
    res2 = mpm.nmax_corr_negative_rho_cdf(x, k, rho)
    print("cdf, mpm:", res2)


def demo_rv_nmm_neg_corr():
    print("Test demo_rv_nmm_neg_corr")

    mpm.dps = 15
    k = 5
    x = 2.56
    x = 3.08
    rho = -mpm.t(1)/(k-1)
    print("k:", k, " x:", x, " rho: ", rho)

    rv = mpm.dist_nmm_corr(k, rho)
    res = rv.negative_rho_cdf(x)
    print("cdf, rv:", res)
    res2 = mpm.nmm_corr_negative_rho_cdf(x, k, rho)
    print("cdf, mpm:", res2)




def demo_rv_nmax_corr():
    print("Test demo_rv_nmax_corr")
    print("Multivariate normal, equicorrelated, 1-sided")
    # Hochberg 1987, page 381

    mpm.dps = 15

    k = 8
    x = 2.381
    rho = 0.0

    print("rho: ", rho)
    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nmax_corr_pdf(x, k, rho)
    print("pdf:", res2)

    print("rho: ", rho)
    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nmax_corr_cdf(x, k, rho)
    print("cdf:", res2)

    k = 8
    x = 2.381
    rho = 0.5

    print("rho: ", rho)
    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nmax_corr_pdf(x, k, rho)
    print("pdf:", res2)


    rho = 0.5
    print("rho: ", rho)
    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nmax_corr_cdf(x, k, rho)
    print("cdf:", res2)

    mpm.dps = 15
    k = 5
    x = 2.08
    rho = -mpm.t(1)/(k-1)
    print("rho: ", rho)

    rv = mpm.dist_nmax_corr(k, rho)
    res = rv.negative_rho_cdf(x)
    print("cdf:", res)
    res2 = mpm.nmax_corr_negative_rho_cdf(x, k, rho)
    print("cdf:", res2)


def demo_rv_nmm_corr():
    print("Test demo_rv_nmm_corr")
    print("Multivariate normal, equicorrelated, 2-sided")
    # Hochberg 1987, page 382

    mpm.dps = 15

    k = 6
    x = 2.567
    rho = 0.5

    rv = mpm.dist_nmm_corr(k, rho)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nmm_corr_pdf(x, k, rho)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nmm_corr_cdf(x, k, rho)
    print("cdf:", res2)

    k = 10
# scale used by Nelson
    x = 3.29
    rho = -1/(k-1)
    print("rho:", rho)
    rv = mpm.dist_nmm_corr(k, rho)
    res = rv.negative_rho_cdf(x)
    print("negative_rhocdf:", res)
    res2 = mpm.nmm_corr_negative_rho_cdf(x, k, rho)
    print("negative_rhocdf:", res2)




def demo_rv_normal_range_old():
    print("Test demo_rv_normal_range")
    mpm.dps = 15

    k = 4
    x = 3.240

    rv = mpm.dist_normal_range(k)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.nrange_pdf(x, k)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.nrange_cdf(x, k)
    print("cdf:", res2)



def demo_rv_normal_range():
    print("Test demo_rv_normal_range")
    mpm.dps = 15

    k = 4
    x = 3.240

    res2 = mpm.nrange_pdf(x, k)
    print("pdf:", res2)
    #mpm.plot(lambda x: mpm.nrange_pdf(x, k), [0, 5])

##    res = rv.cdf(x)
##    print("cdf:", res)
    res2 = mpm.nrange_cdf(x, k)
    print("cdf:", res2)


def demo_rv_smax():
    print("Test demo_rv_smax")
    mpm.dps = 15

    k = 8
    x = 3.444
    n = 20
##    n = 1
##    n = 10000

##    rv = mpm.dist_smax(k, n)
##    res = rv.pdf(x)
##    print("pdf:", res)
    res2 = mpm.smax_pdf(x, k, n)
    print("pdf:", res2)

##    res = rv.cdf(x)
##    print("cdf:", res)
    res2 = mpm.smax_cdf(x, k, n)
    print("cdf:", res2)
##    res3 = mpm.smax_cdf(x+1E-9, k, n)
##    print("cdf:", res3)
##    res4 = (res3-res2)/1E-9
##    print("pdf:", res4)



def demo_rv_smm():
    print("Test demo_rv_smm")
    mpm.dps = 15

    k = 8
    x = 2.691
    n = 20

    rv = mpm.dist_smm(k, n)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.smm_pdf(x, k, n)
    print("pdf:", res2)

    k = 8
    x = 2.691
    n = 20

    rv = mpm.dist_smm(k, n)
    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.smm_cdf(x, k, n)
    print("cdf:", res2)




def demo_rv_dunnett1_t():
    print("Test demo_rv_dunnett1_t")
    mpm.dps = 15

    k = 8
    x = 3.337
    n = 20
    rho = 0.5

    rv = mpm.dist_dunnett1_t(k, n, rho)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.dunnett1_pdf(x, k, n, rho)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.dunnett1_cdf(x, k, n, rho)
    print("cdf:", res2)




def demo_rv_dunnett2_t():
    print("Test demo_rv_dunnett2_t")
    mpm.dps = 15

    k = 8
    x = 3.651
    n = 20
    rho = 0.5

    rv = mpm.dist_dunnett2_t(k, n, rho)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.dunnett2_pdf(x, k, n, rho)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.dunnett2_cdf(x, k, n, rho)
    print("cdf:", res2)


def demo_nair_t_cdf():
    print("Test demo_nair_t_cdf")
    # Nair 1948, Table 6.
    mpm.dps = 7
    k = 5
    n = 20
    x = 2.26 * mpm.sqrt((k)/(k-1))
    rho = -mpm.t(1)/(k-1)  # maximal negative rho
    print("k:", k, " x:", x, " rho: ", rho)

    res2 = mpm.nair1_cdf(x, k, n, rho)
    print("cdf, mpm:", res2)


def demo_halperin_t_cdf():
    print("Test demo_halperin_t_cdf")
    # print("Halperin 1955: Table 1")
    mpm.dps = 7
    k = 5
    n = 20
    x = 2.50 * mpm.sqrt((k)/(k-1))
    rho = -mpm.t(1)/(k-1)
    print("k:", k, " x:", x, " rho: ", rho)

    res2 = mpm.nelson2_cdf(x, k, n, rho)
    print("cdf, mpm:", res2)


def demo_nelson_t_cdf():
    print("Test demo_nelson_t_cdf")
    # print("Ryan 2007: Modern experimental design (ANOM), page 573")
    mpm.dps = 7
    k = 5
    n = 20
    x = 3.53
    rho = -mpm.t(1)/(k-1)  # maximal negative rho
    print("k:", k, " x:", x, " rho: ", rho)

    res2 = mpm.nelson2_cdf(x, k, n, rho)
    print("cdf, mpm:", res2)



def demo_rv_studentized_range():
    print("Test demo_rv_studentized_range")
    mpm.dps = 15

    k = 4
    x = 3.462
    n = 20

    rv = mpm.dist_studentized_range(k, n)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.srange_pdf(x, k, n)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.srange_cdf(x, k, n)
    print("cdf:", res2)



#demo_chidens(mpm)

#demo_rv_nmax_corr()
#demo_rv_nmax_neg_corr()
#demo_rv_nmax_neg_corr_nair()

#demo_rv_nmm_corr()
#demo_rv_nmm_neg_corr()

#demo_nair_t_cdf()
#demo_nelson_t_cdf()
#demo_halperin_t_cdf()

#demo_rv_normal_range()
demo_rv_smax()
#demo_rv_smm()
#demo_rv_dunnett1_t()
#demo_rv_dunnett2_t()
#demo_rv_studentized_range()




















