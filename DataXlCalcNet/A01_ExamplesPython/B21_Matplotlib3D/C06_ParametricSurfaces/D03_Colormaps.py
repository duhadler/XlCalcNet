from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu



def Colormaps(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define function to examine .....................................
    def twistFunction(rtz,twists=6) :
        r,t,z = rtz
        phi = twists*t/2
        w = 0.33*z
        R = 1 + w * np.cos(phi)
        Z = w * np.sin(phi)
        return R,t,Z

    # 2. Setup and map surfaces .........................................
    bcmap = cmu.binary_cmap('silver', 'sandybrown', name='slvr_brwn' )

    surface = s3d.CylindricalSurface(5, basetype='squ_s', cmap=bcmap)
    surface.map_geom_from_op( twistFunction )

    # 3. Construct figures, add surface, plot ...........................
    minmax = (-.8,.8)
    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()

    ax.view_init(azim=-70)
    surface.map_cmap_from_normals(direction=ax)
    ax.add_collection3d(surface.shade(ax=ax).hilite(ax=ax))

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
        Colormaps()



except Exception:
    import traceback
    print(traceback.format_exc())
