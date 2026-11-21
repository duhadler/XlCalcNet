
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_dilog_real_ctx()
    demo_dilog_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    z = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.dilog(z)))
    print('</H1>')


def demo_dilog_real_ctx():
    print('<H1 Title="demo_dilog_real_ctx">')
    zlist = [-5.1, 8.8]; gui.setdps(90)
    for z in zlist:
        print('<H2 Title="dilog(z); z=' + str(z) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.dilog(z)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_dilog_real_explicit():
    print('<H1 Title="demo_dilog_real_explicit">')
    zlist = [-5.1, 8.8]; gui.setdps(90)
    for z in zlist:
        print('<H2 Title="dilog(z); z=' + str(z) + '">')
        res = math53.dilog(z); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.dilog(z); print('sflint: ' + sflint.fmt(res))
            res = dflint.dilog(z); print('dflint: ' + dflint.fmt(res))
            res = eflint.dilog(z); print('eflint: ' + eflint.fmt(res))
            res = qflint.dilog(z); print('qflint: ' + qflint.fmt(res))
            res = oflint.dilog(z); print('oflint: ' + oflint.fmt(res))
            res = mflint.dilog(z); print('mflint: ' + mflint.fmt(res))
            res = aflint.dilog(z); print('aflint: ' + aflint.fmt(res))
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











