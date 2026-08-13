from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/datagridmap/mri_3d.html


def MRI3D(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MRI3D'
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

    # 1. Define function to examine .....................................
    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples', 'Pics'])


    with gzip.open(datapath + '/s1045.ima.gz') as datafile:
        s = datafile.read()
    Z = np.frombuffer(s, np.uint16).astype(float).reshape((256, 256))
    Z = np.flip(Z,0)

    # 2. Setup and map surfaces .........................................
    rez=6

    surface = s3d.PlanarSurface(rez, basetype='oct1', name='MRI')
    surface.map_cmap_from_datagrid( Z, 'hot' )

    # 3. Construct figure, add surface, plot ............................
    show3D = True

    minmax = (-0.9,0.9)
    fig = plt.figure(figsize=plt.figaspect(0.9))
    fig.text(0.01,0.01,str(surface), ha='left', va='bottom', fontsize='smaller')
    ax = plt.axes(projection='3d')
    ax.set_proj_type('ortho')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.set_axis_off()
    ax.set_title(surface.name, fontsize='xx-large')
    cbar = plt.colorbar(surface.cBar_ScalarMappable, ax=ax,  shrink=0.65, pad=-.01 )
    cbar.set_label(surface.cname, rotation=270, labelpad = 15)

    if show3D :
        ax.view_init(40,-60)
        surface.map_geom_from_datagrid( Z, scale=.3 ).shade(.1,ax=ax)
    else :
        ax.view_init(90,-90)

    ax.add_collection3d( surface)

    fig.tight_layout(pad=1)

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
        MRI3D()



except Exception:
    import traceback
    print(traceback.format_exc())
