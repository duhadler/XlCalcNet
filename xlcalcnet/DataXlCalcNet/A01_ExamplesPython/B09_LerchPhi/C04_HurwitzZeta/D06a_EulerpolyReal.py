
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_eulerpoly_real_ctx()
    demo_eulerpoly_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 12; z = 4.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.eulerpoly(n, z)))
    print('</H1>')


def demo_eulerpoly_real_ctx():
    print('<H1 Title="demo_eulerpoly_real_ctx">')
    gui.setdps(90)
    nlist = [12, 23, 34]
    zlist = [-3.333, 0.0, 4.3]
    for n in nlist:
        for z in zlist:
            print('<H2 Title="eulerpoly(n, z); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.eulerpoly(n, z)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_eulerpoly_real_explicit():
    print('<H1 Title="demo_eulerpoly_real_explicit">')
    gui.setdps(90)
    nlist = [12, 23, 34]
    zlist = [-3.333, 0.0, 4.3]
    for n in nlist:
        for z in zlist:
            print('<H2 Title="eulerpoly(n, z); z=' + str(z) + '">')
            res = math53.eulerpoly(n, z); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.eulerpoly(n, z); print('sflint: ' + sflint.fmt(res))
                res = dflint.eulerpoly(n, z); print('dflint: ' + dflint.fmt(res))
                res = eflint.eulerpoly(n, z); print('eflint: ' + eflint.fmt(res))
                res = qflint.eulerpoly(n, z); print('qflint: ' + qflint.fmt(res))
                res = oflint.eulerpoly(n, z); print('oflint: ' + oflint.fmt(res))
                res = mflint.eulerpoly(n, z); print('mflint: ' + mflint.fmt(res))
                res = aflint.eulerpoly(n, z); print('aflint: ' + aflint.fmt(res))
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











