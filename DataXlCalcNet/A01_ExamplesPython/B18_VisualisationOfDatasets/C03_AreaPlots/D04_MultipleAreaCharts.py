
# See: https://python-graph-gallery.com/255-percentage-stacked-area-chart/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import seaborn as sns
import pandas as pd
import matplotlib.pyplot as plt
 


def MultipleAreaCharts(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MultipleAreaCharts'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    # Create a dataset
    my_count=["France","Australia","Japan","USA","Germany","Congo","China","England","Spain","Greece","Marocco","South Africa","Indonesia","Peru","Chili","Brazil"]
    df = pd.DataFrame({
    "country":np.repeat(my_count, 10),
    "years":list(range(2000, 2010)) * 16,
    "value":np.random.rand(160)
    })
     
    # Create a grid : initialize it
    g = sns.FacetGrid(df, col='country', hue='country', col_wrap=4, )

    # Add the line over the area with the plot function
    g = g.map(plt.plot, 'years', 'value')
     
    # Fill the area with fill_between
    g = g.map(plt.fill_between, 'years', 'value', alpha=0.2).set_titles("{col_name} country")
     
    # Control the title of each facet
    g = g.set_titles("{col_name}")
     
    # Add a title for the whole plot
    plt.subplots_adjust(top=0.92)
    g = g.fig.suptitle('Evolution of the value of stuff in 16 countries')
    fig = plt.gcf()
    fig.tight_layout()


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
        MultipleAreaCharts()


except Exception:
    import traceback
    print(traceback.format_exc())





