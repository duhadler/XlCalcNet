

import matplotlib.pyplot as plt
import numpy as np
import pickle
from mpl_toolkits.mplot3d import Axes3D




import subprocess
from subprocess import DETACHED_PROCESS, CREATE_NEW_PROCESS_GROUP, Popen;


outpath = r'C:\Users\dietrichhadler\Documents\xlcalcnet.xl\Demos\demo01'


def popen_demo2():
    import sys
    import userpaths
    import os
    #print(sys.executable)
    PgmExe = sys.executable
    MyDocs = userpaths.get_my_documents()
    PgmPy = os.sep.join([MyDocs, 'DataMpFunLab', 'ShowPlt.py'])
    args = [PgmExe, PgmPy]
    subprocess.Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
        stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)


def showplot(fname):
    fig = pickle.load(open(fname, 'rb'))
    plt.show()



def open_plot_new():
    import sys
    import userpaths
    import os
    #print(sys.executable)
    PgmExe = sys.executable
    MyDocs = userpaths.get_my_documents()
    PgmPy = os.sep.join([MyDocs, 'DataMpFunLab', 'ShowPlt.py'])
    args = [PgmExe, PgmPy]
    subprocess.Popen(args, creationflags=DETACHED_PROCESS | CREATE_NEW_PROCESS_GROUP, \
        stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)



def stacked_4_plot():
    # Some example data to display
    x = np.linspace(0, 2 * np.pi, 400)
    y = np.sin(x ** 2)
    fig, ((ax1, ax2), (ax3, ax4)) = plt.subplots(2, 2, figsize=(10, 5))
    fig.suptitle('Sharing 2x per column, y per row')
    ax1.plot(x, y)
    ax2.plot(x, y**2, 'tab:orange')
    ax3.plot(x, -y, 'tab:green')
    ax4.plot(x, -y**2, 'tab:red')
##    for ax in fig.get_axes():
##        ax.label_outer()

    fname = r'C:\Temp\myfigfile.plt'
    pickle.dump(fig,  open(fname, 'wb'))
    plt.close("all")
    open_plot_new()




def demohelix3dNew():
    # https://scipython.com/book2/chapter-7-matplotlib/examples/depicting-a-helix/

    n = 1000
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')

    # Plot a helix along the x-axis
    theta_max = 8 * np.pi
    theta = np.linspace(0, theta_max, n)
    x = theta
    z =  np.sin(theta)
    y =  np.cos(theta)
    ax.plot(x, y, z, 'b', lw=2)

    # An line through the centre of the helix
    ax.plot((-theta_max*0.2, theta_max * 1.2), (0,0), (0,0), color='k', lw=2)
    # sin/cos components of the helix (e.g. electric and magnetic field
    # components of a circularly-polarized electromagnetic wave
    ax.plot(x, y, 0, color='r', lw=1, alpha=0.5)
    ax.plot(x, [0]*n, z, color='m', lw=1, alpha=0.5)

    # Remove axis planes, ticks and labels
    ax.set_axis_off()
    fname = r'C:\Temp\myfigfile.plt'
    pickle.dump(fig,  open(fname, 'wb'))
    plt.close("all")
    showplot(fname)

    #plt.show()




def demoCycloid():
    #See also: https://en.wikipedia.org/wiki/Cycloid

    from numpy import sin,cos,linspace,pi
    import pylab

    t = linspace(0,20,300*1)

    r = 1;
    x = r * (t - sin(t));
    y = r * (1 - cos(t));


    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Cycloid')
    pylab.show()


def demoTrochoid():
    #See also: https://en.wikipedia.org/wiki/Trochoid

    from numpy import sin,cos,linspace,pi
    import pylab

    t = linspace(0,20,300*1)

    a = 4;
    b = 5;
    x = a * t - b * sin(t);
    y = a - b * cos(t);

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Trochoid')
    pylab.show()


def demoHypocycloid():
    #See also: https://en.wikipedia.org/wiki/Hypotrochoid
    #See also: https://mathworld.wolfram.com/Hypotrochoid.html

    from numpy import sin,cos,linspace,pi
    import pylab

    t = linspace(0,40,300*5)

    k = 7.2;
    r = 1;
    R = k * r;
    x = (R - r) * cos(t) + cos((R - r) * t / r);
    y = (R - r) * sin(t) - sin((R - r) * t / r);

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Hypocycloid')
    pylab.show()


