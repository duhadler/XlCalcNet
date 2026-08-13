# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import fpm, mpm, gmp, ipm, dec, arb



# %%21 Generalized hypergeometric functions pFq and related functions


class test21():



# %%% 21.1 Generalized hypergeometric functions


# 21.1.1 Generalized hypergeometric function pFq
    def demo_hyper(self):
        print("demo_hyper")

# 21.1.2 Generalized hypergeometric function 2F3
    def demo_hyp2f3(self):
        print("demo_hyp2f3")

# 21.1.3 Generalized hypergeometric function 3F2
    def demo_hyp3f2(self):
        print("demo_hyp3f2")

# 21.1.4 Generalized hypergeometric function 2F2
    def demo_hyp2f2(self):
        print("demo_hyp2f2")

# 21.1.5 Generalized hypergeometric function 2F0
    def demo_hyp2f0(self):
        print("demo_hyp2f0")



# %%% 21.2 Generalized hypergeometric function 1F2 and related functions

# 21.2.1 Non-regularized hypergeometric function 1F2
    def demo_hyp1f2(self):
        print("demo_hyp1f2")

# 21.2.2 Regularized hypergeometric function 1F2
    def demo_hyp1f2r(self):
        print("demo_hyp1f2r")

# 21.2.3 Scorer function Gi
    def demo_scorergi(self):
        print("demo_scorergi")

# 21.2.4 Scorer function Hi
    def demo_scorerhi(self):
        print("demo_scorerhi")

# 21.2.5 Struve function H
    def demo_struveh(self):
        print("demo_struveh")

# 21.2.6 Struve function L
    def demo_struvel(self):
        print("demo_struvel")

# 21.2.7 Struve function K
    def demo_struvek(self):
        print("demo_struvek")

# 21.2.8 Struve function M
    def demo_struvem(self):
        print("demo_struvem")

# 21.2.9 Anger function J
    def demo_angerj(self):
        print("demo_angerj")

# 21.2.10 Weber function E
    def demo_webere(self):
        print("demo_webere")

# 21.2.11 Lommel function S1
    def demo_lommels1(self):
        print("demo_lommels1")

# 21.2.12 Lommel function S2
    def demo_lommels2(self):
        print("demo_lommels2")






# %%%  Main Run


    # 21.1 Generalized hypergeometric functions
    def demo_21_1(self):
        self.demo_hyper()
        self.demo_hyp2f3()
        self.demo_hyp3f2()
        self.demo_hyp2f2()
        self.demo_hyp2f0()
        print()



    # 21.2 Generalized hypergeometric function 1𝐹2 and related functions
    def demo_21_2(self):
        self.demo_hyp1f2()
        self.demo_hyp1f2r()
        self.demo_scorergi()
        self.demo_scorerhi()
        self.demo_struveh()
        self.demo_struvel()
        self.demo_struvek()
        self.demo_struvem()
        self.demo_angerj()
        self.demo_webere()
        self.demo_lommels1()
        self.demo_lommels2()
        print()



    def demo_21(self):
        self.demo_21_1()
        self.demo_21_2()
        return



test = test21()
test.demo_21()





