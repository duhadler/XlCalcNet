# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gpm, ipm, dpm, apm



### 17 Lerch’s transcendent and related functions


class test17():



# %%% 17.1 Overview

# 17.1.1 Lerch’s transcendent
    def demo_lerchphi(self):
        print("demo_lerchphi")


# 17.1.2 Lerch’s zeta
    def demo_lerch_zeta(self):
        print("demo_lerch_zeta")



# %%% 17.2 Polygamma functions

# 17.2.1 Polygamma function
    def demo_polygamma(self):
        print("demo_polygamma")

# 17.2.2 TriGamma function
    def demo_trigamma(self):
        print("demo_trigamma")

# 17.2.3 DiGamma function
    def demo_digamma(self):
        print("demo_digamma")



# %%% 17.3 Polylogarithms and related functions

# 17.3.1 Polylogarithm
    def demo_polylog(self):
        print("demo_polylog")

# 17.3.2 Trilogarithm Function
    def demo_trilog(self):
        print("demo_trilog")

# 17.3.3 Dilogarithm Function
    def demo_dilog(self):
        print("demo_dilog")

# 17.3.4 Generalized Clausen sine function
    def demo_clsin(self):
        print("demo_clsin")

# 17.3.5 Generalized Clausen cosine function
    def demo_clcos(self):
        print("demo_clcos")

# 17.3.6 Classical Clausen function
    def demo_cl2(self):
        print("demo_cl2")

# 17.3.7 Bose-Einstein integrals of real order
    def demo_bose_einstein(self):
        print("demo_bose_einstein")

# 17.3.8 Fermi-Dirac integrals
    def demo_fermi_dirac(self):
        print("demo_fermi_dirac")

# 17.3.9 Legendre’s chi function
    def demo_legendre_chi(self):
        print("demo_legendre_chi")

# 17.3.10 Inverse tangent integral
    def demo_ti(self):
        print("demo_ti")

# 17.3.11 Debye functions
    def demo_debye(self):
        print("demo_debye")



# %%% 17.4 Hurwitz zeta function and related functions

# 17.4.1 Hurwitz zeta function
    def demo_hurwitz(self):
        print("demo_hurwitz")

# 17.4.2 Stieltjes constant
    def demo_stieltjes(self):
        print("demo_stieltjes")

# 17.4.3 Harmonic numbers
    def demo_harmonic(self):
        print("demo_harmonic")

# 17.4.4 Generalized harmonic number function
    def demo_harmonic2(self):
        print("demo_harmonic2")

# 17.4.5 Bernoulli numbers
    def demo_bernoulli(self):
        print("demo_bernoulli")

# 17.4.6 Bernoulli number as fraction
    def demo_bernfrac(self):
        print("demo_bernfrac")

# 17.4.7 Bernoulli polynomials
    def demo_bernpoly(self):
        print("demo_bernpoly")

# 17.4.8 Euler numbers
    def demo_eulernum(self):
        print("demo_eulernum")

# 17.4.9 Euler polynomials
    def demo_eulerpoly(self):
        print("demo_eulerpoly")

# 17.4.10 Logarithm of Barnes G function
    def demo_lnbarnesg(self):
        print("demo_lnbarnesg")

# 17.4.11 Barnes G-function
    def demo_barnesg(self):
        print("demo_barnesg")

# 17.4.12 Hyperfactorial
    def demo_hyperfac(self):
        print("demo_hyperfac")

# 17.4.13 Superfactorial
    def demo_superfac(self):
        print("demo_superfac")



# %%% 17.5 Dirichlet L-Series, Riemann zeta function, and related functions

# 17.5.1 Dirichlet L-Series
    def demo_dirichlet_l(self):
        print("demo_dirichlet_l")

# 17.5.2 Riemann zeta function
    def demo_zeta(self):
        print("demo_zeta")

# 17.5.3 Riemann zeta - 1
    def demo_zetam1(self):
        print("demo_zetam1")

# 17.5.4 Riemann (Landau) function xi
    def demo_riemann_xi(self):
        print("demo_riemann_xi")

# 17.5.5 Dirichlet eta function
    def demo_dirichlet_eta(self):
        print("demo_dirichlet_eta")

# 17.5.6 Dirichlet eta - 1
    def demo_dirichlet_etam1(self):
        print("demo_dirichlet_etam1")

# 17.5.7 Dirichlet Beta function
    def demo_dirichlet_beta(self):
        print("demo_dirichlet_beta")

# 17.5.8 Dirichlet Lambda function
    def demo_dirichlet_lambda(self):
        print("demo_dirichlet_lambda")

