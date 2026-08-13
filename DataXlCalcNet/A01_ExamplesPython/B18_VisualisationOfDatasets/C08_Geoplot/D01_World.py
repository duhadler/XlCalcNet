
# See: https://coderzcolumn.com/tutorials/data-science/plotting-static-maps-with-geopandas-working-with-geospatial-data

from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib as mpl


def WorldHappinessReport2019(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'WorldHappinessReport2019'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

#    Item = 'Score'
#    ItemLabel  = 'Happiness score by country'
#    ItemCmap = mpl.colormaps['viridis']

#    Item = 'GDPPerCapita'
#    ItemLabel  = 'GDP per capita by country'
#    ItemCmap = mpl.colormaps['OrRd']

#    Item = 'SocialSupport'
#    ItemLabel  = 'Social support'
#    ItemCmap = mpl.colormaps['winter']

#    Item = 'HealthyLifeExpectancy'
#    ItemLabel  = 'Healthy life expectancy'
#    ItemCmap = mpl.colormaps['autumn']

#    Item = 'FreedomToMakeLifeChoices'
#    ItemLabel  = 'Freedom to make life choices'
#    ItemCmap = mpl.colormaps['Greens']

#    Item = 'Generosity'
#    ItemLabel  = 'Generosity score by country'
#    ItemCmap = mpl.colormaps['summer']

    Item = 'PerceptionsOfCorruption'
    ItemLabel  = 'Perceptions of corruption'
    ItemCmap = mpl.colormaps['hot']


# End of custom key word arguments


    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'geojson', 'all_world.geojson'])
    world = gpd.read_file(DataPath)
    world = world[(world.name != 'Antarctica') 
        & (world.name != 'Fr. S. Antarctic Lands')]

    print(world.head())

    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'CSV', 'world_happiness_2019.csv'])
    world_happiness = pd.read_csv(DataPath)

    print('Dataset Size : ',world_happiness.shape)
    world_happiness.head()


    world_happiness_final = world.merge(world_happiness, how='left', 
        left_on=['name'], right_on=['Country'])
    print('Type of DataFrame : ', type(world_happiness_final))
    print(world_happiness_final.head())

    with  plt.style.context(PlotStyle):
        ax = world_happiness_final.plot(
            Item, 
            figsize=(FigSizeX, FigSizeY),
            edgecolor='black',
            cmap=ItemCmap,
            legend=True,
            legend_kwds={
                'label': ItemLabel, 
                'shrink':.8
                #'loc':'lower left',
                #'title_fontsize':'medium', 
                #'fontsize':'small'
            },
            #cmap=plt.cm.BrBG,
            missing_kwds={
               'color':'grey',
               'edgecolor':'black',
               'hatch':'---',
               'label':'Missing Values'
            }
            )
        plt.title(Title);

    plt.tight_layout()
    fig = plt.gcf()

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
        WorldHappinessReport2019()


except Exception:
    import traceback
    print(traceback.format_exc())


