from xlcalcnet import gui
import os, re

import plotly.graph_objects as go



def Sankey1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Sankey1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 5
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    cA1 = "rgba(255, 0, 0, 0.5)"
    cA2 = "rgba(0, 255, 0, 0.5)"
    cA3 = "rgba(0, 0, 255, 0.5)"
    cA4 = "rgba(255, 128, 0, 0.5)"

    fig = go.Figure(data=[go.Sankey(
        node = dict(
          pad = 15,
          thickness = 60,
          line = dict(color = "black", width = 0.5),
          label = ["A1", "A2", "A3", "A4", "A1", "A2", "A3", "A4"],
          #color = ["blue", "yellow", "green", "red", "cyan", "orange"]
          color = [cA1, cA2, cA3, cA4, cA1, cA2, cA3, cA4]
        ),
        link = dict(
          source = [0, 0, 0, 0,  1, 1, 1, 1,  2, 2, 2, 2,  3, 3, 3, 3], 
          target = [4, 5, 6, 7,  4, 5, 6, 7,  4, 5, 6, 7,  4, 5, 6, 7],
          value =  [6, 2, 2, 1,  4, 2, 3, 1,  3, 2, 3, 1,  1, 1, 2, 3],
          color = [cA1, cA1, cA1, cA1, 
                    cA2, cA2, cA2, cA2, 
                    cA3, cA3, cA3, cA3,
                    cA4, cA4, cA4, cA4]

      ))])

    fig.update_layout(
        title_text="Basic Sankey Diagram", 
        width=FigSizeX * 100, height=FigSizeY * 100,
        font_size=15)


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
        Sankey1()


except Exception:
    import traceback
    print(traceback.format_exc())




