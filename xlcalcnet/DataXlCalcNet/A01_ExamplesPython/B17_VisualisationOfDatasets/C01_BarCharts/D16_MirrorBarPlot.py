
# See: https://python-graph-gallery.com/web-ordered-mirror-barplot/

from xlcalcnet import gui
from pathlib import Path
import os, time
import pandas as pd
import numpy as np



def MirrorBarPlot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MirrorBarPlot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    

    # Choose 'Agg' as backend unless we want to display the graphics
    if (OutputMode != 'gui'):
        import matplotlib
        matplotlib.use('Agg')
    import matplotlib.pyplot as plt
    plt.style.use(PlotStyle)


    # URLs
    resume_url = 'https://raw.githubusercontent.com/holtzy/the-python-graph-gallery/master/static/data/resume.csv'
    erasmus_url = 'https://raw.githubusercontent.com/holtzy/the-python-graph-gallery/master/static/data/erasmus.csv'

    # load datasets
    resume = pd.read_csv(resume_url)
    data = pd.read_csv(erasmus_url)

    # Create a figure and axis with a specific size
    fig, ax = plt.subplots(figsize=(6, 6))

    # Create both barplots
    ax.barh(resume['country_name'], resume['mean_rec'],
            color='blue', alpha=0.3)
    ax.barh(resume['country_name'], -resume['mean_send'],
            color='darkorange', alpha=0.3)

    # Add a title
    ax.set_title('Number of Students', weight='bold')


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
        start0 = time.time()
        MirrorBarPlot(OutputMode = 'gui')
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())



