
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_one()
    demo_one_ctx()
    demo_one_explicit()


def demo_manual_one():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.one))
    print('</H1>')


def demo_one_ctx():
    print('<H1 Title="demo_one_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.one
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_one_explicit():
    print('<H1 Title="demo_one_explicit">')
    gui.setdps(90)
    res = math53.one; print('math53: ' + math53.fmt(res))
    res = sreal.one; print(' sreal: ' + sreal.fmt(res))
    res = dreal.one; print(' dreal: ' + dreal.fmt(res))
    res = ereal.one; print(' ereal: ' + ereal.fmt(res))
    res = qreal.one; print(' qreal: ' + qreal.fmt(res))
    res = oreal.one; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.one; print(' mreal: ' + mreal.fmt(res))
        res = sflint.one; print('sflint: ' + sflint.fmt(res))
        res = dflint.one; print('dflint: ' + dflint.fmt(res))
        res = eflint.one; print('eflint: ' + eflint.fmt(res))
        res = qflint.one; print('qflint: ' + qflint.fmt(res))
        res = oflint.one; print('oflint: ' + oflint.fmt(res))
        res = mflint.one; print('mflint: ' + mflint.fmt(res))
        res = aflint.one; print('aflint: ' + aflint.fmt(res))
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











