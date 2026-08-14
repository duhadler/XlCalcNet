# -*- coding: utf-8 -*-
"""
@author: DH
"""



from xlcalcnet.dist_base import ctx_rv_cont


# Noncentral distribution functions

# %% Noncentral chi^2-distribution



class ctx_chi2_nc(ctx_rv_cont):

    def __init__(self, ctx, n, lambda1):
        self.set_ctx(ctx)
        self.n = ctx.t(n)
        self.lambda1 = ctx.t(lambda1)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x, method='default'):
        r"""
        Return the pdf of a non-central chi-squared  distribution with n degrees
        of freedom and noncentrality parameter lambda1.

        Parameters
        ----------
        x : The value for which the pdf is evaluated (a real scalar of type ctx.mpf)

        Returns
        -------
        the value of the pdf (a real scalar of type ctx.mpf)

        Use this function like this:

        .. code-block:: python

            rv = mpm2.dist_chi2_nc(10,10)
            res = rv.pdf(5)

        The pdf can be expressed as

        :math:`\text{pdf}_X(x) = f_{\chi^2}\left(n, x; \lambda_1\right)
        = f_{\chi^2}(x, n) \times e^{-\lambda_1/2}  \times
        {}_0F_1 \left(-; \frac{n}{2}; \frac{x \lambda_1}{4}\right).`

        **References**

        1. Wikipedia contributors. *Noncentral chi-squared distribution.
        Wikipedia, the free encyclopedia*.
        https://en.wikipedia.org/wiki/Noncentral_chi-squared_distribution
        """
        ctx = self.ctx
        x = ctx.t(x)
        if method == 'default':
            return chi2_nc_pdf_hyper(ctx, self.n, x, self.lambda1)
        if method == 'bessel':
            return chi2_nc_pdf_bessel(ctx, self.n, x, self.lambda1)
        if method == 'hyper':
            return chi2_nc_pdf_hyper(ctx, self.n, x, self.lambda1)

    def cdf(self, x, method='default'):
        ctx = self.ctx
        x = ctx.t(x)
        if method == 'default':
            return chi2_nc_cdf_benton(ctx, x, self.n, self.lambda1)
        if method == 'benton':
            return chi2_nc_cdf_benton(ctx, x, self.n, self.lambda1)
        if method == 'chou':
            return chi2_nc_cdf_chou(ctx, x, self.n, self.lambda1)
        if method == 'cohen':
            return chi2_nc_cdf_cohen(ctx, x, self.n, self.lambda1)
        if method == 'penev':
            L1, R1 = chi2_nc_cdf_penev(ctx, x, self.n, self.lambda1)
            return L1
        if method == 'ecf':
            order = 10
            kappa = self.cumulants(order+3)
            L1, R1 = ctx.edgeworth(x, order, kappa)
            return L1
        if method == 'spa':
            order = 10
            s = self.saddleppoint(x)
            kderiv = self.k_x(s, order)
            L1, R1 = ctx.lugannani_rice(order, kderiv)
            return L1

    def sf(self, x, method='default'):
        ctx = self.ctx
        x = ctx.t(x)
        if method == 'default':
            return chi2_nc_sf_benton(ctx, x, self.n, self.lambda1)
        if method == 'benton':
            return chi2_nc_sf_benton(ctx, x, self.n, self.lambda1)
        if method == 'chou':
            return 1-chi2_nc_cdf_chou(ctx, x, self.n, self.lambda1)
        if method == 'cohen':
            return 1-chi2_nc_cdf_cohen(ctx, x, self.n, self.lambda1)
        if method == 'penev':
            L1, R1 = chi2_nc_cdf_penev(ctx, x, self.n, self.lambda1)
            return R1
        if method == 'ecf':
            order = 10
            kappa = self.cumulants(order+3)
            L1, R1 = ctx.edgeworth(x, order, kappa)
            return R1
        if method == 'spa':
            order = 10
            s = self.saddleppoint(x)
            kderiv = self.k_x(s, order)
            L1, R1 = ctx.lugannani_rice(order, kderiv, s, True)
            return R1

    def qtf(self, q, method='default'):
        ctx = self.ctx
        q = ctx.t(q)
        if (method == 'default') or (method == 'patnaik'):
            return chi2_nc_qtf_patnaik(ctx, self.n, self.lambda1, q, 1-q)
        if method == 'ecf':
            order = 10
            kappa = self.cumulants(order+3)
            L1, R1 = ctx.edgeworth(q, order, kappa)
            return L1
        if method == 'spa':
            order = 10
            #s = self.saddleppoint(x)
            #kderiv = self.k_x(s, order)
            #L1, R1 = ctx.jensen_inverse(order, kderiv, True)
            return None

    def isf(self, q, method='default'):
        ctx = self.ctx
        q = ctx.t(q)
        if (method == 'default') or (method == 'patnaik'):
            return chi2_nc_qtf_patnaik(self.n, self.lambda1, 1-q, q)
        if (method == 'default') or (method == 'ecf'):
            order = 10
            kappa = self.cumulants(order+3)
            L1, R1 = ctx.edgeworth(q, order, kappa)
            return R1

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return ctx.exp((self.lambda1 * t *1j) / \
                (1-2*t*1j))*(1-2*t*1j)**(-self.n/2)

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        # note: t < 0.5 required
        return ctx.exp((self.lambda1 * t) / \
                (1-2*t))*(1-2*t)**(-self.n/2)

    def k_x(self, t, order):
        ctx = self.ctx
        t = ctx.t(t)
        # note: t < 0.5 required
        kderiv = ctx.matrix(order+2, 1)
        kderiv[0] = -(self.n/2) * ctx.log(1-2*t) + self.lambda1*t/(1-2*t)
        for j in range(1, order+1):
            p1 = (2 ** (j - 1)) * ctx.gamma(j) / ((1 - 2 * t) ** j)
            p2 = (self.n + (self.lambda1 * j) / (1 - 2 * t))
            kderiv[j] = p1 * p2
        return kderiv

    def saddleppoint(self, x):
        ctx = self.ctx
        s = -(1 / (4 * x)) * (self.n - 2 * x + \
            ctx.sqrt(self.n * self.n + 4 * x * self.lambda1))
        return s


    def cumulants(self, k):
        ctx = self.ctx
        k = int(k)
        kappa = ctx.matrix(k+1, 1)
        kappa[0] = 1
        kappa[1] = self.n + self.lambda1
        for i in range(2, k+1):
            kappa[i] = kappa[i - 1] * 2 * (i-1) * \
                (1 + self.lambda1 / (self.n + (i-1) * self.lambda1))
        return kappa

    def chi2_nc_cl(self, alpha, beta):
        ctx = self.ctx
        '''for the non-central 𝜒2-distribution,returns the confidence
        limit for lambda1'''
        return chi2_nc_cl_winterbottom(ctx, self.n, alpha, beta)






# Noncentral chi^2-distribution, pdf
def chi2_nc_pdf_bessel(ctx, k, x, l):
    t1 = ctx.exp(-(x+l)/2)
    t2 = (x/l)**(k/4-1/2)
    t3 = ctx.besseli(k/2-1, ctx.sqrt(l*x))
    return t1 * t2 * t3 / 2

