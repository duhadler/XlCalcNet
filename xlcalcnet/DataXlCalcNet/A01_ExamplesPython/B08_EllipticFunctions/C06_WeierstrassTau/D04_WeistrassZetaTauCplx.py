
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
    demo_weierstrass_zeta_t_cplx_ctx()
    demo_weierstrass_zeta_t_cplx_re_im_ctx()
    demo_weierstrass_zeta_t_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = 1.2+2j;  tau = 0.1+1.2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.weierstrass_zeta_t(x, tau)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = 1.2+2j;  tau = 0.1+1.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.weierstrass_zeta_t(x, tau))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = 1.2+2j;  tau = 0.1+1.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.weierstrass_zeta_t(x, tau))))
    print('</H1>')




def demo_weierstrass_zeta_t_cplx_ctx():
    print('<H1 Title="weierstrass_zeta_t_cplx_ctx">')
    xlist = [0.75+2j, 0.51+2j]; gui.setdps(50)
    taulist = [0.52+2j, 0.2+2j];
    for x in xlist:
        for tau in taulist:
            print('<H2 Title="weierstrass_zeta_t(x, tau); x=' + str(x) + ' tau=' + str(tau) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weierstrass_zeta_t(x, tau)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_weierstrass_zeta_t_cplx_re_im_ctx():
    print('<H1 Title="weierstrass_zeta_t_cplx_re_im_ctx">')
    xlist = [0.75+2j, 0.51+2j]; gui.setdps(90)
    taulist = [0.22+2j, 0.2+2j];
    for x in xlist:
        for tau in taulist:
            print('<H2 Title="Re(weierstrass_zeta_t(x, tau)); x=' + str(x) + ' tau=' + str(tau) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weierstrass_zeta_t(x, tau)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(weierstrass_zeta_t(x, tau)); x=' + str(x) + ' tau=' + str(tau) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weierstrass_zeta_t(x, tau)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_weierstrass_zeta_t_cplx_explicit():
    print('<H1 Title="demo_weierstrass_zeta_t_cplx_explicit">')
    xlist = [0.75+2j, 0.51+2j]; gui.setdps(90)
    taulist = [0.22+2j, 0.2+2j];
    for x in xlist:
        for tau in taulist:
            print('<H2 Title="weierstrass_zeta_t(x, tau); x=' + str(x) + ' tau=' + str(tau) + '">')
            res = cmath53.weierstrass_zeta_t(x, tau); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.weierstrass_zeta_t(x, tau); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.weierstrass_zeta_t(x, tau); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.weierstrass_zeta_t(x, tau); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.weierstrass_zeta_t(x, tau); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.weierstrass_zeta_t(x, tau); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.weierstrass_zeta_t(x, tau); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.weierstrass_zeta_t(x, tau); print('aflintc: ' + aflintc.fmt(res))
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











