# -*- coding: utf-8 -*-

from xlcalcnet import mpm

from xlcalcnet.ctx12Asymptotic import ctxAsymptotic


def demo_rv_signtest_MISSING():
    print("Test demo_rv_wilcoxon_MISSING")
    N = 30
    x, nl = mpm.signtest_pmf_vector(N)
    for i in range(0, nl+0):
        print("i:", i,  "x(i):", x[i])


def demo_rv_wilcoxon():
    print("Test demo_rv_wilcoxon, part1")
    N = 10
    x, nl = mpm.wilcoxon_full_vector(N, False, True)


    print()
    print("Test demo_rv_wilcoxon, part2")

    def wilcoxon_cx(ctx, t, n):
        prod = 1
        for h in range(1, n+1):
            prod = prod*mpm.cosh(1j*h*t/2)
        d = mpm.exp(n*(n+1)*1j*t/4)
        res = d * prod
        #print("res:", res)
        return res

    def wilcoxon_cx2(ctx, t, x, n):
        prod = 1
        for h in range(1, n+1):
            prod = prod*mpm.cosh(1j*h*t/2)
        d = mpm.exp(n*(n+1)*1j*t/4)
        res = d * prod
        e = mpm.exp(-1j*t*x)
        res2 = e * res
        #print("res:", res)
        return res2

    def demo_wilcoxon_cx_inversion_pmf(ctx):
        print("demo_wilcoxon_cx_inversion_pmf()")
        mpm.dps = 15
        N = 5
        #x = N * (N+1) // 4
        xvec, nl = mpm.wilcoxon_full_vector(N, False)
        print(xvec)
        sum1 = 0
        for x in range(0, 3+1):
            #    x = 4
            #    plot(lambda y: wilcoxon_cx(y, N), [-mpm.pi, mpm.pi])
            #plot(lambda y: wilcoxon_cx2(y, x, N), [-mpm.pi, mpm.pi])
            res0 = mpm.quad(lambda y:  wilcoxon_cx2(ctx, y, x, N), [-mpm.pi, mpm.pi])
            print("x:", x, "quad: ", res0)
            res = res0 / (2*mpm.pi)
            print("x:", x, "res: ", res)
            sum1 = sum1 + res
            print("x:", x, "sum1: ", sum1)

    def wilcoxon_cx3(ctx, t, x, n):
        res = wilcoxon_cx(ctx, t, n)
        s = 1
        if x > 0:
            e1 = mpm.exp(-1j*t)
            e = e1
            s = s + e
            if x > 1:
                for z in range(2, x+1):
                    e = e * e1
                    s = s + e
        res2 = s * res
        return mpm.real(res2)
        # return res2

    def demo_wilcoxon_cx_inversion_cdf(ctx):
        print("demo_wilcoxon_cx_inversion_cdf()")
        mpm.dps = 15
        N = 5
        #x = N * (N+1) // 4
        x = 4
        xvec, nl = mpm.wilcoxon_full_vector(N, True)
        print(xvec)
        #plot(lambda y: wilcoxon_cx3(y, x, N), [-1, 1])
        res0 = mpm.quad(lambda y:  wilcoxon_cx3(ctx, y, x, N), [0, mpm.pi])
        print("quad: ", res0)
        res = res0 / (mpm.pi)
        print("res: ", res)

    def wilcoxon_cx4(ctx, t, x, n):
        res = wilcoxon_cx(ctx, t, n)
        nmax = n*(n+1)//2
        s = mpm.exp(-1j*t*(x+1))
        if x > 0:
            e1 = mpm.exp(-1j*t)
            e = s
            if x > 1:
                for z in range(x+2, nmax+1):
                    e = e * e1
                    s = s + e
        res2 = s * res
        return mpm.real(res2)
        # return res2

    def demo_wilcoxon_cx_inversion_sf(ctx):
        print("demo_wilcoxon_cx_inversion_cdf()")
        mpm.dps = 15
        N = 5
        #x = N * (N+1) // 4
        x = 13
        xvec, nl = mpm.wilcoxon_full_vector(N, True)
        print(xvec)
        #plot(lambda y: wilcoxon_cx4(y, x, N), [-1, 1])
        res0 = mpm.quad(lambda y:  wilcoxon_cx4(ctx, y, x, N), [0, mpm.pi])
        print("quad: ", res0)
        res = res0 / (mpm.pi)
        print("res: ", res)

    demo_wilcoxon_cx_inversion_pmf(mpm)
    demo_wilcoxon_cx_inversion_cdf(mpm)
    demo_wilcoxon_cx_inversion_sf(mpm)


    print()
    print("Test demo_rv_wilcoxon, part3")

    def demo_wilcoxon_factorial_moments(ctx):
        print("demo_wilcoxon_factorial_moments()")
        mpm.dps = 160
        N = 10
        order = N * (N+1) // 2
        #order = 15
        kappa = ctxAsymptotic().wilcoxon_cumulants(mpm, N, order+3)
        mraw = mpm.rawmoments_from_cumulants(kappa)
    #    for i in range(1,order+1):
    #        print("i:", i, "mraw(i):", mraw[i])
        mfac = mpm.factorialmoments_from_rawmoments(mraw)
    #    for i in range(1,order+1):
    #        print("i:", i, "mfac(i):", mfac[i])
        xvec, nl = mpm.wilcoxon_full_vector(N, True)
        print(xvec)
        x = order // 2
        sum1 = 0
        sum2 = 0
        for j in range(x, order+2):
            s = (-1)**(x+j)
            b1 = mpm.binomial(j, x)
            b2 = mpm.binomial(j-1, x-1)
            m = mfac[j]
            f = mpm.factorial(j)
            t1 = s*b1*m/f
            t2 = s*b2*m/f
            sum1 = sum1 + t1
            sum2 = sum2 + t2
            print(j, t1, t2)
            #print(j, s, b, m, f)
        print("sum1", sum1)
        print("sum2", sum2)


    demo_wilcoxon_factorial_moments(mpm)



    print()
    print("Test demo_rv_wilcoxon, part4")

    def demo_wilcoxon_cumulants(ctx):
        print("demo_wilcoxon_cumulants()")
        mpm.dps = 30
        N = 20
        order = 10
        # %%% This just to check that the cumulants are correct:
        x, nl = mpm.wilcoxon_full_vector(N, False)
        mpm.cumulants_from_pmfvector(x, nl, order, True)
        print("demo_wilcoxon_cumulants()")
        kappa = ctxAsymptotic().wilcoxon_cumulants(mpm, N, order+3)
        for i in range(1, order+3):
            print("i:", i, "kappa:", kappa[i])
        kappa = mpm.sheppard_correction(kappa, True)
        x = mpm.t(int(kappa[1]-75))
        print("x0: ", x)
        L1, R1 = mpm.edgeworth(x+0.5, order, kappa)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        x, nl = mpm.wilcoxon_full_vector(N, True, True, x-2, x+3)

    def demo_wilcoxon_ecf(ctx):
        print("demo_wilcoxon_ecf()")
        mpm.dps = 30
        N = 20
        order = 10
        x = mpm.t(int(N*(N+1)/4-75))
        print("x00: ", x)
        L1, R1 = mpm.wilcoxon_ecf(x, N, order)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        x, nl = mpm.wilcoxon_full_vector(N, True, True, x-2, x+3)

    def demo_wilcoxon_ecf_inv(ctx):
        print("demo_wilcoxon_ecf_inv()")
        mpm.dps = 30
        L1 = mpm.convert("0.01")
        R1 = 1 - L1
        N = 40
        order = 15
        X1 = mpm.wilcoxon_ecf_inv(L1, R1, N, order)
        print("X1: ", X1)
        mpm.wilcoxon_full_vector(N, True, True, X1-2, X1+3)

    demo_wilcoxon_cumulants(mpm)
    demo_wilcoxon_ecf(mpm)
    demo_wilcoxon_ecf_inv(mpm)


    return



