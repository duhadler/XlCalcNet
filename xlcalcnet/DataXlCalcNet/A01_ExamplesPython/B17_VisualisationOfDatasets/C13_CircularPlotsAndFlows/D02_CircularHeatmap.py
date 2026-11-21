


# https://moshi4.github.io/pyCirclize/plot_api_example/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import ColorCycler


def CircularHeatmap(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircularHeatmap'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    sectors = {"A": 10, "B": 20, "C": 15}
    circos = Circos(sectors, space=10)
    vmin1, vmax1 = 0, 10
    vmin2, vmax2 = -100, 100
    for sector in circos.sectors:
        # Plot heatmap
        track1 = sector.add_track((80, 100))
        track1.axis()
        track1.xticks_by_interval(1)
        data = np.random.randint(vmin1, vmax1 + 1, (4, int(sector.size)))
        track1.heatmap(data, vmin=vmin1, vmax=vmax1, show_value=True)
        # Plot heatmap with labels
        track2 = sector.add_track((50, 70))
        track2.axis()
        x = np.linspace(1, int(track2.size), int(track2.size)) - 0.5
        xlabels = [str(int(v + 1)) for v in x]
        track2.xticks(x, xlabels, outer=False)
        track2.yticks([0.5, 1.5, 2.5, 3.5, 4.5], list("ABCDE"), vmin=0, vmax=5)
        data = np.random.randint(vmin2, vmax2 + 1, (5, int(sector.size)))
        track2.heatmap(data, vmin=vmin2, vmax=vmax2, cmap="viridis", rect_kws=dict(ec="white", lw=1))

    circos.colorbar(bounds=(0.35, 0.55, 0.3, 0.01), vmin=vmin1, vmax=vmax1, orientation="horizontal")
    circos.colorbar(bounds=(0.35, 0.45, 0.3, 0.01), vmin=vmin2, vmax=vmax2, orientation="horizontal", cmap="viridis")

    fig = circos.plotfig()


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
        CircularHeatmap()


except Exception:
    import traceback
    print(traceback.format_exc())


