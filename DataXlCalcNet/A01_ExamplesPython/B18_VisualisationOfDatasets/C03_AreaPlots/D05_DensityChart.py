

# See also:https://python-graph-gallery.com/density-chart-multiple-groups-seaborn/


from xlcalcnet import gui
from pathlib import Path
import os
import seaborn as sns
import matplotlib.pyplot as plt
import pandas as pd



def DensityChart(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'DensityChart'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    # set seaborn whitegrid theme
    sns.set_theme(style="whitegrid")

    # load dataset from github and convert it to a long format
    data = pd.read_csv(
        "https://raw.githubusercontent.com/zonination/perceptions/master/probly.csv"
    )
    data = pd.melt(data, var_name="text", value_name="value")

    # take only "Almost No Chance", "About Even", "Probable", "Almost Certainly"
    data = data.loc[
        data.text.isin(["Almost No Chance", "About Even", "Probable", "Almost Certainly"])
    ]

    # density plot
    p = sns.kdeplot(
        data=data,
        x="value",
        hue="text",
        fill=True,
        common_norm=False,
        alpha=0.6,
        palette="viridis",
        legend=False,
    )
    # control x limit
    plt.xlim(0, 100)

    # dataframe for annotations
    annot = pd.DataFrame(
        {
            "x": [5, 53, 65, 79],
            "y": [0.15, 0.4, 0.06, 0.1],
            "text": ["Almost No Chance", "About Even", "Probable", "Almost Certainly"],
        }
    )

    # add annotations one by one with a loop
    for point in range(0, len(annot)):
        p.text(
            annot.x[point],
            annot.y[point],
            annot.text[point],
            horizontalalignment="left",
            size="large",
        )

    # add axis names
    plt.xlabel("Assigned Probability (%)")
    plt.ylabel("")


    fig = plt.gcf()
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
        DensityChart()


except Exception:
    import traceback
    print(traceback.format_exc())




