
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
    demo_hermite_he_cplx_ctx()
    demo_hermite_he_cplx_re_im_ctx()
    demo_hermite_he_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hermite_he(n, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.hermite_he(n, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    n = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.hermite_he(n, x))))
    print('</H1>')




def demo_hermite_he_cplx_ctx():
    print('<H1 Title="hermite_he_cplx_ctx">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="hermite_he(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hermite_he(n, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hermite_he_cplx_re_im_ctx():
    print('<H1 Title="hermite_he_cplx_re_im_ctx">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="Re(hermite_he(n, x)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hermite_he(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(hermite_he(n, x)); n=' + str(n) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.hermite_he(n, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hermite_he_cplx_explicit():
    print('<H1 Title="demo_hermite_he_cplx_explicit">')
    nlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="hermite_he(n, x); n=' + str(n) + '">')
            res = cmath53.hermite_he(n, x); print('cmath53: ' + cmath53.fmt(res))
#            res = scplx.hermite_he(n, x); print('  scplx: ' + scplx.fmt(res))
#            res = dcplx.hermite_he(n, x); print('  dcplx: ' + dcplx.fmt(res))
#            res = ecplx.hermite_he(n, x); print('  ecplx: ' + ecplx.fmt(res))
#            res = qcplx.hermite_he(n, x); print('  qcplx: ' + qcplx.fmt(res))
#            res = ocplx.hermite_he(n, x); print('  ocplx: ' + ocplx.fmt(res))
            if gui.has_xlcalcnet2:
#                res = mcplx.hermite_he(n, x); print('  mcplx: ' + mcplx.fmt(res))
                res = sflintc.hermite_he(n, x); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.hermite_he(n, x); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.hermite_he(n, x); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.hermite_he(n, x); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.hermite_he(n, x); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.hermite_he(n, x); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.hermite_he(n, x); print('aflintc: ' + aflintc.fmt(res))
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











