# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm, dpm



# 13 Algebra with random variables



# 13.3 Probability density function (pdf)
def demo_13_3(ctx):
    return



# 13.4 Probability mass function (pmf)
def demo_13_4(ctx):
    return



# 13.5 Cumulative distribution function (cdf)
def demo_13_5(ctx):
    return



# 13.6 Percentage point function
def demo_13_6(ctx):
    return


# 13.7 Characteristic function
def demo_13_7(ctx):
    return


# 13.8 Moment generating function
def demo_13_8(ctx):

    #13.8.6 Calculating the moment-generating function from the pmf vector
    def demo_mgf_from_pmf():
        t = 0.7
        n=20
        p = 0.8
        pmf = mpm.binomial_pmf_vector(n, p)
        msum = mpm.mgf_from_pmf_vector(t, pmf)
        print("msum:", msum)
        mgf = (1-p+p*mpm.exp(t))**n
        print("mgf :", mgf)

    demo_mgf_from_pmf()
    return



# 13.9 Cumulant generating function
def demo_13_9(ctx):

    #13.9.5 Calculating the cumulant-generating function from the the pmf vector
    def demo_cgf_from_pmf():
        t = 0.7
        n=20
        p = 0.8
        pmf = mpm.binomial_pmf_vector(n, p)
        csum = mpm.cgf_from_pmf_vector(t, pmf)
        print("csum:", csum)
        cgf = n * mpm.ln(p*mpm.exp(t) + 1 - p)
        print("cgf :", cgf)

    demo_cgf_from_pmf()
    return



# 13.10 Probability generating function
def demo_13_10(ctx):

    # 13.10 Probability generating function
    def demo_pgf_from_pmf():
        t = 0.2
        n=20
        p = 0.8
        gsum = 0.0
        msum = 0.0
        for k in range(0,n+1):
            px = fpm.binomial_pmf(k,n,p)
            gsum = gsum + px * t**k
            msum = gsum + px * fpm.exp(t)**k
            print("k:", k, "px:", px)
        print("gsum:", gsum)
        pgf = (1-p+p*t)**n
        print("pgf :", pgf)
        print("msum:", msum)
        pgf = (1-p+p*fpm.exp(t))**n
        print("mgf :", msum)
        return

    #demo_pgf_from_pmf()   #error
    return



# 13.11 Factorial Moments


# 13.12 Raw Moments


# 13.13 Central Moments


# 13.14 Cumulants





def demo_13(ctx):
    demo_13_3(ctx)
    demo_13_4(ctx)
    demo_13_5(ctx)
    demo_13_6(ctx)
    demo_13_7(ctx)
    demo_13_8(ctx)
    demo_13_9(ctx)
    demo_13_10(ctx)
    return



mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dpm
ctxm = mpm


demo_13(ctxm)

