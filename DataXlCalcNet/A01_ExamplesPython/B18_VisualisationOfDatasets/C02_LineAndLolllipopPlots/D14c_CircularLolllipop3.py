
# See: https://python-graph-gallery.com/web-circular-lollipop-plot-with-matplotlib/

from xlcalcnet import gui
from pathlib import Path
import os
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
 


def CircularLolllipop3(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CircularLolllipop3'
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


    # Different shades of grey used in the plot
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




    def circular_plot(angles, heights, colors, lw, ax):
        ax.set_facecolor("white")
        
        ax.set_rscale("symlog")
        ax.set_theta_offset(np.pi / 2)
        ax.set_theta_direction(-1)
        
        ax.spines["start"].set_color("none")
        ax.spines["polar"].set_color("none")
        
        ax.grid(False)
        ax.set_xticks([])
        ax.set_yticklabels([])
        
        # The 'lw' argument controls the width of the lines. 
        # This is going to be different for the top and lower panels.
        ax.vlines(angles, 0 + PLUS, heights + PLUS, color=colors, lw=lw)
        ax.scatter(angles, heights + PLUS, s=scale_to_interval(heights), color=colors)
        
        HANGLES = np.linspace(0, 2 * np.pi, 200)
        ax.plot(HANGLES, np.repeat(1 * 24 * 60 + PLUS, 200), color= GREY88, lw=0.7)
        ax.plot(HANGLES, np.repeat(7 * 24 * 60 + PLUS, 200), color= GREY85, lw=0.7)
        ax.plot(HANGLES, np.repeat(30 * 24 * 60 + PLUS, 200), color= GREY82, lw=0.7)
        ax.plot(HANGLES, np.repeat(365 * 24 * 60 + PLUS, 200), color= GREY79, lw=0.7)
        
        ax.fill(HANGLES, np.repeat(PLUS, 200), GREY97)
        
        # Change upper limit of the radial axis so larger dots fit within the plot area
        ax.set_rmax(ax.get_rmax() * 2)

    def map_category(category):
        if category == "cool-macho":
            return "cool-\nmacho"
        elif category == "nerdy-pop":
            return "nerdy-\npop"
        elif category == "password-related":
            return "password-\nrelated"
        elif category == "rebellious-rude":
            return "rebel-\nlious-\nrude"
        elif category == "simple-alphanumeric":
            return "simple-\nalpha-\nnumeric"
        else:
            return category

    CATEGORIES = sorted(pd.Categorical(df_pw["category"]).unique())
    LABELS = [map_category(category) for category in CATEGORIES]

    # The plot consists of 2 rows and 5 columns (10 categories in total)
    fig, axes = plt.subplots(2, 5, figsize=(14, 6), subplot_kw={"projection": "polar"})
    fig.patch.set_facecolor("white")

    # Define the slices used to iterate through 'axes'.
    # It iterates in a rowwise manner.
    # It starts in the first row, and iterates over all the columns of that row
    # from left to right, then it goes to the next row and does the same.
    SLICES = [(i, j) for i in range(2) for j in range(5)]

    for category, label, slice_ in zip(CATEGORIES, LABELS, SLICES):
        # Select axis
        ax = axes[slice_]
        
        # Select indexes corresponding to the passwords in this category
        idx = df_pw.index[df_pw["category"] == category].tolist()
        
        # Subset ANGLES, HEIGHTS, and COLORS to use the ones for this category.
        angles = ANGLES[idx]
        heights = HEIGHTS[idx]
        colors = COLORS[idx]
        
        # Create circular plot
        circular_plot(angles, heights, colors, 0.8, ax)
        
        # Add text within the inner circle representing the category
        ax.text(
            x=0.5, y=0.5, s=label, color=colors[0], va="center", ha="center",
            ma="center", 
            #fontfamily="Roboto Mono", 
            fontsize=14, fontweight="bold",
            linespacing=0.87, transform=ax.transAxes
        )

    # Adjust space between subplots.
    # 'wspace=0' leaves no horizontal space between subplots.
    # 'hspace=0' leaves no vertical space between subplots.
    fig.subplots_adjust(wspace=0, hspace=0)

    fig.tight_layout()


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
        CircularLolllipop3()


except Exception:
    import traceback
    print(traceback.format_exc())


