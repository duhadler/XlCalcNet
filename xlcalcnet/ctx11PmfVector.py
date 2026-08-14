# -*- coding: utf-8 -*-
"""
@author: DH
"""

# 9 Pmf vectors


class ctxPmfBasicVector(object):

    # %% 9.1 Basic discrete (lattice) distribution functions

## Should be changed from matrix to list
    # %%% 9.1.1 Poisson distribution, pmf vector
    def poisson_pmf_vector(self, ctx, lambda1, count):
        pmf = ctx.matrix(count+1, 1)
        for k in range(0, count+1):
            pmf[k] = ctx.poisson_pmf(k, lambda1)
        return pmf

# %%% 9.1.2 Binomial distribution, pmf vector
    def binomial_pmf_vector(self, ctx, n, p):
        pmf = ctx.matrix(n+1, 1)
        for k in range(0, n+1):
            pmf[k] = ctx.binomial_pmf(k, n, p)
        return pmf

# %%% 9.1.3 Negative binomial distribution, pmf vector
    def negbinom_pmf_vector(self, ctx, r, p, count):
        #n = 20
        pmf = ctx.matrix(count+1, 1)
        for k in range(0, count+1):
            pmf[k] = ctx.negbinom_pmf(k, r, p)
        return pmf

# %%% 9.1.4 Hypergeometric distribution, pmf vector
    def hypergeo_pmf_vector(self, ctx, n, K, N):
        start = n + K - N
        if start < 0:
            start = 0
        stop = K
        if n < K:
            stop = n
        pmf = ctx.matrix(stop+1, 1)
##        print("start:", start)
##        print("stop:", stop)
        for k in range(start, stop+1):
            pmf[k] = ctx.hypergeo_pmf(k, K, n, N)
            #print("k:", k, "pmf[k]:", pmf[k])
        return pmf


# %%% 9.1.5 Noncentral hypergeometric distribution (Fisher), pmf vector


    def hypergeo_nc_pmf_vector(self, ctx, N):
        return None


# %% 9.2 Discrete (lattice) distribution functions related to (stratified) rank tests


# %%% 9.2.1 Sign test distribution (under 𝐻0), pmf vector


    def signtest_pmf_vector(self, ctx, N):
        Order = 0
        x, nl = self.PageQuadeCalc(ctx, False, 2, N, Order)
        return x, nl


# %%% 9.2.2 Wilcoxon 𝑇 distribution (under 𝐻0), pmf vector


    def wilcoxon_pmf_vector(self, ctx, N):
        Order = 0
        x, nl = self.PageQuadeCalc(ctx, True, 2, N, Order)
        return x, nl

    def wilcoxon_full_vector(self, ctx, N, cdf, show, start, stop):
        x, nl = self.PageQuadeCalc(ctx, True, 2, N, 0)
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



# %%% 9.2.4 Kendall 𝑆 (or tau) distribution (under 𝐻0), pmf vector


    def kendall_tau_pmf_vector(self, ctx, n):
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

    def kendall_full_vector(self, ctx, N, cdf, show, start, stop):
        x, nl = self.kendall_tau_pmf_vector(ctx, N)
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

    def perm2(self, ctx, X, n, m):
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


# %%% 9.2.5 Mann-Whitney 𝑈 distribution (under 𝐻0), pmf vector


    def mann_whitney_u_pmf_vector(self, ctx, m, n):
        x = [0]*(m + n + 1)
        for i in range(1, m+n+1):
            x[i] = i
        pprob, panz = self.perm2(ctx, x, m+n, m)
        return pprob, panz


# %%% 9.2.6 Jonckheere-Terpsta 𝑆 distribution (under 𝐻0), pmf vector


    def jterpsta_s_pmf_vector(self, ctx, k, n):
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
        pprob, panz = self.perm2(ctx, X, m[2], m[1])
        for j in range(3, k+1):
            qprob, qanz = self.perm2(ctx, X, m[j], m[j - 1])
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


# %%% 9.2.7 Spearman 𝜌 distribution (under 𝐻0), pmf vector


    def spearman_rho_pmf_vector(self, ctx, n, Order):
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

    def PageQuadeCalc(self, ctx, UseRanks, k, n, Order):
        if UseRanks:
            F = n * (n + 1) // 2
        else:
            F = n
        p, pl = self.spearman_rho_pmf_vector(ctx, k, Order)
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


