
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_atan2_real_ctx()
    demo_atan2_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    y = 5.1; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.atan2(y, x)))
    print('</H1>')


def demo_atan2_real_ctx():
    print('<H1 Title="demo_atan2_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for y in xlist:
        for x in ylist:
            print('<H2 Title="atan2(y, x); y=' + str(y) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.atan2(y, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_atan2_real_explicit():
    print('<H1 Title="demo_atan2_real_explicit">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for y in xlist:
        for x in ylist:
            print('<H2 Title="atan2(y, x); y=' + str(y) + ' x=' + str(x) + '">')
            res = math53.atan2(y, x); print('math53: ' + math53.fmt(res))
            res = sreal.atan2(y, x); print(' sreal: ' + sreal.fmt(res))
            res = dreal.atan2(y, x); print(' dreal: ' + dreal.fmt(res))
            res = ereal.atan2(y, x); print(' ereal: ' + ereal.fmt(res))
            res = qreal.atan2(y, x); print(' qreal: ' + qreal.fmt(res))
            res = oreal.atan2(y, x); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.atan2(y, x); print(' mreal: ' + mreal.fmt(res))
                res = sflint.atan2(y, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.atan2(y, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.atan2(y, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.atan2(y, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.atan2(y, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.atan2(y, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.atan2(y, x); print('aflint: ' + aflint.fmt(res))
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











