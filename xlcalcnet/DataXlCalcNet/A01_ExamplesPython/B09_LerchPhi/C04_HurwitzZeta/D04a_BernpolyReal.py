
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_bernpoly_real_ctx()
    demo_bernpoly_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 12; z = 4.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.bernpoly(n, z)))
    print('</H1>')


def demo_bernpoly_real_ctx():
    print('<H1 Title="demo_bernpoly_real_ctx">')
    gui.setdps(90)
    nlist = [12, 23, 34]
    zlist = [-3.333, 0.0, 4.3]
    for n in nlist:
        for z in zlist:
            print('<H2 Title="bernpoly(n, z); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.bernpoly(n, z)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_bernpoly_real_explicit():
    print('<H1 Title="demo_bernpoly_real_explicit">')
    gui.setdps(90)
    nlist = [12, 23, 34]
    zlist = [-3.333, 0.0, 4.3]
    for n in nlist:
        for z in zlist:
            print('<H2 Title="bernpoly(n, z); z=' + str(z) + '">')
            res = math53.bernpoly(n, z); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.bernpoly(n, z); print('sflint: ' + sflint.fmt(res))
                res = dflint.bernpoly(n, z); print('dflint: ' + dflint.fmt(res))
                res = eflint.bernpoly(n, z); print('eflint: ' + eflint.fmt(res))
                res = qflint.bernpoly(n, z); print('qflint: ' + qflint.fmt(res))
                res = oflint.bernpoly(n, z); print('oflint: ' + oflint.fmt(res))
                res = mflint.bernpoly(n, z); print('mflint: ' + mflint.fmt(res))
                res = aflint.bernpoly(n, z); print('aflint: ' + aflint.fmt(res))
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











