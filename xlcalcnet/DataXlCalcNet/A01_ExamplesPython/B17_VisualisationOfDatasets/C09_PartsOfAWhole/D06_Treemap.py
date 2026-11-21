
# See: https://python-graph-gallery.com/590-advanced-treemap/

from xlcalcnet import gui
from pathlib import Path
import os
import squarify  # pip install squarify (algorithm for treemap)
import matplotlib.pyplot as plt
from pypalettes import load_cmap
import pandas as pd
from highlight_text import fig_text



def Treemap(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Treemap'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    df = pd.read_csv(
        "https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/simple-treemap.csv"
    )

    ## create a figure
    #fig, ax = plt.subplots(figsize=(10, 10))
    #ax.set_axis_off()
    ##
    ## add treemap
    #squarify.plot(sizes=df["value"], label=df["name"], ax=ax)
    #
    ## display plot
    #plt.show()
    #
    #
    ## create a color palette
    #cmap = load_cmap("Acadia")
    #category_codes, unique_categories = pd.factorize(df["parent"])
    #colors = [cmap(code) for code in category_codes]
    #
    ## create a treemap
    #fig, ax = plt.subplots(figsize=(10, 10))
    #ax.set_axis_off()
    #squarify.plot(
    #    sizes=df["value"],
    #    label=df["name"],
    #    color=colors,
    #    text_kwargs={"color": "white"},
    #    pad=True,
    #    ax=ax,
    #)
    #plt.show()


    # create a color palette
    cmap = load_cmap("Acadia")
    category_codes, unique_categories = pd.factorize(df["parent"])
    colors = [cmap(code) for code in category_codes]

    # customize the labels
    labels = [
        f"{name} ({parent[5:]})\n{value}"
        for name, value, parent in zip(df["name"], df["value"], df["parent"])
    ]

    # create a treemap
    fig, ax = plt.subplots(figsize=(7.5, 7))
    ax.set_axis_off()
    squarify.plot(
        sizes=df["value"],
        label=labels,
        color=colors,
        text_kwargs={"color": "white", "fontsize": 8, "fontweight": "bold"},
        pad=True,
        ax=ax,
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
        Treemap()


except Exception:
    import traceback
    print(traceback.format_exc())






