from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/lines/conic.html


def GeometricMapping(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'GeometricAndColorDatagridMapping'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. Geometric and Color Datagrid Mapping

    # 1. Define function to examine ....................................

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples', 'Pics'])


    Z=np.load(datapath + r'\jacksboro_fault_dem.npz')['elevation']
    datagrid = np.flip(Z,0)

    # 2. Setup and map surfaces .........................................
    rez=6

    fault = s3d.SphericalSurface(rez, cmap='jet')
    fault.map_cmap_from_datagrid(datagrid)
    fault.map_geom_from_datagrid(datagrid, scale=0.2)
    fault.shade(direction=[0,1,1],contrast=0.8)

    # 3. Construct figure, add surfaces, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1), facecolor='black' )
    fig.text(0.975,0.975,str(fault), ha='right', va='top',
            fontsize='smaller', multialignment='right', color='white')
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-0.8,0.8)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_facecolor('black')
    ax.set_axis_off()
    ax.view_init(0,90)

    ax.add_collection3d(fault)

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
        GeometricAndColorDatagridMapping()


except Exception:
    import traceback
    print(traceback.format_exc())
