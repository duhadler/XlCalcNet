
from xlcalcnet import math53
cb = math53.cb1SRet1S


def main_tests():
    demo_mbrent()


def F1(x):
    y = -math53.exp(-x * x)
#    print('x: ', x, 'y: ', y)
    return y


def demo_mbrent():
    print('Local Minimum, mbrent:')
    res = math53.mbrent(f=cb(F1), a=-10.0, b=20.0, tol=1E-6)
    print('math53.mbrent(f=cb(F1), a=-10.0, b=20.0, tol=1E-6): ')
    x = res.Item1
    fx = res.Item2
    ic = res.Item3
    print(' x:', x)
    print('fx:', fx)
    print('ic:', ic)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











