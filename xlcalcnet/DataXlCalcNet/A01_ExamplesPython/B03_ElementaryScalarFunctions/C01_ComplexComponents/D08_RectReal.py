
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_rect_real_ctx()
    demo_rect_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from rlcalcnet import *
    r = 5.1; phi = 3.1; gui.setdps(40)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(ctx.rect(r, phi)))
    print('</H1>')


def demo_rect_real_ctx():
    print('<H1 Title="demo_rect_real_ctx">')
    rlist = [-5.1, 8.8]
    philist = [3.1, 1.8]; gui.setdps(40)
    for r in rlist:
        for phi in philist:
            print('<H2 Title="rect(r, phi); r=' + str(r) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.rect(r, phi)
                print(ctx.fmtname + ': ' + ctx.cplxctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_rect_real_explicit():
    print('<H1 Title="demo_rect_real_explicit">')
    rlist = [-5.1, 8.8]
    philist = [3.1, 1.8]; gui.setdps(40)
    for r in rlist:
        for phi in philist:
            print('<H2 Title="rect(r, phi); r=' + str(r) + '">')
            res = math53.rect(r, phi); print('math53: ' + math53.cplxctx.fmt(res))
            res = sreal.rect(r, phi); print(' sreal: ' + sreal.cplxctx.fmt(res))
            res = dreal.rect(r, phi); print(' dreal: ' + dreal.cplxctx.fmt(res))
            res = ereal.rect(r, phi); print(' ereal: ' + ereal.cplxctx.fmt(res))
            res = qreal.rect(r, phi); print(' qreal: ' + qreal.cplxctx.fmt(res))
            res = oreal.rect(r, phi); print(' oreal: ' + oreal.cplxctx.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.rect(r, phi); print(' mreal: ' + mreal.cplxctx.fmt(res))
                res = sflint.rect(r, phi); print('sflint: ' + sflint.cplxctx.fmt(res))
                res = dflint.rect(r, phi); print('dflint: ' + dflint.cplxctx.fmt(res))
                res = eflint.rect(r, phi); print('eflint: ' + eflint.cplxctx.fmt(res))
                res = qflint.rect(r, phi); print('qflint: ' + qflint.cplxctx.fmt(res))
                res = oflint.rect(r, phi); print('oflint: ' + oflint.cplxctx.fmt(res))
                res = mflint.rect(r, phi); print('mflint: ' + mflint.cplxctx.fmt(res))
                res = aflint.rect(r, phi); print('aflint: ' + aflint.cplxctx.fmt(res))
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











