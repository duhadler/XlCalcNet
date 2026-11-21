
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_clausen_cos_real_ctx()
    demo_clausen_cos_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    s = 3; z = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.clausen_cos(s, z)))
    print('</H1>')


def demo_clausen_cos_real_ctx():
    print('<H1 Title="demo_clausen_cos_real_ctx">')
    gui.setdps(90)
    slist = [2, 3, 4]
    zlist = [-5.1, 0.8]
    for s in slist:
        for z in zlist:
            print('<H2 Title="clausen_cos(s, z); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.clausen_cos(s, z)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_clausen_cos_real_explicit():
    print('<H1 Title="demo_clausen_cos_real_explicit">')
    gui.setdps(90)
    slist = [2, 3, 4]
    zlist = [-5.1, 0.8]
    for s in slist:
        for z in zlist:
            print('<H2 Title="clausen_cos(s, z); z=' + str(z) + '">')
            res = math53.clausen_cos(s, z); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.clausen_cos(s, z); print('sflint: ' + sflint.fmt(res))
                res = dflint.clausen_cos(s, z); print('dflint: ' + dflint.fmt(res))
                res = eflint.clausen_cos(s, z); print('eflint: ' + eflint.fmt(res))
                res = qflint.clausen_cos(s, z); print('qflint: ' + qflint.fmt(res))
                res = oflint.clausen_cos(s, z); print('oflint: ' + oflint.fmt(res))
                res = mflint.clausen_cos(s, z); print('mflint: ' + mflint.fmt(res))
                res = aflint.clausen_cos(s, z); print('aflint: ' + aflint.fmt(res))
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











