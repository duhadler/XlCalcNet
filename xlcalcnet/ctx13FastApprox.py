# -*- coding: utf-8 -*-
"""
Created on Fri Apr  3 20:13:25 2015

@author: DH
"""

# 11 Fast approximations without error estimates


class ctxApprox(object):

    def ndisx(self, ctx, LeftTailTarget, RightTailTarget):
        temp = 0
        #print(LeftTailTarget, RightTailTarget)
        if LeftTailTarget < RightTailTarget:
            temp = self.ndisx1(ctx, LeftTailTarget, RightTailTarget)
        else:
            temp = self.ndisx1(ctx, RightTailTarget, LeftTailTarget)
        if LeftTailTarget > RightTailTarget:
            temp = -temp
        return temp

    def ndisx1(self, ctx, LeftTailTarget, RightTailTarget):
        split1 = 0.425
        split2 = 5.0
        const1 = 0.180625
        const2 = 1.6
        a0 = 3.38713287279637
        A1 = 133.141667891784
        A2 = 1971.59095030655
        a3 = 13731.6937655095
        a4 = 45921.9539315499
        A5 = 67265.7709270087
        a6 = 33430.5755835881
        A7 = 2509.08092873012
        b1 = 42.3133307016009
        b2 = 687.187007492058
        B3 = 5394.19602142475
        b4 = 21213.7943015866
        B5 = 39307.8958000927
        B6 = 28729.0857357219
        B7 = 5226.49527885285
        C0 = 1.42343711074968
        C1 = 4.63033784615655
        c2 = 5.76949722146069
        c3 = 3.6478483247632
        c4 = 1.27045825245237
        c5 = 0.241780725177451
        c6 = 0.0227238449892692
        C7 = 0.000774545014278341
        d1 = 2.05319162663776
        d2 = 1.6763848301838
        D3 = 0.6897673349851
        D4 = 0.14810397642748
        D5 = 0.0151986665636165
        D6 = 0.000547593808499535
        D7 = 1.05075007164442E-09
        E0 = 6.6579046435011
        e1 = 5.46378491116411
        e2 = 1.78482653991729
        E3 = 0.296560571828505
        E4 = 0.0265321895265761
        E5 = 0.00124266094738808
        E6 = 2.71155556874349E-05
        E7 = 2.01033439929229E-07
        f1 = 0.599832206555888
        f2 = 0.136929880922736
        f3 = 0.0148753612908506
        f4 = 0.000786869131145613
        f5 = 1.84631831751005E-05
        f6 = 1.42151175831645E-07
        f7 = 2.04426310338994E-15
        ppnd16 = 0
        r = 0
        p = 0
        Q = 0
        p = LeftTailTarget
        Q = LeftTailTarget - 0.5
        if (ctx.fabs(Q) <= split1):
            r = const1 - Q * Q
            ppnd16 = Q * (((((((A7 * r + a6) * r + A5) * r + a4) * r + a3) * r + A2) * r + A1) *
                          r + a0) / (((((((B7 * r + B6) * r + B5) * r + b4) * r + B3) * r + b2) * r + b1) * r + 1)
        else:
            if (Q < 0):
                r = p
            else:
                r = 1 - p
            if r <= 0:
                # {     ifault=1}
                ppnd16 = 0
            r = ctx.sqrt(-ctx.ln(r))
            if (r <= split2):
                r = r - const2
                ppnd16 = (((((((C7 * r + c6) * r + c5) * r + c4) * r + c3) * r + c2) * r + C1) * r + C0) / \
                    (((((((D7 * r + D6) * r + D5) * r + D4) * r + D3) * r + d2) * r + d1) * r + 1)
            else:
                r = r - split2
                ppnd16 = (((((((E7 * r + E6) * r + E5) * r + E4) * r + E3) * r + e2) * r + e1) * r + E0) / \
                    (((((((f7 * r + f6) * r + f5) * r + f4) * r + f3) * r + f2) * r + f1) * r + 1)
            if Q < 0:
                ppnd16 = -ppnd16
        return ppnd16

    def DemoNdisx(self, ctx):
        LeftTailTarget = ctx.convert("0.05")
        RightTailTarget = 1-LeftTailTarget
        res1 = self.ndisx(LeftTailTarget, RightTailTarget)
        print("res1: ", res1)
        res2 = self.ndisx_erf(LeftTailTarget, RightTailTarget)
        print("res2: ", res2)
        print()
        LeftTailTarget = ctx.convert("0.95")
        RightTailTarget = 1-LeftTailTarget
        res1 = self.ndisx(LeftTailTarget, RightTailTarget)
        print("res1:  ", res1)
        res2 = self.ndisx_erf(LeftTailTarget, RightTailTarget)
        print("res2:  ", res2)


# %% 11.1 Approximations based on the normal distribution


# 11.1.1   Non-central chi-squared distribution: cdf and sf (Penev)

    def cdisn_penev(self, ctx, x, n, l):
        m2 = l / n
        if m2 == 0:
            s = x / n
        else:
            s = (-1 + ctx.sqrt(1 + (4 * x * m2) / n)) / (2 * m2)
        if s == 1:
            s = 1 + 0.0000001 / n
        if s > 1:
            sg = 1
        else:
            sg = -1
        if s <= 0:
            si = 1
            y = 1 - s
        else:
            y = 1 - 1 / s
            si = -1
        if y == 0:
            hs = 0.0
        else:
            hs = si * (1 / (y * y) * ((1 - y) *
                       ctx.log(1 - y) + y - 0.5 * y * y))
        z = n * (s - 1) ** 2
        z = z * (1 / (2 * s) + m2 - (1 / s) * hs)
        z = z - ctx.log(1 / s - (2 / s) * hs / (1 + 2 * m2 * s))
        z = z + (2 * (1 + 3 * m2) ** 2) / (9 * n * (1 + 2 * m2) ** 3)
        z = sg * ctx.sqrt(ctx.fabs(z))
        LeftTail = ctx.ndis(z)
        RightTail = ctx.ndis(-z)
        return LeftTail, RightTail


# 11.1.2 (Non-central) chi-squared distribution: qtf and isf (Canal)

    def chi2_canal_qtf(self, ctx, LeftTail, RightTail, n):
        UseLambert = False
        if UseLambert:
            a = 1 / (0.5 * (n + 2) - 1)
            k = self.LnGamma(ctx, 0.5 * (n + 2))
            d = a * (ctx.ln(LeftTail) + k)
            t = -a * ctx.exp(LeftTail + d)
            if ctx.fabs(t) > 0.1:
                UseLambert = False
        if UseLambert:
            #print("Use Lambert")
            result = -(((((125 * t - 64) * t + 36) * t - 24)
                       * t + 24) * t) / (12 * a)
        else:
            #print("Use Canal")
            z = self.ndisx(ctx, LeftTail, RightTail)
            m = 1 / n
            m2 = m * m
            m3 = m2 * m
            mean = (14580 - 1944 * m - 189 * m2 + 200 * m3) / 17496
            stdev = ctx.sqrt(ctx.fabs(648 * m + 72 * m2 - 37 * m3)) / 108
            g = ctx.sqrt(0.5 * m3) / 162
            z = z - g + (z * g) * (z - (2 * z * z - 5) * g)
            L = 6 * (z * stdev + mean)
            h = ctx.cbrt(2 * (L + ctx.sqrt(13 + L * (L - 5))) - 5)
            U = 0.5 + 0.5 * h - 1.5 / h
            U = U * U * U
            result = n * U * U
        return ctx.fabs(result)


# 11.1.3 Gamma distribution: qtf and isf (Canal)

    def gamma_canal_qtf(self, ctx, LeftTail, RightTail, a):
        x = 0.5 * self.chi2_canal_qtf(ctx, LeftTail, RightTail, 2*a)
        return x


# 11.1.4 F distribution: qtf and isf (Davis)

    def fisher_f_davis_qtf(self, ctx, l, r, m, n):
        if m <= n:
            return self.fdisx_approx_1(ctx, l, r, m, n)
        else:
            return 1 / self.fdisx_approx_1(ctx, r, l, n, m)

    def fdisx_approx_2(self, ctx, l, r, m, n):
        q = n - 1 + m / 2
        d = (m * m - 4) / (24 * q * q)
        z = self.chi2_canal_qtf(ctx, l, r, m)
        z = z * (1 + d) + z * z * (d / (m + 2))
        h = -z / q
        u = ctx.exp(h)
        v = -ctx.expm1(h)
        return (v / u) * (n / m)

    def fdisx_approx_1(self, ctx, l, r, m, n):
        u = self.ndisx(ctx, l, r)
        if u < 0:
            b = 0.8
        else:
            b = 0.4
        if ((m / n) < (1 - b * u / 4.7)) and (u <= n - 1):
            return self.fdisx_approx_2(ctx, l, r, m, n)
        else:
            return 1 / self.fdisx_approx_2(ctx, r, l, n, m)


