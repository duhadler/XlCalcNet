
# See: https://plotly.com/python/3d-charts/

# See: https://plotly.com/python/trisurf/

from xlcalcnet import gui
import os, re

import plotly.figure_factory as ff

import numpy as np
from scipy.spatial import Delaunay



def Boy(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Boy'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 8
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    u=np.linspace(-np.pi/2, np.pi/2, 60)
    v=np.linspace(0, np.pi, 60)
    u,v=np.meshgrid(u,v)
    u=u.flatten()
    v=v.flatten()

    x = (np.sqrt(2)*(np.cos(v)*np.cos(v))*np.cos(2*u) + np.cos(u)*np.sin(2*v))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))
    y = (np.sqrt(2)*(np.cos(v)*np.cos(v))*np.sin(2*u) - np.sin(u)*np.sin(2*v))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))
    z = (3*(np.cos(v)*np.cos(v)))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))

    points2D = np.vstack([u, v]).T
    tri = Delaunay(points2D)
    simplices = tri.simplices

    fig = ff.create_trisurf(x=x, y=y, z=z,
                             colormap=['rgb(50, 0, 75)', 'rgb(200, 0, 200)', '#c8dcc8'],
                             show_colorbar=True,
                             simplices=simplices,
                             title=dict(text="Boy's Surface"))


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
        Boy()


except Exception:
    import traceback
    print(traceback.format_exc())








