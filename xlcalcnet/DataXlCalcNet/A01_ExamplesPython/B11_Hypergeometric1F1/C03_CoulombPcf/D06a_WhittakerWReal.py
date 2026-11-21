
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_whittaker_w_real_ctx()
    demo_whittaker_w_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    k = 5; m = 2.7; x = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.whittaker_w(k, m, x)))
    print('</H1>')


def demo_whittaker_w_real_ctx():
    print('<H1 Title="demo_whittaker_w_real_ctx">')
    klist = [5, 8]; gui.setdps(90)
    mlist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for k in klist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="whittaker_w(k, m, x); k=' + str(k) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.whittaker_w(k, m, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_whittaker_w_real_explicit():
    print('<H1 Title="demo_whittaker_w_real_explicit">')
    klist = [5, 8]; gui.setdps(90)
    mlist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for k in klist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="whittaker_w(k, m, x); k=' + str(k) + ' m=' + str(m) + ' x=' + str(x) + '">')
                res = math53.whittaker_w(k, m, x); print('math53: ' + math53.fmt(res))
#                res = sreal.whittaker_w(k, m, x); print(' sreal: ' + sreal.fmt(res))
#                res = dreal.whittaker_w(k, m, x); print(' dreal: ' + dreal.fmt(res))
#                res = ereal.whittaker_w(k, m, x); print(' ereal: ' + ereal.fmt(res))
#                res = qreal.whittaker_w(k, m, x); print(' qreal: ' + qreal.fmt(res))
#                res = oreal.whittaker_w(k, m, x); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
#                    res = mreal.whittaker_w(k, m, x); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.whittaker_w(k, m, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.whittaker_w(k, m, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.whittaker_w(k, m, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.whittaker_w(k, m, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.whittaker_w(k, m, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.whittaker_w(k, m, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.whittaker_w(k, m, x); print('aflint: ' + aflint.fmt(res))
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











