
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_hyperg_0f1_real_ctx()
    demo_hyperg_0f1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    b = 5.1; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hyperg_0f1(b, x)))
    print('</H1>')


def demo_hyperg_0f1_real_ctx():
    print('<H1 Title="demo_hyperg_0f1_real_ctx">')
    blist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for b in blist:
        for x in xlist:
            print('<H2 Title="hyperg_0f1(b, x); b=' + str(b) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.hyperg_0f1(b, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hyperg_0f1_real_explicit():
    print('<H1 Title="demo_hyperg_0f1_real_explicit">')
    blist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for b in blist:
        for x in xlist:
            print('<H2 Title="hyperg_0f1(b, x); b=' + str(b) + ' x=' + str(x) + '">')
            res = math53.hyperg_0f1(b, x); print('math53: ' + math53.fmt(res))
            res = sreal.hyperg_0f1(b, x); print(' sreal: ' + sreal.fmt(res))
            res = dreal.hyperg_0f1(b, x); print(' dreal: ' + dreal.fmt(res))
            res = ereal.hyperg_0f1(b, x); print(' ereal: ' + ereal.fmt(res))
            res = qreal.hyperg_0f1(b, x); print(' qreal: ' + qreal.fmt(res))
            res = oreal.hyperg_0f1(b, x); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.hyperg_0f1(b, x); print(' mreal: ' + mreal.fmt(res))
                res = sflint.hyperg_0f1(b, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.hyperg_0f1(b, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.hyperg_0f1(b, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.hyperg_0f1(b, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.hyperg_0f1(b, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.hyperg_0f1(b, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.hyperg_0f1(b, x); print('aflint: ' + aflint.fmt(res))
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











