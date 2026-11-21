
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_apery()
    demo_apery_ctx()
    demo_apery_explicit()


def demo_manual_apery():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.apery))
    print('</H1>')


def demo_apery_ctx():
    print('<H1 Title="demo_apery_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.apery
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_apery_explicit():
    print('<H1 Title="demo_apery_explicit">')
    gui.setdps(90)
    res = math53.apery; print('math53: ' + math53.fmt(res))
    res = sreal.apery; print(' sreal: ' + sreal.fmt(res))
    res = dreal.apery; print(' dreal: ' + dreal.fmt(res))
    res = ereal.apery; print(' ereal: ' + ereal.fmt(res))
    res = qreal.apery; print(' qreal: ' + qreal.fmt(res))
    res = oreal.apery; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.apery; print(' mreal: ' + mreal.fmt(res))
        res = sflint.apery; print('sflint: ' + sflint.fmt(res))
        res = dflint.apery; print('dflint: ' + dflint.fmt(res))
        res = eflint.apery; print('eflint: ' + eflint.fmt(res))
        res = qflint.apery; print('qflint: ' + qflint.fmt(res))
        res = oflint.apery; print('oflint: ' + oflint.fmt(res))
        res = mflint.apery; print('mflint: ' + mflint.fmt(res))
        res = aflint.apery; print('aflint: ' + aflint.fmt(res))
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











