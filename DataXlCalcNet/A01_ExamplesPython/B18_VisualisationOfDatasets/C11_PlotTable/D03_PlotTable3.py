from xlcalcnet import gui
from pathlib import Path
import os
from pathlib import Path
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd

from plottable import ColDef, Table
from plottable.plots import image

# See: https://python-graph-gallery.com/560-introduction-plottable/
# See: https://plottable.readthedocs.io/en/latest/example_notebooks/basic_example.html


def PlotTable3(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlotTable3'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    data = {
      'pts': [27, 18, 34, 25, 22, 26, 15, 17, 14, 18, 28, 27, 9, 18, 14, 13, 23, 21],
      'gd': [7.0, -1.0, 36.0, 4.0, 4.0, 8.0, -8.0, -8.0, -3.0, -5.0, 9.0, 5.0, -19.0, 0.0, -9.0, -22.0, 4.0, -2.0],
      'gf': [23.0, 25.0, 49.0, 25.0, 28.0, 31.0, 18.0, 21.0, 19.0, 18.0, 30.0, 21.0, 13.0, 22.0, 18.0, 14.0, 24.0, 25.0],
      'ga': [16.0, 26.0, 13.0, 21.0, 24.0, 23.0, 26.0, 29.0, 22.0, 23.0, 21.0, 16.0, 32.0, 22.0, 27.0, 36.0, 20.0, 27.0],
      'xgf': [13.85, 22.98, 41.06, 26.56, 24.62, 24.69, 16.93, 23.79, 20.45, 18.62, 30.96, 24.65, 18.39, 24.01, 21.88, 15.39, 20.12, 22.15],
      'xga': [14.29, 23.41, 16.55, 18.72, 26.00, 18.11, 31.46, 20.35, 24.78, 22.58, 17.72, 18.82, 26.38, 23.31, 22.20, 34.90, 24.34, 27.18],
      'games': [14, 15, 15, 15, 14, 15, 15, 15, 15, 14, 15, 14, 15, 15, 15, 15, 15, 15],
      'W': [8, 5, 10, 8, 6, 8, 4, 4, 3, 5, 8, 8, 2, 5, 3, 4, 6, 6],
      'D': [3, 3, 4, 1, 4, 2, 3, 5, 5, 3, 4, 3, 3, 3, 5, 1, 5, 3],
      'L': [3, 7, 1, 6, 5, 4, 8, 6, 7, 6, 3, 3, 10, 7, 7, 10, 4, 6]
    }

    perform = pd.DataFrame(data, index = ['1. FC Union Berlin', 'Bayer Leverkusen', 
        'Bayern Munich', 'Borussia Dortmund', 'Borussia Monchengladbach', 
        'Eintracht Frankfurt', 'FC Augsburg', 'FC Cologne', 'Hertha Berlin', 
        'Mainz', 'RB Leipzig', 'SC Freiburg', 'Schalke 04', 'TSG Hoffenheim', 
        'VfB Stuttgart', 'VfL Bochum', 'VfL Wolfsburg', 'Werder Bremen'])

    perform.index.name = 'team'

    print(perform)

    bundesliga_crests_22_23 = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'bundesliga_crests_22_23'])

    # mapping teamnames to logo paths

    club_logo_path = Path(bundesliga_crests_22_23)
    club_logo_files = list(club_logo_path.glob('*.png'))
    club_logos_paths = {f.stem: f for f in club_logo_files}
    perform = perform.reset_index()

    # Add a column for crests
    perform.insert(0, 'crest', perform['team'])
    perform['crest'] = perform['crest'].replace(club_logos_paths)

    # sort by table standings
    perform = perform.sort_values(by=['pts', 'gd', 'gf'], ascending=False)

    for colname in ['gd', 'gf', 'ga']:
        perform[colname] = perform[colname].astype('int32')

    perform['goal_difference'] = perform['gf'].astype(str) + ':' + perform['ga'].astype(str)

    perform['rank'] = list(range(1, 19))

    row_colors = {
        'top4': '#2d3636',
        'top6': '#516362',
        'playoffs': '#8d9386',
        'relegation': '#c8ab8d',
        'even': '#627979',
        'odd': '#68817e',
    }

    bg_color = row_colors['odd']
    text_color = '#e0e8df'

    table_cols = ['crest', 'team', 'games', 'W', 'D', 'L', 'goal_difference', 'gd', 'pts']

    table_col_defs = [
        ColDef('rank', width=0.5, title=''),
        ColDef('crest', width=0.35, plot_fn=image, title=''),
        ColDef('team', width=2.5, title='', textprops={'ha': 'left'}),
        ColDef('games', width=0.5, title='Games'),
        ColDef('W', width=0.5),
        ColDef('D', width=0.5),
        ColDef('L', width=0.5),
        ColDef('goal_difference', title='Goals'),
        ColDef('gd', width=0.5, title='', formatter='{:+}'),
        ColDef('pts', border='left', title='Points'),
    ]

    fig, ax = plt.subplots(figsize=(7, 6))
    fig.tight_layout()


    plt.rcParams['text.color'] = text_color
    #plt.rcParams['font.family'] = 'Roboto'

    fig.set_facecolor(bg_color)
    ax.set_facecolor(bg_color)

    table = Table(
        perform,
        column_definitions=table_col_defs,
        row_dividers=True,
        col_label_divider=False,
        footer_divider=True,
        index_col='rank',
        columns=table_cols,
        even_row_color=row_colors['even'],
        footer_divider_kw={'color': bg_color, 'lw': 2},
        row_divider_kw={'color': bg_color, 'lw': 2},
        column_border_kw={'color': bg_color, 'lw': 2},
        #textprops={'fontsize': 16, 'ha': 'center', 'fontname': 'Roboto'},
        textprops={'fontsize': 8, 'ha': 'center'},
    )

    for idx in [0, 1, 2, 3]:
        table.rows[idx].set_facecolor(row_colors['top4'])
        
    for idx in [4, 5]:
        table.rows[idx].set_facecolor(row_colors['top6'])
        
    table.rows[15].set_facecolor(row_colors['playoffs'])

    for idx in [16, 17]:
        table.rows[idx].set_facecolor(row_colors['relegation'])
        table.rows[idx].set_fontcolor(row_colors['top4'])

#    fig.savefig(
#        'images/bohndesliga_table_recreation.png',
#        facecolor=fig.get_facecolor(),
#        dpi=200,
#    )
        

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
        PlotTable3()


except Exception:
    import traceback
    print(traceback.format_exc())


