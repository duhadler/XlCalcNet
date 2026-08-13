# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gmp, ipm, dec, arb



# %%19 Hypergeometric functions 1F1 (Kummer), U (Tricomi), and related functions


class test19():




# %%% 19.1 Overview

# 19.1.1 Kummer’s Confluent Hypergeometric Function 1F1
    def demo_hyp1f1(self):
        print("demo_hyp1f1")

# 19.1.2 Regularized Kummer’s Confluent Hypergeometric Function 1F1
    def demo_hyp1f1r(self):
        print("demo_hyp1f1r")

# 19.1.3 Tricomi’s Confluent Hypergeometric Function U
    def demo_hyperu(self):
        print("demo_hyperu")




# %%% 19.2 Incomplete gamma functions

# 19.2.1 Incomplete gamma function, general form
    def demo_gammainc(self):
        print("demo_gammainc")

# 19.2.2 Lower non-normalised incomplete gamma function
    def demo_gamma_lower(self):
        print("demo_gamma_lower")

# 19.2.3 Upper non-normalised incomplete gamma function
    def demo_gamma_upper(self):
        print("demo_gamma_upper")

# 19.2.4 Lower normalised incomplete gamma function
    def demo_gamma_p(self):
        print("demo_gamma_p")

# 19.2.5 Upper normalised incomplete gamma function
    def demo_gamma_q(self):
        print("demo_gamma_q")

# 19.2.6 Tricomi’s entire incomplete gamma function
    def demo_gamma_tricomi(self):
        print("demo_gamma_tricomi")

# 19.2.7 Derivative of the incomplete gamma function
    def demo_gamma_derivative(self):
        print("demo_gamma_derivative")




# %%% 19.3 Error function and related functions

# 19.3.1 Error function erf
    def demo_erf(self):
        print("demo_erf")

# 19.3.2 Complementary error function erfc
    def demo_erfc(self):
        print("demo_erfc")

# 19.3.3 Scaled repeated integrals of erfc
    def demo_inerfc(self):
        print("demo_inerfc")

# 19.3.4 Imaginary error function erfi
    def demo_erfi(self):
        print("demo_erfi")

# 19.3.5 Dawson’s integral
    def demo_dawson(self):
        print("demo_dawson")

# 19.3.6 Fresnel sine integral
    def demo_fresnels(self):
        print("demo_fresnels")

# 19.3.7 Fresnel cosine integral
    def demo_fresnelc(self):
        print("demo_fresnelc")

# 19.3.8 Faddeeva function
    def demo_faddeeva(self):
        print("demo_faddeeva")

# 19.3.9 Voigt function U
    def demo_voigt_u(self):
        print("demo_voigt_u")

# 19.3.10 Voigt function V
    def demo_voigt_v(self):
        print("demo_voigt_v")

# 19.3.11 Voigt function H
    def demo_voigt_h(self):
        print("demo_voigt_h")



#Complex normal
    def demo_complex_normal(self):
# See also  https://github.com/fredrik-johansson/mpmath/issues/545
        print("demo_complex_normal")
        mpm.dps=15
        z = 100 + 1j

        print(mpm.cplxerfc(z))
        print(mpm.cplxerfc(-z))

        print()
        print(mpm.erfc(z))


        y = -z
        print(-mpm.erfc(y))

        print(mpm.erfc(-z))

        print("ARB")
        res = mpm.cplxerfc2(z)
        print(res)
        res = mpm.cplxerfc2(-z)
        print(res)

        print("NDIS")

        z1 =mpm.cplxndis(z)
        z2 =mpm.cplxndis2(z)
        print(z1)
        print(z2)






# %%% 19.4 Exponential integrals and related functions

# 19.4.1 Hyperbolic cosine integral Chi
    def demo_chi(self):
        print("demo_chi")

# 19.4.2 Cosine integral Ci
    def demo_ci(self):
        print("demo_ci")

# 19.4.3 Exponential integral E1
    def demo_e1(self):
        print("demo_e1")

# 19.4.4 Exponential integral Ei
    def demo_ei(self):
        print("demo_ei")

# 19.4.5 Exponential integral En
    def demo_expint(self):
        print("demo_expint")

# 19.4.6 Logarithmic integral li
    def demo_li(self):
        print("demo_li")

# 19.4.7 Bounds for the value of the prime counting function
    def demo_primepi2_upper(self):
        print("demo_primepi2_upper")

