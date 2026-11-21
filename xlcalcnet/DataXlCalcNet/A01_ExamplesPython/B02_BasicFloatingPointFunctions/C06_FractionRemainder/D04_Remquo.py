
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_remquo_real_ctx()
    demo_remquo_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = '7.5'; y = '2.1'; gui.setdps(30)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ', ctx.remquo(x, y))
    print('</H1>')


def demo_remquo_real_ctx():
    print('<H1 Title="demo_remquo_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="remquo(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.remquo(x, y)
                print(ctx.fmtname + ': ', res)
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_remquo_real_explicit():
    print('<H1 Title="demo_remquo_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="remquo(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            res = math53.remquo(x, y); print('math53: ', res)
            res = sreal.remquo(x, y); print(' sreal: ', res)
            res = dreal.remquo(x, y); print(' dreal: ', res)
            res = ereal.remquo(x, y); print(' ereal: ', res)
            res = qreal.remquo(x, y); print(' qreal: ', res)
            res = oreal.remquo(x, y); print(' oreal: ', res)
            if gui.has_xlcalcnet2:
                res = mreal.remquo(x, y); print(' mreal: ', res)
                res = sflint.remquo(x, y); print('sflint: ', res)
                res = dflint.remquo(x, y); print('dflint: ', res)
                res = eflint.remquo(x, y); print('eflint: ', res)
                res = qflint.remquo(x, y); print('qflint: ', res)
                res = oflint.remquo(x, y); print('oflint: ', res)
                res = mflint.remquo(x, y); print('mflint: ', res)
                res = aflint.remquo(x, y); print('aflint: ', res)
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











