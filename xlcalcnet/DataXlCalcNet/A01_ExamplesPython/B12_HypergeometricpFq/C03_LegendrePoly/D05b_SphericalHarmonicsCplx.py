
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx


def main_tests():
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_spherical_y_cplx_ctx()
    demo_spherical_y_cplx_re_im_ctx()
    demo_spherical_y_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = 7;  m = 3; theta = 0.3+2j; phi = 0.4+2j;  gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.spherical_y(n, m, theta, phi)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = 7;  m = 3; theta = 0.3+2j; phi = 0.4+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.spherical_y(n, m, theta, phi))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = 7;  m = 3; theta = 0.3+2j; phi = 0.4+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.spherical_y(n, m, theta, phi))))
    print('</H1>')




def demo_spherical_y_cplx_ctx():
    print('<H1 Title="spherical_y_cplx_ctx">')
    nlist = [7, 9, 13]; gui.setdps(50)
    mlist = [1, 4, 6];
    thetalist = [2.9+2j, 5.4+2j];
    philist = [7.3+2j, 6.2+2j];
    for n in nlist:
        for m in mlist:
            for theta in thetalist:
                for phi in philist:
                    print('<H2 Title="spherical_y(n, m, theta, phi); n=' + str(n) 
                        + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.spherical_y(n, m, theta, phi)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_spherical_y_cplx_re_im_ctx():
    print('<H1 Title="spherical_y_cplx_re_im_ctx">')
    nlist = [7, 9, 13]; gui.setdps(90)
    mlist = [1, 4, 6];
    thetalist = [2.9+2j, 5.4+2j];
    philist = [7.3+2j, 6.2+2j];
    for n in nlist:
        for m in mlist:
            for theta in thetalist:
                for phi in philist:
                    print('<H2 Title="Re(spherical_y(n, m, theta, phi)); n=' + str(n) 
                        + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.spherical_y(n, m, theta, phi)
                        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                    print('</H2>')
                    print()
                    print('<H2 Title="Im(spherical_y(n, m, theta, phi)); n=' + str(n) 
                        + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.spherical_y(n, m, theta, phi)
                        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_spherical_y_cplx_explicit():
    print('<H1 Title="demo_spherical_y_cplx_explicit">')
    nlist = [7, 9, 13]; gui.setdps(90)
    mlist = [1, 4, 6];
    thetalist = [2.9+2j, 5.4+2j];
    philist = [7.3+2j, 6.2+2j];
    for n in nlist:
        for m in mlist:
            for theta in thetalist:
                for phi in philist:
                    print('<H2 Title="spherical_y(n, m, theta, phi); n=' + str(n) 
                        + ' m=' + str(m) + ' theta=' + str(theta)  + ' phi=' + str(phi) + '">')
                    res = cmath53.spherical_y(n, m, theta, phi); print('cmath53: ' + cmath53.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = sflintc.spherical_y(n, m, theta, phi); print('sflintc: ' + sflintc.fmt(res))
                        res = dflintc.spherical_y(n, m, theta, phi); print('dflintc: ' + dflintc.fmt(res))
                        res = eflintc.spherical_y(n, m, theta, phi); print('eflintc: ' + eflintc.fmt(res))
                        res = qflintc.spherical_y(n, m, theta, phi); print('qflintc: ' + qflintc.fmt(res))
                        res = oflintc.spherical_y(n, m, theta, phi); print('oflintc: ' + oflintc.fmt(res))
                        res = mflintc.spherical_y(n, m, theta, phi); print('mflintc: ' + mflintc.fmt(res))
                        res = aflintc.spherical_y(n, m, theta, phi); print('aflintc: ' + aflintc.fmt(res))
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











