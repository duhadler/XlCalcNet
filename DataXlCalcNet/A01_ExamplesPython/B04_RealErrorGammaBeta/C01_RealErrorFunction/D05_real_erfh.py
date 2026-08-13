# !!! only implemented for math53

import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_real_erfh()


def demo_real_erfh():
    print('demo_real_erfh: ')
    xlist = [-5.1, 8.8]
    hlist = [0.01, 0.008]
    for x in xlist:
        for h in hlist:
            for ctx in ctxlist:
                name = FormatCtxName(ctx.name)
                res = ctx.real_erfh(x, h)
                print(name, ': erfh(x=' + str(x) +  'h=' + str(h) + '): ', ctx.fmt(res))
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











