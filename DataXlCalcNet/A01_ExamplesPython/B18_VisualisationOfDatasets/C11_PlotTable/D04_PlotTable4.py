from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
from matplotlib.colors import LinearSegmentedColormap
import numpy as np
import pandas as pd

from plottable import ColumnDefinition, Table
from plottable.formatters import decimal_to_percent
from plottable.plots import bar, percentile_bars, percentile_stars, progress_donut

#See: https://plottable.readthedocs.io/en/latest/example_notebooks/basic_example.html


def PlotTable4(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlotTable4'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    cmap = LinearSegmentedColormap.from_list(
        name='bugw', colors=['#ffffff', '#f2fbd2', '#c9ecb4', '#93d3ab', '#35b0ab'], N=256
    )
    fig, ax = plt.subplots(figsize=(6, 6))
    fig.tight_layout()


    d = pd.DataFrame(np.random.random((10, 4)), columns=['A', 'B', 'C', 'D']).round(2)

    tab = Table(
        d,
        cell_kw={
            'linewidth': 0,
            'edgecolor': 'k',
        },
        textprops={'fontsize': 12, 'ha': 'center'},
        column_definitions=[
            ColumnDefinition(
                'index', 
                textprops={'ha': 'left'}
            ),
            ColumnDefinition(
                'A', 
                plot_fn=percentile_bars, 
                plot_kw={'is_pct': True}
            ),
            ColumnDefinition(
                'B', 
                width=1.5, 
                plot_fn=percentile_stars, 
                plot_kw={'is_pct': True}
            ),
            ColumnDefinition(
                'C',
                plot_fn=progress_donut,
                plot_kw={
                    'is_pct': True,
                    'textprops': {'fontsize': 6},
                    'formatter': '{:.0%}'
                    },
                ),
            ColumnDefinition(
                'D',
                width=1.25,
                plot_fn=bar,
                plot_kw={
                    'cmap': cmap,
                    'plot_bg_bar': True,
                    'annotate': True,
                    'height': 0.8,
                    'lw': 0.5,
                    'formatter': decimal_to_percent,
                },
            ),
        ],
    )

    #plt.show()

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
        PlotTable4()


except Exception:
    import traceback
    print(traceback.format_exc())



