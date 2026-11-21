
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_trilog_real_ctx()
    demo_trilog_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    z = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.trilog(z)))
    print('</H1>')


def demo_trilog_real_ctx():
    print('<H1 Title="demo_trilog_real_ctx">')
    zlist = [-5.1, 8.8]; gui.setdps(90)
    for z in zlist:
        print('<H2 Title="trilog(z); z=' + str(z) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.trilog(z)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_trilog_real_explicit():
    print('<H1 Title="demo_trilog_real_explicit">')
    zlist = [-5.1, 8.8]; gui.setdps(90)
    for z in zlist:
        print('<H2 Title="trilog(z); z=' + str(z) + '">')
        res = math53.trilog(z); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.trilog(z); print('sflint: ' + sflint.fmt(res))
            res = dflint.trilog(z); print('dflint: ' + dflint.fmt(res))
            res = eflint.trilog(z); print('eflint: ' + eflint.fmt(res))
            res = qflint.trilog(z); print('qflint: ' + qflint.fmt(res))
            res = oflint.trilog(z); print('oflint: ' + oflint.fmt(res))
            res = mflint.trilog(z); print('mflint: ' + mflint.fmt(res))
            res = aflint.trilog(z); print('aflint: ' + aflint.fmt(res))
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











