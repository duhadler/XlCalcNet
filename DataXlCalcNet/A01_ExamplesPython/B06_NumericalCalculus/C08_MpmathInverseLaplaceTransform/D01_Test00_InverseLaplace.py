

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():


# %%%  12.6 Numerical inverse Laplace transform



    def test_inverse_laplace(self, ctx):
        print()
        print("****************************")
        print("Test test_inverse_laplace")

    # 7.12.1 One-step algorithm

        ctx.dps = 15
        tt = [ctx.t('0.001'), ctx.t('0.01'), ctx.t('0.1'), 1, 10]
        fp = lambda p: ctx.t(1)/(p+1)**2
        ft = lambda t: t*ctx.exp(-t)

        print()
        result1a = ft(tt[0])
        print("result1a", result1a)
        result1b = ctx.invertlaplace(fp,tt[0],method='talbot')
        print("result1b", result1b)

        print()
        result2a = ft(tt[1])
        print("result2a", result2a)
        result2b = ctx.invertlaplace(fp,tt[1],method='talbot')
        print("result2b", result2b)

        print()
        result3a = ft(tt[2])
        print("result3a", result3a)
        result3b = ctx.invertlaplace(fp,tt[2],method='talbot')
        print("result3b", result3b)

        print()
        result4a = ft(tt[3])
        print("result4a", result4a)
        result4b = ctx.invertlaplace(fp,tt[3],method='talbot')
        print("result4b", result4b)

        print()
        result5a = ft(tt[4])
        print("result5a", result5a)
        result5b = ctx.invertlaplace(fp,tt[4],method='talbot')
        print("result5b", result5b)

        ctx.dps = 100
        print()
        result6a = ft(tt[0])
        print("result6a", result6a)
        result6b = ctx.invertlaplace(fp,tt[0],method='talbot')
        print("result6b", result6b)

        print()
        result7a = ft(tt[1])
        print("result7a", result7a)
        result7b = ctx.invertlaplace(fp,tt[1],method='talbot')
        print("result7b", result7b)



        ctx.dps = 15
        print()
        fp = lambda p: 1/ctx.sqrt(p*p + 1)
        ft = lambda t: ctx.besselj(0,t)

        result8a = ft(tt[0])
        print("result8a", result8a)
        result8b = ctx.invertlaplace(fp,tt[0])
        print("result8b", result8b)


        result9a = ft(tt[1])
        print("result9a", result9a)
        result9b = ctx.invertlaplace(fp,tt[1])
        print("result9b", result9b)



        ctx.dps = 15
        print()
        fp = lambda p: 1/ctx.sqrt(p*p + 1)
        ft = lambda t: ctx.besselj(0,t)

        result8a = ft(tt[0])
        print("result8a", result8a)
        result8b = ctx.invertlaplace(fp,tt[0])
        print("result8b", result8b)


        result9a = ft(tt[1])
        print("result9a", result9a)
        result9b = ctx.invertlaplace(fp,tt[1])
        print("result9b", result9b)



        ctx.dps = 15
        print()
        fp = lambda p: ctx.log(p)/p
        ft = lambda t: -ctx.euler-ctx.log(t)

        result10a = ft(tt[0])
        print("result10a", result10a)
        result10b = ctx.invertlaplace(fp,tt[0])
        print("result10b", result10b)


        result11a = ft(tt[1])
        print("result11a", result11a)
        result11b = ctx.invertlaplace(fp,tt[1])
        print("result11b", result11b)



        ctx.dps = 15
        print()
        fp = lambda p: 1/(p*p-9)
        ft = lambda t: ctx.sinh(3*t)/3
        tt = [ctx.t('0.01'),ctx.t('0.1'),ctx.t('1.0'),ctx.t('10.0')]

        result12a = ft(tt[0])
        print("result12a", result12a)
        result12b = ctx.invertlaplace(fp,tt[0], method='talbot')
        print("result12b", result12b)

        result13a = ft(tt[1])
        print("result13a", result13a)
        result13b = ctx.invertlaplace(fp,tt[1], method='talbot')
        print("result13b", result13b)

        result14a = ft(tt[2])
        print("result14a", result14a)
        result14b = ctx.invertlaplace(fp,tt[2], method='talbot')
        print("result14b", result14b)

        result15a = ft(tt[3])
        print("result15a", result15a)
        # This is to demonstrate the effect of a pole: completely wrong result
        result15b = ctx.invertlaplace(fp,tt[3], method='talbot')
        print("result15b", result15b)





# %%%  Main Run


    # 12.6 Numerical inverse Laplace transform
    def demo_12_6(self, ctx):
        self.test_inverse_laplace(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_6(ctx)
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

