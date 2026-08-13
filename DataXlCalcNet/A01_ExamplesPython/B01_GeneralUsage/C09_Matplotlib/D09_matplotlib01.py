

import matplotlib.pyplot as plt
import numpy as np
import pickle
from mpl_toolkits.mplot3d import Axes3D


outpath = r'C:\Users\dietrichhadler\Documents\xlcalcnet.xl\Demos\demo01'


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
    plt.show()


def democomplex3d(): 
    # See also: https://stackoverflow.com/questions/77217044/a-complex-function-3d-plot
    # See also: https://stackoverflow.com/questions/67275178/pyplot-how-to-increase-the-resolution-of-plot-surface-and-how-to-remove-the-lin
    
    x1=25
    y1=22
    x2=15
    y2=17
    x3=25
    y3=12
    A1=np.exp(np.deg2rad(0.0) * 1j)
    A2=np.exp(np.deg2rad(10.) * 1j)
    A3=np.exp(np.deg2rad(20.) * 1j)

    # this lambda function represents your "complex function"
    z = lambda x, y: (((2*A1*(y1-y))/((x1-x)**2+(y1-y)**2))+((2*A2*(y2-y))/((x2-x)**2+(y2-y)**2))+((2*A3*(y3-y))/((x3-x)**2+(y3-y)**2)))
    # this lambda function represents the absolute value of your complex function
    z_abs = lambda x, y: np.abs(z(x, y))


    #n = 250
    n = 501
    x = np.linspace(13, 18, n)
    y = np.linspace(15, 20, n)  
    X, Y = np.meshgrid(x, y)
    Z = np.log10(z_abs(X, Y))

    fig = plt.figure()
    ax = plt.axes(projection='3d')
    #surf = ax.plot_surface(X, Y, Z, cmap = plt.cm.cividis)

    #surf = ax.plot_surface(X, Y, Z,color='gray',alpha=.9)

    surf = ax.plot_surface(X, Y, Z,color='gray',alpha=.9, rstride=5,cstride=5)



    ax.set_xlabel('x', labelpad=20)
    ax.set_ylabel('y', labelpad=20)
    fig.colorbar(surf, shrink=0.5, aspect=8, label='abs(z)')
    plt.show()




def singleplot():
    # Some example data to display
    x = np.linspace(0, 2 * np.pi, 400)
    y = np.sin(x ** 2)
    fig, ax = plt.subplots(figsize=(10, 4.5))
    ax.plot(x, y)
    ax.set_title('A single plot')
    #fig.savefig('foo_0.pdf', bbox_inches='tight')
    plt.show()
    fig.savefig(outpath + r'\singleplot.svg', bbox_inches='tight')
    print('saved singleplot.svg')


def stacked_2_plot():
    # Some example data to display
    x = np.linspace(0, 2 * np.pi, 400)
    y = np.sin(x ** 2)
    fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(10, 4.5))
    fig.suptitle('Horizontally stacked subplots')
    ax1.plot(x, y)
    ax2.plot(x, -y)
    plt.show()
    #fig.savefig('foo_2.pdf', bbox_inches='tight')
#    fig.savefig(outpath + r'\stacked_2_plot.svg', bbox_inches='tight')
#    print('saved stacked_2_plot.svg')


def stacked_4_plot():
    # Some example data to display
    x = np.linspace(0, 2 * np.pi, 400)
    y = np.sin(x ** 2)
    fig, ((ax1, ax2), (ax3, ax4)) = plt.subplots(2, 2, figsize=(10, 5))
    fig.suptitle('Sharing x per column, y per row')
    ax1.plot(x, y)
    ax2.plot(x, y**2, 'tab:orange')
    ax3.plot(x, -y, 'tab:green')
    ax4.plot(x, -y**2, 'tab:red')
    for ax in fig.get_axes():
        ax.label_outer()

    pickle.dump(fig,  open(r'C:\Temp\myfigfile.plt', 'wb'))

    plt.close("all")

    fig = pickle.load(open(r'C:\Temp\myfigfile.plt', 'rb'))

    plt.show()
    #fig.savefig('foo_4.pdf', bbox_inches='tight')
    #fig.savefig(outpath + r'\stacked_4_plot.svg', bbox_inches='tight')
    print('saved stacked_4_plot.svg')



def surface_colormap():
    from matplotlib import cm
    from matplotlib.ticker import LinearLocator

    fig, ax = plt.subplots(subplot_kw={"projection": "3d"})

    # Make data.
    X = np.arange(-5, 5, 0.25)
    Y = np.arange(-5, 5, 0.25)
    X, Y = np.meshgrid(X, Y)
    R = np.sqrt(X**2 + Y**2)
    Z = np.sin(R)

    # Plot the surface.
    surf = ax.plot_surface(X, Y, Z, cmap=cm.coolwarm,
                           linewidth=0, antialiased=False)

    # Customize the z axis.
    ax.set_zlim(-1.01, 1.01)
    ax.zaxis.set_major_locator(LinearLocator(10))
    # A StrMethodFormatter is used automatically
    ax.zaxis.set_major_formatter('{x:.02f}')

    # Add a color bar which maps values to colors.
    fig.colorbar(surf, shrink=0.5, aspect=5)

    plt.show()
#    fig.savefig(outpath + r'\surface_colormap.svg', bbox_inches='tight')
#    print('saved surface_colormap.svg')
#    fig.savefig(outpath + r'\surface_colormap.pdf', bbox_inches='tight')
#    print('saved surface_colormap.pdf')
    fig.savefig(outpath + r'\surface_colormap.png', bbox_inches='tight')
    print('saved surface_colormap.png')



def surface_hillshading():
    from matplotlib import cbook
    from matplotlib import cm
    from matplotlib.colors import LightSource

    # Load and format data
    dem = cbook.get_sample_data('jacksboro_fault_dem.npz', np_load=True)
    z = dem['elevation']
    nrows, ncols = z.shape
    x = np.linspace(dem['xmin'], dem['xmax'], ncols)
    y = np.linspace(dem['ymin'], dem['ymax'], nrows)
    x, y = np.meshgrid(x, y)

    region = np.s_[5:50, 5:50]
    x, y, z = x[region], y[region], z[region]

    # Set up plot
    fig, ax = plt.subplots(subplot_kw=dict(projection='3d'))

    ls = LightSource(270, 45)
    # To use a custom hillshading mode, override the built-in shading and pass
    # in the rgb colors of the shaded surface calculated from "shade".
    rgb = ls.shade(z, cmap=cm.gist_earth, vert_exag=0.1, blend_mode='soft')
    surf = ax.plot_surface(x, y, z, rstride=1, cstride=1, facecolors=rgb,
                           linewidth=0, antialiased=False, shade=False)

    plt.show()
#    fig.savefig(outpath + r'\surface_hillshading.svg', bbox_inches='tight')
#    print('saved surface_colormap.svg')
#    fig.savefig(outpath + r'\surface_hillshading.pdf', bbox_inches='tight')
#    print('saved surface_colormap.pdf')
#    fig.savefig(outpath + r'\surface_hillshading.png', bbox_inches='tight')
#    print('saved surface_hillshading.png')




def surface_polar():
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Create the mesh in polar coordinates and compute corresponding Z.
    r = np.linspace(0, 1.25, 50)
    p = np.linspace(0, 2*np.pi, 50)
    R, P = np.meshgrid(r, p)
    Z = ((R**2 - 1)**2)

    # Express the mesh in the cartesian system.
    X, Y = R*np.cos(P), R*np.sin(P)

    # Plot the surface.
    ax.plot_surface(X, Y, Z, cmap=plt.cm.YlGnBu_r)

    # Tweak the limits and add latex math labels.
    ax.set_zlim(0, 1)
    ax.set_xlabel(r'$\phi_\mathrm{real}$')
    ax.set_ylabel(r'$\phi_\mathrm{im}$')
    ax.set_zlabel(r'$V(\phi)$')

    plt.show()
    fig.savefig(outpath + r'\surface_polar.svg', bbox_inches='tight')
    print('saved surface_polar.svg')
    fig.savefig(outpath + r'\surface_polar.pdf', bbox_inches='tight')
    print('saved surface_polar.pdf')
    fig.savefig(outpath + r'\surface_polar.png', bbox_inches='tight')
    print('saved surface_polar.png')



def surface_checkerboard():
    from matplotlib.ticker import LinearLocator
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Make data.
    X = np.arange(-5, 5, 0.25)
    xlen = len(X)
    Y = np.arange(-5, 5, 0.25)
    ylen = len(Y)
    X, Y = np.meshgrid(X, Y)
    R = np.sqrt(X**2 + Y**2)
    Z = np.sin(R)

    # Create an empty array of strings with the same shape as the meshgrid, and
    # populate it with two colors in a checkerboard pattern.
    colortuple = ('y', 'b')
    colors = np.empty(X.shape, dtype=str)
    for y in range(ylen):
        for x in range(xlen):
            colors[y, x] = colortuple[(x + y) % len(colortuple)]

    # Plot the surface with face colors taken from the array we made.
    surf = ax.plot_surface(X, Y, Z, facecolors=colors, linewidth=0)

    # Customize the z axis.
    ax.set_zlim(-1, 1)
    ax.zaxis.set_major_locator(LinearLocator(6))

    plt.show()
    fig.savefig(outpath + r'\surface_checkerboard.svg', bbox_inches='tight')
    print('saved surface_checkerboard.svg')
    fig.savefig(outpath + r'\surface_checkerboard.pdf', bbox_inches='tight')
    print('saved surface_checkerboard.pdf')
    fig.savefig(outpath + r'\surface_checkerboard.png', bbox_inches='tight')
    print('saved surface_checkerboard.png')




