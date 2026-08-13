
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

def main_tests():
    Poissondemo1()


def Poissondemo1():
    print("Poissondemo1()")
    lambda1 = 2.5  
    count =20
    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf = pmfbasic.poisson_pmf_vector(mpm, lambda1, count)
    for i in range(count):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




