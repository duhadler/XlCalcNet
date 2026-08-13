

import numpy as np
import matplotlib.pyplot as plt
from matplotlib.tri import Triangulation
import matplotlib.ticker as ticker



outpath = r"C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\xlfunlab\Test"






# See also: https://jakevdp.github.io/PythonDataScienceHandbook/04.04-density-and-contour-plots.html
def contour2D_jakevdp():

    def f(x, y):
        return np.sin(x) ** 10 + np.cos(10 + y * x) * np.cos(x)

    x = np.linspace(0, 5, 50)
    y = np.linspace(0, 5, 40)
    X, Y = np.meshgrid(x, y)
    Z = f(X, Y)
    plt.contour(X, Y, Z, 20, cmap='RdGy');
    plt.show()
    #plt.savefig(outpath + r'\contour2D_jakevdp.svg', bbox_inches='tight')
    #plt.savefig(outpath + r'\contour2D_jakevdp.pdf', bbox_inches='tight')




# See also: https://jakevdp.github.io/PythonDataScienceHandbook/04.04-density-and-contour-plots.html
def contour2D_jakevdp_filled():

    def f(x, y):
        return np.sin(x) ** 10 + np.cos(10 + y * x) * np.cos(x)

    x = np.linspace(0, 5, 50)
    y = np.linspace(0, 5, 40)
    X, Y = np.meshgrid(x, y)
    Z = f(X, Y)
    plt.contourf(X, Y, Z, 20, cmap='RdGy')
    plt.colorbar();
    plt.show()
    #plt.savefig(outpath + r'\contour2D_jakevdp_filled.svg', bbox_inches='tight')
    #plt.savefig(outpath + r'\contour2D_jakevdp_filled.pdf', bbox_inches='tight')




#contour2D_jakevdp()
contour2D_jakevdp_filled()