# 17.5.9 Riemann-Siegel Z function
    def demo_siegelz(self):
        print("demo_siegelz")

# 17.5.10 Riemann-Siegel theta function
    def demo_siegeltheta(self):
        print("demo_siegeltheta")

# 17.5.11 Backlund S function
    def demo_backlunds(self):
        print("demo_backlunds")

# 17.5.12 Gram points
    def demo_grampoint(self):
        print("demo_grampoint")

# 17.5.13 Number of zeros of the Riemann zeta function
    def demo_nzeros(self):
        print("demo_nzeros")

# 17.5.14 Zeros of the Riemann zeta function
    def demo_zetazero(self):
        print("demo_zetazero")

# 17.5.15 Secondary zeta function
    def demo_secondzeta(self):
        print("demo_secondzeta")



# %%% 17.6 Additional numbertheoretic functions

# 17.6.1 Prime counting function
    def demo_primepi(self):
        print("demo_primepi")


# 17.6.2 Mangoldt function
    def demo_mangoldt(self):
        print("demo_mangoldt")

# 17.6.3 Riemann R function
    def demo_riemannr(self):
        print("demo_riemannr")

# 17.6.4 Prime zeta function
    def demo_primezeta(self):
        print("demo_primezeta")

# 17.6.5 Mertens constant
    def demo_const_mertens(self):
        print("demo_const_mertens")

# 17.6.6 Twin prime constant
    def demo_const_twinprime(self):
        print("demo_const_twinprime")

# 17.6.7 Cyclotomic polynomial
    def demo_cyclotomic(self):
        print("demo_cyclotomic")

# 17.6.8 Stirling number of the first kind
    def demo_stirling1(self):
        print("demo_stirling1")

# 17.6.9 Stirling number of the second kind
    def demo_stirling2(self):
        print("demo_stirling2")

# 17.6.10 Bell (Touchard) polynomials
    def demo_bell(self):
        print("demo_bell")

# 17.6.11 Polyexponential function
    def demo_polyexp(self):
        print("demo_polyexp")









# %%% Main Run


    # 17.1 Overview
    def demo_17_1(self):
        self.demo_lerchphi()
        self.demo_lerch_zeta()
        print()



    # 17.2 Polygamma functions
    def demo_17_2(self):
        self.demo_polygamma()
        self.demo_trigamma()
        self.demo_digamma()
        print()



    # 17.3 Polylogarithms and related functions
    def demo_17_3(self):
        self.demo_polylog()
        self.demo_trilog()
        self.demo_dilog()
        self.demo_clsin()
        self.demo_clcos()
        self.demo_cl2()
        self.demo_bose_einstein()
        self.demo_fermi_dirac()
        self.demo_legendre_chi()
        self.demo_ti()
        self.demo_debye()
        print()



    # 17.4 Hurwitz zeta function and related functions
    def demo_17_4(self):
        self.demo_hurwitz()
        self.demo_stieltjes()
        self.demo_harmonic()
        self.demo_harmonic2()
        self.demo_bernoulli()
        self.demo_bernfrac()
        self.demo_bernpoly()
        self.demo_eulernum()
        self.demo_eulerpoly()
        self.demo_lnbarnesg()
        self.demo_barnesg()
        self.demo_hyperfac()
        self.demo_superfac()
        print()


    # 17.5 Dirichlet L-Series, Riemann zeta function, and related functions
    def demo_17_5(self):
        self.demo_dirichlet_l()
        self.demo_zeta()
        self.demo_zetam1()
        self.demo_riemann_xi()
        self.demo_dirichlet_eta()
        self.demo_dirichlet_etam1()
        self.demo_dirichlet_beta()
        self.demo_dirichlet_lambda()
        self.demo_siegelz()
        self.demo_siegeltheta()
        self.demo_backlunds()
        self.demo_grampoint()
        self.demo_nzeros()
        self.demo_zetazero()
        self.demo_secondzeta()
        print()


    # 17.6 Additional numbertheoretic functions
    def demo_17_6(self):
        self.demo_primepi()
        self.demo_mangoldt()
        self.demo_riemannr()
        self.demo_primezeta()
        self.demo_const_mertens()
        self.demo_const_twinprime()
        self.demo_cyclotomic()
        self.demo_stirling1()
        self.demo_stirling2()
        self.demo_bell()
        self.demo_polyexp()
        print()




    def demo_17(self):
        self.demo_17_1()
        self.demo_17_2()
        self.demo_17_3()
        self.demo_17_4()
        self.demo_17_5()
        self.demo_17_6()
        print()


test = test17()
test.demo_17()




