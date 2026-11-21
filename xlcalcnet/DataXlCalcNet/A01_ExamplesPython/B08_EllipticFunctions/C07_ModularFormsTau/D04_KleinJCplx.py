
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
    demo_klein_j_cplx_ctx()
    demo_klein_j_cplx_re_im_ctx()
    demo_klein_j_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    tau = 0.1+1.2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.klein_j(tau)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    tau = 0.1+1.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.klein_j(tau))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    tau = 0.1+1.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.klein_j(tau))))
    print('</H1>')




def demo_klein_j_cplx_ctx():
    print('<H1 Title="klein_j_cplx_ctx">')
    taulist = [0.52+2j, 0.2+2j];
    for tau in taulist:
        print('<H2 Title="klein_j(tau); tau=' + str(tau) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.klein_j(tau)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_klein_j_cplx_re_im_ctx():
    print('<H1 Title="klein_j_cplx_re_im_ctx">')
    taulist = [0.22+2j, 0.2+2j];
    for tau in taulist:
        print('<H2 Title="Re(klein_j(tau)); tau=' + str(tau) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.klein_j(tau)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(klein_j(tau)); tau=' + str(tau) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.klein_j(tau)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_klein_j_cplx_explicit():
    print('<H1 Title="demo_klein_j_cplx_explicit">')
    gui.setdps(90)
    taulist = [0.22+2j, 0.2+2j];
    for tau in taulist:
        print('<H2 Title="klein_j(tau); tau=' + str(tau) + '">')
        res = cmath53.klein_j(tau); print('cmath53: ' + cmath53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflintc.klein_j(tau); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.klein_j(tau); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.klein_j(tau); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.klein_j(tau); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.klein_j(tau); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.klein_j(tau); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.klein_j(tau); print('aflintc: ' + aflintc.fmt(res))
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











