
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
    demo_sph_bessel_kn_real_ctx()
    demo_sph_bessel_kn_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; x = 2.7; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sph_bessel_kn(n, x, scaled=False)))
    print('</H1>')


def demo_sph_bessel_kn_real_ctx():
    print('<H1 Title="demo_sph_bessel_kn_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_bessel_kn(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            for ctx in gui.ctxlist_noipm_real:
                res = ctx.sph_bessel_kn(n, x, scaled)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_sph_bessel_kn_real_explicit():
    print('<H1 Title="demo_sph_bessel_kn_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    xlist = [1.5, 2.7];
    for n in nlist:
        for x in xlist:
            print('<H2 Title="sph_bessel_kn(n, x); n=' + str(n) + ' x=' + str(x) + '">')
            res = math53.sph_bessel_kn(n, x, scaled); print('math53: ' + math53.fmt(res))
            res = sreal.sph_bessel_kn(n, x, scaled); print(' sreal: ' + sreal.fmt(res))
            res = dreal.sph_bessel_kn(n, x, scaled); print(' dreal: ' + dreal.fmt(res))
            res = ereal.sph_bessel_kn(n, x, scaled); print(' ereal: ' + ereal.fmt(res))
            res = qreal.sph_bessel_kn(n, x, scaled); print(' qreal: ' + qreal.fmt(res))
            res = oreal.sph_bessel_kn(n, x, scaled); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.sph_bessel_kn(n, x, scaled); print(' mreal: ' + mreal.fmt(res))
                res = sflint.sph_bessel_kn(n, x, scaled); print('sflint: ' + sflint.fmt(res))
                res = dflint.sph_bessel_kn(n, x, scaled); print('dflint: ' + dflint.fmt(res))
                res = eflint.sph_bessel_kn(n, x, scaled); print('eflint: ' + eflint.fmt(res))
                res = qflint.sph_bessel_kn(n, x, scaled); print('qflint: ' + qflint.fmt(res))
                res = oflint.sph_bessel_kn(n, x, scaled); print('oflint: ' + oflint.fmt(res))
                res = mflint.sph_bessel_kn(n, x, scaled); print('mflint: ' + mflint.fmt(res))
                res = aflint.sph_bessel_kn(n, x, scaled); print('aflint: ' + aflint.fmt(res))
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











