
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
    demo_hankel_h2_real_ctx()
    demo_hankel_h2_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    nu = 5.1; x = 2.7; gui.setdps(40)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.hankel_h2(nu, x, scaled=False)))
    print('</H1>')


def demo_hankel_h2_real_ctx():
    print('<H1 Title="demo_hankel_h2_real_ctx">')
    nulist = [5.1, 8.8]; gui.setdps(40)
    xlist = [1.5, 2.7];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="hankel_h2(nu, x, scaled); nu=' + str(nu) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.hankel_h2(nu, x, scaled)
                print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_hankel_h2_real_explicit():
    print('<H1 Title="demo_hankel_h2_real_explicit">')
    nulist = [5.1, 8.8]; gui.setdps(40)
    xlist = [1.5, 2.7];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="hankel_h2(nu, x, scaled); nu=' + str(nu) + ' x=' + str(x) + '">')
            res = math53.hankel_h2(nu, x, scaled); print('math53: ' + math53.cplxctx.fmt(res))
            res = sreal.hankel_h2(nu, x, scaled); print(' sreal: ' + sreal.cplxctx.fmt(res))
            res = dreal.hankel_h2(nu, x, scaled); print(' dreal: ' + dreal.cplxctx.fmt(res))
            res = ereal.hankel_h2(nu, x, scaled); print(' ereal: ' + ereal.cplxctx.fmt(res))
            res = qreal.hankel_h2(nu, x, scaled); print(' qreal: ' + qreal.cplxctx.fmt(res))
            res = oreal.hankel_h2(nu, x, scaled); print(' oreal: ' + oreal.cplxctx.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.hankel_h2(nu, x, scaled); print(' mreal: ' + mreal.cplxctx.fmt(res))
                res = sflint.hankel_h2(nu, x, scaled); print('sflint: ' + sflint.cplxctx.fmt(res))
                res = dflint.hankel_h2(nu, x, scaled); print('dflint: ' + dflint.cplxctx.fmt(res))
                res = eflint.hankel_h2(nu, x, scaled); print('eflint: ' + eflint.cplxctx.fmt(res))
                res = qflint.hankel_h2(nu, x, scaled); print('qflint: ' + qflint.cplxctx.fmt(res))
                res = oflint.hankel_h2(nu, x, scaled); print('oflint: ' + oflint.cplxctx.fmt(res))
                res = mflint.hankel_h2(nu, x, scaled); print('mflint: ' + mflint.cplxctx.fmt(res))
                res = aflint.hankel_h2(nu, x, scaled); print('aflint: ' + aflint.cplxctx.fmt(res))
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











