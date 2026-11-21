
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_faddeeva_real_ctx()
    demo_faddeeva_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 1.1; gui.setdps(40)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.faddeeva(x)))
    print('</H1>')


def demo_faddeeva_real_ctx():
    print('<H1 Title="demo_faddeeva_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(40)
    for x in xlist:
        print('<H2 Title="faddeeva(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.faddeeva(x)
            print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_faddeeva_real_explicit():
    print('<H1 Title="demo_faddeeva_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(40)
    for x in xlist:
        print('<H2 Title="faddeeva(x); x=' + str(x) + '">')
        res = math53.faddeeva(x); print('math53: ' + math53.cplxctx.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.faddeeva(x); print('sflint: ' + sflint.cplxctx.fmt(res))
            res = dflint.faddeeva(x); print('dflint: ' + dflint.cplxctx.fmt(res))
            res = eflint.faddeeva(x); print('eflint: ' + eflint.cplxctx.fmt(res))
            res = qflint.faddeeva(x); print('qflint: ' + qflint.cplxctx.fmt(res))
            res = oflint.faddeeva(x); print('oflint: ' + oflint.cplxctx.fmt(res))
            res = mflint.faddeeva(x); print('mflint: ' + mflint.cplxctx.fmt(res))
            res = aflint.faddeeva(x); print('aflint: ' + aflint.cplxctx.fmt(res))
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











