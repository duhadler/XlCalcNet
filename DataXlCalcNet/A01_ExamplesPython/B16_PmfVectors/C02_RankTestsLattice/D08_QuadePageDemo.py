
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    QuadePagedemo1()


def QuadePagedemo1():
    print("QuadePagedemo1()")
    k = 3
    N = 6
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf, nl = pmfbasic.quade_l_pmf_vector(mpm, k, N)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




