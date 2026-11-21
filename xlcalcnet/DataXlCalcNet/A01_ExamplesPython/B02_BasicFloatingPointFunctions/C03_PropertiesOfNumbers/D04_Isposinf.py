
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_isposinf_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 8.8, dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []; 
        for x in xlist: res.append(ctx.isposinf(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_isposinf_real_explicit():
    print('<H1 Title="demo_isposinf_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 8.8, dreal.inf]
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="isposinf(x); x=' + str(x) + '">')
        res = math53.isposinf(x); print('math53: ', res)
        res = sreal.isposinf(x); print(' sreal: ', res)
        res = dreal.isposinf(x); print(' dreal: ', res)
        res = ereal.isposinf(x); print(' ereal: ', res)
        res = qreal.isposinf(x); print(' qreal: ', res)
        res = oreal.isposinf(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.isposinf(x); print(' mreal: ', res)
            res = sflint.isposinf(x); print('sflint: ', res)
            res = dflint.isposinf(x); print('dflint: ', res)
            res = eflint.isposinf(x); print('eflint: ', res)
            res = qflint.isposinf(x); print('qflint: ', res)
            res = oflint.isposinf(x); print('oflint: ', res)
            res = mflint.isposinf(x); print('mflint: ', res)
            res = aflint.isposinf(x); print('aflint: ', res)
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











