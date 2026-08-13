# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm , dpm



# 8 Series and integrals



# 8.1 Finite sums algorithms for selected distributions
def demo_8_1_finite_sums(ctx):


    # 8.1.1 Central chi2 distribution, cdf (integer degrees of freedom)
    def demo_chi2_cohen_cdf(ctx):
        x = 11
        n = 11
        mpm.dps = 30
    #        L1 = fpm.chi_squared_cdf(x, n, True)
    #        print("L1:", L1)
        L1 = mpm.chi2_cohen_cdf(x, n, True)
        print("L1:", L1)

    # 8.1.2 Central Student t distribution, cdf (integer degrees of freedom)
    def demo_student_t_owen_cdf(ctx):
        x = -5
        n = 20
        mpm.dps = 30
    #        L1 = fpm.student_t_cdf(x, n, True)
    #        print("L1:", L1)
        L1 = mpm.student_t_owen_cdf(x, n, True)
        print("L1:", L1)

    # 8.1.3 Central Fisher F distribution, cdf (integer degrees of freedom)
    def demo_fisher_f_seber_cdf(ctx):
        x = 11
        m = 16
        n = 12
    #        L1 = fpm.fisher_f_cdf(x, m, n, True)
    #        print("L1:", L1)
        L1 = mpm.fisher_f_seber_cdf(x, m, n, True)
        print("L1:", L1)

    # 8.1.4 Central Beta distribution, cdf (2a an integer, 2b an integer)
    def demo_beta_seber_cdf(ctx):
        xbeta = 0.3
        a = 10
        b = 20
        mpm.dps = 30
    #        L2 = fpm.beta_cdf(xbeta, a, b, True)
    #        print("L2:", L2)
        L2 = mpm.beta_seber_cdf(xbeta, a, b, True)
        print("L2:", L2)




    # 8.1.5 Noncentral chi2 distribution, cdf (integer degrees of freedom)
    def demo_chi2_nc_cohen_cdf(ctx):
        x = 165
        n = 111
        #n = 3
        nc = 115
        ctx.dps = 30

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='benton')
        print("L4:", L4, " benton")

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='chou')
        print("L4:", L4, " chou")

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='cohen')
        ctx.dps = 30
        print("L4:", 1*L4, " cohen")

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='spa')
        print("L4:", L4, " spa")

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='penev')
        print("L4:", L4, " penev")

        ctx.dps = 30
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='ecf')
        print("L4:", L4, " ecf")




    # 8.1.6 Noncentral Student t distribution, cdf (integer degrees of freedom)
    def demo_student_t_nc_owen_cdf(ctx):
##        x = 11
##        n = 20
##        delta = 15.0
        for i in range(-10, 40, 4):
            x = 1.0 * i # - 0.2
            print("x:", x)
            n = 20
            delta = 15
            #delta = ctx.t('1E-20')

            ctx.dps = 30
            L1 = ctx.student_t_nc_owen_cdf(x, n, delta, True)
            print("L1:", L1, " owen")

            L3 = ctx.student_t_nc_cdf(x, n, delta, True, method='default')
            print("L3:", L3, " witkovsky" )

            #ctx.dps = 100
            L2 = ctx.student_t_nc_benton_cdf_sf(x, n, delta, True)
            ctx.dps = 30
            L2 = 1 * L2
            print("L2:", L2, " benton")


            ctx.dps = 30
            L4 = ctx.student_t_nc_cdf(x, n, delta, True, method='broda')
            print("L4:", L4, " broda")
            print()


