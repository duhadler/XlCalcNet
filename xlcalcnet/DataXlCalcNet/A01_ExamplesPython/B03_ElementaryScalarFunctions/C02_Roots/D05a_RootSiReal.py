
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_root_si_real_ctx()
    demo_root_si_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; n = 3; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.root_si(x, n)))
    print('</H1>')


def demo_root_si_real_ctx():
    print('<H1 Title="demo_root_si_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="root_si(x, n); x=' + str(x) + '">')
            for ctx in gui.ctxlist_real:
                res = ctx.root_si(x, n)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_root_si_real_explicit():
    print('<H1 Title="demo_root_si_real_explicit">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    nlist = [2, 3, 4]
    for x in xlist:
        for n in nlist:
            print('<H2 Title="root_si(x, n); x=' + str(x) + '">')
            res = math53.root_si(x, n); print('math53: ' + math53.fmt(res))
            res = sreal.root_si(x, n); print(' sreal: ' + sreal.fmt(res))
            res = dreal.root_si(x, n); print(' dreal: ' + dreal.fmt(res))
            res = ereal.root_si(x, n); print(' ereal: ' + ereal.fmt(res))
            res = qreal.root_si(x, n); print(' qreal: ' + qreal.fmt(res))
            res = oreal.root_si(x, n); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.root_si(x, n); print(' mreal: ' + mreal.fmt(res))
                res = sflint.root_si(x, n); print('sflint: ' + sflint.fmt(res))
                res = dflint.root_si(x, n); print('dflint: ' + dflint.fmt(res))
                res = eflint.root_si(x, n); print('eflint: ' + eflint.fmt(res))
                res = qflint.root_si(x, n); print('qflint: ' + qflint.fmt(res))
                res = oflint.root_si(x, n); print('oflint: ' + oflint.fmt(res))
                res = mflint.root_si(x, n); print('mflint: ' + mflint.fmt(res))
                res = aflint.root_si(x, n); print('aflint: ' + aflint.fmt(res))
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











