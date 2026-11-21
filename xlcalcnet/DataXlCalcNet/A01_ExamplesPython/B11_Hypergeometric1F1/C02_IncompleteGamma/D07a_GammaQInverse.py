
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_gamma_q_inv_real_ctx()
    demo_gamma_q_inv_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    a = 5.1; q = 0.7; gui.setdps(90)
    for ctx in gui.ctxlist_boost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.gamma_q_inv(a, q)))
    print('</H1>')


def demo_gamma_q_inv_real_ctx():
    print('<H1 Title="demo_gamma_q_inv_real_ctx">')
    alist = [5.1, 8.8]; gui.setdps(90)
    qlist = [0.25, 0.75];
    for a in alist:
        for q in qlist:
            print('<H2 Title="gamma_q_inv(a, q); a=' + str(a) + ' q=' + str(q) + '">')
            for ctx in gui.ctxlist_boost_real:
                res = ctx.gamma_q_inv(a, q)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_gamma_q_inv_real_explicit():
    print('<H1 Title="demo_gamma_q_inv_real_explicit">')
    alist = [5.1, 8.8]; gui.setdps(90)
    qlist = [0.25, 0.75];
    for a in alist:
        for q in qlist:
            print('<H2 Title="gamma_q_inv(a, q); a=' + str(a) + ' q=' + str(q) + '">')
            res = math53.gamma_q_inv(a, q); print('math53: ' + math53.fmt(res))
            res = sreal.gamma_q_inv(a, q); print(' sreal: ' + sreal.fmt(res))
            res = dreal.gamma_q_inv(a, q); print(' dreal: ' + dreal.fmt(res))
            res = ereal.gamma_q_inv(a, q); print(' ereal: ' + ereal.fmt(res))
            res = qreal.gamma_q_inv(a, q); print(' qreal: ' + qreal.fmt(res))
            res = oreal.gamma_q_inv(a, q); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.gamma_q_inv(a, q); print(' mreal: ' + mreal.fmt(res))
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











