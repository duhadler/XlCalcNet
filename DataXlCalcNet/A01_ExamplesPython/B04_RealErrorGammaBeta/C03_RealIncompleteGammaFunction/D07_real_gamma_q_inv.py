import time
import math
from xlcalcnet import math53, sreal, dreal, ereal, qreal, qcplx, oreal
from xlcalcnet import ArbPrec, mreal
ArbPrec.SetDps(80);

ctxlist = [math53, sreal, dreal, ereal, qreal, oreal, mreal]


def main_tests():
    demo_real_gamma_q_inv()


def demo_real_gamma_q_inv():
    print('demo_real_gamma_q_inv: ')
    alist = [1.5, 3.5]
    plist = [0.1, 0.8]
    for a in alist:
        for p in plist:
            for ctx in ctxlist:
                name = FormatName(ctx.name)
                res = ctx.real_gamma_q_inv(a, p)
                print(name, ': gamma_q_inv(a=' + str(a) + ', p=' + str(p),'): ' + ctx.fmt(res))
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











