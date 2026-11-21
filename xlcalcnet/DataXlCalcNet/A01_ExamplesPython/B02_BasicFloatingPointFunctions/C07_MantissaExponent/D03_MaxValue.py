
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_maxvalue()
    demo_maxvalue_ctx()
    demo_maxvalue_explicit()


def demo_manual_maxvalue():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(40)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.maxvalue()))
    print('</H1>')


def demo_maxvalue_ctx():
    print('<H1 Title="demo_maxvalue_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.maxvalue()
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_maxvalue_explicit():
    print('<H1 Title="demo_maxvalue_explicit">')
    gui.setdps(90)
    res = math53.maxvalue(); print('math53: ' + math53.fmt(res))
    res = sreal.maxvalue(); print(' sreal: ' + sreal.fmt(res))
    res = dreal.maxvalue(); print(' dreal: ' + dreal.fmt(res))
    res = ereal.maxvalue(); print(' ereal: ' + ereal.fmt(res))
    res = qreal.maxvalue(); print(' qreal: ' + qreal.fmt(res))
    res = oreal.maxvalue(); print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.maxvalue(); print(' mreal: ' + mreal.fmt(res))
        res = sflint.maxvalue(); print('sflint: ' + sflint.fmt(res))
        res = dflint.maxvalue(); print('dflint: ' + dflint.fmt(res))
        res = eflint.maxvalue(); print('eflint: ' + eflint.fmt(res))
        res = qflint.maxvalue(); print('qflint: ' + qflint.fmt(res))
        res = oflint.maxvalue(); print('oflint: ' + oflint.fmt(res))
        res = mflint.maxvalue(); print('mflint: ' + mflint.fmt(res))
        res = aflint.maxvalue(); print('aflint: ' + aflint.fmt(res))
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











