
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_sinpi_real_ctx()
    demo_sinpi_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sinpi(x)))
    print('</H1>')


def demo_sinpi_real_ctx():
    print('<H1 Title="demo_sinpi_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sinpi(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.sinpi(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sinpi_real_explicit():
    print('<H1 Title="demo_sinpi_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sinpi(x); x=' + str(x) + '">')
        res = math53.sinpi(x); print('math53: ' + math53.fmt(res))
        res = sreal.sinpi(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.sinpi(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.sinpi(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.sinpi(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.sinpi(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.sinpi(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.sinpi(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.sinpi(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.sinpi(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.sinpi(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.sinpi(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.sinpi(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.sinpi(x); print('aflint: ' + aflint.fmt(res))
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











