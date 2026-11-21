
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_coulomb_hminus_real_ctx()
    demo_coulomb_hminus_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    l = 5; eta = 2.7; x = 1.3; gui.setdps(40)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.coulomb_hminus(l, eta, x)))
    print('</H1>')


def demo_coulomb_hminus_real_ctx():
    print('<H1 Title="demo_coulomb_hminus_real_ctx">')
    llist = [5, 8]; gui.setdps(40)
    etalist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_hminus(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.coulomb_hminus(l, eta, x)
                    print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_coulomb_hminus_real_explicit():
    print('<H1 Title="demo_coulomb_hminus_real_explicit">')
    llist = [5, 8]; gui.setdps(40)
    etalist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_hminus(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                res = math53.coulomb_hminus(l, eta, x); print('math53: ' + math53.cplxctx.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflint.coulomb_hminus(l, eta, x); print('sflint: ' + sflint.cplxctx.fmt(res))
                    res = dflint.coulomb_hminus(l, eta, x); print('dflint: ' + dflint.cplxctx.fmt(res))
                    res = eflint.coulomb_hminus(l, eta, x); print('eflint: ' + eflint.cplxctx.fmt(res))
                    res = qflint.coulomb_hminus(l, eta, x); print('qflint: ' + qflint.cplxctx.fmt(res))
                    res = oflint.coulomb_hminus(l, eta, x); print('oflint: ' + oflint.cplxctx.fmt(res))
                    res = mflint.coulomb_hminus(l, eta, x); print('mflint: ' + mflint.cplxctx.fmt(res))
                    res = aflint.coulomb_hminus(l, eta, x); print('aflint: ' + aflint.cplxctx.fmt(res))
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











