from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def RomanSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RomanSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Spherical Coordinates to XYZ

    # 1. Define function to examine ....................................

    def roman(rtp) :
        r,t,p = rtp
        ct, st = np.cos(t), np.sin(t)
        cp, sp = np.cos(p), np.sin(p)
        cp_sp = cp*sp
        ct_st = ct*st
        x = cp*ct_st
        y = sp*ct_st
        z = cp_sp*np.square(ct)
        return x,y,z

    # 2. Setup and map surface .........................................
    rez = 6

    surface = s3d.SphericalSurface(rez,basetype='octa_c',minrad=0.001)
    surface.map_geom_from_op( roman, returnxyz=True )
    surface.map_cmap_from_op( lambda rtp: rtp[0] , cmap='magma_r' )

    # 3. Construct figure, add surface plot ............................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975, "Roman Surface", ha='right', va='top', fontsize='larger', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-.38,.38)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.view_init(elev=20, azim=-83)

    ax.add_collection3d(surface.shade(.5))

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
        RomanSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
