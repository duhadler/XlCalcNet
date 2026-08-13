# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont


# %% 21 Closed form distributions, based on the incomplete gamma function


class ctx_amoroso(ctx_rv_cont):

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



class ctx_chi(ctx_rv_cont):

    def __init__(self, ctx, nu):
        self.set_ctx(ctx)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

        self.nu = ctx.t(nu)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 2*x*ctx.chi2_pdf(x*x, self.nu)

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.chi2_cdf(x*x, self.nu, True)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.chi2_cdf(x*x, self.nu, False)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.sqrt(ctx.chi2_qtf(q, self.nu, True))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.sqrt(ctx.chi2_qtf(q, self.nu, False))

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


#  Central 𝜒2 distribution, cdf (integer degrees of freedom)

def chi2_cohen_cdf(self, ctx, x, nu):
    # Algorithm by Cohen
    k = int(nu) % 2
    nu = ctx.t(nu)
    x = ctx.t(x)
    c = -ctx.exp(-x / 2)
    f = ctx.t(1)
    if k != 0:
        c = c * ctx.sqrt(2 * x / ctx.pi)  # c=ndens(x)
        f = 1 - 2 * ctx.ndis(-ctx.sqrt(x))
    k = k + 2
    i = k
    while i <= nu:
        f = f + c
        c = c * x / i
        i = i + 2
    return f


