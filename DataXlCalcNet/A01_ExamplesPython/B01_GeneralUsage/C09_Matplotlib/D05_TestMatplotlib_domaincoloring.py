
import math
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.colors import hsv_to_rgb
# https://stackoverflow.com/questions/3018313/algorithm-to-convert-rgb-to-hsv-and-hsv-to-rgb-in-range-0-255-for-both


FPath = r"C:\Users\dietrichhadler\Documents\Bitmaps"


# https://notebook.community/empet/Math/DomainColoring




def Hcomplex(z):# computes the hue corresponding to the complex number z
    H = np.angle(z) / (2*np.pi) + 1
    return np.mod(H, 1)


def perfract(x, t, m, M):
    x = x / t
    return m + (M-m) * (x-np.floor(x))


def func_vals(f, re, im,  N): #evaluates the complex function at the nodes of the grid
    # re and im are  tuples, re=(a, b) and im=(c, d), defining the rectangular region
    # N is the number of discrete points per unit interval

    l = re[1]-re[0]
    h = im[1]-im[0]
    resL = N * l # horizontal resolution
    resH = N * h # vertical resolution
    x = np.linspace(re[0], re[1], int(resL))
    y = np.linspace(im[0], im[1], int(resH))
    x, y = np.meshgrid(x,y)
    z = x + 1j*y
    return f(z)





def plot_domain(color_func, f,   re=[-1,1], im= [-1,1], title='',
                s=0.9, N=200, daxis=None):
    w = func_vals(f, re, im, N)
    domc = color_func(w, s)
    plt.xlabel("$\Re(z)$")
    plt.ylabel("$\Im(z)$")
    plt.title(title)
    if(daxis):
         plt.imshow(domc, origin="lower", extent=[re[0], re[1], im[0], im[1]])

    else:
        plt.imshow(domc, origin="lower")
        plt.axis('off')




def domaincol_c(w, s):#Classical domain coloring
    # w is the  array of values f(z)
    # s is the constant saturation
    H = Hcomplex(w)
    S = s * np.ones(H.shape)
    modul = np.absolute(w)
    V = (1.0-1.0/(1+modul**2))**0.2
    # the points mapped to infinity are colored with white; hsv_to_rgb(0, 0, 1)=(1, 1, 1)=white
    HSV = np.dstack((H, S, V))
    RGB = hsv_to_rgb(HSV)
    return RGB



def domaincol_p(w,s): #domain coloring with contours of the phase
    H = Hcomplex(w)
    m = 0.7 # brightness is restricted to [0.7,1]; interval suggested by E Wegert
    M = 1
    n = 15 # n=number of isochromatic lines per cycle
    isol = perfract(H, 1.0/n, m, M) # isochromatic lines
    V = isol
    S = 0.9 * np.ones(H.shape)
    HSV = np.dstack((H, S, V))
    RGB = hsv_to_rgb(HSV)
    return RGB



def domaincol_m(w,  s): #domain coloring with contours of the modulus
    # w the array of values
    #s is the constant Saturation
    H = Hcomplex(w)
    modulus = np.absolute(w)
    c = np.log(2)
    logm = np.log(modulus)/c#log base 2
    logm = np.nan_to_num(logm)
    V = logm - np.floor(logm)
    S = s*np.ones(H.shape)
    HSV = np.dstack((H, S, V**0.2)) # V**0.2>V for V in[0,1];this choice  avoids too dark colors
    RGB = hsv_to_rgb(HSV)
    return RGB


def domaincol_pm(w,s): #domain coloring with contours of modulus & phase
    H = Hcomplex(w)
    m = 0.7 # brightness is restricted to [0.7,1]; interval suggested by E Wegert
    M = 1
    n = 15 # n=number of isochromatic lines per cycle
    isol = perfract(H, 1.0/n, m, M) # isochromatic lines
    modul = np.absolute(w)
    logm = np.log(modul)
    logm = np.nan_to_num(logm)
    modc = perfract(logm, 2*np.pi/n, m, M) # lines of constant log-modulus
    V = modc * isol
    S = 0.9 * np.ones(H.shape)
    HSV = np.dstack((H, S, V))
    RGB = hsv_to_rgb(HSV)
    return RGB





def demo1a():
    plt.rcParams['figure.figsize'] = 5, 5

##    ab = (-2,2)
##    cd = (-2,2)

    ab = (-3,3)
    cd = (-3,3)

    ab = (-1.5,1.5)
    cd = (-1.5,1.5)

##    ab = (-0.6,0.6)
##    cd = (-0.6,0.6)
##
##    ab = (-0.2,0.2)
##    cd = (-0.2,0.2)
##
##    ab = (-0.1,0.1)
##    cd = (-0.1,0.1)

    fig, ax = plt.subplots(figsize=(5, 5))
