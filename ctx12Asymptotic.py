# -*- coding: utf-8 -*-
"""
@author: DH
"""


# 10 Asymptotic expansions

class ctxAsymptotic(object):

    # %% 9.1 Edgeworth and Cornish-Fisher expansions: continuous distributions

    # 9.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf
    def edgeworth(self, ctx, X, Order, kappa, verbose=False):
        mean = kappa[1]
        sigma = ctx.sqrt(kappa[2])
        Z = (X - mean) / sigma
        #print("X: ", X, ", Z: ", Z, ", mean: ", mean, ", sigma: ", sigma)

        B = self.BellPoly(ctx, Order, kappa)
        H = self.HermitePoly(ctx, Order, Z)

        s3 = ctx.normal_cdf(Z)
        s4 = ctx.normal_pdf(Z)
        #print("s3: ", s3, ", s4: ", s4)
        for j in range(1, Order + 1):
            s1 = self.h0j(ctx, j, B, H)
            s2 = -s1 * s4
            s3 = s3 + s2
            if verbose: print("j: ", j, ", s2: ", s2, ", s3: ", s3)

        LeftTail1 = s3
        RightTail1 = 1-LeftTail1
        return LeftTail1, RightTail1

    def BellPoly(self, ctx, Order, kappa):
        d0 = 3+Order
        #print("d0: ", d0)
#        alpha = ctx.matrix(d0, 1)
#        sigma = ctx.sqrt(kappa[2])
        alpha = ctx.matrix(d0, 1)
        sigma = ctx.sqrt(kappa[2])
        alpha[2] = 0
        fakt = kappa[2]
        for i in range(3, d0):
            fakt = fakt * sigma
            alpha[i] = kappa[i] / fakt

#        B = ctx.matrix(3*Order+2, 3*Order+1)
        B = ctx.matrix(3*Order+2, 3*Order+1)
        B[0, 0] = 1
        for r in range(3, d0):
            B[r, 1] = alpha[r]

        #print("Begin B[r, k]")
        for r in range(4, 3*Order+1):
            t = r // 3
            t = t + 1
            r1 = ctx.convert(r)
            for k in range(2, t+1):
                s = ctx.convert(0)
                d = r-k+2
                if d > d0:
                    d = d0
                bk = (r1-1)*(r1-2)/2
                for i in range(3, d):
                    s = s + bk * alpha[i] * B[r-i, k-1]
                    #s = s + mp.binomial(r-1, i-1) * alpha[i] * B[r-i, k-1]
#                    print("binom", r-1,i-1,mp.binomial(r-1, i-1), bk)
                    bk = bk * (r1-i) / i
                B[r, k] = s
                #print(r,k,B[r, k])
        return B

    def HermitePoly(self, ctx, Order, x):
        #print("Hermite order: ", 3 * Order)
        k = 3 * Order
#        H = ctx.matrix(k+2, 1)
        H = ctx.matrix(k+2, 1)
        H[0] = 1
        H[1] = x
        for r in range(1, k+1):
            H[r+1] = x * H[r] - r * H[r-1]
        return H

    def h0j(self, ctx, j, B, H):
        s = ctx.convert(0)
        for k in range(1, j+1):
            r = j + 2*k
            s = s + B[r, k] * H[r-1] / ctx.factorial(r)
        return s


