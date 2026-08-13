"""
Description of this CPython module
"""

import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import curve_fit



def func(x, a, b, c):
    return a * np.exp(-b * x) + c



def test_curvefit():
    # See https://docs.scipy.org/doc/scipy/reference/generated/scipy.optimize.curve_fit.html
    print('Hello from test_curvefit!')

    xdata = np.linspace(0, 4, 50)
    y = func(xdata, 2.5, 1.3, 0.5)
    rng = np.random.default_rng()
    y_noise = 0.2 * rng.normal(size=xdata.size)
    ydata = y + y_noise
    plt.plot(xdata, ydata, 'b-', label='data')

    popt, pcov = curve_fit(func, xdata, ydata)
    print(popt)
    plt.plot(xdata, func(xdata, *popt), 'r-',
             label='fit: a=%5.3f, b=%5.3f, c=%5.3f' % tuple(popt))


    popt, pcov = curve_fit(func, xdata, ydata, bounds=(0, [3., 1., 0.5]))
    print(popt)
    plt.plot(xdata, func(xdata, *popt), 'g--',
             label='fit: a=%5.3f, b=%5.3f, c=%5.3f' % tuple(popt))

    plt.xlabel('x')
    plt.ylabel('y')
    plt.legend()
    plt.show()

try:
    print()
    test_curvefit()



except Exception:
    import traceback
    print(traceback.format_exc())

