from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def Base3DClassSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    v = [ [  0, 0, 0 ],  [  0, 1, 0 ],  [ 1 , 1, 0 ],  [  1, 0, 0 ],
          [  0, 0, 1 ],  [  0, 1, 1 ],  [ 1 , 1, 1 ],  [  1, 0, 1 ]  ]
    f = [ [0,1,2,3], [3,2,6,7], [2,1,5,6], [1,0,4,5], [0,3,7,4], [4,7,6,5] ]
    facecolors = np.array( ['b', 'm', 'c', 'g', 'r', 'y' ] )

    surface = s3d.Surface3DCollection(v, f, facecolors=facecolors)
    surface.transform(scale=2,translate=[-1,-1,-1])
    surface.set_surface_alpha(.5)

    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-1.5,1.5)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_title(str(surface))
    ax.set_proj_type('ortho')

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
        Base3DClassSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
