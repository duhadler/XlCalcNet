# -*- coding: utf-8 -*-
"""
@author: DH
"""


from xlcalcnet.dist_base import ctx_rv_cont



# %% 20 Closed form distributions, based on the error function


class ctx_birnb_saunders(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_emg(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_folded_normal(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_half_normal(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_johnson_sb(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_johnson_su(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_levy(ctx_rv_cont):

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
        s = ctx.sqrt(self.b / (2 * ctx.pi))
        t = ctx.exp(-self.b / (2 * (x - self.a)))
        u = ctx.power(x-self.a, ctx.t("1.5"))
        return s * t / u

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.sqrt(self.b / (2 * (x-self.a)))
        return ctx.real_erfc(s)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.sqrt(self.b / (2 * (x-self.a)))
        return ctx.real_erf(s)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s1 = ctx.real_erfcinv(q)
        s1 = 2 * s1 * s1
        return self.a + self.b / s1

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s1 = ctx.real_erfinv(q)
        s1 = 2 * s1 * s1
        return self.a + self.b / s1

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_lognormal(ctx_rv_cont):

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
        e = ctx.log(x) - self.a
        e *= -e
        e /= 2 * self.b * self.b
        result = ctx.exp(e)
        result /= self.b * ctx.sqrt(2 * ctx.pi) * x
        return result

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        x = ctx.log(x)
        s = self.b * ctx.sqrt(2)
        return ctx.t("0.5") * ctx.real_erfc(-(x - self.a) / s)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        x = ctx.log(x)
        s = self.b * ctx.sqrt(2)
        return ctx.t("0.5") * ctx.real_erfc((x - self.a) / s)


    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s = self.b * ctx.sqrt(2)
        return ctx.exp(self.a - s * ctx.real_erfcinv(2*q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s = self.b * ctx.sqrt(2)
        return ctx.exp(self.a + s * ctx.real_erfcinv(2*q))

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_moyal(ctx_rv_cont):

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
        t1 = (x - self.a) / (2 * self.b)
        t2 = ctx.t("0.5") * ctx.exp(-(x-self.a)/self.b)
        s = self.b * ctx.sqrt(2 * ctx.pi)
        return ctx.exp(-t1 - t2) / s

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.exp(-(x - self.a) / (2 * self.b)) / ctx.sqrt(2)
        return ctx.real_erfc(s)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.exp(-(x - self.a) / (2 * self.b)) / ctx.sqrt(2)
        return ctx.real_erf(s)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s1 = ctx.real_erfcinv(q)
        s1 = 2 * s1 * s1
        return self.a - self.b * ctx.ln(s1)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s1 = ctx.real_erfinv(q)
        s1 = 2 * s1 * s1
        return self.a - self.b * ctx.ln(s1)

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_normal(ctx_rv_cont):

    def __init__(self, ctx, mu, sigma):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.mu = ctx.t(mu)
        self.sigma = ctx.t(sigma)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t = ctx.exp(-(x - self.mu)**2 / (2 * self.sigma**2))
        s = self.sigma * ctx.sqrt(2 * ctx.pi)
        return t / s

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = self.sigma * ctx.sqrt(2)
        return ctx.t("0.5") * ctx.real_erfc(-(x - self.mu) / s)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = self.sigma * ctx.sqrt(2)
        return ctx.t("0.5") * ctx.real_erfc((x - self.mu) / s)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s = self.sigma * ctx.sqrt(2)
        return self.mu - s * ctx.real_erfcinv(2*q)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        s = self.sigma * ctx.sqrt(2)
        return self.mu + s * ctx.real_erfcinv(2*q)

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"



class ctx_normal_max(ctx_rv_cont):

    def __init__(self, ctx, k):
        self.set_ctx(ctx)
        self.k = ctx.t(k)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(-ctx.inf)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res = self.k*(ctx.ndis(x))**(self.k-1) * ctx.ndens(x)
        return res

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res = (ctx.ndis(x))**self.k
        return res

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_normal_maxmod(ctx_rv_cont):

    def __init__(self, ctx, k):
        self.set_ctx(ctx)
        self.k = ctx.t(k)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(-ctx.inf)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res = 2*self.k * (2*ctx.ndis(x)-1)**(self.k-1) * ctx.ndens(x)
        return res

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res = (ctx.ndis(x) - ctx.ndis(-x))**self.k
        return res

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"





class ctx_sasnormal(ctx_rv_cont):

    def __init__(self, ctx, mu, sigma):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.mu = ctx.t(mu)
        self.sigma = ctx.t(sigma)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"





class ctx_skewnormal(ctx_rv_cont):

    def __init__(self, ctx, a, b, c):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)

        self.a = ctx.t(a)
        self.b = ctx.t(b)
        self.c = ctx.t(c)


    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t1 = (2/self.b) * ctx.normal_pdf((x-self.a)/self.b)
        t2 = ctx.normal_cdf(self.c*(x-self.a)/self.b)
        return t1 * t2

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t1a = ctx.normal_cdf((x-self.a)/self.b, 0, 1, True)
        t2 = 2 * ctx.owent((x-self.a)/self.b, self.c)
        return t1a - t2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t1b = ctx.normal_cdf((x-self.a)/self.b, 0, 1, False)
        t2 = 2 * ctx.owent((x-self.a)/self.b, self.c)
        return t1b + t2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"





class ctx_trunc_normal(ctx_rv_cont):

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
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"






class ctx_wald(ctx_rv_cont):

    def __init__(self, ctx, mu, b):
        self.set_ctx(ctx)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.mu = ctx.t(mu)
        self.b = ctx.t(b)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        c = ctx.sqrt(self.b / (2*ctx.pi*x*x*x))
        s = ctx.exp(-(self.b*(x-self.mu)*(x-self.mu))/(2*x*self.mu**2))
        return c * s

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t1 = ctx.sqrt(self.b/x) * (x/self.mu - 1)
        t2 = -ctx.sqrt(self.b/x) * (x/self.mu + 1)
        s1a = ctx.normal_cdf(t1, 0, 1, True)
        s2 = ctx.normal_cdf(t2, 0, 1, True)
        c = ctx.exp(2*self.b/self.mu)
        return s1a + c * s2

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        t1 = ctx.sqrt(self.b/x) * (x/self.mu - 1)
        t2 = -ctx.sqrt(self.b/x) * (x/self.mu + 1)
        s1b = ctx.normal_cdf(t1, 0, 1, False)
        s2 = ctx.normal_cdf(t2, 0, 1, True)
        c = ctx.exp(2*self.b/self.mu)
        return s1b - c * s2

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"








