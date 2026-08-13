
from xlcalcnet import gui
from pathlib import Path
import os

import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import geopandas as gpd
import libpysal as lps
import esda
import mapclassify as mc

# See https://github.com/pysal/esda
# See: https://github.com/pysal/esda/blob/main/notebooks/spatial_autocorrelation_for_areal_unit_data.ipynb

# Note: !!! needs 17 seconds to read the data !!!
# https://github.com/pysal/esda/blob/main/notebooks/data/berlin-neighbourhoods.geojson


def BerlinEsda(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BerlinEsda'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 12
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    gdf = gpd.read_file("https://raw.githubusercontent.com/pysal/esda/main/notebooks/data/berlin-neighbourhoods.geojson")
    bl_df = pd.read_csv("https://raw.githubusercontent.com/pysal/esda/main/notebooks/data/berlin-listings.csv")
    geometry = gpd.points_from_xy(x=bl_df.longitude, y=bl_df.latitude, crs='epsg:4326')
    bl_gdf = gpd.GeoDataFrame(bl_df, geometry=geometry)
    bl_gdf["price"] = bl_gdf["price"].astype("float32")
    sj_gdf = gpd.sjoin(
        gdf, bl_gdf, how="inner", predicate="intersects", lsuffix="left", rsuffix="right"
    )
    median_price_gb = sj_gdf["price"].groupby([sj_gdf["neighbourhood_group"]]).mean()
    print(median_price_gb)

    gdf = gdf.join(median_price_gb, on="neighbourhood_group")
    gdf.rename(columns={"price": "median_pri"}, inplace=True)
    print(gdf.head(15))

    fig, axarr = plt.subplots(2, 2, figsize=(10, 8))


    pd.isnull(gdf["median_pri"]).sum()
    np.int64(2)
    gdf["median_pri"] = gdf["median_pri"].fillna(gdf["median_pri"].mean())
    gdf.plot(column="median_pri", ax=axarr[0][0])

    axarr[0][0].set_axis_off()
    axarr[0][0].set_title("Median Price")


    #
    #gdf.plot(column="median_pri", scheme="Quantiles", k=5, cmap="GnBu", legend=True, ax=axarr[0][1])

    df = gdf
    wq = lps.weights.Queen.from_dataframe(df, use_index=False, silence_warnings=True)
    wq.transform = "r"

    y = df["median_pri"]
    ylag = lps.weights.lag_spatial(wq, y)
    print(ylag)


    ylagq5 = mc.Quantiles(ylag, k=5)
    df.assign(cl=ylagq5.yb).plot(
        column="cl",
        categorical=True,
        k=5,
        #cmap="GnBu",
        linewidth=0.1,
        ax=axarr[0][1],
        edgecolor="white",
        legend=True,
    )
    axarr[0][1].set_axis_off()
    axarr[0][1].set_title("Spatial Lag Median Price (Quintiles)")
    #plt.show()



    df["lag_median_pri"] = ylag


    #f, ax = plt.subplots(1, 2, figsize=(2.16 * 4, 4))


    df.plot(
        column="median_pri", ax=axarr[1][0], edgecolor="k", scheme="quantiles", k=5, cmap="GnBu"
    )
    axarr[1][0].axis(df.total_bounds[np.asarray([0, 2, 1, 3])])
    axarr[1][0].set_title("Price")



    df.plot(
        column="lag_median_pri",
        ax=axarr[1][1],
        edgecolor="k",
        scheme="quantiles",
        cmap="GnBu",
        k=5,
    )
    axarr[1][1].axis(df.total_bounds[np.asarray([0, 2, 1, 3])])
    axarr[1][1].set_title("Spatial Lag Price")
    axarr[1][0].axis("off")
    axarr[1][1].axis("off")


    plt.tight_layout()
    fig = plt.gcf()


# Start of output choices
    if (OutputMode == 'plt'):
        plt.show()
    elif (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = (Path(__file__).stem)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName + '.' + OutputMode])
        plt.savefig(FullPath,  bbox_inches='tight')
        if OutputDir != 'Temp': print('Graphics written to: ', FullPath)
    plt.close('all')


try:
    if __name__ == '__main__':
        BerlinEsda()


except Exception:
    import traceback
    print(traceback.format_exc())











