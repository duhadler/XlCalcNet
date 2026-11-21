
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
    demo_kelvin_ber_prime_cplx_ctx()
    demo_kelvin_ber_prime_cplx_re_im_ctx()
    demo_kelvin_ber_prime_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    nu = -5.1;  x = 2.7+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.kelvin_ber_prime(nu, x, scaled=False)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    nu = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.kelvin_ber_prime(nu, x, scaled=False))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    nu = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.kelvin_ber_prime(nu, x, scaled=False))))
    print('</H1>')




def demo_kelvin_ber_prime_cplx_ctx():
    print('<H1 Title="kelvin_ber_prime_cplx_ctx">')
    nulist = [-5.1, 8.8+2j]; gui.setdps(50)
    xlist = [1.5+2j, 2.7+2j];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="kelvin_ber_prime(nu, x, scaled); nu=' + str(nu) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.kelvin_ber_prime(nu, x, scaled)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_kelvin_ber_prime_cplx_re_im_ctx():
    print('<H1 Title="kelvin_ber_prime_cplx_re_im_ctx">')
    nulist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="Re(kelvin_ber_prime(nu, x, scaled)); nu=' + str(nu) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.kelvin_ber_prime(nu, x, scaled)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(kelvin_ber_prime(nu, x, scaled)); nu=' + str(nu) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.kelvin_ber_prime(nu, x, scaled)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_kelvin_ber_prime_cplx_explicit():
    print('<H1 Title="demo_kelvin_ber_prime_cplx_explicit">')
    nulist = [-5.1, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="kelvin_ber_prime(nu, x, scaled); nu=' + str(nu) + '">')
            res = cmath53.kelvin_ber_prime(nu, x, scaled); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.kelvin_ber_prime(nu, x, scaled); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.kelvin_ber_prime(nu, x, scaled); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.kelvin_ber_prime(nu, x, scaled); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.kelvin_ber_prime(nu, x, scaled); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.kelvin_ber_prime(nu, x, scaled); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.kelvin_ber_prime(nu, x, scaled); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.kelvin_ber_prime(nu, x, scaled); print('aflintc: ' + aflintc.fmt(res))
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











