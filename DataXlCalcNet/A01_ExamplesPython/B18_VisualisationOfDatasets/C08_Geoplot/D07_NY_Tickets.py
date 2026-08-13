
# See https://residentmario.github.io/geoplot/gallery/plot_nyc_parking_tickets.html

from xlcalcnet import gui
from pathlib import Path
import os
import geopandas as gpd
import geoplot as gplt
import geoplot.crs as gcrs
import matplotlib.pyplot as plt



def NewYorkTickets(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'NewYorkTickets'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    # load the data
    nyc_boroughs = gpd.read_file(gplt.datasets.get_path('nyc_boroughs'))
    tickets = gpd.read_file(gplt.datasets.get_path('nyc_parking_tickets'))

    proj = gcrs.AlbersEqualArea(central_latitude=40.7128, central_longitude=-74.0059)


    def plot_state_to_ax(state, ax):
        gplt.choropleth(
            tickets.set_index('id').loc[:, [state, 'geometry']],
            hue=state, cmap='Blues',
            linewidth=0.0, ax=ax
        )
        gplt.polyplot(
            nyc_boroughs, edgecolor='black', linewidth=0.5, ax=ax
        )


    f, axarr = plt.subplots(2, 2, figsize=(8, 8), subplot_kw={'projection': proj})

    plt.suptitle('Parking Tickets Issued to State by Precinct, 2016', fontsize=12)
    #plt.subplots_adjust(top=0.95)

    plot_state_to_ax('ny', axarr[0][0])
    axarr[0][0].set_title('New York (n=6,679,268)')

    plot_state_to_ax('nj', axarr[0][1])
    axarr[0][1].set_title('New Jersey (n=854,647)')

    plot_state_to_ax('pa', axarr[1][0])
    axarr[1][0].set_title('Pennsylvania (n=215,065)')

    plot_state_to_ax('ct', axarr[1][1])
    axarr[1][1].set_title('Connecticut (n=126,661)')

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
        NewYorkTickets()


except Exception:
    import traceback
    print(traceback.format_exc())

