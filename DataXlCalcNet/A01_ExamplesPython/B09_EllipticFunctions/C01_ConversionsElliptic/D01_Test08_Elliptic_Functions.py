# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gpm, ipm, dpm #, arb



# %%16 Elliptic functions and integrals


class test16():



# %%% 16.1 Conversions of parameters of elliptic functions

# 16.1.1 Elliptic nome q
    def demo_qfrom(self):
        print("demo_qfrom")

# 16.1.2 Number-theoretic nome qbar
    def demo_qbarfrom(self):
        print("demo_qbarfrom")

# 16.1.3 Elliptic parameter m
    def demo_mfrom(self):
        print("demo_mfrom")

# 16.1.4 Elliptic modulus k
    def demo_kfrom(self):
        print("demo_kfrom")

# 16.1.5 Elliptic half-period ratio tau
    def demo_taufrom(self):
        print("demo_taufrom")

# 16.1.6 Elliptic lattice roots
    def demo_efrom(self):
        print("demo_efrom")

# 16.1.7 Elliptic lattice invariants
    def demo_gfrom(self):
        print("demo_gfrom")



# %%% 16.2 Legendre elliptic integrals, and related functions

# 16.2.2 Legendre complete elliptic integral of the first kind
    def demo_elliptic_k(self):
        print("demo_elliptic_k")

# 16.2.3 Legendre complete elliptic integral of the second kind
    def demo_elliptic_e(self):
        print("demo_elliptic_e")

# 16.2.4 Legendre complete elliptic integral of the third kind
    def demo_elliptic_pi(self):
        print("demo_elliptic_pi")

# 16.2.5 Legendre incomplete elliptic integral of the first kind
    def demo_elliptic_f(self):
        print("demo_elliptic_f")

# 16.2.6 Legendre incomplete elliptic integral of the second kind
    def demo_elliptic_e_inc(self):
        print("demo_elliptic_e_inc")

# 16.2.7 Legendre incomplete elliptic integral of the third kind
    def demo_elliptic_pi_inc(self):
        print("demo_elliptic_pi_inc")

# 16.2.8 Jacobi Zeta function
    def demo_jacobi_zeta(self):
        print("demo_jacobi_zeta")

# 16.2.9 Heuman’s Lambda function
    def demo_heuman_lambda(self):
        print("demo_heuman_lambda")



# %%% 16.3 Carlson symmetric elliptic integrals

# 16.3.1 Carlson symmetric elliptic integral of the first kind, RF
    def demo_elliprf(self):
        print("demo_elliprf")

# 16.3.2 Carlson completely symmetric elliptic integral of the second kind, RG
    def demo_elliprg(self):
        print("demo_elliprg")

# 16.3.3 Carlson symmetric elliptic integral of the third kind, RJ
    def demo_elliprj(self):
        print("demo_elliprj")

# 16.3.4 Carlson symmetric elliptic integral of the second kind, RD
    def demo_elliprd(self):
        print("demo_elliprd")

# 16.3.5 Carlson degenerate symmetric elliptic integral of the first kind, RC
    def demo_elliprc(self):
        print("demo_elliprc")



# %%% 16.4 Jacobi elliptic functions

# 16.4.1 Jacobi elliptic functions, general form
    def demo_ellipfun(self):
        print("demo_ellipfun")

# 16.4.2 Jacobi elliptic function sn
    def demo_jacobi_sn(self):
        print("demo_acobi_sn")

# 16.4.3 Jacobi elliptic function cn
    def demo_jacobi_cn(self):
        print("demo_jacobi_cn")

# 16.4.4 Jacobi elliptic function dn
    def demo_jacobi_dn(self):
        print("demo_jacobi_dn")

# 16.4.5 Jacobi elliptic function ns
    def demo_jacobi_ns(self):
        print("demo_jacobi_ns")

# 16.4.6 Jacobi elliptic function nc
    def demo_jacobi_nc(self):
        print("demo_jacobi_nc")

# 16.4.7 Jacobi elliptic function nd
    def demo_jacobi_nd(self):
        print("demo_jacobi_nd")

# 16.4.8 Jacobi elliptic function sc
    def demo_jacobi_sc(self):
        print("demo_jacobi_sc")

# 16.4.9 Jacobi elliptic function sd
    def demo_jacobi_sd(self):
        print("demo_jacobi_sd")

# 16.4.10 Jacobi elliptic function dc
    def demo_jacobi_dc(self):
        print("demo_jacobi_dc")

