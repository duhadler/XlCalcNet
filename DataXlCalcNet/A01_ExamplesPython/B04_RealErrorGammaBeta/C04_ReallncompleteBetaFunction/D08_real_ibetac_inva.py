import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_ibetac_inva()


def demo_real_ibetac_inva():
    print('demo_real_ibetac_inva: ')
    blist = [1.5, 3.5]
    xlist = [0.1, 0.9]
    qlist = [0.1, 0.8]
    for b in blist:
        for x in xlist:
            for q in qlist:
                for ctx in ctxlist:
                    name = FormatName(ctx.name)
                    res = ctx.real_ibetac_inva(b, x, q)
                    print(name, ': ibetac_inva(b=' + str(b) + ', x=' + str(x) \
                            + ', q=' + str(q),'): ', ctx.fmt(res))
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











