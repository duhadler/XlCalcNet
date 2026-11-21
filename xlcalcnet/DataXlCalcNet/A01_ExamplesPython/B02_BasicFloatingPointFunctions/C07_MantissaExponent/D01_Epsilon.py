
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_epsilon()
    demo_epsilon_ctx()
    demo_epsilon_explicit()


def demo_manual_epsilon():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.epsilon()))
    print('</H1>')


def demo_epsilon_ctx():
    print('<H1 Title="demo_epsilon_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.epsilon()
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_epsilon_explicit():
    print('<H1 Title="demo_epsilon_explicit">')
    gui.setdps(90)
    res = math53.epsilon(); print('math53: ' + math53.fmt(res))
    res = sreal.epsilon(); print(' sreal: ' + sreal.fmt(res))
    res = dreal.epsilon(); print(' dreal: ' + dreal.fmt(res))
    res = ereal.epsilon(); print(' ereal: ' + ereal.fmt(res))
    res = qreal.epsilon(); print(' qreal: ' + qreal.fmt(res))
    res = oreal.epsilon(); print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.epsilon(); print(' mreal: ' + mreal.fmt(res))
        res = sflint.epsilon(); print('sflint: ' + sflint.fmt(res))
        res = dflint.epsilon(); print('dflint: ' + dflint.fmt(res))
        res = eflint.epsilon(); print('eflint: ' + eflint.fmt(res))
        res = qflint.epsilon(); print('qflint: ' + qflint.fmt(res))
        res = oflint.epsilon(); print('oflint: ' + oflint.fmt(res))
        res = mflint.epsilon(); print('mflint: ' + mflint.fmt(res))
        res = aflint.epsilon(); print('aflint: ' + aflint.fmt(res))
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











