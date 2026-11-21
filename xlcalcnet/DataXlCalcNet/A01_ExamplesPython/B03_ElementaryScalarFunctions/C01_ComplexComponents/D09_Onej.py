
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_onej()
    demo_onej_ctx()
    demo_onej_explicit()


def demo_manual_onej():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.onej))
    print('</H1>')


def demo_onej_ctx():
    print('<H1 Title="demo_onej_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.onej
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_onej_explicit():
    print('<H1 Title="demo_onej_explicit">')
    gui.setdps(90)
    res = math53.onej; print('math53: ' + math53.fmt(res))
    res = sreal.onej; print(' sreal: ' + sreal.fmt(res))
    res = dreal.onej; print(' dreal: ' + dreal.fmt(res))
    res = ereal.onej; print(' ereal: ' + ereal.fmt(res))
    res = qreal.onej; print(' qreal: ' + qreal.fmt(res))
    res = oreal.onej; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.onej; print(' mreal: ' + mreal.fmt(res))
        res = sflint.onej; print('sflint: ' + sflint.fmt(res))
        res = dflint.onej; print('dflint: ' + dflint.fmt(res))
        res = eflint.onej; print('eflint: ' + eflint.fmt(res))
        res = qflint.onej; print('qflint: ' + qflint.fmt(res))
        res = oflint.onej; print('oflint: ' + oflint.fmt(res))
        res = mflint.onej; print('mflint: ' + mflint.fmt(res))
        res = aflint.onej; print('aflint: ' + aflint.fmt(res))
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











