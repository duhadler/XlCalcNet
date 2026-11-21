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






    def demo_07(self, ctx):
        #self.demo_stats_student_t_1sample_test(ctx)
        #self.demo_stats_student_t_1sample_power(ctx)
        self.demo_stats_student_t_1sample_samplesize(ctx)



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






























