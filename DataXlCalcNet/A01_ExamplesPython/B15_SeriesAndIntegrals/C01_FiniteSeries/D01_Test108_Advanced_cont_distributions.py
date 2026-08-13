# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm, dpm

useplot = False

# Advanced continuous distribution functions




# 6.3 Noncentral Distributions
def demo_6_3_noncentral(ctx):


    # 6.3.1 Noncentral chi^2-distribution, pdf

    def demo_chi2_nc_pdf(ctx):
        x = 11
        n = 11
        nc = 15
        mpm.dps = 30
    #        print("Boost double precision")
    #        L1 = fpm.chi2_nc_pdf(x, n, nc)
    #        print("L1:", L1)
        print("default")
        L2 = mpm.chi2_nc_pdf(x, n, nc, 'default')
        print("L2:", L2)

        print("bessel")
        L2 = mpm.chi2_nc_pdf(x, n, nc, 'bessel')
        print("L2:", L2)

        print("hyper")
        L2 = mpm.chi2_nc_pdf(x, n, nc, 'hyper')
        print("L2:", L2)


    # 6.3.2 Noncentral chi^2-distribution, cdf

    def demo_chi2_nc_cdf(ctx):
        print("demo_chi2_nc_cdf")
        x = 11
        n = 11
        nc = 15
        mpm.dps = 30
    #        print("Boost double precision")
    #        L1 = fpm.chi2_nc_cdf(x, n, nc)
    #        print("L1:", L1)

        print("default")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'default')
        print("L2:", L2)

        print("benton")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'benton')
        print("L2:", L2)

        print("chou")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'chou')
        print("L2:", L2)

        print("cohen")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'cohen')
        print("L2:", L2)

        print("ecf")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'ecf')
        print("L2:", L2)

        print("spa")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'spa')
        print("L2:", L2)

        print("penev")
        L2 = mpm.chi2_nc_cdf(x, n, nc, True, 'penev')
        print("L2:", L2)

        print()

    #        print("Boost double precision")
    #        R1 = fpm.chi2_nc_cdf(x, n, nc, False)
    #        print("R1:", R1)

        print("default")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'default')
        print("R2:", R2)

        print("benton")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'benton')
        print("R2:", R2)

        print("chou")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'chou')
        print("R2:", R2)

        print("cohen")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'cohen')
        print("R2:", R2)

        print("ecf")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'ecf')
        print("R2:", R2)

        print("spa")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'spa')
        print("R2:", R2)

        print("penev")
        R2 = mpm.chi2_nc_cdf(x, n, nc, False, 'penev')
        print("R2:", R2)
        return



    # 6.3.12 Non-central Student 𝑡 distribution: pdf (Witkovsky2013)

    def demo_student_t_nc_pdf(ctx):
        x = 4
        n = 10
        delta = 2
        res1 = mpm.student_t_nc_pdf(x, n, delta)
        print(res1)
    #        res2 = fpm.student_t_nc_pdf(x, n, delta)
    #        print(res2)


    # 6.3.13 Non-central Student 𝑡 distribution: cdf and sf

    def demo_student_t_nc_cdf(ctx):
        x = 11
        n = 20
        delta = 5.0
        mpm.dps = 30

    #        L1 = fpm.student_t_nc_cdf(x, n, delta, True)
    #        print("L1:", L1)

        print("default")
        L2 = mpm.student_t_nc_cdf(x, n, delta, True, 'default')
        print("L2:", L2)

        print("benton")
        L2 = mpm.student_t_nc_cdf(x, n, delta, True, 'benton')
        print("L2:", L2)

        print("witkovsky")
        L3 = mpm.student_t_nc_cdf(x, n, delta, True, 'witkovsky')
        print("L3:", L3)

        print("owen")
        L3 = mpm.student_t_nc_cdf(x, n, delta, True, 'owen')
        print("L3:", L3)

        print("broda")
        L1 = mpm.student_t_nc_cdf(x, n, delta, True, 'broda')
        print("L1:", L1)

        print()

    #        L1 = fpm.student_t_nc_cdf(x, n, delta, False)
    #        print("L1:", L1)

        print("default")
        L2 = mpm.student_t_nc_cdf(x, n, delta, False, 'default')
        print("L2:", L2)

        print("benton")
        L2 = mpm.student_t_nc_cdf(x, n, delta, False, 'benton')
        print("L2:", L2)

        print("witkovsky")
        L3 = mpm.student_t_nc_cdf(x, n, delta, False, 'witkovsky')
        print("L3:", L3)

        print("owen")
        L3 = mpm.student_t_nc_cdf(x, n, delta, False, 'owen')
        print("L3:", L3)

        print("broda")
        L1 = mpm.student_t_nc_cdf(x, n, delta, False, 'broda')
        print("L1:", L1)




    # 6.3.17 Non-central Pearson’s rho distribution: cdf and sf

    def demo_RhoDisN_Guenther(ctx):
        r = 0.5
        N = 11
        rho = 0.59

        print("guenther")
        L1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=True, method='guenther')
        print("L1", L1)

        print("hotelling")
        L1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=True, method='hotelling')
        print("L1", L1)

        print()

        print("guenther")
        R1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=False, method='guenther')
        print("R1", R1)

        print("hotelling")
        R1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=False, method='hotelling')
        print("R1", R1)
        return


    # 6.3.18 Non-central Pearson’s rho distribution: qtf and isf

    def demo_pearson_rho_nc_qtf(ctx):
        print("demo_pearson_rho_nc_qtf")


    # 6.3.19 Non-central Pearson’s rho distribution: confidence limit for rho

    def demo_pearson_rho_nc_cl(ctx):
        print("demo_pearson_rho_nc_cl")


    # 6.3.20 Pearson’s rho: unbiased estimate of rho

    def demo_pearson_rho_nc_unbiased_estimate(ctx):
        print("demo_pearson_rho_nc_unbiased_estimate")


    # 6.3.21 Non-central Fisher 𝐹 distribution: pdf

    def demo_fisher_f_nc_pdf(ctx):
        x = 1.9
        m = 7
        n = 117
        lambda1 = 15
        res1 = mpm.fisher_f_nc_pdf(x, m, n, lambda1)
        print(res1)
    #        res2 = fpm.fisher_f_nc_pdf(x, m, n, lambda1)
    #        print(res2)


    # 6.3.22 Non-central Fisher 𝐹 distribution: cdf and sf

    def demo_fisher_f_nc_cdf(ctx):
        x = 1.9
        m = 7
        n = 17
        lambda1 = 5

        x = 11
        m = 16
        n = 12
        lambda1 = 115

        x = 1819.9
        m = 8
        n = 8
        lambda1 = 1115

        print("mu2")
        L2 = mpm.fisher_f_nc_mu2_cdf(x, m, n, lambda1, True)
        print("L2:", L2)

        print()


        print("Noncentral F, cdf")
        for method in ["default", "benton", "chou", "seber", "spa", "mu2"]:
            print(method)
            L2 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, True, method)
            print("L2:", L2)

        print("Noncentral F, sf")
        for method in ["default", "benton", "chou", "seber", "spa"]:
            print(method)
            L2 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, False, method)
            print("L2:", L2)


    # 6.5.22 Non-central Fisher 𝐹 distribution: cdf and sf

    def demo_fdisnc_cdf2(ctx):
        x = 1.9
        m = 7
        n = 17
        lambda1 = 5
        res1 = mpm.fdisnc_cdf2(x, m, n, lambda1)
        print(res1)
    #        res2 = fpm.fisher_f_nc_cdf(x, m, n, lambda1)
    #        print(res2)
        LeftTail1, Righttail1 = mpm.fisher_f_nc2_spa(x,  m, n, lambda1, 0)
        print("L: , R: ", LeftTail1, Righttail1)


    # 6.5.23 Non-central Fisher 𝐹 distribution: qtf and isf

    def demo_fisher_f_nc_qtf(ctx):
        x = 1.9
        m = 7
        n = 17
        lambda1 = 5

        x = 11.5
        m = 16
        n = 12
        lambda1 = 115
        print("mu2")
        L2 = mpm.fisher_f_nc_mu2_cdf(x, m, n, lambda1, True)
        print("L2:", L2)
        X2 = mpm.fisher_f_nc_mu2_qtf(L2, m, n, lambda1, True)
        print("X2:", X2)


    # 6.3.24 Non-central Fisher 𝐹 distribution: confidence limit for lambda1

    def demo_fisher_f_nc_cl(ctx):
        print("demo_fisher_f_nc_cl")


    # 6.3.25 Non-central Beta distribution: pdf

    def demo_beta_nc_pdf(ctx):
        print("demo_beta_nc_pdf")


    # 6.3.26 Non-central Beta distribution: cdf and sf

    def demo_betadisn(ctx):
        xbeta = 0.7
        a = 10
        b = 20
        nc = 11
        mpm.dps = 30
    #        L2 = fpm.beta_nc_cdf(xbeta, a, b, nc)
    #        print("L2:", L2)

        print("default")
        L2 = mpm.beta_nc_cdf(xbeta, a, b, nc, True, 'default')
        print("L2:", L2)

        print()

    #        R2 = fpm.beta_nc_cdf(xbeta, a, b, nc, False)
    #        print("R2:", R2)

        print("default")
        R2 = mpm.beta_nc_cdf(xbeta, a, b, nc, False, 'default')
        print("R2:", R2)

        return


    # 6.3.27 Non-central Beta distribution: qtf and isf

    def demo_beta_nc_qtf(ctx):
        print("demo_beta_nc_qtf")


    # 6.3.28 Non-central Beta distribution: confidence limit for lambda1

    def demo_beta_nc_cl(ctx):
        print("demo_beta_nc_cl")


    # 6.3.29 Fisher’s 𝑅2 distribution: pdf

    def demo_fisher_r2_pdf(ctx):
        print("demo_fisher_r2_pdf")


    # 6.3.30 Fisher’s 𝑅2 distribution: cdf and sf

    def demo_fisher_r2_cdf(ctx):
        #p = 2
        p = 3
        N = 15  # N = sample size
        R2 = 0.6
        Rho = 0.5
        R2 = R2*R2
        Rho2 = Rho*Rho
        # Rho2=0
        print("R2: ", R2)
        print("mu2")
        L0 = mpm.fisher_r2_lee_cdf(R2, p, N, Rho2)
        print("L0", L0)
        LeftTail = L0
        X0 = mpm.fisher_r2_lee_qtf(LeftTail, p, N, Rho2)
        print("X0", X0)
        print()

        print("gurland1")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, True, 'gurland1')
        print("L1", L1)

        print("gurland2")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, True, 'gurland2')
        print("L1", L1)

        print()

        print("gurland1")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, False, 'gurland1')
        print("L1", L1)

        print("gurland2")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, False, 'gurland2')
        print("L1", L1)

        return


    # 6.3.31 Fisher’s 𝑅2 distribution: qtf and isf

    def demo_fisher_r2_qtf(ctx):
        print("demo_fisher_r2_qtf")


    # 6.3.32 Fisher’s 𝑅2 distribution: confidence limit for rho2

    def demo_fisher_r2_cl(ctx):
        print("demo_fisher_r2_cl")


    # 6.3.33 Fisher’s 𝑅2: unbiased estimate of rho2

    def demo_fisher_r2_unbiased_estimate(ctx):
        print("demo_fisher_r2_unbiased_estimate")


    # 6.3.34 Doubly non-central Student 𝑡 distribution: pdf

    def demo_student_t_nc2_pdf(ctx):
        x = 4
        n = 100
        delta = 2
        theta = 35
        res1 = mpm.student_t_nc2_pdf(x, n, delta, theta)
        print(res1)
        res = mpm.diff(lambda x: mpm.student_t_nc2_cdf(x, n, delta, theta), x)
        print(res)
        L, R = mpm.student_t_nc2_broda_cdf(x-0.001, n, delta, theta)
        print("L: , R: ", L, R)
        L2, R2 = mpm.student_t_nc2_broda_cdf(x+0.001, n, delta, theta)
        print("L: , R: ", L2, R2)
        print("pdf: ", (L2-L)/0.002)


    # 6.3.35 Doubly non-central Student 𝑡 distribution: cdf and sf

    def demo_student_t_nc2_cdf(ctx):
        x = 4
        n = 100
        delta = 2
        theta = 15
        res1 = mpm.student_t_nc2_cdf(x, n, delta, theta)
        print(res1)
        L, R = mpm.student_t_nc2_broda_cdf(x, n, delta, theta)
        print("L: , R: ", L, R)




    # 6.3.38 Doubly non-central Fisher 𝐹 distribution: pdf

    def demo_fisher_f_nc2_pdf(ctx):
        x = 3.9
        m = 7
        n = 17
        lambda1 = 5
        lambda2 = 3
        L1a = mpm.fisher_f_nc2_cdf(x+0.001, m, n, lambda1, lambda2)
        R1a = 1-L1a
        print("L1a: , R1a: ", L1a, R1a)
        L1b = mpm.fisher_f_nc2_cdf(x-0.001, m, n, lambda1, lambda2)
        R1b = 1-L1b
        print("L1b: , R1b: ", L1b, R1b)
        dens1 = (L1a-L1b)/0.002
        print("dens1:", dens1)
        dens2 = mpm.fisher_f_nc2_pdf(x, m, n, lambda1, lambda2)
        print("dens2:", dens2)
        print("ratio:", dens1/dens2)


    # 6.3.39 Doubly non-central Fisher 𝐹 distribution: cdf and sf

    def demo_fisher_f_nc2_cdf(ctx):
        x = 1.9
        m = 7
        n = 17
        lambda1 = 5
        lambda2 = 3
        print("mu2")
        L2 = mpm.fisher_f_nc2_mu2_cdf(x, m, n, lambda1, lambda2)
        print("L2:", L2)
        L1 = mpm.fisher_f_nc2_cdf(x, m, n, lambda1, lambda2)
        R1 = 1-L1
        print("L1: , R1: ", L1, R1)
        L2, R2 = mpm.fisher_f_nc2_spa(x,  m, n, lambda1, lambda2)
        print("L2: , R2: ", L2, R2)


    # 6.3.40 Doubly noncentral Fisher 𝐹 distribution, qtf and isf

    def demo_fisher_f_nc2_qtf(ctx):
        x = 3.9
        m = 7
        n = 17
        lambda1 = 5
        lambda2 = 3
        print("mu2")
        L2 = mpm.fisher_f_nc2_mu2_cdf(x, m, n, lambda1, lambda2)
        print("L2:", L2)
        X2 = mpm.fisher_f_nc2_mu2_qtf(L2, m, n, lambda1, lambda2)
        print("X2:", X2)





    demo_chi2_nc_pdf(ctx)
    demo_chi2_nc_cdf(ctx)
    # demo_chi2_nc_qtf(ctx)
    # demo_chi2_nc_cl(ctx)
    # demo_marcumq(ctx)

    # demo_chi_nc_pdf(ctx)
    # demo_chi_nc_cdf(ctx)
    # demo_chi_nc_qtf(ctx)

    # demo_rice_pdf(ctx)
    # demo_rice_cdf(ctx)
    # demo_rice_qtf(ctx)

    # demo_student_t_nc_pdf(ctx)
    # demo_student_t_nc_cdf(ctx)
    # demo_student_t_nc_qtf(ctx)
    # demo_student_t_nc_cl(ctx)

    # demo_pearson_rho_nc_pdf(ctx)
    # demo_RhoDisN_Guenther(ctx)
    # demo_pearson_rho_nc_qtf(ctx)
    # demo_pearson_rho_nc_cl(ctx)
    # demo_pearson_rho_nc_unbiased_estimate(ctx)

    # demo_fisher_f_nc_pdf(ctx)
    # demo_fisher_f_nc_cdf(ctx)
    # #demo_fdisnc_sf(ctx)
    # demo_fdisnc_cdf2(ctx)
    # demo_fisher_f_nc_qtf(ctx)
    # demo_fisher_f_nc_cl(ctx)

    # demo_beta_nc_pdf(ctx)
    # demo_betadisn(ctx)
    # demo_beta_nc_qtf(ctx)
    # demo_beta_nc_cl(ctx)

    # demo_fisher_r2_pdf(ctx)
    # demo_fisher_r2_cdf(ctx)
    # demo_fisher_r2_qtf(ctx)
    # demo_fisher_r2_cl(ctx)
    # demo_fisher_r2_unbiased_estimate(ctx)

    # demo_student_t_nc2_pdf(ctx)
    # demo_student_t_nc2_cdf(ctx)
    # demo_student_t_2nc_qtf(ctx)
    # demo_student_t_nc2_cl(ctx)

    # demo_fisher_f_nc2_pdf(ctx)
    # demo_fisher_f_nc2_cdf(ctx)
    # demo_fisher_f_nc2_qtf(ctx)
    # demo_fisher_f_nc2_cl(ctx)

    # demo_wilks_lambda_glm_pdf(ctx)
    # demo_wilks_lambda_glm_cdf(ctx)
    # demo_wilks_lambda_glm_qtf(ctx)

    # demo_wilks_lambda_ind_pdf(ctx)
    # demo_wilks_lambda_ind_cdf(ctx)
    # demo_wilks_lambda_ind_qtf(ctx)


