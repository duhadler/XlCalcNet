
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_jacobi_theta4_real_ctx()
    demo_jacobi_theta4_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -1.5; q = 0.5; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.jacobi_theta4(x, q)))
    print('</H1>')


def demo_jacobi_theta4_real_ctx():
    print('<H1 Title="demo_jacobi_theta4_real_ctx">')
    xlist = [-1.5, 1.5]; gui.setdps(90)
    qlist = [0.5, 0.9];
    for x in xlist:
        for q in qlist:
            print('<H2 Title="jacobi_theta4(x, q); x=' + str(x) + ' q=' + str(q) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.jacobi_theta4(x, q)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_jacobi_theta4_real_explicit():
    print('<H1 Title="demo_jacobi_theta4_real_explicit">')
    xlist = [-1.5, 1.5]; gui.setdps(90)
    qlist = [0.5, 0.9];
    for x in xlist:
        for q in qlist:
            print('<H2 Title="jacobi_theta4(x, q); x=' + str(x) + ' q=' + str(q) + '">')
            res = math53.jacobi_theta4(x, q); print('math53: ' + math53.fmt(res))
            res = sreal.jacobi_theta4(x, q); print(' sreal: ' + sreal.fmt(res))
            res = dreal.jacobi_theta4(x, q); print(' dreal: ' + dreal.fmt(res))
            res = ereal.jacobi_theta4(x, q); print(' ereal: ' + ereal.fmt(res))
            res = qreal.jacobi_theta4(x, q); print(' qreal: ' + qreal.fmt(res))
            res = oreal.jacobi_theta4(x, q); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.jacobi_theta4(x, q); print(' mreal: ' + mreal.fmt(res))
                res = sflint.jacobi_theta4(x, q); print('sflint: ' + sflint.fmt(res))
                res = dflint.jacobi_theta4(x, q); print('dflint: ' + dflint.fmt(res))
                res = eflint.jacobi_theta4(x, q); print('eflint: ' + eflint.fmt(res))
                res = qflint.jacobi_theta4(x, q); print('qflint: ' + qflint.fmt(res))
                res = oflint.jacobi_theta4(x, q); print('oflint: ' + oflint.fmt(res))
                res = mflint.jacobi_theta4(x, q); print('mflint: ' + mflint.fmt(res))
                res = aflint.jacobi_theta4(x, q); print('aflint: ' + aflint.fmt(res))
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











