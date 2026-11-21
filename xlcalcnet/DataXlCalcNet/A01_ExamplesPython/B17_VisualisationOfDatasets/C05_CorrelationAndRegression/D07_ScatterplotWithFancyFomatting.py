
# See: https://python-graph-gallery.com/web-scatterplot-text-annotation-and-regression-matplotlib/

from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np
import pandas as pd



def ScatterplotAnnotation(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ScatterplotAnnotation'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)



    #from adjustText import adjust_text
    from matplotlib.lines import Line2D # for the legend
    from sklearn.linear_model import LinearRegression

    corruption = pd.read_csv("https://raw.githubusercontent.com/holtzy/The-Python-Graph-Gallery/master/static/data/corruption.csv")

    corrupt = corruption.query("year == 2015").dropna()


    CPI = corrupt["cpi"].values
    HDI = corrupt["hdi"].values


    fig, ax = plt.subplots(figsize=(12, 8));
    #fig, ax = plt.subplots(figsize=(6, 4));


    def adjust_lightness(color, amount=0.5):
        import matplotlib.colors as mc
        import colorsys
        try:
            c = mc.cnames[color]
        except:
            c = color
        c = colorsys.rgb_to_hls(*mc.to_rgb(c))
        return colorsys.hls_to_rgb(c[0], c[1] * amount, c[2])



    # Okabe Ito colors
    REGION_COLS = ["#E69F00", "#56B4E9", "#009E73", "#F0E442", "#0072B2"]

    # Category values for the colors
    CATEGORY_CODES = pd.Categorical(corrupt["region"]).codes

    # Select colors for each region according to its category.
    COLORS = np.array(REGION_COLS)[CATEGORY_CODES]

    # Compute colors for the edges: simply darker versions of the original colors
    EDGECOLORS = [adjust_lightness(color, 0.6) for color in COLORS] 


    ax.scatter(
        CPI, HDI, color=COLORS, edgecolors=EDGECOLORS,
        s=80, alpha=0.5, zorder=10
    );
    # zorder = 10 is used to make sure markers are on top of the regression line added later


    # Some notes: 
    # * scikit-learn asks 2-dimensional arrays for X, that's why the reshape
    # * The response, y, does not need to be 2-dimensional
    X = CPI.reshape(-1, 1)
    y = HDI

    # Initialize linear regression object
    linear_regressor = LinearRegression()

    # Fit linear regression model of HDI on the log of CPI
    linear_regressor.fit(np.log(X), y)

    # Make predictions
    # * Construct a sequence of values ranging from 10 to 95 and
    #   apply logarithmic transform to them.
    x_pred = np.log(np.linspace(10, 95, num=200).reshape(-1, 1))

    # * Use .predict() method with the created sequence
    y_pred = linear_regressor.predict(x_pred)  

    # Plot regression line.
    # * Logarithmic transformation is reverted by using the exponential one.
    ax.plot(np.exp(x_pred), y_pred, color="#696969", lw=4)



    # Set default font size to 16
    plt.rcParams.update({"font.size": "16"})

    # Set y limits and y ticks
    ax.set_ylim(0.3, 1.05)
    ax.set_yticks([0.4, 0.6, 0.8, 1.0])

    # Set x limits and x ticks
    ax.set_xlim(10, 95)
    ax.set_xticks([20, 40, 60, 80])

    # Remove tick marks on both x and y axes
    ax.yaxis.set_tick_params(length=0)
    ax.xaxis.set_tick_params(length=0)

    # Add grid lines, only for y axis
    ax.grid(axis="y")

    # Remove all spines but keep the bottom one
    ax.spines["left"].set_color("none")
    ax.spines["right"].set_color("none")
    ax.spines["top"].set_color("none")

    # And finally set labels
    ax.set_xlabel("Corruption Perceptions Index, 2015 (100 = least corrupt)")
    ax.set_ylabel("Human Development Index, 2015\n(1.0 = most developed)")





    # Create handles -------------------------------------------------
    # Region names with linebreaks for the long ones
    REGIONS = [
        "Americas", "Asia Pacific", "Europe and\nCentral Asia", 
        "Middle East\nand North Africa", "Sub-Saharan\nAfrica"
    ]

    # Create handles for lines.
    handles = [
        Line2D(
            [], [], label=label, 
            lw=0, # there's no line added, just the marker
            marker="o", # circle marker
            markersize=10, 
            markerfacecolor=REGION_COLS[idx], # marker fill color
        )
        for idx, label in enumerate(REGIONS)
    ]

    # Append a handle for the line
    handles += [Line2D([], [], label="y ~ log(x)", color="#696969", lw=2)]

    # Add legend -----------------------------------------------------
    legend = fig.legend(
        handles=handles,
        bbox_to_anchor=[0.5, 0.95], # Located in the top-mid of the figure.
        fontsize=12,
        handletextpad=0.6, # Space between text and marker/line
        handlelength=1.4, 
        columnspacing=1.4,
        loc="center", 
        ncol=6,
        frameon=False
    )

    # Set transparency -----------------------------------------------
    # Iterate through first five handles and set transparency
    for i in range(5): 
        handle = legend.legend_handles[i]
        #handle._marker.set_alpha(0.5)



    # Save it! -------------------------------------------------------
    # Optional:
    # ax.set_facecolor("white") # set axis background color to white
    # fig.set_facecolor("white") # set figure background color to white
    # fig.savefig("plot.png", dpi=300)



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
        ScatterplotAnnotation()


except Exception:
    import traceback
    print(traceback.format_exc())