def surface_solid():

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Make data
    u = np.linspace(0, 2 * np.pi, 100)
    v = np.linspace(0, np.pi, 100)
    x = 10 * np.outer(np.cos(u), np.sin(v))
    y = 10 * np.outer(np.sin(u), np.sin(v))
    z = 10 * np.outer(np.ones(np.size(u)), np.cos(v))

    # Plot the surface
    ax.plot_surface(x, y, z)

    plt.show()
    fig.savefig(outpath + r'\surface_solid.svg', bbox_inches='tight')
    print('saved surface_solid.svg')
    fig.savefig(outpath + r'\surface_solid.pdf', bbox_inches='tight')
    print('saved surface_solid.pdf')
    fig.savefig(outpath + r'\surface_solid.png', bbox_inches='tight')
    print('saved surface_solid.png')



def stem_3d():

    theta = np.linspace(0, 2*np.pi)
    x = np.cos(theta - np.pi/2)
    y = np.sin(theta - np.pi/2)
    z = theta

    fig, ax = plt.subplots(subplot_kw=dict(projection='3d'))
    ax.stem(x, y, z)

    plt.show()
    fig.savefig(outpath + r'\stem_3d.svg', bbox_inches='tight')
    print('saved stem_3d.svg')
    fig.savefig(outpath + r'\stem_3d.pdf', bbox_inches='tight')
    print('saved stem_3d.pdf')
    fig.savefig(outpath + r'\stem_3d.png', bbox_inches='tight')
    print('saved stem_3d.png')




def polygon_3d():

    from matplotlib.collections import PolyCollection
    from scipy.stats import poisson

    # Fixing random state for reproducibility
    np.random.seed(19680801)


    def polygon_under_graph(x, y):
        """
        Construct the vertex list which defines the polygon filling the space under
        the (x, y) line graph. This assumes x is in ascending order.
        """
        return [(x[0], 0.), *zip(x, y), (x[-1], 0.)]


    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    x = np.linspace(0., 10., 31)
    lambdas = range(1, 9)

    # verts[i] is a list of (x, y) pairs defining polygon i.
    verts = [polygon_under_graph(x, poisson.pmf(l, x)) for l in lambdas]
    facecolors = plt.colormaps['viridis_r'](np.linspace(0, 1, len(verts)))

    poly = PolyCollection(verts, facecolors=facecolors, alpha=.7)
    ax.add_collection3d(poly, zs=lambdas, zdir='y')

    ax.set(xlim=(0, 10), ylim=(1, 9), zlim=(0, 0.35),
           xlabel='x', ylabel=r'$\lambda$', zlabel='probability')

    plt.show()
    fig.savefig(outpath + r'\polygon_3d.svg', bbox_inches='tight')
    print('saved polygon_3d.svg')
    fig.savefig(outpath + r'\polygon_3d.pdf', bbox_inches='tight')
    print('saved polygon_3d.pdf')
    fig.savefig(outpath + r'\polygon_3d.png', bbox_inches='tight')
    print('saved polygon_3d.png')



def surface_triangular():
    n_radii = 8
    n_angles = 36

    # Make radii and angles spaces (radius r=0 omitted to eliminate duplication).
    radii = np.linspace(0.125, 1.0, n_radii)
    angles = np.linspace(0, 2*np.pi, n_angles, endpoint=False)[..., np.newaxis]

    # Convert polar (radii, angles) coords to cartesian (x, y) coords.
    # (0, 0) is manually added at this stage,  so there will be no duplicate
    # points in the (x, y) plane.
    x = np.append(0, (radii*np.cos(angles)).flatten())
    y = np.append(0, (radii*np.sin(angles)).flatten())

    # Compute z to make the pringle surface.
    z = np.sin(-x*y)

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    ax.plot_trisurf(x, y, z, linewidth=0.2, antialiased=True)

    plt.show()
    fig.savefig(outpath + r'\surface_triangular.svg', bbox_inches='tight')
    print('saved surface_triangular.svg')
    fig.savefig(outpath + r'\surface_triangular.pdf', bbox_inches='tight')
    print('saved surface_triangular.pdf')
    fig.savefig(outpath + r'\surface_triangular.png', bbox_inches='tight')
    print('saved surface_triangular.png')



def surface_moebius():
    import matplotlib.tri as mtri

    fig = plt.figure(figsize=plt.figaspect(0.5))

    # ==========
    # First plot
    # ==========

    # Make a mesh in the space of parameterisation variables u and v
    u = np.linspace(0, 2.0 * np.pi, endpoint=True, num=50)
    v = np.linspace(-0.5, 0.5, endpoint=True, num=10)
    u, v = np.meshgrid(u, v)
    u, v = u.flatten(), v.flatten()

    # This is the Mobius mapping, taking a u, v pair and returning an x, y, z
    # triple
    x = (1 + 0.5 * v * np.cos(u / 2.0)) * np.cos(u)
    y = (1 + 0.5 * v * np.cos(u / 2.0)) * np.sin(u)
    z = 0.5 * v * np.sin(u / 2.0)

    # Triangulate parameter space to determine the triangles
    tri = mtri.Triangulation(u, v)

    # Plot the surface.  The triangles in parameter space determine which x, y, z
    # points are connected by an edge.
    ax = fig.add_subplot(1, 2, 1, projection='3d')
    ax.plot_trisurf(x, y, z, triangles=tri.triangles, cmap=plt.cm.Spectral)
    ax.set_zlim(-1, 1)


    # ===========
    # Second plot
    # ===========

    # Make parameter spaces radii and angles.
    n_angles = 36
    n_radii = 8
    min_radius = 0.25
    radii = np.linspace(min_radius, 0.95, n_radii)

    angles = np.linspace(0, 2*np.pi, n_angles, endpoint=False)
    angles = np.repeat(angles[..., np.newaxis], n_radii, axis=1)
    angles[:, 1::2] += np.pi/n_angles

    # Map radius, angle pairs to x, y, z points.
    x = (radii*np.cos(angles)).flatten()
    y = (radii*np.sin(angles)).flatten()
    z = (np.cos(radii)*np.cos(3*angles)).flatten()

    # Create the Triangulation; no triangles so Delaunay triangulation created.
    triang = mtri.Triangulation(x, y)

    # Mask off unwanted triangles.
    xmid = x[triang.triangles].mean(axis=1)
    ymid = y[triang.triangles].mean(axis=1)
    mask = xmid**2 + ymid**2 < min_radius**2
    triang.set_mask(mask)

    # Plot the surface.
    ax = fig.add_subplot(1, 2, 2, projection='3d')
    ax.plot_trisurf(triang, z, cmap=plt.cm.CMRmap)

    plt.show()
    fig.savefig(outpath + r'\surface_moebius.svg', bbox_inches='tight')
    print('saved surface_moebius.svg')
    fig.savefig(outpath + r'\surface_moebius.pdf', bbox_inches='tight')
    print('saved surface_moebius.pdf')
    fig.savefig(outpath + r'\surface_moebius.png', bbox_inches='tight')
    print('saved surface_moebius.png')




def voxel_3d():

    # prepare some coordinates
    x, y, z = np.indices((8, 8, 8))

    # draw cuboids in the top left and bottom right corners, and a link between
    # them
    cube1 = (x < 3) & (y < 3) & (z < 3)
    cube2 = (x >= 5) & (y >= 5) & (z >= 5)
    link = abs(x - y) + abs(y - z) + abs(z - x) <= 2

    # combine the objects into a single boolean array
    voxelarray = cube1 | cube2 | link

    # set the colors of each object
    colors = np.empty(voxelarray.shape, dtype=object)
    colors[link] = 'red'
    colors[cube1] = 'blue'
    colors[cube2] = 'green'

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(voxelarray, facecolors=colors, edgecolor='k')

    plt.show()
    fig.savefig(outpath + r'\voxel_3d.svg', bbox_inches='tight')
    print('saved voxel_3d.svg')
    fig.savefig(outpath + r'\voxel_3d.pdf', bbox_inches='tight')
    print('saved voxel_3d.pdf')
    fig.savefig(outpath + r'\voxel_3d.png', bbox_inches='tight')
    print('saved voxel_3d.png')


def voxel_3d_numpy():

    def explode(data):
        size = np.array(data.shape)*2
        data_e = np.zeros(size - 1, dtype=data.dtype)
        data_e[::2, ::2, ::2] = data
        return data_e

    # build up the numpy logo
    n_voxels = np.zeros((4, 3, 4), dtype=bool)
    n_voxels[0, 0, :] = True
    n_voxels[-1, 0, :] = True
    n_voxels[1, 0, 2] = True
    n_voxels[2, 0, 1] = True
    facecolors = np.where(n_voxels, '#FFD65DC0', '#7A88CCC0')
    edgecolors = np.where(n_voxels, '#BFAB6E', '#7D84A6')
    filled = np.ones(n_voxels.shape)

    # upscale the above voxel image, leaving gaps
    filled_2 = explode(filled)
    fcolors_2 = explode(facecolors)
    ecolors_2 = explode(edgecolors)

    # Shrink the gaps
    x, y, z = np.indices(np.array(filled_2.shape) + 1).astype(float) // 2
    x[0::2, :, :] += 0.05
    y[:, 0::2, :] += 0.05
    z[:, :, 0::2] += 0.05
    x[1::2, :, :] += 0.95
    y[:, 1::2, :] += 0.95
    z[:, :, 1::2] += 0.95

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(x, y, z, filled_2, facecolors=fcolors_2, edgecolors=ecolors_2)

    plt.show()
    fig.savefig(outpath + r'\voxel_3d_numpy.svg', bbox_inches='tight')
    print('saved voxel_3d_numpy.svg')
    fig.savefig(outpath + r'\voxel_3d_numpy.pdf', bbox_inches='tight')
    print('saved voxel_3d_numpy.pdf')
    fig.savefig(outpath + r'\voxel_3d_numpy.png', bbox_inches='tight')
    print('saved voxel_3d_numpy.png')


