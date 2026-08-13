
# !!! only implemented for math53

import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_ndisx()


def demo_ndisx():
    print('demo_ndisx: ')
    qlist = [0.1, 0.8]
    for q in qlist:
        for ctx in ctxlist:
            name = FormatCtxName(ctx.name)
            res = ctx.ndis(q)
            print(name, ': ndisx(q=' + str(q) + '): ', ctx.fmt(res))
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





