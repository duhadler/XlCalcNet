
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_polar_real_ctx()
    demo_polar_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(35)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ', ctx.polar(x))
    print('</H1>')


def demo_polar_real_ctx():
    print('<H1 Title="demo_polar_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(40)
    for x in xlist:
        print('<H2 Title="polar(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.polar(x)
            print(ctx.fmtname + ': ', res)
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_polar_real_explicit():
    print('<H1 Title="demo_polar_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(40)
    for x in xlist:
        print('<H2 Title="polar(x); x=' + str(x) + '">')
        res = math53.polar(x); print('math53: ', res)
        res = sreal.polar(x); print(' sreal: ', res)
        res = dreal.polar(x); print(' dreal: ', res)
        res = ereal.polar(x); print(' ereal: ', res)
        res = qreal.polar(x); print(' qreal: ', res)
        res = oreal.polar(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.polar(x); print(' mreal: ', res)
            res = sflint.polar(x); print('sflint: ', res)
            res = dflint.polar(x); print('dflint: ', res)
            res = eflint.polar(x); print('eflint: ', res)
            res = qflint.polar(x); print('qflint: ', res)
            res = oflint.polar(x); print('oflint: ', res)
            res = mflint.polar(x); print('mflint: ', res)
            res = aflint.polar(x); print('aflint: ', res)
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











