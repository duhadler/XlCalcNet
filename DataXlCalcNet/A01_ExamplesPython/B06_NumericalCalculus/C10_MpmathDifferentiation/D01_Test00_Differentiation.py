

# list comprehension: https://stackoverflow.com/questions/43684041/initialize-an-nested-list-with-values-e-g-0s

# https://www.programiz.com/python-programming/examples/multiply-matrix

from xlcalcnet import gpm, mpm, dpm, mp

from xlcalcnet.ctx_mparray import gauss_quadrature
#import time

class test12():



# %%%  12.4 Numerical differentiation and ordinary differential equations





    def test_quad_hermite_nmax_rho(self, ctx):

        print("****************************")
        print("test_quad_hermite_nmax_rho")
        def f(y):
            res = 1
            y = y + 0.0
            x = ctx.t(1.0)
            rho = ctx.t(0.25)
            k = 3
            a = y * ctx.sqrt(ctx.fabs(rho))
            b = ctx.sqrt(1-rho)
            z1 = (x+a)/b
            res = (ctx.ndis(z1))**(k)

            res = res * ctx.ndens(y)
            return res

        #f = lambda x: ctx.ndens(x)

        # The following set of values will integrate ctx.ndens(x) exactly, for n>=1
        C = 1
        F = 1 / ctx.sqrt(2)
        d = 0

        C = 6.8998125291077868
        F = 5.4
        d = 1.2906271606993869E-09

        LeftTail = True
        #TargetRelError = 1.0E-15
        TargetRelError = 1.0E-2
        RelError = 1
        n = 1
        LastEstimate = ctx.nan
        while RelError>TargetRelError:
            n = 2 * n
            print("n: ", n)
            X, W = gauss_quadrature(ctx, n, "hermite")

            j = int(n/2)
            sum2a = ctx.t(0)
            summand = ctx.t(1)
            if (n<=8):
                factor = ctx.t(1)
            else:
                factor = LastEstimate
            while (j < n) and ((summand > (0*TargetRelError * factor)) or (n<=8)):
                beta = ctx.exp(X[j]*X[j])*W[j]
                alpha = C * X[j] / F + d
                beta = C * beta / F
                summand = f(alpha) * beta
                print(j, alpha, beta, summand)
                sum2a = sum2a + summand
                j = j + 1
            jplus = j-int(n/2)
            print("j plus: ", jplus)

            print()
            j = int(n/2)
            sum2b = ctx.t(0)
            summand = ctx.t(1)
            while (j < n) and ((summand > (0*TargetRelError * factor)) or (n<=8)):
                beta = ctx.exp(X[j]*X[j])*W[j]
                alpha = C * X[j] / F + d
                beta = C * beta / F
                summand = f(alpha) * beta
                print(j, alpha, beta, summand)

                sum2b = sum2b + summand
                j = j + 1
            jminus = j-int(n/2)
            print("j minus: ", jminus)
            sum2 = sum2a + sum2b
            #print("1-sum2: ", 1-sum2)

            #print("sum1: ", sum1, 1-sum1)
            #print("1-sum1: ", 1-sum1)
            if (LeftTail):
                Estimate = sum2
            else:
                Estimate = 1-sum2
            print("Estimate: ", Estimate)
            print("LastEstimate: ", LastEstimate)
            if ctx.isfinite(LastEstimate):
                RelError = ctx.fabs((Estimate-LastEstimate)/Estimate)
                print("RelError", float(RelError))
            LastEstimate = Estimate
            print()




    def test_quad_hermite_nmax_rho_old2(self, ctx):

        print()
        print("****************************")
        print("test_quad_hermite_nmax_rho_old2")

        n = 16
        f = lambda x: ctx.ndens(x)
        X, W = gauss_quadrature(ctx, n, "hermite")

        # The following set of values will integrate ctx.ndens(x) exactly, for n>=1
        C = 1
        F = 1 / ctx.sqrt(2)
        d = 0

        sum1 = ctx.t(0)
        print("i, alpha, beta, summand")
        for i in range(len(X)-0):
            beta = ctx.exp(X[i]*X[i])*W[i]
            alpha = C * X[i] / F + d
            beta = C * beta / F
            summand = f(alpha) * beta
            print(i, alpha, beta, summand)
            sum1 = sum1 + summand

        print("sum1: ", sum1, 1-sum1)



    def test_quad_hermite_nmax_rho_old(self, ctx):
        fmax = ctx.t(0.0)
        def f(y):
            y = y + 0.0
            x = ctx.t(-1.0)
            rho = ctx.t(0.5)
            k = 3
            a = y * ctx.sqrt(ctx.fabs(rho))
            b = ctx.sqrt(1-rho)
            z1 = (x+a)/b
            res = (ctx.ndis(z1))**(k)
            return res


        print()
        print("****************************")
        print("test_quad_hermite_nmax_rho")

