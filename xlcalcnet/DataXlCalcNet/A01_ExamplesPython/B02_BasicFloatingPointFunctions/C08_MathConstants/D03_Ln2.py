
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_ln2()
    demo_ln2_ctx()
    demo_ln2_explicit()


def demo_manual_ln2():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.ln2))
    print('</H1>')


def demo_ln2_ctx():
    print('<H1 Title="demo_ln2_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.ln2
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_ln2_explicit():
    print('<H1 Title="demo_ln2_explicit">')
    gui.setdps(90)
    res = math53.ln2; print('math53: ' + math53.fmt(res))
    res = sreal.ln2; print(' sreal: ' + sreal.fmt(res))
    res = dreal.ln2; print(' dreal: ' + dreal.fmt(res))
    res = ereal.ln2; print(' ereal: ' + ereal.fmt(res))
    res = qreal.ln2; print(' qreal: ' + qreal.fmt(res))
    res = oreal.ln2; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.ln2; print(' mreal: ' + mreal.fmt(res))
        res = sflint.ln2; print('sflint: ' + sflint.fmt(res))
        res = dflint.ln2; print('dflint: ' + dflint.fmt(res))
        res = eflint.ln2; print('eflint: ' + eflint.fmt(res))
        res = qflint.ln2; print('qflint: ' + qflint.fmt(res))
        res = oflint.ln2; print('oflint: ' + oflint.fmt(res))
        res = mflint.ln2; print('mflint: ' + mflint.fmt(res))
        res = aflint.ln2; print('aflint: ' + aflint.fmt(res))
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











