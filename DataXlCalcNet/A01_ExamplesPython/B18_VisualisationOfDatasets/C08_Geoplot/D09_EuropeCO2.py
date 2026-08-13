
# https://python-graph-gallery.com/web-bubble-map-with-arrows/
from xlcalcnet import gui
from pathlib import Path
import os

import pandas as pd
import geopandas as gpd
import matplotlib.pyplot as plt
from pypalettes import load_cmap
from drawarrow import fig_arrow
from pyfonts import load_google_font

from highlight_text import fig_text, ax_text




def EuropeCO2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EuropeCO2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    url = "https://raw.githubusercontent.com/holtzy/the-python-graph-gallery/master/static/data/europe.geojson"
    world = gpd.read_file(url)
    print(world.head())

    url = "https://raw.githubusercontent.com/holtzy/the-python-graph-gallery/master/static/data/co2PerCapita.csv"
    df = pd.read_csv(url)

    # merge data
    data = world.merge(df, how="left", left_on="name", right_on="Country")

    # filter to keep only specific countries
    data = data[data["continent"] == "Europe"]
    data = data[~data["name"].isin(["Russia", "Iceland"])]
    data = data[data["Year"] == 2021]
    data = data[["name", "Total", "geometry"]]
    data = data.dropna()
    print(data.head())


    # load the colormap
    cmap = load_cmap("BrwnYl", cmap_type="continuous")
    background_color = "white"
    text_color = "black"

    value_ranges = [1, 3, 5, 7, 9, 11, 13, 15]
    labels = ["0-2 t", "2-4 t", "4-6 t", "6-8 t", "8-10 t", "10-12 t", "12+ t"]

    # load the font
    font = load_google_font("Bebas Neue")
    other_font = load_google_font("Fira Sans", weight="light")
    other_bold_font = load_google_font("Fira Sans", weight="medium")

    # arrow properties
    arrow_props = dict(width=0.5, head_width=4, head_length=8, color="black")

    # initialize the figure
    fig, ax = plt.subplots(figsize=(10, 10), dpi=96)
    #fig, ax = plt.subplots(figsize=(3, 3), dpi=300)
    fig.set_facecolor(background_color)

    # create the plot
    data.plot(ax=ax, column="Total", cmap=cmap, edgecolor="black", linewidth=0.5)

    # custom axis
    ax.set_xlim(-11, 41)
    ax.set_ylim(32, 73)
    ax.set_axis_off()

    # define range and values for the legend
    value_ranges = [1, 3, 5, 7, 9, 11, 13, 15]
    labels = ["0-2 t", "2-4 t", "4-6 t", "6-8 t", "8-10 t", "10-12 t", "12+ t"]

    # parameters of the legend
    rectangle_width = 2
    rectangle_height = 1.5
    legend_x = 35
    legend_y_start = 65
    legend_y_step = 1.5

    # create the legend
    for i in range(len(labels)):
        value = (
            (value_ranges[i] + value_ranges[i + 1]) / 2 / value_ranges[-1]
        )  # Normalize the value to [0, 1]
        color = cmap(value)
        ax.add_patch(
            plt.Rectangle(
                (legend_x, legend_y_start - i * legend_y_step),
                rectangle_width,
                rectangle_height,
                color=color,
                ec="black",
                lw=0.6,
            )
        )
        ax.text(
            legend_x + 2.5,
            legend_y_start - i * legend_y_step + 0.7,
            labels[i],
            fontsize=12,
            fontproperties=other_font,
            color=text_color,
            va="center",
        )

    # compute centroids and display the total
    adjustments = {
        "France": (10, 3),
        "Italy": (-2.4, 2.5),
        "Finland": (0, -2),
        "Belarus": (0, -0.4),
        "Ireland": (0, -1),
        "Germany": (-0.2, 0),
        "Poland": (0, 0.2),
        "Sweden": (-1.2, -2.8),
        "United Kingdom": (1, -1.5),
        "Norway": (-4, -5.5),
    }
    data_projected = data.to_crs(epsg=3035)
    data_projected["centroid"] = data_projected.geometry.centroid
    data["centroid"] = data_projected["centroid"].to_crs(data.crs)
    countries_to_annotate = data["name"].tolist()
    countries_to_annotate = [
        "France",
        "Italy",
        "Romania",
        "Poland",
        "Finland",
        "Ukraine",
        "Spain",
        "Germany",
        "Sweden",
        "United Kingdom",
        "Belarus",
        "Norway",
    ]
    for country in countries_to_annotate:
        centroid = data.loc[data["name"] == country, "centroid"].values[0]
        x, y = centroid.coords[0]
        try:
            x += adjustments[country][0]
            y += adjustments[country][1]
        except KeyError:
            pass
        rate = data.loc[data["name"] == country, "Total"].values[0]
        if country == "United Kingdom":
            country = "UK"
        if rate > 7:
            color_text = "white"
        else:
            color_text = text_color
        ax_text(
            x=x,
            y=y,
            s=f"<{country.upper()}>: {rate:.2f}",
            fontsize=9,
            font=other_font,
            color=color_text,
            ha="center",
            va="center",
            ax=ax,
            highlight_textprops=[{"font": other_bold_font}],
        )

    # title
    fig_text(
        s="CO2 emissions per capita in Europe (2021)",
        x=0.5,
        y=0.11,
        color=text_color,
        fontsize=25,
        font=font,
        ha="center",
        va="top",
        ax=ax,
    )

    # subtitle
    fig_text(
        s="<Unit>: metric tons | <Data>: zenodo.org | <Viz>: barbierjoseph.com",
        x=0.5,
        y=0.075,
        color=text_color,
        fontsize=14,
        font=other_font,
        ha="center",
        va="top",
        ax=ax,
        highlight_textprops=[
            {"font": other_bold_font},
            {"font": other_bold_font},
            {"font": other_bold_font},
        ],
    )

    # arrows for the Luxembourg
    luxembourg_values = data.loc[data["name"] == "Luxembourg", "Total"].values[0]
    fig_arrow(
        tail_position=(0.32, 0.7), head_position=(0.375, 0.45), radius=0.3, **arrow_props
    )
    fig_text(
        s=f"<LUXEMBOURG>: {luxembourg_values:.2f}",
        x=0.32,
        y=0.71,
        highlight_textprops=[{"font": other_bold_font}],
        color=text_color,
        fontsize=9,
        font=other_font,
        ha="center",
        va="center",
        fig=fig,
    )

    # display the plot
    #plt.savefig("../../static/graph/web-map-with-custom-legend.png", dpi=300)

    fig = plt.gcf()
    fig.tight_layout()

    #plt.show()


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
        EuropeCO2()


except Exception:
    import traceback
    print(traceback.format_exc())






