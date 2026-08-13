
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_intdeo()


def F6(x):
    alpha = 2.0
    y = math53.sin(x * alpha) / math53.sqrt(x)
#    print('x: ', x, 'y: ', y)
    return y


def demo_intdeo():
    print('Numerical Quadrature, intdeo:')
    res = math53.intdeo(f=cb(F6), a=0.0, omega=2.0, eps=1E-8)
    print('math53.intdeo(f=cb(F6), a=0.0, omega=2.0, eps=1E-8)')
    result = res.Item1
    errest = res.Item2
    neval = res.Item3
    ier = res.Item4
    print('result:', result)
    print('errest:', errest)
    print(' neval:', neval)
    print('   ier:', ier)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











