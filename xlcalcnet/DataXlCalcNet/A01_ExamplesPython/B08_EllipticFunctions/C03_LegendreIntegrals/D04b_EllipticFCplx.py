
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
    demo_elliptic_f_cplx_ctx()
    demo_elliptic_f_cplx_re_im_ctx()
    demo_elliptic_f_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    phi = 0.75+2j;  k = 0.5+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.elliptic_f(phi, k)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    phi = 0.75+2j;  k = 0.5+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.elliptic_f(phi, k))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    phi = 0.75+2j;  k = 0.5+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.elliptic_f(phi, k))))
    print('</H1>')




def demo_elliptic_f_cplx_ctx():
    print('<H1 Title="elliptic_f_cplx_ctx">')
    philist = [0.75+2j, 0.5+2j]; gui.setdps(50)
    klist = [0.5+2j, 0.2+2j];
    for phi in philist:
        for k in klist:
            print('<H2 Title="elliptic_f(phi, k); phi=' + str(phi) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.elliptic_f(phi, k)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_elliptic_f_cplx_re_im_ctx():
    print('<H1 Title="elliptic_f_cplx_re_im_ctx">')
    philist = [0.75+2j, 0.5+2j]; gui.setdps(90)
    klist = [0.5+2j, 0.2+2j];
    for phi in philist:
        for k in klist:
            print('<H2 Title="Re(elliptic_f(phi, k)); phi=' + str(phi) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.elliptic_f(phi, k)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(elliptic_f(phi, k)); phi=' + str(phi) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.elliptic_f(phi, k)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_elliptic_f_cplx_explicit():
    print('<H1 Title="demo_elliptic_f_cplx_explicit">')
    philist = [0.75+2j, 0.5+2j]; gui.setdps(90)
    klist = [0.5+2j, 0.2+2j];
    for phi in philist:
        for k in klist:
            print('<H2 Title="elliptic_f(phi, k); phi=' + str(phi) + ' k=' + str(k) + '">')
            res = cmath53.elliptic_f(phi, k); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.elliptic_f(phi, k); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.elliptic_f(phi, k); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.elliptic_f(phi, k); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.elliptic_f(phi, k); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.elliptic_f(phi, k); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.elliptic_f(phi, k); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.elliptic_f(phi, k); print('aflintc: ' + aflintc.fmt(res))
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











