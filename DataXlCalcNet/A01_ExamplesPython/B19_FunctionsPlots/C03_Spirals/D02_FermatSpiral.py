from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')


def FermatSpiralPolarEQ(theta, a):
    r = a * np.sqrt(theta)
    return r


def FermatSpiralXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FermatSpiralXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    bb = 0.1;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    a = np.full((Resolution, ), 1)
    theta = np.linspace(0, 4.0 * np.pi, Resolution)
    r = FermatSpiralPolarEQ(theta, a)

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
        FermatSpiralXY()


except Exception:
    import traceback
    print(traceback.format_exc())


