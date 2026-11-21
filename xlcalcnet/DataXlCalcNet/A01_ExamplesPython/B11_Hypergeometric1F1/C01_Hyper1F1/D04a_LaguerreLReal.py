
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_laguerre_l_real_ctx()
    demo_laguerre_l_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; a = 2; x = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.laguerre_l(n, a, x)))
    print('</H1>')


def demo_laguerre_l_real_ctx():
    print('<H1 Title="demo_laguerre_l_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    alist = [1, 7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for a in alist:
            for x in xlist:
                print('<H2 Title="laguerre_l(n, a, x); n=' + str(n) + ' a=' + str(a) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noipm_real:
                    res = ctx.laguerre_l(n, a, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_laguerre_l_real_explicit():
    print('<H1 Title="demo_laguerre_l_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    alist = [1, 7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for a in alist:
            for x in xlist:
                print('<H2 Title="laguerre_l(n, a, x); n=' + str(n) + ' a=' + str(a) + ' x=' + str(x) + '">')
                res = math53.laguerre_l(n, a, x); print('math53: ' + math53.fmt(res))
                res = sreal.laguerre_l(n, a, x); print(' sreal: ' + sreal.fmt(res))
                res = dreal.laguerre_l(n, a, x); print(' dreal: ' + dreal.fmt(res))
                res = ereal.laguerre_l(n, a, x); print(' ereal: ' + ereal.fmt(res))
                res = qreal.laguerre_l(n, a, x); print(' qreal: ' + qreal.fmt(res))
                res = oreal.laguerre_l(n, a, x); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.laguerre_l(n, a, x); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.laguerre_l(n, a, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.laguerre_l(n, a, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.laguerre_l(n, a, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.laguerre_l(n, a, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.laguerre_l(n, a, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.laguerre_l(n, a, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.laguerre_l(n, a, x); print('aflint: ' + aflint.fmt(res))
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











