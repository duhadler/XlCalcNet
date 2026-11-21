
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
    demo_pow_si_cplx_ctx()
    demo_pow_si_cplx_re_im_ctx()
    demo_pow_si_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(50)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.pow_si(x, n)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.pow_si(x, n))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.pow_si(x, n))))
    print('</H1>')




def demo_pow_si_cplx_ctx():
    print('<H1 Title="pow_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="pow_si(x, n); x=' + str(x) + ' n=' + str(n) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.pow_si(x, n)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_pow_si_cplx_re_im_ctx():
    print('<H1 Title="pow_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="Re(pow_si(x, n)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.pow_si(x, n)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(pow_si(x, n)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.pow_si(x, n)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_pow_si_cplx_explicit():
    print('<H1 Title="demo_pow_si_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="pow_si(x, n); x=' + str(x) + '">')
            res = cmath53.pow_si(x, n); print('cmath53: ' + cmath53.fmt(res))
            res = scplx.pow_si(x, n); print('  scplx: ' + scplx.fmt(res))
            res = dcplx.pow_si(x, n); print('  dcplx: ' + dcplx.fmt(res))
            res = ecplx.pow_si(x, n); print('  ecplx: ' + ecplx.fmt(res))
            res = qcplx.pow_si(x, n); print('  qcplx: ' + qcplx.fmt(res))
            res = ocplx.pow_si(x, n); print('  ocplx: ' + ocplx.fmt(res))
            if gui.has_xlcalcnet2:
                res = mcplx.pow_si(x, n); print('  mcplx: ' + mcplx.fmt(res))
                res = sflintc.pow_si(x, n); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.pow_si(x, n); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.pow_si(x, n); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.pow_si(x, n); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.pow_si(x, n); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.pow_si(x, n); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.pow_si(x, n); print('aflintc: ' + aflintc.fmt(res))
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











