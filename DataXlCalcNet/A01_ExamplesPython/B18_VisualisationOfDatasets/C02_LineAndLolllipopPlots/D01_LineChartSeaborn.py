
# See: https://python-graph-gallery.com/501-parallel-plot-seaborn/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd


def ParallelPlotSeaborn(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ParallelPlotSeaborn'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    url = "https://raw.githubusercontent.com/jennybc/gapminder/master/data-raw/08_gap-every-five-years.tsv"
    df = pd.read_csv(url, sep='\t')


    # Calculate the average values for each continent
    average_data = df.groupby('continent')[['gdpPercap', 'lifeExp', 'pop']].mean()

    # Normalize the data for better visualization
    normalized_data = (average_data - average_data.mean()) / average_data.std()

    # Create parallel plot
    plt.figure(figsize=(8, 6))
    parallel_plot = sns.lineplot(data=normalized_data.transpose(),
                                 dashes=False,
                                 markers=True,
                                 markersize=8)

    # Add title
    plt.title('Parallel Plot \nAverage GDP, Life Expectancy, and Population by Continent')

    # Remove y-axis ticks and tick labels
    plt.yticks([])

    # Add legend
    plt.legend(title='Continent',
               bbox_to_anchor=(1, 1), # Shift legend to the right
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
        ParallelPlotSeaborn()


except Exception:
    import traceback
    print(traceback.format_exc())



