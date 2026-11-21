
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_neginf()
    demo_neginf_ctx()
    demo_neginf_explicit()


def demo_manual_neginf():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.neginf))
    print('</H1>')


def demo_neginf_ctx():
    print('<H1 Title="demo_neginf_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.neginf
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_neginf_explicit():
    print('<H1 Title="demo_neginf_explicit">')
    gui.setdps(90)
    res = math53.neginf; print('math53: ' + math53.fmt(res))
    res = sreal.neginf; print(' sreal: ' + sreal.fmt(res))
    res = dreal.neginf; print(' dreal: ' + dreal.fmt(res))
    res = ereal.neginf; print(' ereal: ' + ereal.fmt(res))
    res = qreal.neginf; print(' qreal: ' + qreal.fmt(res))
    res = oreal.neginf; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.neginf; print(' mreal: ' + mreal.fmt(res))
        res = sflint.neginf; print('sflint: ' + sflint.fmt(res))
        res = dflint.neginf; print('dflint: ' + dflint.fmt(res))
        res = eflint.neginf; print('eflint: ' + eflint.fmt(res))
        res = qflint.neginf; print('qflint: ' + qflint.fmt(res))
        res = oflint.neginf; print('oflint: ' + oflint.fmt(res))
        res = mflint.neginf; print('mflint: ' + mflint.fmt(res))
        res = aflint.neginf; print('aflint: ' + aflint.fmt(res))
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











