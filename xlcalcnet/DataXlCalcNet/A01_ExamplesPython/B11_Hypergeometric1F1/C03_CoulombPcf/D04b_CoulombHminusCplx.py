
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
    demo_coulomb_hminus_cplx_ctx()
    demo_coulomb_hminus_cplx_re_im_ctx()
    demo_coulomb_hminus_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    l = -5.1;  eta = 2.7; x = 1.3+2j;  gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.coulomb_hminus(l, eta, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    l = -5.1;  eta = 2.7; x = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.coulomb_hminus(l, eta, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    l = -5.1;  eta = 2.7; x = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.coulomb_hminus(l, eta, x))))
    print('</H1>')




def demo_coulomb_hminus_cplx_ctx():
    print('<H1 Title="coulomb_hminus_cplx_ctx">')
    llist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    etalist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_hminus(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.coulomb_hminus(l, eta, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_coulomb_hminus_cplx_re_im_ctx():
    print('<H1 Title="coulomb_hminus_cplx_re_im_ctx">')
    llist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    etalist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="Re(coulomb_hminus(l, eta, x)); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.coulomb_hminus(l, eta, x)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                print('</H2>')
                print()
                print('<H2 Title="Im(coulomb_hminus(l, eta, x)); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.coulomb_hminus(l, eta, x)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_coulomb_hminus_cplx_explicit():
    print('<H1 Title="demo_coulomb_hminus_cplx_explicit">')
    llist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    etalist = [1.5+2j, 2.7+2j];
    xlist = [2.9+2j, 5.4+2j];
    for l in llist:
        for eta in etalist:
            for x in xlist:
                print('<H2 Title="coulomb_hminus(l, eta, x); l=' + str(l) + ' eta=' + str(eta) + ' x=' + str(x) + '">')
                res = cmath53.coulomb_hminus(l, eta, x); print('cmath53: ' + cmath53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflintc.coulomb_hminus(l, eta, x); print('sflintc: ' + sflintc.fmt(res))
                    res = dflintc.coulomb_hminus(l, eta, x); print('dflintc: ' + dflintc.fmt(res))
                    res = eflintc.coulomb_hminus(l, eta, x); print('eflintc: ' + eflintc.fmt(res))
                    res = qflintc.coulomb_hminus(l, eta, x); print('qflintc: ' + qflintc.fmt(res))
                    res = oflintc.coulomb_hminus(l, eta, x); print('oflintc: ' + oflintc.fmt(res))
                    res = mflintc.coulomb_hminus(l, eta, x); print('mflintc: ' + mflintc.fmt(res))
                    res = aflintc.coulomb_hminus(l, eta, x); print('aflintc: ' + aflintc.fmt(res))
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











