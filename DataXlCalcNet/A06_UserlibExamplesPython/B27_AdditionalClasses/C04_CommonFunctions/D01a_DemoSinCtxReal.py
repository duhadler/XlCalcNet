
from xlcalcnet import gui, fpmlib, mpmlib, dpmlib, ipmlib
if gui.has_gpm: from xlcalcnet import gpmlib
if gui.has_apm: from xlcalcnet import apmlib
if gui.has_userfixedlib: from xlcalcnet import m53lib, slib, dlib, elib, qlib, \
    olib
if gui.has_userarblib: from xlcalcnet import mlib, sflib, dflib, eflib, qflib, \
    oflib, mflib, aflib
import time


def main_tests():
    demo_manual_real()
    demo_sin_real_ctx()
    demo_sin_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    ctxlist = gui.ctxlist_pm_user + gui.ctxlist_real_user
    for ctx in ctxlist: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sin(x)))
    print('</H1>')


def demo_sin_real_ctx():
    print('<H1 Title="demo_sin_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ctxlist = gui.ctxlist_pm_user + gui.ctxlist_real_user
    for x in xlist:
        print('<H2 Title="sin(x); x=' + str(x) + '">')
        for ctx in ctxlist:
            res = ctx.sin(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sin_real_explicit():
    print('<H1 Title="demo_sin_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sin(x); x=' + str(x) + '">')
        res = m53lib.sin(x); print('math53: ' + m53lib.fmt(res))
        res = slib.sin(x); print(' slib: ' + slib.fmt(res))
        res = dlib.sin(x); print(' dlib: ' + dlib.fmt(res))
        res = elib.sin(x); print(' elib: ' + elib.fmt(res))
        res = qlib.sin(x); print(' qlib: ' + qlib.fmt(res))
        res = olib.sin(x); print(' olib: ' + olib.fmt(res))
        if gui.has_xlcalcnet2:
            res = mlib.sin(x); print(' mreal: ' + mlib.fmt(res))
            res = sflib.sin(x); print('sflib: ' + sflib.fmt(res))
            res = dflib.sin(x); print('dflib: ' + dflib.fmt(res))
            res = eflib.sin(x); print('eflib: ' + eflib.fmt(res))
            res = qflib.sin(x); print('qflib: ' + qflib.fmt(res))
            res = oflib.sin(x); print('oflib: ' + oflib.fmt(res))
            res = mflib.sin(x); print('mflib: ' + mflib.fmt(res))
            res = aflib.sin(x); print('aflib: ' + aflib.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()



try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())











