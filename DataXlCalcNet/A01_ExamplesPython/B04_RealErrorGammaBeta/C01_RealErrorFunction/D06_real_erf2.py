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
    x1list = [-5.1, 8.8]
    x2list = [0.01, 0.008]
    for x1 in x1list:
        for x2 in x2list:
            for ctx in ctxlist:
                name = FormatCtxName(ctx.name)
                res = ctx.real_erf2(x1, x2)
                print(name, ': erf2(x=' + str(x1) +  'h=' + str(x2) + '): ', ctx.fmt(res))
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











