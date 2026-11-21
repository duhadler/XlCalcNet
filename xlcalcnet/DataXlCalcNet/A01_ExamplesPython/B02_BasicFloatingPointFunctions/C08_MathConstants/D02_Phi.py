
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mreal, sflint, dflint, \
    eflint, qflint, oflint, mflint, aflint
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal


def main_tests():
    demo_manual_phi()
    demo_phi_ctx()
    demo_phi_explicit()


def demo_manual_phi():
    print('<H1 Title="demo_manual_real">')
    #from xlcalcnet import *
    gui.setdps(90)
    for ctx in gui.ctxlist_real: print(ctx.fmtname + ': ' + ctx.fmt(ctx.phi))
    print('</H1>')


def demo_phi_ctx():
    print('<H1 Title="demo_phi_ctx">')
    gui.setdps(90)
    for ctx in gui.ctxlist_real:
        res = ctx.phi
        print(ctx.fmtname + ': ' + ctx.fmt(res))
    print()
    print('</H1>')
    print()


def demo_phi_explicit():
    print('<H1 Title="demo_phi_explicit">')
    gui.setdps(90)
    res = math53.phi; print('math53: ' + math53.fmt(res))
    res = sreal.phi; print(' sreal: ' + sreal.fmt(res))
    res = dreal.phi; print(' dreal: ' + dreal.fmt(res))
    res = ereal.phi; print(' ereal: ' + ereal.fmt(res))
    res = qreal.phi; print(' qreal: ' + qreal.fmt(res))
    res = oreal.phi; print(' oreal: ' + oreal.fmt(res))
    if gui.has_xlcalcnet2:
        res = mreal.phi; print(' mreal: ' + mreal.fmt(res))
        res = sflint.phi; print('sflint: ' + sflint.fmt(res))
        res = dflint.phi; print('dflint: ' + dflint.fmt(res))
        res = eflint.phi; print('eflint: ' + eflint.fmt(res))
        res = qflint.phi; print('qflint: ' + qflint.fmt(res))
        res = oflint.phi; print('oflint: ' + oflint.fmt(res))
        res = mflint.phi; print('mflint: ' + mflint.fmt(res))
        res = aflint.phi; print('aflint: ' + aflint.fmt(res))
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











