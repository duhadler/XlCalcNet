
import time
from xlcalcnet import gui
if gui.has_gpm: from xlcalcnet import gpm, gpmlib


def demogpmlib():
    if gui.has_gpm: 
        gpm.dps=40

        res = gpmlib.sin(4)
        print('res = gpmlib.sin(4):', res)
        res = gpmlib.sin(4+5j)
        print('res = gpmlib.sin(4+5j):', res)

        res = gpmlib.abs(4)
        print('res = gpmlib.abs(4):', res)
        res = gpmlib.abs(4+5j)
        print('res = gpmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        start0 = time.time()
        demogpmlib()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())
