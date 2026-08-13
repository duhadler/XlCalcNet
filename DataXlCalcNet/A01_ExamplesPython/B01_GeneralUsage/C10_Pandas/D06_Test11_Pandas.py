# see also: https://pandas.pydata.org/docs/user_guide/basics.html

import numpy as np
import pandas as pd

from xlcalcnet import dpm, fpm, mpm, ipm
from mpaddinG import gpm


def demo_fp():
    r = 8
    c = 4
    dates = pd.date_range('1/1/2000', periods=r)

    R = np.ndarray((r,c),dtype=float)
    d1 = 1.0
    for i in range(r):
        for j in range(c):
            R[i,j] = 10*(i+1) + d1/(j+4)

    npdata = R

    #npdata = np.random.randn(r, c)


    df = pd.DataFrame(npdata, index=dates, columns=['A', 'B', 'C', 'D'])

    print("df: \n", df)

    print("df['A']: \n", df['A'])

    print("df.A: \n", df.A)

    print("df.mean(0): \n", df.mean(0))

    print("df.mean(1): \n", df.mean(1))

def demo_mp():
    r = 8
    c = 4
    gpm.dps = 30
    dates = pd.date_range('1/1/2000', periods=r)

    R = np.ndarray((r,c),dtype=gpm.realtype)
    d1 = gpm.t(1.0)
    for i in range(r):
        for j in range(c):
            R[i,j] = 10*(i+1) + d1/(j+4)

    npdata = R
    print(R)

    #npdata = np.random.randn(r, c)


    df = pd.DataFrame(npdata, index=dates, columns=['A', 'B', 'C', 'D'])

    print("df: \n", df)

    print("df['A']: \n", df['A'])

    print("df.A: \n", df.A)

    #print("df.mean(0): \n", df.mean(0))

    #print("df.mean(1): \n", df.mean(1))


#demo_fp()

demo_mp()
