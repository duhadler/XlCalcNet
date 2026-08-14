# -*- coding: utf-8 -*-
"""
@author: DH
"""


from xlcalcnet.mpmath import mp as mp_

from xlcalcnet.ctx10Series import ctxSeries, ctxIntegral

from xlcalcnet.ctx11PmfVector import ctxPmfBasicVector, ctxLehmann, ctxMilton, \
    ctxFriedman, ctxKruskal

from xlcalcnet.ctx12Asymptotic import ctxAsymptotic

from xlcalcnet.ctx13FastApprox import ctxApprox


class ctxUtil(object):




    # %% 4 Real scalar functions

    # %%% 4.1 Error functions for real arguments

    def ndisx_erf2(self, ctx, LeftTailTarget, RightTailTarget):
        temp = ctx.sqrt(2) * ctx.real_erfinv(2 * LeftTailTarget - 1)
        return temp

    def ndisx_erf(self, ctx, LeftTailTarget, RightTailTarget):
        temp = 0
        if LeftTailTarget < RightTailTarget:
            temp = self.ndisx_erf2(ctx, LeftTailTarget, RightTailTarget)
        else:
            temp = self.ndisx_erf2(ctx, RightTailTarget, LeftTailTarget)
        if LeftTailTarget > RightTailTarget:
            temp = -temp
        return temp


# %%% 4.2 Incomplete gamma functions for non-negative real arguments and parameters


    def real_gamma_p(self, ctx,  a, x, **kwargs):
        a = ctx.t(a)
        x = ctx.t(x)
        if "method" in kwargs:
            method = kwargs["method"]
            if method == 'mpmath':
                res = ctx.gammainc(a, 0, x, regularized=True)
                return ctx.t(res)
            if method == 'peizer':
                L, R, d = ctxSeries().gamma_peizer_cdf_sf_pdf(ctx, a, x)
                return L
            if method == 'paris':
                L, R = ctxSeries().gamma_paris_cdf_sf(ctx, a, x, 20)
                return L
        else:
            res = ctx.gammainc(a, 0, x, regularized=True)
            return ctx.t(res)

    def real_gamma_q(self, ctx, a, x, **kwargs):
        a = ctx.t(a)
        x = ctx.t(x)
        if "method" in kwargs:
            method = kwargs["method"]
            if method == 'mpmath':
                res = ctx.gammainc(a, x, +ctx.inf, regularized=True)
                return ctx.t(res)
            if method == 'peizer':
                L, R, d = ctxSeries().gamma_peizer_cdf_sf_pdf(ctx, a, x)
                return R
            if method == 'paris':
                L, R = ctxSeries().gamma_paris_cdf_sf(ctx, a, x, 20)
                return R
        else:
            res = ctx.gammainc(a, x, +ctx.inf, regularized=True)
            return ctx.t(res)

    def real_gamma_p_inv(self, ctx, a, LeftTail, **kwargs):
        RightTail = 1-LeftTail
        #X0 = self.gammainv_approx(mp_, LeftTail, RightTail, a)
        X0 = self.gamma_canal_qtf(ctx, LeftTail, RightTail, a)
        #print("X0: ", X0)
        return ctx.findroot(lambda x: self.real_gamma_p(ctx, a, x, **kwargs) - LeftTail, X0)
#        return mp_.findroot(lambda x: self.real_gamma_p(ctx, a, x, **kwargs) - LeftTail, X0, verbose = True)

    def real_gamma_q_inv(self, ctx, a, RightTail, **kwargs):
        LeftTail = 1-RightTail
        X0 = self.gamma_canal_qtf(ctx, LeftTail, RightTail, a)
        #print("X0: ", X0)
        return ctx.findroot(lambda x: self.real_gamma_q(ctx, a, x, **kwargs) - RightTail, X0)
#        return mp_.findroot(lambda x: self.real_gamma_q(ctx, a, x, **kwargs) - RightTail, X0, verbose = True)



# %%%  4.3 Incomplete beta functions for non-negative real arguments and parameters


    def betadis(self, ctx,  a, b, q, p):
        a = ctx.t(a)
        b = ctx.t(b)
        q = ctx.t(q)
        p = ctx.t(p)
        L, R, density = ctxSeries().beta_peizer_cdf_sf_pdf(ctx, a, b, q, p)
        return L, R

    def betadis3(self, ctx,  a, b, q, p):
        a = ctx.t(a)
        b = ctx.t(b)
        q = ctx.t(q)
        p = ctx.t(p)
        L, R, density = ctxSeries().beta_peizer_cdf_sf_pdf(ctx, a, b, q, p)
        return L, R, density

    def real_ibeta(self, ctx,  a, b, x, **kwargs):
        a = ctx.t(a)
        b = ctx.t(b)
        x = ctx.t(x)
        q = x
        p = 1 - x
        if "method" in kwargs:
            method = kwargs["method"]
            if method == 'mpmath':
                return ctx.re(ctx.betainc(a, b, 0, q, regularized=True))
            if method == 'cf':
                L, R, density = ctxSeries().beta_peizer_cdf_sf_pdf(ctx, a, b, q, p)
                return L
        else:
            res = ctx.re(ctx.betainc(a, b, 0, q, regularized=True))
            return ctx.t(res)

    def real_ibetac(self, ctx,  a, b, x, **kwargs):
        a = ctx.t(a)
        b = ctx.t(b)
        x = ctx.t(x)
        q = x
        p = 1 - x
        if "method" in kwargs:
            method = kwargs["method"]
            if method == 'mpmath':
                return ctx.re(ctx.betainc(b, a, 0, p, regularized=True))
            if method == 'cf':
                L, R, density = ctxSeries().beta_peizer_cdf_sf_pdf(ctx, a, b, q, p)
                return R
        else:
            res = ctx.re(ctx.betainc(b, a, 0, p, regularized=True))
            return ctx.t(res)

    def real_ibeta_inv(self, ctx, a, b, LeftTail, **kwargs):
        a = ctx.t(a)
        b = ctx.t(b)
        LeftTail = ctx.t(LeftTail)
        RightTail = 1-LeftTail
        #X0, Y0 = self.betadisx_approx(mp_, LeftTail, RightTail, a, b)
        X0, Y0 = self.beta_davis_qtf(ctx, LeftTail, RightTail, a, b)
        #print("X0, Y0: ", X0, Y0)
        return ctx.findroot(lambda x: self.real_ibeta(ctx, a, b, x, **kwargs) - LeftTail, X0)
        # return mp_.findroot(lambda x: self.real_ibeta(mp_, a, b, x, **kwargs) - LeftTail, X0, verbose=True)

    def real_ibetac_inv(self, ctx, a, b, RightTail, **kwargs):
        a = ctx.t(a)
        b = ctx.t(b)
        RightTail = ctx.t(RightTail)
        LeftTail = 1-RightTail
        #X0, Y0 = self.betadisx_approx(mp_, LeftTail, RightTail, a, b)
        X0, Y0 = self.beta_davis_qtf(ctx, LeftTail, RightTail, a, b)
        #print("X0, Y0: ", X0, Y0)
        return ctx.findroot(lambda x: self.real_ibetac(ctx, a, b, x, **kwargs) - RightTail, X0)
        # return mp_.findroot(lambda x: self.real_ibetac(mp_, a, b, x, **kwargs) - RightTail, X0, verbose=True)



# %% 5 Basic continuous distribution functions


# %%%  5.1 Closed form distributions, based on elementary functions

# 5.1.1 Arcsine distribution, pdf
    def arcsine_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        return 1 / (ctx.pi * ctx.sqrt((x-a)*(b-x)))

# 5.1.2 Arcsine distribution, cdf and sf
    def arcsine_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            return 2 * ctx.asin(ctx.sqrt((x-a)/(b-a))) / ctx.pi
        else:
            return 2 * ctx.acos(ctx.sqrt((x-a)/(b-a))) / ctx.pi

# 5.1.3 Arcsine distribution, qtf and isf
    def arcsine_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            t = (ctx.sin(ctx.pi * q / 2))
            return a + (b-a)*t * t
        else:
            t = (ctx.cos(ctx.pi * q / 2))
            return a + (b-a)*t * t


# 5.1.4 Cauchy distribution, pdf
    def cauchy_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        pi = ctx.pi
        return 1 / (pi*b*(1 + (x - a) * (x - a) / (b * b)))

# 5.1.5 Cauchy distribution, cdf and sf
    def cauchy_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        half = ctx.t("0.5")
        pi_inv = 1 / ctx.pi
        t = pi_inv * ctx.atan((x - a) / b)
        if cdf:
            return half + t
        else:
            return half - t

# 5.1.6 Cauchy distribution, qtf and isf
    def cauchy_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        half = ctx.t("0.5")
        if q == half:
            return a
        p1 = q
#        if q > half:
#            p1 = 1 - q
        pi = ctx.pi
        t = b / ctx.tan(pi * p1)
        if qtf:
            return a - t
        else:
            return a + t


# 5.1.7 Dagum distribution, pdf
    def dagum_pdf(self, ctx, x, a, b, p):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        p = ctx.t(p)
        res1 = a*p/x
        res2 = (x/b)**(a*p)
        res3 = ((x/b)**a +1)**(p+1)
        return res1 * res2 / res3

