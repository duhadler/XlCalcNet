
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_fitsint64_real_explicit()



def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(30)
    xlist = [dreal.nan, dreal.neginf, '-9223372036854775809', '-9223372036854775808', \
        0.0, '9223372036854775807', '9223372036854775808', dreal.inf]
    for ctx in gui.ctxlist_real:
        res = []
        for x in xlist: res.append(ctx.fitsint64(x))
        print(ctx.fmtname + ': ', res)   
    print('</H1>')



def demo_fitsint64_real_explicit():
    print('<H1 Title="demo_fitsint64_real_explicit">')
    xlist = [dreal.nan, dreal.neginf, '-9223372036854775809', '-9223372036854775808', \
        0.0, '9223372036854775807', '9223372036854775808', dreal.inf]
    gui.setdps(30)
    for x in xlist:
        print('<H2 Title="fitsint64(x); x=' + str(x) + '">')
        res = math53.fitsint64(x); print('math53: ', res)
        res = sreal.fitsint64(x); print(' sreal: ', res)
        res = dreal.fitsint64(x); print(' dreal: ', res)
        res = ereal.fitsint64(x); print(' ereal: ', res)
        res = qreal.fitsint64(x); print(' qreal: ', res)
        res = oreal.fitsint64(x); print(' oreal: ', res)
        if gui.has_xlcalcnet2:
            res = mreal.fitsint64(x); print(' mreal: ', res)
            res = sflint.fitsint64(x); print('sflint: ', res)
            res = dflint.fitsint64(x); print('dflint: ', res)
            res = eflint.fitsint64(x); print('eflint: ', res)
            res = qflint.fitsint64(x); print('qflint: ', res)
            res = oflint.fitsint64(x); print('oflint: ', res)
            res = mflint.fitsint64(x); print('mflint: ', res)
            res = aflint.fitsint64(x); print('aflint: ', res)
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