def chi2_nc_pdf_hyper(ctx, nu, x, l):
    dens0 = ctx.chi2_pdf(x, nu)
    hyper = ctx.hyp0f1(nu/2, l * x / 4)
    result = dens0 * ctx.exp(-l / 2) * hyper
    return result


# Noncentral chi^2-distribution, cdf (Boost, Benton)

def chi2_nc_q(ctx, x, f, theta, init_sum):
    if (x == 0):
        return 1.0
    lambda1 = theta / 2
    del1 = f / 2
    y = x / 2
    max_iter = 1000000
    errtol = 0.000000000000001
    sum = init_sum
    k = int(lambda1)
    poisf = ctx.gamma_p_derivative((1 + k), lambda1)
    poisb = poisf * k / lambda1
    gamf = ctx.gamma_q(del1 + k, y)
    xtermf = ctx.gamma_p_derivative(del1 + 1 + k, y)
    xtermb = xtermf * (del1 + k) / y
    gamb = gamf - xtermb
    i = 0
    for i in range(k, (max_iter - (i - k))+1):
        term = poisf * gamf
        sum += term
        poisf *= lambda1 / (i + 1)
        gamf += xtermf
        xtermf *= y / (del1 + i + 1)
        if (((sum == 0) or (ctx.fabs(term / sum) < errtol))
            and (term >= poisf * gamf)):
            break
    if ((i - k) >= max_iter):
        print("non_central_chi_squared_distribution series did not " +
            "converge, closest value was ", sum)
        return 0.0

    for i in range(k - 1, -1, -1):
        term = poisb * gamb
        sum += term
        poisb *= i / lambda1
        xtermb *= (del1 + i) / y
        gamb -= xtermb
        if ((sum == 0) or (ctx.fabs(term / sum) < errtol)):
            break
    return sum

def chi2_nc_p(ctx, y, n, lambda1, init_sum):
    if (y == 0):
        return 0.0
    max_iter = 1000000
    errtol = 0.000000000000001
    errorf = 0.0
    errorb = 0.0
    x = y / 2
    del1 = lambda1 / 2
    k = int(lambda1)
    a = n / 2 + k
    gamkf = ctx.gamma_p(a, x)
    if (lambda1 == 0):
        return gamkf
    gamkb = gamkf
    poiskf = ctx.real_gamma_derivative((k + 1), del1)
    poiskb = poiskf
    xtermf = ctx.real_gamma_derivative(a, x)
    xtermb = xtermf * x / a
    sum = init_sum + poiskf * gamkf
    if (sum == 0):
        return sum
    i = 1
    while (i <= k):
        xtermb *= (a - i + 1) / x
        gamkb += xtermb
        poiskb = poiskb * (k - i + 1) / del1
        errorf = errorb
        errorb = gamkb * poiskb
        sum += errorb
        if ((ctx.fabs(errorb / sum) < errtol) and (errorb <= errorf)):
            break
        i = i + 1
    i = 1
    while True:
        xtermf = xtermf * x / (a + i - 1)
        gamkf = gamkf - xtermf
        poiskf = poiskf * del1 / (k + i)
        errorf = poiskf * gamkf
        sum += errorf
        i = i + 1
        if not ((ctx.fabs(errorf / sum) > errtol) and ((i) < max_iter)):
            break
    if ((i) >= max_iter):
        print("non_central_chi_squared_distribution series did not " +
                "converge, closest value was", sum)
        return sum
    return sum


def chi2_nc_cdf_benton(ctx, x, k, l):
    invert = False
    if (x > k + l):
        result = chi2_nc_q(ctx, x, k, l, -1.0)
        invert = not (invert)
    else:
        result = chi2_nc_p(ctx, x, k, l, 0.0)
    if invert:
        result = -result
    return result

def chi2_nc_sf_benton(ctx, x, k, l):
    invert = True
    if (x > k + l):
        result = chi2_nc_q(ctx, x, k, l, 0.0)
        invert = not (invert)
    else:
        result = chi2_nc_p(ctx, x, k, l, -1.0)
    if invert:
        result = -result
    return result



# Noncentral chi^2-distribution, cdf (Chou1985)

def chi2_nc_cdf_chou(ctx, x, n, lambda1):

    def f1(ctx, x, n, l1, c1, y):
        y = ctx.t(y)
        xy = ctx.sqrt(x-y)
        t1 = ctx.ndis(xy-l1)
        t2 = ctx.ndis(-xy-l1)
        t3 = ctx.ndens(ctx.sqrt(y))
        t4 = t3 * (t1 - t2)
        t5 = y ** ((n-3)/2)
        t6 = t4 * t5
        res = t6 * c1
        return res

    x = ctx.t(x)
    n = ctx.t(n)
    lambda1 = ctx.t(lambda1)
    l1 = ctx.sqrt(lambda1)
    t1a = 2**(0.5*(1-n)) * ctx.sqrt(2*ctx.pi)
    t2a = ctx.gamma(0.5*(n-1))
    c1 = t1a/t2a

    res = 1
    res = ctx.quad(lambda y: f1(ctx, x, n, l1, c1, y), [0, x])
    #plot(lambda y: self.chi2nc_cdf_(x, n, lambda1, y), [0, x])
    return res





# Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)

def chi2_nc_cdf_cohen(ctx, X0, n0, lambda0_):
    half = ctx.convert(0.5)
    n = int(n0)
    X = ctx.convert(X0)
    lambda_ = ctx.convert(lambda0_)
    x1 = ctx.sqrt(X)
    d = ctx.sqrt(lambda_)
    e = ctx.exp(half * (X + lambda_))
    g1 = ctx.cosh(ctx.sqrt(X * lambda_)) / ctx.sqrt(2 * ctx.pi * X) / e
    g3 = ctx.sinh(ctx.sqrt(X * lambda_)) / ctx.sqrt(2 * ctx.pi * lambda_) / e
    F1 = ctx.ndis(x1 - d) - ctx.ndis(-x1 - d)
    F3 = F1 - 2 * g3
    i = 5
    while i <= n:
        g5 = (X * g1 - (i - 4) * g3) / lambda_
        F5 = F3 - 2 * g5
        g1 = g3
        g3 = g5
        F3 = F5
        i = i + 2
    return F3



# Non-central chi-squared distribution: cdf and sf (Penev)

def chi2_nc_cdf_penev(ctx, x, n, l):
    m2 = l / n
    if m2 == 0: s = x / n
    else: s = (-1 + ctx.sqrt(1 + (4 * x * m2) / n)) / (2 * m2)
    if s == 1: s = 1 + 0.0000001 / n
    if s > 1: sg = 1
    else: sg = -1
    if s <= 0: si = 1;  y = 1 - s
    else: y = 1 - 1 / s;  si = -1
    if y == 0: hs = 0.0
    else: hs = si * (1 / (y*y) * ((1 - y) * ctx.log(1 - y) + y - 0.5 * y*y))
    z = n * (s - 1) ** 2
    z = z * (1 / (2 * s) + m2 - (1 / s) * hs)
    z = z - ctx.log(1 / s - (2 / s) * hs / (1 + 2 * m2 * s))
    z = z + (2 * (1 + 3 * m2) ** 2) / (9 * n * (1 + 2 * m2) ** 3)
    z = sg * ctx.sqrt(ctx.fabs(z))
    LeftTail = ctx.ndis(z)
    RightTail = ctx.ndis(-z)
    return LeftTail, RightTail



