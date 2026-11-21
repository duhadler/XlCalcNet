
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_isfinite_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 8.8, dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.isfinite(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_isfinite_real_explicit():
    print('<H1 Title="demo_isfinite_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 8.8, dreal.inf]
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="isfinite(x); x=' + str(x) + '">')
        res = math53.isfinite(x); print('math53: ', res)
        res = sreal.isfinite(x); print(' sreal: ', res)
        res = dreal.isfinite(x); print(' dreal: ', res)
        res = ereal.isfinite(x); print(' ereal: ', res)
        res = qreal.isfinite(x); print(' qreal: ', res)
        res = oreal.isfinite(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.isfinite(x); print(' mreal: ', res)
            res = sflint.isfinite(x); print('sflint: ', res)
            res = dflint.isfinite(x); print('dflint: ', res)
            res = eflint.isfinite(x); print('eflint: ', res)
            res = qflint.isfinite(x); print('qflint: ', res)
            res = oflint.isfinite(x); print('oflint: ', res)
            res = mflint.isfinite(x); print('mflint: ', res)
            res = aflint.isfinite(x); print('aflint: ', res)
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











