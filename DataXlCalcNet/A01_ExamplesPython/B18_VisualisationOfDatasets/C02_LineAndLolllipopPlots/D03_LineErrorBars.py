from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/lines_bars_and_markers/fill_between_alpha.html#sphx-glr-gallery-lines-bars-and-markers-fill-between-alpha-py


def LineErrorBars(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'LineErrorBars'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # example data
    x = np.arange(0.1, 4, 0.1)
    y1 = np.exp(-1.0 * x)
    y2 = np.exp(-0.5 * x)

    # example variable error bar values
    y1err = 0.1 + 0.1 * np.sqrt(x)
    y2err = 0.1 + 0.1 * np.sqrt(x/2)


    fig, (ax0, ax1, ax2) = plt.subplots(nrows=1, ncols=3, sharex=True,
                                        figsize=(12, 6))

    ax0.set_title('all errorbars')
    ax0.errorbar(x, y1, yerr=y1err)
    ax0.errorbar(x, y2, yerr=y2err)

    ax1.set_title('only every 6th errorbar')
    ax1.errorbar(x, y1, yerr=y1err, errorevery=6)
    ax1.errorbar(x, y2, yerr=y2err, errorevery=6)

    ax2.set_title('second series shifted by 3')
    ax2.errorbar(x, y1, yerr=y1err, errorevery=(0, 6))
    ax2.errorbar(x, y2, yerr=y2err, errorevery=(3, 6))

    fig.suptitle('Errorbar subsampling')

    #plt.show()
#    gui.plot(fig, __file__, 'ErrorBar3')
#    plt.close("all")

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
        LineErrorBars()


except Exception:
    import traceback
    print(traceback.format_exc())

