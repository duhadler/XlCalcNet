
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_modf_real_ctx()
    demo_modf_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(30)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ', ctx.modf(x))
    print('</H1>')


def demo_modf_real_ctx():
    print('<H1 Title="demo_modf_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(30)
    for x in xlist:
        print('<H2 Title="modf(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.modf(x)
            print(ctx.fmtname + ': ', res)
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_modf_real_explicit():
    print('<H1 Title="demo_modf_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="modf(x); x=' + str(x) + '">')
        res = math53.modf(x); print('math53: ', res)
        res = sreal.modf(x); print(' sreal: ', res)
        res = dreal.modf(x); print(' dreal: ', res)
        res = ereal.modf(x); print(' ereal: ', res)
        res = qreal.modf(x); print(' qreal: ', res)
        res = oreal.modf(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.modf(x); print(' mreal: ', res)
            res = sflint.modf(x); print('sflint: ', res)
            res = dflint.modf(x); print('dflint: ', res)
            res = eflint.modf(x); print('eflint: ', res)
            res = qflint.modf(x); print('qflint: ', res)
            res = oflint.modf(x); print('oflint: ', res)
            res = mflint.modf(x); print('mflint: ', res)
            res = aflint.modf(x); print('aflint: ', res)
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











