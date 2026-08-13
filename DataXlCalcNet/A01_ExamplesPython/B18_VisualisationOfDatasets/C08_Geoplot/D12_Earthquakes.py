
# https://python-graph-gallery.com/web-bubble-map-with-arrows/
from xlcalcnet import gui
from pathlib import Path
import os
# data manipulation
import numpy as np
import pandas as pd
import geopandas as gpd

# visualization
import matplotlib.pyplot as plt
from matplotlib import font_manager
from matplotlib.font_manager import FontProperties
from highlight_text import fig_text, ax_text
from matplotlib.patches import FancyArrowPatch

# geospatial manipulation
import cartopy.crs as ccrs
import cartopy.feature as cfeature
import geoplot
import geoplot.crs as gcrs



def EarthQuakes(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EarthQuakes'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    def draw_arrow(tail_position, head_position, invert=False, radius=0.5, color='black', fig=None):
       if fig is None:
          fig = plt.gcf()
       kw = dict(arrowstyle="Simple, tail_width=0.5, head_width=4, head_length=8", color=color, lw=0.5)
       if invert:
          connectionstyle = f"arc3,rad=-{radius}"
       else:
          connectionstyle = f"arc3,rad={radius}"
       a = FancyArrowPatch(
          tail_position, head_position,
          connectionstyle=connectionstyle,
          transform=fig.transFigure,
          **kw
       )
       fig.patches.append(a)


    proj = ccrs.Mercator()

    url = "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/all_world.geojson"
    world = gpd.read_file(url)
    world = world[~world['name'].isin(["Antarctica", "Greenland"])]
    world = world.to_crs(proj.proj4_init)
    world.head()


    #Load data
    url = "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/earthquakes.csv"
    df = pd.read_csv(url)

    # Filter dataset: big earth quakes only
    df = df[df['Depth (km)']>=0.01] # depth of at least 10 meters

    # Sort: big bubbles must be below small bubbles for visibility
    df.sort_values(by='Depth (km)', ascending=False, inplace=True)

    print(df.head())

    # colors
    background_color = '#14213d'
    map_color = (233/255, 196/255, 106/255, 0.2)
    bubble_color = '#fefae0'

    # initialize the figure
    proj = ccrs.Mercator()
    fig, ax = plt.subplots(figsize=(10, 8), dpi=96, subplot_kw={'projection':proj})
    fig.set_facecolor(background_color)
    ax.set_facecolor(background_color)
    ax.set_axis_off()

    # background map
    world.boundary.plot(ax=ax, linewidth=0, facecolor=map_color)

    # transform the coordinates to the projection's CRS
    pc = ccrs.PlateCarree()
    new_coords = proj.transform_points(pc, df['Longitude'].values, df['Latitude'].values)

    # bubble on top of the map
    ax.scatter(
       new_coords[:, 0], new_coords[:, 1],
       s=df['Depth (km)']/3,
       color=bubble_color,
       linewidth=0.4,
       edgecolor='grey',
       alpha=0.6,
       zorder=10,
    )


    # title
    fig_text(
    #   x=0.5, y=0.98, s='Earthquakes around the world',
    #   color='white', fontsize=30, ha='center', va='top', font=font,
    #   alpha=alpha_text

       x=0.5, y=0.98, s='Earthquakes around the world',
       color='white', fontsize=20, ha='center', va='top'

    )

    # subtitle
    fig_text(
       x=0.5, y=0.92, s='Earthquakes 2015 - 2024. Size of dots is proportionnal to earthquake depth.',
       color='white', fontsize=14, ha='center', va='top'
    )

    alpha_text = 0.7

    # nazaca plate
    highlight_textprops = [
       {"bbox": {"facecolor": "black", "pad": 2, "alpha": 1}, "alpha": alpha_text},
       {"bbox": {"facecolor": "black", "pad": 2, "alpha": 1}, "alpha": alpha_text}
    ]
    draw_arrow((0.23, 0.27), (0.37, 0.35), fig=fig, color='white', invert=True, radius=0.2)
    fig_text(x=0.16, y=0.265, s='<Collisions between Nazca Plate>\n<and South American plate>', 
        fontsize=10, color='white', highlight_textprops=highlight_textprops, zorder=100)

    # india plate
    draw_arrow((0.69, 0.64), (0.64, 0.55), fig=fig, color='white', radius=0.4)
    fig_text(x=0.7, y=0.66, s='<Collisions between Eurasian plate>\n<and Indian plate>', 
        fontsize=10, color='white', highlight_textprops=highlight_textprops, zorder=100)

    # philippine plate
    draw_arrow((0.73, 0.22), (0.8, 0.51), fig=fig, color='white', radius=0.6)
    fig_text(x=0.54, y=0.22, s='<Collisions between Philippine plate>\n<and Eurasian plate>', 
        fontsize=10, color='white', highlight_textprops=highlight_textprops, zorder=100)

    plt.tight_layout()

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
        EarthQuakes()


except Exception:
    import traceback
    print(traceback.format_exc())





