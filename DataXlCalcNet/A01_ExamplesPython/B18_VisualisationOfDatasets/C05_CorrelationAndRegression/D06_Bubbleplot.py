
# See: https://python-graph-gallery.com/bubble-plot-with-seaborn/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd



def Bubbleplot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Bubbleplot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    gapminder = pd.read_csv(
        'https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/gapminderData.csv'
    )
    data = gapminder.loc[gapminder.year == 2007]

    sns.set_theme(style="darkgrid")

    # use the scatterplot function to build the bubble map
    sns.set_theme(style="darkgrid")



    # use the scatterplot function
    sns.scatterplot(
        data=data,
        x="gdpPercap",
        y="lifeExp",
        size="pop",
        hue="continent",
        alpha=0.5,
        sizes=(20, 400)
    )



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
        Bubbleplot()


except Exception:
    import traceback
    print(traceback.format_exc())