def voxel_3d_rgb():

    def midpoints(x):
        sl = ()
        for i in range(x.ndim):
            x = (x[sl + np.index_exp[:-1]] + x[sl + np.index_exp[1:]]) / 2.0
            sl += np.index_exp[:]
        return x

    # prepare some coordinates, and attach rgb values to each
    r, g, b = np.indices((17, 17, 17)) / 16.0
    rc = midpoints(r)
    gc = midpoints(g)
    bc = midpoints(b)

    # define a sphere about [0.5, 0.5, 0.5]
    sphere = (rc - 0.5)**2 + (gc - 0.5)**2 + (bc - 0.5)**2 < 0.5**2

    # combine the color components
    colors = np.zeros(sphere.shape + (3,))
    colors[..., 0] = rc
    colors[..., 1] = gc
    colors[..., 2] = bc

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(r, g, b, sphere,
              facecolors=colors,
              edgecolors=np.clip(2*colors - 0.5, 0, 1),  # brighter
              linewidth=0.5)
    ax.set(xlabel='r', ylabel='g', zlabel='b')

    plt.show()
    fig.savefig(outpath + r'\voxel_3d_rgb.svg', bbox_inches='tight')
    print('saved voxel_3d_rgb.svg')
    fig.savefig(outpath + r'\voxel_3d_rgb.pdf', bbox_inches='tight')
    print('saved voxel_3d_rgb.pdf')
    fig.savefig(outpath + r'\voxel_3d_rgb.png', bbox_inches='tight')
    print('saved voxel_3d_rgb.png')


def voxel_3d_cylindric():

    import matplotlib.colors

    def midpoints(x):
        sl = ()
        for i in range(x.ndim):
            x = (x[sl + np.index_exp[:-1]] + x[sl + np.index_exp[1:]]) / 2.0
            sl += np.index_exp[:]
        return x

    # prepare some coordinates, and attach rgb values to each
    r, theta, z = np.mgrid[0:1:11j, 0:np.pi*2:25j, -0.5:0.5:11j]
    x = r*np.cos(theta)
    y = r*np.sin(theta)

    rc, thetac, zc = midpoints(r), midpoints(theta), midpoints(z)

    # define a wobbly torus about [0.7, *, 0]
    sphere = (rc - 0.7)**2 + (zc + 0.2*np.cos(thetac*2))**2 < 0.2**2

    # combine the color components
    hsv = np.zeros(sphere.shape + (3,))
    hsv[..., 0] = thetac / (np.pi*2)
    hsv[..., 1] = rc
    hsv[..., 2] = zc + 0.5
    colors = matplotlib.colors.hsv_to_rgb(hsv)

    # and plot everything
    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    ax.voxels(x, y, z, sphere,
              facecolors=colors,
              edgecolors=np.clip(2*colors - 0.5, 0, 1),  # brighter
              linewidth=0.5)

    plt.show()
    fig.savefig(outpath + r'\voxel_3d_cylindric.svg', bbox_inches='tight')
    print('saved voxel_3d_cylindric.svg')
    fig.savefig(outpath + r'\voxel_3d_cylindric.pdf', bbox_inches='tight')
    print('saved voxel_3d_cylindric.pdf')
    fig.savefig(outpath + r'\voxel_3d_cylindric.png', bbox_inches='tight')
    print('saved voxel_3d_cylindric.png')


def wireframe_3d_1direction():
    from mpl_toolkits.mplot3d import axes3d

    fig, (ax1, ax2) = plt.subplots(
        2, 1, figsize=(8, 12), subplot_kw={'projection': '3d'})

    # Get the test data
    X, Y, Z = axes3d.get_test_data(0.01)

    # Give the first plot only wireframes of the type y = c
    ax1.plot_wireframe(X, Y, Z, rstride=10, cstride=0)
    ax1.set_title("Column (x) stride set to 0")

    # Give the second plot only wireframes of the type x = c
    ax2.plot_wireframe(X, Y, Z, rstride=0, cstride=10)
    ax2.set_title("Row (y) stride set to 0")

    plt.tight_layout()

    plt.show()
    fig.savefig(outpath + r'\wireframe_3d_1direction.svg', bbox_inches='tight')
    print('saved wireframe_3d_1direction.svg')
    fig.savefig(outpath + r'\wireframe_3d_1direction.pdf', bbox_inches='tight')
    print('saved wireframe_3d_1direction.pdf')
    fig.savefig(outpath + r'\wireframe_3d_1direction.png', bbox_inches='tight')
    print('saved wireframe_3d_1direction.png')



def wireframe_3d():
    from mpl_toolkits.mplot3d import axes3d

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')

    # Grab some test data.
    X, Y, Z = axes3d.get_test_data(0.02)

    # Plot a basic wireframe.
    ax.plot_wireframe(X, Y, Z, rstride=10, cstride=10)

    plt.show()
    fig.savefig(outpath + r'\wireframe_3d.svg', bbox_inches='tight')
    print('saved wireframe_3d.svg')
    fig.savefig(outpath + r'\wireframe_3d.pdf', bbox_inches='tight')
    print('saved wireframe_3d.pdf')
    fig.savefig(outpath + r'\wireframe_3d.png', bbox_inches='tight')
    print('saved wireframe_3d.png')


def bar_chart_gradients():

    np.random.seed(19680801)

    def gradient_image(ax, extent, direction=0.3, cmap_range=(0, 1), **kwargs):
        phi = direction * np.pi / 2
        v = np.array([np.cos(phi), np.sin(phi)])
        X = np.array([[v @ [1, 0], v @ [1, 1]],
                      [v @ [0, 0], v @ [0, 1]]])
        a, b = cmap_range
        X = a + (b - a) / X.max() * X
        im = ax.imshow(X, extent=extent, interpolation='bicubic',
                       vmin=0, vmax=1, **kwargs)
        return im


    def gradient_bar(ax, x, y, width=0.5, bottom=0):
        for left, top in zip(x, y):
            right = left + width
            gradient_image(ax, extent=(left, right, bottom, top),
                           cmap=plt.cm.Blues_r, cmap_range=(0, 0.8))


    xmin, xmax = xlim = 0, 10
    ymin, ymax = ylim = 0, 1

    fig, ax = plt.subplots()
    ax.set(xlim=xlim, ylim=ylim, autoscale_on=False)

    # background image
    gradient_image(ax, direction=1, extent=(0, 1, 0, 1), transform=ax.transAxes,
                   cmap=plt.cm.RdYlGn, cmap_range=(0.2, 0.8), alpha=0.5)

    N = 10
    x = np.arange(N) + 0.15
    y = np.random.rand(N)
    gradient_bar(ax, x, y, width=0.7)
    ax.set_aspect('auto')

    plt.show()
    fig.savefig(outpath + r'\bar_chart_gradients.svg', bbox_inches='tight')
    print('saved bar_chart_gradients.svg')
    fig.savefig(outpath + r'\bar_chart_gradients.pdf', bbox_inches='tight')
    print('saved bar_chart_gradients.pdf')
    fig.savefig(outpath + r'\bar_chart_gradients.png', bbox_inches='tight')
    print('saved bar_chart_gradients.png')




def koch_snowflake_demo():

    def koch_snowflake(order, scale=10):
        def _koch_snowflake_complex(order):
            if order == 0:
                # initial triangle
                angles = np.array([0, 120, 240]) + 90
                return scale / np.sqrt(3) * np.exp(np.deg2rad(angles) * 1j)
            else:
                ZR = 0.5 - 0.5j * np.sqrt(3) / 3

                p1 = _koch_snowflake_complex(order - 1)  # start points
                p2 = np.roll(p1, shift=-1)  # end points
                dp = p2 - p1  # connection vectors

                new_points = np.empty(len(p1) * 4, dtype=np.complex128)
                new_points[::4] = p1
                new_points[1::4] = p1 + dp / 3
                new_points[2::4] = p1 + dp * ZR
                new_points[3::4] = p1 + dp / 3 * 2
                return new_points

        points = _koch_snowflake_complex(order)
        x, y = points.real, points.imag
        return x, y

    x, y = koch_snowflake(order=5)

    #fig = plt.figure()

    fig = plt.figure(figsize=(8, 8))
    plt.axis('equal')
    plt.fill(x, y)

    plt.show()
    fig.savefig(outpath + r'\koch_snowflake_demo.svg', bbox_inches='tight')
    print('saved koch_snowflake_demo.svg')
    fig.savefig(outpath + r'\koch_snowflake_demo.pdf', bbox_inches='tight')
    print('saved koch_snowflake_demo.pdf')
    fig.savefig(outpath + r'\koch_snowflake_demo.png', bbox_inches='tight')
    print('saved koch_snowflake_demo.png')




def confidence_bands():
    N = 21
    x = np.linspace(0, 10, 11)
    y = [3.9, 4.4, 10.8, 10.3, 11.2, 13.1, 14.1,  9.9, 13.9, 15.1, 12.5]

    # fit a linear curve an estimate its y-values and their error.
    a, b = np.polyfit(x, y, deg=1)
    y_est = a * x + b
    y_err = x.std() * np.sqrt(1/len(x) +
                              (x - x.mean())**2 / np.sum((x - x.mean())**2))

    fig, ax = plt.subplots()
    ax.plot(x, y_est, '-')
    ax.fill_between(x, y_est - y_err, y_est + y_err, alpha=0.2)
    ax.plot(x, y, 'o', color='tab:brown')

    plt.show()
    fig.savefig(outpath + r'\confidence_bands.svg', bbox_inches='tight')
    print('saved confidence_bands.svg')
    fig.savefig(outpath + r'\confidence_bands.pdf', bbox_inches='tight')
    print('saved confidence_bands.pdf')
    fig.savefig(outpath + r'\confidence_bands.png', bbox_inches='tight')
    print('saved confidence_bands.png')



