from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def HelloWorldExample2b(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Hello World Example 2, peaks function from
    #   https://www.mathworks.com/help/matlab/ref/peaks.html

    # 1. Define function to examine .....................................

    def peaks(xyz) :
        x,y,z = xyz
        z =  3*(1 - x)**2 * np.exp(-x**2 - (y + 1)**2) \
            - 10*(x/5 - x**3 - y**5)*np.exp(-x**2 - y**2) \
            - 1./3*np.exp(-(x + 1)**2 - y**2)
        return x,y,z

    # 2. Setup and map surfaces .........................................
    rez = 6

    surface = s3d.PlanarSurface(rez,'oct1',cmap='RdYlBu').domain(3,3)
    surface.map_geom_from_op( peaks )
    surface.map_cmap_from_op( )

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure(figsize=plt.figaspect(0.75))
    ax = plt.axes(projection='3d')
    ax.view_init(20)
    s3d.auto_scale(ax,surface)

    fig.text(0.975,0.975,str(surface), ha='right', va='top', fontsize='smaller')
    ax.set_title(surface.name, fontsize='x-large')
    cbar = plt.colorbar(surface.cBar_ScalarMappable, ax=ax,  shrink=0.6 )
    cbar.set_label(surface.cname, rotation=270, labelpad = 15)
    ax.set( xlabel='X', ylabel='Y', zlabel='Z')

    ax.add_collection3d(surface.shade().hilite(.5))

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
        HelloWorldExample2b()


except Exception:
    import traceback
    print(traceback.format_exc())
