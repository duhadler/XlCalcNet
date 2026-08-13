
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]

# currently not working

def main_tests():
    Miltondemo1()


def Miltondemo1():
    print("Miltondemo1()")
    delta = [0,0,1]
    n_ = [0,5,5]
    pmfbasic = mpm.pmfvec().ctxMilton()
    pmf, nl = pmfbasic.milton_pmf(mpm, n_, delta)
    for i in range(nl):
        print(i, pmf[i])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




