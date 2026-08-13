
#https://python-graph-gallery.com/web-choropleth-map-with-histogram/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import geopandas as gpd
import pandas as pd
from pyfonts import load_google_font
from pypalettes import load_cmap



def USSalary(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'USSalary'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    path = "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/refs/heads/master/static/data/usa-salary.csv"
    df_salary = pd.read_csv(path)

    path = "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/refs/heads/master/static/data/us.geojson"
    gdf = gpd.read_file(path).merge(df_salary, on="state")

    gdf = gdf[gdf["salary"] < 100]  # remove district of columbia
    gdf = gdf[gdf["state"] != "Alaska"]
    gdf = gdf[gdf["state"] != "Hawaii"]
    print(gdf.head())

    gdf_projected = gdf.to_crs(epsg=3035)
    gdf_projected["centroid"] = gdf_projected.geometry.centroid
    gdf["centroid"] = gdf_projected["centroid"].to_crs(gdf.crs)
    print(gdf.head())


    cmap = load_cmap("enara", cmap_type="continuous", reverse=True)
    edgecolor = "white"
    linewidth = 0

    fig, ax = plt.subplots(figsize=(8, 6), dpi=96)


    exclude = {
        "Indiana",
        "Michigan",
        "Mississippi",
        "Florida",
        "New Jersey",
        "West Virginia",
        "South Carolina",
        "Louisiana",
        "Massachusetts",
        "Vermont",
        "Connecticut",
        "Maryland",
        "Delaware",
        "Rhode Island",
        "New Hampshire",
    }
    states_to_annotate = [state for state in gdf.state.to_list() if state not in exclude]

    adjustments = {
        "California": (0, -1),
        "Kentucky": (0, -0.2),
        "Washington": (0.5, -0.4),
        "Virginia": (0, -0.2),
        "Idaho": (0, -0.4),
        "New York": (0, -0.2),
    }

#    for state in states_to_annotate:
#        centroid = gdf.loc[gdf["state"] == state, "centroid"].values[0]
#        x_val, y_val = centroid.coords[0]
#        try:
#            x_val += adjustments[state][0]
#            y_val += adjustments[state][1]
#        except KeyError:
#            pass
#        value = gdf.loc[gdf["state"] == state, "salary"].values[0]
#        if value <= 65:
#            color_text = "black"
#        else:
#            pass
#            color_text = "white"
#        ax.text(
#            x=x_val,
#            y=y_val,
#            s=f"{state.upper()}\n${value:.0f}k",
#            fontsize=5,
#            #font=font2,
#            color=color_text,
#            ha="center",
#            va="center",
#        )


    #Add last annotations
    #The title, credit and source annotations are added via the fig.text() function at the end:

    font1 = load_google_font("Ubuntu", italic=True)
    font2 = load_google_font("Ubuntu")
    cmap = load_cmap("enara", cmap_type="continuous", reverse=True)
    edgecolor = "white"
    linewidth = 0
    text_color = "white"

    gdf.plot(ax=ax, column="salary", cmap=cmap, edgecolor=edgecolor, linewidth=linewidth)

    ax.set_xlim(-130, -65)
    ax.set_ylim(20, 50)
    ax.axis("off")

    bar_ax = ax.inset_axes(bounds=[0.05, -0.05, 0.5, 0.4], zorder=-1)
    n, bins, _ = bar_ax.hist(gdf["salary"], bins=15, alpha=0)
    colors = [cmap((val - min(bins)) / (max(bins) - min(bins))) for val in bins]
    bar_ax.bar(
        bins[:-1], n, color=colors, width=2, edgecolor=edgecolor, linewidth=linewidth
    )
    bar_ax.spines[["top", "left", "right"]].set_visible(False)
    bar_ax.set_yticks([])
    x_ticks = list(range(50, 90, 10))
    x_tick_labels = [f"{val}k" for val in x_ticks]
    bar_ax.set_xticks(x_ticks, labels=x_tick_labels, size=8, font=font2)
    bar_ax.tick_params(axis="x", length=0, pad=5)

    exclude = {
        "Indiana",
        "Michigan",
        "Mississippi",
        "Florida",
        "New Jersey",
        "West Virginia",
        "South Carolina",
        "Louisiana",
        "Massachusetts",
        "Vermont",
        "Connedgecolorticut",
        "Maryland",
        "Delaware",
        "Rhode Island",
        "New Hampshire",
    }
    states_to_annotate = [state for state in gdf.state.to_list() if state not in exclude]

    adjustments = {
        "California": (0, -1),
        "Kentucky": (0, -0.2),
        "Washington": (0.5, -0.4),
        "Virginia": (0, -0.2),
        "Idaho": (0, -0.4),
        "New York": (0, -0.2),
    }

    for state in states_to_annotate:
        centroid = gdf.loc[gdf["state"] == state, "centroid"].values[0]
        x_val, y_val = centroid.coords[0]
        try:
            x_val += adjustments[state][0]
            y_val += adjustments[state][1]
        except KeyError:
            pass
        value = gdf.loc[gdf["state"] == state, "salary"].values[0]
        if value <= 65:
            color_text = "black"
        else:
            color_text = text_color
        ax.text(
            x=x_val,
            y=y_val,
            s=f"{state.upper()}\n${value:.0f}k",
            fontsize=5,
            font=font2,
            color=color_text,
            ha="center",
            va="center",
        )

    fig.text(
        x=0.5,
        y=0.9,
        s="Average salary in the United States in 2025",
        ha="center",
        size=22,
        font=load_google_font("Roboto Slab"),
    )

    fig.tight_layout()


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
        USSalary()


except Exception:
    import traceback
    print(traceback.format_exc())






