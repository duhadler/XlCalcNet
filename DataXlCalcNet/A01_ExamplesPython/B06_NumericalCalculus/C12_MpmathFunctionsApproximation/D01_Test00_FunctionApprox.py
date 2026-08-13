

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():



# %%%  12.7 Function approximation



    def test_func_approx(self, ctx):
        print()
        print("****************************")
        print("Test test_func_approx")

    # 7.11.1 Taylor series
        print()
        print("7.11.1 Taylor series")

        ctx.dps = 15
        print(ctx.taylor(ctx.sin, 0, 5))

        print()
        p = ctx.taylor(ctx.exp, 2.0, 10)
        result1 = ctx.polyval(p[::-1], 2.5 - 2.0)
        print("result1", result1)


    # 7.11.2 Pade approximation
        print()
        print("7.11.2 Pade approximation")

        ctx.dps = 15
        one = ctx.t(1)
        def f(x):
            return ctx.sqrt((one + 2*x)/(one + x))

        a = ctx.taylor(f, 0, 6)
        p, q = ctx.pade(a, 3, 3)
        x = 10
        result2 = ctx.polyval(p[::-1], x) / ctx.polyval(q[::-1], x)
        print("result2", result2)


    # 7.11.3 Chebyshev approximation
        print()
        print("7.11.3 Chebyshev approximation")

        ctx.dps = 15
        poly, err = ctx.chebyfit(ctx.cos, [1, 2], 5, error=True)
        print("poly: ", poly)
        print("err: ", err)

        result3 = ctx.polyval(poly, 1.6)
        print("result3", result3)

        error = lambda x: abs(ctx.cos(x) - ctx.polyval(poly, x))
        print(max([error(1+n/1000.) for n in range(1000)]))


    # 7.11.4 Fourier series
        print()
        print("7.11.4 Fourier series")

        ctx.dps = 15
        c, s = ctx.fourier(lambda x: x, [-1*ctx.pi, 1*ctx.pi], 5)
        print(c)
        print(s)

        print()
        I = [-1, 1.5]
        f = lambda x: x**2 - 4*x + 1
        cs = ctx.fourier(f, I, 4)
        print(cs[0])
        print()
        print(cs[1])
        print()

        I = [-1, 1]
        cs = ctx.fourier(ctx.cosh, I, 9)
        g = lambda x: (ctx.cosh(x) - ctx.fourierval(cs, I, x))**2
        print(ctx.sqrt(ctx.quad(g, I)))

        print(ctx.fourier(abs, [-1, 1], 0))
        print(ctx.fourier(abs, [-1, 0, 1], 0), 10)




# %%%  Main Run


    # 12.7 Function approximation
    def demo_12_7(self, ctx):
        self.test_func_approx(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_7(ctx)
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

