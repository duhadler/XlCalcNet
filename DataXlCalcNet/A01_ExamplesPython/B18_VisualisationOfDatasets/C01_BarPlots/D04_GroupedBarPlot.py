
# See: https://python-graph-gallery.com/11-grouped-barplot/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import matplotlib.pyplot as plt



def GroupedBarPlot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'GroupedBarPlot'
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



    # Data
    barWidth = 0.25
    bars1 = [12, 30, 1, 8, 22]
    bars2 = [28, 6, 16, 5, 10]
    bars3 = [29, 3, 24, 25, 17]

    # Bar positions
    r = np.arange(len(bars1))
    r2 = r + barWidth
    r3 = r2 + barWidth

    # Plotting
    fig, ax = plt.subplots(dpi=96)
    ax.bar(r, bars1, color='#7f6d5f', width=barWidth, edgecolor='white', label='var1')
    ax.bar(r2, bars2, color='#557f2d', width=barWidth, edgecolor='white', label='var2')
    ax.bar(r3, bars3, color='#2d7f5e', width=barWidth, edgecolor='white', label='var3')

    # Xticks
    ax.set_xlabel('group', fontweight='bold')
    ax.set_xticks(r + barWidth)
    ax.set_xticklabels(['A', 'B', 'C', 'D', 'E'])

    # Legend and show
    ax.legend()

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
        GroupedBarPlot()


except Exception:
    import traceback
    print(traceback.format_exc())




