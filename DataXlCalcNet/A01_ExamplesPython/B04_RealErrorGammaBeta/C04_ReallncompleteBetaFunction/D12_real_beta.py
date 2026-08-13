# !!! need to rename functions in sreal etc.

import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_real_beta()


def demo_real_beta():
    print('demo_real_beta: ')
    alist = [1.5, 3.5]
    blist = [1.5, 3.5]
    for a in alist:
        for b in blist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_beta(a, b)
                print(name, ': beta(a=' + str(a) + ', b=' + str(b) \
                        + '): ', ctx.fmt(res))
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











