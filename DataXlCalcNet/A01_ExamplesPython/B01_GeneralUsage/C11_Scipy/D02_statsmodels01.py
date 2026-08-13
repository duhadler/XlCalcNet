"""
Description of this CPython module
"""

import numpy as np
import pandas as pd
import statsmodels.api as sm
import statsmodels.formula.api as smf
from patsy import dmatrices
import matplotlib.pyplot as plt



def test_statsmodels01():
    # See https://www.statsmodels.org/stable/gettingstarted.html#data
    print('Hello from statsmodels01!')

    dat = sm.datasets.get_rdataset("Guerry", "HistData").data
    results = smf.ols('Lottery ~ Literacy + np.log(Pop1831)', data=dat).fit()
    print(results.summary())
#    print(dir(results))


def test_statsmodels02():
    # See https://www.statsmodels.org/stable/gettingstarted.html#data
    print('Hello from statsmodels02!')

    nobs = 100
    X = np.random.random((nobs, 2))
    X = sm.add_constant(X)
    beta = [1, .1, .5]
    e = np.random.random(nobs)
    y = np.dot(X, beta) + e
    results = sm.OLS(y, X).fit()
    print(results.summary())
    results_summary = results.summary()
    # Note that tables is a list. The table at index 1 is the "core" table. 
    #Additionally, read_html puts dfs in a list, so we want index 0
    results_as_html = results_summary.tables[1].as_html()
    #pd.read_html(results_as_html, header=0, index_col=0)[0]


def test_statsmodels03():
    # See: https://www.statsmodels.org/stable/index.html
    print('Hello from statsmodels03!')

    df = sm.datasets.get_rdataset("Guerry", "HistData").data
    vars = ['Department', 'Lottery', 'Literacy', 'Wealth', 'Region']
    df = df[vars]
    print(df[-5:])

    print()
    df = df.dropna()
    print(df[-5:])

    y, X = dmatrices('Lottery ~ Literacy + Wealth + Region', data=df, return_type='dataframe')
    print(y[:3])
    print()
    print(X[:3])

    mod = sm.OLS(y, X)    # Describe model
    res = mod.fit()       # Fit model
    print(res.summary())   # Summarize model

    print(res.params)   #  extract parameter estimates
    print(res.rsquared)   #  extract rsquared

    print()
    res = sm.stats.linear_rainbow(res)
    print("F: ", res[0], "p:", res[0])

    sm.graphics.plot_partregress('Lottery', 'Wealth', ['Region', 'Literacy'], data=df, obs_labels=False)
    plt.show()




try:
    print()
    test_statsmodels01()
    #test_statsmodels02()
    #test_statsmodels03()



except Exception:
    import traceback
    print(traceback.format_exc())

