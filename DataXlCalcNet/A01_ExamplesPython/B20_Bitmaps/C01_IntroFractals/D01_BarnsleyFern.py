from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt

# See also: https://en.wikipedia.org/wiki/Barnsley_fern
# See also: https://github.com/Quentin18/Matplotlib-fractals/tree/master

def BarnsleyFern(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BarnsleyFern'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    import random
    def f1(x, y): return np.array([[0, 0], [0, 0.16]]).dot(np.array([x, y]))

    def f2(x, y): return (np.array([[0.85, 0.04], [-0.04, 0.85]])
            .dot(np.array([x, y])) + np.array([0, 1.6]))

    def f3(x, y): return (np.array([[0.20, -0.26], [0.23, 0.22]])
            .dot(np.array([x, y])) + np.array([0, 1.6]))

    def f4(x, y): return (np.array([[-0.15, 0.28], [0.26, 0.24]])
            .dot(np.array([x, y])) + np.array([0, 0.44]))

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    plt.xticks([])
    plt.yticks([])
    #n = 20000
    n = Resolution * 100
    x, y = [0], [0]
    for _ in range(n):
        r = random.random()
        if r < 0.01: dot = f1(x[-1], y[-1])
        elif r < 0.86: dot = f2(x[-1], y[-1])
        elif r < 0.93: dot = f3(x[-1], y[-1])
        else: dot = f4(x[-1], y[-1])
        x.append(dot[0])
        y.append(dot[1])
    plt.plot(x, y, '.', markersize=2, color='g')
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
        BarnsleyFern()

except Exception:
    import traceback
    print(traceback.format_exc())




