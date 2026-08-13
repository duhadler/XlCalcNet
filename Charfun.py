# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
from xlcalcnet import mpm
from xlcalcnet.mpmath import mp
#from xlcalcnet.dist_base import ctx_rv_cont


# 7.6.4 Characteristic functions of the logarithm of central Wilks’ Lambda, 𝑈 = log 2𝑊

def cd_WilksLambda(t, p, q, n):
    result = 1
    for k0 in range(p):
        k = k0 + 1
        g1 = mp.gamma((n-k+1)/2 - mp.j*t)
        g2 = mp.gamma((n+q-k+1)/2)
        g3 = mp.gamma((n-k+1)/2)
        g4 = mp.gamma((n+q-k+1)/2 - mp.j*t)
        prod1 = (g1*g2)/(g3*g4)
        #print("k:", k, "prod1:", prod1 )
        result = result * prod1
    return result


def g_WilksLambda(t):
    x = 2.05292648821553
    #x = 1.1810793514607
    p = 4
    q = 7
    n = 20
    phi = cd_WilksLambda(t, p, q-1, n-q)
    z = mp.exp(-t*x*mp.j) * phi
    result = z.imag / t
    return result




def g_WilksLambda_cdf_cos(t):
    x = 2.05292648821553
    #x = 1.1810793514607
    p = 4
    q = 7
    n = 20
    phi = cd_WilksLambda(t, p, q-1, n-q)
    result = mp.cos(t*x) * phi.imag/t
    return result


def g_WilksLambda_cdf_sin(t):
    x = 2.05292648821553
    #x = 1.1810793514607
    p = 4
    q = 7
    n = 20
    phi = cd_WilksLambda(t, p, q-1, n-q)
    result = -mp.sin(t*x) * phi.real/t
    return result


def g_WilksLambda_u2(u):
    t = u/(1-u)
    g = g_WilksLambda(t)
    result = g/((1-u)*(1-u))
    return result


def g_WilksLambda_u(u):
    t = (1-u)/u
    g = g_WilksLambda(t)
    result = g/(u*u)
    return result


# 7.6.5 Characteristic functions of the Logarithm of the product of independent beta variates, 𝑈 = log 2𝑊


def cd_betaproduct(t, p, b, c):
    result = 1
    for k0 in range(p):
        k = k0 + 1
        bk = b[k]
        dk = c[k]  # - b[k]
        #print("bk", bk, "dk", dk)
        g1 = mp.gamma(bk - mp.j*t)
        g2 = mp.gamma(dk)
        g3 = mp.gamma(bk)
        g4 = mp.gamma(dk - mp.j*t)
        prod1 = (g1*g2)/(g3*g4)
        result = result * prod1
    return result


# def g_betaproduct(t):
#    x = 10
#    #x = 1.1810793514607
#    p = 14
#    f1 = 17 - 1
#    n = 200 - 7
#    b = [0]
#    c = [0]
#    for k0 in range (p):
#        i = k0+1
#        b.append((n-i+1)/2)
#        c.append(b[i] + f1/2)
#    phi = cd_betaproduct(t, p, b, c)
#    z = exp(-t*x*j) * phi
##    result = log(abs(z)/t)
#    result = z.imag / t
#    return result


def g_betaproduct_u2(u):
    t = u/(1-u)
    g = g_betaproduct(t)
    result = g/((1-u)*(1-u))
    return result


def g_betaproduct_u(u):
    t = (1-u)/u
    g = g_betaproduct(t)
    result = g/(u*u)
    return result


def g_betaproduct(t):
    x = 6.1810793514607
    p = 4
    f1 = 7 - 1
    n = 250 - 7
    b = [0]
    c = [0]
    for k0 in range(p):
        i = k0+1
        b.append((n-i+1)/2)
        c.append(b[i] + f1/2)
    phi = cd_betaproduct(t, p, b, c)
    z = mp.exp(-t*x*mp.j) * phi
#    result = log(abs(z)/t)
    result = z.imag / t
    return result


