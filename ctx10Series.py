# -*- coding: utf-8 -*-
"""
Created on Fri Apr  3 20:13:25 2015

@author: DH
"""


# 8 Series and integrals


class ctxSeries(object):

    # %% 8.1 Finite series algorithms for selected distributions

    # %%% 8.1.1 Central 𝜒2 distribution, cdf (integer degrees of freedom)
    def chi2_cohen_cdf(self, ctx, x, nu):
        # Algorithm by Owen
        k = int(nu) % 2
        nu = ctx.convert(nu)
        x = ctx.convert(x)
        c = -ctx.exp(-x / 2)
        f = ctx.convert(1)
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


# %%% 8.1.2 Central Student 𝑡 distribution, cdf (integer degrees of freedom)

    def student_t_owen_cdf(self, ctx, x, nu):
        # Algorithm by Owen
        one = ctx.convert(1)
        k = int(nu) % 2
        nu = ctx.convert(nu)
        x = ctx.convert(x)
        a = x / ctx.sqrt(nu)
        b = 1 + a * a
        f = ctx.convert(0.5)
        if k != 0:
            c = a / (b * ctx.pi)
            f = f + ctx.atan(a) / ctx.pi
        else:
            c = a / (2 * ctx.sqrt(b))
        k = k + 2
        i = k
        while i <= nu:
            f = f + c
            c = c * (one - (one / i)) / b
            i = i + 2
        return f


# %%% 8.1.3 Central Fisher 𝐹 distribution, cdf (integer degrees of freedom)

    def fisher_f_seber_cdf(self, ctx, x, m, n):
        # Algorithm by Owen
        one = ctx.convert(1)
        k = int(m) % 2
        m = ctx.convert(m)
        n = ctx.convert(n)
        x = ctx.convert(x)
        if k == 0:
            z = n / (n + m * x)
            result = z ** (n / 2)
            if m > 2:
                u = one - z
                sum0 = one
                a = one
                i = one
                while i <= (m - 2) / 2:
                    a = (a * u * (2 * i + n - 2)) / (2 * i)
                    sum0 = sum0 + a
                    i = i + 1
                result = result * sum0
        else:
            z = ctx.sqrt(m * x)
            #result = 2 * self.tdisOwen(n, -z)
            result = 2 * self.student_t_owen_cdf(ctx, -z, n)
            if m > 1:
                u = z * z / (z * z + n)
                sum0 = z
                a = z
                i = 2
                while i <= (m - 1) / 2:
                    a = (a * u * (2 * i + n - 3)) / (2 * i - 1)
                    sum0 = sum0 + a
                    i = i + 1
                result = result + 2.0 * sum0 * self.tdens(ctx, n, z)
        return 1-result


# %%% 8.1.4 Central Beta distribution, cdf (2𝑎 an integer, 2𝑏 an integer)

    def beta_seber_cdf(self, ctx, x, a, b):
        # Algorithm by Owen
        x = ctx.convert(x)
        m = 2 * ctx.convert(a)
        n = 2 * ctx.convert(b)
        xf = (n/m) * x/(1-x)
        result = self.fisher_f_seber_cdf(ctx, xf, m, n)
        return result


# %%% 8.1.5 Noncentral 𝜒2 distribution, cdf (integer degrees of freedom)

    def chi2_nc_cohen_cdf(self, ctx, x, n, nc):
        # Algorithm by Cohen
        half = ctx.t(0.5)
        n = int(n)
        x = ctx.t(x)
        nc = ctx.t(nc)

        basedps = ctx.dps
        L1 = ctx.chi2_nc_cdf(x, 1, nc, True, method='spa')
        #print("L1 in cohen, n=1:", L1, " spa")
        L4 = ctx.chi2_nc_cdf(x, n, nc, True, method='spa')
        #print("L4, in cohen n=" + str(n), L4, " spa")
        ctx.dps = basedps + int(n/2) - int(ctx.log10(L4/L1))
        #print("new dps:", ctx.dps)

        x1 = ctx.sqrt(x)
        d = ctx.sqrt(nc)
        e = ctx.exp(half * (x + nc))

        g1 = ctx.cosh(ctx.sqrt(x * nc)) / ctx.sqrt(2 * ctx.pi * x) / e
        g3 = ctx.sinh(ctx.sqrt(x * nc)) / ctx.sqrt(2 * ctx.pi * nc) / e
        f1 = ctx.ndis(x1 - d) - ctx.ndis(-x1 - d)
        f3 = f1 - 2 * g3

        for i in range(5, n+1, 2):
            g5 = (x * g1 - (i - 4) * g3) / nc
            f5 = f3 - 2 * g5
            g1 = g3
            g3 = g5
            f3 = f5
        ctx.dps = basedps
        return f3


# %%% 8.1.6 Noncentral Student 𝑡 distribution, cdf (integer degrees of freedom)

    def student_t_nc_owen_cdf(self, ctx, x, n, delta):
        # Algorithm by Owen
        half = ctx.t(0.5)
        one = ctx.t(1)
        n = int(n)
        x = ctx.t(x)
        d = ctx.t(delta)

        LBroda = ctx.student_t_nc_cdf(x, n, delta, True, method='broda')
        #print("LBroda:", LBroda)
        extradigits = 1 + int(-ctx.log10(LBroda))
        #print("extradigits:", extradigits)
        basedps = ctx.dps
        ctx.dps = ctx.dps + extradigits

        h = 2 / ctx.sqrt(2 * ctx.pi)
        a = x / ctx.sqrt(n)
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
        ctx.dps = basedps
        return 1 * F


