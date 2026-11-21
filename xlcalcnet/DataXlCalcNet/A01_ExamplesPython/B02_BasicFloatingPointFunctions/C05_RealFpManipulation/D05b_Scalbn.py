
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_scalbn_real_ctx()
    demo_scalbn_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    e = 10
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.scalbn(x, e)))
    print('</H1>')


def demo_scalbn_real_ctx():
    print('<H1 Title="demo_scalbn_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    e = 10
    for x in xlist:
        print('<H2 Title="scalbn(x, e); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.scalbn(x, e)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_scalbn_real_explicit():
    print('<H1 Title="demo_scalbn_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    e = 10
    for x in xlist:
        print('<H2 Title="scalbn(x, e); x=' + str(x) + '">')
        res = math53.scalbn(x, e); print('math53: ' + math53.fmt(res))
        res = sreal.scalbn(x, e); print(' sreal: ' + sreal.fmt(res))
        res = dreal.scalbn(x, e); print(' dreal: ' + dreal.fmt(res))
        res = ereal.scalbn(x, e); print(' ereal: ' + ereal.fmt(res))
        res = qreal.scalbn(x, e); print(' qreal: ' + qreal.fmt(res))
        res = oreal.scalbn(x, e); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.scalbn(x, e); print(' mreal: ' + mreal.fmt(res))
            res = sflint.scalbn(x, e); print('sflint: ' + sflint.fmt(res))
            res = dflint.scalbn(x, e); print('dflint: ' + dflint.fmt(res))
            res = eflint.scalbn(x, e); print('eflint: ' + eflint.fmt(res))
            res = qflint.scalbn(x, e); print('qflint: ' + qflint.fmt(res))
            res = oflint.scalbn(x, e); print('oflint: ' + oflint.fmt(res))
            res = mflint.scalbn(x, e); print('mflint: ' + mflint.fmt(res))
            res = aflint.scalbn(x, e); print('aflint: ' + aflint.fmt(res))
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











