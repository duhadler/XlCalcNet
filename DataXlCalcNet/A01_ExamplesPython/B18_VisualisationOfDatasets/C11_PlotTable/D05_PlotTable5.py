from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
from matplotlib.colors import LinearSegmentedColormap

from plottable import ColDef, Table

#See: https://plottable.readthedocs.io/en/latest/example_notebooks/basic_example.html

def PlotTable5(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlotTable5'
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
        name='BuYl', colors=['#01a6ff', '#eafedb', '#fffdbb', '#ffc834'], N=256
    )

    cities = [
        'TORONTO',
        'VANCOUVER',
        'HALIFAX',
        'CALGARY',
        'OTTAWA',
        'MONTREAL',
        'WINNIPEG',
        'EDMONTON',
        'LONDON',
        'ST. JONES',
    ]
    months = [
        'JAN',
        'FEB',
        'MAR',
        'APR',
        'MAY',
        'JUN',
        'JUL',
        'AUG',
        'SEP',
        'OCT',
        'NOV',
        'DEC',
    ]

    data = np.random.random((10, 12)) + np.abs(np.arange(12) - 5.5)
    data = (1 - data / (np.max(data)))


    d = pd.DataFrame(data, columns=months, index=cities).round(2)

    fig, ax = plt.subplots(figsize=(7, 4))
    fig.tight_layout()


    column_definitions = [
        ColDef(name, cmap=cmap, formatter=lambda x: '') for name in months
    ] + [ColDef('index', title='', width=2.5, textprops={'ha': 'right'})]

    tab = Table(
        d,
        column_definitions=column_definitions,
        row_dividers=False,
        col_label_divider=False,
        #textprops={'ha': 'center', 'fontname': 'Roboto'},
        textprops={'ha': 'center'},
        cell_kw={
            'edgecolor': 'w',
            'linewidth': 0,
        },
    )


    tab.col_label_row.set_facecolor('k')
    tab.col_label_row.set_fontcolor('w')
    tab.columns['index'].set_facecolor('k')
    tab.columns['index'].set_fontcolor('w')
    tab.columns['index'].set_linewidth(0)


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
        PlotTable5()


except Exception:
    import traceback
    print(traceback.format_exc())


