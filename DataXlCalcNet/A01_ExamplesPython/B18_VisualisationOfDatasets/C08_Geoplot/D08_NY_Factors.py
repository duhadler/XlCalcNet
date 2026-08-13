
# See https://residentmario.github.io/geoplot/gallery/plot_nyc_collision_factors.html

from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import geoplot as gplt
import geoplot.crs as gcrs
import matplotlib.pyplot as plt


def NewYorkFactors(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'NewYorkFactors'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    nyc_boroughs = gpd.read_file(gplt.datasets.get_path('nyc_boroughs'))
    nyc_collision_factors = gpd.read_file(gplt.datasets.get_path('nyc_collision_factors'))


    proj = gcrs.AlbersEqualArea(central_latitude=40.7128, central_longitude=-74.0059)
    fig = plt.figure(figsize=(10, 5))
    ax1 = plt.subplot(121, projection=proj)
    ax2 = plt.subplot(122, projection=proj)

    gplt.kdeplot(
        nyc_collision_factors[
            nyc_collision_factors['CONTRIBUTING FACTOR VEHICLE 1'] == "Failure to Yield Right-of-Way"
        ],
        cmap='Reds',
        projection=proj,
        fill=True, thresh=0.05,
        clip=nyc_boroughs.geometry,
        ax=ax1
    )
    gplt.polyplot(nyc_boroughs, zorder=1, ax=ax1)
    ax1.set_title("Failure to Yield Right-of-Way Crashes, 2016")

    gplt.kdeplot(
        nyc_collision_factors[
            nyc_collision_factors['CONTRIBUTING FACTOR VEHICLE 1'] == "Lost Consciousness"
        ],
        cmap='Reds',
        projection=proj,
        fill=True, thresh=0.05,
        clip=nyc_boroughs.geometry,
        ax=ax2
    )
    gplt.polyplot(nyc_boroughs, zorder=1, ax=ax2)
    ax2.set_title("Loss of Consciousness Crashes, 2016")

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
        NewYorkFactors()


except Exception:
    import traceback
    print(traceback.format_exc())



