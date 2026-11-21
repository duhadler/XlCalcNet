
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
    demo_sph_bessel_jn_zero_real_ctx()
    demo_sph_bessel_jn_zero_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; m = 2; gui.setdps(90)
    for ctx in gui.ctxlist_boost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.sph_bessel_jn_zero(n, m)))
    print('</H1>')


def demo_sph_bessel_jn_zero_real_ctx():
    print('<H1 Title="demo_sph_bessel_jn_zero_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [1, 2, 4, 6, 8, 10];
    for n in nlist:
        for m in mlist:
            print('<H2 Title="sph_bessel_jn_zero(n, m); n=' + str(n) + ' m=' + str(m) + '">')
            for ctx in gui.ctxlist_boost_real:
                res = ctx.sph_bessel_jn_zero(n, m)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_sph_bessel_jn_zero_real_explicit():
    print('<H1 Title="demo_sph_bessel_jn_zero_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [1, 2, 4, 6, 8, 10];
    for n in nlist:
        for m in mlist:
            print('<H2 Title="sph_bessel_jn_zero(n, m); n=' + str(n) + ' m=' + str(m) + '">')
            res = math53.sph_bessel_jn_zero(n, m); print('math53: ' + math53.fmt(res))
            res = sreal.sph_bessel_jn_zero(n, m); print(' sreal: ' + sreal.fmt(res))
            res = dreal.sph_bessel_jn_zero(n, m); print(' dreal: ' + dreal.fmt(res))
            res = ereal.sph_bessel_jn_zero(n, m); print(' ereal: ' + ereal.fmt(res))
            res = qreal.sph_bessel_jn_zero(n, m); print(' qreal: ' + qreal.fmt(res))
            res = oreal.sph_bessel_jn_zero(n, m); print(' oreal: ' + oreal.fmt(res))
            if gui.has_xlcalcnet2:
                res = mreal.sph_bessel_jn_zero(n, m); print(' mreal: ' + mreal.fmt(res))
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











