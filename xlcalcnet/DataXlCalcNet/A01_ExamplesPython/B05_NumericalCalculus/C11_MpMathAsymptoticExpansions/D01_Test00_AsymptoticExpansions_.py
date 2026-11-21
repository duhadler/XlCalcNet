# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot

from xlcalcnet import mpm , gpm, dpm

from xlcalcnet.ctx12Asymptotic import ctxAsymptotic


# 10 Asymptotic expansions



# 10.1 Edgeworth and Cornish-Fisher expansions: continuous distributions
def demo_10_1_Edgeworth_Cornish_Fisher_cont(ctx):

    def demo_edgeworth(ctx):
        ctx = mpm
        ctx.dps = 10
        x = mpm.convert(12)
        n = 10
        order = 16
        kappa = ctxAsymptotic().chi2_cumulants(ctx, order+3, n)
        for i in range(2, order+3):
            print(i, kappa[i])
        L1, R1 = mpm.edgeworth(x, order, kappa)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        L2 = mpm.chi2_cdf(x, n, True)
        R2 = mpm.chi2_cdf(x, n, False)
        print("      chi2 L2: ", L2, " R2: ",  R2)

    def demo_cornish_fisher(ctx):
        ctx = mpm
        ctx.dps = 10
        LeftTail = 1 - mpm.convert("0.00001")
        RightTail = 1 - LeftTail
        n = 10
        order = 20
        kappa = ctxAsymptotic().chi2_cumulants(ctx, order+3, n)
    #    for i in range(2, Order+3):
    #        print(i, kappa[i])
        X1 = mpm.cornish_fisher(LeftTail, RightTail, kappa, order-5)
        print("X1: ", X1)
        X2 = mpm.chi2_qtf(LeftTail, n, True)
        print("X2: ", X2)

    def demo_chi_squared_ecf(ctx):
        ctx = mpm
        ctx.dps = 20
        x = mpm.convert(12)
        n = 40
        order = 36
        verbose = True
        L1, R1 = mpm.chi2_ecf(x, n, order, verbose)
        print("Edgeworth  L1: ", L1, " R1: ",  R1)
        L2 = mpm.chi2_cdf(x, n, True)
        R2 = mpm.chi2_cdf(x, n, False)
        print("chisquared L2: ", L2, " R2: ",  R2)

    def demo_chi_squared_ecf_inv(ctx):
        mpm.dps = 20
        LeftTail = 1 - mpm.convert("0.001")
        RightTail = 1 - LeftTail
        n = 20
        order = 20
        verbose = True
        X1 = mpm.chi2_ecf_inv(LeftTail, RightTail, n, order, verbose)
        print("X1: ", X1)
        X2 = mpm.chi2_qtf(LeftTail, n, True)
        print("X2: ", X2)


    #  10.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf and sf


    def demo_logchisquare_cumulants(ctx):
        mpm.dps = 15
        n = 100.05

        Order = 14
        LeftTail = 1 - mpm.convert("0.001")
        RightTail = 1 - LeftTail
        kappa = mpm.matrix(Order+3, 1)

        for j in range(1, Order+1):
            kappa[j] = mpm.psi(j-1, n/2)
            #print(j, kappa[j])
        kappa[1] = kappa[1] + mpm.log(2)
        # print(kappa[1])

        X1 = mpm.cornish_fisher(LeftTail, RightTail, kappa, Order-0)
        print("X1: ", X1)
        res1 = mpm.logchisquare_sf(X1, n)
        print("res1: ", res1)


    #  10.1.7 Fisher z distribution: pdf, cdf and sf


    def demo_fisher_z_cumulants(ctx):
        n1 = 20
        n2 = 300
        n11 = 1/n1
        n21 = 1/n2
        n12 = n11*n11
        n22 = n21*n21
        n13 = n12*n11
        n23 = n22*n21
        n14 = n13*n11
        n24 = n23*n21
        n15 = n14*n11
        n25 = n24*n21
        n16 = n15*n11
        n26 = n25*n21
        n17 = n16*n11
        n27 = n26*n21
        n18 = n17*n11
        n28 = n27*n21
        n19 = n18*n11
        n29 = n28*n21

        l1 = (1/2)*(n21-n11)+(1/6)*(n22-n12)-(1/15)*(n24-n14)
        print("l1:", l1)
        l2 = (1/2)*((n2+1)*n22+(n1+1)*n12)+(1/3)*(n23+n13)-(4/15)*(n25+n15)
        print("l2:", l2)
        l3 = (1/2)*((n2+2)*n23-(n1+2)*n13)+1*(n24-n14)-(4/3)*(n26-n16)
        print("l3:", l3)
        l4 = ((n2+3)*n24+(n1+3)*n14)+4*(n25-n15)-8*(n27-n17)
        print("l4:", l4)
        l5 = 3*((n2+4)*n25-(n1+4)*n15)+20*(n26-n16)-56*(n28-n18)
        print("l5:", l5)
        l6 = 12*((n2+5)*n26+(n1+5)*n16)+120*(n27+n17)-488*(n29+n19)
        print("l6:", l6)

        k1 = -0.5*mpm.psi(0, n2/2)+0.5*mpm.psi(0, n1/2) + \
            0.5*(mpm.log(n2)-mpm.log(n1))
        print("k1:", k1)

        k2 = +0.25*mpm.psi(1, n2/2)+0.25*mpm.psi(1, n1/2)
        print("k2:", k2)

        k3 = -(1/8)*mpm.psi(2, n2/2)+(1/8)*mpm.psi(2, n1/2)
        print("k3:", k3)

        k4 = +(1/16)*mpm.psi(3, n2/2)+(1/16)*mpm.psi(3, n1/2)
        print("k4:", k4)

        k5 = -(1/32)*mpm.psi(4, n2/2)+(1/32)*mpm.psi(4, n1/2)
        print("k5:", k5)

        k6 = (1/64)*mpm.psi(5, n2/2)+(1/64)*mpm.psi(5, n1/2)
        print("k6:", k6)

        Order = 6
        LeftTail = 1 - mpm.convert("0.001")
        RightTail = 1 - LeftTail
        kappa = mpm.matrix(Order+3, 1)
        kappa[1] = k1
        kappa[2] = k2
        kappa[3] = k3
        kappa[4] = k4
        kappa[5] = k5
        kappa[6] = k6

        X1 = 1 + mpm.cornish_fisher(LeftTail, RightTail, kappa, Order-0)
        print("X1: ", X1)
        X2 = mpm.fisher_z_qtf(LeftTail, n1, n2)
        print("X2: ", X2)
        Y1 = mpm.fisher_z_cdf(X1, n1, n2)
        print("Y1: ", Y1)
        Y2 = mpm.fisher_z_cdf(X2, n1, n2)
        print("Y2: ", Y2)


    #  10.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf and sf


    def demo_logbeta_cumulants(ctx):
        mpm.dps = 25
        a = 30
        b = 40

        Order = 12
        LeftTail = 1 - mpm.convert("0.99")
        RightTail = 1 - LeftTail
        kappa = mpm.matrix(Order+3, 1)

        for j in range(1, Order+1):
            kappa[j] = (mpm.psi(j-1, a) - mpm.psi(j-1, a+b)) * (-1)**(j+0)
            print(j, kappa[j])

        X1 = mpm.cornish_fisher(LeftTail, RightTail, kappa, Order-0)
        print("X1: ", X1)
        res1 = mpm.logrv_beta_cdf(X1, a, b)
        print("res1: ", res1)


    #  10.1.11 Wilks’ Lambda distribution: pdf, cdf and sf


    def demo_NewTestWilksUArb(ctx):
        ctxAsymptotic().NewTestWilksUArb(mpm)
        return


    #  10.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def demo_pillai_v_moments(ctx):
        mpm.dps = 15
        k = 12
        p = 4
        n1 = 10
        n2 = 35  # 125
        mraw = mpm.pillai_v_moments(k, p, n1, n2)
        kappa = mpm.cumulants_from_rawmoments(mraw)
        for i in range(1, k+1):
            print("i:", i, "kappa(i):", kappa[i])
        x = kappa[1] * 1.2
        L1, R1 = mpm.edgeworth(x, k-2, kappa)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        LeftTail = 1 - mpm.convert("0.05")
        RightTail = 1 - LeftTail
        X1 = mpm.cornish_fisher(LeftTail, RightTail, kappa, k-0)
        print("X1: ", X1)
        V = X1*(n1+n2)/n1  # Anderson2003, page 674
        print("V: ", V)

        X2 = mpm.pillai_v_mu3_qtf(p, n1, n2, LeftTail, RightTail)
        print("X2: ", X2)
        V = X2*(n1+n2)/n1  # Anderson2003, page 674
        print("V: ", V)
        L2, R2 = mpm.pillai_v_mu3_cdf(p, n1, n2, n2*X2)
        print("edgeworth  L2: ", L2, " R2: ",  R2)


    #  10.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf


    def demo_hotelling_t2_moments(ctx):
        k = 7
        p = 4
        n1 = 20
        n2 = 100
        mraw = mpm.hotelling_t2_moments(k, p, n1, n2)
        kappa = mpm.cumulants_from_rawmoments(mraw)
        for i in range(1, k+1):
            print("i:", i, "kappa(i):", kappa[i])
        x = kappa[1] * 1.25
        L1, R1 = mpm.edgeworth(x, k-2, kappa)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        LeftTail = 1 - mpm.convert("0.01")
        RightTail = 1 - LeftTail
        X1 = mpm.cornish_fisher(LeftTail, RightTail, kappa, k-0)
        print("X1: ", X1)
        T2 = X1*(n2)/n1  # Anderson2003, page 661
        print("T2: ", T2)

        m = (n1-p-1)/2
        n = (n2-p-1)/2
        X2 = mpm.hotelling_t2_mu3_qtf(p, m, n, LeftTail, RightTail)
        print("X2: ", X2)
        T2 = X2*(n2)/n1  # Anderson2003, page 661
        print("T2: ", T2)
        L2, R2 = mpm.hotelling_t2_mu3_cdf(p, m, n, 1*X2)
        print("edgeworth  L2: ", L2, " R2: ",  R2)

    demo_edgeworth(ctx)
