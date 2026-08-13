# -*- coding: utf-8 -*-


from xlcalcnet.mpmath import plot

from xlcalcnet import mpm

from xlcalcnet.ctx12Asymptotic import ctxAsymptotic



#Noncentral t-distribution, moments)

def student_t_nc_pdf_moments_quad():
    n = 20
    delta = -2
    res = 1

    print("start student_t_nc2_pdf_moments_quad():")
    mu1 = mpm.quad(lambda y: (y*mpm.student_t_nc_pdf(y, n, delta)), [-mpm.inf(), mpm.inf()])
    print("mu1:", mu1)
    mu2 = mpm.quad(lambda y: (y*y*mpm.student_t_nc_pdf(y, n, delta)), [-mpm.inf(), mpm.inf()])
    print("mu2:", mu2)
    mu3 = mpm.quad(lambda y: (y*y*y*mpm.student_t_nc_pdf(y, n, delta)), [-mpm.inf(), mpm.inf()])
    print("mu3:", mu3)
    mu4 = mpm.quad(lambda y: (y*y*y*y*mpm.student_t_nc_pdf(y, n, delta)), [-mpm.inf(), mpm.inf()])
    print("mu4:", mu4)

    plot(lambda y: (mpm.student_t_nc_pdf(y, n, delta)), [-10, 10])
    plot(lambda y: (y*mpm.student_t_nc_pdf(y, n, delta)), [-10, 10])
    plot(lambda y: (y*y*mpm.student_t_nc_pdf(y, n, delta)), [-10, 10])
    plot(lambda y: (y*y*y*mpm.student_t_nc_pdf(y, n, delta)), [-10, 10])
    plot(lambda y: (y*y*y*y*mpm.student_t_nc_pdf(y, n, delta)), [-10, 10])

    return res



def demo_student_t_nc_moments():
    ctx = mpm
    ctx.dps=10
    k = 4
    n = 20
    delta = -2
    mraw = ctxAsymptotic().student_t_nc2_moments(ctx, k, n, delta, 0)
    student_t_nc_pdf_moments_quad()
    return mraw




def demo_student_t_nc_cumulants():
    ctx = mpm
    ctx.dps=20
    k = 8
    n = 200
    delta = -12
    mraw = ctxAsymptotic().student_t_nc2_moments(ctx, k, n, delta, 0)
    kappa = mpm.cumulants_from_rawmoments(mraw)
    for i in range(1,k+1):
        print("i:", i, "kappa(i):", kappa[i])
    x = kappa[1] * 1.2
    L1, R1 = mpm.edgeworth(x, k-2, kappa)
    print("edgeworth  L1: ", L1, " R1: ",  R1)
    L2 = mpm.student_t_nc_cdf(x, n, delta)
    print("edgeworth  L2: ", L2)





def demo_student_t_nc2_cumulants():
    ctx = mpm
    ctx.dps=20
    k = 12
    n = 200
    delta = 12
    theta = 40
    mraw = ctxAsymptotic().student_t_nc2_moments(ctx, k, n, delta, theta)
    kappa = mpm.cumulants_from_rawmoments(mraw)
    for i in range(1,k+1):
        print("i:", i, "kappa(i):", kappa[i])
    x = kappa[1] / 1.2
    L1, R1 = mpm.edgeworth(x, k-2, kappa)
    print("edgeworth  L1: ", L1, " R1: ",  R1)
    L2 = mpm.student_t_nc2_cdf(x, n, delta, theta)
    print("edgeworth  L2: ", L2)





def testnew():
    n = 20
    delta = -2
    theta = 0
    t2 = theta/2
    #theta = 0
    for i in range(-60,20):
        x = mpm.t(i) / 10
        res1 = mpm.student_t_nc2_pdf(x, n, delta, theta)
        F1 = mpm.exp(-t2) * mpm.hyp1f1((n+1)/2,n/2,(t2/(1+x*x/n)))
        res2 = mpm.student_t_nc_pdf(x, n, delta) * F1
        print("i:", i, "res1:", res1, "res2:", res2, "F1:",res1/res2, F1)

    return


#Doubly Noncentral t-distribution, moments)

