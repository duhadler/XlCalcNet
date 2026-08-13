# -*- coding: utf-8 -*-
"""
Created on Fri Apr  3 20:13:25 2015

@author: DH
"""

import numpy as np
import pandas as pd

# 7 Inferential statistics


# %% 7.1 Basic classical statistical tests for 1 sample


class table(object):

    def __init__(self, ctx, data=None, index=None, columns=None):
        self.ctx = ctx
        self.data = data
        self.index = index
        self.columns = columns
        #print("In table __init__")

    def __str__(self):
        maxlen = 0
        for i in range(len(self.index)):
            if len(self.index[i]) > maxlen:
                maxlen = len(self.index[i])
        #print(maxlen)
        #s = ' ' * (maxlen-9) + 'Parameter  ' + str(self.columns[0]) + '\n'
        s = ' ' * (maxlen-9) + 'Parameter  ' + str(self.columns) + '\n'
        n = len(self.index)
        for i in range(n):
            pad = ' ' * (maxlen - len(self.index[i]))
            s = s + pad + self.index[i] + ': ' + str(self.data[i])
            if i < (n-1):
                s = s + '\n'
        return s

    def __repr__(self):
        #return "table('" + str(self) + "')"
        return str(self)

    def to_csv(self, fname):
        import pandas as pd
        colheaders = self.columns
        rowheaders = self.index
        df = pd.DataFrame(self.data, rowheaders, colheaders)
        #print(df)
        fname = fname
        df.to_csv(fname, index=True)



class inferential_statistics(object):


    def __init__(self):
        pass


# 7.1.2 Student t-test for 1 sample: tests (p-values and confidence intervals)

    def student_t_1sample_test(self, ctx, n, mu0, mean, stdev, alpha,**kwargs):
        import numpy as np
        #print("Student t-test for 1 sample: tests and confidence intervals")
        res = table(ctx)
        res.columns = ['G1', 'G2', 'G3', 'G4']
        res.index, res.data = [], []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        T = kwargs['T'] if 'T' in kwargs else True
        C = kwargs['C'] if 'C' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(x if hasattr(x, "__len__") else [x]) \
            for x in [n, mu0, mean, stdev, alpha]]
        cols = max(len(x) for x in p)
        for item in p:
            for i in range(len(item), cols):
                item.append(item[i-1])

        n = ctx.t1 * np.array(p[0])
        mu0 = ctx.t1 * np.array(p[1])
        mean = ctx.t1 * np.array(p[2])
        stdev = ctx.t1 * np.array(p[3])
        alpha = ctx.t1 * np.array(p[4])

        df, diff, StdDiff, a, t, r = [], [], [], [], [], []
        t_alpha1, t_alpha2, p_H01, p_H02, p_H03 = [], [], [], [], []
        CI_UL1, CI_LL1, CI_UL2, CI_LL2, CILength = [], [], [], [], []

        for i in range(cols):
            df.append(n[i] - 1)
            diff.append(mean[i] - mu0[i])
            StdDiff.append((stdev[i] / ctx.sqrt(n[i])))
            a.append(alpha[i])
            t.append(diff[i] / StdDiff[i])
            r.append(diff[i] / stdev[i])

            t_alpha1.append(ctx.student_t_qtf(a[i], df[i], qtf=False))
            t_alpha2.append(ctx.student_t_qtf(a[i]/2, df[i], qtf=False))

            p_H01.append(ctx.student_t_cdf(t[i], df[i], cdf=True))
            p_H02.append(ctx.student_t_cdf(t[i], df[i], cdf=False))
            p_H03.append(p_H02[i] + ctx.student_t_cdf(-t[i], df[i], cdf=True))

            CI_UL1.append(diff[i] + t_alpha1[i] * StdDiff[i])
            CI_LL1.append(diff[i] - t_alpha1[i] * StdDiff[i])
            CI_UL2.append(diff[i] + t_alpha2[i] * StdDiff[i])
            CI_LL2.append(diff[i] - t_alpha2[i] * StdDiff[i])
            CILength.append(CI_UL2[i] - CI_LL2[i])

        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mean'); res.data.append(mean)
            res.index.append('mu0'); res.data.append(mu0)
            res.index.append('stdev'); res.data.append(stdev)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(df)
            res.index.append('difference of means'); res.data.append(diff)
            res.index.append('rho-tilde = (mean-mu0)/stdev'); res.data.append(r)
            res.index.append('t-value (=delta)'); res.data.append(t)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)')
                res.data.append(t_alpha1)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)')
                res.data.append(t_alpha2)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 >= mu0)')
                res.data.append(p_H01)
                res.index.append('test, p-value (H02: mu1 <= mu0)')
                res.data.append(p_H02)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)')
                res.data.append(p_H03)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)')
                res.data.append(CI_UL1)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)')
                res.data.append(CI_LL1)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)')
                res.data.append(CI_UL2)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)')
                res.data.append(CI_LL2)
                res.index.append('mu1 - mu0, CI-length (2-sided)')
                res.data.append(CILength)
        return res




