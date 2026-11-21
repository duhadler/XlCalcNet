


# https://moshi4.github.io/pyCirclize/chord_diagram/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import ColorCycler


def ChordDiagramFromTo(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ChordDiagramFromTo'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    # Create matrix data (10 x 2)
    row_names = list("ABCDEFGHIJ")
    col_names = list("KL")
    matrix_data = [
        [83, 79],
        [90, 118],
        [165, 81],
        [121, 77],
        [187, 197],
        [177, 8],
        [141, 127],
        [29, 27],
        [95, 82],
        [107, 39],
    ]
    matrix_df = pd.DataFrame(matrix_data, index=row_names, columns=col_names)

    # Define link_kws handler function to customize each link property
    def link_kws_handler(from_label: str, to_label: str):
        if from_label in ("C", "G"):
            # Set alpha, zorder values higher than other links for highlighting
            return dict(alpha=0.5, zorder=1.0)
        else:
            return dict(alpha=0.1, zorder=0)

    # Initialize Circos instance for chord diagram plot
    circos = Circos.chord_diagram(
        matrix_df,
        space=2,
        cmap="Set3",
        label_kws=dict(size=12),
        link_kws=dict(direction=1, ec="black", lw=0.5),
        link_kws_handler=link_kws_handler,
    )

    print(matrix_df)
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
        ChordDiagramFromTo()


except Exception:
    import traceback
    print(traceback.format_exc())


