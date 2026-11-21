
# dpm, ipm should use complex for x outside (-1,1)

import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_atanh_real_ctx()
    demo_atanh_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 0.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.atanh(x)))
    print('</H1>')


def demo_atanh_real_ctx():
    print('<H1 Title="demo_atanh_real_ctx">')
    xlist = [0.1, 0.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="atanh(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.atanh(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_atanh_real_explicit():
    print('<H1 Title="demo_atanh_real_explicit">')
    xlist = [0.1, 0.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="atanh(x); x=' + str(x) + '">')
        res = math53.atanh(x); print('math53: ' + math53.fmt(res))
        res = sreal.atanh(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.atanh(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.atanh(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.atanh(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.atanh(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.atanh(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.atanh(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.atanh(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.atanh(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.atanh(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.atanh(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.atanh(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.atanh(x); print('aflint: ' + aflint.fmt(res))
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