def g_betaproduct_imag_cos(t):
    x = 6.1810793514607
    p = 4
    f1 = 7 - 1
    n = 250 - 7
    b = [0]
    c = [0]
    for k0 in range(p):
        i = k0+1
        b.append((n-i+1)/2)
        c.append(b[i] + f1/2)
    phi = cd_betaproduct(t, p, b, c)
    #z = cos(-t*x) * phi
    #z = phi
    #result = z.imag / t
    result = mp.cos(-t*x) * phi.imag/t
    return result


def g_betaproduct_imag_sin(t):
    x = 6.1810793514607
    p = 4
    f1 = 7 - 1
    n = 250 - 7
    b = [0]
    c = [0]
    for k0 in range(p):
        i = k0+1
        b.append((n-i+1)/2)
        c.append(b[i] + f1/2)
    phi = cd_betaproduct(t, p, b, c)
    #z = sin(-t*x) * phi * j
    #z = phi*j
    #result = z.imag / t
    result = mp.sin(-t*x) * phi.real/t
    return result


# 7.6 Characteristic functions of selected distributions

# 7.6.1 Central Chi-square


def cd_chisquared(k, t):
    return (1 - 2*t*mp.j)**(-k/2)


def cd_chisquared_t(t):
    k = 25
    return (1 - 2*t*mp.j)**(-k/2)


def g_chisquared(t):
    k = 25
    x = 15
    phi = cd_chisquared(k, t)
    z = mp.exp(-t*x*mp.j) * phi
    result = z.imag / t
    return result


