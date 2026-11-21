
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_gamma_lower_real_ctx()
    demo_gamma_lower_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    a = 5.1; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.gamma_lower(a, x)))
    print('</H1>')


def demo_gamma_lower_real_ctx():
    print('<H1 Title="demo_gamma_lower_real_ctx">')
    alist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for a in alist:
        for x in xlist:
            print('<H2 Title="gamma_lower(a, x); a=' + str(a) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.gamma_lower(a, x)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_gamma_lower_real_explicit():
    print('<H1 Title="demo_gamma_lower_real_explicit">')
    alist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for a in alist:
        for x in xlist:
            print('<H2 Title="gamma_lower(a, x); a=' + str(a) + ' x=' + str(x) + '">')
            res = math53.gamma_lower(a, x); print('math53: ' + math53.fmt(res))
            res = sreal.gamma_lower(a, x); print(' sreal: ' + sreal.fmt(res))
            res = dreal.gamma_lower(a, x); print(' dreal: ' + dreal.fmt(res))
            res = ereal.gamma_lower(a, x); print(' ereal: ' + ereal.fmt(res))
            res = qreal.gamma_lower(a, x); print(' qreal: ' + qreal.fmt(res))
            res = oreal.gamma_lower(a, x); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.gamma_lower(a, x); print(' mreal: ' + mreal.fmt(res))
                res = sflint.gamma_lower(a, x); print('sflint: ' + sflint.fmt(res))
                res = dflint.gamma_lower(a, x); print('dflint: ' + dflint.fmt(res))
                res = eflint.gamma_lower(a, x); print('eflint: ' + eflint.fmt(res))
                res = qflint.gamma_lower(a, x); print('qflint: ' + qflint.fmt(res))
                res = oflint.gamma_lower(a, x); print('oflint: ' + oflint.fmt(res))
                res = mflint.gamma_lower(a, x); print('mflint: ' + mflint.fmt(res))
                res = aflint.gamma_lower(a, x); print('aflint: ' + aflint.fmt(res))
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











