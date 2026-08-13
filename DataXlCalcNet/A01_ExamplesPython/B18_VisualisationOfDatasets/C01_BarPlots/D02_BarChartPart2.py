from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/statistics/histogram_multihist.html#sphx-glr-gallery-statistics-histogram-multihist-py


def BarChartPart2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BarChartPart2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    np.random.seed(19680801)

    mu_x = 200
    sigma_x = 25
    x = np.random.normal(mu_x, sigma_x, size=100)

    mu_w = 200
    sigma_w = 10
    w = np.random.normal(mu_w, sigma_w, size=100)

    fig, axs = plt.subplots(nrows=2, ncols=2)

    axs[0, 0].hist(x, 20, density=True, histtype='stepfilled', facecolor='g',
                   alpha=0.75)
    axs[0, 0].set_title('stepfilled')

    axs[0, 1].hist(x, 20, density=True, histtype='step', facecolor='g',
                   alpha=0.75)
    axs[0, 1].set_title('step')

    axs[1, 0].hist(x, density=True, histtype='barstacked', rwidth=0.8)
    axs[1, 0].hist(w, density=True, histtype='barstacked', rwidth=0.8)
    axs[1, 0].set_title('barstacked')

    # Create a histogram by providing the bin edges (unequally spaced).
    bins = [100, 150, 180, 195, 205, 220, 250, 300]
    axs[1, 1].hist(x, bins, density=True, histtype='bar', rwidth=0.8)
    axs[1, 1].set_title('bar, unequal bins')

    fig.tight_layout()


# Start of output choices
    if (OutputMode == 'plt'):
        plt.show()
    elif (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = (Path(__file__).stem)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName + '.' + OutputMode])
        plt.savefig(FullPath,  bbox_inches='tight')
        if OutputDir != 'Temp': print('Graphics written to: ', FullPath)
    plt.close('all')


try:
    if __name__ == '__main__':
        BarChartPart2()


except Exception:
    import traceback
    print(traceback.format_exc())