# 11.2.2 Non-Central chi-squared: qtf, isf (Patnaik)

def chi2_nc_qtf_patnaik(ctx, n, lambda1, LeftTail, RightTail):
    n1 = (n + lambda1) ** 2 / (n + 2 * lambda1)
    b = lambda1 / (n + lambda1)
    x = ctx.cdisx(LeftTail, RightTail, n1)
    return (1 + b) * x



# Non-Central chi-squared: confidence limit for 𝜆 (Winterbottom)

def chi2_nc_cl_winterbottom(self, ctx, n, alpha, beta):
    X = ctx.ndisx(1 - beta, beta)
    Chi2 = ctx.cdisx(1 - alpha, alpha, n)
    t = (Chi2 - n) / n
    n = n
    t2 = t * t
    t3 = t2 * t
    t4 = t3 * t
    x2 = X * X
    x3 = x2 * X
    x4 = x3 * X
    x5 = x4 * X
    y = 2 * t + 1
    Y_12 = ctx.sqrt(y)
    Y_32 = y * Y_12 * ctx.sqrt(n)
    Y_52 = y * Y_32
    Y_4 = Y_52 * Y_32
    Y_112 = Y_4 * Y_32
    lambda1 = n * t + ctx.sqrt(2 * n * y) * X + 2 * ((3 * t + 2) * x2  \
        + (3 * t + 1)) / (3 * y) - ctx.sqrt(2) * ((6 * t + 5) * x3   \
        - (36 * t2 + 42 * t + 17) * X) / (18 * Y_52) + ((324 * t2 + 594 * t  \
        + 276) * x4 - (1080 * t3 + 2484 * t2 + 2394 * t + 976) * x2 \
        + (1080 * t3 + 1512 * t2 + 612 * t + 148)) / (405 * Y_4) \
        - ctx.sqrt(2) * ((10368 * t3 + 30780 * t2 + 30564 * t + 10143) * x5 \
        - (25920 * t4 + 98928 * t3 + 163080 * t2 + 137544 * t + 47188) * x3 \
        + (45360 * t4 + 106704 * t3 + 80460 * t2 + 31092 * t + 13489) * X) \
        / (9720 * Y_112)
    if lambda1 < 0:
        lambda1 = 0.00001
    return lambda1, Chi2




# %% Noncentral chi-distribution



class ctx_chi_nc(ctx_rv_cont):

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





# %% Noncentral Rice-distribution



class ctx_rice(ctx_rv_cont):

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







# %% Noncentral t-distribution


class ctx_student_t_nc(ctx_rv_cont):

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




# Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)


def student_t_nc_benton_cdf_sf(ctx, x, n, delta, cdf=True):
    if cdf:
        return non_central_t_cdf(ctx, n, delta, x)
    else:
        return non_central_t_cdf_complement(ctx, n, delta, x)

def non_central_t_cdf(ctx, v, delta, t):
    return non_central_t_cdf_main(ctx, v, delta, t, False)

def non_central_t_cdf_complement(ctx, v, delta, t):
    return non_central_t_cdf_main(ctx, v, delta, t, True)

def non_central_t_cdf_main(ctx, v, delta, t, invert):
    if (t < 0):
        t = -t
        delta = -delta
        invert = not (invert)
    X = t * t / (v + t * t)
    y = v / (v + t * t)
    d2 = delta * delta
    a = 0.5
    b = v / 2
    c = a + b + d2 / 2
    cross = 1 - (b / c) * (1 + d2 / (2 * c * c))
    result = 0.0
    if (X < cross):
        if (X != 0):
            result = non_central_beta_p(ctx, a, b, d2, X, y, 0.0)
            result = non_central_t2_p(ctx, v, delta, X, y, result)
            result /= 2
        else:
            result = 0
            result += ctx.dist_normal(-delta, 0, 1, 2)
    else:
        invert = not (invert)
        if (X != 0):
            result = non_central_beta_q(ctx, a, b, d2, X, y, 0)
            result = non_central_t2_q(ctx, v, delta, X, y, result)
            result /= 2
        else:
            result = ctx.dist_normal(-delta, 0, 1, 2)
    if (invert):
        result = 1 - result
    return result

def non_central_t2_p(ctx, v, delta, x, y, init_val):
    max_iter = 1000000
    errtol = 0.000000000000001
    d2 = delta * delta / 2
    k = int(d2)
    if (k == 0):
        k = 1
    pois = 0
    if (k == 0):
        k = 1
    pois = ctx.real_gamma_derivative((k + 1), d2) \
        * ctx.gamma_delta_ratio(k + 1, 0.5) \
        * delta / ctx.sqrt(2)
    if (pois == 0):
        return init_val
    xterm = 0
    beta = 0
    if x < y:
        beta, xterm = ibeta_imp(ctx, k + 1, v / 2, x, False, True)
    else:
        beta, xterm = ibeta_imp(ctx, v / 2, k + 1, y, True, True)
    xterm *= y / (v / 2 + k)
    poisf = pois
    betaf = beta
    xtermf = xterm
    sum = init_val
    if ((beta == 0) and (xterm == 0)):
        return init_val
    last_term = 0
    count = 0
    for i in range(k, -1, -1):
        term = beta * pois
        sum += term
        if ((ctx.fabs(last_term) >= ctx.fabs(term))
            and (ctx.fabs(term / sum) < errtol)):
            break
        last_term = term
        pois *= (i + 0.5) / d2
        beta += xterm
        xterm *= (i) / (x * (v / 2 + i - 1))
        count = count + 1
    last_term = 0
    for i in range(k + 1, max_iter+1):
        poisf *= d2 / (i + 0.5)
        xtermf *= (x * (v / 2 + i - 1)) / (i)
        betaf -= xtermf
        term = poisf * betaf
        sum += term
        if ((ctx.fabs(last_term) >= ctx.fabs(term))
            and (ctx.fabs(term / sum) < errtol)):
            break
        last_term = term
        count = count + 1
        if (count >= max_iter):
            print(
                "cdf(non_central_t_distribution) Series did not " +
                "converge, closest value was {0}", sum)
            return sum
    return sum

