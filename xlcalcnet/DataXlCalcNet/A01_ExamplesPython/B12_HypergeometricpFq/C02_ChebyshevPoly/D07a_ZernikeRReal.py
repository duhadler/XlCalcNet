
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_zernike_r_real_ctx()
    demo_zernike_r_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; m = 1; x = 1.3; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.zernike_r(n, m, x)))
    print('</H1>')


def demo_zernike_r_real_ctx():
    print('<H1 Title="demo_zernike_r_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [5, 7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="zernike_r(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                for ctx in gui.ctxlist_noipm_real:
                    res = ctx.zernike_r(n, m, x)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_zernike_r_real_explicit():
    print('<H1 Title="demo_zernike_r_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    mlist = [5, 7];
    xlist = [2.9, 5.4];
    for n in nlist:
        for m in mlist:
            for x in xlist:
                print('<H2 Title="zernike_r(n, m, x); n=' + str(n) + ' m=' + str(m) + ' x=' + str(x) + '">')
                res = math53.zernike_r(n, m, x); print('math53: ' + math53.fmt(res))
                res = sreal.zernike_r(n, m, x); print(' sreal: ' + sreal.fmt(res))
                res = dreal.zernike_r(n, m, x); print(' dreal: ' + dreal.fmt(res))
                res = ereal.zernike_r(n, m, x); print(' ereal: ' + ereal.fmt(res))
                res = qreal.zernike_r(n, m, x); print(' qreal: ' + qreal.fmt(res))
                res = oreal.zernike_r(n, m, x); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.zernike_r(n, m, x); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.zernike_r(n, m, x); print('sflint: ' + sflint.fmt(res))
                    res = dflint.zernike_r(n, m, x); print('dflint: ' + dflint.fmt(res))
                    res = eflint.zernike_r(n, m, x); print('eflint: ' + eflint.fmt(res))
                    res = qflint.zernike_r(n, m, x); print('qflint: ' + qflint.fmt(res))
                    res = oflint.zernike_r(n, m, x); print('oflint: ' + oflint.fmt(res))
                    res = mflint.zernike_r(n, m, x); print('mflint: ' + mflint.fmt(res))
                    res = aflint.zernike_r(n, m, x); print('aflint: ' + aflint.fmt(res))
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











