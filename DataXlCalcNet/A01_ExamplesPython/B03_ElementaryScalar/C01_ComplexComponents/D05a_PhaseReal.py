
dps = 40; ctx2 = []
import time
from xlcalcnet import use_gpm, use_apm, use_xlcalcnet2

from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal
ctx1 = [math53, sreal, dreal, ereal, qreal, oreal]

from xlcalcnet import fpm, mpm, dpm, ipm
ctx3 = [fpm, mpm, dpm, ipm]
mpm.dps = dpm.dps = ipm.dps = dps

if use_gpm:
    from xlcalcnet import gpm
    gpm.dps = dps
    ctx3.append(gpm)

if use_apm:
    from xlcalcnet import apm
    apm.dps = dps
    ctx3.append(apm)

if use_xlcalcnet2:
    from xlcalcnet import ArbPrec, mreal, sflint, dflint, eflint, qflint, \
        oflint, mflint, aflint
    ctx2 = [mreal, sflint, dflint, eflint, qflint, oflint, mflint, aflint]
    ArbPrec.SetDps(dps);

ctxlist = ctx1 + ctx2 + ctx3


def main_tests():
    """ A doc string """
    demo_phase_real()
    demo_phase_real_ctx()
    demo_phase_real_mpm_ctx()
    demo_phase_real_mpm_ctx2()



def demo_phase_real():
    print('<H1 Title="phase_real">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        res = math53.phase(x)
        print('math53: phase(x=' + str(x) + '): ' + math53.fmt(res))
        res = sreal.phase(x)
        print(' sreal: phase(x=' + str(x) + '): ' + sreal.fmt(res))
        res = dreal.phase(x)
        print(' dreal: phase(x=' + str(x) + '): ' + dreal.fmt(res))
        res = ereal.phase(x)
        print(' ereal: phase(x=' + str(x) + '): ' + ereal.fmt(res))
        res = qreal.phase(x)
        print(' qreal: phase(x=' + str(x) + '): ' + qreal.fmt(res))
        res = oreal.phase(x)
        print(' oreal: phase(x=' + str(x) + '): ' + oreal.fmt(res))

        if use_xlcalcnet2:
            res = mreal.phase(x)
            print(' mreal: phase(x=' + str(x) + '): ' + mreal.fmt(res))
            res = sflint.phase(x)
            print('sflint: phase(x=' + str(x) + '): ' + sflint.fmt(res))
            res = dflint.phase(x)
            print('dflint: phase(x=' + str(x) + '): ' + dflint.fmt(res))
            res = eflint.phase(x)
            print('eflint: phase(x=' + str(x) + '): ' + eflint.fmt(res))
            res = qflint.phase(x)
            print('qflint: phase(x=' + str(x) + '): ' + qflint.fmt(res))
            res = oflint.phase(x)
            print('oflint: phase(x=' + str(x) + '): ' + oflint.fmt(res))
            res = mflint.phase(x)
            print('mflint: phase(x=' + str(x) + '): ' + mflint.fmt(res))
            res = aflint.phase(x)
            print('aflint: phase(x=' + str(x) + '): ' + aflint.fmt(res))
        print()
    print('</H1>')
    print()


def demo_phase_real_ctx():
    print('<H1 Title="phase_real_ctx">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxName(ctx.name)
            res = ctx.phase(x)
            
            print(name + ': phase(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_phase_real_mpm_ctx():
    print('<H1 Title="phase_real_mpm_ctx">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.phase(x)
            print('   ' + name + ': phase(x=' + str(x) + '): ' + str(res))
        print()
    print('</H1>')
    print()



def demo_phase_real_mpm_ctx2():
    print('<H1 Title="phase_real_mpm_ctx2">')
    xlist = [-5.1, 8.8+2.2j]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.phase(x)
            print('   ' + name + ': phase(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def FormatCtxName(name):
    if (len(name)==3): name = '   ' + name
    if (len(name)==4): name = '  ' + name
    if (len(name)==5): name = ' ' + name
    return name


try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())











