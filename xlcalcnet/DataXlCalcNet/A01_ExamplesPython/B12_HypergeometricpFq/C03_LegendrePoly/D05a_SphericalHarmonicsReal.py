
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_spherical_y_real_ctx()
    demo_spherical_y_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 7; m = 1; theta = 0.3; phi = 0.4; gui.setdps(40)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.spherical_y(n, m, theta, phi)))
    #for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ', ctx.spherical_y(n, m, theta, phi))
    print('</H1>')


def demo_spherical_y_real_ctx():
    print('<H1 Title="demo_spherical_y_real_ctx">')
    nlist = [7, 9]; gui.setdps(90)
    mlist = [1, 4];
    thetalist = [2.9, 5.4];
    philist = [0.3, 0.2];
    for n in nlist:
        for m in mlist:
            for theta in thetalist:
                for phi in philist:
                    print('<H2 Title="spherical_y(n, m, theta, phi); n=' + str(n) 
                        + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    for ctx in gui.ctxlist_noipm_real:
                        res = ctx.spherical_y(n, m, theta, phi)
                        print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_spherical_y_real_explicit():
    print('<H1 Title="demo_spherical_y_real_explicit">')
    nlist = [7, 9]; gui.setdps(90)
    mlist = [1, 4];
    thetalist = [2.9, 5.4];
    philist = [0.3, 0.2];
    for n in nlist:
        for m in mlist:
            for theta in thetalist:
                for phi in philist:
                    print('<H2 Title="spherical_y(n, m, theta, phi); n=' + str(n) + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    res = math53.spherical_y(n, m, theta, phi); print('math53: ' + math53.cplxctx.fmt(res))
                    res = sreal.spherical_y(n, m, theta, phi); print('math53: ' + sreal.cplxctx.fmt(res))
                    res = dreal.spherical_y(n, m, theta, phi); print('math53: ' + dreal.cplxctx.fmt(res))
                    res = ereal.spherical_y(n, m, theta, phi); print('math53: ' + ereal.cplxctx.fmt(res))
                    res = qreal.spherical_y(n, m, theta, phi); print('math53: ' + qreal.cplxctx.fmt(res))
                    res = oreal.spherical_y(n, m, theta, phi); print('math53: ' + oreal.cplxctx.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = mreal.spherical_y(n, m, theta, phi); print('math53: ' + mreal.cplxctx.fmt(res))
                        res = sflint.spherical_y(n, m, theta, phi); print('sflint: ' + sflint.cplxctx.fmt(res))
                        res = dflint.spherical_y(n, m, theta, phi); print('dflint: ' + dflint.cplxctx.fmt(res))
                        res = eflint.spherical_y(n, m, theta, phi); print('eflint: ' + eflint.cplxctx.fmt(res))
                        res = qflint.spherical_y(n, m, theta, phi); print('qflint: ' + qflint.cplxctx.fmt(res))
                        res = oflint.spherical_y(n, m, theta, phi); print('oflint: ' + oflint.cplxctx.fmt(res))
                        res = mflint.spherical_y(n, m, theta, phi); print('mflint: ' + mflint.cplxctx.fmt(res))
                        res = aflint.spherical_y(n, m, theta, phi); print('aflint: ' + aflint.cplxctx.fmt(res))
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











