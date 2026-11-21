
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_isregular_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 1.0, 8.8, dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.isregular(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_isregular_real_explicit():
    print('<H1 Title="demo_isregular_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, -5.1, -0.0, 0.0, 1.0, 8.8, dreal.inf]
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="isregular(x); x=' + str(x) + '">')
        res = math53.isregular(x); print('math53: ', res)
        res = sreal.isregular(x); print(' sreal: ', res)
        res = dreal.isregular(x); print(' dreal: ', res)
        res = ereal.isregular(x); print(' ereal: ', res)
        res = qreal.isregular(x); print(' qreal: ', res)
        res = oreal.isregular(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.isregular(x); print(' mreal: ', res)
            res = sflint.isregular(x); print('sflint: ', res)
            res = dflint.isregular(x); print('dflint: ', res)
            res = eflint.isregular(x); print('eflint: ', res)
            res = qflint.isregular(x); print('qflint: ', res)
            res = oflint.isregular(x); print('oflint: ', res)
            res = mflint.isregular(x); print('mflint: ', res)
            res = aflint.isregular(x); print('aflint: ', res)
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











