from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/lines/filled_octa_cont.html


def SphericalContourFilledSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SphericalContourFilledSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # 2. Setup and map surfaces .........................................
    rez,lrez = 5,4

    surface = s3d.SphericalSurface.platonic(rez,'octa')
    line = surface.contourLines(0.65)  # default: spherical contours
    fsurf = line.get_filled_surface(dist=0.33,coor='s',lrez=lrez)

    fsurf.map_cmap_from_op( lambda c : s3d.SphericalSurface.coor_convert(c)[0],'inferno')

    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975, str(surface)+'\n'+str(line)+'\n'+str(fsurf),
        ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = ( -0.5,0.5 )
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.set_axis_off()

    ax.add_collection(fsurf.shade(0.5,isAbs=True))

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
        SphericalContourFilledSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
