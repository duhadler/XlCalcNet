# -*- coding: utf-8 -*-
"""
@author: DH
"""

from xlcalcnet.dist_base import ctx_rv_cont


# %% 19 Closed form distributions, based on elementary functions


class ctx_arcsine(ctx_rv_cont):

    def __init__(self, ctx, a=0, b=1):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(a)
        self.set_supportright(b)

        self.a = ctx.t(a)
        self.b = ctx.t(b)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 1 / (ctx.pi * ctx.sqrt((x-self.a)*(self.b-x)))


    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 2 * ctx.asin(ctx.sqrt((x-self.a)/(self.b-self.a))) / ctx.pi


    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 2 * ctx.acos(ctx.sqrt((x-self.a)/(self.b-self.a))) / ctx.pi


    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        t = (ctx.sin(ctx.pi * q / 2))
        return self.a + (self.b-self.a)*t * t


    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        t = (ctx.cos(ctx.pi * q / 2))
        return self.a + (self.b-self.a)*t * t


    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.hyp1f1(0.5, 1.0, t*1j)


    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.hyp1f1(0.5, 1.0, t)


    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.log(self.m_x(t))


    def saddleppoint(self, x):
        return "calc numerically"


    def moments(self, k):
        mu = [0]
        mu[0] = 1
        for i in range(k-1):
            prod = 1
            for j1 in range(i-1):
                prod = prod * (2*j1+1)/(2*j1+2)
            mu.append(prod)
        return mu


    def cumulants(self, k):  # return the first k cumulants
        return "from moments"



class ctx_cauchy(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        pi = ctx.pi
        return 1 / (pi*self.b*(1 + (x - self.a) * (x - self.a) / \
                               (self.b * self.b)))

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.atan2(1, -((x - self.a) / self.b)) / ctx.pi
##        half = ctx.convert("0.5")
##        pi_inv = 1 / ctx.pi
##        t = pi_inv * ctx.atan((x - self.a) / self.b)
##        return half + t


    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.atan2(1, ((x - self.a) / self.b)) / ctx.pi
##        half = ctx.convert("0.5")
##        pi_inv = 1 / ctx.pi
##        t = pi_inv * ctx.atan((x - self.a) / self.b)
##        return half - t

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.convert("0.5")
        if q == half:
            return self.a
        p1 = q
        pi = ctx.pi
        t = self.b / ctx.tan(pi * p1)
        return self.a - t

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.convert("0.5")
        if q == half:
            return self.a
        p1 = q
        pi = ctx.pi
        t = self.b / ctx.tan(pi * p1)
        return self.a + t

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.exp(self.a*t*1j - self.b*ctx.fabs(t))

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return None

    def cumulants(self, k):
        return None


class ctx_dagum(ctx_rv_cont):

    def __init__(self, ctx, a, b, p):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)
        self.p = ctx.t(p)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = self.a*self.p/x
        res2 = (x/self.b)**(self.a*self.p)
        res3 = ((x/self.b)**self.a +1)**(self.p+1)
        return res1 * res2 / res3

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = 1 + (x/self.b)**(-self.a)
        res2 = res1 **(-self.p)
        return res2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = 1 + (x/self.b)**(-self.a)
        res2 = res1 **(-self.p)
        return 1-res2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        res1 = self.b*(q**(-1/self.p)-1)
        res2 = res1 **(-1/self.a)
        return res2

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        q=1-q
        res1 = self.b*(q**(-1/self.p)-1)
        res2 = res1 **(-1/self.a)
        return res2

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_exponential(ctx_rv_cont):

    def __init__(self, ctx, lambda1):
        self.set_ctx(ctx)
        self.lambda1 = ctx.t(lambda1)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return self.lambda1 * ctx.exp(-self.lambda1 * x)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return -ctx.expm1(-x * self.lambda1)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.exp(-x * self.lambda1)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return -ctx.log1p(-q) / self.lambda1

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return -ctx.log(q) / self.lambda1

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return self.lambda1 / (self.lambda1 - t*1j)

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return self.lambda1 / (self.lambda1 - t)

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.log(self.m_x(t))

    def saddleppoint(self, x):
        return "todo"

    def moments(self, t):
        return "todo"

    def cumulants(self, k):  # return the first k cumulants
        return "from moments"


