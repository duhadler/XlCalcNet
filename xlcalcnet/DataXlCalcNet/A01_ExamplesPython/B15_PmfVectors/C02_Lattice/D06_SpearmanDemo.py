
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    Spearmandemo1()


def Spearmandemo1():
    print("Spearmandemo1()")
    N = 6
    Order = 1
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf, nl = pmfbasic.spearman_rho_pmf_vector(mpm, N, Order)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