# 6.4 Distributions related to multiple comparisons of means
def demo_6_4_multiple_comparisons_of_means(ctx):


    # 6.4.7 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜌: pdf

    def demo_nmax_rho_pdf(ctx):
        mpm.dps = 5
        print("demo_nmax_corr_pdf():")
        k = 8
        x = 2.381
        rho = 0.9
        res = mpm.nmax_corr_pdf(x, k, rho)
        print(res)
        if useplot: plot(lambda x: mpm.nmax_corr_pdf(x, k, rho), [-3, 5])
        print("k:", k, "rho: ", rho)
    #        res = mpm.diff(lambda x: mpm.nmax_corr_cdf(x, k, rho), x)
    #        print(res)


    # 6.4.8 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜌: cdf and sf

    def demo_nmax_rho_cdf(ctx):
        print("demo_nmax_corr_cdf():")
        k = 8
    #        x = 2.381
    #        rho = 0.5
        x = 2.381
        rho = 0.5
        res = mpm.nmax_corr_cdf(x, k, rho)
        print(res)


    # 6.4.8 Normal maximum distribution, negative rho, cdf

    def demo_nmax_rho_negative_rho_cdf(ctx):
        print("demo_nmax_corr_negative_rho_cdf():")
        print("Grubbs 1972, page 15")
        mpm.dps = 15
        k = 5
        x = 2.08
        rho = -mpm.t(1)/(k-1)
    # Adjustment for scaling used in Grubbs 1972
        x1 = x * mpm.sqrt(k/(k-1))
        print("x1: ", x1)
        print("rho :", rho)
        res = mpm.nmax_corr_negative_rho_cdf(x1, k, rho)
        print(res)


    # 6.4.9 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜌: qtf and isf

    def demo_nmax_rho_qtf(ctx):
        print("demo_nmax_qtf():")


    # 6.4.10 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜌: pdf

    def demo_nmm_rho_pdf(ctx):
        print("demo_nmm_corr_pdf():")
        k = 6
        x = 2.567
        rho = 0.5
        res = mpm.nmm_corr_pdf(x, k, rho)
        print(res)
        res = mpm.diff(lambda x: mpm.nmm_corr_cdf(x, k, rho), x)
        print(res)


    # 6.4.11 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜌: cdf and sf

    def demo_nmm_rho_cdf(ctx):
        print("demo_nmm_corr_cdf():")
        k = 6
        x = 2.567
        rho = 0.5
        res = mpm.nmm_corr_cdf(x, k, rho)
        print(res)


    # 6.4.11 Normal maximum modulus distribution, negative rho, cdf

    def demo_nmm_rho_negative_rho_cdf(ctx):
        print("demo_nmm_corr_negative_rho_cdf():")
        print("Ryan 2007: Modern experimental design (ANOM), page 573")
        print("See also: Nelson 2005, ANOM")
        print("See also: Jayalath 2021, ANOM")
        print("See also: Elamir 2016, ANOM")
        print("See also: Soong 2001, ANOM")
        print("See also: R Package ANOM 2017")
        mpm.dps = 15
        k = 10
    # scale used by Nelson
        x = 3.29
        rho = -1/(k-1)
        print("rho:", rho)
        res = mpm.nmm_corr_negative_rho_cdf(x, k, rho)
        print(res)


    # 6.4.12 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜌: qtf and isf

    def demo_nmm_rho_qtf(ctx):
        print("demo_nmm_rho_qtf():")


    # 6.4.13 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: pdf

    def demo_nmax_rhoij_pdf(ctx):
        print("demo_nmax_rhoij_pdf():")


    # 6.4.14 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: cdf and sf

    def demo_nmax_rhoij_cdf(ctx):
        print("demo_nmax_rhoij_cdf():")


    # 6.4.15 Normal maximum distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: qtf and isf

    def demo_nmax_rhoij_qtf(ctx):
        print("demo_nmax_rhoij_qtf():")


    # 6.4.16 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: pdf

    def demo_nmm_rhoij_pdf(ctx):
        print("demo_nmm_rhoij_pdf():")


    # 6.4.17 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: cdf and sf

    def demo_nmm_rhoij_cdf(ctx):
        print("demo_nmm_rhoij_cdf():")


    # 6.4.18 Normal maximum modulus distribution, 𝜌𝑖𝑗 = 𝜆𝑖𝜆𝑗: qtf and isf

    def demo_nmm_rhoij_qtf(ctx):
        print("demo_nmm_rhoij_qtf():")


    # 6.4.19 Normal range distribution: pdf

    def demo_nrange_pdf(ctx):
        print("demo_nrange_pdf():")
        k = 4
        x = 3.240
        res = mpm.nrange_pdf(x, k)
        print(res)
        res = mpm.diff(lambda x: mpm.nrange_cdf(x, k), x)
        print(res)


    # 6.4.20 Normal range distribution: cdf and sf

    def demo_nrange_cdf(ctx):
        print("demo_nrange_cdf():")
        k = 4
        x = 3.240
        res = mpm.nrange_cdf(x, k)
        print(res)


    # 6.4.21 Normal range distribution: qtf and isf

    def demo_nrange_qtf(ctx):
        print("demo_nrange_qtf():")


    # 6.4.22 Studentized maximum distribution: pdf

    def demo_smax_pdf(ctx):
        print("demo_smax_pdf():")
        k = 8
        x = 3.444
        n = 20
        res = mpm.smax_pdf(x, k, n)
        print(res)
        res = mpm.diff(lambda x: mpm.smax_cdf(x, k, n), x)
        print(res)


    # 6.4.23 Studentized maximum distribution: cdf and sf

    def demo_smax_cdf(ctx):
        print("demo_smax_cdf():")
        k = 8
        x = 3.444
    #x = 1.444
        n = 20
        res = mpm.smax_cdf(x, k, n)
        print(res)


    # 6.4.24 Studentized maximum distribution: qtf and isf

    def demo_smax_qtf(ctx):
        print("demo_smax_qtf():")


    # 6.4.25 Studentized maximum modulus distribution: pdf

    def demo_smm_pdf(ctx):
        print("demo_smm_pdf():")
        k = 8
        x = 3.444
        n = 20
        res = mpm.smm_pdf(x, k, n)
        print(res)
        res = mpm.diff(lambda x:  mpm.smm_cdf(x, k, n), x)
        print(res)


    # 6.4.26 Studentized maximum modulus distribution: cdf and sf

    def demo_smm_cdf(ctx):
        print("demo_smm_cdf():")
        k = 8
        x = 2.691
        n = 20
        res = mpm.smm_cdf(x, k, n)
        print(res)


    # 6.4.27 Studentized maximum modulus distribution: qtf and isf

    def demo_smm_qtf(ctx):
        print("demo_smm_qtf():")


    # 6.4.28 Dunnett’s 𝑡-distribution, 1-sided: pdf

    def demo_dunnett1_pdf(ctx):
        print("demo_dunnett1_pdf():")
        k = 8
        x = 3.337
        n = 20
        rho = 0.5
        res = mpm.dunnett1_pdf(x, k, n, rho)
        print(res)


    # 6.4.29 Dunnett’s 𝑡-distribution, 1-sided: cdf and sf

    def demo_dunnett1_cdf(ctx):
        print("demo_dunnett1_cdf():")
        k = 8
        x = 3.337
        n = 20
        rho = 0.5
        res = mpm.dunnett1_cdf(x, k, n, rho)
        print(res)


    # 6.4.30 Dunnett’s 𝑡-distribution, 1-sided: qtf and isf

    def demo_dunnett1_qtf(ctx):
        print("demo_dunnett1_qtf():")


    # 6.4.31 Dunnett’s 𝑡-distribution, 2-sided: pdf

    def demo_dunnett2_pdf(ctx):
        print("demo_dunnett2_pdf():")
        k = 8
        x = 3.651
        n = 20
        rho = 0.5
        res = mpm.dunnett2_pdf(x, k, n, rho)
        print(res)


    # 6.4.32 Dunnett’s 𝑡-distribution, 2-sided: cdf and sf

    def demo_dunnett2_cdf(ctx):
        print("demo_dunnett2_cdf():")
        k = 8
        x = 3.651
        n = 20
        rho = 0.5
        res = mpm.dunnett2_cdf(x, k, n, rho)
        print(res)


    # 6.4.33 Dunnett’s 𝑡-distribution, 2-sided: qtf and isf

    def demo_dunnett2_qtf(ctx):
        print("demo_dunnett2_qtf():")


    # 6.4.34 Nair’s 𝑡-distribution: pdf

    def demo_nair_pdf(ctx):
        print("demo_nair_pdf():")


    # 6.4.35 Nair’s 𝑡-distribution: cdf and sf

    def demo_nair_cdf(ctx):
        print("demo_nair_cdf():")


    # 6.4.36 Nair’s 𝑡-distribution: qtf and isf

    def demo_nair_qtf(ctx):
        print("demo_nair_qtf():")


    # 6.4.37 Halperin’s 𝑡-distribution: pdf

    def demo_halperin_pdf(ctx):
        print("demo_halperin_pdf():")


    # 6.4.38 Halperin’s 𝑡-distribution: cdf and sf

    def demo_halperin_cdf(ctx):
        print("demo_halperin_cdf():")

    def demo_nelson2_cdf(ctx):
        # this uses Nelson's scaling
        print("demo_nmm_corr_negative_rho_cdf():")
        print("Ryan 2007: Modern experimental design (ANOM), page 573")
        print("See also: Nelson 2005, ANOM")
        print("See also: Jayalath 2021, ANOM")
        print("See also: Elamir 2016, ANOM")
        print("See also: Soong 2001, ANOM")
        print("See also: R Package ANOM 2017")
        mpm.dps = 15
        k = 10
        n = 20
        x = 3.11
        rho = -1/(k-1)
        print("rho:", rho)

        res = mpm.nelson2_cdf(x, k, n, rho)
        print(res)


    # 6.4.39 Halperin’s 𝑡-distribution: qtf and isf

    def demo_halperin_qtf(ctx):
        print("demo_halperin_qtf():")


    # 6.4.40 Studentized range distribution: pdf

    def demo_stdrange_pdf(ctx):
        print("demo_stdrange_pdf():")
        k = 4
        x = 3.462
        n = 20
        res = mpm.srange_pdf(x, k, n)
        print(res)


    # 6.4.41 Studentized range distribution: cdf and isf

    def demo_stdrange_cdf(ctx):
        print("demo_stdrange_cdf():")
        k = 4
        x = 3.462
        n = 20
        res = mpm.srange_cdf(x, k, n)
        print(res)


    # 6.4.42 Studentized range distribution: qtf and isf

    def demo_stdrange_qtf(ctx):
        print("demo_stdrange_qtf():")

    # density of chi
    # def chidens(x, n):
    #    x = mp.mpf(x)
    #    n = mp.mpf(n)
    #    t1 = n**(n/2) * x**(n-1) *mp.exp(-n*x*x/2)
    #    t2 = 2**((n-1)/2) * mp.gamma(n/2)
    #    res = t1/t2
    #    res = res * mp.sqrt(2)
    #    return res

    def demo_chidens(ctx):
        mpm.dps = 30
        x = mpm.mpf("2.462")
        n = 400
        res1 = mpm.sqrt(n)*mpm.chi_pdf(mpm.sqrt(n)*x, n)
        print("res1: ", res1)
        res2 = mpm.chidens(x, n)
        print("res2: ", res2)
        return



    demo_nmax_rho_pdf(ctx)
    demo_nmax_rho_cdf(ctx)
    demo_nmax_rho_negative_rho_cdf(ctx)
    demo_nmax_rho_qtf(ctx)

    demo_nmm_rho_pdf(ctx)
    demo_nmm_rho_cdf(ctx)
    demo_nmm_rho_negative_rho_cdf(ctx)
    demo_nmm_rho_qtf(ctx)

    demo_nmax_rhoij_pdf(ctx)
    demo_nmax_rhoij_cdf(ctx)
    demo_nmax_rhoij_qtf(ctx)

    demo_nmm_rhoij_pdf(ctx)
    demo_nmm_rhoij_cdf(ctx)
    demo_nmm_rhoij_qtf(ctx)

    demo_nrange_pdf(ctx)
    demo_nrange_cdf(ctx)
    demo_nrange_qtf(ctx)

    demo_smax_pdf(ctx)
    demo_smax_cdf(ctx)
    demo_smax_qtf(ctx)

    demo_smm_pdf(ctx)
    demo_smm_cdf(ctx)
    demo_smm_qtf(ctx)

    demo_dunnett1_pdf(ctx)
    demo_dunnett1_cdf(ctx)
    demo_dunnett1_qtf(ctx)

    demo_dunnett2_pdf(ctx)
    demo_dunnett2_cdf(ctx)
    demo_dunnett2_qtf(ctx)

    demo_nair_pdf(ctx)
    demo_nair_cdf(ctx)
    demo_nair_qtf(ctx)

    demo_halperin_pdf(ctx)
    demo_halperin_cdf(ctx)
    demo_nelson2_cdf(ctx)
    demo_halperin_qtf(ctx)

    demo_stdrange_pdf(ctx)
    demo_stdrange_cdf(ctx)
    demo_stdrange_qtf(ctx)



def demo_6(ctx):
    # demo_6_3_noncentral(ctx)
    demo_6_4_multiple_comparisons_of_means(ctx)
    # demo_6_5_miscellaneous(ctx)
    return



mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dpm
ctxm = mpm


demo_6_3_noncentral(ctxm)


