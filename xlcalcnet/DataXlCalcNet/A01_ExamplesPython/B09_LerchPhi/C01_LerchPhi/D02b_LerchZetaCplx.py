
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
#    demo_lerch_zeta_cplx_ctx()
#    demo_lerch_zeta_cplx_re_im_ctx()
#    demo_lerch_zeta_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    lambda1 = -5.1+2j;  alpha = 2.7+2j; s = 1.3+2j;  gui.setdps(40)
    for ctx in [fpm, mpm]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.lerch_zeta(lambda1, alpha, s)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    lambda1 = -5.1+2j;  alpha = 2.7+2j; s = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.lerch_zeta(lambda1, alpha, s))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    lambda1 = -5.1+2j;  alpha = 2.7+2j; s = 1.3+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.lerch_zeta(lambda1, alpha, s))))
    print('</H1>')




def demo_lerch_zeta_cplx_ctx():
    print('<H1 Title="lerch_zeta_cplx_ctx">')
    gui.setdps(50)
    lambda1list = [1.5+1.0j, 2.5+1.0j, 13.5+1.0j]
    alphalist = [2.1+1.0, 12.1+1.0, 53.5+1.0j]
    slist = [0.01+1.0j, 0.5+1.0j, 0.99+1.0j]
    for lambda1 in lambda1list:
        for alpha in alphalist:
            for s in slist:
                print('<H2 Title="lerch_zeta(lambda1, alpha, s); lambda1=' + str(lambda1) + ' alpha=' + str(alpha) + ' s=' + str(s) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.lerch_zeta(lambda1, alpha, s)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_lerch_zeta_cplx_re_im_ctx():
    print('<H1 Title="lerch_zeta_cplx_re_im_ctx">')
    gui.setdps(50)
    lambda1list = [1.5+1.0j, 2.5+1.0j, 13.5+1.0j]
    alphalist = [2.1+1.0, 12.1+1.0, 53.5+1.0j]
    slist = [0.01+1.0j, 0.5+1.0j, 0.99+1.0j]
    for lambda1 in lambda1list:
        for alpha in alphalist:
            for s in slist:
                print('<H2 Title="Re(lerch_zeta(lambda1, alpha, s)); lambda1=' + str(lambda1) + ' alpha=' + str(alpha) + ' s=' + str(s) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.lerch_zeta(lambda1, alpha, s)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                print('</H2>')
                print()
                print('<H2 Title="Im(lerch_zeta(lambda1, alpha, s)); lambda1=' + str(lambda1) + ' alpha=' + str(alpha) + ' s=' + str(s) + '">')
                for ctx in gui.ctxlist_noboost_cplx:
                    res = ctx.lerch_zeta(lambda1, alpha, s)
                    print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_lerch_zeta_cplx_explicit():
    print('<H1 Title="demo_lerch_zeta_cplx_explicit">')
    lambda1list = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    alphalist = [1.5+2j, 2.7+2j];
    slist = [2.9+2j, 5.4+2j];
    for lambda1 in lambda1list:
        for alpha in alphalist:
            for s in slist:
                print('<H2 Title="lerch_zeta(lambda1, alpha, s); lambda1=' + str(lambda1) + ' alpha=' + str(alpha) + ' s=' + str(s) + '">')
                res = cmath53.lerch_zeta(lambda1, alpha, s); print('cmath53: ' + cmath53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflintc.lerch_zeta(lambda1, alpha, s); print('sflintc: ' + sflintc.fmt(res))
                    res = dflintc.lerch_zeta(lambda1, alpha, s); print('dflintc: ' + dflintc.fmt(res))
                    res = eflintc.lerch_zeta(lambda1, alpha, s); print('eflintc: ' + eflintc.fmt(res))
                    res = qflintc.lerch_zeta(lambda1, alpha, s); print('qflintc: ' + qflintc.fmt(res))
                    res = oflintc.lerch_zeta(lambda1, alpha, s); print('oflintc: ' + oflintc.fmt(res))
                    res = mflintc.lerch_zeta(lambda1, alpha, s); print('mflintc: ' + mflintc.fmt(res))
                    res = aflintc.lerch_zeta(lambda1, alpha, s); print('aflintc: ' + aflintc.fmt(res))
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