# %%% 9.2.8 Page 𝐿 distribution (under 𝐻0), pmf vector


    def page_l_pmf_vector(self, ctx, k, N):
        Order = 0
        x, nl = self.PageQuadeCalc(ctx, False, k, N, Order)
        return x, nl


# %%% 9.2.9 Quade 𝐿 distribution (under 𝐻0), pmf vector


    def quade_l_pmf_vector(self, ctx, k, N):
        Order = 0
        x, nl = self.PageQuadeCalc(ctx, True, k, N, Order)
        return x, nl


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


# %%% 9.2.10 Mann-Whitney 𝑈 distribution (under Lehmann alternatives), pmf vector


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
##        print("Result1: ", Result)
##        print("Result1: ", Result[::-1])
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


# %%% 9.2.11 Mann-Whitney 𝑈 distribution (under Milton alternatives), pmf vector


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


#    def Demomilton_pmf(self, ctx):
#        n = [1,2,3]
#        delta = [0,1,2]
#        self.milton_pmf(ctx, n, delta)


#    def milton_pmf(self, ctx, n, delta):
#        return ctxMilton().milton_pmf(ctx, n, delta)


# %% 9.3 Discrete (non-lattice) distribution functions related to rank tests


class ctxFriedman(object):

    # %%% 9.3.1 Cochran 𝑆 distribution (under 𝐻0), pmf vector

    # %%% 9.3.2 Friedman 𝑆 distribution (under 𝐻0), pmf vector

    # %%% 9.3.3 Quade 𝑆 distribution (under 𝐻0), pmf vector

##    def friedman_s_pmf_vector(self, ctx, GetWhat, sum2, n, Quade, Mode, Mode2):
    def friedman_s_pmf_vector(self, ctx, sum2, n, Quade, Mode, Mode2):

        vlimit = 1000000
        vlimit = 10000
        zfak = [0.0]*(vlimit)
        vfak = [0.0]*(vlimit)
        rows = n + 1
        cols = sum2 + 1
        x = [[0 for col in range(cols)] for row in range(rows)]
        cols = vlimit + 1
        rows = sum2 + 1
        zv = [[0 for col in range(cols)] for row in range(rows)]
        cols = vlimit + 1
        rows = sum2 + 1
        v = [[0 for col in range(cols)] for row in range(rows)]
        w = [0]*(sum2 + 1)
        zz = [0]*(sum2 + 1)
        b = [0]*(sum2 + 1)
        y = [0]*(sum2 + 1)
        z = [0]*(sum2 + 1)
        diff = [0]*(2 * (sum2 + 1) + 1)

        show = True
        for i in range(1, n+1):
            for j in range(1, sum2+1):
                if Quade == 2:
                    x[i][j] = 2 * j * i
                else:
                    x[i][j] = 2 * j
        asymend = 0

        if show:
            print("Listing des Datensatzes")
            print("-----------------------")
            for i in range(1, n+1):
                sline = str(i) + ".Block: "
                for j in range(1, sum2+1):
                    sline = sline + str(x[i][j]) + "  "
                print(sline)

        sdiv2 = sum2 // 2
        sum3 = sum2 + 1
        if Mode >= 2:
            sumanz = 1
        else:
            sumanz = sum2 - 1
        fit = 1
        h = sumanz
        permanz = 1
        Last = 0
        Varianz = 0

        for k in range(1, sum2+1):
            zv[k][1] = 0
            y[k] = 0
            permanz = permanz * k
        cols = permanz + 1
        rows = sum2 + 1
        perm = [[0 for col in range(cols)] for row in range(rows)]
        pfak = [0]*(permanz + 1)

        vlength = 1
        rsum = 0
        # zfak[1] = 1.0E-300 #'   (*permanz;*)
        zfak[1] = 1  # '   (*permanz;*)
        vfak[1] = 0

        for it in range(1, n+1):
            vneuend = 1
            lastrsum = rsum
            first = True
            notsame = False
            mean = 0

            for k in range(1, sum2+1):
                mean = mean + fit * x[it][k]
            mean = mean // sum2
            for k in range(1, sum2+1):
                yk = fit * x[it][k] - mean
                rsum = rsum + yk
                Varianz = Varianz + (yk * yk)
                if yk != y[k]:
                    notsame = True
                y[k] = yk

