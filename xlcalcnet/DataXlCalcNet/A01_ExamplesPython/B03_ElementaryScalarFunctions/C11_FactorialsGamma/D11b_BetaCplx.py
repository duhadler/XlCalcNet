
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
    demo_beta_cplx_ctx()
    demo_beta_cplx_re_im_ctx()
    demo_beta_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+3j; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.beta(x, y)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+3j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.beta(x, y))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  y = 2.7+3j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.beta(x, y))))
    print('</H1>')




def demo_beta_cplx_ctx():
    print('<H1 Title="beta_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    ylist = [1.5+3j, 2.7+3j];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="beta(x, y); x=' + str(x) + ' y=' + str(y) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.beta(x, y)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_beta_cplx_re_im_ctx():
    print('<H1 Title="beta_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    ylist = [1.5+23, 2.7+3j];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="Re(beta(x, y)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.beta(x, y)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(beta(x, y)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.beta(x, y)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_beta_cplx_explicit():
    print('<H1 Title="demo_beta_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    ylist = [1.5+3j, 2.7+3j];
    for x in xlist:
        for y in ylist:
            print('<H2 Title="beta(x, y); x=' + str(x) + '">')
            res = cmath53.beta(x, y); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.beta(x, y); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.beta(x, y); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.beta(x, y); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.beta(x, y); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.beta(x, y); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.beta(x, y); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.beta(x, y); print('aflintc: ' + aflintc.fmt(res))
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











