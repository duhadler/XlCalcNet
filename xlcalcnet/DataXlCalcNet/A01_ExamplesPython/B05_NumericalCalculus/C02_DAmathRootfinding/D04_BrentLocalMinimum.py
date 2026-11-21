
from xlcalcnet import math53
cb = math53.cb1SRet1S


def main_tests():
    demo_localmin()
    demo_localmin_lambda()


def F1(x):
    y = -math53.exp(-x * x)
#    print('x:', x, '  y:', y)
    return y


def demo_localmin():
    print('Local Minimum, function call:')
    res = math53.localmin(f=cb(F1), a=-10.0, b=20.0, eps=1E-6, tol=1E-6)
    print('math53.localmin(f=cb(F1), a=-10.0, b=20.0, eps=1E-6, tol=1E-6): ')
    x = res.Item1
    fx = res.Item2
    ic = res.Item3
    print(' x:', x)
    print('fx:', fx)
    print('ic:', ic)
    print()


def demo_localmin_lambda():
    print('Local Minimum, lambda expression:')
    f = cb(lambda x: -math53.exp(-x * x))
    print('f = cb(lambda x: -math.exp(-x * x))')
    res = math53.localmin(f, a=-10.0, b=20.0, eps=1E-6, tol=1E-6)
    print('math53.localmin(f, a=-10.0, b=20.0, eps=1E-6, tol=1E-6): ')
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