# 16.4.11 Jacobi elliptic function ds
    def demo_jacobi_ds(self):
        print("demo_jacobi_ds")

# 16.4.12 Jacobi elliptic function cs
    def demo_jacobi_cs(self):
        print("demo_jacobi_cs")

# 16.4.13 Jacobi elliptic function cd
    def demo_jacobi_cd(self):
        print("demo_jacobi_cd")



# %%% 16.5 Weierstrass elliptic functions

# 16.5.1 Weierstrass function
    def demo_weierstrass_p(self):
        print("demo_weierstrass_p")

# 16.5.2 Weierstrass function, first derivative
    def demo_weierstrass_p_prime(self):
        print("demo_weierstrass_p_prime")

# 16.5.3 Inverse Weierstrass function
    def demo_weierstrass_p_inv(self):
        print("demo_weierstrass_p_inv")

# 16.5.4 Weierstrass Zeta
    def demo_weierstrass_zeta(self):
        print("demo_weierstrass_zeta")

# 16.5.5 Weierstrass Sigma
    def demo_weierstrass_sigma(self):
        print("demo_weierstrass_sigma")



# %%% 16.6 Jacobi theta functions and related functions

# 16.6.1 Jacobi theta functions, general form
    def demo_jtheta(self):
        print("demo_jtheta")

# 16.6.2 Dedekind eta function
    def demo_dedekind_eta(self):
        print("demo_dedekind_eta")

# 16.6.3 Elliptic modular Lambda
    def demo_modular_lambda(self):
        print("demo_modular_lambda")

# 16.6.4 Elliptic modular Delta
    def demo_modular_delta(self):
        print("demo_modular_delta")

# 16.6.5 Klein j-invariant
    def demo_kleinj(self):
        print("demo_kleinj")

# 16.6.6 Elliptic lattice roots in terms of Elliptic period ratio tau
    def demo_elliptic_roots(self):
        print("demo_elliptic_roots")

# 16.6.7 Elliptic lattice invariants
    def demo_elliptic_invariants(self):
        print("demo_elliptic_invariants")










# %%% Main Run


    # 16.1 Conversions of parameters of elliptic functions
    def demo_16_1(self):
        self.demo_qfrom()
        self.demo_qbarfrom()
        self.demo_mfrom()
        self.demo_kfrom()
        self.demo_taufrom()
        self.demo_efrom()
        self.demo_gfrom()
        print()



    # 16.2 Legendre elliptic integrals, and related functions
    def demo_16_2(self):
        self.demo_elliptic_k()
        self.demo_elliptic_e()
        self.demo_elliptic_pi()
        self.demo_elliptic_f()
        self.demo_elliptic_e_inc()
        self.demo_elliptic_pi_inc()
        self.demo_jacobi_zeta()
        self.demo_heuman_lambda()
        print()



    # 16.3 Carlson symmetric elliptic integrals
    def demo_16_3(self):
        self.demo_elliprf()
        self.demo_elliprg()
        self.demo_elliprj()
        self.demo_elliprd()
        self.demo_elliprc()
        print()



    # 16.4 Jacobi elliptic functions
    def demo_16_4(self):
        self.demo_ellipfun()
        self.demo_jacobi_sn()
        self.demo_jacobi_cn()
        self.demo_jacobi_dn()
        self.demo_jacobi_ns()
        self.demo_jacobi_nc()
        self.demo_jacobi_nd()
        self.demo_jacobi_sc()
        self.demo_jacobi_sd()
        self.demo_jacobi_dc()
        self.demo_jacobi_ds()
        self.demo_jacobi_cs()
        self.demo_jacobi_cd()
        print()


    # 16.5 Weierstrass elliptic functions
    def demo_16_5(self):
        self.demo_weierstrass_p()
        self.demo_weierstrass_p_prime()
        self.demo_weierstrass_p_inv()
        self.demo_weierstrass_zeta()
        self.demo_weierstrass_sigma()
        print()


    # 16.6 Jacobi theta functions and related functions
    def demo_16_6(self):
        self.demo_jtheta()
        self.demo_dedekind_eta()
        self.demo_modular_lambda()
        self.demo_modular_delta()
        self.demo_kleinj()
        self.demo_elliptic_roots()
        self.demo_elliptic_invariants()
        print()




    def demo_16(self):
        self.demo_16_1()
        self.demo_16_2()
        self.demo_16_3()
        self.demo_16_4()
        self.demo_16_5()
        self.demo_16_6()
        return


test = test16()
test.demo_16()



