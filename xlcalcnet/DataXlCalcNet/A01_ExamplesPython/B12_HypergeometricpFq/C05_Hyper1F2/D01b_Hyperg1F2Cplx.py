
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
    demo_hyperg_1f2_cplx_ctx()
    demo_hyperg_1f2_cplx_re_im_ctx()
    demo_hyperg_1f2_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    a = 1.5;  b1 = 5.7; b2 = 15.3; x = 6.4+2j;  gui.setdps(40)
    for ctx in [fpm, mpm, cmath53]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.hyperg_1f2(a, b1, b2, x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    a = 1.5;  b1 = 5.7; b2 = 15.3; x = 6.4+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.hyperg_1f2(a, b1, b2, x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    a = 1.5;  b1 = 5.7; b2 = 15.3; x = 6.4+2j;  gui.setdps(90)
    for ctx in gui.ctxlist_noboost_cplx: 
        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.hyperg_1f2(a, b1, b2, x))))
    print('</H1>')




def demo_hyperg_1f2_cplx_ctx():
    print('<H1 Title="hyperg_1f2_cplx_ctx">')
    alist = [5.1+2j, 8.8+2j]; gui.setdps(50)
    b1list = [1.5+2j, 2.7+2j];
    b2list = [2.9+2j, 5.4+2j];
    xlist = [7.3+2j, 6.2+2j];
    for a in alist:
        for b1 in b1list:
            for b2 in b2list:
                for x in xlist:
                    print('<H2 Title="hyperg_1f2(a, b1, b2, x); a=' + str(a) 
                        + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.hyperg_1f2(a, b1, b2, x)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_hyperg_1f2_cplx_re_im_ctx():
    print('<H1 Title="hyperg_1f2_cplx_re_im_ctx">')
    alist = [5.1+2j, 8.8+2j]; gui.setdps(90)
    b1list = [1.5+2j, 2.7+2j];
    b2list = [2.9+2j, 5.4+2j];
    xlist = [7.3+2j, 6.2+2j];
    for a in alist:
        for b1 in b1list:
            for b2 in b2list:
                for x in xlist:
                    print('<H2 Title="Re(hyperg_1f2(a, b1, b2, x)); a=' + str(a) 
                        + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.hyperg_1f2(a, b1, b2, x)
                        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
                    print('</H2>')
                    print()
                    print('<H2 Title="Im(hyperg_1f2(a, b1, b2, x)); a=' + str(a) 
                        + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noboost_cplx:
                        res = ctx.hyperg_1f2(a, b1, b2, x)
                        print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_hyperg_1f2_cplx_explicit():
    print('<H1 Title="demo_hyperg_1f2_cplx_explicit">')
    alist = [5.1+2j, 8.8+2j]; gui.setdps(90)
    b1list = [1.5+2j, 2.7+2j];
    b2list = [2.9+2j, 5.4+2j];
    xlist = [7.3+2j, 6.2+2j];
    for a in alist:
        for b1 in b1list:
            for b2 in b2list:
                for x in xlist:
                    print('<H2 Title="hyperg_1f2(a, b1, b2, x); a=' + str(a) 
                        + ' b1=' + str(b1) + ' b2=' + str(b2)  + ' x=' + str(x) + '">')
                    res = cmath53.hyperg_1f2(a, b1, b2, x); print('cmath53: ' + cmath53.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = sflintc.hyperg_1f2(a, b1, b2, x); print('sflintc: ' + sflintc.fmt(res))
                        res = dflintc.hyperg_1f2(a, b1, b2, x); print('dflintc: ' + dflintc.fmt(res))
                        res = eflintc.hyperg_1f2(a, b1, b2, x); print('eflintc: ' + eflintc.fmt(res))
                        res = qflintc.hyperg_1f2(a, b1, b2, x); print('qflintc: ' + qflintc.fmt(res))
                        res = oflintc.hyperg_1f2(a, b1, b2, x); print('oflintc: ' + oflintc.fmt(res))
                        res = mflintc.hyperg_1f2(a, b1, b2, x); print('mflintc: ' + mflintc.fmt(res))
                        res = aflintc.hyperg_1f2(a, b1, b2, x); print('aflintc: ' + aflintc.fmt(res))
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











