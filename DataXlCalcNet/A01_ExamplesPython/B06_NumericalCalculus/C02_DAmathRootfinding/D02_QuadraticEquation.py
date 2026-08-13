
import math
from xlcalcnet import math53


def main_tests():
    demo_quadratic_equation()


def demo_quadratic_equation():
    print('Roots (z1, z2) of a Quadratic Equation (ax^2+bx+c=0):')
    res = math53.squadx(a=1.1, b=2.2, c=3.3)
    print('math53.squadx(a=1.1, b=2.2, c=3.3): ')
    z1 = complex(res.Item1.Real, res.Item1.Imaginary)
    z2 = complex(res.Item2.Real, res.Item2.Imaginary)
    print('z1:', z1)
    print('z2:', z2)
    print()


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











