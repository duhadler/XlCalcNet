from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu

# See: https://s3dlib.org/examples/showcase/sphericalspirals.html


def EscherSphereSpirals(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EscherSphereSpirals'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. influenced by M.C.Escher - Sphere Spirals
    #.. https://mcescher.com/gallery/mathematical/

    # 1. Define function to examine .....................................
    ttlcolor =  [0.502, 0.200, 0.278, 0.1]
    fgbgcolor = [0.957, 0.925, 0.882]
    outercolor = [0.875, 0.682, 0.388]
    innercolor = [0.847, 0.525, 0.471]

    elev, azim = 45,30
    light_direction = [1,-1,2 ]

    def twist(rtp, twists=1) :
        r,t,p = rtp
        f = np.cos(t) + 1
        b =  2*p/np.pi -1
        g = ( 1 + np.sign(b)*np.power(  np.abs(b), 6 ) )/2
        T = t - 2*twists*(p+g*2*np.pi)
        return r,T,p

    def clipFunc(rtp) :
        T = (8*rtp[1]/(2*np.pi)).astype(int)
        return T%2 == 1

    def getGrid(axis) :
        viewDir = -1*s3d.elev_azim_2vector(axis.elev,axis.azim)
        grid = s3d.SphericalSurface(4,color='.45',lw=0.2)
        grid.clip_plane(0, direction=viewDir )
        grid.transform(scale=1.01)
        grid.set_facecolor([0,0,0,0])
        return grid

    # 2. Setup and map surfaces .........................................
    bcmap= cmu.binary_cmap(innercolor,outercolor)

    surface = s3d.SphericalSurface.grid(9*20,8*10,'x',color='w',edgecolor='k')
    surface.clip(clipFunc)
    surface.map_geom_from_op(twist)

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure(figsize=plt.figaspect(1), facecolor=fgbgcolor)
    text = fig.text(0.97, 0.52, 'S3Dlib.org', color=ttlcolor, ha='right',
        va='center', rotation=90, fontsize=55, fontweight='bold'  )
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = ( -0.75,0.75 )
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.set_axis_off()
    ax.view_init(elev, azim)
    ax.set_facecolor(fgbgcolor)

    surface.map_cmap_from_normals(bcmap,direction=ax)
    surface.shade(ax=ax,direction=light_direction)
    surface.hilite(0.5,ax=ax,direction=light_direction)
    ax.add_collection3d(getGrid(ax))
    ax.add_collection3d(surface)

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
        EscherSphereSpirals()



except Exception:
    import traceback
    print(traceback.format_exc())
