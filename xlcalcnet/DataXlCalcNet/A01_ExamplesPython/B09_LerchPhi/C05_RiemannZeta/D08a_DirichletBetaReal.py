
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    print('real dirichlet_beta(t)')
    demo_manual_real()
    demo_dirichlet_beta_real_ctx()
    demo_dirichlet_beta_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    t = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.dirichlet_beta(t)))
    print('</H1>')


def demo_dirichlet_beta_real_ctx():
    print('<H1 Title="demo_dirichlet_beta_real_ctx">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for t in slist:
        print('<H2 Title="dirichlet_beta(t); t=' + str(t) + '">')
        for ctx in gui.ctxlist_noboost_real:
            res = ctx.dirichlet_beta(t)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_dirichlet_beta_real_explicit():
    print('<H1 Title="demo_dirichlet_beta_real_dirichlet_betalicit">')
    slist = [-5.1, 8.8]; gui.setdps(90)
    for t in slist:
        print('<H2 Title="dirichlet_beta(t); t=' + str(t) + '">')
        res = math53.dirichlet_beta(t); print('math53: ' + math53.fmt(res))
        if gui.has_xlcalcnet2:
            res = sflint.dirichlet_beta(t); print('sflint: ' + sflint.fmt(res))
            res = dflint.dirichlet_beta(t); print('dflint: ' + dflint.fmt(res))
            res = eflint.dirichlet_beta(t); print('eflint: ' + eflint.fmt(res))
            res = qflint.dirichlet_beta(t); print('qflint: ' + qflint.fmt(res))
            res = oflint.dirichlet_beta(t); print('oflint: ' + oflint.fmt(res))
            res = mflint.dirichlet_beta(t); print('mflint: ' + mflint.fmt(res))
            res = aflint.dirichlet_beta(t); print('aflint: ' + aflint.fmt(res))
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


