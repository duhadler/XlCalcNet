# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm, dpm


# 11 Fast approximations without error estimates



# 11.1 Approximations based on the normal distribution
def demo_11_1_normal(ctx):



    # 11.1.7 Pearson’s rho distribution: cdf and sf (Winterbottom)
    def demo_pearson_rho_wb_cdf(ctx):
        N = 20
        r = 0.1
        rho = 0.4
        alpha = mpm.pearson_rho_wb_cdf(N, r, rho)
        print("alpha:", alpha)
        l = alpha
        r2 = mpm.pearson_rho_wb_qtf(l, 1-l, N, rho)
        print("r2:", r2)



    # 11.1.12 Singly noncentral t: qtf, isf (Harley)
    def demo_student_t_nc_harley_qtf(ctx):
        N = 60
        alpha = 0.2
        delta = 1.5
    #        t4 = fpm.student_t_nc_qtf(alpha, N-2, delta)
    #        print("t4:", t4)
        t5 = mpm.student_t_nc_harley_qtf(alpha, N-2, delta)
        print("t5:", t5)
        return






# 11.3 Approximations based on the central 𝑡, 𝐹 or beta distribution
def demo_11_3_beta(ctx):



    # 11.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)
    def demo_fisher_f_nc_cdf(ctx):
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


    # 11.3.3 Singly non-central F distribution: qtf, isf (Patnaik)
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



    # 11.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)
    def demo_fisher_f_nc2_cdf(ctx):
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


    # 11.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)
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


    # 11.3.7 Multiple correlation coefficient: cdf, sf (Lee and Gurland)
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
        print(ctx)


    # 11.3.8 Multiple correlation coefficient: qtf, isf (Lee and Gurland)
    def demo_fisher_r2_qtf(ctx):
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
        print(ctx)


    # 11.3.10 Central Wilks’ Lambda: cdf, sf (Rao)
    def demo_wilks_lambda_rao_cdf(ctx):
    #        '  p: # of variables in 1. set
    #        '  q: # of variables in 2. set
    #        '  n: # of cases-1 }
        p = 4
        q = 7
        n = 100
        LeftTail = 0.9
        RightTail = 1 - LeftTail
        resultX = mpm.wilks_lambda_rao_qtf(LeftTail, RightTail, p, q - 1, n - q)
        print("resultX:", resultX)
        resultL = -mpm.log(resultX)
        print("resultL:", resultL)
        resultM = -n * mpm.log(resultX)
        print("resultM:", resultM)
        p_rao = mpm.wilks_lambda_rao_cdf(resultX, p, q - 1, n - q)
        print("p_rao:", p_rao)



    # 11.3.11 Central Wilks’ Lambda: qtf, isf (Rao)
    def demo_wilks_lambda_rao_qtf(ctx):
    #        '  p: # of variables in 1. set
    #        '  q: # of variables in 2. set
    #        '  n: # of cases-1 }
        p = 4
        q = 7
        n = 100
        LeftTail = 0.9
        RightTail = 1 - LeftTail
        resultX = mpm.wilks_lambda_rao_qtf(LeftTail, RightTail, p, q - 1, n - q)
        print("resultX:", resultX)
        resultL = -mpm.log(resultX)
        print("resultL:", resultL)
        resultM = -n * mpm.log(resultX)
        print("resultM:", resultM)
        p_rao = mpm.wilks_lambda_rao_cdf(resultX, p, q - 1, n - q)
        print("p_rao:", p_rao)




    # 11.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)
    def demo_beta_product_mu3_cdf(ctx):
    #        '  p: # of variables in 1. set
    #        '  q: # of variables in 2. set
    #        '  n: # of cases-1 }
        p = 4
        q = 7
        n = 100
        LeftTail = 0.9
        RightTail = 1 - LeftTail
    #        resultX = mpm.wilks_lambda_rao_qtf(LeftTail, RightTail, p, q - 1, n - q)
    #        print("resultX:", resultX)
    #        resultL = -mpm.log(resultX)
    #        print("resultL:", resultL)
    #        resultM = -n * mpm.log(resultX)
    #        print("resultM:", resultM)
    #        p_rao = mpm.wilks_lambda_rao_cdf(resultX, p, q - 1, n - q)
    #        print("p_rao:", p_rao)

        resultX = mpm.wilks_lambda_bp_qtf(LeftTail, RightTail, p, q - 1, n - q)
        print("resultX:", resultX)
        resultL = -mpm.log(resultX)
        print("resultL:", resultL)
        resultM = -n * mpm.log(resultX)
        print("resultM:", resultM)
        p_bp = mpm.wilks_lambda_bp_cdf(resultX, p, q - 1, n - q)
        print("p_bp:", p_bp)
    #        p_bp1 = mpm.wilks_lambda_bp_cdf(resultX-0.0001, p, q - 1, n - q)
    #        print("p_bp1:", p_bp1)
    #        p_bp2 = mpm.wilks_lambda_bp_cdf(resultX+0.0001, p, q - 1, n - q)
    #        print("p_bp2:", p_bp2)
    #        dens = (p_bp1 - p_bp2) / (0.0002)
    #        print("dens:", dens)
        dens = mpm.wilks_lambda_bp_pdf(resultX, p, q - 1, n - q)
        print("dens:", dens)


    # 11.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)
    def demo_beta_product_mu3_qtf(ctx):
    #        '  p: # of variables in 1. set
    #        '  q: # of variables in 2. set
    #        '  n: # of cases-1 }
        p = 4
        q = 7
        n = 100
        LeftTail = 0.9
        RightTail = 1 - LeftTail
        resultX = mpm.wilks_lambda_rao_qtf(LeftTail, RightTail, p, q - 1, n - q)
        print("resultX:", resultX)
        resultL = -mpm.log(resultX)
        print("resultL:", resultL)
        resultM = -n * mpm.log(resultX)
        print("resultM:", resultM)
        p_rao = mpm.wilks_lambda_rao_cdf(resultX, p, q - 1, n - q)
        print("p_rao:", p_rao)

        resultX = mpm.wilks_lambda_bp_qtf(LeftTail, RightTail, p, q - 1, n - q)
        print("resultX:", resultX)
        resultL = -mpm.log(resultX)
        print("resultL:", resultL)
        resultM = -n * mpm.log(resultX)
        print("resultM:", resultM)
        p_bp = mpm.wilks_lambda_bp_cdf(resultX, p, q - 1, n - q)
        print("p_bp:", p_bp)


    demo_fisher_f_nc_cdf(ctx)
    demo_fisher_f_nc_qtf(ctx)
    demo_fisher_f_nc2_cdf(ctx)
    demo_fisher_f_nc2_qtf(ctx)
    demo_fisher_r2_cdf(ctx)
    demo_fisher_r2_qtf(ctx)
    demo_wilks_lambda_rao_cdf(ctx)
    demo_wilks_lambda_rao_qtf(ctx)
    demo_beta_product_mu3_cdf(ctx)
    demo_beta_product_mu3_qtf(ctx)
    return






def demo_11(ctx):
    demo_11_1_normal(ctx)
    demo_11_3_beta(ctx)
    return



mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dec
ctxm = mpm


demo_11(ctxm)



