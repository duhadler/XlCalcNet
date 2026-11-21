
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_phase_real_ctx()
    demo_phase_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.phase(x)))
    print('</H1>')


def demo_phase_real_ctx():
    print('<H1 Title="demo_phase_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="phase(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.phase(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_phase_real_explicit():
    print('<H1 Title="demo_phase_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="phase(x); x=' + str(x) + '">')
        res = math53.phase(x); print('math53: ' + math53.fmt(res))
        res = sreal.phase(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.phase(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.phase(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.phase(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.phase(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.phase(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.phase(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.phase(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.phase(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.phase(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.phase(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.phase(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.phase(x); print('aflint: ' + aflint.fmt(res))
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











