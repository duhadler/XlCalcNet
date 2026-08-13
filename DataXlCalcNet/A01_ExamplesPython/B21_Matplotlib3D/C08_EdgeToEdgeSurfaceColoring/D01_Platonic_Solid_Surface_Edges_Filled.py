from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/data_surface/inner_platonic.html


def PlatonicSolidSurfaceEdgesFilled(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlatonicSolidSurfaceEdgesFilled'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. Platonic Solid Surface Edges Filled

    def radial_Color(c):
        return s3d.SphericalSurface.coor_convert(c)[0]

    surfaceType = ['tetra','octa','icosa','','cube','dodeca']

    fig = plt.figure()
    minmax = (-.67,.67)
    for i,stgID in enumerate(surfaceType) :
        ax =  fig.add_subplot(231+i, projection='3d', aspect='equal')
        ax.set(xlim=(-1, 1), ylim=(-1, 1), zlim=(-1, 1))
        ax.set_axis_off()
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
        if len(stgID) == 0 : continue
        surface = s3d.SphericalSurface.platonic(0,stgID)
        line = surface.edges
        surface = line.get_filled_surface(coor='s',dist=0.01, lrez=5,name=stgID)
        surface.map_cmap_from_op( radial_Color,'rainbow_r' )
        ax.set_title(surface.name, fontsize='x-large')
        ax.set_proj_type('ortho')
        ax.view_init(20,-15)

        ax.add_collection3d(surface.shade(0.4,ax=ax))

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
        PlatonicSolidSurfaceEdgesFilled()



except Exception:
    import traceback
    print(traceback.format_exc())
