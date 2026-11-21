
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
    demo_legendre_plm_cplx_ctx()
    demo_legendre_plm_cplx_re_im_ctx()
    demo_legendre_plm_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = -5.1;  m = 2.7; x = 1.3+2j;  gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.legendre_plm(n, m, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = -5.1;  m = 2.7; x = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.legendre_plm(n, m, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = -5.1;  m = 2.7; x = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.legendre_plm(n, m, x))))
    print('</H1>')




def demo_legendre_plm_cplx_ctx():
    print('<H1 Title="legendre_plm_cplx_ctx">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    mlist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="legendre_plm(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.legendre_plm(n, m, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_legendre_plm_cplx_re_im_ctx():
    print('<H1 Title="legendre_plm_cplx_re_im_ctx">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    mlist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="Re(legendre_plm(n, m, x)); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.legendre_plm(n, m, x)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                print('</H2>')
                print()
                print('<H2 Title="Im(legendre_plm(n, m, x)); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.legendre_plm(n, m, x)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_legendre_plm_cplx_explicit():
    print('<H1 Title="demo_legendre_plm_cplx_explicit">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    mlist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="legendre_plm(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                res = cmath53.legendre_plm(n, m, x); print('cmath53: ' + cmath53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflintc.legendre_plm(n, m, x); print('sflintc: ' + sflintc.fmt(res))
                    res = dflintc.legendre_plm(n, m, x); print('dflintc: ' + dflintc.fmt(res))
                    res = eflintc.legendre_plm(n, m, x); print('eflintc: ' + eflintc.fmt(res))
                    res = qflintc.legendre_plm(n, m, x); print('qflintc: ' + qflintc.fmt(res))
                    res = oflintc.legendre_plm(n, m, x); print('oflintc: ' + oflintc.fmt(res))
                    res = mflintc.legendre_plm(n, m, x); print('mflintc: ' + mflintc.fmt(res))
                    res = aflintc.legendre_plm(n, m, x); print('aflintc: ' + aflintc.fmt(res))
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











