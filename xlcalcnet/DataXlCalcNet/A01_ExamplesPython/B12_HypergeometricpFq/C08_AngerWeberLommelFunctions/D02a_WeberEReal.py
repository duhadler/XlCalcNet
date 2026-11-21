
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_weber_e_real_ctx()
    demo_weber_e_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; x = 0.7; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.weber_e(n, x)))
    print('</H1>')


def demo_weber_e_real_ctx():
    print('<H1 Title="demo_weber_e_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    xlist = [0.5, 0.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="weber_e(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.weber_e(n, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_weber_e_real_explicit():
    print('<H1 Title="demo_weber_e_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    xlist = [0.5, 0.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="weber_e(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            res = math53.weber_e(n, x); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.weber_e(n, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.weber_e(n, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.weber_e(n, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.weber_e(n, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.weber_e(n, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.weber_e(n, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.weber_e(n, x); print('aflint: ' + aflint.fmt(res))
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











