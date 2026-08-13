
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_zeroin()


def F3(x):
    y = math.exp(x) - 1.0
#    print('x: ', x, 'y: ', y)
    return y


def demo_zeroin():
    print('Local Zero, zeroin:')
    res = math53.zeroin(f=cb(F3), a=-20.0, b=10.0, tol=1E-8)
    print('math53.zbrent(f=cb(F3), a=-20.0, b=10.0, tol=1E-8): ')
    x = res
    print(' x:', x)
    print()


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