def student_t_nc2_pdf_moments_quad():
    n = 20
    delta = -2
    theta = 4
    #delta = 0
    res = 1

    print("start student_t_nc2_pdf_moments_quad():")
    mu1 = mpm.quad(lambda y: (y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-mpm.inf(), mpm.inf()])
    print("mu1:", mu1)
    mu2 = mpm.quad(lambda y: (y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-mpm.inf(), mpm.inf()])
    print("mu2:", mu2)
    mu3 = mpm.quad(lambda y: (y*y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-mpm.inf(), mpm.inf()])
    print("mu3:", mu3)
    mu4 = mpm.quad(lambda y: (y*y*y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-mpm.inf(), mpm.inf()])
    print("mu4:", mu4)

    plot(lambda y: (mpm.student_t_nc2_pdf(y, n, delta, theta)), [-10, 10])
    plot(lambda y: (y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-10, 10])
    plot(lambda y: (y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-10, 10])
    plot(lambda y: (y*y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-10, 10])
    plot(lambda y: (y*y*y*y*mpm.student_t_nc2_pdf(y, n, delta, theta)), [-10, 10])

    return res



def demo_student_t_nc2_moments():
    ctx = mpm
    ctx.dps=10
    k = 4
    n = 20
    delta = -2
    theta = 4
    mraw = ctxAsymptotic().student_t_nc2_moments(ctx, k, n, delta, theta)
    student_t_nc2_pdf_moments_quad()
    return mraw




#Doubly Noncentral F-distribution, moments)

def fisher_f_nc_pdf_moments_quad():
    n1 = 20
    n2 = 200
    lambda1 = 10
    #lambda2 = 0
    res = 1
    mu1 = mpm.quad(lambda y: (y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, mpm.inf()])
    print("mu1:", mu1)
    mu2 = mpm.quad(lambda y: (y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, mpm.inf()])
    print("mu2:", mu2)
    mu3 = mpm.quad(lambda y: (y*y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, mpm.inf()])
    print("mu3:", mu3)
    mu4 = mpm.quad(lambda y: (y*y*y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, mpm.inf()])
    print("mu4:", mu4)

    plot(lambda y: mpm.fisher_f_nc_pdf(y, n1, n2, lambda1), [0, 4])
    plot(lambda y: (y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, 4])
    plot(lambda y: (y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, 4])
    plot(lambda y: (y*y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, 4])
    plot(lambda y: (y*y*y*y*mpm.fisher_f_nc_pdf(y, n1, n2, lambda1)), [0, 4])
    return res


def demo_fisher_f_nc_moments():
    ctx = mpm
    ctx.dps=10
    k = 7
    n1 = 20
    n2 = 200
    lambda1 = 10
    mraw = ctxAsymptotic().fisher_f_nc_moments(ctx, k, n1, n2, lambda1)
    fisher_f_nc_pdf_moments_quad()
    return mraw


def demo_fisher_f_nc_cumulants():
    ctx = mpm
    ctx.dps=30
    k = 8
    n1 = 3
    n2 = 300
    lambda1 = 1000
    mraw = ctxAsymptotic().fisher_f_nc_moments(ctx, k, n1, n2, lambda1)
    kappa = mpm.cumulants_from_rawmoments(mraw)
    for i in range(1,k+1):
        print("i:", i, "kappa(i):", kappa[i])
    x = kappa[1] * 1.2
    L1, R1 = mpm.edgeworth(x, k-2, kappa)
    print("edgeworth  L1: ", L1, " R1: ",  R1)
    L2 = mpm.fisher_f_nc_cdf(x, n1, n2, lambda1)
    print("edgeworth  L2: ", L2)



def demo_fisher_f_nc2_cumulants():
    ctx = mpm
    ctx.dps=30
    k = 8
    n1 = 3
    n2 = 300
    lambda1 = 1000
    lambda2 = 50
    mraw = ctxAsymptotic().fisher_f_nc2_moments(ctx, k, n1, n2, lambda1, lambda2)
    kappa = mpm.cumulants_from_rawmoments(mraw)
    for i in range(1,k+1):
        print("i:", i, "kappa(i):", kappa[i])
    x = kappa[1] / 1.2
    L1, R1 = mpm.edgeworth(x, k-2, kappa)
    print("edgeworth  L1: ", L1, " R1: ",  R1)
    L2 = mpm.fisher_f_nc2_cdf(x, n1, n2, lambda1, lambda2)
    print("edgeworth  L2: ", L2)
    return mraw



#Doubly Noncentral F-distribution, moments)