def survey_chart():

    category_names = ['Strongly disagree', 'Disagree',
                      'Neither agree nor disagree', 'Agree', 'Strongly agree']
    results = {
        'Question 1': [10, 15, 17, 32, 26],
        'Question 2': [26, 22, 29, 10, 13],
        'Question 3': [35, 37, 7, 2, 19],
        'Question 4': [32, 11, 9, 15, 33],
        'Question 5': [21, 29, 5, 5, 40],
        'Question 6': [8, 19, 5, 30, 38]
    }

    def survey(results, category_names):
        labels = list(results.keys())
        data = np.array(list(results.values()))
        data_cum = data.cumsum(axis=1)
        category_colors = plt.colormaps['RdYlGn'](
            np.linspace(0.15, 0.85, data.shape[1]))

        fig, ax = plt.subplots(figsize=(9.2, 5))
        ax.invert_yaxis()
        ax.xaxis.set_visible(False)
        ax.set_xlim(0, np.sum(data, axis=1).max())

        for i, (colname, color) in enumerate(zip(category_names, category_colors)):
            widths = data[:, i]
            starts = data_cum[:, i] - widths
            rects = ax.barh(labels, widths, left=starts, height=0.5,
                            label=colname, color=color)

            r, g, b, _ = color
            text_color = 'white' if r * g * b < 0.5 else 'darkgrey'
            ax.bar_label(rects, label_type='center', color=text_color)
        ax.legend(ncol=len(category_names), bbox_to_anchor=(0, 1),
                  loc='lower left', fontsize='small')

        return fig, ax


    fig, ax = survey(results, category_names)

    plt.show()
    fig.savefig(outpath + r'\survey_chart.svg', bbox_inches='tight')
    print('saved survey_chart.svg')
    fig.savefig(outpath + r'\survey_chart.pdf', bbox_inches='tight')
    print('saved survey_chart.pdf')
    fig.savefig(outpath + r'\survey_chart.png', bbox_inches='tight')
    print('saved survey_chart.png')




def masked_plot():

    x = np.linspace(-np.pi/2, np.pi/2, 31)
    y = np.cos(x)**3

    # 1) remove points where y > 0.7
    x2 = x[y <= 0.7]
    y2 = y[y <= 0.7]

    # 2) mask points where y > 0.7
    y3 = np.ma.masked_where(y > 0.7, y)

    # 3) set to NaN where y > 0.7
    y4 = y.copy()
    y4[y3 > 0.7] = np.nan

    fig, ax = plt.subplots()

    ax.plot(x*0.1, y, 'o-', color='lightgrey', label='No mask')
    ax.plot(x2*0.4, y2, 'o-', label='Points removed')
    ax.plot(x*0.7, y3, 'o-', label='Masked values')
    ax.plot(x*1.0, y4, 'o-', label='NaN values')
    ax.legend()
    #ax.title('Masked and NaN data')

    plt.show()
    fig.savefig(outpath + r'\masked_plot.svg', bbox_inches='tight')
    print('saved masked_plot.svg')
    fig.savefig(outpath + r'\masked_plot.pdf', bbox_inches='tight')
    print('saved masked_plot.pdf')
    fig.savefig(outpath + r'\masked_plot.png', bbox_inches='tight')
    print('saved masked_plot.png')



def fill_between_alpha():

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    Nsteps, Nwalkers = 100, 250
    t = np.arange(Nsteps)

    # an (Nsteps x Nwalkers) array of random walk steps
    S1 = 0.004 + 0.02*np.random.randn(Nsteps, Nwalkers)
    S2 = 0.002 + 0.01*np.random.randn(Nsteps, Nwalkers)

    # an (Nsteps x Nwalkers) array of random walker positions
    X1 = S1.cumsum(axis=0)
    X2 = S2.cumsum(axis=0)


    # Nsteps length arrays empirical means and standard deviations of both
    # populations over time
    mu1 = X1.mean(axis=1)
    sigma1 = X1.std(axis=1)
    mu2 = X2.mean(axis=1)
    sigma2 = X2.std(axis=1)

    # plot it!
    fig, ax = plt.subplots(1)
    ax.plot(t, mu1, lw=2, label='mean population 1')
    ax.plot(t, mu2, lw=2, label='mean population 2')
    ax.fill_between(t, mu1+sigma1, mu1-sigma1, facecolor='C0', alpha=0.4)
    ax.fill_between(t, mu2+sigma2, mu2-sigma2, facecolor='C1', alpha=0.4)
    ax.set_title(r'random walkers empirical $\mu$ and $\pm \sigma$ interval')
    ax.legend(loc='upper left')
    ax.set_xlabel('num steps')
    ax.set_ylabel('position')
    ax.grid()

    plt.show()
    fig.savefig(outpath + r'\fill_between_alpha.svg', bbox_inches='tight')
    print('saved fill_between_alpha.svg')
    fig.savefig(outpath + r'\fill_between_alpha.pdf', bbox_inches='tight')
    print('saved fill_between_alpha.pdf')
    fig.savefig(outpath + r'\fill_between_alpha.png', bbox_inches='tight')
    print('saved fill_between_alpha.png')




def walker_1sigma():

    # Fixing random state for reproducibility
    np.random.seed(1)

    Nsteps = 500
    t = np.arange(Nsteps)

    mu = 0.002
    sigma = 0.01

    # the steps and position
    S = mu + sigma*np.random.randn(Nsteps)
    X = S.cumsum()

    # the 1 sigma upper and lower analytic population bounds
    lower_bound = mu*t - sigma*np.sqrt(t)
    upper_bound = mu*t + sigma*np.sqrt(t)

    fig, ax = plt.subplots(1)
    ax.plot(t, X, lw=2, label='walker position')
    ax.plot(t, mu*t, lw=1, label='population mean', color='C0', ls='--')
    ax.fill_between(t, lower_bound, upper_bound, facecolor='C0', alpha=0.4,
                    label='1 sigma range')
    ax.legend(loc='upper left')

    # here we use the where argument to only fill the region where the
    # walker is above the population 1 sigma boundary
    ax.fill_between(t, upper_bound, X, where=X > upper_bound, fc='red', alpha=0.4)
    ax.fill_between(t, lower_bound, X, where=X < lower_bound, fc='red', alpha=0.4)
    ax.set_xlabel('num steps')
    ax.set_ylabel('position')
    ax.grid()

    plt.show()
    fig.savefig(outpath + r'\walker_1sigma.svg', bbox_inches='tight')
    print('saved walker_1sigma.svg')
    fig.savefig(outpath + r'\walker_1sigma.pdf', bbox_inches='tight')
    print('saved walker_1sigma.pdf')
    fig.savefig(outpath + r'\walker_1sigma.png', bbox_inches='tight')
    print('saved walker_1sigma.png')




def multicolored_lines():

    import numpy as np
    import matplotlib.pyplot as plt
    from matplotlib.collections import LineCollection
    from matplotlib.colors import ListedColormap, BoundaryNorm

    x = np.linspace(0, 3 * np.pi, 500)
    y = np.sin(x)
    dydx = np.cos(0.5 * (x[:-1] + x[1:]))  # first derivative

    # Create a set of line segments so that we can color them individually
    # This creates the points as a N x 1 x 2 array so that we can stack points
    # together easily to get the segments. The segments array for line collection
    # needs to be (numlines) x (points per line) x 2 (for x and y)
    points = np.array([x, y]).T.reshape(-1, 1, 2)
    segments = np.concatenate([points[:-1], points[1:]], axis=1)

    fig, axs = plt.subplots(2, 1, sharex=True, sharey=True)

    # Create a continuous norm to map from data points to colors
    norm = plt.Normalize(dydx.min(), dydx.max())
    lc = LineCollection(segments, cmap='viridis', norm=norm)
    # Set the values used for colormapping
    lc.set_array(dydx)
    lc.set_linewidth(2)
    line = axs[0].add_collection(lc)
    fig.colorbar(line, ax=axs[0])

    # Use a boundary norm instead
    cmap = ListedColormap(['r', 'g', 'b'])
    norm = BoundaryNorm([-1, -0.5, 0.5, 1], cmap.N)
    lc = LineCollection(segments, cmap=cmap, norm=norm)
    lc.set_array(dydx)
    lc.set_linewidth(2)
    line = axs[1].add_collection(lc)
    fig.colorbar(line, ax=axs[1])

    axs[0].set_xlim(x.min(), x.max())
    axs[0].set_ylim(-1.1, 1.1)

    plt.show()
    fig.savefig(outpath + r'\multicolored_lines.svg', bbox_inches='tight')
    print('saved multicolored_lines.svg')
    fig.savefig(outpath + r'\multicolored_lines.pdf', bbox_inches='tight')
    print('saved multicolored_lines.pdf')
    fig.savefig(outpath + r'\multicolored_lines.png', bbox_inches='tight')
    print('saved multicolored_lines.png')



def scatterplot_histogram():

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    # some random data
    x = np.random.randn(1000)
    y = np.random.randn(1000)


    def scatter_hist(x, y, ax, ax_histx, ax_histy):
        # no labels
        ax_histx.tick_params(axis="x", labelbottom=False)
        ax_histy.tick_params(axis="y", labelleft=False)

        # the scatter plot:
        ax.scatter(x, y)

        # now determine nice limits by hand:
        binwidth = 0.25
        xymax = max(np.max(np.abs(x)), np.max(np.abs(y)))
        lim = (int(xymax/binwidth) + 1) * binwidth

        bins = np.arange(-lim, lim + binwidth, binwidth)
        ax_histx.hist(x, bins=bins)
        ax_histy.hist(y, bins=bins, orientation='horizontal')

    # definitions for the axes
    left, width = 0.1, 0.65
    bottom, height = 0.1, 0.65
    spacing = 0.005


    rect_scatter = [left, bottom, width, height]
    rect_histx = [left, bottom + height + spacing, width, 0.2]
    rect_histy = [left + width + spacing, bottom, 0.2, height]

    # start with a square Figure
    fig = plt.figure(figsize=(8, 8))

    ax = fig.add_axes(rect_scatter)
    ax_histx = fig.add_axes(rect_histx, sharex=ax)
    ax_histy = fig.add_axes(rect_histy, sharey=ax)

    # use the previously defined function
    scatter_hist(x, y, ax, ax_histx, ax_histy)

    plt.show()
    fig.savefig(outpath + r'\scatterplot_histogram.svg', bbox_inches='tight')
    print('saved scatterplot_histogram.svg')
    fig.savefig(outpath + r'\scatterplot_histogram.pdf', bbox_inches='tight')
    print('saved scatterplot_histogram.pdf')
    fig.savefig(outpath + r'\scatterplot_histogram.png', bbox_inches='tight')
    print('saved scatterplot_histogram.png')




