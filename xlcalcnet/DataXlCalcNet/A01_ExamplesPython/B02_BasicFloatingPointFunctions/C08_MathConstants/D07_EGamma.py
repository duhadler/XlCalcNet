
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_egamma()
    demo_egamma_ctx()
    demo_egamma_explicit()


def demo_manual_egamma():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.egamma))
    print('</H1>')


def demo_egamma_ctx():
    print('<H1 Title="demo_egamma_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.egamma
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_egamma_explicit():
    print('<H1 Title="demo_egamma_explicit">')
    gui.setdps(90)
    res = math53.egamma; print('math53: ' + math53.fmt(res))
    res = sreal.egamma; print(' sreal: ' + sreal.fmt(res))
    res = dreal.egamma; print(' dreal: ' + dreal.fmt(res))
    res = ereal.egamma; print(' ereal: ' + ereal.fmt(res))
    res = qreal.egamma; print(' qreal: ' + qreal.fmt(res))
    res = oreal.egamma; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.egamma; print(' mreal: ' + mreal.fmt(res))
        res = sflint.egamma; print('sflint: ' + sflint.fmt(res))
        res = dflint.egamma; print('dflint: ' + dflint.fmt(res))
        res = eflint.egamma; print('eflint: ' + eflint.fmt(res))
        res = qflint.egamma; print('qflint: ' + qflint.fmt(res))
        res = oflint.egamma; print('oflint: ' + oflint.fmt(res))
        res = mflint.egamma; print('mflint: ' + mflint.fmt(res))
        res = aflint.egamma; print('aflint: ' + aflint.fmt(res))
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











