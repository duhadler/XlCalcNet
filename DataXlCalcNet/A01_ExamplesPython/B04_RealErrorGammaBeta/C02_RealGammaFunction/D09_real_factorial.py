# math53 needs to change from int to double

import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_factorial()


def demo_real_factorial():
    print('demo_real_factorial: ')
    xlist = [5.1, 8.2]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatName(ctx.name)
            res = ctx.real_factorial(x)
            print(name, ': factorial(x=' + str(x) + '): ', ctx.fmt(res))
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











