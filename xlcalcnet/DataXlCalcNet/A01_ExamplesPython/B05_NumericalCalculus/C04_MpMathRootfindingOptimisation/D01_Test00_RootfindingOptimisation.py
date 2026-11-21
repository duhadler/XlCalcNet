

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():



# %%%  12.2 Rootfinder

    def test_rootfinder(self, ctx):

        print()
        print("****************************")
        print("Test test_rootfinder")


        #print("ctx.eps: ", ctx.eps)


        ctx.dps = 30
        result1 = ctx.findroot(ctx.sin, 3)
        print("result1: ", result1)
        print()
        print()


#        ctx.dps = 15
#        result2 = ctx.findroot(lambda x: x**3 + 2*x + 1, 1j, verbose=False)
#        print("result2: ", result2)
#
#        ctx.dps = 20
#        result2 = ctx.findroot(lambda x: x**3 + 2*x + 1, 1j, verbose=False, verify=True)
#        print("result2: ", result2)

#        ctx.dps = 30
#        result3 = ctx.findroot(ctx.zeta, 0.5+14j, verbose=True)
#        print("result3: ", result3)

        ctx.dps = 20
        result4 = ctx.findroot(lambda x: ctx.diff(ctx.gamma, x), 1)
        print("result4: ", result4)

        def lambert(x):
            return ctx.findroot(lambda w: w*ctx.exp(w) - x, ctx.log(1+x))

        print()
        print("lambert example:")
        ctx.dps = 15
        print(lambert(1)); print(gpm.lambertw(1))
        print(lambert(1000)); print(gpm.lambertw(1000))



        print()
        print("multidimensional example1:")
        f = [lambda x1, x2: x1**2 + x2, lambda x1, x2: 5*x1**2 - 3*x1 + 2*x2 - 3]
        result4 = ctx.findroot(f, (0, 0))
        print("result4: ", result4)

        result5 = ctx.findroot(f, (10, 10))
        print("result5: ", result5)

        def f(x1, x2):
            return x1**2 + x2, 5*x1**2 - 3*x1 + 2*x2 - 3

        result6 = ctx.findroot(f, (0, 0))
        print("result6: ", result6)


    # 7.3.3 Multiple roots

        print()
        f = lambda x: (x - 1)**99

        result15 = ctx.findroot(f, 0.9, verify=False)
        print("result15: ", result15)

        result16 = ctx.findroot(f, -10, solver='mnewton')
        print("result16: ", result16)

#        ctx.dps = 20
#        result17 = ctx.findroot(f, -10, solver='anewton', verbose=True, tol=10E-15)
#        print("result17: ", result17)
#        return

    # 7.3.4 Complex roots

#        print()
#        ctx.dps = 15
#        result18 = ctx.findroot(lambda x: x**4 + x + 1, (0, 1, 2), solver='muller')
#        print("result18: ", result18)



    # 7.3.5 Intersection methods

        print()
        ctx.dps = 15
        result19 = ctx.findroot(lambda x: x**3, (-1, 1), solver='anderson')
        print("result19: ", result19)

        # This will cause a ZeroDivisionError
#        ctx.dps = 15
#        result20 = ctx.findroot(lambda x: x**2, (-1, 1), solver='anderson')
#        print("result20: ", result20)

        # This will cause a ValueError
#        ctx.dps = 15
#        result21 = ctx.findroot(lambda x: x**2, (-1, .5), solver='anderson')
#        print("result21: ", result21)





# %%%  Main Run


    # 12.2 Rootfinder
    def demo_12_2(self, ctx):
        self.test_rootfinder(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_2(ctx)
        print()


mpm.dps=25
gpm.dps=mpm.dps
dpm.dps=mpm.dps
print("dps: ", mpm.dps)

ctxm = dpm
ctxm = gpm
ctxm = mpm
test12().demo_12(ctxm)


# Notes on decimal:
# No arithmetic operations with double or complex
# results may overflow when mpm and gmp work
# complex numbers need to be converted to decc_t before arith. op. take place

