
# See: https://plotly.com/python/3d-charts/

# See: https://plotly.com/python/3d-surface-plots/

from xlcalcnet import gui
import os, re

import plotly.graph_objects as go
from plotly.subplots import make_subplots


def RingCyclide(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RingCyclide'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 7
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    # Equation of ring cyclide
    # see https://en.wikipedia.org/wiki/Dupin_cyclide
    import numpy as np
    a, b, d = 1.32, 1., 0.8
    c = a**2 - b**2
    u, v = np.mgrid[0:2*np.pi:200j, 0:2*np.pi:200j]
    #u, v = np.mgrid[0:2*np.pi:100j, 0:2*np.pi:100j]
    x = (d * (c - a * np.cos(u) * np.cos(v)) + b**2 * np.cos(u)) / (a - c * np.cos(u) * np.cos(v))
    y = b * np.sin(u) * (a - d*np.cos(v)) / (a - c * np.cos(u) * np.cos(v))
    z = b * np.sin(v) * (c*np.cos(u) - d) / (a - c * np.cos(u) * np.cos(v))

    fig = make_subplots(rows=1, cols=1,
                        specs=[[{'is_3d': True}]],
                        subplot_titles=['Color corresponds to z'],
                        )

    #fig = make_subplots(rows=1, cols=2,
    #                    specs=[[{'is_3d': True}, {'is_3d': True}]],
    #                    subplot_titles=['Color corresponds to z', 'Color corresponds to distance to origin'],
    #                    )

    fig.add_trace(go.Surface(x=x, y=y, z=z, colorbar_x=-0.07), 1, 1)
    #fig.add_trace(go.Surface(x=x, y=y, z=z, surfacecolor=x**2 + y**2 + z**2), 1, 2)

    #fig.update_layout(title_text="Ring cyclide")

    fig.update_layout(
        title=dict(text='Ring cyclide'),
        width=FigSizeX * 100, height=FigSizeY * 100,
        margin=dict(t=40, r=0, l=20, b=20)
    )


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
        RingCyclide()


except Exception:
    import traceback
    print(traceback.format_exc())

