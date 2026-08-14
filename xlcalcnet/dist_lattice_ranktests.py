# -*- coding: utf-8 -*-
"""
@author: DH
"""


from xlcalcnet.dist_base import ctx_rv_discrete


# %% 30 Discrete (non-lattice) distributions related to rank tests


class ctx_wilcoxon(ctx_rv_discrete):

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




def wilcoxon_pmf_vector(ctx, N):
    Order = 0
    x, nl = PageQuadeCalc(ctx, True, 2, N, Order)
    return x, nl

def wilcoxon_full_vector(ctx, N, cdf, show, start, stop):
    x, nl = PageQuadeCalc(ctx, True, 2, N, 0)
    if cdf:
        for i in range(1, nl+0):
            x[i] = x[i] + x[i-1]
    if show:
        if start is None:
            start = 0
        if stop is None:
            stop = nl
        # for i in range(0, nl+0):
        for i in range(int(start), int(stop)):
            print("i:", i,  "x(i):", x[i])
    return x, nl




class ctx_bennett(ctx_rv_discrete):

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


class ctx_mann_whitney_u(ctx_rv_discrete):

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



def mann_whitney_u_pmf_vector(ctx, m, n):
    x = [0]*(m + n + 1)
    for i in range(1, m+n+1):
        x[i] = i
    pprob, panz = perm2(ctx, x, m+n, m)
    return pprob, panz




def perm2(ctx, X, n, m):
    ic = [0]*1024
    ir = [0]*1024
    ira = [0]*1024
    if m > n / 2:
        m = n - m
    for i in range(1, n+1):
        ir[i] = X[i]
    ic[1] = 1
    ih = 1
    iminm = 0
    for i in range(1, m+1):
        ic[i + 1] = ic[i] + ih
        iminm = iminm + ir[i]
        ih = ih + ir[n - i + 1] - ir[i]
    icm = ic[m + 1] + ih
    ASize = icm + 10
    a = ctx.matrix(ASize + 2, 1)
    for i in range(1, icm+1):
        a[i] = 0
    a[1] = 1
    ira[1] = 0
    for L in range(2, n+1):
        irl = ir[L]
        l2 = L // 2
        ib = m + 1 - l2
        if ib < 1:
            ib = 1
        else:
            if (2 * l2) == L:
                jb = ic[l2]
                je = jb + ira[l2]
                icj = ic[l2 + 1] + je
                for j in range(jb, je+1):
                    a[icj - j] = a[j]
        for k in range(ib, m+1):
            il = m + 1 - k
            jb = ic[il + 1] + irl - ir[il]
            je = jb + ira[il]
            ici = ic[il] - jb
            for j in range(jb, je+1):
                a[j] = a[j] + a[ici + j]
            ira[il + 1] = ira[il] + irl - ir[il]
    asum = ctx.t(1)
    msum = ctx.t(1)
    for i in range(1, n+1):
        asum = asum * i
    for i in range(1, m+1):
        msum = msum * i
    for i in range(1, n-m+1):
        msum = msum * i
    asum = asum / msum
    qmin = iminm
    qmax = iminm + icm - ic[m + 1] - 1
    for i in range(ic[m + 1], icm+1):
        j3 = i - ic[m + 1] + 1
        a[j3] = a[i] / asum
    pcum = ctx.t(0)
    panz = qmax - qmin
    pprob = ctx.matrix(panz + 2, 1)
    for i in range(1, qmax - qmin + 2):
        i1 = i - 1
        ai = a[i]
        pprob[i1] = ai
        pcum = pcum + ai
    return pprob, panz









class ctx_mann_whitney_u_lehmann(ctx_rv_discrete):

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


class ctx_mann_whitney_u_milton(ctx_rv_discrete):

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


class ctx_kendall_tau(ctx_rv_discrete):

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



def kendall_tau_pmf_vector(ctx, n):
    nmax = n * (n - 1) + 1
    X = ctx.matrix(nmax + 3, 1)
    y = ctx.matrix(nmax + 3, 1)
    permanz = ctx.t(1)
    X[1] = permanz
    nl = 1
    for it in range(2, n+1):
        permanz = permanz * it
        nl = nl + it - 1
        mitte = (nl + 1) // 2
        for i in range(1, nl+1):
            y[i] = ctx.t(0)
        for i in range(mitte, 0, -1):
            limit = i - it + 1
            if limit < 1:
                limit = 1
            yy = y[i]
            for j in range(i, limit-1, -1):
                yy = yy + X[j]
            y[i] = yy
        j = nl + 1
        for i in range(1, mitte+1):
            j = j - 1
            yy = y[i]
            X[i] = yy
            X[j] = yy
    permanz = ctx.t(1)
    for i in range(2, n+1):
        permanz = permanz * i
    for i in range(1, nl+1):
        X[i - 1] = X[i] / permanz
    return X, nl

