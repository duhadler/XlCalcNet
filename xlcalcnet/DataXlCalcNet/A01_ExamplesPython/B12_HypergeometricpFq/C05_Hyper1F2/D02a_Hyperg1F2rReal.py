
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_hyperg_1f2r_real_ctx()
    demo_hyperg_1f2r_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    a = 1.5; b1 = 7.1; b2 = 5.1; x = -1.5; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hyperg_1f2r(a, b1, b2, x)))
    print('</H1>')


def demo_hyperg_1f2r_real_ctx():
    print('<H1 Title="demo_hyperg_1f2r_real_ctx">')
    alist = [1.5, 2.5, 3.5]; gui.setdps(90)
    b1list = [7.1, 12.1, 53.5];
    b2list = [5.1, 8.1, 29.5];
    xlist = [-1.5, 0.0, 0.5, 2.5];
    for a in alist:
        for b1 in b1list:
            for b2 in b2list:
                for x in xlist:
                    print('<H2 Title="hyperg_1f2r(a, b1, b2, x); a=' + str(a) 
                        + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noboost_real:
                        res = ctx.hyperg_1f2r(a, b1, b2, x)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_hyperg_1f2r_real_explicit():
    print('<H1 Title="demo_hyperg_1f2r_real_explicit">')
    alist = [1.5, 2.5, 3.5]; gui.setdps(90)
    b1list = [7.1, 12.1, 53.5];
    b2list = [5.1, 8.1, 29.5];
    xlist = [-1.5, 0.0, 0.5, 2.5];
    for a in alist:
        for b1 in b1list:
            for b2 in b2list:
                for x in xlist:
                    print('<H2 Title="hyperg_1f2r(a, b1, b2, x); a=' + str(a) + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    res = math53.hyperg_1f2r(a, b1, b2, x); print('math53: ' + math53.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = sflint.hyperg_1f2r(a, b1, b2, x); print('sflint: ' + sflint.fmt(res))
                        res = dflint.hyperg_1f2r(a, b1, b2, x); print('dflint: ' + dflint.fmt(res))
                        res = eflint.hyperg_1f2r(a, b1, b2, x); print('eflint: ' + eflint.fmt(res))
                        res = qflint.hyperg_1f2r(a, b1, b2, x); print('qflint: ' + qflint.fmt(res))
                        res = oflint.hyperg_1f2r(a, b1, b2, x); print('oflint: ' + oflint.fmt(res))
                        res = mflint.hyperg_1f2r(a, b1, b2, x); print('mflint: ' + mflint.fmt(res))
                        res = aflint.hyperg_1f2r(a, b1, b2, x); print('aflint: ' + aflint.fmt(res))
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











