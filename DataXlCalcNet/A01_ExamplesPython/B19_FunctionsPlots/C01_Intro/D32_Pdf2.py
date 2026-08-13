from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/statistics/histogram_normalization.html#sphx-glr-gallery-statistics-histogram-normalization-py


def Pdf2Plot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FishCurveXY'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    rng = np.random.default_rng(19680801)

    xdata = rng.normal(size=1000)
    xpdf = np.arange(-4, 4, 0.1)
    pdf = 1 / (np.sqrt(2 * np.pi)) * np.exp(-xpdf**2 / 2)

    # changing the style of the histogram bars just to make it
    # very clear where the boundaries of the bins are:
    style = {'facecolor': 'none', 'edgecolor': 'C0', 'linewidth': 3}

    fig, ax = plt.subplot_mosaic([['False', 'True']], layout='constrained')
    #fig, ax = plt.subplot_mosaic([['False', 'True']])


    dx = 0.1
    xbins = np.arange(-4, 4, dx)
    ax['False'].hist(xdata, bins=xbins, density=False, histtype='step', label='Counts')

    # scale and plot the expected pdf:
    ax['False'].plot(xpdf, pdf * len(xdata) * dx, label=r'$N\,f_X(x)\,\delta x$')
    ax['False'].set_ylabel('Count per bin')
    ax['False'].set_xlabel('x bins [V]')
    ax['False'].legend()

    ax['True'].hist(xdata, bins=xbins, density=True, histtype='step', label='density')
    ax['True'].plot(xpdf, pdf, label='$f_X(x)$')
    ax['True'].set_ylabel('Probability density [$V^{-1}$]')
    ax['True'].set_xlabel('x bins [$V$]')
    ax['True'].legend()

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
        Pdf2Plot()


except Exception:
    import traceback
    print(traceback.format_exc())


