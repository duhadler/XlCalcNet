
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
    demo_polygamma_cplx_ctx()
    demo_polygamma_cplx_re_im_ctx()
    demo_polygamma_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = 3; x = -5.1+2j;  gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.polygamma(n, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = 3; x = -5.1+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.polygamma(n, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = 3; x = -5.1+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.polygamma(n, x))))
    print('</H1>')




def demo_polygamma_cplx_ctx():
    print('<H1 Title="pow_cplx_ctx">')
    gui.setdps(50)
    nlist = [2, 3, 4]
    xlist = [-5.1+2j, 8.8+2j]
    for n in nlist:
        for x in xlist:
            print('<H2 Title="polygamma(n, x); x=' + str(x) + ' n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.polygamma(n, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_polygamma_cplx_re_im_ctx():
    print('<H1 Title="pow_cplx_re_im_ctx">')
    gui.setdps(90)
    nlist = [2, 3, 4]
    xlist = [-5.1+2j, 8.8+2j]
    for n in nlist:
        for x in xlist:
            print('<H2 Title="Re(polygamma(n, x)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.polygamma(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(polygamma(n, x)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.polygamma(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_polygamma_cplx_explicit():
    print('<H1 Title="demo_polygamma_cplx_explicit">')
    gui.setdps(50)
    nlist = [2, 3, 4]
    xlist = [-5.1+2j, 8.8+2j]
    for n in nlist:
        for x in xlist:
            print('<H2 Title="polygamma(n, x); x=' + str(x) + '">')
            res = cmath53.polygamma(n, x); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.polygamma(n, x); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.polygamma(n, x); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.polygamma(n, x); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.polygamma(n, x); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.polygamma(n, x); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.polygamma(n, x); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.polygamma(n, x); print('aflintc: ' + aflintc.fmt(res))
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