##    ax.set_axis_off()

    plt.subplot(1,1,1)
##    f = lambda z: (z**3-1)/z
##    f = lambda z: (z**6-1)/(z**12+1)
##    f = lambda z: np.exp(1/z)
##    f = lambda z: z*np.sin(1/z)
##    f = lambda z: np.sin(z) / (z-1j)**2
    f = lambda z: np.exp(1/(z*z))



##    plot_domain(domaincol_c, f, re=ab, im=cd, title='$f(z)=(z^3-1)/z$',  daxis=True)
##    plot_domain(domaincol_p, f, re=ab, im=cd, title='$f(z)=(z^3-1)/z$',  daxis=True)
##    plot_domain(domaincol_m, f, re=ab, im=cd, title='$f(z)=(z^3-1)/z$',  daxis=True)
##    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=(z^3-1)/z$',  daxis=True)

##    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=(z**6-1)/(z**12+1)$',  daxis=True)
##    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=exp(1/z)$',  daxis=True)
##    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=z*sin(1/z)$',  daxis=True, N=400)
##    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=sin(z)/(z-1j)**2$',  daxis=True, N=200)
    plot_domain(domaincol_pm, f, re=ab, im=cd, title='$f(z)=exp(1/z^2)$',  daxis=True, N=300)


    plt.tight_layout()

##    fig.savefig(FPath + r'\domaincoloring_c.jpg', bbox_inches='tight')

##    fig.savefig(FPath + r'\dc_poly6_12.jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\dc_exp(1overz).jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\dc_z_sin(1overz).jpg', bbox_inches='tight')
##    fig.savefig(FPath + r'\dc_z_sin(z)over(z-i)^2.jpg', bbox_inches='tight')
    fig.savefig(FPath + r'\dc_exp(1overz2).jpg', bbox_inches='tight')


    plt.show()



def demo1():
    plt.rcParams['figure.figsize'] = 8, 5
    ab = (-2,2)
    cd = (-2,2)
    plt.subplot(1,2,1)
    plot_domain(domaincol_m, lambda z:z,   re=ab, im=cd, title='$f(z)=z$',  daxis=True)
    plt.subplot(1,2,2)
    f = lambda z: (z**3-1)/z
    plot_domain(domaincol_m, f,   re=ab, im=cd, title='$f(z)=(z^3-1)/z$',  daxis=True)
    plt.tight_layout()
    plt.show()



def demo2():
    plt.rcParams['figure.figsize'] = 10, 6
    plt.subplot(1, 2, 1)
    ab = (-2, 2)
    cd = (-2, 2)
    f = lambda z: z**5 + z
    plot_domain(domaincol_m, f, re=ab, im=cd, title='$f(z)=(z^5+z)$', daxis=True)
    plt.subplot(1, 2, 2)
    ab = (-2.5, 2)
    cd = (-2.5, 2)
    g = lambda z: (z - 0.5 - 0.5*1j) / z**2
    plot_domain(domaincol_m, g,   re=ab, im=cd, title='$g(z)=(z-0.5(1+i))/z^2$', daxis=True)
    plt.tight_layout()
    plt.show()




def demo3():
    plt.rcParams['figure.figsize'] = 12, 6
    ab = (-np.pi, np.pi)
    cd = (-2, 2)
    plt.subplot(1, 2, 1)
    plot_domain(domaincol_m, np.sin,   re=ab, im=cd, title='$f(z)=\sin z$', daxis=True)
    plt.subplot(1, 2, 2)
    plot_domain(domaincol_m, np.tan,   re=ab, im=cd, title='$g(z)=tan(z)$', daxis=True)
    plt.tight_layout()
    plt.show()




def demo4():
    plt.rcParams['figure.figsize'] = 10, 6
    fig, ax = plt.subplots(figsize=(10, 6))

    plt.subplot(1, 2, 1)
    ab = (-2, 2)
    cd = (-1.5, 1.5)
    f = lambda z: np.exp(1/z)
    ax.set_axis_off()
    plot_domain(domaincol_m,  f,   re=ab, im=cd, title='$f(z)=\exp(1/z)$', N=350, daxis=True)
    plt.subplot(1, 2, 2)
    ab = (-0.6, 0.6)
    cd = (-0.6 ,0.6)
    g = lambda z: z*np.sin(1.0/z)
    plot_domain(domaincol_m,  g,   re=ab, im=cd, title='$g(z)=z\sin(1/z)$', N=350, daxis=True)
    plt.tight_layout()

    fig.savefig(FPath + r'\domaincoloring4.jpg', bbox_inches='tight')
##    plt.show()




