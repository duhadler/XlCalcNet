
# See: https://python-graph-gallery.com/541-waffle-chart-with-additionnal-grouping/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from pywaffle import Waffle



def WaffleChart2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'WaffleChart2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    data = {'labels': ['Car', 'Truck', 'Motorcycle'],
            'Factory A': [32384, 13354, 5245],
            'Factory B': [22147, 6678, 2156],
            'Factory C': [8932, 3879, 896],
           }
    df = pd.DataFrame(data).set_index('labels')



    plot1 = {'values': [value/1000 for value in data['Factory A']],  # Convert actual number to a reasonable block number
             'labels': [f"{index} ({value})" for index, value in zip(df['Factory A'],df.index)],
             'legend': {'loc': 'upper left', 'bbox_to_anchor': (1.05, 1), 'fontsize': 8},
             'title': {'label': 'Vehicle Production of Factory A', 'loc': 'left', 'fontsize': 12}
            }

    plot2 = {'values': [value/1000 for value in data['Factory B']],
             'labels': [f"{index} ({value})" for index, value in zip(df['Factory B'],df.index)],
             'legend': {'loc': 'upper left', 'bbox_to_anchor': (1.2, 1), 'fontsize': 8},
             'title': {'label': 'Vehicle Production of Factory B', 'loc': 'left', 'fontsize': 12}
            }

    plot3 = {'values': [value/1000 for value in data['Factory C']],
             'labels': [f"{index} ({value})" for index, value in zip(df['Factory C'],df.index)],
             'legend': {'loc': 'upper left', 'bbox_to_anchor': (1.3, 1), 'fontsize': 8},
             'title': {'label': 'Vehicle Production of Factory C', 'loc': 'left', 'fontsize': 12}
            }

    fig = plt.figure(
        FigureClass=Waffle,
        plots={
            311: plot1,
            312: plot2,
            313: plot3,
        },
        rows=5,  # Outside parameter applied to all subplots, same as below
        cmap_name="Accent",  # Change color with cmap
        rounding_rule='ceil',  # Change rounding rule, so value less than 1000 will still have at least 1 block
        figsize=(8, 6)
    )

    # Add a title and a small detail at the bottom
    fig.suptitle('Vehicle Production by Vehicle Type', fontsize=14, fontweight='bold')
    fig.supxlabel('1 block = 1000 vehicles',
                  fontsize=8,
                  x=0.14, # position at the 14% axis
                 )
    fig.set_facecolor('#EEEDE7')



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
        WaffleChart2()


except Exception:
    import traceback
    print(traceback.format_exc())


