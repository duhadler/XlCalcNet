from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')

#See also: http://www.csharphelper.com/howtos/howto_chrysanthemum_curve.html
#See also: http://paulbourke.net/geometry/chrysanthemum/


def ChrysanthemumCurve(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ChrysanthemumCurve'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 1500
# End of standard key word arguments
    bb = 0.1;
# End of custom key word arguments

    t = np.linspace(0, 40, Resolution)
    r = 5.0 * (1.0 + np.sin(11.0 * t / 5.0)) \
        - 4.0 * np.pow(np.sin(17.0 * t / 3.0), + 4.0) \
        * np.pow(np.sin(2.0 * np.cos(3.0 * t) - 28.0 * t), 8.0);
    x = r * np.sin(t);
    y = r * np.cos(t);

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    ax.plot(x, y)
    ax.axis('equal')
    ax.set_title(Title)

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
        ChrysanthemumCurve()


except Exception:
    import traceback
    print(traceback.format_exc())


