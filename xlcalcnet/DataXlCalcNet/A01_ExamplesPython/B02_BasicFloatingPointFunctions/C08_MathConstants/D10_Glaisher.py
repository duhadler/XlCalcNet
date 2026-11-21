
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_glaisher()
    demo_glaisher_ctx()
    demo_glaisher_explicit()


def demo_manual_glaisher():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.glaisher))
    print('</H1>')


def demo_glaisher_ctx():
    print('<H1 Title="demo_glaisher_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.glaisher
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_glaisher_explicit():
    print('<H1 Title="demo_glaisher_explicit">')
    gui.setdps(90)
    res = math53.glaisher; print('math53: ' + math53.fmt(res))
    res = sreal.glaisher; print(' sreal: ' + sreal.fmt(res))
    res = dreal.glaisher; print(' dreal: ' + dreal.fmt(res))
    res = ereal.glaisher; print(' ereal: ' + ereal.fmt(res))
    res = qreal.glaisher; print(' qreal: ' + qreal.fmt(res))
    res = oreal.glaisher; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.glaisher; print(' mreal: ' + mreal.fmt(res))
        res = sflint.glaisher; print('sflint: ' + sflint.fmt(res))
        res = dflint.glaisher; print('dflint: ' + dflint.fmt(res))
        res = eflint.glaisher; print('eflint: ' + eflint.fmt(res))
        res = qflint.glaisher; print('qflint: ' + qflint.fmt(res))
        res = oflint.glaisher; print('oflint: ' + oflint.fmt(res))
        res = mflint.glaisher; print('mflint: ' + mflint.fmt(res))
        res = aflint.glaisher; print('aflint: ' + aflint.fmt(res))
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