def simple_plot():
    # Data for plotting
    t = np.arange(0.0, 2.0, 0.01)
    s = 1 + np.sin(2 * np.pi * t)

    fig, ax = plt.subplots()
    ax.plot(t, s)

    ax.set(xlabel='time (s)', ylabel='voltage (mV)',
           title='About as simple as it gets, folks')
    ax.grid()

    plt.show()
    fig.savefig(outpath + r'\simple_plot.svg', bbox_inches='tight')
    print('saved simple_plot.svg')
    fig.savefig(outpath + r'\simple_plot.pdf', bbox_inches='tight')
    print('saved simple_plot.pdf')
    fig.savefig(outpath + r'\simple_plot.png', bbox_inches='tight')
    print('saved simple_plot.png')



def spectrum_representations():

    np.random.seed(0)

    dt = 0.01  # sampling interval
    Fs = 1 / dt  # sampling frequency
    t = np.arange(0, 10, dt)

    # generate noise:
    nse = np.random.randn(len(t))
    r = np.exp(-t / 0.05)
    cnse = np.convolve(nse, r) * dt
    cnse = cnse[:len(t)]

    s = 0.1 * np.sin(4 * np.pi * t) + cnse  # the signal

    fig, axs = plt.subplots(nrows=3, ncols=2, figsize=(7, 7))

    # plot time signal:
    axs[0, 0].set_title("Signal")
    axs[0, 0].plot(t, s, color='C0')
    axs[0, 0].set_xlabel("Time")
    axs[0, 0].set_ylabel("Amplitude")

    # plot different spectrum types:
    axs[1, 0].set_title("Magnitude Spectrum")
    axs[1, 0].magnitude_spectrum(s, Fs=Fs, color='C1')

    axs[1, 1].set_title("Log. Magnitude Spectrum")
    axs[1, 1].magnitude_spectrum(s, Fs=Fs, scale='dB', color='C1')

    axs[2, 0].set_title("Phase Spectrum ")
    axs[2, 0].phase_spectrum(s, Fs=Fs, color='C2')

    axs[2, 1].set_title("Angle Spectrum")
    axs[2, 1].angle_spectrum(s, Fs=Fs, color='C2')

    axs[0, 1].remove()  # don't display empty ax

    fig.tight_layout()

    plt.show()
    fig.savefig(outpath + r'\spectrum_representations.svg', bbox_inches='tight')
    print('saved spectrum_representations.svg')
    fig.savefig(outpath + r'\spectrum_representations.pdf', bbox_inches='tight')
    print('saved spectrum_representations.pdf')
    fig.savefig(outpath + r'\spectrum_representations.png', bbox_inches='tight')
    print('saved spectrum_representations.png')




def boxplots():

    # Random test data
    np.random.seed(19680801)
    all_data = [np.random.normal(0, std, size=100) for std in range(1, 4)]
    labels = ['x1', 'x2', 'x3']

    fig, (ax1, ax2) = plt.subplots(nrows=1, ncols=2, figsize=(9, 4))

    # rectangular box plot
    bplot1 = ax1.boxplot(all_data,
                         vert=True,  # vertical box alignment
                         patch_artist=True,  # fill with color
                         labels=labels)  # will be used to label x-ticks
    ax1.set_title('Rectangular box plot')

    # notch shape box plot
    bplot2 = ax2.boxplot(all_data,
                         notch=True,  # notch shape
                         vert=True,  # vertical box alignment
                         patch_artist=True,  # fill with color
                         labels=labels)  # will be used to label x-ticks
    ax2.set_title('Notched box plot')

    # fill with colors
    colors = ['pink', 'lightblue', 'lightgreen']
    for bplot in (bplot1, bplot2):
        for patch, color in zip(bplot['boxes'], colors):
            patch.set_facecolor(color)

    # adding horizontal grid lines
    for ax in [ax1, ax2]:
        ax.yaxis.grid(True)
        ax.set_xlabel('Three separate samples')
        ax.set_ylabel('Observed values')

    plt.show()
    fig.savefig(outpath + r'\boxplots.svg', bbox_inches='tight')
    print('saved boxplots.svg')
    fig.savefig(outpath + r'\boxplots.pdf', bbox_inches='tight')
    print('saved boxplots.pdf')
    fig.savefig(outpath + r'\boxplots.png', bbox_inches='tight')
    print('saved boxplots.png')




def confidence_ellipse(x, y, ax, n_std=3.0, facecolor='none', **kwargs):
    from matplotlib.patches import Ellipse
    import matplotlib.transforms as transforms

    if x.size != y.size:
        raise ValueError("x and y must be the same size")

    cov = np.cov(x, y)
    pearson = cov[0, 1]/np.sqrt(cov[0, 0] * cov[1, 1])
    # Using a special case to obtain the eigenvalues of this
    # two-dimensionl dataset.
    ell_radius_x = np.sqrt(1 + pearson)
    ell_radius_y = np.sqrt(1 - pearson)
    ellipse = Ellipse((0, 0), width=ell_radius_x * 2, height=ell_radius_y * 2,
                      facecolor=facecolor, **kwargs)

    # Calculating the stdandard deviation of x from
    # the squareroot of the variance and multiplying
    # with the given number of standard deviations.
    scale_x = np.sqrt(cov[0, 0]) * n_std
    mean_x = np.mean(x)

    # calculating the stdandard deviation of y ...
    scale_y = np.sqrt(cov[1, 1]) * n_std
    mean_y = np.mean(y)

    transf = transforms.Affine2D() \
        .rotate_deg(45) \
        .scale(scale_x, scale_y) \
        .translate(mean_x, mean_y)

    ellipse.set_transform(transf + ax.transData)
    return ax.add_patch(ellipse)


def get_correlated_dataset(n, dependency, mu, scale):
    latent = np.random.randn(n, 2)
    dependent = latent.dot(dependency)
    scaled = dependent * scale
    scaled_with_offset = scaled + mu
    # return x and y of the new, correlated dataset
    return scaled_with_offset[:, 0], scaled_with_offset[:, 1]


def demo_correlation():

    np.random.seed(0)

    PARAMETERS = {
        'Positive correlation': [[0.85, 0.35],
                                 [0.15, -0.65]],
        'Negative correlation': [[0.9, -0.4],
                                 [0.1, -0.6]],
        'Weak correlation': [[1, 0],
                             [0, 1]],
    }

    mu = 2, 4
    scale = 3, 5

    fig, axs = plt.subplots(1, 3, figsize=(9, 3))
    for ax, (title, dependency) in zip(axs, PARAMETERS.items()):
        x, y = get_correlated_dataset(800, dependency, mu, scale)
        ax.scatter(x, y, s=0.5)

        ax.axvline(c='grey', lw=1)
        ax.axhline(c='grey', lw=1)

        confidence_ellipse(x, y, ax, edgecolor='red')

        ax.scatter(mu[0], mu[1], c='red', s=3)
        ax.set_title(title)

    plt.show()
    fig.savefig(outpath + r'\demo_correlation.svg', bbox_inches='tight')
    print('saved demo_correlation.svg')
    fig.savefig(outpath + r'\demo_correlation.pdf', bbox_inches='tight')
    print('saved demo_correlation.pdf')
    fig.savefig(outpath + r'\demo_correlation.png', bbox_inches='tight')
    print('saved demo_correlation.png')



def demo_corr_diff_std():

    fig, ax_nstd = plt.subplots(figsize=(6, 6))

    dependency_nstd = [[0.8, 0.75],
                       [-0.2, 0.35]]
    mu = 0, 0
    scale = 8, 5

    ax_nstd.axvline(c='grey', lw=1)
    ax_nstd.axhline(c='grey', lw=1)

    x, y = get_correlated_dataset(500, dependency_nstd, mu, scale)
    ax_nstd.scatter(x, y, s=0.5)

    confidence_ellipse(x, y, ax_nstd, n_std=1,
                       label=r'$1\sigma$', edgecolor='firebrick')
    confidence_ellipse(x, y, ax_nstd, n_std=2,
                       label=r'$2\sigma$', edgecolor='fuchsia', linestyle='--')
    confidence_ellipse(x, y, ax_nstd, n_std=3,
                       label=r'$3\sigma$', edgecolor='blue', linestyle=':')

    ax_nstd.scatter(mu[0], mu[1], c='red', s=3)
    ax_nstd.set_title('Different standard deviations')
    ax_nstd.legend()

    plt.show()
    fig.savefig(outpath + r'\demo_corr_diff_std.svg', bbox_inches='tight')
    print('saved demo_corr_diff_std.svg')
    fig.savefig(outpath + r'\demo_corr_diff_std.pdf', bbox_inches='tight')
    print('saved demo_corr_diff_std.pdf')
    fig.savefig(outpath + r'\demo_corr_diff_std.png', bbox_inches='tight')
    print('saved demo_corr_diff_std.png')



def demo_corr_kwargs():

    fig, ax_kwargs = plt.subplots(figsize=(6, 6))
    dependency_kwargs = [[-0.8, 0.5],
                         [-0.2, 0.5]]
    mu = 2, -3
    scale = 6, 5

    ax_kwargs.axvline(c='grey', lw=1)
    ax_kwargs.axhline(c='grey', lw=1)

    x, y = get_correlated_dataset(500, dependency_kwargs, mu, scale)
    # Plot the ellipse with zorder=0 in order to demonstrate
    # its transparency (caused by the use of alpha).
    confidence_ellipse(x, y, ax_kwargs,
                       alpha=0.5, facecolor='pink', edgecolor='purple', zorder=0)

    ax_kwargs.scatter(x, y, s=0.5)
    ax_kwargs.scatter(mu[0], mu[1], c='red', s=3)
    ax_kwargs.set_title('Using keyword arguments')

    fig.subplots_adjust(hspace=0.25)

    plt.show()
    fig.savefig(outpath + r'\demo_corr_kwargs.svg', bbox_inches='tight')
    print('saved demo_corr_kwargs.svg')
    fig.savefig(outpath + r'\demo_corr_kwargs.pdf', bbox_inches='tight')
    print('saved demo_corr_kwargs.pdf')
    fig.savefig(outpath + r'\demo_corr_kwargs.png', bbox_inches='tight')
    print('saved demo_corr_kwargs.png')



