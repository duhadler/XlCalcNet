
from xlcalcnet import gui, fpmlib, mpmlib, dpmlib, ipmlib
if gui.has_gpm: from xlcalcnet import gpmlib
if gui.has_apm: from xlcalcnet import apmlib
if gui.has_userfixedlib: from xlcalcnet import m53libc, slibc, dlibc,  elibc, \
    qlibc, olibc
if gui.has_userarblib: from xlcalcnet import mlibc, sflibc, dflibc, eflibc, \
    qflibc, oflibc, mflibc, aflibc
import time


def main_tests():
    demo_manual_cplx_short()
    demo_manual_cplx_real_part()
    demo_manual_cplx_imag_part()
    demo_sin_cplx_ctx()
    demo_sin_cplx_re_im_ctx()
    demo_sin_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(50)
    for ctx in [fpmlib, mpmlib, m53libc, qlibc]: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sin(x)))
    print('</H1>')


def demo_manual_cplx_real_part():
    print('<H1 Title="demo_manual_cplx_real_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    ctxlist = gui.ctxlist_pm_user + gui.ctxlist_cplx_user
    for ctx in ctxlist: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(ctx.sin(x))))
    print('</H1>')


def demo_manual_cplx_imag_part():
    print('<H1 Title="demo_manual_cplx_imag_part">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(90)
    ctxlist = gui.ctxlist_pm_user + gui.ctxlist_cplx_user
    for ctx in ctxlist: print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(ctx.sin(x))))
    print('</H1>')




def demo_sin_cplx_ctx():
    print('<H1 Title="sin_cplx_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(50)
    for x in xlist:
        print('<H2 Title="sin(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx_user:
            res = ctx.sin(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sin_cplx_re_im_ctx():
    print('<H1 Title="sin_cplx_re_im_ctx">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="Re(sin(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx_user:
            res = ctx.sin(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.real(res)))
        print('</H2>')
        print()
        print('<H2 Title="Im(sin(x)); x=' + str(x) + '">')
        for ctx in gui.ctxlist_cplx_user:
            res = ctx.sin(x)
            print(ctx.fmtname + ': ' +  ctx.realctx.fmt(ctx.imag(res)))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sin_cplx_explicit():
    print('<H1 Title="demo_sin_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sin(x); x=' + str(x) + '">')
        res = m53libc.sin(x); print('cmath53: ' + m53libc.fmt(res))
        res = slibc.sin(x); print('  slibc: ' + slibc.fmt(res))
        res = dlibc.sin(x); print('  dlibc: ' + dlibc.fmt(res))
        res = elibc.sin(x); print('  elibc: ' + elibc.fmt(res))
        res = qlibc.sin(x); print('  qlibc: ' + qlibc.fmt(res))
        res = olibc.sin(x); print('  olibc: ' + olibc.fmt(res))
        if gui.has_xlcalcnet2:
            res = mlibc.sin(x); print('  mlibc: ' + mlibc.fmt(res))
            res = sflibc.sin(x); print('sflibc: ' + sflibc.fmt(res))
            res = dflibc.sin(x); print('dflibc: ' + dflibc.fmt(res))
            res = eflibc.sin(x); print('eflibc: ' + eflibc.fmt(res))
            res = qflibc.sin(x); print('qflibc: ' + qflibc.fmt(res))
            res = oflibc.sin(x); print('oflibc: ' + oflibc.fmt(res))
            res = mflibc.sin(x); print('mflibc: ' + mflibc.fmt(res))
            res = aflibc.sin(x); print('aflibc: ' + aflibc.fmt(res))
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











