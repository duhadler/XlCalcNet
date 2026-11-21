
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx

scaled = False


def main_tests():
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_sph_bessel_jn_prime_cplx_ctx()
    demo_sph_bessel_jn_prime_cplx_re_im_ctx()
    demo_sph_bessel_jn_prime_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sph_bessel_jn_prime(n, x, scaled=False)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.sph_bessel_jn_prime(n, x, scaled=False))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.sph_bessel_jn_prime(n, x, scaled=False))))
    print('</H1>')




def demo_sph_bessel_jn_prime_cplx_ctx():
    print('<H1 Title="sph_bessel_jn_prime_cplx_ctx">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(50)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_bessel_jn_prime(n, x, scaled); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.sph_bessel_jn_prime(n, x, scaled)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_sph_bessel_jn_prime_cplx_re_im_ctx():
    print('<H1 Title="sph_bessel_jn_prime_cplx_re_im_ctx">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="Re(sph_bessel_jn_prime(n, x, scaled)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.sph_bessel_jn_prime(n, x, scaled)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(sph_bessel_jn_prime(n, x, scaled)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.sph_bessel_jn_prime(n, x, scaled)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_sph_bessel_jn_prime_cplx_explicit():
    print('<H1 Title="demo_sph_bessel_jn_prime_cplx_explicit">')
    nlist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_bessel_jn_prime(n, x, scaled); n=' + str(n) + '">')
            res = cmath53.sph_bessel_jn_prime(n, x, scaled); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.sph_bessel_jn_prime(n, x, scaled); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.sph_bessel_jn_prime(n, x, scaled); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.sph_bessel_jn_prime(n, x, scaled); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.sph_bessel_jn_prime(n, x, scaled); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.sph_bessel_jn_prime(n, x, scaled); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.sph_bessel_jn_prime(n, x, scaled); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.sph_bessel_jn_prime(n, x, scaled); print('aflintc: ' + aflintc.fmt(res))
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











