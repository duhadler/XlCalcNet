
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_jacobi_p_real_ctx()
    demo_jacobi_p_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    n = 5; a = 2.7; b = 1.3; x = 0.4; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.jacobi_p(n, a, b, x)))
    print('</H1>')


def demo_jacobi_p_real_ctx():
    print('<H1 Title="demo_jacobi_p_real_ctx">')
    nlist = [5, 8]; gui.setdps(90)
    alist = [1.5, 2.7];
    blist = [2.9, 5.4];
    xlist = [0.3, 0.2];
    for n in nlist:
        for a in alist:
            for b in blist:
                for x in xlist:
                    print('<H2 Title="jacobi_p(n, a, b, x); n=' + str(n) 
                        + ' a=' + str(a) + ' b=' + str(b)  + ' x=' + str(x) + '">')
                    for ctx in gui.ctxlist_noipm_real:
                        res = ctx.jacobi_p(n, a, b, x)
                        print(ctx.fmtname + ': ' + ctx.fmt(res))
                    print('</H2>')
                    print()
    print('</H1>')
    print()


def demo_jacobi_p_real_explicit():
    print('<H1 Title="demo_jacobi_p_real_explicit">')
    nlist = [5, 8]; gui.setdps(90)
    alist = [1.5, 2.7];
    blist = [2.9, 5.4];
    xlist = [0.3, 0.2];
    for n in nlist:
        for a in alist:
            for b in blist:
                for x in xlist:
                    print('<H2 Title="jacobi_p(n, a, b, x); n=' + str(n) + ' a=' + str(a) + ' b=' + str(b)  + ' x=' + str(x) + '">')
                    res = math53.jacobi_p(n, a, b, x); print('math53: ' + math53.fmt(res))
                    res = sreal.jacobi_p(n, a, b, x); print('math53: ' + sreal.fmt(res))
                    res = dreal.jacobi_p(n, a, b, x); print('math53: ' + dreal.fmt(res))
                    res = ereal.jacobi_p(n, a, b, x); print('math53: ' + ereal.fmt(res))
                    res = qreal.jacobi_p(n, a, b, x); print('math53: ' + qreal.fmt(res))
                    res = oreal.jacobi_p(n, a, b, x); print('math53: ' + oreal.fmt(res))
                    if gui.has_xlcalcnet2:
                        res = mreal.jacobi_p(n, a, b, x); print('math53: ' + mreal.fmt(res))
                        res = sflint.jacobi_p(n, a, b, x); print('sflint: ' + sflint.fmt(res))
                        res = dflint.jacobi_p(n, a, b, x); print('dflint: ' + dflint.fmt(res))
                        res = eflint.jacobi_p(n, a, b, x); print('eflint: ' + eflint.fmt(res))
                        res = qflint.jacobi_p(n, a, b, x); print('qflint: ' + qflint.fmt(res))
                        res = oflint.jacobi_p(n, a, b, x); print('oflint: ' + oflint.fmt(res))
                        res = mflint.jacobi_p(n, a, b, x); print('mflint: ' + mflint.fmt(res))
                        res = aflint.jacobi_p(n, a, b, x); print('aflint: ' + aflint.fmt(res))
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