def fdisnc2_pdf_moments_quad():
    n1 = 20
    n2 = 200
    lambda1 = 10
    lambda2 = 15
    res = 1
    mu1 = mpm.quad(lambda y: (y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, mpm.inf()])
    print("mu1:", mu1)
    mu2 = mpm.quad(lambda y: (y*y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, mpm.inf()])
    print("mu2:", mu2)
    mu3 = mpm.quad(lambda y: (y*y*y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, mpm.inf()])
    print("mu3:", mu3)
    mu4 = mpm.quad(lambda y: (y*y*y*y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, mpm.inf()])
    print("mu4:", mu4)

    plot(lambda y: (mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, 4])
    plot(lambda y: (y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, 4])
    plot(lambda y: (y*y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, 4])
    plot(lambda y: (y*y*y*mpm.fisher_f_nc2_pdf(y, n1, n2, lambda1, lambda2)), [0, 4])
    return res


def demo_fisher_f_nc2_moments():
    ctx = mpm
    ctx.dps=10
    k = 4
    n1 = 20
    n2 = 200
    lambda1 = 10
    lambda2 = 15
    mraw = ctxAsymptotic().fisher_f_nc2_moments(ctx, k, n1, n2, lambda1, lambda2)
    fdisnc2_pdf_moments_quad()
    return mraw



# used for recurrences noncentral F
def Gdis(X, m, n, lambda1, lambda2):
  F = X * n / m
  L1 = mpm.fdisnc2_cdf(F, m, n, lambda1, lambda2)
  return L1



# used for recurrences noncentral F
def Gdens(X, m, n, lambda1, lambda2):
    if m <= 2 :
      print( "Error! m needs to be > 2")
      return 0
    l1 = Gdis(X, m, n + 2, lambda1, lambda2)
    l2 = Gdis(X, m - 2, n + 2, lambda1, lambda2)
    return -(l1 - l2) * (n / 2)


# used for recurrences noncentral F
def demo_Gdens():
    x = 1.9
    m = 7
    n = 17
    lambda1 = 5
    lambda2 = 0
    L1 = Gdis(x, m, n, lambda1, lambda2)
    R1 = 1-L1
    print("L1: , R1: ", L1, R1)

    L1a = Gdis(x+0.001, m, n, lambda1, lambda2)
    R1a = 1-L1a
    print("L1a: , R1a: ", L1a, R1a)
    L1b = Gdis(x-0.001, m, n, lambda1, lambda2)
    R1b = 1-L1b
    print("L1b: , R1b: ", L1b, R1b)
    dens1 = (L1a-L1b)/0.002
    print("dens1:", dens1)

    dens2 = Gdens(x, m, n, lambda1, lambda2)
    print("dens2:", dens2)




def demo_rv_chisquared():
    mpm.dps = 30

    print("mpm:")
    rv = mpm.dist_chisquare(10)
    res = rv.pdf(8)
    print("pdf:", res)
    res = rv.cdf(15)
    print("cdf:", res)
    res = rv.sf(15)
    print("sf :", res)
    res = rv.qtf(0.6)
    print("qtf:", res)
    res = rv.isf(0.6)
    print("isf:", res)
    res = rv.c_x(0.2)
    print("c_x:", res)
    res = rv.m_x(0.2)
    print("m_x:", res)
    res = rv.k_x(0.2)
    print("k_x:", res)
    res = rv.saddleppoint('0.2')
    print("saddleppoint:", res)
    res = rv.cumulants(6)
    print("cumulants:", res)
    print()

    return



def demo_rv_chi2_nc():
    print("Test demo_rv_chi2_nc")
    mpm.dps = 30

    nu = 10
    lambda1 = 10
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_chi2_nc(nu, lambda1)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.chi2_nc_pdf(x, nu, lambda1)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.chi2_nc_cdf(x, nu, lambda1, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.chi2_nc_cdf(x, nu, lambda1, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.chi2_nc_qtf(q, nu, lambda1, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.chi2_nc_qtf(q, nu, lambda1, False)
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


#demo_rv_chi2_nc()

#demo_rv_chisquared()


demo_fisher_f_nc_cumulants()

#demo_fisher_f_nc2_cumulants()

#demo_student_t_nc_cumulants()

#demo_student_t_nc2_cumulants()

#testnew()

#demo_student_t_nc_moments()

#demo_student_t_nc2_moments()

#demo_fisher_f_nc_moments()

#demo_fisher_f_nc2_moments()



