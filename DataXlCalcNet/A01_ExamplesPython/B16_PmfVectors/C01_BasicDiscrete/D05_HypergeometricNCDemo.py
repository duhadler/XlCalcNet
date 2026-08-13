
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm

ctx_all = [qpm, fpm, mpm, ipm, dpm, gpm, apm]


# Note: this has not yet been implemented in ctx_shared.py

def main_tests():
    HypergeometricNCdemo1()


def HypergeometricNCdemo1():
    print("HypergeometricNCdemo1()")
    n = 10 
    K = 40 
    N =100
    start = n + K - N
    if start < 0:
        start = 0
    stop = K
    if n < K:
        stop = n

    pmfbasic = mpm.pmfvec().ctxPmfBasicVector()
    pmf = pmfbasic.hypergeo_pmf_vector(mpm, n, K, N)
    for k in range(start, stop+1):
        print("k:", k, "pmf[k]:", pmf[k])



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




