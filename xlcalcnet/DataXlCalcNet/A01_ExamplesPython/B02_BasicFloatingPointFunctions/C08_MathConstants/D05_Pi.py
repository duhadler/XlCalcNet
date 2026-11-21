
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_pi()
    demo_pi_ctx()
    demo_pi_explicit()


def demo_manual_pi():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.pi))
    print('</H1>')


def demo_pi_ctx():
    print('<H1 Title="demo_pi_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.pi
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_pi_explicit():
    print('<H1 Title="demo_pi_explicit">')
    gui.setdps(90)
    res = math53.pi; print('math53: ' + math53.fmt(res))
    res = sreal.pi; print(' sreal: ' + sreal.fmt(res))
    res = dreal.pi; print(' dreal: ' + dreal.fmt(res))
    res = ereal.pi; print(' ereal: ' + ereal.fmt(res))
    res = qreal.pi; print(' qreal: ' + qreal.fmt(res))
    res = oreal.pi; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.pi; print(' mreal: ' + mreal.fmt(res))
        res = sflint.pi; print('sflint: ' + sflint.fmt(res))
        res = dflint.pi; print('dflint: ' + dflint.fmt(res))
        res = eflint.pi; print('eflint: ' + eflint.fmt(res))
        res = qflint.pi; print('qflint: ' + qflint.fmt(res))
        res = oflint.pi; print('oflint: ' + oflint.fmt(res))
        res = mflint.pi; print('mflint: ' + mflint.fmt(res))
        res = aflint.pi; print('aflint: ' + aflint.fmt(res))
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











