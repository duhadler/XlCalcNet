


# https://moshi4.github.io/pyCirclize/circos_plot/


from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.parser import Gff
from pycirclize.utils import load_prokaryote_example_file


def CircosPlotGenomHomoSapiens(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircosPlotGenomHomoSapiens'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    from pycirclize import Circos
    from pycirclize.utils import load_eukaryote_example_dataset

    # Load hg38 dataset (https://github.com/moshi4/pycirclize-data/tree/main/eukaryote/hg38)
    chr_bed_file, cytoband_file, _ = load_eukaryote_example_dataset("hg38")

    # Initialize Circos from BED chromosomes
    circos = Circos.initialize_from_bed(chr_bed_file, space=3)
    circos.text("Homo sapiens (hg38)", size=15)

    # Add cytoband tracks from cytoband file
    circos.add_cytoband_tracks((95, 100), cytoband_file)

    # Plot chromosome name
    for sector in circos.sectors:
        sector.text(sector.name, size=10)

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
        CircosPlotGenomHomoSapiens()


except Exception:
    import traceback
    print(traceback.format_exc())


