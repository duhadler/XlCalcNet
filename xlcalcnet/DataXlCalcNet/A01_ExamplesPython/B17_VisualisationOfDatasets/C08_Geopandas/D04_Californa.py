
# See https://residentmario.github.io/geoplot/gallery/plot_california_districts.html#sphx-glr-gallery-plot-california-districts-py


from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import geoplot as gplt
import geoplot.crs as gcrs
import mapclassify as mc
import matplotlib.pyplot as plt


import warnings



def California(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'California'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    warnings.filterwarnings('ignore')

    fsize = 12


    cali = gpd.read_file(gplt.datasets.get_path('california_congressional_districts'))
    cali = cali.assign(area=cali.geometry.area)


    proj = gcrs.AlbersEqualArea(central_latitude=37.16611, central_longitude=-119.44944)
    fig, axarr = plt.subplots(2, 2, figsize=(8, 8), subplot_kw={'projection': proj})

    gplt.choropleth(
        cali, hue='area', linewidth=0, scheme=None, ax=axarr[0][0]
    )
    axarr[0][0].set_title('scheme=None', fontsize=fsize)

    scheme = mc.Quantiles(cali.area, k=5)
    gplt.choropleth(
        cali, hue='area', linewidth=0, scheme=scheme, ax=axarr[0][1]
    )
    axarr[0][1].set_title('scheme="Quantiles"', fontsize=fsize)

    scheme = mc.EqualInterval(cali.area, k=5)
    gplt.choropleth(
        cali, hue='area', linewidth=0, scheme=scheme, ax=axarr[1][0]
    )
    axarr[1][0].set_title('scheme="EqualInterval"', fontsize=fsize)

    scheme = mc.FisherJenks(cali.area, k=5)
    gplt.choropleth(
        cali, hue='area', linewidth=0, scheme=scheme, ax=axarr[1][1]
    )
    axarr[1][1].set_title('scheme="FisherJenks"', fontsize=fsize)

    #plt.subplots_adjust(top=0.92)
    plt.suptitle('California State Districts by Area, 2010', fontsize=18)


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
        California()


except Exception:
    import traceback
    print(traceback.format_exc())




