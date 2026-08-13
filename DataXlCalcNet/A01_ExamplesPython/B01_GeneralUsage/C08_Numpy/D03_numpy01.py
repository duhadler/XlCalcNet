"""
Description of this CPython module
"""

import numpy as np


def test_numpy01():
    print('Hello from numpy01!')
    a = np.array([2, 3, 4])
    print(a)
    print(a.dtype)
    b = np.array([1.2, 3.5, 5.1])
    print(a.dtype)
    



try:
    print()
    test_numpy01()



except Exception:
    import traceback
    print(traceback.format_exc())

