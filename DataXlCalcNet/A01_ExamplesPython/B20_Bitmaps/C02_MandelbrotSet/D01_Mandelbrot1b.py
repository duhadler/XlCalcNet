from xlcalcnet import gui
import os, re
#from numba import jit
import numpy as np
from matplotlib import colors, pyplot as plt


#@jit(nopython=True)
def mandelbrot(c, maxiter):
    z = complex(0,0)
    for n in range(maxiter):
        if abs(z) > 2:
            return n
        z = z*z + c
    return maxiter


#@jit(nopython=True)
def mandelbrot_set(xmin,xmax,ymin,ymax,width,height,maxiter):
    r1 = np.linspace(xmin, xmax, width)
    r2 = np.linspace(ymin, ymax, height)
    n3 = np.empty((width,height))
    for i in range(width):
        for j in range(height):
            n3[i,j] = mandelbrot(r1[i] + 1j*r2[j],maxiter)
    return n3


def mandelbrot_image(xmin,xmax,ymin,ymax,width=6,height=6,maxiter=80,cmap='hot'):
    dpi = 96
    z = mandelbrot_set(xmin, xmax, ymin, ymax, dpi * width,dpi * height, maxiter)
    fig, ax = plt.subplots(figsize=(width, height), dpi=dpi)    
    norm = colors.PowerNorm(0.3)
    ax.imshow(z.T, cmap=cmap, norm=norm, origin='lower', extent=[xmin, xmax, ymin, ymax])

    #plt.show()
    gui.plot(fig, __file__, 'Mandelbrot1')
    plt.close("all")


try:
    print()
    mandelbrot_image(-2.0,0.5,-1.25,1.25,maxiter=255,cmap='gist_ncar')

except Exception:
    import traceback
    print(traceback.format_exc())