# 5.1.8 Dagum distribution, cdf and sf
    def dagum_cdf(self, ctx, x, a, b, p, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        p = ctx.t(p)
        res1 = 1 + (x/b)**(-a)
        res2 = res1 **(-p)
        if cdf:
            return res2
        else:
            return 1-res2

# 5.1.9 Dagum distribution, qtf and isf
    def dagum_qtf(self, ctx, q, a, b, p, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        p = ctx.t(p)
        if qtf==False: q=1-q
        res1 = b*(q**(-1/p)-1)
        res2 = res1 **(-1/a)
        if qtf:
            return res2
        else:
            return res2


# 5.1.10 Exponential distribution, pdf
    def exponential_pdf(self, ctx, x, lambda1):
        x = ctx.t(x)
        lambda1 = ctx.t(lambda1)
        return lambda1 * ctx.exp(-lambda1 * x)

# 5.1.11 Exponential distribution, cdf and sf
    def exponential_cdf(self, ctx, x, lambda1, cdf):
        x = ctx.t(x)
        lambda1 = ctx.t(lambda1)
        if cdf:
            return -ctx.expm1(-x * lambda1)
        else:
            return ctx.exp(-x * lambda1)

# 5.1.12 Exponential distribution, qtf and isf
    def exponential_qtf(self, ctx, q, lambda1, qtf):
        q = ctx.t(q)
        lambda1 = ctx.t(lambda1)
        if qtf:
            return -ctx.log1p(-q) / lambda1
        else:
            return -ctx.log(q) / lambda1


# 5.1.13 Fisk distribution, pdf
    def fisk_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res1 = (b/a)*(x/a)**(b-1)
        res2 = (1+(x/a)**b)**2
        res3 = res1/res2
        return res3

# 5.1.14 Fisk distribution, cdf and sf
    def fisk_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        xb = x**b
        ab = a**b
        res3 = xb/(ab+xb)
        if cdf:
            return res3
        else:
            return 1-res3

# 5.1.15 Fisk distribution, qtf and isf
    def fisk_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf==False: q=1-q
        res1 = a*(q/(1-q))
        res2 = res1**(1/b)
        if qtf:
            return res2
        else:
            return res2


# 5.1.16 Frechet distribution, pdf
    def frechet_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res1 = b * a**b * x**(-(b+1))
        res2 = ctx.exp(-(a/x)**b)
        res3 = res1*res2
        return res3

# 5.1.17 Frechet distribution, cdf and sf
    def frechet_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res2 = ctx.exp(-(a/x)**b)
        if cdf:
            return res2
        else:
            return 1-res2

# 5.1.18 Frechet distribution, qtf and isf
    def frechet_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf==False: q=1-q
        res2 = (-ctx.ln(q))**(-1/a)
        if qtf:
            return res2
        else:
            return res2


# 5.1.19 Generalized Extreme Value (GEV), pdf
    def gev_pdf(self, ctx, x, a, b, c, Max):
        return None

# 5.1.20 Generalized Extreme Value (GEV), cdf and sf
    def gev_cdf(self, ctx, x, a, b, c, cdf, Max):
        return None

# 5.1.21 Generalized Extreme Value (GEV), qtf and isf
    def gev_qtf(self, ctx, q, a, b, c, qtf, Max):
        return None




# 5.1.22 Generalized Pareto distribution, pdf
    def genpareto_pdf(self, ctx, x, m, s, c):
        x = ctx.t(x)
        m = ctx.t(m)
        s = ctx.t(s)
        c = ctx.t(c)
        z = (x-m)/s
        if c== 0: return ctx.exp(-z)
        res1 = (1+c*z)**(-(c+1)/c)
        return res1

# 5.1.23 Generalized Pareto distribution, cdf and sf
    def genpareto_cdf(self, ctx, x, m, s, c, cdf):
        x = ctx.t(x)
        m = ctx.t(m)
        s = ctx.t(s)
        c = ctx.t(c)
        z = (x-m)/s
        if cdf:
            if c== 0: return 1-ctx.exp(-z)
            res1 = 1-(1+c*z)**(-1/c)
            return res1
        else:
            if c== 0: return ctx.exp(-z)
            res1 = (1+c*z)**(-1/c)
            return res1

# 5.1.24 Generalized Pareto distribution, qtf and isf
    def genpareto_qtf(self, ctx, q, m, s, c, qtf):
        q = ctx.t(q)
        m = ctx.t(m)
        s = ctx.t(s)
        c = ctx.t(c)
        if qtf:
            if c== 0: return m - s*ctx.log(1-q)
            res1 = m + s * ((1-q)**(-c)-1)/c
            return res1
        else:
            if c== 0: return m - s*ctx.log(q)
            res1 = m + s * (q**(-c)-1)/c
            return res1




# 5.1.25 Gompertz-Makeham distribution, pdf
    def gompertz_pdf(self, ctx, x, a, b, l):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        l = ctx.t(l)
        return (a * ctx.exp(b*x) + l) * ctx.exp(-l*x-(a/b)*(ctx.expm1(b*x)))

# 5.1.26 Gompertz-Makeham distribution, cdf and sf
    def gompertz_cdf(self, ctx, x, a, b, l, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        l = ctx.t(l)
        if cdf:
            return -ctx.expm1(-l*x-(a/b)*(ctx.expm1(b*x)))
        else:
            return ctx.exp(-l*x-(a/b)*(ctx.expm1(b*x)))

# 5.1.27 Gompertz-Makeham distribution, qtf and isf
    def gompertz_qtf(self, ctx, q, a, b, l, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        l = ctx.t(l)
        if qtf:
            if l == 0:
                return (1/b) * ctx.log1p(-(b/a) * ctx.log1p(-q))
            else:
                res1 = a/(b*l) - ctx.log1p(-q)/l
                res2 = (a/l) * ctx.exp(a/l) * ctx.pow1p(-q, -b/l)
                return  res1 - (1/b) * ctx.lambertw(res2)
        else:
            if l == 0:
                return  (1/b) * ctx.log1p(-(b/a) * ctx.ln(q))
            else:
                res1 = a/(b*l) - ctx.ln(q)/l
                res2 = (a/l) * ctx.exp(a/l) * ctx.pow(q, -b/l)
                return  res1 - (1/b) * ctx.lambertw(res2)



# 5.1.28 Gumbel (Extreme Value) distribution, pdf
    def gumbel_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.exp(-(x - a) / b)
        return c * ctx.exp(-c) / b

# 5.1.29 Gumbel (Extreme Value) distribution, cdf and sf
    def gumbel_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.exp(-(x - a) / b)
        if cdf:
            return ctx.exp(-c)
        else:
            return -ctx.expm1(-c)

# 5.1.30 Gumbel (Extreme Value) distribution, qtf and isf
    def gumbel_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return a - ctx.log(-ctx.log(q)) * b
        else:
            return a - ctx.log(-ctx.log1p(-q)) * b


# 5.1.31 Hyperexponential distribution, pdf
    def hyperexp_pdf(self, ctx, x, k, w, l):
        x = ctx.t(x)
        k = int(k)
        wsum = 0
        for i in range(k):
            wsum  += w[i]
        for i in range(k):
            w[i] /= wsum
        res1 = 0
        for i in range(k):
            res1 += w[i] * l[i] * ctx.exp(-l[i]*x)
        return res1

# 5.1.32 Hyperexponential distribution, cdf and sf
    def hyperexp_cdf(self, ctx, x, k, w, l, cdf=True):
        x = ctx.t(x)
        k = int(k)
        wsum = 0
        for i in range(k):
            wsum  += w[i]
        for i in range(k):
            w[i] /= wsum
        cdf_ = 0
        sf_ = 0
        for i in range(k):
            cdf_ += w[i] * ctx.expm1(-l[i]*x)
            sf_  += w[i] * ctx.exp(-l[i]*x)
        cdf_ = -cdf_
        if cdf:
            return cdf_
        else:
            return sf_

# 5.1.33 Hyperexponential distribution, qtf and isf
    def hyperexp_qtf(self, ctx, q, k, w, l, qtf=True):
        q = ctx.t(q)
        k = int(k)
        wl = 0
        for i in range(k):
            wl += w[i] /l[i]
        #print("wl:", wl, 1/wl)
        qtf_ = -ctx.log1p(-q) * wl
        #print("qtf:", qtf_)
        isf_ = -ctx.log(q) * wl
        #print("isf:", isf_)
        if qtf: return qtf_
        return isf_


# 5.1.34 Kumaraswamy distribution, pdf
    def kumaraswamy_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        #s = ctx.powm1(x,a)
        r = ctx.powm1(x, a)
        t = ctx.power(-r, b-1)
        s = ctx.power(x, a-1)
        return a*b*s*t

# 5.1.35 Kumaraswamy distribution, cdf and sf
    def kumaraswamy_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        t = ctx.powm1(x, a)
        if cdf:
            return -ctx.powm1(-t, b)
        else:
            return ctx.power(-t, b)

# 5.1.36 Kumaraswamy distribution, qtf and isf
    def kumaraswamy_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            t = ctx.pow1pm1(-q, 1/b)
        else:
            t = ctx.powm1(q, 1/b)
        return ctx.power(-t, 1/a)


# 5.1.37 Laplace distribution, pdf
    def laplace_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        e = x - a
        if (e > 0):
            e = -e
        e /= b
        result = ctx.exp(e)
        result /= 2 * b
        return result

# 5.1.38 Laplace distribution, cdf and sf
    def laplace_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            if (x <= a):
                return ctx.exp((x - a) / b) / 2
            else:
                return 1 - ctx.exp((a - x) / b) / 2
        else:
            if (-x < -a):
                return ctx.exp((-x + a) / b) / 2
            else:
                return 1 - ctx.exp((-a + x) / b) / 2

# 5.1.39 Laplace distribution, qtf and isf
    def laplace_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        half = ctx.t("0.5")
        if qtf:
            if q <= half:
                return a + b * ctx.log((2 * q))
            else:
                return a - b * ctx.log((2 - 2 * q))
        else:
            if q <= half:
                return a - b * ctx.log((2 * q))
            else:
                return a + b * ctx.log((2 - 2 * q))
#            if half < q: return a + b * ctx.log((2 - 2 * q))
#            else: return a - b * ctx.log((2 * q))


# 5.1.40 Logistic distribution, pdf
    def logistic_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.exp(-(x - a) / b)
        return c / (b * (1 + c) ** 2)

# 5.1.41 Logistic distribution, cdf and sf
    def logistic_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            return 1 / (1 + ctx.exp(-(x - a) / b))
        else:
            return 1 / (1 + ctx.exp((x - a) / b))

# 5.1.42 Logistic distribution, qtf and isf
    def logistic_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return a + b * ctx.log(q / (1-q))
        else:
            return a - b * ctx.log(q / (1-q))


# 5.1.43 Lomax distribution, pdf
    def lomax_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res1 = (a/b)
        res2 = (1+(x/b))**(-(a+1))
        res3 = res1*res2
        return res3

# 5.1.44 Lomax distribution, cdf and sf
    def lomax_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res2 = (1+(x/b))**(-a)
        if cdf:
            return 1-res2
        else:
            return res2

# 5.1.45 Lomax distribution, qtf and isf
    def lomax_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return b * ( (1-q)**(-1/a) -1 )
        else:
            return b * ( (q)**(-1/a) -1 )


# 5.1.46 Pareto distribution, pdf
    def pareto_pdf(self, ctx, x, k, a):
        x = ctx.t(x)
        k = ctx.t(k)
        a = ctx.t(a)
        if (x < k):
            return ctx.t(0)
        else:
            return a * ctx.power(k, a) / ctx.power(x, a + 1)

# 5.1.47 Pareto distribution, cdf and sf
    def pareto_cdf(self, ctx, x, k, a, cdf):
        x = ctx.t(x)
        k = ctx.t(k)
        a = ctx.t(a)
        if cdf:
            if (x < k): return ctx.t(0)
            else:return -ctx.powm1(k/x, a)
        else:
            if (x < k): return ctx.t(1)
            else:return ctx.pow(k/x, a)

# 5.1.48 Pareto distribution, qtf and isf
    def pareto_qtf(self, ctx, q, k, a, qtf):
        q = ctx.t(q)
        k = ctx.t(k)
        a = ctx.t(a)
        if qtf:
            return k / ((1 - q) ** (1 / a))
        else:
            return k / (q ** (1 / a))


# 5.1.49 Rayleigh distribution, pdf
    def rayleigh_pdf(self, ctx, x, b):
        x = ctx.t(x)
        b = ctx.t(b)
        s2 = b * b
        return x * (ctx.exp(-(x * x) / (2 * s2))) / s2

# 5.1.50 Rayleigh distribution, cdf and sf
    def rayleigh_cdf(self, ctx, x, b, cdf=True):
        x = ctx.t(x)
        b = ctx.t(b)
        if cdf:
            return -ctx.expm1(-x * x / (2 * b * b))
        else:
            return ctx.exp(-(x * x) / (2 * b * b))

# 5.1.51 Rayleigh distribution, qtf and isf
    def rayleigh_qtf(self, ctx, q, b, qtf=True):
        q = ctx.t(q)
        b = ctx.t(b)
        if qtf:
            return b * ctx.sqrt(-2 * ctx.log1p(-q))
        else:
            return b * ctx.sqrt(-2 * ctx.log(q))


# 5.1.52 Shifted Gompertz distribution, pdf
    def shifted_gompertz_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res1 = b *ctx.exp(-(b*x+a*ctx.exp(-b*x)))
        res2 = (1+a*(1-ctx.exp(-b*x)))
        return res1 * res2

# 5.1.53 Shifted Gompertz distribution, cdf and sf
    def shifted_gompertz_cdf(self, ctx, x, a, b, cdf=True):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        res1 = (1-ctx.exp(-b*x))
        res2 = ctx.exp(a*ctx.exp(-b*x))
        if cdf:
            return res1 * res2
        else:
            return 1 - res1 * res2

# 5.1.54 Shifted Gompertz distribution, qtf and isf
    def shifted_gompertz_qtf(self, ctx, q, a, b, qtf=True):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf==False: q=1-q
        res1 = ctx.lambertw(a*ctx.exp(a)*q) / a
        res2 = (1/b) * ctx.log(1-res1)
        if qtf:
            return -res2
        else:
            return -res2


# 5.1.55 Singh-Maddala (Burr Type XII) distribution, pdf
    def singh_maddala_pdf(self, ctx, x, a, b, d):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        d = ctx.t(d)
        res1 = a*d*x**(a-1)
        res2 = 1+(x/b)**a
        res3 = b**a * res2**(1+d)
        res4 = res1/res3
        return res4

# 5.1.56 Singh-Maddala (Burr Type XII) distribution, cdf and sf
    def singh_maddala_cdf(self, ctx, x, a, b, d, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        d = ctx.t(d)
        res2 = (1+(x/b)**a)**(-d)
        if cdf:
            return 1-res2
        else:
            return res2
        return None

# 5.1.57 Singh-Maddala (Burr Type XII) distribution, qtf and isf
    def singh_maddala_qtf(self, ctx, q, a, b, d, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        d = ctx.t(d)
        if qtf==False: q=1-q
        res1 = (1-q)**(-1/d) - 1
        res2 = b * res1**(1/a)
        if qtf:
            return res2
        else:
            return res2


# 5.1.58 Triangular distribution, pdf
    # lower = a; upper = b; mode = c
    def triangular_pdf(self, ctx, x, a, b, c):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        if x<a: return ctx.zero
        if x>b: return ctx.zero
        if x==c: return 2/(b-a)
        if (a<=x) and (x<c): return 2*(x-a)/((b-a)*(c-a))
        if (c<x) and (x<=b): return 2*(b-x)/((b-a)*(b-c))

# 5.1.59 Triangular distribution, cdf and sf
    # lower = a; upper = b; mode = c
    def triangular_cdf(self, ctx, x, a, b, c, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        if cdf:
            if x<a: return ctx.zero
            if x>b: return ctx.one
            if (a<=x) and (x<=c): return (x-a)*(x-a)/((b-a)*(c-a))
            if (c<x) and (x<=b): return 1-(b-x)*(b-x)/((b-a)*(b-c))
        else:
            if x<a: return ctx.one
            if x>b: return ctx.zero
            if (a<=x) and (x<=c): return 1-(x-a)*(x-a)/((b-a)*(c-a))
            if (c<x) and (x<=b): return (b-x)*(b-x)/((b-a)*(b-c))

# 5.1.60 Triangular distribution, qtf and isf
    # lower = a; upper = b; mode = c
    def triangular_qtf(self, ctx, q, a, b, c, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        y = q
        if qtf==False: y=1-y
        if y<(c-a)/(b-a):
            return a + ctx.sqrt((b-a)*(c-a)*y)
        if y==(c-a)/(b-a):
            return c
        if y>(c-a)/(b-a):
            return b - ctx.sqrt((b-a)*(b-c)*(1-y))


# 5.1.61 Uniform distribution, pdf
    def uniform_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if ((x < a) or (x > b)):
            return ctx.t(0)
        else:
            return 1 / (b - a)

# 5.1.62 Uniform distribution, cdf and sf
    def uniform_cdf(self, ctx, x, a, b, cdf=True):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if ((x < a) or (x > b)):
            if (x < a):
                cdf1 = 0
                cdf2 = 1
            else:
                cdf1 = 1
                cdf2 = 0
        else:
            cdf1 = (x - a) / (b - a)
            cdf2 = (b - x) / (b - a)
        if cdf:
            return cdf1
        else:
            return cdf2

# 5.1.63 Uniform distribution, qtf and isf
    def uniform_qtf(self, ctx, q, a, b, qtf=True):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if ((q == 0) or (q == 0)):
            if (q == 0):
                icdf1 = a
                icdf2 = b
            else:
                icdf1 = b
                icdf2 = a
        else:
            icdf1 = q * (b - a) + a
            icdf2 = -(1 - q) * (b - a) + b
        if qtf:
            return icdf1
        else:
            return icdf2


# 5.1.64 Weibull distribution, pdf
    def weibull_pdf(self, ctx, x, a, b, Max):
        x = ctx.t(x)
        b = ctx.t(b)
        a = ctx.t(a)
        result = ctx.exp(-ctx.power(x / b, a))
        result *= ctx.power(x / b, a - 1) * a / b
        return result

# 5.1.65 Weibull distribution, cdf and sf
    def weibull_cdf(self, ctx, x, a, b, cdf, Max):
        x = ctx.t(x)
        b = ctx.t(b)
        a = ctx.t(a)
        if cdf:
            return -ctx.expm1(-ctx.power(x / b, a))
        else:
            return ctx.exp(-ctx.power(x / b, a))

# 5.1.66 Weibull distribution, qtf and isf
    def weibull_qtf(self, ctx, q, a, b, qtf, Max):
        q = ctx.t(q)
        b = ctx.t(b)
        a = ctx.t(a)
        if qtf:
            return b * ctx.power(-ctx.log1p(-q), 1 / a)
        else:
            return b * ctx.power(-ctx.log(q), 1 / a)


# %%%  5.2 Closed form distributions, based on the error function


# 5.2.1 Birnbaum-Saunders distribution, pdf


    def birnb_saunders_pdf(self, ctx, x, mu, sigma):
        return None

# 5.2.2 Birnbaum-Saunders distribution, cdf and sf
    def birnb_saunders_cdf(self, ctx, x, mu, sigma, cdf=True):
        return None

# 5.2.3 Birnbaum-Saunders distribution distribution, qtf and isf
    def birnb_saunders_qtff(self, ctx, x, mu, sigma, qtf=True):
        return None


# 5.2.4 Exponentially Modified Gaussian (EMG) distribution, pdf


    def emg_pdf(self, ctx, x, mu, sigma):
        return None

# 5.2.5 Exponentially Modified Gaussian (EMG) distribution, cdf and sf
    def emg_cdf(self, ctx, x, mu, sigma, cdf=True):
        return None

# 5.2.6 Exponentially Modified Gaussian (EMG) distribution, qtf and isf
    def emg_qtff(self, ctx, x, mu, sigma, qtf=True):
        return None


# 5.2.7 Folded normal distribution, pdf


    def folded_normal_pdf(self, ctx, x, sigma):
        return None

# 5.2.8 Folded normal distribution, cdf and sf
    def folded_normal_cdf(self, ctx, x, sigma, cdf=True):
        return None

# 5.2.9 Folded normal distribution, qtf and isf
    def folded_normal_qtff(self, ctx, x, sigma, qtf=True):
        return None


# 5.2.10 Half-normal distribution, pdf


    def half_normal_pdf(self, ctx, x, sigma):
        return None

# 5.2.11 Half_normal distribution, cdf and sf
    def half_normal_cdf(self, ctx, x, sigma, cdf=True):
        return None

# 5.2.12 Half_normal distribution, qtf and isf
    def half_normal_qtff(self, ctx, x, sigma, qtf=True):
        return None


# 5.2.13 Johnson 𝑆𝐵 distribution, pdf


    def johnson_sb_pdf(self, ctx, x, sigma):
        return None

# 5.2.14 Johnson 𝑆𝐵 distribution, cdf and sf
    def johnson_sb_cdf(self, ctx, x, sigma, cdf=True):
        return None

# 5.2.15 Johnson 𝑆𝐵 distribution, qtf and isf
    def johnson_sb_qtff(self, ctx, x, sigma, qtf=True):
        return None


# 5.2.16 Johnson 𝑆𝑈 distribution, pdf


    def johnson_su_pdf(self, ctx, x, sigma):
        return None

# 5.2.17 Johnson 𝑆𝑈 distribution, cdf and sf
    def johnson_su_cdf(self, ctx, x, sigma, cdf=True):
        return None

# 5.2.18 Johnson 𝑆𝑈 distribution, qtf and isf
    def johnson_su_qtff(self, ctx, x, sigma, qtf=True):
        return None


# 5.2.19 Lévy distribution, pdf


    def levy_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = ctx.sqrt(b / (2 * ctx.pi))
        t = ctx.exp(-b / (2 * (x - a)))
        u = ctx.power(x-a, ctx.t("1.5"))
        return s * t / u

# 5.2.20 Lévy distribution, cdf and sf
    def levy_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = ctx.sqrt(b / (2 * (x-a)))
        if cdf:
            return ctx.real_erfc(s)
        else:
            return ctx.real_erf(s)

# 5.2.21 Lévy distribution, qtf and isf
    def levy_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            s1 = ctx.real_erfcinv(q)
            s1 = 2 * s1 * s1
            return a + b / s1
        else:
            s1 = ctx.real_erfinv(q)
            s1 = 2 * s1 * s1
            return a + b / s1


# 5.2.22 Lognormal distribution, pdf


    def lognormal_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        e = ctx.log(x) - a
        e *= -e
        e /= 2 * b * b
        result = ctx.exp(e)
        result /= b * ctx.sqrt(2 * ctx.pi) * x
        return result

# 5.2.23 Lognormal distribution, cdf and sf
    def lognormal_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        x = ctx.log(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = b * ctx.sqrt(2)
        if cdf:
            return ctx.t("0.5") * ctx.real_erfc(-(x - a) / s)
        else:
            return ctx.t("0.5") * ctx.real_erfc((x - a) / s)

# 5.2.24 Lognormal distribution, qtf and isf
    def lognormal_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        s = b * ctx.sqrt(2)
        if qtf:
            return ctx.exp(a - s * ctx.real_erfcinv(2*q))
        else:
            return ctx.exp(a + s * ctx.real_erfcinv(2*q))


# 5.2.25 Moyal distribution, pdf


    def moyal_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        t1 = (x - a) / (2 * b)
        t2 = ctx.t("0.5") * ctx.exp(-(x-a)/b)
        s = b * ctx.sqrt(2 * ctx.pi)
        return ctx.exp(-t1 - t2) / s

# 5.2.26 Moyal distribution, cdf and sf
    def moyal_cdf(self, ctx, x, a, b, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = ctx.exp(-(x - a) / (2 * b)) / ctx.sqrt(2)
        if cdf:
            return ctx.real_erfc(s)
        else:
            return ctx.real_erf(s)

# 5.2.27 Moyal distribution, qtf and isf
    def moyal_qtf(self, ctx, q, a, b, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            s1 = ctx.real_erfcinv(q)
            s1 = 2 * s1 * s1
            return a - b * ctx.ln(s1)
        else:
            s1 = ctx.real_erfinv(q)
            s1 = 2 * s1 * s1
            return a - b * ctx.ln(s1)


# 5.2.28 Normal distribution, pdf
    def normal_pdf(self, ctx, x, mu, sigma):
        x = ctx.t(x)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        t = ctx.exp(-(x - mu) * (x - mu) / (2 * sigma * sigma))
        s = sigma * ctx.sqrt(2 * ctx.pi)
        return t / s

# 5.2.29 Normal distribution, cdf and sf
    def normal_cdf(self, ctx, x, mu, sigma, cdf):
        x = ctx.t(x)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        s = sigma * ctx.sqrt(2)
        if cdf:
            return ctx.t("0.5") * ctx.real_erfc(-(x - mu) / s)
        else:
            return ctx.t("0.5") * ctx.real_erfc((x - mu) / s)

# 5.2.30 Normal distribution, qtf and isf
    def normal_qtf(self, ctx, q, mu, sigma, qtf):
        q = ctx.t(q)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        s = sigma * ctx.sqrt(2)
        if qtf:
            return mu - s * ctx.real_erfcinv(2*q)
        else:
            return mu + s * ctx.real_erfcinv(2*q)


# 5.2.31 Normal maximum distribution: pdf
    def nmax_pdf(self, ctx, x, k):
        res = k*(ctx.ndis(x))**(k-1) * ctx.ndens(x)
        return res

# 5.2.32 Normal maximum distribution: cdf and sf
    def nmax_cdf(self, ctx, x, k):
        res = (ctx.ndis(x))**k
        return res

# 5.2.33 Normal maximum distribution: qtf and isf
    def nmax_qtf(self, ctx, q, k):
        return None




# 5.2.34 Normal maximum modulus distribution: pdf
    def nmm_pdf(self, ctx, x, k):
        res = 2*k * (2*ctx.ndis(x)-1)**(k-1) * ctx.ndens(x)
        return res

# 5.2.35 Normal maximum modulus distribution: cdf and sf
    def nmm_cdf(self, ctx, x, k):
        res = (ctx.ndis(x) - ctx.ndis(-x))**k
        return res

# 5.2.36 Normal maximum modulus distribution: qtf and isf
    def nmm_qtf(self, ctx, q, k):
        return None



# 5.2.37 Sinh-arcsinh normal distribution, pdf
# This is the normal distribtion not sasnormal !!!
    def sasnormal_pdf(self, ctx, x, mu, sigma):
        x = ctx.t(x)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        t = ctx.exp(-(x - mu) * (x - mu) / (2 * sigma * sigma))
        s = sigma * ctx.sqrt(2 * ctx.pi)
        return t / s

# 5.2.38 Sinh-arcsinh normal distribution, cdf and sf
# This is the normal distribtion not sasnormal !!!
    def sasnormal_cdf(self, ctx, x, mu, sigma, cdf):
        x = ctx.t(x)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        s = sigma * ctx.sqrt(2)
        if cdf:
            return ctx.t("0.5") * ctx.real_erfc(-(x - mu) / s)
        else:
            return ctx.t("0.5") * ctx.real_erfc((x - mu) / s)

# 5.2.39 Sinh-arcsinh normal distribution, qtf and isf
# This is the normal distribtion not sasnormal !!!
    def sasnormal_qtf(self, ctx, q, mu, sigma, qtf):
        q = ctx.t(q)
        mu = ctx.t(mu)
        sigma = ctx.t(sigma)
        s = sigma * ctx.sqrt(2)
        if qtf:
            return mu - s * ctx.real_erfcinv(2*q)
        else:
            return mu + s * ctx.real_erfcinv(2*q)



    # def skewnormal_pdf(self, x, location, scale, a):
# 5.2.40 Skew normal distribution, pdf
    def skewnormal_pdf(self, ctx, x, a, b, c):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        t1 = (2/b) * ctx.normal_pdf((x-a)/b)
        t2 = ctx.normal_cdf(c*(x-a)/b)
        return t1 * t2

# 5.2.41 Skew normal distribution, cdf and sf
    def skewnormal_cdf(self, ctx, x, a, b, c, cdf):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        t1a = ctx.normal_cdf((x-a)/b, 0, 1, True)
        t1b = ctx.normal_cdf((x-a)/b, 0, 1, False)
        t2 = 2 * ctx.owent((x-a)/b, c)
        if cdf:
            return t1a - t2
        else:
            return t1b + t2

    def skewnormal_cdf_mp_(self, ctx, x, a, b, c, cdf):
        x = ctx.t(x)
        res = self.skewnormal_cdf(ctx, x, a, b, c, cdf)
        return ctx.converto_mpf(res)

# 5.2.42 Skew normal distribution, qtf and isf
    def skewnormal_qtf(self, ctx, q, a, b, c, qtf):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        return None
#        a_ = ctx.converto_float(a)
#        b_ = ctx.converto_float(b)
#        c_ = ctx.converto_float(c)
#        prob_ = ctx.converto_float(q)
#        if qtf:
#            X0 = boost2.dist_skewnormal(prob_, a_, b_, c_, 6)
#            #print("X0: ", X0)
#            res = mp_.findroot(lambda x: self.skewnormal_cdf_mp_(
#                ctx, x, a, b, c, True) - q, X0)
#            #res = mp_.findroot(lambda x: self.skewnormal_cdf_mp_(ctx, x, a, b, c, True) - q, X0, verbose = True)
#            return ctx.t(str(res))
#        else:
#            X0 = boost2.dist_skewnormal(prob_, a_, b_, c_, 7)
#            #print("X0: ", X0)
#            res = mp_.findroot(lambda x: self.skewnormal_cdf_mp_(
#                ctx, x, a, b, c, False) - q, X0)
#            #res = mp_.findroot(lambda x: self.skewnormal_cdf_mp_(ctx, x, a, b, c, False) - q, X0, verbose = True)
#            return ctx.t(str(res))


# 5.2.43 Truncated normal distribution, pdf
    def trunc_normal_pdf(self, ctx, x, a, b, c):
        return None

# 5.2.44 Truncated normal distribution, cdf and sf
    def trunc_normal_cdf(self, ctx, x, a, b, c, cdf=True):
        return None

# 5.2.45 Truncated normal distribution, qtf and isf
    def trunc_normal_qtf(self, ctx, prob, a, b, c, qtf=True):
        return None


# 5.2.46 Wald distribution, pdf
    def wald_pdf(self, ctx, x, mu, b):
        x = ctx.t(x)
        mu = ctx.t(mu)
        b = ctx.t(b)
        c = ctx.sqrt(b / (2*ctx.pi*x*x*x))
        s = ctx.exp(-(b*(x-mu)*(x-mu))/(2*x*mu*mu))
        return c * s

# 5.2.47 Wald distribution, cdf and sf
    def wald_cdf(self, ctx, x, mu, b, cdf):
        x = ctx.t(x)
        mu = ctx.t(mu)
        b = ctx.t(b)
        t1 = ctx.sqrt(b/x) * (x/mu - 1)
        t2 = -ctx.sqrt(b/x) * (x/mu + 1)
        s1a = ctx.normal_cdf(t1, 0, 1, True)
        s1b = ctx.normal_cdf(t1, 0, 1, False)
        s2 = ctx.normal_cdf(t2, 0, 1, True)
        c = ctx.exp(2*b/mu)
        if cdf:
            return s1a + c * s2
        else:
            return s1b - c * s2

    def wald_cdf_mp_(self, ctx, x, mu, b, cdf):
        x = ctx.t(x)
        res = self.wald_cdf(ctx, x, mu, b, cdf)
        return ctx.converto_mpf(res)

# 5.2.48 Wald distribution, qtf and isf
    def wald_qtf(self, ctx, q, mu, b, qtf):
        q = ctx.t(q)
        mu = ctx.t(mu)
        b = ctx.t(b)
        return None
#        mu_ = ctx.converto_float(mu)
#        b_ = ctx.converto_float(b)
#        prob_ = ctx.converto_float(q)
#        if qtf:
#            X0 = boost2.dist_wald(prob_, mu_, b_, 6)
#            #print("X0: ", X0)
#            res = mp_.findroot(lambda x: self.wald_cdf_mp_(
#                ctx, x, mu, b, True) - q, X0)
#            #res = mp_.findroot(lambda x: self.wald_cdf_mp_(ctx, x, mu, b, True) - q, X0, verbose = True)
#            return ctx.t(str(res))
#        else:
#            X0 = boost2.dist_wald(prob_, mu_, b_, 7)
#            #print("X0: ", X0)
#            res = mp_.findroot(lambda x: self.wald_cdf_mp_(
#                ctx, x, mu, b, False) - q, X0)
#            #res = mp_.findroot(lambda x: self.wald_cdf_mp_(ctx, x, mu, b, False) - q, X0, verbose = True)
#            return ctx.t(str(res))

    def log_ndens(self, ctx,  X):
        Result = (-X * X * 0.5) - ctx.log(ctx.sqrt(2 * ctx.pi))
        return Result

    def ndens(self, ctx,  X):
        Result = ctx.exp(self.log_ndens(ctx, X))
        return Result

    def ndis(self, ctx,  x):
        Result = ctx.t(0.5) * ctx.erfc(-x / ctx.sqrt(2))
        return Result

    def ndis_ctx(self, ctx, x):
        Result = ctx.t(0.5) * ctx.real_erfc(-x / ctx.sqrt(2))
        return Result




# %%%  5.3 Closed form distributions, based on the incomplete gamma function


# 5.3.1 Amoroso distribution, pdf


    def amoroso_pdf(self, x, nu):
        return None

# 5.3.2 Amoroso distribution, cdf and sf
    def amoroso_cdf(self, x, nu, cdf=True, **kwargs):
        return None

# 5.3.3 Amoroso distribution, qtf and isf
    def amoroso_qtf(self, prob, nu, qtf=True, **kwargs):
        return None


# 5.3.4 𝜒-distribution, pdf

    def chi_pdf(self, ctx, x, nu):
        x = ctx.t(x)
        return 2*x*ctx.chi2_pdf(x*x, nu)

# 5.3.5 𝜒-distribution, cdf and sf
    def chi_cdf(self, ctx, x, nu, cdf, **kwargs):
        x = ctx.t(x)
        return ctx.chi2_cdf(x*x, nu, cdf, **kwargs)

# 5.3.6 𝜒-distribution, qtf and isf
    def chi_qtf(self, ctx, q, nu, qtf, **kwargs):
        return ctx.sqrt(ctx.chi2_qtf(q, nu, qtf, **kwargs))


# 5.3.7 𝜒2-distribution, pdf


    def chi2_pdf(self, ctx, x, nu):
        b = ctx.t(nu)/2
        m = ctx.t(x)/2
        if (m <= 0):
            return ctx.t(0)
        else:
            return ctx.exp(ctx.ln(m) * (b-1)-ctx.loggamma(b)-m)/2

# 5.3.8 𝜒2-distribution, cdf and sf
    def chi2_cdf(self, ctx, x, nu, cdf, **kwargs):
        b = ctx.t(nu)/2
        m = ctx.t(x)/2
        if cdf:
            return ctx.real_gamma_p(b, m, **kwargs)
        else:
            return ctx.real_gamma_q(b, m, **kwargs)

# 5.3.9 𝜒2-distribution, qtf and isf
    def chi2_qtf(self, ctx, q, nu, qtf, **kwargs):
        b = ctx.t(nu)/2
        q = ctx.t(q)
        if qtf:
            return 2*ctx.real_gamma_p_inv(b, q, **kwargs)
        else:
            return 2*ctx.real_gamma_q_inv(b, q, **kwargs)


# 5.3.10 Distribution of the logarithm of a 𝜒2 random variable, pdf


    def logchisquare_pdf(self, ctx, x, n):
        k = 1.0
        z = ctx.exp(k*x)
        t = k*z * ctx.chi2_pdf(z, n)
        return t

# 5.3.11 Distribution of the logarithm of a 𝜒2 random variable, cdf and sf
    def logchisquare_cdf(self, ctx, x, n, cdf=True, **kwargs):
        z = ctx.exp(x)
        t = ctx.chi2_cdf(z, n)
        return t

    def logchisquare_sf(self, ctx, x, n, cdf=False, **kwargs):
        z = ctx.exp(x)
        t = ctx.chi2_cdf(z, n, False)
        return t

# 5.3.12 Distribution of the logarithm of a 𝜒2 random variable, qtf and isf
    def logchisquare_qtf(self, ctx, q, n, qtf=True, **kwargs):
        z = ctx.chi2_qtf(q, n)
        x = ctx.log(z)
        return x

    def logchisquare_isf(self, ctx, q, n, qtf=False, **kwargs):
        z = ctx.chi2_qtf(q, n, False)
        x = ctx.log(z)
        return x


# 5.3.13 Gamma distribution, pdf


    def gamma_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = ctx.exp(-x/b) * ctx.power(x, a-1)
        t = ctx.gamma(a) * ctx.power(b, a)
        return s / t

# 5.3.14 Gamma distribution, cdf and sf
    def gamma_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            return ctx.real_gamma_p(a, x/b, **kwargs)
        else:
            return ctx.real_gamma_q(a, x/b, **kwargs)

# 5.3.15 Gamma distribution, qtf and isf
    def gamma_qtf(self, ctx, q, a, b, qtf=True, **kwargs):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return b * ctx.real_gamma_p_inv(a, q, **kwargs)
        else:
            return b * ctx.real_gamma_q_inv(a, q, **kwargs)



# 5.3.16 Hypoexponential distribution, pdf
    def hypoexp_pdf(self, ctx, x, n, l):
        x = ctx.t(x)
#        l = [1,2,3,4]
#        AllDistinct=True
#        AllEqual=False
        l = [2,2,2,2]
        AllDistinct=False
        AllEqual=True
        if AllEqual:
            return l[0]**n * x**(n-1)*ctx.exp(-l[0]*x)/ctx.factorial(n-1)
        if AllDistinct:
            p = [1, 1, 1, 1]
            for i in range(n):
                for j in range(n):
                    if i!= j:
                        p[i] = p[i] * (1-l[i]/l[j])
            res1 = 0
            for i in range(n):
                res1 += l[i] * ctx.exp(-l[i]*x) / p[i]
            return res1


# 5.3.17 Hypoexponential distribution, cdf and sf
    def hypoexp_cdf(self, ctx, x, n, l, cdf=True):
        x = ctx.t(x)
#        l = [1,2,3,4]
#        AllDistinct=True
#        AllEqual=False
        l = [2,2,2,2]
        AllDistinct=False
        AllEqual=True
        if AllEqual:
            cdf = ctx.gamma_p(n, l[0]*x)
            print("cdf:", cdf)
            sf = ctx.gamma_q(n, l[0]*x)
            print(" sf:", sf)
        if AllDistinct:
            p = [1, 1, 1, 1]
            for i in range(n):
                for j in range(n):
                    if i!= j:
                        p[i] = p[i] * (1-l[i]/l[j])
            res = 0
            for i in range(n):
                res += ctx.exp(-l[i]*x) / p[i]
            if cdf: return 1-res
            else: return res
        return None

# 5.3.18 Hypoexponential distribution, qtf and isf
    def hypoexp_qtf(self, ctx, prob, a, b, qtf=True):
        return None



# 5.3.19 Inverse 𝜒2-distribution, pdf
    def invchisquared_pdf(self, ctx, x, a, b):
        return None

# 5.3.20 Inverse 𝜒2-distribution, cdf and sf
    def invchisquared_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.3.21 Inverse 𝜒2-distribution, qtf and isf
    def invchisquared_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None



# 5.3.22 Inverse Gamma distribution, pdf
    def invgamma_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        s = ctx.exp(-b/x) * ctx.power(b/x, a)
        t = x * ctx.gamma(a)
        return s / t

# 5.3.23 Inverse Gamma distribution, cdf and sf
    def invgamma_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            return ctx.real_gamma_q(a, b/x, **kwargs)
        else:
            return ctx.real_gamma_p(a, b/x, **kwargs)

# 5.3.24 Inverse Gamma distribution, qtf and isf
    def invgamma_qtf(self, ctx, q, a, b, qtf=True, **kwargs):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return b / ctx.real_gamma_q_inv(a, q, **kwargs)
        else:
            return b / ctx.real_gamma_p_inv(a, q, **kwargs)


# 5.3.25 Maxwell distribution, pdf
    def maxwell_pdf(self, ctx, x, b):
        x = ctx.t(x)
        b = ctx.t(b)
        s = ctx.sqrt(2 / ctx.pi)
        t = (x*x) / (b*b*b)
        u = ctx.exp(-(x*x)/(2*b*b))
        return s * t * u

# 5.3.26 Maxwell distribution, cdf and sf
    def maxwell_cdf(self, ctx, x, b, cdf=True, **kwargs):
        x = ctx.t(x)
        b = ctx.t(b)
        n = ctx.t("1.5")
        t = (x*x)/(2*b*b)
        if cdf:
            return ctx.real_gamma_p(n, t, **kwargs)
        else:
            return ctx.real_gamma_q(n, t, **kwargs)

# 5.3.27 Maxwell distribution, qtf and isf
    def maxwell_qtf(self, ctx, q, b, qtf=True, **kwargs):
        q = ctx.t(q)
        b = ctx.t(b)
        n = ctx.t("1.5")
        if qtf:
            return b * ctx.sqrt(2*ctx.real_gamma_p_inv(n, q, **kwargs))
        else:
            return b * ctx.sqrt(2*ctx.real_gamma_q_inv(n, q, **kwargs))


# 5.3.28 Lindley distribution, pdf
    def lindley_pdf(self, ctx, x, b):
        x = ctx.t(x)
        b = ctx.t(b)
        return None

# 5.3.29 Lindley distribution, cdf and sf
    def lindley_cdf(self, ctx, x, b, cdf=True, **kwargs):
        x = ctx.t(x)
        b = ctx.t(b)
        if cdf:
            return None
        else:
            return None

# 5.3.30 Lindley distribution, qtf and isf
    def lindley_qtf(self, ctx, q, b, qtf=True, **kwargs):
        q = ctx.t(q)
        b = ctx.t(b)
        if qtf:
            return None
        else:
            return None


# 5.3.31 Nakagami distribution, pdf
    def nakagami_pdf(self, ctx, x, m, w):
        x = ctx.t(x)
        m = ctx.t(m)
        w = ctx.t(w)
        s = ctx.exp(-m*x*x/w) * ctx.power(2*m, m) * ctx.power(x, 2*m-1)
        t = ctx.gamma(m) * ctx.power(w, m)
        return s / t

# 5.3.32 Nakagami distribution, cdf and sf
    def nakagami_cdf(self, ctx, x, m, w, cdf=True, **kwargs):
        x = ctx.t(x)
        m = ctx.t(m)
        w = ctx.t(w)
        if cdf:
            return ctx.real_gamma_p(m, m*x*x/w, **kwargs)
        else:
            return ctx.real_gamma_q(m, m*x*x/w, **kwargs)

# 5.3.33 Nakagami distribution, qtf and isf
    def nakagami_qtf(self, ctx, q, m, w, qtf=True, **kwargs):
        q = ctx.t(q)
        m = ctx.t(m)
        w = ctx.t(w)
        if qtf:
            return ctx.sqrt((w/m) * ctx.real_gamma_p_inv(m, q, **kwargs))
        else:
            return ctx.sqrt((w/m) * ctx.real_gamma_q_inv(m, q, **kwargs))


# 5.3.34 Skew exponential power distribution, pdf
    def skew_exp_power_pdf(self, ctx, x, m, w):
        return None

# 5.3.35 Skew exponential power distribution, cdf and sf
    def skew_exp_power_cdf(self, ctx, x, m, w, cdf=True, **kwargs):
        return None

# 5.3.36 Skew exponential power distribution, qtf and isf
    def skew_exp_power_qtf(self, ctx, prob, m, w, qtf=True, **kwargs):
        return None


# 5.3.37 Stacy (generalized gamma) distribution, pdf
    def stacy_pdf(self, ctx, x, m, w):
        return None

# 5.3.38 Stacy (generalized gamma) distribution, cdf and sf
    def stacy_cdf(self, ctx, x, m, w, cdf=True, **kwargs):
        return None

# 5.3.39 Stacy (generalized gamma) distribution, qtf and isf
    def stacy_qtf(self, ctx, prob, m, w, qtf=True, **kwargs):
        return None


# %%%  5.4 Closed form distributions, based on the incomplete beta function


# 5.4.1 Beta distribution, pdf
    def beta_pdf(self, ctx, x, a, b):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        return ctx.real_ibeta_derivative(a, b, x)

# 5.4.2 Beta distribution, cdf and sf
    def beta_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        if cdf:
            return ctx.real_ibeta(a, b, x, **kwargs)
        else:
            return ctx.real_ibetac(a, b, x, **kwargs)

# 5.4.3 Beta distribution, qtf and isf
    def beta_qtf(self, ctx, q, a, b, qtf=True, **kwargs):
        q = ctx.t(q)
        a = ctx.t(a)
        b = ctx.t(b)
        if qtf:
            return ctx.real_ibeta_inv(a, b, q, **kwargs)
        else:
            return ctx.real_ibetac_inv(a, b, q, **kwargs)


# 5.4.4 Distribution of the negative logarithm of a beta variable, pdf
    def logbeta_pdf(self, ctx, x, a, b):
        z = ctx.exp(-x)
        return z * ctx.beta_pdf(z, a, b)

# 5.4.5 Distribution of the negative logarithm of a beta variable, cdf and sf
    def logbeta_cdf(self, ctx, x, a, b, cdf, **kwargs):
        z = ctx.exp(-x)
        return ctx.beta_cdf(z, a, b, not cdf)

    def logbeta_sf(self, ctx, x, a, b, cdf, **kwargs):
        z = ctx.exp(-x)
        return ctx.beta_cdf(z, a, b, not cdf)

# 5.4.6 Distribution of the negative logarithm of a beta variable, qtf and isf
    def logbeta_qtf(self, ctx, q, a, b, qtf, **kwargs):
        z = ctx.beta_qtf(q, a, b, not qtf)
        x = -ctx.log(z)
        return x

    def logbeta_isf(self, ctx, q, a, b, qtf, **kwargs):
        z = ctx.beta_qtf(q, a, b, not qtf)
        x = -ctx.log(z)
        return x


# 5.4.7 Beta-prime distribution, pdf
    def beta_prime_pdf(self, ctx, x, a, b):
        return None

# 5.4.8 Beta-prime distribution, cdf and sf
    def beta_prime_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.9 Beta-prime distribution, qtf and isf
    def beta_prime_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None


# 5.4.10 Generalized Beta (Type 1) distribution, pdf
    def genbeta1_pdf(self, ctx, x, a, b):
        return None

# 5.4.11 Generalized Beta (Type 1) distribution, cdf and sf
    def genbeta1_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.12 Generalized Beta (Type 1) distribution, qtf and isf
    def genbeta1_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None


# 5.4.13 Generalized Beta (Type 2) distribution, pdf
    def genbeta2_pdf(self, ctx, x, a, b):
        return None

# 5.4.14 Generalized Beta (Type 2) distribution, cdf and sf
    def genbeta2_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.15 Generalized Beta (Type 2) distribution, qtf and isf
    def genbeta2_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None


# 5.4.16 Generalized logistic distribution, pdf
    def genlogistic_pdf(self, ctx, x, a, b):
        return None

# 5.4.17 Generalized logistic distribution, cdf and sf
    def genlogistic_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.18 Generalized logistic distribution, qtf and isf
    def genlogistic_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None


# 5.4.19 Generalized beta-exponential distribution, pdf
    def gen_beta_exp_pdf(self, ctx, x, a, b):
        return None

# 5.4.20 Generalized beta-exponential distribution, cdf and sf
    def gen_beta_exp_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.21 Generalized beta-exponential distribution, qtf and isf
    def gen_beta_exp_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None


# 5.4.22 Feller-Pareto distribution, pdf
    def feller_pareto_pdf(self, ctx, x, a, b):
        return None

# 5.4.23 Feller-Pareto distribution, cdf and sf
    def feller_pareto_cdf(self, ctx, x, a, b, cdf=True, **kwargs):
        return None

# 5.4.24 Feller-Pareto distribution, qtf and isf
    def feller_pareto_qtf(self, ctx, prob, a, b, qtf=True, **kwargs):
        return None




# 5.4.25 Fisher F distribution, pdf
    def fisher_f_pdf(self, ctx, x, m, n, **kwargs):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        res = m**(m/2) * n**(n/2) * x**((m-2)/2) * (n+m*x)**(-(m+n)/2)
        res = res / ctx.exp(ctx.ln(ctx.beta(m/2, n/2)))
        return res

# 5.4.26 Fisher F distribution, cdf and sf
    def fisher_f_cdf(self, ctx, x, m, n, cdf, **kwargs):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        v1x = m * x
        if cdf:
            if (v1x > n):
                cm = ctx.real_ibetac(n/2, m/2, n / (n + v1x))
            else:
                cm = ctx.real_ibeta(m/2, n/2, v1x / (n + v1x))
            return cm
        else:
            if (v1x > n):
                cn = ctx.real_ibeta(n/2, m/2, n / (n + v1x))
            else:
                cn = ctx.real_ibetac(m/2, n/2, v1x / (n + v1x))
            return cn

# 5.4.27 Fisher F distribution, qtf and isf
    def fisher_f_qtf(self, ctx, q, m, n, qtf, **kwargs):
        q = ctx.t(q)
        m = ctx.t(m)
        n = ctx.t(n)
        if qtf:
            x = ctx.real_ibeta_inv(m/2, n/2, q)
        else:
            x = ctx.real_ibetac_inv(m/2, n/2, q)
        return n * x / (m * (1-x))


# 5.4.28 Fisher z distribution, pdf
    def fisher_z_pdf(self, ctx, x, m, n, mode=0):
        x = x - mode
        z = ctx.exp(2*x)
        return 2 * z * ctx.fisher_f_pdf(z, m, n)

# 5.4.29 Fisher z distribution, cdf and sf
    def fisher_z_cdf(self, ctx, x, m, n, mode=0):
        x = x - mode
        z = ctx.exp(2*x)
        return ctx.fisher_f_cdf(z, m, n)

    def fisher_z_sf(self, ctx, x, m, n, mode=0):
        x = x - mode
        z = ctx.exp(-2*x)
        return ctx.fisher_f_cdf(z, n, m)

# 5.4.30 Fisher z distribution, qtf and isf
    def fisher_z_qtf(self, ctx, q, m, n, mode=0):
        z = ctx.fisher_f_qtf(q, m, n)
        x = 0.5 * ctx.log(z) + mode
        return x

    def fisher_z_isf(self, ctx, q, m, n, mode=0):
        z = ctx.fisher_f_qtf(q, n, m)
        x = -0.5 * ctx.log(z) + mode
        return x


# 5.4.31 Student t distribution, pdf
    def student_t_pdf(self, ctx, x, n, **kwargs):
        x = ctx.t(x)
        n = ctx.t(n)
        half = ctx.t("0.5")
        C = (1 + (x * x) / (n * 1))
        h = ctx.loggamma((n + 1) / 2) - ctx.loggamma(n / 2)
        h = ctx.exp(h)
        h = h / ctx.sqrt(ctx.pi) / ctx.sqrt(n)
        res = h * (C ** (-((n / 2) + (half))))
        return res

# 5.4.32 Student t distribution, cdf and sf
    def student_t_cdf(self, ctx, x, n, cdf, **kwargs):
        x = ctx.t(x)
        n = ctx.t(n)
        half = ctx.t("0.5")
        x2 = x * x
        if (n > 2 * x2):
            z = x2 / (n + x2)
            p = ctx.real_ibetac(half, n / 2, z) / 2
        else:
            z = n / (n + x2)
            p = ctx.real_ibeta(n / 2, half, z) / 2
        if cdf:
            if (x > 0):
                return 1 - p
            else:
                return p
            # return 1-p if (x > 0) else p
        else:
            if (x > 0):
                return p
            else:
                return 1 - p
            # return p if (x > 0) else 1 - p

# 5.4.33 Student t distribution, qtf and isf
    def student_t_qtf(self, ctx, q, n, qtf, **kwargs):
        q = ctx.t(q)
        n = ctx.t(n)
        half = ctx.t("0.5")
        sign = 1
        if q < half:
            sign = -1
        pq = q
        if q > half:
            pq = 1-q
        x = ctx.real_ibeta_inv(n / 2, half, 2*pq)
        y = 1 - x
        t = sign * ctx.sqrt(n * y/x)
        if qtf:
            return t
        else:
            return -t



# %% 6 Advanced continuous distribution functions




# %%% 6.3 Noncentral distribution functions


# 6.3.1 Noncentral chi^2-distribution, pdf


    def chi2_nc_pdf(self, ctx, x, n, lambda1, method='default'):
        x = ctx.t(x)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        if method == 'default':
            return self.chi2_nc_hyper_pdf(ctx, n, x, lambda1)
        if method == 'bessel':
            return self.chi2_nc_bessel_pdf(ctx, n, x, lambda1)
        if method == 'hyper':
            return self.chi2_nc_hyper_pdf(ctx, n, x, lambda1)

    def chi2_nc_bessel_pdf(self, ctx, k, x, l):
        t1 = ctx.exp(-(x+l)/2)
        t2 = (x/l)**(k/4-1/2)
        t3 = ctx.besseli(k/2-1, ctx.sqrt(l*x))
        return t1 * t2 * t3 / 2

    def chi2_nc_hyper_pdf(self, ctx, nu, x, l):
        dens0 = ctx.chi2_pdf(x, nu)
        hyper = ctx.hyp0f1(nu/2, l * x / 4)
        result = dens0 * ctx.exp(-l / 2) * hyper
        return result


# 6.3.2 Noncentral chi^2-distribution, cdf


    def chi2_nc_cdf(self, ctx, x, n, lambda1, cdf, method):
        x = ctx.t(x)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        if method == 'default':
            if cdf:
                return ctxSeries().non_central_chi_square_cdf(ctx, x, n, lambda1)
            else:
                return ctxSeries().non_central_chi_square_cdf_complement(ctx, x, n, lambda1)
        if method == 'benton':
            if cdf:
                return ctxSeries().non_central_chi_square_cdf(ctx, x, n, lambda1)
            else:
                return ctxSeries().non_central_chi_square_cdf_complement(ctx, x, n, lambda1)
        if method == 'chou':
            if cdf:
                return ctxIntegral().chi2nc_cdf(ctx, x, n, lambda1)
            else:
                return 1-ctxIntegral().chi2nc_cdf(ctx, x, n, lambda1)
        if method == 'cohen':
            if cdf:
                return self.chi2_nc_cohen_cdf(ctx, x, n, lambda1)
            else:
                return 1-self.chi2_nc_cohen_cdf(ctx, x, n, lambda1)
        if method == 'ecf':
            L1, R1 = self.chi2_nc_ecf(ctx, x, n, lambda1, 10, False)
            if cdf:
                return L1
            else:
                return R1
        if method == 'spa':
            L1, R1 = self.chi2_nc_spa(ctx, x, n, lambda1, 10, False)
            if cdf:
                return L1
            else:
                return R1
        if method == 'penev':
            L1, R1 = self.cdisn_penev(ctx, x, n, lambda1)
            if cdf:
                return L1
            else:
                return R1


# 6.3.3 Non-central 𝜒2-distribution, qtf and isf


    def chi2_nc_qtf(self, ctx, q, n, lambda1, qtf=True, method='default'):
        q = ctx.t(q)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        return None
        if method == 'default':
            if qtf:
                return ctxSeries().non_central_chi_square_cdf(ctx, q, n, lambda1)
            else:
                return ctxSeries().non_central_chi_square_cdf_complement(ctx, q, n, lambda1)
        if method == 'patnaik':
            if qtf:
                return ctxSeries().non_central_chi_square_cdf(ctx, q, n, lambda1)
            else:
                return ctxSeries().non_central_chi_square_cdf_complement(ctx, q, n, lambda1)

        raise Exception("NOT IMPLEMENTED")


# 6.3.4 Non-central 𝜒2-distribution: confidence limit for lambda1


    def chi2_nc_cl(self, ctx, alpha, beta, n, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.5 Generalized Marcum 𝑄 function


    def marcumq(self, ctx, alpha, beta, n):
        raise Exception("NOT IMPLEMENTED")


# 6.3.6 Noncentral Chi-distribution, pdf


    def chi_nc_pdf(self, ctx, x, n, lambda1, method='default'):
        raise Exception("NOT IMPLEMENTED")

# 6.3.7 Noncentral Chi-distribution, cdf and sf
    def chi_nc_cdf(self, ctx, x, n, lambda1, cdf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")

# 6.3.8 Noncentral Chi-distribution, qtf and isf
    def chi_nc_qtf(self, ctx, q, n, lambda1, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.9 Rice distribution, pdf


    def rice_pdf(self, ctx, x, nu, sigma, method='default'):
        raise Exception("NOT IMPLEMENTED")

# 6.3.10 Rice distribution, cdf and sf
    def rice_cdf(self, ctx, x, nu, sigma, cdf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")

# 6.3.11 Rice distribution, qtf and isf
    def rice_qtf(self, ctx, q, nu, sigma, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.12 Non-central Student 𝑡 distribution: pdf


    def student_t_nc_pdf(self, ctx, x, n, delta, method='default'):
        if method == 'default':
            return self.student_t_nc_hyper_pdf(ctx, x, n, delta)
        if method == 'hyper':
            return self.student_t_nc_hyper_pdf(ctx, x, n, delta)
        if method == 'chou':
            return self.student_t_nc_chou_pdf(ctx, x, n, delta)

    def student_t_nc_hyper_pdf(self, ctx, x, n, delta):
        m = n / 2
        a = n + x * x
        d2 = delta * delta
        y2 = d2 * x * x / (2 * a)
        K1 = (n ** m * ctx.gamma(n + 1) * ctx.exp(-0.5 * d2)) / \
            (2 ** n * a ** m * ctx.gamma(m))
        LSide = (ctx.sqrt(2) * delta * x * ctx.hyp1f1(m +
                 1, 3 / 2, y2)) / (a * ctx.gamma(m + 0.5))
        RSide = ctx.hyp1f1(m + 0.5, 0.5, y2) / (ctx.sqrt(a) * ctx.gamma(m + 1))
        # needs check for catastrophic cancellation
        sum = LSide + RSide
        result = K1 * (sum)
        return result

    def Tdisnc_pdf_(self, ctx, x, n, delta, y):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        y = ctx.t(y)
        t1 = ctx.ndens(x * ctx.sqrt(y/n) - delta)
        t2 = ctx.chi2_pdf(y, n) * ctx.sqrt(y/n)
        res = t1 * t2
        return res

    def student_t_nc_chou_pdf(self, ctx, x, n, delta):
        res = 1
        res = ctx.quad(lambda y: self.Tdisnc_pdf_(
            ctx, x, n, delta, y), [0, ctx.inf])
        #plot(lambda y: self.Tdisnc_pdf_(x, n, delta, y), [0, 30])
        return res


# 6.3.13 Non-central Student 𝑡 distribution: cdf and sf


    def student_t_nc_cdf(self, ctx, x, n, delta, cdf=True, method='default'):
        if method == 'default':
            if cdf:
                return self.tdisnc_cdf(ctx, x, n, delta)
            else:
                return self.tdisnc_sf(ctx, x, n, delta)
        if method == 'benton':
            if cdf:
                return ctxSeries().non_central_t_cdf(ctx, n, delta, x)
            else:
                return ctxSeries().non_central_t_cdf_complement(ctx, n, delta, x)
        if method == 'witkovsky':
            if cdf:
                return self.tdisnc_cdf(ctx, x, n, delta)
            else:
                return self.tdisnc_sf(ctx, x, n, delta)
        if method == 'owen':
            if cdf:
                return self.student_t_nc_owen_cdf(ctx, x, n, delta)
            else:
                return 1-self.student_t_nc_owen_cdf(ctx, x, n, delta)
        if method == 'broda':
            L1, R1 = self.student_t_nc_broda_cdf(ctx, x, n, delta)
            if cdf:
                return L1
            else:
                return R1

    def tdisnc_cdf(self, ctx, x, n, delta):
        res = 1
        res = ctx.quad(lambda y: self.tdisnc_cdf_(
            ctx, x, n, delta, y), [0, ctx.inf])
        #plot(lambda y: self.tdisnc_cdf_(x, n, delta, y), [0, 260])
        return res

    def tdisnc_cdf_(self, ctx, x, n, delta, y):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        y = ctx.t(y)
        t1 = ctx.ndis(x * ctx.sqrt(y/n) - delta)
        t2 = ctx.chi2_pdf(y, n)
        res = t1 * t2
        return res

    # Noncentral t-distribution, sf (Witkovsky2013)

    def tdisnc_sf_(self, ctx, x, n, delta, y):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        y = ctx.t(y)
        #t1 = 1 -  Ndis(x * mp.sqrt(y/n) -delta)
        t1 = ctx.ndis(-x * ctx.sqrt(y/n) + delta)
        t2 = ctx.chi2_pdf(y, n)
        res = t1 * t2
        return res

    def tdisnc_sf(self, ctx, x, n, delta):
        res = 1
        res = ctx.quad(lambda y: self.tdisnc_sf_(
            ctx, x, n, delta, y), [0, ctx.inf])
        #plot(lambda y: self.tdisnc_sf_(x, n, delta, y), [0, 260])
        return res


# 6.3.14 Non-central Student 𝑡 distribution, qtf and isf


    def student_t_nc_qtf(self, ctx, q, n, delta, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.15 Non-central Student 𝑡 distribution,: confidence limit for 𝛿


    def student_t_nc_cl(self, ctx, alpha, beta, n, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.16 Non-central Pearson’s rho distribution: pdf


    def pearson_rho_nc_pdf(self, ctx, r, N, rho, method='default'):
        if method == 'default':
            return self.pearson_rho_nc_pdf2(ctx, r, N, rho)

    def pearson_rho_nc_pdf2(self, ctx, r, n, rho):
        r2 = r * r
        Rho2 = rho * rho
        x = r * rho
        w = 0.5 * (1 + x)
        A2 = 1 - Rho2
        a = ctx.sqrt(A2)
        c2 = 1 - r2
        C = ctx.sqrt(c2)
        k1 = ((n - 2) / ctx.sqrt(2 * ctx.pi)) * \
            ctx.exp(ctx.loggamma(n - 1) - ctx.loggamma(n - 0.5))
        ACTerm = ctx.exp(ctx.log(a) * (n - 1) + ctx.log(C) *
                         (n - 4) + ctx.log(1 - x) * (1.5 - n))
        t = ctx.hyp2f1(0.5, 0.5, n - 0.5, w)
        density = k1 * ACTerm * t
        return density


# 6.3.17 Non-central Pearson’s rho distribution: cdf and sf


    def pearson_rho_nc_cdf(self, ctx, r, N, rho, cdf=True, method='default'):
        if method == 'guenther':
            L, R = ctxSeries().pearson_rho_nc_gt_cdf(ctx, r, N, rho)
            if cdf:
                return L
            else:
                return R
        if method == 'hotelling':
            L, R = ctxSeries().pearson_rho_nc_ht_cdf(ctx, r, N, rho)
            if cdf:
                return L
            else:
                return R


# 6.3.18 Non-central Pearson’s rho distribution: qtf and isf


    def pearson_rho_nc_qtf(self, ctx, q, N, rho, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.19 Non-central Pearson’s rho distribution: confidence limit for 𝜌


    def pearson_rho_nc_cl(self, ctx, alpha, beta, N, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.20 Pearson’s rho: unbiased estimate of rho
    def pearson_rho_nc_unbiased_estimate(self, ctx, r, N):
        # see Anderson 2nd edition, page 119
        r = self.t(r)
        N = self.t(N)
        n = N-1
        res = r * self.hyp2f1(0.5, 0.5, 0.5*(n-1), 1-r*r)
        return res


# 6.3.21 Non-central Fisher 𝐹 distribution: pdf
    def fisher_f_nc_pdf(self, ctx, x, m, n, lambda1, method='default'):
        if method == 'default':
            return self.fisher_f_nc_hyper_pdf(ctx, x, m, n, lambda1)
        if method == 'hyper':
            return self.fisher_f_nc_hyper_pdf(ctx, x, m, n, lambda1)
        if method == 'chou':
            return self.fisher_f_nc_chou_pdf(ctx, x, m, n, lambda1)

    def fisher_f_nc_hyper_pdf(self, ctx, x, m, n, l):
        dens0 = ctx.fisher_f_pdf(x, m, n)
        hyper = ctx.hyp1f1(0.5 * (m + n), 0.5 * m,
                           (m * x * l) / (2 * (n + m * x)))
        result = dens0 * ctx.exp(-l / 2) * hyper
        return result

    # Singly Noncentral F-distribution, pdf (Chou1985)
    def fdisnc_pdf_(self, ctx, x, m, n, lambda1, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        t1 = ctx.chi2_nc_0f1_nc_pdf(m*x*y/n, m, lambda1)
        t2 = ctx.chi2_pdf(y, n)
        res = (y * m/n) * t1 * t2
        return res

    def fisher_f_nc_chou_pdf(self, ctx, x, m, n, lambda1):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc_pdf_(
            ctx, x, m, n, lambda1, y), [0, ctx.inf])
        #plot(lambda y: self.fdisnc_pdf_(x, m, n, lambda1, y), [10, 240])
        return res


# 6.3.22 Non-central Fisher 𝐹 distribution: cdf and sf
    def fisher_f_nc_cdf(self, ctx, x, m, n, lambda1, cdf=True, method='default'):
        if method == 'default':
            if cdf:
                return ctxSeries().non_central_f_cdf(ctx, x, m, n, lambda1)
            else:
                return ctxSeries().non_central_f_cdf_complement(ctx, x, m, n, lambda1)
        if method == 'benton':
            return ctxSeries().fisher_f_nc_benton_cdf_sf(ctx, x, m, n, lambda1, cdf)

##            if cdf:
##                return ctxSeries().non_central_f_cdf(ctx, x, m, n, lambda1)
##            else:
##                return ctxSeries().non_central_f_cdf_complement(ctx, x, m, n, lambda1)
        if method == 'chou':
            if cdf:
                return self.fdisnc_cdf2(ctx, x, m, n, lambda1)
            else:
                return self.fdisnc_sf(ctx, x, m, n, lambda1)
        if method == 'seber':
            if cdf:
                return self.fisher_f_nc_seber_cdf(ctx, x, m, n, lambda1)
            else:
                return 1-self.fisher_f_nc_seber_cdf(ctx, x, m, n, lambda1)
#        if method=='ecf':
#            L1, R1 = self.chi2_nc_ecf(ctx, x, n, lambda1, 10, False)
#            if cdf: return L1
#            else:  return R1
        if method == 'spa':
            L1, R1 = self.fisher_f_nc2_spa(ctx, x,  m, n, lambda1, 0)
            if cdf:
                return L1
            else:
                return R1

    def fdisnc_cdf_(self, ctx, x, m, n, lambda1, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        t1 = ctx.int_df_chi2_nc_cdf(m*x*y/n, m, lambda1)
        t2 = ctx.chi2_pdf(y, n)
        res = t1 * t2
        return res

    def fdisnc_cdf(self, ctx, x, m, n, lambda1):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc_cdf_(
            ctx, x, m, n, lambda1, y), [0, ctx.inf])
        #plot(lambda y: self.fdisnc_cdf_(x, m, n, lambda1, y), [0, 50])
        return res

    # Noncentral F-distribution, cdf2
    def fdisnc_cdf2_(self, ctx, x, m, n, lambda1, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        #t1 = ctx.chi2_nc_0f1_nc_pdf(x*y*m/n, m, lambda1)
        t1 = ctx.chi2_nc_pdf(x*y*m/n, m, lambda1)
        t2 = ctx.chi2_cdf(y, n, False)
        res = t1 * t2
        res = res * x * m / n
        return res

    def fdisnc_cdf2(self, ctx, x, m, n, lambda1):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc_cdf2_(
            ctx, x, m, n, lambda1, y), [0, ctx.inf])
        #plot(lambda y: self.fdisnc_cdf2_(x, m, n, lambda1, y), [0, 28])
        return res

    # Non-central Fisher F distribution: sf
    def fdisnc_sf_(self, ctx, x, m, n, lambda1, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        t1 = ctx.chi2_nc_pdf(x*y*m/n, m, lambda1)
        t2 = ctx.chi2_cdf(y, n)
        res = t1 * t2
        res = res * x * m / n
        return res

    def fdisnc_sf(self, ctx, x, m, n, lambda1):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc_sf_(
            ctx, x, m, n, lambda1, y), [0, ctx.inf])
        #plot(lambda y: self.fdisnc_sf_(x, m, n, lambda1, y), [0.4, 0.8])
        return res


# 6.3.23 Non-central Fisher F distribution: qtf and isf
    def fisher_f_nc_qtf(self, ctx, q, m, n, lambda1, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.24 Non-central Fisher F distribution: confidence limit for lambda1
    def fisher_f_nc_cl(self, ctx, alpha, beta, m, n, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.25 Non-central Beta distribution: pdf
    def beta_nc_pdf(self, ctx, x, a, b, lambda1, method='default'):
        raise Exception("NOT IMPLEMENTED")

    def betadens_nc(self, ctx, x, a, b, l):
        y = 1 - x
        dens0 = self.betadens(a, b, x, y)
        hyper = ctx.hyp1f1(a + b, a, x * l / 2)
        result = dens0 * ctx.exp(-l / 2) * hyper
        return result


# 6.3.26 Non-central Beta distribution: cdf and sf


    def beta_nc_cdf(self, ctx, x, a, b, lambda1, cdf=True, method='default'):
        if method == 'default':
            if cdf:
                return ctxSeries().non_central_beta_cdf(ctx, a, b, lambda1, x, 1-x)
            else:
                return ctxSeries().non_central_beta_cdf_complement(ctx, a, b, lambda1, x, 1-x)


# 6.3.27 Non-central Beta distribution: qtf and isf


    def beta_nc_qtf(self, ctx, q, a, b, lambda1, cdf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.28 Non-central Beta distribution: confidence limit for 𝜆1


    def beta_nc_cl(self, ctx, alpha, beta, a, b, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.29 Fisher’s 𝑅2 distribution: pdf


    def fisher_r2_pdf(self, ctx, x, p, N, rho2, typeI=True, method='default'):
        raise Exception("NOT IMPLEMENTED")

    def fisher_r2_pdf2(self, ctx, x, p, N, rho2):
        # see Gurland 1968
        y = 1 - x
        PP = p + 1
        NN = N + p + 1
        n1 = NN - 1
        dens0 = self.betadens(0.5 * (PP - 1), 0.5 * (NN - PP), x, y)
        print("dens0: ", dens0)
        hyper = ctx.hyp2f1(0.5 * n1, 0.5 * n1, 0.5 * (PP - 1), rho2 * x)
        print("hyper: ", hyper)
        result = dens0 * (1 - rho2) ** (n1 / 2) * hyper
        return result


# 6.3.30 Fisher’s 𝑅2 distribution: cdf and sf


    def fisher_r2_cdf(self, ctx, x, p, N, rho2, cdf, method):
        if method == 'gurland1':
            L, R = ctxSeries().fisher_r2_gd1_cdf(ctx, x, p, N, rho2)
            if cdf:
                return L
            else:
                return R
        if method == 'gurland2':
            L, R = ctxSeries().fisher_r2_gd2_cdf(ctx, x, p, N, rho2)
            if cdf:
                return L
            else:
                return R

    def fisher_r2_cdf2(self, ctx, x, p, N, rho2):
        # see Gurland 1968
        res = 1
        res = ctx.quad(lambda y: self.fisher_r2_pdf(
            ctx, y, p, N, rho2), [0, x])
        #plot(lambda y: self.fdisnc_sf_(x, m, n, lambda1, y), [0.4, 0.8])
        return res


# 6.3.31 Fisher’s 𝑅2 distribution: qtf and isf


    def fisher_r2_qtf(self, ctx, q, p, N, rho2, qtf, typeI, method):
        raise Exception("NOT IMPLEMENTED")


# 6.3.32 Fisher’s 𝑅2 distribution: confidence limit for 𝜌2


    def fisher_r2_cl(self, ctx, alpha, beta, p, N, cdfmethod):
        raise Exception("NOT IMPLEMENTED")


# 6.3.33 Fisher’s 𝑅2: unbiased estimate of rho^2


    def fisher_r2_unbiased_estimate(self, ctx, R, p, N):
        # see Anderson 2nd edition, page 147
        R = self.t(R)
        p = self.t(p)
        N = self.t(N)
        res = (N-3)*(1-R*R)/(N-p)
        res = 1 - res * self.hyp2f1(1, 1, 0.5 * (N-p+2), 1-R*R)
        return res


# 6.3.34 Doubly non-central Student 𝑡 distribution: pdf


    def student_t_nc2_pdf(self, ctx, x, n, delta, theta, method='default'):
        #print("in student_t_nc2_pdf, x:", x)
        res = self.tdisnc2_pdf(ctx, x, n, delta, theta)
        return res

    def tdisnc2_pdf_(self, ctx, x, n, delta, theta, y):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        y = ctx.t(y)
        t1 = ctx.ndens(x * ctx.sqrt(y/n) - delta)
        t2 = ctx.chi2_nc_pdf(y, n, theta) * ctx.sqrt(y/n)
        res = t1 * t2
        return res

    def tdisnc2_pdf(self, ctx, x, n, delta, theta):
        res = 1
        res = ctx.quad(lambda y: self.tdisnc2_pdf_(
            ctx, x, n, delta, theta, y), [0, ctx.inf])
        #plot(lambda y: self.tdisnc2_pdf_(x, n, delta, theta, y), [0, 260])
        return res


# 6.3.35 Doubly non-central Student 𝑡 distribution: cdf and sf


    def student_t_nc2_cdf(self, ctx, x, n, delta, theta, cdf=True, method='default'):
        res = self.tdisnc2_cdf(ctx, x, n, delta, theta)
        return res

    def tdisnc2_cdf_(self, ctx, x, n, delta, theta, y):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        y = ctx.t(y)
        t1 = ctx.ndis(x * ctx.sqrt(y/n) - delta)
        t2 = ctx.chi2_nc_pdf(y, n, theta)
        res = t1 * t2
        return res

    def tdisnc2_cdf(self, ctx, x, n, delta, theta):
        res = 1
        res = ctx.quad(lambda y: self.tdisnc2_cdf_(
            ctx, x, n, delta, theta, y), [0, ctx.inf])
        #plot(lambda y: self.tdisnc2_cdf_(x, n, delta, theta, y), [0, 260])
        return res


# 6.3.36 Doubly noncentral Student 𝑡 distribution, qtf and isf


    def student_t_nc2_qtf(self, ctx, x, n, delta, theta, qtf=True, method='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.37 Doubly noncentral Student 𝑡 distribution,: confidence limit for 𝛿


    def student_t_nc2_cl(self, ctx, alpha, beta, n, theta, cdfmethod='default'):
        raise Exception("NOT IMPLEMENTED")


# 6.3.38 Doubly non-central Fisher 𝐹 distribution: pdf


    def fisher_f_nc2_pdf(self, ctx, x, m, n, lambda1, lambda2, method='default'):
        #print("in student_t_nc2_pdf, x:", x)
        res = self.fdisnc2_pdf(ctx, x, m, n, lambda1, lambda2)
        return res

    def fdisnc2_pdf_(self, ctx, x, m, n, lambda1, lambda2, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        t1 = ctx.chi2_nc_pdf(m*x*y/n, m, lambda1)
        t2 = ctx.chi2_nc_pdf(y, n, lambda2)
        res = (y * m/n) * t1 * t2
        return res

    def fdisnc2_pdf(self, ctx, x, m, n, lambda1, lambda2):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc2_pdf_(
            ctx, x, m, n, lambda1, lambda2, y), [0, ctx.inf])
        #plot(lambda y: fdisnc2_cdf_(x, m, n, lambda1, lambda2, y), [0, 50])
        return res


# 6.3.39 Doubly non-central Fisher 𝐹 distribution: cdf and sf


    def fisher_f_nc2_cdf(self, ctx, x, m, n, lambda1, lambda2, cdf=True, method='default'):
        res = self.fdisnc2_cdf(ctx, x, m, n, lambda1, lambda2)
        return res

    # Doubly Noncentral F-distribution, cdf

    def fdisnc2_cdf_(self, ctx, x, m, n, lambda1, lambda2, y):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        y = ctx.t(y)
        t1 = ctx.chi2_nc_cohen_cdf(m*x*y/n, m, lambda1)
        t2 = ctx.chi2_nc_pdf(y, n, lambda2)
        res = t1 * t2
        return res

    def fdisnc2_cdf(self, ctx, x, m, n, lambda1, lambda2):
        res = 1
        res = ctx.quad(lambda y: self.fdisnc2_cdf_(
            ctx, x, m, n, lambda1, lambda2, y), [0, ctx.inf])
        #plot(lambda y: self.fdisnc2_cdf_(x, m, n, lambda1, lambda2, y), [0, 50])
        return res



# %%% 6.4 Distributions related to multiple comparisons of means


# 6.4.1 Normal maximum distribution, equicorrelated case: pdf
    def nmax_corr_pdf(self, ctx, x, k, rho):
        def f(y):
            a = y * ctx.sqrt(rho)
            b = ctx.sqrt(1-rho)
            z1 = (x + a)/b
            d = ctx.ndis(z1)
            d = d**(k-1)
            res = (k/b) * d * ctx.ndens(z1) * ctx.ndens(y)
            return res
        k = int(k)
        x = ctx.t(x)
        rho = ctx.t(rho)
        #res = ctx.quad(lambda y: f(y), [-ctx.inf, ctx.inf])
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])

##        ctx.plot(lambda y: f(y), [-4, 2])
        return res


    def temp2(self, ctx, z):
        #res =ctx.sign(z) * ctx.log10(1+ctx.fabs(z))
        res =ctx.log10(1+ctx.fabs(z))
        return res


    def temp3(self, ctx, z):
        #res =ctx.sign(z) * ctx.log10(1+ctx.fabs(z))
        res1 =ctx.log10(1+ctx.fabs(z))
        if res1<0.1:
            res2 =ctx.exp(1+ctx.fabs(res1))
        else: res2 = res1
        return res2


# 6.4.2 Normal maximum distribution, equicorrelated case:: cdf and sf
    def nmax_corr_cdf(self, ctx, x, k, rho):
        def f(y):
            a = y * ctx.sqrt(rho)
            b = ctx.sqrt(1-rho)
            z1 = (x + a)/b
            d = ctx.ndis(z1)
            d = d**k
            d = d * ctx.ndens(y)
            return d
        k = int(k)
        x = ctx.t(x)
        rho = ctx.t(rho)
        res = 1
        #res = ctx.quad(lambda y: f(y), [-ctx.inf, ctx.inf])
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])

        #ctx.plot(lambda y: f(y), [-3, 3])
        #n = 10
        #ctx.plot(lambda y:  self.temp2(ctx, ctx.diff(lambda y: f(y), y, n)), [-10, 10], points=400)
        #ctx.plot(lambda y:  self.temp3(ctx, ctx.diff(lambda y: f(y), y, n)), [-10, 20], points=400)
        #print("x:", x, "k:", k, "rho:", rho, "n:", n)
        return res


# 6.4.3 Normal maximum distribution, equicorrelated case: qtf and isf
    def nmax_corr_qtf(self, ctx, q, k, rho, qtf=True):
        return None


# 6.4.4 Normal maximum distribution, negative rho: cdf and sf
    def nmax_corr_negative_rho_cdf(self, ctx, x, k, rho):
        def f(y):
            #print("y: ", y)
            if (ctx.fabs(y) > 100):
                return ctx.t(0)
            else:
                #print("y: ", y)
                a = y * ctx.sqrt(rho)
                b = ctx.sqrt(1-rho)
                z1 = (x - a)/b
                d = ctx.ndis(z1)
                #d = ctx.cplxndis(z1)
                d = d**k
                d = d * ctx.ndens(y)
                d = ctx.re(d)
                #print("d: ", d)
                return d
        k = int(k)
        x = ctx.t(x)
        rho = ctx.t(rho)
        res = 1
        #res = ctx.quadsubdiv(lambda y: f(y), [-12, 12])
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])

        #ctx.plot(lambda y: f(y), [-12, 12])
        return res


# 6.4.5 Normal maximum modulus distribution, equicorrelated case: pdf
    def nmm_corr_pdf(self, ctx, x, k, rho):
        def f(y):
            a = y * ctx.sqrt(abs(rho))
            b = ctx.sqrt(1-rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**(k-1)
            res = (k/b) * d * (ctx.ndens(z1) + ctx.ndens(z2)) * ctx.ndens(y)
            return res
        k = int(k)
        x = ctx.t(x)
        rho = ctx.t(rho)
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        ##ctx.plot(lambda y: f(y), [-6, 6])
        return res


# 6.4.6 Normal maximum modulus distribution, equicorrelated case: cdf and sf
    def nmm_corr_cdf(self, ctx, x, k, rho):
        def f(y):
            a = y * ctx.sqrt(rho)
            b = ctx.sqrt(1-rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**k
            d = d * ctx.ndens(y)
            return d
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        ##ctx.plot(lambda y: f(y), [-6, 6])
        return res


# 6.4.12 Normal maximum modulus distribution, equicorrelated case: qtf and isf
    def nmm_corr_qtf(self, ctx, q, k, rho, qtf=True):
        return None


# 6.4.11 Normal maximum modulus distribution, negative rho: cdf and sf
    def nmm_corr_negative_rho_cdf(self, ctx, x, k, rho):
        #print("In nmm_corr_negative_rho_cdf")
        def f(y):
            a = y * ctx.sqrt((rho))
            b = ctx.sqrt(1-rho)
            z1 = (x + a)/b
            z2 = (-x + a)/b
            d = ctx.ndis(z1) - ctx.ndis(z2)
            d = d**k
            d = d * ctx.ndens(y)
            return ctx.re(d)
            #return d
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-26, 26])
        ##ctx.plot(lambda y: f(y), [-10, 10])
        return res


# 6.4.13 Normal range distribution: pdf
    def nrange_pdf(self, ctx, x, k):
        def f(y):
            d1 = ctx.ndis(y)
            d2 = ctx.ndis(y-x)
            d = k * (k-1) * ((d1-d2)**(k-2))
            d = d * ctx.ndens(y)*ctx.ndens(y-x)
            return d
        k = int(k)
        x = ctx.t(x)
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        ##ctx.plot(lambda y: f(y), [-1, 5])
        return res


# 6.4.14 Normal range distribution: cdf and sf
    def nrange_cdf(self, ctx, x, k):
        def f(y):
            d1 = ctx.ndis(y)
            d2 = ctx.ndis(y-x)
            d = k * ((d1-d2)**(k-1))
            d = d * ctx.ndens(y)
            return d
        k = int(k)
        x = ctx.t(x)
        res = 1
        res = ctx.quadsubdiv(lambda y: f(y), [-ctx.inf, ctx.inf])
        ##ctx.plot(lambda y: f(y), [-2, 4])
        return res


# 6.4.15 Normal range distribution: qtf and isf
    def nrange_qtf(self, ctx, q, k, qtf=True):
        return None


    # density of chi
    def chidens(self, ctx, x, n):
        x = ctx.t(x)
        n = ctx.t(n)
        t1 = n**(n/2) * x**(n-1) * ctx.exp(-n*x*x/2)
        t2 = 2**((n-1)/2) * ctx.gamma(n/2)
        res = t1/t2
        res = res * ctx.sqrt(2)
        return res


# 6.4.16 Studentized maximum distribution: pdf
    def smax_pdf(self, ctx, x, k, n):
        def f(y): return ctx.nmax_pdf(x*y, k) * self.chidens(ctx, y, n) * y
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        #ctx.plot(lambda y: f(y), [0, 3])
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


# 6.4.17 Studentized maximum distribution: cdf and sf
    def smax_cdf(self, ctx, x, k, n):
        def f(y):
##            res = ctx.nmax_cdf(x*y, k) * ctx.sqrt(n) * \
##                ctx.chi_pdf(ctx.sqrt(n)*y, n)
            res = ctx.nmax_cdf(x*y, k) * self.chidens(ctx, y, n)

            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        ctx.plot(lambda y: f(y), [0, 3])
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


# 6.4.18 Studentized maximum distribution: qtf and isf
    def smax_qtf(self, ctx, q, k, n, qtf=True):
        return None


# 6.4.19 Studentized maximum modulus distribution: pdf
    def smm_pdf(self, ctx, x, k, n):
        def f(y):
            res = ctx.nmm_pdf(x*y, k) * self.chidens(ctx, y, n) * y
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.20 Studentized maximum modulus distribution: cdf and sf
    def smm_cdf(self, ctx, x, k, n):
        def f(y):
            res = ctx.nmm_cdf(x*y, k) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.21 Studentized maximum modulus distribution: qtf and isf
    def smm_qtf(self, ctx, q, k, n, qtf=True):
        return None


# 6.4.22 Dunnett’s t-distribution, 1-sided: pdf
    def dunnett1_pdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmax_corr_pdf(x*y, k, rho) * self.chidens(ctx, y, n) * y
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        #ctx.plot(lambda y: f(y), [0, 3])
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


# 6.4.23 Dunnett’s t-distribution, 1-sided: cdf and sf
    def dunnett1_cdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmax_corr_cdf(x*y, k, rho) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        #ctx.plot(lambda y: f(y), [0, 3])
        return ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])


# 6.4.24 Dunnett’s t-distribution, 1-sided: qtf and isf
    def dunnett1_qtf(self, ctx, q, k, n, rho, qtf=True):
        return None


# 6.4.25 Dunnett’s t-distribution, 2-sided: pdf
    def dunnett2_pdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmm_corr_pdf(x*y, k, rho) * self.chidens(ctx, y, n) * y
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.26 Dunnett’s t-distribution, 2-sided: cdf and sf
    def dunnett2_cdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmm_corr_cdf(x*y, k, rho) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.27 Dunnett’s t-distribution, 2-sided: qtf and isf
    def dunnett2_qtf(self, ctx, q, k, n, rho, qtf=True):
        return None


# 6.4.26 Nelson’s t-distribution, 2-sided: cdf and sf
    def nelson2_cdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmm_corr_negative_rho_cdf(
                x*y, k, rho) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.26 Nelson’s t-distribution, 1-sided: cdf and sf
    def nair1_cdf(self, ctx, x, k, n, rho):
        def f(y):
            res = ctx.nmax_corr_negative_rho_cdf(
                x*y, k, rho) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        rho = ctx.t(rho)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.28 Studentized range distribution: pdf


    def srange_pdf(self, ctx, x, k, n):
        def f(y):
            res = ctx.nrange_pdf(x*y, k) * self.chidens(ctx, y, n) * y
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.29 Studentized range distribution: cdf and isf
    def srange_cdf(self, ctx, x, k, n):
        def f(y):
            res = ctx.nrange_cdf(x*y, k) * self.chidens(ctx, y, n)
            return res
        k = int(k)
        x = ctx.t(x)
        n = ctx.t(n)
        res = ctx.quadsubdiv(lambda y: f(y), [0, ctx.inf])
        #ctx.plot(lambda y: f(y), [0, 3])
        return res


# 6.4.30 Studentized range distribution: qtf and isf
    def srange_qtf(self, ctx, q, k, n, qtf=True):
        return None




# %%%  6.5 Miscellaneous continuous distributions


# 6.5.1 Lévy alpha-stable distribution, pdf
    def levy_alphastable_pdf(self, ctx, a, b, n):
        return None

# 6.5.2 Lévy alpha-stable distribution, cdf and sf
    def levy_alphastable_cdf(self, ctx, a, b, n):
        return None

# 6.5.3 Lévy alpha-stable distribution, qtf and isf
    def levy_alphastable_qtf(self, ctx, a, b, n):
        return None


# 6.5.4 Landau distribution, pdf
    def landau_pdf(self, ctx, a, b, n):
        return None

# 6.5.5 Landau distribution, cdf and sf
    def landau_cdf(self, ctx, a, b, n):
        return None

# 6.5.6 Landau distribution, qtf and isf
    def landau_qtf(self, ctx, a, b, n):
        return None


# 6.5.7 Pearson Type IV distribution, pdf
    def pearson_type4_pdf(self, ctx, a, b, n):
        return None

# 6.5.8 Pearson Type IV distribution, cdf and sf
    def pearson_type4_cdf(self, ctx, a, b, n):
        return None

# 6.5.9 Pearson Type IV distribution, qtf and isf
    def pearson_type4_qtf(self, ctx, a, b, n):
        return None


# 6.5.10 Meixner distribution, pdf
    def meixner_pdf(self, ctx, a, b, n):
        return None

# 6.5.11 Meixner distribution, cdf and sf
    def meixner_cdf(self, ctx, a, b, n):
        return None

# 6.5.12 Meixner distribution, qtf and isf
    def meixner_qtf(self, ctx, a, b, n):
        return None


# 6.5.13 Voigt Profile distribution, pdf
    def voigt_profile_pdf(self, ctx, a, b, n):
        return None

# 6.5.14 Voigt Profile distribution, cdf and sf
    def voigt_profile_cdf(self, ctx, a, b, n):
        return None

# 6.5.15 Voigt Profile distribution, qtf and isf
    def voigt_profile_qtf(self, ctx, a, b, n):
        return None


# 6.5.16 Wrapped Cauchy  distribution, pdf
    def wrapped_cauchy_pdf(self, ctx, a, b, n):
        return None

# 6.5.17 Wrapped Cauchy  distribution, cdf and sf
    def wrapped_cauchy_cdf(self, ctx, a, b, n):
        return None

# 6.5.18 Wrapped Cauchy  distribution, qtf and isf
    def wrapped_cauchy_qtf(self, ctx, a, b, n):
        return None


# 6.5.19 Wrapped normal distribution, pdf
    def wrapped_normal_pdf(self, ctx, a, b, n):
        return None

# 6.5.20 Wrapped normal distribution, cdf and sf
    def wrapped_normal_cdf(self, ctx, a, b, n):
        return None

# 6.5.21 Wrapped normal distribution, qtf and isf
    def wrapped_normal_qtf(self, ctx, a, b, n):
        return None


# 6.5.22 von Mises distribution, pdf
    def von_mises_pdf(self, ctx, a, b, n):
        return None

# 6.5.23 von Mises distribution, cdf and sf
    def von_mises_cdf(self, ctx, a, b, n):
        return None

# 6.5.24 von Mises distribution, qtf and isf
    def von_mises_qtf(self, ctx, a, b, n):
        return None







# 6.5.25 Generalized inverse Gaussian distribution, pdf
    def gen_inv_gaussian_pdf(self, ctx, a, b, n):
        return None

# 6.5.26 Generalized inverse Gaussian distribution, cdf and sf
    def gen_inv_gaussian_cdf(self, ctx, a, b, n):
        return None

# 6.5.27 Generalized inverse Gaussian distribution, qtf and isf
    def gen_inv_gaussian_qtf(self, ctx, a, b, n):
        return None


# 6.5.28 Harmonic distribution, pdf
    def harmonic_pdf(self, ctx, a, b, n):
        return None

# 6.5.29 Harmonic distribution, cdf and sf
    def harmonic_cdf(self, ctx, a, b, n):
        return None

# 6.5.30 Harmonic distribution, qtf and isf
    def harmonic_qtf(self, ctx, a, b, n):
        return None


# 6.5.31 Halphen A distribution, pdf
    def halphen_a_pdf(self, ctx, a, b, n):
        return None

# 6.5.32 Halphen A distribution, cdf and sf
    def halphen_a_cdf(self, ctx, a, b, n):
        return None

# 6.5.33 Halphen A distribution, qtf and isf
    def halphen_a_qtf(self, ctx, a, b, n):
        return None


# 6.5.34 Halphen B distribution, pdf
    def halphen_b_pdf(self, ctx, a, b, n):
        return None

# 6.5.35 Halphen B distribution, cdf and sf
    def halphen_b_cdf(self, ctx, a, b, n):
        return None

# 6.5.36 Halphen B distribution, qtf and isf
    def halphen_b_qtf(self, ctx, a, b, n):
        return None


# 6.5.37 Halphen IB distribution, pdf
    def halphen_ib_pdf(self, ctx, a, b, n):
        return None

# 6.5.38 Halphen IB distribution, cdf and sf
    def halphen_ib_cdf(self, ctx, a, b, n):
        return None

# 6.5.39 Halphen IB distribution, qtf and isf
    def halphen_ib_qtf(self, ctx, a, b, n):
        return None


# 6.5.40 Generalized hyperbolic distribution, pdf
    def gen_hyperbolic_pdf(self, ctx, a, b, n):
        return None

# 6.5.41 Generalized hyperbolic distribution, cdf and sf
    def gen_hyperbolic_cdf(self, ctx, a, b, n):
        return None

# 6.5.42 Generalized hyperbolic distribution, qtf and isf
    def gen_hyperbolic_qtf(self, ctx, a, b, n):
        return None


# 6.5.43 Hyperbolic distribution, pdf
    def hyperbolic_pdf(self, ctx, a, b, n):
        return None

# 6.5.44 Hyperbolic distribution, cdf and sf
    def hyperbolic_cdf(self, ctx, a, b, n):
        return None

# 6.5.45 Hyperbolic distribution, qtf and isf
    def hyperbolic_qtf(self, ctx, a, b, n):
        return None


# 6.5.46 Variance-gamma distribution, pdf
    def variance_gamma_pdf(self, ctx, a, b, n):
        return None

# 6.5.47 Variance-gamma distribution, cdf and sf
    def variance_gamma_cdf(self, ctx, a, b, n):
        return None

# 6.5.48 Variance-gamma distribution, qtf and isf
    def variance_gamma_qtf(self, ctx, a, b, n):
        return None



# %% 7 Discrete (lattice) distribution functions

# %%% 7.1 Elementary discrete (lattice) distribution functions


# 7.1.1 Geometric distribution, pmf


    def geometric_pmf(self, ctx, k, p):
        k = ctx.t(k)
        p = ctx.t(p)
        return p * ctx.exp(k * ctx.log1p(-p))

# 7.1.2 Geometric distribution, cdf and sf
    def geometric_cdf(self, ctx, k, p, cdf):
        k = ctx.t(k)
        p = ctx.t(p)
        if cdf:
            return -ctx.expm1(ctx.log1p(-p) * (k + 1))
        else:
            return ctx.exp(ctx.log1p(-p) * (k + 1))

# 7.1.3 Geometric distribution, qtf and isf
    def geometric_qtf(self, ctx, q, p, qtf):
        q = ctx.t(q)
        p = ctx.t(p)
        if qtf:
            return ctx.log1p(-q) / ctx.log1p(-p) - 1
        else:
            return ctx.log(q) / ctx.log1p(-p) - 1


# 7.1.4 Log-series distribution, pmf


    def logseries_pmf(self, ctx, k, lambda1):
        return None

# 7.1.5 Log-series distribution, cdf and sf
    def logseries_cdf(self, ctx, k, lambda1, cdf=True, **kwargs):
        return None

# 7.1.6 Log-series distribution, qtf and isf
    def logseries_qtf(self, ctx, prob, lambda1, qtf=True, **kwargs):
        return None


# 7.1.7 Poisson distribution, pmf


    def poisson_pmf(self, ctx, k, mu, **kwargs):
        k = ctx.t(k)
        mu = ctx.t(mu)
        return ctx.exp(-mu)*ctx.power(mu, k)/ctx.gamma(k+1)

# 7.1.8 Poisson distribution, cdf and sf
    def poisson_cdf(self, ctx, k, mu, cdf=True, **kwargs):
        k = ctx.t(k)
        mu = ctx.t(mu)
        if cdf:
            return ctx.real_gamma_q(k+1, mu)
        else:
            return ctx.real_gamma_p(k+1, mu)

# 7.1.9 Poisson distribution, qtf and isf
    def poisson_qtf(self, ctx, q, mu, qtf=True, **kwargs):
        q = ctx.t(q)
        mu = ctx.t(mu)
        if qtf:
            return ctx.real_gamma_q_inva(mu, q)-1
        else:
            return ctx.real_gamma_p_inva(mu, q)-1


# 7.1.10 Skellam distribution, pmf


    def skellam_pmf(self, ctx, k, lambda1):
        return None

# 7.1.11 Skellam distribution, cdf and sf
    def skellam_cdf(self, ctx, k, lambda1, cdf=True, **kwargs):
        return None

# 7.1.12 Skellam distribution, qtf and isf
    def skellam_qtf(self, ctx, prob, lambda1, qtf=True, **kwargs):
        return None


# 7.1.13 Binomial distribution, pmf


    def binomial_pmf(self, ctx, k, n, p):
        k = ctx.t(k)
        p = ctx.t(p)
        n = ctx.t(n)
        return ctx.real_ibeta_derivative(k + 1, n - k + 1, p) / (n + 1)

# 7.1.14 Binomial distribution, cdf and sf
    def binomial_cdf(self, ctx, k, n, p, cdf=True, **kwargs):
        k = ctx.t(k)
        p = ctx.t(p)
        n = ctx.t(n)
        if cdf:
            return ctx.real_ibetac(k + 1, n - k, p)
        else:
            return ctx.real_ibeta(k + 1, n - k, p)

# 7.1.15 Binomial distribution, qtf and isf
#    def binomial_qtf(self, ctx, q, n, p, qtf=True, **kwargs):
#        q = ctx.t(q)
#        p = ctx.t(p)
#        n = ctx.t(n)
#        prob_ = ctx.converto_float(q)
#        n_ = ctx.converto_float(n)
#        p_ = ctx.converto_float(p)
#        if qtf:
#            res = boost2.dist_binomial(prob_, n_, p_, 6)
#        else:
#            res = boost2.dist_binomial(prob_, n_, p_, 7)
#        return ctx.t(res)

    # k: number of failures
    # r: number of successes
    # p:  probability that any one trial will be successful (the success fraction)
# 7.1.16 Negative binomial (gamma-Poisson) distribution, pmf

    def negbinom_pmf(self, ctx, k, r, p, **kwargs):
        k = ctx.t(k)
        r = ctx.t(r)
        p = ctx.t(p)
        return (p / (r + k)) * ctx.real_ibeta_derivative(r, (k + 1), p)

# 7.1.17 Negative binomial (gamma-Poisson) distribution, cdf and sf
    def negbinom_cdf(self, ctx, k, r, p, cdf=True, **kwargs):
        k = ctx.t(k)
        r = ctx.t(r)
        p = ctx.t(p)
        if cdf:
            return ctx.real_ibeta(r, (k + 1), p)
        else:
            return ctx.real_ibetac(r, (k + 1), p)

# 7.1.18 Negative binomial (gamma-Poisson) distribution, qtf and isf
    def negbinom_qtf(self, ctx, q, r, p, qtf=True):
        q = ctx.t(q)
        p = ctx.t(p)
        r = ctx.t(r)
        if qtf:
            return ctx.real_ibeta_invb(r, p, q) - 1
        else:
            return ctx.real_ibetac_invb(r, p, q) - 1


# 7.1.19 Delaporte distribution, pmf


    def delaporte_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.20 Delaporte distribution, cdf and sf
    def delaporte_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.21 Delaporte distribution, qtf and isf
    def delaporte_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.22 Beta-Poisson distribution (Quinkert), pmf


    def betapoisson_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.23 Beta-Poisson distribution (Quinkert), cdf and sf
    def betapoisson_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.24 Beta-Poisson distribution (Quinkert), qtf and isf
    def betapoisson_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.25 Beta-binomial distribution, pmf


    def betabinom_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.26 Beta-binomial distribution, cdf and sf
    def betabinom_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.27 Beta-binomial distribution, qtf and isf
    def betabinom_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.28 Beta-negative binomial distribution (Waring), pmf


    def beta_negbinom_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.29 Beta-negative binomial distribution (Waring), cdf and sf
    def beta_negbinom_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.30 Beta-negative binomial distribution (Waring), qtf and isf
    def beta_negbinom_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.31 Classical hypergeometric distribution, pmf


    def hypergeo_pmf(self, ctx, k, K, n, N):
        return None

# 7.1.32 Classical hypergeometric distribution, cdf and sf
    def hypergeo_cdf(self, ctx, k, K, n, N, cdf=True):
        return None


# 7.1.33 Classical hypergeometric distribution, qtf and isf


    def hypergeo_qtf(self, ctx, prob, K, n, N, qtf=True):
        return None


# 7.1.34 Negative hypergeometric distribution, pmf


    def neghypergeo_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.35 Negative hypergeometric distribution, cdf and sf
    def neghypergeo_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.36 Negative hypergeometric distribution, qtf and isf
    def neghypergeo_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.37 Pólya-Eggenberger distribution, pmf


    def polya_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.38 Pólya-Eggenberger distribution, cdf and sf
    def polya_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.39 Pólya-Eggenberger distribution, qtf and isf
    def polya_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.40 General hypergeometric distribution, pmf


    def genhypergeo_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.41 General hypergeometric distribution, cdf and sf
    def genhypergeo_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.42 General hypergeometric distribution, qtf and isf
    def genhypergeo_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.43 Noncentral hypergeometric distribution (Fisher alternatives), pmf


    def hypergeo_nc_pmf(self, ctx, x, r, n, NN):
        return None

# 7.1.44 Noncentral hypergeometric distribution (Fisher alternatives), cdf and sf
    def hypergeo_nc_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.1.45 Noncentral hypergeometric distribution (Fisher alternatives), qtf and isf
    def hypergeo_nc_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.1.46 Zeta distribution, pmf


    def zeta_pmf(self, ctx, k, p):
        return None

# 7.1.47 Zeta distribution, cdf and sf
    def zeta_cdf(self, ctx,  k, p, cdf=True):
        return None

# 7.1.48 Zeta distribution, qtf and isf
    def zeta_qtf(self, ctx, prob, p, qtf=True):
        return None


# %%%  7.2 Discrete (lattice) distribution functions related to (stratified) rank tests


# 7.2.1 Wilcoxon 𝑇 distribution, pmf


    def wilcoxon_pmf(self, ctx, x, N):
        return None

# 7.2.2 Wilcoxon 𝑇 distribution, cdf and sf
    def wilcoxon_cdf(self, ctx, x, N, cdf=True):
        return None

# 7.2.3 Wilcoxon 𝑇 distribution, qtf and isf
    def wilcoxon_qtf(self, ctx, prob, N, qtf=True):
        return None


# 7.2.4 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, pmf


    def wilcoxon_nc_bennett_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.5 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, cdf and sf
    def wilcoxon_nc_bennett_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.6 Noncentral Wilcoxon 𝑇 distribution, Bennett alternatives, qtf and isf
    def wilcoxon_nc_bennett_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.7 Mann-Whitney 𝑈 distribution, pmf


    def mannwhitney_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.8 Mann-Whitney 𝑈 distribution, cdf and sf
    def mannwhitney_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.9 Mann-Whitney 𝑈 distribution, qtf and isf
    def mannwhitney_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.10 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, pmf


    def mannwhitney_nc_lehmann_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.11 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, cdf and sf
    def mannwhitney_nc_lehmann_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.12 Noncentral Mann-Whitney 𝑈 distribution, Lehmann alternatives, qtf and isf
    def mannwhitney_nc_lehmann_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.13 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, pmf


    def mannwhitney_nc_milton_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.14 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, cdf and sf
    def mannwhitney_nc_milton_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.15 Noncentral Mann-Whitney 𝑈 distribution, Milton alternatives, qtf and isf
    def mannwhitney_nc_milton_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.16 Kendall’s 𝑆 (or 𝜏 ) distribution, pmf


    def kendall_tau_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.17 Kendall’s 𝑆 (or 𝜏 ) distribution, cdf and sf
    def kendall_tau_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.18 Kendall’s 𝑆 (or 𝜏 ) distribution, qtf and isf
    def kendall_tau_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.19 Jonckheere-Terpsta 𝑆 distribution, pmf


    def jterpsta_s_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.20 Jonckheere-Terpsta 𝑆 distribution, cdf and sf
    def jterpsta_s_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.21 Jonckheere-Terpsta 𝑆 distribution, qtf and isf
    def jterpsta_s_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.22 Generalized Page 𝐿 distribution, pmf


    def page_l_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.23 Generalized Page 𝐿 distribution, cdf and sf
    def page_l_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.24 Generalized Page 𝐿 distribution, qtf and isf
    def page_l_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.2.25 Noncentral generalized Page 𝐿 distribution, Milton alternatives, pmf


    def page_l_nc_milton_pmf(self, ctx, x, r, n, NN):
        return None

# 7.2.26 Noncentral generalized Page 𝐿 distribution, Milton alternatives, cdf and sf
    def page_l_nc_milton_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.2.27 Noncentral generalized Page 𝐿 distribution, Milton alternatives, qtf and isf
    def page_l_nc_milton_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# %%%  7.3 Discrete (non-lattice) distribution functions related to rank tests


# 7.3.1 Cochran-Friedman-Quade distribution, pmf


    def friedman_pmf(self, ctx, x, r, n, NN):
        return None

# 7.3.2 Cochran-Friedman-Quade distribution, cdf and sf
    def friedman_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.3.3 Cochran-Friedman-Quade distribution, qtf and isf
    def friedman_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None


# 7.3.4 Kruskal-Wallis distribution, pmf


    def kruskal_wallis_pmf(self, ctx, x, r, n, NN):
        return None

# 7.3.5 Kruskal-Wallis distribution, cdf and sf
    def kruskal_wallis_cdf(self, ctx, x, r, n, NN, cdf=True):
        return None

# 7.3.6 Kruskal-Wallis distribution, qtf and isf
    def kruskal_wallis_qtf(self, ctx, prob, r, n, NN, qtf=True):
        return None




# %% 8 Series and integrals


# %%% 8.1 Finite sums algorithms for selected distributions


# 8.1.1 Central 𝜒2 distribution, cdf (integer degrees of freedom)


    def chi2_cohen_cdf(self, ctx, x, nu):
        return ctxSeries().chi2_cohen_cdf(ctx, x, nu)


# 8.1.2 Central Student 𝑡 distribution, cdf (integer degrees of freedom)


    def student_t_owen_cdf(self, ctx, x, nu):
        return ctxSeries().student_t_owen_cdf(ctx, x, nu)


# 8.1.3 Central Fisher 𝐹 distribution, cdf (integer degrees of freedom)


    def fisher_f_seber_cdf(self, ctx, x, m, n):
        return ctxSeries().fisher_f_seber_cdf(ctx, x, m, n)


# 8.1.4 Central Beta distribution, cdf (2𝑎 an integer, 2𝑏 an integer)


    def beta_seber_cdf(self, ctx, x, a, b):
        return ctxSeries().beta_seber_cdf(ctx, x, a, b)


# 8.1.5 Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)


    def chi2_nc_cohen_cdf(self, ctx, X0, n0, lambda0_):
        return ctxSeries().chi2_nc_cohen_cdf(ctx, X0, n0, lambda0_)


# 8.1.6 Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)


    def student_t_nc_owen_cdf(self, ctx, X0, n0, delta0):
        return ctxSeries().student_t_nc_owen_cdf(ctx, X0, n0, delta0)


# 8.1.7 Noncentral Fisher 𝐹 distribution, cdf (𝑚 an even integer)


    def fisher_f_nc_seber_cdf(self, ctx, x, nu1, nu2, nc):
        return ctxSeries().fisher_f_nc_seber_cdf(ctx, x, nu1, nu2, nc)


# 8.1.8 Noncentral Beta distribution, cdf (𝑏 an integer)


    def beta_nc_seber_cdf(self, ctx, x0, a0, b0, lambda0_):
        return ctxSeries().beta_nc_seber_cdf(ctx, x0, a0, b0, lambda0_)


# 8.1.9 Pearson’s 𝜌 distribution, pdf (integer N)


    def pearson_rho_nc_owen_pdf(self, ctx, r, N, rho):
        return ctxSeries().pearson_rho_nc_owen_pdf(ctx, r, N, rho)


# 8.1.10 Pearson’s 𝜌 distribution, cdf (integer N)


    def pearson_rho_nc_owen_cdf(self, ctx, r, N, rho):
        return ctxSeries().pearson_rho_nc_owen_cdf(ctx, r, N, rho)


# 8.1.11 Fisher’s 𝑅2 distribution, cdf (finite sum for odd 𝑁 − 𝑝)


    def fisher_r2_gd1_cdf(self, ctx, x, p, N, Rho2):
        return ctxSeries().fisher_r2_gd1_cdf(ctx, x, p, N, Rho2)


# 8.1.12 Roy’s largest root distribution, pdf, cdf and sf


    def roy_pdf_cdf_sf(self, ctx, x, p, n1, n2):
        return ctxSeries().roy_pdf_cdf_sf(ctx, x, p, n1, n2)


# %%% 8.2 Infinite sums algorithms for selected functions and distributions


# 8.2.1 Incomplete gamma function, continued fractions (Peizer)


    def gamma_peizer_cdf_sf_pdf(self, ctx, a, x):
        return ctxSeries().gamma_peizer_cdf_sf_pdf(ctx, a, x)


# 8.2.2 Incomplete gamma function, asymptotic expansion (Paris)


    def gamma_paris_cdf_sf(self, ctx, a, x, n=10):
        return ctxSeries().gamma_paris_cdf_sf(ctx, a, x, n)


# 8.2.3 Incomplete beta function, continued fractions (Peizer)


    def beta_peizer_cdf_sf_pdf(self, ctx, a, b, q, p):
        return ctxSeries().beta_peizer_cdf_sf_pdf(ctx, a, b, q, p)


# 8.2.4 Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)


    def chi2_nc_benton_cdf_sf(self, ctx, x, n, lambda1, cdf):
        return ctxSeries().chi2_nc_benton_cdf_sf(ctx, x, n, lambda1, cdf)


# 8.2.5 Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)


    def student_t_nc_benton_cdf_sf(self, ctx, x, nu, delta, cdf):
        return ctxSeries().student_t_nc_benton_cdf_sf(ctx, x, nu, delta, cdf)


# 8.2.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)


    def beta_nc_benton_cdf_sf(self, ctx, x, a, b, lambda1, cdf):
        return ctxSeries().beta_nc_benton_cdf_sf(ctx, x, a, b, lambda1, cdf)


# 8.2.7 Noncentral F distribution, pdf, cdf and sf (Boost)


    def fisher_f_nc_benton_cdf_sf(self, ctx, x, m, n, lambda1, cdf):
        return ctxSeries().fisher_f_nc_benton_cdf_sf(ctx, x, m, n, lambda1, cdf)


# 8.2.8 Pearson’s 𝜌 distribution, cdf and sf (Hotelling’s series)


    def pearson_rho_nc_ht_cdf(self, ctx, r, N, rho):
        return ctxSeries().pearson_rho_nc_ht_cdf(ctx, r, N, rho)


# 8.2.9 Pearson’s 𝜌 distribution, cdf and sf (Guenther’s series)


    def pearson_rho_nc_gt_cdf(self, ctx, r, N, rho):
        return ctxSeries().pearson_rho_nc_gt_cdf(ctx, r, N, rho)


# 8.2.10 Fisher’s 𝑅2 distribution, pdf (Gurland)


    def fisher_r2_gd2_cdf(self, ctx, x, p, N, rho2):
        return ctxSeries().fisher_r2_gd2_cdf(ctx, x, p, N, rho2)




# %% 8.3 Finite series for lattice distributions, based on factorial moments

    def demo_factorial_moments_pdf(self, ctx):
        print("demo_bell_shaped")

    def demo_factorial_moments_cdf(self, ctx):
        print("demo_bell_shaped")


# %% 8.4 Efficient integration of bell-shaped functions


    def demo_bell_shaped(self, ctx):
        print("demo_bell_shaped")




# %%% 8.5 Verified numerical integration


# 8.5.1 Verified Integration


    def quad_verified(self, ctx, f, a, b, epsabsStart, alpha, beta, verbose):
        return ctxIntegral().quad_verified(ctx, f, a, b, epsabsStart, alpha, beta, verbose)


# 8.5.2 Error function


    def real_quad_erf(self, ctx, x):
        return None


# 8.5.3 Lower non-normalised incomplete gamma function,


    def real_quad_gamma_lower(self, ctx, a, x):
        return None


# 8.5.4 Real upper non-normalised incomplete gamma function,


    def real_quad_gamma_upper(self, ctx, a, x):
        return None


# 8.5.5 Normalised incomplete beta function,


    def real_quad_ibeta(self, ctx, a, b, x):
        return None


# 8.5.6 Non-central chi-square cdf and sf (Chow)


    def chi2_nc_quad_cdf(self, ctx, n, x, l):
        return None


# 8.5.1 Owen’s 𝑇 function


    def owent_quad(self, ctx, h, a):
        l = 0
        r = 1
        res = 2*mp_.quad(lambda x: self.owentfx(h, a, x), [l, r])
        return res

    def owentfx(self, h, a, x):
        ax = a*x
        ax2p1 = 1 + ax*ax
        temp = mp_.exp(-h*h*ax2p1/2) / ax2p1
        res = temp * a / (4*mp_.pi())
        return res

    #  MarcumQ[m,a,b]
    #  https://www.wolframalpha.com/input/?i=MarcumQ[1%2c1%2C1.1]
# 8.5.2 Marcum 𝑄 function

    def marcumq_quad(self, ctx, a, b):
        l = 0
        r = 1*mp_.pi()
        res = 2*mp_.quad(lambda x: self.marcumqfx(a, b, x), [l, r])
        if a == b:
            res = 0.5 + res
        if a > b:
            res = 1 + res
        return res

    def marcumqfx(self, a, b, x):
        z = a/b
        ct = mp_.cos(x)
        resa = (1-z*ct)
        resb = (1-2*z*ct+z*z)
        if resb == 0:
            res1 = 0.5
        else:
            res1 = resa/resb
        res2 = mp_.exp(a*b*ct)
        res = res1*res2
        res = res * mp_.exp(-(a*a+b*b)/2)/(2*mp_.pi())
        return res


# %%% 8.6 Numerical (continuous) Fourier transform and its inverse


# 8.6.1 Central Chi-square: pdf, cdf, sf

    def chi2_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def cd_chisquared(self, ctx, k, t):
        return (1 - 2*t*ctx.j)**(-k/2)

    def cd_chisquared_t(self, ctx, t):
        k = 25
        return (1 - 2*t*ctx.j)**(-k/2)

    def g_chisquared(self, ctx, t):
        k = 25
        x = 15
        phi = self.cd_chisquared(self, k, t)
        z = ctx.exp(-t*x*ctx.j) * phi
        result = z.imag / t
        return result

    def g_chisquared_imag_cos(self, ctx, t):
        k = 25
        x = 15
        phi = self.cd_chisquared(k, t)
        result = ctx.cos(-t*x) * phi.imag/t
        return result

    def g_chisquared_imag_sin(self, ctx, t):
        k = 25
        x = 15
        phi = self.cd_chisquared(k, t)
        result = ctx.sin(-t*x) * phi.real/t
        return result

    def g_chisquared_imag_combined(self, ctx, t):
        result = self.g_chisquared_imag_cos(t) + self.g_chisquared_imag_sin(t)
        return result

    def g_chisquared_u2(self, ctx, u):
        t = u/(1-u)
        g = self.g_chisquared(t)
        result = g/((1-u)*(1-u))
        return result


# 8.6.2 Wilks’ Lambda distribution: pdf, cdf and sf


    def wilks_lambda_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def cd_WilksLambda(self, ctx, t, p, q, n):
        result = 1
        for k0 in range(p):
            k = k0 + 1
            g1 = ctx.gamma((n-k+1)/2 - ctx.j*t)
            g2 = ctx.gamma((n+q-k+1)/2)
            g3 = ctx.gamma((n-k+1)/2)
            g4 = ctx.gamma((n+q-k+1)/2 - ctx.j*t)
            prod1 = (g1*g2)/(g3*g4)
            #print("k:", k, "prod1:", prod1 )
            result = result * prod1
        return result

    def g_WilksLambda(self, ctx, t):
        x = 2.05292648821553
        #x = 1.1810793514607
        p = 4
        q = 7
        n = 20
        phi = self.cd_WilksLambda(t, p, q-1, n-q)
        z = ctx.exp(-t*x*ctx.j) * phi
        result = z.imag / t
        return result

    def g_WilksLambda_u2(self, ctx, u):
        t = u/(1-u)
        g = self.g_WilksLambda(t)
        result = g/((1-u)*(1-u))
        return result

    def g_WilksLambda_u(self, ctx, u):
        t = (1-u)/u
        g = self.g_WilksLambda(t)
        result = g/(u*u)
        return result


# 8.6.3 Distribution of the product of independent beta variates: pdf, cdf and sf

    def log_beta_prod_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def cd_betaproduct(self, ctx, t, p, b, c):
        result = 1
        for k0 in range(p):
            k = k0 + 1
            bk = b[k]
            dk = c[k]  # - b[k]
            #print("bk", bk, "dk", dk)
            g1 = ctx.gamma(bk - ctx.j*t)
            g2 = ctx.gamma(dk)
            g3 = ctx.gamma(bk)
            g4 = ctx.gamma(dk - ctx.j*t)
            prod1 = (g1*g2)/(g3*g4)
            result = result * prod1
        return result

    # def g_betaproduct(t):
    #   x = 10
    #   #x = 1.1810793514607
    #   p = 14
    #   f1 = 17 - 1
    #   n = 200 - 7
    #   b = [0]
    #   c = [0]
    #   for k0 in range (p):
    #       i = k0+1
    #       b.append((n-i+1)/2)
    #       c.append(b[i] + f1/2)
    #   phi = cd_betaproduct(t, p, b, c)
    #   z = exp(-t*x*j) * phi
    ##   result = log(abs(z)/t)
    #   result = z.imag / t
    #   return result

    def g_betaproduct_u2(self, ctx, u):
        t = u/(1-u)
        g = self.g_betaproduct(t)
        result = g/((1-u)*(1-u))
        return result

    def g_betaproduct_u(self, u):
        t = (1-u)/u
        g = self.g_betaproduct(t)
        result = g/(u*u)
        return result

    def g_betaproduct(self, ctx, t):
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
        phi = self.cd_betaproduct(t, p, b, c)
        z = ctx.exp(-t*x*ctx.j) * phi
    #   result = log(abs(z)/t)
        result = z.imag / t
        return result

    def g_betaproduct_imag_cos(self, ctx, t):
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
        phi = self.cd_betaproduct(t, p, b, c)
        #z = cos(-t*x) * phi
        #z = phi
        #result = z.imag / t
        result = ctx.cos(-t*x) * phi.imag/t
        return result

    def g_betaproduct_imag_sin(self, ctx, t):
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
        phi = self.cd_betaproduct(t, p, b, c)
        #z = sin(-t*x) * phi * j
        #z = phi*j
        #result = z.imag / t
        result = ctx.sin(-t*x) * phi.real/t
        return result

    def g_betaproduct_imag_combined(self, ctx, t):
        result = self.g_betaproduct_imag_cos(
            t) + self.g_betaproduct_imag_sin(t)
        return result


# 8.6.4 Box-Davis distribution: pdf, cdf and sf


    def log_box_davis_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.6.5 Noncentral Chi-square: pdf, cdf, sf


    def chi2_nc_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.6.6 Non-central Beta distribution: pdf, cdf and sf


    def log1mbeta_nc_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.6.7 Fisher’s 𝑅2 distribution: pdf, cdf and sf


    def fisher_log1mr2_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.6.8 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf and sf


    def wilks_lambda_glm_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.6.9 Noncentral Chi-square: pdf, cdf, sf


    def wilks_lambda_ind_gp(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def cd_chisquared_nc(self, ctx, k, t, theta):
        a = (1 - 2*t*ctx.j)**(-k/2)
        b = ctx.exp((ctx.j*t*theta)/(1-2*ctx.j*t))
        result = a * b
        return result

    def g_chisquared_nc(self, ctx, t):
        k = 1101
        x = 1100
        theta = 50
        phi = self.cd_chisquared_nc(k, t, theta)
        z = ctx.exp(-t*x*ctx.j) * phi
        result = z.imag / t
        return result

    def g_chisquared_u_nc(self, ctx, u):
        t = (1-u)/u
        g = self.g_chisquared_nc(t)
        result = g/(u*u)
        return result


# %%% 8.7 Numerical Fourier transform and its inverse: discrete distributions


# 8.8.1 Binomial distribution: pmf, cdf, sf


    def binomial_ft(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 8.8.2 Wilcoxon distribution: pmf, cdf, sf


    def wilcoxon_ft(self, ctx):
        raise Exception("NOT IMPLEMENTED")




# %% 9 Pmf vectors


# %%%  9.1 Basic discrete (lattice) distribution functions


# 9.1.1 Poisson distribution, pmf vector


    def poisson_pmf_vector(self, ctx, lambda1, count):
        return ctxPmfBasicVector().poisson_pmf_vector(ctx, lambda1, count)

# 9.1.2 Binomial distribution, pmf vector
    def binomial_pmf_vector(self, ctx, n, p):
        return ctxPmfBasicVector().binomial_pmf_vector(ctx, n, p)

# 9.1.3 Negative binomial distribution, pmf vector
    def negbinom_pmf_vector(self, ctx, r, p, count):
        return ctxPmfBasicVector().negbinom_pmf_vector(ctx, r, p, count)

# 9.1.4 Hypergeometric distribution, pmf vector
    def hypergeo_pmf_vector(self, ctx, r, n, NN):
        return ctxPmfBasicVector().hypergeo_pmf_vector(ctx, r, n, NN)


# 9.1.5 Noncentral hypergeometric distribution (Fisher), pmf vector


    def hypergeo_nc_pmf_vector(self, ctx, N):
        return None


# %%%  9.2 Discrete (lattice) distribution functions related to (stratified) rank tests


# 9.2.1 Sign test distribution (under 𝐻0), pmf vector


    def signtest_pmf_vector(self, ctx, N):
        return ctxPmfBasicVector().signtest_pmf_vector(ctx, N)


# 9.2.2 Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector


    def wilcoxon_pmf_vector(self, ctx, N):
        return ctxPmfBasicVector().wilcoxon_pmf_vector(ctx, N)

    def wilcoxon_full_vector(self, ctx, N, cdf, show, start, stop):
        return ctxPmfBasicVector().wilcoxon_full_vector(ctx, N, cdf, show, start, stop)


# 9.2.3 Wilcoxon 𝑇 distribution (under Bennett alternatives), pmf vector


    def wilcoxon_bennett_pmf_vector(self, ctx, N):
        return None


# 9.2.4 Kendall 𝑆 (or tau) distribution (under 𝐻0), pmf vector


    def kendall_tau_pmf_vector(self, ctx, n):
        return ctxPmfBasicVector().kendall_tau_pmf_vector(ctx, n)

    def kendall_full_vector(self, ctx, N, cdf, show, start, stop):
        return ctxPmfBasicVector().kendall_full_vector(ctx, N, cdf, show, start, stop)


# 9.2.5 Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector


    def mann_whitney_u_pmf_vector(self, ctx, m, n):
        return ctxPmfBasicVector().mann_whitney_u_pmf_vector(ctx, m, n)


# 9.2.6 Jonckheere-Terpsta 𝑆 distribution (under 𝐻0), pmf vector


    def jterpsta_s_pmf_vector(self, ctx, k, n):
        return ctxPmfBasicVector().jterpsta_s_pmf_vector(ctx, k, n)


# 9.2.7 Spearman 𝜌 distribution (under 𝐻0), pmf vector


    def spearman_rho_pmf_vector(self, ctx, n, Order):
        return ctxPmfBasicVector().spearman_rho_pmf_vector(ctx, n, Order)


# 9.2.8 Page 𝐿 distribution (under 𝐻0), pmf vector


    def page_l_pmf_vector(self, ctx, k, N):
        return ctxPmfBasicVector().page_l_pmf_vector(ctx, k, N)


# 9.2.9 Quade 𝐿 distribution (under 𝐻0), pmf vector


    def quade_l_pmf_vector(self, ctx, k, N):
        return ctxPmfBasicVector().quade_l_pmf_vector(ctx, k, N)


# 9.2.10 Mann-Whitney 𝑈 distribution (under Lehmann alternatives), pmf vector


    def mannwhitney_u_lehmann_pmf_vector(self, ctx, kValue, N1, n2):
        return ctxLehmann().mannwhitney_u_lehmann_pmf_vector(ctx, kValue, N1, n2)


# 9.2.11 Mann-Whitney 𝑈 distribution (under Milton alternatives), pmf vector


    def mannwhitney_u_milton_pmf_vector(self, ctx, m, n):
        return None

    def milton_pmf(self, ctx, n, delta):
        return ctxMilton().milton_pmf(ctx, n, delta)


# %%%  9.3 Discrete (non-lattice) distribution functions related to rank tests


# 9.3.1 Cochran 𝑆 distribution (under 𝐻0), pmf vector


    def cochran_s_pmf_vector(self, ctx, m, n):
        return None


# 9.3.2 Friedman 𝑆 distribution (under 𝐻0), pmf vector


    def friedman_s_pmf_vector(self, ctx, GetWhat, sum2, n, Quade, Mode, Mode2):
        return ctxFriedman().friedman_s_pmf_vector(ctx, GetWhat, sum2, n, Quade, Mode, Mode2)


# 9.3.3 Quade 𝑆 distribution (under 𝐻0), pmf vector


    def quade_s_pmf_vector(self, ctx, m, n):
        return None


# 9.3.4 Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector


    def kruskal_wallis_h_pmf_vector(self, ctx, n):
        return ctxKruskal().kruskal_wallis_h_pmf_vector(ctx, n)


# %% 10 Asymptotic expansions


# %%%  10.1 Edgeworth and Cornish-Fisher expansions: continuous distributions


# 10.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf

    def edgeworth(self, ctx, x, order, kappa):
        return ctxAsymptotic().edgeworth(ctx, x, order, kappa)


#  10.1.2 Cornish-Fisher expansion: general approximation to the qtf and isf


    def cornish_fisher(self, ctx,  LeftTail, RightTail, kappa, nord):
        return ctxAsymptotic().cornish_fisher(ctx, LeftTail, RightTail, kappa, nord)


# 10.1.3 Chi-squared distribution: pdf, cdf and sf


    def chi2_ecf(self, ctx, x, n, order, verbose):
        return ctxAsymptotic().chi2_ecf(ctx, x, n, order, verbose)


# 10.1.4 Chi-squared distribution: qtf and isf


    def chi2_ecf_inv(self, ctx, L1, R1, n, order, verbose):
        return ctxAsymptotic().chi2_ecf_inv(ctx, L1, R1, n, order, verbose)


#  10.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf and sf


    def logrv_chisquared_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.6 Distribution of the logarithm of a 𝜒2 random variable: qtf and isf
    def logrv_chisquared_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.7 Fisher 𝑧 distribution: pdf, cdf and sf


    def fisher_z_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.8 Fisher 𝑧 distribution: qtf and isf
    def fisher_z_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf and sf


    def logrv_beta_ecf_pdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.10 Distribution of the negative logarithm of a beta variable: qtf and isf
    def logrv_beta_ecf_qtf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.11 Wilks’ Lambda distribution: pdf, cdf and sf


    def wilks_lambda_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.12 Wilks’ Lambda distribution: qtf and isf


    def wilks_lambda_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf


    def pillai_v_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.14 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def pillai_v_moments(self, ctx, k, p, n1, n2):
        mraw = ctxAsymptotic().CalcT2VMoments2(ctx, False, k, p, n1, (p - n1 - n2 + 1))
        return mraw


#  10.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf


    def hotelling_t2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.16 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def hotelling_t2_moments(self, ctx, k, p, n1, n2):
        mraw = ctxAsymptotic().CalcT2VMoments2(ctx, True, k, p, n1, n2)
        return mraw


#  10.1.17 Distribution of the product of independent beta variates: pdf, cdf and sf


    def beta_product_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.18 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.19 Box-Davis distribution (covariance matrices): pdf, cdf and sf


    def box_davis_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.20 Box-Davis distribution (covariance matrices): qtf and isf
    def box_davis_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.21 Noncentral chi-squared distribution: pdf, cdf and sf


    def chi2_nc_ecf(self, ctx, x, n, lambda1, order, verbose):
        return ctxAsymptotic().chi2_nc_ecf(ctx, x, n, lambda1, order, verbose)


#  10.1.22 Noncentral chi-squared distribution: qtf and isf


    def chi2_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.23 Noncentral 𝑡-distribution: pdf, cdf and sf


    def student_t_nc_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.24 Noncentral 𝑡-distribution: qtf and isf
    def student_t_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.25 Noncentral 𝐹-distribution: pdf, cdf and sf


    def fisher_f_nc_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.26 Noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.27 Doubly noncentral 𝑡-distribution: pdf, cdf and sf


    def student_t_nc2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.28 Doubly noncentral 𝑡-distribution: qtf and isf
    def student_t_nc2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.1.29 Doubly noncentral 𝐹-distribution: pdf, cdf and sf


    def fisher_f_nc2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.1.30 Doubly noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 10.2 Edgeworth and Cornish-Fisher expansions: discrete (lattice) distributions


# 10.2.1 The Sheppard correction


    def sheppard_correction(self, ctx, kappa, show=False):
        return ctxAsymptotic().sheppard_correction(ctx, kappa, show)


#   10.2.2 Poisson distribution: pdf, cdf and sf


    def poisson_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.2.3 Poisson distribution: qtf and isf
    def poisson_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   10.2.4 Binomial distribution: pdf, cdf and sf


    def binomial_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.2.5 Binomial distribution: qtf and isf
    def binomial_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   10.2.6 Negative binomial distribution: pdf, cdf and sf


    def negbinom_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.2.7 Negative binomial distribution: qtf and isf
    def negbinom_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   10.2.8 Hypergeometric distribution: pdf, cdf and sf


    def hypergeo_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.2.9 Hypergeometric distribution: qtf and isf
    def hypergeo_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 10.2.10 Wilcoxon Signed Rank distribution: pdf, cdf and sf


    def wilcoxon_ecf(self, ctx, x, N, order):
        return ctxAsymptotic().wilcoxon_ecf(ctx, x, N, order)

# 10.2.11 Wilcoxon Signed Rank distribution: qtf and isf
    def wilcoxon_ecf_inv(self, ctx, L1, R1, N, order):
        return ctxAsymptotic().wilcoxon_ecf_inv(ctx, L1, R1, N, order)


# 10.2.12 Kendall’s 𝑆 (or 𝜏 ) distribution: pdf, cdf and sf


    def kendall_ecf(self, ctx, x, N, order):
        x = ctx.t(x)
        N = int(N)
        order = int(order)
        return ctxAsymptotic().kendall_ecf(ctx, x, N, order)

# 10.2.13 Kendall’s 𝑆 (or 𝜏 ) distribution: qtf and isf
    def kendall_ecf_inv(self, ctx, L1, R1, N, order):
        L1 = ctx.t(L1)
        R1 = ctx.t(R1)
        N = int(N)
        order = int(order)
        return ctxAsymptotic().kendall_ecf_inv(ctx, L1, R1, N, order)


# 10.2.14 Mann-Whitney 𝑈 distribution: pdf, cdf and sf


    def mannwhitney_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 10.2.15 Mann-Whitney 𝑈 distribution: qtf and isf
    def mannwhitney_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 10.2.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf and sf


    def jterpsta_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 10.2.17 Jonckheere-Terpsta 𝑆 distribution: qtf and isf
    def jterpsta_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   10.2.18 Page 𝐿 distribution: pdf, cdf and sf


    def page_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.2.19 Page 𝐿 distribution: qtf and isf
    def page_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 10.3 Luggannini-Rice and Jensen saddle point expansions: continuous distributions

# 10.3.1 Luggannini-Rice expansion: general approximation to the pdf, cdf, and sf


    def lugannani_rice(self, ctx, order, kderiv, s, verbose=False):
        return ctxAsymptotic().lugannani_rice(ctx, order, kderiv, s, verbose)


# 10.3.2a jensen expansion: general approximation to the qtf and isf


    def jensen(self, ctx,  kderiv, s):
        return ctxAsymptotic().jensen(ctx,  kderiv, s)


# 10.3.2b jensen expansion: general approximation to the qtf and isf


    def jensen_inverse(self, ctx,  n0, lambda0_, za_):
        return ctxAsymptotic().jensen_inverse(self, ctx,  n0, lambda0_, za_)


#   10.3.3 Central Chi-square: pdf, cdf, sf


    def chi2_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.3.4 Central Chi-square: qtf, isf
    def chi2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   10.3.5 Fisher 𝑧 distribution: pdf, cdf, sf


    def fisher_z_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   10.3.6 Fisher 𝑧 distribution: qtf, isf
    def fisher_z_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 10.3.7 Noncentral Chi-square: pdf, cdf, sf


    def chi2_nc_spa(self, ctx, x0, n0, lambda0_, Order, verbose):
        return ctxAsymptotic().chi2_nc_spa(ctx, x0, n0, lambda0_, Order, verbose)

# 10.3.8 Noncentral Chi-square: qtf, isf
    def chi2_nc_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 10.3.9 Doubly Non-central Fisher F


    def fisher_f_nc2_spa(self, ctx, x, n1, n2, lambda1, lambda2):
        return ctxAsymptotic().fisher_f_nc2_spa(ctx, x, n1, n2, lambda1, lambda2)


# 10.3.10 Doubly Non-central Fisher F: qtf, isf

    def fisher_f_nc2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.11 Wilks’ Λ distribution, pdf, cdf, sf


    def wilks_lambda_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.12 Wilks’ Λ distribution, cdf and sf
    def wilks_lambda_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.13 Distribution of the product of independent beta variables, pdf, cdf, sf


    def beta_prod_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.14 Distribution of the product of independent beta variables : qtf, isf
    def beta_prod_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.15 Box distribution: pdf, cdf, sf


    def box_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.16 Box distribution : qtf, isf
    def box_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.17 Non-central Beta distribution: pdf, cdf, sf


    def beta_nc_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.18 Non-central Beta distribution : qtf, isf
    def beta_nc_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.19 Fisher’s 𝑅2 distribution: pdf, cdf, sf


    def fisher_r2_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.20 Fisher’s 𝑅2 distribution : qtf, isf
    def fisher_r2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.21 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf, sf


    def wilks_lambda_glm_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.22 Noncentral Wilks’ Λ distribution: MANOVA, qtf, isf
    def wilks_lambda_glm_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.3.23 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf, sf


    def wilks_lambda_ind_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.3.24 Noncentral Wilks’ Λ distribution: Independence, : qtf, isf
    def wilks_lambda_ind_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%%   10.4 Luggannini-Rice and Jensen saddle point expansions: discrete (lattice) distributions


#  10.4.1 The Sheppard correction


    def sheppard_per_cgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.2 Poisson distribution: pdf, cdf, sf


    def poisson_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.3 Poisson distribution: qtf, isf
    def poisson_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.4 Binomial distribution: pdf, cdf and sf


    def binomial_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.5 Binomial distribution: qtf and isf
    def binomial_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.6 Negative binomial distribution: pdf, cdf and sf


    def negbinom_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.7 Negative binomial distribution: qtf and isf
    def negbinom_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.8 Hypergeometric distribution: pdf, cdf and sf


    def hypergeo_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.9 Hypergeometric distribution: qtf and isf
    def hypergeo_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.10 Wilcoxon distribution: pdf, cdf, sf


    def wilcoxon_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.11 Wilcoxon distribution: qtf, isf
    def wilcoxon_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.12 Mann-Whitney’s U distribution: pdf, cdf, sf


    def mannwhitney_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.13 Mann-Whitney’s U distribution: qtf, isf
    def mannwhitney_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.14 Kendall’s Tau distribution: pdf, cdf, sf


    def kendall_tau_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.15 Kendall’s Tau distribution: qtf, isf
    def kendall_tau_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf, sf


    def jterpsta_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.17 Jonckheere-Terpsta 𝑆 distribution: qtf, isf
    def jterpsta_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  10.4.18 Page 𝐿 distribution: pdf, cdf, sf


    def page_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  10.4.19 Page 𝐿 distribution: qtf, isf
    def page_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%%  10.5 Box-Davis expansions and their inverses


#  10.5.1 Box-Davis expansion: general approximation to the pdf, cdf and sf


    def box_davis_expansion(self, ctx, x, f, rho, omega):
        return ctxAsymptotic().box_davis_expansion(ctx, x, f, rho, omega)

#  10.5.2 Box-Davis expansion: general approximation to the qtf and isf
    def box_davis_expansion_inv(self, ctx, q, f, rho, omega):
        return ctxAsymptotic().box_davis_expansion_inv(ctx, q, f, rho, omega)


#  10.5.3 Wilks’ Lambda distribution: pdf, cdf and sf


    def wilks_lambda_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.4 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.5 Distribution of the product of independent beta variates: pdf, cdf and sf


    def beta_product_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

# 10.5.6 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.7 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf


    def box_cov_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.8 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_cov_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.9 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf


    def box_means_cov_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.10 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_means_cov_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.11 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: pdf, cdf and sf


    def lrt_vc0_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.12 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: qtf and isf
    def lrt_vc0_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.13 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: pdf, cdf and sf


    def lrt_x0_vc0_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.14 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: qtf and isf
    def lrt_x0_vc0_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.15 Pillai’s 𝑉 distribution: pdf, cdf and sf


    def pillai_v_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.16 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  10.5.17 Hotelling’s 𝑇2 distribution: pdf, cdf and sf


    def hotelling_t2_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  10.5.18 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


# %% 11 Fast approximations

# %%% 11.1 Approximations based on the normal distribution

# 11.1.1   Non-central chi-squared distribution: cdf and sf (Penev)


    def cdisn_penev(self, ctx, x, n, nc):
        x = ctx.t(x)
        n = ctx.t(n)
        nc = ctx.t(nc)
        return ctxApprox().cdisn_penev(ctx, x, n, nc)


# 11.1.2 (Non-central) chi-squared distribution: qtf and isf (Canal)


    def chi2_nc_canal_qtf(self, ctx, L, R, n):
        L = ctx.t(L)
        R = ctx.t(R)
        n = ctx.t(n)
        return ctxApprox().chi2_nc_canal_qtf(ctx, L, R, n)


# 11.1.3 Gamma distribution: qtf and isf (Canal)


    def gamma_canal_qtf(self, ctx, L, R, a):
        L = ctx.t(L)
        R = ctx.t(R)
        a = ctx.t(a)
        return ctxApprox().gamma_canal_qtf(ctx, L, R, a)


# 11.1.4 F distribution: qtf and isf (Davis)


    def fisher_f_davis_qtf(self, ctx, l, r, m, n):
        l = ctx.t(l)
        r = ctx.t(r)
        m = ctx.t(m)
        n = ctx.t(n)
        return ctxApprox().fisher_f_davis_qtf(ctx, l, r, m, n)


# 11.1.5 Beta distribution: qtf and isf (Davis)


    def beta_davis_qtf(self, ctx, l, r, a, b):
        l = ctx.t(l)
        r = ctx.t(r)
        a = ctx.t(a)
        b = ctx.t(b)
        return ctxApprox().beta_davis_qtf(ctx, l, r, a, b)


# 11.1.6 Pearson’s rho distribution: pdf (Winterbottom)


    def pearson_rho_wb_pdf(self, ctx, N, r, rho):
        N = ctx.t(N)
        r = ctx.t(r)
        rho = ctx.t(rho)
        return ctxApprox().pearson_rho_wb_pdf(ctx, N, r, rho)


# 11.1.7  Pearson’s rho distribution: cdf and sf (Winterbottom, DH version)


    def pearson_rho_wb_cdf(self, ctx, N, r, rho):
        N = ctx.t(N)
        r = ctx.t(r)
        rho = ctx.t(rho)
        return ctxApprox().pearson_rho_wb_cdf(ctx, N, r, rho)


# 11.1.8  Pearson’s rho distribution: qtf and isf (Winterbottom)


    def pearson_rho_wb_qtf(self, ctx, l, r, n, rho):
        l = ctx.t(l)
        r = ctx.t(r)
        n = ctx.t(n)
        rho = ctx.t(rho)
        return ctxApprox().pearson_rho_wb_qtf(ctx, l, r, n, rho)


# 11.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)


    def pearson_rho_wb_cl(self, ctx, l, r, N, x):
        l = ctx.t(l)
        r = ctx.t(r)
        N = ctx.t(N)
        x = ctx.t(x)
        return ctxApprox().pearson_rho_wb_cl(self, ctx, l, r, N, x)


# 11.1.10 Singly noncentral t: pdf (Broda)


    def student_t_nc_broda_pdf(self, ctx, x, n, delta):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        return ctxApprox().student_t_nc_broda_pdf(ctx, x, n, delta)


# 11.1.11 Singly noncentral t: cdf, sf (Broda)


    def student_t_nc_broda_cdf(self, ctx, x, n, delta):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        return ctxApprox().student_t_nc_broda_cdf(ctx, x, n, delta)


# 11.1.12 Singly noncentral t: qtf, isf (Harley)


    def student_t_nc_harley_qtf(self, ctx, alpha, df, delta):
        alpha = ctx.t(alpha)
        df = ctx.t(df)
        delta = ctx.t(delta)
        return ctxApprox().student_t_nc_harley_qtf(ctx, alpha, df, delta)


# 7.1.13 Singly noncentral t: confidence limit for 𝛿 (Akahira)


    def student_t_nc_akahira_cl(self, ctx, IsGLM, df, t, beta):
        df = ctx.t(df)
        t = ctx.t(t)
        beta = ctx.t(beta)
        return ctxApprox().student_t_nc_akahira_cl(ctx, IsGLM, df, t, beta)


# 11.1.14 Doubly noncentral t: cdf, sf (Broda)


    def student_t_nc2_broda_cdf(self, ctx, x, n, delta, theta):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        theta = ctx.t(theta)
        return ctxApprox().student_t_nc2_broda_cdf(ctx, x, n, delta, theta)


# 11.1.15 Doubly noncentral t: qtf, isf (Broda)


    def student_t_nc2_broda_qtf(self, ctx, alpha, n, delta, theta):
        alpha = ctx.t(alpha)
        n = ctx.t(n)
        delta = ctx.t(delta)
        theta = ctx.t(theta)
        return ctxApprox().student_t_nc2_broda_qtf(self, ctx, alpha, n, delta, theta)


# 11.1.16 Spearman’s rho, first 8 cumulants


    def spearman_mu8(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# 11.1.17 Mann-Whitney U distribution: general alternatives specified by rank order probabilities


    def mannwhitney_nc_mu4(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# 11.1.18 First 4 moments of Kendalls 𝜏 in the general case


    def kendall_tau_nc_mu4(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# %%%  11.2 Approximations based on the chi-squared distribution


# 11.2.1 Non-Central chi-squared : cdf, sf (Patnaik)

    def chi2_nc_mu2_cdf(self, ctx, x, n, lambda1):
        x = ctx.t(x)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        return ctxApprox().chi2_nc_mu2_cdf(ctx, x, n, lambda1)


# 11.2.2 Non-Central chi-squared: qtf, isf (Patnaik)


    def chi2_nc_mu2_qtf(self, ctx, n, lambda1, L, R):
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
        L = ctx.t(L)
        R = ctx.t(R)
        return ctxApprox().chi2_nc_mu2_qtf(self, ctx, n, lambda1, L, R)


# 11.2.3 Non-Central chi-squared: confidence limit for 𝜆 (Winterbottom)


    def chi2_nc_wb_cl(self, ctx, F, alpha, Beta):
        F = ctx.t(F)
        alpha = ctx.t(alpha)
        Beta = ctx.t(Beta)
        return ctxApprox().chi2_nc_wb_cl(self, ctx, F, alpha, Beta)


# 11.2.4 Roy’s largest root 𝜃: pdf (Chiani)


    def roy_chiani_pdf(self, ctx, t1, p, n1, n2):
        t1 = ctx.t(t1)
        p = ctx.t(p)
        n1 = ctx.t(n1)
        n2 = ctx.t(n2)
        return ctxApprox().roy_chiani_pdf(self, ctx, t1, p, n1, n2)


# 11.2.5 Roy’s largest root: cdf and sf (Chiani)


    def roy_chiani_cdf(self, ctx, t1, p, n1, n2):
        t1 = ctx.t(t1)
        p = ctx.t(p)
        n1 = ctx.t(n1)
        n2 = ctx.t(n2)
        return ctxApprox().roy_chiani_cdf(self, ctx, t1, p, n1, n2)


# 11.2.6 Roy’s largest root: qtf and isf (Chiani)


    def roy_chiani_qtf(self, ctx, LeftTail, p, n1, n2):
        LeftTail = ctx.t(LeftTail)
        p = ctx.t(p)
        n1 = ctx.t(n1)
        n2 = ctx.t(n2)
        return ctxApprox().roy_chiani_qtf(self, ctx, LeftTail, p, n1, n2)


# %%%  11.3 Approximations based on the central F or beta distribution

# 11.3.1 Dunn-Šidák percentage points


    def dunn_sidak_qtf(self, ctx, LeftTail, RightTail, f1):
        LeftTail = ctx.t(LeftTail)
        RightTail = ctx.t(RightTail)
        f1 = ctx.t(f1)
        return ctxApprox().dunn_sidak_qtf(ctx, LeftTail, RightTail, f1)


# 11.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)


    def fisher_f_nc_mu2_cdf(self, ctx, X, f1, f2, lambda1, IsGLM):
        X = ctx.t(X)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        lambda1 = ctx.t(lambda1)
        return ctxApprox().fisher_f_nc_mu2_cdf(ctx, X, f1, f2, lambda1, IsGLM)


# 11.3.3 Singly non-central F distribution: qtf, isf (Patnaik)


    def fisher_f_nc_mu2_qtf(self, ctx, L, f1, f2, lambda1, IsGLM):
        L = ctx.t(L)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        lambda1 = ctx.t(lambda1)
        return ctxApprox().fisher_f_nc_mu2_qtf(ctx, L, f1, f2, lambda1, IsGLM)


# 11.3.4 Singly non-central F: confidence interval for the noncentrality parameter 𝜆


    def fisher_f_nc_cl_(self, ctx, alpha, beta, f1, f2):
        alpha = ctx.t(alpha)
        beta = ctx.t(beta)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().fisher_f_nc_cl_(self, ctx, alpha, beta, f1, f2)


# 11.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)


    def fisher_f_nc2_mu2_cdf(self, ctx, X, f1, f2,  lambda1, lambda2):
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        X = ctx.t(X)
        lambda1 = ctx.t(lambda1)
        lambda2 = ctx.t(lambda2)
        return ctxApprox().fisher_f_nc2_mu2_cdf(ctx, X, f1, f2,  lambda1, lambda2)


# 11.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)


    def fisher_f_nc2_mu2_qtf(self, ctx, L, f1, f2, lambda1, lambda2):
        L = ctx.t(L)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        lambda1 = ctx.t(lambda1)
        lambda2 = ctx.t(lambda2)
        return ctxApprox().fisher_f_nc2_mu2_qtf(ctx, L, f1, f2, lambda1, lambda2)


# 11.3.7 Multiple correlation coefficient: cdf, sf (Lee and Gurland)


    def fisher_r2_lee_cdf(self, ctx, r2, p, N, Rho2):
        r2 = ctx.t(r2)
        p = ctx.t(p)
        N = ctx.t(N)
        Rho2 = ctx.t(Rho2)
        return ctxApprox().fisher_r2_lee_cdf(ctx, r2, p, N, Rho2)


# 11.3.8 Multiple correlation coefficient: qtf, isf (Lee and Gurland)


    def fisher_r2_lee_qtf(self, ctx, L, p, N, rho2):
        L = ctx.t(L)
        p = ctx.t(p)
        N = ctx.t(N)
        rho2 = ctx.t(rho2)
        return ctxApprox().fisher_r2_lee_qtf(ctx, L, p, N, rho2)


# 11.3.9 Fisher 𝑅2,: confidence limit for rho^2


    def fisher_r2_lee_cl(self, ctx, alpha, beta, p, N):
        alpha = ctx.t(alpha)
        beta = ctx.t(beta)
        p = ctx.t(p)
        N = ctx.t(N)
        return ctxApprox().fisher_r2_lee_cl(ctx, alpha, beta, p, N)


# 11.3.10 Central Wilks’ Lambda: cdf, sf (Rao)


    def wilks_lambda_rao_cdf(self, ctx, x, p, f1, f2):
        x = ctx.t(x)
        p = ctx.t(p)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().wilks_lambda_rao_cdf(ctx, x, p, f1, f2)


    def wilks_lambda_bp_cdf(self, ctx, x, p, f1, f2):
        x = ctx.t(x)
        p = ctx.t(p)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().wilks_lambda_bp_cdf(ctx, x, p, f1, f2)



    def wilks_lambda_bp_pdf(self, ctx, x, p, f1, f2):
        x = ctx.t(x)
        p = ctx.t(p)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().wilks_lambda_bp_pdf(ctx, x, p, f1, f2)


# 11.3.11 Central Wilks’ Lambda: qtf, isf (Rao)


    def wilks_lambda_rao_qtf(self, ctx, L, R, p, f1, f2):
        L = ctx.t(L)
        R = ctx.t(R)
        p = ctx.t(p)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().wilks_lambda_rao_qtf(ctx, L, R, p, f1, f2)


    def wilks_lambda_bp_qtf(self, ctx, L, R, p, f1, f2):
        L = ctx.t(L)
        R = ctx.t(R)
        p = ctx.t(p)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        return ctxApprox().wilks_lambda_bp_qtf(ctx, L, R, p, f1, f2)




# 11.3.12 Central Hotelling’s 𝑇2: cdf, sf (Pillai and Young)


    def hotelling_t2_mu3_cdf(self, ctx, p, m, n, x):
        p = ctx.t(p)
        m = ctx.t(m)
        n = ctx.t(n)
        x = ctx.t(x)
        return ctxApprox().hotelling_t2_mu3_cdf(ctx, p, m, n, x)


# 11.3.13 Central Hotelling’s 𝑇2: qtf, isf (Pillai and Young)


    def hotelling_t2_mu3_qtf(self, ctx, p, m, n, L, R):
        p = ctx.t(p)
        m = ctx.t(m)
        n = ctx.t(n)
        L = ctx.t(L)
        R = ctx.t(R)
        return ctxApprox().hotelling_t2_mu3_qtf(ctx, p, m, n, L, R)


# 11.3.14 Central Pillai’s 𝑉 : cdf, sf (Ginzberg)


    def pillai_v_mu3_cdf(self, ctx, p, n1, n2, x):
        p = ctx.t(p)
        n1 = ctx.t(n1)
        n2 = ctx.t(n2)
        x = ctx.t(x)
        return ctxApprox().pillai_v_mu3_cdf(ctx, p, n1, n2, x)


# 11.3.15 Central Pillai’s 𝑉 : qtf, isf (Ginzberg)


    def pillai_v_mu3_qtf(self, ctx, p, n1, n2, L, R):
        p = ctx.t(p)
        n1 = ctx.t(n1)
        n2 = ctx.t(n2)
        L = ctx.t(L)
        R = ctx.t(R)
        return ctxApprox().pillai_v_mu3_qtf(ctx, p, n1, n2, L, R)


# 11.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)


    def beta_product_mu3_pdf(self, ctx, x, p, b, c):
        p = ctx.t(p)
        # b[] needs extra code
        # c[] needs extra code
        x = ctx.t(x)
        return ctxApprox().beta_product_mu3_pdf(ctx, x, p, b, c)


    def beta_product_mu3_cdf(self, ctx, x, p, b, c):
        p = ctx.t(p)
        # b[] needs extra code
        # c[] needs extra code
        x = ctx.t(x)
        return ctxApprox().beta_product_mu3_cdf(ctx, x, p, b, c)


# 11.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)


    def beta_product_mu3_qtf(self, ctx, L, R, p, b, c):
        p = ctx.t(p)
        # b[] needs extra code
        # c[] needs extra code
        L = ctx.t(L)
        R = ctx.t(R)
        return ctxApprox().beta_product_mu3_qtf(ctx, L, R, p, b, c)


# %%%  11.4 Approximations based on the noncentral chi-squared distribution

# 11.4.1 Non-central Wilks’ Lambda (GLM): cdf and sf (Fujikoshi)


    def wilks_lambda_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().wilks_lambda_glm_chi2_cdf(ctx, p, q, n, x, omega)


# 11.4.2 Non-central Wilks’ Lambda (independence): cdf and sf (Lee)


    def wilks_lambda_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().wilks_lambda_ind_chi2_cdf(ctx, p, q, n, x, omega)


# 11.4.3 Non-central Pillai’s V (GLM): cdf and sf Fujikoshi


    def pillai_v_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().pillai_v_glm_chi2_cdf(ctx, p, q, n, x, omega)


# 11.4.4 Non-central Pillai’s V (independence): cdf and sf (Lee)


    def pillai_v_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().pillai_v_ind_chi2_cdf(ctx, p, q, n, x, omega)


# 11.4.5 Non-central Hotelling 𝑇2 (GLM): cdf and sf (Fujikoshi)


    def hotelling_t2_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().hotelling_t2_glm_chi2_cdf(ctx, p, q, n, x, omega)


# 11.4.6 Non-central Hotelling 𝑇2 (independence): cdf and sf (Lee)


    def hotelling_t2_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().hotelling_t2_ind_chi2_cdf(ctx, p, q, n, x, omega)


# %%%  11.5 Approximations based on the noncentral F or beta distribution

# 11.5.1 Multiple correlation coefficient (Lee and Gurland)


    def fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2):
        r2 = ctx.t(r2)
        f1 = ctx.t(f1)
        f2 = ctx.t(f2)
        Rho2 = ctx.t(Rho2)
        return ctxApprox().fisher_r2_lee_mu3_cdf(ctx, r2, f1, f2, Rho2)


# 11.5.2 Noncentral Wilks’ Lambda under the GLM or independence alternative


    def wilks_lambda_glm_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().wilks_lambda_glm_mu2_cdf(ctx, p, q, n, x, omega)

    def wilks_lambda_ind_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().wilks_lambda_ind_mu2_cdf(ctx, p, q, n, x, omega)


# 11.5.4 Noncentral Pillai’s V under the GLM or independence alternative


    def pillai_v_glm_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().pillai_v_glm_mu2_cdf(ctx, p, q, n, x, omega)

    def pillai_v_ind_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().pillai_v_ind_mu2_cdf(ctx, p, q, n, x, omega)


# 11.5.3 Noncentral Hotelling’s T under the GLM or independence alternative


    def hotelling_t2_glm_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().hotelling_t2_glm_mu2_cdf(ctx, p, q, n, x, omega)

    def hotelling_t2_ind_mu2_cdf(self, ctx, p, q, n, x, omega):
        p = ctx.t(p)
        q = ctx.t(q)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().hotelling_t2_ind_mu2_cdf(ctx, p, q, n, x, omega)


# 11.5.5 Noncentral Roy’s largest root under the GLM or independence alternative


    def roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega):
        p = ctx.t(p)
        m = ctx.t(m)
        n = ctx.t(n)
        x = ctx.t(x)
        # omega[] needs extra code
        return ctxApprox().roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega)


# %%%  11.6 Approximations based on hypergeometric functions of scalar argument

# 11.6.1 Hypergeometric function 1F1 for matrix argument (Butler’s approximation)


    def hypergeom_matrix_1f1_butler(self, ctx, a, b, x):
        a = ctx.t(a)
        b = ctx.t(b)
        # x[] needs extra code
        return ctxApprox().hypergeom_matrix_1f1_butler(self, ctx, a, b, x)


# 11.6.3 Hypergeometric function 2F1 for matrix argument (Butler’s approximation)

    def hypergeom_matrix_2f1_butler(self, ctx, a, b, c, x):
        a = ctx.t(a)
        b = ctx.t(b)
        c = ctx.t(c)
        # x[] needs extra code
        return ctxApprox().hypergeom_matrix_2f1_butler(self, ctx, a, b, c, x)


# %% 12 Numerical calculus (multiprecision floating point arithmetic)


# %%% 12.2 Rootfinder (Brent)

    def AdjustSign(self, UseLeftTail, x):
        if (UseLeftTail):
            return x
        else:
            return -x

    def Brent(self, ctx,  func, UseLeftTail, a, b, fa, fb, LogTarget):
        eps = ctx.t("1E-30")
        iter = 0
        maxiter = 1000
        if fa * fb > 0:
            raise("f(a) und f(b) need to have different sign")
        c = a
        fc = fa
        d = b - a
        e = d
        while iter < maxiter:
            iter = iter + 1
            if fb * fc > 0:
                c = a
                fc = fa
                d = b - a
                e = d
            if ctx.fabs(fc) < ctx.fabs(fb):
                a = b
                b = c
                c = a
                fa = fb
                fb = fc
                fc = fa
            tol = 2 * eps * ctx.fabs(b)
            m = (c - b) / 2  # 'Tolerance
            if (ctx.fabs(m) > tol) and (ctx.fabs(fb) > 0):
                if (ctx.fabs(e) < tol) or (ctx.fabs(fa) <= ctx.fabs(fb)):
                    d = m
                    e = m
                else:
                    s = fb / fa
                    if (a == c):
                        p = 2 * m * s
                        q = 1 - s
                    else:
                        q = fa / fc
                        r = fb / fc
                        p = s * (2 * m * q * (q - r) - (b - a) * (r - 1))
                        q = (q - 1) * (r - 1) * (s - 1)
                    if p > 0:
                        q = -q
                    else:
                        p = -p
                    s = e
                    e = d
                    if (2 * p < 3 * m * q - ctx.fabs(tol * q)) and (p < ctx.fabs(s * q / 2)):
                        d = p / q
                    else:
                        d = m
                        e = m
                a = b
                fa = fb
                if ctx.fabs(d) > tol:
                    b = b + d
                else:
                    if m > 0:
                        b = b + tol
                    else:
                        b = b - tol
            else:
                print("iter: ", iter,  "ctx.fabs(m): ", ctx.fabs(m))
                print("tol: ", tol)
                print("ctx.fabs(fb): ", ctx.fabs(fb))
                xs = b
                return xs
            LogRefTail = func(b)
            fb = self.AdjustSign(UseLeftTail, LogTarget - LogRefTail)
            #print("iter: ", iter, "a: ", a, "b: ", b, "fa: ", fa, "fb: ", fb, "ctx.fabs(m): ", ctx.fabs(m))
            print("iter: ", iter,  "ctx.fabs(m): ", ctx.fabs(m))


# %% 13 Algebra with random variables


# %%% 13.3 Probability density function (pdf)

# 13.3.1 Calculating the pdf from the cdf


    def pdf_from_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.3.2 Calculating the pdf from the characteristic function
    def pdf_from_cf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.4 Probability mass function (pmf)

# 13.4.1 Calculating the pmf from the cdf


    def pmf_from_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.4.2 Calculating the pmf from the characteristic function
    def pmf_from_cf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.4.3 Calculating the pmf from the factorial moments
    def pmf_from_factorialmoments(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 13.4.4 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.5 Cumulative distribution function (cdf)


# 13.5.1 Calculating the cdf from the pdf


    def cdf_from_pdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.5.2 Calculating the cdf from the pmf vector
    def cdf_from_pmf_vector(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 13.5.3 Calculating the cdf from the characteristic function, continuous cdf


    def cdf_from_cf_continuous(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 13.5.4 Calculating the cdf from the characteristic function (lattice distribution)


    def cdf_from_cf_lattice(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.5.5 Calculating the cdf from the factorial moments (lattice distributions)
    def cdf_from_factorial_moments_lattice(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.6 Percentage point function

# 13.6.1 Calculating the percentage point function from the cdf


    def qtf_from_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 13.6.2 Approximating the pmf with asymptotic expansions
    # no general function


# %%% 13.7 Characteristic function

# 13.7.1 Calculating the characteristic function from the pdf


    def cf_from_pdf(self, ctx, cf):
        raise Exception("NOT IMPLEMENTED")

# 13.7.2 Calculating the characteristic function from the pmf (lattice distribution)
    def cf_from_pmf(self, ctx, cf):
        raise Exception("NOT IMPLEMENTED")

# 13.7.3 Calculating the characteristic function from the percentage point function
    def cf_from_qtf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.7.4 Calculating the characteristic function from the raw moments
    def cf_from_rawmoments(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.8 Moment generating function

# 13.8.1 Calculating the moment-generating function from the pdf


    def mgf_from_pdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.8.2 Calculating the moment-generating function from the characteristic function
    def mgf_from_cf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.8.3 Calculating the moment-generating function from the cumulant-generating function
    def mgf_from_cgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.8.4 Calculating the moment-generating function from the probability-generating function
    def mgf_from_pgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.8.5 Calculating the moment-generating function from the raw moments
    def mgf_from_rawmoments(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.8.6 Calculating the moment-generating function from the pmf vector
    def mgf_from_pmf_vector(self, ctx, t, pmfvec):
        et = ctx.exp(t)
        etk = 1
        msum = 0
        for k in range(0, pmfvec.rows):
            msum += pmfvec[k] * etk
            etk *= et
            #print("k:", k, "pmfvec[k]:", pmfvec[k])
        return msum


# %%% 13.9 Cumulant generating function

# 13.9.1 Calculating the cumulant-generating function from the characteristic function


    def cgf_from_cf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.9.2 Calculating the cumulant-generating function from the moment-generating function
    def cgf_from_mgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.9.3 Calculating the cumulant-generating function from the probability-generating function
    def cgf_from_pgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.9.4 Calculating the cumulant-generating function from the cumulants
    def cgf_from_cumulants(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.9.5 Calculating the cumulant-generating function from the the pmf vector
    def cgf_from_pmf_vector(self, ctx, t, pmfvec):
        return ctx.ln(self.mgf_from_pmf_vector(ctx, t, pmfvec))


# %%% 13.10 Probability generating function

# 13.10.1 Calculating the probability-generating function from the pmf vector


    def pgf_from_pmf_vector(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.10.1 Calculating the probability-generating function from the pmf vector
    def pgf_from_mgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.11 Factorial Moments


# 13.11.1 Calculating the factorial moments from the raw moments


    def factorialmoments_from_rawmoments(self, ctx, mraw):
        rmax = mraw.rows - 1
        mfac = ctx.matrix(rmax+1, 1)
        for r in range(0, rmax+1):
            sum1 = 0
            for j in range(0, r+1):
                S = ctx.stirling1(r, j)
                sum1 = sum1 + S * mraw[j]
            mfac[r] = sum1
        return mfac


# 13.11.2 Calculating the factorial moments from the cumulants


    def factorialmoments_from_cumulants(self, ctx, mraw):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.12 Raw Moments

# 13.13.1 Calculating the raw moments from the pdf


    def rawmoments_from_pdf(self, ctx, pdf):
        raise Exception("NOT IMPLEMENTED")


# 13.13.2 Calculating the raw moments from the pmf vector


    def rawmoments_from_pmfvector(self, ctx, x, nl, order, show=False):
        mu = ctx.matrix(order+3, 1)
        mu[1] = 0
        for i in range(0, nl+0):
            mu[1] = mu[1] + i * x[i]
        for i in range(0, nl+0):
            #print("i:", i,  "x(i):", x[i])
            for r in range(2, order+3):
                mu[r] = mu[r] + (i-mu[1])**r * x[i]
        if show:
            for r in range(2, order+3):
                print("r:", r, "mu[r]:", mu[r])
        return mu

# 13.13.3 Calculating the raw moments from the factorial moments
    def rawmoments_from_factorialmoments(self, ctx, mfac):
        rmax = mfac.rows - 1
        mraw = ctx.matrix(rmax+1, 1)
        for r in range(0, rmax+1):
            sum1 = 0
            for j in range(0, r+1):
                S = ctx.stirling2(r, j)
                sum1 = sum1 + S * mfac[j]
            mraw[r] = sum1
        return mraw

# 13.13.4 Calculating the raw moments from the central moments
    def rawmoments_from_centralmoments(self, ctx, mu):
        rmax = mu.rows - 1
        mraw = ctx.matrix(rmax+1, 1)
        for r in range(0, rmax+1):
            sum1 = 0
            for j in range(0, r+1):
                S = ctx.stirling2(r, j)
                sum1 = sum1 + S * mu[j]
            mraw[r] = sum1
        return mraw

# 13.13.5 Calculating the raw moments from the cumulants
    def rawmoments_from_cumulants(self, ctx, kappa):
        rmax = kappa.rows - 1
        mraw = ctx.matrix(rmax+1, 1)
        mraw[0] = 1
        mraw[1] = kappa[1]
        for r in range(2, rmax+1):
            sum1 = 0
            for j in range(1, r+0):
                S = ctx.binomial(r-1, j-1)
                sum1 = sum1 + S * mraw[r-j] * kappa[j]
            mraw[r] = sum1 + kappa[r]
        return mraw


# 13.13.6 Calculating the raw moments from the moment-generating function


    def rawmoments_from_mgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.13.7 Calculating the raw moments from the characteristic function
    def rawmoments_from_cf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 13.13.8 Calculating the raw moments from the probability-generating function
    def rawmoments_from_pgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.13 Central Moments

# 13.13.1 Calculating the central moments from the factorial moments


    def centralmoments_from_factorialmoments(self, ctx, mfac):
        mraw = self.rawmoments_from_factorialmoments(ctx, mfac)
        kappa = self.centralmoments_from_rawmoments(ctx, mraw)
        return kappa

# 13.13.1 Calculating the central moments from the raw moments
    def centralmoments_from_rawmoments(self, ctx,  mraw):
        k = mraw.rows - 1
        mu = ctx.matrix(k+1, 1)
        mu[0] = 1
        mu[1] = mraw[1]
        for n in range(2, k+1):
            sum1 = ctx.t(0)
            BK = ctx.t(1)
            prod = ctx.t(1)
            sign = 1
            j = n
            while (j >= 0):
                sum1 = sum1 + sign * BK * mraw[j] * prod
                BK = (BK * j) / (n - j + 1)
                sign = -sign
                prod = prod * mu[1]
                j = j - 1
            mu[n] = sum1
        return mu

# 13.13.2 Calculating the central moments from the cumulants
    def centralmoments_from_cumulants(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %%% 13.14 Cumulants, standardized cumulants

# 13.14.1 Calculating the cumulants from the pmf vector


    def cumulants_from_pmfvector(self, ctx, x, nl, order, show=False):
        # print("cumulants_from_pmfvector()")
        mu = ctx.rawmoments_from_pmfvector(x, nl, order, False)
        kappa = ctx.cumulants_from_centralmoments(mu)
        if show:
            for i in range(1, kappa.rows):
                print("i:", i, "kappa:", kappa[i])
        return kappa

# 13.14.2 Calculating the cumulants from the factorial moments
    def cumulants_from_factorialmoments(self, ctx, mfac):
        mraw = self.rawmoments_from_factorialmoments(ctx, mfac)
        kappa = self.cumulants_from_rawmoments(ctx, mraw)
        return kappa

# 13.14.3 Calculating the cumulants from the raw moments
    def cumulants_from_rawmoments(self, ctx,  mu):
        k = mu.rows - 1
        kappa = ctx.matrix(k+1, 1)
        kappa[1] = mu[1]
        for r in range(1, k+1):
            sum1 = ctx.t(0)
            F = ctx.t(1)
            for j in range(1, r):
                sum1 = sum1 + F * mu[r - j] * kappa[j]
                F = (F * (r - j)) / j
            kappa[r] = mu[r] - sum1
        return kappa

# 13.14.4 Calculating the cumulants from the central moments
    def cumulants_from_centralmoments(self, ctx,  mu):
        k = mu.rows - 1
        #kappa = ctx.matrix(k+1, 1)
        kappa = mp_.matrix(k+1, 1)
        kappa[0] = 1
        kappa[1] = mu[1]
        for r in range(2, k+1):
            sum1 = ctx.t(0)
            F = ctx.t(r - 1)
            for j in range(2, r-1):
                sum1 = sum1 + F * mu[r - j] * kappa[j]
                F = (F * (r - j)) / j
            kappa[r] = mu[r] - sum1
        return kappa

# 13.14.5 Calculating the cumulants from the cumulant-generating function
    def CumulantToGamma(self, ctx,  m, kappa):
        k = kappa.rows - 1
        omega = ctx.matrix(k+1, 1)
        sigma = ctx.sqrt(kappa[2])
        sign = -1
        fakt = 2 * kappa[2]
        for i in range(3, m+1):
            fakt = fakt * sigma * i
            omega[i - 2] = sign * kappa[i] / fakt
            sign = -sign
        return omega


# %% Matrices as dictionaries


# %% Statistical data analysis


# %% Lerch’s transcendent and related functions

# %%%  16.3 Polylogarithms and related functions

    def debye(self, ctx, n, x):
        raise Exception("NOT IMPLEMENTED")
