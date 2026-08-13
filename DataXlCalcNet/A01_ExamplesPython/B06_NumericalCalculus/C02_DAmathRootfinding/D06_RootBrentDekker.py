
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_zbrent()


def F3(x):
    y = math.exp(x) - 1.0
#    print('x: ', x, 'y: ', y)
    return y


def demo_zbrent():
    print('Local Zero, zbrent:')
    res = math53.zbrent(f=cb(F3), a=-20.0, b=10.0, tol=1E-8)
    print('math53.zbrent(f=cb(F3), a=-20.0, b=10.0, tol=1E-8)')
    x = res.Item1
    ic = res.Item2
    errc = res.Item3
    print('   x:', x)
    print('  ic:', ic)
    print('errc:', errc)
    print()


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











