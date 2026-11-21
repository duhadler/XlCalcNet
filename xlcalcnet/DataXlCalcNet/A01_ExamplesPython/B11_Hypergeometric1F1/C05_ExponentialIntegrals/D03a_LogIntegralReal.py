
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_log_integral_real_ctx()
    demo_log_integral_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 1.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.log_integral(x)))
    print('</H1>')


def demo_log_integral_real_ctx():
    print('<H1 Title="demo_log_integral_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="log_integral(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.log_integral(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_log_integral_real_explicit():
    print('<H1 Title="demo_log_integral_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="log_integral(x); x=' + str(x) + '">')
        res = math53.log_integral(x); print('math53: ' + math53.fmt(res))
        res = sreal.log_integral(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.log_integral(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.log_integral(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.log_integral(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.log_integral(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.log_integral(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.log_integral(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.log_integral(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.log_integral(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.log_integral(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.log_integral(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.log_integral(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.log_integral(x); print('aflint: ' + aflint.fmt(res))
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











