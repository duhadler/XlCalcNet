# -*- coding: utf-8 -*-

from xlcalcnet import mpm

from xlcalcnet.ctx12Asymptotic import ctxAsymptotic


def demo_rv_geometric_MISSING():
    print("Test demo_rv_geometric_MISSING")


def demo_rv_logseries_MISSING():
    print("Test demo_rv_logseries_MISSING")


def demo_rv_poisson():
    print("Test demo_rv_poisson, part1")
    mpm.dps = 30
    count = 60
    lambda1 = 11.2
    pv = mpm.poisson_pmf_vector(lambda1, count)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    rv = mpm.dist_poisson(lambda1)
    pv = rv.pmf_vector(count)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    print()
    print("Test demo_rv_poisson, part2")
    def demo_poisson_cumulants(ctx):
        mpm.dps = 30
        mu = 100
        rmax = 14

        mfac = mpm.matrix(rmax+1, 1)
        for r in range(0, rmax+1):
            mfac[r] = mu**r
            print("r:", r, "mfac[r]:", mfac[r])

        mraw = mpm.rawmoments_from_factorialmoments(mfac)
        for r in range(1, rmax+1):
            print("r:", r, "mraw[r]:", mraw[r])

        kappa2 = mpm.cumulants_from_rawmoments(mraw)
        for r in range(1, rmax+1):
            print("r:", r, "kappa2[r]:", kappa2[r])

        kappa3 = mpm.cumulants_from_rawmoments(mraw)
        for r in range(1, rmax+1):
            print("r:", r, "kappa3[r]:", kappa3[r])

        kappa = ctxAsymptotic().poisson_cumulants(mpm, mu, rmax)
        for r in range(1, rmax+1):
            print("r:", r, "kappa[r]:", kappa[r])

    demo_poisson_cumulants(mpm)

    return



def demo_rv_skellam_MISSING():
    print("Test demo_rv_skellam_MISSING")


def demo_rv_binomial():
    print("Test demo_rv_binomial, part1")
    count = 100
    n = 120
    p = 0.2
    pv = mpm.binomial_pmf_vector(n, p)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    rv = mpm.dist_binomial(n, p)
    pv = rv.pmf_vector(count)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    print()
    print("Test demo_rv_binomial, part2")
    def demo_binomial_cumulants(ctx):
        n = 100
        p = 0.5
        rmax = 10

        mfac = mpm.matrix(rmax+1, 1)
        for r in range(0, rmax+1):
            mfac[r] = p**r * mpm.factorial(n)/mpm.factorial(n-r)
            print("r:", r, "mfac[r]:", mfac[r])

        kappa2 = mpm.cumulants_from_factorialmoments(mfac)
        for r in range(1, rmax+1):
            print("r:", r, "kappa2[r]:", kappa2[r])

        kappa = ctxAsymptotic().binomial_cumulants(mpm, n, p, rmax)
        for r in range(1, rmax):
            print("r:", r, "kappa[r]:", kappa[r])
        return

    demo_binomial_cumulants(mpm)


    print()
    print("Test demo_rv_binomial, part3")

    def demo_binomial_kderiv(ctx):
        mpm.dps = 20
        n = 100
        p = 0.5
        t = 0.2
        order = 4
        res = ctxAsymptotic().binomial_kderiv(mpm, order, t, n, p)
        print(res)

    demo_binomial_kderiv(mpm)
    return




def demo_rv_negative_binomial():
    print("Test demo_rv_negative_binomial, part1")
    count = 160
    r = 15
    p = 0.2
    pv = mpm.negbinom_pmf_vector(r, p, count)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    rv = mpm.dist_negative_binomial(r, p)
    pv = rv.pmf_vector(count)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    print()
    print("Test demo_rv_negative_binomial, part2")
    def demo_negbinom_cumulants(ctx):
        r = 10
        p = 0.5
        jmax = 10
        kappa = ctxAsymptotic().negbinom_cumulants(mpm, r, p, jmax)
        for j in range(1, jmax):
            print("j:", j, "kappa[j]:", kappa[j])
        return

    demo_negbinom_cumulants(mpm)

    print()
    print("Test demo_rv_negative_binomial, part3")
    def demo_negbinomial_kderiv(ctx):
        mpm.dps = 20
        r = 100
        p = 0.5
        t = 0.2
        order = 4
        res = ctxAsymptotic().negbinomial_kderiv(mpm, order, t, r, p)
        print(res)

    demo_negbinomial_kderiv(mpm)

    return



def demo_rv_delaporte_MISSING():
    print("Test demo_rv_delaporte_MISSING")


def demo_rv_betapoisson_MISSING():
    print("Test demo_rv_betapoisson_MISSING")


def demo_rv_betabinomial_MISSING():
    print("Test demo_rv_betabinomial_MISSING")


def demo_rv_beta_negbinomial_MISSING():
    print("Test demo_rv_beta_negbinomial_MISSING")


def demo_rv_hypergeometric():
    print("Test demo_rv_hypergeometric, part1")
    n = 300
    K = 70
    N = 500
    rv = mpm.dist_hypergeometric(n, K, N)
    pv = rv.pmf_vector(100)
    for k in range(pv.rows):
        print("k:", k, "pv[k]:", pv[k])

    print("in demo_hypergeo")
    k = 45
    K = 70
    n = 300
    N = 500
