from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def ImplicitSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ImplicitSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    def bc_surf(xyz) :
        x,y,z = xyz
        V,A = (0.80)**2, 0.03
        f1 = ((x**2+y**2-V)**2+(z**2-1)**2)
        f2 = ((y**2+z**2-V)**2+(x**2-1)**2)
        f3 = ((z**2+x**2-V)**2+(y**2-1)**2)
        return f1*f2*f3 - A

    surface = s3d.Surface3DCollection.implsurf( bc_surf, 10, 1.1)

    fig = plt.figure(figsize=plt.figaspect(1), facecolor='k')
    fig.text(0.025,0.01,str(surface), ha='left', va='bottom',
        fontsize='smaller', color='navajowhite')
    ax = plt.axes(projection='3d', facecolor='k', aspect='equal')
    ax.set_box_aspect((1,1,0.9))
    ax.set_axis_off()
    ax.view_init(35,-70)
    s3d.auto_scale(ax,surface,uscale=.8)
    surface.map_cmap_from_normals('copper',ax)
    ax.add_collection3d(surface.shade(ax=ax).hilite(focus=2) )

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
        ImplicitSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
