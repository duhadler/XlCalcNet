
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
    demo_elliptic_rf_cplx_ctx()
    demo_elliptic_rf_cplx_re_im_ctx()
    demo_elliptic_rf_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+2j; z = 1.3+2j;  gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_rf(x, y, z)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+2j; z = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.elliptic_rf(x, y, z))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+2j; z = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.elliptic_rf(x, y, z))))
    print('</H1>')




def demo_elliptic_rf_cplx_ctx():
    print('<H1 Title="elliptic_rf_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    ylist = [1.5+2j, 2.7+2j];
    zlist = [2.9+2j, 5.4+2j];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="elliptic_rf(x, y, z); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.elliptic_rf(x, y, z)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_elliptic_rf_cplx_re_im_ctx():
    print('<H1 Title="elliptic_rf_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    ylist = [1.5+2j, 2.7+2j];
    zlist = [2.9+2j, 5.4+2j];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="Re(elliptic_rf(x, y, z)); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.elliptic_rf(x, y, z)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                print('</H2>')
                print()
                print('<H2 Title="Im(elliptic_rf(x, y, z)); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.elliptic_rf(x, y, z)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_elliptic_rf_cplx_explicit():
    print('<H1 Title="demo_elliptic_rf_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    ylist = [1.5+2j, 2.7+2j];
    zlist = [2.9+2j, 5.4+2j];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="elliptic_rf(x, y, z); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                res = cmath53.elliptic_rf(x, y, z); print('cmath53: ' + cmath53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflintc.elliptic_rf(x, y, z); print('sflintc: ' + sflintc.fmt(res))
                    res = dflintc.elliptic_rf(x, y, z); print('dflintc: ' + dflintc.fmt(res))
                    res = eflintc.elliptic_rf(x, y, z); print('eflintc: ' + eflintc.fmt(res))
                    res = qflintc.elliptic_rf(x, y, z); print('qflintc: ' + qflintc.fmt(res))
                    res = oflintc.elliptic_rf(x, y, z); print('oflintc: ' + oflintc.fmt(res))
                    res = mflintc.elliptic_rf(x, y, z); print('mflintc: ' + mflintc.fmt(res))
                    res = aflintc.elliptic_rf(x, y, z); print('aflintc: ' + aflintc.fmt(res))
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











