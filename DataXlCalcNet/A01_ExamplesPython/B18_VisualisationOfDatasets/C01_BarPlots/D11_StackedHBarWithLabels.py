
# See: https://stackoverflow.com/questions/21397549/horizontal-stacked-bar-plot-and-add-labels-to-each-section

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import matplotlib.pyplot as plt


def StackedHBarWithLabels(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'StackedHBarWithLabels'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
#    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

# Source - https://stackoverflow.com/a/21405292
# Posted by Bonlenfum, modified by community. See post 'Timeline' for change history
# Retrieved 2026-03-04, License - CC BY-SA 4.0


    people = ('A','B','C','D','E','F','G','H')
    segments = 4

    # generate some multi-dimensional data & arbitrary labels
    data = 3 + 10* np.random.rand(segments, len(people))
    percentages = (np.random.randint(5,20, (len(people), segments)))
    y_pos = np.arange(len(people))

    fig = plt.figure(figsize=(10,8))
    ax = fig.add_subplot(111)

    colors ='rgbmc'
    patch_handles = []
    left = np.zeros(len(people)) # left alignment of data starts at zero
    for i, d in enumerate(data):
        patch_handles.append(ax.barh(y_pos, d, 
          color=colors[i%len(colors)], align='center', 
          left=left))
        # accumulate the left-hand offsets
        left += d
        
    # go through all of the bar segments and annotate
    for j in range(len(patch_handles)):
        for i, patch in enumerate(patch_handles[j].get_children()):
            bl = patch.get_xy()
            x = 0.5*patch.get_width() + bl[0]
            y = 0.5*patch.get_height() + bl[1]
            ax.text(x,y, "%d%%" % (percentages[i,j]), ha='center')

    ax.set_yticks(y_pos)
    ax.set_yticklabels(people)
    ax.set_xlabel('Distance')


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
        StackedHBarWithLabels()


except Exception:
    import traceback
    print(traceback.format_exc())