def cum_histogram():

    np.random.seed(19680801)

    mu = 200
    sigma = 25
    n_bins = 50
    x = np.random.normal(mu, sigma, size=100)

    fig, ax = plt.subplots(figsize=(8, 4))

    # plot the cumulative histogram
    n, bins, patches = ax.hist(x, n_bins, density=True, histtype='step',
                               cumulative=True, label='Empirical')

    # Add a line showing the expected distribution.
    y = ((1 / (np.sqrt(2 * np.pi) * sigma)) *
         np.exp(-0.5 * (1 / sigma * (bins - mu))**2))
    y = y.cumsum()
    y /= y[-1]

    ax.plot(bins, y, 'k--', linewidth=1.5, label='Theoretical')

    # Overlay a reversed cumulative histogram.
    ax.hist(x, bins=bins, density=True, histtype='step', cumulative=-1,
            label='Reversed emp.')

    # tidy up the figure
    ax.grid(True)
    ax.legend(loc='right')
    ax.set_title('Cumulative step histograms')
    ax.set_xlabel('Annual rainfall (mm)')
    ax.set_ylabel('Likelihood of occurrence')

    plt.show()
    fig.savefig(outpath + r'\cum_histogram.svg', bbox_inches='tight')
    print('saved cum_histogram.svg')
    fig.savefig(outpath + r'\cum_histogram.pdf', bbox_inches='tight')
    print('saved cum_histogram.pdf')
    fig.savefig(outpath + r'\cum_histogram.png', bbox_inches='tight')
    print('saved cum_histogram.png')



def density_histogram():

    np.random.seed(19680801)

    # example data
    mu = 100  # mean of distribution
    sigma = 15  # standard deviation of distribution
    x = mu + sigma * np.random.randn(437)

    num_bins = 50

    fig, ax = plt.subplots()

    # the histogram of the data
    n, bins, patches = ax.hist(x, num_bins, density=True)

    # add a 'best fit' line
    y = ((1 / (np.sqrt(2 * np.pi) * sigma)) *
         np.exp(-0.5 * (1 / sigma * (bins - mu))**2))
    ax.plot(bins, y, '--')
    ax.set_xlabel('Smarts')
    ax.set_ylabel('Probability density')
    ax.set_title(r'Histogram of IQ: $\mu=100$, $\sigma=15$')

    # Tweak spacing to prevent clipping of ylabel
    fig.tight_layout()

    plt.show()
    fig.savefig(outpath + r'\density_histogram.svg', bbox_inches='tight')
    print('saved density_histogram.svg')
    fig.savefig(outpath + r'\density_histogram.pdf', bbox_inches='tight')
    print('saved density_histogram.pdf')
    fig.savefig(outpath + r'\density_histogram.png', bbox_inches='tight')
    print('saved density_histogram.png')




def bar_of_pie():

    from matplotlib.patches import ConnectionPatch

    # make figure and assign axis objects
    fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(9, 5))
    fig.subplots_adjust(wspace=0)

    # pie chart parameters
    overall_ratios = [.27, .56, .17]
    labels = ['Approve', 'Disapprove', 'Undecided']
    explode = [0.1, 0, 0]
    # rotate so that first wedge is split by the x-axis
    angle = -180 * overall_ratios[0]
    wedges, *_ = ax1.pie(overall_ratios, autopct='%1.1f%%', startangle=angle,
                         labels=labels, explode=explode)

    # bar chart parameters
    age_ratios = [.33, .54, .07, .06]
    age_labels = ['Under 35', '35-49', '50-65', 'Over 65']
    bottom = 1
    width = .2

    # Adding from the top matches the legend.
    for j, (height, label) in enumerate(reversed([*zip(age_ratios, age_labels)])):
        bottom -= height
        bc = ax2.bar(0, height, width, bottom=bottom, color='C0', label=label,
                     alpha=0.1 + 0.25 * j)
        ax2.bar_label(bc, labels=[f"{height:.0%}"], label_type='center')

    ax2.set_title('Age of approvers')
    ax2.legend()
    ax2.axis('off')
    ax2.set_xlim(- 2.5 * width, 2.5 * width)

    # use ConnectionPatch to draw lines between the two plots
    theta1, theta2 = wedges[0].theta1, wedges[0].theta2
    center, r = wedges[0].center, wedges[0].r
    bar_height = sum(age_ratios)

    # draw top connecting line
    x = r * np.cos(np.pi / 180 * theta2) + center[0]
    y = r * np.sin(np.pi / 180 * theta2) + center[1]
    con = ConnectionPatch(xyA=(-width / 2, bar_height), coordsA=ax2.transData,
                          xyB=(x, y), coordsB=ax1.transData)
    con.set_color([0, 0, 0])
    con.set_linewidth(4)
    ax2.add_artist(con)

    # draw bottom connecting line
    x = r * np.cos(np.pi / 180 * theta1) + center[0]
    y = r * np.sin(np.pi / 180 * theta1) + center[1]
    con = ConnectionPatch(xyA=(-width / 2, 0), coordsA=ax2.transData,
                          xyB=(x, y), coordsB=ax1.transData)
    con.set_color([0, 0, 0])
    ax2.add_artist(con)
    con.set_linewidth(4)

    plt.show()
    fig.savefig(outpath + r'\bar_of_pie.svg', bbox_inches='tight')
    print('saved bar_of_pie.svg')
    fig.savefig(outpath + r'\bar_of_pie.pdf', bbox_inches='tight')
    print('saved bar_of_pie.pdf')
    fig.savefig(outpath + r'\bar_of_pie.png', bbox_inches='tight')
    print('saved bar_of_pie.png')




def polar_plot():

    r = np.arange(0, 2, 0.01)
    theta = 2 * np.pi * r

    fig, ax = plt.subplots(subplot_kw={'projection': 'polar'})
    ax.plot(theta, r)
    ax.set_rmax(2)
    ax.set_rticks([0.5, 1, 1.5, 2])  # Less radial ticks
    ax.set_rlabel_position(-22.5)  # Move radial labels away from plotted line
    ax.grid(True)

    ax.set_title("A line plot on a polar axis", va='bottom')

    plt.show()
    fig.savefig(outpath + r'\polar_plot.svg', bbox_inches='tight')
    print('saved polar_plot.svg')
    fig.savefig(outpath + r'\polar_plot.pdf', bbox_inches='tight')
    print('saved polar_plot.pdf')
    fig.savefig(outpath + r'\polar_plot.png', bbox_inches='tight')
    print('saved polar_plot.png')



def math_fonts():

    fig, ax = plt.subplots(figsize=(6, 5))

    # A simple plot for the background.
    ax.plot(range(11), color="0.9")

    # A text mixing normal text and math text.
    msg = (r"Normal Text. $Text\ in\ math\ mode:\ "
           r"\int_{0}^{\infty } x^2 dx$")

    # Set the text in the plot.
    ax.text(1, 7, msg, size=12, math_fontfamily='cm')

    # Set another font for the next text.
    ax.text(1, 3, msg, size=12, math_fontfamily='dejavuserif')

    # *math_fontfamily* can be used in most places where there is text,
    # like in the title:
    ax.set_title(r"$Title\ in\ math\ mode:\ \int_{0}^{\infty } x^2 dx$",
                 math_fontfamily='stixsans', size=14)

    # Note that the normal text is not changed by *math_fontfamily*.

    plt.show()
    fig.savefig(outpath + r'\math_fonts.svg', bbox_inches='tight')
    print('saved math_fonts.svg')
    fig.savefig(outpath + r'\math_fonts.pdf', bbox_inches='tight')
    print('saved math_fonts.pdf')
    fig.savefig(outpath + r'\math_fonts.png', bbox_inches='tight')
    print('saved math_fonts.png')


def color_bar():

    # setup some generic data
    N = 37
    x, y = np.mgrid[:N, :N]
    Z = (np.cos(x*0.2) + np.sin(y*0.3))

    # mask out the negative and positive values, respectively
    Zpos = np.ma.masked_less(Z, 0)
    Zneg = np.ma.masked_greater(Z, 0)

    fig, (ax1, ax2, ax3) = plt.subplots(figsize=(13, 3), ncols=3)

    # plot just the positive data and save the
    # color "mappable" object returned by ax1.imshow
    pos = ax1.imshow(Zpos, cmap='Blues', interpolation='none')

    # add the colorbar using the figure's method,
    # telling which mappable we're talking about and
    # which axes object it should be near
    fig.colorbar(pos, ax=ax1)

    # repeat everything above for the negative data
    # you can specify location, anchor and shrink the colorbar
    neg = ax2.imshow(Zneg, cmap='Reds_r', interpolation='none')
    fig.colorbar(neg, ax=ax2, location='right', anchor=(0, 0.3), shrink=0.7)

    # Plot both positive and negative values between +/- 1.2
    pos_neg_clipped = ax3.imshow(Z, cmap='RdBu', vmin=-1.2, vmax=1.2,
                                 interpolation='none')
    # Add minorticks on the colorbar to make it easy to read the
    # values off the colorbar.
    cbar = fig.colorbar(pos_neg_clipped, ax=ax3, extend='both')
    cbar.minorticks_on()

    plt.show()
    fig.savefig(outpath + r'\color_bar.svg', bbox_inches='tight')
    print('saved color_bar.svg')
    fig.savefig(outpath + r'\color_bar.pdf', bbox_inches='tight')
    print('saved color_bar.pdf')
    fig.savefig(outpath + r'\color_bar.png', bbox_inches='tight')
    print('saved color_bar.png')