def demo_rv_bennett_MISSING():
    print("Test demo_rv_bennett_MISSING")


def demo_rv_mann_whitney():
    print("Test demo_rv_mann_whitney")
    mpm.dps = 30
    m = 18
    n = 18
    pprob, panz = mpm.mann_whitney_u_pmf_vector(m, n)
    for i in range(panz+1):
        print("i:", i, "pprob[i]:", pprob[i])


    def demo_MannWhitneyCum(ctx):
        mpm.dps = 30
        k = 2
        n = [0, 20, 20]
        maxcum = 12
        kappa, nl = ctxAsymptotic().TerpstaCum(mpm, k, n, maxcum)
        for i in range(1, maxcum+1):
            print("i:", i, "kappa:", kappa[i])
        return

    demo_MannWhitneyCum(mpm)
    return


def demo_rv_mann_whitney_u_lehmann_MISSING():
    print("Test demo_rv_mann_whitney_u_lehmann_MISSING")
    kValue = 2
    N1 = 8
    n2 = 8
    pprob, panz = mpm.mannwhitney_u_lehmann_pmf_vector(kValue, N1, n2)
    print("Final Result")
    pcum = 0
    for i in range(0, panz+1):
        p = pprob[i]
        pcum = pcum + p
        print("i:", i, "p:", p, "pcum:", pcum)




def demo_rv_mann_whitney_u_milton_MISSING():
    print("Test demo_rv_mann_whitney_u_milton_MISSING")


