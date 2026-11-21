
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_lommel_s1_real_ctx()
    demo_lommel_s1_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    nu = 5; mu = 3; x = 0.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.lommel_s1(nu, mu, x)))
    print('</H1>')


def demo_lommel_s1_real_ctx():
    print('<H1 Title="demo_lommel_s1_real_ctx">')
    nulist = [5, 8]; gui.setdps(90)
    mulist = [3, 4];
    xlist = [0.9, 0.4];
    for nu in nulist:
        for mu in mulist:
            for x in xlist:
                print('<H2 Title="lommel_s1(nu, mu, x); nu=' + str(nu) + ' mu=' + str(mu) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noboost_real:
                    res = ctx.lommel_s1(nu, mu, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_lommel_s1_real_explicit():
    print('<H1 Title="demo_lommel_s1_real_explicit">')
    nulist = [5, 8]; gui.setdps(90)
    mulist = [3, 4];
    xlist = [0.9, 0.4];
    for nu in nulist:
        for mu in mulist:
            for x in xlist:
                print('<H2 Title="lommel_s1(nu, mu, x); nu=' + str(nu) + ' mu=' + str(mu) + ' x=' + str(x) + '">')
                res = math53.lommel_s1(nu, mu, x); print('math53: ' + math53.fmt(res))
                if gui.has_xlcalcnet2:
                    res = sflint.lommel_s1(nu, mu, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.lommel_s1(nu, mu, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.lommel_s1(nu, mu, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.lommel_s1(nu, mu, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.lommel_s1(nu, mu, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.lommel_s1(nu, mu, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.lommel_s1(nu, mu, x); print('aflint: ' + aflint.fmt(res))
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











