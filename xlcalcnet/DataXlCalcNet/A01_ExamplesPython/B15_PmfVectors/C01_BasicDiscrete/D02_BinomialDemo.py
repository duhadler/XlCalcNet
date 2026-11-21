
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    Binomialdemo1()


def Binomialdemo1():
    print("Binomialdemo1()")
    p = 0.75  # 0.5 same as signtest
    n =20
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf = pmfbasic.binomial_pmf_vector(mpm, n, p)
    for i in range(n+1):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




