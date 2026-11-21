
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_zero()
    demo_zero_ctx()
    demo_zero_explicit()


def demo_manual_zero():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.zero))
    print('</H1>')


def demo_zero_ctx():
    print('<H1 Title="demo_zero_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.zero
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_zero_explicit():
    print('<H1 Title="demo_zero_explicit">')
    gui.setdps(90)
    res = math53.zero; print('math53: ' + math53.fmt(res))
    res = sreal.zero; print(' sreal: ' + sreal.fmt(res))
    res = dreal.zero; print(' dreal: ' + dreal.fmt(res))
    res = ereal.zero; print(' ereal: ' + ereal.fmt(res))
    res = qreal.zero; print(' qreal: ' + qreal.fmt(res))
    res = oreal.zero; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.zero; print(' mreal: ' + mreal.fmt(res))
        res = sflint.zero; print('sflint: ' + sflint.fmt(res))
        res = dflint.zero; print('dflint: ' + dflint.fmt(res))
        res = eflint.zero; print('eflint: ' + eflint.fmt(res))
        res = qflint.zero; print('qflint: ' + qflint.fmt(res))
        res = oflint.zero; print('oflint: ' + oflint.fmt(res))
        res = mflint.zero; print('mflint: ' + mflint.fmt(res))
        res = aflint.zero; print('aflint: ' + aflint.fmt(res))
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











