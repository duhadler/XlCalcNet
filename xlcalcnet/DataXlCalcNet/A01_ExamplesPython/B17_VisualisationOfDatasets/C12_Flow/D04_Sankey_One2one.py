
# Note : python -m pip install -U  pysankeybeta

# Some code might need update from pysankey to pySankey

from xlcalcnet import gui
from pathlib import Path
import os

import pandas as pd
from pySankey import sankey
import matplotlib.pyplot as plt




def Sankey_One2one(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Sankey_One2one'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    url = "https://raw.githubusercontent.com/Pierre-Sassoulas/pySankey/master/pysankey/fruits.txt"



    df = pd.read_csv(
        url,
        sep=' ',
        names=['true', 'predicted']
    )


    colorDict = {
        'apple':'#f71b1b',
        'blueberry':'#1b7ef7',
        'banana':'#f3f71b',
        'lime':'#12e23f',
        'orange':'#f78c1b',
        'kiwi':'#9BD937'
    }

    labels = list(colorDict.keys())
    leftLabels = [label for label in labels if label in df['true'].values]
    rightLabels = [label for label in labels if label in df['predicted'].values]

    # Create the sankey diagram
    ax = sankey(
        left=df['true'],
        right=df['predicted'],
        leftLabels=leftLabels,
        rightLabels=rightLabels,
        colorDict=colorDict,
        aspect=20,
        fontsize=12
    )

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
        Sankey_One2one()


except Exception:
    import traceback
    print(traceback.format_exc())