# %%% 8.1.7 Noncentral Fisher 𝐹 distribution, cdf (𝑚 an even integer)

    def fisher_f_nc_seber_cdf(self, ctx, x, nu1, nu2, nc):
        # Algorithm by Seber
        nu1 = int(nu1)
        nu2 = ctx.t(nu2)
        x = ctx.t(x)
        nc = ctx.t(nc)
        y = x * nu1 / (x * nu1 + nu2)
        result = self.beta_nc_seber_cdf(ctx, y, nu1/2, nu2/2, nc)
        return result


# %%% 8.1.8 Noncentral Beta distribution, cdf (𝑏 an integer)

    def beta_nc_seber_cdf(self, ctx, x0, a0, b0, lambda0_):
        # Algorithm by Seber
        b = int(b0)
        a = ctx.t(a0)
        x = ctx.t(x0)
        lambda_ = ctx.t(lambda0_)
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


# %%% 8.1.9 Pearson’s 𝜌 distribution, pdf (integer N)

    def pearson_rho_nc_owen_pdf(self, ctx, r, N, rho):
        cdf, pdf = self.pearson_rho_nc_owen_pdf_cdf(ctx, r, N, rho)
        return pdf


# %%% 8.1.10 Pearson’s 𝜌 distribution, cdf (integer N)

    def pearson_rho_nc_owen_cdf(self, ctx, r, N, rho):
        cdf, pdf = self.pearson_rho_nc_owen_pdf_cdf(ctx, r, N, rho)
        return cdf

    def pearson_rho_nc_owen_pdf_cdf(self, ctx, r, N, rho):
        r = ctx.convert(r)
        rho = ctx.convert(rho)
        Pi = ctx.convert(ctx.pi)
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


# %%% 8.1.11 Fisher’s 𝑅2 distribution, cdf (finite sum for 𝑁 − 𝑝 even)


    def fisher_r2_gd1_cdf(self, ctx, x, p, N, Rho2):
        # Gurland 1968, equ. 33
        x = ctx.t(x)
        Rho2 = ctx.t(Rho2)

        if ((N-p) % 2) != 0:
            print("p:", p, "N:", N, "x:", x, "Rho2:", Rho2)
            raise Exception("(N-p) needs to be an even number")

        y = x * (1 - Rho2) / (1 - Rho2 * x)
        k = int((N - p) / 2)
        #print("k:", k)
        sum1 = ctx.t(0)
        bj = ctx.t(1)
        for j in range(0, k+1):
            bj = ctx.binomial(k, j) * Rho2**j * (1 - Rho2)**(k - j)
            sum0 = bj * ctx.real_ibeta(ctx.t(0.5) * (p - 1 + 2 * j), k, y)
            sum1 = sum1 + sum0
        LeftTail = sum1
        RightTail = 1 - sum1
        return LeftTail, RightTail


# %%% 8.1.12 Roy’s largest root distribution, pdf, cdf and sf


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


# %% 8.2 Infinite series algorithms for selected functions and distributions


# %%% 8.2.1 Incomplete gamma function, continued fractions (Peizer)

    def gamma_peizer_cdf_sf_pdf(self, ctx, b, m):
        b = ctx.convert(b)
        m = ctx.convert(m)
        One = ctx.convert(1)
        Zero = ctx.convert(0)
        MinRelError = ctx.convert("1.0E-" + str(ctx.dps))
        if (m <= Zero):
            LeftTail = Zero
            RightTail = One
            density = Zero
            return LeftTail, RightTail, density
        #density = self.cdens(ctx, 2*b, 2*m)
        density = ctx.chi2_pdf(2*m, 2*b)
        #print("density:", density)
        if (m <= b - ctx.convert('0.5')):
            c3 = True  # LeftTail probability
        else:
            c3 = False  # RightTail probability
        k = 2 * density
        a0 = One
        b0 = One
        bn = Zero
        j = Zero
        sum0 = One
        sum1 = One
        if c3:
            k = k * m / b
            A1 = b + One - m
            b1 = b + One
            bn = b + One
        else:
            A1 = m + One - b
            b1 = m
        eps = One
        while (ctx.fabs(eps) > MinRelError):
            j = j + One
            i = 0
            while i <= 1:
                if c3:
                    if i == 1:
                        an = -(b + j) * m
                    else:
                        an = j * m
                    bn = bn + One
                else:
                    if i == 1:
                        an = j + One - b
                        bn = m
                    else:
                        an = j
                        bn = One
                A2 = bn * A1 + an * a0
                b2 = bn * b1 + an * b0
                A2 = A2 / b2
                A1 = A1 / b2
                b1 = b1 / b2
                b2 = One
                a0 = A1
                A1 = A2
                b0 = b1
                b1 = b2
                if i == 1:
                    sum1 = A2
                else:
                    sum0 = A2
                i = i + 1
            xsum = (sum0 + sum1) / 2
            eps = ctx.fabs(sum0 - sum1) / xsum
        k = k / xsum
#        print(j)
        LeftTail = One - k
        RightTail = k
        if c3:
            return RightTail, LeftTail, density
        return LeftTail, RightTail, density


# %%% 8.2.2 Incomplete gamma function, asymptotic expansion (Paris)


    def real_gamma_paris_p(self, ctx, a, z, n):
        l, r = self.gamma_paris_cdf_sf(a, z, n)
        return l

    def real_gamma_paris_q(self, ctx, a, z, n):
        l, r = self.gamma_paris_cdf_sf(a, z, n)
        return r

    def gamma_paris_cdf_sf(self, ctx, a, z, n):
        a = ctx.convert(a)
        z = ctx.convert(z)
        verbose = False
        zero = ctx.convert(0)
        one = ctx.convert(1)
        UseLeftTail = True
        z2 = ctx.sqrt(z)
        x = (z - a) / z2
        if x > 0:
            UseLeftTail = False
        f = ctx.power(z, a - 0.5) * ctx.exp(-z) / ctx.gamma(a)
        d = self.d0(ctx, ctx.fabs(x))
        #n = 5
