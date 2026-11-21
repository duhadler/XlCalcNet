from xlcalcnet import gui
import os, re
from numba import jit
import numpy as np
from matplotlib import colors, pyplot as plt


@jit(nopython=True)
def julia(z, maxiter,c0):
    c = z
    i = maxiter
    while ((abs(z) < 2) and (i > 1)):
        z = (z * z + c0) / (z * z - c0)
        i -= 1;
    return i


@jit(nopython=True)
def julia_set(xmin,xmax,ymin,ymax,width,height,maxiter):
    r1 = np.linspace(xmin, xmax, width)
    r2 = np.linspace(ymin, ymax, height)
    n3 = np.empty((width,height))
    cX = -0.7;
    cY = 0.27015;
    c0 = complex(cX, cY)
    for i in range(width):
        for j in range(height):
            n3[i,j] = julia(r1[i] + 1j*r2[j], maxiter, c0)
    return n3



def Julia10(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    xmin=-2.2
    xmax=2.2
    ymin=-2.2
    ymax=2.2
    width=6
    height=6
    maxiter=255
    dpi = 96
    pnorm = 10.0
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
        Julia10()

except Exception:
    import traceback
    print(traceback.format_exc())


