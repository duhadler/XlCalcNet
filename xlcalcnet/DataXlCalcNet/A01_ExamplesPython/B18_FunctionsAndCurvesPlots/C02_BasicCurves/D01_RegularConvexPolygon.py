from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')

# See also: https://mathcurve.com/polyedres/regulier/polygoneregulier.shtml
# See also: https://en.wikipedia.org/wiki/Regular_polygon
# See also: https://en.wikipedia.org/wiki/List_of_regular_polytopes#Convex


def RegularPolygonPolarEQ(theta, a, n):
    alpha = (2.0 * np.pi / (n))
    r = a / (np.cos(theta - 0.5 * alpha - alpha * np.floor(theta / alpha)))
    return r



def RegularConvexPolygon(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RegularConvexPolygon'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    UsePolar = True
    a = 1.0
    n = 7
# End of custom key word arguments

    plt.style.use(PlotStyle)
    theta = np.linspace(0, 2.0 * np.pi, n+1)
    r = RegularPolygonPolarEQ(theta, a, n)
    if UsePolar:
        fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY), 
                        subplot_kw={'projection': 'polar'})
        ax.plot(theta, r)
        ax.grid(True,color='lightgrey')
    else:
        y = r * np.sin(theta);
        x = r * np.cos(theta);
        fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
        ax.plot(x, y)
        ax.axis('equal')
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
        RegularConvexPolygon()


except Exception:
    import traceback
    print(traceback.format_exc())