##    def student_t_nc_cdf(self, x, n, delta, cdf=True, method='default'):
##        '''Returns the Non-central Student 𝑡 distribution: cdf and sf'''
##        return ctxm.student_t_nc_cdf(self, x, n, delta, cdf, method)










    # 8.1.7 Noncentral Fisher F distribution, cdf (n an even integer)
    def demo_fisher_f_nc_seber_cdf(ctx):
        from scipy import special

        x = 100.005
        m = 6
        n = 16
        lambda1 = 218
        L0 = special.ncfdtr(m, n, lambda1, x)
        print("L0:", L0, "(scipy)")

        L4 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, cdf=True, method='seber')
        print("L4:", L4, "(seber)")

        L1 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, cdf=True, method='chou')
        print("L1:", L1, "(chou)")

        L3 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, cdf=True, method='benton')
        print("L3:", L3, "(benton)")

        L2 = mpm.fisher_f_nc_cdf(x, m, n, lambda1, cdf=True, method='spa')
        print("L2:", L2, "(spa)")














    # 8.1.8 Noncentral Beta distribution, cdf (b an integer)
    def demo_beta_nc_seber_cdf(ctx):
        xbeta = 0.5
        a = 20
        b = 20
        nc = 5
        ctx.dps = 30
        L2 = ctx.beta_nc_seber_cdf(xbeta, a, b, nc, True)
        print("L2:", L2, "(Seber)")

        L3 = ctx.beta_nc_benton_cdf_sf(xbeta, a, b, nc, True)
        print("L3:", L3, "(Benton)")





    # 8.1.9 Pearson’s rho distribution, pdf (integer N)
    def demo_pearson_rho_nc_owen_pdf(ctx):
        r = 0.5
        N = 11
        rho = 0.59
        print("default")
        L1 = ctx.pearson_rho_nc_pdf(r, N, rho)
        print("L1", L1)
        print("owen")
        L1 = ctx.pearson_rho_nc_owen_pdf(r, N, rho)
        print("L1", L1)

    # 8.1.10 Pearson’s rho distribution, cdf (integer N)
    def demo_pearson_rho_nc_owen_cdf(ctx):
        r = 0.5
        N = 110
        rho = 0.59

        ctx.dps = 30
        basedps = ctx.dps

        ctx.dps = 50
        print("owen")
        L1 = ctx.pearson_rho_nc_owen_cdf(r, N, rho, True)
        ctx.dps = basedps
        print("L1", 1*L1)

        print("guenther")
        L1 = ctx.pearson_rho_nc_cdf(r, N, rho, True, 'guenther')
        print("L1", L1)

        print("hotelling")
        L1 = ctx.pearson_rho_nc_cdf(r, N, rho, True, 'hotelling')
        print("L1", L1)




    # 8.1.11 Fisher’s R2 distribution, cdf (finite sum for N − p even)
    def demo_fisher_r2_gd1_cdf(ctx):
    #p = 2
        p = 3
        N = 15  # N = sample size
        R2 = ctx.t(0.5)
        Rho2 = ctx.t(0.9)
        R2 = R2*R2

        Rho2 = Rho2*Rho2
        print("gurland2")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, True, 'gurland2')
        print("L1", L1)

        print("gurland1")
        L1, R1 = mpm.fisher_r2_gd1_cdf(R2, p, N, Rho2)
        print("L1", L1)




    # 8.1.12 Roy’s largest root distribution, pdf, cdf and sf
    def demo_roy_pdf_cdf_sf(ctx):
    # uses scaling as in Anderson
        x1 = 3.512
        x1 = 4.692
        p = 2
        n1 = 3
        n2 = 123  # '128
        print("x1 (Anderson): {0}", x1)
        f = n1 / (n2 + n1)
        x = x1 * f
        print("x: {0}", x)
        Result1 = mpm.roy_pdf_cdf_sf(x, p, n1, n2)
        print("Result1: {0}", Result1)


##    demo_chi2_cohen_cdf(ctx)
##    demo_student_t_owen_cdf(ctx)
##    demo_fisher_f_seber_cdf(ctx)
##    demo_beta_seber_cdf(ctx)


##    demo_chi2_nc_cohen_cdf(ctx)
##    demo_student_t_nc_owen_cdf(ctx)
##    demo_pearson_rho_nc_owen_cdf(ctx)
##    demo_fisher_f_nc_seber_cdf(ctx)
##    demo_beta_nc_seber_cdf(ctx)
    demo_fisher_r2_gd1_cdf(ctx)



##    demo_pearson_rho_nc_owen_pdf(ctx)
##    demo_roy_pdf_cdf_sf(ctx)
    return


