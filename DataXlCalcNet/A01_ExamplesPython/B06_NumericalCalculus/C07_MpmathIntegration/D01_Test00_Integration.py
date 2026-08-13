

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():





# %%%  12.5 Numerical integration




    def test_quad(self, ctx):
        print()
        print("****************************")
        print("Test quad")


        result1 = ctx.quad(ctx.sin, [0, ctx.pi])
        print("result1: ", result1)

        f = lambda x, y: ctx.cos(x+y/2)
        result2 = ctx.quad(f, [-ctx.pi/2, ctx.pi/2], [0, ctx.pi])
        print("result2: ", result2)

    # 7.5.4 Examples of 1D integrals

        result3 = ctx.quad(lambda x: 2/(x**2+1), [0, ctx.inf])
        print("result3: ", result3)

        result4 = ctx.quad(lambda x: ctx.exp(-x**2), [-ctx.inf, ctx.inf])**2
        print("result4: ", result4)

        ctx.dps = 50
        result5 = 2*ctx.quad(lambda x: ctx.sqrt(1-x**2), [-1, 1])
        print("result5: ", result5)

        ctx.dps = 15
        result6 = ctx.quad(lambda z: 1/z, [1,1j,-1,-1j,1])
        print("result6: ", result6)


    # 7.5.5 Examples of 2D and 3D integrals

        print()
        ctx.dps = 30
        f = lambda x, y: (x-1)/((1-x*y)*ctx.log(x*y))
        result7 = ctx.quad(f, [0, 1], [0, 1])
        print("result7: ", result7)

        f = lambda x, y: 1/ctx.sqrt(1+x**2+y**2)
        result8 = ctx.quad(f, [-1, 1], [-1, 1])
        print("result8: ", result8)

        f = lambda x, y: 1/(1-x**2 * y**2)
        result9 = ctx.quad(f, [0, 1], [0, 1])
        print("result9: ", result9)

        result10 = ctx.quad(lambda x, y: 1/(1-x*y), [0, 1], [0, 1])
        print("result10: ", result10)

        ctx.dps = 15
        result11 = ctx.quad(lambda x,y: ctx.exp(-x-y), [0, ctx.inf], [1, ctx.inf])
        print("result11: ", result11)

        f = lambda x: ctx.quad(lambda y: 1, [-ctx.sqrt(1-x**2), ctx.sqrt(1-x**2)])
        result12 = ctx.quad(f, [-1, 1])
        print("result12: ", result12)

        f = lambda x,y,z: x*y/(1+z)
        result13 = ctx.quad(f, [0,1], [0,1], [1,2], method='gauss-legendre')
        print("result13: ", result13)


    # 7.5.6 Singularities

        print()
        ctx.dps = 15
        result14 = ctx.quad(lambda x: abs(ctx.sin(x)), [0, 2*ctx.pi]) # Bad
        print("result14: ", result14)

        result15 = ctx.quad(lambda x: abs(ctx.sin(x)), [0, 1*ctx.pi, 2*ctx.pi]) # Good
        print("result15: ", result15)


        result16 = ctx.quad(ctx.log, [0, 1], method='tanh-sinh') # Good
        print("result16: ", result16)

        result17 = ctx.quad(ctx.log, [0, 1], method='gauss-legendre') # Bad
        print("result17: ", result17)

        result18 = ctx.quad(lambda x: 1/ctx.sqrt(x), [0, 1], method='tanh-sinh')
        print("result18: ", result18)

        ctx.dps = 30
        result19 = ctx.quad(lambda x: 1/ctx.sqrt(x), [0, 1], method='tanh-sinh')
        ctx.dps = 15
        print("result19: ", +result19)


    # 7.5.7 Highly variable functions

        print()
        ctx.dps = 15
        result20 = ctx.quad(ctx.sin, [0, 100]) # Good
        print("result20: ", result20)

        result21 = ctx.quad(ctx.sin, [0, 1000]) # Bad
        print("result21: ", result21)

