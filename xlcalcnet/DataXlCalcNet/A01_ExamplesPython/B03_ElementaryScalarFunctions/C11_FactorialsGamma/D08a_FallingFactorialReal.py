
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_falling_factorial_real_ctx()
    demo_falling_factorial_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.falling_factorial(x, y)))
    print('</H1>')


def demo_falling_factorial_real_ctx():
    print('<H1 Title="demo_falling_factorial_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="falling_factorial(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.falling_factorial(x, y)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_falling_factorial_real_explicit():
    print('<H1 Title="demo_falling_factorial_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="falling_factorial(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            res = math53.falling_factorial(x, y); print('math53: ' + math53.fmt(res))
            res = sreal.falling_factorial(x, y); print(' sreal: ' + sreal.fmt(res))
            res = dreal.falling_factorial(x, y); print(' dreal: ' + dreal.fmt(res))
            res = ereal.falling_factorial(x, y); print(' ereal: ' + ereal.fmt(res))
            res = qreal.falling_factorial(x, y); print(' qreal: ' + qreal.fmt(res))
            res = oreal.falling_factorial(x, y); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.falling_factorial(x, y); print(' mreal: ' + mreal.fmt(res))
                res = sflint.falling_factorial(x, y); print('sflint: ' + sflint.fmt(res))
                res = dflint.falling_factorial(x, y); print('dflint: ' + dflint.fmt(res))
                res = eflint.falling_factorial(x, y); print('eflint: ' + eflint.fmt(res))
                res = qflint.falling_factorial(x, y); print('qflint: ' + qflint.fmt(res))
                res = oflint.falling_factorial(x, y); print('oflint: ' + oflint.fmt(res))
                res = mflint.falling_factorial(x, y); print('mflint: ' + mflint.fmt(res))
                res = aflint.falling_factorial(x, y); print('aflint: ' + aflint.fmt(res))
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











