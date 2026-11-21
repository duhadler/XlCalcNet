
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_binomial_real_ctx()
    demo_binomial_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.binomial(x, y)))
    print('</H1>')


def demo_binomial_real_ctx():
    print('<H1 Title="demo_binomial_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="binomial(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.binomial(x, y)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_binomial_real_explicit():
    print('<H1 Title="demo_binomial_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="binomial(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            res = math53.binomial(x, y); print('math53: ' + math53.fmt(res))
            res = sreal.binomial(x, y); print(' sreal: ' + sreal.fmt(res))
            res = dreal.binomial(x, y); print(' dreal: ' + dreal.fmt(res))
            res = ereal.binomial(x, y); print(' ereal: ' + ereal.fmt(res))
            res = qreal.binomial(x, y); print(' qreal: ' + qreal.fmt(res))
            res = oreal.binomial(x, y); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.binomial(x, y); print(' mreal: ' + mreal.fmt(res))
                res = sflint.binomial(x, y); print('sflint: ' + sflint.fmt(res))
                res = dflint.binomial(x, y); print('dflint: ' + dflint.fmt(res))
                res = eflint.binomial(x, y); print('eflint: ' + eflint.fmt(res))
                res = qflint.binomial(x, y); print('qflint: ' + qflint.fmt(res))
                res = oflint.binomial(x, y); print('oflint: ' + oflint.fmt(res))
                res = mflint.binomial(x, y); print('mflint: ' + mflint.fmt(res))
                res = aflint.binomial(x, y); print('aflint: ' + aflint.fmt(res))
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











