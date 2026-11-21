
from xlcalcnet import gui, mpm



def demo_stats_student_t_1sample_power(ctx):
    n = [10, 20, 30]; mu0 = 1.0; mu1 = [4.5,4.6]; sigma = [1,2,3,4]; alpha=0.015
    #n = 56; mu0 = 4.05; mu1 = 5.24; sigma = 1.5; alpha=0.05
    res = ctx.student_t_1sample_power(n, mu0, mu1, sigma, alpha, \
      I=True, D=True, T=True, P=True, E=True, Onesided=True, Twosided = True)
    print(res)
    #gui.table(res, __file__, "Student t-test, 1 sample: power")

try:
    mpm.dps=10
    mpm.pretty = True
    demo_stats_student_t_1sample_power(mpm)


except Exception:
    import traceback
    print(traceback.format_exc())

