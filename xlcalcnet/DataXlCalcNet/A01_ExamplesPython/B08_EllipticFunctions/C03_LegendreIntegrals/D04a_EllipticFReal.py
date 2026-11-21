
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_elliptic_f_real_ctx()
    demo_elliptic_f_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    phi = 0.75; k = 0.5; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_f(phi, k)))
    print('</H1>')


def demo_elliptic_f_real_ctx():
    print('<H1 Title="demo_elliptic_f_real_ctx">')
    philist = [0.75, 0.5]; gui.setdps(90)
    klist = [0.5, 0.2];
    for phi in philist:
        for k in klist:
            print('<H2 Title="elliptic_f(phi, k); phi=' + str(phi) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.elliptic_f(phi, k)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_elliptic_f_real_explicit():
    print('<H1 Title="demo_elliptic_f_real_explicit">')
    philist = [0.75, 0.5]; gui.setdps(90)
    klist = [0.5, 0.2];
    for phi in philist:
        for k in klist:
            print('<H2 Title="elliptic_f(phi, k); phi=' + str(phi) + ' k=' + str(k) + '">')
            res = math53.elliptic_f(phi, k); print('math53: ' + math53.fmt(res))
            res = sreal.elliptic_f(phi, k); print(' sreal: ' + sreal.fmt(res))
            res = dreal.elliptic_f(phi, k); print(' dreal: ' + dreal.fmt(res))
            res = ereal.elliptic_f(phi, k); print(' ereal: ' + ereal.fmt(res))
            res = qreal.elliptic_f(phi, k); print(' qreal: ' + qreal.fmt(res))
            res = oreal.elliptic_f(phi, k); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.elliptic_f(phi, k); print(' mreal: ' + mreal.fmt(res))
                res = sflint.elliptic_f(phi, k); print('sflint: ' + sflint.fmt(res))
                res = dflint.elliptic_f(phi, k); print('dflint: ' + dflint.fmt(res))
                res = eflint.elliptic_f(phi, k); print('eflint: ' + eflint.fmt(res))
                res = qflint.elliptic_f(phi, k); print('qflint: ' + qflint.fmt(res))
                res = oflint.elliptic_f(phi, k); print('oflint: ' + oflint.fmt(res))
                res = mflint.elliptic_f(phi, k); print('mflint: ' + mflint.fmt(res))
                res = aflint.elliptic_f(phi, k); print('aflint: ' + aflint.fmt(res))
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











