
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_ilogb_real_ctx()
    demo_ilogb_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(30)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ', ctx.ilogb(x))
    print('</H1>')


def demo_ilogb_real_ctx():
    print('<H1 Title="demo_ilogb_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="ilogb(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.ilogb(x)
            print(ctx.fmtname + ': ', res)
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_ilogb_real_explicit():
    print('<H1 Title="demo_ilogb_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="ilogb(x); x=' + str(x) + '">')
        res = math53.ilogb(x); print('math53: ', res)
        res = sreal.ilogb(x); print(' sreal: ', res)
        res = dreal.ilogb(x); print(' dreal: ', res)
        res = ereal.ilogb(x); print(' ereal: ', res)
        res = qreal.ilogb(x); print(' qreal: ', res)
        res = oreal.ilogb(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.ilogb(x); print(' mreal: ', res)
            res = sflint.ilogb(x); print('sflint: ', res)
            res = dflint.ilogb(x); print('dflint: ', res)
            res = eflint.ilogb(x); print('eflint: ', res)
            res = qflint.ilogb(x); print('qflint: ', res)
            res = oflint.ilogb(x); print('oflint: ', res)
            res = mflint.ilogb(x); print('mflint: ', res)
            res = aflint.ilogb(x); print('aflint: ', res)
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











