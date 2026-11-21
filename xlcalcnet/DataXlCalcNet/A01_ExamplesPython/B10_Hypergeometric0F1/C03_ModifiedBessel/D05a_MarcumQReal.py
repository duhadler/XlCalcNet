
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_marcum_q_real_ctx()
    demo_marcum_q_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    m = 1; a = 1.5; b = 2.1; gui.setdps(90)
    for ctx in gui.ctxlist_boost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.marcum_q(m, a, b)))
    print('</H1>')


def demo_marcum_q_real_ctx():
    print('<H1 Title="demo_marcum_q_real_ctx">')
    gui.setdps(90)
    mlist = [1, 2, 3, 4]
    alist = [1.5, 2.5, 13.5]
    blist = [2.1, 12.1, 53.5]
    for m in mlist:
        for a in alist:
            for b in blist:
                print('<H2 Title="marcum_q(m, a, b); m=' + str(m) + ' a=' + str(a) + ' b=' + str(b) + '">')
                for ctx in gui.ctxlist_boost_real:
                    res = ctx.marcum_q(m, a, b)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_marcum_q_real_explicit():
    print('<H1 Title="demo_marcum_q_real_explicit">')
    gui.setdps(90)
    mlist = [1, 2, 3, 4]
    alist = [1.5, 2.5, 13.5]
    blist = [2.1, 12.1, 53.5]
    for m in mlist:
        for a in alist:
            for b in blist:
                print('<H2 Title="marcum_q(m, a, b); m=' + str(m) + ' a=' + str(a) + ' b=' + str(b) + '">')
                res = math53.marcum_q(m, a, b); print('math53: ' + math53.fmt(res))
                res = sreal.marcum_q(m, a, b); print(' sreal: ' + sreal.fmt(res))
                res = dreal.marcum_q(m, a, b); print(' dreal: ' + dreal.fmt(res))
                res = ereal.marcum_q(m, a, b); print(' ereal: ' + ereal.fmt(res))
                res = qreal.marcum_q(m, a, b); print(' qreal: ' + qreal.fmt(res))
                res = oreal.marcum_q(m, a, b); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.marcum_q(m, a, b); print(' mreal: ' + mreal.fmt(res))
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











