import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_gamma()


def demo_real_gamma():
    print('demo_real_gamma: ')
    xlist = [5.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatName(ctx.name)
            res = ctx.real_gamma(x)
            print(name, ': gamma(x=' + str(x) + '): ', ctx.fmt(res))
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