def non_central_t2_q(ctx, v, delta, x, y, init_val):
    max_iter = 1000000
    errtol = 0.000000000000001
    d2 = delta * delta / 2
    k = int(d2)
    if (k == 0):
        k = 1
    pois = 0
    pois = ctx.real_gamma_derivative((k + 1), d2) \
        * ctx.gamma_delta_ratio(k + 1, 0.5) \
        * delta / ctx.sqrt(2)
    if (pois == 0):
        return init_val
    xterm = 0
    beta = 0
    if x < y:
        beta, xterm = ibeta_imp(ctx, k + 1, v / 2, x, False, True)
    else:
        beta, xterm = ibeta_imp(ctx, v / 2, k + 1, y, True, True)
    xterm *= y / (v / 2 + k)
    poisf = pois
    betaf = beta
    xtermf = xterm
    sum = init_val
    if ((beta == 0) and (xterm == 0)):
        return init_val
    last_term = 0
    count = 0
    j = k + 1
    for i in range(k + 1, max_iter+1):
        j = j - 1
        poisf *= d2 / (i + 0.5)
        xtermf *= (x * (v / 2 + i - 1)) / (i)
        betaf += xtermf
        term = poisf * betaf
        if (j >= 0):
            term += beta * pois
            pois *= (j + 0.5) / d2
            beta -= xterm
            xterm *= (j) / (x * (v / 2 + j - 1))
        sum += term
        if ((ctx.fabs(last_term) >= ctx.fabs(term))
            and (ctx.fabs(term / sum) < errtol)):
            break
        last_term = term
        if (count >= max_iter):
            print(
                "cdf(non_central_t_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
            return sum
        count = count + 1
    return sum


# Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)


def student_t_nc_cdf_owen(ctx, X0, n0, delta0):
    # Algorithm by Owen
    half = ctx.convert(0.5)
    one = ctx.convert(1)
    n = int(n0)
    X = ctx.convert(X0)
    d = ctx.convert(delta0)
    h = 2 / ctx.sqrt(2 * ctx.pi)
    a = X / ctx.sqrt(n)
    b2 = 1 / (1 + a * a)
    b = ctx.sqrt(b2)
    k = n % 2
    if k == 0:
        F = ctx.ndis(-d)
    else:
        F = ctx.ndis(-d * b) + 2 * ctx.owent(d * b, a)

    if n > 1:
        C0 = a * b * ctx.ndis(d * a * b) * ctx.exp(-half * d * d * b2)
        C1 = a * b2 * (d * C0 + half * ctx.exp(-half * d * d) * h)
        if k == 0:
            F = F + C0
        else:
            F = F + h * C1
        g = 1
        i = 2
        while not (i >= n - k):
            C = b2 * (one - one / i) * (a * g * d * C1 + C0)
            C0 = C1
            C1 = C
            i = i + 1
            g = one / (g * (i - 2))
            C = b2 * (one - one / i) * (a * g * d * C1 + C0)
            C0 = C1
            C1 = C
            i = i + 1
            g = one / (g * (i - 2))
            if k == 0:
                F = F + C0
            else:
                F = F + h * C1
    return F


# Singly noncentral t: pdf (Broda)

def student_t_nc_broda_pdf(self, ctx, x, n, delta):
    L, R, d = self.TDistDoublyNC_Broda_Combined(ctx, n, x, delta, 0)
    return d


#  Singly noncentral t: cdf, sf (Broda)

def student_t_nc_broda_cdf(self, ctx, x, n, delta):
    L, R, d = self.TDistDoublyNC_Broda_Combined(ctx, n, x, delta, 0)
    return L, R


#  Singly noncentral t: qtf, isf (Harley)

def student_t_nc_harley_qtf(self, ctx, alpha, df, delta):
    N = df + 2
    rho = delta * ctx.sqrt(2 / (2*N-3 + delta*delta))
    #print("rho:", rho)
    r3 = self.pearson_rho_wb_qtf(ctx, alpha, 1-alpha, N, rho)
    #print("r3:", r3)
    r3 = ctx.real(r3)
    #print("r3:", r3)
    t3 = ctx.sqrt(2*(N-2)*(1-rho*rho)) / ctx.sqrt(2-rho*rho)
    t3 = t3 * r3/ctx.sqrt(1-r3*r3)
    #print("t3:", t3)
    t3 = ctx.real(t3)
    #print("t3:", t3)
    return t3


# Singly noncentral t: confidence limit for 𝛿 (Akahira)

def student_t_nc_akahira_cl(self, ctx, IsGLM, Df2, t, beta):
    if IsGLM:
        # 'Algorithm by Akahira (1995)
        # Dim k As Double, bn As Double, a As Double, u As Double,
        # b As Double, c As Double
        nn = Df2
        bn = ctx.sqrt(
            2 / nn) * ctx.exp(ctx.LnGamma((nn + 1) / 2) - ctx.LnGamma(nn / 2))
        k = 1 + (1 - bn * bn) * t * t
        a = t * t * t * (1 / (nn * nn) + 1 / (4 * nn * nn * nn)) / (24 * k)
        b = -ctx.sqrt(k)
        c = bn * t - a
        u = ctx.ndisx(beta, 1 - beta)
        delta = a * u * u + b * u + c
    else:
        # 'Algorithm by Winterbottom (1980)
        r = t / ctx.sqrt(t * t + Df2)
        rho = ctx.pearson_rho_wb_cl(beta, 1 - beta, Df2 + 2, r)
        delta = rho * ctx.sqrt(Df2 / (1 - rho * rho))
    # End If
    print("delta: {0}", delta)
    return delta



# %% Noncentral Pearson’s 𝜌 distribution



class ctx_pearson_rho_nc(ctx_rv_cont):

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




# Algorithm using infinite series, Hotelling, 1953


def pearson_rho_nc_cdf_hotelling(ctx, r, n, rho):
    fs = [0, 0]
    Betas = [0, 0]
    Dens = [0, 0]
    slimit = 10000
    mlimit = 100
    IBeta = [0 for row in range(slimit)]
    nk = [0 for row in range(mlimit)]
    Swapped = False
    if rho > r:
        r = -r
        rho = -rho
        Swapped = True
    n = n - 1
    smax = -1
    Q = (n - 1) * 0.398942280401433
    Q = Q * ctx.exp(ctx.loggamma(n) - ctx.loggamma(n + 0.5))
    X = ((r - rho) / (1 - rho * r))
    X = X * X
    y = 1 - X
    Factor = 1
    A1 = 1 - rho * rho
    a = 1
    TWO = 1
    RelError = 1
    m = 0
    sum3 = 0
    sum = 0
    while ctx.fabs(RelError) > 0.0000000001:
        S = 0
        gf = 1
        RelError2 = 1
        while (ctx.fabs(RelError2) > 0.0000000001):
            if S > smax:
                smax = S
                if smax > slimit:
                    slimit = 2 * slimit
                    # ReDim Preserve IBeta(slimit)
                if (S % 2 != 0):
                    j = 1
                else:
                    j = 0
                if S <= 1:
                    LeftTail, Betas[j], Dens[j] = ctx.betadis3(
                        (S + 1) / 2, (n - 1) / 2, X, y)
                    fs[j] = ctx.exp(ctx.logbeta((S + 1) / 2, (n - 1) / 2))
                    Dens[j] = 2 * y * Dens[j]
                else:
                    fs[j] = fs[j] * (S - 1) / (n + S - 2)
                    Dens[j] = Dens[j] * X / (S - 1)
                    Betas[j] = Betas[j] + Dens[j]
                    Dens[j] = Dens[j] * (n + S - 2)
                IBeta[S] = Betas[j] * fs[j]
            if S == 0:
                sum3 = IBeta[0]
            else:
                gf = gf * rho * (1.5 - m - S) / S
                summand = gf * IBeta[S]
                sum3 = sum3 + summand
                if sum3 != 0:
                    RelError2 = ctx.fabs(summand / sum3)
            S = S + 1
        nk[m] = a * sum3 / 2
        a = a * A1
        if m == 0:
            sum = nk[0]
        else:
            TWO = TWO * 2
            Factor = Factor * (2.0 * m - 1) * (2.0 * m - 1) / \
                (m * 4 * (2 * n + 2 * m - 1))
            sum2 = TWO * nk[0]
            t2 = TWO
            sign = -1
            BK = 1
            for k in range(1, m+1):
                BK = BK * (m - k + 1) / k
                t2 = t2 / 2
                sum2 = sum2 + sign * BK * t2 * nk[k]
                sign = -sign

            sum2 = Factor * sum2
            sum = sum + sum2
            RelError = ctx.fabs(sum2 / sum)
        m = m + 1
        if m > mlimit:
            mlimit = 2 * mlimit
            # ReDim Preserve nk(mlimit)
    RightTail = Q * sum
    LeftTail = 1 - RightTail
    if Swapped:
        sum = RightTail
        RightTail = LeftTail
        LeftTail = sum
    return LeftTail, RightTail


# Algorithm using infinite series, Guenther 1971


def pearson_rho_nc_cdf_guenther(ctx, r, n, rho):
    Pi = 3.14159265358979
    Rho2 = rho * rho
    r2 = r * r
    if rho < 0:
        sign = -1
    else:
        if rho > 0:
            sign = 1
        else:
            sign = 0
    Left1, Right1 = ctx.betadis(1 / 2, (n - 1) / 2, Rho2, 1 - Rho2)
    sum0 = 0.5 * (1 + sign * Left1)
    if r == 0:
        RightTail = sum0
        LeftTail = 1 - RightTail
        return LeftTail, RightTail
    k1 = 0.5 * ctx.exp(ctx.log(1 - Rho2) * (n - 1) / 2)
    Left1, Right1 = ctx.betadis(1 / 2, (n - 2) / 2, r2, 1 - r2)
    sum1 = k1 * Left1
    sum3 = k1 * Right1
    j = 0
    RelError = 1
    RelError3 = 1
    while RelError > 0.00000000000001:
        j = j + 1
        k1 = ((2 * j + n - 3) / (2 * j)) * Rho2 * k1
        Left1, Right1 = ctx.betadis(
            (2 * j + 1) / 2, (n - 2) / 2, r2, 1 - r2)
        summand = k1 * Left1
        sum1 = sum1 + summand
        RelError = ctx.fabs(summand / sum1)
        summand = k1 * Right1
        sum3 = sum3 + summand
        if sum3 != 0:
            RelError3 = ctx.fabs(summand / sum3)
    if rho == 0:
        sum2 = 0
        sum4 = 0
    else:
        k2 = rho / ctx.sqrt(Pi) * ctx.exp(ctx.loggamma(n / 2) -
            ctx.loggamma((n - 1) / 2) + ctx.log(1 - Rho2) * (n - 1) / 2)
        Left1, Right1 = ctx.betadis(1, (n - 2) / 2, r2, 1 - r2)
        sum2 = k2 * Left1
        sum4 = k2 * Right1
        j = 0
        RelError = 1
        RelError3 = 1
        while RelError > 0.00000000000001:
            j = j + 1
            k2 = ((2 * j + n - 2) / (2 * j + 1)) * Rho2 * k2
            Left1, Right1 = ctx.betadis(j + 1, (n - 2) / 2, r2, 1 - r2)
            summand = k2 * Left1
            sum2 = sum2 + summand
            if sum2 != 0:
                RelError = ctx.fabs(summand / sum2)
            summand = k2 * Right1
            sum4 = sum4 + summand
            if sum4 != 0:
                pass
                RelError3 = ctx.fabs(summand / sum4); print(RelError3)
#                print (j, sum2, RelError, Left1)
#                print (j, sum4, RelError3, Right1)
    RightTail = sum0 - (sum1 + sum2)
    LeftTail = (1 - sum0) + (sum1 + sum2)
    return LeftTail, RightTail




def pearson_rho_nc_pdf_owen(ctx, r, N, rho):
    cdf, pdf = pearson_rho_nc_owen_pdf_cdf(ctx, r, N, rho)
    return pdf


def pearson_rho_nc_cdf_owen(ctx, r, N, rho):
    cdf, pdf = pearson_rho_nc_owen_pdf_cdf(ctx, r, N, rho)
    return cdf

def pearson_rho_nc_owen_pdf_cdf(ctx, r, N, rho):
    r = ctx.t(r)
    rho = ctx.t(rho)
    Pi = ctx.t(ctx.pi)
    r2 = r * r
    Rho2 = rho * rho
    X = r * rho
    x2 = X * X
    A2 = 1 - Rho2
    a = ctx.sqrt(A2)
    c2 = 1 - r2
    C = ctx.sqrt(c2)
    b2 = 1 - x2
    b = ctx.sqrt(b2)
    U = ctx.acos(-X) / b

    F = ctx.matrix(N + 1, 1)
    d = ctx.matrix(N + 1, 1)

    # This is calculating the pdf
    d[3] = A2 * (1 + X * U) / (Pi * b2 * C)
    d[4] = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi)
    for k in range(5, N+1):
        d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) +
                A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2

    # This is calculating the cdf for N = 3, 5
    if (N % 2) != 0:
        k1 = 2
        d1 = ctx.acos(-r) / Pi
        result = d1 - (rho * C * U) / Pi
        if (N == 3):
            return result, d[3]
        else:
            F[1 + k1] = result
        result = d1 + ((x2 + 2 - 3 * Rho2) * r * C * A2 + (Rho2 -
            3 + 2 * Rho2 * x2) * rho * c2 * C * U) / (2 * Pi * b2 * b2)
        if (N == 5):
            return result, d[5]
        else:
            F[3 + k1] = result
    else:
        # This is calculating the cdf for N = 4, 6
        k1 = 3
        d1 = ctx.acos(rho) / Pi
        result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2)
        if (N == 4):
            return result
        else:
            F[1 + k1] = result
        f6 = (X * r * (2 * x2 + 13) - 2 * rho * (4 * x2 * x2 +
              6 * x2 + 5) + Rho2 * rho * (11 * x2 + 4)) * a * c2
        f6u = ((-r2 + 3) + 2 * x2 * (-2 * r2 + 1)) * r * A2 * A2 * a * U
        result = d1 + (f6 + 3 * f6u) / (6 * Pi * b2 * b2 * b2)
        if (N == 6):
            return result
        else:
            F[3 + k1] = result
    # This is calculating the cdf for N > 7
    for k in range(k1 + 5, N+1, 2):
        k4 = k - 4
        sum1 = (2 * k4 * Rho2 - k + 5) * F[k - 2]
        sum2 = (k - 5) * A2 * F[k4]
        sum31 = rho * (k4 * a * C - (2 * k - 9) *
                    b2 / (a * C)) * d[k - 1] / k4
        k4 = k4 * k4
        sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d[k - 2] / k4
        sum3 = (sum31 + sum32)
        F[k] = (sum1 + sum2 + sum3) / ((k - 3) * Rho2)
        # print k, F(k + 5), sum1, sum2, sum31, sum32,
        #    (sum31 + sum32) / sum31
    return F[N], d[N]