# 19.4.8 Bounds for the value of the prime counting function
    def demo_primepi2_lower(self):
        print("demo_primepi2_lower")

# 19.4.9 Hyperbolic sine integral shi
    def demo_shi(self):
        print("demo_shi")

# 19.4.10 Sine integral si
    def demo_si(self):
        print("demo_si")



# %%% 19.5 Orthogonal polynomials

# 19.5.1 Hermite polynomials (physicist)
    def demo_hermite(self):
        print("demo_hermite")

# 19.5.2 Hermite polynomials (probabilist)
    def demo_hermite_he(self):
        print("demo_hermite_he")

# 19.5.3 Laguerre Polynomials
    def demo_laguerre_l(self):
        print("demo_laguerre_l")

# 19.5.4 Generalized Laguerre polynomials
    def demo_laguerre(self):
        print("demo_laguerre")



# %%% 19.6 Coulomb functions

# 19.6.1 Normalizing Gamow constant for Coulomb wave functions
    def demo_coulombc(self):
        print("demo_coulombc")

# 19.6.2 Coulomb wave function F
    def demo_coulombf(self):
        print("demo_coulombf")

# 19.6.3 Coulomb wave function G
    def demo_coulombg(self):
        print("demo_coulombg")



# %%% 19.7 Whittaker functions

# 19.7.1 Whittaker function M
    def demo_whitm(self):
        print("demo_whitm")

# 19.7.2 Whittaker function W
    def demo_whitw(self):
        print("demo_whitw")



# %%% 19.8 Parabolic cylinder functions

# 19.8.1 Parabolic cylinder function D
    def demo_pcfd(self):
        print("demo_pcfd")

# 19.8.2 Parabolic cylinder function U
    def demo_pcfu(self):
        print("demo_pcfu")

# 19.8.3 Parabolic cylinder function V
    def demo_pcfv(self):
        print("demo_pcfv")

# 19.8.4 Parabolic cylinder function W
    def demo_pcfw(self):
        print("demo_pcfw")












# %%% Main Run


    # 19.1 Overview
    def demo_19_1(self):
        self.demo_hyp1f1()
        self.demo_hyp1f1r()
        self.demo_hyperu()
        print()



    # 19.2 Incomplete gamma functions
    def demo_19_2(self):
        self.demo_gammainc()
        self.demo_gamma_lower()
        self.demo_gamma_upper()
        self.demo_gamma_p()
        self.demo_gamma_q()
        self.demo_gamma_tricomi()
        self.demo_gamma_derivative()
        print()



    # 19.3 Error function and related functions
    def demo_19_3(self):
        self.demo_erf()
        self.demo_erfc()
        self.demo_inerfc()
        self.demo_erfi()
        self.demo_dawson()
        self.demo_fresnels()
        self.demo_fresnelc()
        self.demo_faddeeva()
        self.demo_voigt_u()
        self.demo_voigt_v()
        self.demo_voigt_h()
        self.demo_complex_normal()
        print()



    # 19.4 Exponential integrals and related functions
    def demo_19_4(self):
        self.demo_chi()
        self.demo_ci()
        self.demo_e1()
        self.demo_ei()
        self.demo_expint()
        self.demo_li()
        self.demo_primepi2_upper()
        self.demo_primepi2_lower()
        self.demo_shi()
        self.demo_si()
        print()


    # 19.5 Orthogonal polynomials
    def demo_19_5(self):
        self.demo_hermite()
        self.demo_hermite_he()
        self.demo_laguerre_l()
        self.demo_laguerre()
        print()


    # 19.6 Coulomb functions
    def demo_19_6(self):
        self.demo_coulombc()
        self.demo_coulombf()
        self.demo_coulombg()
        print()


    # 19.7 Whittaker functions
    def demo_19_7(self):
        self.demo_whitm()
        self.demo_whitw()
        print()


    # 19.8 Parabolic cylinder functions
    def demo_19_8(self):
        self.demo_pcfd()
        self.demo_pcfu()
        self.demo_pcfv()
        self.demo_pcfw()
        print()




    def demo_19(self):
        self.demo_19_1()
        self.demo_19_2()
        self.demo_19_3()
        self.demo_19_4()
        self.demo_19_5()
        self.demo_19_6()
        self.demo_19_7()
        self.demo_19_8()
        return



test = test19()
test.demo_19()