# 11.1.5 Beta distribution: qtf and isf (Davis)

    def beta_davis_qtf(self, ctx, LeftTail, RightTail, a, b):
        w = ctx.fabs(self.fisher_f_davis_qtf(
            ctx, LeftTail, RightTail, 2 * a, 2 * b))
        x = a * w / (a * w + b)
        y = b / (a * w + b)
        return x, y


# 11.1.6 Pearson’s rho distribution: pdf (Winterbottom)

    def pearson_rho_wb_pdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 11.1.7  Pearson’s rho distribution: cdf and sf (Winterbottom, DH version)

    def pearson_rho_wb_cdf(self, ctx, N, r, rho):
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

    def zTransformInverse(self, ctx, y):
        y = ctx.exp(2 * y)
        return (y - 1) / (y + 1)

    def zTransform(self, ctx, r):
        return 0.5 * ctx.log((1 + r) / (1 - r))


# 11.1.8  Pearson’s rho distribution: qtf and isf (Winterbottom)

    def pearson_rho_wb_qtf(self, ctx, LeftTail, RightTail, n, rho):
        X = self.ndisx(ctx, LeftTail, RightTail)
        z = self.zTransform(ctx, rho)
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
        rdisx = self.zTransformInverse(ctx, y)
        #print("rdisx: {0}", rdisx)
        return rdisx


# 11.1.9 Pearson’s rho distribution: confidence limit for 𝜌 (Winterbottom)

    def pearson_rho_wb_cl(self, ctx, LeftTail, RightTail, N, r):
        X = -self.ndisx(ctx, LeftTail, RightTail)
        z = self.zTransform(r)
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
        rdis_nc = self.zTransformInverse(y)
        return rdis_nc

    def DemoRhoExplicit(self, ctx):
        # ' Smallest N: N = 3
        n = 166
        r = 0.9
        rho = 0.67
        LeftTail = 0.95
        RightTail = 1 - LeftTail

        rho1 = self.Rhodis_NC(LeftTail, RightTail, n, r)
        print("rho: {0}", rho1)
        result1a = self.Rhodis_DH(n, r, rho1)
        print("result1a:  ", result1a)
        result1b = self.RhoExplicit_Arb(n, r, rho1)
        print("result1b: ", result1b)

        print("")
        r1 = self.Rhodisx_W(LeftTail, RightTail, n, rho)
        print("r: {0}", r1)
        result2a = self.Rhodis_DH(n, r1, rho)
        print("result2a:  ", result2a)
        result2b = self.RhoExplicit_Arb(n, r1, rho)
        print("result2b: ", result2b)

    def TDistDoublyNC_Broda_Combined(self, ctx, n, x, mu, theta):
        n = ctx.convert(n)
        x = ctx.convert(x)
        mu = ctx.convert(mu)
        theta = ctx.convert(theta)
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
                #print("x:", x, "mu:", mu, "t1:", t1, "s:", s)
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


# 11.1.10 Singly noncentral t: pdf (Broda)

    def student_t_nc_broda_pdf(self, ctx, x, n, delta):
        L, R, d = self.TDistDoublyNC_Broda_Combined(ctx, n, x, delta, 0)
        return d


# 11.1.11 Singly noncentral t: cdf, sf (Broda)

    def student_t_nc_broda_cdf(self, ctx, x, n, delta):
        if (x==0): return ctx.ndis(-delta), ctx.ndis(+delta)
        z = ctx.fabs((x-delta)/x)
        if z < ctx.t(0.001):
            L1, R1, d1 = self.TDistDoublyNC_Broda_Combined(ctx, n, x+0.01, delta, 0)
            L2, R2, d2 = self.TDistDoublyNC_Broda_Combined(ctx, n, x-0.01, delta, 0)
            L = (L1 + L2) / 2
            R = (R1 + R2) / 2
            return L, R
        else:
            L, R, d = self.TDistDoublyNC_Broda_Combined(ctx, n, x, delta, 0)
            return L, R


    def DemoSinglyTdisn(self, ctx):
        n = 114
        x = 10
        mu = 7
        theta = 0
        LeftTail1, Righttail1 = self.TDistDoublyNC_Broda_Combined(
            n, x, mu, theta)
        print("L: , R: ", LeftTail1, Righttail1)


# 11.1.12 Singly noncentral t: qtf, isf (Harley)

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


# 7.1.13 Singly noncentral t: confidence limit for 𝛿 (Akahira)

    def student_t_nc_akahira_cl(self, ctx, IsGLM, Df2, t, beta):
        if IsGLM:
            # 'Algorithm by Akahira (1995)
            # Dim k As Double, bn As Double, a As Double, u As Double, b As Double, c As Double
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
    # End Function


# 11.1.14 Doubly noncentral t: cdf, sf (Broda)


    def student_t_nc2_broda_pdf(self, ctx, x, n, delta, theta):
        L, R, d = self.TDistDoublyNC_Broda_Combined(n, x, delta, theta)
        return d

    def student_t_nc2_broda_cdf(self, ctx, x, n, delta, theta):
        L, R, d = self.TDistDoublyNC_Broda_Combined(ctx, n, x, delta, theta)
        return L, R


# 11.1.15 Doubly noncentral t: qtf, isf (Broda)

    def student_t_nc2_broda_qtf(self, ctx, alpha, n, delta, theta):
        raise Exception("NOT IMPLEMENTED")

    def DemoDoublyTdisn(self, ctx):
        n = 114
        x = 10
        mu = 7
        theta = 0
        LeftTail1, Righttail1 = self.TDistDoublyNC_Broda_Combined(
            n, x, mu, theta)
        print("L: , R: ", LeftTail1, Righttail1)


