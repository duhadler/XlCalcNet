
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    NegBinomialdemo1()


def NegBinomialdemo1():
    print("NegBinomialdemo1()")
    r = 10 
    p = 0.5  
    count =20
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf = pmfbasic.negbinom_pmf_vector(mpm, r, p, count)
    for i in range(count):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




