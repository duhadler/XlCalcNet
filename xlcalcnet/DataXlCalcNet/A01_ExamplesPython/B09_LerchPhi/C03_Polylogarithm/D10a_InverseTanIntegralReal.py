
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_real()
    demo_inverse_tan_integral_real_ctx()
    demo_inverse_tan_integral_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    s = 3; z = -5.1; gui.setdps(90)
    for ctx in gui.ctxlist_noboost_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.inverse_tan_integral(s, z)))
    print('</H1>')


def demo_inverse_tan_integral_real_ctx():
    print('<H1 Title="demo_inverse_tan_integral_real_ctx">')
    gui.setdps(90)
    slist = [2, 3, 4]
    zlist = [-5.1, 0.8]
    for s in slist:
        for z in zlist:
            print('<H2 Title="inverse_tan_integral(s, z); z=' + str(z) + '">')
            for ctx in gui.ctxlist_noboost_real:
                res = ctx.inverse_tan_integral(s, z)
                print(ctx.fmtname + ': ' + ctx.fmt(res))
            print('</H2>')
            print()
    print('</H1>')
    print()


def demo_inverse_tan_integral_real_explicit():
    print('<H1 Title="demo_inverse_tan_integral_real_explicit">')
    gui.setdps(90)
    slist = [2, 3, 4]
    zlist = [-5.1, 0.8]
    for s in slist:
        for z in zlist:
            print('<H2 Title="inverse_tan_integral(s, z); z=' + str(z) + '">')
            res = math53.inverse_tan_integral(s, z); print('math53: ' + math53.fmt(res))
            if gui.has_xlcalcnet2:
                res = sflint.inverse_tan_integral(s, z); print('sflint: ' + sflint.fmt(res))
                res = dflint.inverse_tan_integral(s, z); print('dflint: ' + dflint.fmt(res))
                res = eflint.inverse_tan_integral(s, z); print('eflint: ' + eflint.fmt(res))
                res = qflint.inverse_tan_integral(s, z); print('qflint: ' + qflint.fmt(res))
                res = oflint.inverse_tan_integral(s, z); print('oflint: ' + oflint.fmt(res))
                res = mflint.inverse_tan_integral(s, z); print('mflint: ' + mflint.fmt(res))
                res = aflint.inverse_tan_integral(s, z); print('aflint: ' + aflint.fmt(res))
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











