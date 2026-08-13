

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm

#import time

class test12():



# %%%  12.3 Sums, products, limits and extrapolation



    def test_sums(self, ctx):
        print()
        print("****************************")
        print("Test test_sums_limits")

        ctx.dps = 15
        result1 = ctx.nsum(lambda n: 1/ctx.factorial(n), [0, ctx.inf])
        print("result1: ", result1)

        result2 = ctx.nsum(lambda n: 1/n**2, [1, ctx.inf])
        print("result2: ", result2)


    # 7.7.1.3 Basic examples

        result3 = ctx.nsum(lambda k: 1/k, [1, 6])
        print("result3: ", result3)

        result4 = ctx.nsum(lambda k: 1/k**2, [-ctx.inf, -1])
        print("result4: ", result4)

        result5 = ctx.nsum(lambda k: 1/(1+k**2), [-ctx.inf, ctx.inf])
        print("result5: ", result5)

#        result6 = ctx.nsum(lambda k: (0.5+0.25j)**k, [0, ctx.inf])
#        print("result6: ", +result6)
#        print(ctx.dps)


        ctx.dps = 1000
        a = ctx.nsum(lambda k: -(-1)**k * k**2 / ctx.factorial(2*k), [1, ctx.inf], method='direct')
        b = (ctx.cos(1) + ctx.sin(1))/4
        result7 = abs(a-b) < ctx.t('1e-998')
        print("result7: ", result7)


    # 7.7.1.4 Examples with Richardson extrapolation

        ctx.dps = 50
        result8 = ctx.nsum(lambda k: 1 / k**3, [1, ctx.inf], method='richardson')
        print("result8: ", result8)

        result9 = ctx.nsum(lambda n: (n + 3)/(n**3 + n**2), [1, ctx.inf], method='richardson')
        print("result9: ", result9)

        result10 = ctx.nsum(lambda k: (-1)**k / k**3, [1, ctx.inf], method='richardson')
        print("result10: ", result10)


    # 7.7.1.5 Examples with Shanks transformation

        ctx.dps = 50
        result11 = ctx.nsum(lambda k: -(-1)**k/k, [1, ctx.inf], method='shanks')
        print("result11: ", result11)

        result12 = ctx.nsum(lambda k: ctx.t('0.995')**k, [0, ctx.inf], method='shanks')
        print("result12: ", result12)

#        ctx.dps = 15
#        result13 = ctx.nsum(lambda k: (-1)**(k+1) / k**1.5, [1, ctx.inf], method='shanks')
#        print("result13: ", result13)

        ctx.dps = 15
        result14 = ctx.nsum(lambda k: (-1)**k / ctx.log(k), [2, ctx.inf], method='shanks')
        print("result14: ", result14)

        ctx.dps = 30
        result15 = ctx.nsum(lambda k: (-1)**k / ctx.log(k), [2, ctx.inf], method='shanks')
        print("result15: ", result15)


    # 7.7.1.6 Examples with Levin transformation

        ctx.dps = 30
        z = ctx.t(10) ** (-10)
        a = ctx.nsum(lambda n: n**(-(1+z)), [1, ctx.inf], method = "levin") - 1 / z
        result16 = a - ctx.euler
        print("result16: ", result16)

        # Note: comparison with zeta function not yet possible (bernoulli is missing)
        ctx.dps = 15
        z = ctx.t(10) ** (-10)
        w = ctx.nsum(lambda n: n ** ctx.t(2 + 3j), [1, ctx.inf], method = "levin", levin_variant = "v")
        result17 = w
        print("result17: ", result17)

        ctx.dps = 15
        z = ctx.t(10)
        exact = z * ctx.exp(z) * ctx.expint(1,z)
        w = ctx.nsum(lambda n: (-1) ** n * ctx.factorial(n) * z ** (-n), [0, ctx.inf], method = "sidi", levin_variant = "t")
        result18 = w - exact
        print("result18: ", result18)


