
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    Wilcoxondemo1()


def Wilcoxondemo1():
    print("Wilcoxondemo1()")
    N = 50
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf, nl = pmfbasic.wilcoxon_pmf_vector(mpm, N)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




