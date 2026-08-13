from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt

#See also: https://en.wikipedia.org/wiki/Dragon_curve


def DragonCurve(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'DragonCurve'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 100
# End of standard key word arguments

    import random
    from math import sqrt, cos, sin, pi
    def f1(x, y): return (1 / sqrt(2)) * np.array([[cos(pi/4), -sin(pi/4)],
        [sin(pi/4), cos(pi/4)]]).dot(np.array([x, y]))

    def f2(x, y): return (1 / sqrt(2)) * np.array([[cos(3*pi/4), -sin(3*pi/4)],
        [sin(3*pi/4), cos(3*pi/4)]]).dot(np.array([x, y])) + np.array([1, 0])

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeX))
    plt.xticks([])
    plt.yticks([])
    n = Resolution * 100
    x, y = [0], [0]
    for _ in range(n):
        r = random.random()
        if r <= 0.5: dot = f1(x[-1], y[-1])
        else: dot = f2(x[-1], y[-1])
        x.append(dot[0])
        y.append(dot[1])
    plt.plot(x, y, '.', markersize=1, color='r')
    #plt.tight_layout()

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
        DragonCurve()

except Exception:
    import traceback
    print(traceback.format_exc())




