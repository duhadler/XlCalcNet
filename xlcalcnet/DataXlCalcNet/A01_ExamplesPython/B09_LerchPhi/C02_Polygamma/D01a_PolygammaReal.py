
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_polygamma_real_ctx()
    demo_polygamma_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 3; x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.polygamma(n, x)))
    print('</H1>')


def demo_polygamma_real_ctx():
    print('<H1 Title="demo_polygamma_real_ctx">')
    gui.setdps(90)
    nlist = [2, 3, 4]
    xlist = [-5.1, 8.8]
    for n in nlist:
        for x in xlist:
            print('<H2 Title="polygamma(n, x); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.polygamma(n, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_polygamma_real_explicit():
    print('<H1 Title="demo_polygamma_real_explicit">')
    gui.setdps(90)
    nlist = [2, 3, 4]
    xlist = [-5.1, 8.8]
    for n in nlist:
        for x in xlist:
            print('<H2 Title="polygamma(n, x); x=' + str(x) + '">')
            res = math53.polygamma(n, x); print('math53: ' + math53.fmt(res))
            res = sreal.polygamma(n, x); print(' sreal: ' + sreal.fmt(res))
            res = dreal.polygamma(n, x); print(' dreal: ' + dreal.fmt(res))
            res = ereal.polygamma(n, x); print(' ereal: ' + ereal.fmt(res))
            res = qreal.polygamma(n, x); print(' qreal: ' + qreal.fmt(res))
            res = oreal.polygamma(n, x); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.polygamma(n, x); print(' mreal: ' + mreal.fmt(res))
                res = sflint.polygamma(n, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.polygamma(n, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.polygamma(n, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.polygamma(n, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.polygamma(n, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.polygamma(n, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.polygamma(n, x); print('aflint: ' + aflint.fmt(res))
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











