# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont


# %% 22 Closed form distributions, based on the incomplete beta function


class ctx_beta(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
        self.set_supportright(1)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_ibeta_derivative(self.a, self.b, x)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_ibeta(self.a, self.b, x)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_ibetac(self.a, self.b, x)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.real_ibeta_inv(self.a, self.b, q)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.real_ibetac_inv(self.a, self.b, q)

    def c_x(self, t):
        ctx = self.ctx
        return ctx.hyp1f1(self.a, self.a+self.b, 1j*t)

    def m_x(self, t):
        ctx = self.ctx
        return ctx.hyp1f1(self.a, self.a+self.b, t)

    def k_x(self, t):
        ctx = self.ctx
        return ctx.ln(self.m_x(t))

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):
        k = int(k)
        return "Todo"


class ctx_logrv_beta(ctx_rv_cont):

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
        z = ctx.exp(-x)
        return z * ctx.beta_pdf(z, self.a, self.b)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = ctx.exp(-x)
        return ctx.beta_cdf(z, self.a, self.b, False)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = ctx.exp(-x)
        return ctx.beta_cdf(z, self.a, self.b, True)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.beta_qtf(q, self.a, self.b, False)
        x = -ctx.log(z)
        return x

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.beta_qtf(q, self.a, self.b, True)
        x = -ctx.log(z)
        return x

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



class ctx_beta_prime(ctx_rv_cont):

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


class ctx_genbeta1(ctx_rv_cont):

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


class ctx_genbeta2(ctx_rv_cont):

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


class ctx_genlogistic(ctx_rv_cont):

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


class ctx_gen_beta_exp(ctx_rv_cont):

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



class ctx_feller_pareto(ctx_rv_cont):

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


class ctx_fisher_f(ctx_rv_cont):

    def __init__(self, ctx, m, n):
        self.set_ctx(ctx)
        self.m = ctx.t(m)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        res = self.m**(self.m/2) * self.n**(self.n/2) * x**((self.m-2)/2) * \
            (self.n+self.m*x)**(-(self.m+self.n)/2)
        res = res / ctx.exp(ctx.ln(ctx.beta(self.m/2, self.n/2)))
        return res

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        v1x = self.m * x
        if (v1x > self.n):
            return ctx.real_ibetac(self.n/2, self.m/2, self.n / (self.n + v1x))
        else:
            return ctx.real_ibeta(self.n/2, self.m/2, self.n / (self.n + v1x))

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        v1x = self.m * x
        if (v1x > self.n):
            return ctx.real_ibeta(self.n/2, self.m/2, self.n / (self.n + v1x))
        else:
            return ctx.real_ibetac(self.n/2, self.m/2, self.n / (self.n + v1x))

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        x = ctx.real_ibeta_inv(self.m/2, self.n/2, q)
        return self.n * x / (self.m * (1-x))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        x = ctx.real_ibetac_inv(self.m/2, self.n/2, q)
        return self.n * x / (self.m * (1-x))

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


class ctx_fisher_z(ctx_rv_cont):

    def __init__(self, ctx, m, n, mode=0):
        self.set_ctx(ctx)
        self.m = ctx.t(m)
        self.n = ctx.t(n)
        self.mode = ctx.t(mode)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        x = x - self.mode
        z = ctx.exp(2*x)
        return 2 * z * ctx.fisher_f_pdf(z, self.m, self.n)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        x = x - self.mode
        z = ctx.exp(2*x)
        return ctx.fisher_f_cdf(z, self.m, self.n)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        x = x - self.mode
        z = ctx.exp(-2*x)
        return ctx.fisher_f_cdf(z, self.n, self.m)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.fisher_f_qtf(q, self.m, self.n)
        x = 0.5 * ctx.log(z) + self.mode
        return x

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.fisher_f_qtf(q, self.n, self.m)
        x = -0.5 * ctx.log(z) + self.mode
        return x

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


class ctx_student_t(ctx_rv_cont):

    def __init__(self, ctx, n):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        half = ctx.convert("0.5")
        C = (1 + (x * x) / (self.n * 1))
        h = ctx.loggamma((self.n + 1) / 2) - ctx.loggamma(self.n / 2)
        h = ctx.exp(h)
        h = h / ctx.sqrt(ctx.pi) / ctx.sqrt(self.n)
        res = h * (C ** (-((self.n / 2) + (half))))
        return res

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        half = ctx.convert("0.5")
        x2 = x * x
        if (self.n > 2 * x2):
            z = x2 / (self.n + x2)
            p = ctx.real_ibetac(half, self.n / 2, z) / 2
        else:
            z = self.n / (self.n + x2)
            p = ctx.real_ibeta(self.n / 2, half, z) / 2
        if (x > 0):
            return 1 - p
        else:
            return p

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        half = ctx.convert("0.5")
        x2 = x * x
        if (self.n > 2 * x2):
            z = x2 / (self.n + x2)
            p = ctx.real_ibetac(half, self.n / 2, z) / 2
        else:
            z = self.n / (self.n + x2)
            p = ctx.real_ibeta(self.n / 2, half, z) / 2
        if (x > 0):
            return p
        else:
            return 1 - p

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.convert("0.5")
        sign = 1
        if q < half:
            sign = -1
        pq = q
        if q > half:
            pq = 1-q
        x = ctx.real_ibeta_inv(self.n / 2, half, 2*pq)
        y = 1 - x
        t = sign * ctx.sqrt(self.n * y/x)
        return t

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        half = ctx.convert("0.5")
        sign = 1
        if q < half:
            sign = -1
        pq = q
        if q > half:
            pq = 1-q
        x = ctx.real_ibeta_inv(self.n / 2, half, 2*pq)
        y = 1 - x
        t = sign * ctx.sqrt(self.n * y/x)
        return -t

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


class ctx_skew_t(ctx_rv_cont):

    def __init__(self, ctx, df_):
        self.set_ctx(ctx)
        self.df = ctx.t(df_)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
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


class ctx_pearson_rho(ctx_rv_cont):

    def __init__(self, ctx, N):
        self.set_ctx(ctx)
        self.a = ctx.t(N)

        self.set_rangeleft(-1)
        self.set_rangeright(1)

        self.set_supportleft(-1)
        self.set_supportright(1)

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








