
from xlcalcnet import math53
import numpy as np


def main_tests():

    scalar1()


def scalar1():
    x0 = 1.5
    print('x0:', x0)
    Res0 = math53.sin(x0)
    print('Res0:', Res0)
    print()




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











