
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_quanc8()


def F4(x):
    y = math53.student_t_pdf(10, x)
#    print('x: ', x, 'y: ', y)
    return y


def demo_quanc8():
    print('Numerical Quadrature, quanc8:')
    res = math53.quanc8(f=cb(F4), a=0.0, b=2.0, abserr=1E-8, relerr=1E-8)
    print('math53.quanc8(f=cb(F4), a=-0.0, b=2.0, abserr=1E-8, relerr=1E-8)')
    result = res.Item1
    errest = res.Item2
    flag = res.Item3
    neval = res.Item4
    print('result:', result)
    print('errest:', errest)
    print('  flag:', flag)
    print(' neval:', neval)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

