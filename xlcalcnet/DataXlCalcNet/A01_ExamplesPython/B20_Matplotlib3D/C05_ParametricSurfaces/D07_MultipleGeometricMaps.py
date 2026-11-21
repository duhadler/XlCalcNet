from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def MultipleGeometricMaps(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MultipleGeometricMaps'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Multiple Geometric Maps

    # 1. Define functions to examine ....................................

    def torusFunc(rtz) :
        r,t,z = rtz
        ratio = .2
        Z = ratio*np.sin(z*np.pi)
        R = r + ratio*np.cos(z*np.pi)
        return R,t,Z

    def knot(rtz) :
        r,t,z = rtz
        R = r*( (1+np.cos(5*t))/2 + 0.65*(1+np.cos(np.pi + 5*t))/2 )
        Z = z +  0.25*np.sin(5*t)
        return R,2*t,Z

    # 2. Setup and map surfaces .........................................
    rez = 5

    torus = s3d.CylindricalSurface(rez)
    torus.map_cmap_from_op( lambda rtz : rtz[1] , 'hsv_r')
    torus.map_geom_from_op( torusFunc )
    torus.map_geom_from_op( knot )

    # 3. Construct figure, add surfaces, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975,str(torus), ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-.8,.8)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.set_axis_off()
    ax.view_init(azim=0)

    ax.add_collection3d(torus.shade().hilite(.5))

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
        MultipleGeometricMaps()



except Exception:
    import traceback
    print(traceback.format_exc())
