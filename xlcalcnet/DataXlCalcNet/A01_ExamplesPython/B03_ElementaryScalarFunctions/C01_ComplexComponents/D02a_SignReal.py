
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_sign_real_ctx()
    demo_sign_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sign(x)))
    print('</H1>')


def demo_sign_real_ctx():
    print('<H1 Title="demo_sign_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sign(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_real:
            res = ctx.sign(x)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_sign_real_explicit():
    print('<H1 Title="demo_sign_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="sign(x); x=' + str(x) + '">')
        res = math53.sign(x); print('math53: ' + math53.fmt(res))
        res = sreal.sign(x); print(' sreal: ' + sreal.fmt(res))
        res = dreal.sign(x); print(' dreal: ' + dreal.fmt(res))
        res = ereal.sign(x); print(' ereal: ' + ereal.fmt(res))
        res = qreal.sign(x); print(' qreal: ' + qreal.fmt(res))
        res = oreal.sign(x); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.sign(x); print(' mreal: ' + mreal.fmt(res))
            res = sflint.sign(x); print('sflint: ' + sflint.fmt(res))
            res = dflint.sign(x); print('dflint: ' + dflint.fmt(res))
            res = eflint.sign(x); print('eflint: ' + eflint.fmt(res))
            res = qflint.sign(x); print('qflint: ' + qflint.fmt(res))
            res = oflint.sign(x); print('oflint: ' + oflint.fmt(res))
            res = mflint.sign(x); print('mflint: ' + mflint.fmt(res))
            res = aflint.sign(x); print('aflint: ' + aflint.fmt(res))
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











