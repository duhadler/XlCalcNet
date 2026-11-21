
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_khinchin()
    demo_khinchin_ctx()
    demo_khinchin_explicit()


def demo_manual_khinchin():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.khinchin))
    print('</H1>')


def demo_khinchin_ctx():
    print('<H1 Title="demo_khinchin_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.khinchin
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_khinchin_explicit():
    print('<H1 Title="demo_khinchin_explicit">')
    gui.setdps(90)
    res = math53.khinchin; print('math53: ' + math53.fmt(res))
    res = sreal.khinchin; print(' sreal: ' + sreal.fmt(res))
    res = dreal.khinchin; print(' dreal: ' + dreal.fmt(res))
    res = ereal.khinchin; print(' ereal: ' + ereal.fmt(res))
    res = qreal.khinchin; print(' qreal: ' + qreal.fmt(res))
    res = oreal.khinchin; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.khinchin; print(' mreal: ' + mreal.fmt(res))
        res = sflint.khinchin; print('sflint: ' + sflint.fmt(res))
        res = dflint.khinchin; print('dflint: ' + dflint.fmt(res))
        res = eflint.khinchin; print('eflint: ' + eflint.fmt(res))
        res = qflint.khinchin; print('qflint: ' + qflint.fmt(res))
        res = oflint.khinchin; print('oflint: ' + oflint.fmt(res))
        res = mflint.khinchin; print('mflint: ' + mflint.fmt(res))
        res = aflint.khinchin; print('aflint: ' + aflint.fmt(res))
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











