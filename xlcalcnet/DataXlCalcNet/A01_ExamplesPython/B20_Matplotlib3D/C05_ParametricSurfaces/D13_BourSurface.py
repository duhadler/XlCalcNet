from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def BourSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BourSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Polar Coordinates to XYZ 2

    # 1. Define function to examine .....................................

    def boursurf(rtz) :
        r,t,z = rtz
        T = 2*t
        x = r*np.cos(T) - np.power(r,2.0)*np.cos(2*T)/2.0
        y = -r*np.sin(T) * ( r*np.cos(T) + 1.0)
        z = 1.3333*np.power(r,1.5)*np.cos(1.5*T)
        return x,y,z

    # 2. Setup and map surfaces .........................................
    rez = 6

    surface = s3d.PolarSurface(rez, basetype='hex_c', minrad=0.4)
    surface.map_cmap_from_op( lambda rtz: rtz[0] , cmap='viridis_r' )
    surface.map_geom_from_op( boursurf, returnxyz=True )

    # 3. Construct figures, add surface, plot ...........................

    fig = plt.figure(figsize=plt.figaspect(1))
    minmax = (-1.1,1.1)
    fig.text(0.975,0.975, "Bour's Minimal Surface, r>0.4", ha='right', va='top', fontsize='larger', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.view_init(azim=-50)
    ax.set_axis_off()

    ax.add_collection3d(surface.shade(.7))

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
        BourSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
