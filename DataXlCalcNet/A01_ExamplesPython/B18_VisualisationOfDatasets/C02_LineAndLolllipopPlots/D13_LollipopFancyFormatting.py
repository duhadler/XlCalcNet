
# See: https://python-graph-gallery.com/web-lollipop-with-colormap-and-arrow/

from xlcalcnet import gui
from pathlib import Path
import os
import pandas as pd
import matplotlib.pyplot as plt
from pypalettes import load_cmap
from pyfonts import load_google_font
from highlight_text import ax_text
from drawarrow import ax_arrow



def LollipopFancyFormatting(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'LollipopFancyFormatting'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    path = "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/temperature-variation.csv"
    df = pd.read_csv(path)

    cmap = load_cmap("Coconut", cmap_type="continuous", reverse=True)
    font = load_google_font("Urbanist", weight="light")
    bold_font = load_google_font("Urbanist", weight="medium")
    arrow_props = dict(color="black", width=0.5, head_width=2, head_length=5, radius=0.1)

    fig, ax = plt.subplots(figsize=(15, 8), dpi=96)
    ax.set_axis_off()

    for i, row in df.iterrows():
        year = row["Year"]
        change = row["Change"]
        color = cmap(change)
        ax.scatter(x=year, y=change, color=color)
        ax.plot([year, year], [0, change], color=color, alpha=0.8)

        if year % 20 == 0:
            ax.text(x=year, y=-0.6, s=f"{year:.0f}", font=font, size=15, ha="left")
    ax.text(x=1881, y=-0.6, s=f"{1880}", font=font, size=15, ha="left")

    h_lines = [-0.4, 0, 0.4, 0.8]
    ax.hlines(
        y=h_lines,
        xmin=1881,
        xmax=2023,
        colors=[cmap(val) for val in h_lines],
        linewidth=1.2,
        zorder=-1,
        alpha=0.5,
    )
    for value in h_lines:
        ax.text(
            x=1877, y=value, s=f"{value}", font=font, color=cmap(value), size=9, va="center"
        )

    s = "Global Land-Ocean Temperature Index"
    ax_text(x=1881, y=1.1, s=s, font=font, size=35, ha="left")

    s = "Change in global surface temperature compared to the long-term average from 1951 to 1980"
    ax_text(x=1881, y=0.94, s=s, font=font, size=16, ha="left", color="grey", alpha=0.7)

    s = "<Graph>: barbierjoseph.com\n<Data Source>: NASA"
    ax_text(
        x=1881,
        y=-0.7,
        s=s,
        font=font,
        size=8,
        ha="left",
        highlight_textprops=[{"font": bold_font}] * 2,
    )

    s = "Heat waves in Europe\nin the 1940s"
    ax_text(x=1915, y=0.52, s=s, font=font, size=10, ha="left")
    ax_arrow(tail_position=(1927, 0.43), head_position=(1938, 0.2), **arrow_props)

    s = "Beginning of only positive\nvalues in global change"
    ax_text(x=2018, y=-0.2, s=s, font=font, size=10, ha="right")
    ax_arrow(
        tail_position=(1996, -0.22), head_position=(1980, -0.05), invert=True, **arrow_props
    )
    fig.tight_layout()


    #plt.savefig(
    #    "../../static/graph/web-lollipop-with-colormap-and-arrow.png",
    #    dpi=300,
    #    bbox_inches="tight",
    #)


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
        LollipopFancyFormatting()


except Exception:
    import traceback
    print(traceback.format_exc())




