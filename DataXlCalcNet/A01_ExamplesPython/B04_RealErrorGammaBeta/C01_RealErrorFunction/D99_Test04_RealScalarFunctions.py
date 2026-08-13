# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot

from xlcalcnet import mpm, ipm, dpm


# 4 Real scalar functions and their inversess


# 4.1 Error functions
def demo_4_1_real_error_function(ctx):


    # 4.1.1 Error function erf
    def demo_real_erf(ctx):
        print("demo_real_erf")
        return

    # 4.1.2 Complementary error function erfc
    def demo_real_erfc(ctx):
        print("demo_real_erfc")
        return

    # 4.1.3 Inverse of the real error function
    def demo_real_erfinv(ctx):
        print("demo_real_erfinv")
        return

    # 4.1.4 Inverse of the real complementory error function
    def demo_real_erfcinv(ctx):
        print("demo_real_erfcinv")
        return

    # 4.1.5 Standard normal density function
    def demo_ndens(ctx):
        print("demo_ndens")
        return

    # 4.1.6 Standard normal cumulative distribution function
    def demo_ndis(ctx):
        print("demo_ndis")
        return

    # 4.1.7 Standard normal percentage point function
    def demo_ndis_inv(ctx):
        print("demo_ndis_inv")
        return

    demo_real_erf(ctx)
    demo_real_erfc(ctx)
    demo_real_erfinv(ctx)
    demo_real_erfcinv(ctx)
    demo_ndens(ctx)
    demo_ndis(ctx)
    demo_ndis_inv(ctx)


# 4.2 Incomplete gamma functions for real arguments and parameters
def demo_4_2_real_incomplete_gamma_function(ctx):

    # 4.2.1 Real lower non-normalised incomplete gamma function,
    def demo_real_gamma_lower(ctx):
        print("demo_real_gamma_lower")
        return

    # 4.2.2 Real upper non-normalised incomplete gamma function,
    def demo_real_gamma_upper(ctx):
        print("demo_real_gamma_upper")
        return


    # 4.2.3 Real lower normalised incomplete gamma function, P(a, x)
    def demo_real_gamma_p(ctx):
        print("demo_real_gamma_p")
        mpm.dps = 40
        a = '11023.1'
        x = '11134.1'
        mx = mpm.real_gamma_p(a, x, method='peizer')
        #mpm.show([mx])
        print(mx, '(peizer)')
        mx = mpm.real_gamma_p(a, x, method='mpmath')
        #mpm.show([mx])
        print(mx, '(mpmath)')
        mx = mpm.real_gamma_p(a, x, method='paris')
        #mpm.show([mx])
        print(mx, '(paris)')
        print()


    # 4.2.4 Real upper normalised incomplete gamma function, Q(a, x)
    def demo_real_gamma_q(ctx):
        print("demo_gamma_p_q")
        mpm.dps = 40
        a = '11023.1'
        x = '11134.1'
        mx = mpm.real_gamma_q(a, x, method='peizer')
        mpm.show([mx])
        mx = mpm.real_gamma_q(a, x, method='mpmath')
        mpm.show([mx])
        mx = mpm.real_gamma_q(a, x, method='paris')
        mpm.show([mx])
        print()



    # 4.2.6 Inverse of the real lower normalised incomplete gamma function
    def demo_real_gamma_p_inv(ctx):
        print("demo_real_gamma_p_inv")
        mpm.dps = 40
        a = '11023.1'
        p = '0.05'
        mx = mpm.real_gamma_p_inv(a, p, method='mpmath')
        mpm.show([mx])
        print()


    # 4.2.7 Inverse of the real upper normalised incomplete gamma function
    def demo_real_gamma_q_inv(ctx):
        print("demo_real_gamma_p_inv")
        mpm.dps = 40
        a = '11023.1'
        p = '0.05'
        mx = mpm.real_gamma_q_inv(a, p, method='mpmath')
        mpm.show([mx])
        print()




    # 4.2.10 Derivative of the incomplete gamma function
    def demo_real_gamma_derivative(ctx):
        print("demo_real_gamma_derivative")


    demo_real_gamma_lower(ctx)
    demo_real_gamma_upper(ctx)
    demo_real_gamma_p(ctx)
    demo_real_gamma_q(ctx)
    demo_real_gamma_p_inv(ctx)
    demo_real_gamma_q_inv(ctx)
    demo_real_gamma_derivative(ctx)



# 4.3 Incomplete beta functions for real arguments and parameters
def demo_4_3_real_incomplete_beta_function(ctx):


    # 4.3.1 Non-normalised incomplete beta function
    def demo_real_beta3(ctx):
        print("demo_real_beta3")


    # 4.3.2 Non-normalised complement of the incomplete beta function
    def demo_real_betac(ctx):
        print("demo_real_betac")


    # 4.3.3 Normalised incomplete beta function,
    def demo_real_ibeta(ctx):
        print("demo_ibeta():")
        mpm.dps = 40
        a = '8.3'
        b = '10.4'
        x = '0.97'
        mx = mpm.real_ibeta(a, b, x, method='cf')
        mpm.show([mx])
        mx = mpm.real_ibeta(a, b, x, method='mpmath')
        mpm.show([mx])
        print()


    # 4.3.4 Normalised complementory incomplete beta function,
    def demo_real_ibetac(ctx):
        print("demo_ibeta():")
        mpm.dps = 40
        a = '8.3'
        b = '10.4'
        x = '0.97'
        mx = mpm.real_ibetac(a, b, x, method='cf')
        mpm.show([mx])
        mx = mpm.real_ibetac(a, b, x, method='mpmath')
        mpm.show([mx])
        print()


    # 4.3.5 Inverse of the real normalised incomplete beta function
    def demo_real_ibeta_inv(ctx):
        print("demo_real_ibeta_inv")
        mpm.dps = 40
        a = '8.3'
        b = '10.4'
        p = '0.05'
        mx = mpm.real_ibeta_inv(a, b, p, method='mpmath')
        mpm.show([mx])
        print()


    # 4.3.6 Inverse of the real normalised complementary incomplete beta function
    def demo_real_ibetac_inv(ctx):
        print("demo_real_ibetac_inv")
        mpm.dps = 40
        a = '8.3'
        b = '10.4'
        p = '0.05'
        mx = mpm.real_ibetac_inv(a, b, p, method='mpmath')
        mpm.show([mx])
        print()



    # 4.3.11 Derivative of the incomplete beta function
    def demo_real_beta_derivative(ctx):
        print("demo_real_beta_derivative")

    demo_real_beta3(ctx)
    demo_real_betac(ctx)
    demo_real_ibeta(ctx)
    demo_real_ibetac(ctx)
    demo_real_ibeta_inv(ctx)
    demo_real_ibetac_inv(ctx)
    demo_real_beta_derivative(ctx)


def demo_4(ctx):
    #demo_4_1_real_error_function(ctx)
    demo_4_2_real_incomplete_gamma_function(ctx)
    #demo_4_3_real_incomplete_beta_function(ctx)
    return


mpm.dps=35
dpm.dps=mpm.dps
ipm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dec
ctxm = mpm


demo_4(ctxm)