#        ctx.dps = 15
#        z = ctx.t(2)
#        one = ctx.t(1)
#        exact = ctx.exp(one / (32 * z)) * ctx.besselk(one / 4, one / (32 * z)) / (4 * ctx.sqrt(z * ctx.pi))
#        print("exact: ", exact)
#        w = ctx.nsum(lambda n: (-z)**n * ctx.fac(4 * n) / (ctx.fac(n) * ctx.fac(2 * n) * (4 ** n)), [0, ctx.inf], method = "levin", levin_variant = "t", workprec = 8*ctx.prec, steps = [2] + [1 for x in range(1000)])
#        result18 = w - exact
#        print("result18: ", result18)


#        ctx.dps = 15
#        z = 2 + 1j
#        exact = ctx.hyp2f1(2 / ctx.t(3), 4 / ctx.t(3), 1 / ctx.t(3), z)
#        print("exact: ", exact)
#        f = lambda n: ctx.rf(2 / ctx.t(3), n) * ctx.rf(4 / ctx.t(3), n) * z**n / (ctx.rf(1 / ctx.t(3), n) * ctx.factorial(n))
#        v = ctx.nsum(f, [0, ctx.inf], method = "levin", steps = [10 for x in range(1000)])
#        result19 = v - exact
#        print("result19: ", result19)


    # 7.7.1.7 Examples with Cohen’s alternating series resummation

        ctx.dps = 15
        result20 = ctx.nsum(lambda n: (-1)**(n-1) / n, [1, ctx.inf], method = "a")
        print("result20: ", result20)

        result21 = ctx.nsum(lambda n: (-1)**n * ctx.log(n) * n, [1, ctx.inf], method = "a")
        print("result21: ", result21)

        # Note: comparison with zeta function not yet possible (bernoulli is missing)
    #    z = ctx.diff(lambda s: ctx.altzeta(s), -1)
    #    print("z: ", z)




    # 7.7.1.8 Examples with Euler-Maclaurin summation

        #!!! Note: change to extrapolation.py !!!
        ctx.dps = 15
        res = ctx.bernoulli(8)
        print("res = ctx.bernoulli(8)", res)
        f = lambda k: ctx.log(k)/k**ctx.t('2.5')
        result22 = ctx.nsum(f, [1, ctx.inf], method='euler-maclaurin')
        print("result22: ", result22)

        ctx.dps = 50
        f = lambda k: ctx.log(k)/k**ctx.t('2.5')
        result23 = ctx.nsum(f, [1, ctx.inf], method='euler-maclaurin', steps=[250])
        print("result23: ", result23)


    # 7.7.1.9 Divergent series

        ctx.dps = 50
        f = lambda k: ctx.log(k)/k**2.5
        result24 = ctx.nsum(lambda k: -(-9)**k/k, [1, ctx.inf], method='shanks')
        print("result24: ", result24)


