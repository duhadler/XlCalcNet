
# See: https://python-graph-gallery.com/184-lollipop-plot-with-2-groups/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
 


def Lolllipop2Groups(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Lolllipop2Groups'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    # Create a dataframe
    value1=np.random.uniform(size=20)
    value2=value1+np.random.uniform(size=20)/4
    df = pd.DataFrame({'group':list(map(chr, range(65, 85))), 'value1':value1 , 'value2':value2 })
     
    # Reorder it following the values of the first value:
    ordered_df = df.sort_values(by='value1')
    my_range=range(1,len(df.index)+1)
     
    # The horizontal plot is made using the hline function
    plt.hlines(y=my_range, xmin=ordered_df['value1'], xmax=ordered_df['value2'], color='grey', alpha=0.4, zorder=1)
    plt.scatter(ordered_df['value1'], my_range, color='skyblue', alpha=1, label='value1')
    plt.scatter(ordered_df['value2'], my_range, color='lightgreen', alpha=1 , label='value2')
    plt.legend()
     
    # Add title and axis names
    plt.yticks(my_range, ordered_df['group'])
    plt.title("Comparison of the value 1 and the value 2", loc='left')
    plt.xlabel('Value of the variables')
    plt.ylabel('Group')


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
        Lolllipop2Groups()


except Exception:
    import traceback
    print(traceback.format_exc())