# Pearson’s rho distribution: cdf and sf (Winterbottom, DH version)

def pearson_rho_wb_cdf(ctx, N, r, rho):
    m2 = 1 / (N - 1)
    m1 = ctx.sqrt(m2)
    m3 = m2 * m1
    m4 = m2 * m2
    m5 = m2 * m3
    r2 = r * r
    r3 = r2 * r
    r4 = r3 * r

    ua2 = 5.0
    F = ua2 / 10  # this is an attempt to correct for u^5

    a = m3 / 12 + (6 * r4 - 3 * r2 + 2 + F) * m5 / 48
    b = -r3 * m4 / 6
    C = m1 + (1 + r2) * m3 / 4 + (11 * r4 + 2 * r2 + 1) * m5 / 32
    d = r * m2 / 2 + (5 * r3 + 9 * r) * m4 / 24
    d = 0.5 * ctx.log((1 + rho) / (1 - rho)) - 0.5 * \
        ctx.log((1 + r) / (1 - r)) + d

    b = b / a
    C = C / a
    d = d / a
    d = d + b * C / 3 - 2 * b * b * b / 27
    C = C - b * b / 3
    # 'revise if negative
    p = ctx.sqrt(ctx.fabs((12 * C * C * C + 81 * d * d)))
    k = (108 * d + 12 * p) ** (1 / 3)
    X = k / 6 - 2 * C / k - b / 3
    return ctx.normal_cdf(-X)