##    demo_cornish_fisher(ctx)
##    demo_chi_squared_ecf(ctx)
##    demo_chi_squared_ecf_inv(ctx)
##    demo_logchisquare_cumulants(ctx)
##    demo_logbeta_cumulants(ctx)
##    demo_fisher_z_cumulants(ctx)
##    demo_NewTestWilksUArb(ctx)
##    demo_pillai_v_moments(ctx)
##    demo_hotelling_t2_moments(ctx)
    return




# 10.3 Luggannini-Rice and Jensen saddle point expansions: continuous distributions
def demo_10_3_Luggannini_Rice_cont(ctx):

    def demo_chi_squared_nc_spa(ctx):
        x = mpm.convert("131.900000001")
        #x = ctx.convert("0.00000001")
        #x = 0.1
        nu = 40.0
        nc = 70.0
        Order = 18
        verbose = True
        LeftTail1, RightTail1 = mpm.chi2_nc_spa(x, nu, nc, Order, verbose)
        print("LeftTail1:", LeftTail1, ",  RightTail1:", RightTail1)
        LeftTail2, RightTail2 = ctxAsymptotic().CdisnJensen(mpm, x, nu, nc)
        print("LeftTail2:", LeftTail2, ",  RightTail2:", RightTail2)
        LeftTail3, RightTail3 = mpm.chi2_nc_penev_cdf(x, nu, nc)
        print("LeftTail3:", LeftTail3, ",  RightTail3:", RightTail3)

    def demo_fisher_f_nc2_spa(ctx):
        x = 4.500
        N1 = 5
        n2 = 100
        t1 = 10
        t2 = 20
        LeftTail1, Righttail1 = mpm.fisher_f_nc2_spa(x, N1, n2, t1, t2)
        print("L: , R: ", LeftTail1, Righttail1)
        LeftTail2, Righttail2 = ctxAsymptotic().FdisnJensen(mpm, N1, n2, x, t1, t2)
        print("L: , R: ", LeftTail2, Righttail2)

    def demo_JensenDemo(ctx):
        ctxAsymptotic().JensenDemo(mpm)


    demo_chi_squared_nc_spa(ctx)
    demo_fisher_f_nc2_spa(ctx)
    demo_JensenDemo(ctx)
    return




# 10.5 Box-Davis expansions and their inverses
def demo_10_5_box_davis(ctx):
    return


def demo_10(ctx):
    demo_10_1_Edgeworth_Cornish_Fisher_cont(ctx)
##    demo_10_3_Luggannini_Rice_cont(ctx)
##    demo_10_5_box_davis(ctx)
    return



mpm.dps=35
dpm.dps=mpm.dps
gpm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = dpm
#ctxm = gpm
ctxm = mpm


demo_10(ctxm)



