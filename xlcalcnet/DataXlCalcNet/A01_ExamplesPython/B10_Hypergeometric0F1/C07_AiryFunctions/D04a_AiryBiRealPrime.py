
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
    demo_airy_bi_prime_real_ctx()
    demo_airy_bi_prime_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.airy_bi_prime(x, False)))
    print('</H1>')


def demo_airy_bi_prime_real_ctx():
    print('<H1 Title="demo_airy_bi_prime_real_ctx">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="airy_bi_prime(x); x=' + str(x) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.airy_bi_prime(x, scaled)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_airy_bi_prime_real_explicit():
    print('<H1 Title="demo_airy_bi_prime_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    for x in xlist:
        print('<H2 Title="airy_bi_prime(x); x=' + str(x) + '">')
        res = math53.airy_bi_prime(x, scaled); print('math53: ' + math53.fmt(res))
        res = sreal.airy_bi_prime(x, scaled); print(' sreal: ' + sreal.fmt(res))
        res = dreal.airy_bi_prime(x, scaled); print(' dreal: ' + dreal.fmt(res))
        res = ereal.airy_bi_prime(x, scaled); print(' ereal: ' + ereal.fmt(res))
        res = qreal.airy_bi_prime(x, scaled); print(' qreal: ' + qreal.fmt(res))
        res = oreal.airy_bi_prime(x, scaled); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.airy_bi_prime(x, scaled); print(' mreal: ' + mreal.fmt(res))
            res = sflint.airy_bi_prime(x, scaled); print('sflint: ' + sflint.fmt(res))
            res = dflint.airy_bi_prime(x, scaled); print('dflint: ' + dflint.fmt(res))
            res = eflint.airy_bi_prime(x, scaled); print('eflint: ' + eflint.fmt(res))
            res = qflint.airy_bi_prime(x, scaled); print('qflint: ' + qflint.fmt(res))
            res = oflint.airy_bi_prime(x, scaled); print('oflint: ' + oflint.fmt(res))
            res = mflint.airy_bi_prime(x, scaled); print('mflint: ' + mflint.fmt(res))
            res = aflint.airy_bi_prime(x, scaled); print('aflint: ' + aflint.fmt(res))
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











