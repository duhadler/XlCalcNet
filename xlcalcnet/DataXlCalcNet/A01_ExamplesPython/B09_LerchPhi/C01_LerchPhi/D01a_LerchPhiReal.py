
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_lerch_phi_real_ctx()
    demo_lerch_phi_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    z = -0.8; s = -0.5; a = 0.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.lerch_phi(z, s, a)))
    print('</H1>')


def demo_lerch_phi_real_ctx():
    print('<H1 Title="demo_lerch_phi_real_ctx">')
    gui.setdps(90)
    zlist = [-0.8, -0.1, 0.5]  # |z|<1
    slist = [-0.5, 2.5, 13.5]  # s>=-1
    alist = [0.1, 0.5, 13.5]  # a>=0
    for z in zlist:
        for s in slist:
            for a in alist:
                print('<H2 Title="lerch_phi(z, s, a); z=' + str(z) + ' s=' + str(s) + ' a=' + str(a) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.lerch_phi(z, s, a)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_lerch_phi_real_explicit():
    print('<H1 Title="demo_lerch_phi_real_explicit">')
    gui.setdps(90)
    zlist = [-0.8, -0.1, 0.5]  # |z|<1
    slist = [-0.5, 2.5, 13.5]  # s>=-1
    alist = [0.1, 0.5, 13.5]  # a>=0
    for z in zlist:
        for s in slist:
            for a in alist:
                print('<H2 Title="lerch_phi(z, s, a); z=' + str(z) + ' s=' + str(s) + ' a=' + str(a) + '">')
                res = math53.lerch_phi(z, s, a); print('math53: ' + math53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflint.lerch_phi(z, s, a); print('sflint: ' + sflint.fmt(res))
                    res = dflint.lerch_phi(z, s, a); print('dflint: ' + dflint.fmt(res))
                    res = eflint.lerch_phi(z, s, a); print('eflint: ' + eflint.fmt(res))
                    res = qflint.lerch_phi(z, s, a); print('qflint: ' + qflint.fmt(res))
                    res = oflint.lerch_phi(z, s, a); print('oflint: ' + oflint.fmt(res))
                    res = mflint.lerch_phi(z, s, a); print('mflint: ' + mflint.fmt(res))
                    res = aflint.lerch_phi(z, s, a); print('aflint: ' + aflint.fmt(res))
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











