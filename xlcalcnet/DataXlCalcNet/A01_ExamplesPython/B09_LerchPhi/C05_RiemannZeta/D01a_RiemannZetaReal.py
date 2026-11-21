
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    print('real zeta(s)')
    demo_manual_real()
    demo_zeta_real_ctx()
    demo_zeta_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    s = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.zeta(s)))
    print('</H1>')


def demo_zeta_real_ctx():
    print('<H1 Title="demo_zeta_real_ctx">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for s in slist:
        print('<H2 Title="zeta(s); s=' + str(s) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.zeta(s)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_zeta_real_explicit():
    print('<H1 Title="demo_zeta_real_zetalicit">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for s in slist:
        print('<H2 Title="zeta(s); s=' + str(s) + '">')
        res = math53.zeta(s); print('math53: ' + math53.fmt(res))
        res = sreal.zeta(s); print(' sreal: ' + sreal.fmt(res))
        res = dreal.zeta(s); print(' dreal: ' + dreal.fmt(res))
        res = ereal.zeta(s); print(' ereal: ' + ereal.fmt(res))
        res = qreal.zeta(s); print(' qreal: ' + qreal.fmt(res))
        res = oreal.zeta(s); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.zeta(s); print(' mreal: ' + mreal.fmt(res))
            res = sflint.zeta(s); print('sflint: ' + sflint.fmt(res))
            res = dflint.zeta(s); print('dflint: ' + dflint.fmt(res))
            res = eflint.zeta(s); print('eflint: ' + eflint.fmt(res))
            res = qflint.zeta(s); print('qflint: ' + qflint.fmt(res))
            res = oflint.zeta(s); print('oflint: ' + oflint.fmt(res))
            res = mflint.zeta(s); print('mflint: ' + mflint.fmt(res))
            res = aflint.zeta(s); print('aflint: ' + aflint.fmt(res))
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


