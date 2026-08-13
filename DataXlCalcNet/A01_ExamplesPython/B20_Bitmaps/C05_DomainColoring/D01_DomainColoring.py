from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.colors import hsv_to_rgb

# https://stackoverflow.com/questions/3018313/algorithm-to-convert-rgb-to-hsv-and-hsv-to-rgb-in-range-0-255-for-both
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

    L = re[1]-re[0]
    H = im[1]-im[0]
    resL = N * L # horizontal resolution
    resH = N * H # vertical resolution
    x = np.linspace(re[0], re[1], int(resL))
    y = np.linspace(im[0], im[1], int(resH))
    x, y = np.meshgrid(x,y)
    z = x + 1j*y
    return f(z)


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


def plot_domain(color_func, f,   re=[-1,1], im= [-1,1], title='',
                s=0.9, N=200, daxis=None):
    import warnings
    with warnings.catch_warnings():
        warnings.simplefilter("ignore")    
        w = func_vals(f, re, im, N)
        domc = color_func(w, s)
        plt.xlabel(r"$\Re(z)$")
        plt.ylabel(r"$\Im(z)$")
        plt.title(title)
        if(daxis):
             plt.imshow(domc, origin="lower", extent=[re[0], re[1], im[0], im[1]])
        else:
            plt.imshow(domc, origin="lower")
            plt.axis('off')






def DomainColoring(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'DomainColoring'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 350
# End of standard key word arguments
    f = kwargs['func'] if 'func' in kwargs else np.atan
    style = kwargs['style'] if 'style' in kwargs else 'pm'  # c, p, m, pm
    re = kwargs['re'] if 're' in kwargs else [-1.0, 1.0]
    im = kwargs['im'] if 'im' in kwargs else [-1.0, 1.0]
    daxis = kwargs['daxis'] if 'daxis' in kwargs else True
# End of custom key word arguments

    if style == 'c':
        color_func = domaincol_c
        Title += ', without contours'
    if style == 'p':
        color_func = domaincol_p
        Title += ', contours of phase'
    if style == 'm':
        color_func = domaincol_m
        Title += ', contours of modulus'
    if style == 'pm':
        color_func = domaincol_pm
        Title += ', contours of phase and modulus'

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    plot_domain(color_func, f, re, im, title=Title, N=Resolution, daxis=daxis)
    plt.tight_layout()

# Start of output choices
    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        plt.savefig(FullPath + '.' + OutputMode,  bbox_inches='tight')
    plt.close('all')


try:
    if __name__ == '__main__':
        #DomainColoring(func=lambda z:np.exp(1.0 / z**2), style='pm', re=[-1.5, 1.5], im=[-1.5, 1.5], Title=r'$f(z)=\exp(1/z^2)$', daxis=True)

        #DomainColoring(func=lambda z:np.sin(z) / (z-1j)**2, style='pm', re=[-3, 3], im=[-3, 3], Title=r'$f(z)=\dfrac{\sin(z)}{(z-i)^2}$', daxis=True)

        #DomainColoring(func=lambda z:z*np.sin(1/z), style='pm', re=[-0.75, 0.75], im=[-0.75, 0.75], Title=r'$f(z)=z \cdot \sin(1/z)$', daxis=True)

        #DomainColoring(func=lambda z:np.exp(1/z), style='pm', re=[-0.75, 0.75], im=[-0.75, 0.75], Title=r'$f(z)=\exp(1/z)$', daxis=True)

        #DomainColoring(func=lambda z:z*np.exp(1/z), style='pm', re=[-0.75, 0.75], im=[-0.75, 0.75], Title=r'$f(z)=z \cdot \exp(1/z)$', daxis=True)

        #DomainColoring(func=lambda z:(z**6-1) / (z**12+1), style='pm', re=[-1.5, 1.5], im=[-1.5, 1.5], Title=r'$f(z)=\dfrac{z^6-1}{z^{12}+1}$', daxis=True)

        #DomainColoring(func=lambda z:(z**3-1)/z, style='pm', re=[-1.5, 1.5], im=[-1.5, 1.5], Title=r'$f(z)=\dfrac{z^3-1}{z}$', daxis=True)

        #DomainColoring(func=lambda z:z**5 + z, style='pm', re=[-2, 2], im=[-2, 2], Title=r'$f(z)=(z^5+z)$', daxis=True)

        #DomainColoring(func=lambda z:(z - 0.5 - 0.5*1j) / z**2, style='pm', re=[-1.5, 1.5], im=[-1.5, 1.5], Title=r'$f(z)=\dfrac{z-0.5(1+i)}{z^2}$', daxis=True)

        #DomainColoring(func=lambda z:np.sin(z), style='pm', re=[-np.pi, np.pi], im=[-2, 2], Title=r'$f(z)=\sin(z)$', daxis=True)

        DomainColoring(func=lambda z:np.tan(z), style='pm', re=[-np.pi, np.pi], im=[-2, 2], Title=r'$f(z)=\tan(z)$', daxis=True)




except Exception:
    import traceback
    print(traceback.format_exc())



