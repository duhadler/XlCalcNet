
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_lowestvalue()
    demo_lowestvalue_ctx()
    demo_lowestvalue_explicit()


def demo_manual_lowestvalue():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(40)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.lowestvalue()))
    print('</H1>')


def demo_lowestvalue_ctx():
    print('<H1 Title="demo_lowestvalue_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.lowestvalue()
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_lowestvalue_explicit():
    print('<H1 Title="demo_lowestvalue_explicit">')
    gui.setdps(90)
    res = math53.lowestvalue(); print('math53: ' + math53.fmt(res))
    res = sreal.lowestvalue(); print(' sreal: ' + sreal.fmt(res))
    res = dreal.lowestvalue(); print(' dreal: ' + dreal.fmt(res))
    res = ereal.lowestvalue(); print(' ereal: ' + ereal.fmt(res))
    res = qreal.lowestvalue(); print(' qreal: ' + qreal.fmt(res))
    res = oreal.lowestvalue(); print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.lowestvalue(); print(' mreal: ' + mreal.fmt(res))
        res = sflint.lowestvalue(); print('sflint: ' + sflint.fmt(res))
        res = dflint.lowestvalue(); print('dflint: ' + dflint.fmt(res))
        res = eflint.lowestvalue(); print('eflint: ' + eflint.fmt(res))
        res = qflint.lowestvalue(); print('qflint: ' + qflint.fmt(res))
        res = oflint.lowestvalue(); print('oflint: ' + oflint.fmt(res))
        res = mflint.lowestvalue(); print('mflint: ' + mflint.fmt(res))
        res = aflint.lowestvalue(); print('aflint: ' + aflint.fmt(res))
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











