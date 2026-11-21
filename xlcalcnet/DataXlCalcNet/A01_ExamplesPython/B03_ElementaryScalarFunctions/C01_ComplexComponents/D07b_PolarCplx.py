
import time
from xlcalcnet import gui, fpm, mpm, dpm, ipm
if gui.has_gpm: from xlcalcnet import gpm
if gui.has_apm: from xlcalcnet import apm
if gui.has_xlcalcnet2: from xlcalcnet import ArbPrec, mcplx, sflintc, dflintc, \
    eflintc, qflintc, oflintc, mflintc, aflintc
from xlcalcnet import cmath53, scplx, dcplx, ecplx, qcplx, ocplx


def main_tests():
    demo_manual_cplx_short()
    demo_manual_cplx_full()
    demo_polar_cplx_explicit()


def demo_manual_cplx_short():
    print('<H1 Title="demo_manual_cplx_short">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(35)
    for ctx in [fpm, mpm, cmath53, qcplx]: print(ctx.fmtname + ': ', ctx.polar(x))
    print('</H1>')


def demo_manual_cplx_full():
    print('<H1 Title="demo_manual_cplx_full">')
    #from xlcalcnet import *
    x = -5.1+2j; gui.setdps(35)
    for ctx in gui.ctxlist_cplx: print(ctx.fmtname + ': ',  ctx.polar(x))
    print('</H1>')



def demo_polar_cplx_explicit():
    print('<H1 Title="demo_polar_cplx_explicit">')
    xlist = [-5.1+2j, 8.8+2j]; gui.setdps(35)
    for x in xlist:
        print('<H2 Title="polar(x); x=' + str(x) + '">')
        res = cmath53.polar(x); print('cmath53: ', res)
        res = scplx.polar(x); print('  scplx: ', res)
        res = dcplx.polar(x); print('  dcplx: ', res)
        res = ecplx.polar(x); print('  ecplx: ', res)
        res = qcplx.polar(x); print('  qcplx: ', res)
        res = ocplx.polar(x); print('  ocplx: ', res)
        if gui.has_xlcalcnet2:
            res = mcplx.polar(x); print('  mcplx: ', res)
            res = sflintc.polar(x); print('sflintc: ', res)
            res = dflintc.polar(x); print('dflintc: ', res)
            res = eflintc.polar(x); print('eflintc: ', res)
            res = qflintc.polar(x); print('qflintc: ', res)
            res = oflintc.polar(x); print('oflintc: ', res)
            res = mflintc.polar(x); print('mflintc: ', res)
            res = aflintc.polar(x); print('aflintc: ', res)
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











