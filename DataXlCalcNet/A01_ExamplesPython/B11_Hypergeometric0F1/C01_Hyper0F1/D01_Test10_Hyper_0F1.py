# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gpm, ipm, dpm, apm



### 18 Hypergeometric function 0F1and related functions


class test18():



# %%% 18.1 Overview

# 18.1.1 Confluent Hypergeometric Limit Function 0F1
    def demo_hyp0f1(self):
        print("demo_hyp0f1")

# 18.1.1 Regularized Confluent Hypergeometric Limit Function 0F1
    def demo_hyp0f1r(self):
        print("demo_hyp0f1r")

# 18.1.2 Noncentral chi-squared distribution: pdf
    def demo_chi_squared_nc_0f1_nc_pdf(self):
        print("demo_chi_squared_nc_0f1_nc_pdf")




# %%% 18.2 Bessel functions and modified Bessel functions

# 18.2.1 Bessel function of the 1st kind
    def demo_besselj(self):
        print("demo_besselj")

# 18.2.2 Bessel function of the 2nd kind
    def demo_bessely(self):
        print("demo_bessely")

# 18.2.3 Zeros of the Bessel function of the first kind
    def demo_besseljzero(self):
        print("demo_besseljzero")

# 18.2.4 Zeros of the Bessel function of the second kind
    def demo_besselyzero(self):
        print("demo_besselyzero")

# 18.2.5 Modified Bessel function of the 1st kind
    def demo_besseli(self):
        print("demo_besseli")

# 18.2.6 Modified Bessel function of the 2nd kind
    def demo_besselk(self):
        print("demo_besselk")

# 18.2.7 Hankel function of the first kind
    def demo_hankel1(self):
        print("demo_hankel1")

# 18.2.8 Hankel function of the second kind
    def demo_hankel2(self):
        print("demo_hankel2")




# %%% 18.3 Spherical Bessel functions

# 18.3.1 Spherical Bessel function of the first kind
    def demo_sph_bessel_jn(self):
        print("demo_sph_bessel_jn")

# 18.3.2 Spherical Bessel function of the second kind
    def demo_sph_bessel_yn(self):
        print("demo_sph_bessel_yn")

# 18.3.3 Modified Spherical Bessel function of the first kind
    def demo_sph_bessel_in(self):
        print("demo_sph_bessel_in")

# 18.3.4 Modified Spherical Bessel function of the second kind
    def demo_sph_bessel_kn(self):
        print("demo_sph_bessel_kn")

# 18.3.5 Spherical Hankel function of the first kind
    def demo_sph_hankel_h1(self):
        print("demo_sph_hankel_h1")

# 18.3.6 Spherical Hankel function of the second kind
    def demo_sph_hankel_h2(self):
        print("demo_sph_hankel_h2")



# %%% 18.4 Airy functions

# 18.4.1 Airy function Ai
    def demo_airyai(self):
        print("demo_airyai")

# 18.4.2 Airy function Bi
    def demo_airybi(self):
        print("demo_airybi")

# 18.4.3 Zeros of the Airy function Ai
    def demo_airyaizero(self):
        print("demo_airyaizero")

# 18.4.4 Zeros of the Airy function Bi
    def demo_airybizero(self):
        print("demo_airybizero")

# 18.4.5 Airy Ai’(x)
    def demo_airy_aip(self):
        print("demo_airy_aip")

# 18.4.6 Airy Bi’(x)
    def demo_airy_bip(self):
        print("demo_airy_bip")



# %%% 18.5 Kelvin functions

# 18.5.1 Kelvin function ber
    def demo_kelvinber(self):
        print("demo_kelvinber")

# 18.5.2 Kelvin function bei
    def demo_kelvinbei(self):
        print("demo_kelvinbei")

# 18.5.3 Kelvin function ker
    def demo_kelvinker(self):
        print("demo_kelvinker")

# 18.5.4 Kelvin function kei
    def demo_kelvinkei(self):
        print("demo_kelvinkei")











# %%% ### Main Run


    # 18.1 Overview
    def demo_18_1(self):
        self.demo_hyp0f1()
        self.demo_hyp0f1r()
        self.demo_chi_squared_nc_0f1_nc_pdf()
        print()



    # 18.2 Bessel functions and modified Bessel functions
    def demo_18_2(self):
        self.demo_besselj()
        self.demo_bessely()
        self.demo_besseljzero()
        self.demo_besselyzero()
        self.demo_besseli()
        self.demo_besselk()
        self.demo_hankel1()
        self.demo_hankel2()
        print()



    # 18.3 Spherical Bessel functions
    def demo_18_3(self):
        self.demo_sph_bessel_jn()
        self.demo_sph_bessel_yn()
        self.demo_sph_bessel_in()
        self.demo_sph_bessel_kn()
        self.demo_sph_hankel_h1()
        self.demo_sph_hankel_h2()
        print()



    # 18.4 Airy functions
    def demo_18_4(self):
        self.demo_airyai()
        self.demo_airybi()
        self.demo_airyaizero()
        self.demo_airybizero()
        self.demo_airy_aip()
        self.demo_airy_bip()
        print()


    # 18.5 Kelvin functions
    def demo_18_5(self):
        self.demo_kelvinber()
        self.demo_kelvinbei()
        self.demo_kelvinker()
        self.demo_kelvinkei()
        print()





    def demo_18(self):
        self.demo_18_1()
        self.demo_18_2()
        self.demo_18_3()
        self.demo_18_4()
        self.demo_18_5()
        return


test = test18()
test.demo_18()




