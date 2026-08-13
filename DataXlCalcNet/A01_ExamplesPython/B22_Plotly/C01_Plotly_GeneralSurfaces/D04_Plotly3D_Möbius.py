
# See: https://plotly.com/python/3d-charts/

# See: https://plotly.com/python/trisurf/
from xlcalcnet import gui
import os, re


import plotly.figure_factory as ff

import numpy as np
from scipy.spatial import Delaunay



def Mobius(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Mobius'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 8
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    u = np.linspace(0, 2*np.pi, 24)
    v = np.linspace(-1, 1, 8)
    u,v = np.meshgrid(u,v)
    u = u.flatten()
    v = v.flatten()

    tp = 1 + 0.5*v*np.cos(u/2.)
    x = tp*np.cos(u)
    y = tp*np.sin(u)
    z = 0.5*v*np.sin(u/2.)

    points2D = np.vstack([u,v]).T
    tri = Delaunay(points2D)
    simplices = tri.simplices

    fig = ff.create_trisurf(x=x, y=y, z=z,
                             colormap="Portland",
                             simplices=simplices,
                             title=dict(text="Mobius Band"))


# Start of output choices
    if (OutputMode == 'gui'):
        fig.show()
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        fig.write_image(FullPath + '.' + OutputMode)



try:
    if __name__ == '__main__':
        Mobius()


except Exception:
    import traceback
    print(traceback.format_exc())







