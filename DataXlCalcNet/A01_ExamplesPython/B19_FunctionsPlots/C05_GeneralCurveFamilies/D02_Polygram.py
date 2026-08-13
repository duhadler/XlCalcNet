from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')


def PolygramPolarEQ(theta, a, alpha):
    r = a / (np.cos(theta - 0.5 * alpha - alpha * np.floor(theta / alpha)))
    return r


def PolygramXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PolygramXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1.0
    n = 1
    m = 3
# End of custom key word arguments

    plt.style.use(PlotStyle)
    res = m+1
    alpha = (2.0 * 1 * np.pi / (1.0 * m))
    theta0 = 1 * (np.pi / m)

    theta1 = np.linspace(0, 2.0 * np.pi, m+1)
    r1 = PolygramPolarEQ(theta1, a, alpha)

    y1 = r1 * np.sin(theta1);
    x1 = r1 * np.cos(theta1);

    theta2 = np.linspace( - theta0, 2.0 * np.pi - theta0, m+1)
    r2 = PolygramPolarEQ(theta2, 2*a, alpha)

    y2 = r2 * np.sin(theta2);
    x2 = r2 * np.cos(theta2);

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    ax.plot(x1, y1)
    ax.plot(x2, y2)

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
        PolygramXY()


except Exception:
    import traceback
    print(traceback.format_exc())