def zTransformInverse(ctx, y):
    y = ctx.exp(2 * y)
    return (y - 1) / (y + 1)

def zTransform(ctx, r):
    return 0.5 * ctx.log((1 + r) / (1 - r))


# Pearson’s rho distribution: qtf and isf (Winterbottom)

def pearson_rho_wb_qtf(ctx, LeftTail, RightTail, n, rho):
    X = ctx.ndisx(ctx, LeftTail, RightTail)
    z = zTransform(ctx, rho)
    m = n - 1
    m2 = m * m
    m12 = ctx.sqrt(m)
    m32 = m * m12
    m52 = m2 * m12
    x2 = X * X
    x3 = x2 * X
    x4 = x3 * X
    x5 = x4 * X
    Rho2 = rho * rho
    rho3 = Rho2 * rho
    rho4 = rho3 * rho
    y = z + X / m12 + rho / (2 * m)
    y = y + (x3 + 3 * (3 - Rho2) * X) / (12 * m32)
    y = y + (4 * rho3 * x2 - rho3 + 15 * rho) / (24 * m2)
    y = y + (x5 + (-60 * rho4 + 30 * Rho2 + 80) * x3 +
             (45 * rho4 - 21 * Rho2 + 375) * X) / (480 * m52)
    rdisx = zTransformInverse(ctx, y)
    #print("rdisx: {0}", rdisx)
    return rdisx


# 11.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)

def pearson_rho_wb_cl(ctx, LeftTail, RightTail, N, r):
    X = -ctx.ndisx(ctx, LeftTail, RightTail)
    z = zTransform(r)
    m = N - 1
    m2 = m * m
    m12 = ctx.sqrt(m)
    m32 = m * m12
    m52 = m2 * m12
    x2 = X * X
    x3 = x2 * X
    x4 = x3 * X
    x5 = x4 * X
    r2 = r * r
    r3 = r2 * r
    r4 = r3 * r
    y = z + X / m12 - r / (2 * m)
    y = y + (x3 + 3 * (1 + r2) * X) / (12 * m32)
    y = y - (4 * r3 * x2 + 5 * r3 + 9 * r) / (24 * m2)
    y = y + (x5 + (60 * r4 - 30 * r2 + 20) * x3 +
             (165 * r4 + 30 * r2 + 15) * X) / (480 * m52)
    rdis_nc = zTransformInverse(y)
    return rdis_nc





# %% Noncentral F-distribution


class ctx_fisher_f_nc(ctx_rv_cont):

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




# Noncentral F distribution, pdf, cdf and sf (Boost)


def fisher_f_nc_benton_cdf_sf(self, ctx, x, m, n, lambda1, cdf=True):
    if cdf:
        return self.non_central_f_cdf(ctx, x, m, n, lambda1)
    else:
        return self.non_central_f_cdf_complement(ctx, x, m, n, lambda1)

def non_central_f_cdf(self, ctx, xparam, df1, df2, lambda1):
    alpha = df1 / 2
    beta = df2 / 2
    y = xparam * alpha / beta
    x = y / (1 + y)
    cx = 1 / (1 + y)
    result = self.non_central_beta_cdf(ctx, alpha, beta, lambda1, x, cx)
    return result

def non_central_f_cdf_complement(self, ctx, xparam, df1, df2, lambda1):
    alpha = df1 / 2
    beta = df2 / 2
    y = xparam * alpha / beta
    x = y / (1 + y)
    cx = 1 / (1 + y)
    result = self.non_central_beta_cdf_complement(
        ctx, alpha, beta, lambda1, x, cx)
    return result


def fisher_f_nc_seber_cdf(ctx, x, nu1, nu2, nc):
    # Algorithm by Seber
    nu1 = int(nu1)
    nu2 = ctx.convert(nu2)
    x = ctx.convert(x)
    nc = ctx.convert(nc)
    y = x * nu1 / (x * nu1 + nu2)
    result = beta_nc_seber_cdf(ctx, y, nu1/2, nu2/2, nc)
    return result









# %% Noncentral beta-distribution


class ctx_beta_nc_type_I(ctx_rv_cont):

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





# Noncentral Beta distribution, pdf, cdf and sf (Boost)


def beta_nc_benton_cdf_sf(self, ctx, x, a, b, lambda1, cdf=True):
    if cdf:
        return self.non_central_beta_cdf(ctx, a, b, lambda1, x, 1-x)
    else:
        return self.non_central_beta_cdf_complement(ctx, a, b, lambda1,
            x, 1-x)

def non_central_beta_cdf(self, ctx, a, b, lambda1, x, y):
    invert = False
    result = 0
    c = a + b + lambda1 / 2
    cross = 1 - (b / c) * (1 + lambda1 / (2 * c * c))
    if (x > cross):
        result = self.non_central_beta_q(ctx, a, b, lambda1, x, y, -1.0)
        invert = not (invert)
    else:
        result = self.non_central_beta_p(ctx, a, b, lambda1, x, y, 0.0)
    if invert:
        result = -result
    return result

def non_central_beta_cdf_complement(self, ctx, a, b, lambda1, x, y):
    invert = True
    result = 0
    c = a + b + lambda1 / 2
    cross = 1 - (b / c) * (1 + lambda1 / (2 * c * c))
    if (x > cross):
        result = self.non_central_beta_q(ctx, a, b, lambda1, x, y, 0.0)
        invert = not (invert)
    else:
        result = self.non_central_beta_p(ctx, a, b, lambda1, x, y, -1.0)
    if invert:
        result = -result
    return result

def ibeta_imp(self, ctx, a, b, x, inv, normalised):
    xterm = ctx.real_ibeta_derivative(a, b, x)
    return ctx.ibeta(a, b, x), xterm

