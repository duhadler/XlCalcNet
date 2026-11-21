


# https://moshi4.github.io/pyCirclize/circos_plot/

from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from pycirclize import Circos
from pycirclize.utils import ColorCycler, load_eukaryote_example_dataset


def CircosPlotChromosomeLinks(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircosPlotChromosomeLinks'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    # Load hg38 dataset (https://github.com/moshi4/pycirclize-data/tree/main/eukaryote/hg38)
    chr_bed_file, cytoband_file, chr_links = load_eukaryote_example_dataset("hg38")

    # Initialize Circos from BED chromosomes
    circos = Circos.initialize_from_bed(chr_bed_file, space=3)
    circos.text("Homo sapiens\n(hg38)", deg=315, r=150, size=12)

    # Add cytoband tracks from cytoband file
    circos.add_cytoband_tracks((95, 100), cytoband_file)

    # Create chromosome color dict
    ColorCycler.set_cmap("hsv")
    chr_names = [s.name for s in circos.sectors]
    colors = ColorCycler.get_color_list(len(chr_names))
    chr_name2color = {name: color for name, color in zip(chr_names, colors)}

    # Plot chromosome name & xticks
    for sector in circos.sectors:
        sector.text(sector.name, r=120, size=10, color=chr_name2color[sector.name])
        sector.get_track("cytoband").xticks_by_interval(
            40000000,
            label_size=8,
            label_orientation="vertical",
            label_formatter=lambda v: f"{v / 1000000:.0f} Mb",
        )

    # Plot chromosome link
    for link in chr_links:
        region1 = (link.query_chr, link.query_start, link.query_end)
        region2 = (link.ref_chr, link.ref_start, link.ref_end)
        color = chr_name2color[link.query_chr]
        if link.query_chr in ("chr1", "chr8", "chr16") and link.query_chr != link.ref_chr:
            circos.link(region1, region2, color=color)

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
        CircosPlotChromosomeLinks()


except Exception:
    import traceback
    print(traceback.format_exc())


