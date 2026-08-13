


# https://moshi4.github.io/pyCirclize/chord_diagram/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import ColorCycler


def ChordDiagramMatrix10x10(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ChordDiagramMatrix10x10'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    # Create matrix data (10 x 10)
    row_names = list("ABCDEFGHIJ")
    col_names = row_names
    matrix_data = [
        [51, 115, 60, 17, 120, 126, 115, 179, 127, 114],
        [108, 138, 165, 170, 85, 221, 75, 107, 203, 79],
        [108, 54, 72, 123, 84, 117, 106, 114, 50, 27],
        [62, 134, 28, 185, 199, 179, 74, 94, 116, 108],
        [211, 114, 49, 55, 202, 97, 10, 52, 99, 111],
        [87, 6, 101, 117, 124, 171, 110, 14, 175, 164],
        [167, 99, 109, 143, 98, 42, 95, 163, 134, 78],
        [88, 83, 136, 71, 122, 20, 38, 264, 225, 115],
        [145, 82, 87, 123, 121, 55, 80, 32, 50, 12],
        [122, 109, 84, 94, 133, 75, 71, 115, 60, 210],
    ]
    matrix_df = pd.DataFrame(matrix_data, index=row_names, columns=col_names)

    # Initialize Circos instance for chord diagram plot
    circos = Circos.chord_diagram(
        matrix_df,
        space=3,
        r_lim=(93, 100),
        cmap="tab10",
        ticks_interval=500,
        label_kws=dict(r=94, size=12, color="white"),
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
        ChordDiagramMatrix10x10()


except Exception:
    import traceback
    print(traceback.format_exc())


