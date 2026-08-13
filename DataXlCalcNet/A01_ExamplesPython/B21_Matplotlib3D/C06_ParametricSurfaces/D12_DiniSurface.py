from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def DiniSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'DiniSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Polar Coordinates to XYZ

    # 1. Define function to examine .....................................

    def dinisurf(rtz) :
        r,t,z = rtz
        a, b = 1, 0.2
        T = 2*t
        x = a*np.cos(T)*np.sin(r)
        y = a*np.sin(T)*np.sin(r)
        z = a*(np.cos(r) + np.log(np.tan(r/2))) + b*T
        return x,y,z

    # 2. Setup and map surfaces .........................................
    rez = 4

    surface = s3d.PolarSurface(rez, basetype='hex_c', minrad=0.01)
    surface.map_cmap_from_op( lambda rtz: rtz[0] , cmap='inferno' )
    surface.map_geom_from_op( dinisurf, returnxyz=True )

    # 3. Construct figures, add surface, plot ...........................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975, "Dini's Surface", ha='right', va='top', fontsize='larger', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=(-.75,.75), ylim=(-.75,.75), zlim=(-3,1) )
    ax.set_axis_off()
    ax.view_init(elev=20)
    ax.add_collection3d(surface)

    fig.tight_layout()

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
        DiniSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
