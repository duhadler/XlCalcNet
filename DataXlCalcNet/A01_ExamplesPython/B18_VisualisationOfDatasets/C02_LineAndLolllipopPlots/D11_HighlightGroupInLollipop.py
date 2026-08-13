
# See: https://python-graph-gallery.com/183-highlight-a-group-in-lollipop/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
 

def HighlightGroupInLollipop(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'HighlightGroupInLollipop'
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
    df = pd.DataFrame({'group':list(map(chr, range(65, 85))), 'values':np.random.uniform(size=20) })
     
    # Reorder it based on values:
    ordered_df = df.sort_values(by='values')
    my_range=range(1,len(df.index)+1)
     
    # Create a color if the group is "B"
    my_color=np.where(ordered_df ['group']=='B', 'orange', 'skyblue')
    my_size=np.where(ordered_df ['group']=='B', 70, 30)
     
    # The horizontal plot is made using the hline() function
    plt.hlines(y=my_range, xmin=0, xmax=ordered_df['values'], color=my_color, alpha=0.4)
    plt.scatter(ordered_df['values'], my_range, color=my_color, s=my_size, alpha=1)
     
    # Add title and axis names
    plt.yticks(my_range, ordered_df['group'])
    plt.title("What about the B group?", loc='left')
    plt.xlabel('Value of the variable')
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
        HighlightGroupInLollipop()


except Exception:
    import traceback
    print(traceback.format_exc())

