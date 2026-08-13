

# See also: https://allisonhorst.github.io/palmerpenguins/

# See: https://python-graph-gallery.com/raincloud-plot-with-matplotlib-and-ptitprince/

# See: https://github.com/pog87/PtitPrince

# For Examples: https://github.com/pog87/PtitPrince/blob/master/tests/test_raincloud.py

# And: https://github.com/pog87/PtitPrince/blob/master/tutorial_python/raincloud_tutorial_python.ipynb



from xlcalcnet import gui
from pathlib import Path
import os
import palmerpenguins
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from ptitprince import RainCloud



def RaincloudPlot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RaincloudPlot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    penguins = palmerpenguins.load_penguins().dropna()

    fig, ax = plt.subplots(figsize=(6, 6))

    SPECIES = ["Adelie", "Gentoo", "Chinstrap"]
    #ORIENT = "h"
    ORIENT = "v"

    ax = RainCloud(x="species", y="bill_length_mm", data=penguins, hue="species", 
            width_viol=0.5, palette = "Set2", ax=ax, orient=ORIENT)


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
        RaincloudPlot()


except Exception:
    import traceback
    print(traceback.format_exc())




