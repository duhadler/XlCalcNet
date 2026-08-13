from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')

#See also: https://mathworld.wolfram.com/HeartCurve.html
#See also: https://en.wikipedia.org/wiki/Heart_symbol#Parametrisation


def HeartCurve(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'HeartCurve'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    bb = 0.1;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    t = np.linspace(0, 2*np.pi, Resolution)
    s = np.sin(t);
    s2 = s * s;
    c1 = np.cos(t);
    c2 = np.cos(2 * t);
    c3 = np.cos(3 * t);
    c4 = np.cos(4 * t);
    x = 16 * s * s * s;
    y = 13 * c1 - 5 * c2 - 2 * c3 - c4;
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
        HeartCurve()


except Exception:
    import traceback
    print(traceback.format_exc())


