

import numpy as np
import matplotlib.pyplot as plt

from colorsys import hsv_to_rgb, hls_to_rgb
from xlcalcnet.mpmath import *


# https://notebook.community/empet/Math/Klein-j-function


plt.rcParams['figure.figsize'] = 6, 6

pi = 3.1415926535898


def hue(z): # hue value corresponding to a complex number
    h = (float(arg(z)) + pi) / (2*pi)
    return (h + 0.5) % 1.0


def color_hsv (fz):
    if isinf(fz):
        return (1.0, 1.0, 1.0)
    if isnan(fz):
        return (0.5, 0.5, 0.5)
    h=hue(fz)
    m=fabs(fz)
    v=(1-1.0/(1+m**2))**0.2#brightness value
    return  hsv_to_rgb(h, 0.9, v)# s=0.9 is saturation


def color_phase (fz):
    if isinf(fz):
        return (1, 1, 1)
    elif isnan(fz):
        return (0.5, 0.5, 0.5)
    else:
        return  hsv_to_rgb(hue(fz), 1, 1)



def PerFract(x, t, m, M):
    x=x/t
    return m+(M-m)*(x-floor(x))

def color_cont(fz):
    if isinf(fz):
        return (1, 1, 1)
    if isnan(fz):
        return (0.5, 0.5, 0.5)

    n=12  #n is the number of rays drawn in a cycle

    h=hue(fz)
    modul=fabs(fz)
    Logm=log(modul)
    v=PerFract(Logm, 2*pi/n, 0.7, 1)

    return  hsv_to_rgb(h, 1, v)



def demoQ1():
    color_function = "default"
    cplot(lambda q: kleinj(qbar=q), [-1,1], [-1,1], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjQbarDefault.jpg')


def demoQ2():
    color_function = "phase"
    cplot(lambda q: kleinj(qbar=q), [-1,1], [-1,1], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjQbarPhase.jpg')


def demoQ3():
    color_function = color_hsv
    cplot(lambda q: kleinj(qbar=q), [-1,1], [-1,1], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjQbarHsv.jpg')


def demoQ4():
    color_function = color_phase
    cplot(lambda q: kleinj(qbar=q), [-1,1], [-1,1], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjQbarColorPhase.jpg')


def demoQ5():
    color_function = color_cont
    cplot(lambda q: kleinj(qbar=q), [-1,1], [-1,1], color=color_function, \
    verbose=True, points=200000, file='CplotKleinjQbarColorCont.jpg')




def demoT1():
    color_function = "default"
    cplot(lambda t: kleinj(tau=t), [-1,2], [0,1.5], color=color_function, \
    #verbose=True, points=100000, file='CplotKleinjTauDefault.svg')
    verbose=True, points=100000, file='CplotKleinjTauDefault.jpg')


def demoT2():
    color_function = "phase"
    cplot(lambda t: kleinj(tau=t), [-1,2], [0,1.5], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjTauPhase.jpg')


def demoT3():
    color_function = color_hsv
    cplot(lambda t: kleinj(tau=t), [-1,2], [0,1.5], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjTauHsv.jpg')


def demoT4():
    color_function = color_phase
    cplot(lambda t: kleinj(tau=t), [-1,2], [0,1.5], color=color_function, \
    verbose=True, points=100000, file='CplotKleinjTauColorPhase.jpg')


def demoT5():
    color_function = color_cont
    cplot(lambda t: kleinj(tau=t), [-1,2], [0,1.5], color=color_function, \
    verbose=True, points=200000, file='CplotKleinjTauColorCont.jpg')




#demoQ1()
#demoQ2()
#demoQ3()
#demoQ4()
#demoQ5()


demoT1()
#demoT2()
#demoT3()
#demoT4()
#demoT5()