# 11.1.16 Spearman’s rho, first 8 cumulants

    def spearman_mu8(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# 11.1.17 Mann-Whitney U distribution: general alternatives specified by rank order probabilities

    def mannwhitney_nc_mu4(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# 11.1.18 First 4 moments of Kendalls 𝜏 in the general case

    def kendall_tau_nc_mu4(self, ctx, x, n, lambda1):
        raise Exception("NOT IMPLEMENTED")


# %% 11.2 Approximations based on the chi-squared distribution


# 11.2.1 Non-Central chi-squared : cdf, sf (Patnaik)

    def chi2_nc_mu2_cdf(self, ctx, x, n, lambda1):
        n1 = (n + lambda1) ** 2 / (n + 2 * lambda1)
        x1 = x*(n + lambda1) / (n + 2 * lambda1)
        res = ctx.cdis(x1, n1)
        return res


# 11.2.2 Non-Central chi-squared: qtf, isf (Patnaik)

    def chi2_nc_mu2_qtf(self, ctx, n, lambda1, LeftTail, RightTail):
        n1 = (n + lambda1) ** 2 / (n + 2 * lambda1)
        b = lambda1 / (n + lambda1)
        x = ctx.cdisx(LeftTail, RightTail, n1)
        return (1 + b) * x


# 11.2.3 Non-Central chi-squared: confidence limit for 𝜆 (Winterbottom)

    def chi2_nc_wb_cl(self, ctx, F, alpha, Beta):
        # def GetL(self, ctx, F, Chi2, lambda1, alpha, Beta):
        X = ctx.ndisx(1 - Beta, Beta)
        Chi2 = ctx.cdisx(1 - alpha, alpha, F)
        t = (Chi2 - F) / F
        n = F
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
        lambda1 = n * t + ctx.sqrt(2 * n * y) * X + 2 * ((3 * t + 2) * x2 + (3 * t + 1)) / (3 * y) \
            - ctx.sqrt(2) * ((6 * t + 5) * x3 - (36 * t2 + 42 * t + 17) * X) / (18 * Y_52) \
            + ((324 * t2 + 594 * t + 276) * x4 - (1080 * t3 + 2484 * t2 + 2394 * t + 976) * x2
               + (1080 * t3 + 1512 * t2 + 612 * t + 148)) / (405 * Y_4) \
            - ctx.sqrt(2) * ((10368 * t3 + 30780 * t2 + 30564 * t + 10143) * x5
                             - (25920 * t4 + 98928 * t3 + 163080 *
                                t2 + 137544 * t + 47188) * x3
                             + (45360 * t4 + 106704 * t3 + 80460 * t2 + 31092 * t + 13489) * X) / (9720 * Y_112)
        if lambda1 < 0:
            lambda1 = 0.00001
        return lambda1, Chi2
    # End Sub


# 11.2.4 Roy’s largest root 𝜃: pdf (Chiani)

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


# 11.2.5 Roy’s largest root: cdf and sf (Chiani)

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


# 11.2.6 Roy’s largest root: qtf and isf (Chiani)

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


# %% 11.3 Approximations based on the central F or beta distribution

# 11.3.1 Dunn-Šidák percentage points

    def dunn_sidak_qtf(self, ctx, LeftTail, RightTail, f1):
        raise Exception("NOT IMPLEMENTED")


# 11.3.2 Singly non-central Fisher F distribution: cdf, sf (Patnaik)

    def fisher_f_nc_mu2_cdf(self, ctx, X, f1, f2, L=0, IsGLM=True):
        #    '2 moment approximation
        if IsGLM:
            A1 = f1 + L
            A2 = A1 + L
        else:
            Rho2 = L / (L + f2)
            g2 = 1 / (1 - Rho2)
            n = f2 + f1
            A1 = n * (g2 - 1) + f1
            A2 = n * (g2 * g2 - 1) + f1
        x1 = f1 * X / A1
        m1 = A1 * A1 / A2
        print("x1:", x1, "f1:", f1, "m1:", m1)
        res = ctx.fisher_f_cdf(x1, m1, f2)
        return res


# 11.3.3 Singly non-central F distribution: qtf, isf (Patnaik)


    def fisher_f_nc_mu2_qtf(self, ctx, LeftTail, f1, f2, L=0, IsGLM=True):
        #    '2 moment approximation
        if IsGLM:
            A1 = f1 + L
            A2 = A1 + L
        else:
            Rho2 = L / (L + f2)
            g2 = 1 / (1 - Rho2)
            n = f2 + f1
            A1 = n * (g2 - 1) + f1
            A2 = n * (g2 * g2 - 1) + f1
        m1 = A1 * A1 / A2
        #x1 = self.Fdisx(LeftTail, RightTail, m1, f2)
        x1 = ctx.fisher_f_qtf(LeftTail, m1, f2)
        res = x1 * A1 / f1
        return res


# 11.3.4 Singly non-central F: confidence interval for the noncentrality parameter 𝜆

    def fisher_f_nc_cl_(self, f1, f2,  X, l1, l2, LeftTail, RightTail):
        raise Exception("NOT IMPLEMENTED")


# 11.3.5 Doubly non-central F distribution: cdf, sf (Patnaik)


    def fisher_f_nc2_mu2_cdf(self, ctx, X, f1, f2,  l1, l2):
        # '2 moment approximation
        A1 = f1 + l1
        b1 = A1 + l1
        m1 = A1 * A1 / b1
        A2 = f2 + l2
        b2 = A2 + l2
        m2 = A2 * A2 / b2
        x1 = f1 * A2 * X / (A1 * f2)
        res = ctx.fisher_f_cdf(x1, m1, m2)
        return res


# 11.3.6 Doubly non-central F distribution: qtf, isf (Patnaik)


    def fisher_f_nc2_mu2_qtf(self, ctx, LeftTail, f1, f2, l1, l2):
        # '2 moment approximation
        A1 = f1 + l1
        b1 = A1 + l1
        m1 = A1 * A1 / b1
        A2 = f2 + l2
        b2 = A2 + l2
        m2 = A2 * A2 / b2
        x1 = ctx.fisher_f_qtf(LeftTail, m1, m2)
        res = x1 * A1 * f2 / (f1 * A2)
        return res


#    def fisher_r2_lee_cdf_old(self, ctx, IsGLM, X , f1, f2, L):
#    #    '2 moment approximation
#        if IsGLM :
#            A1 = f1 + L
#            A2 = A1 + L
#        else:
#            Rho2 = L / (L + f2);  g2 = 1 / (1 - Rho2);  n = f2 + f1
#            A1 = n * (g2 - 1) + f1
#            A2 = n * (g2 * g2 - 1) + f1
#        x1 = f1 * X / A1
#        m1 = A1 * A1 / A2
#        print("x1:", x1, "f1:", f1, "m1:", m1)
#        res = self.Fdis(m1, f2, x1)
#        return res


# 11.3.7 Multiple correlation coefficient: cdf, sf (Lee and Gurland)

    def fisher_r2_lee_cdf(self, ctx, r2, p, N, rho2):
        #    '2 moment approximation
        #L = rho2*(N-p) / (1-rho2)
        L = rho2*(N-p) / (1-rho2)
        f2 = N-p
        f1 = p-1
        F = r2/(1-r2) * (N-p)/(p-1)
        X = F
        Rho2 = L / (L + f2)
        g2 = 1 / (1 - Rho2)
        n = f2 + f1
        A1 = n * (g2 - 1) + f1
        A2 = n * (g2 * g2 - 1) + f1
        x1 = f1 * X / A1
        m1 = A1 * A1 / A2
        print("x1:", x1, "f1:", f1, "m1:", m1)
        res = ctx.fisher_f_cdf(x1, m1, f2)
        return res


#    def fisher_r2_lee_qtf_old(self, ctx, IsGLM, LeftTail, RightTail, f1, f2, L):
#    #    '2 moment approximation
#        if IsGLM :
#            A1 = f1 + L
#            A2 = A1 + L
#        else:
#            Rho2 = L / (L + f2);  g2 = 1 / (1 - Rho2);  n = f2 + f1
#            A1 = n * (g2 - 1) + f1
#            A2 = n * (g2 * g2 - 1) + f1
#        m1 = A1 * A1 / A2
#        x1 = self.Fdisx(LeftTail, RightTail, m1, f2)
#        res = x1 * A1 / f1
#        return res


# 11.3.8 Multiple correlation coefficient: qtf, isf (Lee and Gurland)

    def fisher_r2_lee_qtf(self, ctx, LeftTail, p, N, rho2):
        #    '2 moment approximation
        L = rho2*(N-p) / (1-rho2)
        f2 = N-p
        f1 = p-1
#        F = r2/(1-r2) * (N-p)/(p-1)
#        X = F
        Rho2 = L / (L + f2)
        g2 = 1 / (1 - Rho2)
        n = f2 + f1
        A1 = n * (g2 - 1) + f1
        A2 = n * (g2 * g2 - 1) + f1
        m1 = A1 * A1 / A2
        x1 = ctx.fisher_f_qtf(LeftTail, m1, f2)
        F = x1 * A1 / f1
        r2 = F*(p-1) / (F*(p-1) + N-p)
        return r2


# 11.3.9 Fisher 𝑅2,: confidence limit for rho^2
    def fisher_r2_lee_cl(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 11.3.10 Central Wilks’ Lambda: cdf, sf (Rao)
    def wilks_lambda_rao_cdf(self, ctx, l1, p, q, n):
    #def Wilksdis(self, ctx, l1, p, q, n):
#        '{ p: # of variables in 1. set
#        '  q: # of variables in 2. set
#        '  n: # of cases-1 }
        if (n < p) or (l1 < 0): return 0
        if (l1 >= 1): return 1
        pq = p * q
        s = (p * p + q * q - 5)
        if s != 0 : s = (pq * pq - 4) / s
        else: s = 1
        if s < 0 : s = 1
        else: s = ctx.sqrt(s)
        l = ctx.exp(ctx.log(l1) / s)
        m = s * (n - (p + 1 - q) / 2) - (pq - 2) / 2
        F = m * (1 - l) / (pq * l)
#        Fdisn2(pq, m, F, 0, l2, r2)
#        print("l2: {0}, r2: {1}", l2, r2)
        print("F", F, "pq:", pq, "m", m)
        l2 = ctx.fisher_f_cdf(F, pq, m)
        return l2


# 11.3.11 Central Wilks’ Lambda: qtf, isf (Rao)
    def wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, q, n):
    #def Udisx(self, ctx, LeftTail, Righttail, p, q, n):
        #'  p: # of variables in 1. set
        #'  q: # of variables in 2. set
        #'  n: # of cases-1-q }
        if ((n < p) or (LeftTail <= 0) or (Righttail >= 1)):
            return 0
        pq = p * q
        s = (p * p + q * q - 5)
        if s != 0 : s = (pq * pq - 4) / s
        else: s = 1
        if s < 0 : s = 1
        else: s = ctx.sqrt(s)
        m = s * (n - (p + 1 - q) / 2) - (pq - 2) / 2
        #'F = fdisx(LeftTail, Righttail, pq, m)
        #'F = xpr.dist_qf(LeftTail, pq, m, True)
        #F = boost2.dist_fisher_f(LeftTail, pq, m, 6)
        F = ctx.fisher_f_qtf(LeftTail, pq, m)
        l = 1.0 / (1 + pq * F / m)
        res = ctx.exp(s * ctx.log(l))
        return res




# 11.3.10 Central Wilks’ Lambda: cdf, sf (Rao)
    def wilks_lambda_bp_cdf(self, ctx, l, p, f1, f2):
        # ReDim b(p)
        p = int(p)
        b = [0 for row in range(p+1)]
        # ReDim c(p)
        c = [0 for row in range(p+1)]
        for i in range(1, p+1):
            b[i] = (f2 - i + 1) / 2
            c[i] = b[i] + f1 / 2
            print(i, b[i], c[i])
        LeftTail = self.beta_product_mu3_cdf(ctx, l, p, b, c)
        return LeftTail


    def wilks_lambda_bp_pdf(self, ctx, l, p, f1, f2):
        # ReDim b(p)
        p = int(p)
        b = [0 for row in range(p+1)]
        # ReDim c(p)
        c = [0 for row in range(p+1)]
        for i in range(1, p+1):
            b[i] = (f2 - i + 1) / 2
            c[i] = b[i] + f1 / 2
            print(i, b[i], c[i])
        LeftTail = self.beta_product_mu3_pdf(ctx, l, p, b, c)
        return LeftTail




    def bartlett_bp_cdf(self, ctx, l, p, f1, f2):
        # ReDim b(p)
        p = int(p)
        b = [0 for row in range(p+1)]
        # ReDim c(p)
        c = [0 for row in range(p+1)]
        for i in range(1, p+1):
            b[i] = (f2 - i + 1) / 2
            c[i] = b[i] + f1 / 2
            print(i, b[i], c[i])
        LeftTail = self.beta_product_mu3_cdf(ctx, l, p, b, c)
        return LeftTail



# 11.3.11 Central Wilks’ Lambda: qtf, isf (Rao)
    def wilks_lambda_bp_qtf(self, ctx, LeftTail, Righttail, p, f1, f2):
        # ReDim b(p)
        p = int(p)
        b = [0 for row in range(p+1)]
        # ReDim c(p)
        c = [0 for row in range(p+1)]
        for i in range(1, p+1):
            b[i] = (f2 - i + 1) / 2
            c[i] = b[i] + f1 / 2
            print(i, b[i], c[i])
        return self.beta_product_mu3_qtf(ctx, LeftTail, Righttail, p, b, c)




## 11.3.10 Central Wilks’ Lambda: cdf, sf (Rao)
#    def wilks_lambda_rao_cdf(self, ctx, p, f1, f2, l):
#        # ReDim b(p)
#        b = [0 for row in range(p+1)]
#        # ReDim c(p)
#        c = [0 for row in range(p+1)]
#        for i in range(1, p+1):
#            b[i] = (f2 - i + 1) / 2
#            c[i] = b[i] + f1 / 2
#        LeftTail, Righttail = self.beta_product_mu3_cdf(p, b, c, l)
#
#
## 11.3.11 Central Wilks’ Lambda: qtf, isf (Rao)
#    def wilks_lambda_rao_qtf(self, ctx, LeftTail, Righttail, p, f1, f2):
#        # ReDim b(p)
#        b = [0 for row in range(p+1)]
#        # ReDim c(p)
#        c = [0 for row in range(p+1)]
#        for i in range(1, p+1):
#            b[i] = (f2 - i + 1) / 2
#            c[i] = b[i] + f1 / 2
#        return self.beta_product_mu3_qtf(LeftTail, Righttail, p, b, c)



# 11.3.12 Central Hotelling’s 𝑇2: cdf, sf (Pillai and Young)
    # Let m=(n1-p-1)/2 and n=(n2-p-1)/2.}
    def hotelling_t2_mu3_cdf(self, ctx, p, m, n, x):
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
    # End Sub


# 11.3.13 Central Hotelling’s 𝑇2: qtf, isf (Pillai and Young)
    def hotelling_t2_mu3_qtf(self, ctx, p, m, n, LeftTail, Righttail):
        # x=T²/n2 is distributed as Iw(a+1,b-a-1), where w=x/(x+K)
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
    # End Sub


# 11.3.14 Central Pillai’s V : cdf, sf (Ginzberg)
    def pillai_v_mu3_cdf(self, ctx, p, N1, n2, x):
        #        Dim s As Double, n As Double, m As Double, density As Double, mu1 As Double, mu2 As Double, a As Double, b As Double, w As Double
        #        Dim m1 As Double, m2 As Double
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
    # End Sub


# 11.3.15 Central Pillai’s V : qtf, isf (Ginzberg)
    def pillai_v_mu3_qtf(self, ctx, p, n1, n2, LeftTail, Righttail):
        # Dim n As Double, m As Double, k1 As Double, k2 As Double, k3 As Double, r As Double
        m = (n1 - p - 1) / 2
        n = (n2 - p - 1) / 2
        r = m + n + p
        k1 = p * (2 * m + p + 1) / (2 * (r + 1))
        k2 = k1 * (2 * n + p + 1) * (2 * m + 2 * n + p + 2) / \
            (2 * (r + 1) * (r + 2) * (2 * r + 1))
        k3 = 4 * k2 * (n - m) * (m + n + 1) / ((r + 1) * (r + 3) * (2 * r))
        print("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3)

        # Dim k12, k22 As Double
        k12 = k1 * k1
        k22 = k2 * k2
        a = (2 * k1 * (k12 * k2 - k22 + k1 * k3)) / \
            (4 * k1 * k22 - k12 * k3 + k2 * k3)
        b = (2 * k2 * (2 * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3)) / \
            ((k1 * k3 - 2 * k22) * (k12 * k3 - 4 * k1 * k22 - k2 * k3))
        k = (k12 * k3 - 4 * k1 * k22 - k2 * k3) / (k1 * k3 - 2 * k22)

        # Dim wx, wy As Double
        wx, wy = ctx.betadisx(LeftTail, Righttail, a, b)
        V = k * wx
        print("(n + m) * V / n: {0}", (n1 + n2) * V / n1)

        return V


# 11.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)
    def beta_product_mu3_pdf(self, ctx, x, p, b, c):
        # Approximation by Nagarsenker
        print("Hello Density BetaProdDis2Arb")
        v1 = 0
        v2 = 0
        p = int(p)
        for i in range(1, p + 1):
            v1 = v1 + c[i] - b[i]
            v2 = v2 + c[i] ** 2 - b[i] ** 2
        m = (v2 - v1) / (2 * v1)
        k = 0
        for i in range(1, p + 1):
            k = k + self.B3Arb(ctx, b[i] - m) - self.B3Arb(ctx, c[i] - m)
        alpha = (1 - v1) / 2
        s = (-2 * self.B3Arb(ctx, (1 + v1) / 2) / k)
        s = ctx.sqrt(s)
        df2 = s * m + alpha
        x1 = ctx.exp(ctx.log(x) / s)
        #print("x: {0}", x)
        #LeftTail, RightTail, d = ctx.betadis3(v1, df2, 1 - x1, x1)
        d2 = ctx.real_ibeta_derivative(v1, df2, 1 - x1)
        #print("d: ", d)
        #print("d2: ", d2)
        d1 = d2 * x**((1/s)- 1) / s
        #print("d1:", d1)
        return d1



# 11.3.16 Product of independent beta variables: cdf, sf (Nagarsenker)
    def beta_product_mu3_cdf(self, ctx, x, p, b, c):
        # Approximation by Nagarsenker
        print("Hello BetaProdDis2Arb")
        v1 = 0
        v2 = 0
        p = int(p)
        for i in range(1, p + 1):
            v1 = v1 + c[i] - b[i]
            v2 = v2 + c[i] ** 2 - b[i] ** 2
        m = (v2 - v1) / (2 * v1)
        k = 0
        for i in range(1, p + 1):
            k = k + self.B3Arb(ctx, b[i] - m) - self.B3Arb(ctx, c[i] - m)
        alpha = (1 - v1) / 2
        s = (-2 * self.B3Arb(ctx, (1 + v1) / 2) / k)
        s = ctx.sqrt(s)
        df2 = s * m + alpha
        x1 = ctx.exp(ctx.log(x) / s)
        #print("x: {0}", x)
        LeftTail, RightTail, d = ctx.betadis3(v1, df2, 1 - x1, x1)
#        d1 = d * x**((1/s)- 1) / s
#        print("d1:", d1)
        return LeftTail


# 11.3.17 Product of independent beta variables: qtf, isf (Nagarsenker)
    def beta_product_mu3_qtf(self, ctx, LeftTail, RightTail, p, b, c):
        # Approximation by Nagarsenker
        print("Hello BetaProdDisX2Arb")
        v1 = 0
        v2 = 0
        p = int(p)
        for i in range(1, p + 1):
            v1 = v1 + c[i] - b[i]
            v2 = v2 + c[i] ** 2 - b[i] ** 2
        m = (v2 - v1) / (2 * v1)
        k = 0
        for i in range(1, p + 1):
            k = k + self.B3Arb(ctx, b[i] - m) - self.B3Arb(ctx, c[i] - m)
        alpha = (1 - v1) / 2
        s = (-2 * self.B3Arb(ctx, (1 + v1) / 2) / k)
        s = ctx.sqrt(s)
        df2 = s * m + alpha
        X, Y = ctx.betadisx(LeftTail, RightTail, v1, df2)
        print("v1: ", v1, "df2: ", df2)
        print("X: ", X, "Y: ", Y)
        X2 = ctx.exp(s * ctx.log(Y))
        return X2

    def B3Arb(self, ctx, h):
        return h * h * h - 1.5 * h * h + 0.5 * h


# %% 11.4 Approximations based on the noncentral chi-squared distribution


# 11.4.1 Non-central Wilks’ Lambda (GLM): cdf and sf (Fujikoshi)
    def wilks_lambda_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.UdisN("GLM", p, q, n - q, x, omega)
        return Left1


# 11.4.2 Non-central Wilks’ Lambda (independence): cdf and sf (Lee)
    def wilks_lambda_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.UdisN("CORR", p, q, n - q, x, omega)
        return Left1


# 11.4.3 Non-central Pillai’s V (GLM): cdf and sf Fujikoshi
    def pillai_v_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.VdisN("GLM", p, q, n - q, x, omega)
        return Left1


# 11.4.4 Non-central Pillai’s V (independence): cdf and sf (Lee)
    def pillai_v_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.VdisN("CORR", p, q, n - q, x, omega)
        return Left1


# 11.4.5 Non-central Hotelling 𝑇2 (GLM): cdf and sf (Fujikoshi)
    def hotelling_t2_glm_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.T2disN("GLM", p, q, n - q, x, omega)
        return Left1


# 11.4.6 Non-central Hotelling 𝑇2 (independence): cdf and sf (Lee)
    def hotelling_t2_ind_chi2_cdf(self, ctx, p, q, n, x, omega):
        Left1 = self.T2disN("CORR", p, q, n - q, x, omega)
        return Left1

    # ' Wilk's U
    # ' Noncentral distribution function
    def UdisN(self, ctx, Model, p, q, n, x, omega):
        IsRho = False
        LeftTail, Righttail = self.UT2VGRdisN(
            1, IsRho, Model, p, q, n, x, omega)
        return LeftTail

    # ' Hotelling's T²
    # ' Noncentral distribution function
    def T2disN(self, ctx, Model, p, q, n, x, omega):
        IsRho = False
        LeftTail, Righttail = self.UT2VGRdisN(
            2, IsRho, Model, p, q, n, x, omega)
        return LeftTail

    # ' Pillai 's V
    # ' Noncentral distribution function
    def VdisN(self, ctx, Model, p, q, n, x, omega):
        IsRho = False
        LeftTail, Righttail = self.UT2VGRdisN(
            3, IsRho, Model, p, q, n, x, omega)
        return LeftTail

    def UT2VGRdisN(self, ctx, dis, IsRho, Model, p, q, n, x, omega):
        a = [0, 0, 0, 0, 0]
        b = [0, 0, 0, 0, 0, 0, 0, 0, 0]
        c = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        left = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        show = False
        if dis == 1:
            l = (q - p - 1) / 2
            m = n + l
            x = -m * ctx.log(x)
        else:
            if (dis == 2):
                if Model == "GLM":
                    m = n - p - 1
                else:
                    m = n
                # End If
            else:
                m = n + q
            # End If
            x = x * m
        # End If

        o1 = 0
        o2 = 0
        o3 = 0
        o4 = 0

        for i in range(1, p+1):
            # For i = 1 To p
            # 'omeg = omega(i)
            omeg = omega(i - 1)
            # '{if the nc parameter is given as canonical correlation}
            if IsRho:
                omeg = n * omeg / (1 - omeg)
            if (not (Model == "GLM") and (dis == 3)):
                omeg = n * omeg / (n - q + omeg)
            o1 = o1 + omeg
            o2 = o2 + (omeg) ** 2
            o3 = o3 + omeg * (omeg) ** 2
            o4 = o4 + (omeg) ** 4
            print("omeg: {0}", omeg)
        # Next i

        print("o1: {0}", o1)
        o1 = o1 / 2
        o2 = o2 / 4
        o3 = o3 / 8
        o4 = o4 / 16
        o12 = (o1) ** 2
        o13 = o1 * o12
        o22 = (o2) ** 2
        o23 = o2 * o22

        F = p * q
        f2 = F * F
        p2 = p * p
        q2 = q * q
        G = p + q + 1
        g2 = G * G
        g3 = g2 * G
        s = (p + q + 1) / 4
        s2 = s * s
        s3 = s * s2
        r = F * (p2 + q2 - 5) / 48

        # Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
        L0 = (3 * F - 8) * g2 + 4 * G + 4 * (F + 2)
        l1 = -12 * F * g2
        l2 = 6 * (3 * F + 8) * g2
        l3 = -4 * ((3 * F + 16) * g2 + 4 * G + 4 * (F + 2))
        l4 = 3 * ((F + 8) * g2 + 4 * G + 4 * (F + 2))

        if (dis == 1):
            #        Select Case dis
            #            Case 1
            if show:
                print("Udis")
            # Fujikoshi (1973), Ann. Inst. Math. Statist., 25, p. 423
            if Model == "GLM":
                if show: print("GLM")
                a[0] = 0
                a[1] = 2 * s * o1
                a[2] = -(2 * s * o1 - o2)
                a[3] = -o2
                a[4] = 0

                b[0] = -r
                b[1] = 0
                b[2] = r - 4 * s2 * o1 + 2 * s2 * o12 + 2 * s * o2
                b[3] = 4 * s2 * o1 - (1 + 4 * s2) * o12 - \
                    (1 + 8 * s) * o2 + 2 * s * o1 * o2 + (4 / 3) * o3
                b[4] = (1 + 2 * s2) * o12 + (1 + 6 * s) * \
                    o2 - 4 * s * o1 * o2 - 4 * o3 + o22 / 2
                b[5] = 2 * s * o1 * o2 + (8 / 3) * o3 - o22
                b[6] = o22 / 2
                b[7] = 0
                b[8] = 0

                c[0] = 0
                c[1] = 2 * r * s * o1
                c[2] = -r * (2 * s * o1 - o2)
                c[3] = -2 * s * (r + 4 * s2) * o1 + 2 * s * (1 + 4 * s2) * o12 +  \
                    (-r + 2 * s + 12 * s2) * o2 - (4 / 3) * s3 * o13 - 4 * s2 * o1 * o2 -  \
                    (8 / 3) * s * o3
                c[4] = 2 * s * (r + 4 * s2) * o1 - (1 + 10 * s + 16 * s3) * o12 -  \
                    (3 + r + 10 * s + 36 * s2) * o2 + 2 * s * (1 + 2 * s2) * o13 +  \
                    2 * ( 2 + s + 12 * s2) * o1 * o2 + 4 * (1 + 6 * s) * o3 -  \
                    2 * s2 * o12 * o2 - 2 * s * o22 - (8 / 3) * s * o1 * o3 - 2 * o4
                c[5] = (1 + 8 * s + 8 * s3) * o12 + (3 + r + 8 * s + 24 * s2) * o2 -  \
                    4 * s * (1 + s2) * o13 - 4 * (3 + s + 9 * s2) * o1 * o2 -  \
                    12 * ( 1 + 4 * s) * o3 + (1 + 6 * s2) * o12 * o2 + (1 + 10 * s) * o22 +  \
                    (32 / 3) * s * o1 * o3 + 12 * o4 - (4 / 3) * o2 * o3 - s * o1 * o22
                c[6] = s * (2 + (4 / 3) * s2) * o13 + 2 * (4 + s + 8 * s2) * o1 * o2 +  \
                    8 * (1 + (10 / 3) * s) * o3 - 2 * (1 + 3 * s2) * \
                    o12 * o2 - 2 * (1 + 7 * s) * o22 - (40 / 3) * s * o1 * o3 - \
                    20 * o4 + (16 / 3) * o2 * o3 + 3 * \
                    s * o1 * o22 - (1 / 6) * o23
                c[7] = (1 + 2 * s2) * o12 * o2 + (1 + 6 * s) * o22 + (16 / 3) * s * o1 * \
                    o3 + 10 * o4 - (20 / 3) * o2 * o3 - 3 * \
                    s * o1 * o22 + (1 / 2) * o23
                c[8] = (8 / 3) * o2 * o3 + s * o1 * o22 - (1 / 2) * o23
                c[9] = (1 / 6) * o23

            else:
                if show:
                    print("CORR")
                a[0] = -q * o1 + o2
                a[1] = (2 * s + q) * o1 - 2 * o2
                a[2] = -2 * s * o1 + 2 * o2
                a[3] = -o2
                a[4] = 0

                b[0] = -r - q * l * o1 + (q + l) * o2 + 0.5 * q * \
                    q * o12 - 4 * o3 / 3 - q * o1 * o2 + 0.5 * o22
                b[1] = q2 * o1 - 4 * q * o2 - q * \
                    (q + 2 * s) * o12 + 4 * o3 + \
                    (3 * q + 2 * s) * o1 * o2 - 2 * o22
                b[2] = r - 2 * s * (q + 2 * s) * o1 + (2 * p + 6 * q + 3) * o2 +  \
                    (0.5 * l * l + 6 * q * s + 1) * o12 - 8 * o3 - (4 * q + 6 * s) * o1 * o2 + 4 * o22
                b[3] = 4 * s2 * o1 - (3 * p + 5 * q + 5) * o2 - (4 * s2 + 2 * q * s + 2) * \
                    o12 + 32 * o3 / 3 + (3 * q + 8 * s) * o1 * o2 - 5 * o22
                b[4] = (6 * s + 1) * o2 + (2 * s2 + 1) * o12 - \
                    8 * o3 - (q + 6 * s) * o1 * o2 + 4 * o22
                b[5] = 8 * o3 / 3 + 2 * s * o1 * o2 - 2 * o22
                b[6] = 0.5 * o22
                b[7] = 0
                b[8] = 0

                for i in range(0, 9+1):
                    # For i = 0 To 9
                    c[i] = 0
                # Next i
            # End If

        if (dis == 2):
            #                If show Then Console.WriteLine("T2dis")
            # ' Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
            if Model == "GLM":
                if show:
                    print("GLM")
                a[0] = F * G
                a[1] = -2 * G * (F - 2 * o1)
                a[2] = F * G - 8 * G * o1 + 4 * o2
                a[3] = 4 * (G * o1 - 2 * o2)
                a[4] = 4 * o2

                b[0] = F * L0
                b[1] = l1 * (F - 2 * o1)
                b[2] = F * l2 + 2 * (l1 - 2 * l2) * o1 + \
                    48 * g2 * o12 + 24 * (F + 4) * G * o2
                b[3] = F * l3 + 2 * (2 * l2 - 3 * l3) * o1 - 192 * (g2 + 1) * \
                    o12 - 96 * ((F + 8) * G + 2) * o2 + \
                    96 * G * o1 * o2 + 128 * o3
                b[4] = F * l4 + 2 * (3 * l3 - 4 * l4) * o1 + 96 * (3 * g2 + 7) * o12 + 48 * (
                    3 * (F + 12) * G + 14) * o2 - 384 * G * o1 * o2 - 768 * o3 + 48 * o22
                b[5] = 8 * l4 * o1 - 192 * (g2 + 4) * o12 - 96 * (
                    (F + 16) * G + 8) * o2 + 576 * G * o1 * o2 + 1536 * o3 - 192 * o22
                b[6] = 48 * (g2 + 6) * o12 + 24 * ((F + 20) * G + 12) * \
                    o2 - 384 * G * o1 * o2 - 1280 * o3 + 288 * o22
                b[7] = 96 * G * o1 * o2 + 384 * o3 - 192 * o22
                b[8] = 48 * o22

            else:
                if show:
                    print("CORR")
                S1 = o1 * 2
                s2 = o2 * 4
                s3 = o3 * 8
                s12 = S1 * S1
                s22 = s2 * s2
#                    p1 = p + 1
                p3 = p2 * p
                p4 = p3 * p
                q3 = q2 * q
                q4 = q3 * q
#                    h = q * p1
#                    H1 = 2 * q + p1
#                    p2p = p2 + p

                a[0] = q * p * (q - p - 1) - 2 * q * S1 + s2
                a[1] = -2 * q2 * p + 4 * q * S1 - 2 * s2
                a[2] = q * p * (q + p + 1) - 2 * (2 * q + p + 1) * S1 + 2 * s2
                a[3] = 2 * (q + p + 1) * S1 - 2 * s2
                a[4] = s2
                b[0] = q * p * (3 * q * p3 - 2 * (3 * q2 - 3 * q + 4) * p2 +  \
                    3 * (q3 - 2 * q2 + 5 * q - 4) * p - 8 * q2 + 12 * q + 4) - \
                    12 * q2 * p * (q - p - 1) * S1 - 6 * q * (p2 - q * p + p - 4) * \
                    s2 + 12 * q2 * s12 - 16 * s3 - 12 * q * S1 * s2 + 3 * s22
                b[1] = -12 * q3 * p2 * (q - p - 1) - 24 * q2 * (p2 - 2 * q * p + p - 2) * S1 +  \
                    12 * q * ( p2 - 2 * q * p + p - 8) * s2 - 48 * q2 * s12 + 48 * s3 +  \
                    48 * q * S1 * s2 - 12 * s22
                b[2] = -6 * q2 * p4 - 12 * q2 * p3 + 18 * q2 * (q2 + 1) * p2 +  \
                    24 * q2 * (2 * q + 1) * p + 12 * q * (p3 + 2 * p2 - 7 * (q2 + 1) * p -  \
                    16 * q - 8) * S1 - 6 * ( q * p2 - (7 * q2 - q + 8) * p - 40 * q - 12) * s2 + \
                    24 * (q * p + 4 * q2 + q + 1) * s12 - 12 * (p + 8 * q + 1) * S1 * s2 - 96 * s3 + 24 * s22
                b[3] = -(12 * q3 + 16 * q) * p3 - (12 * q4 + 12 * q3 + 96 * q2 + 48 * q) * p2 -  \
                    (64 * q3 + 96 * q2 + 64 * q) * p + 12 * (-q * p3 +  \
                    (4 * q2 - 2 * q + 4) * p2 + (7 * q3 + 4 * q2 + 31 * q + 12)  * p +  \
                    4 * (7 * q2 + 8 * q + 4)) * S1 - 48 * ((q2 + 3) * p + 9 * q + 5) * s2 -  \
                    24 * (3 * q * p + 5 * q2 + 3 * q + 4) * s12 +  \
                    176 * s3 + 12 * (3 * p + 11 * q + 3) * S1 * s2 - 36 * s22
                b[4] = 3 * q2 * p4 + (6 * q3 + 6 * q2 + 24 * q) * p3 + (3 * q4 +  \
                    6 * q3 + 63 * q2 + 60 * q) * p2 + (24 * q3 + 60 * q2 + 60 * q) * p -  \
                    12 * (q * p3 + (5 * q2 + 2 * q + 12) * p2 + (4 * q3 + 5 * q2 +  \
                    45 * q + 32) * p + 4 * ( 6 * q2 + 11 * q + 9)) * S1 +  \
                    6 * (q * p2 + (7 * q2 + q + 44) * p + 88 * q + 76) * s2 +  \
                    12 * (p2 + 2 * (4 * q + 1) * p + 8 * q2 + 8 * q + 17) * s12 -  \
                    12 * (4 * p + 11 * q + 4) * S1 * s2 - 240 * s3 + 42 * s22
                b[5] = (12 * q * p3 + 24 * (q2 + q + 4) * p2 + 12 * (q3 + 2 * q2 +  \
                    21 * q + 20) * p + 48 * (2 * q2 + 5 * q + 5)) * S1 - 12 * (q * p2 +  \
                    (2 * q2 + q + 24) * p + 32 * q + 40) * s2 - 24 * (p2 + (3 * q + 2) *  \
                    p + 2 * q2 + 3 * q + 9) * s12 + 240 * s3 + 48 * (p + 2 * q + 1) * S1 * s2 - 36 * s22
                b[6] = (6 * q * p2 + 6 * (q2 + q + 20) * p + 120 * q + 192) * s2 +  \
                    (12 * p2 + 24 * (q + 1) * p + 12 * (q2 + 2 * q + 7)) * s12 -  \
                    12 * (3 * p + 4 * q + 3) * S1 * s2 - 160 * s3 + 24 * s22
                b[7] = 48 * s3 + 12 * (q + p + 1) * S1 * s2 - 12 * s22
                b[8] = 3 * s22
            # End If

        if (dis == 3):
            #            Case 3
            # ' Pillai's V, Manova
            # ' Fujikoshi (1974), Ann. Inst. Math. Statist., 26, p. 289
            if show:
                print("Vdis")
            if Model == "GLM":
                if show:
                    print("GLM")
                a[0] = -F * G
                a[1] = 2 * F * G
                a[2] = -F * G + 4 * G * o1 + 4 * o2
                a[3] = -4 * G * o1
                a[4] = -4 * o2

                b[0] = F * L0
                b[1] = F * l1
                b[2] = F * l2 + 2 * l1 * o1 - 24 * F * G * o2
                b[3] = F * l3 + 4 * l2 * o1 + 48 * (F + 4) * G * o2 + 128 * o3
                b[4] = F * l4 + 6 * l3 * o1 + 48 * \
                    (g2 - 2) * o12 - 96 * (G + 1) * \
                    o2 + 96 * G * o1 * o2 + 48 * o22
                b[5] = 8 * (l4 * o1 - 12 * (g2 + 2) * o12 -  \
                    6 * ((F + 12) * G + 4) * o2 - 12 * G * o1 * o2 - 48 * o3)
                b[6] = 8 * (6 * (g2 + 6) * o12 + 3 * ((F + 20) * G + 12) * o2 -  \
                    12 * G * o1 * o2 - 16 * o3 - 12 * o22)
                b[7] = 96 * (G * o1 * o2 + 4 * o3)
                b[8] = 48 * o22
            else:
                if show:
                    print("CORR")
                a[0] = -F * G - 4 * o2
                a[1] = 2 * F * G
                a[2] = -F * G + 4 * G * o1 + 8 * o2
                a[3] = -4 * G * o1
                a[4] = -4 * o2
                b[0] = F * L0 + 24 * F * G * o2 - 128 * o3 + 48 * o22
                b[1] = F * l1 - 48 * F * G * o2
                b[2] = F * l2 + 2 * l1 * o1 + 96 * o12 - 24 * \
                    (q * p2 + q * (q + 1) * p - 4) * \
                    o2 - 96 * G * o1 * o2 - 192 * o22
                b[3] = F * l3 + 4 * l2 * o1 + 96 * \
                    (q * p2 + (q2 + q + 4) * p + 4 * (q + 1)) * \
                    o2 + 96 * G * o1 * o2 + 640 * o3
                b[4] = F * l4 + 6 * l3 * o1 + 48 * (p2 + 2 * (q + 1) * p +  \
                    q2 + 2 * q - 3) * o12 - 24 * (q * p2 + (q2 + q + 12) * p +  \
                    4 * (3 * q + 5)) * o2 + 192 * G * o1 * o2 + 288 * o22
                b[5] = 8 * l4 * o1 - 96 * (p2 + 2 * (q + 1) * p + q2 +  \
                    2 * q + 3) * o12 - 48 * (q * p2 + (q2 + q + 12) * p +  \
                    4 * (3 * q + 4)) * o2 - 192 * G * o1 * o2 - 768 * o3
                b[6] = 48 * (p2 + 2 * (q + 1) * p + q2 + 2 * q + 7) * o12 +  \
                    24 * (q * p2 + (q2 + q + 20) * p + 4 * (5 * q + 8)) * o2 -  \
                    96 * G * o1 * o2 - 128 * o3 - 192 * o22
                b[7] = 96 * (G * o1 * o2 + 4 * o3)
                b[8] = 48 * o22
            # End If
        # End Select

        if ((o1 == 0) and (dis != 1)):
            c[0] = G * ((f2 - 8 * F + 16) * g2 + 4 *
                        (F - 4) * G + 4 * (f2 - 2 * F - 8))
            c[1] = -2 * F * G * L0
            c[2] = F * G * (5 * (3 * F + 8) * g2 + 4 * G + 4 * (F + 2))
            c[3] = -(4 * G * (5 * (f2 + 8 * F + 16) * g2 +
                     4 * (F + 4) * G + 4 * (f2 + 6 * F + 8)))
            c[4] = 5 * (3 * f2 + 40 * F + 144) * g3 + 4 * (11 * F + 108) * \
                g2 + 4 * (11 * f2 + 130 * F + 288) * G + 96 * (F + 2)
            c[5] = -(2 * ((3 * f2 + 56 * F + 288) * g3 + 4 * (5 * F + 72)
                     * g2 + 4 * (5 * f2 + 82 * F + 216) * G + 96 * (F + 2)))
            c[6] = (f2 + 24 * F + 160) * g3 + 4 * (3 * F + 56) * \
                g2 + 4 * (3 * f2 + 62 * F + 184) * G + 96 * (F + 2)
            c[7] = 0
            c[8] = 0
            c[9] = 0
        # End If

        for i in range(0, 9+1):
            # For i = 0 To 9
            LeftTail, Righttail = self.Cdisn2(F + 2 * i, x, 2 * o1)
            left[i] = LeftTail
        # Next i

        sum0 = left[0]
        if show:
            OutStr = str(sum0)
            OutStr = "sum0:  " + OutStr
            print(OutStr)
        # End If
        sum1 = 0

        for i in range(0, 4+1):
            # For i = 0 To 4
            sum1 = sum1 + a(i) * left[i]
        # Next i
        sum1 = sum1 / m
        if dis != 1:
            sum1 = sum1 / 4
        if show:
            OutStr = str(sum1)
            OutStr = "sum1:  " + OutStr
            print(OutStr)
        # End If

        sum2 = 0
        for i in range(i, 8+1):
            # For i = 0 To 8
            sum2 = sum2 + b(i) * left[i]
        # Next i
        sum2 = sum2 / (m * m)
        if dis != 1:
            sum2 = sum2 / 96

        if show:
            OutStr = str(sum2)
            OutStr = "sum2:  " + OutStr
            print(OutStr)
        # End If

        sum3 = 0
        if ((o1 == 0) or ((dis == 1) and (Model == "GLM"))):
            for i in range(0, 9+1):
                # For i = 0 To 9
                sum3 = sum3 + c(i) * left[i]
            # Next i
        # End If
        sum3 = sum3 / (m * m * m)
        if dis != 1:
            sum3 = F * sum3 / 384
        if ((dis == 3) or (dis == 1)):
            sum3 = -sum3
        if show:
            OutStr = str(sum3)
            OutStr = "sum3:  " + OutStr
            print(OutStr)
        # End If
#        'If (sum0 * sum1 * sum2) <> 0 Then
#        't0(0) = -Abs(sum0):: x0(0) = -1
#        't0(1) = -Abs(sum1):: x0(1) = -1 / Sqr(m)
#        't0(2) = -Abs(sum2):: x0(2) = -1 / (m)
#        't0(3) = Abs(sum2):: x0(3) = 1 / (m)
#        't0(4) = Abs(sum1):: x0(4) = 1 / Sqr(m)
#        't0(5) = Abs(sum0):: x0(5) = 1
#        'result = interpolate(True, 1 / (m * Sqr(m)), 0, 5, x0(), t0())
#        'If ((sum1 < 0) And (sum2 < 0)) Then result = -result
#        'If show Then Debug.Print "Result   :", result
#        'End If
        LeftTail = sum0 + sum1 + sum2 + sum3
#        'If (LeftTail + sum1 < 1) And (LeftTail + sum1 > 0) Then LeftTail = LeftTail + sum1
#        'If (LeftTail + sum2 < 1) And (LeftTail + sum2 > 0) Then LeftTail = LeftTail + sum2
#        'If (LeftTail + sum3 < 1) And (LeftTail + sum3 > 0) Then LeftTail = LeftTail + sum3
        Righttail = 1 - LeftTail
#        'If show Then Debug.Print "New:", LeftTail + result
#        'Console.WriteLine("LeftTail: {0}, Righttail: {1}", LeftTail, Righttail)
        return LeftTail, Righttail
    # End Sub

    def DemoGLMPower(self):
        # '  p: # of variables in 1. set
        # '  q: # of variables in 2. set
        # '  n: # of cases-1 }
        #        Dim p, q, n As Int32
        #        Dim x, LeftTail, RightTail, Left1 As Double

        p = 4
        q = 6
        n = 80 + q
        LeftTail = 0.95
        RightTail = 1 - LeftTail

        Omega2 = [0, 0, 0, 0, 0]
        # 'Dim Omega() As Double = {0.0, 1.0, 1.0, 1.0}
        Omega = [0.0, 11.0, 1.0, 1.0]
        Omega[0] = 27

        print("")
        print("grdis")
        x = self.GRDisX(LeftTail, RightTail, p, q, n - q)
        print("x: {0}", x)

        Left1 = self.GRDisN(False, "GLM", p, q, n - q, x, Omega2)
        print("Null:: {0}", Left1)

        Left1 = self.GRDisN(False, "CORR", p, q, n - q, x, Omega)
        print("CORR:: {0}", Left1)

        Left1 = self.GRDisN(False, "GLM", p, q, n - q, x, Omega)
        print("GLM: : {0}", Left1)

        print("")
        print("udis")
        x = self.Udisx(LeftTail, RightTail, p, q, n - q)
        print("x: {0}", x)

        Left1 = self.UdisN("GLM", p, q, n - q, x, Omega2)
        print("Null:: {0}", Left1)

        Left1 = self.UdisN("CORR", p, q, n - q, x, Omega)
        print("CORR:: {0}", Left1)

        Left1 = self.UdisN("GLM", p, q, n - q, x, Omega)
        print("GLM: : {0}", Left1)

        print("")
        print("t2dis")
        x = self.T2disX(LeftTail, RightTail, p, q, n - q)
        print("x: {0}", x)

        Left1 = self.T2disN("GLM", p, q, n - q, x, Omega2)
        print("Null:: {0}", Left1)

        Left1 = self.T2disN("CORR", p, q, n - q, x, Omega)
        print("CORR:: {0}", Left1)

        Left1 = self.T2disN("GLM", p, q, n - q, x, Omega)
        print("GLM: : {0}", Left1)

        print("")
        print("vdis")
        x = self.VdisX(LeftTail, RightTail, p, q, n - q)
        print("x: {0}", x)

        Left1 = self.VdisN("GLM", p, q, n - q, x, Omega2)
        print("Null:: {0}", Left1)

        Left1 = self.VdisN("CORR", p, q, n - q, x, Omega)
        print("CORR:: {0}", Left1)

        Left1 = self.VdisN("GLM", p, q, n - q, x, Omega)
        print("GLM: : {0}", Left1)

    # End Sub


# %% 11.5 Approximations based on the noncentral F or beta distribution


# 11.5.1 Multiple correlation coefficient (Lee and Gurland)
    def fisher_r2_lee_mu3_cdf(self, ctx, r2, f1, f2, Rho2):
        #        '3 moment approximation by noncentral F (Lee, 1970)
        gamma2 = 1 / (1 - Rho2)
        n = f2 + f1
        A1 = n * (gamma2 - 1) + f1
        A2 = n * (gamma2 * gamma2 - 1) + f1
        a3 = n * (gamma2 * gamma2 * gamma2 - 1) + f1
        g = (A2 - ctx.sqrt(A2 * A2 - A1 * a3)) / A1
        lambda1 = Rho2 * gamma2 * ctx.sqrt(gamma2 * n * f2) / (g * g)
        nu = A2 / (g * g) - 2 * lambda1
        x1 = (r2 / (1 - r2)) * (f2 / (nu * g))
        density, l1, r1 = self.DoublyFdisn_Paolella_Combined(
            ctx, nu, f2, x1, lambda1, 0)
        return r1

    def demoRho_By_fdisn(self, ctx, ):
        #        Dim LeftTail As Double, RightTail As Double, f1 As Double, f2 As Double, L As Double, X As Double, p As Double
        #        Dim IsGLM As Boolean, mr As Double
        #        Dim Rho2 As Double, r2 As Double
        IsGLM = False
        LeftTail = 0.05
        RightTail = 1 - LeftTail
        f1 = 2
        f2 = 12
        L = 13
        X = self.Fdisnx2(IsGLM, LeftTail, RightTail, f1, f2, L)

        Rho2 = L / (L + f2)
        r2 = X * f1 / (X * f1 + f2)
        print("Rho2:", Rho2)
        print("R2:", r2)

        p = self.Fdisn2Z2(IsGLM, X, f1, f2, L)
        print("X:", X, "p:", p)

        p = self.fisher_r2_lee_mu3_cdf(r2, f1, f2, Rho2)
        print("R2:", r2, "p:", p)

#        Call R2DisN(False, f1, f2, r2, Rho2, LeftTail, RightTail)
#        Debug.Print LeftTail, RightTail

    def R2DisX0(self, ctx, LeftTail, Righttail, a, b):
        w = self.Fdisx(LeftTail, Righttail, a, b)
        x = a * w / (a * w + b)
        y = b / (a * w + b)
        return x, y

    def GRDisX(self, ctx, LeftTail, Righttail, p, m, n):
        LeftTail = ctx.exp(ctx.log(LeftTail) / p)
        Righttail = 1 - LeftTail
        x = self.R2DisX0(LeftTail, Righttail, m, n)
        return x


# 11.5.2 Noncentral Wilks’ Lambda under the GLM or independence alternative
    def wilks_lambda_glm_mu2_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 11.5.3 Noncentral Hotelling’s T under the GLM or independence alternative
    def hotelling_t2_glm_mu2_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 11.5.4 Noncentral Pillai’s V under the GLM or independence alternative
    def pillai_v_glm_mu2_cdf(self, ctx):
        raise Exception("NOT IMPLEMENTED")


# 11.5.5 Noncentral Roy’s largest root under the GLM or independence alternative
    def roy_glm_mu2_cdf(self, ctx, IsRho, Model, p, m, n, x, omega):
        # def GRDisN(self, ctx, IsRho, Model, p, m, n, x, omega):
        result = 1
        if Model == "GLM":
            IsGLM = True
        else:
            IsGLM = False
        for i in range(1, p+1):
            # 'If IsRho Then rho = omega(i) Else rho = omega(i) / (n + omega(i))
            if IsRho:
                rho = omega(i - 1)
            else:
                rho = omega[i - 1] / (n + omega[i - 1])
            LeftTail, Righttail = self.R2DisN(IsGLM, m, n, x, rho)
            Left1 = LeftTail
            result = result * Left1
        return result


# %% 11.6 Approximations based on hypergeometric functions of scalar argument

# 11.6.1 Hypergeometric function 1F1 for matrix argument (Butler’s approximation)
    def hypergeom_matrix_1f1_butler(self, ctx, a, b, x):
        r0 = self.hyper_1f1_butler_wood(a, b, x)
        p = len(x)
        x1 = [0]
        prod1 = 1.0
        prod2 = 1.0
        for i in range(p):
            x1[0] = x[i]
            r1 = self.hyper_1f1_butler_wood(ctx, a, b, x1)
            prod1 = prod1 * r1
            r2 = ctx.hyp1f1(a, b, x1[0])
            prod2 = prod2 * r2
        ratio = prod1/prod2
        Result = r0/ratio
        return Result

    def hyper_1f1_butler_wood(self, ctx, a, b, x):
        p = len(x)
        y = [0] * p
        prod = 1
        for i in range(p):
            tau = b - x[i]
            y[i] = (2 * a) / (tau + ctx.sqrt(tau * tau + 4 * a * x[i]))
            prod = prod * \
                (((y[i] / a) ** a) * (((1 - y[i]) / (b - a))
                 ** (b - a)) * ctx.exp(x[i] * y[i]))
        r11 = 1
        for i in range(p):
            for j in range(i, p):
                r11 = r11 * ((y[i] * y[j] / a) + (1 - y[i])
                             * (1 - y[j]) / (b - a))
        k = b ** (p * b - p * (p + 1) / 4)
        Result = k * prod / ctx.sqrt(r11)
        return Result

    def demo_hypergeometric_1f1_matrix(self, ctx):
        a = 3
        b = 45
        x = [32, 24, 13]
        r0 = self.hypergeom_matrix_1f1_butler(ctx, a, b, x)
        print("r0:", r0)


# 11.6.3 Hypergeometric function 2F1 for matrix argument (Butler’s approximation)
    def hypergeom_matrix_2f1_butler(self, ctx, a, b, c, x):
        r0 = self.hyper_2f1_butler_wood(a, b, c, x)
        p = len(x)
        x1 = [0]
        prod1 = 1.0
        prod2 = 1.0
        for i in range(p):
            x1[0] = x[i]
            r1 = self.hyper_2f1_butler_wood(ctx, a, b, c, x1)
            prod1 = prod1 * r1
            r2 = ctx.hyp2f1(a, b, c, x1[0])
            prod2 = prod2 * r2
        ratio = prod1/prod2
        Result = r0/ratio
        return Result

    def hyper_2f1_butler_wood(self, ctx, a, b, c, x):
        p = len(x)
        y = [0] * p
        s = [0] * p
        prod = 1
        for i in range(p):
            tau = x[i] * (b - a) - c
            y[i] = (2 * a) / (ctx.sqrt(tau * tau - 4 * a * x[i] * (c - b)) - tau)
            s[i] = x[i] * y[i] * (1 - y[i]) / (1 - x[i] * y[i])
            prod = prod * (((y[i] / a) ** a) * (((1 - y[i]) / (c - a))
                           ** (c - a)) * (1 - x[i] * y[i]) ** (-b))
        r21 = 1
        for i in range(p):
            for j in range(i, p):
                r21 = r21 * ((y[i] * y[j] / a) + (1 - y[i]) * (1 -
                             y[j]) / (c - a) - b * s[i] * s[j] / (a * (c - a)))
        k = c ** (p * c - p * (p + 1) / 4)
        Result = k * prod / ctx.sqrt(r21)
        return Result

    def demo_hypergeometric_2f1_matrix(self, ctx):
        a = 8.0
        b = 2.5
        c = 15.0
        x = [0.9, 0.2, 0.1]
        r0 = self.hypergeom_matrix_2f1_butler(ctx, a, b, c, x)
        print("r0:", r0)
