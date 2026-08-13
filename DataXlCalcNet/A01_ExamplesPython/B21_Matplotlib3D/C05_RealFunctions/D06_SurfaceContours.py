from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def SurfaceContours3d(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define function to examine ....................................

    def townsend(xyz) :
        x,y,z = xyz
        A = -np.cos( (x-0.1)*y )**2
        B = -np.sin(3*x + y)
        return x, y, (A + x*B)

    # 2. Setup and map surface .........................................

    plane = s3d.PlanarSurface(6).domain( 2.25, (-2.5, 1.75) )
    plane.map_geom_from_op(townsend)
    plane.map_cmap_from_op()     # default: z-direction

    contours = plane.contourLineSet(20)
    contours.map_to_plane( -5 )  # default: xy plane
    contours.set_linewidth(1)

    # 3. Construct figure & axes, add surface & contours, show .........

    fig = plt.figure()
    ax = plt.axes(projection='3d', proj_type='ortho')
    ax.set(xlabel='X',ylabel='Y',zlabel='Z')

    s3d.auto_scale(ax,plane,contours)
    ax.add_collection3d(plane.shade(0.5).hilite(.5))
    ax.add_collection3d(contours)

    fig.tight_layout(pad=0)

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
        SurfaceContours3d()



except Exception:
    import traceback
    print(traceback.format_exc())
