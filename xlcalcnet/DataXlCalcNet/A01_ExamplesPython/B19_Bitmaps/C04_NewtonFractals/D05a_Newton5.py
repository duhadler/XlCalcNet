from xlcalcnet import gui
import os, re
#from numba import jit
import numpy as np
from matplotlib import colors, pyplot as plt


#Classical Halley
#@jit(nopython=True)
def newton(z,maxiter):
    iteration = 0
    zlast = complex(0.0, 0.0)
    while True:
        if (iteration != 0): zlast = z
        f = (z * z * z - 1)
        df = (3 * z * z)
        d2f = 6 * z
        z = z - (2 * f * df) / (2 * df * df - f * d2f)
        iteration = iteration + 1
        if not((abs(z - zlast) > 0.00001) and (iteration < maxiter)):
            break
    if (iteration < maxiter): return 1 * iteration
    else: return maxiter+2


#@jit(nopython=True)
def newton_set(xmin,xmax,ymin,ymax,width,height,maxiter):
    r1 = np.linspace(xmin, xmax, width)
    r2 = np.linspace(ymin, ymax, height)
    n3 = np.empty((width,height))
    for i in range(width):
        for j in range(height):
            n3[i,j] = newton(r1[i] + 1j*r2[j],maxiter)
    return n3



def Newton5(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    xmin=-1.0
    xmax=1.0
    ymin=-1.0
    ymax=1.0
    width=6
    height=6
    maxiter=63
    dpi = 96
    pnorm = 1.0
    #cmap='gist_ncar'
    cmap='gist_ncar_r'
# End of custom key word arguments

    z = newton_set(xmin, xmax, ymin, ymax, dpi * width, dpi * height, maxiter)
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
        Newton5()

except Exception:
    import traceback
    print(traceback.format_exc())


