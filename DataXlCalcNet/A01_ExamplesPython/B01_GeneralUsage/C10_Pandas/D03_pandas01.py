"""
Description of this CPython module
"""

import pandas as pd


def test_pandas01():
    print("Hello from test_pandas01!")
    titanic = pd.read_csv(r"C:\Users\dietrichhadler\Documents\xlcalcnet.xl\Demos\demo01/titanic.csv")
    print(titanic)
    print(titanic.head(8))
    print(titanic.dtypes)



try:
    print()
    test_pandas01()



except Exception:
    import traceback
    print(traceback.format_exc())

