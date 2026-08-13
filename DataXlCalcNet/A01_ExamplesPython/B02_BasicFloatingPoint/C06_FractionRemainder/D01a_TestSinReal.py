
dps = 40
use_xlcalcnet2 = True
ctx2 = ctx3 = []

from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal
ctx1 = [math53, sreal, dreal, ereal, qreal, oreal]

from xlcalcnet import  fpm, mpm, dpm, gpm, ipm, apm
ctx3 = [fpm, mpm, dpm, gpm, ipm, apm]
mpm.dps = dpm.dps = gpm.dps = ipm.dps = apm.dps = dps

if use_xlcalcnet2:
    from xlcalcnet import ArbPrec, mreal, sflint, dflint, eflint, qflint, \
        oflint, mflint, aflint
    ctx2 = [mreal, sflint, dflint, eflint, qflint, oflint, mflint, aflint]
    ArbPrec.SetDps(dps);

ctxlist = ctx1 + ctx2 + ctx3


def main_tests():
    """ A doc string """
    demo_sin_real()
    demo_sin_real_ctx()
    demo_sin_real_mpm_ctx()
    demo_sin_real_mpm_ctx2()



def demo_sin_real():
    print('<H1 Title="sin_real">')
    xlist = ["-5.1", "8.8"]
    for x in xlist:
        res = math53.sin(x)
        print('math53: sin(x=' + str(x) + '): ' + math53.fmt(res))
        res = sreal.sin(x)
        print(' sreal: sin(x=' + str(x) + '): ' + sreal.fmt(res))
        res = dreal.sin(x)
        print(' dreal: sin(x=' + str(x) + '): ' + dreal.fmt(res))
        res = ereal.sin(x)
        print(' ereal: sin(x=' + str(x) + '): ' + ereal.fmt(res))
        res = qreal.sin(x)
        print(' qreal: sin(x=' + str(x) + '): ' + qreal.fmt(res))
        res = oreal.sin(x)
        print(' oreal: sin(x=' + str(x) + '): ' + oreal.fmt(res))

        if use_xlcalcnet2:
            res = mreal.sin(x)
            print(' mreal: sin(x=' + str(x) + '): ' + mreal.fmt(res))
            res = sflint.sin(x)
            print('sflint: sin(x=' + str(x) + '): ' + sflint.fmt(res))
            res = dflint.sin(x)
            print('dflint: sin(x=' + str(x) + '): ' + dflint.fmt(res))
            res = eflint.sin(x)
            print('eflint: sin(x=' + str(x) + '): ' + eflint.fmt(res))
            res = qflint.sin(x)
            print('qflint: sin(x=' + str(x) + '): ' + qflint.fmt(res))
            res = oflint.sin(x)
            print('oflint: sin(x=' + str(x) + '): ' + oflint.fmt(res))
            res = mflint.sin(x)
            print('mflint: sin(x=' + str(x) + '): ' + mflint.fmt(res))
            res = aflint.sin(x)
            print('aflint: sin(x=' + str(x) + '): ' + aflint.fmt(res))
        print()
    print('</H1>')
    print()


def demo_sin_real_ctx():
    print('<H1 Title="sin_real_ctx">')
    xlist = ["-5.1", "8.8"]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxName(ctx.name)
            res = ctx.sin(x)
            print(name + ': sin(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


# note: need to change use of double as if it were a string for input
def demo_sin_real_mpm_ctx():
    print('<H1 Title="sin_real_mpm_ctx">')
    xlist = ["-5.1", "8.8"]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.sin(x)
            print('   ' + name + ': sin(x=' + str(x) + '): ' + str(res))
        print()
    print('</H1>')
    print()



# note: need to change use of double as if it were a string for input
def demo_sin_real_mpm_ctx2():
    print('<H1 Title="sin_real_mpm_ctx2">')
    xlist = ["-5.1", "8.8+2.2j"]
    for x in xlist:
        for ctx in ctx3:
            name = FormatCtxName(ctx.name)
            res = ctx.sin(x)
            print('   ' + name + ': sin(x=' + str(x) + '): ' + ctx.fmt(res))
        print()
    print('</H1>')
    print()


def FormatCtxName(name):
    if (len(name)==3): name = '   ' + name
    if (len(name)==4): name = '  ' + name
    if (len(name)==5): name = ' ' + name
    return name


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











