import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_falling_factorial()


def demo_real_falling_factorial():
    print('demo_real_falling_factorial: ')
    xlist = [5.1, 8.8]
    nlist = [15.1, 2.8]
    for x in xlist:
        for n in nlist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_falling_factorial(x, n)
                print(name, ': falling_factorial(x=' + str(x) + ', n=' + str(n),'): ', ctx.fmt(res))
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











