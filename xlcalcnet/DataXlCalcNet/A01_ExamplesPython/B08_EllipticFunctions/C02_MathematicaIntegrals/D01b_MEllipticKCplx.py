
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx


def main_tests():
    print('cplx m_elliptic_k(m)')
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_m_elliptic_k_cplx_ctx()
    demo_m_elliptic_k_cplx_re_im_ctx()
    demo_m_elliptic_k_cplx_m_elliptic_klicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    m = -5.1+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.m_elliptic_k(m)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    m = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.m_elliptic_k(m))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    m = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.m_elliptic_k(m))))
    print('</H1>')




def demo_m_elliptic_k_cplx_ctx():
    print('<H1 Title="m_elliptic_k_cplx_ctx">')
    mlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for m in mlist:
        print('<H2 Title="m_elliptic_k(m); m=' + str(m) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.m_elliptic_k(m)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_m_elliptic_k_cplx_re_im_ctx():
    print('<H1 Title="m_elliptic_k_cplx_re_im_ctx">')
    mlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for m in mlist:
        print('<H2 Title="Re(m_elliptic_k(m)); m=' + str(m) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.m_elliptic_k(m)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(m_elliptic_k(m)); m=' + str(m) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.m_elliptic_k(m)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_m_elliptic_k_cplx_m_elliptic_klicit():
    print('<H1 Title="demo_m_elliptic_k_cplx_m_elliptic_klicit">')
    mlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for m in mlist:
        print('<H2 Title="m_elliptic_k(m); m=' + str(m) + '">')
        res = cmath53.m_elliptic_k(m); print('cmath53: ' + cmath53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflintc.m_elliptic_k(m); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.m_elliptic_k(m); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.m_elliptic_k(m); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.m_elliptic_k(m); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.m_elliptic_k(m); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.m_elliptic_k(m); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.m_elliptic_k(m); print('aflintc: ' + aflintc.fmt(res))
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


