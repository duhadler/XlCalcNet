
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_pcfu_real_ctx()
    demo_pcfu_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    a = 1.5; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.pcfu(a, x)))
    print('</H1>')


def demo_pcfu_real_ctx():
    print('<H1 Title="demo_pcfu_real_ctx">')
    alist = [5, 8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for a in alist:
        for x in xlist:
            print('<H2 Title="pcfu(a, x); a=' + str(a) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.pcfu(a, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_pcfu_real_explicit():
    print('<H1 Title="demo_pcfu_real_explicit">')
    alist = [5, 8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for a in alist:
        for x in xlist:
            print('<H2 Title="pcfu(a, x); a=' + str(a) + ' x=' + str(x) + '">')
            res = math53.pcfu(a, x); print('math53: ' + math53.fmt(res))
#            res = sreal.pcfu(a, x); print(' sreal: ' + sreal.fmt(res))
#            res = dreal.pcfu(a, x); print(' dreal: ' + dreal.fmt(res))
#            res = ereal.pcfu(a, x); print(' ereal: ' + ereal.fmt(res))
#            res = qreal.pcfu(a, x); print(' qreal: ' + qreal.fmt(res))
#            res = oreal.pcfu(a, x); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
#                res = mreal.pcfu(a, x); print(' mreal: ' + mreal.fmt(res))
                res = sflint.pcfu(a, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.pcfu(a, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.pcfu(a, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.pcfu(a, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.pcfu(a, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.pcfu(a, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.pcfu(a, x); print('aflint: ' + aflint.fmt(res))
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


