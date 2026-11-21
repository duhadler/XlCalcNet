from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def IsoSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'IsoSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # 1. Define function to examine .....................................

    def mfunc(xyz) :
        x,y,z = xyz
        return np.sin(x*y*z)/(x*y*z)

    # 2. Setup and map surface .........................................

    surface = s3d.Surface3DCollection.implsurf(mfunc, 1.9, 10, fval=0.1, color='c').evert()
    surface.triangulate(3)

    # 3. Construct figure, add surface, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975,str(surface), ha='right', va='top', fontsize='smaller')
    ax = plt.axes(projection='3d', aspect='equal', focal_length=0.5)
    ax.set(xlabel='X',ylabel='Y',zlabel='Z')
    ax.view_init(20)
    s3d.auto_scale(ax,surface)
    surface.shade(0.0,ax=ax,flat=False).hilite(.9,focus=1,flat=False)
    ax.add_collection3d(surface)

    fig.tight_layout(pad=2)

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
        IsoSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