#        ctx.dps = 15
#        for n in range(-8, 8):
#            if n == 1:
#                continue
#            print("%s %s %s" % (ctx.t(n), ctx.t(1)/(1-n), ctx.nsum(lambda k: n**k, [0, ctx.inf], method='shanks')))



    def test_2D_3D_sums(self, ctx):
        print()
        print("****************************")
        print("Test test_2D_3D_sums")

    # 7.7.1.10 Multidimensional sums

        ctx.dps = 15
        result1 = ctx.nsum(lambda x,y: x+y, [2,3], [4,5])
        print("result1: ", result1)

        result2 = ctx.nsum(lambda x,y: x/2**y, [1,3], [1,ctx.inf])
        print("result2: ", result2)

        result3 = ctx.nsum(lambda x,y: y/2**x, [1,ctx.inf], [1,3])
        print("result3: ", result3)

        result4 = ctx.nsum(lambda x,y,z: z/(2**x*2**y), [1,ctx.inf], [1,ctx.inf], [3,4])
        print("result4: ", result4)

        result5 = ctx.nsum(lambda x,y,z: y/(2**x*2**z), [1,ctx.inf], [3,4], [1,ctx.inf])
        print("result5: ", result5)

        result6 = ctx.nsum(lambda x,y,z: x/(2**z*2**y), [3,4], [1,ctx.inf], [1,ctx.inf])
        print("result6: ", result6)



        result7 = ctx.nsum(lambda m, n: 1/2**(m*n), [1,ctx.inf], [1,ctx.inf])
        print("result7: ", result7)

        result8 = ctx.nsum(lambda n: 1/(2**n-1), [1,ctx.inf])
        print("result8: ", result8)

        result9 = ctx.nsum(lambda i,j: (-1)**(i+j)/(i**2+j**2), [1,ctx.inf], [1,ctx.inf])
        print("result9: ", result9)

        result10 = ctx.nsum(lambda i,j: (-1)**(i+j)/(i+j)**2, [1,ctx.inf], [1,ctx.inf])
        print("result10: ", result10)

        result11 = ctx.nsum(lambda i,j: (-1)**(i+j)/(i+j)**3, [1,ctx.inf], [1,ctx.inf])
        print("result11: ", result11)

        result12 = ctx.nsum(lambda m,n: m**2*n/(3**m*(n*3**m+m*3**n)), [1,ctx.inf], [1,ctx.inf])
        print("result12: ", result12)

    #    #This takes a long time !!!
    #    result13 = ctx.nsum(lambda i,j: ctx.fac(i-1)*ctx.fac(j-1)/ctx.fac(i+j), [1,ctx.inf], [1,ctx.inf], workprec=400)
    #    print("result13: ", result13)


    #    #This is taking too long !!!!
    #    result14 = ctx.nsum(lambda x,y,z: (-1)**(x+y+z)/(x*x+y*y+z*z)**0.5, [-ctx.inf,ctx.inf], [-ctx.inf,ctx.inf], [-ctx.inf,ctx.inf], ignore=True)
    #    print("result14: ", result14)

        result15 = ctx.nsum(lambda x,y: -12*ctx.pi*ctx.sech(ctx.t(0.5)*ctx.pi * ctx.sqrt((2*x+1)**2+(2*y+1)**2))**2, [0,ctx.inf], [0,ctx.inf])
        print("result15: ", result15)

    #    # This gives a wrong result (should be -2.1775860903036)
    #    result16 = ctx.nsum(lambda x,y: (-1)**(x+y) / (x**2+y**2), [-ctx.inf,ctx.inf], [-ctx.inf,ctx.inf], ignore=True)
    #    print("result16: ", result16)
    #
    #    # This gives a wrong result (should be (3.1512120021539 + 0.0j))
    #    result17 = ctx.nsum(lambda m,n: (m+n*1j)**(-4), [-ctx.inf,ctx.inf], [-ctx.inf,ctx.inf], ignore=True)
    #    print("result17: ", result17)


    def test_euler_maclaurin_abel_plana_sums(self, ctx):
        print()
        print("****************************")
        print("Test euler_maclaurin_abel_plana_sums")

    # 7.7.2.1 Examples Euler-Maclaurin formula

        ctx.dps = 50
        result1 = ctx.sumem(lambda n: 1/n**2, [32, ctx.inf])
        print("result1: ", result1)

        I = ctx.t(1)/32
        D1 = ((-1)**n*ctx.factorial(n+1)*32**ctx.t(-2-n) for n in range(999))
        result2 = ctx.sumem(lambda n: 1/n**2, [32, ctx.inf], integral=I, adiffs=D1)
        print("result2: ", result2)


        result3 = ctx.sumem(lambda n: n**5-12*n**2+3*n, [-100000, 200000])
        print("result3: ", result3)

        result4 = sum(n**5-12*n**2+3*n for n in range(-100000, 200001))
        print("result4: ", result4)

    # 7.7.2.1 Examples Abel-Plana formula

        ctx.dps = 25
        # dec: overflow
