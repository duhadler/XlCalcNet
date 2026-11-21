from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu

# See: https://s3dlib.org/examples/colormaps/mri.html


def SurfaceColormap2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SurfaceColormap2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. Gradient Binary colormap used to visualize the inner/outer surfaces.

    # 1. Define function to examine .....................................

    def shell_shape(rtp) :
        r,t,p = rtp
        N, Rmin, Zst, sqeez = 4, 0.25, 1.25, 0.65
        T = N*t
        zeta = np.power(Rmin,1/(1-N))
        n = (N/(1-N))/(2*np.pi)
        R = np.power(zeta,n*T)
        x,y,z = s3d.SphericalSurface.coor_convert([R,T,p],True)
        Z = (1+zeta)*R/zeta
        Z =  z - Zst*Z
        return x,y,sqeez*Z

    # 2. Setup and map surfaces .........................................
    mlt = 15

    cmap1 = cmu.hsv_cmap_gradient('peru','bisque', name='peru_bisque')
    cmap2 = cmu.hsv_cmap_gradient('+pink','plum',  name='+pink_plum' )
    bcmap = cmu.stitch_cmap( cmap2, cmap1, name='piplm_|_pebsq' )

    shell = s3d.SphericalSurface.grid(mlt*4,mlt*36, 'x')
    shell.map_geom_from_op( shell_shape, True )

    # 3. Construct figures, add surface, plot ...........................

    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set_axis_off()
    ax.view_init(elev=20,azim=-50)

    s3d.auto_scale(ax,shell,uscale=0.7)
    #shell.clip_plane(0,direction=[0,-1,0])
    fig.text(0.02,0.02,str(shell), ha='left', va='bottom', fontsize='smaller')
    shell.map_cmap_from_normals(direction=ax,cmap=bcmap)
    ax.add_collection3d(shell.shade(ax=ax).hilite(ax=ax,focus=2,direction=[1,-.4,1]))

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
        SurfaceColormap2()



except Exception:
    import traceback
    print(traceback.format_exc())
