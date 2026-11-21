
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx


def main_tests():
    print('cplx dirichlet_beta(t)')
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_dirichlet_beta_cplx_ctx()
    demo_dirichlet_beta_cplx_re_im_ctx()
    demo_dirichlet_beta_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    t = -5.1+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.dirichlet_beta(t)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    t = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.dirichlet_beta(t))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    t = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.dirichlet_beta(t))))
    print('</H1>')




def demo_dirichlet_beta_cplx_ctx():
    print('<H1 Title="dirichlet_beta_cplx_ctx">')
    tlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for t in tlist:
        print('<H2 Title="dirichlet_beta(t); t=' + str(t) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.dirichlet_beta(t)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_dirichlet_beta_cplx_re_im_ctx():
    print('<H1 Title="dirichlet_beta_cplx_re_im_ctx">')
    tlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for t in tlist:
        print('<H2 Title="Re(dirichlet_beta(t)); t=' + str(t) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.dirichlet_beta(t)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(dirichlet_beta(t)); t=' + str(t) + '">')
        for ctx in gui.ctxlist_noboost_cplx:
            res = ctx.dirichlet_beta(t)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_dirichlet_beta_cplx_explicit():
    print('<H1 Title="demo_dirichlet_beta_cplx_dirichlet_betalicit">')
    tlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for t in tlist:
        print('<H2 Title="dirichlet_beta(t); t=' + str(t) + '">')
        res = cmath53.dirichlet_beta(t); print('cmath53: ' + cmath53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflintc.dirichlet_beta(t); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.dirichlet_beta(t); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.dirichlet_beta(t); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.dirichlet_beta(t); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.dirichlet_beta(t); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.dirichlet_beta(t); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.dirichlet_beta(t); print('aflintc: ' + aflintc.fmt(res))
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

