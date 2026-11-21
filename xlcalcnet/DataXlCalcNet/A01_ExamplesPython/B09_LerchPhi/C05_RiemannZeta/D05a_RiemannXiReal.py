
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    print('real riemann_xi(t)')
    demo_manual_real()
    demo_riemann_xi_real_ctx()
    demo_riemann_xi_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    t = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.riemann_xi(t)))
    print('</H1>')


def demo_riemann_xi_real_ctx():
    print('<H1 Title="demo_riemann_xi_real_ctx">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for t in slist:
        print('<H2 Title="riemann_xi(t); t=' + str(t) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.riemann_xi(t)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_riemann_xi_real_explicit():
    print('<H1 Title="demo_riemann_xi_real_riemann_xilicit">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for t in slist:
        print('<H2 Title="riemann_xi(t); t=' + str(t) + '">')
        res = math53.riemann_xi(t); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.riemann_xi(t); print('sflint: ' + sflint.fmt(res))
            res = dflint.riemann_xi(t); print('dflint: ' + dflint.fmt(res))
            res = eflint.riemann_xi(t); print('eflint: ' + eflint.fmt(res))
            res = qflint.riemann_xi(t); print('qflint: ' + qflint.fmt(res))
            res = oflint.riemann_xi(t); print('oflint: ' + oflint.fmt(res))
            res = mflint.riemann_xi(t); print('mflint: ' + mflint.fmt(res))
            res = aflint.riemann_xi(t); print('aflint: ' + aflint.fmt(res))
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


