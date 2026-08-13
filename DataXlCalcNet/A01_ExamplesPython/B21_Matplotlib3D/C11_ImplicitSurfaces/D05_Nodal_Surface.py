from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def NodalSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'NodalSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # 1. Define function to examine ....................................

    def nodesurf(xyz) :
        x,y,z = xyz
        i = 1j
        h = 1 + np.exp(i*x) + np.exp(i*y) + np.exp(i*z)
        return np.abs(h)-1

    # 2. Setup and map surface .........................................
    pi,p2 = np.pi, 2*np.pi
    cmap= cmu.rgb_cmap_gradient('red','khaki')

    surface = s3d.Surface3DCollection.implsurf( nodesurf,8,[0,p2])
    surface.map_cmap_from_normals(cmap )

    # 3. Construct figure, add surface, and plot ......................
    tks = [0,pi,p2]
    tklabels =  ['0',r'$\pi$',r'2$\pi$']
    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975,str(surface), ha='right', va='top', fontsize='smaller')
    ax = plt.axes(projection='3d', focal_length=0.5, aspect='equal' )
    ax.set(xlabel='k1', ylabel='k2', zlabel='k3', xticks=tks, yticks=tks, zticks=tks )
    ax.view_init(20,-45)
    ax.set_xticklabels(tklabels)
    ax.set_yticklabels(tklabels)
    ax.set_zticklabels(tklabels)
    s3d.auto_scale(ax,surface)

    ax.add_collection3d(surface.shade(.1).hilite())

    #fig.tight_layout(pad=0)

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
        NodalSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
