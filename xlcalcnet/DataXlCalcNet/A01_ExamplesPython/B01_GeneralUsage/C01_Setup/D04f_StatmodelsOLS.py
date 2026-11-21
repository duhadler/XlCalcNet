
import time
import numpy as np
import pandas as pd
import statsmodels.api as sm

# See also: https://www.statsmodels.org/stable/examples/notebooks/generated/ols.html


def OLS(**kwargs):

# End of standard key word arguments

    nsample = 100
    x = np.linspace(0, 10, 100)
    X = np.column_stack((x, x**2))
    beta = np.array([1, 0.1, 10])
    e = np.random.normal(size=nsample)

    X = sm.add_constant(X)
    y = np.dot(X, beta) + e

    model = sm.OLS(y, X)
    results = model.fit()
    print(results.summary())


try:
    if __name__ == '__main__':
        start0 = time.time()
        OLS()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())


