from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def Hyperboloid3D(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments


    def circle(t,r,z,twist) :
        theta = (2*t+twist)*np.pi
        x = r*np.cos(theta)
        y = r*np.sin(theta)
        z = z*np.ones(len(t))
        return x,y,z

    radius, twist = 1, 0.75
    def top_circle(t):
        return circle(t,radius,1,0.0)
    def btm_circle(t):
        return circle(t,radius,-1.0,twist)

    rez=3

    line_1 = s3d.ParametricLine(rez,top_circle,color='firebrick')
    line_2 = s3d.ParametricLine(rez,btm_circle,color='teal')
    lines = line_1 + line_2
    lines.set_linewidth(4)

    edges = line_1.get_surface_to_line(line_2).edges # create temp surface for 'simple' edges.
    edges.set_color('k')

    surface = line_1.get_surface_to_line(line_2,lrez=6) # surface takes line_1 color.
    surface.triangulate()


    minmax,ticks=(-1,1), [-1,0,1]
    fig = plt.figure(figsize=(8,4))
    for i in range(2):
        ax= fig.add_subplot(121+i, projection='3d')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax,
                xlabel='X', ylabel='Y', zlabel='Z',
                xticks=ticks, yticks=ticks, zticks=ticks
            )
        if i==0 :
            ax.add_collection3d(edges.fade())
            ax.add_collection3d(lines.fade(.25))
        else:
            ax.add_collection3d(surface.shade(.25,ax=ax))

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
        Hyperboloid3D()

except Exception:
    import traceback
    print(traceback.format_exc())
