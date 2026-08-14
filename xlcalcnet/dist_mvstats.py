# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont


# Distribution functions related to multivariate statistical analysis



# %% Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix


class ctx_lrt_s0(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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




# %% Distribution of the modified likelihood ratio test (LRT) for a given
    # covariance matrix and mean


class ctx_lrt_x0_s0(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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







# %% Beta-product Distribution


class ctx_betaproduct(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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




# %% Log of Beta-product Distribution


class ctx_logrv_betaproduct(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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




# %% Bartlett Distribution




class ctx_bartlett(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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






# %% Wilks' ip-distribution



class ctx_wilks_ip(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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





# %% Mauchley distribution




class ctx_mauchley(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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






# %% Wilks' cs-distribution



class ctx_wilks_cs(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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





# %% Wilks' iblocks-distribution


class ctx_wilks_iblocks(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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




# %% Box' nsame_cov-distribution


class ctx_box_nsame_cov(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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





# %% Box' nsame_cov_means-distribution



class ctx_box_nsame_means_cov(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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









# %% Distribution of Box’s test of equality of k covariance matrices,
    # unequal sample sizes


class ctx_box_cov(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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




# %% Distribution of Box’s test for same multivariate normal distributions,
    # unequal sample sizes


class ctx_box_mvn(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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








# %% Distribution of Roy's theta



class ctx_roy(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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



# Roy’s largest root distribution, pdf, cdf and sf



def roy_pdf_cdf_sf(self, ctx, x, p, n1, n2):
    pdf_factor = ctx.t(0)
    m = 0.5 * (ctx.fabs(n1 - p) - 1)
    n = 0.5 * (ctx.fabs(n2 - p) - 1)
    C = self.Roy_Const(ctx, p, m, n)
    SqrtDet, pdf_factor = self.Roy_Chiani(ctx, x, p, m, n)
    print("pdf_factor: {0}", pdf_factor)
    pdf = C * SqrtDet * pdf_factor
    print("pdf: {0}", pdf)
    return C * SqrtDet

#    'Chiani 2017, Algorithm 1

def Roy_A(self, ctx, x, s, m, n):
    d = s + (s % 2)
    k = n + 1
    b = ctx.matrix(s, 1)
    t = ctx.matrix(s, 1)
    A = ctx.matrix(d, d)
    m2 = int(2 * m)
    xinv = 1 / x
    b1 = k
    z = (1 - x) ** b1
    xa1 = z * x ** (m + s)
    t[s - 1] = ctx.real_beta3(m + s, b1, x)
    for i in range(s-2, -1, -1):
        a1 = m + i + 1
        xa1 = xa1 * xinv
        t[i] = ((a1 + b1) * t[i + 1] + xa1) / a1
        if (s != d):
            A[i, s] = t[i]
            A[s, i] = -A[i, s]
    if (s != 1):
        amin = m2 + 2
        amax = m2 + 2 * (s - 1)
        t4 = ctx.matrix(amax - amin + 1, 1)
        b1 = 2 * k
        z = (1 - x) ** b1
        xa1 = z * x ** (amax)
        t4[amax - amin] = ctx.real_beta3(amax, b1, x)
        for a1 in range(amax-1, amin-1, -1):
            xa1 = xa1 * xinv
            t4[a1 - amin] = ((a1 + b1) * t4[a1 + 1 - amin] + xa1) / a1
        for i in range(0, s-1+1):
            b[i] = 0.5 * t[i] * t[i]
            for j in range(i+1, s-1+1):
                a1 = m2 + i + j + 1
                t6 = t4[a1 - amin]
                b[j] = ((m + j) * b[j - 1] - t6) / (m + j + k)
                A[i, j] = t[i] * t[j] - 2 * b[j]
                A[j, i] = -A[i, j]
    return A

# 'Chiani 2017, Algorithm 1

def Roy_Chiani(self, ctx, x, s, m, n):
    A = self.Roy_A(ctx, x, s, m, n)
    print("start det")
    det = ctx.det(A)
    pdf_factor = 1
    print("mat_fullPivLu2 det: {0}, Log(Det): {1}", det, ctx.log(det))
    sqrtdet = ctx.sqrt(det)
    print("sqrtdet: {0}", sqrtdet)
    return sqrtdet, pdf_factor

def Roy_Const(self, ctx, s, m, n):
    C1 = ctx.t(0)
    for i in range(1, s+1):
        C1 += ctx.loggamma(0.5 * (i + 2 * m + 2 * n + s + 2)) \
            - ctx.loggamma(0.5 * i) \
            - ctx.loggamma(0.5 * (i + 2 * m + 1)) \
            - ctx.loggamma(0.5 * (i + 2 * n + 1))
    C = ctx.pow(ctx.pi, 0.5 * s) * ctx.exp(C1)
    print("C: {0}", C)
    return C




# Roy’s largest root 𝜃: pdf (Chiani)

def roy_chiani_pdf(self, ctx, t1, p, n1, n2):
    # still needs differentiation of t1
    k = 46.446
    delta = 0.186054
    alpha = 9.84801
    phi = ctx.acos((n2 - n1) / (n2 + n1 - 1))
    g = ctx.acos((n2 + n1 - 2 * p) / (n2 + n1 - 1))
    s3 = 16 / (((n2 + n1 - 1) ^ 2) * (ctx.sin(g + phi) ^ 2)
               * ctx.sin(g) * ctx.sin(phi))
    mu = 2 * ctx.log(ctx.tan((g + phi) / 2))
    sigma = s3 ^ (1 / 3)
    x = (ctx.log(t1 / (1 - t1)) - mu + sigma * alpha) / (delta * sigma)
    P1 = ctx.gamma_p(k, x)
    return P1


# Roy’s largest root: cdf and sf (Chiani)

def roy_chiani_cdf(self, ctx, t1, p, n1, n2):
    k = 46.446
    delta = 0.186054
    alpha = 9.84801
    phi = ctx.acos((n2 - n1) / (n2 + n1 - 1))
    g = ctx.acos((n2 + n1 - 2 * p) / (n2 + n1 - 1))
    s3 = 16 / (((n2 + n1 - 1) ^ 2) * (ctx.sin(g + phi) ^ 2)
               * ctx.sin(g) * ctx.sin(phi))
    mu = 2 * ctx.log(ctx.tan((g + phi) / 2))
    sigma = s3 ^ (1 / 3)
    x = (ctx.log(t1 / (1 - t1)) - mu + sigma * alpha) / (delta * sigma)
    P1 = ctx.gamma_p(k, x)
    return P1


# Roy’s largest root: qtf and isf (Chiani)

def roy_chiani_qtf(self, ctx, LeftTail, p, n1, n2):
    k = 46.446
    delta = 0.186054
    alpha = 9.84801
    phi = ctx.acos((n2 - n1) / (n2 + n1 - 1))
    g = ctx.acos((n2 + n1 - 2 * p) / (n2 + n1 - 1))
    s3 = 16 / (((n2 + n1 - 1) ^ 2) * (ctx.sin(g + phi) ^ 2)
               * ctx.sin(g) * ctx.sin(phi))
    mu = 2 * ctx.log(ctx.tan((g + phi) / 2))
    sigma = s3 ^ (1 / 3)
    P1 = ctx.gamma_p_inv(k, LeftTail)
    num = ctx.exp(sigma * (delta * P1 - alpha) + mu)
    result = num / (1 + num)
    return result




# %% Distribution of Wilks' Lambda


class ctx_wilks_lambda(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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





# %% Distribution of Pillai's V


class ctx_pillai_v(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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



# Central Pillai’s V : cdf, sf (Ginzberg)
# !!! only 2 moments !!!
def pillai_v_cdf_ginzberg(self, ctx, p, N1, n2, x):
    x = x / n2
    m = (N1 - p - 1) / 2
    n = (n2 - p - 1) / 2
    s = p
    mu1 = s * (2 * m + s + 1) / (2 * (m + n + s + 1))
    mu2 = s * (2 * m + s + 1) * (2 * n + s + 1) * (2 * m + 2 * n + s + 2) / \
    (4 * (m + n + s + 1) ** 2 * (m + n + s + 2) * (2 * m + 2 * n + 2 * s + 1))
    m1 = mu1 / p
    m2 = (mu2) / (p * p)
    a = (m1 / m2) * (m1 - (m1) ** 2 - m2)
    b = a * (1 - m1) / m1
    w = x / p
    LeftTail, Righttail = ctx.betadis(a, b, w, 1 - w)
    return LeftTail, Righttail


# Central Pillai’s V : qtf, isf (Ginzberg)
def pillai_v_qtf_ginzberg(self, ctx, p, n1, n2, LeftTail, Righttail):
    m = (n1 - p - 1) / 2
    n = (n2 - p - 1) / 2
    r = m + n + p
    k1 = p * (2 * m + p + 1) / (2 * (r + 1))
    k2 = k1 * (2 * n + p + 1) * (2 * m + 2 * n + p + 2) / \
        (2 * (r + 1) * (r + 2) * (2 * r + 1))
    k3 = 4 * k2 * (n - m) * (m + n + 1) / ((r + 1) * (r + 3) * (2 * r))
    #print("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3)
    k12 = k1 * k1
    k22 = k2 * k2
    a = (2 * k1 * (k12 * k2 - k22 + k1 * k3)) / \
        (4 * k1 * k22 - k12 * k3 + k2 * k3)
    b = (2 * k2 * (2 * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3)) / \
        ((k1 * k3 - 2 * k22) * (k12 * k3 - 4 * k1 * k22 - k2 * k3))
    k = (k12 * k3 - 4 * k1 * k22 - k2 * k3) / (k1 * k3 - 2 * k22)
    wx, wy = ctx.betadisx(LeftTail, Righttail, a, b)
    V = k * wx
    #print("(n + m) * V / n: {0}", (n1 + n2) * V / n1)
    return V





# %% Distribution of Hotelling's T^2


class ctx_hotelling_t2(ctx_rv_cont):

    def __init__(self, ctx, a, b):
        self.set_ctx(ctx)
        self.df = ctx.t(a)
        self.df = ctx.t(b)
        
        self.set_rangeleft(0)
        self.set_rangeright(1)

        self.set_supportleft(0)
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





# Central Hotelling’s 𝑇2: cdf, sf (Pillai and Young)
def hotelling_t2_cdf_young(ctx, p, m, n, x):
    mu1 = p * (2 * m + p + 1) / (2 * n)
    mu2 = mu1 * (2 * m + 2 * n + p + 1) * (2 * n + p) / \
        (2 * n * (n - 1) * (2 * n + 1))
    mu3 = 2 * mu2 * (2 * m + n + p + 1) * (n + p) / (n * (n - 2) * (n + 1))
    mu12 = mu1 ** 2
    mu13 = mu1 * mu12
    mu22 = mu2 ** 2
    a = (2 * mu13 * mu2 + 3 * mu12 * mu3 - 6 * mu1 * mu22 -
         mu2 * mu3) / (mu2 * mu3 + 4 * mu1 * mu22 - mu12 * mu3)
    b = ((a + 1) * (a + 3) - mu12 / mu2) / ((a + 1) - mu12 / mu2)
    k = mu1 * (b - a - 2) / (a + 1)
    w = x / (x + k)
    LeftTail, Righttail = ctx.betadis(a + 1, b - a - 1, w, 1 - w)
    return LeftTail, Righttail


# Central Hotelling’s 𝑇2: qtf, isf (Pillai and Young)
def hotelling_t2_qtf_young(ctx, p, m, n, LeftTail, Righttail):
    mu1 = p * (2 * m + p + 1) / (2 * n)
    mu2 = mu1 * (2 * m + 2 * n + p + 1) * (2 * n + p) / \
        (2 * n * (n - 1) * (2 * n + 1))
    mu3 = 2 * mu2 * (2 * m + n + p + 1) * (n + p) / (n * (n - 2) * (n + 1))
    mu12 = mu1 ** 2
    mu13 = mu1 * mu12
    mu22 = mu2 ** 2
    a = (2 * mu13 * mu2 + 3 * mu12 * mu3 - 6 * mu1 * mu22 -
         mu2 * mu3) / (mu2 * mu3 + 4 * mu1 * mu22 - mu12 * mu3)
    b = ((a + 1) * (a + 3) - mu12 / mu2) / ((a + 1) - mu12 / mu2)
    k = mu1 * (b - a - 2) / (a + 1)
    wx, wy = ctx.betadisx(LeftTail, Righttail, a + 1, b - a - 1)
    x = k * (wx / wy)
    print("x:", x)
    return x





# %% Noncentral distribution of Wilks' lambda, GLM



class ctx_wilks_lambda_glm(ctx_rv_cont):

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






# %% Noncentral distribution of Wilks' lambda, independence



class ctx_wilks_lambda_corr(ctx_rv_cont):

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












