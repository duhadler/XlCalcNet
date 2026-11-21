
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_harmonic2_real_ctx()
    demo_harmonic2_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    z = 3; r = 4.3; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.harmonic2(z, r)))
    print('</H1>')


def demo_harmonic2_real_ctx():
    print('<H1 Title="demo_harmonic2_real_ctx">')
    gui.setdps(90)
    zlist = [2, 3, 4]
    rlist = [0.3, 0.7]
    for z in zlist:
        for r in rlist:
            print('<H2 Title="harmonic2(z, r); r=' + str(r) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.harmonic2(z, r)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_harmonic2_real_explicit():
    print('<H1 Title="demo_harmonic2_real_explicit">')
    gui.setdps(90)
    zlist = [2, 3, 4]
    rlist = [0.3, 0.7]
    for z in zlist:
        for r in rlist:
            print('<H2 Title="harmonic2(z, r); r=' + str(r) + '">')
            res = math53.harmonic2(z, r); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.harmonic2(z, r); print('sflint: ' + sflint.fmt(res))
                res = dflint.harmonic2(z, r); print('dflint: ' + dflint.fmt(res))
                res = eflint.harmonic2(z, r); print('eflint: ' + eflint.fmt(res))
                res = qflint.harmonic2(z, r); print('qflint: ' + qflint.fmt(res))
                res = oflint.harmonic2(z, r); print('oflint: ' + oflint.fmt(res))
                res = mflint.harmonic2(z, r); print('mflint: ' + mflint.fmt(res))
                res = aflint.harmonic2(z, r); print('aflint: ' + aflint.fmt(res))
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











