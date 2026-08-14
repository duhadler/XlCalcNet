# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont



# %% 27 Miscellaneous continuous distributions


class ctx_levy_alpha_stable(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_landau(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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



class ctx_pearson_type_IV(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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





class ctx_meixner(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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






class ctx_voigt_profile(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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





class ctx_wrapped_cauchy(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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





class ctx_wrapped_normal(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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





class ctx_von_mises(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_gen_inv_gaussian(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_harmonic(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_halphen_a(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_halphen_b(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_halphen_ib(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_gen_hyperbolic(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_hyperbolic(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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


class ctx_variance_gamma(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

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
