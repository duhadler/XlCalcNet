from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np


# See also: https://jakevdp.github.io/PythonDataScienceHandbook/04.04-density-and-contour-plots.html
def ContourOpen(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RegularConvexPolygon'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1.0
# End of custom key word arguments


    def f(x, y):
        return np.sin(x) ** 10 + np.cos(10 + y * x) * np.cos(x)

    x = np.linspace(0, 5, 50)
    y = np.linspace(0, 5, 40)
    X, Y = np.meshgrid(x, y)
    Z = f(X, Y)
    fig, ax = plt.subplots()
    fig.canvas.manager.set_window_title('ContourOpen')    
    plt.contour(X, Y, Z, 20, cmap='RdGy');
    plt.colorbar();

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
        ContourOpen()

except Exception:
    import traceback
    print(traceback.format_exc())


