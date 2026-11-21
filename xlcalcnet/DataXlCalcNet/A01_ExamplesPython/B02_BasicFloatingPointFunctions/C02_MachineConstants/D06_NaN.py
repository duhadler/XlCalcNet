
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_nan()
    demo_nan_ctx()
    demo_nan_explicit()


def demo_manual_nan():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.nan))
    print('</H1>')


def demo_nan_ctx():
    print('<H1 Title="demo_nan_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.nan
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_nan_explicit():
    print('<H1 Title="demo_nan_explicit">')
    gui.setdps(90)
    res = math53.nan; print('math53: ' + math53.fmt(res))
    res = sreal.nan; print(' sreal: ' + sreal.fmt(res))
    res = dreal.nan; print(' dreal: ' + dreal.fmt(res))
    res = ereal.nan; print(' ereal: ' + ereal.fmt(res))
    res = qreal.nan; print(' qreal: ' + qreal.fmt(res))
    res = oreal.nan; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.nan; print(' mreal: ' + mreal.fmt(res))
        res = sflint.nan; print('sflint: ' + sflint.fmt(res))
        res = dflint.nan; print('dflint: ' + dflint.fmt(res))
        res = eflint.nan; print('eflint: ' + eflint.fmt(res))
        res = qflint.nan; print('qflint: ' + qflint.fmt(res))
        res = oflint.nan; print('oflint: ' + oflint.fmt(res))
        res = mflint.nan; print('mflint: ' + mflint.fmt(res))
        res = aflint.nan; print('aflint: ' + aflint.fmt(res))
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











