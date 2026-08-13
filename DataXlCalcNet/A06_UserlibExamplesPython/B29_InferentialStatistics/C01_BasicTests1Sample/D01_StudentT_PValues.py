from xlcalcnet import gui, mpm


def demo_stats_student_t_1sample_test_old(ctx):
    n = [10, 20, 30]; mu0 = 1.0; mean = [4.5,4.6]; stdev = [1,2,3,4]; alpha=0.015
    res = ctx.student_t_1sample_test(n, mu0, mean, stdev, alpha, \
      I=True, D=True, T=True, C=True, Onesided=True, Twosided = True)
    #print(res)
    gui.table(res, __file__, "Student t-test, 1 sample: p-values and confidence intervals")


def demo_stats_student_t_1sample_test():
    from xlcalcnet import gui, mpm;
    mpm.dps=10;
    res = mpm.student_t_1sample_test(n = [10, 20, 30], mu0 = 1.0, mean = [4.5,4.6], std = [1,2,3,4], alpha=0.015);
    #print(res)
    gui.table(res, r'C:\Temp\Temp.py', 'Student t-test, 1 sample: p-values and confidence intervals')


try:
    demo_stats_student_t_1sample_test()

    #mpm.dps=10
    #demo_stats_student_t_1sample_test_old(mpm)

except Exception:
    import traceback
    print(traceback.format_exc())





























