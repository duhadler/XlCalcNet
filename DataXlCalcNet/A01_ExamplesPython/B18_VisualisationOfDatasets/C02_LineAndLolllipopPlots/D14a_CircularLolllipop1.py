
# See: https://python-graph-gallery.com/web-circular-lollipop-plot-with-matplotlib/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
 


def CircularLolllipop1(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircularLolllipop1'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    df_pw = pd.read_csv('https://raw.githubusercontent.com/rfordatascience/tidytuesday/master/data/2020/2020-01-14/passwords.csv')
    # Remove rows where the password is missing
    df_pw = df_pw.dropna(subset=['password'])

    def to_seconds(value, time_unit):
        if time_unit == "seconds":
            return value
        elif time_unit == "minutes":
            return value * 60
        elif time_unit == "hours":
            return value * 60 * 60
        elif time_unit == "days":
            return value * 60 * 27
        elif time_unit == "weeks":
            return value * 60 * 24 * 7
        elif time_unit == "months":
            return value * 60 * 24 * 30
        elif time_unit == "years":
            return value * 60 * 24 * 365
        else:
            return np.nan

    TIMES = [
        to_seconds(row["value"], row["time_unit"])
        for _, row in df_pw.iterrows()
    ]

    TIME_MAX = np.max(TIMES)
    TIME_MIN = np.min(TIMES)

    # 'low' and 'high' refer to the final dot size.
    def scale_to_interval(x, low=1, high=60):
        return ((x - TIME_MIN) / (TIME_MAX - TIME_MIN)) * (high - low) + low

    # Different sades of grey used in the plot
    GREY88 = "#e0e0e0"
    GREY85 = "#d9d9d9"
    GREY82 = "#d1d1d1"
    GREY79 = "#c9c9c9"
    GREY97 = "#f7f7f7"
    GREY60 = "#999999"

    # Values for the x axis
    ANGLES = np.linspace(0, 2 * np.pi, len(TIMES), endpoint=False)

    # Heights of the lines and y-position of the dot are given by the times.
    HEIGHTS = np.array(TIMES)

    # Category values for the colors
    CATEGORY_CODES = pd.Categorical(df_pw["category"]).codes

    # Colormap taken from https://carto.com/carto-colors/
    COLORMAP = ["#5F4690", "#1D6996", "#38A6A5", "#0F8554", "#73AF48", 
                "#EDAD08", "#E17C05", "#CC503E", "#94346E", "#666666"]

    # Select colors for each password according to its category.
    COLORS = np.array(COLORMAP)[CATEGORY_CODES]


    # This is going to be helpful to create some space for labels within the circle 
    # Don't worry if it doesn't make much sense yet, you're going to see it in action below
    PLUS = 1000
    # Create a data frame with the information for the four passwords that are going to be labeled
    LABELS_DF = df_pw[df_pw["value"] > 90].reset_index()
    # Create labels
    LABELS_DF["label"] = [
        f"{pswrd}\nRank: {int(rank)}" 
        for pswrd, rank in zip(LABELS_DF["password"], LABELS_DF["rank"])
    ]

    # Set positions for the labels
    LABELS_DF["x"] = [40, 332, 401, 496]
    LABELS_DF["y"] = [160000000, 90000000, 45000000, 48498112]

    # Initialize layout in polar coordinates
    fig, ax = plt.subplots(figsize=(8, 8), subplot_kw={"projection": "polar"})

    # Set background color to white, both axis and figure.
    fig.patch.set_facecolor("white")
    ax.set_facecolor("white")

    # Use logarithmic scale for the radial axis
    ax.set_rscale('symlog')

    # Angular axis starts at 90 degrees, not at 0
    ax.set_theta_offset(np.pi / 2)

    # Reverse the direction to go counter-clockwise.
    ax.set_theta_direction(-1)

    # Add lines
    ax.vlines(ANGLES, 0 + PLUS, HEIGHTS + PLUS, color=COLORS, lw=0.9)

    # Add dots
    ax.scatter(ANGLES, HEIGHTS + PLUS, s=scale_to_interval(HEIGHTS), color=COLORS);



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
        CircularLolllipop1()


except Exception:
    import traceback
    print(traceback.format_exc())