#        pdf = fpm.hypergeo_pmf(k, K, n, N)
#        print("pdf :", pdf)
#        cdf = fpm.hypergeo_cdf(k, K, n, N)
#        print("cdf :", cdf)

    t1 = mpm.binomial(K, k)
    t2 = mpm.binomial(N-K, n-k)
    t3 = mpm.binomial(N, n)
    mpm1 = t1*t2/t3
    print("mpm1:", mpm1)

    t1 = mpm.binomial(n, k+1)
    t2 = mpm.binomial(N-n, K-k-1)
    t3 = mpm.binomial(N, K)
    mpm2 = t1*t2/t3
    print("mpm2:", mpm2)
#        pdf2 = fpm.hypergeo_pmf(k+1, K, n, N)
#        print("pdf2:", pdf2)

    t4 = mpm.hyp3f2(1, k+1-K, k+1-n, k+2, N+k+2-K-n, 1)
    print("t4:", t4)
    cdf2 = 1-mpm2*t4
    print("cdf2:", cdf2)

    print()
    print("Test demo_rv_hypergeometric, part2")

    def demo_hypergeo_rawmoments(ctx):
        mpm.dps = 30
        M = 450
        n = 10
        NN = 500
        rmax = 8

        mfac = mpm.matrix(rmax+1, 1)
        for r in range(1, rmax+1):
            sum1 = 0
            sum1 = mpm.factorial(r)
            sum1 = sum1 * mpm.binomial(M, r)*mpm.binomial(n, r)
            sum1 = sum1 / mpm.binomial(NN, r)
            mfac[r] = sum1
            print("r:", r, "mfac[r]:", mfac[r])

        mraw = mpm.rawmoments_from_factorialmoments(mfac)
        for r in range(1, rmax+1):
            print("r:", r, "mraw[r]:", mraw[r])

        mu = ctxAsymptotic().hypergeo_rawmoments(mpm, M, n, NN, rmax)
        for i in range(1, rmax+1):
            print("i:", i, "mu(i):", mu[i])

        kappa = mpm.cumulants_from_rawmoments(mraw)
        for i in range(1, rmax+1):
            print("i:", i, "kappa(i):", kappa[i])

        mraw2 = mpm.rawmoments_from_cumulants(kappa)
        for i in range(1, rmax+1):
            print("i:", i, "mraw2(i):", mraw2[i])

        mfac2 = mpm.factorialmoments_from_rawmoments(mraw)
        for r in range(1, rmax+1):
            print("r:", r, "mfac2[r]:", mfac2[r])

    def demo_hypergeo_cumulants(ctx):
        mpm.dps = 30
        M = 450
        n = 10
        NN = 500
        rmax = 8

        mfac = mpm.matrix(rmax+1, 1)
        for r in range(1, rmax+1):
            sum1 = 0
            sum1 = mpm.factorial(r)
            sum1 = sum1 * mpm.binomial(M, r)*mpm.binomial(n, r)
            sum1 = sum1 / mpm.binomial(NN, r)
            mfac[r] = sum1
            print("r:", r, "mfac[r]:", mfac[r])

        kappa2 = mpm.cumulants_from_factorialmoments(mfac)
        for r in range(1, rmax+1):
            print("r:", r, "kappa2[r]:", kappa2[r])

        kappa = ctxAsymptotic().hypergeo_cumulants(mpm, M, n, NN, rmax)
        for i in range(1, rmax+1):
            print("i:", i, "kappa(i):", kappa[i])
        return

    demo_hypergeo_rawmoments(mpm)
    demo_hypergeo_cumulants(mpm)

    print()
    print("Test demo_rv_hypergeometric, part3")

    def demo_hypergeo_kderiv(ctx):
        mpm.dps = 20
        t = 0.75
        n = 30
        K = 100
        N = 300
        res = ctxAsymptotic().hypergeo_kderiv(mpm, t, n, K, N)

        print("RESULT:")
        print(res)
        print()

        for i in range(0, 9):
            print(i, res[i])
            H = ctxAsymptotic().hypergeo_cgf_diff(mpm, t, n, K, N, i)
            print(i, H, (H-res[i])/H)

    demo_hypergeo_kderiv(mpm)
    return



def demo_rv_neghypergeo_MISSING():
    print("Test demo_rv_neghypergeo_MISSING")


def demo_rv_polya_MISSING():
    print("Test demo_rv_polya_MISSING")


def demo_rv_genhypergeo_MISSING():
    print("Test demo_rv_genhypergeo_MISSING")



def demo_rv_hypergeo_nc_fisher_MISSING():
    print("Test demo_rv_hypergeo_nc_fisher_MISSING")


def demo_rv_zeta_MISSING():
    print("Test demo_rv_zeta_MISSING")


#demo_rv_geometric_MISSING()
#demo_rv_logseries_MISSING()
#demo_rv_poisson()
#demo_rv_skellam_MISSING()

#demo_rv_binomial()
#demo_rv_negative_binomial()
#demo_rv_delaporte_MISSING()
#demo_rv_betapoisson_MISSING()

#demo_rv_betabinomial_MISSING()
#demo_rv_beta_negbinomial_MISSING()
demo_rv_hypergeometric()
#demo_rv_neghypergeo_MISSING()

#demo_rv_polya_MISSING()
#demo_rv_genhypergeo_MISSING()
#demo_rv_hypergeo_nc_fisher_MISSING()
#demo_rv_zeta_MISSING()