def demoHypotrochoid():
    #See also: https://en.wikipedia.org/wiki/Hypotrochoid
    #See also: https://mathworld.wolfram.com/Hypotrochoid.html

    from numpy import sin,cos,linspace,pi
    import pylab

    t = linspace(0,40,300*5)

    R = 5;
    r = 3;
    d = 5;
    x = (R - r) * cos(t) + d * cos((R - r) * t / r);
    y = (R - r) * sin(t) - d * sin((R - r) * t / r);

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Hypotrochoid')
    pylab.show()


def demoEpitrochoidCS():
    #See also: https://en.wikipedia.org/wiki/Epitrochoid
    #See also: https://mathworld.wolfram.com/Epitrochoid.html

    from numpy import sin,cos,linspace,pi
    import pylab

    # curve parameters
    #R = 14; r = 1; d = 18
    #R = 6; r = 1; d = 6
    R = 3; r = 1; d = 0.5

    t = linspace(0,20,300*5)

    # Epitrochoid parametric equations
    x = (R+r)*cos(t)-d*cos( (R+r)*t / r )
    y = (R+r)*sin(t)-d*sin( (R+r)*t / r )

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('EpitrochoidCS')
    pylab.show()



def demoEpicycloid():
    #See also: https://en.wikipedia.org/wiki/Epicycloid
    #See also: https://mathworld.wolfram.com/Epicycloid.html

    from numpy import sin,cos,linspace,pi
    import pylab

    # curve parameters
    #R = 14; r = 1; d = 18
    #R = 6; r = 1; d = 6
    k = 3.8; r = 1; R = k*r

    t = linspace(0,40,300*5)

    # Epitrochoid parametric equations
    x = (R+r)*cos(t)-cos( (R+r)*t / r )
    y = (R+r)*sin(t)-sin( (R+r)*t / r )

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Epicycloid')
    pylab.show()


def demochrysanthemum_curve():
    #See also: http://www.csharphelper.com/howtos/howto_chrysanthemum_curve.html
    #See also: http://paulbourke.net/geometry/chrysanthemum/

    from numpy import sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,40,300*5)
    r = 5.0 * (1.0 + sin(11.0 * t / 5.0)) - 4.0 * pow(sin(17.0 * t / 3.0), 4.0) * pow(sin(2.0 * cos(3.0 * t) - 28.0 * t), 8.0);
    x = (r * sin(t));
    y = (-r * cos(t));
    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Chrysanthemum curve')
    pylab.show()


def demoButterfly_curve():
    #See also: https://en.wikipedia.org/wiki/Butterfly_curve_(transcendental)
    #See also: https://mathworld.wolfram.com/ButterflyCurve.html

    from numpy import exp,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,40,300*5)
    expr = exp(cos(t)) - 2 * cos(4 * t) - pow(sin(t / 12), 5);
    x = -sin(t) * expr;
    y = cos(t) * expr;
    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Butterfly curve')
    pylab.show()


def demoLissajous_curve():
    #See also: https://en.wikipedia.org/wiki/Lissajous_curve
    #See also: https://mathworld.wolfram.com/LissajousCurve.html

    from numpy import exp,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,40,300*5)

    A = 1;
    B = 1;
    a = 5.0;
    b = 6.0;
    delta = 1.0 * pi / 8.0;

    x = A * sin(a * t + delta);
    y = B * sin(b * t);

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Lissajous curve')
    pylab.show()


def demoLemniscate_of_Bernoulli():
    #See also: https://mathworld.wolfram.com/Lemniscate.html
    #See also: https://en.wikipedia.org/wiki/Lemniscate_of_Bernoulli

    from numpy import exp,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,2*pi,300)

    a = 1;
    s = sin(t);
    c = cos(t);
    d = 1 + s * s;

    x = a * c / d;
    y = a * s * c / d;

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Lemniscate of Bernoulli')
    pylab.show()


def demoLemniscate_of_Gerono():
    #See also: https://mathworld.wolfram.com/EightCurve.html
    #See also: https://en.wikipedia.org/wiki/Lemniscate_of_Gerono

    from numpy import exp,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,2*pi,300)

    a = 1;
    x = a * sin(t);
    y = x * cos(t);

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Lemniscate of Gerono')
    pylab.show()


def demoFish_curve():
    #See also: https://mathworld.wolfram.com/FishCurve.html
    #See also: https://en.wikipedia.org/wiki/Fish_curve

    from numpy import sqrt,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,2*pi,300)

    a = 1;
    s = sin(t);
    c = cos(t);

    x = a * c - (a * s * s) / sqrt(2);
    y = a * c * s;

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Fish curve')
    pylab.show()