def kendall_full_vector(ctx, N, cdf, show, start, stop):
    x, nl = kendall_tau_pmf_vector(ctx, N)
    if cdf:
        for i in range(1, nl+0):
            x[i] = x[i] + x[i-1]
    if show:
        if start is None:
            start = 0
        if stop is None:
            stop = nl
        # for i in range(0, nl+0):
        for i in range(int(start), int(stop)):
            print("i:", i,  "x(i):", x[i])
    return x, nl














class ctx_jterpsta_s(ctx_rv_discrete):

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



def jterpsta_s_pmf_vector(ctx, k, n):
    m = [0]*(k + 1)
    m[0] = 0
    for j in range(1, k+1):
        m[j] = m[j - 1] + n[j]
    TS = 0
    for j in range(1, k):
        TS = TS + m[j] * n[j + 1]
    pneu = ctx.matrix(TS + 3, 1)
    X = [0]*(m[k] + 2)
    for i in range(1, m[k]+1):
        X[i] = i
    pprob, panz = perm2(ctx, X, m[2], m[1])
    for j in range(3, k+1):
        qprob, qanz = perm2(ctx, X, m[j], m[j - 1])
        for i in range(0, qanz + panz+1):
            pneu[i] = 0
        for i in range(0, qanz+1):
            for i2 in range(0, panz+1):
                i4 = i + i2
                pneu[i4] = pneu[i4] + pprob[i2] * qprob[i]
        panz = panz + qanz
        if j == 3:
            pprob = ctx.matrix(TS + 3, 1)
        for i in range(0, panz+1):
            pprob[i] = pneu[i]
    return pprob, panz







class spearman(ctx_rv_discrete):

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


def spearman_rho_pmf_vector(ctx, n, Order):
    X = [0]*(n + 1)
    y = [0]*(n + 1)
    p = [0]*(n + 1)
    d = [0]*(n + 1)
    nn = n
    First = True
    count = 0
    Upper = 0
    lower = 0
    for i in range(1, nn+1):
        X[i] = i
        y[i] = i
    for i in range(1, nn+1):
        Upper = Upper + X[i] * y[i]
        lower = lower + X[i] * y[nn + 1 - i]
    Valcount = Upper - lower
    result = [0]*(Valcount + 1)
    while True:
        n = nn
        if First:
            for k in range(2, n+1):
                p[k] = 0
                d[k] = 1
            First = False
        k = 0
        while True:
            Q = p[n] + d[n]
            p[n] = Q
            if Q == n:
                d[n] = -1
                if n > 2:
                    n = n-1
                else:
                    Q = 1
                    First = True
                    break
            else:
                if Q != 0:
                    break
                else:
                    d[n] = 1
                    k = k + 1
                    if n > 2:
                        n = n-1
                    else:
                        Q = 1
                        First = True
                        break
        Q = Q + k
        t = X[Q]
        X[Q] = X[Q + 1]
        X[Q + 1] = t
        count = count + 1
        sum1 = 0
        for i in range(1, nn+1):
            sum1 = sum1 + (X[i] * y[i])
        result[sum1 - lower] = result[sum1 - lower] + 1

        if First == True:
            break
    xx = ctx.matrix(Valcount + 1, 1)
    for i in range(0, Valcount+1):
        fraction = ctx.t(result[i]) / count
        #print(" i:", i, "fraction:", fraction)
        xx[i] = fraction

    return xx, Valcount








class ctx_page_l(ctx_rv_discrete):

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


def PageQuadeCalc(ctx, UseRanks, k, n, Order):
    if UseRanks:
        F = n * (n + 1) // 2
    else:
        F = n
    p, pl = spearman_rho_pmf_vector(ctx, k, Order)
    qanz = pl * F + 1
    Q = ctx.matrix(qanz, 1)
    r = ctx.matrix(qanz, 1)
    for i in range(0, pl+1):
        Q[i] = p[i]
    ql = pl
    for h in range(2, n+1):
        if UseRanks:
            F = h
        else:
            F = 1
        for i in range(0, pl+1):
            for j in range(0, ql+1):
                r[F * i + j] = r[F * i + j] + p[i] * Q[j]
        ql = ql + F * pl
        for i in range(0, ql+1):
            Q[i] = r[i]
            r[i] = 0
    return Q, qanz



