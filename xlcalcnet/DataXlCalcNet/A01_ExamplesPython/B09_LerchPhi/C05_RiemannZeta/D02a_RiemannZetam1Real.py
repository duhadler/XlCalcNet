
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    print('real zetam1(s)')
    demo_manual_real()
    demo_zetam1_real_ctx()
    demo_zetam1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    s = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.zetam1(s)))
    print('</H1>')


def demo_zetam1_real_ctx():
    print('<H1 Title="demo_zetam1_real_ctx">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for s in slist:
        print('<H2 Title="zetam1(s); s=' + str(s) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.zetam1(s)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_zetam1_real_explicit():
    print('<H1 Title="demo_zetam1_real_zetam1licit">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for s in slist:
        print('<H2 Title="zetam1(s); s=' + str(s) + '">')
        res = math53.zetam1(s); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.zetam1(s); print('sflint: ' + sflint.fmt(res))
            res = dflint.zetam1(s); print('dflint: ' + dflint.fmt(res))
            res = eflint.zetam1(s); print('eflint: ' + eflint.fmt(res))
            res = qflint.zetam1(s); print('qflint: ' + qflint.fmt(res))
            res = oflint.zetam1(s); print('oflint: ' + oflint.fmt(res))
            res = mflint.zetam1(s); print('mflint: ' + mflint.fmt(res))
            res = aflint.zetam1(s); print('aflint: ' + aflint.fmt(res))
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


