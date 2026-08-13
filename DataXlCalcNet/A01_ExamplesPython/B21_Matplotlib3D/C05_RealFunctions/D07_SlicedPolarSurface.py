from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def SlicedPolarSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)

    from matplotlib.ticker import LinearLocator
    #.. Sliced Polar Surface

    # 1. Define function to examine .....................................

    def screwfunc(rtz, k) :
        r,t,z = rtz
        T = k*t
        Z = T - k*np.pi
        return r,T,Z

    # 2. Setup and map surfaces .........................................
    rez = 4
    purple2green = cmu.hue_cmap(lowHue="blueviolet", hiHue='+g',name='purple_green')

    screw = s3d.PolarSurface(rez, basetype='hex_s', antialiased=True)
    screw.map_geom_from_op( lambda rtz : screwfunc(rtz, 3) )
    screw.map_cmap_from_op( lambda rtz : rtz[2], purple2green )

    # 3. Construct figures, add surface, plot ...........................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975,str(screw), ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=(-1,1), ylim=(-1,1), zlim=(-10,10) )
    ax.xaxis.set_major_locator(LinearLocator(5))
    ax.yaxis.set_major_locator(LinearLocator(5))
    ax.zaxis.set_major_locator(LinearLocator(5))
    ax.view_init(20, 45)

    ax.add_collection3d(screw.shade(direction=[0,0,1]))

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
        SlicedPolarSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
