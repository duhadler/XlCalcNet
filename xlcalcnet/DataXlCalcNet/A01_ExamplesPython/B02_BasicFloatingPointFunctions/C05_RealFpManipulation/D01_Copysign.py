
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_copysign_real_ctx()
    demo_copysign_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    y = 1.0
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.copysign(x, y)))
    print('</H1>')


def demo_copysign_real_ctx():
    print('<H1 Title="demo_copysign_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    y = 1.0
    for x in xlist:
        print('<H2 Title="copysign(x, y); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.copysign(x, y)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_copysign_real_explicit():
    print('<H1 Title="demo_copysign_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    y = 1.0
    for x in xlist:
        print('<H2 Title="copysign(x, y); x=' + str(x) + '">')
        res = math53.copysign(x, y); print('math53: ' + math53.fmt(res))
        res = sreal.copysign(x, y); print(' sreal: ' + sreal.fmt(res))
        res = dreal.copysign(x, y); print(' dreal: ' + dreal.fmt(res))
        res = ereal.copysign(x, y); print(' ereal: ' + ereal.fmt(res))
        res = qreal.copysign(x, y); print(' qreal: ' + qreal.fmt(res))
        res = oreal.copysign(x, y); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.copysign(x, y); print(' mreal: ' + mreal.fmt(res))
            res = sflint.copysign(x, y); print('sflint: ' + sflint.fmt(res))
            res = dflint.copysign(x, y); print('dflint: ' + dflint.fmt(res))
            res = eflint.copysign(x, y); print('eflint: ' + eflint.fmt(res))
            res = qflint.copysign(x, y); print('qflint: ' + qflint.fmt(res))
            res = oflint.copysign(x, y); print('oflint: ' + oflint.fmt(res))
            res = mflint.copysign(x, y); print('mflint: ' + mflint.fmt(res))
            res = aflint.copysign(x, y); print('aflint: ' + aflint.fmt(res))
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