#        result5 = ctx.sumap(lambda k: 1/k**ctx.t(2.5), [1,ctx.inf])
#        print("result5: ", result5)
#        print("ctx.zeta(2.5): ", ctx.zeta(2.5))

        # dec: overflow
#        result6 = ctx.sumap(lambda k: 1/ctx.t(k+ctx.t(1j))**ctx.t('2.5+2.5j'), [1,ctx.inf])
#        print("result6: ", result6)
#        print("ctx.zeta(2.5+2.5j, 1+1j): ", ctx.hurwitz(2.5+2.5j, 1+1j))



    def test_products(self, ctx):
        print()
        print("****************************")
        print("Test test_products")


    # 7.7.2.1 Examples Products

        ctx.dps = 25
        result1 = ctx.nprod(lambda k: k, [1, 4])
        print("result1: ", result1)

        result2 = 2*ctx.nprod(lambda k: (4*k**2)/(4*k**2-1), [1, ctx.inf])
        print("result2: ", result2)

        result3 = ctx.nprod(lambda k: (1+1/k)**2/(1+2/k), [1, ctx.inf])
        print("result3: ", result3)

        result4 = ctx.nprod(lambda k: (k**3-1)/(k**3+1), [2, ctx.inf])
        print("result4: ", result4)

        result5 = ctx.nprod(lambda k: (1-1/k**2), [2, ctx.inf])
        print("result5: ", result5)


        result6 = ctx.nprod(lambda k: ctx.exp(1/k**2), [1, ctx.inf])
        print("result6: ", result6)

        result7 = ctx.nprod(lambda k: (k**2-1)/(k**2+1), [2, ctx.inf])
        print("result7: ", result7)

        result8 = ctx.nprod(lambda k: (k**4-1)/(k**4+1), [2, ctx.inf])
        print("result8: ", result8)

        result9 = ctx.nprod(lambda k: (1+1/k+1/k**2)**2/(1+2/k+3/k**2), [1, ctx.inf])
        print("result9: ", result9)

        result10 = ctx.nprod(lambda k: (1-1/k**4), [2, ctx.inf]); ctx.sinh(1*ctx.pi)/(4*ctx.pi)
        print("result10: ", result10)

        result11 = ctx.nprod(lambda k: (1-1/k**6), [2, ctx.inf])
        print("result11: ", result11)

        result12 = ctx.nprod(lambda k: (1+ctx.t(1)/k**2), [2, ctx.inf])
        print("result12: ", result12)

        result13 = ctx.nprod(lambda n: (1+ctx.t(1)/n)**n * ctx.exp(ctx.t(1)/(2*n)-1), [1, ctx.inf])
        print("result13: ", result13)


        result14 = ctx.nprod(lambda k: (1-ctx.pi**-k)/(1+ctx.pi**-k), [1, ctx.inf])
        print("result14: ", result14)

        result15 = ctx.nprod(lambda k: ctx.tanh(k*ctx.log(ctx.pi)/2), [1, ctx.inf])
        print("result15: ", result15)


        result16 = ctx.nprod(lambda k: (1-1/2**k), [1, ctx.inf])
        print("result16: ", result16)


        result17 = ctx.nprod(lambda k: 1-k**(-3), [-ctx.inf,-2])
        print("result17: ", result17)

        result18 = ctx.nprod(lambda k: ctx.exp(1/(1+k**2)), [-ctx.inf, ctx.inf])
        print("result18: ", result18)

        result19 = ctx.nprod(lambda k: (1-1/k**ctx.t(2.5)), [2, ctx.inf], method='e')
        print("result19: ", result19)



    def test_limits(self, ctx):
        print()
        print("****************************")
        print("Test test_limits")


    # 7.7.2.1 Examples Products

        ctx.dps = 30
        result1 = ctx.limit(lambda x: (x-ctx.sin(x))/x**3, 0)
        print("result1: ", result1)

        result2 = ctx.limit(lambda n: (1+3/n)**n, ctx.inf)
        print("result2: ", result2)

        f = lambda n: 2**(4*n+1)*ctx.factorial(n)**4/(2*n+1)/ctx.factorial(2*n)**2
        result3 = ctx.limit(f, ctx.inf)
        print("result3: ", result3)

        result4 = ctx.limit(lambda n: ctx.factorial(n) / (ctx.sqrt(n)*(n/ctx.e)**n), ctx.inf)
        print("result4: ", result4)


        f = lambda n: sum([ctx.t(1)/k for k in range(1,int(n)+1)]) - ctx.log(n)
        result5 = ctx.limit(f, ctx.inf)
        print("result5: ", result5)

        f = lambda x: ctx.sqrt(x**3+x**2)/(ctx.sqrt(x**3)+x)
        result6 = ctx.limit(f, ctx.inf)
        print("result6: ", result6)
        result7 = ctx.limit(f, ctx.inf, exp=True)
        print("result7: ", result7)



    # 7.7.6 Limit of a weighted combination of hypergeometric functions

        ctx.dps = 15

        # This calls the local hypsum ## Amazingly, this gives a correct result
        result8 = ctx.hypercomb(lambda a: [([a-1],[1],[a-3],[a-4],[a],[a-1],3)], [1])
        print("result8: ", result8)


    # 7.7.7 Limit of the product of gamma functions

        ctx.dps = 15
        result9 = ctx.gammaprod([], [0])
        print("result9: ", result9)

        result10 = ctx.gammaprod([-4], [-3])
        print("result10: ", result10)

        result11 = ctx.limit(lambda x: ctx.gamma(x-1)/ctx.gamma(x), -3, direction=1)
        print("result11: ", result11)

        result12 = ctx.limit(lambda x: ctx.gamma(x-1)/ctx.gamma(x), -3, direction=1)
        print("result12: ", result12)



    def test_extrapolation(self, ctx):
        print()
        print("****************************")
        print("Test test_extrapolation")


    # 7.8.1 Richardson extrapolation
        print()
        print("7.8.1 Richardson extrapolation")

        ctx.dps = 30
        S = [4*sum(ctx.t(-1)**n/(2*n+1) for n in range(m)) for m in range(1,30)]
        v, c = ctx.richardson(S[:10])
        print("v:", v)
        print("[v-pi, c]:", [v-ctx.pi, c])

        v, c = ctx.richardson(S[:30])
        print("v:", v)
        print("[v-pi, c]:", [v-ctx.pi, c])



    # 7.8.2 Shanks extrapolation
        print()
        print("7.8.2 Shanks extrapolation")

        ctx.dps = 50
        S = [4*sum(ctx.t(-1)**n/(2*n+1) for n in range(m)) for m in range(1,30)]

        T = ctx.shanks(S[:7])
        for row in T: print(row)
        print()
        L = T[-1]
        print([abs(L[-1] - ctx.pi), abs(L[-1] - L[-3]), abs(L[-2])])
        print()

        T = ctx.shanks(S[:25])
        L = T[-1]
        print([abs(L[-1] - ctx.pi), abs(L[-1] - L[-3]), abs(L[-2])])


        ctx.dps = 15
        for row in ctx.shanks([ctx.t(0.5), ctx.t(0.75), ctx.t(0.875), ctx.t(0.9375), ctx.t(0.96875)]): print(row)






# %%%  Main Run


    # 12.3 Sums, products, limits and extrapolation
    def demo_12_3(self, ctx):
        self.test_sums(ctx)
        self.test_2D_3D_sums(ctx)
        self.test_euler_maclaurin_abel_plana_sums(ctx)
        self.test_products(ctx)
        self.test_limits(ctx)
        self.test_extrapolation(ctx)
        print()



    def demo_12(self, ctx):
        self.demo_12_3(ctx)
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

