import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_ibetac()


def demo_real_ibetac():
    print('demo_real_ibetac: ')
    alist = [1.5, 3.5]
    blist = [1.5, 3.5]
    xlist = [0.1, 0.8]
    for a in alist:
        for b in blist:
            for x in xlist:
                for ctx in ctxlist:
                    name = FormatName(ctx.name)
                    res = ctx.real_ibetac(a, b, x)
                    print(name, ': ibetac(a=' + str(a) + ', b=' + str(b) \
                            + ', x=' + str(x),'): ', ctx.fmt(res))
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











