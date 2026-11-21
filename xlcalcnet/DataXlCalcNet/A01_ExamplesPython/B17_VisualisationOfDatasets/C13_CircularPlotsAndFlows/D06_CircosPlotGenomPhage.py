


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


def CircosPlotGenomPhage(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircosPlotGenomPhage'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    # Load GFF file
    gff_file = load_prokaryote_example_file("enterobacteria_phage.gff")
    gff = Gff(gff_file)

    # Initialize circos instance
    seqid2size = gff.get_seqid2size()
    space = 0 if len(seqid2size) == 1 else 2
    circos = Circos(sectors=seqid2size, space=space)
    circos.text("Enterobacteria phage\n(NC_000902)", size=15)

    seqid2features = gff.get_seqid2features(feature_type="CDS")
    for sector in circos.sectors:
        cds_track = sector.add_track((90, 100))
        cds_track.axis(fc="#EEEEEE", ec="none")

        features = seqid2features[sector.name]
        label_pos_list, labels = [], []
        for feature in features:
            # Plot CDS features
            if feature.location.strand == 1:
                cds_track.genomic_features(feature, plotstyle="arrow", r_lim=(95, 100), fc="salmon")
            else:
                cds_track.genomic_features(feature, plotstyle="arrow", r_lim=(90, 95), fc="skyblue")
            # Extract feature product label & position
            start, end = int(feature.location.start), int(feature.location.end)
            label_pos = (start + end) / 2
            label = feature.qualifiers.get("product", [""])[0]
            if label == "" or label.startswith("hypothetical"):
                continue
            cds_track.annotate(label_pos, label, label_size=7)

        # Plot xticks & intervals on inner position
        cds_track.xticks_by_interval(
            interval=5000,
            outer=False,
            label_formatter=lambda v: f"{v/ 1000:.1f} Kb",
            label_orientation="vertical",
            line_kws=dict(ec="grey"),
        )

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
        CircosPlotGenomPhage()


except Exception:
    import traceback
    print(traceback.format_exc())