##                '(************************************
##                ' *  permutations of the ith block  *
##                ' ************************************)

            if notsame:
                permneu = 0
                for j in range(permanz, 1-1, -1):
                    z[1] = 0
                    nr = j
                    pn = permanz
                    for k in range(1, sum2+1):
                        b[k] = k
                    for k in range(sum2, 1-1, -1):
                        pn = pn // k
                        s2 = (nr - 1) // pn
                        nr = nr - pn * s2
                        s2 = s2 + 1
                        if Mode == 1:
                            z[k] = y[b[s2]]
                        if Mode == 2:
                            z[1] = z[1] - (2 * k - sum3) * y[b[s2]]
                        for k1 in range(s2, k):
                            b[k1] = b[k1 + 1]
                    i = 1
                    notfound = True
                    while (notfound and (i <= permneu)):
                        k = 1
                        while ((perm[k][i] == z[k]) and (k < sum2)):
                            k = k + 1
                        if k == sum2:
                            notfound = False
                        else:
                            i = i + 1
                    if notfound:
                        permneu = permneu + 1
                        for k in range(1, sum2+1):
                            perm[k][i] = z[k]
                        pfak[i] = 1
                    else:
                        pfak[i] = pfak[i] + 1

##                '(**************************************
##                ' *   Calculate rank sums        *
##                ' **************************************)

            k2 = 0
            for i in range(1, vlength+1):
                zfaki1 = zfak[i]
                tsum = 0
                for k in range(1, h+1):
                    k2 = k2 + 1
                    zz[k] = zv[k][i]
                    tsum = tsum + zz[k]
                zz[sum2] = lastrsum - tsum

                for j in range(1, permneu+1):
                    zfaki = zfaki1 * pfak[j]
                    if Mode > 1:
                        w[1] = zz[1] + perm[1][j]
                    else:
                        for k in range(1, sum2+1):
                            w[k] = zz[k] + perm[k][j]
                        while True:
                            sortiert = True
                            for k in range(1, sumanz+1):
                                k1 = k + 1
                                if w[k] > w[k1]:
                                    w1 = w[k]
                                    w[k] = w[k1]
                                    w[k1] = w1
                                    sortiert = False
                            if sortiert:
                                break

                        if it >= asymend:
                            k = 0
                            k1 = sum3
                            while True:
                                k = k + 1
                                k1 = k1 - 1
                                if ((-w[k] != w[k1]) or (k == sdiv2)):
                                    break

                            if -w[k] < w[k1]:
                                for k in range(1, sum2+1):
                                    w[k] = -w[k]
                                k1 = sum2
                                for k in range(1, sdiv2+1):
                                    w1 = w[k]
                                    w[k] = w[k1]
                                    w[k1] = w1

                    if first:
                        first = False
                        for k in range(1, h+1):
                            v[k][1] = w[k]
                        vfak[1] = zfaki
                    else:
                        l = 1
                        r = vneuend
                        while True:
                            m = (l + r + 1) // 2
                            k = 0
                            while True:
                                k = k + 1
                                vref = v[k][m]
                                EQ = (vref == w[k])
                                if (not ((k < h) and EQ)):
                                    break

                            LE = (vref <= w[k])
                            if LE:
                                l = m
                            else:
                                r = m - 1
                            if l == r:
                                break

                        k = 1
                        while (v[k][l] == w[k]) and (k <= h):
                            k = k + 1
                        if k == (h + 1):
                            vfak[l] = vfak[l] + zfaki
                        else:
                            vneuend = vneuend + 1
                            l = l + 1
                            if vneuend > vlimit:
                                print("Not enough memory")
                                return None

                            if vneuend != l:
                                for i1 in range(vneuend, l-1, -1):
                                    i2 = i1 + 1
                                    vfak[i2] = vfak[i1]
                                    for k in range(1, h+1):
                                        v[k][i2] = v[k][i1]
                            vfak[l] = zfaki

                            for k in range(1, h+1):
                                v[k][l] = w[k]

            ve = vneuend
            for i in range(0, ve+1):
                zfak[i] = vfak[i]
                for k in range(1, h+1):
                    zv[k][i] = v[k][i]
            vlength = vneuend
            Last = vneuend

        s = 0

        rv = ctx.matrix(vlimit + 1, 1)
        rvfak = ctx.matrix(vlimit + 1, 1)

        print("Start Sorting")

        if Mode2 >= 7:
            return None
        slength = 1
        first = True
        k2 = 0

        Ranks = ctx.matrix(vlength - 1+1, h+1)
        for i in range(1, vlength+1):
            zfaki = zfak[i]
            print("i:", i, "zfaki", zfaki)

            sanz = 1
            tsum = 0
            for k in range(1, h+1):
                k2 = k2 + 1
                w[k] = zv[k][i]
                tsum = tsum + w[k]
                Ranks[i - 1, k - 1] = int(zv[k][i]) // 2
            w[sum2] = rsum - tsum
            if Mode2 == 1:
                s = 0
                for k in range(1, sum2+1):
                    stemp = w[k]
                    stemp = stemp * stemp
                    s = s + stemp

            if Mode2 == 6:
                s = w(1)
                for j in range(2, sum2+1):
                    s = s + j * w[j]

            if Mode2 == 2:
                s = w[sum2] - w[1]

            if ((Mode2 == 3) or (Mode2 == 4)):
                if Mode2 == 3:
                    dloop = 2
                else:
                    dloop = 1
                k3 = 1
                for j in range(1, dloop+1):
                    for k in range(1, sum2):
                        w[k] = -w[k]
                    for k in range(1, sum2+1):
                        dun1 = -30000
                        for k1 in range(1, sum2+1):
                            if k1 != k:
                                dun = w[k] - w[k1]
                                if Mode2 == 4:
                                    dun = ctx.fabs(dun)
                                if dun > dun1:
                                    dun1 = dun
                        diff[k3] = dun1
                        k3 = k3 + 1
                sanz = dloop * sum2

            if Mode2 == 5:
                s = -w[1]
                if s < w[sum2]:
                    s = w[sum2]

            while sanz > 0:
                if (Mode2 == 3) or (Mode2 == 4):
                    s = diff[sanz]
                if first:
                    first = False
                    rv[1] = s
                    rvfak[1] = zfaki
                else:
                    l = 1
                    r = slength
                    while True:
                        m = (l + r + 1) // 2    # ' (* M:=(L+r+1) div 2;*)
                        if rv[m] >= s:
                            l = m
                        else:
                            r = m - 1
                        if l == r:
                            break

                    if rv[l] == s:
                        rvfak[l] = rvfak[l] + zfaki
                    else:
                        slength = (slength + 1)
                        l = l + 1
                        for i1 in range(slength, l-1, -1):
                            i2 = i1 + 1
                            rv[i2] = rv[i1]
                            rvfak[i2] = rvfak[i1]
                        rvfak[l] = zfaki
                        rv[l] = s
                sanz = sanz - 1

        #nnr = 1.0E-300
        nnr = 1
        if ((Mode2 == 3) or (Mode2 == 4)):
            nnr = nnr * sum2 * dloop
        for i in range(1, n+1):
            nnr = nnr * permanz
        pcum = 0
        Output = ctx.matrix(slength - 1+1, 3+1)
        print("W,            pmf,               CDF,             Approx to CDF")

        for i in range(1, slength+1):
            p1 = rvfak[i] / nnr
            pcum = pcum + p1
            if Mode2 == 1:
                Chi2 = rv[i] / Varianz * h
            else:
                Chi2 = rv[i] / 2
            Output[i - 1, 0] = Chi2 / 2
            Output[i - 1, 1] = p1
            Output[i - 1, 2] = pcum
            Output[i - 1, 3] = 1 - ctx.chi2_cdf(Chi2, h)
            print("W:", Output[i - 1, 0], "pmf:", Output[i - 1, 1],
                  "CDF:", Output[i - 1, 2], "cdis:", Output[i - 1, 3])

        print("Anzahl der Permutationen: ", 1 * nnr)
        return Output


