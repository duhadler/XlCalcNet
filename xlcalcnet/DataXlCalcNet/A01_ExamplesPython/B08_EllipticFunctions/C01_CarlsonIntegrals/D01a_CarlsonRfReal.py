
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_elliptic_rf_real_ctx()
    demo_elliptic_rf_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7; z = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_rf(x, y, z)))
    print('</H1>')


def demo_elliptic_rf_real_ctx():
    print('<H1 Title="demo_elliptic_rf_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [2.9, 5.4];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="elliptic_rf(x, y, z); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                for ctx in gui.ctxlist_noipm_real:
                    res = ctx.elliptic_rf(x, y, z)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_elliptic_rf_real_explicit():
    print('<H1 Title="demo_elliptic_rf_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [2.9, 5.4];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="elliptic_rf(x, y, z); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                res = math53.elliptic_rf(x, y, z); print('math53: ' + math53.fmt(res))
                res = sreal.elliptic_rf(x, y, z); print(' sreal: ' + sreal.fmt(res))
                res = dreal.elliptic_rf(x, y, z); print(' dreal: ' + dreal.fmt(res))
                res = ereal.elliptic_rf(x, y, z); print(' ereal: ' + ereal.fmt(res))
                res = qreal.elliptic_rf(x, y, z); print(' qreal: ' + qreal.fmt(res))
                res = oreal.elliptic_rf(x, y, z); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.elliptic_rf(x, y, z); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.elliptic_rf(x, y, z); print('sflint: ' + sflint.fmt(res))
                    res = dflint.elliptic_rf(x, y, z); print('dflint: ' + dflint.fmt(res))
                    res = eflint.elliptic_rf(x, y, z); print('eflint: ' + eflint.fmt(res))
                    res = qflint.elliptic_rf(x, y, z); print('qflint: ' + qflint.fmt(res))
                    res = oflint.elliptic_rf(x, y, z); print('oflint: ' + oflint.fmt(res))
                    res = mflint.elliptic_rf(x, y, z); print('mflint: ' + mflint.fmt(res))
                    res = aflint.elliptic_rf(x, y, z); print('aflint: ' + aflint.fmt(res))
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











