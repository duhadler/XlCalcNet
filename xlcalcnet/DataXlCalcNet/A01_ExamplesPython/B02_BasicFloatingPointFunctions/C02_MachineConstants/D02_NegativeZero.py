
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_negzero()
    demo_negzero_ctx()
    demo_negzero_explicit()


def demo_manual_negzero():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.negzero))
    print('</H1>')


def demo_negzero_ctx():
    print('<H1 Title="demo_negzero_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.negzero
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_negzero_explicit():
    print('<H1 Title="demo_negzero_explicit">')
    gui.setdps(90)
    res = math53.negzero; print('math53: ' + math53.fmt(res))
    res = sreal.negzero; print(' sreal: ' + sreal.fmt(res))
    res = dreal.negzero; print(' dreal: ' + dreal.fmt(res))
    res = ereal.negzero; print(' ereal: ' + ereal.fmt(res))
    res = qreal.negzero; print(' qreal: ' + qreal.fmt(res))
    res = oreal.negzero; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.negzero; print(' mreal: ' + mreal.fmt(res))
        res = sflint.negzero; print('sflint: ' + sflint.fmt(res))
        res = dflint.negzero; print('dflint: ' + dflint.fmt(res))
        res = eflint.negzero; print('eflint: ' + eflint.fmt(res))
        res = qflint.negzero; print('qflint: ' + qflint.fmt(res))
        res = oflint.negzero; print('oflint: ' + oflint.fmt(res))
        res = mflint.negzero; print('mflint: ' + mflint.fmt(res))
        res = aflint.negzero; print('aflint: ' + aflint.fmt(res))
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











