from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np


#outpath = r'C:\Users\dietrichhadler\Documents\SVG'


#requires Python 3.9 or higher

def Cdf1Plot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Cdf1Plot'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    # see https://matplotlib.org/stable/gallery/statistics/histogram_cumulative.html#sphx-glr-gallery-statistics-histogram-cumulative-py

    np.random.seed(19680801)

    mu = 200
    sigma = 25
    n_bins = 25
    data = np.random.normal(mu, sigma, size=100)

    fig = plt.figure(figsize=(9, 4), layout="constrained")
    axs = fig.subplots(1, 2, sharex=True, sharey=True)

    # Cumulative distributions.
    axs[0].ecdf(data, label="CDF")
    n, bins, patches = axs[0].hist(data, n_bins, density=True, histtype="step",
                                   cumulative=True, label="Cumulative histogram")
    x = np.linspace(data.min(), data.max())
    y = ((1 / (np.sqrt(2 * np.pi) * sigma)) *
         np.exp(-0.5 * (1 / sigma * (x - mu))**2))
    y = y.cumsum()
    y /= y[-1]
    axs[0].plot(x, y, "k--", linewidth=1.5, label="Theory")

    # Complementary cumulative distributions.
    axs[1].ecdf(data, complementary=True, label="CCDF")
    axs[1].hist(data, bins=bins, density=True, histtype="step", cumulative=-1,
                label="Reversed cumulative histogram")
    axs[1].plot(x, 1 - y, "k--", linewidth=1.5, label="Theory")

    # Label the figure.
    fig.suptitle("Cumulative distributions")
    for ax in axs:
        ax.grid(True)
        ax.legend()
        ax.set_xlabel("Annual rainfall (mm)")
        ax.set_ylabel("Probability of occurrence")
        ax.label_outer()

# Start of output choices
    if (OutputMode == 'gui'):
        gui.plot(fig, __file__, Title)
    else:
        FName = 'Temp'
        if OutputDir != 'Temp': FName = re.sub('[^a-zA-Z0-9]', '', Title)
        LocalDir = gui.get_local_appdata_xlcalcnet()
        FullPath = os.sep.join([LocalDir, OutputDir, FName])
        plt.savefig(FullPath + '.' + OutputMode,  bbox_inches='tight')
    plt.close('all')



try:
    if __name__ == '__main__':
        Cdf1Plot()

except Exception:
    import traceback
    print(traceback.format_exc())


