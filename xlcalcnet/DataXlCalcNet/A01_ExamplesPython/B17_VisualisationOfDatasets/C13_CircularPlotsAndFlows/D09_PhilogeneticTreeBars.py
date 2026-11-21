


# See: https://moshi4.github.io/pyCirclize/phylogenetic_tree/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import load_example_tree_file


def PhilogeneticTreeBars(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PhilogeneticTreeBars'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    np.random.seed(0)

    tree_file = load_example_tree_file("alphabet.nwk")
    circos, tv = Circos.initialize_from_tree(
        tree_file,
        start=5,
        end=355,
        r_lim=(30, 70),
        # Set large margin to insert heatmap & bar track between tree and labels
        leaf_label_rmargin=32,
        ignore_branch_length=True,
        line_kws=dict(lw=1),
    )

    # Create example dataframe for heatmap & bar plot
    df = pd.DataFrame(
        dict(
            s1=np.random.randint(0, 100, tv.leaf_num),
            s2=np.random.randint(0, 100, tv.leaf_num),
            s3=np.random.randint(0, 100, tv.leaf_num),
            count=np.random.randint(1, 10, tv.leaf_num),
        ),
        index=tv.leaf_labels,
    )
    print(df.head())

    # Plot bar (from `count` column data)
    sector = tv.track.parent_sector
    bar_track = sector.add_track((85, 100), r_pad_ratio=0.1)
    bar_track.axis()
    bar_track.grid()
    x = np.arange(0, tv.leaf_num) + 0.5
    y = df["count"].to_numpy()
    bar_track.bar(x, y, width=0.3, color="orange")

    # Plot heatmaps (from `s1, s2, s3` column data)
    track1 = sector.add_track((80, 85))
    track1.heatmap(df["s1"].to_numpy(), cmap="Reds", show_value=True, rect_kws=dict(ec="grey", lw=0.5))
    track2 = sector.add_track((75, 80))
    track2.heatmap(df["s2"].to_numpy(), cmap="Blues", show_value=True, rect_kws=dict(ec="grey", lw=0.5))
    track3 = sector.add_track((70, 75))
    track3.heatmap(df["s3"].to_numpy(), cmap="Greens", show_value=True, rect_kws=dict(ec="grey", lw=0.5))

    # Plot track labels
    circos.text("count", r=bar_track.r_center, color="orange")
    circos.text("s1", r=track1.r_center, color="red")
    circos.text("s2", r=track2.r_center, color="blue")
    circos.text("s3", r=track3.r_center, color="green")

    fig = circos.plotfig()



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
        PhilogeneticTreeBars()


except Exception:
    import traceback
    print(traceback.format_exc())


