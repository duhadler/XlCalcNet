from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def SchwarzPSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SchwarzPSurface'
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

    #.. Schwarz P Surface

    def schwarzP(xyz) :
        x,y,z = xyz
        return np.cos(x) + np.cos(y) + np.cos(z)

    bcmap = cmu.binary_cmap('orange', 'yellowgreen')

    fig = plt.figure(figsize=(8,4))
    mnmx,tck = (-2*np.pi, 2*np.pi), (-2*np.pi, 0, 2*np.pi)

    for i,[dmn,title] in enumerate ( [ \
            [2*np.pi, r'-2$\pi$ < surface < 2$\pi$'],
            [  np.pi,  r'-$\pi$ < central section < $\pi$']   ] ) :
        ax =fig.add_subplot(121+i, projection='3d',aspect='equal')
        ax.set(xlabel='X',ylabel='Y',zlabel='Z',title=title,
            xlim=mnmx,  ylim=mnmx,  zlim=mnmx,
            xticks=tck, yticks=tck, zticks=tck )
        surface = s3d.Surface3DCollection.implsurf( schwarzP,6,dmn, cmap=bcmap )
        surface.map_cmap_from_normals(direction=ax)
        if i == 0 :
            fullSurf = copy.copy(surface)
            fullSurf.set_surface_alpha(0.01)
        else :
            surface = surface + fullSurf
        ax.add_collection3d(surface.shade(.3).hilite(0.7,focus=2))

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
        SchwarzPSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
