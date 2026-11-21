
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_eulernum_real_ctx()
    demo_eulernum_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 16; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.eulernum(n)))
    print('</H1>')


def demo_eulernum_real_ctx():
    print('<H1 Title="demo_eulernum_real_ctx">')
    nlist = [0, 1, 2, 4, 6, 8, 10]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="eulernum(n); n=' + str(n) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.eulernum(n)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_eulernum_real_explicit():
    print('<H1 Title="demo_eulernum_real_explicit">')
    nlist = [0, 1, 2, 4, 6, 8, 10]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="eulernum(n); n=' + str(n) + '">')
        res = math53.eulernum(n); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.eulernum(n); print('sflint: ' + sflint.fmt(res))
            res = dflint.eulernum(n); print('dflint: ' + dflint.fmt(res))
            res = eflint.eulernum(n); print('eflint: ' + eflint.fmt(res))
            res = qflint.eulernum(n); print('qflint: ' + qflint.fmt(res))
            res = oflint.eulernum(n); print('oflint: ' + oflint.fmt(res))
            res = mflint.eulernum(n); print('mflint: ' + mflint.fmt(res))
            res = aflint.eulernum(n); print('aflint: ' + aflint.fmt(res))
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











