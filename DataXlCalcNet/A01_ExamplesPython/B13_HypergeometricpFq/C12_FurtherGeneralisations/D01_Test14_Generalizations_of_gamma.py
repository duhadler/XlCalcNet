# -*- coding: utf-8 -*-

from xlcalcnet.mpmath import plot

from xlcalcnet import mpm



# %%22 Generalizations of gamma and hypergeometric functions (without ARB support)


class test22():


# %%% 22.1 Appell Functions

# 22.1.1 Appell function F1
    def demo_appellf1(self):
        print("demo_appellf1")

# 22.1.1 Appell function F2
    def demo_appellf2(self):
        print("demo_appellf2")

# 22.1.1 Appell function F3
    def demo_appellf3(self):
        print("demo_appellf3")

# 22.1.1 Appell function F4
    def demo_appellf4(self):
        print("demo_appellf4")


# %%% 22.2 Q Functions

# 22.2.1 q-Pochhammer symbol
    def demo_qp(self):
        print("demo_qp")

# 22.2.2 q-gamma function
    def demo_qgamma(self):
        print("demo_qgamma")

# 22.2.3 q-factorial
    def demo_qfac(self):
        print("demo_qfac")

# 22.2.4 Hypergeometric q-series
    def demo_qhyper(self):
        print("demo_qhyper")



# %%% 22.3 Further generalizations of gamma and hypergeometric functions

# 22.3.1 Limit of the product of gamma functions
    def demo_gammaprod(self):
        print("demo_gammaprod")

# 22.3.2 Limit of a weighted combination of hypergeometric functions
    def demo_hypercomb(self):
        print("demo_hypercomb")

# 22.3.3 Meijer G-function
    def demo_meijerg(self):
        print("demo_meijerg")

# 22.3.4 Bilateral hypergeometric series
    def demo_bihyper(self):
        print("demo_bihyper")

# 22.3.5 Generalized 2D hypergeometric series
    def demo_hyper2d(self):
        print("demo_hyper2d")






# %%% Main Run


    # 22.1 Appell Functions
    def demo_22_1(self):
        self.demo_appellf1()
        self.demo_appellf2()
        self.demo_appellf3()
        self.demo_appellf4()
        print()



    # 22.2 Q Functions
    def demo_22_2(self):
        self.demo_qp()
        self.demo_qgamma()
        self.demo_qfac()
        self.demo_qhyper()
        print()



    # 22.3 Further generalizations of gamma and hypergeometric functions
    def demo_22_3(self):
        self.demo_gammaprod()
        self.demo_hypercomb()
        self.demo_meijerg()
        self.demo_bihyper()
        self.demo_hyper2d()
        print()






    def demo_22(self):
        self.demo_22_1()
        self.demo_22_2()
        self.demo_22_3()
        return



mpm.dps=35


print("dps: ", mpm.dps)

ctxm = mpm


test22().demo_22(ctxm)





