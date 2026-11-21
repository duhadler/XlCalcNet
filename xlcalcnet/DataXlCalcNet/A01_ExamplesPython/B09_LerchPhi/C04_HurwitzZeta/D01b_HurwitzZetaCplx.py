
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
    demo_hurwitz_zeta_cplx_ctx()
    demo_hurwitz_zeta_cplx_re_im_ctx()
    demo_hurwitz_zeta_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    s = 3; z = -5.1+2j;  gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hurwitz_zeta(s, z)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    s = 3; z = -5.1+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.hurwitz_zeta(s, z))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    s = 3; z = -5.1+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.hurwitz_zeta(s, z))))
    print('</H1>')




def demo_hurwitz_zeta_cplx_ctx():
    print('<H1 Title="pow_cplx_ctx">')
    gui.setdps(50)
    slist = [2, 3, 4]
    zlist = [-5.1+2j, 8.8+2j]
    for s in slist:
        for z in zlist:
            print('<H2 Title="hurwitz_zeta(s, z); z=' + str(z) + ' s=' + str(s) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hurwitz_zeta(s, z)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hurwitz_zeta_cplx_re_im_ctx():
    print('<H1 Title="pow_cplx_re_im_ctx">')
    gui.setdps(90)
    slist = [2, 3, 4]
    zlist = [-5.1+2j, 8.8+2j]
    for s in slist:
        for z in zlist:
            print('<H2 Title="Re(hurwitz_zeta(s, z)); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hurwitz_zeta(s, z)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(hurwitz_zeta(s, z)); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hurwitz_zeta(s, z)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hurwitz_zeta_cplx_explicit():
    print('<H1 Title="demo_hurwitz_zeta_cplx_explicit">')
    gui.setdps(50)
    slist = [2, 3, 4]
    zlist = [-5.1+2j, 8.8+2j]
    for s in slist:
        for z in zlist:
            print('<H2 Title="hurwitz_zeta(s, z); z=' + str(z) + '">')
            res = cmath53.hurwitz_zeta(s, z); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.hurwitz_zeta(s, z); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.hurwitz_zeta(s, z); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.hurwitz_zeta(s, z); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.hurwitz_zeta(s, z); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.hurwitz_zeta(s, z); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.hurwitz_zeta(s, z); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.hurwitz_zeta(s, z); print('aflintc: ' + aflintc.fmt(res))
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











