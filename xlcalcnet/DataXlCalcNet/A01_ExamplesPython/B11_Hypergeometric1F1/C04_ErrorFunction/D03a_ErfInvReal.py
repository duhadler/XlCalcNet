
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_erf_inv_real_ctx()
    demo_erf_inv_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -0.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.erf_inv(x)))
    print('</H1>')


def demo_erf_inv_real_ctx():
    print('<H1 Title="demo_erf_inv_real_ctx">')
    xlist = [-1.0, -0.999, -0.5, 0.0, 0.5, 0.999, 1.0]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="erf_inv(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.erf_inv(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_erf_inv_real_explicit():
    print('<H1 Title="demo_erf_inv_real_explicit">')
    xlist = [-1.0, -0.999, -0.5, 0.0, 0.5, 0.999, 1.0]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="erf_inv(x); x=' + str(x) + '">')
        res = math53.erf_inv(x); print('math53: ' + math53.fmt(res))
        res = sreal.erf_inv(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.erf_inv(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.erf_inv(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.erf_inv(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.erf_inv(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.erf_inv(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.erf_inv(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.erf_inv(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.erf_inv(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.erf_inv(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.erf_inv(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.erf_inv(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.erf_inv(x); print('aflint: ' + aflint.fmt(res))
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