# 8.2 Infinite sums algorithms for selected functions and distributions
def demo_8_2_infinite_sums(ctx):

    # 8.2.1 Incomplete gamma function, continued fractions (Peizer)
    def demo_gamma_peizer_cdf_sf_pdf(ctx):
        x = 141.1
        n = 121.1
        mpm.dps = 30
    #        L1 = fpm.gamma_p(x, n)
    #        print("L1:", L1)
        L1 = mpm.real_gamma_p(x, n, method='mpmath')
        print("L1:", L1)
        L2 = mpm.real_gamma_p(x, n, method='cf')
        print("L2:", L2)
        L3 = mpm.real_gamma_p(x, n, method='paris')
        print("L3:", L3)
        L4, R4, d = mpm.gamma_peizer_cdf_sf_pdf(x, n)
        print("L4:", L4)
        print()

    #        R1 = fpm.gamma_q(x, n)
    #        print("R1:", R1)
        R1 = mpm.real_gamma_q(x, n, method='mpmath')
        print("R1:", R1)
        R2 = mpm.real_gamma_q(x, n, method='cf')
        print("R2:", R2)
        R3 = mpm.real_gamma_q(x, n, method='paris')
        print("R3:", R3)
        print("R4:", R4)

    # 8.2.2 Incomplete gamma function, asymptotic expansion (Paris)
    def demo_gamma_paris_cdf_sf(ctx):
        x = 141.1
        n = 121.1
        mpm.dps = 30
    #        L1 = fpm.gamma_p(x, n)
    #        print("L1:", L1)
        L1 = mpm.real_gamma_p(x, n, method='mpmath')
        print("L1:", L1)
        L2 = mpm.real_gamma_p(x, n, method='cf')
        print("L2:", L2)
        L3 = mpm.real_gamma_p(x, n, method='paris')
        print("L3:", L3)
        L4, R4 = mpm.gamma_paris_cdf_sf(x, n, 20)
        print("L4:", L4)
        print()

    #        R1 = fpm.gamma_q(x, n)
    #        print("R1:", R1)
        R1 = mpm.real_gamma_q(x, n, method='mpmath')
        print("R1:", R1)
        R2 = mpm.real_gamma_q(x, n, method='cf')
        print("R2:", R2)
        R3 = mpm.real_gamma_q(x, n, method='paris')
        print("R3:", R3)
        print("R4:", R4)

    # 8.2.3 Incomplete beta function, continued fractions (Peizer)
    def demo_beta_peizer_cdf_sf_pdf(ctx):
        print("demo_beta_peizer_cdf_sf_pdf():")
        mpm.dps = 30
        a = 8.0
        b = 10.1
        x = 0.26

        L2 = mpm.beta_seber_cdf(x, a, b, True)
        print("L2:", L2)

        L, R, d = mpm.beta_peizer_cdf_sf_pdf(a, b, x, 1-x)
        print("L: ", L)

        mx = mpm.real_ibeta(a, b, x, method='cf')
        print("cf:", mx)
        mx = mpm.real_ibeta(a, b, x, method='mpmath')
        print("mp:", mx)
    #        fx = fpm.real_ibeta(a, b, x)
    #        print("fp:", fx)
        print()

        print("R: ", R)
        mx = mpm.real_ibetac(a, b, x, method='cf')
        print("cf:", mx)
        mx = mpm.real_ibetac(a, b, x, method='mpmath')
        print("mp:", mx)
    #        fx = fpm.real_ibetac(a, b, x)
    #        print("fp:", fx)

    # 8.2.4 Noncentral Chi2 distribution, pdf, cdf and sf (Boost)
    def demo_chi2_nc_benton_cdf_sf(ctx):
        x = 11
        n = 11
        nc = 15
        mpm.dps = 30
    #        L1 = fpm.chi2_nc_cdf(x, n, nc)
    #        print("L1:", L1)
        L1 = mpm.chi2_nc_benton_cdf_sf(x, n, nc)
        print("L1:", L1)

    # 8.2.5 Noncentral Student t distribution, pdf, cdf and sf (Boost)
    def demo_student_t_nc_benton_cdf_sf(ctx):
        x = 11
        n = 20
        delta = 5.0
        mpm.dps = 30
    #        L1 = fpm.student_t_nc_cdf(x, n, delta, True)
    #        print("L1:", L1)
        L1 = mpm.student_t_nc_benton_cdf_sf(x, n, delta, True)
        print("L1:", L1)

    # 8.2.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)
    def demo_beta_nc_benton_cdf_sf(ctx):
        xbeta = 0.7
        a = 10
        b = 20
        nc = 11
        mpm.dps = 30
    #        L2 = fpm.beta_nc_cdf(xbeta, a, b, nc)
    #        print("L2:", L2)
        L2 = mpm.beta_nc_benton_cdf_sf(xbeta, a, b, nc)
        print("L2:", L2)

    # 8.2.6 Noncentral F distribution, pdf, cdf and sf (Boost)
    def demo_fisher_f_nc_benton_cdf_sf(ctx):
        x = 11
        m = 16
        n = 12
        lambda1 = 115
    #        L1 = fpm.fisher_f_nc_cdf(x, m, n, lambda1)
    #        print("L1:", L1)
        L1 = mpm.fisher_f_nc_benton_cdf_sf(x, m, n, lambda1)
        print("L1:", L1)

    # 8.2.7 Pearson’s rho distribution, cdf and sf (Hotelling’s series)
    def demo_pearson_rho_nc_ht_cdf(ctx):
        r = 0.5
        N = 11
        rho = 0.59
        print("hotelling")
        L1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=True, method='hotelling')
        print("L1", L1)
        L1 = mpm.pearson_rho_nc_ht_cdf(r, N, rho)
        print("L1:", L1)

    # 8.2.8 Pearson’s rho distribution, cdf and sf (Guenther’s series)
    def demo_pearson_rho_nc_gt_cdf(ctx):
        r = 0.5
        N = 11
        rho = 0.59
        print("guenther")
        L1 = mpm.pearson_rho_nc_cdf(r, N, rho, cdf=True, method='guenther')
        print("L1", L1)
        L1 = mpm.pearson_rho_nc_gt_cdf(r, N, rho)
        print("L1:", L1)

    # 8.2.10 Fisher’s R2 distribution, cdf and sf (Boost, Benton)
    def demo_fisher_r2_gd2_cdf(ctx):
    #p = 2
        p = 3
        N = 15  # N = sample size
        R2 = 0.5
        Rho2 = 0.9
        R2 = R2*R2
        Rho2 = Rho2*Rho2
        print("gurland1")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, True, 'gurland1')
        print("L1", L1)
        print("gurland2")
        L1 = mpm.fisher_r2_cdf(R2, p, N, Rho2, True, 'gurland2')
        print("L1", L1)
        L1 = mpm.fisher_r2_gd2_cdf(R2, p, N, Rho2)
        print("L1", L1)


