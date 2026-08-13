
from xlcalcnet import cmath53
import numpy as np


def main_tests():
    scalar1(3+4j)
    scalar1(-3+0j)



def scalar1(z):
    y = cmath53.sqrt(z)
    print('z:', z, '; y = cmath53.sqrt(z):', y)
    y = np.sqrt(z)
    print('z:', z, '; y = np.sqrt(z):', y)

    print()




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











