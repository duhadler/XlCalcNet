
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_inf()
    demo_inf_ctx()
    demo_inf_explicit()


def demo_manual_inf():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.inf))
    print('</H1>')


def demo_inf_ctx():
    print('<H1 Title="demo_inf_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.inf
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_inf_explicit():
    print('<H1 Title="demo_inf_explicit">')
    gui.setdps(90)
    res = math53.inf; print('math53: ' + math53.fmt(res))
    res = sreal.inf; print(' sreal: ' + sreal.fmt(res))
    res = dreal.inf; print(' dreal: ' + dreal.fmt(res))
    res = ereal.inf; print(' ereal: ' + ereal.fmt(res))
    res = qreal.inf; print(' qreal: ' + qreal.fmt(res))
    res = oreal.inf; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.inf; print(' mreal: ' + mreal.fmt(res))
        res = sflint.inf; print('sflint: ' + sflint.fmt(res))
        res = dflint.inf; print('dflint: ' + dflint.fmt(res))
        res = eflint.inf; print('eflint: ' + eflint.fmt(res))
        res = qflint.inf; print('qflint: ' + qflint.fmt(res))
        res = oflint.inf; print('oflint: ' + oflint.fmt(res))
        res = mflint.inf; print('mflint: ' + mflint.fmt(res))
        res = aflint.inf; print('aflint: ' + aflint.fmt(res))
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











