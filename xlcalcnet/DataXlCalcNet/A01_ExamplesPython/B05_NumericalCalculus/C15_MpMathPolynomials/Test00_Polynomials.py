

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():



# %%%  12.1 Polynomials


    def test_polynomials(self, ctx):
        print()
        print("****************************")
        print("Test test_polynomials")

# 12.1.1 Polynomial evaluation

        ctx.dps = 15
        result1 = ctx.polyval([3, 0, 2], ctx.t(0.5))
        print("result1", result1)

        result2 = ctx.polyval([3, 0, 2], ctx.t(0.5), derivative=True)
        print("result2", result2)


# 12.1.2 Polynomial roots

        ctx.dps = 15
        result1 = ctx.polyval([3, 0, 2], ctx.t(0.5))
        print("result1", result1)

        print(ctx.polyroots([1,-1,-14,24]), 4)

        roots, err = ctx.polyroots([4,3,2], error=True)
        for r in roots: print(r)
        print("err: ", err)

        result2 = ctx.polyval([4,3,2], roots[0])
        print("result2", result2)

        result3 = ctx.polyval([4,3,2], roots[1])
        print("result3", result3)


        ctx.dps = 20
        for r in ctx.polyroots([1, 0, 0, 0, 0, -1]): print(r)


        ctx.dps = 60
        for r in ctx.polyroots([1, 0, -10, 0, 1]): print(r)




# %%%  Main Run

    # 12.1 Polynomials
    def demo_12_1(self, ctx):
        self.test_polynomials(ctx)
        print()


    def demo_12(self, ctx):
        self.demo_12_1(ctx)

        print()


mpm.dps=25
gpm.dps=mpm.dps
dpm.dps=mpm.dps
print("dps: ", mpm.dps)

ctxm = dpm
#ctxm = gpm
#ctxm = mpm
test12().demo_12(ctxm)


# Notes on decimal:
# No arithmetic operations with double or complex
# results may overflow when mpm and gmp work
# complex numbers need to be converted to decc_t before arith. op. take place

