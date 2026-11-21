
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal

scaled = False

def main_tests():
    demo_manual_real()
    demo_bessel_iv_real_ctx()
    demo_bessel_iv_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    nu = 5.1; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.bessel_iv(nu, x, scaled=False)))
    print('</H1>')


def demo_bessel_iv_real_ctx():
    print('<H1 Title="demo_bessel_iv_real_ctx">')
    nulist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="bessel_iv(nu, x); nu=' + str(nu) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.bessel_iv(nu, x, scaled)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_bessel_iv_real_explicit():
    print('<H1 Title="demo_bessel_iv_real_explicit">')
    nulist = [5.1, 8.8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for nu in nulist:
        for x in xlist:
            print('<H2 Title="bessel_iv(nu, x); nu=' + str(nu) + ' x=' + str(x) + '">')
            res = math53.bessel_iv(nu, x, scaled); print('math53: ' + math53.fmt(res))
            res = sreal.bessel_iv(nu, x, scaled); print(' sreal: ' + sreal.fmt(res))
            res = dreal.bessel_iv(nu, x, scaled); print(' dreal: ' + dreal.fmt(res))
            res = ereal.bessel_iv(nu, x, scaled); print(' ereal: ' + ereal.fmt(res))
            res = qreal.bessel_iv(nu, x, scaled); print(' qreal: ' + qreal.fmt(res))
            res = oreal.bessel_iv(nu, x, scaled); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.bessel_iv(nu, x, scaled); print(' mreal: ' + mreal.fmt(res))
                res = sflint.bessel_iv(nu, x, scaled); print('sflint: ' + sflint.fmt(res))
                res = dflint.bessel_iv(nu, x, scaled); print('dflint: ' + dflint.fmt(res))
                res = eflint.bessel_iv(nu, x, scaled); print('eflint: ' + eflint.fmt(res))
                res = qflint.bessel_iv(nu, x, scaled); print('qflint: ' + qflint.fmt(res))
                res = oflint.bessel_iv(nu, x, scaled); print('oflint: ' + oflint.fmt(res))
                res = mflint.bessel_iv(nu, x, scaled); print('mflint: ' + mflint.fmt(res))
                res = aflint.bessel_iv(nu, x, scaled); print('aflint: ' + aflint.fmt(res))
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











