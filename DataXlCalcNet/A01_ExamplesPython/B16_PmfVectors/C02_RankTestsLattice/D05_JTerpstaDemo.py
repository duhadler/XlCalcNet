
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    JTerpstademo1()


def JTerpstademo1():
    print("JTerpstademo1()")
    k = 3
    n = [0,5,5,5]
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf, nl = pmfbasic.jterpsta_s_pmf_vector(mpm, k, n)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




