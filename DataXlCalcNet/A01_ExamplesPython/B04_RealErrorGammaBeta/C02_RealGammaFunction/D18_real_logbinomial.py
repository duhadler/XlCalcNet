# !!! math53 has different results from others

# !!! does not work correctly


import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

#ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]
ctxlist = [math53]


def main_tests():
    demo_real_logbinomial()


def demo_real_logbinomial():
    print('demo_real_logbinomial: ')
    nlist = [35, 28]
    klist = [11, 8]
    for n in nlist:
        for k in klist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_logbinomial(n, k)
                print(name, ': logbinomial(n=' + str(n) + ', k=' + str(k),'): ', ctx.fmt(res))
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