def demo5():
    plt.rcParams['figure.figsize'] = 12, 6
    fig, ax = plt.subplots(figsize=(12, 6))

    plt.subplot(1, 2, 1)
    ab = (-2, 2)
    cd = (-2, 2)
    f = lambda z: (z**6 - 1) / (z**12 + 1)

    #fig, ax = plt.subplots(figsize=(12, 6))
    ax.set_axis_off()
    plot_domain(domaincol_m,  f,   re=ab, im=cd, title='$f(z)=(z^6-1)/(z^{12}+1)$', N=300, daxis=True)
    plt.subplot(1, 2, 2) # plot the same function on smaller square
    ab = (-1.3, 1.3)
    cd = (-1.3, 1.3)
    plot_domain(domaincol_m,  f,   re=ab, im=cd, title='$f(z)=(z^6-1)/(z^{12}+1)$', N=300, daxis=True)
    plt.tight_layout()

    fig.savefig(FPath + r'\domaincoloring5.jpg', bbox_inches='tight')
    #fig.savefig(FPath + r'\domaincoloring5.png', bbox_inches='tight')
    #plt.show()





def demo6():
    plt.rcParams['figure.figsize'] = 8, 5
    ab = (-np.pi, np.pi)
    cd = (-2, 2)
    f = lambda z: 1.0 / np.tan(z)
    plot_domain(domaincol_co,  f,   re=ab, im=cd, title='$f(z)=ctan(z)$', N=300, daxis=True)
    plt.show()






def demo7():
    plt.rcParams['figure.figsize'] = 10, 8
    fig, ax = plt.subplots(figsize=(18, 6))
    plt.subplot(1, 2, 1)
    ab = (-3, 3)
    cd = (-4, 4)
    plot_domain(domaincol_co,  np.exp,    re=ab, im=cd, title='$f(z)=\exp$', daxis=True)
    plt.subplot(1, 2, 2)
    ab = (-1, 1)
    cd = (-1, 1)
    g = lambda z:z
    plot_domain(domaincol_co,  g,   re=ab, im=cd, title='$g(z)=z$',  daxis=True)
    plt.tight_layout()
    fig.savefig(FPath + r'\domaincoloring7.jpg', bbox_inches='tight')
    #plt.show()



def demo8():
    plt.rcParams['figure.figsize'] = 18, 6
    ab = (-1, 3)
    cd = (-2, 2)
    f = lambda z: np.sin(z) / (z-1j)**2

    fig, ax = plt.subplots(figsize=(18, 6))
    ax.set_axis_off()
    plt.subplot(1, 3, 1)
    plot_domain(domaincol_c,  f,   re=ab, im=cd, title='$f(z)=\sin z/(z-i)^2$', daxis=True)
    plt.subplot(1, 3, 2)
    plot_domain(domaincol_m,  f,   re=ab, im=cd, title='$f(z)=\sin z/(z-i)^2$', daxis=True)
    plt.subplot(1, 3, 3)
    plot_domain(domaincol_co,  f,   re=ab, im=cd, title='$f(z)=\sin z/(z-i)^2$', daxis=True)
    plt.tight_layout()

    fig.savefig(FPath + r'\domaincoloring8.jpg', bbox_inches='tight')
    #fig.savefig(FPath + r'\domaincoloring8.png', bbox_inches='tight')
    #plt.show()



def demo9():
    import warnings
    plt.rcParams['figure.figsize'] = 18, 6
    warnings.filterwarnings("ignore", category=RuntimeWarning) # ignore RuntimeWarning: overflow encountered in exp
    ab = (-1.5, 1.5)
    cd = (-1.5, 1.5)
    f=lambda z: np.exp(1.0/z**2)

    fig, ax = plt.subplots(figsize=(18, 6))
    ax.set_axis_off()
    plt.subplot(1, 3, 1)
    plot_domain(domaincol_c,  f,   re=ab, im=cd, title='$f(z)=\exp(1/z^2)$', N=350, daxis=True)
    plt.subplot(1, 3, 2)
    plot_domain(domaincol_m,  f,   re=ab, im=cd, title='$f(z)=\exp(1/z^2)$', N=350, daxis=True)
    plt.subplot(1, 3, 3)
    plot_domain(domaincol_co,  f,   re=ab, im=cd, title='$f(z)=\exp(1/z^2)$',N=350, daxis=True)
    plt.tight_layout()

    fig.savefig(FPath + r'\domaincoloring9.jpg', bbox_inches='tight')
    #fig.savefig(FPath + r'\domaincoloring9.png', bbox_inches='tight')
    #plt.show()



demo1a()

#demo1()
#demo2()
#demo3()
#demo4()
#demo5()      # !!
#demo6()
#demo7()
#demo8()      # !!
#demo9()      # !!