#        ak = ctx.matrix(n + 3, 1)
#        bk = ctx.matrix(n + 3, 1)
        ak = ctx.matrix(n + 3, 1)
        bk = ctx.matrix(n + 3, 1)
        S3 = self.GetS3(ctx, 4 * n)
        pk = self.GetPK(ctx, 4 * n, x)
        qk = self.GetQK(ctx, 4 * n, x)
        for k in range(0, n + 1):
            sumak = zero
            sumbk = zero
            jsign = 1
            for j in range(0, k + 1):
                s = S3[k + 2 * j, j]
                p = pk[k + 2 * j]
                q = qk[k + 2 * j]
                sumak = sumak + jsign * s * p
                sumbk = sumbk + jsign * s * q
                jsign = -jsign
            ak[k] = sumak
            bk[k] = sumbk
        aksum = zero
        bksum = zero
        zk2 = one
#        print("a:", a)
#        print("z", z)
#        print("x:", x)
#        print("d:", d)
        for k in range(0, n + 1):
            aksum = aksum + ak[k] / zk2
            bksum = bksum + bk[k] / zk2
            zk2 = zk2 * z2
            #print("k: ", k, " d*aksum: ", d * aksum, " bksum: ", bksum)
            #print("k: ", k, " ak[k]: ", ak[k], " bksum: ", bk[k])
            temp = (d*ak[k]-bk[k])/zk2
            if verbose:
                if temp < 0:
                    print("k: ", k, " d*ak[k]-bk[k]/zk2: ", temp)
                else:
                    print("k: ", k, " d*ak[k]-bk[k]/zk2:  ", temp)

        if UseLeftTail:
            result = f * (d * aksum + bksum)
            lefttail = result  # / self.gamma(a)
            righttail = 1 - lefttail
        else:
            result = f * (d * aksum - bksum)
            righttail = result  # / self.gamma(a)
            lefttail = 1 - righttail
#        print("result: ", result)
#        print("lefttail: ", lefttail)
#        print("righttail: ", righttail)

        return lefttail, righttail

    def GetS3(self, ctx, n):
        #        S3 = ctx.matrix(3 * n + 3, n + 3)
        S3 = ctx.matrix(3 * n + 3, n + 3)
        S3[0, 0] = ctx.convert(1)
        for k in range(3,  3 * n + 1):
            S3[k, 1] = ctx.convert(1)
        for j in range(2, n + 1):
            for k in range(3 * j - 1, 3 * n + 1):
                S3[k + 1, j] = j * S3[k, j] + \
                    ctx.binomial(k, 2) * S3[k - 2, j - 1]
        return S3

    def GetPK(self, ctx, n, x):
        #        pk = ctx.matrix(n + 3, 1)
        pk = ctx.matrix(n + 3, 1)
        pk[0] = ctx.convert(1)
        pk[1] = ctx.convert(-x)
        for k in range(1, n + 1):
            pk[k + 1] = (pk[k - 1] - x * pk[k]) / (k + 1)
        return pk

    def GetQK(self, ctx, n, x):
        #        qk = ctx.matrix(n + 2, 1)
        qk = ctx.matrix(n + 2, 1)
        qk[0] = ctx.convert(0)
        qk[1] = ctx.convert(-1)
        for k in range(1, n + 1):
            qk[k + 1] = (qk[k - 1] - x * qk[k]) / (k + 1)
        return qk

    def d0(self, ctx, x):
        a1 = ctx.sqrt(0.5 * ctx.pi)
        a2 = ctx.exp(0.5 * x * x)
        a3 = ctx.erfc(x * ctx.sqrt(0.5))
        result = a1 * a2 * a3
        return result


# %%% 8.2.3 Incomplete beta function, continued fractions (Peizer)

    def beta_peizer_cdf_sf_pdf(self, ctx,  a, b, q, p):
        a = ctx.t(a)
        b = ctx.t(b)
        q = ctx.t(q)
        p = ctx.t(p)
        NeedToConvert = not ((b - 0.5) <= (a + b - 1) * p)
        #print("NeedToConvert: {0}", NeedToConvert)
        if NeedToConvert:
            Temp = a
            a = b
            b = Temp
            Temp = q
            q = p
            p = Temp
        L, R, density = self.betadis_(ctx, a, b, q, p)
        if NeedToConvert:
            Temp = L
            L = R
            R = Temp
        return L, R, density

    def betadens(self, ctx,  a, b, Q, p):
        #print("x: ", Q, "a: ", a, "b: ", b)
        k = -ctx.logbeta(a, b)
        k = k + (b - 1.0) * ctx.ln(p) + (a - 1.0) * ctx.ln(Q)
        density = ctx.exp(k)
        return density

    def betadis_(self, ctx,  a, b, q, p):
        One = ctx.t(1)
        Zero = ctx.t(0)
        MinRelError = ctx.convert("1.0E-" + str(ctx.dps))
        #print("MinRelError: ", MinRelError)
        if (q <= Zero):
            LeftTail = Zero
            RightTail = One
            density = Zero
            return LeftTail, RightTail, density
        if (p <= Zero):
            LeftTail = One
            RightTail = Zero
            density = Zero
            return LeftTail, RightTail, density
        density = self.betadens(ctx, a, b, q, p)
        #print("density:", density)
        qp = q / p
        a0 = One
        A1 = a + One - (b - One) * qp
        b0 = One
        b1 = a + One
        j = 0
        bn = a + One
        eps = One
        sum0 = One
        sum1 = One
        # print(qp)
        while (ctx.fabs(eps) > MinRelError):
            j = j + 1
            i = 0
            while i <= 1:
                if i == 1:
                    an = -(a + j) * (b - j - One) * qp
                else:
                    an = j * (a + b - One + j) * qp
                bn = bn + One
                A2 = bn * A1 + an * a0
                b2 = bn * b1 + an * b0
                A2 = A2 / b2
                A1 = A1 / b2
                b1 = b1 / b2
                b2 = One
                a0 = A1
                A1 = A2
                b0 = b1
                b1 = b2
                if i == 1:
                    sum1 = A2
                else:
                    sum0 = A2
                i = i + 1
                #print(sum1, sum0)
            xsum = (sum0 + sum1) / ctx.convert(2)
            eps = ctx.fabs(sum0 - sum1) / xsum
            #print("eps: ", eps)
        LeftTail = density * q / (a * xsum)
        RightTail = 1 - LeftTail
        return LeftTail, RightTail, density


