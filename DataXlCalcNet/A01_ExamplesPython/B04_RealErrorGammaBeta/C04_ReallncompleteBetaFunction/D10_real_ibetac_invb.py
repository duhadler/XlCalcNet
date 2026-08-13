import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_ibetac_invb()


def demo_real_ibetac_invb():
    print('demo_real_ibetac_invb: ')
    alist = [1.5, 3.5]
    xlist = [0.1, 0.9]
    qlist = [0.1, 0.8]
    for a in alist:
        for x in xlist:
            for q in qlist:
                for ctx in ctxlist:
                    name = FormatName(ctx.name)
                    res = ctx.real_ibetac_invb(a, x, q)
                    print(name, ': ibetac_invb(a=' + str(a) + ', x=' + str(x) \
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











