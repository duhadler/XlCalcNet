
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_hyperg_2f1_real_ctx()
    demo_hyperg_2f1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    a = 5.1; b = 2.7; c = 1.3; x = 0.4; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hyperg_2f1(a, b, c, x)))
    print('</H1>')


def demo_hyperg_2f1_real_ctx():
    print('<H1 Title="demo_hyperg_2f1_real_ctx">')
    alist = [5.1, 8.8]; gui.setdps(90)
    blist = [1.5, 2.7];
    clist = [2.9, 5.4];
    xlist = [0.3, 0.2];
    for a in alist:
        for b in blist:
            for c in clist:
                for x in xlist:
                    print('<H2 Title="hyperg_2f1(a, b, c, x); a=' + str(a) 
                        + ' b=' + str(b) + ' c=' + str(c)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noboost_real:
                        res = ctx.hyperg_2f1(a, b, c, x)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_hyperg_2f1_real_explicit():
    print('<H1 Title="demo_hyperg_2f1_real_explicit">')
    alist = [-5.1, 8.8]; gui.setdps(90)
    blist = [1.5, 2.7];
    clist = [2.9, 5.4];
    xlist = [0.3, 0.2];
    for a in alist:
        for b in blist:
            for c in clist:
                for x in xlist:
                    print('<H2 Title="hyperg_2f1(a, b, c, x); a=' + str(a) + ' b=' + str(b) + ' c=' + str(c)  + ' x=' + str(x) + '">')
                    res = math53.hyperg_2f1(a, b, c, x); print('math53: ' + math53.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = sflint.hyperg_2f1(a, b, c, x); print('sflint: ' + sflint.fmt(res))
                        res = dflint.hyperg_2f1(a, b, c, x); print('dflint: ' + dflint.fmt(res))
                        res = eflint.hyperg_2f1(a, b, c, x); print('eflint: ' + eflint.fmt(res))
                        res = qflint.hyperg_2f1(a, b, c, x); print('qflint: ' + qflint.fmt(res))
                        res = oflint.hyperg_2f1(a, b, c, x); print('oflint: ' + oflint.fmt(res))
                        res = mflint.hyperg_2f1(a, b, c, x); print('mflint: ' + mflint.fmt(res))
                        res = aflint.hyperg_2f1(a, b, c, x); print('aflint: ' + aflint.fmt(res))
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











