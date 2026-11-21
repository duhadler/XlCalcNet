
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_imag_real_ctx()
    demo_imag_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.imag(x)))
    print('</H1>')


def demo_imag_real_ctx():
    print('<H1 Title="demo_imag_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="imag(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.imag(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_imag_real_explicit():
    print('<H1 Title="demo_imag_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="imag(x); x=' + str(x) + '">')
        res = math53.imag(x); print('math53: ' + math53.fmt(res))
        res = sreal.imag(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.imag(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.imag(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.imag(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.imag(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.imag(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.imag(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.imag(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.imag(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.imag(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.imag(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.imag(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.imag(x); print('aflint: ' + aflint.fmt(res))
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











