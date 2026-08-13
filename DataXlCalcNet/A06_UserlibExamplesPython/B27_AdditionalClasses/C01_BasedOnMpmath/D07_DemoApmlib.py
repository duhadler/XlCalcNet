
import time
from xlcalcnet import gui
if gui.has_apm: from xlcalcnet import apm, apmlib


def demoapmlib():
    if gui.has_apm:
        apm.dps=40

        res = apmlib.sin(4)
        print('res = apmlib.sin(4):', res)
        res = apmlib.sin(4+5j)
        print('res = apmlib.sin(4+5j):', res)

        res = apmlib.abs(4)
        print('res = apmlib.abs(4):', res)
        res = apmlib.abs(4+5j)
        print('res = apmlib.abs(4+5j):', res)


try:
    if __name__ == '__main__':
        start0 = time.time()
        demoapmlib()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())
