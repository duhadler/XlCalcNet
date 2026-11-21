
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_fitsint32_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    xlist = [dreal.nan, dreal.neginf, '-2147483649', '-2147483648', 0.0, '2147483647', '2147483648', dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.fitsint32(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_fitsint32_real_explicit():
    print('<H1 Title="demo_fitsint32_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, '-2147483649', '-2147483648', 0.0, '2147483647', '2147483648', dreal.inf]
    gui.setdps(90)
    for x in xlist:
        print('<H2 Title="fitsint32(x); x=' + str(x) + '">')
        res = math53.fitsint32(x); print('math53: ', res)
        res = sreal.fitsint32(x); print(' sreal: ', res)
        res = dreal.fitsint32(x); print(' dreal: ', res)
        res = ereal.fitsint32(x); print(' ereal: ', res)
        res = qreal.fitsint32(x); print(' qreal: ', res)
        res = oreal.fitsint32(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.fitsint32(x); print(' mreal: ', res)
            res = sflint.fitsint32(x); print('sflint: ', res)
            res = dflint.fitsint32(x); print('dflint: ', res)
            res = eflint.fitsint32(x); print('eflint: ', res)
            res = qflint.fitsint32(x); print('qflint: ', res)
            res = oflint.fitsint32(x); print('oflint: ', res)
            res = mflint.fitsint32(x); print('mflint: ', res)
            res = aflint.fitsint32(x); print('aflint: ', res)
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