# 7.1.4 Student t-test for 1 sample: power

    def student_t_1sample_power(self, ctx, n, mu0, mu1, sigma, alpha,**kwargs):
        print("Student t-test for 1 sample: power")
        res = table(ctx)
        res.columns = ['G1', 'G2', 'G3', 'G4']
        res.index, res.data = [], []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        P = kwargs['T'] if 'P' in kwargs else True
        E = kwargs['E'] if 'E' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(x if hasattr(x, "__len__") else [x]) \
            for x in [n, mu0, mu1, sigma, alpha]]
        cols = max(len(x) for x in p)
        for item in p:
            for i in range(len(item), cols):
                item.append(item[i-1])

        n = ctx.t1 * np.array(p[0])
        mu0 = ctx.t1 * np.array(p[1])
        mu1 = ctx.t1 * np.array(p[2])
        sigma = ctx.t1 * np.array(p[3])
        alpha = ctx.t1 * np.array(p[4])

        df, diff, StdDiff, a, t, r = [], [], [], [], [], []
        t_alpha1, t_alpha2, p_H01, p_H02, p_H03 = [], [], [], [], []

        for i in range(cols):
            df.append(n[i] - 1)
            diff.append(mu1[i] - mu0[i])
            StdDiff.append((sigma[i] / ctx.sqrt(n[i])))
            a.append(alpha[i])
            t.append(diff[i] / StdDiff[i])
            r.append(t[i] / ctx.sqrt(t[i]*t[i] + df[i]))

            t_alpha1.append(ctx.student_t_qtf(a[i], df[i], qtf=False))
            t_alpha2.append(ctx.student_t_qtf(a[i]/2, df[i], qtf=False))

            p_H01.append(ctx.student_t_cdf(t[i], df[i], cdf=True))
            p_H02.append(ctx.student_t_cdf(t[i], df[i], cdf=False))
            p_H03.append(p_H02[i] + ctx.student_t_cdf(-t[i], df[i], cdf=True))

        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mu0'); res.data.append(mu0)
            res.index.append('mu1'); res.data.append(mu1)
            res.index.append('sigma'); res.data.append(sigma)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(df)
            res.index.append('mu1 - mu0'); res.data.append(diff)
            res.index.append('rho'); res.data.append(r)
            res.index.append('delta'); res.data.append(t)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)')
                res.data.append(t_alpha1)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)')
                res.data.append(t_alpha2)
        if P:
            if Onesided:
                res.index.append('1-sided test, power (HA1: mu1 < mu2)'); res.data.append(7.46E-08)
                res.index.append('1-sided test, power (HA2: mu1 > mu2)'); res.data.append(0.974564)
            if Twosided:
                res.index.append('2-sided test, power (HA1: mu1 < mu2)'); res.data.append(1.65E-08)
                res.index.append('2-sided test, power (HA2: mu1 > mu2)'); res.data.append(0.943648)
                res.index.append('2-sided test, power (HA1: mu1 <> mu2)'); res.data.append(0.943648)
        if E:
            res.index.append('Pr(Mean1 < Mean2)'); res.data.append(9.92E-05)
            res.index.append('Pr(Mean1 > Mean2)'); res.data.append(0.999901)
        return res




