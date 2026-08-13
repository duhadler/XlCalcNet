# -*- coding: utf-8 -*-
"""
Spyder Editor


"""

from xlcalcnet import apm,  mpm , gmp, fpm, ipm, dec

from xlcalcnet.arbclasses import mp2


# %% 34 Testing Arb for speed


class test02():

# %%%  34.1 Arb multiplication


    def demo_ArbMulScalar(self, ctx):
        print("")
        print("Hello DemoArbMulScalar")
        import time

        n = 1
        #n = 100000

        mp2.setdps(15)

        #x1 = arb3_t('2.5')
        x1 = ctx.t('2.5')
        x1 = x1.sqrt()
        print("x1: ", x1)

        #x2 = arb3_t('3')
        x2 = ctx.t('3')
        x2 = x2.sqrt()
        print("x2: ", x2)

        start0a = time.time()

        for i in range(n):
            #x1 /= x2
            #x1 = x1 + x2
            x1 += i
            #x1 = x1 * (i+1)

        end0a = time.time()
        Elapsed0a = end0a - start0a

        print("x1: ", x1)
        print("Elapsed0a: ", Elapsed0a)

        #x1 = arb3_t('inf')
        x1 = ctx.t('inf')
        print("x1: ", -x1)

        #x1 = arb3_t(0)
        x1 = ctx.t(0)
        print("x1: ", 1/x1)


        print(int(x1))
        print(x1.frexp())
        y, n = x1.frexp()
        print("y:", y, "n:", n)
        z = y.ldexp(n)
        print(z)

        print(type(x1))
        #print(isinstance(x1, arb3_t))

        return


    def demo_AcbMulScalar(self, ctx):
        print("")
        print("Hello DemoAcbMulScalar")
        import time

        n = 1
        #n = 100000

        mp2.setdps(15)

        x1 = ctx.t("2+5j")
    #    x1.real = arb3_t('0.381').sqrt()
    #    x1.imag = arb3_t('0.777').sqrt()
        print("x1: ", x1)

        x2 = ctx.t('0')
    #    x2.real = arb3_t('0.785').sqrt()
    #    x2.imag = arb3_t('0.251').sqrt()
    #    print("x2: ", x2)

        #x2 = arb3_t('3')
        x2 = ctx.t('3')
        print("x2: ", x2)
        x2 = x2.sqrt()
        print("x2: ", x2)

        start0a = time.time()

        for i in range(n):
            #x1 /= x2
            #x1 = x1 / x2
            #x1 = x1 + x2
            #x1 = x2 + x1
            #x1 /= i
            #x1 = x1 + i
            x1 = (i+1) * x1

        end0a = time.time()
        Elapsed0a = end0a - start0a

        print("x1: ", x1)

        a1 = abs(x1)
        print("a1: ", a1)

        print("Elapsed0a: ", Elapsed0a)

        print(type(x1))
        #print(isinstance(x1, acb3_t))

        return


    def demo_CplxDec(self, ctx):
        print("")
        print("Hello demo_CplxDec")
        print("demo_power")
        a = ctx.t('2.1')
        b = ctx.t('1.2')
        res = ctx.power(a, b)
        print(res)
        a = ctx.t('2.1+4.3j')
        b = 2
        #b = ctx.t(4.3+2.1j)
        #res = ctx.power(a, b)
        res = a**b
        print("a**b:", res)
        res = b**a
        print("b**a:", res)
        a **= b
        print("a **= b:", a)
        #print(a*a)
        print()




# %%%  Main Run


    # 2.1 Contexts in xlcalcnet: common interface
    def demo_2_1(self, ctx):
        #self.demo_convert(ctx)
        #self.demo_ArbMulScalar(ctx)
        #self.demo_AcbMulScalar(ctx)
        self.demo_CplxDec(ctx)
        print()

    def demo_2(self, ctx):
#        self.demo_2_1(ctx)
        print()


mpm.dps=35
fpm.dps=mpm.dps
gmp.dps=mpm.dps
dec.dps=mpm.dps
ipm.dps=mpm.dps
apm.dps=mpm.dps

print("mpm.dps: ", mpm.dps)
print("apm.dps: ", apm.dps)

ctxm = apm
#ctxm = ipm
#ctxm = fpm
#ctxm = dec
#ctxm = gmp
#ctxm = mpm
test02().demo_2(ctxm)


