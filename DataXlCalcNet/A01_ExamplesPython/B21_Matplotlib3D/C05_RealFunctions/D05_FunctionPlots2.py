from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def FunctionPlots2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define function to examine .....................................

    def McCormick_function(xyz) :
        x,y,z = xyz
        Z = np.sin(x+y) + (x-y)**2 - 1.5*x + 2.5*y + 1
        return x,y,Z

    # 2. Setup and map surfaces .........................................
    rez = 6

    surface = s3d.PlanarSurface(rez).domain( (-1.5,4.0),(-3.0,4.0) )
    surface.map_geom_from_op( McCormick_function )
    surface.map_cmap_from_op( lambda C: C[2] , 'jet')

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure()
    ax = plt.axes(projection='3d')
    ax.view_init(25)
    ax.set_title(surface.name, fontsize='x-large')
    ax.set_xlabel('X')
    ax.set_ylabel('Y')
    s3d.auto_scale(ax,surface)

    ax.add_collection3d(surface.shade(.5).hilite(.5))

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
        FunctionPlots2()


except Exception:
    import traceback
    print(traceback.format_exc())
