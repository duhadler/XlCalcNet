# math53 needs to change from int to double

import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_doublefactorial()


def demo_real_doublefactorial():
    print('demo_real_doublefactorial: ')
    xlist = [5.1, 8.8]
    for x in xlist:
        for ctx in ctxlist:
            name = FormatName(ctx.name)
            res = ctx.real_doublefactorial(x)
            print(name, ': doublefactorial(x=' + str(x) + '): ', ctx.fmt(res))
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











