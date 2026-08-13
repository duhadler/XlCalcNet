from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def SphereImplicitA(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SphereImplicitA'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    def sphere(xyz):
        x,y,z = xyz
        f = x**2 + y**2 + z**2 - 1.0
        return f

    #rez,dmn = 1, 1.1
    rez,dmn = 5, 1.1
    surface = s3d.Surface3DCollection.implsurf( sphere,rez,dmn,color='orange')


    fig = plt.figure(figsize=plt.figaspect(1))
    mnmx = (-1,0,1)
    fig.text(0.025,0.01,str(surface),ha='left', va='bottom', fontsize='x-small')
    #ax = plt.axes(projection='3d', aspect='equal')
    ax = plt.axes(projection='3d')
    ax.set_box_aspect((1,1,0.9))
    ax.set_title(surface.name)
    ax.set(xlabel='X',ylabel='Y',zlabel='Z',xticks=mnmx,yticks=mnmx,zticks=mnmx)
    ax.add_collection3d(surface.shade().hilite(focus=2))

    fig.tight_layout(pad=3)

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
        SphereImplicitA()



except Exception:
    import traceback
    print(traceback.format_exc())
