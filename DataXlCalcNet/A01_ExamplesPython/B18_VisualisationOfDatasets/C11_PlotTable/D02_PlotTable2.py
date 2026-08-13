from xlcalcnet import gui
from pathlib import Path
import os
from pathlib import Path
import matplotlib
import matplotlib.pyplot as plt
from matplotlib.colors import LinearSegmentedColormap
import numpy as np
import pandas as pd

from plottable import ColumnDefinition, Table
from plottable.cmap import normed_cmap
from plottable.formatters import decimal_to_percent
from plottable.plots import circled_image # image

#See: https://plottable.readthedocs.io/en/latest/example_notebooks/wwc_example.html


def PlotTable2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlotTable2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    cols = [
        'team',
        'points',
        'group',
        'spi',
        'global_o',
        'global_d',
        'group_1',
        'group_2',
        'group_3',
        'make_round_of_16',
        'make_quarters',
        'make_semis',
        'make_final',
        'win_league',
    ]

    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'CSV', 'wwc_forecasts.csv'])
    df = pd.read_csv( DataPath, usecols=cols,)

    colnames = [
        'Team',
        'Points',
        'Group',
        'SPI',
        'OFF',
        'DEF',
        '1st Place',
        '2nd Place',
        '3rd Place',
        'Make Rd Of 16',
        'Make Quarters',
        'Make Semis',
        'Make Finals',
        'Win World Cup',
    ]

    col_to_name = dict(zip(cols, colnames))
    country_flags = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'country_flags'])

    flag_paths = list(Path(country_flags).glob('*.png'))
    country_to_flagpath = {p.stem: p for p in flag_paths}
    df[['spi', 'global_o', 'global_d']] = df[['spi', 'global_o', 'global_d']].round(1)

    df = df.rename(col_to_name, axis=1)
    df = df.drop('Points', axis=1)
    df.insert(0, 'Flag', df['Team'].apply(lambda x: country_to_flagpath.get(x)))

    df = df.set_index('Team')
    df.head()

    cmap = LinearSegmentedColormap.from_list(
        name='bugw', colors=['#ffffff', '#f2fbd2', '#c9ecb4', '#93d3ab', '#35b0ab'], N=256
    )

    team_rating_cols = ['SPI', 'OFF', 'DEF']
    group_stage_cols = ['1st Place', '2nd Place', '3rd Place']
    knockout_stage_cols = list(df.columns[-5:])


    col_defs = (
        [
            ColumnDefinition(
                name='Flag',
                title='',
                textprops={'ha': 'center'},
                width=0.5,
                plot_fn=circled_image,
            ),
            ColumnDefinition(
                name='Team',
                textprops={'ha': 'left', 'weight': 'bold'},
                width=1.5,
            ),
            ColumnDefinition(
                name='Group',
                textprops={'ha': 'center'},
                width=0.75,
            ),
            ColumnDefinition(
                name='SPI',
                group='Team Rating',
                textprops={'ha': 'center'},
                width=0.75,
            ),
            ColumnDefinition(
                name='OFF',
                width=0.75,
                textprops={
                    'ha': 'center',
                    'bbox': {'boxstyle': 'circle', 'pad': 0.35},
                },
                cmap=normed_cmap(df['OFF'], cmap=matplotlib.cm.PiYG, num_stds=2.5),
                group='Team Rating',
            ),
            ColumnDefinition(
                name='DEF',
                width=0.75,
                textprops={
                    'ha': 'center',
                    'bbox': {'boxstyle': 'circle', 'pad': 0.35},
                },
                cmap=normed_cmap(df['DEF'], cmap=matplotlib.cm.PiYG_r, num_stds=2.5),
                group='Team Rating',
            ),
        ]
        + [
            ColumnDefinition(
                name=group_stage_cols[0],
                title=group_stage_cols[0].replace(' ', '\n', 1),
                formatter=decimal_to_percent,
                group='Group Stage Chances',
                border='left',
            )
        ]
        + [
            ColumnDefinition(
                name=col,
                title=col.replace(' ', '\n', 1),
                formatter=decimal_to_percent,
                group='Group Stage Chances',
            )
            for col in group_stage_cols[1:]
        ]
        + [
            ColumnDefinition(
                name=knockout_stage_cols[0],
                title=knockout_stage_cols[0].replace(' ', '\n', 1),
                formatter=decimal_to_percent,
                cmap=cmap,
                group='Knockout Stage Chances',
                border='left',
            )
        ]
        + [
            ColumnDefinition(
                name=col,
                title=col.replace(' ', '\n', 1),
                formatter=decimal_to_percent,
                cmap=cmap,
                group='Knockout Stage Chances',
            )
            for col in knockout_stage_cols[1:]
        ]
    )
    plt.rcParams['font.family'] = ['DejaVu Sans']
    plt.rcParams['savefig.bbox'] = 'tight'
    fig, ax = plt.subplots(figsize=(10, 11))
    fig.tight_layout()


    table = Table(
        df,
        column_definitions=col_defs,
        row_dividers=True,
        footer_divider=True,
        ax=ax,
        #textprops={'fontsize': 14},
        textprops={'fontsize': 10},
        row_divider_kw={'linewidth': 1, 'linestyle': (0, (1, 5))},
        col_label_divider_kw={'linewidth': 1, 'linestyle': '-'},
        column_border_kw={'linewidth': 1, 'linestyle': '-'},
    ).autoset_fontcolors(colnames=['OFF', 'DEF'])

    #fig.savefig('images/wwc_table.png', facecolor=ax.get_facecolor(), dpi=200)
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
        PlotTable2()


except Exception:
    import traceback
    print(traceback.format_exc())


