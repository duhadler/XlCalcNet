
import math
from xlcalcnet import math53, FixedPrecNet
from FixedPrecNet import cb1SDouble1S as cb


def main_tests():
    demo_intdei()


def F4(x):
    y = math53.student_t_pdf(10, x)
#    print('x: ', x, 'y: ', y)
    return y




def demo_intdei():
    print('Numerical Quadrature, intdei:')
    res = math53.intdei(f=cb(F4), a=0.0, eps=1E-8)
    print('math53.intdei(f=cb(F4), a=0.0, eps=1E-8')
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











