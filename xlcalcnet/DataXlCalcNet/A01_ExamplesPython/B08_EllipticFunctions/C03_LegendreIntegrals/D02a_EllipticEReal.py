
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    print('real elliptic_e(k)')
    demo_manual_real()
    demo_elliptic_e_real_ctx()
    demo_elliptic_e_real_elliptic_elicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    k = 0.999; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_e(k)))
    print('</H1>')


def demo_elliptic_e_real_ctx():
    print('<H1 Title="demo_elliptic_e_real_ctx">')
    klist = [0.1, 0.999]; gui.setdps(90)
    for k in klist:
        print('<H2 Title="elliptic_e(k); k=' + str(k) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.elliptic_e(k)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_elliptic_e_real_elliptic_elicit():
    print('<H1 Title="demo_elliptic_e_real_elliptic_elicit">')
    klist = [0.1, 0.999]; gui.setdps(90)
    for k in klist:
        print('<H2 Title="elliptic_e(k); k=' + str(k) + '">')
        res = math53.elliptic_e(k); print('math53: ' + math53.fmt(res))
        res = sreal.elliptic_e(k); print(' sreal: ' + sreal.fmt(res))
        res = dreal.elliptic_e(k); print(' dreal: ' + dreal.fmt(res))
        res = ereal.elliptic_e(k); print(' ereal: ' + ereal.fmt(res))
        res = qreal.elliptic_e(k); print(' qreal: ' + qreal.fmt(res))
        res = oreal.elliptic_e(k); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.elliptic_e(k); print(' mreal: ' + mreal.fmt(res))
            res = sflint.elliptic_e(k); print('sflint: ' + sflint.fmt(res))
            res = dflint.elliptic_e(k); print('dflint: ' + dflint.fmt(res))
            res = eflint.elliptic_e(k); print('eflint: ' + eflint.fmt(res))
            res = qflint.elliptic_e(k); print('qflint: ' + qflint.fmt(res))
            res = oflint.elliptic_e(k); print('oflint: ' + oflint.fmt(res))
            res = mflint.elliptic_e(k); print('mflint: ' + mflint.fmt(res))
            res = aflint.elliptic_e(k); print('aflint: ' + aflint.fmt(res))
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