#        result22 = ctx.quad(ctx.sin, ctx.linspace(0, 1000, 10)) # Good
#        print("result22: ", result22)

        result23 = ctx.quad(ctx.sin, [0, 1000], maxdegree=10) # Also good
        print("result23: ", result23)


        f = lambda x: 1/(1+x**2)
        result24 = ctx.quad(f, [-100, 100]) # Bad
        print("result24: ", result24)

        result25 = ctx.quad(f, [-100, 100], maxdegree=10) # Good
        print("result25: ", result25)

        result26 = ctx.quad(f, [-100, 0, 100]) # Also good
        print("result26: ", result26)


        return


    def test_quadsubdiv(self, ctx):
        print()
        print("****************************")
        print("Test quadsubdiv")
        ctx.dps = 15; ctx.pretty = True
        result1 = ctx.quad(lambda x: abs(ctx.sin(x)), [0, 2*ctx.pi])
        print("result1: ", result1)
        result2 = ctx.quadsubdiv(lambda x: abs(ctx.sin(x)), [0, 2*ctx.pi])
        print("result2: ", result2)
        result3 = ctx.quadsubdiv(ctx.sin, [0, 1000])
        print("result3: ", result3)
        result4 = ctx.quadsubdiv(lambda x: 1/(1+x**2), [-100, 100])
        print("result4: ", result4)
        result5 = ctx.quadsubdiv(lambda x: ctx.ceil(x), [0, 100])
        print("result5: ", result5)
        result6 = ctx.quadsubdiv(lambda x: ctx.sin(x+ctx.exp(x)), [0,8])
        print("result6: ", result6)

        result7 = ctx.quadsubdiv(lambda x: ctx.sin(x**2), [0,100], maxintervals=5, error=True)
        print("result7: ", result7)
        result8 = ctx.quadsubdiv(lambda x: ctx.sin(x**2), [0,100], maxintervals=100, error=True)
        print("result8: ", result8)

        result9 = ctx.quadsubdiv(lambda x: ctx.sech(10*x-2)**2 + ctx.sech(100*x-40)**4 + ctx.sech(1000*x-600)**6, [0,1], error=True)
        print("result9: ", result9)
        ctx.dps = 20
        result10 = ctx.quadsubdiv(lambda x: ctx.sech(10*x-2)**2 + ctx.sech(100*x-40)**4 + ctx.sech(1000*x-600)**6, [0,1], error=True)
        print("result10: ", result10)
        ctx.dps = 15
        # note: problem with linspace
        result11 = ctx.quadsubdiv(lambda x: ctx.sech(10*x-2)**2 + ctx.sech(100*x-40)**4 + ctx.sech(1000*x-600)**6, ctx.linspace(0,1,5))
        print("result11: ", result11)

        v, err = ctx.quadsubdiv(lambda x: ctx.sin(1/x), [0,1], error=True)
        print(round(v, 6), round(err, 6))
        print(ctx.sin(1) - ctx.ci(1))




    def test_quadosc(self, ctx):
        print()
        print("****************************")
        print("Test quadosc")


        ctx.dps = 15
        f = lambda x: ctx.sin(3*x)/(x**2+1)

        result1 = ctx.quadosc(f, [0, ctx.inf], omega=3)
        print("result1: ", result1)

        result2 = ctx.quadosc(f, [0,ctx.inf], period=2*ctx.pi/3)
        print("result2: ", result2)

        result3 = ctx.quadosc(f, [0,ctx.inf], zeros=lambda n: ctx.pi*n/3)
        print("result3: ", result3)


        result4 = ctx.quadosc(lambda x: ctx.cos(x)/(1+x**2), [-ctx.inf, ctx.inf], omega=1)
        print("result4: ", result4)

        result5 = ctx.quadosc(lambda x: ctx.cos(x)/x**2, [-ctx.inf, -1], period=2*ctx.pi)
        print("result5: ", result5)


        #result6 = ctx.quadosc(lambda x: ctx.exp(3j*x)/(1+x**2), [-ctx.inf,ctx.inf], omega=3)
        result6 = ctx.quadosc(lambda x: ctx.exp(3*ctx.j*x)/(1+x**2), [-ctx.inf,ctx.inf], omega=3)
        print("result6: ", result6)

        #result7 = ctx.quadosc(lambda x: ctx.exp(3j*x)/(2+x+x**2), [-ctx.inf,ctx.inf], omega=3)
        result7 = ctx.quadosc(lambda x: ctx.exp(3*ctx.j*x)/(2+x+x**2), [-ctx.inf,ctx.inf], omega=3)
        print("result7: ", result7)


    # 7.6.1 Non-periodic functions

        print()
        # for gmp. j0 is slow and inaccurate, rootfinding fails
#        result8 = ctx.quadosc(ctx.j0, [0, ctx.inf], period=2*ctx.pi)
#        print("result8: ", result8)
#
#        result9 = ctx.quadosc(ctx.j0, [0, ctx.inf], period=2*ctx.pi)
#        print("result9: ", result9)

#        j0zero = lambda n: ctx.findroot(ctx.j0, ctx.pi*(n-0.25))
#        result10 = ctx.quadosc(ctx.j0, [0, ctx.inf], zeros=j0zero)
#        print("result10: ", result10)

        ctx.dps = 30
        f = lambda x: ctx.cos(x**2)
        result11 = ctx.quadosc(f, [0,ctx.inf], zeros=lambda n:ctx.sqrt(ctx.pi*n))
        print("result11: ", result11)

        f = lambda x: ctx.sin(x**2)
        result12 = ctx.quadosc(f, [0,ctx.inf], zeros=lambda n:ctx.sqrt(ctx.pi*n))
        print("result12: ", result12)

        ctx.dps = 15
        f = lambda x: ctx.sin(ctx.exp(x))
        result13 = ctx.quadosc(f, [1,ctx.inf], zeros=lambda n: ctx.log(n))
        print("result13: ", result13)



    # 7.6.1 Non-periodic functions

        print()
        ctx.dps = 15
        f = lambda x: 1/x**2+ctx.sin(x)/x**4
        result14 = ctx.quadosc(f, [1,ctx.inf], omega=1) # Bad
        print("result14: ", result14)

        result15 = ctx.quadosc(f, [1,ctx.inf], omega=ctx.t(0.5)) # Perfect
        print("result15: ", result15)


    # 7.6.3 Fast decay

        print()
        result16 = ctx.quadosc(lambda x: ctx.cos(x)/ctx.exp(x), [0, ctx.inf], omega=1)
        print("result16: ", result16)

        # This overflows for dec
#        result17 = ctx.quad(lambda x: ctx.cos(x)/ctx.exp(x), [0, ctx.inf])
#        print("result17: ", result17)





# %%%  Main Run


    # 12.5 Numerical integration
    def demo_12_5(self, ctx):
        self.test_quad(ctx)
        self.test_quadsubdiv(ctx)
        self.test_quadosc(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_5(ctx)
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

