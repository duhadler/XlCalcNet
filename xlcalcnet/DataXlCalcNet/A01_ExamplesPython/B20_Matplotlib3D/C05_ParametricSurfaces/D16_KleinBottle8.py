from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def KleinBottle8(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'KleinBottle8'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)

    #.. Figure 8 Klein Bottle

    # 1. Define function to examine ....................................

    def fig8(rtp) :
        r,t,p = rtp
        R=2
        v = 2*p
        Q = ( R + np.cos(t/2)*np.sin(v) - np.sin(t/2)*np.sin(2*v) )
        x = Q*np.cos(t)
        y = Q*np.sin(t)
        z = np.sin(t/2)*np.sin(v) + np.cos(t/2)*np.sin(2*v)
        return x,y,z

    # 2. Setup and map surface .........................................
    rez=5

    surface = s3d.SphericalSurface(rez,basetype='octa_c',color='burlywood')
    surface.map_geom_from_op( fig8, returnxyz=True )

    # 3. Construct figure, add surface plot ............................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975, "Figure 8 Immersion of the Klein Bottle", \
        ha='right', va='top', fontsize='larger', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-2,2)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.view_init(elev=35, azim=-60)

    ax.add_collection3d(surface.shade(ax=ax).hilite(ax=ax))

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
        KleinBottle8()



except Exception:
    import traceback
    print(traceback.format_exc())
