
# https://python-graph-gallery.com/web-choropleth-map-with-barplot/
from xlcalcnet import gui
from pathlib import Path
import os
import pandas as pd
import cartopy.crs as ccrs
import geopandas as gpd
import matplotlib.pyplot as plt
from pypalettes import create_cmap
#from pyfonts import load_google_font
import unicodedata



def Belgium(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Belgium'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 5
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    def remove_accents(text):
        return "".join(
            c if not unicodedata.combining(c) else ""
            for c in unicodedata.normalize("NFKD", text)
        )


    belgium = gpd.read_file(
        "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/refs/heads/master/static/data/belgium.json",
        layer="municipalities",
    ).drop(
        columns=[
            "prov_nis",
            "prov_fr",
            "prov_nl",
            "arr_nis",
            "id",
            "reg_nis",
            "reg_nl",
            "reg_fr",
            "arr_fr",
            "arr_nl",
            "nis",
        ]
    )
    belgium["name_nl"] = belgium["name_nl"].apply(remove_accents).str.lower()

    rates = pd.read_csv(
        "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/refs/heads/master/static/data/belgium-unemployment.csv"
    )
    rates["Gemeente"] = rates["Gemeente"].apply(remove_accents).str.lower()

    df = belgium.merge(rates, left_on="name_nl", right_on="Gemeente", how="left")

    projection = ccrs.Mercator()
    df.crs = "EPSG:4326"
    df = df.to_crs(projection.proj4_init)
    print(df.head())

    #regular = load_google_font("Roboto")
    #bold = load_google_font("Roboto", weight="bold")


    cmap = create_cmap(
        colors=[
            "#5A1A74",
            "#661d5c",
            "#86277A",
            "#9D2D7A",
            "#C74370",
            "#FB9A70",
            "#FDC48C",
            "#FED69A",
            "#FCFCBD",
        ][::-1],
        cmap_type="continuous",
        name="Sunset3",
    )

    fig, ax = plt.subplots(figsize=(8, 8), subplot_kw={"projection": projection}, dpi=96)
    ax.axis("off")

    df.plot(ax=ax, column="Werkloosheidsgraad", cmap=cmap, edgecolor="#e6e6e6", lw=0.3)

    # Add barplot
    bar_ax = ax.inset_axes(bounds=[0.05, 0.15, 0.4, 0.3], zorder=-1)
    n, bins, _ = bar_ax.hist(df["Werkloosheidsgraad"], bins=18, alpha=0)
    colors = [cmap((val - min(bins)) / (max(bins) - min(bins))) for val in bins]
    bar_ax.bar(bins[:-1], n, color=colors)
    bar_ax.spines[["top", "left", "right"]].set_visible(False)
    bar_ax.set_yticks([])
    x_ticks = list(range(0, 19, 3))
    bar_ax.set_xticks(x_ticks, labels=["0", "3", "6", "9", "12", "15", "18%"], size=8)
    bar_ax.tick_params(axis="x", length=2)

    #fig.text(x=0.2, y=0.89, s="Unemployment rate in Belgium", size=12, font=bold)
    #fig.text(x=0.2, y=0.86, s="By municipality, in December 2024", size=8, font=regular)
    fig.text(x=0.2, y=0.89, s="Unemployment rate in Belgium", size=12)
    fig.text(x=0.2, y=0.86, s="By municipality, in December 2024", size=8)
    fig.text(
        x=0.2,
        y=0.13,
        s="Map: Koen Van den Eeckhout · Source: RVA (Interactive Statistics)",
        size=6,
        color="#909090",
        #font=regular,
    )

    fig.tight_layout()

    #plt.show()


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
        Belgium()


except Exception:
    import traceback
    print(traceback.format_exc())