##        c = 2.00
##        mp.plot([lambda y: f(y+c) * ctx.ndens(y+c), lambda y: ctx.ndens(y+0.0)], [-4, 4], points=400)

        c = 1.80
        mp.plot([lambda y: f(y+c) * ctx.ndens(y+c),  \
                lambda y:  f(y+0) * ctx.ndens(y+0)],  \
            [-4, 4], points=400)

        LeftTail = True
        #TargetRelError = 1.0E-15
        TargetRelError = 1.0E-8
        RelError = 1
        n = 1
        LastEstimate = ctx.nan
        while RelError>TargetRelError:
            n = 2 * n
            print("n: ", n)

            #fdiff = lambda x: ctx.diff(lambda y: f(y), x, n=2*n)
            #mp.plot(lambda y: f(y), [-6, 6], points=200)
            #mp.plot(lambda x: fdiff(x), [-16, 16], points=200)
            #print("fmax: ", fmax)

            X, W = gauss_quadrature(ctx, n, "hermite")

##            sum1 = ctx.t(0)
            sqrt2 = ctx.sqrt(2)
            sqrtinvpi = 1/ctx.sqrt(ctx.pi)
##            for j in range(len(X)-0):
##                beta =  W[j]*sqrtinvpi
##                alpha = X[j]*sqrt2
##                summand = f(alpha) * beta
##                print(j, alpha, beta, summand)
##                sum1 = sum1 + summand

            #print()
            j = int(n/2)
            sum2a = ctx.t(0)
            summand = ctx.t(1)
            if (n<=8):
                factor = ctx.t(1)
            else:
                factor = LastEstimate
            while (j < n) and ((summand > (TargetRelError * factor)) or (n<=8)):
                beta =  W[j]*sqrtinvpi
                alpha = X[j]*sqrt2
                summand = f(alpha) * beta
                print(j, alpha, beta, summand)
                sum2a = sum2a + summand
                j = j + 1
            jplus = j-int(n/2)
            print("j plus: ", jplus)

            print()
            j = int(n/2)
            sum2b = ctx.t(0)
            summand = ctx.t(1)
            while (j < n) and ((summand > (TargetRelError * factor)) or (n<=8)):
                beta =  W[j]*sqrtinvpi
                alpha = -X[j]*sqrt2
                summand = f(alpha) * beta
                print(j, alpha, beta, summand)
                sum2b = sum2b + summand
                j = j + 1
            jminus = j-int(n/2)
            print("j minus: ", jminus)
            sum2 = sum2a + sum2b
            #print("1-sum2: ", 1-sum2)



            #print("sum1: ", sum1, 1-sum1)
            #print("1-sum1: ", 1-sum1)
            if (LeftTail):
                Estimate = sum2
            else:
                Estimate = 1-sum2
            print("Estimate: ", Estimate)
            if ctx.isfinite(LastEstimate):
                RelError = ctx.fabs((Estimate-LastEstimate)/Estimate)
                print("RelError", float(RelError))
            LastEstimate = Estimate
            print()


        #print("S: ", S)


    def test_quad_hermite_probabilist(self, ctx):

        print()
        print("****************************")
        print("Test diff new2")

    # 7.3.2 Examples

        n = 10
        f0 = lambda x: 1
