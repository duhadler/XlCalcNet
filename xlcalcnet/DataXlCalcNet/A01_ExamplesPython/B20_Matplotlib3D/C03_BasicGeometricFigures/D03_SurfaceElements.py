from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def SurfaceElements(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    surface = s3d.SphericalSurface.platonic(0,'dodeca',color='c')

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.025,0.025,str(surface),ha='left', va='bottom',fontsize='smaller')
    minmax=(-0.9,0.9)
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.view_init(38,-54)

    ax.scatter(*surface.vertices,color='m',label='vertices')
    ax.scatter(*surface.facecenters,color='y',label='face centers')
    ax.scatter(*surface.edges.segmentcenters,color='c',label='edge centers')
    ax.add_collection3d(surface.vertexnormals(scale=0.3,color='g'))
    ax.add_collection3d(surface.facenormals(scale=0.3,color='r'))
    ax.add_collection3d(surface.edges.fade(0,ax=ax))
    ax.legend(fontsize='x-small')

    ax.add_collection3d(surface.set_surface_alpha(0.1).shade())

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
        SurfaceElements()



except Exception:
    import traceback
    print(traceback.format_exc())
