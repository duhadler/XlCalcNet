import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_expn()


def demo_expn():
    print('demo_expn: ')
    nlist = [5, 35]   # needs to be a positive integer
    xlist = [5.1, 8.8]   # needs to be a real number
    for n in nlist:
        for x in xlist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.expn(n, x)
                print(name, ': expn(n=' + str(n) + ', x=' + str(x),'): ', res)
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











