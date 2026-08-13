from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/statistics/histogram_normalization.html#sphx-glr-gallery-statistics-histogram-normalization-py


def Pdf1Plot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    rng = np.random.default_rng(19680801)

    xdata = np.array([1.2, 2.3, 3.3, 3.1, 1.7, 3.4, 2.1, 1.25, 1.3])
    xbins = np.array([1, 2, 3, 4])

    # changing the style of the histogram bars just to make it
    # very clear where the boundaries of the bins are:
    style = {'facecolor': 'none', 'edgecolor': 'C0', 'linewidth': 3}

    fig, ax = plt.subplots()
    ax.hist(xdata, bins=xbins, **style)

    # plot the xdata locations on the x axis:
    ax.plot(xdata, 0*xdata, 'd')
    ax.set_ylabel('Number per bin')
    ax.set_xlabel('x bins (dx=1.0)')

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
        Pdf1Plot()


except Exception:
    import traceback
    print(traceback.format_exc())



