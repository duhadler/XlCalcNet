
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_qawc()


def F5(x):
    y = 1.0 / (1.0 * (5.0 * x * x * x + 6.0))
#    print('x: ', x, 'y: ', y)
    return y


def demo_qawc():
    print('Numerical Quadrature, qawc:')
    res = math53.qawc(f=cb(F5), a=-1.0, b=5.0, c=0.0, epsabs=1E-5, epsrel=1E-5)
    print('math53.qawc(f=cb(F5), a=-1.0, b=5.0, c=0.0, epsabs=1E-5, epsrel=1E-5')
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