# 7.1.5 Student t-test for 1 sample: sample size calculation

    def student_t_1sample_samplesize(self, ctx, mu0, mu1, sigma, alpha, beta, \
            **kwargs):
        print("In Student t-test for 1 sample: sample size calculation")
        res = table(ctx)
        res.columns = ['G1', 'G2', 'G3', 'G4']
        res.index = []; res.data = []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        P = kwargs['T'] if 'P' in kwargs else True
        E = kwargs['E'] if 'E' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(x if hasattr(x, "__len__") else [x]) \
            for x in [mu0, mu1, sigma, alpha, beta]]
        cols = max(len(x) for x in p)
        for item in p:
            for i in range(len(item), cols):
                item.append(item[i-1])

        mu0 = ctx.t(1) * np.array(p[0])
        mu1 = ctx.t(1) * np.array(p[1])
        sigma = ctx.t(1) * np.array(p[2])
        alpha = ctx.t(1) * np.array(p[3])
        beta = ctx.t(1) * np.array(p[4])




        res.index.append('df'); res.data.append(21)
        res.index.append('difference of means'); res.data.append(1.19)
        res.index.append('t-value (=delta)'); res.data.append(3.721063)
        res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
        res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)

        res.index.append('1-sided test, required N (HA1: mu1 < mu2)'); res.data.append(18)
        res.index.append('1-sided test, actual power (HA1: mu1 < mu2)'); res.data.append(0.974564)

        res.index.append('1-sided test, required N (HA2: mu1 > mu2)'); res.data.append(9.92E-05)
        res.index.append('1-sided test, actual power (HA2: mu1 > mu2)'); res.data.append(0.999901)

        res.index.append('2-sided test, required N (HA1: mu1 < mu2)'); res.data.append(9.92E-05)
        res.index.append('2-sided test, actual power (HA1: mu1 < mu2)'); res.data.append(0.999901)

        res.index.append('2-sided test, required N (HA2: mu1 > mu2)'); res.data.append(9.92E-05)
        res.index.append('2-sided test, actual power (HA2: mu1 > mu2)'); res.data.append(0.999901)

        res.index.append('2-sided test, required N (HA2: mu1 <>mu2)'); res.data.append(9.92E-05)
        res.index.append('2-sided test, actual power (HA2: mu1 <>mu2)'); res.data.append(0.999901)

        return res




# 7.1.9 Chi-squared-test for the variance of 1 sample: tests (p-values)

    def variance_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.1.10 Chi-squared-test for the variance of 1 sample: confidence intervals

    def variance_conf_intv(x, k, n, method='default'):
        temp = 0
        return temp





# 7.1.11 Chi-squared-test for the variance of 1 sample: power

    def variance_power(x, k, n, method='default'):
        temp = 0
        return temp





# 7.1.12 Chi-squared-test for the variance of 1 sample: sample size

    def variance_samplesize(x, k, n, method='default'):
        temp = 0
        return temp




# %% 7.2 Basic classical statistical tests for 2 independent samples




# 7.1.2 Student t-test for 2 independent samples: : tests (p-values)

    def student_t_2isamples_test(self, ctx, n1, n2, mean1, mean2, stdev1, stdev2, alpha, blocks=None, **kwargs):
        print("Student t-test for 2 independent samples: tests and confidence intervals")
        def f(x):
            if not(hasattr(x, "__len__")): x = [x]
            return x

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = True; D = True; T = True; C = True; Onesided=True; Twosided = True
        if 'I' in kwargs: I = kwargs["I"]
        if 'D' in kwargs: D = kwargs["D"]
        if 'T' in kwargs: T = kwargs["T"]
        if 'C' in kwargs: C = kwargs["C"]
        if 'Onesided' in kwargs: Onesided = kwargs["Onesided"]
        if 'Twosided' in kwargs: Twosided = kwargs["Twosided"]
        params = [f(x) for x in [n1, n2, mean1, mean2, stdev1, stdev2, alpha]]
        #print(params)
        maxlen = max(len(x) for x in params)

        for item in params:
            for i in range(len(item), maxlen):
                item.append(item[i-1])

        n1 = params[0]
        n2 = params[1]
        mean1 = params[2]
        mean2 = params[3]
        stdev1 = params[4]
        stdev2 = params[5]
        alpha = params[6]


        #print("maxlen:", maxlen)
        #print("params:", params)
        if I:
            res.index.append('n1'); res.data.append(n1)
            res.index.append('n2'); res.data.append(n2)
            res.index.append('mean1'); res.data.append(mean1)
            res.index.append('mean2'); res.data.append(mean2)
            res.index.append('stdev1'); res.data.append(stdev1)
            res.index.append('stdev2'); res.data.append(stdev2)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res