class ctx_fisk(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = (self.b/self.a)*(x/self.a)**(self.b-1)
        res2 = (1+(x/self.a)**self.b)**2
        res3 = res1/res2
        return res3

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        xb = x**self.b
        ab = self.a**self.b
        res3 = xb/(ab+xb)
        return res3

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        xb = x**self.b
        ab = self.a**self.b
        res3 = xb/(ab+xb)
        return 1-res3

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        res1 = self.a*(q/(1-q))
        res2 = res1**(1/self.b)
        return res2

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        q=1-q
        res1 = self.a*(q/(1-q))
        res2 = res1**(1/self.b)
        return res2

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "todo"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "todo"

    def cumulants(self, k):
        return "todo"


class ctx_frechet(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = self.b * self.a**self.b * x**(-(self.b+1))
        res2 = ctx.exp(-(self.a/x)**self.b)
        res3 = res1*res2
        return res3

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res2 = ctx.exp(-(self.a/x)**self.b)
        return res2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res2 = ctx.exp(-(self.a/x)**self.b)
        return 1-res2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        res2 = (-ctx.ln(q))**(-1/self.a)
        return res2

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        q=1-q
        res2 = (-ctx.ln(q))**(-1/self.a)
        return res2

    def c_x(self, t):
        return "Todo"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):  # return the first k cumulants
        return "Todo"




class ctx_gev(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        return "Todo"

    def cdf(self, x):
        return "Todo"

    def sf(self, x):
        return "Todo"

    def qtf(self, prob):
        return "Todo"

    def isf(self, prob):
        return "Todo"

    def c_x(self, t):
        return "Todo"

    def m_x(self, t):
        return "Todo"

    def k_x(self, t):
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):  # return the first k cumulants
        return "Todo"







class ctx_genpareto(ctx_rv_cont):

    def __init__(self, ctx, m, s, c):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.m = ctx.t(m)
        self.s = ctx.t(s)
        self.c = ctx.t(c)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = (x-self.m)/self.s
        if self.c== 0: return ctx.exp(-z)
        res1 = (1+self.c*z)**(-(self.c+1)/self.c)
        return res1

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = (x-self.m)/self.s
        if self.c== 0: return 1-ctx.exp(-z)
        res1 = 1-(1+self.c*z)**(-1/self.c)
        return res1

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = (x-self.m)/self.s
        if self.c== 0: return ctx.exp(-z)
        res1 = (1+self.c*z)**(-1/self.c)
        return res1

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if self.c== 0: return self.m - self.s*ctx.log(1-q)
        res1 = self.m + self.s * ((1-q)**(-self.c)-1)/self.c
        return res1

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if self.c== 0: return self.m - self.s*ctx.log(q)
        res1 = self.m + self.s * (q**(-self.c)-1)/self.c
        return res1


    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None





class ctx_gompertz(ctx_rv_cont):

    def __init__(self, ctx, a, b, l):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)
        self.l = ctx.t(l)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return (self.a * ctx.exp(self.b*x) + self.l) * \
            ctx.exp(-self.l*x-(self.a/self.b)*(ctx.expm1(self.b*x)))

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return -ctx.expm1(-self.l*x-(self.a/self.b) *  \
                               (ctx.expm1(self.b*x)))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.exp(-self.l*x-(self.a/self.b) *   \
                            (ctx.expm1(self.b*x)))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if self.l == 0:
            return (1/self.b) * ctx.log1p(-(self.b/self.a) *   \
                                               ctx.log1p(-q))
        else:
            res1 = self.a/(self.b*self.l) - ctx.log1p(-q)/self.l
            res2 = (self.a/self.l) * ctx.exp(self.a/self.l) * \
            ctx.pow1p(-q, -self.b/self.l)
            return  res1 - (1/self.b) * ctx.lambertw(res2)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if self.l == 0:
            return  (1/self.b) * ctx.log1p(-(self.b/self.a) *  \
                                                ctx.ln(q))
        else:
            res1 = self.a/(self.b*self.l) - ctx.ln(q)/self.l
            res2 = (self.a/self.l) * ctx.exp(self.a/self.l) *  \
            ctx.pow(q, - self.b/self.l)
            return  res1 - (1/self.b) * ctx.lambertw(res2)


    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None




