import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_real_poch1()


def demo_real_poch1():
    print('demo_real_poch1: ')
    alist = [5.1, 8.8]
    xlist = [15.1, 2.8]
    for a in alist:
        for x in xlist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_poch1(a, x)
                print(name, ': poch1(a=' + str(a) + ', x=' + str(x),'): ', ctx.fmt(res))
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











