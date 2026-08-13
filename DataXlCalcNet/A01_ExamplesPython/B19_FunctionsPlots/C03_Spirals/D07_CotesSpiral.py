from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')


def CotesSpiralPolarEQ(theta, A, k, eps, CotesCase):
    r1 = 1
    if (CotesCase==1):      r1 = A * np.cosh(k * theta + eps)
    elif (CotesCase==2): r1 = A * np.exp(k * theta + eps)
    elif (CotesCase==3): r1 = A * np.sinh(k * theta + eps)
    elif (CotesCase==4): r1 = A * (k * theta + eps)
    elif (CotesCase==5): r1 = A * np.cos(k * theta + eps)
    r = 1/r1
    return r


def CotesSpiralXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CotesSpiralXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    A = 1;
    k = 0.4;
    eps = 0;
    CotesCase = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    theta = np.linspace(-10.0, 10.0, Resolution)
    r = CotesSpiralPolarEQ(theta, A, k, eps, CotesCase)

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
        CotesSpiralXY()


except Exception:
    import traceback
    print(traceback.format_exc())

