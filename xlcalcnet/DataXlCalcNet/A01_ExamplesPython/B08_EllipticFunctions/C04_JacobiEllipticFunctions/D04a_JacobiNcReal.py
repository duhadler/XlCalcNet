
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_jacobi_nc_real_ctx()
    demo_jacobi_nc_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; k = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.jacobi_nc(x, k)))
    print('</H1>')


def demo_jacobi_nc_real_ctx():
    print('<H1 Title="demo_jacobi_nc_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    klist = [1.5, 2.7];
    for x in xlist:
        for k in klist:
            print('<H2 Title="jacobi_nc(x, k); x=' + str(x) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.jacobi_nc(x, k)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_jacobi_nc_real_explicit():
    print('<H1 Title="demo_jacobi_nc_real_explicit">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    klist = [1.5, 2.7];
    for x in xlist:
        for k in klist:
            print('<H2 Title="jacobi_nc(x, k); x=' + str(x) + ' k=' + str(k) + '">')
            res = math53.jacobi_nc(x, k); print('math53: ' + math53.fmt(res))
            res = sreal.jacobi_nc(x, k); print(' sreal: ' + sreal.fmt(res))
            res = dreal.jacobi_nc(x, k); print(' dreal: ' + dreal.fmt(res))
            res = ereal.jacobi_nc(x, k); print(' ereal: ' + ereal.fmt(res))
            res = qreal.jacobi_nc(x, k); print(' qreal: ' + qreal.fmt(res))
            res = oreal.jacobi_nc(x, k); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.jacobi_nc(x, k); print(' mreal: ' + mreal.fmt(res))
                res = sflint.jacobi_nc(x, k); print('sflint: ' + sflint.fmt(res))
                res = dflint.jacobi_nc(x, k); print('dflint: ' + dflint.fmt(res))
                res = eflint.jacobi_nc(x, k); print('eflint: ' + eflint.fmt(res))
                res = qflint.jacobi_nc(x, k); print('qflint: ' + qflint.fmt(res))
                res = oflint.jacobi_nc(x, k); print('oflint: ' + oflint.fmt(res))
                res = mflint.jacobi_nc(x, k); print('mflint: ' + mflint.fmt(res))
                res = aflint.jacobi_nc(x, k); print('aflint: ' + aflint.fmt(res))
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