class ctx_gumbel(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        c = ctx.exp(-(x - self.a) / self.b)
        return c * ctx.exp(-c) / self.b

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        c = ctx.exp(-(x - self.a) / self.b)
        return ctx.exp(-c)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        c = ctx.exp(-(x - self.a) / self.b)
        return -ctx.expm1(-c)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.a - ctx.log(-ctx.log(q)) * self.b

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.a - ctx.log(-ctx.log1p(-q)) * self.b

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_hyperexponential(ctx_rv_cont):

    def __init__(self, ctx, k, w, l):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        k = int(k)
        for i in range(k):
            w[i] = ctx.t(w[i])
            l[i] = ctx.t(l[i])

        self.w = w
        self.l = l
        self.k = int(k)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        wsum = 0
        for i in range(self.k):
            wsum  += self.w[i]
        for i in range(self.k):
            self.w[i] /= wsum
        res1 = 0
        for i in range(self.k):
            res1 += self.w[i] * self.l[i] * ctx.exp(-self.l[i]*x)
        return res1


    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        wsum = 0
        for i in range(self.k):
            wsum  += self.w[i]
        for i in range(self.k):
            self.w[i] /= wsum
        cdf_ = 0
        for i in range(self.k):
            cdf_ += self.w[i] * ctx.expm1(-self.l[i]*x)
        cdf_ = -cdf_
        return cdf_

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        wsum = 0
        for i in range(self.k):
            wsum  += self.w[i]
        for i in range(self.k):
            self.w[i] /= wsum
        sf_ = 0
        for i in range(self.k):
            sf_  += self.w[i] * ctx.exp(-self.l[i]*x)
        return sf_


    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        wl = 0
        for i in range(self.k):
            wl += self.w[i] / self.l[i]
        #print("wl:", wl, 1/wl)
        qtf_ = -ctx.log1p(-q) * wl
        #print("qtf:", qtf_)
        return qtf_

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        wl = 0
        for i in range(self.k):
            wl += self.w[i] / self.l[i]
        #print("wl:", wl, 1/wl)
        isf_ = -ctx.log(q) * wl
        #print("isf:", isf_)
        return isf_


    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_kumaraswamy(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
        self.set_supportright(1)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        r = ctx.powm1(x, self.a)
        t = ctx.power(-r, self.b-1)
        s = ctx.power(x, self.a-1)
        return self.a*self.b*s*t

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t = ctx.powm1(x, self.a)
        return -ctx.powm1(-t, self.b)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t = ctx.powm1(x, self.a)
        return ctx.power(-t, self.b)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        t = ctx.pow1pm1(-q, 1/self.b)
        return ctx.power(-t, 1/self.a)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        t = ctx.powm1(q, 1/self.b)
        return ctx.power(-t, 1/self.a)

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_laplace(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.convert(x)
        e = x - self.a
        if (e > 0):
            e = -e
        e /= self.b
        result = ctx.exp(e)
        result /= (2 * self.b)
        return result

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.convert(x)
        if (x <= self.a):
            return ctx.exp((x - self.a) / self.b) / 2
        else:
            return 1 - ctx.exp((self.a - x) / self.b) / 2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.convert(x)
        if (-x < -self.a):
            return ctx.exp((-x + self.a) / self.b) / 2
        else:
            return 1 - ctx.exp((-self.a + x) / self.b) / 2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.t("0.5")
        if q <= half:
            return self.a + self.b * ctx.log((2 * q))
        else:
            return self.a - self.b * ctx.log((2 - 2 * q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.t("0.5")
        if q <= half:
            return self.a - self.b * ctx.log((2 * q))
        else:
            return self.a + self.b * ctx.log((2 - 2 * q))

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_logistic(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        c = ctx.exp(-(x - self.a) / self.b)
        return c / (self.b * (1 + c) ** 2)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 1 / (1 + ctx.exp(-(x - self.a) / self.b))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 1 / (1 + ctx.exp((x - self.a) / self.b))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.a + self.b * ctx.log(q / (1-q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.a - self.b * ctx.log(q / (1-q))

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_lomax(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = (self.a/self.b)
        res2 = (1+(x/self.b))**(-(self.a+1))
        res3 = res1*res2
        return res3

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 1-(1+(x/self.b))**(-self.a)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return (1+(x/self.b))**(-self.a)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ( (1-q)**(-1/self.a) -1 )

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ( (q)**(-1/self.a) -1 )

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_pareto(ctx_rv_cont):

    def __init__(self, ctx, k, a):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.k = ctx.t(k)
        self.a = ctx.t(a)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if (x < self.k): return ctx.t(0)
        else: return self.a * ctx.power(self.k, self.a) / \
                ctx.power(x, self.a + 1)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if (x < self.k): return ctx.t(0)
        else: return -ctx.powm1(self.k/x, self.a)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if (x < self.k): return ctx.t(1)
        else: return ctx.pow(self.k/x, self.a)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.k / ((1 - q) ** (1 / self.a))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.k / (q ** (1 / self.a))

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_rayleigh(ctx_rv_cont):

    def __init__(self, ctx, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s2 = self.b * self.b
        return x * (ctx.exp(-(x * x) / (2 * s2))) / s2

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return -ctx.expm1(-x * x / (2 * self.b * self.b))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.exp(-(x * x) / (2 * self.b * self.b))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.sqrt(-2 * ctx.log1p(-q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.sqrt(-2 * ctx.log(q))

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None



class ctx_shifted_gompertz(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = self.b *ctx.exp(-(self.b*x+self.a*ctx.exp(-self.b*x)))
        res2 = (1+self.a*(1-ctx.exp(-self.b*x)))
        return res1 * res2

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = (1-ctx.exp(-self.b*x))
        res2 = ctx.exp(self.a*ctx.exp(-self.b*x))
        return res1 * res2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = (1-ctx.exp(-self.b*x))
        res2 = ctx.exp(self.a*ctx.exp(-self.b*x))
        return 1 - res1 * res2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        res1 = ctx.lambertw(self.a*ctx.exp(self.a)*q) / self.a
        res2 = (1/self.b) * ctx.log(1-res1)
        return -res2

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        q = 1 - q
        res1 = ctx.lambertw(self.a*ctx.exp(self.a)*q) / self.a
        res2 = (1/self.b) * ctx.log(1-res1)
        return -res2

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None







class ctx_singh_maddala(ctx_rv_cont):

    def __init__(self, ctx, a, b, d):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)
        self.d = ctx.t(d)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res1 = self.a*self.d*x**(self.a-1)
        res2 = 1+(x/self.b)**self.a
        res3 = self.b**self.a * res2**(1+self.d)
        res4 = res1/res3
        return res4

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res2 = (1+(x/self.b)**self.a)**(-self.d)
        return 1-res2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res2 = (1+(x/self.b)**self.a)**(-self.d)
        return res2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        res1 = (1-q)**(-1/self.d) - 1
        res2 = self.b * res1**(1/self.a)
        return res2

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        q = 1 - q
        res1 = (1-q)**(-1/self.d) - 1
        res2 = self.b * res1**(1/self.a)
        return res2

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None






class ctx_triangular(ctx_rv_cont):

    def __init__(self, ctx, a, b, c):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)
        self.c = ctx.t(c)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if x<self.a: return ctx.zero
        if x>self.b: return ctx.zero
        if x==self.c: return 2/(self.b-self.a)
        if (self.a<=x) and (x<self.c):
            return 2*(x-self.a) / ((self.b-self.a) * (self.c-self.a))
        if (self.c<x) and (x<=self.b):
            return 2*(self.b-x)/((self.b-self.a)*(self.b-self.c))

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if x<self.a: return ctx.zero
        if x>self.b: return ctx.one
        if (self.a<=x) and (x<=self.c):
            return (x-self.a)*(x-self.a)/((self.b-self.a)*(self.c-self.a))
        if (self.c<x) and (x<=self.b):
            return 1-(self.b-x)*(self.b-x)/((self.b-self.a)*(self.b-self.c))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if x<self.a: return ctx.one
        if x>self.b: return ctx.zero
        if (self.a<=x) and (x<=self.c):
            return 1-(x-self.a)*(x-self.a)/((self.b-self.a)*(self.c-self.a))
        if (self.c<x) and (x<=self.b):
            return (self.b-x)*(self.b-x)/((self.b-self.a)*(self.b-self.c))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        y = q
        if y<(self.c-self.a)/(self.b-self.a):
            return self.a + ctx.sqrt((self.b-self.a)*(self.c-self.a)*y)
        if y==(self.c-self.a)/(self.b-self.a):
            return self.c
        if y>(self.c-self.a)/(self.b-self.a):
            return self.b-ctx.sqrt((self.b-self.a)*(self.b-self.c)*(1-y))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        y = q
        y=1-y
        if y<(self.c-self.a)/(self.b-self.a):
            return self.a + ctx.sqrt((self.b-self.a)*(self.c-self.a)*y)
        if y==(self.c-self.a)/(self.b-self.a):
            return self.c
        if y>(self.c-self.a)/(self.b-self.a):
            return self.b-ctx.sqrt((self.b-self.a)*(self.b-self.c)*(1-y))

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None




class ctx_uniform(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(a)
        self.set_supportright(b)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if ((x < self.a) or (x > self.b)):
            return ctx.t(0)
        else:
            return 1 / (self.b - self.a)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if ((x < self.a) or (x > self.b)):
            if (x < self.a):
                cdf1 = ctx.t(0)
            else:
                cdf1 = ctx.t(1)
        else:
            cdf1 = (x - self.a) / (self.b - self.a)
        return cdf1

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        if ((x < self.a) or (x > self.b)):
            if (x < self.a):
                cdf2 = ctx.t(1)
            else:
                cdf2 = ctx.t(0)
        else:
            cdf2 = (self.b - x) / (self.b - self.a)
        return cdf2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if ((q == ctx.t(0)) or (q == ctx.t(1))):
            if (q == ctx.t(0)):
                icdf1 = self.a
            else:
                icdf1 = self.b
        else:
            icdf1 = q * (self.b - self.a) + self.a
        return icdf1

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        if ((q == ctx.t(0)) or (q == ctx.t(1))):
            if (q == ctx.t(0)):
                icdf2 = self.b
            else:
                icdf2 = self.a
        else:
            icdf2 = -(1 - q) * (self.b - self.a) + self.b
        return icdf2

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None


class ctx_weibull(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(a)
        self.set_supportright(b)

        self.a = ctx.t(a)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        result = ctx.exp(-ctx.power(x / self.b, self.a))
        result *= ctx.power(x / self.b, self.a - 1) * self.a / self.b
        return result

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return -ctx.expm1(-ctx.power(x / self.b, self.a))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.exp(-ctx.power(x / self.b, self.a))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.power(-ctx.log1p(-q), 1 / self.a)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.power(-ctx.log(q), 1 / self.a)

    def c_x(self, t):
        return "evaluate via pdf"

    def m_x(self, t):
        return None

    def k_x(self, t):
        return None

    def saddleppoint(self, x):
        return None

    def moments(self, t):
        return "Todo"

    def cumulants(self, k):
        return None






