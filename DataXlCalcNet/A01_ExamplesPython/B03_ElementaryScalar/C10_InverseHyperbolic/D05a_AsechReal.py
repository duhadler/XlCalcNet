
# dpm, ipm: should use complex outside of (0, 1)

import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_asech_real_ctx()
    demo_asech_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 0.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.asech(x)))
    print('</H1>')


def demo_asech_real_ctx():
    print('<H1 Title="demo_asech_real_ctx">')
    xlist = [.1, 0.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="asech(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.asech(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_asech_real_explicit():
    print('<H1 Title="demo_asech_real_explicit">')
    xlist = [0.1, 0.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="asech(x); x=' + str(x) + '">')
        res = math53.asech(x); print('math53: ' + math53.fmt(res))
        res = sreal.asech(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.asech(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.asech(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.asech(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.asech(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.asech(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.asech(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.asech(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.asech(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.asech(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.asech(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.asech(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.asech(x); print('aflint: ' + aflint.fmt(res))
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











