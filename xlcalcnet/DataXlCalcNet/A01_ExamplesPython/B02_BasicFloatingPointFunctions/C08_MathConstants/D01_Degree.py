
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_degree()
    demo_degree_ctx()
    demo_degree_explicit()


def demo_manual_degree():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.degree))
    print('</H1>')


def demo_degree_ctx():
    print('<H1 Title="demo_degree_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.degree
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_degree_explicit():
    print('<H1 Title="demo_degree_explicit">')
    gui.setdps(90)
    res = math53.degree; print('math53: ' + math53.fmt(res))
    res = sreal.degree; print(' sreal: ' + sreal.fmt(res))
    res = dreal.degree; print(' dreal: ' + dreal.fmt(res))
    res = ereal.degree; print(' ereal: ' + ereal.fmt(res))
    res = qreal.degree; print(' qreal: ' + qreal.fmt(res))
    res = oreal.degree; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.degree; print(' mreal: ' + mreal.fmt(res))
        res = sflint.degree; print('sflint: ' + sflint.fmt(res))
        res = dflint.degree; print('dflint: ' + dflint.fmt(res))
        res = eflint.degree; print('eflint: ' + eflint.fmt(res))
        res = qflint.degree; print('qflint: ' + qflint.fmt(res))
        res = oflint.degree; print('oflint: ' + oflint.fmt(res))
        res = mflint.degree; print('mflint: ' + mflint.fmt(res))
        res = aflint.degree; print('aflint: ' + aflint.fmt(res))
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











