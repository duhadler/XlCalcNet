from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/datagridmap/mri_3d.html


def JacksboroFault(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'JacksboroFault'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    import copy

    #.. Geometric and Color Datagrid Mapping, 2

    # 1. Define function to examine .....................................

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples', 'Pics'])


    Z=np.load(datapath + '/jacksboro_fault_dem.npz')['elevation']
    datagrid = np.flip(Z,0)

    # 2. Setup and map surfaces .........................................
    rez=6

    surface = s3d.PlanarSurface(rez, basetype='oct1', cmap='gist_earth')
    surface.map_cmap_from_datagrid( datagrid )
    surface.map_geom_from_datagrid( datagrid, scale=0.35 )

    surface.transform(translate=[0,0,0.5])  # move up to 0.5
    flat_surf = copy.copy(surface)
    # flatten and move down to -0.75
    flat_surf.map_geom_from_op(lambda c: [c[0],c[1],-0.75*np.ones_like(c[0])] )

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure()
    fig.text(0.975,0.975,str(surface), ha='right', va='top',
            fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=(-1,1), ylim=(-1,1), zlim=(-1,1) )
    minc, maxc = surface.bounds['vlim']
    cbar=plt.colorbar(surface.cBar_ScalarMappable, ax=ax,
            ticks=np.linspace(minc,maxc,5), shrink=0.6, pad=0  )
    cbar.set_label('Elevation', rotation=270, labelpad = 15)
    ax.set_axis_off()
    ax.set_proj_type('ortho')
    ax.view_init(elev=20, azim=60)

    surface.shade(depth=0,direction=(1,0,1),contrast=1.3)
    ax.add_collection3d(surface)
    ax.add_collection3d(s3d.PlanarSurface(color='k').domain(zcoor=0.5))
    ax.add_collection3d(flat_surf)

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
        JacksboroFault()



except Exception:
    import traceback
    print(traceback.format_exc())