#  9.1.2 Cornish-Fisher expansion: general approximation to the qtf and isf

    def cornish_fisher(self, ctx,  LeftTail, RightTail, kappa, nord):
        #        ac = ctx.matrix(nord+3, 1)
        #        del_ = ctx.matrix(nord+3, 1)
        ac = ctx.matrix(nord+3, 1)
        del_ = ctx.matrix(nord+3, 1)
        mean = kappa[1]
        sigma = ctx.sqrt(kappa[2])
        S = sigma * sigma
        for i in range(3, nord+1):
            S = S * sigma
            ac[i - 2] = kappa[i] / S
        X = ctx.ndisx(LeftTail, RightTail)
        self.CornishFisherLee(ctx, nord, X, ac, del_)
        for i in range(1, nord-1):
            X = X + del_[i]
            #print("X:", X, "del_[i]:", del_[i], "del_[i]/X:", del_[i]/X)
        result = mean + sigma * X
        return result

    def CornishFisherLee(self, ctx,  r, x0, ac, adj):
        #        a = ctx.matrix(r+3, 1);
        #        d = ctx.matrix(r+3, 1)
        #        h = ctx.matrix(3 * (r+3), 1)
        #        p = ctx.matrix((3 * (r+3)) * ((r+3) + 1) // 2, 1)
        a = ctx.matrix(r+3, 1)
        d = ctx.matrix(r+3, 1)
        h = ctx.matrix(3 * (r+3), 1)
        p = ctx.matrix((3 * (r+3)) * ((r+3) + 1) // 2, 1)
        x = ctx.convert(x0)
        cc = -1
        for j in range(1, r+1):
            a[j] = cc * ac[j] / ((j + 1) * (j + 2))
            cc = -cc
        h[1] = -x
        h[2] = x * x - 1
        for j in range(3, (3 * r)+1):
            h[j] = -(x * h[j - 1] + (j - 1) * h[j - 2])
        d[1] = -a[1] * h[2]
        adj[1] = d[1]
        p[1] = d[1]
        p[3] = a[1]
        fac = ctx.convert(1)
        ja = 0
        for j in range(2, r+1):
            fac = fac * j
            bc = ctx.convert(1)
            ja = ja + 3 * (j - 1)
            jb = ja
            for k in range(1, j):
                bcd = bc * d[k]
                bca = bc * a[k]
                jb -= 3 * (j - k)
                for m in range(1, (3 * (j - k))+1):
                    jbl = jb + m
                    jal = ja + m
                    p[jal + 1] += bcd * p[jbl]
                    p[jal + k + 2] += bca * p[jbl]
                bc = (bc * (j - k)) / k
            p[ja + j + 2] += a[j]
            d[j] = 0
            for m in range(2, (3 * j)+1):
                d[j] -= p[ja + m] * h[m - 1]
            p[ja + 1] = d[j]
            adj[j] = d[j] / fac

    def CalcCornish(self, ctx,  LeftTail, RightTail, mean, sigma, kappa, nord):
        #        ac = ctx.matrix(nord+3, 1)
        #        del_ = ctx.matrix(nord+3, 1)
        ac = ctx.matrix(nord+3, 1)
        del_ = ctx.matrix(nord+3, 1)
        S = sigma * sigma
        for i in range(3, nord+1):
            S = S * sigma
            ac[i - 2] = kappa[i] / S
        X = ctx.convert(ctx.ndisx(LeftTail, RightTail))
        self.CornishFisherLee(ctx, nord, X, ac, del_)
        for i in range(1, nord-1):
            X = X + del_[i]
            print("X:", X, "del_[i]:", del_[i], "del_[i]/X:", del_[i]/X)
        result = mean + sigma * X
        return result


# 9.1.3 Chi-squared distribution: pdf, cdf and sf

    def chi2_ecf(self, ctx, x, n, order, verbose):
        x = ctx.t(x)
        n = ctx.t(n)
        kappa = self.chi2_cumulants(ctx, order+3, n)
        if verbose:
            for i in range(2, order+3):
                print(i, kappa[i])
        L1, R1 = self.edgeworth(ctx, x, order, kappa)
        return L1, R1


# 9.1.4 Chi-squared distribution: qtf and isf

    def chi2_ecf_inv(self, ctx, L1, R1, n, order, verbose):
        L1 = ctx.t(L1)
        R1 = ctx.t(R1)
        n = ctx.t(n)
        kappa = self.chi2_cumulants(ctx, order+3, n)
        if verbose:
            for i in range(2, order+3):
                print(i, kappa[i])
        X1 = self.cornish_fisher(ctx, L1, R1, kappa, order-5)
        return X1

    def chi2_rawmoments(self, ctx, k, df):
        df = ctx.convert(df)
        k = int(k)
        raw = ctx.matrix(k+1, 1)
        raw[0] = ctx.convert(1)
        for i in range(1, k+1):
            m = ctx.convert(i)
            raw[i] = (2**m) * ctx.gamma(m+df/2) / ctx.gamma(df/2)
        return raw

    def chi2_cumulants(self, ctx, k, df):
        df = ctx.convert(df)
        k = int(k)
        kappa = ctx.matrix(k+1, 1)
        kappa[0] = 1
        kappa[1] = df
        for i in range(2, k+1):
            kappa[i] = kappa[i - 1] * 2 * (i - 1)
        return kappa


#  9.1.5 Distribution of the logarithm of a 𝜒2 random variable: pdf, cdf and sf

    def logrv_chi2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.6 Distribution of the logarithm of a 𝜒2 random variable: qtf and isf
    def logrv_chi2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.7 Fisher 𝑧 distribution: pdf, cdf and sf

    def fisher_z_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.8 Fisher 𝑧 distribution: qtf and isf
    def fisher_z_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.9 Distribution of the negative logarithm of a beta variable: pdf, cdf and sf

    def logrv_beta_ecf_pdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.10 Distribution of the negative logarithm of a beta variable: qtf and isf
    def logrv_beta_ecf_qtf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.11 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.12 Wilks’ Lambda distribution: qtf and isf

    def wilks_lambda_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.13 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.14 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def CalcT2VMoments2(self, ctx, IsT2, k, p, n1, n2):
        # calculates the raw moments of the null distribution of Hotelling's T2 and Pillai's V
        #mraw = [0 for row in range(k+1)]
        mraw = ctx.matrix(k+1, 1)
        mu = [0 for row in range(k+1)]
        L0 = [0 for row in range(k+1)]
        nu = [0 for row in range(k+1)]
        L1 = [0 for row in range(k+1)]
        a = [0 for row in range(k+1)]
        Lr = [0 for row in range(k+1)]
        for r in range(0, p+1):
            a[r] = 0.5 * (p - r) * (n2 - r)
            if r == p:
                L1[r] = 0
            else:
                L1[r] = (r + 1) * (n2 - r - 1) * (p + n2 - r) * (n1 - p +
                                                                 1 + r) / ((p + n2 - 2 * r - 2) * (p + n2 - 2 * r - 1))
            mu[r] = (-r * (p + n2 - r) * (p + 2 * n1 + n2 + 1) + p * (n1 + n2)
                     * (p + n2 + 1)) / ((p + n2 - 2 * r - 1) * (p + n2 - 2 * r + 1))
            if r == 0:
                nu[r] = 0
            else:
                nu[r] = -(p - r + 1) * (n1 + n2 - r + 1) / \
                    ((p + n2 - 2 * r + 1) * (p + n2 - 2 * r + 2))
            if r < p:
                L0[r] = 0
            else:
                L0[r] = 1
        rfakt = 1
        for r in range(1, k+1):
            rfakt = rfakt * r
            mraw[r] = 0
            weight = 1
            for j in range(p, -1, -1):
                sum1 = 0
                if j > 0:
                    sum1 = sum1 + nu[j] * L0[j - 1]
                sum1 = sum1 + mu[j] * L0[j]
                if j < p:
                    sum1 = sum1 + L1[j] * L0[j + 1]
                sum1 = sum1 / (r - a[j])
                Lr[j] = sum1
                mraw[r] = mraw[r] + sum1 / weight
                weight = weight * (n2 + p - j + 1)
            if (IsT2 and ((r % 2) != 0)):
                mraw[r] = -mraw[r]
            mraw[r] = mraw[r] * rfakt
            print(r, mraw[r])
            for j in range(0, p+1):
                L0[j] = Lr[j]
        return mraw

    def pillai_v_moments(self, ctx, k, p, n1, n2):
        mraw = self.CalcT2VMoments2(ctx, False, k, p, n1, (p - n1 - n2 + 1))
        return mraw


#  9.1.15 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.16 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def hotelling_t2_moments(self, ctx, k, p, n1, n2):
        mraw = self.CalcT2VMoments2(ctx, True, k, p, n1, n2)
        return mraw


#  9.1.17 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.18 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.19 Box-Davis distribution (covariance matrices): pdf, cdf and sf

    def box_davis_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.20 Box-Davis distribution (covariance matrices): qtf and isf
    def box_davis_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.21 Noncentral chi-squared distribution: pdf, cdf and sf

    def chi2_nc_ecf(self, ctx, x, n, lambda1, order, verbose):
        x = ctx.t(x)
        n = ctx.t(n)
        #order = 10
        kappa = self.chi2_nc_cumulants(ctx, order+3, n, lambda1)
        if verbose:
            for i in range(2, order+3):
                print(i, kappa[i])
        L1, R1 = self.edgeworth(ctx, x, order, kappa)
        return L1, R1

#  9.1.22 Noncentral chi-squared distribution: qtf and isf
    def chi2_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def chi2_nc_cumulants(self, ctx, k, df, lambda1):
        #        df = ctx.convert(2000)
        #        lambda1 = 33
        #        k = 10
        kappa = ctx.matrix(k+1, 1)
        kappa[0] = 1
        kappa[1] = df + lambda1
        for i in range(2, k+1):
            kappa[i] = kappa[i - 1] * 2 * \
                (i - 1) * (1 + lambda1 / (df + (i - 1) * lambda1))
        return kappa


#  9.1.23 Noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.24 Noncentral 𝑡-distribution: qtf and isf
    def student_t_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.1.25 Noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.26 Noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def fisher_f_nc_moments(self, ctx, k, n1, n2, lambda1):
        print("k:", k, "n1:", n1, "n2:", n2, "lambda1:", lambda1)
        #mraw = [0 for row in range(k+1)]
        mraw = ctx.matrix(k+1, 1)
        for r in range(1, k+1):
            F1 = ctx.hyp1f1r(-r, n1/2, -lambda1/2)
            G = (n2/n1)**r * ctx.gamma(n1/2+r) * \
                ctx.gamma(n2/2-r) / ctx.gamma(n2/2)
            mraw[r] = G * F1
            print("r:", r, "mu:", mraw[r])
        return mraw


#  9.1.27 Doubly noncentral 𝑡-distribution: pdf, cdf and sf

    def student_t_nc2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.28 Doubly noncentral 𝑡-distribution: qtf and isf
    def student_t_nc2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def student_t_nc2_moments(self, ctx, k, n, delta, theta):
        import math
        print("k:", k, "n:", n, "delta:", delta, "theta:", theta)
        #mraw = [0 for row in range(k+1)]
        mraw = ctx.matrix(k+1, 1)
        for r in range(1, k+1):
            sum1 = 0
            F = 1
            F = ctx.hyp1f1(r/2, n/2, -theta/2)
            temp = (n/2)**(r/2) * ctx.gamma((n-r)/2) / ctx.gamma(n/2)
            limit = int(math.floor(r/2))
            for i in range(0, limit+1):
                p1 = ctx.binomial(r, 2*i)
                p2 = ctx.factorial(2*i)/(2**i * ctx.factorial(i))
                p3 = delta**(r-2*i)
                summand = p1 * p2 * p3
                sum1 = sum1 + summand
            mraw[r] = temp * F * sum1
            print("r:", r, "mu:", mraw[r])
        return mraw


#  9.1.29 Doubly noncentral 𝐹-distribution: pdf, cdf and sf

    def fisher_f_nc2_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.1.30 Doubly noncentral 𝐹-distribution: qtf and isf
    def fisher_f_nc2_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def fisher_f_nc2_moments(self, ctx, k, n1, n2, lambda1, lambda2):
        print("k:", k, "n1:", n1, "n2:", n2,
              "lambda1:", lambda1, "lambda2:", lambda2)
        #mraw = [0 for row in range(k+1)]
        mraw = ctx.matrix(k+1, 1)
        for r in range(1, k+1):
            F1 = ctx.hyp1f1r(-r, n1/2, -lambda1/2)
            F2 = ctx.hyp1f1r(+r, n2/2, -lambda2/2)
            G = (n2/n1)**r * ctx.gamma(n1/2+r)*ctx.gamma(n2/2-r)
            mraw[r] = G * F1 * F2
            print("r:", r, "mu:", mraw[r])
        return mraw


# %% 9.2 Edgeworth and Cornish-Fisher expansions: discrete (lattice) distributions


# 9.2.1 The Sheppard correction

    def sheppard_correction(self, ctx, kappa, show=False):
        if show:
            print("Sheppard cumulants")
        for i in range(2, kappa.rows):
            kappa[i] = kappa[i] - 1 * ctx.bernoulli(i) / i
            if show:
                print("i:", i, "kappa:", kappa[i])
        return kappa


#   9.2.2 Poisson distribution: pdf, cdf and sf

    def poisson_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.2.3 Poisson distribution: qtf and isf
    def poisson_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def poisson_cumulants(self, ctx, mu, maxcum):
        kappa = ctx.matrix(maxcum+1, 1)
        for j in range(1, maxcum+1):
            kappa[j] = mu
        return kappa


#   9.2.4 Binomial distribution: pdf, cdf and sf

    def binomial_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.2.5 Binomial distribution: qtf and isf
    def binomial_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def binomial_central_moments(self, ctx, n, p, rmax):
        mraw1 = n*p
        mu = ctx.matrix(rmax+1, 1)
        mu[0] = 1
        mu[1] = 0
        mu[2] = n*p*(1-p)
        for r in range(3, rmax):
            sum1 = 0
            sum2 = 0
            for i in range(r-1):
                bk = ctx.binomial(r-1, i)
                sum1 += bk * mu[i]
                sum2 += bk * mu[i+1]
            mu[r] = mu[2] * sum1 - p * sum2
            #print("r:", r, "mu[r]:", mu[r])
        mu[1] = mraw1
        return mu

    def binomial_cumulants(self, ctx, n, p, rmax):
        mu = self.binomial_central_moments(ctx, n, p, rmax)
        kappa = ctx.cumulants_from_centralmoments(mu)
        return kappa


#   9.2.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.2.7 Negative binomial distribution: qtf and isf
    def negbinom_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def negbinom_central_moments(self, ctx, r, p, jmax):
        mraw1 = r*(1-p)/p
        mu = ctx.matrix(jmax+1, 1)
        mu[0] = 1
        mu[1] = 0
        mu[2] = r*(1-p)/(p*p)
        for j in range(3, jmax):
            sum1 = 0
            sum2 = 0
            for l in range(j-1):
                bk = ctx.binomial(j-1, l)
                sum1 += bk * mu[l]
                sum2 += bk * mu[l+1]
            mu[j] = mu[2] * sum1 + ((1-p)/p) * sum2
            #print("j:", j, "mu[j]:", mu[j])
        mu[1] = mraw1
        return mu

    def negbinom_cumulants(self, ctx, r, p, jmax):
        mu = self.negbinom_central_moments(ctx, r, p, jmax)
        kappa = ctx.cumulants_from_centralmoments(mu)
        return kappa


#   9.2.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.2.9 Hypergeometric distribution: qtf and isf
    def hypergeo_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def hypergeo_rawmoments(self, ctx, M, n, NN, rmax):
        T = ctx.matrix(rmax+2, 1)
        S = ctx.matrix(rmax+2, rmax+2)
        mu = ctx.matrix(rmax+2, 1)
        T[1] = n * M / NN
        for j in range(1, rmax+1):
            S[j, j] = 1
        jmax = rmax
        if jmax > n:
            jmax = n
        if jmax > M:
            jmax = M
        for j in range(1, jmax+1):
            T[j + 1] = T[j] * (n - j) * (M - j) / (NN - j)
        for i in range(1, rmax+1):
            for j in range(1, rmax+1):
                S[i + 1, j] = j * S[i, j] + S[i, j - 1]
        for i in range(1, rmax+1):
            for j in range(1, jmax+1):
                mu[i] = mu[i] + S[i, j] * T[j]
        return mu

    def hypergeo_cumulants(self, ctx, M, n, NN, rmax):
        mu = self.hypergeo_rawmoments(ctx, M, n, NN, rmax)
        kappa = ctx.cumulants_from_rawmoments(mu)
        return kappa


# 9.2.10 Wilcoxon Signed Rank distribution: pdf, cdf and sf

    def wilcoxon_ecf(self, ctx, x, N, order):
        kappa = self.wilcoxon_cumulants(ctx, N, order+3)
        kappa = self.sheppard_correction(ctx, kappa)
        L1, R1 = self.edgeworth(ctx, x+0.5, order, kappa)
        return L1, R1


# 9.2.11 Wilcoxon Signed Rank distribution: qtf and isf

    def wilcoxon_ecf_inv(self, ctx, L1, R1, N, order):
        kappa = self.wilcoxon_cumulants(ctx, N, order+3)
        kappa = self.sheppard_correction(ctx, kappa)
        X1 = self.cornish_fisher(ctx, L1, R1, kappa, order-5)-0.5
        return X1

    def wilcoxon_cumulants(self, ctx, N, cmax):
        # Fellingham, 1964
        kappa = ctx.matrix(cmax+1, 1)
        cmax = cmax // 2
        kappa[1] = N*(N+1)/4
        for j in range(1, cmax+1):
            s1 = (ctx.t(2)**(2*j)-1) * ctx.bernoulli(2*j) / (2*j)
            s2 = (ctx.bernpoly(2*j + 1, N + 1) -
                  ctx.bernoulli(2*j + 1)) / (2*j + 1)
            kappa[2*j] = (s1 * s2)
        return kappa


# 9.2.12 Kendall’s 𝑆 (or 𝜏 ) distribution: pdf, cdf and sf

    def kendall_ecf(self, ctx, x, N, order):
        kappa = self.kendall_cumulants(ctx, N, order+3)
        kappa = self.sheppard_correction(ctx, kappa)
        L1, R1 = self.edgeworth(ctx, x+0.5, order, kappa)
        return L1, R1


# 9.2.13 Kendall’s 𝑆 (or 𝜏 ) distribution: qtf and isf

    def kendall_ecf_inv(self, ctx, L1, R1, N, order):
        kappa = self.kendall_cumulants(ctx, N, order+3)
        kappa = self.sheppard_correction(ctx, kappa)
        X1 = self.cornish_fisher(ctx, L1, R1, kappa, order-5)-0.5
        return X1

    def kendall_cumulants(self, ctx, N, maxcum):
        #Praskova, 1976
        kappa = ctx.matrix(maxcum+1, 1)
        maxcum = maxcum // 2
        kappa[1] = N * (N-1) / 4
        for j in range(1, maxcum+1):
            if ((j % 2) != 0):
                sign = 1
            else:
                sign = -1
            j2 = 2 * j
            Bern = ctx.bernpoly(j2 + 1, N + 1)
            Bn0j2_1 = ctx.bernoulli(j2 + 1)
            sum1 = (Bern - Bn0j2_1) / (j2 + 1)
            kappa[j2] = sign * ctx.fabs(ctx.bernoulli(j2)) * (sum1 - N) / j2
        return kappa


# 9.2.14 Mann-Whitney 𝑈 distribution: pdf, cdf and sf

    def mannwhitney_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 9.2.15 Mann-Whitney 𝑈 distribution: qtf and isf
    def mannwhitney_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 9.2.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf and sf

    def jterpsta_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

# 9.2.17 Jonckheere-Terpsta 𝑆 distribution: qtf and isf
    def jterpsta_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def TerpstaCum(self, ctx, k, n, maxcum):
        m = ctx.matrix(k+1, 1)
        kappa = ctx.matrix(maxcum+1, 1)
        m[0] = 0
        for j in range(1, k+1):
            m[j] = m[j - 1] + n[j]
        TS = 0
        for j in range(1, k):
            TS = TS + m[j] * n[j + 1]
        for j in range(2, maxcum+1, 2):
            kappa[j] = self.JTCum(ctx, j, k, n, m)
        return kappa, TS

    def JTCum(self, ctx, j, k, n, m):
        # Robillard, 1972
        nn = m[k]
        j2 = j
        j21 = j2 + 1
        sum1 = 0
        F = 1
        for i in range(1, j+1):
            F = F * 2
        for i in range(1, k+1):
            sum1 = sum1 + ctx.bernpoly(j21, n[i] + 1)
        res = F * ctx.bernoulli(j2) / (1.0 * j2 * j21) * \
            (ctx.bernpoly(j21, nn + 1) + (k - 1) * ctx.bernoulli(j21) - sum1)
        return res


#   9.2.18 Page 𝐿 distribution: pdf, cdf and sf

    def page_ecf(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.2.19 Page 𝐿 distribution: qtf and isf
    def page_ecf_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %% 9.3 Luggannini-Rice and Jensen saddle point expansions: continuous distributions


# 9.3.1 Luggannini-Rice expansion: general approximation to the pdf, cdf, and sf


    def sign(self, x):
        if x < 0:
            return -1
        if x > 0:
            return 1
        return 0

    def lugannani_rice(self, ctx,  order, kderiv, s, verbose=False):
        #      theta = ctx.matrix(order + 1, 1); sumf = ctx.matrix(order + 1, 1)
        #      A = ctx.matrix(order + 1, 1); B = ctx.matrix(order + 1, 1)
        #      d = ctx.matrix(2 * order + 3, 2 * order + 3)

        theta = ctx.matrix(order + 1, 1)
        sumf = ctx.matrix(order + 1, 1)
        A = ctx.matrix(order + 1, 1)
        B = ctx.matrix(order + 1, 1)
        d = ctx.matrix(2 * order + 3, 2 * order + 3)

        w = self.sign(s) * ctx.sqrt(2 * (s * kderiv[1] - kderiv[0]))
        u = s * ctx.sqrt(kderiv[2])
        w1 = 1 / w
        w2 = -2 * w1 * w1
        mu = 1 / u

        k = ctx.sqrt(kderiv[2])
        factor = 2 * kderiv[2]

        for j in range(3, order+1):
            factor = factor * j * k
            theta[j] = kderiv[j] / factor

        density = ctx.ndens(w)

        B[0] = density * w1
        factor = ctx.convert(0.5)

        for j in range(1, order+1):
            B[j] = B[j - 1] * w2 * factor
            factor += 1

        d[0, 0] = ctx.convert(1)
        for m in range(0, order-2):
            for n in range(m, order-2):
                sum0 = ctx.convert(0)
                for k in range(1, n - m + 2):
                    sum0 = sum0 + k * theta[k + 2] * d[m, n - k + 1]
                d[m + 1, n + 1] = sum0 / (n + 1)

        A[0] = density * mu
        for j in range(1, order-2):
            sum1 = ctx.convert(0)
            for n in range(0, (2 * j)+1):
                sum2 = ctx.convert(0)
                for m in range(0, n+1):
                    sum2 += d[m, n] * ((-2) ** (m + j)) * \
                        self.GammaHalf(ctx, m + j)
                sum1 += ((-mu) ** (2 * j - n)) * sum2
            A[j] = A[0] * sum1

        totalsum = ctx.convert(0)
        useorder = order - 3
        LastSumj = ctx.convert("10")

        for j in range(0, useorder+1):
            sumf[j] = A[j] - B[j]
            #abssumj = ctx.fabs(sumf[j].mid)
            abssumj = ctx.fabs(sumf[j])
            if verbose:
                print("j:", j, "A:", abssumj, "L:",
                      LastSumj, "L>A:", (LastSumj > abssumj))
            if (LastSumj > abssumj):
                totalsum = totalsum + sumf[j]
                LastSumj = abssumj
            else:
                break
        LeftTail = ctx.ndis(w) - totalsum
        RightTail = ctx.ndis(-w) + totalsum
        return LeftTail, RightTail

    def GammaHalf(self, ctx,  mj):
        return ctx.gamma(ctx.convert(mj + 0.5)) / ctx.sqrt(ctx.pi)


# 9.3.2a jensen expansion: general approximation to the qtf and isf


    def jensen(self, ctx,  kderiv, s):
        w = self.sign(s) * ctx.sqrt(2 * (s * kderiv[1] - kderiv[0]))
        u = s * ctx.sqrt(kderiv[2])
        v = ctx.log(u/w)
        r = w + (v/w)
        LeftTail = ctx.ndis(ctx.convert(r))
        RightTail = ctx.ndis(ctx.convert(-r))
        return LeftTail, RightTail


# 9.3.2b jensen expansion: general approximation to the qtf and isf


    def jensen_inverse(self, ctx,  n0, lambda0_, za_):
        upperlimit = ctx.convert(0.5)
        za = ctx.convert(za_)
        #s = self.sign(za) * ctx.convert("0.01")
        s = ctx.convert("0.01")
        print("s:", s)
        Order = 5
        kderiv = ctx.matrix(Order+2, 1)

        for lp in range(1, 100):
            #print("Iteration: ", lp)
            kderiv = self.CdisnKderiv(ctx, Order, s, n0, lambda0_)

            w = self.sign(s) * ctx.sqrt(2 * (s * kderiv[1] - kderiv[0]))
            u = s * ctx.sqrt(kderiv[2])

            v = ctx.log(u/w)
            r = w + (v/w)
            h = r - za
            w1 = s * kderiv[2] / w
            u1 = (s * kderiv[3] + 2 * kderiv[2]) / (2 * ctx.sqrt(kderiv[2]))
            h1 = w1 + (w*u1 - u*w1 * (v+1)) / (u*w*w)
            # print("s: ", s)
            # print("r: ", r)
            # print("h: ", h)
            # print("h1: ", h1)

            adj = h/h1
            #print("adj:", adj)
            stemp = ctx.convert((s-adj))
            fits = stemp < upperlimit
            if fits:
                s = s-adj
            else:
                print("no fit")
                s = s + (ctx.convert(upperlimit) - s)/2
            #print("new s:", s)
            rel_adj = ctx.fabs(ctx.convert((adj/s)))
            print("s:", s, "rel_adj:", rel_adj)
            if rel_adj < ctx.convert(1E-10):
                break
            # print()
        print("final s:", s)
        x = self.CdisnX0FromSP(ctx, n0, s, lambda0_)
        return x

    def JensenDemo(self, ctx):
        nu = 10.0
        nc = 0.0
        za = -14.0

        print("jensen_inverse")
        x = self.jensen_inverse(ctx, nu, nc, za)
        print("x: ", x)
        print("Jensen2")
        L, R = self.CdisnJensen(ctx, x, nu, nc)
        print("LeftTail1:", L, ",  RightTail1:", R)
        LeftTail = ctx.ndis(za)
        RightTail = ctx.ndis(-za)
        print("LeftTail2:", LeftTail, ",  RightTail2:", RightTail)
        LeftTail3, RightTail3 = ctx.chi2_nc_penev_cdf(x, nu, nc)
        print("LeftTail3:", LeftTail3, ",  RightTail3:", RightTail3)


#   9.3.3 Central Chi-square: pdf, cdf, sf

    def chi2_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.3.4 Central Chi-square: qtf, isf
    def chi2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#   9.3.5 Fisher 𝑧 distribution: pdf, cdf, sf

    def fisher_z_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#   9.3.6 Fisher 𝑧 distribution: qtf, isf
    def fisher_z_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 9.3.7 Noncentral Chi-square: pdf, cdf, sf

    def chi2_nc_spa(self, ctx, x0, n0, lambda0_, Order, verbose):
        s = self.CdisnSP(ctx, n0, x0, lambda0_)
        #x = self.CdisnX0FromSP(ctx, n0, s, lambda0_)
#        print("s0: ", s)
#        print("x0: ", x0)
#        print("x1: ", x)
        kderiv = self.CdisnKderiv(ctx, Order, s, n0, lambda0_)
        LeftTail, RightTail = self.lugannani_rice(
            ctx, Order, kderiv, s, verbose)
        return LeftTail, RightTail


# 9.3.8 Noncentral Chi-square: qtf, isf


    def chi2_nc_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def CdisnJensen(self, ctx,  x0, n0, lambda0_):
        s = self.CdisnSP(ctx, n0, x0, lambda0_)
        kderiv = self.CdisnKderiv(ctx, 2, s, n0, lambda0_)
        LeftTail, RightTail = self.jensen(ctx, kderiv, s)
        return LeftTail, RightTail

    # noncentral chi2: K'(x)

    def CdisnKderiv(self, ctx,  order, t0, n0, lambda0_):
        kderiv = ctx.matrix(order+2, 1)
        t = ctx.convert(t0)
        n = ctx.convert(n0)
        lambda_ = ctx.convert(lambda0_)
        kderiv[0] = -(n / 2) * ctx.log(1 - 2 * t) + lambda_ * t / (1 - 2 * t)
        for j in range(1, order+1):
            p1 = (2 ** (j - 1)) * ctx.gamma(j) / ((1 - 2 * t) ** j)
            p2 = (n + (lambda_ * j) / (1 - 2 * t))
            kderiv[j] = p1 * p2
        return kderiv

    # noncentral chi2: saddlepoint

    def CdisnSP(self, ctx,  n0, x0, lambda0_):
        n = ctx.convert(n0)
        x = ctx.convert(x0)
        lambda_ = ctx.convert(lambda0_)
        s = -(1 / (4 * x)) * (n - 2 * x + ctx.sqrt(n * n + 4 * x * lambda_))
        return s

    # noncentral chi2: x0 from saddlepoint
    def CdisnX0FromSP(self, ctx,  n0, s0, lambda0_):
        n = ctx.convert(n0)
        s = ctx.convert(s0)
        lambda_ = ctx.convert(lambda0_)
        x = (n + lambda_ / (1 - 2 * s)) / (1 - 2 * s)
        return x


# 9.3.9 Doubly Non-central Fisher F


    def fisher_f_nc2_spa(self, ctx, x, n1, n2, lambda1, lambda2):
        Order = 18
        s = self.FdisNCalcSaddlepoint(ctx, n1, n2, x, lambda1, lambda2)
        #print("s: ", s)
        kderiv = self.FdisNButlerKderiv(
            ctx, Order, s, n1, n2, lambda1, lambda2)
        LeftTail, RightTail = self.lugannani_rice(ctx, Order, kderiv, s)
        return LeftTail, RightTail

    def FdisNButlerKderiv(self, ctx, Order, S_, N1_, N2_, t1_, t2_):
        S = ctx.convert(S_)
        N1 = ctx.convert(N1_)
        N2 = ctx.convert(N2_)
        t1 = ctx.convert(t1_)
        t2 = ctx.convert(t2_)
        F = self.FdisNButlerFromS(ctx, S_, N1_, N2_, t1_, t2_)
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

    def FdisNButlerFromS(self, ctx, S_, N1_, N2_, t1_, t2_):
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

    def FdisNCalcSaddlepoint(self, ctx, N1_, N2_, F_, t1_, t2_):
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


# 9.3.10 Doubly Non-central Fisher F: qtf, isf


    def fisher_f_nc2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def FdisnJensen(self, ctx, N1, N2, F, t1, t2):
        S = self.FdisNCalcSaddlepoint(ctx, N1, N2, F, t1, t2)
        kderiv = self.FdisNButlerKderiv(ctx, 2, S, N1, N2, t1, t2)
        LeftTail, RightTail = self.jensen(ctx, kderiv, S)
        return LeftTail, RightTail


#  9.3.11 Wilks’ Λ distribution, pdf, cdf, sf

    def wilks_lambda_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.12 Wilks’ Λ distribution, cdf and sf
    def wilks_lambda_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.13 Distribution of the product of independent beta variables, pdf, cdf, sf

    def beta_prod_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.14 Distribution of the product of independent beta variables : qtf, isf
    def beta_prod_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.15 Box distribution: pdf, cdf, sf

    def box_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.16 Box distribution : qtf, isf
    def box_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.17 Non-central Beta distribution: pdf, cdf, sf

    def beta_nc_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.18 Non-central Beta distribution : qtf, isf
    def beta_nc_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.19 Fisher’s 𝑅2 distribution: pdf, cdf, sf

    def fisher_r2_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.20 Fisher’s 𝑅2 distribution : qtf, isf
    def fisher_r2_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.21 Noncentral Wilks’ Λ distribution: MANOVA, pdf, cdf, sf

    def wilks_lambda_glm_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.22 Noncentral Wilks’ Λ distribution: MANOVA, qtf, isf
    def wilks_lambda_glm_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.3.23 Noncentral Wilks’ Λ distribution: Independence, pdf, cdf, sf

    def wilks_lambda_ind_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.3.24 Noncentral Wilks’ Λ distribution: Independence, : qtf, isf
    def wilks_lambda_ind_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %% 9.4 Luggannini-Rice and Jensen saddle point expansions: discrete (lattice) distributions


#  9.4.1 The Sheppard correction

    def sheppard_per_cgf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.2 Poisson distribution: pdf, cdf, sf

    def poisson_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.3 Poisson distribution: qtf, isf
    def poisson_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.4 Binomial distribution: pdf, cdf and sf

    def binomial_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.5 Binomial distribution: qtf and isf
    def binomial_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def binomial_kderiv(self, ctx, order, t, n, p):
        def k0(t, n, p): return n * ctx.ln(p*ctx.exp(t) + 1 - p)
        def k1(t, n, p): return n*p*ctx.exp(t) / (p*ctx.exp(t)+1-p)
        def k2(t, n, p): return -n*(p-1)*p*ctx.exp(t) / (p*(ctx.exp(t)-1)+1)**2
        def k3(t, n, p): return n*(p-1)*p*ctx.exp(t) * \
            (p*ctx.exp(t)+p-1) / (p*(ctx.exp(t)-1)+1)**3
        explicit = True
        kderiv = ctx.matrix(order+1, 1)
        t = ctx.convert(t)
        n = ctx.convert(n)
        p = ctx.convert(p)
        kderiv[0] = k0(t, n, p)
        #print(0, kderiv[0])
        for j in range(1, order+1):
            if explicit:
                if j < 4:
                    if j == 1:
                        kderiv[j] = k1(t, n, p)
                    if j == 2:
                        kderiv[j] = k2(t, n, p)
                    if j == 3:
                        kderiv[j] = k3(t, n, p)
                else:
                    kderiv[j] = ctx.diff(lambda x: k3(x, n, p), t, j-3)
            else:
                print("in deriv k0")
                kderiv[j] = ctx.diff(lambda x: k0(x, n, p), t, j)
            #print(j, kderiv[j])
        return kderiv


#  9.4.6 Negative binomial distribution: pdf, cdf and sf

    def negbinom_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.7 Negative binomial distribution: qtf and isf
    def negbinom_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def negbinomial_kderiv(self, ctx, order, t, r, p):
        def k0(t, r, p): return r * ctx.ln((1-p)/(1-p*ctx.exp(t)))
        def k1(t, r, p): return (p*r*ctx.exp(t))/(1-p*ctx.exp(t))
        def k2(t, r, p): return (p*r*ctx.exp(t))/((1-p*ctx.exp(t))**2)
        def k3(t, r, p): return (p*r*ctx.exp(t) *
                                 (p*ctx.exp(t)+1))/((1-p*ctx.exp(t))**3)
        explicit = True
        kderiv = ctx.matrix(order+1, 1)
        t = ctx.convert(t)
        r = ctx.convert(r)
        p = ctx.convert(p)
        kderiv[0] = k0(t, r, p)
        #print(0, kderiv[0])
        for j in range(1, order+1):
            if explicit:
                if j < 4:
                    if j == 1:
                        kderiv[j] = k1(t, r, p)
                    if j == 2:
                        kderiv[j] = k2(t, r, p)
                    if j == 3:
                        kderiv[j] = k3(t, r, p)
                else:
                    kderiv[j] = ctx.diff(lambda x: k3(x, r, p), t, j-3)
            else:
                print("in deriv k0")
                kderiv[j] = ctx.diff(lambda x: k0(x, r, p), t, j)
            #print(j, kderiv[j])
        return kderiv


#  9.4.8 Hypergeometric distribution: pdf, cdf and sf

    def hypergeo_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.9 Hypergeometric distribution: qtf and isf
    def hypergeo_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")

    def hypergeo_cgf(self, ctx, t, a, b, c, T):
        res = ctx.ln(T * ctx.hyp2f1(a, b, c, ctx.exp(t)))
        return res

    def hypergeo_cgf_diff(self, ctx, t, n, K, N, d):
        a = -n
        b = -K
        c = N-K-n+1
        T = ctx.binomial(N-K, n)/ctx.binomial(N, n)
        if d == 0:
            return self.hypergeo_cgf(ctx, t, a, b, c, T)
        else:
            return ctx.diff(lambda x: self.hypergeo_cgf(ctx, x, a, b, c, T), t, d)

    def hypergeo_kderiv(self, ctx, t, n, K, N):
        startdps = ctx.dps
        ctx.dps = 2*startdps
        a = -n
        b = -K
        c = N-K-n+1
        T = ctx.binomial(N-K, n)/ctx.binomial(N, n)
        print("a:", a, "b:", b, "c:", c, "T:", T)
        z = ctx.exp(t)
        H = ctx.matrix(9, 1)
        H[0] = ctx.hyp2f1(a, b, c, z)
        H[1] = ctx.hyp2f1(a+1, b+1, c+1, z)*a*b/c

        for i in range(0, 7):
            H[i+2] = ((a+i)*(b+i)*H[i] -
                      (((c+i)-((a+i)+(b+i)+1)*z)*H[i+1])) / (z*(1-z))
        for i in range(9):
            H[i] = ctx.exp(i*t) * H[i]

        F0 = 1*H[0]
        F1 = 1*H[1]
        F2 = 1*H[2] + 1*H[1]
        F3 = 1*H[3] + 3*H[2] + 1*H[1]
        F4 = 1*H[4] + 6*H[3] + 7*H[2] + 1*H[1]
        F5 = 1*H[5] + 10*H[4] + 25*H[3] + 15*H[2] + 1*H[1]
        F6 = 1*H[6] + 15*H[5] + 65*H[4] + 90*H[3] + 31*H[2] + 1*H[1]
        F7 = 1*H[7] + 21*H[6] + 140*H[5] + 350 * \
            H[4] + 301*H[3] + 63*H[2] + 1*H[1]
        F8 = 1*H[8] + 28*H[7] + 266*H[6] + 1050*H[5] + \
            1701*H[4] + 966*H[3] + 127*H[2] + 1*H[1]

        F02 = F0*F0
        F03 = F02*F0
        F04 = F03*F0
        F05 = F04*F0
        F06 = F05*F0
        F07 = F06*F0
        F08 = F07*F0
        F12 = F1*F1
        F13 = F12*F1
        F14 = F13*F1
        F15 = F14*F1
        F16 = F15*F1
        F17 = F16*F1
        F18 = F17*F1
        F22 = F2*F2
        F23 = F22*F2
        F24 = F23*F2
        F32 = F3*F3
        F42 = F4*F4

        K = ctx.matrix(9, 1)
        K[0] = ctx.ln(T * F0)
        K[1] = F1/F0
        K[2] = F2/F0 - F12/F02
        K[3] = F3/F0 + 2*F13/F03 - 3*F1*F2/F02
        K[4] = F4/F0 + 12*F12*F2/F03 - (3*F22+4*F3*F1)/F02 - 6*F14/F04
        S2 = (5*F4*F1 + 10*F3*F2)/F02 + 60*F13*F2/F04
        K[5] = F5/F0 + (20*F3*F12 + 30*F1*F22)/F03 + 24*F15/F05 - S2
        S2 = (10*F32 + 6*F5*F1 + 15*F4*F2)/F02 + \
            (120*F3*F13 + 270*F12*F22)/F04 + 120*F16/F06
        K[6] = F6/F0 + (30*F23 + 30*F4*F12 + 120*F3*F1*F2) / \
            F03 + 360*F14*F2/F05 - S2

        S1 = F7/F0 + (42*F5*F12 + 210*F3*F22 + 140*F32*F1 + 210*F4*F1*F2)/F03
        S1 += (840*F3*F14 + 2520*F13*F22)/F05 + 720*F17/F07
        S2 = (7*F6*F1 + 21*F5*F2 + 35*F3*F4)/F02 + (2520*F15*F2)/F06
        S2 += (210*F4*F13 + 630*F1*F23 + 1260*F3*F12*F2)/F04
        K[7] = S1-S2

        S1 = F8/F0 + (56*F6*F12 + 420*F4*F22 + 560*F32 *
                      F2 + 336*F5*F1*F2 + 560*F3*F4*F1)/F03
        S1 += (1680*F4*F14 + 10080*F12*F23 + 13440 *
               F3*F13*F2)/F05 + 20160*F16*F2/F07
        S2 = (35*F42 + 8*F7*F1 + 28*F6*F2 + 56*F3*F5)/F02
        S2 += (630*F24 + 336*F5*F13 + 1680*F32*F12 +
               2520*F4*F12*F2 + 5040*F3*F1*F22)/F04
        S2 += (6720*F3*F15 + 25200*F14*F22)/F06 + (5040*F18)/F08
        K[8] = S1-S2

        ctx.dps = startdps
        return K


#  9.4.10 Wilcoxon distribution: pdf, cdf, sf

    def wilcoxon_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.11 Wilcoxon distribution: qtf, isf
    def wilcoxon_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.12 Mann-Whitney’s U distribution: pdf, cdf, sf

    def mannwhitney_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.13 Mann-Whitney’s U distribution: qtf, isf
    def mannwhitney_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.14 Kendall’s Tau distribution: pdf, cdf, sf

    def kendall_tau_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.15 Kendall’s Tau distribution: qtf, isf
    def kendall_tau_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.16 Jonckheere-Terpsta 𝑆 distribution: pdf, cdf, sf

    def jterpsta_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.17 Jonckheere-Terpsta 𝑆 distribution: qtf, isf
    def jterpsta_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


#  9.4.18 Page 𝐿 distribution: pdf, cdf, sf

    def page_spa(self, ctx):
        raise Exception("NOT IMPLEMENTED")

#  9.4.19 Page 𝐿 distribution: qtf, isf
    def page_spa_inv(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# %% 9.5 Box-Davis expansions and their inverses


#  9.5.1 Box-Davis expansion: general approximation to the pdf, cdf and sf

    def box_davis_expansion(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.2 Box-Davis expansion: general approximation to the qtf and isf
    def box_davis_expansion_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.3 Wilks’ Lambda distribution: pdf, cdf and sf

    def wilks_lambda_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.4 Wilks’ Lambda distribution: qtf and isf
    def wilks_lambda_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.5 Distribution of the product of independent beta variates: pdf, cdf and sf

    def beta_product_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

# 9.5.6 Distribution of the product of independent beta variates: qtf and isf
    def beta_product_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.7 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_cov_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.8 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_cov_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.9 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: pdf, cdf and sf

    def box_means_cov_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.10 Distribution of Box’s test of equality of k covariance matrices, unequal sample sizes: qtf and isf
    def box_means_cov_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.11 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: pdf, cdf and sf

    def lrt_vc0_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.12 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix: qtf and isf
    def lrt_vc0_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.13 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: pdf, cdf and sf

    def lrt_x0_vc0_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.14 Distribution of the modified likelihood ratio test (LRT) for a given covariance matrix and mean: qtf and isf
    def lrt_x0_vc0_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.15 Pillai’s 𝑉 distribution: pdf, cdf and sf

    def pillai_v_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.16 Pillai’s 𝑉 distribution: qtf and isf
    def pillai_v_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")


#  9.5.17 Hotelling’s 𝑇2 distribution: pdf, cdf and sf

    def hotelling_t2_bd(self, ctx, x, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

#  9.5.18 Hotelling’s 𝑇2 distribution: qtf and isf
    def hotelling_t2_bd_inv(self, ctx, q, f, rho, omega):
        raise Exception("NOT IMPLEMENTED")

    def cp(self, ctx,  n, k, h, p, F, z):
        # Dim a As Integer, b As Integer, i As Integer, j As Integer, Q As Integer, r As Integer
        if F:
            if z:
                a = n
                p[k] = -1
            else:
                a = n - k
                p[k] = 0
            # End If
            F = False
            j = k
        else:
            a = p[1] - p[2] - 2
            j = 2
            while p[1] - p[j] < 2:
                a = a - 1 + j * (p[j] - p[j + 1])
                j = j + 1
            # End While
        # End If
        b = h - 1 - p[j]
        Q = int(a // b)
        #print("Q:", Q)
        r = a - b * Q
        for i in range(1, Q+1):
            p[i] = h
        # Next i
        if Q == k:
            F = True
            return F
            # Exit Sub
        # End If
        for i in range(Q + 1, j+1):
            p[i] = 1 + p[j]
        # Next i
        p[Q + 1] = r + p[Q + 1]
        if (p[1] - p[k]) < 2:
            F = True
        return F
    # End Sub

    def CalcOmega(self, ctx,  o, p, m):
        # Dim j As Integer, position As Integer, i As Integer
        # Dim Value(0 To 100) As Integer, count(0 To 100) As Integer
        Value = ctx.matrix(100, 1)
        count = ctx.matrix(100, 1)
        # Dim prod As Double
        Value[1] = p[1]
        count[1] = 1
        position = 1
        for i in range(2, m+1):
            if p[i - 1] == p[i]:
                count[position] = count[position] + 1
            else:
                position = position + 1
                Value[position] = p[i]
                count[position] = 1
            # End If
        # Next i
        prod = 1
        for i in range(1, position+1):
            prod = prod * o[int(Value[i])]
            for j in range(2, int(count[i])+1):
                prod = prod * o[int(Value[i])] / j
            # Next j
        # Next i
        return prod
    # End Function

    def CalcZ(self, ctx,  h, p, m, n_order):
        # Dim d As Integer, i As Integer
        d = 0
        for i in range(1, m+1):
            d = d + p[i] + 2
        # Next i
        return h[int(n_order + d - 1)]
    # End Function

    def calc(self, ctx,  IsBoxDavis, h, o, p, k, n_order):
        #        Dim m As Integer, i As Integer
        #        Dim co As Double, ch As Double
        i = 1
        while ((p[i] != 0) and (i < k + 1)):
            i = i + 1
        # End While
        m = i - 1
        return self.CalcOmega(o, p, m) * self.CalcZ(h, p, m, n_order)

    def BoxDavisSum(self, ctx,  IsBoxDavis, UseOne, h, o, n, n_order):
        #        Dim icount As Integer, k As Integer, HH As Integer, i As Integer
        # Dim p(0 To 100) As Integer
        p = ctx.matrix(100, 1)
#        Dim F As Boolean, z As Boolean
#        Dim sum As Double
        HH = n
        icount = 1
        z = True  # 'Teil kann 0 sein
        F = True
        # '  UseOne=true Teil kann 1 sein
        if UseOne:
            k = n
        else:
            k = n // 2
        sum = 0
        F = self.cp(n, k, HH, p, F, z)
        sum = sum + self.calc(IsBoxDavis, h, o, p, k, n_order)
        while (F == False):
            F = self.cp(n, k, HH, p, F, z)
            if not(UseOne):
                i = 1
                while ((p[i] != 1) and (i < k + 1)):
                    i = i + 1
                # End While
                if i == (k + 1):
                    sum = sum + self.calc(IsBoxDavis, h, o, p, k, n_order)
                    icount = icount + 1
                # End If
            else:
                sum = sum + self.calc(IsBoxDavis, h, o, p, k, n_order)
                icount = icount + 1
            # End If
        # End While
        return sum

    def NewTestWilksUArb(self, ctx):
        ctx.dps = 30
        print("Hello NewTestWilksUArb")
        p = 1  # number of variables
        f1 = 10000  # number of groups
        n = 10000  # n is sample size
        LeftTail = ctx.convert("0.51")
        Righttail = 1 - LeftTail
#        b = ctx.matrix(p + 1, 1)
#        c = ctx.matrix(p + 1, 1)
        b = ctx.matrix(p + 1, 1)
        c = ctx.matrix(p + 1, 1)
        for i in range(1, p + 1):
            b[i] = (n - i + 1) / 2
            c[i] = b[i] + f1 / 2
            # 'Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
#        result2 = self.BetaProdDisX2Arb(LeftTail, Righttail, p, b, c)
#        print("result2: {0}", result2)
#        resultL = -ctx.log(result2)
#        print("resultL: {0}", resultL)
#        resultM = -n * ctx.log(result2)
#        print("resultM: {0}", resultM)
#        LeftTail2, RightTail2 = self.BetaProdDis2Arb(p, b, c, result2)
#        print("LeftTail2: {0}", LeftTail2)

#        resultM = ctx.convert("693.9404416810925277082492625552503112248")  # n=1000
        resultM = ctx.convert(
            "6933.979073352299894516426803975980616234")  # n=10000
        self.NewBetaProdDistArb(ctx, LeftTail, Righttail,
                                p, n / 2, b, c, resultM)

    def NewBetaProdDistArb(self, ctx,  LeftTail, RightTail, k, n2, bi, ci, resultM):
        #        y = ctx.matrix(k + 4, 1)
        #        xi = ctx.matrix(k + 4, 1)
        #        eta = ctx.matrix(k + 4, 1)
        y = ctx.matrix(k + 4, 1)
        xi = ctx.matrix(k + 4, 1)
        eta = ctx.matrix(k + 4, 1)

        for j in range(1, k + 1):
            y[j] = n2
            xi[j] = bi[j] - n2
            eta[j] = ci[j] - bi[j] + xi[j]  # 'simplify later
            # 'Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}, xi(j): {3}", j, y(j), eta(j), xi(j))

        print("")
        print("Hello TestBoxDavis")
        TargetError = ctx.convert("1.0E-20")

        # 'TestBoxDavisArb("Quantile", "CHI2", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        # 'Console.WriteLine("resultM: {0}", resultM)
#        self.TestBoxDavisArb("PValue", "CHI2", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
#        print("LeftTail: {0}", LeftTail)

        self.TestBoxDavisArb(ctx, "Quantile", "CornishFisher", k, k,
                             y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
        print("resultM: {0}", resultM)
#        self.TestBoxDavisArb("PValue", "CornishFisher", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
#        print("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail)

    def TestBoxDavisArb(self, ctx,  C_Result, C_Algorithm, a, b, x, y, xi, eta, z, LeftTail, RightTail, TargetError):

        if C_Algorithm == "CHI2":

            # ' Calculate f
            sum1 = 0
            for k in range(1, a + 1):
                sum1 = sum1 + xi[k]
            sum2 = 0
            for j in range(1, b + 1):
                sum2 = sum2 + eta[j]
            f = -2 * (sum1 - sum2 - (a - b) / 2)
            print("f: {0}", f)

            # ' Calculate rho
            sum1 = 0
            for k in range(1, a + 1):
                sum1 = sum1 + ctx.bernpoly(2, xi[k]) / x[k]
            sum2 = 0
            for j in range(1, b + 1):
                sum2 = sum2 + ctx.bernpoly(2, eta[j]) / y[j]
            rho = 1 - (sum1 - sum2) / f
            print("rho: {0}", rho)

            # ' Calculate omega
            rmax = 1400
            rsign = -1
            omega = ctx.matrix(rmax + 1, 1)

            for r in range(1, rmax + 1):
                rsign = -rsign
                sum1 = 0
                for k in range(1, a + 1):
                    sum1 = sum1 + \
                        ctx.bernpoly(r + 1, (1 - rho) *
                                     x[k] + xi[k]) / ((rho * x[k]) ** r)
                sum2 = 0
                for j in range(1, b + 1):
                    sum2 = sum2 + \
                        ctx.bernpoly(r + 1, (1 - rho) *
                                     y[j] + eta[j]) / ((rho * y[j]) ** r)
                omega[r] = rsign * (sum1 - sum2) / (r * (r + 1))

            if C_Result == "PValue":  # Get p-value
                LeftTail = self.GuptaArbNew(
                    rmax, f, z * rho, rho, omega, TargetError)
                print("LeftTail: ", LeftTail)
            # End If

#            'If C_Result = "Quantile" Then ' Get Quantile
#            '    Call DavisPercentileArb(f, z, LeftTail, RightTail, rho, omega)
#            'End If

        # End If C_Algorithm = "CHI2"

        if C_Algorithm == "CornishFisher":

            # ' Calculate cumulants
            print("")
            print("Hello Calculate cumulants")

            rmax = 20
            # Dim kappa As New arb_mat_t()
            #kappa = ctx.matrix(rmax + 1, 1)
            kappa = ctx.matrix(rmax + 1, 1)

            #kappa.resize(rmax + 1, 1)
            for r in range(1, rmax + 1):
                sum1 = 0
                for k in range(1, a + 1):
                    sum1 = sum1 + ((-2 * x[k]) ** r) * \
                        ctx.polygamma(r - 1, x[k] + xi[k])
                # Next k
                sum2 = 0
                for j in range(1, b + 1):
                    sum2 = sum2 + ((-2 * y[j]) ** r) * \
                        ctx.polygamma(r - 1, y[j] + eta[j])
                # Next j
                kappa[r] = sum1 - sum2
                # 'Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa(r))
            # Next r
            mean = kappa[1]
            sigma = ctx.sqrt(kappa[2])

            if C_Result == "Quantile":  # ' Get quantile
                #XX = self.ndisx(LeftTail, RightTail)
                #XAdj = CFArb_Continuous(rmax, XX, kappa, TargetError)
                XAdj = self.CalcCornish(
                    ctx, LeftTail, RightTail, mean, sigma, kappa, rmax-5)
                print("XAdj:      ", XAdj)
                #z = mean + sigma * XAdj.mid()
            # End If C_Result == "Quantile"

            if C_Result == "PValue":  # ' Get p-value
                print("")
                fxTarget = (z - mean) / sigma
                print("z: {0}, fxTarget: {1}", z, fxTarget)
                x3Start = self.CF_up(fxTarget, kappa)
                Result2 = self.InvCornArbContinuous(
                    fxTarget, x3Start, kappa, rmax, TargetError)
                LeftTail = self.ndis(Result2)
                RightTail = self.ndis(-Result2)
            # End If C_Result == "PValue"
        # End If C_Algorithm == "CornishFisher"

    def GuptaArbNew(self, ctx,  cmax, f, z, rho, omega, TargetError):
        print("f: {0}, z: {1}, rho: {2}", f, z, rho)
        LogKB = ctx.convert(0)
        sum = self.Arb_ChiSquare_CDF(z, f, True, False)

        a = ctx.matrix(cmax, 1)
        a[0] = ctx.convert(1.0)
        for j in range(1, cmax + 1):
            temp = ctx.convert(0.0)
            for l in range(1, j + 1):
                temp = temp + l * omega[l] * a[j - l]
            a[j] = temp / j
            LogKB = LogKB + omega[j]

            adj = self.Arb_ChiSquare_CDF(z, f + 2 * j, True, False)
            adj2 = a[j] * adj
            sum = sum + adj2
            if j % 2 == 0:
                # 'Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
                RelErr = ctx.fabs(adj2 / sum)
                print("j: {0}, sum: {1}, adj2: {2}, RelErr: {3}",
                      j, sum, adj2, RelErr)
                if RelErr < TargetError:
                    break   # Then Exit For
        KB = ctx.exp(-LogKB)
        print("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}",
              LogKB, KB, sum, KB * sum)
        LeftTail = KB * sum
        return LeftTail


# 9.5.2 Box-Davis expansion: general approximation to the qtf and isf (for 𝜔1 = 0)

    def DavisPercentile(self, ctx,  f, LeftTail, RightTail, rho, o):
        #        Dim p1 As New arb_t, p2 As New arb_t, p3 As New arb_t, p4 As New arb_t, P5 As New arb_t, p6 As New arb_t, P7 As New arb_t, P22 As New arb_t, P32 As New arb_t, P42 As New arb_t, P33 As New arb_t, P222 As New arb_t, P52 As New arb_t, P43 As New arb_t, P322 As New arb_t,
        #            f2 As New arb_t, f3 As New arb_t, f4 As New arb_t, f5 As New arb_t, f6 As New arb_t, f7 As New arb_t,
        #            f12 As New arb_t, f13 As New arb_t, f22 As New arb_t,
        #            S1 As New arb_t, u As New arb_t, u2 As New arb_t, u3 As New arb_t, u4 As New arb_t, u5 As New arb_t, u6 As New arb_t, u7 As New arb_t,
        #            sum As New arb_t, i As Integer, show As Boolean
        #        Dim s As New arb_mat_t
        s = ctx.matrix(7 + 1, 1)
        show = True
        u = self.cdisx(LeftTail, RightTail, f)
        f2 = f * (f + 2)
        f3 = f2 * (f + 4)
        f4 = f3 * (f + 6)
        f5 = f4 * (f + 8)
        f6 = f5 * (f + 10)
        f7 = f6 * (f + 12)
        f12 = f * f
        f13 = f12 * f
        f22 = f2 * f2
        u2 = u * u
        u3 = u * u2
        u4 = u * u3
        u5 = u * u4
        u6 = u * u5
        u7 = u * u6
        S1 = u2 * (3 * f + 4 * 2 - 2) / (f2 * f2) \
            + u3 * (3 * f + 4 * 3 - 2) / (f2 * f3) \
            + u4 * (3 * f + 4 * 4 - 2) / (f2 * f4) \
            + u5 * (3 * f + 4 * 5 - 2) / (f2 * f5)
        p1 = u / f
        p2 = p1 + u2 / f2
        p3 = p2 + u3 / f3
        p4 = p3 + u4 / f4
        P5 = p4 + u5 / f5
        p6 = P5 + u6 / f6
        P7 = p6 + u7 / f7
        P22 = -8 * u4 * (f + 3) / (f2 * f4) + 8 * u3 / \
            (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12
        P32 = -12 * u5 * (f + 4) / (f2 * f5) - 2 * u4 * (f - 6) / (f2 * f4) + 2 * u3 * (3 * f + 10) / (f2 * f3) \
            + 6 * u2 / (f * f2) + 2 * u / f12
        P42 = -16 * u6 * (f + 5) / (f2 * f6) - 4 * u5 * (f - 4) / (f2 * f5) + 2 * u4 * (3 * f + 14) / (f2 * f4) \
            + 2 * u3 * (3 * f + 10) / (f2 * f3) + 6 * \
            u2 / (f * f2) + 2 * u / f12
        P33 = -6 * u6 * (3 * f12 + 30 * f + 80) / (f3 * f6) - 6 * u5 * (f2 + 2 * f - 16) / (f3 * f5) + 4 * u4 * (f + 12) / (f2 * f4) \
            + 4 * u3 * (3 * f + 8) / (f2 * f3) + 6 * \
            u2 / (f * f2) + 2 * u / f12
        P222 = 32 * u6 * (7 * f12 + 62 * f + 120) / (f22 * f6) - 32 * u5 * (2 * f12 + 37 * f + 96) / (f22 * f5) - 8 * u4 \
            * (23 * f12 + 124 * f + 132) / (f22 * f4) - 8 * u3 * (f - 10)(f * f2 * f3) + 28 * u2 / (f12 * f2) + 4 * u / f13
        P52 = -20 * u7 * (f + 6) / (f2 * f7) - 2 * u6 * \
            (3 * f - 10) / (f2 * f6) + S1 + 2 * u / f12
        P43 = -24 * u7 * (f2 + 12 * f + 40) / (f3 * f7) - 2 * u6 * (5 * f2 + 18 * f - 80) / (f3 * f6) \
            + 2 * u5 * (f2 + 42 * f + 176) / (f3 * f5) + 4 * u4 * (3 * f + 16) / (f2 * f4) + 4 * u3 * (3 * f + 8) / (f2 * f3) \
            + 6 * u2 / (f * f2) + 2 * u / f12
        P322 = 192 * u7 * (2 * f13 + 31 * f12 + 154 * f + 240) / (f2 * f3 * f7) \
            - 16 * u6 * (4 * f13 + 153 * f12 + 1106 * f + 2160) / (f2 * f3 * f6) - 8 * u5 * (35 * f3
                                                                                             + 420 * f12 + 1540 * f + 1632) / (f2 * f3 * f5) - 4 * u4 * (25 * f12 + 80 * f + 12) / (f22 * f4) \
            + 4 * u3 * (7 * f + 38) / (f * f2 * f3) + \
            28 * u2 / (f12 * f3) + 4 * u / f13
        s[2] = o[2] * p2
        s[3] = o[3] * p3
        s[4] = o[4] * p4 + 0.5 * (o[2] ^ 2) * P22
        s[5] = o[5] * P5 + o[3] * o[2] * P32
        s[6] = o[6] * p6 + o[4] * o[2] * P42 + 0.5 * (o[3] ^ 2) * P33 \
            + o[2] * o[2] * o[2] * P222 / 6
        s[7] = o[7] * P7 + o[5] * o[2] * P52 + o[4] * o[3] * P43 \
            + 0.5 * o[3] * (o[2] ^ 2) * P322
        sum = 0
        if show:
            print("u: {0}", u)
        for i in range(2, 7+1):
            sum = sum + s[i]
            if show:
                print("i: {0}, sum: {1}, s(i): {2}", i, sum, s(i))
        x = u + 2 * sum
        print("resultM/rho in DavisPercentile: {0}", x / rho)
        return x / rho