def non_central_beta_p(self, ctx, a, b, lambda1, x, y, init_val):
    max_iter = 1000000
    errtol = 0.000000000000001
    l2 = lambda1 / 2
    k = int(l2)
    if (k == 0):
        k = 1
    pois = ctx.real_gamma_derivative((k + 1), l2)
    if (pois == 0):
        return init_val
    xterm = 0
    beta = 0
    if x < y:
        beta, xterm = self.ibeta_imp(ctx, a + k, b, x, False, True)
    else:
        beta, xterm = self.ibeta_imp(ctx, b, a + k, y, True, True)
    xterm *= y / (a + b + k - 1)
    poisf = pois
    betaf = beta
    xtermf = xterm
    sum = init_val
    if ((beta == 0) and (xterm == 0)):
        return init_val
    last_term = 0
    for i in range(k, -1, -1):
        term = beta * pois
        sum += term
        if (((ctx.fabs(term / sum) < errtol) and (last_term >= term))
            or (term == 0)):
            break
        pois *= i / l2
        beta += xterm
        xterm *= (a + i - 1) / (x * (a + b + i - 2))
        last_term = term
    for i in range(k+1, max_iter+1):
        poisf *= l2 / i
        xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
        betaf -= xtermf
        term = poisf * betaf
        sum += term
        if ((ctx.fabs(term / sum) < errtol) or (term == 0)):
            break
        if ((i) >= max_iter):
            print("cdf(non_central_beta_distribution) Series did not " +
                "converge, closest value was {0}", sum)
            return sum
    return sum

def non_central_beta_q(self, ctx, a, b, lambda1, x, y, init_val):
    max_iter = 1000000
    errtol = 0.000000000000001
    l2 = lambda1 / 2
    k = int(l2)
    pois = 0
    if (k <= 30):
        if (a + b > 1):
            k = 0
        else:
            if (k == 0):
                k = 1
    if (k == 0):
        pois = ctx.exp(-l2)
    else:
        pois = ctx.real_gamma_derivative((k + 1), l2)
    if (pois == 0):
        return init_val
    xterm = 0
    beta = 0
    if x < y:
        beta, xterm = self.ibeta_imp(ctx, a + k, b, x, True, True)
    else:
        beta, xterm = self.ibeta_imp(ctx, b, a + k, y, False, True)
    xterm *= y / (a + b + k - 1)
    poisf = pois
    betaf = beta
    xtermf = xterm
    sum = init_val
    if ((beta == 0) and (xterm == 0)):
        return init_val
    last_term = 0
    count = 0
    for i in range(k + 1, max_iter+1):
        poisf *= l2 / i
        xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
        betaf += xtermf

        term = poisf * betaf
        sum += term
        if ((ctx.fabs(term / sum) < errtol) and (last_term >= term)):
            count = i - k
            break
        if ((i - k) >= max_iter):
            print("cdf(non_central_beta_distribution) Series did not " +
                "converge, closest value was {0}", sum)
        last_term = term
    for i in range(k, -1, -1):
        term = beta * pois
        sum += term
        if (ctx.fabs(term / sum) < errtol):
            break
        if ((count + k - i) >= max_iter):
            print("cdf(non_central_beta_distribution) Series did not " +
                "converge, closest value was {0}", sum)
        pois *= i / l2
        beta -= xterm
        xterm *= (a + i - 1) / (x * (a + b + i - 2))
    return sum




# Noncentral Beta distribution, cdf (𝑏 an integer)


def beta_nc_seber_cdf(ctx, x0, a0, b0, lambda0_):
    # Algorithm by Seber
    b = int(b0)
    a = ctx.convert(a0)
    x = ctx.convert(x0)
    lambda_ = ctx.convert(lambda0_)
    C = (x ** a) * ctx.exp(lambda_ * (x - 1) / 2)
    b0 = 0
    b1 = 1
    S = 1
    k = 2
    while (k <= b):
        f = (2 * k - 4 + a + lambda_ * x / 2) * \
            b1 + (k - 3 + a) * (x - 1) * b0
        f = f * (1 - x) / (k - 1)
        S = S + f
        b0 = b1
        b1 = f
        k = k + 1
    return C * S




# %% Log of noncentral beta-distribution type 2



class ctx_logrv_beta_nc_type_II(ctx_rv_cont):

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





# %% Fisher R^2 distribution



class ctx_fisher_r2(ctx_rv_cont):

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



# Fisher’s 𝑅2 distribution, cdf and sf (Boost, Benton)

def fisher_r2_gd2_cdf(ctx, X, p, ng, Rho2):
    # Gurland 1968, equ. 38 and 39
    #print("p:", p, "N:", ng,"X:", X, "Rho2:",Rho2)
    a = 1.0 / (1 - Rho2)
    n = ng - 1
    k = (ng - p) / 2
    theta = Rho2 / (1 - Rho2)
    b = a
    BK = k
    p1 = (p - 1) / 2
    binom = 1
    t1 = 1
    y = 2 * k * X / (b * (1 - X))
    y = y / (y + 2 * k)
    lefttail1, RightTail1 = ctx.betadis(p1, k, y, 1 - y)
    sum = lefttail1
    j = 1
    while True:
        binom = binom * (BK - j + 1) / j
        t1 = t1 * theta
        cj = binom * t1
        lefttail1, RightTail1 = ctx.betadis(p1 + j, k, y, 1 - y)
        summand = cj * lefttail1
        sum = sum + summand
        RelErr = ctx.fabs(summand / sum)
        #print("RelErr:", RelErr)
        j = j + 1
        if (RelErr < 0.000000000001):
            break
    sum = sum * ctx.exp(ctx.log(b) * (p - 1) / 2)
    sum = sum / ctx.exp(ctx.log(a) * n / 2)
    LeftTail = sum
    RightTail = 1 - sum
    return LeftTail, RightTail




# Fisher’s 𝑅2 distribution, cdf (finite sum for 𝑁 − 𝑝 even)

def fisher_r2_gd1_cdf(ctx, x, p, N, Rho2):
    # Gurland 1968, equ. 33
    if ((N-p) % 2) != 0:
        print("p:", p, "N:", N, "x:", x, "Rho2:", Rho2)
        raise Exception("(N-p) needs to be an even number")
    y = x*(1-Rho2)/(1-Rho2*x)
    k = int((N - p) / 2)
    #print("k:", k)
    sum1 = 0
    bj = 1
    for j in range(0, k+1):
        bj = ctx.binomial(k, j) * Rho2**j * (1-Rho2)**(k-j)
        sum0 = bj * ctx.real_ibeta(0.5*(p-1+2*j), k, y)
        sum1 = sum1 + sum0
    LeftTail = sum1
    RightTail = 1 - sum1
    return LeftTail, RightTail






# %% Log of Fisher 1-R^2 distribution



class ctx_logrv_fisher_1mr2(ctx_rv_cont):

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




# %% Doubly noncentral t-distribution



class ctx_student_t_2nc(ctx_rv_cont):

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



# Doubly noncentral t: cdf, sf (Broda)