def bezier_curve():
    #see https://matplotlib.org/stable/gallery/shapes_and_collections/quad_bezier.html

    import matplotlib.path as mpath
    import matplotlib.patches as mpatches

    Path = mpath.Path

    fig, ax = plt.subplots()
    pp1 = mpatches.PathPatch(
        Path([(0, 0), (1, 0), (1, 1), (0, 0)],
             [Path.MOVETO, Path.CURVE3, Path.CURVE3, Path.CLOSEPOLY]),
        fc="none", transform=ax.transData)

    ax.add_patch(pp1)
    ax.plot([0.75], [0.25], "ro")
    ax.set_title('The red point should be on the path')

    plt.show()
    fig.savefig(outpath + r'\bezier_curve.svg', bbox_inches='tight')
    print('saved bezier_curve.svg')
    fig.savefig(outpath + r'\bezier_curve.pdf', bbox_inches='tight')
    print('saved bezier_curve.pdf')
    fig.savefig(outpath + r'\bezier_curve.png', bbox_inches='tight')
    print('saved bezier_curve.png')



def scatter_plot():
    # see https://matplotlib.org/stable/gallery/shapes_and_collections/scatter.html
    # Fixing random state for reproducibility
    np.random.seed(19680801)

    fig, ax = plt.subplots()
    N = 50
    x = np.random.rand(N)
    y = np.random.rand(N)
    colors = np.random.rand(N)
    area = (30 * np.random.rand(N))**2  # 0 to 15 point radii

    ax.scatter(x, y, s=area, c=colors, alpha=0.5)

    plt.show()
    fig.savefig(outpath + r'\scatter_plot.svg', bbox_inches='tight')
    print('saved scatter_plot.svg')
    fig.savefig(outpath + r'\scatter_plot.pdf', bbox_inches='tight')
    print('saved scatter_plot.pdf')
    fig.savefig(outpath + r'\scatter_plot.png', bbox_inches='tight')
    print('saved scatter_plot.png')



def bayesian_hackers():
    # see https://matplotlib.org/stable/gallery/style_sheets/bmh.html

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    plt.style.use('bmh')

    def plot_beta_hist(ax, a, b):
        ax.hist(np.random.beta(a, b, size=10000),
                histtype="stepfilled", bins=25, alpha=0.8, density=True)

    fig, ax = plt.subplots()
    plot_beta_hist(ax, 10, 10)
    plot_beta_hist(ax, 4, 12)
    plot_beta_hist(ax, 50, 12)
    plot_beta_hist(ax, 6, 55)
    ax.set_title("'bmh' style sheet")

    plt.show()
    fig.savefig(outpath + r'\bayesian_hackers.svg', bbox_inches='tight')
    print('saved bayesian_hackers.svg')
    fig.savefig(outpath + r'\bayesian_hackers.pdf', bbox_inches='tight')
    print('saved bayesian_hackers.pdf')
    fig.savefig(outpath + r'\bayesian_hackers.png', bbox_inches='tight')
    print('saved bayesian_hackers.png')




def ggplot_style_sheet():
    # see https://matplotlib.org/stable/gallery/style_sheets/ggplot.html
    plt.style.use('ggplot')

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    fig, axs = plt.subplots(ncols=2, nrows=2)
    ax1, ax2, ax3, ax4 = axs.flat

    # scatter plot (Note: `plt.scatter` doesn't use default colors)
    x, y = np.random.normal(size=(2, 200))
    ax1.plot(x, y, 'o')

    # sinusoidal lines with colors from default color cycle
    L = 2*np.pi
    x = np.linspace(0, L)
    ncolors = len(plt.rcParams['axes.prop_cycle'])
    shift = np.linspace(0, L, ncolors, endpoint=False)
    for s in shift:
        ax2.plot(x, np.sin(x + s), '-')
    ax2.margins(0)

    # bar graphs
    x = np.arange(5)
    y1, y2 = np.random.randint(1, 25, size=(2, 5))
    width = 0.25
    ax3.bar(x, y1, width)
    ax3.bar(x + width, y2, width,
            color=list(plt.rcParams['axes.prop_cycle'])[2]['color'])
    ax3.set_xticks(x + width, labels=['a', 'b', 'c', 'd', 'e'])

    # circles with colors from default color cycle
    for i, color in enumerate(plt.rcParams['axes.prop_cycle']):
        xy = np.random.normal(size=2)
        ax4.add_patch(plt.Circle(xy, radius=0.3, color=color['color']))
    ax4.axis('equal')
    ax4.margins(0)

    plt.show()
    fig.savefig(outpath + r'\ggplot_style_sheet.svg', bbox_inches='tight')
    print('saved ggplot_style_sheet.svg')
    fig.savefig(outpath + r'\ggplot_style_sheet.pdf', bbox_inches='tight')
    print('saved ggplot_style_sheet.pdf')
    fig.savefig(outpath + r'\ggplot_style_sheet.png', bbox_inches='tight')
    print('saved ggplot_style_sheet.png')




def grayscale_style_sheet():
    # see https://matplotlib.org/stable/gallery/style_sheets/grayscale.html

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    def color_cycle_example(ax):
        L = 6
        x = np.linspace(0, L)
        ncolors = len(plt.rcParams['axes.prop_cycle'])
        shift = np.linspace(0, L, ncolors, endpoint=False)
        for s in shift:
            ax.plot(x, np.sin(x + s), 'o-')

    def image_and_patch_example(ax):
        ax.imshow(np.random.random(size=(20, 20)), interpolation='none')
        c = plt.Circle((5, 5), radius=5, label='patch')
        ax.add_patch(c)

    plt.style.use('grayscale')

    fig, (ax1, ax2) = plt.subplots(ncols=2)
    fig.suptitle("'grayscale' style sheet")

    color_cycle_example(ax1)
    image_and_patch_example(ax2)

    plt.show()
    fig.savefig(outpath + r'\grayscale_style_sheet.svg', bbox_inches='tight')
    print('saved grayscale_style_sheet.svg')
    fig.savefig(outpath + r'\grayscale_style_sheet.pdf', bbox_inches='tight')
    print('saved grayscale_style_sheet.pdf')
    fig.savefig(outpath + r'\grayscale_style_sheet.png', bbox_inches='tight')
    print('saved grayscale_style_sheet.png')


def bachelor_degrees():
    # see https://matplotlib.org/stable/gallery/showcase/bachelors_degrees_by_gender.html

    import numpy as np
    import matplotlib.pyplot as plt
    from matplotlib.cbook import get_sample_data


    fname = get_sample_data('percent_bachelors_degrees_women_usa.csv',
                            asfileobj=False)
    gender_degree_data = np.genfromtxt(fname, delimiter=',', names=True)

    # You typically want your plot to be ~1.33x wider than tall. This plot
    # is a rare exception because of the number of lines being plotted on it.
    # Common sizes: (10, 7.5) and (12, 9)
    fig, ax = plt.subplots(1, 1, figsize=(12, 14))

    # These are the colors that will be used in the plot
    ax.set_prop_cycle(color=[
        '#1f77b4', '#aec7e8', '#ff7f0e', '#ffbb78', '#2ca02c', '#98df8a',
        '#d62728', '#ff9896', '#9467bd', '#c5b0d5', '#8c564b', '#c49c94',
        '#e377c2', '#f7b6d2', '#7f7f7f', '#c7c7c7', '#bcbd22', '#dbdb8d',
        '#17becf', '#9edae5'])

    # Remove the plot frame lines. They are unnecessary here.
    ax.spines[:].set_visible(False)

    # Ensure that the axis ticks only show up on the bottom and left of the plot.
    # Ticks on the right and top of the plot are generally unnecessary.
    ax.xaxis.tick_bottom()
    ax.yaxis.tick_left()

    fig.subplots_adjust(left=.06, right=.75, bottom=.02, top=.94)
    # Limit the range of the plot to only where the data is.
    # Avoid unnecessary whitespace.
    ax.set_xlim(1969.5, 2011.1)
    ax.set_ylim(-0.25, 90)

    # Set a fixed location and format for ticks.
    ax.set_xticks(range(1970, 2011, 10))
    ax.set_yticks(range(0, 91, 10))
    # Use automatic StrMethodFormatter creation
    ax.xaxis.set_major_formatter('{x:.0f}')
    ax.yaxis.set_major_formatter('{x:.0f}%')

    # Provide tick lines across the plot to help your viewers trace along
    # the axis ticks. Make sure that the lines are light and small so they
    # don't obscure the primary data lines.
    ax.grid(True, 'major', 'y', ls='--', lw=.5, c='k', alpha=.3)

    # Remove the tick marks; they are unnecessary with the tick lines we just
    # plotted. Make sure your axis ticks are large enough to be easily read.
    # You don't want your viewers squinting to read your plot.
    ax.tick_params(axis='both', which='both', labelsize=14,
                   bottom=False, top=False, labelbottom=True,
                   left=False, right=False, labelleft=True)

    # Now that the plot is prepared, it's time to actually plot the data!
    # Note that I plotted the majors in order of the highest % in the final year.
    majors = ['Health Professions', 'Public Administration', 'Education',
              'Psychology', 'Foreign Languages', 'English',
              'Communications\nand Journalism', 'Art and Performance', 'Biology',
              'Agriculture', 'Social Sciences and History', 'Business',
              'Math and Statistics', 'Architecture', 'Physical Sciences',
              'Computer Science', 'Engineering']

    y_offsets = {'Foreign Languages': 0.5, 'English': -0.5,
                 'Communications\nand Journalism': 0.75,
                 'Art and Performance': -0.25, 'Agriculture': 1.25,
                 'Social Sciences and History': 0.25, 'Business': -0.75,
                 'Math and Statistics': 0.75, 'Architecture': -0.75,
                 'Computer Science': 0.75, 'Engineering': -0.25}

    for column in majors:
        # Plot each line separately with its own color.
        column_rec_name = column.replace('\n', '_').replace(' ', '_')

        line, = ax.plot('Year', column_rec_name, data=gender_degree_data,
                        lw=2.5)

        # Add a text label to the right end of every line. Most of the code below
        # is adding specific offsets y position because some labels overlapped.
        y_pos = gender_degree_data[column_rec_name][-1] - 0.5

        if column in y_offsets:
            y_pos += y_offsets[column]

        # Again, make sure that all labels are large enough to be easily read
        # by the viewer.
        ax.text(2011.5, y_pos, column, fontsize=14, color=line.get_color())

    # Make the title big enough so it spans the entire plot, but don't make it
    # so big that it requires two lines to show.

    # Note that if the title is descriptive enough, it is unnecessary to include
    # axis labels; they are self-evident, in this plot's case.
    fig.suptitle("Percentage of Bachelor's degrees conferred to women in "
                 "the U.S.A. by major (1970-2011)", fontsize=18, ha="center")

    # Finally, save the figure as a PNG.
    # You can also save it as a PDF, JPEG, etc.
    # Just change the file extension in this call.
    # fig.savefig('percent-bachelors-degrees-women-usa.png', bbox_inches='tight')

    plt.show()
    fig.savefig(outpath + r'\bachelor_degrees.svg', bbox_inches='tight')
    print('saved bachelor_degrees.svg')
    fig.savefig(outpath + r'\bachelor_degrees.pdf', bbox_inches='tight')
    print('saved bachelor_degrees.pdf')
    fig.savefig(outpath + r'\bachelor_degrees.png', bbox_inches='tight')
    print('saved bachelor_degrees.png')



