
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_coulomb_f_real_ctx()
    demo_coulomb_f_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    l = 5; eta = 2.7; x = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.coulomb_f(l, eta, x)))
    print('</H1>')


def demo_coulomb_f_real_ctx():
    print('<H1 Title="demo_coulomb_f_real_ctx">')
    llist = [5, 8]; gui.setdps(90)
    etalist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_f(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.coulomb_f(l, eta, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_coulomb_f_real_explicit():
    print('<H1 Title="demo_coulomb_f_real_explicit">')
    llist = [5, 8]; gui.setdps(90)
    etalist = [1.5, 2.7];
    xlist = [2.9, 5.4];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_f(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                res = math53.coulomb_f(l, eta, x); print('math53: ' + math53.fmt(res))
#                res = sreal.coulomb_f(l, eta, x); print(' sreal: ' + sreal.fmt(res))
#                res = dreal.coulomb_f(l, eta, x); print(' dreal: ' + dreal.fmt(res))
#                res = ereal.coulomb_f(l, eta, x); print(' ereal: ' + ereal.fmt(res))
#                res = qreal.coulomb_f(l, eta, x); print(' qreal: ' + qreal.fmt(res))
#                res = oreal.coulomb_f(l, eta, x); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
#                    res = mreal.coulomb_f(l, eta, x); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.coulomb_f(l, eta, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.coulomb_f(l, eta, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.coulomb_f(l, eta, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.coulomb_f(l, eta, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.coulomb_f(l, eta, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.coulomb_f(l, eta, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.coulomb_f(l, eta, x); print('aflint: ' + aflint.fmt(res))
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











