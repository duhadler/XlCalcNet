# -*- coding: utf-8 -*-

from xlcalcnet import mpm



def demo_rv_beta():
    print("Test demo_rv_beta")
    mpm.dps = 30

    a = 10
    b = 11
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_beta(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.beta_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.beta_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.beta_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.beta_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.beta_qtf(q, a, b, False)
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



def demo_rv_logbeta():
    print("Test demo_rv_logbeta")
    mpm.dps = 30

    a = 10
    b = 11
    x = 0.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_logrv_beta(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.logrv_beta_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.logrv_beta_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.logrv_beta_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.logrv_beta_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.logrv_beta_qtf(q, a, b, False)
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



def demo_rv_beta_prime_MISSING():
    print("Test demo_rv_beta_prime_MISSING")



def demo_rv_genbeta1_MISSING():
    print("Test demo_rv_genbeta1_MISSING")



def demo_rv_genbeta2_MISSING():
    print("Test demo_rv_genbeta2_MISSING")



def demo_rv_genlogistic_MISSING():
    print("Test demo_rv_genlogistic_MISSING")



def demo_rv_gen_beta_exp_MISSING():
    print("Test demo_rv_gen_beta_exp_MISSING")



def demo_rv_feller_pareto_MISSING():
    print("Test demo_rv_feller_pareto_MISSING")





def demo_rv_fisher_f():
    print("Test demo_rv_fisher_f")
    mpm.dps = 30

    a = 10
    b = 11
    x = 20.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_fisher_f(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.fisher_f_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.fisher_f_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.fisher_f_cdf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.fisher_f_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.fisher_f_qtf(q, a, b, False)
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




def demo_rv_fisher_z():
    print("Test demo_rv_fisher_z")
    mpm.dps = 30

    a = 10
    b = 11
    x = 2.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_fisher_z(a, b)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.fisher_z_pdf(x, a, b)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.fisher_z_cdf(x, a, b, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.fisher_z_sf(x, a, b, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.fisher_z_qtf(q, a, b, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.fisher_z_isf(q, a, b, False)
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




def demo_rv_student_t():
    print("Test demo_rv_student_t")
    mpm.dps = 30

    n = 10
    x = 2.75
    q = 0.8
    t = 0.51

    rv = mpm.dist_student_t(n)
    res = rv.pdf(x)
    print("pdf:", res)
    res2 = mpm.student_t_pdf(x, n)
    print("pdf:", res2)

    res = rv.cdf(x)
    print("cdf:", res)
    res2 = mpm.student_t_cdf(x, n, True)
    print("cdf:", res2)

    res = rv.sf(x)
    print("sf :", res)
    res2 = mpm.student_t_cdf(x, n, False)
    print("sf :", res2)

    res = rv.qtf(q)
    print("qtf:", res)
    res2 = mpm.student_t_qtf(q, n, True)
    print("qtf:", res2)

    res = rv.isf(q)
    print("isf:", res)
    res2 = mpm.student_t_qtf(q, n, False)
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




def demo_rv_skewt_MISSING():
    print("Test demo_rv_skewt_MISSING")



def demo_rv_pearson_rho_MISSING():
    print("Test demo_rv_pearson_rho_MISSING")







#demo_rv_beta()
#demo_rv_logbeta()

# demo_rv_beta_prime_MISSING()
# demo_rv_genbeta1_MISSING()
# demo_rv_genbeta2_MISSING()
# demo_rv_genlogistic_MISSING()
# demo_rv_gen_beta_exp_MISSING()
# demo_rv_feller_pareto_MISSING()

#demo_rv_fisher_f()
#demo_rv_fisher_z()
#demo_rv_student_t()

demo_rv_skewt_MISSING()
demo_rv_pearson_rho_MISSING()














