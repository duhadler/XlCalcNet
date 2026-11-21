
from xlcalcnet import gui
import os, time
import numpy as np

# https://matplotlib.org/stable/gallery/lines_bars_and_markers/step_demo.html


def Stepplot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Stepplot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    if (OutputMode != 'gui'):
        import matplotlib
        matplotlib.use('Agg')
    import matplotlib.pyplot as plt
    plt.style.use(PlotStyle)

    x = np.arange(14)
    y = np.sin(x / 2)
    fig, ax = plt.subplots()

    plt.step(x, y + 2, label='pre (default)')
    plt.plot(x, y + 2, 'o--', color='grey', alpha=0.3)

    plt.step(x, y + 1, where='mid', label='mid')
    plt.plot(x, y + 1, 'o--', color='grey', alpha=0.3)

    plt.step(x, y, where='post', label='post')
    plt.plot(x, y, 'o--', color='grey', alpha=0.3)

    plt.grid(axis='x', color='0.95')
    plt.legend(title='Parameter where:')
    plt.title('plt.step(where=...)')

# Start of output choices
    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        plt.savefig(FullPath + '.' + OutputMode,  bbox_inches='tight')
    plt.close('all')


try:
    if __name__ == '__main__':
        start0 = time.time()
        Stepplot(OutputMode = 'gui')
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())


