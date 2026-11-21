

# See: https://plotly.com/python/choropleth-maps/

from xlcalcnet import gui
import os, re
import plotly.graph_objects as go
import pandas as pd



def US_Agriculture(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'US_Agriculture'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments



    df = pd.read_csv('https://raw.githubusercontent.com/plotly/datasets/master/2011_us_ag_exports.csv')

    for col in df.columns:
        df[col] = df[col].astype(str)

    df['text'] = df['state'] + '<br>' + \
        'Beef ' + df['beef'] + ' Dairy ' + df['dairy'] + '<br>' + \
        'Fruits ' + df['total fruits'] + ' Veggies ' + df['total veggies'] + '<br>' + \
        'Wheat ' + df['wheat'] + ' Corn ' + df['corn']

    fig = go.Figure(data=go.Choropleth(
        locations=df['code'],
        z=df['total exports'].astype(float),
        locationmode='USA-states',
        colorscale='Reds',
        autocolorscale=False,
        text=df['text'], # hover text
        marker_line_color='white', # line markers between states
        colorbar=dict(
            len=0.9,
            title=dict(
                text="Millions USD"
                )
        )
    ))


    fig.update_layout(
        title_text='2011 US Agriculture Exports by State<br>(Hover for breakdown)',
        width=FigSizeX * 100, height=FigSizeY * 100,
        geo = dict(
            scope='usa',
            projection=go.layout.geo.Projection(type = 'albers usa'),
            showlakes=True, # lakes
            lakecolor='rgb(255, 255, 255)'),
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
        US_Agriculture()


except Exception:
    import traceback
    print(traceback.format_exc())




