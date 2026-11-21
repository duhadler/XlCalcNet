
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_hypot_real_ctx()
    demo_hypot_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hypot(x, y)))
    print('</H1>')


def demo_hypot_real_ctx():
    print('<H1 Title="demo_hypot_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="hypot(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.hypot(x, y)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hypot_real_explicit():
    print('<H1 Title="demo_hypot_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="hypot(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            res = math53.hypot(x, y); print('math53: ' + math53.fmt(res))
            res = sreal.hypot(x, y); print(' sreal: ' + sreal.fmt(res))
            res = dreal.hypot(x, y); print(' dreal: ' + dreal.fmt(res))
            res = ereal.hypot(x, y); print(' ereal: ' + ereal.fmt(res))
            res = qreal.hypot(x, y); print(' qreal: ' + qreal.fmt(res))
            res = oreal.hypot(x, y); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.hypot(x, y); print(' mreal: ' + mreal.fmt(res))
                res = sflint.hypot(x, y); print('sflint: ' + sflint.fmt(res))
                res = dflint.hypot(x, y); print('dflint: ' + dflint.fmt(res))
                res = eflint.hypot(x, y); print('eflint: ' + eflint.fmt(res))
                res = qflint.hypot(x, y); print('qflint: ' + qflint.fmt(res))
                res = oflint.hypot(x, y); print('oflint: ' + oflint.fmt(res))
                res = mflint.hypot(x, y); print('mflint: ' + mflint.fmt(res))
                res = aflint.hypot(x, y); print('aflint: ' + aflint.fmt(res))
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


