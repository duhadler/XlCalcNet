from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/images_contours_and_fields/plot_streamplot.html#sphx-glr-gallery-images-contours-and-fields-plot-streamplot-py


def Stepplot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

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
        Stepplot()


except Exception:
    import traceback
    print(traceback.format_exc())