def demoHeart_curve():
    #See also: https://mathworld.wolfram.com/HeartCurve.html
    #See also: https://en.wikipedia.org/wiki/Heart_symbol#Parametrisation

    from numpy import sqrt,sin,cos,linspace,pi, power as pow
    import pylab
    t = linspace(0,2*pi,300)

    s = sin(t);
    s2 = s * s;
    c1 = cos(t);
    c2 = cos(2 * t);
    c3 = cos(3 * t);
    c4 = cos(4 * t);
    x = 16 * s * s * s;
    y = 13 * c1 - 5 * c2 - 2 * c3 - c4;

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.title('Heart curve')
    pylab.show()







def demoPolarplot():
    # https://matplotlib.org/stable/gallery/pie_and_polar_charts/polar_demo.html

    r = np.arange(0, 2, 0.01)
    theta = 2 * np.pi * r

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    ax.set_rmax(2)
    ax.set_rticks([0.5, 1, 1.5, 2])  # Less radial ticks
    ax.set_rlabel_position(-22.5)  # Move radial labels away from plotted line
    ax.grid(True,color='lightgrey')
    #ax.grid(True,color='grey',linestyle='dotted')
    ax.set_title("A line plot on a polar axis", va='bottom')
    plt.show()


def demoCardioid():
    # https://scipython.com/book2/chapter-3-simple-plotting/examples/a-cardioid/
    # A cardioid:
    theta = np.linspace(0, 2.*np.pi, 1000)
    a = 1.0
    r = 2 * a * (1. + np.cos(theta))
    #r = 2 * a * (1. - np.cos(theta))

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    ax.set_rmax(4)

    ax.set_rticks([1, 2, 3, 4])
    ax.grid(True,color='lightgrey')
    ax.set_title("Cardioid", va='bottom')
    plt.show()


def demoLimacon(): # not working
    # See also: https://en.wikipedia.org/wiki/Lima%C3%A7on
    # See also: https://mathcurve.com/courbes2d.gb/limacon/limacon.shtml

    theta = np.linspace(0, 2.*np.pi, 2000)
    a = 10.0
    b = 0.5
    r =  b + (a * np.cos(theta))
    #r = 2 * a * (1. - np.cos(theta))

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    #ax.set_rmax(4)

    #ax.set_rticks([1, 2, 3, 4])
    ax.grid(True,color='lightgrey')
    ax.set_title("Limacon", va='bottom')
    plt.show()




def demoRose():
    # See also: https://en.wikipedia.org/wiki/Maurer_rose
    # See also: https://mathworld.wolfram.com/RoseCurve.html

    a = 1.0;
    p = 7.0;
    q = 4.0;   ## angle needs to be 0 to q * 360
    n = p / q;


    theta = np.linspace(0, q * 2.*np.pi, 1000)
    r =  a * np.sin(n * theta)

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    #ax.set_rmax(4)

    ax.set_rticks([-1,  0.0,  1.0])
    ax.grid(True,color='lightgrey')
    ax.set_title("Rose curve", va='bottom')
    plt.show()



def demoNephroid():
    # See also: https://en.wikipedia.org/wiki/Lima%C3%A7on
    # See also: https://mathcurve.com/courbes2d.gb/limacon/limacon.shtml

    a = 1.0;
    n = 4.0;

    theta = np.linspace(0, 4.*np.pi, 2000)

    s1 = np.sin(n * theta / (n - 1));
    s2 = n * np.sin(theta / (n - 1));
    r = a * (1+2*np.sin(theta/2))

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    #ax.set_rmax(4)

    #ax.set_rticks([1, 2, 3, 4])
    ax.grid(True,color='lightgrey')
    ax.set_title("Nephroid", va='bottom')
    plt.show()



def demoSpirals():
    # https://scipython.com/book2/chapter-3-simple-plotting/problems/p33/plotting-spirals/

    # The Archimedean spiral:
    theta = np.linspace(0., 8*np.pi, 1000)
    a, b = 0, 2.
    plt.polar(theta, a+b*theta)
    plt.show()


    # The logarithmic  spiral:
    theta = np.linspace(0, 8*np.pi, 1000)
    a1 = 0.8
    plt.polar(theta, a1**theta)
    plt.show()



