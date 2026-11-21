
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_bernoulli_real_ctx()
    demo_bernoulli_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 16; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.bernoulli(n)))
    print('</H1>')


def demo_bernoulli_real_ctx():
    print('<H1 Title="demo_bernoulli_real_ctx">')
    nlist = [0, 1, 2, 4, 6, 8, 10]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="bernoulli(n); n=' + str(n) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.bernoulli(n)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_bernoulli_real_explicit():
    print('<H1 Title="demo_bernoulli_real_explicit">')
    nlist = [0, 1, 2, 4, 6, 8, 10]; gui.setdps(90)
    for n in nlist:
        print('<H2 Title="bernoulli(n); n=' + str(n) + '">')
        res = math53.bernoulli(n); print('math53: ' + math53.fmt(res))
        res = sreal.bernoulli(n); print(' sreal: ' + sreal.fmt(res))
        res = dreal.bernoulli(n); print(' dreal: ' + dreal.fmt(res))
        res = ereal.bernoulli(n); print(' ereal: ' + ereal.fmt(res))
        res = qreal.bernoulli(n); print(' qreal: ' + qreal.fmt(res))
        res = oreal.bernoulli(n); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.bernoulli(n); print(' mreal: ' + mreal.fmt(res))
            res = sflint.bernoulli(n); print('sflint: ' + sflint.fmt(res))
            res = dflint.bernoulli(n); print('dflint: ' + dflint.fmt(res))
            res = eflint.bernoulli(n); print('eflint: ' + eflint.fmt(res))
            res = qflint.bernoulli(n); print('qflint: ' + qflint.fmt(res))
            res = oflint.bernoulli(n); print('oflint: ' + oflint.fmt(res))
            res = mflint.bernoulli(n); print('mflint: ' + mflint.fmt(res))
            res = aflint.bernoulli(n); print('aflint: ' + aflint.fmt(res))
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