def integral():
    # see https://matplotlib.org/stable/gallery/showcase/integral.html
    from matplotlib.patches import Polygon

    def func(x):
        return (x - 3) * (x - 5) * (x - 7) + 85

    a, b = 2, 9  # integral limits
    x = np.linspace(0, 10)
    y = func(x)

    fig, ax = plt.subplots()
    ax.plot(x, y, 'r', linewidth=2)
    ax.set_ylim(bottom=0)

    # Make the shaded region
    ix = np.linspace(a, b)
    iy = func(ix)
    verts = [(a, 0), *zip(ix, iy), (b, 0)]
    poly = Polygon(verts, facecolor='0.9', edgecolor='0.5')
    ax.add_patch(poly)

    ax.text(0.5 * (a + b), 30, r"$\int_a^b f(x)\mathrm{d}x$",
            horizontalalignment='center', fontsize=20)

    fig.text(0.9, 0.05, '$x$')
    fig.text(0.1, 0.9, '$y$')

    ax.spines.right.set_visible(False)
    ax.spines.top.set_visible(False)
    ax.xaxis.set_ticks_position('bottom')

    ax.set_xticks([a, b], labels=['$a$', '$b$'])
    ax.set_yticks([])

    plt.show()
    fig.savefig(outpath + r'\integral.svg', bbox_inches='tight')
    print('saved integral.svg')
    fig.savefig(outpath + r'\integral.pdf', bbox_inches='tight')
    print('saved integral.pdf')
    fig.savefig(outpath + r'\integral.png', bbox_inches='tight')
    print('saved integral.png')




def mandelbrot():
    # see https://matplotlib.org/stable/gallery/showcase/mandelbrot.html

    import time
    import matplotlib
    from matplotlib import colors
    import matplotlib.pyplot as plt

    def mandelbrot_set(xmin, xmax, ymin, ymax, xn, yn, maxiter, horizon=2.0):
        X = np.linspace(xmin, xmax, xn).astype(np.float32)
        Y = np.linspace(ymin, ymax, yn).astype(np.float32)
        C = X + Y[:, None] * 1j
        N = np.zeros_like(C, dtype=int)
        Z = np.zeros_like(C)
        for n in range(maxiter):
            I = abs(Z) < horizon
            N[I] = n
            Z[I] = Z[I]**2 + C[I]
        N[N == maxiter-1] = 0
        return Z, N


    xmin, xmax, xn = -2.25, +0.75, 3000 // 2
    ymin, ymax, yn = -1.25, +1.25, 2500 // 2
    maxiter = 200
    horizon = 2.0 ** 40
    log_horizon = np.log2(np.log(horizon))
    Z, N = mandelbrot_set(xmin, xmax, ymin, ymax, xn, yn, maxiter, horizon)

    # Normalized recount as explained in:
    # https://linas.org/art-gallery/escape/smooth.html
    # https://web.archive.org/web/20160331171238/https://www.ibm.com/developerworks/community/blogs/jfp/entry/My_Christmas_Gift?lang=en

    # This line will generate warnings for null values but it is faster to
    # process them afterwards using the nan_to_num
    with np.errstate(invalid='ignore'):
        M = np.nan_to_num(N + 1 - np.log2(np.log(abs(Z))) + log_horizon)

    dpi = 72
    width = 10
    height = 10*yn/xn
    fig = plt.figure(figsize=(width, height), dpi=dpi)
    ax = fig.add_axes([0, 0, 1, 1], frameon=False, aspect=1)

    # Shaded rendering
    light = colors.LightSource(azdeg=315, altdeg=10)
    M = light.shade(M, cmap=plt.cm.hot, vert_exag=1.5,
                    norm=colors.PowerNorm(0.3), blend_mode='hsv')
    ax.imshow(M, extent=[xmin, xmax, ymin, ymax], interpolation="bicubic")
    ax.set_xticks([])
    ax.set_yticks([])

    # Some advertisement for matplotlib
    year = time.strftime("%Y")
    text = ("The Mandelbrot fractal set\n"
            "Rendered with matplotlib %s, %s - https://matplotlib.org"
            % (matplotlib.__version__, year))
    ax.text(xmin+.025, ymin+.025, text, color="white", fontsize=12, alpha=0.5)

    plt.show()
    fig.savefig(outpath + r'\mandelbrot.svg', bbox_inches='tight')
    print('saved mandelbrot.svg')
    fig.savefig(outpath + r'\mandelbrot.pdf', bbox_inches='tight')
    print('saved mandelbrot.pdf')
    fig.savefig(outpath + r'\mandelbrot.png', bbox_inches='tight')
    print('saved mandelbrot.png')




def anscombe():
    # see https://matplotlib.org/stable/gallery/specialty_plots/anscombe.html

    x = [10, 8, 13, 9, 11, 14, 6, 4, 12, 7, 5]
    y1 = [8.04, 6.95, 7.58, 8.81, 8.33, 9.96, 7.24, 4.26, 10.84, 4.82, 5.68]
    y2 = [9.14, 8.14, 8.74, 8.77, 9.26, 8.10, 6.13, 3.10, 9.13, 7.26, 4.74]
    y3 = [7.46, 6.77, 12.74, 7.11, 7.81, 8.84, 6.08, 5.39, 8.15, 6.42, 5.73]
    x4 = [8, 8, 8, 8, 8, 8, 8, 19, 8, 8, 8]
    y4 = [6.58, 5.76, 7.71, 8.84, 8.47, 7.04, 5.25, 12.50, 5.56, 7.91, 6.89]

    datasets = {
        'I': (x, y1),
        'II': (x, y2),
        'III': (x, y3),
        'IV': (x4, y4)
    }

    fig, axs = plt.subplots(2, 2, sharex=True, sharey=True, figsize=(6, 6),
                            gridspec_kw={'wspace': 0.08, 'hspace': 0.08})
    axs[0, 0].set(xlim=(0, 20), ylim=(2, 14))
    axs[0, 0].set(xticks=(0, 10, 20), yticks=(4, 8, 12))

    for ax, (label, (x, y)) in zip(axs.flat, datasets.items()):
        ax.text(0.1, 0.9, label, fontsize=20, transform=ax.transAxes, va='top')
        ax.tick_params(direction='in', top=True, right=True)
        ax.plot(x, y, 'o')

        # linear regression
        p1, p0 = np.polyfit(x, y, deg=1)  # slope, intercept
        ax.axline(xy1=(0, p0), slope=p1, color='r', lw=2)

        # add text box for the statistics
        stats = (f'$\\mu$ = {np.mean(y):.2f}\n'
                 f'$\\sigma$ = {np.std(y):.2f}\n'
                 f'$r$ = {np.corrcoef(x, y)[0][1]:.2f}')
        bbox = dict(boxstyle='round', fc='blanchedalmond', ec='orange', alpha=0.5)
        ax.text(0.95, 0.07, stats, fontsize=9, bbox=bbox,
                transform=ax.transAxes, horizontalalignment='right')

    plt.show()
    fig.savefig(outpath + r'\anscombe.svg', bbox_inches='tight')
    print('saved anscombe.svg')
    fig.savefig(outpath + r'\anscombe.pdf', bbox_inches='tight')
    print('saved anscombe.pdf')
    fig.savefig(outpath + r'\anscombe.png', bbox_inches='tight')
    print('saved anscombe.png')




try:
    print()

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

    #singleplot()
    #stacked_2_plot()
    stacked_4_plot()

    #surface_colormap()
    #surface_hillshading()
    #surface_polar()
    #surface_checkerboard()
    #surface_solid()
    #stem_3d()
    #polygon_3d()
    #surface_triangular()
    #surface_moebius()
    #voxel_3d()
    #voxel_3d_numpy()
    #voxel_3d_rgb()
    #voxel_3d_cylindric()
    #wireframe_3d_1direction()
    #wireframe_3d()

    #bar_chart_gradients()
    #koch_snowflake_demo()
    #confidence_bands()
    #survey_chart()
    #masked_plot()
    #fill_between_alpha()
    #walker_1sigma()
    #multicolored_lines()
    #scatterplot_histogram()
    #simple_plot()
    #spectrum_representations()
    #boxplots()
    #demo_correlation()
    #demo_corr_diff_std()
    #demo_corr_kwargs()

    #cum_histogram()
    #density_histogram()
    #bar_of_pie()
    #polar_plot()
    #math_fonts()
    #color_bar()
    #bezier_curve()
    #scatter_plot()
    #bayesian_hackers()
    #ggplot_style_sheet()
    #bachelor_degrees()
    #integral()
    #mandelbrot()
    #anscombe()

except Exception:
    import traceback
    print(traceback.format_exc())
