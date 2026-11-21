from xlcalcnet import gui
import os, re
#from numba import jit
import numpy as np
from matplotlib import colors, pyplot as plt


#@jit(nopython=True)
def julia(z, maxiter,c0):
    i = maxiter
    while ((abs(z) < 2) and (i > 1)):
        z = np.power(z, 1.5) + c0;
        i -= 1;
    return i


#@jit(nopython=True)
def julia_set(xmin,xmax,ymin,ymax,width,height,maxiter):
    r1 = np.linspace(xmin, xmax, width)
    r2 = np.linspace(ymin, ymax, height)
    n3 = np.empty((width,height))
    cX = -0.2;
    cY = 0.0;
    c0 = complex(cX, cY)
    for i in range(width):
        for j in range(height):
            n3[i,j] = julia(r1[i] + 1j*r2[j], maxiter, c0)
    return n3


def julia_image(xmin,xmax,ymin,ymax,width=6,height=6,maxiter=80,cmap='hot'):
    dpi = 96
    z = julia_set(xmin, xmax, ymin, ymax, dpi * width,dpi * height, maxiter)
    fig, ax = plt.subplots(figsize=(width, height), dpi=dpi)    
    norm = colors.PowerNorm(1.0)
    ax.imshow(z.T, cmap=cmap, norm=norm, origin='lower', extent=[xmin, xmax, ymin, ymax])

    #plt.show()
    gui.plot(fig, __file__, 'Julia02')
    plt.close("all")



def Julia02(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    xmin=-1.0
    xmax=1.5
    ymin=-1.25
    ymax=1.25
    width=6
    height=6
    maxiter=255
    dpi = 96
    pnorm = 1.0
    cmap='gist_ncar'
# End of custom key word arguments

    z = julia_set(xmin, xmax, ymin, ymax, dpi * width, dpi * height, maxiter)
    fig, ax = plt.subplots(figsize=(width, height), dpi=dpi)    
    norm = colors.PowerNorm(pnorm)
    ax.imshow(z.T, cmap=cmap, norm=norm, origin='lower', extent=[xmin, xmax, ymin, ymax])

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
        Julia02()


except Exception:
    import traceback
    print(traceback.format_exc())


