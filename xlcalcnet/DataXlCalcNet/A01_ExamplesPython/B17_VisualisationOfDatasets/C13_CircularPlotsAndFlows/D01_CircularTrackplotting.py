


# https://moshi4.github.io/pyCirclize/getting_started/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import ColorCycler


def CircularTrackplotting(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircularTrackplotting'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    np.random.seed(0)
    ColorCycler.set_cmap("tab10")

    sectors = {"A": 200, "B": 140, "C": 160}
    sector_colors = {"A": "red", "B": "blue", "C": "green"}
    circos = Circos(sectors, space=10, start=90, end=360, endspace=False)

    for sector in circos.sectors:
        # Outer Track
        outer_track = sector.add_track((95, 100))
        outer_track.text(sector.name, color="white")
        outer_track.axis(fc=sector_colors[sector.name])
        outer_track.xticks_by_interval(interval=10, label_orientation="vertical")
        # Rectangle Track
        rect_track = sector.add_track((90, 95))
        rect_size = 10
        for i in range(int(rect_track.size / rect_size)):
            x1, x2 = i * rect_size, i * rect_size + rect_size
            rect_track.rect(x1, x2, ec="black", lw=0.5, color=ColorCycler())
            rect_track.text(str(i + 1), (x1 + x2) / 2, size=8, color="white")
        # Generate random x, y plot data
        x = np.arange(1, int(sector.size), 2)
        y = np.random.randint(0, 10, len(x))
        # Line Track
        line_track = sector.add_track((80, 90), r_pad_ratio=0.1)
        line_track.axis()
        line_track.line(x, y, color="blue")
        # Scatter Track
        scatter_track = sector.add_track((70, 80), r_pad_ratio=0.1)
        scatter_track.axis()
        scatter_track.bar(x, y, width=0.8, color="orange")
        # Bar Track
        bar_track = sector.add_track((60, 70), r_pad_ratio=0.1)
        bar_track.axis()
        bar_track.scatter(x, y, color="green", s=3)
        # Fill Track
        fill_track = sector.add_track((50, 60), r_pad_ratio=0.1)
        fill_track.axis()
        fill_track.fill_between(x, y, y2=0, fc="red", ec="black", lw=0.5, alpha=0.5)
        # Line + Bar + Scatter Track
        line_bar_scatter_track = sector.add_track((40, 50), r_pad_ratio=0.1)
        line_bar_scatter_track.axis()
        line_bar_scatter_track.line(x, y, color="blue")
        line_bar_scatter_track.bar(x, y, width=0.8, color="orange")
        line_bar_scatter_track.scatter(x, y, color="green", s=3)

    # Plot text description
    text_common_kws = dict(ha="left", va="center", size=8)
    circos.text(" 01. Outer Track", r=97.5, color="black", **text_common_kws)
    circos.text(" 02. Rectangle Track", r=92.5, color="grey", **text_common_kws)
    circos.text(" 03. Line Track", r=85, color="blue", **text_common_kws)
    circos.text(" 04. Bar Track", r=75, color="orange", **text_common_kws)
    circos.text(" 05. Scatter Track", r=65, color="green", **text_common_kws)
    circos.text(" 06. Fill between Track", r=55, color="red", **text_common_kws)
    circos.text(" 07. Line + Bar + Scatter Track", r=45, color="purple", **text_common_kws)

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
        CircularTrackplotting()


except Exception:
    import traceback
    print(traceback.format_exc())


