
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_catalan()
    demo_catalan_ctx()
    demo_catalan_explicit()


def demo_manual_catalan():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.catalan))
    print('</H1>')


def demo_catalan_ctx():
    print('<H1 Title="demo_catalan_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.catalan
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_catalan_explicit():
    print('<H1 Title="demo_catalan_explicit">')
    gui.setdps(90)
    res = math53.catalan; print('math53: ' + math53.fmt(res))
    res = sreal.catalan; print(' sreal: ' + sreal.fmt(res))
    res = dreal.catalan; print(' dreal: ' + dreal.fmt(res))
    res = ereal.catalan; print(' ereal: ' + ereal.fmt(res))
    res = qreal.catalan; print(' qreal: ' + qreal.fmt(res))
    res = oreal.catalan; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.catalan; print(' mreal: ' + mreal.fmt(res))
        res = sflint.catalan; print('sflint: ' + sflint.fmt(res))
        res = dflint.catalan; print('dflint: ' + dflint.fmt(res))
        res = eflint.catalan; print('eflint: ' + eflint.fmt(res))
        res = qflint.catalan; print('qflint: ' + qflint.fmt(res))
        res = oflint.catalan; print('oflint: ' + oflint.fmt(res))
        res = mflint.catalan; print('mflint: ' + mflint.fmt(res))
        res = aflint.catalan; print('aflint: ' + aflint.fmt(res))
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











