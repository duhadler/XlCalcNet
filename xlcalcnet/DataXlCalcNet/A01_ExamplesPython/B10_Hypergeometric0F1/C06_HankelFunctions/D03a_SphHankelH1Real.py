
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal

scaled = False

def main_tests():
    demo_manual_real()
    demo_sph_hankel_h1_real_ctx()
    demo_sph_hankel_h1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; x = 2.7; gui.setdps(40)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.sph_hankel_h1(n, x, scaled=False)))
    print('</H1>')


def demo_sph_hankel_h1_real_ctx():
    print('<H1 Title="demo_sph_hankel_h1_real_ctx">')
    nlist = [5, 8]; gui.setdps(40)
    xlist = [1.5, 2.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_hankel_h1(n, x, scaled); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.sph_hankel_h1(n, x, scaled)
                print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_sph_hankel_h1_real_explicit():
    print('<H1 Title="demo_sph_hankel_h1_real_explicit">')
    nlist = [5, 8]; gui.setdps(40)
    xlist = [1.5, 2.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_hankel_h1(n, x, scaled); n=' + str(n) + ' x=' + str(x) + '">')
            res = math53.sph_hankel_h1(n, x, scaled); print('math53: ' + math53.cplxctx.fmt(res))
            res = sreal.sph_hankel_h1(n, x, scaled); print(' sreal: ' + sreal.cplxctx.fmt(res))
            res = dreal.sph_hankel_h1(n, x, scaled); print(' dreal: ' + dreal.cplxctx.fmt(res))
            res = ereal.sph_hankel_h1(n, x, scaled); print(' ereal: ' + ereal.cplxctx.fmt(res))
            res = qreal.sph_hankel_h1(n, x, scaled); print(' qreal: ' + qreal.cplxctx.fmt(res))
            res = oreal.sph_hankel_h1(n, x, scaled); print(' oreal: ' + oreal.cplxctx.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.sph_hankel_h1(n, x, scaled); print(' mreal: ' + mreal.cplxctx.fmt(res))
                res = sflint.sph_hankel_h1(n, x, scaled); print('sflint: ' + sflint.cplxctx.fmt(res))
                res = dflint.sph_hankel_h1(n, x, scaled); print('dflint: ' + dflint.cplxctx.fmt(res))
                res = eflint.sph_hankel_h1(n, x, scaled); print('eflint: ' + eflint.cplxctx.fmt(res))
                res = qflint.sph_hankel_h1(n, x, scaled); print('qflint: ' + qflint.cplxctx.fmt(res))
                res = oflint.sph_hankel_h1(n, x, scaled); print('oflint: ' + oflint.cplxctx.fmt(res))
                res = mflint.sph_hankel_h1(n, x, scaled); print('mflint: ' + mflint.cplxctx.fmt(res))
                res = aflint.sph_hankel_h1(n, x, scaled); print('aflint: ' + aflint.cplxctx.fmt(res))
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











