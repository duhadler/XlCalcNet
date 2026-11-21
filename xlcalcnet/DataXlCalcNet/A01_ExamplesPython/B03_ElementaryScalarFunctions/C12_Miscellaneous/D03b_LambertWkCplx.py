
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
    demo_lambert_wk_cplx_ctx()
    demo_lambert_wk_cplx_re_im_ctx()
    demo_lambert_wk_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j;  k = 3; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.lambert_wk(x, k)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  k = 3; gui.setdps(50)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.lambert_wk(x, k))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  k = 3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.lambert_wk(x, k))))
    print('</H1>')




def demo_lambert_wk_cplx_ctx():
    print('<H1 Title="pow_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    nlist = [2, 3, 4]
    for x in xlist:
        for k in nlist:
            print('<H2 Title="lambert_wk(x, k); x=' + str(x) + ' k=' + str(k) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.lambert_wk(x, k)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_lambert_wk_cplx_re_im_ctx():
    print('<H1 Title="pow_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for k in nlist:
            print('<H2 Title="Re(lambert_wk(x, k)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.lambert_wk(x, k)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(lambert_wk(x, k)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.lambert_wk(x, k)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_lambert_wk_cplx_explicit():
    print('<H1 Title="demo_lambert_wk_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for k in nlist:
            print('<H2 Title="lambert_wk(x, k); x=' + str(x) + '">')
            res = cmath53.lambert_wk(x, k); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.lambert_wk(x, k); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.lambert_wk(x, k); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.lambert_wk(x, k); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.lambert_wk(x, k); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.lambert_wk(x, k); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.lambert_wk(x, k); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.lambert_wk(x, k); print('aflintc: ' + aflintc.fmt(res))
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