# 7.2.2 Student t-test for 2 independent samples: confidence intervals

    def student_t_conf_intv(x, k, n, method='default'):
        temp = 0
        return temp



# 7.2.3 Student t-test for 2 independent samples: power

    def student_t_power(x, k, n, method='default'):
        temp = 0
        return temp




# 7.2.4 Student t-test for 2 independent samples: sample size calculation

    def student_t_samplesize(x, k, n, method='default'):
        temp = 0
        return temp




# 7.1.6 Student t-test for 1 sample: CI for effect size (delta)

    def student_t_delta_intv(x, k, n, method='default'):
        temp = 0
        return temp



# 7.2.5 Student t-test for 2 independent samples: power and sample size:
    #failure to stratify

    def student_t_power2(mean, sd, n, alpha=0.05):
        temp = 0
        return temp





# 7.2.6 Student t-test for 2 independent samples: equivalence and
    #non-inferiority

    def student_t_equivalence(x, k, n, method='default'):
        temp = 0
        return temp





# 7.2.7 F-test for the variances of 2 independent samples: tests (p-values)

    def variance_fratio_test(s2, n, alpha=0.05):
        temp = 0
        return temp






# 7.2.8 F-test for the variances of 2 independent samples: confidence
    #intervals

    def variance_fratio_conf_intv(s2, n, alpha=0.05):
        temp = 0
        return temp





# 7.2.9 F-test for the variances of 2 independent samples: power

    def variance_fratio_power(s2, n, alpha=0.05):
        temp = 0
        return temp



# 7.2.10 F-test for the variances of 2 independent samples: sample size

    def variance_fratio_samplesize(s2, alpha=0.05, beta=0.1):
        temp = 0
        return temp






# %% 7.3 Basic classical statistical tests for 2 correlated samples




# 7.3.1 Student t-test for 2 correlated samples: tests (p-values)


    def student_t_2csamples_test(self, ctx, n, mean1, mean2, stdev1, stdev2, rho, alpha, **kwargs):
        print("Student t-test for 2 correlated samples: tests and confidence intervals")
        def f(x):
            if not(hasattr(x, "__len__")): x = [x]
            return x

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = True; D = True; T = True; C = True; Onesided=True; Twosided = True
        if 'I' in kwargs: I = kwargs["I"]
        if 'D' in kwargs: D = kwargs["D"]
        if 'T' in kwargs: T = kwargs["T"]
        if 'C' in kwargs: C = kwargs["C"]
        if 'Onesided' in kwargs: Onesided = kwargs["Onesided"]
        if 'Twosided' in kwargs: Twosided = kwargs["Twosided"]
        params = [f(x) for x in [n, mean1, mean2, stdev1, stdev2, rho, alpha]]
        #print(params)
        maxlen = max(len(x) for x in params)

        for item in params:
            for i in range(len(item), maxlen):
                item.append(item[i-1])

        n = params[0]
        mean1 = params[1]
        mean2 = params[2]
        stdev1 = params[3]
        stdev2 = params[4]
        rho = params[5]
        alpha = params[6]

        #print("maxlen:", maxlen)
        #print("params:", params)
        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mean1'); res.data.append(mean1)
            res.index.append('mean2'); res.data.append(mean2)
            res.index.append('stdev'); res.data.append(stdev1)
            res.index.append('stdev'); res.data.append(stdev2)
            res.index.append('rho'); res.data.append(rho)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res




# 7.3.2 Student t-test for 2 correlated samples: confidence intervals

    def student_t_conf_intv(x, k, n, method='default'):
        temp = 0
        return temp




# 7.3.3 Student t-test for 2 correlated samples: power

    def student_t_power(x, k, n, method='default'):
        temp = 0
        return temp




# 7.3.4 Student t-test for 2 correlated samples: sample size calculation

    def student_t_samplesize(x, k, n, method='default'):
        temp = 0
        return temp




# 7.3.5 Morgan-Pitman test for the variances of 2 correlated samples:
    #tests (p-values)

    def variance_fratio_test(s2, n, alpha=0.05):
        temp = 0
        return temp




# 7.3.6 Morgan-Pitman test for the variances of 2 correlated samples:
    #confidence intervals

    def variance_fratio_conf_intv(s2, n, alpha=0.05):
        temp = 0
        return temp




