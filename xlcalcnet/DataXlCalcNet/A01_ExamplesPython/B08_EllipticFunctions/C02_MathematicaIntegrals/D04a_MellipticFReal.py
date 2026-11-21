
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_m_elliptic_f_real_ctx()
    demo_m_elliptic_f_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    phi = 0.75; m = 0.5; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.m_elliptic_f(phi, m)))
    print('</H1>')


def demo_m_elliptic_f_real_ctx():
    print('<H1 Title="demo_m_elliptic_f_real_ctx">')
    philist = [0.75, 0.5]; gui.setdps(90)
    mlist = [0.5, 0.2];
    for phi in philist:
        for m in mlist:
            print('<H2 Title="m_elliptic_f(phi, m); phi=' + str(phi) + ' m=' + str(m) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.m_elliptic_f(phi, m)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_m_elliptic_f_real_explicit():
    print('<H1 Title="demo_m_elliptic_f_real_explicit">')
    philist = [0.75, 0.5]; gui.setdps(90)
    mlist = [0.5, 0.2];
    for phi in philist:
        for m in mlist:
            print('<H2 Title="m_elliptic_f(phi, m); phi=' + str(phi) + ' m=' + str(m) + '">')
            res = math53.m_elliptic_f(phi, m); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.m_elliptic_f(phi, m); print('sflint: ' + sflint.fmt(res))
                res = dflint.m_elliptic_f(phi, m); print('dflint: ' + dflint.fmt(res))
                res = eflint.m_elliptic_f(phi, m); print('eflint: ' + eflint.fmt(res))
                res = qflint.m_elliptic_f(phi, m); print('qflint: ' + qflint.fmt(res))
                res = oflint.m_elliptic_f(phi, m); print('oflint: ' + oflint.fmt(res))
                res = mflint.m_elliptic_f(phi, m); print('mflint: ' + mflint.fmt(res))
                res = aflint.m_elliptic_f(phi, m); print('aflint: ' + aflint.fmt(res))
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











