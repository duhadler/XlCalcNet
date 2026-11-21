
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_legendre_qlm_real_ctx()
    demo_legendre_qlm_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; m = 3; x = 0.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.legendre_qlm(n, m, x)))
    print('</H1>')


def demo_legendre_qlm_real_ctx():
    print('<H1 Title="demo_legendre_qlm_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [3, 4];
    xlist = [0.9, 0.4];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="legendre_qlm(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.legendre_qlm(n, m, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_legendre_qlm_real_explicit():
    print('<H1 Title="demo_legendre_qlm_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [3, 4];
    xlist = [0.9, 0.4];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="legendre_qlm(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                res = math53.legendre_qlm(n, m, x); print('math53: ' + math53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflint.legendre_qlm(n, m, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.legendre_qlm(n, m, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.legendre_qlm(n, m, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.legendre_qlm(n, m, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.legendre_qlm(n, m, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.legendre_qlm(n, m, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.legendre_qlm(n, m, x); print('aflint: ' + aflint.fmt(res))
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











