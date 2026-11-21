
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_gegenbauer_c_real_ctx()
    demo_gegenbauer_c_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; lambda1 = 2.7; x = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.gegenbauer_c(n, lambda1, x)))
    print('</H1>')


def demo_gegenbauer_c_real_ctx():
    print('<H1 Title="demo_gegenbauer_c_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    lambda1list = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for lambda1 in lambda1list:
            for x in xlist:
                print('<H2 Title="gegenbauer_c(n, lambda1, x); n=' + str(n) + ' lambda1=' + str(lambda1) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noipm_real:
                    res = ctx.gegenbauer_c(n, lambda1, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_gegenbauer_c_real_explicit():
    print('<H1 Title="demo_gegenbauer_c_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    lambda1list = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for lambda1 in lambda1list:
            for x in xlist:
                print('<H2 Title="gegenbauer_c(n, lambda1, x); n=' + str(n) + ' lambda1=' + str(lambda1) + ' x=' + str(x) + '">')
                res = math53.gegenbauer_c(n, lambda1, x); print('math53: ' + math53.fmt(res))
                res = sreal.gegenbauer_c(n, lambda1, x); print(' sreal: ' + sreal.fmt(res))
                res = dreal.gegenbauer_c(n, lambda1, x); print(' dreal: ' + dreal.fmt(res))
                res = ereal.gegenbauer_c(n, lambda1, x); print(' ereal: ' + ereal.fmt(res))
                res = qreal.gegenbauer_c(n, lambda1, x); print(' qreal: ' + qreal.fmt(res))
                res = oreal.gegenbauer_c(n, lambda1, x); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.gegenbauer_c(n, lambda1, x); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.gegenbauer_c(n, lambda1, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.gegenbauer_c(n, lambda1, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.gegenbauer_c(n, lambda1, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.gegenbauer_c(n, lambda1, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.gegenbauer_c(n, lambda1, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.gegenbauer_c(n, lambda1, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.gegenbauer_c(n, lambda1, x); print('aflint: ' + aflint.fmt(res))
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











