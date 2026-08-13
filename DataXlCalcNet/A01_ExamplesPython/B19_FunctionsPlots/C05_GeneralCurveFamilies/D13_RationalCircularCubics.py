from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')


def CubicCircularRationalsXYEq(t, a, b, d):
    x = (d * t * t + 2 * b * t + 2 * a + d) / (1 + t * t);
    y = t * x;
    return x, y


def CubicCircularRationalsXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CubicCircularRationalsXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 600
# End of standard key word arguments
    #  Maclaurin trisectrix
    b = 0.0;
    d = -1.0;
    a = -2.0 * d;
    k = 4.0;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    t = np.linspace(-k, k, Resolution)
    x, y = CubicCircularRationalsXYEq(t, a, b, d)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    ax.plot(x, y)
    ax.set_xlim(-4, 4)
    ax.set_ylim(-4, 4)
    #ax.axis('equal')
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
        CubicCircularRationalsXY()


except Exception:
    import traceback
    print(traceback.format_exc())


