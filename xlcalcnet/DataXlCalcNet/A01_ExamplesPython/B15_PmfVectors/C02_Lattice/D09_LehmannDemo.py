
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    Lehmanndemo1()


def Lehmanndemo1():
    print("Lehmanndemo1()")
    kvalue = 1
    m = 10
    n = 10
    pmfbasic = mpm.pmfvec().ctxLehmann()
    pmf, nl = pmfbasic.mannwhitney_u_lehmann_pmf_vector(mpm, kvalue, m, n)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