# %%% 8.2.4 Noncentral 𝜒2 distribution, pdf, cdf and sf (Boost)


    def chi2_nc_benton_cdf_sf(self, ctx, x, n, lambda1, cdf):
        if cdf:
            return self.non_central_chi_square_cdf(ctx, x, n, lambda1)
        else:
            return self.non_central_chi_square_cdf_complement(ctx, x,
                n, lambda1)

    def non_central_chi_square_cdf(self, ctx, x, k, l):
        invert = False
        if (x > k + l):
            result = self.non_central_chi_square_q(ctx, x, k, l, -1.0)
            invert = not (invert)
        else:
            result = self.non_central_chi_square_p(ctx, x, k, l, 0.0)
        if invert:
            result = -result
        return result

    def non_central_chi_square_cdf_complement(self, ctx, x, k, l):
        invert = True
        if (x > k + l):
            result = self.non_central_chi_square_q(ctx, x, k, l, 0.0)
            invert = not (invert)
        else:
            result = self.non_central_chi_square_p(ctx, x, k, l, -1.0)
        if invert:
            result = -result
        return result

    def non_central_chi_square_q(self, ctx, x, f, theta, init_sum):
        print("in non_central_chi_square_q")

        if (x == 0):
            return ctx.t(1)
        lambda1 = theta / 2
        del1 = f / 2
        y = x / 2
        max_iter = 1000000
        errtol = 10 * ctx.eps

        sum = init_sum
        k = int(lambda1)
        #poisf = ctx.gamma_p_derivative((1 + k), lambda1)
        poisf = ctx.real_gamma_derivative((1 + k), lambda1)
        poisb = poisf * k / lambda1
        gamf = ctx.real_gamma_derivative(del1 + k, y)
        #xtermf = ctx.gamma_p_derivative(del1 + 1 + k, y)
        xtermf = ctx.real_gamma_derivative(del1 + 1 + k, y)
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
            print("cdf(non_central_chi_squared_distribution Series did not " +
                "converge, closest value was {0}", sum)
            return ctx.t(sum)

        for i in range(k - 1, -1, -1):
            term = poisb * gamb
            sum += term
            poisb *= i / lambda1
            xtermb *= (del1 + i) / y
            gamb -= xtermb
            if ((sum == 0) or (ctx.fabs(term / sum) < errtol)):
                break
        return sum

    def non_central_chi_square_p(self, ctx, y, n, lambda1, init_sum):
        print("in non_central_chi_square_p")
        if (y == 0):
            return 0.0
        max_iter = 1000000
        errtol = 10 * ctx.eps

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
            print("cdf(non_central_chi_squared_distribution Series did not " +
                    "converge, closest value was {0}", sum)
            return sum
        return sum


