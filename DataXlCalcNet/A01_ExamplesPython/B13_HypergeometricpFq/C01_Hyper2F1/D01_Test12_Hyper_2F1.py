# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gmp, ipm, dec, arb



# %%20 Hypergeometric function 2F1 (Gauss) and related functions


class test20():



# %%% 20.1 Overview

# 20.1.1 Gauss Hypergeometric Function 2F1
    def demo_hyp2f1(self):
        print("demo_hyp2f1")

# 20.1.2 Regularized Gauss Hypergeometric Function 2F1
    def demo_hyp2f1r(self):
        print("demo_hyp2f1r")



# %%% 20.2 Orthogonal polynomials

# 20.2.1 Chebyshev polynomial of the first kind
    def demo_chebyt(self):
        print("demo_chebyt")

# 20.2.2 Chebyshev polynomial of the second kind
    def demo_chebyu(self):
        print("demo_chebyu")

# 20.2.3 Gegenbauer polynomials
    def demo_gegenbauer(self):
        print("demo_gegenbauer")

# 20.2.4 Jacobi polynomials
    def demo_jacobi(self):
        print("demo_jacobi")

# 20.2.5 Legendre polynomials / functions
    def demo_legendre(self):
        print("demo_legendre")

# 20.2.6 Associated Legendre polynomials / functions
    def demo_legenp(self):
        print("demo_legenp")

# 20.2.7 Associated Legendre function of the second kind
    def demo_legenq(self):
        print("demo_legenq")

# 20.2.8 Spherical harmonics
    def demo_spherharm(self):
        print("demo_spherharm")



# %%% 20.3 Incomplete Beta Function

# 20.3.1 General incomplete beta function
    def demo_betainc(self):
        print("demo_betainc")

# 20.3.2 Normalised incomplete beta function
    def demo_ibeta(self):
        print("demo_ibeta")

# 20.3.3 Non-Normalised incomplete beta function
    def demo_beta3(self):
        print("demo_beta3")







# %%% Main Run


    # 20.1 Overview
    def demo_20_1(self):
        self.demo_hyp2f1()
        self.demo_hyp2f1r()
        print()



    # 20.2 Orthogonal polynomials
    def demo_20_2(self):
        self.demo_chebyt()
        self.demo_chebyu()
        self.demo_gegenbauer()
        self.demo_jacobi()
        self.demo_legendre()
        self.demo_legenp()
        self.demo_legenq()
        self.demo_spherharm()
        print()



    # 20.3 Incomplete Beta Function
    def demo_20_3(self):
        self.demo_betainc()
        self.demo_ibeta()
        self.demo_beta3()
        print()






    def demo_20(self):
        self.demo_20_1()
        self.demo_20_2()
        self.demo_20_3()
        return


test = test20()
test.demo_20()




