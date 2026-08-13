from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def Knot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Knot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define function to examine .....................................
    def knot(rtz) :
        r,t,z = rtz
        rho,zeta,delta = 0.25, 0.3, 0.3
        R = (1-rho)*(1-delta*np.sin(3*t)) + rho*np.cos(z*np.pi)
        Z = rho*np.sin(z*np.pi) + zeta*np.cos(3*t)
        return R, 2*t, Z

    # 2. Setup and map surface  .........................................
    surface = s3d.CylindricalSurface(6)
    surface.map_cmap_from_op(lambda c: c[1],'hsv')
    surface.map_geom_from_op( knot )

    # 3. Construct figure & axes, add surface, show .....................
    fig, ax = plt.subplots(subplot_kw={"projection": "3d"})
    ax.set( xlim=(-1,1),ylim=(-1,1),zlim=(-1,1) )
    ax.add_collection3d(surface.shade().hilite(.75))

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
        Knot()



except Exception:
    import traceback
    print(traceback.format_exc())
