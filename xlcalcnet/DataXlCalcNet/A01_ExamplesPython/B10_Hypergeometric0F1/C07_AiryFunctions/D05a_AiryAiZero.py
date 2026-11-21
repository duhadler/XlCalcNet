
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal

scaled = False


def main_tests():
    demo_manual_real()
    demo_airy_ai_zero_real_ctx()
    demo_airy_ai_zero_real_explicit()


def demo_manual_real():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    m = 5; gui.setdps(90)
    for ctx in gui.ctxlist_noipm_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.airy_ai_zero(m)))
    print('</H1>')


def demo_airy_ai_zero_real_ctx():
    print('<H1 Title="demo_airy_ai_zero_real_ctx">')
    mlist = [1, 2, 3, 4, 5]; gui.setdps(90)
    for m in mlist:
        print('<H2 Title="airy_ai_zero(m); m=' + str(m) + '">')
        for ctx in gui.ctxlist_noipm_real:
            res = ctx.airy_ai_zero(m)
            print(ctx.fmtname + ': ' + ctx.fmt(res))
        print('</H2>')
        print()
    print('</H1>')
    print()


def demo_airy_ai_zero_real_explicit():
    print('<H1 Title="demo_airy_ai_zero_real_explicit">')
    mlist = [1, 2, 3, 4, 5]; gui.setdps(90)
    for m in mlist:
        print('<H2 Title="airy_ai_zero(m); m=' + str(m) + '">')
        res = math53.airy_ai_zero(m); print('math53: ' + math53.fmt(res))
        res = sreal.airy_ai_zero(m); print(' sreal: ' + sreal.fmt(res))
        res = dreal.airy_ai_zero(m); print(' dreal: ' + dreal.fmt(res))
        res = ereal.airy_ai_zero(m); print(' ereal: ' + ereal.fmt(res))
        res = qreal.airy_ai_zero(m); print(' qreal: ' + qreal.fmt(res))
        res = oreal.airy_ai_zero(m); print(' oreal: ' + oreal.fmt(res))
        if gui.has_xlcalcnet2:
            res = mreal.airy_ai_zero(m); print(' mreal: ' + mreal.fmt(res))
            res = sflint.airy_ai_zero(m); print('sflint: ' + sflint.fmt(res))
            res = dflint.airy_ai_zero(m); print('dflint: ' + dflint.fmt(res))
            res = eflint.airy_ai_zero(m); print('eflint: ' + eflint.fmt(res))
            res = qflint.airy_ai_zero(m); print('qflint: ' + qflint.fmt(res))
            res = oflint.airy_ai_zero(m); print('oflint: ' + oflint.fmt(res))
            res = mflint.airy_ai_zero(m); print('mflint: ' + mflint.fmt(res))
            res = aflint.airy_ai_zero(m); print('aflint: ' + aflint.fmt(res))
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











