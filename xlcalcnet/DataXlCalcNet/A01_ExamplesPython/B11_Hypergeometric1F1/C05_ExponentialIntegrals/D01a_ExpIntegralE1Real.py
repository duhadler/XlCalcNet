
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_exp_integral_e1_real_ctx()
    demo_exp_integral_e1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 1.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.exp_integral_e1(x)))
    print('</H1>')


def demo_exp_integral_e1_real_ctx():
    print('<H1 Title="demo_exp_integral_e1_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="exp_integral_e1(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.exp_integral_e1(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_exp_integral_e1_real_explicit():
    print('<H1 Title="demo_exp_integral_e1_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="exp_integral_e1(x); x=' + str(x) + '">')
        res = math53.exp_integral_e1(x); print('math53: ' + math53.fmt(res))
        res = sreal.exp_integral_e1(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.exp_integral_e1(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.exp_integral_e1(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.exp_integral_e1(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.exp_integral_e1(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.exp_integral_e1(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.exp_integral_e1(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.exp_integral_e1(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.exp_integral_e1(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.exp_integral_e1(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.exp_integral_e1(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.exp_integral_e1(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.exp_integral_e1(x); print('aflint: ' + aflint.fmt(res))
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











