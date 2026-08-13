
# See https://coderzcolumn.com/tutorials/data-science/geoplot-choropleth-maps-python

from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import pandas as pd
import geoplot as gplt
import geoplot.crs as gcrs
import mapclassify as mc
import matplotlib.pyplot as plt


import warnings


def USAStatePopulations(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'USAStatePopulations'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments



    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'geojson', 'us_states_old.json'])
    us_states_geo = gpd.read_file(DataPath)

    print(us_states_geo.head())



    DataPath = os.sep.join([gui.get_my_documents(), 'DataXlCalcNet', 
        'DataExamples', 'MainExamples', 'CSV', 'US_State_Populations.csv'])
    us_state_pop = pd.read_csv(DataPath)

    print(us_state_pop.head())

    us_states_pop = us_states_geo.merge(us_state_pop, left_on="name", right_on="State")

    print(us_states_pop.head())

    with plt.style.context(( "ggplot")):
        ax = us_states_pop.plot("2018 Population",
            figsize=(7.5,5),
            edgecolor="black",)

    #    ax.set_xlim(-172, -66)   # with Alaska and Hawaii
    #    ax.set_ylim(18, 72)      # with Alaska and Hawaii

        ax.set_xlim(-126, -66)   # without Alaska and Hawaii
        ax.set_ylim(24, 50)      # without Alaska and Hawaii

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
        USAStatePopulations()


except Exception:
    import traceback
    print(traceback.format_exc())








