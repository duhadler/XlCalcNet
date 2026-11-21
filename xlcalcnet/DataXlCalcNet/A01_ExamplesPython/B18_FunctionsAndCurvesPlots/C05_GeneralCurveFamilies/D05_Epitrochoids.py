from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
#import matplotlib
#matplotlib.use('TkAgg')

# https://glowingpython.blogspot.com/2011/11/fun-with-epitrochoids.html

def EpitrochoidsXY(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EpitrochoidsXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 1500
# End of standard key word arguments
    #R = 14; r = 1; d = 18
    #R = 6; r = 1; d = 6
    R = 3; r = 1; d = 0.5
# End of custom key word arguments

    plt.style.use(PlotStyle)
    t = np.linspace(0, 20, Resolution)

    # Epitrochoid parametric equations
    x = (R-r)*np.cos(t)-d*np.cos( (R+r)*t / r )
    y = (R-r)*np.sin(t)-d*np.sin( (R+r)*t / r )

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
        EpitrochoidsXY()


except Exception:
    import traceback
    print(traceback.format_exc())