# %%% 8.2.5 Noncentral Student 𝑡 distribution, pdf, cdf and sf (Boost)


    def student_t_nc_benton_cdf_sf(self, ctx, x, n, delta, cdf=True):
        x = ctx.t(x)
        n = ctx.t(n)
        delta = ctx.t(delta)
        if (delta==0): return ctx.student_t_cdf(x, n, cdf)

        LBroda = ctx.student_t_nc_cdf(x, n, delta, True, method='broda')
        #print("LBroda:", LBroda)
        extradigits = 1 + int(-ctx.log10(LBroda))
        #print("extradigits:", extradigits)
        basedps = ctx.dps
        ctx.dps = ctx.dps + extradigits
        res = 0
        if cdf:
            res = self.non_central_t_cdf(ctx, n, delta, x)
        else:
            res = self.non_central_t_cdf_complement(ctx, n, delta, x)
        ctx.dps = basedps
        return 1 * res

    def non_central_t_cdf(self, ctx, v, delta, t):
        v = ctx.t(v)
        delta = ctx.t(delta)
        t = ctx.t(t)
        return self.non_central_t_cdf_main(ctx, v, delta, t, False)

    def non_central_t_cdf_complement(self, ctx, v, delta, t):
        v = ctx.t(v)
        delta = ctx.t(delta)
        t = ctx.t(t)
        return self.non_central_t_cdf_main(ctx, v, delta, t, True)

    def non_central_t_cdf_main(self, ctx, v, delta, t, invert):
        if (t < 0):
            t = -t
            delta = -delta
            invert = not (invert)
        x = t * t / (v + t * t)
        y = v / (v + t * t)
        d2 = delta * delta
        a = ctx.t(0.5)
        b = v / 2
        c = a + b + d2 / 2
        cross = ctx.t(1) - (b / c) * (ctx.t(1) + d2 / (2 * c * c))
        result = ctx.t(0)
        invert = not (invert)
        if (x != ctx.t(0)):
            result = self.non_central_beta_t2_q(ctx, a, b, d2, x, y, ctx.t(0))
            result = self.non_central_t2_q(ctx, v, delta, x, y, result)
            result /= 2
        else:
            result = ctx.normal_cdf(delta, 0)
        if (invert):
            result = ctx.t(1) - result
        return result


    def non_central_beta_t2_q(self, ctx, a, b, lambda1, x, y, init_val):
        #print("in non_central_beta_t2_q")
        max_iter = 1000000
        errtol = ctx.eps
        l2 = lambda1 / 2
        k = int(l2)
        pois = ctx.t(0)
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
        if (pois == ctx.t(0)):
            return init_val
        beta, xterm = self.ibeta_imp_new_q(ctx, a + k, b, x, y)
        xterm *= y / (a + b + k - 1)
        poisf = pois
        betaf = beta
        xtermf = xterm
        sum = init_val
        if ((beta == ctx.t(0)) and (xterm == ctx.t(0))):
            return init_val
        last_term = ctx.t(0)
        count = 0
        for i in range(k + 1, max_iter+1):
            poisf *= l2 / i
            xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
            betaf += xtermf
            term = poisf * betaf
            sum += term
            if ((ctx.fabs(term / sum) < errtol) and (last_term >= term)):
                count = i - k
                #print("non_central_beta_q count1: ", count)
                break
            if ((i - k) >= max_iter):
                print("cdf(non_central_beta_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
            last_term = term
        for i in range(k, -1, -1):
            term = beta * pois
            sum += term
            if (ctx.fabs(term / sum) < errtol):
                #print("non_central_beta_q count2: ", count)
                break
            if ((count + k - i) >= max_iter):
                print("cdf(non_central_beta_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
            pois *= i / l2
            beta -= xterm
            xterm *= (a + i - 1) / (x * (a + b + i - 2))
        return sum





    def non_central_t2_q(self, ctx, v, delta, x, y, init_val):
        max_iter = 1000000
        errtol = +ctx.eps
        d2 = delta * delta / 2
        k = int(d2)
        if (k == 0):
            k = 1
        pois = ctx.real_gamma_derivative((k + 1), d2) \
            * ctx.gamma_delta_ratio(k + 1, ctx.t(0.5)) \
            * delta / ctx.sqrt(2)
        if (pois == ctx.t(0)):
            return init_val
        beta, xterm = self.ibeta_imp_new_q(ctx, k + 1, v / 2, x, y)
        #print("New: ", "beta: ", beta, "xterm: ", xterm)
        xterm *= y / (v / 2 + k)
        poisf = pois
        betaf = beta
        xtermf = xterm
        sum = init_val
        if ((beta == ctx.t(0)) and (xterm == ctx.t(0))):
            return init_val
        last_term = ctx.t(0)
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
                pois *= (j + ctx.t(0.5)) / d2
                beta -= xterm
                xterm *= (j) / (x * (v / 2 + j - 1))
            sum += term
            if ((ctx.fabs(last_term) >= ctx.fabs(term))
                and (ctx.fabs(term / sum) < errtol)):
                #print("non_central_t2_q count: ", count)
                break
            last_term = term
            if (count >= max_iter):
                print(
                    "cdf(non_central_t_distribution) Series did not " +
                        "converge, closest value was {0}", sum)
                return sum
            count = count + 1
        return sum


# %%% 8.2.6 Noncentral Beta distribution, pdf, cdf and sf (Boost)


    def beta_nc_benton_cdf_sf(self, ctx, x, a, b, lambda1, cdf=True):
        x = ctx.t(x)
        a = ctx.t(a)
        b = ctx.t(b)
        lambda1 = ctx.t(lambda1)
        if cdf:
            return self.non_central_beta_cdf(ctx, a, b, lambda1, x, ctx.t(1)-x)
        else:
            return self.non_central_beta_cdf_complement(ctx, a, b, lambda1,
                x, ctx.t(1)-x)

    def non_central_beta_cdf(self, ctx, a, b, lambda1, x, y):
        invert = False
        result = ctx.t(0)
        c = a + b + lambda1 / 2
        cross = ctx.t(1) - (b / c) * (1 + lambda1 / (2 * c * c))
        if (x > cross):
            result = self.non_central_beta_q(ctx, a, b, lambda1, x, y, ctx.t(-1))
            invert = not (invert)
        else:
            result = self.non_central_beta_p(ctx, a, b, lambda1, x, y, ctx.t(0))
        if invert:
            result = -result
        return result

    def non_central_beta_cdf_complement(self, ctx, a, b, lambda1, x, y):
        invert = True
        result = ctx.t(0)
        c = a + b + lambda1 / 2
        cross = ctx.t(1) - (b / c) * (1 + lambda1 / (2 * c * c))
        if (x > cross):
            result = self.non_central_beta_q(ctx, a, b, lambda1, x, y, ctx.t(0))
            invert = not (invert)
        else:
            result = self.non_central_beta_p(ctx, a, b, lambda1, x, y, ctx.t(-1))
        if invert:
            result = -result
        return result



    def ibeta_imp(self, ctx, a, b, x, inv, normalised):
        xterm = ctx.real_ibeta_derivative(a, b, x)
        if inv:
            #print("in inv")
            #return ctx.ibeta(b, a, 1-x), xterm
            #return ctx.ibeta(a, b, 1-x), xterm
            return ctx.ibeta(a, b, x), xterm
        else:
            #print("in not inv")
            return ctx.ibeta(a, b, x), xterm


    def ibeta_imp_new(self, ctx, a, b, x, y):
        L, R, density = self.beta_peizer_cdf_sf_pdf(ctx, a, b, x, y)
        #print("x: ", x, "y: ", y, "x<y: ", x<y)
        if x < y : return L, density
        else: return R, density

    def ibeta_imp_new_q(self, ctx, a, b, x, y):
        L, R, density = self.beta_peizer_cdf_sf_pdf(ctx, a, b, x, y)
        #print("x: ", x, "y: ", y, "x<y: ", x<y)
        return R, density

    def ibeta_imp_new_p(self, ctx, a, b, x, y):
        L, R, density = self.beta_peizer_cdf_sf_pdf(ctx, a, b, x, y)
        #print("x: ", x, "y: ", y, "x<y: ", x<y)
        return L, density


    def non_central_beta_p(self, ctx, a, b, lambda1, x, y, init_val):
        #print("in non_central_beta_p")
        max_iter = 1000000
        #errtol = 0.000000000000001
        errtol = 10 * ctx.eps

        l2 = lambda1 / 2
        k = int(l2)
        if (k == 0):
            k = 1
        pois = ctx.real_gamma_derivative((k + 1), l2)
        if (pois == ctx.t(0)):
            return init_val
        #xterm = ctx.zero
        #beta = ctx.zero
        #beta, xterm = self.ibeta_imp_new(ctx, a + k, b, x, y)
        beta, xterm = self.ibeta_imp_new_p(ctx, a + k, b, x, y)
        #print("New: ", "beta: ", beta, "xterm: ", xterm)


##        if x < y:
##            beta, xterm = self.ibeta_imp(ctx, a + k, b, x, False, True)
##        else:
##            beta, xterm = self.ibeta_imp(ctx, b, a + k, y, True, True)
##        print("Old: ", "beta: ", beta, "xterm: ", xterm)


        xterm *= y / (a + b + k - 1)
        poisf = pois
        betaf = beta
        xtermf = xterm
        sum = init_val
        if ((beta == ctx.t(0)) and (xterm == ctx.t(0))):
            return init_val
        last_term = ctx.t(0)
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
            if ((ctx.fabs(term / sum) < errtol) or (term == ctx.t(0))):
                break
            if ((i) >= max_iter):
                print("cdf(non_central_beta_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
                return sum
        return sum

    def non_central_beta_q(self, ctx, a, b, lambda1, x, y, init_val):
        #print("in non_central_beta_q")

        max_iter = 1000000
        ##errtol = 0.000000000000001
        errtol = 10 * ctx.eps
        #print("errtol:", errtol)

        l2 = lambda1 / 2
        k = int(l2)
        pois = ctx.t(0)
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
        if (pois == ctx.t(0)):
            return init_val
        #beta, xterm = self.ibeta_imp_new(ctx, a + k, b, x, y)
        beta, xterm = self.ibeta_imp_new_q(ctx, a + k, b, x, y)
        #print("New: ", "beta: ", beta, "xterm: ", xterm)


##        if x < y:
##            beta, xterm = self.ibeta_imp(ctx, a + k, b, x, True, True)
##        else:
##            beta, xterm = self.ibeta_imp(ctx, b, a + k, y, False, True)
##        print("Old: ", "beta: ", beta, "xterm: ", xterm)


        xterm *= y / (a + b + k - 1)
        poisf = pois
        betaf = beta
        xtermf = xterm
        sum = init_val
        if ((beta == ctx.t(0)) and (xterm == ctx.t(0))):
            return init_val
        last_term = ctx.t(0)
        count = 0
        for i in range(k + 1, max_iter+1):
            poisf *= l2 / i
            xtermf *= (x * (a + b + i - 2)) / (a + i - 1)
            betaf += xtermf
            term = poisf * betaf
            sum += term
            if ((ctx.fabs(term / sum) < errtol) and (last_term >= term)):
                count = i - k
                #print("non_central_beta_q count1: ", count)
                break
            if ((i - k) >= max_iter):
                print("cdf(non_central_beta_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
            last_term = term
        for i in range(k, -1, -1):
            term = beta * pois
            sum += term
            if (ctx.fabs(term / sum) < errtol):
                #print("non_central_beta_q count2: ", count)
                break
            if ((count + k - i) >= max_iter):
                print("cdf(non_central_beta_distribution) Series did not " +
                    "converge, closest value was {0}", sum)
            pois *= i / l2
            beta -= xterm
            xterm *= (a + i - 1) / (x * (a + b + i - 2))
        return sum


# %%% 8.2.7 Noncentral F distribution, pdf, cdf and sf (Boost)

    def fisher_f_nc_benton_cdf_sf(self, ctx, x, m, n, lambda1, cdf=True):
        x = ctx.t(x)
        m = ctx.t(m)
        n = ctx.t(n)
        lambda1 = ctx.t(lambda1)
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


# %%% 8.2.8 Pearson’s 𝜌 distribution, cdf and sf (Hotelling’s series)

    # 'Algorithm using infinite series, Hotelling, 1953

    def pearson_rho_nc_ht_cdf(self, ctx, r, n, rho):
        r = ctx.t(r)
        n = ctx.t(n)
        rho = ctx.t(rho)

        fs = [0, 0]
        Betas = [0, 0]
        Dens = [0, 0]
        slimit = 10000
        mlimit = 100
        IBeta = [0 for row in range(slimit)]
        #nk = [0 for row in range(mlimit)]
        nk = [0 for row in range(slimit)]
        Swapped = False
        if rho > r:
            r = -r
            rho = -rho
            Swapped = True
        n = n - 1
        smax = -1
        #Q = (n - 1) * 0.398942280401433 # 1 / sqrt(2*pi)
        Q = (n - 1) / ctx.sqrt(2 * ctx.pi)

        Q = Q * ctx.exp(ctx.loggamma(n) - ctx.loggamma(n + ctx.t(0.5)))
        X = ((r - rho) / (1 - rho * r))
        X = X * X
        y = 1 - X
        Factor = 1
        A1 = 1 - rho * rho
        a = 1
        TWO = 1
        RelError = 1
        m = 0
        sum3 = ctx.t(0)
        sum = ctx.t(0)
        while ctx.fabs(RelError) > +ctx.eps:
            S = 0
            gf = ctx.t(1)
            RelError2 = ctx.t(1)
            while (ctx.fabs(RelError2) > +ctx.eps):
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


# %%% 8.2.9 Pearson’s 𝜌 distribution, cdf and sf (Guenther’s series)

    # ' Algorithm using infinite series, Guenther 1971

    def pearson_rho_nc_gt_cdf(self, ctx, r, n, rho):
        r = ctx.t(r)
        n = ctx.t(n)
        rho = ctx.t(rho)

        Pi = +ctx.pi
        Rho2 = rho * rho
        r2 = r * r
        if rho < ctx.t(0):
            sign = -1
        else:
            if rho > ctx.t(0):
                sign = 1
            else:
                sign = 0
        Left1, Right1 = ctx.betadis(1 / 2, (n - 1) / 2, Rho2, 1 - Rho2)
        sum0 = ctx.t(0.5) * (1 + sign * Left1)
        if r == ctx.t(0):
            RightTail = sum0
            LeftTail = 1 - RightTail
            return LeftTail, RightTail
        k1 = ctx.t(0.5) * ctx.exp(ctx.log(1 - Rho2) * (n - 1) / 2)
        Left1, Right1 = ctx.betadis(1 / 2, (n - 2) / 2, r2, 1 - r2)
        sum1 = k1 * Left1
        sum3 = k1 * Right1
        j = 0
        RelError = 1
        RelError3 = 1
        while RelError > +ctx.eps:
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
        if rho == ctx.t(0):
            sum2 = ctx.t(0)
            sum4 = ctx.t(0)
        else:
            k2 = rho / ctx.sqrt(Pi) * ctx.exp(ctx.loggamma(n / 2) -
                ctx.loggamma((n - 1) / 2) + ctx.log(1 - Rho2) * (n - 1) / 2)
            Left1, Right1 = ctx.betadis(1, (n - 2) / 2, r2, 1 - r2)
            sum2 = k2 * Left1
            sum4 = k2 * Right1
            j = 0
            RelError = 1
            RelError3 = 1
            while RelError > +ctx.eps:
                j = j + 1
                k2 = ((2 * j + n - 2) / (2 * j + 1)) * Rho2 * k2
                Left1, Right1 = ctx.betadis(j + 1, (n - 2) / 2, r2, 1 - r2)
                summand = k2 * Left1
                sum2 = sum2 + summand
                if sum2 != ctx.t(0):
                    RelError = ctx.fabs(summand / sum2)
                summand = k2 * Right1
                sum4 = sum4 + summand
                if sum4 != ctx.t(0):
                    RelError3 = ctx.fabs(summand / sum4)
#                print (j, sum2, RelError, Left1)
#                print (j, sum4, RelError3, Right1)
        RightTail = sum0 - (sum1 + sum2)
        LeftTail = (1 - sum0) + (sum1 + sum2)
        return LeftTail, RightTail


# %%% 8.2.10 Fisher’s 𝑅2 distribution, cdf and sf (Boost, Benton)


    def fisher_r2_gd2_cdf(self, ctx, x, p, ng, Rho2):
        # Gurland 1968, equ. 38 and 39
        x = ctx.t(x)
        p = ctx.t(p)
        ng = ctx.t(ng)
        Rho2 = ctx.t(Rho2)
        #print("p:", p, "N:", ng,"x:", x, "Rho2:",Rho2)
        a = 1 / (1 - Rho2)
        n = ng - 1
        k = (ng - p) / 2
        theta = Rho2 / (1 - Rho2)
        b = a
        BK = k
        p1 = (p - 1) / 2
        binom = ctx.t(1)
        t1 = ctx.t(1)
        y = 2 * k * x / (b * (1 - x))
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
            if (RelErr < +ctx.eps):
                break
        sum = sum * ctx.exp(ctx.log(b) * (p - 1) / 2)
        sum = sum / ctx.exp(ctx.log(a) * n / 2)
        LeftTail = sum
        RightTail = 1 - sum
        return LeftTail, RightTail


class ctxIntegral(object):

    # %% 8.3 Verified numerical integration

    # %%% 8.3.1 Introduction

    # wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
    def quad_verified(self, ctx, func, a, b, epsabsStart, alpha,
        beta, verbose):
        a = ctx.t(a)
        b = ctx.t(b)
        pi = ctx.pi
        p2 = pi / 2
        zero = ctx.t(0)
        one = ctx.t(1)
        hmin = zero
        C1Final = zero
        epsabsFinal = zero
        nmin = ctx.t("1E1000000000000")
        mu = beta
        nu = alpha
        if alpha < beta:
            mu = alpha
            nu = beta
        ab1 = alpha + beta - 1

        # Determine optimal h and n
        for d1 in range(1, 26):
            radX, radY, ds = self.GetRectAndK(d1)
            d = ctx.t(ds)
            #print("radX:, radY:, d:", radX, radY, d)
            radX_ = ctx.t(radX)
            radY_ = ctx.t(radY)
            K = self.GetAcbK(ctx, func, a.mid, b.mid, radX_, radY_)
            C1 = (1 / mu) * 2 * K * (b - a)
            if (ab1 != one):
                C1 = C1 ** ab1
            epsabs = epsabsStart / C1
            C2 = 2 / ((ctx.cos(p2 * ctx.sin(d))) **
                      (alpha + beta) * ctx.cos(d))
            h = 2 * pi * d / (ctx.log(1 + 2 * C2 / epsabs))
            n = (1 / h) * ctx.log(2 / (pi * mu) *
                ctx.log(2 * ctx.exp(p2 * nu) / epsabs))
            if n < nmin:
                nmin = n
                hmin = h
                C1Final = C1
                epsabsFinal = epsabs
        if verbose:
            print("Final epsabs: ", epsabsFinal)
        if verbose:
            print("Final C1: ", C1Final)
        #        Determine NN and MM if alpha <> beta
        if verbose:
            print("hmin:, nmin:", hmin, nmin)
        MM = int(ctx.ceil(nmin))
        NN = MM
        if verbose:
            print("n0:", NN)
        if (mu == alpha):
            NN = NN - int(ctx.floor(ctx.log(beta / alpha) / hmin))
        else:
            MM = MM - int(ctx.floor(ctx.log(alpha / beta) / hmin))
        if verbose:
            print("NN:", NN)
        if verbose:
            print("MM:", MM)

        # Perform actual integration
        sum1 = ctx.t(0)
        #c = p2 * ((b-a)/2) ** (alpha+beta-1)
        b1 = (b - a) / 2
        b2 = (b + a) / 2
        c = p2 * (b1) ** ab1
        for kk in range(-MM, NN):
            u = hmin * kk
            eu1 = ctx.exp(u)
            eu2 = 1 / eu1
            su = (eu1 - eu2) * 0.5
            cu = (eu1 + eu2) * 0.5
            x1 = (p2 * su)
            e1 = ctx.exp(x1)
            e2 = 1 / e1
            e3 = 1 / (e1 + e2)
            f = (e1 - e2) * e3
            fp1 = 2 * e1 * e3
            fm1 = 2 * e2 * e3
            #PHI2 = c * ctx.cosh(u) * (ctx.abs(1+f))**alpha
            #* (ctx.abs(1-f))**beta
            if alpha != 1:
                fp1 = fp1 ** alpha
            if beta != 1:
                fm1 = fm1 ** beta
            PHI2 = c * cu * fp1 * fm1
            t = f * b1 + b2
            sum1 = sum1 + func(t) * PHI2
        res = hmin * sum1
        if verbose:
            print("ED+ET:", C1Final * epsabsFinal)
        return res

    def GetAcbK(self, ctx, func, a, b, radX, radY):
        ba2 = (b - a) / 2
        x_re_mid = (b + a) / 2
        x_re_rad = ba2 * radX
        x_im_mid = 0
        x_im_rad = ba2 * radY
        x_re = ctx.union(x_re_mid - x_re_rad, x_re_mid + x_re_rad)
        x_im = ctx.union(x_im_mid - x_im_rad, x_im_mid + x_im_rad)
        x = ctx.t(x_re, x_im)
        z = func(x)
        av = ctx.fabs(z)
    #    print("Infimum: {0}", ctx.infimum(av))
    #    print("Supremum: {0}", ctx.supremum(av))
        return ctx.supremum(av)

    def GetRectAndK(self, d1):
        switcher = {
            1: ["165.2", "254.3", "1.5"],
            2: ["28.375", "43.75", "1.4"],
            3: ["11.3", "18.46", "1.3"],
            4: ["6.06", "9.34", "1.2"],
            5: ["3.8", "5.795", "1.1"],
            6: ["2.633", "3.933", "1.0"],
            7: ["1.968", "2.826", "0.9"],
            8: ["1.566", "2.103", "0.8"],
            9: ["1.312", "1.5994", "0.7"],
            10: ["1.1552", "1.2276", "0.6"],
            11: ["1.065", "0.937", "0.5"],
            12: ["1.0197", "0.702", "0.4"],
            13: ["1.0032", "0.5008", "0.3"],
            14: ["1.001", "0.41", "0.25"],
            15: ["1.001", "0.3228", "0.2"],
            16: ["1.001", "0.199", "0.125"],
            17: ["1.001", "0.1584", "0.1"],
            18: ["1.001", "0.1423", "0.09"],
            19: ["1.001", "0.1263", "0.08"],
            20: ["1.001", "0.11037", "0.07"],
            21: ["1.001", "0.09456", "0.06"],
            22: ["1.001", "0.0787", "0.05"],
            23: ["1.001", "0.06296", "0.04"],
            24: ["1.001", "0.0472", "0.03"],
            25: ["1.001", "0.03145", "0.02"],
            26: ["1.0", "0.01572", "0.01"]
        }
        if (d1 < 1) or (d1 > 26):
            raise("GetRectAndK index needs to be >0 and <27")
        res = (switcher.get(d1, "Invalid argument"))
        return res[0], res[1], res[2]

    # Noncentral chi^2-distribution, cdf (Chou1985)

    def chi2nc_cdf(self, ctx, x, n, lambda1):
        x = ctx.convert(x)
        n = ctx.convert(n)
        lambda1 = ctx.convert(lambda1)
        res = 1
        res = ctx.quad(lambda y: self.chi2nc_cdf_(
            ctx, x, n, lambda1, y), [0, x])
        #plot(lambda y: self.chi2nc_cdf_(x, n, lambda1, y), [0, x])
        return res

    def Chi2Const(self, ctx, n):
        t1 = 2**(0.5*(1-n)) * ctx.sqrt(2*ctx.pi)
        t2 = ctx.gamma(0.5*(n-1))
        return t1/t2

    def chi2nc_cdf_(self, ctx, x, n, lambda1, y):
        x = ctx.convert(x)
        n = ctx.convert(n)
        l1 = ctx.sqrt(lambda1)
        y = ctx.convert(y)
        xy = ctx.sqrt(x-y)
        t1 = ctx.ndis(xy-l1)
        t2 = ctx.ndis(-xy-l1)
        t3 = ctx.ndens(ctx.sqrt(y))
        t4 = t3 * (t1 - t2)
        t5 = y ** ((n-3)/2)
        t6 = t4 * t5
        res = t6 * self.Chi2Const(ctx, n)
        return res
