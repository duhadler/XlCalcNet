
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_fma_real_ctx()
    demo_fma_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    x = 5.1; y = 2.7;  z = 3.5; gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.fma(x, y, z)))
    print('</H1>')


def demo_fma_real_ctx():
    print('<H1 Title="demo_fma_real_ctx">')
    xlist = [5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [3.5, 6.4];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="fma(x, y, z); x=' + str(x) + ' y=' + str(y) + ' z=' + str(z) + '">')
                for ctx in gui.ctxlist_real:
                    res = ctx.fma(x, y, z)
                    print(ctx.fmtname + ': ' + ctx.fmt(res))
                print('</H2>')
                print()
    print('</H1>')
    print()


def demo_fma_real_explicit():
    print('<H1 Title="demo_fma_real_explicit">')
    xlist = [-5.1, 8.8]; gui.setdps(90)
    ylist = [1.5, 2.7];
    zlist = [3.5, 6.4];
    for x in xlist:
        for y in ylist:
            for z in zlist:
                print('<H2 Title="fma(x, y, z); x=' + str(x) + ' y=' + str(y) + '">')
                res = math53.fma(x, y, z); print('math53: ' + math53.fmt(res))
                res = sreal.fma(x, y, z); print(' sreal: ' + sreal.fmt(res))
                res = dreal.fma(x, y, z); print(' dreal: ' + dreal.fmt(res))
                res = ereal.fma(x, y, z); print(' ereal: ' + ereal.fmt(res))
                res = qreal.fma(x, y, z); print(' qreal: ' + qreal.fmt(res))
                res = oreal.fma(x, y, z); print(' oreal: ' + oreal.fmt(res))
                if gui.has_xlcalcnet2:
                    res = mreal.fma(x, y, z); print(' mreal: ' + mreal.fmt(res))
                    res = sflint.fma(x, y, z); print('sflint: ' + sflint.fmt(res))
                    res = dflint.fma(x, y, z); print('dflint: ' + dflint.fmt(res))
                    res = eflint.fma(x, y, z); print('eflint: ' + eflint.fmt(res))
                    res = qflint.fma(x, y, z); print('qflint: ' + qflint.fmt(res))
                    res = oflint.fma(x, y, z); print('oflint: ' + oflint.fmt(res))
                    res = mflint.fma(x, y, z); print('mflint: ' + mflint.fmt(res))
                    res = aflint.fma(x, y, z); print('aflint: ' + aflint.fmt(res))
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











