from xlcalcnet import gui
from pathlib import Path
import os
import seaborn as sns
import matplotlib.pyplot as plt

# See also: https://seaborn.pydata.org/examples/scatterplot_matrix.html


def ScatterplotMatrix(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ScatterplotMatrix'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    sns.set_theme(style="ticks")
    df = sns.load_dataset("penguins")
    sns.pairplot(df, hue="species")
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
        ScatterplotMatrix()


except Exception:
    import traceback
    print(traceback.format_exc())


