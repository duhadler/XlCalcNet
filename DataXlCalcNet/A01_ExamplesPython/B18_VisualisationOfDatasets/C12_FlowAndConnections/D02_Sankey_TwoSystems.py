from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
from matplotlib.sankey import Sankey

# See https://matplotlib.org/stable/gallery/specialty_plots/sankey_basics.html


def SankeyTwoSystems(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SankeyTwoSystems'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    fig = plt.figure()
    ax = fig.add_subplot(1, 1, 1, xticks=[], yticks=[], title="Two Systems")
    flows = [0.25, 0.15, 0.60, -0.10, -0.05, -0.25, -0.15, -0.10, -0.35]
    sankey = Sankey(ax=ax, unit=None)
    sankey.add(flows=flows, label='one',
               orientations=[-1, 1, 0, 1, 1, 1, -1, -1, 0])
    sankey.add(flows=[-0.25, 0.15, 0.1], label='two',
               orientations=[-1, -1, -1], prior=0, connect=(0, 0))
    diagrams = sankey.finish()
    diagrams[-1].patch.set_hatch('/')
    plt.legend()

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
        SankeyTwoSystems()


except Exception:
    import traceback
    print(traceback.format_exc())


