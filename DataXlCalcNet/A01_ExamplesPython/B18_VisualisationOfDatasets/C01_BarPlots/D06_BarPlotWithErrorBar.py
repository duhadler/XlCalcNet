
# See: https://python-graph-gallery.com/8-add-confidence-interval-on-barplot/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import matplotlib.pyplot as plt
 


def BarPlotWithErrorBar(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BarPlotWithErrorBar'
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


    # width of the bars
    barWidth = 0.3
     
    # Choose the height of the blue bars
    bars1 = [10, 9, 2]
     
    # Choose the height of the cyan bars
    bars2 = [10.8, 9.5, 4.5]
     
    # Choose the height of the error bars (bars1)
    yer1 = [0.5, 0.4, 0.5]
     
    # Choose the height of the error bars (bars2)
    yer2 = [1, 0.7, 1]
     
    # The x position of bars
    r1 = np.arange(len(bars1))
    r2 = [x + barWidth for x in r1]
     
    # Create blue bars
    plt.bar(r1, bars1, width = barWidth, color = 'blue', edgecolor = 'black', yerr=yer1, capsize=7, label='poacee')
     
    # Create cyan bars
    plt.bar(r2, bars2, width = barWidth, color = 'cyan', edgecolor = 'black', yerr=yer2, capsize=7, label='sorgho')
     
    # general layout
    plt.xticks([r + barWidth for r in range(len(bars1))], ['cond_A', 'cond_B', 'cond_C'])
    plt.ylabel('height')
    plt.legend()

    fig = plt.gcf()
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
        BarPlotWithErrorBar()


except Exception:
    import traceback
    print(traceback.format_exc())

