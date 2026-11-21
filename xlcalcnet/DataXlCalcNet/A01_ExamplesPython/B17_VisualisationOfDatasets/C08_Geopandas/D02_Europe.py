
# See: https://coderzcolumn.com/tutorials/data-science/plotting-static-maps-with-geopandas-working-with-geospatial-data


from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import matplotlib as mpl


def WHReport2019Europe(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'WHReport2019Europe'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    Item = 'Score'
    ItemLabel  = 'Happiness score by country'
    ItemCmap = mpl.colormaps['viridis']

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

#    Item = 'PerceptionsOfCorruption'
#    ItemLabel  = 'Perceptions of corruption'
#    ItemCmap = mpl.colormaps['hot']

# End of custom key word arguments


    FromNaturalEarth = False
    if FromNaturalEarth:
        url = 'https://naciscdn.org/naturalearth/10m/cultural/ne_10m_admin_0_countries.zip'
        #url = 'https://naciscdn.org/naturalearth/50m/cultural/ne_50m_admin_0_countries.zip'
        #url = 'https://naciscdn.org/naturalearth/110m/cultural/ne_110m_admin_0_countries.zip'
        world = gpd.read_file(url).rename({'ADMIN': 'name'}, axis='columns')
        europe = world[world['CONTINENT'] == 'Europe']
    else:
        DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
            'DataExamples', 'MainExamples', 'geojson', 'europe.geojson'])
        europe = gpd.read_file(DataPath)

    print(europe.head())

    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
#        'DataExamples', 'MainExamples', 'CSV', 'World_Happiness_Report.csv'])
        'DataExamples', 'MainExamples', 'CSV', 'world_happiness_2019.csv'])
    europe_happiness = pd.read_csv(DataPath)

    print('Dataset Size : ',europe_happiness.shape)
    europe_happiness.head()


    europe_happiness_final = europe.merge(europe_happiness, how='left', left_on=['name'], right_on=['Country'])
    print('Type of DataFrame : ', type(europe_happiness_final))
    print(europe_happiness_final.head())

    with  plt.style.context(PlotStyle):
        ax = europe_happiness_final.plot(
            Item, 
            figsize=(FigSizeX, FigSizeY),
            edgecolor='black',
            cmap=ItemCmap,
            legend=True,
            legend_kwds={'label': ItemLabel},
            missing_kwds={
               'color':'grey',
               'edgecolor':'black',
               'hatch':'---',
               'label':'Missing Values'
            }
        )
        ax.set_xlim(-12, 42)
        ax.set_ylim(34, 72)
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
        WHReport2019Europe()


except Exception:
    import traceback
    print(traceback.format_exc())



