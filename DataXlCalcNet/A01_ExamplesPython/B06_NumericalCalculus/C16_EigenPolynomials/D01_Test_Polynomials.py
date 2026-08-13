

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






# %%%  12.4 Numerical differentiation and ordinary differential equations




    def test_diff(self, ctx):

        print()
        print("****************************")
        print("Test diff")

    # 7.3.2 Examples

        result1 = ctx.diff(lambda x: x**2 + x, 1.0)
        print("result1: ", result1)


        result2 = ctx.diff(lambda x: x**2 + x, 1.0, 2)
        print("result2: ", result2)


        result3 = ctx.diff(lambda x: x**2 + x, 1.0, 3)
        print("result3: ", result3)


        result4 = ([ctx.diff(ctx.exp, 3, n) for n in range(5)])
        print(result4)



        result5 = ctx.diff(lambda x,y: 3*x*y + 2*y - x, (0.25, 0.5), (0,1))
        print("result5: ", result5)


        result6 = ctx.diff(lambda x,y: 3*x*y + 2*y - x, (0.25, 0.5), (1,1))
        print("result6: ", result6)



        result7 = ctx.diff(abs, 0, direction=0)
        print("result7: ", result7)

        result8 = ctx.diff(abs, 0, direction=1)
        print("result8: ", result8)

        result9 = ctx.diff(abs, 0, direction=-1)
        print("result9: ", result9)

#        result10 = ctx.diff(abs, 0, direction=1j)
#        print("result10: ", result10)



#        result11 = ctx.diff(ctx.sqrt, 1, method='quad')
#        print("result11: ", result11)


        result12 = ctx.diff(ctx.cos, 1e-30)
        print("result12: ", result12)


        result13 = ctx.diff(ctx.cos, 1e-30, h=0.0001)
        print("result13: ", result13)


        result14 = ctx.diff(ctx.cos, 1e-30, addprec=100)
        print("result14: ", result14)




        return


    def test_differentiation(self, ctx):
        print()
        print("****************************")
        print("Test test_differentiation")
        print()

    # 7.9.1 Generating a sequence of derivatives

        print("7.9.1 Generating a sequence of derivatives")

        ctx.dps = 15
        print(list(ctx.diffs(ctx.cos, 1, 5)))

        for i, d in zip(range(6), ctx.diffs(ctx.cos, 1)): print("%s %s" % (i, d))


    # 7.9.2 Composition of derivatives

        print()
        print("7.9.2 Composition of derivatives")

        f = lambda x: ctx.exp(x)*ctx.cos(x)*ctx.sin(x)
        u = ctx.diffs(f, 1)
        v = ctx.diffs_prod([ctx.diffs(ctx.exp,1), ctx.diffs(ctx.cos,1), ctx.diffs(ctx.sin,1)])
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()


    # 7.9.3 Composition of exponential of derivatives

        print()
        print("7.9.3 Composition of exponential of derivatives")

        # ERROR: 'GPContext' object has no attribute 'psi'

        def diffs_loggamma(x):
            yield ctx.loggamma(x)
            i = 0
            while 1:
                yield ctx.psi(i,x)
                i += 1

        u = ctx.diffs_exp(diffs_loggamma(3))
        v = ctx.diffs(ctx.gamma, 3)
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()
        print(next(u)); print(next(v)); print()


    # 7.9.4 Fractional derivatives / differintegration

        print()
        print("7.9.4 Fractional derivatives / differintegration")

        ctx.dps = 15
        x = ctx.t(3); p = 2; n = 0.5
        result1 = ctx.differint(lambda t: t**p, x, n)
        print("result1", result1)

        result2 = ctx.differint(lambda x: ctx.exp(ctx.pi*x), -1.5, 3)
        print("result2", result2)

        result3 = ctx.differint(lambda x: ctx.exp(ctx.pi*x), 3.5, -3, -ctx.inf)
        print("result3", result3)

#        x = ctx.t(3.5)
#        c = 1*ctx.pi
#        n = 1+2j
#        result4 = ctx.differint(lambda x: ctx.exp(c*x), x, n)
#        print("result4", result4)



    def test_ode(self, ctx):
        print()
        print("****************************")
        print("Test test_ode")

    # 7.10.1.2 Examples of first-order ODEs

        ctx.dps = 15
        f = ctx.odefun(lambda x, y: y, 0, 1)
        for x in [0, 1, 2.5]: print((f(x), ctx.exp(x)))


        ctx.dps = 50
        f = ctx.odefun(lambda x, y: y, 0, 1)
        print(f(1))

        ctx.dps = 15
        f = ctx.odefun(lambda x, y: [y[0]], 0, [1])
        print(f(1))

        print()
        f = ctx.odefun(lambda x, y: x*ctx.sin(y), 0, ctx.pi/2)
        for x in [2, 5, 10]:
            print((f(x), 2*ctx.atan(ctx.exp(ctx.t(x)**2/2))))

        print()
        f = lambda x: (1+x**2)/(1+x**3)
        g = ctx.odefun(lambda x, y: f(x), 1*ctx.pi, 0)
        result1 = g(2*ctx.pi)
        print("result1", result1)
        result2 = ctx.quad(f, [1*ctx.pi, 2*ctx.pi])
        print("result2", result2)


    # 7.10.1.3 Examples of second-order ODEs

        print()
        f = ctx.odefun(lambda x, y: [-y[1], y[0]], 0, [1, 0])
        for x in [0, 1, 2.5, 10]:
            print(f(x), 15)
            print([ctx.cos(x), ctx.sin(x)])
            print("---")





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

    # 12.1 Polynomials
    def demo_12_1(self, ctx):
        self.test_polynomials(ctx)
        print()

    # 12.2 Rootfinder
    def demo_12_2(self, ctx):
        self.test_rootfinder(ctx)
        print()

    # 12.3 Sums, products, limits and extrapolation
    def demo_12_3(self, ctx):
        self.test_sums(ctx)
        self.test_2D_3D_sums(ctx)
        self.test_euler_maclaurin_abel_plana_sums(ctx)
        self.test_products(ctx)
        self.test_limits(ctx)
        self.test_extrapolation(ctx)
        print()

    # 12.4 Numerical differentiation and ordinary differential equations
    def demo_12_4(self, ctx):
        self.test_diff(ctx)
        self.test_differentiation(ctx)
        self.test_ode(ctx)
        print()

    # 12.5 Numerical integration
    def demo_12_5(self, ctx):
        #self.test_quad(ctx)
        self.test_quadsubdiv(ctx)
        #self.test_quadosc(ctx)
        print()

    # 12.6 Numerical inverse Laplace transform
    def demo_12_6(self, ctx):
        self.test_inverse_laplace(ctx)
        print()

    # 12.7 Function approximation
    def demo_12_7(self, ctx):
        self.test_func_approx(ctx)
        print()

    # 12.8 Number identification
    def demo_12_8(self, ctx):
        self.test_number_identification(ctx)
        print()



    def demo_12(self, ctx):
#        self.demo_12_1(ctx)
#        self.demo_12_2(ctx)
#        self.demo_12_3(ctx)
#        self.demo_12_4(ctx)
        self.demo_12_5(ctx)
#        self.demo_12_6(ctx)
#        self.demo_12_7(ctx)
#        self.demo_12_8(ctx)
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

