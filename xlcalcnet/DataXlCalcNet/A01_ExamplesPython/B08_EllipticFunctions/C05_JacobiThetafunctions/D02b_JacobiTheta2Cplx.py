
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
    demo_jacobi_theta2_cplx_ctx()
    demo_jacobi_theta2_cplx_re_im_ctx()
    demo_jacobi_theta2_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = 1.0+2j;  q = 0.5+0.2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: 
        print(ctx.fmtname + ': ' + ctx.fmt(ctx.jacobi_theta2(x, q)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = 1.0+2j;  q = 0.5+0.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.jacobi_theta2(x, q))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = 1.0+2j;  q = 0.5+0.2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.jacobi_theta2(x, q))))
    print('</H1>')




def demo_jacobi_theta2_cplx_ctx():
    print('<H1 Title="jacobi_theta2_cplx_ctx">')
    xlist = [1.0+2j, 1.5+2j]; gui.setdps(50)
    qlist = [0.5+0.2j, 0.33+0.22j];
    for x in xlist:
        for q in qlist:
            print('<H2 Title="jacobi_theta2(x, q); x=' + str(x) + ' q=' + str(q) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.jacobi_theta2(x, q)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_jacobi_theta2_cplx_re_im_ctx():
    print('<H1 Title="jacobi_theta2_cplx_re_im_ctx">')
    xlist = [1.0+2j, 1.5+2j]; gui.setdps(90)
    qlist = [0.5+0.2j, 0.33+0.22j];
    for x in xlist:
        for q in qlist:
            print('<H2 Title="Re(jacobi_theta2(x, q)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.jacobi_theta2(x, q)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(jacobi_theta2(x, q)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.jacobi_theta2(x, q)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_jacobi_theta2_cplx_explicit():
    print('<H1 Title="demo_jacobi_theta2_cplx_explicit">')
    xlist = [1.0+2j, 1.5+2j]; gui.setdps(90)
    qlist = [0.5+0.2j, 0.33+0.22j];
    for x in xlist:
        for q in qlist:
            print('<H2 Title="jacobi_theta2(x, q); x=' + str(x) + '">')
            res = cmath53.jacobi_theta2(x, q); print('cmath53: ' + cmath53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflintc.jacobi_theta2(x, q); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.jacobi_theta2(x, q); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.jacobi_theta2(x, q); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.jacobi_theta2(x, q); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.jacobi_theta2(x, q); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.jacobi_theta2(x, q); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.jacobi_theta2(x, q); print('aflintc: ' + aflintc.fmt(res))
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











