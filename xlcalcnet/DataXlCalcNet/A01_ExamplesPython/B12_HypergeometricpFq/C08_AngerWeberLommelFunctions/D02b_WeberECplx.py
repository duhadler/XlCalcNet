
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
    demo_weber_e_cplx_ctx()
    demo_weber_e_cplx_re_im_ctx()
    demo_weber_e_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = 1.1;  x = 2.7+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.weber_e(n, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = 1.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.weber_e(n, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = 1.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.weber_e(n, x))))
    print('</H1>')




def demo_weber_e_cplx_ctx():
    print('<H1 Title="weber_e_cplx_ctx">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(50)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="weber_e(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weber_e(n, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_weber_e_cplx_re_im_ctx():
    print('<H1 Title="weber_e_cplx_re_im_ctx">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="Re(weber_e(n, x)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weber_e(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(weber_e(n, x)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.weber_e(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_weber_e_cplx_explicit():
    print('<H1 Title="demo_weber_e_cplx_explicit">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="weber_e(n, x); n=' + str(n) + '">')
            res = cmath53.weber_e(n, x); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.weber_e(n, x); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.weber_e(n, x); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.weber_e(n, x); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.weber_e(n, x); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.weber_e(n, x); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.weber_e(n, x); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.weber_e(n, x); print('aflintc: ' + aflintc.fmt(res))
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











