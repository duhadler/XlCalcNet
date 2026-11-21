
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_isnormal_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 1.0, 8.8, dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.isnormal(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_isnormal_real_explicit():
    print('<H1 Title="demo_isnormal_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 1.0, 8.8, dreal.inf]
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="isnormal(x); x=' + str(x) + '">')
        res = math53.isnormal(x); print('math53: ', res)
        res = sreal.isnormal(x); print(' sreal: ', res)
        res = dreal.isnormal(x); print(' dreal: ', res)
        res = ereal.isnormal(x); print(' ereal: ', res)
        res = qreal.isnormal(x); print(' qreal: ', res)
        res = oreal.isnormal(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.isnormal(x); print(' mreal: ', res)
            res = sflint.isnormal(x); print('sflint: ', res)
            res = dflint.isnormal(x); print('dflint: ', res)
            res = eflint.isnormal(x); print('eflint: ', res)
            res = qflint.isnormal(x); print('qflint: ', res)
            res = oflint.isnormal(x); print('oflint: ', res)
            res = mflint.isnormal(x); print('mflint: ', res)
            res = aflint.isnormal(x); print('aflint: ', res)
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











