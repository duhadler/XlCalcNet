
import time
from xlcalcnet import gui #, fpm, mpm, dpm, ipm, fpmlib, mpmlib, dpmlib, ipmlib
#if gui.has_gpm: from xlcalcnet import gpm, gpmlib
#if gui.has_apm: from xlcalcnet import apm, apmlib


def main_tests():
    demo_manual_real()
#    demo_sin_real_ctx()
#    demo_sin_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_pm_user:
        print(ctx.fmtname + ': ' + ctx.fmt(ctx.sin(x)))
    print('</H1>')



try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())
