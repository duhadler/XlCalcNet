
# See https://residentmario.github.io/geoplot/gallery/plot_nyc_collisions_map.html#sphx-glr-gallery-plot-nyc-collisions-map-py

from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import geoplot as gplt
import geoplot.crs as gcrs
import matplotlib.pyplot as plt


def NewYorkCollisions(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'NewYorkCollisions'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    # load the data
    nyc_boroughs = gpd.read_file(gplt.datasets.get_path('nyc_boroughs'))
    nyc_fatal_collisions = gpd.read_file(gplt.datasets.get_path('nyc_fatal_collisions'))
    nyc_injurious_collisions = gpd.read_file(gplt.datasets.get_path('nyc_injurious_collisions'))


    fig = plt.figure(figsize=(10, 5))
    proj = gcrs.AlbersEqualArea(central_latitude=40.7128, central_longitude=-74.0059)
    ax1 = plt.subplot(121, projection=proj)
    ax2 = plt.subplot(122, projection=proj)

    ax1 = gplt.pointplot(
        nyc_fatal_collisions, projection=proj,
        hue='BOROUGH', cmap='Set1',
        edgecolor='white', linewidth=0.5,
        scale='NUMBER OF PERSONS KILLED', limits=(8, 24),
        legend=True, legend_var='scale',
        legend_kwargs={'loc': 'upper left', 'markeredgecolor': 'black'},
        legend_values=[2, 1], legend_labels=['2 Fatalities', '1 Fatality'],
        ax=ax1
    )
    gplt.polyplot(nyc_boroughs, ax=ax1)
    ax1.set_title("Fatal Crashes in New York City, 2016")

    gplt.pointplot(
        nyc_injurious_collisions, projection=proj,
        hue='BOROUGH', cmap='Set1',
        edgecolor='white', linewidth=0.5,
        scale='NUMBER OF PERSONS INJURED', limits=(4, 20),
        legend=True, legend_var='scale',
        legend_kwargs={'loc': 'upper left', 'markeredgecolor': 'black'},
        legend_values=[20, 15, 10, 5, 1],
        legend_labels=['20 Injuries', '15 Injuries', '10 Injuries', '5 Injuries', '1 Injury'],
        ax=ax2
    )
    gplt.polyplot(nyc_boroughs, ax=ax2, projection=proj)
    ax2.set_title("Injurious Crashes in New York City, 2016")


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
        NewYorkCollisions()


except Exception:
    import traceback
    print(traceback.format_exc())