class ctx_chi2(ctx_rv_cont):
    r"""
    The **ctx_chisquare** class implements a central chi-square distribution with
    **df** degrees of freedom.

    **References**

    1. Wikipedia contributors. *Chi-squared distribution. Wikipedia, the free encyclopedia*.
       https://en.wikipedia.org/wiki/Chi-squared_distribution
    """

    def __init__(self, ctx, nu):
        self.set_ctx(ctx)
        self.nu = ctx.t(nu)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        b = self.nu/2
        m = x/2
        if (m <= 0): return ctx.t(0)
        else: return ctx.exp(ctx.ln(m) * (b-1) - \
                     ctx.loggamma(b)-m)/2

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        b = self.nu/2
        m = x/2
        return ctx.real_gamma_p(b, m)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        b = self.nu/2
        m = x/2
        return ctx.real_gamma_q(b, m)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        b = self.nu/2
        return 2*ctx.real_gamma_p_inv(b, q)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        b = self.nu/2
        return 2*ctx.real_gamma_q_inv(b, q)

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return (1 - 2j*t)**(-self.nu/2)

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return (1 - 2*t)**(-self.nu/2)

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return -self.nu/2 * ctx.log(1-2*t)

    def saddleppoint(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return 1 - self.nu/x

    def moments(self, k):
        return "Todo"

    def cumulants(self, k):
        return "Todo"




class ctx_logrv_chi2(ctx_rv_cont):

    def __init__(self, ctx, n):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(-ctx.inf)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(-ctx.inf)
        self.set_supportright(-ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        k = 1.0
        z = ctx.exp(k*x)
        t = k*z * ctx.chi2_pdf(z, self.n)
        return t

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = ctx.exp(x)
        t = ctx.chi2_cdf(z, self.n)
        return t

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        z = ctx.exp(x)
        t = ctx.chi2_cdf(z, self.n, False)
        return t

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.chi2_qtf(q, self.n)
        x = ctx.log(z)
        return x

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        z = ctx.chi2_qtf(q, self.n, False)
        x = ctx.log(z)
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



class ctx_gamma(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.exp(-x/self.b) * ctx.power(x, self.a-1)
        t = ctx.gamma(self.a) * ctx.power(self.b, self.a)
        return s / t

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_p(self.a, x/self.b)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_q(self.a, x/self.b)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.real_gamma_p_inv(self.a, q)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b * ctx.real_gamma_q_inv(self.a, q)

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




class ctx_hypoexp(ctx_rv_cont):

    def __init__(self, ctx, n, l):
        self.set_ctx(ctx)
        self.n = int(n)
        self.l = ctx.t(l)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        l = [2,2,2,2]
        AllDistinct=False
        AllEqual=True
        if AllEqual: return l[0]**self.n * x**(self.n-1) * \
            ctx.exp(-l[0]*x)/ctx.factorial(self.n-1)
        if AllDistinct:
            p = [1, 1, 1, 1]
            for i in range(self.n):
                for j in range(self.n):
                    if i!= j:
                        p[i] = p[i] * (1-l[i]/l[j])
            res1 = 0
            for i in range(self.n):
                res1 += l[i] * ctx.exp(-l[i]*x) / p[i]
            return res1

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        l = [2,2,2,2]
        AllDistinct=False
        AllEqual=True
        if AllEqual:
            cdf = ctx.gamma_p(self.n, l[0]*x)
            print("cdf:", cdf)
            sf = ctx.gamma_q(self.n, l[0]*x)
            print(" sf:", sf)
        if AllDistinct:
            p = [1, 1, 1, 1]
            for i in range(self.n):
                for j in range(self.n):
                    if i!= j:
                        p[i] = p[i] * (1-l[i]/l[j])
            res = 0
            for i in range(self.n):
                res += ctx.exp(-l[i]*x) / p[i]
            # if cdf: return 1-res
            # else: return res
            return 1-res
        return None

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





class ctx_invchi2(ctx_rv_cont):

    def __init__(self, ctx, df_):
        self.set_ctx(ctx)
        self.df = ctx.t(df_)

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



class ctx_invgamma(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.exp(-self.b/x) * ctx.power(self.b/x, self.a)
        t = x * ctx.gamma(self.a)
        return s / t

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_q(self.a, self.b/x)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_p(self.a, self.b/x)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b / ctx.real_gamma_q_inv(self.a, q)

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return self.b / ctx.real_gamma_p_inv(self.a, q)

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


class ctx_maxwell(ctx_rv_cont):

    def __init__(self, ctx, b):
        self.set_ctx(ctx)
        self.b = ctx.t(b)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.sqrt(2 / ctx.pi)
        t = (x*x) / (self.b*self.b*self.b)
        u = ctx.exp(-(x*x)/(2*self.b*self.b))
        return s * t * u

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        n = ctx.convert("1.5")
        t = (x*x)/(2*self.b*self.b)
        return ctx.real_gamma_p(n, t)

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        n = ctx.convert("1.5")
        t = (x*x)/(2*self.b*self.b)
        return ctx.real_gamma_q(n, t)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        n = ctx.convert("1.5")
        return self.b * ctx.sqrt(2*ctx.real_gamma_p_inv(n, q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        n = ctx.convert("1.5")
        return self.b * ctx.sqrt(2*ctx.real_gamma_q_inv(n, q))

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


class ctx_lindley(ctx_rv_cont):

    def __init__(self, ctx, m, w):
        self.set_ctx(ctx)
        self.m = ctx.t(m)
        self.w = ctx.t(w)

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


class ctx_nakagami(ctx_rv_cont):

    def __init__(self, ctx, m, w):
        self.set_ctx(ctx)
        self.m = ctx.t(m)
        self.w = ctx.t(w)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        s = ctx.exp(-self.m*x*x/self.w) * \
            2 * ctx.power(self.m, self.m) * ctx.power(x, 2*self.m-1)
        t = ctx.gamma(self.m) * ctx.power(self.w, self.m)
        return s / t

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_p(self.m, self.m*x*x/self.w)

    def sf(self, x):
        ctx = self.ctx
        ctx = self.ctx
        x = ctx.t(x)
        return ctx.real_gamma_q(self.m, self.m*x*x/self.w)

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.sqrt((self.w/self.m) * \
               ctx.real_gamma_p_inv(self.m, q))

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return ctx.sqrt((self.w/self.m) * \
               ctx.real_gamma_q_inv(self.m, q))

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


class ctx_skew_exp_power(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

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


class ctx_stacy(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.a = ctx.t(a)
        self.b = ctx.t(b)

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






