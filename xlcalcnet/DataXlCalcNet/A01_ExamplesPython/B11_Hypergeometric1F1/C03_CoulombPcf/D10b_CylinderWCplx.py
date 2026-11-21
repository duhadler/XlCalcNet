
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
    demo_pcfw_cplx_ctx()
    demo_pcfw_cplx_re_im_ctx()
    demo_pcfw_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    a = -5.1;  x = 2.7+2j; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.pcfw(a, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    a = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.pcfw(a, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    a = -5.1;  x = 2.7+2j; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.pcfw(a, x))))
    print('</H1>')




def demo_pcfw_cplx_ctx():
    print('<H1 Title="pcfw_cplx_ctx">')
    alist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    xlist = [1.5+2j, 2.7+2j];
    for a in alist:
        for x in xlist:
            print('<H2 Title="pcfw(a, x); a=' + str(a) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.pcfw(a, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_pcfw_cplx_re_im_ctx():
    print('<H1 Title="pcfw_cplx_re_im_ctx">')
    alist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for a in alist:
        for x in xlist:
            print('<H2 Title="Re(pcfw(a, x)); a=' + str(a) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.pcfw(a, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(pcfw(a, x)); a=' + str(a) + '">')
            for ctx in gui.ctxlist_noboost_cplx:
                res = ctx.pcfw(a, x)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_pcfw_cplx_explicit():
    print('<H1 Title="demo_pcfw_cplx_explicit">')
    alist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    xlist = [1.5+2j, 2.7+2j];
    for a in alist:
        for x in xlist:
            print('<H2 Title="pcfw(a, x); a=' + str(a) + '">')
            res = cmath53.pcfw(a, x); print('cmath53: ' + cmath53.fmt(res))
#            res = scplx.pcfw(a, x); print('  scplx: ' + scplx.fmt(res))
#            res = dcplx.pcfw(a, x); print('  dcplx: ' + dcplx.fmt(res))
#            res = ecplx.pcfw(a, x); print('  ecplx: ' + ecplx.fmt(res))
#            res = qcplx.pcfw(a, x); print('  qcplx: ' + qcplx.fmt(res))
#            res = ocplx.pcfw(a, x); print('  ocplx: ' + ocplx.fmt(res))
            if gui.has_xlcalcnet2:
#                res = mcplx.pcfw(a, x); print('  mcplx: ' + mcplx.fmt(res))
                res = sflintc.pcfw(a, x); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.pcfw(a, x); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.pcfw(a, x); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.pcfw(a, x); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.pcfw(a, x); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.pcfw(a, x); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.pcfw(a, x); print('aflintc: ' + aflintc.fmt(res))
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











