import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53]


def main_tests():
    demo_real_gammastar()


def demo_real_gammastar():
    print('demo_real_gammastar: ')
    xlist = [0.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatName(ctx.name)
            res = ctx.real_gammastar(x)
            print(name, ': gammastar(x=' + str(x) + '): ', ctx.fmt(res))
        print()
    print()


def FormatName(name):
    if (len(name)==5): name = ' ' + name
    return name


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











