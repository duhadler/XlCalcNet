
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_ln10()
    demo_ln10_ctx()
    demo_ln10_explicit()


def demo_manual_ln10():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.ln10))
    print('</H1>')


def demo_ln10_ctx():
    print('<H1 Title="demo_ln10_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.ln10
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_ln10_explicit():
    print('<H1 Title="demo_ln10_explicit">')
    gui.setdps(90)
    res = math53.ln10; print('math53: ' + math53.fmt(res))
    res = sreal.ln10; print(' sreal: ' + sreal.fmt(res))
    res = dreal.ln10; print(' dreal: ' + dreal.fmt(res))
    res = ereal.ln10; print(' ereal: ' + ereal.fmt(res))
    res = qreal.ln10; print(' qreal: ' + qreal.fmt(res))
    res = oreal.ln10; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.ln10; print(' mreal: ' + mreal.fmt(res))
        res = sflint.ln10; print('sflint: ' + sflint.fmt(res))
        res = dflint.ln10; print('dflint: ' + dflint.fmt(res))
        res = eflint.ln10; print('eflint: ' + eflint.fmt(res))
        res = qflint.ln10; print('qflint: ' + qflint.fmt(res))
        res = oflint.ln10; print('oflint: ' + oflint.fmt(res))
        res = mflint.ln10; print('mflint: ' + mflint.fmt(res))
        res = aflint.ln10; print('aflint: ' + aflint.fmt(res))
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











