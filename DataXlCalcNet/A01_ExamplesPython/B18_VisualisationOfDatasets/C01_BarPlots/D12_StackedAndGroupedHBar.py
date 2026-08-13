
# See: https://stackoverflow.com/questions/74037490/stacked-and-grouped-horizontal-bar-plot-in-python

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt


def StackedAndGroupedHBar(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedAndGroupedHBar'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


# Source - https://stackoverflow.com/a/74045490
# Posted by Redox
# Retrieved 2026-03-04, License - CC BY-SA 4.0

    # Your data, some changes to differentiate the values
    female_numbers_2015 = [20882, 31322, 52204, 52205, 31322, 20881]
    female_numbers_2018 = [20882, 31322, 52204, 52205, 31322, 20881]
    male_numbers_2015 = [13352, 15080, 24380, 32380, 15028, 13351]
    male_numbers_2018 = [14454, 14181, 30636, 26634, 12181, 16454]

    # Percentage calculation corrected. Need to just divide each entry by sum(vals)
    percent_males_2015 = [i /sum(male_numbers_2015) * 100 for i in male_numbers_2015]
    percent_females_2015 = [i /sum(female_numbers_2015) * 100 for i in female_numbers_2015]
    percent_males_2018 = [i /sum(male_numbers_2018) * 100 for i in male_numbers_2018]
    percent_females_2018 = [i /sum(female_numbers_2018) * 100 for i in female_numbers_2018]

    myindex = ['Poorest 10%', '10-25%', '25-50%', '50-75%', '75-90%', 'Richest 10%']

    # Source - https://stackoverflow.com/a/74045490
    # Posted by Redox
    # Retrieved 2026-03-04, License - CC BY-SA 4.0

    Year = []
    Female = []
    Male = []

    Year=['2015']*len(percent_females_2015)
    Year=Year+['2018']*len(percent_females_2018)

    Female=percent_females_2015+percent_females_2018
    Male=percent_males_2015+percent_males_2018

    df=pd.DataFrame({'index':myindex*2, 'Year':Year, 'Female':Female, 'Male':Male})

    df.set_index(['Year', 'index'], inplace=True)
    df0 = df.reorder_levels(['index', 'Year']).sort_index()
    df0 = df0.unstack(level=-1)

    # Source - https://stackoverflow.com/a/74045490
    # Posted by Redox
    # Retrieved 2026-03-04, License - CC BY-SA 4.0

    colors = plt.cm.Paired.colors
    fig, ax = plt.subplots(figsize=(10,5))
    (df0['Female']+df0['Male']).plot(kind='barh', color=[colors[3], colors[2]], rot=0, ax=ax)
    df0['Male'].plot(kind='barh', color=[colors[5], colors[4]], rot=0, ax=ax)

    legend_labels = [f'{val} ({context})' for val, context in df0.columns]
    ax.legend(legend_labels)

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
        StackedAndGroupedHBar()


except Exception:
    import traceback
    print(traceback.format_exc())


