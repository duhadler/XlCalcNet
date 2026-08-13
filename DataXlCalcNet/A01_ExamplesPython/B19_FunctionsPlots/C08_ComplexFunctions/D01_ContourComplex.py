from xlcalcnet import gui
import os, re
import numpy as np; 
def f(z): return np.exp(z);
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')

import cmath


# See also: https://medium.com/@mephisto_Dev/how-to-plot-simple-complex-function-with-python-6dc7f5eb8019
# See also: https://matplotlib.org/stable/gallery/images_contours_and_fields/contour_demo.html



#def f(z):
    #w = z**1; wclip = 20.0
    #w = z**2; wclip = 20.0
    #w = z**3; wclip = 20.0

    #w = (z**2-1)*(z-2-1j)**2/(z**2+2+2j) ; wclip = 20.0

    #w = 1 / z**1; wclip = 2.0
    #w = 1 / z**2; wclip = 2.0
    #w = 1 / z**3; wclip = 2.0

    #w = z**6 + 1; wclip = 20.0
    #w = z**6 - 1; wclip = 20.0
    #w = z**(-6) + 1; wclip = 2.0

    #w = z**z; wclip = 20.0
    #w = (1/z)**z; wclip = 2.0
    #w = z**(1/z); wclip = 2.0

    #w = np.sqrt(z); wclip = 20.0
    #w = z**(1.0/3.0); wclip = 20.0
    #w = z**(1.0/4.0); wclip = 20.0

    #w = np.log(z); wclip = 2.5
    #w = np.exp(z); wclip = 20.0
    #w = np.exp2(z); wclip = 20.0

    #w = np.exp(1/z); wclip = 2.0
    #w = z * np.sin(1/z); wclip = 1.0
    #w = np.cos(1/z); wclip = 2.0

    #w = np.exp(-z**2); wclip = 2.0
    #w = 1 / (1 + z ** 2); wclip = 2.0

    #w = np.sin(z); wclip = 20.0
    #w = np.cos(z); wclip = 20.0
    #w = np.tan(z); wclip = 2.0

    #w = np.sinh(z); wclip = 20.0
    #w = np.cosh(z); wclip = 20.0
    #w = np.tanh(z); wclip = 2.0

    #w = np.asin(z); wclip = 20.0
    #w = np.acos(z); wclip = 20.0
    #w = np.atan(z); wclip = 20.0

    #w = np.asinh(z); wclip = 20.0
    #w = np.acosh(z); wclip = 20.0
    #w = np.atanh(z); wclip = 20.0

    #w = np.sin(z) / z; wclip = 20.0
    #w = np.cos(z) / z; wclip = 2.0
    #w = np.tan(z) / z; wclip = 2.0

###        wreal = np.clip(w.real, -0, wclip)
###        wimag = np.clip(w.imag, -0, wclip)
#    wreal = np.clip(w.real, -wclip, wclip)
#    wimag = np.clip(w.imag, -wclip, wclip)
#    w.real = wreal
#    w.imag = wimag
#    return w

    

def Contour2dComplex(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'f(z) = atan(z)'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    func = kwargs['func'] if 'func' in kwargs else np.atan
    wclip = float(kwargs['wclip']) if 'wclip' in kwargs else 20.0
    showlevels = kwargs['showlevels'] if 'showlevels' in kwargs else False
# End of custom key word arguments


    x = np.linspace(-2, 2, 1000)
    y = np.linspace(-2, 2, 1000)
#    x = np.linspace(-3, 3, 1000)
#    y = np.linspace(-3, 3, 1000)
    X, Y = np.meshgrid(x, y)
    Z = X + 1j*Y
    

    w = func(Z)
#    wreal = np.clip(w.real, -0, wclip)
#    wimag = np.clip(w.imag, -0, wclip)

    wreal = np.clip(w.real, -wclip, wclip)
    wimag = np.clip(w.imag, -wclip, wclip)
    w.real = wreal
    w.imag = wimag

    W = w

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    CSre = ax.contour(X, Y, np.real(W), levels=20, colors='b');
    CSim = ax.contour(X, Y, np.imag(W), levels=20, colors='r');

    if showlevels:
        ax.clabel(CSre, CSre.levels, fontsize=10)
        ax.clabel(CSim, CSim.levels, fontsize=10)

    ax.set_xlabel(r'$\Re(z)$')
    ax.set_ylabel(r'$\Im(z)$')
    ax.set_title(Title)

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
#        Contour2dComplex(func=np.sin, wclip=20.0, Title='f(z)=sin(z)')
        Contour2dComplex(func=lambda z:z*z, wclip=20.0, showlevels=True, Title=r'$f(z)=z^2$')

except Exception:
    import traceback
    print(traceback.format_exc())


