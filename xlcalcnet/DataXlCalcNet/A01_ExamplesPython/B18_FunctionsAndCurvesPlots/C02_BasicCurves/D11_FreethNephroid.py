from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import warnings
#import matplotlib
#matplotlib.use('TkAgg')


def FreethsNephroidPolarEq(theta, a, n):
    s1 = np.sin(n * theta / (n - 1))
    s2 = n * np.sin(theta / (n - 1))
    r = a * s1 / s2
    return r


def FreethsNephroidXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FreethsNephroidXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    n = 4.0
# End of custom key word arguments

    plt.style.use(PlotStyle)
    a = np.full((Resolution, ), 1.0)
    theta = np.linspace(0, 4.0 * np.pi, Resolution)

    # this is to suppress a warning when dividing by zero
    with warnings.catch_warnings(action='ignore'):
        r = FreethsNephroidPolarEq(theta, a, n)

    x = r * np.cos(theta);
    y = r * np.sin(theta);
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
        FreethsNephroidXY()


except Exception:
    import traceback
    print(traceback.format_exc())


