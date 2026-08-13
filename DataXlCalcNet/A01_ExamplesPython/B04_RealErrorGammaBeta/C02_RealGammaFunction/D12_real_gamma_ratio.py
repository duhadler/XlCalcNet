import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_gamma_ratio()


def demo_real_gamma_ratio():
    print('demo_real_gamma_ratio: ')
    alist = [5.1, 8.8]
    blist = [15.1, 2.8]
    for a in alist:
        for b in blist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_gamma_ratio(a, b)
                print(name, ': gamma_ratio(a=' + str(a) + ', b=' + str(b),'): ', ctx.fmt(res))
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











