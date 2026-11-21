
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_llround_real_ctx()
    demo_llround_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = '-9223372036854775807.2'; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + str(ctx.llround(x)))
    print('</H1>')


def demo_llround_real_ctx():
    print('<H1 Title="demo_rint_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="rint(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.llround(x)
            print(ctx.fmtname + ': ' + str(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_llround_real_explicit():
    print('<H1 Title="demo_rint_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="rint(x); x=' + str(x) + '">')
        res = math53.llround(x); print('math53: ' + math53.fmt(res))
        res = sreal.llround(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.llround(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.llround(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.llround(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.llround(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.llround(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.llround(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.llround(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.llround(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.llround(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.llround(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.llround(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.llround(x); print('aflint: ' + aflint.fmt(res))
        print('</H2>')
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











