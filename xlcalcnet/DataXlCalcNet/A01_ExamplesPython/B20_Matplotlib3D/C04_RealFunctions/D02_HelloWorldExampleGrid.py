from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def HelloWorldExampleGrid(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define function to examine .....................................

    def Image_demo(xyz) : # ..... for surface geometry
        x,y,z = xyz
        X,Y = 3*x, 3*y
        Z1 = np.exp(-X**2 - Y**2)
        Z2 = np.exp(-(X - 1)**2 - (Y - 1)**2)
        Z = Z1-Z2
        return x,y,Z

    def vertical_position(xyz) : # ..... for colormapping
        x,y,z = xyz
        return z

    # 2. Setup and map surfaces .........................................
    rez = 4

    surface = s3d.PlanarSurface(rez,'squ')
    surface.map_geom_from_op( Image_demo )
    surface.map_cmap_from_op( vertical_position )
    surface.set_facecolor([1,1,1])

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure(figsize=plt.figaspect(0.75))
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=( -0.8,0.8 ), ylim=( -0.8,0.8 ), zlim=( -0.8,0.8 ) )
    ax.set_axis_off()
    ax.view_init(20,-55)

    fig.text(0.05,0.05,str(surface), ha='left', va='bottom', fontsize='smaller')
    ax.set_title(surface.name, fontsize='x-large')
    cbar = plt.colorbar(surface.cBar_ScalarMappable, ax=ax,  shrink=0.6 )
    cbar.set_label(surface.cname, rotation=270, labelpad = 15)

    ax.add_collection3d(surface)

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
        HelloWorldExampleGrid()


except Exception:
    import traceback
    print(traceback.format_exc())