# 7.3.7 Morgan-Pitman test for the variances of 2 correlated samples: power

    def variance_fratio_power(s2, n, alpha=0.05):
        temp = 0
        return temp




# 7.3.8 Morgan-Pitman test for the variances of 2 correlated samples:
    #sample size

    def variance_fratio_samplesize(s2, alpha=0.05, beta=0.1):
        temp = 0
        return temp





# 7.3.9 Pearson’s rho, 2 correlated samples: tests (p-values)

    def pearson_rho_test(rho, rh0, n, alpha=0.05, rtype=1):
        temp = 0
        return temp





# 7.3.10 Pearson’s rho, 2 correlated samples: confidence intervals

    def pearson_rho_conf_intv(rho, rh0, n, alpha=0.05, rtype=1):
        temp = 0
        return temp




# 7.3.11 Pearson’s rho, 2 correlated samples:: power

    def pearson_rho_power(rho, rho0, n, alpha=0.05, rtype=1):
        temp = 0
        return temp




# 7.3.12 Pearson’s rho, 2 correlated samples:: sample size calculation

    def pearson_rho_samplesize(rho, rho0, n, alpha=0.05, beta=0.1, rtype=1):
        temp = 0
        return temp







# %% 7.4 Anova and multiple comparisons of means




# 7.4.1 Anova (completely randomized and randomized blocks): p-value

    def anova_test(self, ctx, n, mean, stdev, alpha=0.05, rho=None, blocks=None, **kwargs):
        print("In anova_test: tests (p-values)")
        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        T = kwargs['T'] if 'T' in kwargs else True
        C = kwargs['C'] if 'C' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(np.atleast_2d(x)).T  for x in [n, mean, stdev, alpha]]
        rows = max(len(x) for x in p)
        cols = max(len(x) for x in p[0])
        for i in range(len(p)):
            p[i] = np.pad(p[i],[[0, rows-p[i].shape[0]],[0, cols-p[i].shape[1]]], 'edge')
        n = p[0]
        mean = p[1]
        stdev = p[2]
        alpha = p[3][0]

        if I:
            for i in range(rows):
                res.index.append('n'+str(i)); res.data.append(n[i])
            for i in range(rows):
                res.index.append('mean'+str(i)); res.data.append(mean[i])
            for i in range(rows):
                res.index.append('stdev'+str(i)); res.data.append(stdev[i])
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res





# 7.4.5 Anova (completely randomized and randomized blocks): power

    def anova_power(mean, sd, alpha=0.05, beta=0.1, rho=None, eta=0):
        temp = 0
        return temp



# 7.4.6 Anova (completely randomized and randomized blocks): sample size

    def anova_samplesize(mean, sd, alpha=0.05, beta=0.1, rho=None, eta=0):
        temp = 0
        return temp




# 7.4.7 Anova, trend tests using orthogonal polynomials: p-value

    def orthogonal_poly_test(self, ctx, n, mean, stdev, alpha, **kwargs):
        print("In orthogonal_poly_test: tests (p-values)")
        import numpy as np

        res = table(self.ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        T = kwargs['T'] if 'T' in kwargs else True
        C = kwargs['C'] if 'C' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(np.atleast_2d(x)).T  for x in [n, mean, stdev, alpha]]
        rows = max(len(x) for x in p)
        cols = max(len(x) for x in p[0])
        for i in range(len(p)):
            p[i] = np.pad(p[i],[[0, rows-p[i].shape[0]],[0, cols-p[i].shape[1]]], 'edge')
        n = p[0]
        mean = p[1]
        stdev = p[2]
        alpha = p[3][0]

        if I:
            for i in range(rows):
                res.index.append('n'+str(i)); res.data.append(n[i])
            for i in range(rows):
                res.index.append('mean'+str(i)); res.data.append(mean[i])
            for i in range(rows):
                res.index.append('stdev'+str(i)); res.data.append(stdev[i])
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res






# 7.4.9 Anova, trend tests using orthogonal polynomials: power

    def orthogonal_poly_power(x, k, n, method='default'):
        temp = 0
        return temp




# 7.4.10 Anova, trend tests using orthogonal polynomials: sample size

    def orthogonal_poly_samplesize(x, k, n, method='default'):
        temp = 0
        return temp




# %% 7.5 Multiple comparisons of means




