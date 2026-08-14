# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont


# Distributions related to multiple comparisons of means



def chidens(ctx, x, n):
    x = ctx.convert(x)
    n = ctx.convert(n)
    t1 = n**(n/2) * x**(n-1) * ctx.exp(-n*x*x/2)
    t2 = 2**((n-1)/2) * ctx.gamma(n/2)
    res = t1/t2
    res = res * ctx.sqrt(2)
    return res


# %% Normal maximum distribution, equicorrelated case
# includes negative rho

class ctx_nmax_corr(ctx_rv_cont):

    # print("Ryan 2007: Modern experimental design (ANOM), page 573")
    # print("See also: Nelson 2005, ANOM")
    # print("See also: Jayalath 2021, ANOM")
    # print("See also: Elamir 2016, ANOM")
    # print("See also: Soong 2001, ANOM")
    # print("See also: R Package ANOM 2017")

    def __init__(self, ctx, k, rho):
        self.set_ctx(ctx)
        self.k = int(k)
        self.rho = ctx.t(rho)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            z1 = (x + y * sr)/b
            d = ctx.ndis(z1)
            d = d**(self.k-1)
            res = (self.k/b) * d * ctx.ndens(z1) * ctx.ndens(y)
            return res
        ctx = self.ctx
        x = ctx.t(x)
        sr = ctx.sqrt(self.rho)
        b = ctx.sqrt(1-self.rho)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        return res

    def cdf(self, x):
        def f(y):
            a = y * ctx.sqrt(self.rho)
            b = ctx.sqrt(1-self.rho)
            z1 = (x + a)/b
            d = ctx.ndis(z1)
            d = d**self.k
            d = d * ctx.ndens(y)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        return res

    def negative_rho_cdf(self, x):
        def f(y):
            a = y * ctx.sqrt(self.rho)
            b = ctx.sqrt(1-self.rho)
            z1 = (x - a)/b
            d = ctx.ndis(z1)
            d = d**self.k
            d = d * ctx.ndens(y)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-12, 12])
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





# %% Normal maximum modulus distribution, equicorrelated case
# includes negative rho

class ctx_nmm_corr(ctx_rv_cont):

    # print("Ryan 2007: Modern experimental design (ANOM), page 573")
    # print("See also: Nelson 2005, ANOM")
    # print("See also: Jayalath 2021, ANOM")
    # print("See also: Elamir 2016, ANOM")
    # print("See also: Soong 2001, ANOM")
    # print("See also: R Package ANOM 2017")

    def __init__(self, ctx, k, rho):
        self.set_ctx(ctx)
        self.k = int(k)
        self.rho = ctx.t(rho)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        def f(y):
            a = y * ctx.sqrt(abs(self.rho))
            b = ctx.sqrt(1-self.rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**(self.k-1)
            res = (self.k/b) * d * (ctx.ndens(z1) + ctx.ndens(z2)) \
                * ctx.ndens(y)
            return res
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        return res

    def cdf(self, x):
        def f(y):
            a = y * ctx.sqrt(self.rho)
            b = ctx.sqrt(1-self.rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**self.k
            d = d * ctx.ndens(y)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        return res

    def negative_rho_cdf(self, x):
        def f(y):
            a = y * ctx.sqrt((self.rho))
            b = ctx.sqrt(1-self.rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**self.k
            d = d * ctx.ndens(y)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-26, 26])
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



# %% Normal range distribution


class ctx_normal_range(ctx_rv_cont):

    def __init__(self, ctx, k):
        self.set_ctx(ctx)
        self.k = int(k)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            d1 = ctx.ndis(y)
            d2 = ctx.ndis(y-x)
            d = self.k * (self.k-1) * ((d1-d2)**(self.k-2))
            d = d * ctx.ndens(y)*ctx.ndens(y-x)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        return res

    def cdf(self, x):
        def f(y):
            d1 = ctx.ndis(y)
            d2 = ctx.ndis(y-x)
            d = self.k * ((d1-d2)**(self.k-1))
            d = d * ctx.ndens(y)
            return d
        ctx = self.ctx
        x = ctx.t(x)
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
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




# %% Studentized  maximum distribution


class ctx_smax(ctx_rv_cont):

    def __init__(self, ctx, k, n):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            return nmax.pdf(x*y) * chidens(ctx, y, self.n) * y
        ctx = self.ctx
        x = ctx.t(x)
        nmax = ctx.dist_normal_max(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


    def cdf(self, x):
        def f(y):
            return nmax.cdf(x*y) * chidens(ctx, y, self.n)
        ctx = self.ctx
        x = ctx.t(x)
        nmax = ctx.dist_normal_max(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


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

    def moments(self, k):
        k = int(k)
        return "Todo"



# %% Studentized  maximum modulus distribution


class ctx_smm(ctx_rv_cont):

    def __init__(self, ctx, k, n):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            return nmm.pdf(x*y) * chidens(ctx, y, self.n) * y
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_normal_maxmod(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

    def cdf(self, x):
        def f(y):
            return nmm.cdf(x*y) * chidens(ctx, y, self.n)
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_normal_maxmod(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

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

    def moments(self, k):
        k = int(k)
        return "Todo"




# %% Dunnett’s t-distribution, 1-sided

class ctx_dunnett1_t(ctx_rv_cont):

    def __init__(self, ctx, k, n, rho):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)
        self.rho = ctx.t(rho)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            return nmax.pdf(x*y) * chidens(ctx, y, self.n) * y
        ctx = self.ctx
        x = ctx.t(x)
        nmax = ctx.dist_nmax_corr(self.k, self.rho)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

    def cdf(self, x):
        def f(y):
            return nmax.cdf(x*y) * chidens(ctx, y, self.n)
        ctx = self.ctx
        x = ctx.t(x)
        nmax = ctx.dist_nmax_corr(self.k, self.rho)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

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

    def moments(self, k):
        k = int(k)
        return "Todo"





# %% Dunnett’s t-distribution, 2-sided

class ctx_dunnett2_t(ctx_rv_cont):

    def __init__(self, ctx, k, n, rho):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)
        self.rho = ctx.t(rho)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            return nmm.pdf(x*y) * chidens(ctx, y, self.n) * y
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_nmm_corr(self.k, self.rho)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

    def cdf(self, x):
        def f(y):
            return nmm.cdf(x*y) * chidens(ctx, y, self.n)
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_nmm_corr(self.k, self.rho)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

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

    def moments(self, k):
        k = int(k)
        return "Todo"



# %% Nair's t-distribution

class ctx_nair_t(ctx_rv_cont):

    def __init__(self, ctx, k, n):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
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

    def moments(self, k):
        k = int(k)
        return "Todo"




# %% Halperin's t-distribution (see also Nelson)


class ctx_halperin_t(ctx_rv_cont):

    def __init__(self, ctx, k, n):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
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

    def moments(self, k):
        k = int(k)
        return "Todo"




# %% Studentized range distribution


class ctx_studentized_range(ctx_rv_cont):

    def __init__(self, ctx, k, n):
        self.set_ctx(ctx)
        self.k = int(k)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)


    def pdf(self, x):
        def f(y):
            return nmm.pdf(x*y) * chidens(ctx, y, self.n) * y
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_normal_range(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

    def cdf(self, x):
        def f(y):
            return nmm.cdf(x*y) * chidens(ctx, y, self.n)
        ctx = self.ctx
        x = ctx.t(x)
        nmm = ctx.dist_normal_range(self.k)
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])

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

    def moments(self, k):
        k = int(k)
        return "Todo"






