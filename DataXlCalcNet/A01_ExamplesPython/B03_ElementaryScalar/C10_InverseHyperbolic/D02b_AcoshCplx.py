
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
    demo_acosh_cplx_ctx()
    demo_acosh_cplx_re_im_ctx()
    demo_acosh_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.acosh(x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.acosh(x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.acosh(x))))
    print('</H1>')




def demo_acosh_cplx_ctx():
    print('<H1 Title="acosh_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for x in xlist:
        print('<H2 Title="acosh(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.acosh(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_acosh_cplx_re_im_ctx():
    print('<H1 Title="acosh_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="Re(acosh(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.acosh(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(acosh(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx:
            res = ctx.acosh(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_acosh_cplx_explicit():
    print('<H1 Title="demo_acosh_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="acosh(x); x=' + str(x) + '">')
        res = cmath53.acosh(x); print('cmath53: ' + cmath53.fmt(res))
        res = scplx.acosh(x); print('  scplx: ' + scplx.fmt(res))
        res = dcplx.acosh(x); print('  dcplx: ' + dcplx.fmt(res))
        res = ecplx.acosh(x); print('  ecplx: ' + ecplx.fmt(res))
        res = qcplx.acosh(x); print('  qcplx: ' + qcplx.fmt(res))
        res = ocplx.acosh(x); print('  ocplx: ' + ocplx.fmt(res))
        if gui.has_xlcalcnet2:
            res = mcplx.acosh(x); print('  mcplx: ' + mcplx.fmt(res))
            res = sflintc.acosh(x); print('sflintc: ' + sflintc.fmt(res))
            res = dflintc.acosh(x); print('dflintc: ' + dflintc.fmt(res))
            res = eflintc.acosh(x); print('eflintc: ' + eflintc.fmt(res))
            res = qflintc.acosh(x); print('qflintc: ' + qflintc.fmt(res))
            res = oflintc.acosh(x); print('oflintc: ' + oflintc.fmt(res))
            res = mflintc.acosh(x); print('mflintc: ' + mflintc.fmt(res))
            res = aflintc.acosh(x); print('aflintc: ' + aflintc.fmt(res))
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











