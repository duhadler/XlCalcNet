
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
    demo_root_si_cplx_ctx()
    demo_root_si_cplx_re_im_ctx()
    demo_root_si_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(40)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.root_si(x, n)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.root_si(x, n))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j;  n = 3; gui.setdps(90)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.root_si(x, n))))
    print('</H1>')




def demo_root_si_cplx_ctx():
    print('<H1 Title="root_si_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="root_si(x, n); x=' + str(x) + ' n=' + str(n) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.root_si(x, n)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_root_si_cplx_re_im_ctx():
    print('<H1 Title="root_si_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="Re(root_si(x, n)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.root_si(x, n)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
            print('</H2>')
            print()
            print('<H2 Title="Im(root_si(x, n)); x=' + str(x) + '">')
            for ctx in gui.ctxlist_cplx:
                res = ctx.root_si(x, n)
                print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_root_si_cplx_explicit():
    print('<H1 Title="demo_root_si_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="root_si(x, n); x=' + str(x) + '">')
            res = cmath53.root_si(x, n); print('cmath53: ' + cmath53.fmt(res))
            res = scplx.root_si(x, n); print('  scplx: ' + scplx.fmt(res))
            res = dcplx.root_si(x, n); print('  dcplx: ' + dcplx.fmt(res))
            res = ecplx.root_si(x, n); print('  ecplx: ' + ecplx.fmt(res))
            res = qcplx.root_si(x, n); print('  qcplx: ' + qcplx.fmt(res))
            res = ocplx.root_si(x, n); print('  ocplx: ' + ocplx.fmt(res))
            if gui.has_xlcalcnet2:
                res = mcplx.root_si(x, n); print('  mcplx: ' + mcplx.fmt(res))
                res = sflintc.root_si(x, n); print('sflintc: ' + sflintc.fmt(res))
                res = dflintc.root_si(x, n); print('dflintc: ' + dflintc.fmt(res))
                res = eflintc.root_si(x, n); print('eflintc: ' + eflintc.fmt(res))
                res = qflintc.root_si(x, n); print('qflintc: ' + qflintc.fmt(res))
                res = oflintc.root_si(x, n); print('oflintc: ' + oflintc.fmt(res))
                res = mflintc.root_si(x, n); print('mflintc: ' + mflintc.fmt(res))
                res = aflintc.root_si(x, n); print('aflintc: ' + aflintc.fmt(res))
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











