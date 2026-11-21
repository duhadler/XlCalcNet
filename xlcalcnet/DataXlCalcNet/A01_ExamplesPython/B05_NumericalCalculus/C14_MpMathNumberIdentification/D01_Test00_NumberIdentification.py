

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():


# %%%  12.8 Number identification



    def test_number_identification(self, ctx):
        print()
        print("****************************")
        print("Test test_number_identification")

    # 7.13.1 Constant recognition

    #    ctx.dps = 15
        result1 = ctx.pslq([-1, 1*ctx.pi], tol=0.01)
        print("result1", result1)

        result2 = ctx.pslq([-1, 1*ctx.pi], tol=0.001)
        print("result2", result2)

#        p, q = ctx.pslq([-1, 1*ctx.pi], maxcoeff=10**12)
#        print(p); print(q)

        ctx.dps = 30
        result3 = ctx.pslq([ctx.sqrt(n) for n in range(2, 8+1)])
        print("result3", result3)

        result4 = ctx.pslq([ctx.pi/4, ctx.acot(1)])
        print("result4", result4)

        result5 = ctx.pslq([ctx.pi/4, ctx.acot(5), ctx.acot(239)])
        print("result5", result5)

        result6 = ctx.pslq([ctx.pi/4, ctx.acot(49), ctx.acot(57), ctx.acot(239), ctx.acot(110443)])
        print("result6", result6)

        result7 = ctx.pslq([1*ctx.pi] + [ctx.acot(n) for n in range(2,11)])
        print("result7", result7)

        result8 = ctx.pslq([1*ctx.pi] + [ctx.acot(n) for n in range(2,11) if n not in (3, 5)])
        print("result8", result8)


    # 7.13.2 Algebraic identification

        print()
        ctx.dps = 15
        result9 = ctx.findpoly(0.7)
        print("result9", result9)

        print(ctx.polyval(ctx.findpoly(1*ctx.phi, 2), 1*ctx.phi), 1)

        for r in ctx.polyroots(ctx.findpoly(1*ctx.phi, 2)): print(r)

        result10 = ctx.findpoly(1+ctx.sqrt(2), 2)
        print("result10", result10)

        result11 = ctx.findroot(lambda x: x**2 - 2*x - 1, 1)
        print("result11", result11)

        result12 = ctx.findpoly(ctx.sqrt(2)+ctx.sqrt(3), 4)
        print("result12", result12)

        result13 = ctx.findpoly(1*ctx.pi, 4)
        print("result13", result13)

        result14 = ctx.findpoly(1*ctx.pi, 3, maxcoeff=10000)
        print("result14", result14)

        result15 = ctx.findpoly(1*ctx.pi, 3, tol=1e-7)
        print("result15", result15)


    # 7.13.3 Integer relations (PSLQ)

        print()
        ctx.dps = 15
        result16 = ctx.identify(1*ctx.phi)
        print("result16", result16)

        result16 = ctx.identify(1*ctx.phi)
        print("result16", result16)

        result17 = ctx.identify(0.22222222222222222)
        print("result17", result17)

        result18 = ctx.identify(1.9662210973805663)
        print("result18", result18)

        result19 = ctx.identify(4.1132503787829275)
        print("result19", result19)

        result20 = ctx.identify(0.881373587019543)
        print("result20", result20)


        result21 = ctx.identify(1*ctx.pi)
        print("result21", result21)

        result22 = ctx.identify(3*ctx.pi-2*ctx.e, ['pi', 'e'])
        print("result22", result22)

        result23 = ctx.identify(ctx.pi+ctx.e, {'a':ctx.pi+2, 'b':2*ctx.e})
        print("result23", result23)

        ctx.dps = 50
        base = ['sqrt(2)','pi','log(2)']

        result24 = ctx.identify(0.25, base)
        print("result24", result24)

        result25 = ctx.identify(3*ctx.pi + 2*ctx.sqrt(2) + 5*ctx.log(2)/7, base)
        print("result25", result25)

        result26 = ctx.identify(ctx.exp(ctx.pi+2), base)
        print("result26", result26)

        result27 = ctx.identify(1/(3+ctx.sqrt(2)), base)
        print("result27", result27)

        result28 = ctx.identify(ctx.sqrt(2)/(3*ctx.pi+4), base)
        print("result28", result28)

#        result29 = ctx.identify(5**(ctx.t(1)/3)*ctx.pi*ctx.log(2)**2, base)
#        print("result29", result29)

        ctx.dps = 15
        result30 = ctx.identify(1/(3*ctx.pi-4*ctx.e+ctx.sqrt(8)), ['pi', 'e', 'sqrt(2)'])
        print("result30", result30)

        ctx.dps = 50
        result31 = ctx.identify(1/(3*ctx.pi-4*ctx.e+ctx.sqrt(8)), ['pi', 'e', 'sqrt(2)'])
        print("result31", result31)


        #Finding approximate solutions

        ctx.dps = 15
        result32 = ctx.identify(+ctx.pi, tol=1e-2)
        print("result32", result32)

        result33 = ctx.identify(+ctx.pi, tol=1e-3)
        print("result33", result33)

        result34 = ctx.identify(+ctx.pi, tol=1e-10)
        print("result34", result34)

        #for p in ctx.identify(+ctx.pi, ['e', 'catalan'], tol=1e-5, full=True): print(p)


        #Symbolic processing

        result35 = ctx.identify(ctx.sqrt(2))
        print("result35", result35)





# %%%  Main Run


    # 12.8 Number identification
    def demo_12_8(self, ctx):
        self.test_number_identification(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_8(ctx)
        print()


mpm.dps=25
print("dps: ", mpm.dps)
ctxm = mpm
test12().demo_12(ctxm)


# Notes on decimal:
# No arithmetic operations with double or complex
# results may overflow when mpm and gmp work
# complex numbers need to be converted to decc_t before arith. op. take place