def g_chisquared_pdf(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    z = mp.exp(-t*x*mp.j) * phi
    result = z.real
    return result


def g_chisquared_pdf_cos(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    z = mp.cos(t*x) * phi.real
    result = z.real
    return result


def g_chisquared_pdf_sin(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    z = mp.sin(t*x) * phi.imag
    result = z.real
    return result


def g_chisquared_imag_cos_old(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    result = mp.cos(-t*x) * phi.imag/t
    return result


def g_chisquared_imag_sin_old(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    result = mp.sin(-t*x) * phi.real/t
    return result


def g_chisquared_imag_cos(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    result = mp.cos(t*x) * phi.imag/t
    return result


def g_chisquared_imag_sin(t):
    k = 5
    x = 10
    phi = cd_chisquared(k, t)
    result = -mp.sin(t*x) * phi.real/t
    return result


def g_chisquared_imag_combined(t):
    result = g_chisquared_imag_cos(t) + g_chisquared_imag_sin(t)
    return result


def g_chisquared_u2(u):
    t = u/(1-u)
    g = g_chisquared(t)
    result = g/((1-u)*(1-u))
    return result


# 7.6.2 Non-central Chi-square


def cd_chisquared_nc(k, t, theta):
    a = (1 - 2*t*mp.j)**(-k/2)
    b = mp.exp((mp.j*t*theta)/(1-2*mp.j*t))
    result = a * b
    return result


def g_chisquared_nc(t):
    k = 1101
    x = 1100
    theta = 50
    phi = cd_chisquared_nc(k, t, theta)
    z = mp.exp(-t*x*mp.j) * phi
    result = z.imag / t
    return result


def g_chisquared_u_nc(u):
    t = (1-u)/u
    g = g_chisquared_nc(t)
    result = g/(u*u)
    return result


# 24.1.1 Hypergeometric function 1𝐹1 for matrix argument (Butler’s approximation)

def hyper_1f1_butler_wood(a, b, x):
    p = len(x)
    y = [0] * p
    prod = 1
    for i in range(p):
        tau = b - x[i]
        y[i] = (2 * a) / (tau + mp.sqrt(tau * tau + 4 * a * x[i]))
        prod = prod * (((y[i] / a) ** a) * (((1 - y[i]) /
                       (b - a)) ** (b - a)) * mp.exp(x[i] * y[i]))
    r11 = 1
    for i in range(p):
        for j in range(i, p):
            r11 = r11 * ((y[i] * y[j] / a) + (1 - y[i]) * (1 - y[j]) / (b - a))
    k = b ** (p * b - p * (p + 1) / 4)
    Result = k * prod / mp.sqrt(r11)
    return Result


def hyper_1f1_matrix_approx(a, b, x):
    #    a = 3
    #    b = 45
    #    x = [32, 24, 13]
    r0 = hyper_1f1_butler_wood(a, b, x)
#    print("r0: ", r0)
    p = len(x)
    x1 = [0]
    prod1 = 1.0
    prod2 = 1.0
    for i in range(p):
        x1[0] = x[i]
        r1 = hyper_1f1_butler_wood(a, b, x1)
#        print("r1: ", r1)
        prod1 = prod1 * r1
        r2 = mp.hyp1f1(a, b, x1[0])
#        print("r2:", r2)
        prod2 = prod2 * r2
#    print("prod1: ", prod1)
#    print("prod2: ", prod2)
    ratio = prod1/prod2
#    print("ratio:", ratio)
    Result = r0/ratio
    return Result


def demo_hypergeometric_1f1_matrix():
    a = 3
    b = 45
    x = [32, 24, 13]
    r0 = hyper_1f1_matrix_approx(a, b, x)
    print("r0:", r0)


# 24.2.1 Hypergeometric function 2𝐹1 for matrix argument (Butler’s approximation)


def hyper_2f1_butler_wood(a, b, c, x):
    p = len(x)
    y = [0] * p
    s = [0] * p
    prod = 1
    for i in range(p):
        tau = x[i] * (b - a) - c
        y[i] = (2 * a) / (mp.sqrt(tau * tau - 4 * a * x[i] * (c - b)) - tau)
        s[i] = x[i] * y[i] * (1 - y[i]) / (1 - x[i] * y[i])
        prod = prod * (((y[i] / a) ** a) * (((1 - y[i]) / (c - a))
                       ** (c - a)) * (1 - x[i] * y[i]) ** (-b))
    r21 = 1
    for i in range(p):
        for j in range(i, p):
            r21 = r21 * ((y[i] * y[j] / a) + (1 - y[i]) * (1 -
                         y[j]) / (c - a) - b * s[i] * s[j] / (a * (c - a)))
    k = c ** (p * c - p * (p + 1) / 4)
    Result = k * prod / mp.sqrt(r21)
    return Result


def hyper_2f1_matrix_approx(a, b, c, x):
    r0 = hyper_2f1_butler_wood(a, b, c, x)
#    print("r0: ", r0)
    p = len(x)
    x1 = [0]
    prod1 = 1.0
    prod2 = 1.0
    for i in range(p):
        x1[0] = x[i]
        r1 = hyper_2f1_butler_wood(a, b, c, x1)
#        print("r1: ", r1)
        prod1 = prod1 * r1
        r2 = mp.hyp2f1(a, b, c, x1[0])
#        print("r2:", r2)
        prod2 = prod2 * r2
#    print("prod1: ", prod1)
#    print("prod2: ", prod2)
    ratio = prod1/prod2
#    print("ratio:", ratio)
    Result = r0/ratio
    return Result


def demo_hypergeometric_2f1_matrix():
    a = 8.0
    b = 2.5
    c = 15.0
    x = [0.9, 0.2, 0.1]
    r0 = hyper_2f1_matrix_approx(a, b, c, x)
    print("r0:", r0)


def g_betaproduct_imag_combined(t):
    result = g_betaproduct_imag_cos(t) + g_betaproduct_imag_sin(t)
    return result


# ************ Begin testing distributions Charfun.py ***********


class mp_dist_tests_charfunc_cdf():

    def __init__(self, rv2, x=5, a=0, b=2):

        cdf_value = rv2.cdf(x)
        print("rv2.cdf(x): ", cdf_value)
##
##        rv2.set_x(x)
##        mp.plot(rv2.gil_pelaez_imag, [a, b], points=200)
##        print

##        rv2.set_x(x)
##        mp.plot(rv2.gil_pelaez_cos, [a, b], points=200)
##        print
##
##
##        mp.plot(g_chisquared_imag_cos, [a, b], points=200)
##        print



        rv2.set_x(x)
        mp.plot(rv2.gil_pelaez_sin, [a, b], points=200)
        print


        mp.plot(g_chisquared_imag_sin, [a, b], points=200)
        print



        rv2.set_x(x)
        I0 = mp.quad(rv2.gil_pelaez_imag, [0, +mp.inf])
        print("Integral: ", I0)
        result0 = 0.5 - I0/mp.pi
        print("result0:", result0)
        print("diff0:", result0 - cdf_value)

        rv2.set_x(x)
        I1 = mp.quadosc(rv2.gil_pelaez_cos, [
                        0, mp.inf], period=1*mp.pi/x)  # half period
        print("I1:", I1)

        rv2.set_x(x)
        I2 = mp.quadosc(rv2.gil_pelaez_sin, [
                        0, mp.inf], period=1*mp.pi/x)  # half period
        print("I2:", I2)

        I3 = I1 + I2
        print("I3:", I3)
        print("Int diff:", I3 - I0)
        result3 = 0.5 - I3/mp.pi
        print("result3:", result3)
        print("diff3:", result3 - cdf_value)



class mp_dist_tests_charfunc_pdf():

    def __init__(self, rv2, x=5, a=0, b=2):

        pdf_value = rv2.pdf(x)
        print("rv2.pdf(x): ", pdf_value)

        mp.plot(g_chisquared_pdf, [a, b], points=200)
        print

        mp.plot(g_chisquared_pdf_cos, [a, b], points=200)
        print

        mp.plot(g_chisquared_pdf_sin, [a, b], points=200)
        print

        I0 = mp.quad(g_chisquared_pdf, [0, +mp.inf])
        result0 = I0/mp.pi
        print("result0:    ", result0)
        print("Integral: ", I0)


        rv2.set_x(x)
        I1 = mp.quadosc(g_chisquared_pdf_cos, [
                        0, mp.inf], period=1*mp.pi/x)  # half period
        print("I1:", I1)

        rv2.set_x(x)
        I2 = mp.quadosc(g_chisquared_pdf_sin, [
                        0, mp.inf], period=1*mp.pi/x)  # half period
        print("I2:", I2)
        I3 = (I1+I2)/mp.pi
        print("I3:", I3)



mp.dps = 20
print()
print ("Hello mpDistributions local ! ")
print()


##a = 0.0
##b = 2
##
##n = mpm.t("5")
##x = mpm.t("10")
##rv2 = mpm.dist_chi2(n)
##
##mp_dist_tests_charfunc_cdf(rv2, x, a, b)
#mp_dist_tests_charfunc_pdf(rv2, x, a, b)


#
#
# mp.dps=20
#
# demo_hypergeometric_1f1_matrix()
#
# demo_hypergeometric_2f1_matrix()
#
#a = 0.1
#b = 1
#
#
#plot(g_chisquared, [a, b], points=200)
#
#plot(g_chisquared_imag_combined, [a, b], points=200)
#
#
#plot(g_chisquared_imag_cos, [a, b], points=200)
#
#
#plot(g_chisquared_imag_sin, [a, b], points=200)
#
#


a = 0
b = 10
x = 2.05292648821553
mp.plot(g_WilksLambda, [a, b], points=200)
mp.plot(g_WilksLambda_cdf_cos, [a, b], points=200)
mp.plot(g_WilksLambda_cdf_sin, [a, b], points=200)


I0 = mp.quad(g_WilksLambda, [0, +mp.inf])
result0 = I0/mp.pi
print("result0:    ", result0)
print("Integral: ", 0.5-result0)

I1 = mp.quadosc(g_WilksLambda_cdf_cos, [ 0, mp.inf], period=1*mp.pi/x)  # half period
print("I1:", I1)
I2 = mp.quadosc(g_WilksLambda_cdf_sin, [ 0, mp.inf], period=1*mp.pi/x)  # half period
print("I2:", I2)
I3 = (I1+I2)/mp.pi
print("I3:", I3)
print("Integral: ", 0.5-I3)




##mp.plot(g_betaproduct_imag_combined, [a, b], points=200)
##mp.plot(g_betaproduct_imag_cos, [a, b], points=200)
##mp.plot(g_betaproduct_imag_sin, [a, b], points=200)

#
#
#I = quad(g_betaproduct_u2, [a, b])
#
#print("I:", I )
#
#
#print("(1/pi) * I:", (1/pi) * I )
#
#
#result=0.5 - (1/pi) * I
#
#print("result:", result )
