
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx


def main_tests():
    print('cplx zeta_zero(n)')
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_zeta_zero_cplx_ctx()
    demo_zeta_zero_cplx_re_im_ctx()
    demo_zeta_zero_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = 4; gui.setdps(40)
    for ctx in [fpm, mpm]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.zeta_zero(n)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = 4; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.zeta_zero(n))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = 4; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.zeta_zero(n))))
    print('</H1>')




def demo_zeta_zero_cplx_ctx():
    print('<H1 Title="zeta_zero_cplx_ctx">')
    nlist = [1, 2, 3, 4]; gui.setdps(50)
    for n in nlist:
        print('<H2 Title="zeta_zero(n); n=' + str(n) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.zeta_zero(n)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_zeta_zero_cplx_re_im_ctx():
    print('<H1 Title="zeta_zero_cplx_re_im_ctx">')
    nlist = [1, 2, 3, 4]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="Re(zeta_zero(n)); n=' + str(n) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.zeta_zero(n)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(zeta_zero(n)); n=' + str(n) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.zeta_zero(n)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_zeta_zero_cplx_explicit():
    print('<H1 Title="demo_zeta_zero_cplx_zeta_zerolicit">')
    nlist = [1, 2, 3, 4]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="zeta_zero(n); n=' + str(n) + '">')
        res = cmath53.zeta_zero(n); print('cmath53: ' + cmath53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflintc.zeta_zero(n); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.zeta_zero(n); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.zeta_zero(n); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.zeta_zero(n); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.zeta_zero(n); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.zeta_zero(n); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.zeta_zero(n); print('aflintc: ' + aflintc.fmt(res))
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

