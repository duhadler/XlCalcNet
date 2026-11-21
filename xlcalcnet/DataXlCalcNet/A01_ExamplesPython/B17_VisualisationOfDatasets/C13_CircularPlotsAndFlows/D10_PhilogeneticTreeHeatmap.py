


# See: https://moshi4.github.io/pyCirclize/phylogenetic_tree/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import load_example_tree_file, ColorCycler


def PhilogeneticTreeHeatmap(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PhilogeneticTreeHeatmap'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    np.random.seed(0)

    tree_file = load_example_tree_file("large_example.nwk")
    circos, tv = Circos.initialize_from_tree(
        tree_file,
        start=-350,
        end=0,
        r_lim=(10, 80),
        leaf_label_size=5,
        leaf_label_rmargin=21,
        line_kws=dict(color="lightgrey", lw=1),
    )

    # Define group-species dict for tree annotation
    # In this example, set minimum species list to specify group's MRCA node
    group_name2species_list = dict(
        Monotremata=["Tachyglossus_aculeatus", "Ornithorhynchus_anatinus"],
        Marsupialia=["Monodelphis_domestica", "Vombatus_ursinus"],
        Xenarthra=["Choloepus_didactylus", "Dasypus_novemcinctus"],
        Afrotheria=["Trichechus_manatus", "Chrysochloris_asiatica"],
        Euarchontes=["Galeopterus_variegatus", "Theropithecus_gelada"],
        Glires=["Oryctolagus_cuniculus", "Microtus_oregoni"],
        Laurasiatheria=["Talpa_occidentalis", "Mirounga_leonina"],
    )

    # Set tree line color
    ColorCycler.set_cmap("Set2")
    for species_list in group_name2species_list.values():
        tv.set_node_line_props(species_list, color=ColorCycler())

    # Plot heatmap
    sector = circos.sectors[0]
    heatmap_track = sector.add_track((80, 100))
    matrix_data = np.random.randint(0, 100, (5, tv.leaf_num))
    heatmap_track.heatmap(matrix_data, cmap="viridis")
    heatmap_track.yticks([0.5, 1.5, 2.5, 3.5, 4.5], list("EDCBA"), vmax=5, tick_length=0)

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
        PhilogeneticTreeHeatmap()


except Exception:
    import traceback
    print(traceback.format_exc())


