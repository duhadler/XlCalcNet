from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu

# See: https://s3dlib.org/examples/colormaps/mri.html


def MRIRegions(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MRIRegions'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    import gzip
    import copy

    # colormapped MRI

    # 1. Define function to examine .....................................

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples', 'Pics'])


    with gzip.open(datapath + '/s1045.ima.gz') as datafile:
        s = datafile.read()
    Z = np.frombuffer(s, np.uint16).astype(float).reshape((256, 256))
    Z = np.flip(Z,0)

    # 2. Setup and map surfaces .........................................
    rez=6
    cmu.hsv_cmap_gradient('k','b', name='k2b')
    cmu.rgb_cmap_gradient('k','k',name='black')
    cmu.stitch_cmap( 'k2b', 'black', 'autumn', bndry=[.4,.55], name='MRI' )

    surface = s3d.PlanarSurface(rez, basetype='oct1', name='MRI')
    surface.map_cmap_from_datagrid( Z, 'MRI' )
    surface3D = copy.copy(surface)
    surface3D.map_geom_from_datagrid( Z, scale=.3, name='MRI - 3D' ).shade()

    surfaces = [surface, surface3D]

    # 3. Construct figure, add surface, plot ............................

    minmax = (-.7,.7)
    fig = plt.figure(figsize=plt.figaspect(0.5))
    fig.text(0.01,0.01,str(surface), ha='left', va='bottom', fontsize='smaller')
    for i,surface in enumerate(surfaces) :
        ax = fig.add_subplot(121+i, projection='3d')
        ax.set_proj_type('ortho')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
        ax.set_axis_off()
        ax.view_init(90,-90)
        ax.set_title(surface.name, fontsize='xx-large')

        ax.add_collection3d( surface )

    fig.tight_layout(pad=2)

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
        MRIRegions()



except Exception:
    import traceback
    print(traceback.format_exc())
