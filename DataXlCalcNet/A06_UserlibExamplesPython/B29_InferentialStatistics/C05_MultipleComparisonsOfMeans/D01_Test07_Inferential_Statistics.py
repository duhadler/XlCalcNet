# -*- coding: utf-8 -*-


from xlcalcnet import mpm, dpm, fpm, ipm, gpm




### 07 Test Inferential Statistic

class test_InfStat():



    # Basic classical statistical tests for 1 sample
    def demo_stats_student_t_1sample_test(self, ctx):
        n = [10, 20, 30]; mu0 = 1.0; mean = [4.5,4.6]; stdev = [1,2,3,4]; alpha=0.015
        #n = 16; mu0 = 4.05; mean = 5.24; stdev = 1.5; alpha=0.05
        res = ctx.student_t_1sample_test(n, mu0, mean, stdev, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)

    def demo_stats_student_t_1sample_power(self, ctx):
        n = [10, 20, 30]; mu0 = 1.0; mu1 = [4.5,4.6]; sigma = [1,2,3,4]; alpha=0.015
        #n = 56; mu0 = 4.05; mu1 = 5.24; sigma = 1.5; alpha=0.05
        res = ctx.student_t_1sample_power(n, mu0, mu1, sigma, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)

    def demo_stats_student_t_1sample_samplesize(self, ctx):
        mu0 = 1.0; mean = [4.5,4.6]; stdev = [1,2,3,4]; alpha=0.0; beta=0.1;
        res = ctx.student_t_1sample_samplesize(mu0, mean, stdev, alpha, beta, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)




    # Basic classical statistical tests for 2 independent samples
    def demo_stats_tests_2isamples(self, ctx):
        #print("demo_stats_tests_2isamples")
        n1 = [10, 20, 30]; mean1 = [4.5,4.6]; stdev1 = [1.5,2.5];
        n2 = [15, 25]; mean2 = [5.1,3.7,8.3]; stdev2 = [1.2,3.4];
        alpha = [0.015, 0.05]
        res = ctx.student_t_2isamples_test(n1, n2, mean1, mean2, stdev1, stdev2, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)


    # Basic classical statistical tests for 2 correlated samples
    def demo_stats_tests_2csamples(self, ctx):
        #print("demo_stats_tests_2csamples")
        n = 10; rho = 0.5; alpha = [0.015, 0.05]
        mean1 = [4.5,4.6]; stdev1 = [1,2,3];
        mean2 = [4.5,4.6]; stdev2 = [1,2,3];
        res = ctx.student_t_2csamples_test(n, mean1, mean2, stdev1, stdev2, rho, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)






    # Anova, orthogonal polynomials, and AOM
    def demo_stats_tests_anova(self, ctx):
        #print("demo_stats_tests_anova")
        n = [10, 20, 30]; mean = [4.5,4.6]; mu0 = 1.0; stdev = [1,2,3]; alpha=0.015
        res = ctx.anova_test(n, mean, stdev, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)

    def demo_stats_tests_anova_2D(self, ctx):
        #print("demo_stats_tests_anova_2D")
        n = [[10, 20, 30, 40],[110, 120, 130, 140],[210, 220, 230, 240]];
        mean = [4.5,4.6]; stdev = [1.2]; alpha=0.015
        res = ctx.anova_test(n=n, mean=mean, stdev=stdev, alpha=alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)



    # Multiple comparisons of means
    def demo_stats_tests_mcp(self, ctx):
        #print("demo_stats_tests_mcp")
        n = [[10, 20, 30, 40],[110, 120, 130, 140],[210, 220, 230, 240]];
        mean = [4.5,4.6]; stdev = [1.2]; alpha=0.015
        res = ctx.scheffe_test(n=n, mean=mean, stdev=stdev, alpha=alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)



    # Nonparametric statistical tests, 1 or 2 samples
    def demo_stats_nonparametric_1_2_tests(self, ctx):
        #print("demo_stats_nonparametric_1_2_tests")
        n = [10, 20, 30]; mean = [4.5,4.6]; mu0 = 1.0; stdev = [1,2,3,4]; alpha=0.015
        res = ctx.sign_test(n, mean, mu0, stdev, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)



    # Nonparametric statistical tests, k samples
    def demo_stats_nonparametric_k_tests(self, ctx):
        #print("demo_stats_nonparametric_k_tests")
        n = [10, 20, 30]; mean = [4.5,4.6]; mu0 = 1.0; stdev = [1,2,3,4]; alpha=0.015
        res = ctx.jterpsta_test(n, mean, mu0, stdev, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)



    # Multivariate statistical tests
    def demo_stats_multivariate_tests(self, ctx):
        #print("demo_stats_nonparametric_k_tests")
        n = [10, 20, 30]; mean = [4.5,4.6]; mu0 = 1.0; stdev = [1,2,3,4]; alpha=0.015
        res = ctx.multlinreg_test(n, mean, mu0, stdev, alpha, \
          I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
        print(res)






    def demo_07(self, ctx):
        #self.demo_stats_student_t_1sample_test(ctx)
        #self.demo_stats_student_t_1sample_power(ctx)
        self.demo_stats_student_t_1sample_samplesize(ctx)

        #self.demo_stats_tests_2isamples(ctx)
        #self.demo_stats_tests_2csamples(ctx)

        #self.demo_stats_tests_anova(ctx)
        #self.demo_stats_tests_anova_2D(ctx)


        #self.demo_stats_tests_mcp(ctx)

        #self.demo_stats_nonparametric_1_2_tests(ctx)
        #self.demo_stats_nonparametric_k_tests(ctx)

        #self.demo_stats_multivariate_tests(ctx)


mpm.dps=7
mpm.pretty = True
fpm.dps=mpm.dps
gpm.dps=mpm.dps
dpm.dps=mpm.dps
ipm.dps=mpm.dps

print("dps: ", mpm.dps)

##ctxm = ipm
##ctxm = fpm
##ctxm = dpm
##ctxm = gpm
ctxm = mpm
test_InfStat().demo_07(ctxm)






