def demo_rv_kendall_tau():
    print("Test demo_rv_kendall_tau, part1")
    mpm.dps = 20
    n = 20
    print("pmf:")
    x, nl = mpm.kendall_full_vector(n, False, True)
    print("cdf:")
    x, nl = mpm.kendall_full_vector(n, True, True)

    print()
    print("Test demo_rv_kendall_tau, part2")
    def kendall_gx(ctx, t, N):
        prod = 1
        for k in range(1, N+1):
            prod = prod*(t**k-1)/(t-1)
        res = prod/mpm.factorial(N)
        return res

    def kendall_cx_old(ctx, t, N):
        return kendall_gx(mpm.exp(1j*t), N)

    def kendall_cx(ctx, t, N):
        prod = 1
        et = mpm.exp(1j*t)
        for k in range(1, N+1):
            prod = prod*(et**k-1)/(et-1)
        res = prod/mpm.factorial(N)
        return res

    def kendall_cx2(ctx, t, x, N):
        res = kendall_gx(ctx, mpm.exp(1j*t), N)
        e = mpm.exp(-1j*t*x)
        res2 = e * res
        return mpm.real(res2)

    def demo_kendall_cx_inversion_pmf(ctx):
        print("demo_kendall_cx_inversion_pmf()")
        mpm.dps = 15
        N = 8
        xvec, nl = mpm.kendall_full_vector(N, False, True)
        x = 12
        #plot(lambda y: kendall_cx2(y, x, N), [-mpm.pi, mpm.pi])
        res0 = 2 * mpm.quad(lambda y:  kendall_cx2(ctx, y, x, N), [0, mpm.pi])
        res = res0 / (2*mpm.pi)
        print("x:", x, "quad: ", res)
        print(res/xvec[x])

    demo_kendall_cx_inversion_pmf(mpm)


    print()
    print("Test demo_rv_kendall_tau, part3")

    def demo_kendall_cumulants(ctx):
        mpm.dps = 40
        N = 40
        order = 12
        kappa = ctxAsymptotic().kendall_cumulants(mpm, N, order)
        for i in range(1, order+1):
            print("i:", i, "kappa:", kappa[i])
        x, nl = mpm.kendall_full_vector(N, False, False)
        mpm.cumulants_from_pmfvector(x, nl, order, True)
        return

    def demo_kendall_ecf(ctx):
        print("demo_kendall_ecf()")
        mpm.dps = 30
        N = 16
        order = 10
        x = mpm.t(int(N*(N-1)/4-5))
        print("x00: ", x)
        L1, R1 = mpm.kendall_ecf(x, N, order)
        print("edgeworth  L1: ", L1, " R1: ",  R1)
        x, nl = mpm.kendall_full_vector(N, True, True, x-2, x+3)

    def demo_kendall_ecf_inv(ctx):
        print("demo_kendall_ecf_inv()")
        mpm.dps = 30
        L1 = mpm.convert("0.01")
        R1 = 1 - L1
        N = 40
        order = 15
        X1 = mpm.kendall_ecf_inv(L1, R1, N, order)
        print("X1: ", X1)
        mpm.kendall_full_vector(N, True, True, X1-2, X1+3)

    demo_kendall_cumulants(mpm)
    demo_kendall_ecf(mpm)
    demo_kendall_ecf_inv(mpm)
    return




def demo_rv_jterpsta_s():
    print("Test demo_rv_jterpsta_s")
    mpm.dps = 25
    k = 5
    n = [0, 3, 3, 3, 3, 3]
    #n = [0,8,8,8,8,8]
    pprob, panz = mpm.jterpsta_s_pmf_vector(k, n)
    for i in range(panz+1):
        print("i:", i, "pprob[i]:", pprob[i])


    def demo_TerpstaCum(ctx):
        k = 3
        n = [0, 20, 20, 20]
        maxcum = 12
        kappa, nl = ctxAsymptotic().TerpstaCum(mpm, k, n, maxcum)
        for i in range(1, maxcum+1):
            print("i:", i, "kappa:", kappa[i])
        return

    demo_TerpstaCum(mpm)
    return


def demo_rv_spearman_MISSING():
    print("Test demo_rv_spearman_MISSING")
    mpm.dps = 20
    k = 9
    Order = 1
    pprob, panz = mpm.spearman_rho_pmf_vector(k, Order)
    for i in range(panz+1):
        print("i:", i, "pprob[i]:", pprob[i])



def demo_rv_page_l_MISSING():
    print("Test demo_rv_page_l_MISSING")
    mpm.dps = 25
    k = 3
    N = 10
    x, nl = mpm.page_l_pmf_vector(k, N)
    for i in range(0, nl+0):
        print("i:", i,  "x(i):", x[i])



def demo_rv_quadepage_l_MISSING():
    print("Test demo_rv_quadepage_l_MISSING")
    mpm.dps = 25
    k = 3
    N = 10
    x, nl = mpm.quade_l_pmf_vector(k, N)
    for i in range(0, nl+0):
        print("i:", i,  "x(i):", x[i])



def demo_rv_page_l_nc_milton_MISSING():
    print("Test demo_rv_page_l_nc_milton_MISSING")


#demo_rv_signtest_MISSING()

#demo_rv_wilcoxon()
#demo_rv_bennett_MISSING()
#demo_rv_mann_whitney()
#demo_rv_mann_whitney_u_lehmann_MISSING()

#demo_rv_mann_whitney_u_milton_MISSING()
#demo_rv_kendall_tau()
demo_rv_jterpsta_s()

#demo_rv_spearman_MISSING()
#demo_rv_page_l_MISSING()
#demo_rv_quadepage_l_MISSING()
#demo_rv_page_l_nc_milton_MISSING()








