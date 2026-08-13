from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/lines_bars_and_markers/stem_plot.html#sphx-glr-gallery-lines-bars-and-markers-stem-plot-py


def Simpleplot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Simpleplot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # Data for plotting
    t = np.linspace(0.0, 2.0, Resolution)
    s1 = 1 + np.sin(2 * np.pi * t) * np.exp(-t)
    s2 = 1 - np.sin(2 * np.pi * t) * np.exp(-t)

    fig, ax = plt.subplots()
    ax.plot(t, s1)
    ax.plot(t, s2)
    plt.legend(['First line', 'Second line'],)


    ax.set(xlabel='x', ylabel='pdf(x)', title='Distribution: pdf')
    ax.grid()

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
        Simpleplot()


except Exception:
    import traceback
    print(traceback.format_exc())