# 7.4.11 Scheffé F-test: p-value

    def scheffe_test(self, ctx, n, mean, stdev, alpha, **kwargs):
        print("In scheffe_test: tests (p-values)")
        import numpy as np

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = kwargs['I'] if 'I' in kwargs else True
        D = kwargs['D'] if 'D' in kwargs else True
        T = kwargs['T'] if 'T' in kwargs else True
        C = kwargs['C'] if 'C' in kwargs else True
        Onesided = kwargs['Onesided'] if 'Onesided' in kwargs else True
        Twosided = kwargs['Twosided'] if 'Twosided' in kwargs else True

        p = [(np.atleast_2d(x)).T  for x in [n, mean, stdev, alpha]]
        rows = max(len(x) for x in p)
        cols = max(len(x) for x in p[0])
        for i in range(len(p)):
            p[i] = np.pad(p[i],[[0, rows-p[i].shape[0]],[0, cols-p[i].shape[1]]], 'edge')
        n = p[0]
        mean = p[1]
        stdev = p[2]
        alpha = p[3][0]

        if I:
            for i in range(rows):
                res.index.append('n'+str(i)); res.data.append(n[i])
            for i in range(rows):
                res.index.append('mean'+str(i)); res.data.append(mean[i])
            for i in range(rows):
                res.index.append('stdev'+str(i)); res.data.append(stdev[i])
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res





# 7.4.13 Scheffé F-test: power

    def scheffe_power(mean, sd, n, alpha=0.05, rho=None):
        temp = 0
        return temp




