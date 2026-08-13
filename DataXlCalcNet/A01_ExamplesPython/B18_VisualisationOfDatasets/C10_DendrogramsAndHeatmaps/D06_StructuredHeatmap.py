from xlcalcnet import gui
from pathlib import Path
import os
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt

# See also: https://seaborn.pydata.org/examples/structured_heatmap.html


def StructuredHeatmap(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StructuredHeatmap'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    sns.set_theme()

    # Load the brain networks example dataset
    df = sns.load_dataset("brain_networks", header=[0, 1, 2], index_col=0)

    # Select a subset of the networks
    used_networks = [1, 5, 6, 7, 8, 12, 13, 17]
    used_columns = (df.columns.get_level_values("network")
                              .astype(int)
                              .isin(used_networks))
    df = df.loc[:, used_columns]

    # Create a categorical palette to identify the networks
    network_pal = sns.husl_palette(8, s=.45)
    network_lut = dict(zip(map(str, used_networks), network_pal))

    # Convert the palette to vectors that will be drawn on the side of the matrix
    networks = df.columns.get_level_values("network")
    network_colors = pd.Series(networks, index=df.columns).map(network_lut)

    # Draw the full plot
    g = sns.clustermap(df.corr(), center=0, cmap="vlag",
                       row_colors=network_colors, col_colors=network_colors,
                       dendrogram_ratio=(.1, .2),
                       cbar_pos=(.02, .32, .03, .2),
                       linewidths=.75, figsize=(12, 13))
    g.ax_row_dendrogram.remove()
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
        StructuredHeatmap()


except Exception:
    import traceback
    print(traceback.format_exc())


