
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_e()
    demo_e_ctx()
    demo_e_explicit()


def demo_manual_e():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.e))
    print('</H1>')


def demo_e_ctx():
    print('<H1 Title="demo_e_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.e
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_e_explicit():
    print('<H1 Title="demo_e_explicit">')
    gui.setdps(90)
    res = math53.e; print('math53: ' + math53.fmt(res))
    res = sreal.e; print(' sreal: ' + sreal.fmt(res))
    res = dreal.e; print(' dreal: ' + dreal.fmt(res))
    res = ereal.e; print(' ereal: ' + ereal.fmt(res))
    res = qreal.e; print(' qreal: ' + qreal.fmt(res))
    res = oreal.e; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.e; print(' mreal: ' + mreal.fmt(res))
        res = sflint.e; print('sflint: ' + sflint.fmt(res))
        res = dflint.e; print('dflint: ' + dflint.fmt(res))
        res = eflint.e; print('eflint: ' + eflint.fmt(res))
        res = qflint.e; print('qflint: ' + qflint.fmt(res))
        res = oflint.e; print('oflint: ' + oflint.fmt(res))
        res = mflint.e; print('mflint: ' + mflint.fmt(res))
        res = aflint.e; print('aflint: ' + aflint.fmt(res))
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











