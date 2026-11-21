
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_owen_t_real_ctx()
    demo_owen_t_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    h = 1.1; a = 4.1; gui.setdps(90)
    for ctx in gui.ctxlist_boost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.owen_t(h, a)))
    print('</H1>')


def demo_owen_t_real_ctx():
    print('<H1 Title="demo_owen_t_real_ctx">')
    hlist = [0.0, 0.5, 0.999, 1.0]; gui.setdps(90)
    alist = [2.0, 3.5]
    for h in hlist:
        for a in alist:
            print('<H2 Title="owen_t(h, a); h=' + str(h) + '">')
            for ctx in gui.ctxlist_boost_real:
                res = ctx.owen_t(h, a)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_owen_t_real_explicit():
    print('<H1 Title="demo_owen_t_real_explicit">')
    hlist = [0.0, 0.5, 0.999, 1.0]; gui.setdps(90)
    alist = [2.0, 3.5]
    for h in hlist:
        for a in alist:
            print('<H2 Title="owen_t(h, a); h=' + str(h) + '">')
            res = math53.owen_t(h, a); print('math53: ' + math53.fmt(res))
            res = sreal.owen_t(h, a); print(' sreal: ' + sreal.fmt(res))
            res = dreal.owen_t(h, a); print(' dreal: ' + dreal.fmt(res))
            res = ereal.owen_t(h, a); print(' ereal: ' + ereal.fmt(res))
            res = qreal.owen_t(h, a); print(' qreal: ' + qreal.fmt(res))
            res = oreal.owen_t(h, a); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.owen_t(h, a); print(' mreal: ' + mreal.fmt(res))
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











