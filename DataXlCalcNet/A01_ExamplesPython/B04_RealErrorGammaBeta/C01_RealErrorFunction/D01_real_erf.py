import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_erf()


def demo_real_erf():
    print('demo_real_erf: ')
    xlist = [-5.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatCtxName(ctx.name)
            res = ctx.real_erf(x)
            print(name, ': erf(x=' + str(x) + '): ', ctx.fmt(res))
        print()
    print()


def FormatCtxName(name):
    if (len(name)==5): name = ' ' + name
    return name


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











