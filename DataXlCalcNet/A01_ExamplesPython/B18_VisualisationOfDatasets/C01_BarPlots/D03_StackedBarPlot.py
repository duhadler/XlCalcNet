
# See: https://python-graph-gallery.com/12-stacked-barplot-with-matplotlib/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import matplotlib.pyplot as plt
from matplotlib import rc




def StackedBarPlot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedBarPlot'
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

    # y-axis in bold
    rc('font', weight='bold')

    # Values of each group
    bars1 = [12, 28, 1, 8, 22]
    bars2 = [28, 7, 16, 4, 10]
    bars3 = [25, 3, 23, 25, 17]

    # Heights of bars1 + bars2
    bars = np.add(bars1, bars2).tolist()

    # The position of the bars on the x-axis
    r = [0,1,2,3,4]

    # Names of group and bar width
    names = ['A','B','C','D','E']
    barWidth = 1

    # Create brown bars
    plt.bar(r, bars1, color='#7f6d5f', edgecolor='white', width=barWidth)
    # Create green bars (middle), on top of the first ones
    plt.bar(r, bars2, bottom=bars1, color='#557f2d', edgecolor='white', width=barWidth)
    # Create green bars (top)
    plt.bar(r, bars3, bottom=bars, color='#2d7f5e', edgecolor='white', width=barWidth)

    # Custom X axis
    plt.xticks(r, names, fontweight='bold')
    plt.xlabel("group")


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
        StackedBarPlot()


except Exception:
    import traceback
    print(traceback.format_exc())