# 7.4.14 Scheffé F-test: sample size

    def scheffe_samplesize(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp






# 7.4.15 Tukey-Kramer q-test: p-value

    def tukey_kramer_test(mean, sd, n, rho=None):
        temp = 0
        return temp




# 7.4.16 Tukey-Kramer q-test: confidence interval

    def tukey_kramer_ci(mean, sd, n, alpha=0.05, rho=None):
        temp = 0
        return temp




# 7.4.17 Tukey-Kramer q-test: power

    def tukey_kramer_power(mean, sd, n, alpha=0.05, rho=None):
        temp = 0
        return temp




# 7.4.18 Tukey-Kramer q-test: sample size

    def tukey_kramer_samplesize(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp




# 7.4.19 Fisher-Hayter test: p-value

    def fisher_hayter_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp




# 7.4.20 REGWQ test (CR only): p-value

    def REGWQ_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp




# 7.4.21 Newman-Keuls test (CR only): p-value

    def newman_keuls_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp




# 7.4.22 Duncan-test (CR only): p-value

    def duncan_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp



# 7.4.23 Dunnett t-test: p-value

    def dunnett_test(mean, sd, n, rho=None):
        temp = 0
        return temp



# 7.4.24 Dunnett t-test: confidence interval

    def dunnett_ci(mean, sd, n, alpha=0.05, rho=None):
        temp = 0
        return temp


# 7.4.25 Dunnett t-test: power

    def dunnett_power(mean, sd, n, alpha=0.05, rho=None):
        temp = 0
        return temp


# 7.4.26 Dunnett t-test: sample size

    def dunnett_sample_size(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp



# 7.4.27 Marcus test: p-value

    def marcus_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp



# 7.4.28 Hsu test: p-value

    def hsu_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp



# 7.4.29 Analysis of means (ANOM): p-value

    def anom_test(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp



# 7.4.30 Distribution fitting

    def dist_fit(mean, sd, alpha=0.05, beta=0.1, rho=None):
        temp = 0
        return temp








# %% 7.6 Nonparametric statistical tests, 1 or 2 samples



# 7.5.1 Sign test: p-value and confidence interval

    def sign_test(self, ctx, n, mean1, mean2, stdev, alpha, **kwargs):
        print("In sign_test: tests (p-values)")
        def f(x):
            if not(hasattr(x, "__len__")): x = [x]
            return x

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = True; D = True; T = True; C = True; Onesided=True; Twosided = True
        if 'I' in kwargs: I = kwargs["I"]
        if 'D' in kwargs: D = kwargs["D"]
        if 'T' in kwargs: T = kwargs["T"]
        if 'C' in kwargs: C = kwargs["C"]
        if 'Onesided' in kwargs: Onesided = kwargs["Onesided"]
        if 'Twosided' in kwargs: Twosided = kwargs["Twosided"]
        params = [f(x) for x in [n, mean1, mean2, stdev, alpha]]
        print(params)
        maxlen = max(len(x) for x in params)

        for item in params:
            for i in range(len(item), maxlen):
                item.append(item[i-1])


        print("maxlen:", maxlen)
        print("params:", params)
        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mean1'); res.data.append(mean1)
            res.index.append('mean2'); res.data.append(mean2)
            res.index.append('stdev'); res.data.append(stdev)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res



# 7.5.2 Sign test: power and sample size

    def sign_test_power(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.3 Brown-Mood median test for 2 independent samples: p-value and
    #confidence interval

    def brown_mood_test(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.4 Brown-Mood median test for 2 independent samples: power and
    #sample size

    def brown_mood_power(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.5 Wilcoxon’s signed rank 𝑇 test: p-value and confidence interval,
    #continuous data

    def signed_rank_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.6 Wilcoxon’s signed rank test 𝑇 (Bennett alternatives): power and
    #sample size

    def signed_rank_power(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.7 Mann-Whitney 𝑈 test: p-value and confidence interval, continuous data

    def mannwhitney_test(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.8 Mann-Whitney 𝑈 test: (Lehmann alternatives): power and sample size

    def mannwhitney_power_lehmann(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.9 Mann-Whitney 𝑈 test: (Milton alternatives): power and sample size

    def mannwhitney_power_milton(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.10 Siegel-Tukey test: p-value and confidence interval

    def siegel_tukey_test(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.11 Kepner-Fligner test for 2-4 correlated samples: p-value

    def kepner_fligner_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.12 Kendall test for 2 correlated samples: p-value

    def kendall_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.13 Theill test for 2 correlated samples: p-value and confidence interals

    def theill_test(x, k, n, method='default'):
        temp = 0
        return temp






# %% 7.7 Nonparametric statistical tests, k samples



# 7.5.14 Jonckheere-Terpsta 𝑆 test: p-value and confidence interval,
    #continuous data

    def jterpsta_test(self, ctx, n, mean1, mean2, stdev, alpha, **kwargs):
        print("In jterpsta_testself: tests (p-values)")
        def f(x):
            if not(hasattr(x, "__len__")): x = [x]
            return x

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = True; D = True; T = True; C = True; Onesided=True; Twosided = True
        if 'I' in kwargs: I = kwargs["I"]
        if 'D' in kwargs: D = kwargs["D"]
        if 'T' in kwargs: T = kwargs["T"]
        if 'C' in kwargs: C = kwargs["C"]
        if 'Onesided' in kwargs: Onesided = kwargs["Onesided"]
        if 'Twosided' in kwargs: Twosided = kwargs["Twosided"]
        params = [f(x) for x in [n, mean1, mean2, stdev, alpha]]
        print(params)
        maxlen = max(len(x) for x in params)

        for item in params:
            for i in range(len(item), maxlen):
                item.append(item[i-1])


        print("maxlen:", maxlen)
        print("params:", params)
        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mean1'); res.data.append(mean1)
            res.index.append('mean2'); res.data.append(mean2)
            res.index.append('stdev'); res.data.append(stdev)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res





# 7.5.15 Jonckheere-Terpsta 𝑆 test, Shorack alternatives: power and
    #sample size

    def jterpsta_power_shorack(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.16 Jonckheere-Terpsta 𝑆 test (stratified), Milton alternatives:
    #power and sample size

    def jterpsta_power_milton(x, k, n, method='default'):
        temp = 0
        return temp



# 7.5.17 Spearman test for 2 correlated samples: p-value

    def page_l_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.19 Generalized Page 𝐿 test, Milton alternatives: power and sample size

    def page_l_milton_power(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.20 Generalized Quade 𝐿 test: p-value

    def quade_l_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.21 Friedman’s S, and related linear rank statistics

    def friedman_test(x, k, n, method='default'):
        temp = 0
        return temp




# 7.5.22 Kruskal-Wallis’ H, and related linear rank statistics

    def kruskal_wallis_test(x, k, n, method='default'):
        temp = 0
        return temp






# %% 7.8 Multivariate statistical tests



# 7.6.1 Multiple linear regression: p-value and confidence interval

    def multlinreg_test(self, ctx, n, mean1, mean2, stdev, alpha, **kwargs):
        print("In multlinreg_test: tests (p-values)")
        def f(x):
            if not(hasattr(x, "__len__")): x = [x]
            return x

        res = table(ctx)
        res.columns = ['Variable1']
        res.index = []; res.data = []
        I = True; D = True; T = True; C = True; Onesided=True; Twosided = True
        if 'I' in kwargs: I = kwargs["I"]
        if 'D' in kwargs: D = kwargs["D"]
        if 'T' in kwargs: T = kwargs["T"]
        if 'C' in kwargs: C = kwargs["C"]
        if 'Onesided' in kwargs: Onesided = kwargs["Onesided"]
        if 'Twosided' in kwargs: Twosided = kwargs["Twosided"]
        params = [f(x) for x in [n, mean1, mean2, stdev, alpha]]
        print(params)
        maxlen = max(len(x) for x in params)

        for item in params:
            for i in range(len(item), maxlen):
                item.append(item[i-1])


        print("maxlen:", maxlen)
        print("params:", params)
        if I:
            res.index.append('n'); res.data.append(n)
            res.index.append('mean1'); res.data.append(mean1)
            res.index.append('mean2'); res.data.append(mean2)
            res.index.append('stdev'); res.data.append(stdev)
            res.index.append('alpha'); res.data.append(alpha)
        if D:
            res.index.append('degrees of freedom'); res.data.append(21)
            res.index.append('difference of means'); res.data.append(1.19)
            res.index.append('r-value'); res.data.append(0.648)
            res.index.append('t-value (=delta)'); res.data.append(3.721063)
            if Onesided:
                res.index.append('t(1-alpha, 1-sided)'); res.data.append(1.720743)
            if Twosided:
                res.index.append('t(1-alpha, 2-sided)'); res.data.append(2.079614)
        if T:
            if Onesided:
                res.index.append('test, p-value (H01: mu1 <= mu0)'); res.data.append(0.999368)
                res.index.append('test, p-value (H02: mu1 >= mu0)'); res.data.append(0.000632)
            if Twosided:
                res.index.append('test, p-value (H03: mu1 = mu2)'); res.data.append(0.001263)
        if C:
            if Onesided:
                res.index.append('mu1 - mu0, CI upper limit (1-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (1-sided)'); res.data.append(0.524937)
            if Twosided:
                res.index.append('mu1 - mu0, CI upper limit (2-sided)'); res.data.append(1.855063)
                res.index.append('mu1 - mu0, CI lower limit (2-sided)'); res.data.append(0.524937)
                res.index.append('mu1 - mu0, CI-length (2-sided)'); res.data.append(1.330125)
        return res





# 7.6.2 Multiple linear regression Type I: power and sample size

    def multlinreg_type1_power(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp



# 7.6.3 Multiple linear regression Type II: power and sample size

    def multlinreg_type2_power(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp



# 7.6.4 Hotelling’s 𝑇2 test for 1 sample: p-value and confidence interval

    def hotelling_1sample_test(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp



# 7.6.5 Hotelling’s 𝑇2 test for 1 sample: power and sample size

    def hotelling_1sample_power(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp




# 7.6.6 Hotelling’s 𝑇2 test for 2 independent samples: p-value and
    #confidence interval

    def hotelling_2isamples_test(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp



# 7.6.7 Hotelling’s 𝑇2 test for 2 independent samples: power and sample size

    def hotelling_2isamples_power(self, ctx, mean, mean0, sd, n, alpha=0.05):
        temp = 0
        return temp



# 7.6.9 MANOVA: Wilks Λ, Pillai’s 𝑉 , Hotelling’s 𝑇2, Roy’s largest root 𝜃

    def four_tests_glm_test(x, p, m, n, cdf=True, method='default'):
        temp = 0
        return temp



# 7.6.10 Canonical correlation: Wilks Λ, Pillai’s 𝑉 , Hotelling’s 𝑇2,
    #Roy’s largest root 𝜃

    def four_tests_ind_test(x, p, m, n, cdf=True, method='default'):
        temp = 0
        return temp




# 7.6.11 Power estimates of 4 tests in MANOVA

    def four_tests_glm_power(x, p, m, n, Omega, cdf=True, method='default'):
        temp = 0
        return temp




# 7.6.12 Power estimates of 4 tests in canonical correlation (Type I)

    def four_tests_ind_power(x, p1, p2, n, Rho2, cdf=True, method='default'):
        temp = 0
        return temp





