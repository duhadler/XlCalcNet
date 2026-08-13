
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
    demo_sinh_cplx_ctx()
    demo_sinh_cplx_re_im_ctx()
    demo_sinh_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sinh(x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.sinh(x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.sinh(x))))
    print('</H1>')




def demo_sinh_cplx_ctx():
    print('<H1 Title="sinh_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for x in xlist:
        print('<H2 Title="sinh(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.sinh(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sinh_cplx_re_im_ctx():
    print('<H1 Title="sinh_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="Re(sinh(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.sinh(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(sinh(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.sinh(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sinh_cplx_explicit():
    print('<H1 Title="demo_sinh_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sinh(x); x=' + str(x) + '">')
        res = cmath53.sinh(x); print('cmath53: ' + cmath53.fmt(res))
        res = scplx.sinh(x); print('  scplx: ' + scplx.fmt(res))
        res = dcplx.sinh(x); print('  dcplx: ' + dcplx.fmt(res))
        res = ecplx.sinh(x); print('  ecplx: ' + ecplx.fmt(res))
        res = qcplx.sinh(x); print('  qcplx: ' + qcplx.fmt(res))
        res = ocplx.sinh(x); print('  ocplx: ' + ocplx.fmt(res))
        if gui.has_xlcalcnet2:
            res = mcplx.sinh(x); print('  mcplx: ' + mcplx.fmt(res))
            res = sflintc.sinh(x); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.sinh(x); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.sinh(x); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.sinh(x); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.sinh(x); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.sinh(x); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.sinh(x); print('aflintc: ' + aflintc.fmt(res))
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











