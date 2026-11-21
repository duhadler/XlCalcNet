
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_minposvalue()
    demo_minposvalue_ctx()
    demo_minposvalue_explicit()


def demo_manual_minposvalue():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(40)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.minposvalue()))
    print('</H1>')


def demo_minposvalue_ctx():
    print('<H1 Title="demo_minposvalue_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.minposvalue()
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_minposvalue_explicit():
    print('<H1 Title="demo_minposvalue_explicit">')
    gui.setdps(90)
    res = math53.minposvalue(); print('math53: ' + math53.fmt(res))
    res = sreal.minposvalue(); print(' sreal: ' + sreal.fmt(res))
    res = dreal.minposvalue(); print(' dreal: ' + dreal.fmt(res))
    res = ereal.minposvalue(); print(' ereal: ' + ereal.fmt(res))
    res = qreal.minposvalue(); print(' qreal: ' + qreal.fmt(res))
    res = oreal.minposvalue(); print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.minposvalue(); print(' mreal: ' + mreal.fmt(res))
        res = sflint.minposvalue(); print('sflint: ' + sflint.fmt(res))
        res = dflint.minposvalue(); print('dflint: ' + dflint.fmt(res))
        res = eflint.minposvalue(); print('eflint: ' + eflint.fmt(res))
        res = qflint.minposvalue(); print('qflint: ' + qflint.fmt(res))
        res = oflint.minposvalue(); print('oflint: ' + oflint.fmt(res))
        res = mflint.minposvalue(); print('mflint: ' + mflint.fmt(res))
        res = aflint.minposvalue(); print('aflint: ' + aflint.fmt(res))
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











