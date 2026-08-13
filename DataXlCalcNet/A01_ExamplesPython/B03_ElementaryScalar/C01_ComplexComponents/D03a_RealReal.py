
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
    demo_real_real()
    demo_real_real_ctx()
    demo_real_real_mpm_ctx()
    demo_real_real_mpm_ctx2()



def demo_real_real():
    print('<H1 Title="real_real">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        res = math53.real(x)
        print('math53: real(x=' + str(x) + '): ' + math53.fmt(res))
        res = sreal.real(x)
        print(' sreal: real(x=' + str(x) + '): ' + sreal.fmt(res))
        res = dreal.real(x)
        print(' dreal: real(x=' + str(x) + '): ' + dreal.fmt(res))
        res = ereal.real(x)
        print(' ereal: real(x=' + str(x) + '): ' + ereal.fmt(res))
        res = qreal.real(x)
        print(' qreal: real(x=' + str(x) + '): ' + qreal.fmt(res))
        res = oreal.real(x)
        print(' oreal: real(x=' + str(x) + '): ' + oreal.fmt(res))

        if use_xlcalcnet2:
            res = mreal.real(x)
            print(' mreal: real(x=' + str(x) + '): ' + mreal.fmt(res))
            res = sflint.real(x)
            print('sflint: real(x=' + str(x) + '): ' + sflint.fmt(res))
            res = dflint.real(x)
            print('dflint: real(x=' + str(x) + '): ' + dflint.fmt(res))
            res = eflint.real(x)
            print('eflint: real(x=' + str(x) + '): ' + eflint.fmt(res))
            res = qflint.real(x)
            print('qflint: real(x=' + str(x) + '): ' + qflint.fmt(res))
            res = oflint.real(x)
            print('oflint: real(x=' + str(x) + '): ' + oflint.fmt(res))
            res = mflint.real(x)
            print('mflint: real(x=' + str(x) + '): ' + mflint.fmt(res))
            res = aflint.real(x)
            print('aflint: real(x=' + str(x) + '): ' + aflint.fmt(res))
        print()
    print('</H1>')
    print()


def demo_real_real_ctx():
    print('<H1 Title="real_real_ctx">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxName(ctx.name)
            res = ctx.real(x)
            print(name + ': real(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def demo_real_real_mpm_ctx():
    print('<H1 Title="real_real_mpm_ctx">')
    xlist = [-5.1, 8.8]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.real(x)
            print('   ' + name + ': real(x=' + str(x) + '): ' + str(res))
        print()
    print('</H1>')
    print()



def demo_real_real_mpm_ctx2():
    print('<H1 Title="real_real_mpm_ctx2">')
    xlist = [-5.1, 8.8+2.2j]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.real(x)
            print('   ' + name + ': real(x=' + str(x) + '): ' + ctx.fmt(res))
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











