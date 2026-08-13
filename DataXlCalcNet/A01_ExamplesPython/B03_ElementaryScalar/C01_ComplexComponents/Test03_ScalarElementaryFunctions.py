# -*- coding: utf-8 -*-

#from xlcalcnet.mpmath import plot


from xlcalcnet import  mpm, ipm, dpm, gpm
ctxall = [mpm, ipm, dpm, gpm]


# 3 Scalar elementary functions


# 3.1 Exponential and related functions
def demo_3_1_exponential(ctx):

    # 3.1.1 Exponential function exp(x)
    def demo_exp(ctx):
        print("demo_exp")
        x1 = ctx.t(2.1)
        res = ctx.exp(x1)
        print(res)
        z1 = ctx.t("2.1+4.3j")
        res = ctx.exp(z1)
        print(res)

##        print("\nExamples from manual:")
##        res = []; x = 300
##        for ctx in ctxall: ctx.dps = 40; res.append(ctx.exp(x));
##        mpm.show(res)
##        print()

        res = []; z = '3+1.57079632679489j'
        for ctx in ctxall:ctx.dps = 20;  res.append(ctx.exp(z));
        mpm.show(res)
        print()

    # 3.1.2 Exponential function expj
    def demo_expj(ctx):
        print("demo_expj")
        x1 = ctx.t(2.1)
        res = ctx.expj(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.expj(z1)
        print(res)
        print()

    # 3.1.3 Exponential function expjpi
    def demo_expjpi(ctx):
        print("demo_expjpi")
        x1 = ctx.t(2.1)
        res = ctx.expjpi(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.expjpi(z1)
        print(res)
        print()

    # 3.1.4 Exponential function with base 10,
    def demo_exp10(ctx):
        print("demo_exp10")
        x1 = ctx.t(2.1)
        res = ctx.exp10(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.exp10(z1)
        print(res)
        print()

    # 3.1.5 Exponential function with base 2,
    def demo_exp2(ctx):
        print("demo_exp2")
        x1 = ctx.t(2.1)
        res = ctx.exp2(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.exp2(z1)
        print(res)
        print()

    # 3.1.6 Auxiliary function exp(z) - 1
    def demo_expm1(ctx):
        print("demo_expm1")
        x1 = ctx.t(2.1)
        res = ctx.expm1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.expm1(z1)
        print(res)
        print()

    # 3.1.7 Auxiliary function 10^x - 1
    def demo_exp10m1(ctx):
        print("demo_exp10m1")
        x1 = ctx.t(2.1)
        res = ctx.exp10m1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.exp10m1(z1)
        print(res)
        print()

    # 3.1.8 Auxiliary function 2^x - 1
    def demo_exp2m1(ctx):
        print("demo_exp2m1")
        x1 = ctx.t(2.1)
        res = ctx.exp2m1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.exp2m1(z1)
        print(res)
        print()

    # 3.1.9 Relative error exponential (exp(x) - 1)/x
    def demo_exprel(ctx):
        print("demo_exprel")
        x1 = ctx.t(2.1)
        res = ctx.exprel(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.exprel(z1)
        print(res)
        print()

    # 3.1.10 Auxiliary function logistic(x) = 1/(1+exp(-x))
    def demo_logistic(ctx):
        print("demo_logistic")
        x1 = ctx.t(2.1)
        res = ctx.logistic(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.logistic(z1)
        print(res)
        print()

    demo_exp(ctx)
    demo_expj(ctx)
    demo_expjpi(ctx)
    demo_exp10(ctx)
    demo_exp2(ctx)
    demo_expm1(ctx)
    demo_exp10m1(ctx)
    demo_exp2m1(ctx)
    demo_exprel(ctx)
    demo_logistic(ctx)
    print()



# 3.2 Logarithms and related functions
def demo_3_2_logarithms(ctx):

    # 3.2.1 Logarithm with base b, log_b(x)
    def demo_logb(ctx):
        print("demo_logb")
        z1 = ctx.t(2.1)
        b = ctx.t(5.2)
        res = ctx.logb(z1, b)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        b = ctx.t(5.2+5.8j)
        res = ctx.logb(z1, b)
        print(res)
        print()

    # 3.2.2 Natural logarithm ln(z)
    def demo_ln(ctx):
        print("demo_ln")
        x1 = ctx.t(2.1)
        res = ctx.ln(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.ln(z1)
        print(res)
        print()

    # 3.2.2 Natural logarithm log(z)
    def demo_log(ctx):
        print("demo_log")
        x1 = ctx.t(2.1)
        res = ctx.log(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log(z1)
        print(res)
        print()

    # 3.2.3 Auxiliary function log(z+1)
    def demo_log1p(ctx):
        print("demo_log1p")
        x1 = ctx.t(2.1)
        res = ctx.log1p(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log1p(z1)
        print(res)
        print()

    # 3.2.4 Logarithm with base 10, log_10(x)
    def demo_log10(ctx):
        print("demo_log10")
        x1 = ctx.t(2.1)
        res = ctx.log10(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log10(z1)
        print(res)
        print()

    # 3.2.5 Logarithm with base 2, log_2(x)
    def demo_log2(ctx):
        print("demo_log2")
        x1 = ctx.t(2.1)
        res = ctx.log2(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log2(z1)
        print(res)
        print()

    # 3.2.6 Auxiliary function log(1 - exp(−|z|))
    def demo_log1mexp(ctx):
        print("demo_log1mexp")
        z1 = ctx.t(2.1+4.3)
        res = ctx.log1mexp(z1)
        print(res)

    # 3.2.7 Auxiliary function log_2(1 + x)
    def demo_log2p1(ctx):
        print("demo_log2p1")
        x1 = ctx.t(2.1)
        res = ctx.log2p1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log2p1(z1)
        print(res)
        print()

    # 3.2.8 Auxiliary function log10(1 + x)
    def demo_log10p1(ctx):
        print("demo_log10p1")
        x1 = ctx.t(2.1)
        res = ctx.log10p1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.log10p1(z1)
        print(res)
        print()

    # 3.2.9 Auxiliary function ln(1 − exp(x))
    def demo_ln1mexp(ctx):
        print("demo_ln1mexp")
        x1 = ctx.t(2.1)
        res = ctx.ln1mexp(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.ln1mexp(z1)
        print(res)
        print()

    # 3.2.10 Auxiliary function ln(1 + exp(x))
    def demo_ln1pexp(ctx):
        print("demo_ln1pexp")
        x1 = ctx.t(2.1)
        res = ctx.ln1pexp(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.ln1pexp(z1)
        print(res)
        print()

    # 3.2.11 Auxiliary function ln(1 + x) − x
    def demo_ln1pmx(ctx):
        print("demo_ln1pmx")
        x1 = ctx.t(2.1)
        res = ctx.ln1pmx(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.ln1pmx(z1)
        print(res)
        print()

    # 3.2.12 Auxiliary function logit(x) = ln(x/(1-x))
    def demo_logit(ctx):
        print("demo_logit")
        x1 = ctx.t(2.1)
        res = ctx.logit(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.logit(z1)
        print(res)
        print()

    # 3.2.13 Lambert W
    def demo_lambertw(ctx):
        print("demo_lambertw")
        z1 = ctx.t(2.1)
        k = int(0)
        res = ctx.lambertw(z1, k)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        k = int(0)
        res = ctx.lambertw(z1, k)
        print(res)
        print()

    # 3.2.14 Arithmetic-geometric mean (AGM)
    def demo_agm(ctx):
        print("demo_agm")
        a = ctx.t(3.1)
        b = ctx.t(2.1)
        res = ctx.agm(a, b)
        print(res)
        a = ctx.t(3.1+4.1j)
        b = ctx.t(2.1+4.3j)
        res = ctx.agm(a, b)
        print(res)
        print()

    demo_logb(ctx)
    demo_ln(ctx)
    demo_log(ctx)
    demo_log1p(ctx)
    demo_log10(ctx)
    demo_log2(ctx)
    demo_log1mexp(ctx)
    demo_log2p1(ctx)
    demo_log10p1(ctx)
    demo_ln1mexp(ctx)
    demo_ln1pexp(ctx)
    demo_ln1pmx(ctx)
    demo_logit(ctx)
    demo_lambertw(ctx)
    demo_agm(ctx)
    print()



# 3.3 Square, roots and power functions
def demo_3_3_square_roots_power(ctx):

    # 3.3.1 Square, x^2
    def demo_square(ctx):
        print("demo_square")
        x1 = ctx.t(2.1)
        res = ctx.square(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.square(z1)
        print(res)
        print()

    # 3.3.2 Square root
    def demo_sqrt(ctx):
        print("demo_sqrt")
        x1 = ctx.t(2.1)
        res = ctx.sqrt(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sqrt(z1)
        print(res)
        print()

    # 3.3.3 Reciprocal of the square root
    def demo_rsqrt(ctx):
        print("demo_rsqrt")
        x1 = ctx.t(2.1)
        res = ctx.rsqrt(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.rsqrt(z1)
        print(res)
        print()

    # 3.3.4 Auxiliary function sqtz(1+z) - 1
    def demo_sqrt1pm1(ctx):
        print("demo_sqrt1pm1")
        x1 = ctx.t(2.1)
        res = ctx.sqrt1pm1(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sqrt1pm1(z1)
        print(res)
        print()

    # 3.3.5 Cube root
    def demo_cbrt(ctx):
        print("demo_cbrt")
        x1 = ctx.t(2.1)
        res = ctx.cbrt(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cbrt(z1)
        print(res)
        print()

    # 3.3.6 Returns the cube root in a way which gives a negative real number
    # for negative input (like surd)
    def demo_cuberoot(ctx):
        print("demo_cuberoot")
        x1 = ctx.t(2.1)
        res = ctx.cuberoot(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cuberoot(z1)
        print(res)
        print()

    # 3.3.7 Nth root,
    def demo_nthroot(ctx):
        print("demo_nthroot")
        n=3
        x1 = ctx.t(2.1)
        res = ctx.nthroot(x1, n)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.nthroot(z1, n)
        print(res)
        print()

    # 3.3.8 Unit roots
    def demo_unitroot(ctx):
        print("demo_unitroot")
        k=3
        n=7
        res = ctx.unitroot(k, n)
        print(res)
        print()

    # 3.3.9 Hypotenuse
    def demo_hypot(ctx):
        print("demo_hypot")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.hypot(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.hypot(a, b)
        print(res)
        print()

    # 3.3.10 Power function
    def demo_power(ctx):
        print("demo_power")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.power(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.power(a, b)
        print(res)
        print()

    # 3.3.10 Power function
    def demo_pow(ctx):
        print("demo_pow")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.pow(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.pow(a, b)
        print(res)
        print()

    # 3.3.11 Auxiliary function a^b - 1
    def demo_powm1(ctx):
        print("demo_powm1")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.powm1(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.powm1(a, b)
        print(res)
        print()

    # 3.3.12 Auxiliary function (1+a)^b
    def demo_pow1p(ctx):
        print("demo_pow1p")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.pow1p(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.pow1p(a, b)
        print(res)
        print()

    # 3.3.13 Auxiliary function (1+a)^b - 1
    def demo_pow1pm1(ctx):
        print("demo_pow1pm1")
        a = ctx.t(2.1)
        b = ctx.t(2.1)
        res = ctx.pow1pm1(a, b)
        print(res)
        a = ctx.t(2.1+4.3j)
        b = ctx.t(2.1+4.3j)
        res = ctx.pow1pm1(a, b)
        print(res)
        print()

    # 3.3.14 Fibonacci numbers
    def demo_fibonacci(ctx):
        print("demo_fibonacci")
        n=3
        res = ctx.fibonacci(n)
        print(res)
        print()

    # 3.3.15 Fibonacci polynomials
    def demo_fibpoly(ctx):
        print("demo_fibpoly")
        n=3
        x1 = ctx.t(2.1)
        res = ctx.fibpoly(n, x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.fibpoly(n, z1)
        print(res)
        print()

    # 3.3.16 Lucas numbers
    def demo_lucas(ctx):
        print("demo_lucas")
        n=3
        res = ctx.lucas(n)
        print(res)
        print()

    # 3.3.17 Lucas polynomials
    def demo_lucaspoly(ctx):
        print("demo_lucaspoly")
        n=3
        x1 = ctx.t(2.1)
        res = ctx.lucaspoly(n, x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.lucaspoly(n, z1)
        print(res)
        print()

    demo_square(ctx)
    demo_sqrt(ctx)
    demo_rsqrt(ctx)
    demo_sqrt1pm1(ctx)
    demo_cbrt(ctx)
    demo_cuberoot(ctx)
    demo_nthroot(ctx)
    demo_unitroot(ctx)
    demo_hypot(ctx)
    demo_power(ctx)
    demo_pow(ctx)
    demo_powm1(ctx)
    demo_pow1p(ctx)
    demo_pow1pm1(ctx)
    demo_fibonacci(ctx)
    demo_fibpoly(ctx)
    demo_lucas(ctx)
    demo_lucaspoly(ctx)
    print()



# 3.4 Trigonometric and related functions
def demo_3_4_trigonometric(ctx):

    # 3.4.1 Radians
    def demo_radians(ctx):
        print("demo_radians")
        x1 = ctx.t(60)
        res = ctx.radians(x1)
        print(res)
        print()

    # 3.4.2 Degrees
    def demo_degrees(ctx):
        print("demo_degrees")
        x1 = ctx.pi/3
        res = ctx.degrees(x1)
        print(res)
        print()

    # 3.4.3 Sine
    def demo_sin(ctx):
        print("demo_sin")
        x1 = ctx.t(2.1)
        res = ctx.sin(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sin(z1)
        print(res)
        print()

    # 3.4.4 Cosine
    def demo_cos(ctx):
        print("demo_cos")
        x1 = ctx.t(2.1)
        res = ctx.cos(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cos(z1)
        print(res)
        print()

    # 3.4.5 Sine and cosine
    def demo_sin_cos(ctx):
        print("demo_sin_cos")
        return

    # 3.4.6 Tangent
    def demo_tan(ctx):
        print("demo_tan")
        x1 = ctx.t(2.1)
        res = ctx.tan(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.tan(z1)
        print(res)
        print()

    # 3.4.7 Secant
    def demo_sec(ctx):
        print("demo_sec")
        x1 = ctx.t(2.1)
        res = ctx.sec(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sec(z1)
        print(res)
        print()

    # 3.4.8 Cosecant
    def demo_csc(ctx):
        print("demo_csc")
        x1 = ctx.t(2.1)
        res = ctx.csc(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.csc(z1)
        print(res)
        print()

    # 3.4.9 Cotangent
    def demo_cot(ctx):
        print("demo_cot")
        x1 = ctx.t(2.1)
        res = ctx.cot(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cot(z1)
        print(res)
        print()

    # 3.4.10 Haversine function hav(x) = (1-cos(x))/2
    def demo_hav(ctx):
        print("demo_hav")
        x1 = ctx.t(2.1)
        res = ctx.hav(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.hav(z1)
        print(res)
        print()

    # 3.4.11 Auxiliary function sinpi, sin(pi*x)
    def demo_sinpi(ctx):
        print("demo_sinpi")
        x1 = ctx.t(2.1)
        res = ctx.sinpi(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sinpi(z1)
        print(res)
        print()

    # 3.4.12 Cardinal sine, sinc(x) = sin(x)/x for x!=0; 1 for x==0
    def demo_sinc(ctx):
        print("demo_sinc")
        x1 = ctx.t(2.1)
        res = ctx.sinc(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sinc(z1)
        print(res)
        print()

    # 3.4.13 Auxiliary function sincpi(x) = sin(pi*x)/(pi*x) for x!=0; 1 for x==0
    def demo_sincpi(ctx):
        print("demo_sincpi")
        x1 = ctx.t(2.1)
        res = ctx.sincpi(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sincpi(z1)
        print(res)
        print()

    # 3.4.14 Auxiliary function cospi = cos(pi*x)
    def demo_cospi(ctx):
        print("demo_cospi")
        x1 = ctx.t(2.1)
        res = ctx.cospi(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cospi(z1)
        print(res)
        print()

    demo_radians(ctx)
    demo_degrees(ctx)
    demo_sin(ctx)
    demo_cos(ctx)
    demo_sin_cos(ctx)
    demo_tan(ctx)
    demo_sec(ctx)
    demo_csc(ctx)
    demo_cot(ctx)
    demo_hav(ctx)
    demo_sinpi(ctx)
    demo_sinc(ctx)
    demo_sincpi(ctx)
    demo_cospi(ctx)
    print()



# 3.5 Hyperbolic functions
def demo_3_5_hyperbolic(ctx):

    # 3.5.1 Hyperbolic Sine
    def demo_sinh(ctx):
        print("demo_sinh")
        x1 = ctx.t(2.1)
        res = ctx.sinh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sinh(z1)
        print(res)
        print()

    # 3.5.2 Hyperbolic Cosine
    def demo_cosh(ctx):
        print("demo_cosh")
        x1 = ctx.t(2.1)
        res = ctx.cosh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.cosh(z1)
        print(res)
        print()

    # 3.5.3 Hyperbolic Tangent
    def demo_tanh(ctx):
        print("demo_tanh")
        x1 = ctx.t(2.1)
        res = ctx.tanh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.tanh(z1)
        print(res)
        print()

    # 3.5.4 Hyperbolic Secant
    def demo_sech(ctx):
        print("demo_sech")
        x1 = ctx.t(2.1)
        res = ctx.sech(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.sech(z1)
        print(res)
        print()

    # 3.5.5 Hyperbolic Cosecant
    def demo_csch(ctx):
        print("demo_csch")
        x1 = ctx.t(2.1)
        res = ctx.csch(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.csch(z1)
        print(res)
        print()

    # 3.5.6 Hyperbolic Cotangent
    def demo_coth(ctx):
        print("demo_coth")
        x1 = ctx.t(2.1)
        res = ctx.coth(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.coth(z1)
        print(res)
        print()

    demo_sinh(ctx)
    demo_cosh(ctx)
    demo_tanh(ctx)
    demo_sech(ctx)
    demo_csch(ctx)
    demo_coth(ctx)
    return

# 3.6 Inverse trigonometric functions
def demo_3_6_inverse_trigonometric(ctx):

    # 3.6.1 Inverse Sine
    def demo_asin(ctx):
        print("demo_asin")
        x1 = ctx.t(2.1)
        res = ctx.asin(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.asin(z1)
        print(res)
        print()

    # 3.6.2 Inverse Cosine
    def demo_acos(ctx):
        print("demo_acos")
        x1 = ctx.t(2.1)
        res = ctx.acos(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acos(z1)
        print(res)
        print()

    # 3.6.3 Inverse Tangent
    def demo_atan(ctx):
        print("demo_atan")
        x1 = ctx.t(2.1)
        res = ctx.atan(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.atan(z1)
        print(res)
        print()

    # 3.6.4 Inverse Tangent, 2 real arguments
    def demo_atan2(ctx):
        print("demo_atan2")
#        z1 = ctx.t(2.1+4.3)
#        res = ctx.atan2(z1)
#        print(res)

    # 3.6.5 Inverse Secant
    def demo_asec(ctx):
        print("demo_asec")
        x1 = ctx.t(2.1)
        res = ctx.asec(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.asec(z1)
        print(res)
        print()

    # 3.6.6 Inverse Cosecant
    def demo_acsc(ctx):
        print("demo_acsc")
        x1 = ctx.t(2.1)
        res = ctx.acsc(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acsc(z1)
        print(res)
        print()

    # 3.6.7 Inverse Cotangent
    def demo_acot(ctx):
        print("demo_acot")
        x1 = ctx.t(2.1)
        res = ctx.acot(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acot(z1)
        print(res)
        print()

    # 3.6.8 Gudermannian function gd(x) = asin(tanh(x))
    def demo_gd(ctx):
        print("demo_gd")
        x1 = ctx.t(2.1)
        res = ctx.gd(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.gd(z1)
        print(res)
        print()

    # 3.6.9 Inverse haversine function archav(z) = acos(1-2z) = 2*asin(sqrt(z))
    def demo_archav(ctx):
        print("demo_archav")
        x1 = ctx.t(2.1)
        res = ctx.archav(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.archav(z1)
        print(res)
        print()

    demo_asin(ctx)
    demo_acos(ctx)
    demo_atan(ctx)
    demo_atan2(ctx)
    demo_asec(ctx)
    demo_acsc(ctx)
    demo_acot(ctx)
    demo_gd(ctx)
    demo_archav(ctx)
    print()



# 3.7 Inverse hyperbolic functions
def demo_3_7_inverse_hyperbolic(ctx):

    # 3.7.1 Inverse Hyperbolic Sine
    def demo_asinh(ctx):
        print("demo_asinh")
        x1 = ctx.t(2.1)
        res = ctx.asinh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.asinh(z1)
        print(res)
        print()

    # 3.7.2 Inverse Hyperbolic Cosine
    def demo_acosh(ctx):
        print("demo_acosh")
        x1 = ctx.t(2.1)
        res = ctx.acosh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acosh(z1)
        print(res)
        print()

# 3.7.3 Inverse Hyperbolic Tangent
    def demo_atanh(ctx):
        print("demo_atanh")
        x1 = ctx.t(2.1)
        res = ctx.atanh(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.atanh(z1)
        print(res)
        print()

    # 3.7.4 Inverse Hyperbolic Secant
    def demo_asech(ctx):
        print("demo_asech")
        x1 = ctx.t(2.1)
        res = ctx.asech(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.asech(z1)
        print(res)
        print()

    # 3.7.5 Inverse Hyperbolic Cosecant
    def demo_acsch(ctx):
        print("demo_acsch")
        x1 = ctx.t(2.1)
        res = ctx.acsch(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acsch(z1)
        print(res)
        print()

    # 3.7.6 Inverse Hyperbolic Cotangent
    def demo_acoth(ctx):
        print("demo_acoth")
        x1 = ctx.t(2.1)
        res = ctx.acoth(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.acoth(z1)
        print(res)
        print()

    # 3.7.7 Inverse Gudermannian function arcgd(x) = atanh(sin(x))
    def demo_arcgd(ctx):
        print("demo_arcgd")
        x1 = ctx.t(2.1)
        res = ctx.arcgd(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.arcgd(z1)
        print(res)
        print()

    demo_asinh(ctx)
    demo_acosh(ctx)
    demo_atanh(ctx)
    demo_asech(ctx)
    demo_acsch(ctx)
    demo_acoth(ctx)
    demo_arcgd(ctx)
    print()



# 3.8 Factorials and related functions
def demo_3_8_factorials(ctx):

    # 3.8.1 Factorial
    def demo_factorial(ctx):
        print("demo_factorial")
        x1 = ctx.t(2.1)
        res = ctx.factorial(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.factorial(z1)
        print(res)
        print()

    # 3.8.2 Binomial coefficient
    def demo_binomial(ctx):
        print("demo_binomial")
        n = ctx.t(2.1)
        k = ctx.t(4.2)
        res = ctx.binomial(n, k)
        print(res)
        n = ctx.t(2.1+4.3j)
        k = ctx.t(4.1+7.3j)
        res = ctx.binomial(n, k)
        print(res)
        print()

    # 3.8.3 Multinomial coefficient
    def demo_multinomial(ctx):
        print("demo_multinomial")
        return

    # 3.8.4 Rising factorial (Pochhammer symbol)
    def demo_rf(ctx):
        print("demo_rf")
        z1 = ctx.t(2.1)
        n = ctx.t(7.1)
        res = ctx.rf(z1, n)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        n = ctx.t(7.1+4.3j)
        res = ctx.rf(z1, n)
        print(res)
        print()

    # 3.8.5 Falling factorial
    def demo_ff(ctx):
        print("demo_ff")
        z1 = ctx.t(2.1)
        n = ctx.t(7.3)
        res = ctx.ff(z1, n)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        #n = ctx.t(7.3+4.3j)
        n = ctx.t(7.3)
        res = ctx.ff(z1, n)
        print(res)
        print()

    # 3.8.6 Double factorial
    def demo_fac2(ctx):
        print("demo_fac2")
        x1 = ctx.t(2.1)
        res = ctx.fac2(x1)
        print(res)
        z1 = ctx.t(12.1+1.3j)
        res = ctx.fac2(z1)
        print(res)
        print()

    demo_factorial(ctx)
    demo_binomial(ctx)
    demo_multinomial(ctx)
    demo_rf(ctx)
    demo_ff(ctx)
    demo_fac2(ctx)
    print()

# 3.9 Gamma function and related functions
def demo_3_9_gamma(ctx):

    # 3.9.1 Gamma function
    def demo_gamma(ctx):
        print("demo_gamma")
        x1 = ctx.t(2.1)
        res = ctx.gamma(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.gamma(z1)
        print(res)
        print()

    # 3.9.2 Reciprocal Gamma function
    def demo_rgamma(ctx):
        print("demo_rgamma")
        x1 = ctx.t(2.1)
        res = ctx.rgamma(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.rgamma(z1)
        print(res)
        print()

    # 3.9.3 Log-Gamma function
    def demo_loggamma(ctx):
        print("demo_loggamma")
        x1 = ctx.t(2.1)
        res = ctx.loggamma(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.loggamma(z1)
        print(res)
        print()

    # 3.9.4 Beta function
    def demo_beta(ctx):
        print("demo_beta")
        a = ctx.t(7.1)
        b = ctx.t(2.1)
        res = ctx.beta(a, b)
        print(res)
        a = ctx.t(7.1+4.3j)
        b = ctx.t(2.1+6.3j)
        res = ctx.beta(a, b)
        print(res)
        print()

    # 3.9.5 Log-Beta function
    def demo_logbeta(ctx):
        print("demo_logbeta")
#        z1 = ctx.t(2.1+4.3)
#        res = ctx.factorial(z1)
#        print(res)

    # 3.9.6 Ratio of gamma functions,
    def demo_gamma_ratio(ctx):
        print("demo_gamma_ratio")
        a = ctx.t(7.1)
        b = ctx.t(2.1)
        res = ctx.gamma_ratio(a, b)
        print(res)
        a = ctx.t(7.1+4.3j)
        b = ctx.t(2.1+6.3j)
        res = ctx.gamma_ratio(a, b)
        print(res)
        print()

    # 3.9.7 Gamma-delta ratio,
    def demo_gamma_delta_ratio(ctx):
        print("demo_gamma_delta_ratio")
        a = ctx.t(7.1)
        b = ctx.t(2.1)
        res = ctx.gamma_delta_ratio(a, b)
        print(res)
        a = ctx.t(7.1+4.3j)
        b = ctx.t(2.1+6.3j)
        res = ctx.gamma_delta_ratio(a, b)
        print(res)
        print()

    # 3.9.8 Catalan function
    def demo_catalan_c(ctx):
        print("demo_catalan")
        x1 = ctx.t(2.1)
        res = ctx.catalan_c(x1)
        print(res)
        z1 = ctx.t(2.1+4.3j)
        res = ctx.catalan_c(z1)
        print(res)
        print()

    demo_gamma(ctx)
    demo_rgamma(ctx)
    demo_loggamma(ctx)
    demo_beta(ctx)
    demo_logbeta(ctx)
    demo_gamma_ratio(ctx)
    demo_gamma_delta_ratio(ctx)
    demo_catalan_c(ctx)
    print()

def demo_3(ctx):
    demo_3_1_exponential(ctx)
    demo_3_2_logarithms(ctx)
    demo_3_3_square_roots_power(ctx)
    demo_3_4_trigonometric(ctx)
    demo_3_5_hyperbolic(ctx)
    demo_3_6_inverse_trigonometric(ctx)
    demo_3_7_inverse_hyperbolic(ctx)
    demo_3_8_factorials(ctx)
    demo_3_9_gamma(ctx)
    print()



mpm.dps=35
#dpm.dps=mpm.dps
#ipm.dps=mpm.dps
#gpm.dps=mpm.dps


print("dps: ", mpm.dps)

#ctxm = ipm
#ctxm = dec
ctxm = mpm
#ctxm = gpm


demo_3(ctxm)



