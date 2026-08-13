

# See: https://plotly.com/python/tile-county-choropleth/#introduction-main-parameters-for-choropleth-tile-maps

from xlcalcnet import gui
import os, re
import plotly.express as px
import geopandas as gpd


def MontrealVoting(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'MontrealVoting'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 7
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 7
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    df = px.data.election()
    geo_df = gpd.GeoDataFrame.from_features(
        px.data.election_geojson()["features"]
    ).merge(df, on="district").set_index("district")

    fig = px.choropleth_map(geo_df,
                               geojson=geo_df.geometry,
                               locations=geo_df.index,
                               color="Joly",
                               center={"lat": 45.5517, "lon": -73.7073},
                               map_style="open-street-map",
                               zoom=8.5)


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
        MontrealVoting()


except Exception:
    import traceback
    print(traceback.format_exc())