def demoEpitrochoids():
    # https://glowingpython.blogspot.com/2011/11/fun-with-epitrochoids.html
    from numpy import sin,cos,linspace,pi
    import pylab

    # curve parameters
    #R = 14; r = 1; d = 18
    #R = 6; r = 1; d = 6
    R = 3; r = 1; d = 1

    #t = linspace(0,2*pi,300*5)
    t = linspace(0,4*pi,300*5)

    # Epitrochoid parametric equations
    x = (R-r)*cos(t)-d*cos( (R+r)*t / r )
    y = (R-r)*sin(t)-d*sin( (R+r)*t / r )

    pylab.plot(x,y,'r')
    pylab.axis('equal')
    pylab.show()



def demotorus3d():
    # https://scipython.com/book2/chapter-7-matplotlib/examples/a-torus/

    n = 100

    theta = np.linspace(0, 2.*np.pi, n)
    phi = np.linspace(0, 2.*np.pi, n)
    theta, phi = np.meshgrid(theta, phi)
    c, a = 2, 1
    x = (c + a*np.cos(theta)) * np.cos(phi)
    y = (c + a*np.cos(theta)) * np.sin(phi)
    z = a * np.sin(theta)

    fig = plt.figure()
    ax1 = fig.add_subplot(121, projection='3d')
    ax1.set_zlim(-3,3)
    ax1.plot_surface(x, y, z, rstride=5, cstride=5, color='k', edgecolors='w')
    ax1.view_init(36, 26)
    ax2 = fig.add_subplot(122, projection='3d')
    ax2.set_zlim(-3,3)
    ax2.plot_surface(x, y, z, rstride=5, cstride=5, color='k', edgecolors='w')
    ax2.view_init(0, 0)
    ax2.set_xticks([])
    plt.show()


def demohelix3d():
    # https://scipython.com/book2/chapter-7-matplotlib/examples/depicting-a-helix/

    n = 1000
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')

    # Plot a helix along the x-axis
    theta_max = 8 * np.pi
    theta = np.linspace(0, theta_max, n)
    x = theta
    z =  np.sin(theta)
    y =  np.cos(theta)
    ax.plot(x, y, z, 'b', lw=2)

    # An line through the centre of the helix
    ax.plot((-theta_max*0.2, theta_max * 1.2), (0,0), (0,0), color='k', lw=2)
    # sin/cos components of the helix (e.g. electric and magnetic field
    # components of a circularly-polarized electromagnetic wave
    ax.plot(x, y, 0, color='r', lw=1, alpha=0.5)
    ax.plot(x, [0]*n, z, color='m', lw=1, alpha=0.5)

    # Remove axis planes, ticks and labels
    ax.set_axis_off()
    fig.tight_layout()
    plt.show()


def democomplex3d():

    n = 128
    #n = 256
    x = np.linspace(-3, 3, n)
    y = np.linspace(-3, 3, n)
    X, Y = np.meshgrid(x, y)
    #Z = np.real(np.log(X + 1j*Y))
    #Z = np.imag(np.log(X + 1j*Y))
    Z = np.abs(np.log(X + 1j*Y))

    fig = plt.figure()
    ax = plt.axes(projection='3d')

    #surf = ax.plot_surface(X, Y, Z, color='lightgray', alpha=.9, rstride=5,cstride=5)
    #surf = ax.plot_surface(X, Y, Z, color='gold', alpha=.9, rstride=5,cstride=5)
    surf = ax.plot_surface(X, Y, Z, color='peru', alpha=.9, rstride=5,cstride=5)

    ax.set_xlabel('x', labelpad=20)
    ax.set_ylabel('y', labelpad=20)
    fig.tight_layout()
    plt.show()





def demoMain():
    #popen_demo2()
    stacked_4_plot()
    #demohelix3dNew()

    #demoCycloid()
    #demoTrochoid()
    #demoHypocycloid()
    #demoHypotrochoid()
    #demoEpitrochoidCS()
    #demoEpicycloid()
    #demochrysanthemum_curve()
    #demoButterfly_curve()
    #demoLissajous_curve()
    #demoLemniscate_of_Bernoulli()
    #demoLemniscate_of_Gerono()
    #demoFish_curve()
    #demoHeart_curve()

    #demoPolarplot()
    #demoCardioid()
    #demoLimacon()
    #demoRose()
    #demoNephroid()

    #demoSpirals()
    #demoEpitrochoids()
    #demotorus3d()
    #demohelix3d()
    #democomplex3d()



try:
    print()
    demoMain()


except Exception:
    import traceback
    print(traceback.format_exc())
