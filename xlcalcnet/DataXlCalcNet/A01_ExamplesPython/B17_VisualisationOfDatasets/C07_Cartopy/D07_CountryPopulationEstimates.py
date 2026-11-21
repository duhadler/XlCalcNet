from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt

import cartopy.crs as ccrs

import matplotlib.colors as mcolors
import matplotlib.pyplot as plt

import cartopy.crs as ccrs
import cartopy.io.shapereader as shpreader


def CountryPopulationEstimates(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CountryPopulationEstimates'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # Load Natural Earth's country shapefiles.
    shpfilename = shpreader.natural_earth(resolution='110m',
                                          category='cultural',
                                          name='admin_0_countries')
    reader = shpreader.Reader(shpfilename)
    countries = reader.records()

    # Get hold of the geometry and population estimate from each country's record.
    geometries = []
    population_estimates = []

    for country in countries:
        geometries.append(country.geometry)
        population_estimates.append(country.attributes['POP_EST'])

    # Set up a figure and an axes with the Eckert VI projection.
    fig = plt.figure()
    ax = fig.add_subplot(projection=ccrs.EckertVI())

    # Plot the geometries coloured according to population estimate.
    art = ax.add_geometries(geometries, crs=ccrs.PlateCarree(),
                            array=population_estimates, cmap='YlGnBu',
                            norm=mcolors.LogNorm(vmin=1e6))
    cbar = fig.colorbar(art, orientation='horizontal', extend='min')
    cbar.set_label('Number of people')
    fig.suptitle('Country Population Estimates', fontsize='x-large')

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
        CountryPopulationEstimates()


except Exception:
    import traceback
    print(traceback.format_exc())