def TDistDoublyNC_Broda_Combined(ctx, n, x, mu, theta):
    n = ctx.t(n)
    x = ctx.t(x)
    mu = ctx.t(mu)
    theta = ctx.t(theta)
    x2 = x * x
    if theta != 0:
        x3 = x2 * x
        x4 = x2 * x2
        N2 = n * n
        a = x4 + 2 * n * x2 + N2
        c2 = (-2 * x3 * mu - 2 * x * n * mu) / a
        c1 = (x2 * mu * mu - n * x2 - N2 - theta * n) / a
        c0 = (x * n * mu) / a
        q = c1 / 3 - c2 * c2 / 9
        r = (c1 * c2 - 3 * c0) / 6 - c2 * c2 * c2 / 27
        s = ctx.sqrt(-4 * q) * ctx.cos((1 / 3) *
            ctx.acos(r / ctx.sqrt(-q * q * q))) - c2 / 3
        t1 = -mu + x * s
        t2 = -x * t1 / (2 * n * s)
        nu = 1 / (1 - 2 * t2)
        alpha = mu / ctx.sqrt(1 + theta / n)
        d = 1 / (t1 * s)
        u = ctx.sqrt((x2 + 2 * n * t2) * (2 * n * nu * nu + 4 *
            theta * nu * nu * nu) + 4 * N2 * s * s) / (2 * n * s * s)
        w = ctx.sqrt((-mu * t1 - n * ctx.log(nu) - 2 *
                     theta * nu * t2)) * ctx.sign(x - alpha)
    else:
        if (mu != 0):
            s = (mu * x + ctx.sqrt(4 * n * (x2 + n) +
                 mu * mu * x2)) / (2 * (x2 + n))
            t1 = -mu + x * s
            t2 = -x * t1 / (2 * n * s)
            nu = 1 / (1 - 2 * t2)
            d = 1 / (t1 * s)
            u = ctx.sqrt((mu * x * s + 2 * n) / (2 * n)) / s
            w = ctx.sqrt(-mu * t1 - 2 * n * ctx.log(s)) * ctx.sign(x - mu)
        else:
            s = ctx.sqrt(n / (x2 + n))
            d = 1 / (x * s * s)
            u = 1 / s
            w = ctx.sqrt(-2 * n * ctx.log(s)) * ctx.sign(x)
    u2 = u / d
    v = ctx.log(u2 / w)
    r2 = w + (v / w)
    #r2 = ctx.convert(r2.mid)
    r2 = ctx.convert(r2)
    LeftTail = ctx.ndis(r2)
    RightTail = ctx.ndis(-r2)
    density = ctx.ndens(w) / u
    return LeftTail, RightTail, density



# Doubly noncentral t: cdf, sf (Broda)

def student_t_nc2_broda_pdf(ctx, x, n, delta, theta):
    L, R, d = TDistDoublyNC_Broda_Combined(n, x, delta, theta)
    return d

def student_t_nc2_broda_cdf(ctx, x, n, delta, theta):
    L, R, d = TDistDoublyNC_Broda_Combined(ctx, n, x, delta, theta)
    return L, R




# %% Doubly noncentral F-distribution



class ctx_fisher_f_2nc(ctx_rv_cont):

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





# Doubly Non-central Fisher F, Butler's transformation


def fisher_f_nc2_spa(ctx, x, n1, n2, lambda1, lambda2):
    Order = 18
    s = FdisNCalcSaddlepoint(ctx, n1, n2, x, lambda1, lambda2)
    #print("s: ", s)
    kderiv = FdisNButlerKderiv(ctx, Order, s, n1, n2, lambda1, lambda2)
    LeftTail, RightTail = ctx.lugannani_rice(ctx, Order, kderiv, s)
    return LeftTail, RightTail

def FdisNButlerKderiv(ctx, Order, S_, N1_, N2_, t1_, t2_):
    S = ctx.convert(S_)
    N1 = ctx.convert(N1_)
    N2 = ctx.convert(N2_)
    t1 = ctx.convert(t1_)
    t2 = ctx.convert(t2_)
    F = FdisNButlerFromS(ctx, S_, N1_, N2_, t1_, t2_)
    l1 = N2 / N1
    v1 = 1 / (1 - 2 * S * l1)
    g1 = l1 * v1
    H1 = t1 * v1
    l2 = -F
    v2 = 1 / (1 - 2 * S * l2)
    g2 = l2 * v2
    h2 = t2 * v2
    #kderiv = ctx.matrix(Order+2, 1)
    kderiv = ctx.matrix(Order+2, 1)
    kderiv[0] = 0.5 * (N1 * ctx.log(v1) + N2 *
                       ctx.log(v2)) + S * (t1 * g1 + t2 * g2)
    #print("d: ", 0, " kderiv:", kderiv[0])
    kd = ctx.convert(1.0)
    gd1 = g1
    gd2 = g2
    for d in range(1, Order+1):
        kderiv[d] = kd * (gd1 * (N1 + d * H1) + gd2 * (N2 + d * h2))
        kd = 2 * d * kd
        gd1 = gd1 * g1
        gd2 = gd2 * g2
        #print("d: ", d, " kderiv:", kderiv[d])
    return kderiv

def FdisNButlerFromS(ctx, S_, N1_, N2_, t1_, t2_):
    S = ctx.convert(S_)
    N1 = ctx.convert(N1_)
    N2 = ctx.convert(N2_)
    t1 = ctx.convert(t1_)
    t2 = ctx.convert(t2_)
    l1 = N2 / N1
    v1 = 1 / (1 - 2 * S * l1)
    g1 = l1 * v1
    H1 = t1 * v1
    if t2 == 0:
        # print("Linear")
        C = -(g1 * (N1 + H1)) / N2
        f2 = -C / (1 + 2 * S * C)
    else:
        # print("Quadratic")
        C = -(g1 * (N1 + H1))
        a = 4 * C * S * S + 2 * S * N2
        b = -(4 * C * S + t2 + N2)
        Q = ctx.sqrt(b * b - 4 * a * C) / (2 * a)
        f2 = +(b / (2 * a)) + Q
    #print("F2:", f2)
    return f2

def FdisNCalcSaddlepoint(ctx, N1_, N2_, F_, t1_, t2_):
    S = ctx.convert(0)
    N1 = ctx.convert(N1_)
    N2 = ctx.convert(N2_)
    F = ctx.convert(F_)
    t1 = ctx.convert(t1_)
    t2 = ctx.convert(t2_)
    f2 = F * F
    n22 = N2 * N2
    n12 = N1 * N1
    if (t1_ * t2_) != 0:
        #print("in t1_ * t2_ != 0")
        a = 1 / (8 * f2 * n22 * (N1 + N2))
        a0 = (F * t2 * n12 - (1 - F) * n12 * N2 - N1 * N2 * t1) * a
        A1 = (2 * (n22 * N1 + n12 * N2 * f2) - 4 *
              F * N1 * N2 * (N1 + N2 + t1 + t2)) * a
        A2 = (8 * F * (1 - F) * N1 * n22 + 4 * F * (N2 * n22 +
              t2 * n22 - n12 * N2 * F - N1 * N2 * t1 * F)) * a / 3
        p = ctx.sqrt(ctx.fabs(A1 - 3 * A2 * A2) / 3)
        Q = A2 * (2 * A2 * A2 - A1) + a0
        S = -2 * p * \
            ctx.cos((ctx.acos(-Q / (2 * p * p * p)) + ctx.pi) / 3) - A2
    elif t1_ > 0:
        #print("in elif t1_ > 0")
        p = f2 * N1 * n12 + 2 * f2 * n12 * t1 + 2 * n12 * F * N2 + 4 * f2 * N1 * N2 * \
            t1 + N1 * t1 * t1 * f2 + 2 * N1 * t1 * F * N2 + n22 * N1 + 4 * F * n22 * t1
        S = (F * N1 * (N1 + 2 * N2 + t1) - N1 * N2 -
             ctx.sqrt(N1 * p)) / (4 * N2 * F * (N1 + N2))
        #print("S elif: ", S)
    else:
        #print("in central")
        S = N1 * (F - 1) / (2 * F * (N1 + N2))
    return S










