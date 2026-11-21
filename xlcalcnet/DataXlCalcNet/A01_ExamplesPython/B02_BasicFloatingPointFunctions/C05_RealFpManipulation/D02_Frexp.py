
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_frexp_real_ctx()
    demo_frexp_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(30)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ', ctx.frexp(x))
    print('</H1>')


def demo_frexp_real_ctx():
    print('<H1 Title="demo_frexp_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="frexp(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.frexp(x)
            print(ctx.fmtname + ': ', res)
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_frexp_real_explicit():
    print('<H1 Title="demo_frexp_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="frexp(x); x=' + str(x) + '">')
        res = math53.frexp(x); print('math53: ', res)
        res = sreal.frexp(x); print(' sreal: ', res)
        res = dreal.frexp(x); print(' dreal: ', res)
        res = ereal.frexp(x); print(' ereal: ', res)
        res = qreal.frexp(x); print(' qreal: ', res)
        res = oreal.frexp(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.frexp(x); print(' mreal: ', res)
            res = sflint.frexp(x); print('sflint: ', res)
            res = dflint.frexp(x); print('dflint: ', res)
            res = eflint.frexp(x); print('eflint: ', res)
            res = qflint.frexp(x); print('qflint: ', res)
            res = oflint.frexp(x); print('oflint: ', res)
            res = mflint.frexp(x); print('mflint: ', res)
            res = aflint.frexp(x); print('aflint: ', res)
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











