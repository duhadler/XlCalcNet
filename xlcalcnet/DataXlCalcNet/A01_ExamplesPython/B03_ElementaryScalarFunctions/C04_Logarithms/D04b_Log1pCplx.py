
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
    demo_log1p_cplx_ctx()
    demo_log1p_cplx_re_im_ctx()
    demo_log1p_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.log1p(x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.log1p(x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.log1p(x))))
    print('</H1>')




def demo_log1p_cplx_ctx():
    print('<H1 Title="log1p_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for x in xlist:
        print('<H2 Title="log1p(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.log1p(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_log1p_cplx_re_im_ctx():
    print('<H1 Title="log1p_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="Re(log1p(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.log1p(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(log1p(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.log1p(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_log1p_cplx_explicit():
    print('<H1 Title="demo_log1p_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="log1p(x); x=' + str(x) + '">')
        res = cmath53.log1p(x); print('cmath53: ' + cmath53.fmt(res))
        res = scplx.log1p(x); print('  scplx: ' + scplx.fmt(res))
        res = dcplx.log1p(x); print('  dcplx: ' + dcplx.fmt(res))
        res = ecplx.log1p(x); print('  ecplx: ' + ecplx.fmt(res))
        res = qcplx.log1p(x); print('  qcplx: ' + qcplx.fmt(res))
        res = ocplx.log1p(x); print('  ocplx: ' + ocplx.fmt(res))
        if gui.has_xlcalcnet2:
            res = mcplx.log1p(x); print('  mcplx: ' + mcplx.fmt(res))
            res = sflintc.log1p(x); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.log1p(x); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.log1p(x); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.log1p(x); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.log1p(x); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.log1p(x); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.log1p(x); print('aflintc: ' + aflintc.fmt(res))
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











