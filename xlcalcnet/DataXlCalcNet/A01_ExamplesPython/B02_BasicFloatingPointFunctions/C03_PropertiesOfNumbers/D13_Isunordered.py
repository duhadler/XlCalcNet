
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
    y = 0.0
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.isunordered(x, y))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_isnormal_real_explicit():
    print('<H1 Title="demo_isnormal_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 1.0, 8.8, dreal.inf]
    y = 0.0
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="isunordered(x, y); x=' + str(x) + '">')
        res = math53.isunordered(x, y); print('math53: ', res)
        res = sreal.isunordered(x, y); print(' sreal: ', res)
        res = dreal.isunordered(x, y); print(' dreal: ', res)
        res = ereal.isunordered(x, y); print(' ereal: ', res)
        res = qreal.isunordered(x, y); print(' qreal: ', res)
        res = oreal.isunordered(x, y); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.isunordered(x, y); print(' mreal: ', res)
            res = sflint.isunordered(x, y); print('sflint: ', res)
            res = dflint.isunordered(x, y); print('dflint: ', res)
            res = eflint.isunordered(x, y); print('eflint: ', res)
            res = qflint.isunordered(x, y); print('qflint: ', res)
            res = oflint.isunordered(x, y); print('oflint: ', res)
            res = mflint.isunordered(x, y); print('mflint: ', res)
            res = aflint.isunordered(x, y); print('aflint: ', res)
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











