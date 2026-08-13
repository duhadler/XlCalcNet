
import math
from xlcalcnet import math53


def main_tests():
    demo_cubic_equation()


def demo_cubic_equation():
    print('Roots (x1, z2, z3) of a Cubic Equation (ax^3+bx^2+cx+d=0):')
    res = math53.cubsolve(a=-13, b=4, c=5, d=1)
    print('math53.cubsolve(a=-13, b=4, c=5, d=1): ')
    x1 = res.Item1
    z2 = complex(res.Item2.Real, res.Item2.Imaginary)
    z3 = complex(res.Item3.Real, res.Item3.Imaginary)
    print('x1:', x1)
    print('z2:', z2)
    print('z3:', z3)
    print()


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