##    demo_gamma_peizer_cdf_sf_pdf(ctx)
##    demo_gamma_paris_cdf_sf(ctx)
##    demo_beta_peizer_cdf_sf_pdf(ctx)
##    demo_chi2_nc_benton_cdf_sf(ctx)
##    demo_student_t_nc_benton_cdf_sf(ctx)
##    demo_beta_nc_benton_cdf_sf(ctx)
##    demo_fisher_f_nc_benton_cdf_sf(ctx)
##    demo_pearson_rho_nc_ht_cdf(ctx)
##    demo_pearson_rho_nc_gt_cdf(ctx)
##    demo_fisher_r2_gd2_cdf(ctx)
    return




# 8.5 Verified numerical integration
def demo_8_5_verified_integration(ctx):


    def Test_verified_integration1(ctx):
        ctx = ipm
        mpm.dps = 40
        a = ctx.t("0.0")
        b = ctx.t("10.0")
        alpha = ctx.t("1.0")
        beta = ctx.t("1.0")
    #a = 5.0; b = 10.0; alpha = 1.0; beta = 1.0
    #a = 0.0; b = 1.0; alpha = 0.5; beta = 1.0
    #epsabsStart = "1.0E-2"
        epsabsStart = ctx.t("1.0E-35")
        def f(x): return ctx.exp(-x * x)
        verbose = True
        res = ctx.quad_verified(f, a, b, epsabsStart, alpha, beta, verbose)
        print("Int1:")
        print(res)
        print("Int2: = ctx.sqrt(pi/2)")
        print(ctx.sqrt(ctx.pi) / 2)

    def Test_verified_integration2(ctx):
        ctx = ipm
        mpm.dps = 30
        a = ctx.t("0.0")
        b = ctx.t("10.0")
        eps = ctx.t("1.0E-25")
        def f(x): return ctx.exp(-x * x)
        res = ctx.quad_verified(f, a, b, eps)
        print("Int1:")
        print(res)
        print("Int2: = ctx.sqrt(pi/2)")
        print(ctx.sqrt(ctx.pi) / 2)

    # wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...

    def Test_verified_integration3(ctx):
        ctx = ipm
        mpm.dps = 30
        a = ctx.t("0.0")
        b = ctx.t("2.0")
        alpha = ctx.t("0.5")
        beta = ctx.t("1.0")
        epsabsStart = ctx.t("1.0E-25")
        def f(x): return ctx.sin(ctx.exp(x))
        res = ctx.quad_verified(f, a, b, epsabsStart, alpha, beta)
        print("Int1:")
        print(res)

    def demo_owent(ctx):
    #    l = 0
    #    r = 1
        h = 5
        a = 20
    #plot(lambda x: owentfx(h, a, x), [l, r])
        print("res1:", mpm.owent(h, a))
    #        print("res2:", fpm.owent(h, a))

    def demo_marcumq(ctx):
    #    l = 0
    #    r = 1*mp.pi()
        a = 6
        b = 4
    #plot(lambda x: mpm.marcumqfx(a, b, x), [l, r])
        print("res1:", mpm.marcumq_quad(a, b))
    #        print("res2:", fpm.marcumq(1, a, b))

    Test_verified_integration1(ctx)
    Test_verified_integration2(ctx)
    Test_verified_integration3(ctx)
    demo_owent(ctx)
    demo_marcumq(ctx)
    return


# 8.6 Numerical Fourier transform and its inverse: continuous distributions
def demo_8_6_numerical_Fourier_transform_cont(ctx):

    def tatda4(ctx):
        print("tatda4")
        return

    tatda4(ctx)
    return




def demo_8(ctx):
    demo_8_1_finite_sums(ctx)
    demo_8_2_infinite_sums(ctx)
    #demo_8_5_verified_integration(ctx)   # error
    #demo_8_6_numerical_Fourier_transform_cont(ctx)
    return



mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dec
ctxm = mpm


demo_8(ctxm)


