from xlcalcnet import gui
import os, re

import plotly.graph_objects as go
import pandas as pd


def MtBruno(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MtBruno'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 8
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    # Read data from a csv
    z_data = pd.read_csv('https://raw.githubusercontent.com/plotly/datasets/master/api_docs/mt_bruno_elevation.csv')

    fig = go.Figure(data=go.Surface(z=z_data, showscale=False))
    fig.update_layout(
        title=dict(text='Mt Bruno Elevation'),
        width=FigSizeX * 100, height=FigSizeY * 100,
        margin=dict(t=40, r=0, l=20, b=20)
    )

    name = 'default'
    # Default parameters which are used when `layout.scene.camera` is not provided
    camera = dict(
        up=dict(x=0, y=0, z=1),
        center=dict(x=0, y=0, z=0),
        eye=dict(x=1.25, y=1.25, z=1.25)
    )

    fig.update_layout(scene_camera=camera, title=name)


# Start of output choices
    if (OutputMode == 'gui'):
        fig.show()
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        fig.write_image(FullPath + '.' + OutputMode)
    #plt.close('all')


    #fig.show()

    #fig.write_image("fig1.png")
    #fig.write_image("fig1.svg")
    #fig.write_image("fig1.pdf")


try:
    if __name__ == '__main__':
        MtBruno()


except Exception:
    import traceback
    print(traceback.format_exc())

