
import time
import numpy as np
from xlcalcnet import dpm
    

def NumpyWithDecimals(**kwargs):
    r = 8
    c = 2
    dpm.dps = 30
    R = np.ndarray((r,c),dtype=dpm.realtype)
    d1 = dpm.t(1.0)
    for i in range(r):
        for j in range(c):
            R[i,j] = 10*(i+1) + d1/(j+7)
    print(R)
    print()
    res = np.mean(R)
    print('res = np.mean(R): \n', res, type(res))
    print()
    res = np.mean(R, axis=0)
    print('res = np.mean(R, axis=0): \n', res, type(res))
    print()
    res = np.mean(R, axis=1)
    print('res = np.mean(R, axis=1): \n', res, type(res))



try:
    if __name__ == '__main__':
        start0 = time.time()
        NumpyWithDecimals()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())



