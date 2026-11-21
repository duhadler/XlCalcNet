from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')


def SuperellipseXYEq(t, a, b, m, n):
    s = np.sin(t);
    c = np.cos(t);
    x = np.power(np.abs(c), 2 / m) * a * np.sign(c);
    y = np.power(np.abs(s), 2 / n) * b * np.sign(s);
    return x, y


def SuperellipseXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SuperellipseXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 600
# End of standard key word arguments
    #  Maclaurin trisectrix
    a = 1.0;
    b = 1.0;
    m = 1.0 / 2.0;
    n = m;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    t = np.linspace(0, 2 * np.pi, Resolution)
    x, y = SuperellipseXYEq(t, a, b, m, n)
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
        SuperellipseXY()


except Exception:
    import traceback
    print(traceback.format_exc())