##        f0 = lambda x: ctx.exp(x*x/2) / (ctx.sqrt(2*ctx.pi))

        f = lambda y: ctx.diff(lambda x: f0(x), y, n=2*n)
##        f = lambda y: ctx.diff(lambda x: ctx.ndens(x), y, n=2*n)
        print("maximum, f(0): ", f(0))

        X, W = gauss_quadrature(ctx, n, "hermite")

        sum1 = ctx.t(0)
        sqrt2 = ctx.sqrt(2)
        sqrtinvpi = 1/ctx.sqrt(ctx.pi)
        for i in range(len(X)-0):
            beta =  W[i]*sqrtinvpi
            alpha = X[i]*sqrt2
            summand = f0(alpha) * beta
            print(i, alpha, beta, summand)
            sum1 = sum1 + summand

        print("sum1: ", sum1, 1-sum1)



    def test_quad_hermite_physicist(self, ctx):

        print()
        print("****************************")
        print("Test diff new")

    # 7.3.2 Examples

        n = 50
        f0 = lambda x: ctx.ndens(x)
##        f0 = lambda x: ctx.exp(x*x/2) / (ctx.sqrt(2*ctx.pi))

##        f = lambda y: ctx.diff(lambda x: f0(x) * ctx.exp(-x*x), y, n=2*n)
        f = lambda y: ctx.diff(lambda x: ctx.ndens(x), y, n=2*n)
        print("maximum, f(0): ", f(0))

        error1 = 1.772454 * f(0.0) * mpm.factorial(n) / (2**n * mpm.factorial(2*n))
        print("error1: ", error1)

##        error2 = f(0.0) * (12**(2*n+1)) * mpm.factorial(n)**4 / ((2*n+1) * mpm.factorial(2*n)**3)
##        error2 = f(0.0) * (2**(2*n+1)) * mpm.factorial(n)**4 / ((2*n+1) * mpm.factorial(2*n)**3)
##        print("error2: ", error2)


        X, W = gauss_quadrature(ctx, n, "hermite")

        A1 = 1 / ctx.sqrt(3)
##        A1 = 1
        A2 = ctx.fdot([(f0(x), w) for x, w in zip(X, W)])

        error3 = ctx.fabs(A1-A2)/A1

        print("error3: ", error3)


##        print("A1:", A1)
##        print("A2:", A2)
##        print("X:", X)
##        print("W:", W)

        sum1 = ctx.t(0)
        for i in range(len(X)-0):
            beta =  ctx.exp(X[i]*X[i])*W[i]
            summand = f0(X[i]) * beta
            print(i, X[i], W[i], beta, summand)
            sum1 = sum1 + summand

        print("sum1: ", sum1, 1-sum1)

##        mp.plot(lambda y: f(y), [-6, 6], points=400)






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





# %%%  Main Run


    # 12.4 Numerical differentiation and ordinary differential equations
    def demo_12_4(self, ctx):
        self.test_quad_hermite_nmax_rho(ctx)
##        self.test_quad_hermite_probabilist(ctx)
##        self.test_quad_hermite_physicist(ctx)
##        self.test_diff(ctx)
##        self.test_differentiation(ctx)
##        self.test_ode(ctx)
        print()




    def demo_12(self, ctx):
        self.demo_12_4(ctx)
        print()


mpm.dps=25
gpm.dps=mpm.dps
dpm.dps=mpm.dps
print("dps: ", mpm.dps)

#ctxm = dpm
#ctxm = gpm
ctxm = mpm
test12().demo_12(ctxm)


# Notes on decimal:
# No arithmetic operations with double or complex
# results may overflow when mpm and gmp work
# complex numbers need to be converted to decc_t before arith. op. take place