def page_l_pmf_vector(ctx, k, N):
    Order = 0
    x, nl = PageQuadeCalc(ctx, False, k, N, Order)
    return x, nl



def quade_l_pmf_vector(ctx, k, N):
    Order = 0
    x, nl = PageQuadeCalc(ctx, True, k, N, Order)
    return x, nl




class ctx_page_l_nc_milton(ctx_rv_discrete):

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




class ctxLehmann(object):

    def CalcRankSums(self, kValue, m, ng, n, Rank):
        AddPos = [0 for row in range(10)]
        w = [0 for row in range(10)]
        CurNum = [0 for row in range(10)]
        calc = True
        showstruc = False
        h = m - 1
        m1 = m + 1
        rows = ng + 1
        zlength = [0 for row in range(rows)]
        zul = 1000

        if m == 1:
            if n[0] < n[1]:
                zul = n(0) * (m1 + 1)
            else:
                zul = n[1] * (m1 + 1)

        rows = zul + 1
        ztemp = [0 for row in range(rows)]
        rows = zul + 1
        Last = [0 for row in range(rows)]
        rows = ng + 1
        cols = zul + 1
        z = [[0 for col in range(cols)] for row in range(rows)]

        for j in range(0, m+1):
            w[j] = n[j]
        for j in range(0, m+1):
            n[j] = w[j]
        for k in range(0, m+1):
            z[ng][k] = w[k]

        zlength[ng] = 0
        zmax = 0
        for i in range(ng-1, 0-1, -1):
            i1 = i + 1
            first = True
            for j in range(0, zlength[i1]+1):
                for k2 in range(0, m+1):
                    if z[i1][j * m1 + k2] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[i1][j * m1 + k1]
                        w[k2] = w[k2] - 1
                        if first:
                            first = False
                            zlength[i] = 0
                            for k in range(0, m+1):
                                ztemp[k] = w[k]
                        else:
                            l = 0
                            r = zlength[i]
                            while True:
                                q = (l + r + 1) // 2
                                k = -1
                                while True:
                                    k = k + 1
                                    vref = ztemp[q * m1 + k]
                                    EQ = (vref == w[k])
                                    if not ((k < h) and EQ):
                                        break
                                LE = (vref <= w[k])
                                if LE:
                                    l = q
                                else:
                                    r = q - 1
                                if l == r:
                                    break
                            k = 0
                            while (ztemp[l * m1 + k] == w[k]) and (k <= h):
                                k = k + 1
                            if k < m:
                                zlength[i] = zlength[i] + 1
                                l = l + 1
                                if zlength[i] != l:
                                    for i2 in range(zlength[i], 0-1, -1):
                                        for k in range(0, m+1):
                                            ztemp[(i2 + 1) * m1 +
                                                  k] = ztemp[i2 * m1 + k]
                                for k in range(0, m+1):
                                    ztemp[l * m1 + k] = w[k]
            for j in range(0, (zlength[i] + 1) * m1 - 1+1):
                z[i][j] = ztemp[j]
            if zlength[i] > zmax:
                zmax = zlength[i]

        # '{Calculate the Vectors}

        rows = 1+1
        cols = zmax+1
        pages = (n[0] * n[1])+1
        xvec = [[[0 for page in range(pages)]
                 for col in range(cols)] for row in range(rows)]
        xvec[0][0][0] = 1
        xstart = ng % 2
        for i in range(1, ng+1):
            if calc:
                if xstart == 1:
                    xstart = 0
                else:
                    xstart = 1
            i1 = i - 1
            for j in range(0, ((zlength[i1] + 1) * m1)+1):
                Last[j] = z[i1][j]
            Lastj = zlength[i1]
            if showstruc:
                print((str(i) + ". Iteration"))
            for j in range(0, zlength[i]+1):
                if showstruc:
                    s2 = str(j) + ". Vector"
                    for k in range(0, m+1):
                        s2 = s2 + str(z[i][j * m1 + k])
                    s2 = s2 + "  :"
                CurNumCount = -1
                for k in range(0, m+1):
                    if z[i][j * m1 + k] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[i][j * m1 + k1]
                        w[k] = w[k] - 1
                        if showstruc:
                            for k1 in range(0, m+1):
                                s2 = s2 + str(w[k1])
                                if k == k1:
                                    s2 = s2 + "+"
                        j2 = -1
                        while True:
                            j2 = j2 + 1
                            k3 = -1
                            while True:
                                k3 = k3 + 1
                                EQ = (w[k3] == Last[j2 * m1 + k3])
                                if not (EQ and (k3 < m)):
                                    break
                            if (EQ or (j2 == Lastj)):
                                break
                        CurrentNumber = j2
                        if not (EQ):
                            CurrentNumber = CurrentNumber + 1
                        CurNumCount = CurNumCount + 1
                        CurNum[CurNumCount] = CurrentNumber
                        AddPos[CurNumCount] = k
                        if showstruc:
                            s2 = s2 + \
                                " (" + str(CurNum[CurNumCount]) + \
                                "; " + str(AddPos[CurNumCount]) + ")"
                            s2 = s2 + ", "
                if showstruc:
                    print(s2)
                if calc:
                    self.BuildMWVector(
                        xvec, xstart, kValue, z[i][j * m1],  z[i][j * m1 + 1], j, CurNum[0], CurNum[1])
        return xvec[0][0]

    def BuildMWVector(self, xvec, xstart, k, n, m, Target, Source1, Source2):
        i = 0
        if xstart == 1:
            ystart = 0
        else:
            ystart = 1
        if ((n == 0) or (m == 0)):
            xvec[xstart][Target][i] = 1
            return
        f1 = n / (k * m + n)
        f2 = k * m / (k * m + n)
        for i in range(0, (n*m)+1):
            xvec[xstart][Target][i] = 0
        if f2 > 0:
            for i in range(0, (n * (m - 1))+1):
                xvec[xstart][Target][i] = xvec[xstart][Target][i] + \
                    f2 * xvec[ystart][Source2][i]
        if f1 > 0:
            for i in range(m, (n*m)+1):
                xvec[xstart][Target][i] = xvec[xstart][Target][i] + \
                    f1 * xvec[ystart][Source1][i - m]




    def mannwhitney_u_lehmann_pmf_vector(self, ctx, kValue, N1, n2):
        # ' Recursive algorithm for Lehmann alternatives for the Mann-Whitney test
        m = 1
        n = [0 for row in range(2)]

        n[0] = N1
        n[1] = n2
        ng = 0
        for j in range(0, m+1):
            ng = ng + n[j]
        Rank = [0 for row in range(ng + 1)]

        for j in range(0, ng+1):
            Rank[j] = j

        Result = self.CalcRankSums(kValue, m, ng, n, Rank)
