
# See: https://python-graph-gallery.com/185-lollipop-plot-with-conditional-color/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np
import seaborn as sns
 


def LolllipopConditionalColor(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'LolllipopConditionalColor'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    # Data
    x = np.linspace(0, 2*np.pi, 100)
    y = np.sin(x) + np.random.uniform(size=len(x)) - 0.2
     
    # Create a color if the y axis value is equal or greater than 0
    my_color = np.where(y>=0, 'orange', 'skyblue')
     
    # The vertical plot is made using the vline function
    plt.vlines(x=x, ymin=0, ymax=y, color=my_color, alpha=0.4)
    plt.scatter(x, y, color=my_color, s=1, alpha=1)
     
    # Add title and axis names
    plt.title("Evolution of the value of ...", loc='left')
    plt.xlabel('Value of the variable')
    plt.ylabel('Group')


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
        LolllipopConditionalColor()


except Exception:
    import traceback
    print(traceback.format_exc())



