
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_elliptic_rj_real_ctx()
    demo_elliptic_rj_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7; z = 1.3; p = 6.4; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_rj(x, y, z, p)))
    print('</H1>')


def demo_elliptic_rj_real_ctx():
    print('<H1 Title="demo_elliptic_rj_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [2.9, 5.4];
    plist = [7.3, 6.2];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                for p in plist:
                    print('<H2 Title="elliptic_rj(x, y, z, p); x=' + str(x) 
                        + ' y=' + str(y) + ' z=' + str(z)  + ' p=' + str(p) + '">')
                    for ctx in gui.ctxlist_noipm_real:
                        res = ctx.elliptic_rj(x, y, z, p)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_elliptic_rj_real_explicit():
    print('<H1 Title="demo_elliptic_rj_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [2.9, 5.4];
    plist = [7.3, 6.2];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                for p in plist:
                    print('<H2 Title="elliptic_rj(x, y, z, p); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z)  + ' p=' + str(p) + '">')
                    res = math53.elliptic_rj(x, y, z, p); print('math53: ' + math53.fmt(res))
                    res = sreal.elliptic_rj(x, y, z, p); print(' sreal: ' + sreal.fmt(res))
                    res = dreal.elliptic_rj(x, y, z, p); print(' dreal: ' + dreal.fmt(res))
                    res = ereal.elliptic_rj(x, y, z, p); print(' ereal: ' + ereal.fmt(res))
                    res = qreal.elliptic_rj(x, y, z, p); print(' qreal: ' + qreal.fmt(res))
                    res = oreal.elliptic_rj(x, y, z, p); print(' oreal: ' + oreal.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = mreal.elliptic_rj(x, y, z, p); print(' mreal: ' + mreal.fmt(res))
                        res = sflint.elliptic_rj(x, y, z, p); print('sflint: ' + sflint.fmt(res))
                        res = dflint.elliptic_rj(x, y, z, p); print('dflint: ' + dflint.fmt(res))
                        res = eflint.elliptic_rj(x, y, z, p); print('eflint: ' + eflint.fmt(res))
                        res = qflint.elliptic_rj(x, y, z, p); print('qflint: ' + qflint.fmt(res))
                        res = oflint.elliptic_rj(x, y, z, p); print('oflint: ' + oflint.fmt(res))
                        res = mflint.elliptic_rj(x, y, z, p); print('mflint: ' + mflint.fmt(res))
                        res = aflint.elliptic_rj(x, y, z, p); print('aflint: ' + aflint.fmt(res))
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











