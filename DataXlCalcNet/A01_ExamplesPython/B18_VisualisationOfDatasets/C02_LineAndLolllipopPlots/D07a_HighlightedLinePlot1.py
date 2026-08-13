
# See: https://python-graph-gallery.com/web-highlighted-lineplot-with-faceting/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd

from scipy.stats import rankdata



def HighlightedLinePlot1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'HighlightedLinePlot1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    data_raw = pd.read_csv(
        "https://raw.githubusercontent.com/rfordatascience/tidytuesday/master/data/2021/2021-05-04/water.csv")

    data = (
        data_raw
        .dropna(subset=["install_year", "country_name"])
        .assign(
            install_decade=(data_raw["install_year"] // 10) * 10,
        )
        .query("1970 <= install_decade <= 2020")
    )

    data["nb_install"] = data.groupby(["country_name", "install_decade"])[
        "country_name"].transform("size")

    data_pivoted = pd.pivot_table(
        data, index="country_name", values="nb_install", columns="install_decade"
    ).dropna().reset_index()

    data = pd.melt(data_pivoted, id_vars="country_name",
                   value_name="nb_install", var_name="decade")

    data["country_name"] = data["country_name"].str.upper()
    data["rank"] = data.groupby(
        "decade")["nb_install"].transform(lambda x: rankdata(-x))
    data = data.sort_values(["country_name", "decade"])


    COUNTRIES = data["country_name"].unique()
    COUNTRY = COUNTRIES[0]
    # Initialize figure and axis
    fig, ax = plt.subplots(figsize=(9, 6))

    # From annotations in the original plot we see we have to invert vertical axis
    ax.invert_yaxis()

    # Loop through countries
    for country in COUNTRIES:
        # Filter data to keep rows of the country
        d = data[data["country_name"] == country]
        x = d["decade"].values
        y = d["rank"].values

        # If the country is the selected country, use a thicker blue line and a dot with border
        if country == COUNTRY:
            ax.plot(x, y, color="#0b53c1", lw=2.4, zorder=10)
            ax.scatter(x, y, fc="w", ec="#0b53c1", s=60, lw=2.4, zorder=12)
        # If not, use a gray and thinner line
        else:
            ax.plot(x, y, color="#BFBFBF", lw=1.5)

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
        HighlightedLinePlot1()


except Exception:
    import traceback
    print(traceback.format_exc())