class ctxKruskal(object):

    NewDataX = []
    OldDataX = []
    NewDataR = []
    OldDataR = []
    NewDataSize = []
    OldDataSize = []
    NewDataStart = []
    OldDataStart = []
    m = 0
    MaxTLength = 0

    def initdata(self, mm, MaxVLength, linear):
        self.MaxTLength = 8192
        if linear:
            self.m = 0
        else:
            self.m = mm
        self.OldDataSize = [0 for row in range(self.MaxTLength+2)]
        self.NewDataSize = [0 for row in range(self.MaxTLength+2)]
        self.OldDataStart = [0 for row in range(self.MaxTLength+2)]
        self.NewDataStart = [0 for row in range(self.MaxTLength+2)]
        self.OldDataX = [0 for row in range(self.MaxTLength+2)]
        self.NewDataX = [0 for row in range(self.MaxTLength+2)]
        rows = self.m+1
        cols = self.MaxTLength
        self.OldDataR = [[0 for col in range(cols)] for row in range(rows)]
        rows = self.m+1
        cols = self.MaxTLength
        self.NewDataR = [[0 for col in range(cols)] for row in range(rows)]
        self.OldDataSize[0] = 0
        self.OldDataStart[0] = 0
        self.OldDataX[0] = 1
        for j in range(0, self.m+1):
            self.OldDataR[j][0] = 0

    def DoneData(self):
        self.NewDataSize = []
        self.OldDataSize = []
        self.NewDataStart = []
        self.OldDataStart = []
        self.NewDataX = []
        self.OldDataX = []
        self.NewDataR = []
        self.OldDataR = []

    def BuildNew(self, NextRank, NewDest, CurNumCount, CurNum, AddPos, n, v, linear, score):
        rows = CurNumCount+1
        cols = self.m+1
        w = [[0 for col in range(cols)] for row in range(rows)]
        z = [0 for row in range(CurNumCount+1)]
        Min = [0 for row in range(self.m+1)]
        LocalPos = [0 for row in range(CurNumCount+1)]
        NV = [0 for row in range(CurNumCount+1)]
        nvSum = 0
        for j in range(0, CurNumCount+1):
            NV[j] = n[j] * v[j]
            nvSum = nvSum + NV[j]
        for j in range(0, CurNumCount+1):
            NV[j] = NV[j] / nvSum
        if NewDest == 0:
            self.NewDataStart[NewDest] = 0
        else:
            self.NewDataStart[NewDest] = self.NewDataStart[NewDest -
                                                           1] + self.NewDataSize[NewDest - 1] + 1
        NND = self.NewDataStart[NewDest]
        NewCount = 0
        for j in range(0, CurNumCount+1):
            LocalPos[j] = 0
            z[j] = self.OldDataX[self.OldDataStart[CurNum[j]]]
            for k in range(0, self.m+1):
                w[j][k] = self.OldDataR[k][self.OldDataStart[CurNum[j]]]
                if linear:
                    w[j][k] = w[j][k] + NextRank * score[AddPos[j]]
                else:
                    if k == AddPos[j]:
                        w[j][k] = w[j][k] + NextRank
            if j == 0:
                for k in range(0, self.m+1):
                    Min[k] = w[j][k]
            k4 = -1
            while True:
                k4 = k4 + 1
                if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                    break
            if (w[j][k4] < Min[k4]):
                for k in range(0, self.m+1):
                    Min[k] = w[j][k]
        while CurNumCount >= 0:
            for j in range(0, CurNumCount+1):
                k4 = -1
                while True:
                    k4 = k4 + 1
                    if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                        break
                if (w[j][k4] < Min[k4]):
                    for k in range(0, self.m+1):
                        Min[k] = w[j][k]
            NewZ = 0
            for j in range(0, CurNumCount+1):
                k4 = -1
                while True:
                    k4 = k4 + 1
                    if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                        break
                if (Min[k4] == w[j][k4]):
                    NewZ = NewZ + NV[j] * z[j]
                    if LocalPos[j] < self.OldDataSize[CurNum[j]]:
                        LocalPos[j] = LocalPos[j] + 1
                        j1 = self.OldDataStart[CurNum[j]] + LocalPos[j]
                        z[j] = self.OldDataX[j1]
                        for k in range(0, self.m+1):
                            w[j][k] = self.OldDataR[k][j1]
                        if linear:
                            w[j][self.m] = w[j][self.m] + \
                                NextRank * score[AddPos[j]]
                        else:
                            w[j][AddPos[j]] = w[j][AddPos[j]] + NextRank
                    else:
                        for k in range(j + 1, CurNumCount+1):
                            CurNum[k - 1] = CurNum[k]
                            LocalPos[k - 1] = LocalPos[k]
                            AddPos[k - 1] = AddPos[k]
                            NV[k - 1] = NV[k]
                            score[k - 1] = score[k]
                        CurNumCount = CurNumCount - 1
            if NND + NewCount > self.MaxTLength - 1:
                self.MaxTLength = 2 * self.MaxTLength
                for i in range(self.MaxTLength):
                    self.OldDataX.append(0)
                for i in range(self.MaxTLength):
                    self.NewDataX.append(0)
                for i in range(0, self.m+1):
                    for j in range(0, self.MaxTLength):
                        self.OldDataR[i].append(0)
                for i in range(0, self.m+1):
                    for j in range(0, self.MaxTLength):
                        self.NewDataR[i].append(0)
            for k in range(0, self.m+1):
                self.NewDataR[k][NND + NewCount] = Min[k]
            self.NewDataX[NND + NewCount] = NewZ
            for k in range(0, self.m+1):
                Min[k] = w[0][k]
            NewCount = NewCount + 1
        self.NewDataSize[NewDest] = NewCount - 1

    def GetFinalVector(self):
        k = 0
        FinalSize = self.OldDataSize[k]
        ok = self.OldDataStart[k]
        FinalX = [0 for row in range(FinalSize+1)]
        rows = self.m+1
        cols = FinalSize + 1
        FinalR = [[0 for col in range(cols)] for row in range(rows)]
        for i in range(0, self.OldDataSize[k]+1):
            FinalX[i] = self.OldDataX[ok + i]
            for j in range(0, self.m+1):
                FinalR[j][i] = self.OldDataR[j][ok + i]
        return FinalSize, FinalX, FinalR

    def ShowOldVector(self, k):
        ok = self.OldDataStart(k)
        print("---Old Vector------Size: " + str(self.OldDataSize[k]))
        s2 = ""
        for i in range(0, self.OldDataSize[k]+1):
            s2 = str(i) + ".  " + str(self.OldDataX[ok + i]) + ": "
            for j in range(0, self.m+1):
                s2 = s2 + str(self.OldDataR[j][ok + i])
                if j < self.m:
                    s2 = s2 + ","
            print(s2)

    def ShowNewVector(self, k):
        nk = self.NewDataStart(k)
        print("---New Vector------Size: " + str(self.NewDataSize[k]))
        s2 = ""
        for i in range(0, self.NewDataSize[k]+1):
            s2 = str(i) + ".  " + str(self.NewDataX(nk + i)) + ": "
            for j in range(0, self.m+1):
                s2 = s2 + str(self.NewDataR(j, nk + i))
                if j < self.m:
                    s2 = s2 + ","
            print(s2)
        print("---End New Vector-----")

    def NewToOld(self, MaxVLength):
        #print("    NewToOld: ", MaxVLength)
        for k in range(0, MaxVLength+1):
            nk = self.NewDataStart[k]
            self.OldDataSize[k] = self.NewDataSize[k]
            self.OldDataStart[k] = self.NewDataStart[k]
            for i in range(0, self.NewDataSize[k]+1):
                self.OldDataX[nk + i] = self.NewDataX[nk + i]
                for j in range(0, self.m+1):
                    self.OldDataR[j][nk + i] = self.NewDataR[j][nk + i]

    def CalcRankSums(self, m, ng, n, v, Rank, linear, score):
        calc = True
        showstruc = False
        showvec = False
        h = m - 1
        m1 = m + 1
        zsize = m1 * 6
        ztempsize = m1 * 6
        zlength = [0 for row in range(ng+1)]
        zstart = [0 for row in range(ng+1)]
        AddPos = [0 for row in range(m+1)]
        w = [0 for row in range(m+1)]
        CurNum = [0 for row in range(m+1)]
        t = [0 for row in range(m+1)]
        v4 = [0 for row in range(m+1)]
        n4 = [0 for row in range(m+1)]
        Score4 = [0 for row in range(m+1)]
        ztemp = [0 for row in range(ztempsize+1)]
        z = [0 for row in range(zsize+1)]
        for j in range(0, m+1):
            w[j] = n[j]
        for j in range(0, m+1):
            t[j] = j
        # ' Sorting should be eliminated
        while True:
            sortiert = True
            for k in range(0, m-1+1):
                k1 = k + 1
                if w[k] < w[k1]:
                    w1 = w[k]
                    w[k] = w[k1]
                    w[k1] = w1
                    w1 = t[k]
                    t[k] = t[k1]
                    t[k1] = w1
                    sortiert = False
            if sortiert:
                break
        for j in range(0, m+1):
            n[j] = w[j]
        for k in range(0, m+1):
            z[k] = w[k]
        zlength[ng] = 0
        zstart[ng] = 0
        zmax = 0
        for i in range(ng - 1, -1, -1):
            i1 = i + 1
            zstart[i] = zstart[i1] + (zlength[i1] + 1) * m1
            first = True
            for j in range(0, zlength[i1]+1):
                for k2 in range(0, m+1):
                    if z[zstart[i1] + j * m1 + k2] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[zstart[i1] + j * m1 + k1]
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
                                if (l == r):
                                    break
                            k = 0
                            while (ztemp[l * m1 + k] == w[k]) and (k <= h):
                                k = k + 1
                            if k < m:
                                zlength[i] = zlength[i] + 1
                                if ((zlength[i] + 1) * m1) > (ztempsize):
                                    ztemp2 = ((zlength[i] + 1) * m1)
                                    ztempsize = ztempsize + \
                                        ((zlength[i] + 1) * m1)
                                    for iz2 in range(ztemp2+1):
                                        ztemp.append(0)
                                l = l + 1
                                if zlength[i] != l:
                                    for i2 in range(zlength[i], -1, -1):
                                        for k in range(0, m+1):
                                            ztemp[(i2 + 1) * m1 +
                                                  k] = ztemp[i2 * m1 + k]
                                for k in range(0, m+1):
                                    ztemp[l * m1 + k] = w[k]
            if ((zlength[i] + 1) * m1) > (zsize - zstart[i]):
                ztemp3 = ((zlength[i] + 1) * m1)
                zsize = zsize + ((zlength[i] + 1) * m1)
                for iz3 in range(ztemp3+1):
                    z.append(0)
            for j in range(0, (zlength[i] + 1) * m1 - 1+1):
                z[zstart[i] + j] = ztemp[j]
            if zlength[i] > zmax:
                zmax = zlength[i]
        Last = [0 for row in range(((zmax + 1) * m1)+1)]

        # 'Calculate the Vectors
        if calc:
            self.initdata(m, zmax, linear)
        if (calc and showvec):
            self.ShowOldVector(0)
        for i in range(1, ng+1):
            i1 = i - 1
            print("iteration:", i)
            for j in range(0, ((zlength[i1] + 1) * m1)+1):
                Last[j] = z[zstart[i1] + j]
            Lastj = zlength[i1]
            if showstruc:
                print(str(i) + ". Iteration")
            for j in range(0, zlength[i]+1):
                if showstruc:
                    s2 = ""
                    for k in range(0, m+1):
                        s2 = s2 + str(z[zstart[i] + j * m1 + k])
                    s2 = s2 + "  :"
                    s3 = "   "
                CurNumCount = -1
                for k in range(0, m+1):
                    if z[zstart[i] + j * m1 + k] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[zstart[i] + j * m1 + k1]
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
                        n4[CurNumCount] = w[k] + 1
                        v4[CurNumCount] = v[k]
                        Score4[CurNumCount] = score[k]
                        if showstruc:
                            s3 = s3 + " [" + str(n4(CurNumCount)) + "; " + str(
                                v4(CurNumCount)) + str(Score4(CurNumCount)) + "], "
                            s2 = s2 + " (" + str(CurNum(CurNumCount)) + \
                                "; " + str(AddPos(CurNumCount)) + ")"
                            s2 = s2 + ", "
                if showstruc:
                    print(s2 + s3)
                if calc:
                    if linear:
                        pass
                    else:
                        self.BuildNew(Rank[i], j, CurNumCount,
                                      CurNum, AddPos, n4, v4, linear, Score4)
                if (calc and showvec):
                    self.ShowNewVector(j)
            if calc:
                self.NewToOld(zlength[i])
        FinalSize, FinalX, FinalR = self.GetFinalVector()
        return FinalSize, FinalX, FinalR
        if calc:
            self.DoneData()

    def CalcStats(self, Mode, m, FinalSize, FinalX, FinalR):
        print("---Final Vector------Size: " + str(FinalSize))
        sum = 0
        for j in range(0, m+1):
            sum = sum + FinalR[j][0]
        mean = sum // (m + 1)
        sum2 = 0
        for j in range(0, m+1):
            d = FinalR[j][0] - mean
            sum2 = sum2 + d * d
        vmax = sum2+2
        print("sum2:", sum2)
        Chi2 = [0 for row in range(vmax+1)]
        for i in range(0, vmax+1):
            Chi2[i] = 0
        for i in range(0, FinalSize+1):
            s2 = str(i) + ".  " + str(FinalX[i]) + ": "
            sum2 = 0
            for j in range(0, m+1):
                d = FinalR[j][i] - mean
                sum2 = sum2 + d * d
                s2 = s2 + str(FinalR[j][i])
                if j < m:
                    s2 = s2 + ","
            Chi2[sum2] = Chi2[sum2] + FinalX[i]
            s2 = s2 + "  ;  " + str(sum2)
        print("Chi2")
        j = 0
        for i in range(0, vmax+1):
            if Chi2[i] > 0:
                j = j + 1
        nlength = j - 1
        x = [0 for row in range(nlength+1)]
        Prob = [0 for row in range(nlength+1)]
        j = 0
        for i in range(0, vmax+1):
            if Chi2[i] > 0:
                Prob[j] = Chi2[i]
                x[j] = i
                j = j + 1
        return nlength, Prob, x

    def Kruskaldemo2(self):
        m = 1  # ' number of groups -1
        linear = False
        n = [0 for row in range(m+1)]
        v = [0 for row in range(m+1)]
        score = [0 for row in range(m+1)]
        for j in range(0, m+1):
            v[j] = j * 0 + 1
        for j in range(0, m+1):
            n[j] = 14
        ng = 0
        for j in range(0, m+1):
            ng = ng + n[j]
        Rank = [0 for row in range(ng+1)]
        for j in range(0, ng+1):
            Rank[j] = j

        FinalSize, FinalX, FinalR = self.CalcRankSums(
            m, ng, n, v, Rank, linear, score)
        Mode = 1
        nlength, Prob, x = self.CalcStats(Mode, m, FinalSize, FinalX, FinalR)
        for i in range(0, nlength+1):
            print("i:", i, "x(i):", x[i], "Prob(i)", Prob[i])


# %%% 9.3.4 Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector

    def kruskal_wallis_h_pmf_vector(self, ctx, n):
        # m = 1  #' number of groups -1
        m = len(n)-1
        print("m:", m)
        linear = False
        #n = [0 for row in range(m+1)]
        v = [0 for row in range(m+1)]
        score = [0 for row in range(m+1)]
        for j in range(0, m+1):
            v[j] = j * 0 + 1
##        for j in range(0, m+1):
##            n[j] = 14
        ng = 0
        for j in range(0, m+1):
            ng = ng + n[j]
        Rank = [0 for row in range(ng+1)]
        for j in range(0, ng+1):
            Rank[j] = j

        FinalSize, FinalX, FinalR = self.CalcRankSums(
            m, ng, n, v, Rank, linear, score)
        Mode = 1
        nlength, Prob, x = self.CalcStats(Mode, m, FinalSize, FinalX, FinalR)
        for i in range(0, nlength+1):
            print("i:", i, "x(i):", x[i], "Prob(i)", Prob[i])
