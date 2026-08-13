

# See also:https://python-graph-gallery.com/density-mirror/


from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt



def MirrorHistogram(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MirrorHistogram'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    # dataframe
    df = pd.DataFrame({
    'var1': np.random.normal(size=1000),
    'var2': np.random.normal(loc=2, size=1000) * -1
    })

    # Fig size
    plt.rcParams["figure.figsize"]=12,8

    # plot histogram chart for var1
    sns.histplot(x=df.var1, stat="density", bins=20, edgecolor='black')

    # plot histogram chart for var2
    n_bins = 20
    # get positions and heights of bars
    heights, bins = np.histogram(df.var2, density=True, bins=n_bins)
    # multiply by -1 to reverse it
    heights *= -1
    bin_width = np.diff(bins)[0]
    bin_pos =( bins[:-1] + bin_width / 2) * -1

    # plot
    plt.bar(bin_pos, heights, width=bin_width, edgecolor='black')




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
        MirrorHistogram()


except Exception:
    import traceback
    print(traceback.format_exc())