#        print("Result1: ", Result)
#        print("Result1: ", Result[::-1])
        panz = n[0] * n[1]
        #pprob = [0 for row in range(panz+1)]
        pprob = Result[::-1]
        return pprob, panz




class ctxMilton(object):

    # class-wide variables
    s = 0  # ReDim s(0 To rFieldsize)
    f2 = 0  # ReDim f2(0 To icount + 1, 0 To GroupAnz - 1, 0 To rFieldsize)
    v = 0  # ReDim v(0 To p + 1, 0 To vp + 1, 0 To rFieldsize)
    HH = [0.0 for row in range(10)]
    t2 = [0.0 for row in range(10)]
    delta = [0.0 for row in range(10)]
    a = [[0 for col in range(10)] for row in range(10)]

    sum = 0.0
    h = 0.0
    icount = 0
    Index = 0
    left = 0
    Right = 0
    plimit = 0
    p = 0
    IsNormal = True
    IsWilcoxon = False
    rFieldsize = 1601

    def Myfunction(self, ctx, x, j):
        if self.IsNormal:
            res = ctx.exp(-((x - self.delta[j]) ** 2) / 2) * 0.398942280401433
            return res

    def InitMilton(self, ctx, GroupAnz, n):
        self.Factor = 1
        self.p = 0
        for j in range(1, GroupAnz+1):
            for i in range(1, n[j]+1):
                self.Factor = self.Factor * i
            self.p = self.p + n[j]
        self.plimit = 20
        self.icount = 8
        self.left = 0
        vp = self.p
        if self.p > self.plimit:
            vp = self.plimit

        self.s = [0 for row in range(self.rFieldsize+1)]
        rows = self.icount + 1
        cols = GroupAnz+1
        pages = self.rFieldsize+1
        self.f2 = [[[0 for page in range(pages)] for col in range(
            cols)] for row in range(rows)]
        rows = self.p + 1
        cols = vp+1
        pages = self.rFieldsize+1
        self.v = [[[0 for page in range(pages)]
                   for col in range(cols)] for row in range(rows)]

        self.t2[0] = 4
        for k in range(1, self.icount - 2+1):
            self.t2[k] = self.t2[k - 1] * 4
        Right = 1600 * 2
        h = 0.01 / 2
        for iteration in range(1, self.icount+1):
            Right = Right // 2
            h = h * 2
            self.HH[iteration] = 1
            for i in range(1, self.p+1):
                self.HH[iteration] = self.HH[iteration] * h
            for k in range(self.left, Right+1):
                for j in range(0, GroupAnz - 1+1):
                    if self.IsNormal:
                        self.f2[iteration][j][k] = self.Myfunction(
                            ctx, k * h - 8, j + 1)
                    else:
                        self.f2[iteration][j][k] = self.Myfunction(
                            ctx, (k * h - 8) * 1.0, j + 1)

    def RunMilton(self, ctx, z):
        Right = 1600 * 2
        h = 0.01 / 2
        for iteration in range(1, self.icount+1):
            Right = Right // 2
            h = h * 2
            Index = z[1]
            self.s[self.left] = 0
            for k in range(self.left, Right+1):
                self.v[1][1][k] = self.f2[iteration][Index][k]
                self.s[k + 1] = self.s[k] + self.v[1][1][k]

            for j in range(2, self.p+1):
                Index = z[j]
                vp = j - 1
                if vp > self.plimit:
                    vp = self.plimit
                for i in range(1, vp+1):
                    for k in range(self.left, Right+1):
                        self.v[j][i][k] = self.v[j - 1][i][k] * \
                            self.f2[iteration][Index][k] / (j + 1 - i)
                if j <= self.plimit:
                    for k in range(self.left, Right+1):
                        self.v[j][j][k] = self.s[k] * \
                            self.f2[iteration][Index][k]
                self.s[0] = 0
                for k in range(self.left, Right+1):
                    sum = 0
                    vp = j
                    if vp > self.plimit:
                        vp = self.plimit
                    for i in range(1, vp+1):
                        sum = sum + self.v[j][i][k]
                    self.s[k + 1] = self.s[k] + sum
            self.a[self.icount - iteration][0] = self.Factor * \
                self.HH[iteration] * self.s[Right + 1]

        for k in range(0, self.icount - 2+1):
            for i in range(k + 1, self.icount - 1+1):
                self.a[i][k + 1] = (self.t2[k] * self.a[i]
                                    [k] - self.a[i - 1][k]) / (self.t2[k] - 1)
        return self.a[self.icount - 1][self.icount - 1]

    def DoneMilton(self, ctx):
        self.v = 0
        self.f2 = 0
        self.s = 0

    def ChaseNew(self, ctx, x, y,  k, u, done, p):
        j = 0
        b = 0
        s = 0
        while True:
            j = j + 1
            if abs(p[j]) == k:
                if p[j] < 0:
                    s = j
            else:
                if p[j - 1] == k:
                    for i in range(j - s - 1, 2-1, -1):
                        p[s + i] = -k
                    if s > b:
                        p[s] = k
                    p[s + 1] = p[j]
                    p[j] = k
                    x = s + 1
                    y = j
                    return x, y, done
                if s > b:
                    p[s] = k
                while True:
                    j = j + 1
                    if abs(p[j]) >= k:
                        break
                if j == u:
                    if k == 2:
                        done = True
                        return x, y, done
                    j = s
                    b = s
                    k = k - 1
                else:
                    b = j - 1
                    i = b
                    while True:
                        i = i + 1
                        if p[i] != k:
                            break
                        p[i] = -k
                    if p[i] == -k:
                        p[i] = p[b]
                        p[b] = -k
                        x = b
                        y = i
                        return x, y, done
                    if i == u:
                        if k == 2:
                            done = True
                            return x, y, done
                        u = j
                        j = s
                        b = s
                        k = k - 1
                    else:
                        break
        x = j
        y = i
        p[j] = p[i]
        p[i] = k
        return x, y, done

    def DemoChaseNew(self, ctx):
        GroupAnz = 3  # '(*zahl der gruppen mit verschiedenen werten*)
        a = [0]*(10)
        p = [0]*(10)
        id_ = [0]*(10)
        Ranks = [0]*(10)

        n = [0, 1, 2, 3]
        self.delta[1] = 0
        self.delta[2] = 1
        self.delta[3] = 2

        for i1 in range(1, GroupAnz+1):
            id_[i1] = i1 - 1  # ' (*werte der gruppen*)

        self.InitMilton(ctx, GroupAnz, n)

        csum = 0
        count = 0
        for i1 in range(1, GroupAnz+1):
            csum = csum + n[i1]
            for i2 in range(1, n[i1]+1):
                count = count + 1
                a[count] = id_[i1]
                p[count] = GroupAnz - i1 + 1

        icount2 = 1
        x = 1
        y = 2
        k = GroupAnz
        u = csum + 1
        done = False
        p[0] = GroupAnz + 1
        p[u] = GroupAnz + 1
        totalSum = 0.0
        while not (done):
            ss = str(icount2) + ", permutation: "
            for i1 in range(0, GroupAnz+1):
                Ranks[i1] = 0
            for i1 in range(1, csum+1):
                ss = ss + str(a[i1]) + " "
                Ranks[a[i1]] = Ranks[a[i1]] + i1
            s3 = "["
            for i1 in range(1, GroupAnz+1):
                s3 = s3 + str(Ranks[i1 - 1]) + ","
            s3 = s3 + "]"

            Result = self.RunMilton(ctx, a)

            #Result = 1
            print("i:", ss, ", Ranksumvector:", s3, "Result:", Result)
            totalSum = totalSum + Result
            x, y, done = self.ChaseNew(ctx, x, y, k, u, done, p)
            temp = a[x]
            a[x] = a[y]
            a[y] = temp
            icount2 = icount2 + 1
        print("totalSum: {0}", totalSum)

        self.DoneMilton()




    def mannwhitney_u_milton_pmf_vector(self, ctx, m, n):
        return None

    def milton_pmf(self, ctx, n_, delta_):
        a = [0]*(10)
        p = [0]*(10)
        id_ = [0]*(10)
        Ranks = [0]*(10)

        GroupAnz = len(n_)  # '(*zahl der gruppen mit verschiedenen werten*)
        n = [0]*(GroupAnz+1)

        for i in range(GroupAnz):
            n[i+1] = n_[i]
            self.delta[i+1] = delta_[i]

        for i1 in range(1, GroupAnz+1):
            id_[i1] = i1 - 1  # ' (*werte der gruppen*)

        self.InitMilton(ctx, GroupAnz, n)

        csum = 0
        count = 0
        for i1 in range(1, GroupAnz+1):
            csum = csum + n[i1]
            for i2 in range(1, n[i1]+1):
                count = count + 1
                a[count] = id_[i1]
                p[count] = GroupAnz - i1 + 1

        icount2 = 1
        x = 1
        y = 2
        k = GroupAnz
        u = csum + 1
        done = False
        p[0] = GroupAnz + 1
        p[u] = GroupAnz + 1
        totalSum = 0.0
        while not (done):
            ss = str(icount2) + ", permutation: "
            for i1 in range(0, GroupAnz+1):
                Ranks[i1] = 0
            for i1 in range(1, csum+1):
                ss = ss + str(a[i1]) + " "
                Ranks[a[i1]] = Ranks[a[i1]] + i1
            s3 = "["
            for i1 in range(1, GroupAnz+1):
                s3 = s3 + str(Ranks[i1 - 1]) + ","
            s3 = s3 + "]"

            Result = self.RunMilton(ctx, a)

            #Result = 1
            print("i:", ss, ", Ranksumvector:", s3, "Result:", Result)
            totalSum = totalSum + Result
            x, y, done = self.ChaseNew(ctx, x, y, k, u, done, p)
            temp = a[x]
            a[x] = a[y]
            a[y] = temp
            icount2 = icount2 + 1
        print("totalSum: {0}", totalSum)

        self.DoneMilton(ctx)


    def Demomilton_pmf(self, ctx):
        n = [1,2,3]
        delta = [0,1,2]
        self.milton_pmf(ctx, n, delta)


    # def milton_pmf(self, ctx, n, delta):
    #     return ctxMilton().milton_pmf(ctx, n, delta)



