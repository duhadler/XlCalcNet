from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def GoursatSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'GoursatSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. Goursat Surface

    def goursat_tangle(xyz):
        x,y,z = xyz
        a,b,c = 0.0,-5.0,11.8
        return x**4+y**4+z**4+a*(x**2+y**2+z**2)**2+b*(x**2+y**2+z**2)+c

    rez,dmn = 6, 2.5
    surface = s3d.Surface3DCollection.implsurf( goursat_tangle,rez,dmn )
    surface.map_cmap_from_op(lambda c: s3d.SphericalSurface.coor_convert(c)[0])

    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set_title(surface.name,pad=-1)
    s3d.auto_scale(ax,surface)
    ax.set(xlabel='X',ylabel='Y',zlabel='Z')
    ax.set_box_aspect((1,1,0.9))
    ax.add_collection3d(surface.shade().hilite(focus=2))

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
        GoursatSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
