from xlcalcnet import gui
from pathlib import Path
import os
import matplotlib.pyplot as plt
import numpy as np

# see https://matplotlib.org/stable/gallery/lines_bars_and_markers/fill_between_alpha.html#sphx-glr-gallery-lines-bars-and-markers-fill-between-alpha-py


def RandomWalk(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'RandomWalk'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # Fixing random state for reproducibility
    np.random.seed(19680801)

    Nsteps, Nwalkers = 100, 250
    t = np.arange(Nsteps)

    # an (Nsteps x Nwalkers) array of random walk steps
    S1 = 0.004 + 0.02*np.random.randn(Nsteps, Nwalkers)
    S2 = 0.002 + 0.01*np.random.randn(Nsteps, Nwalkers)

    # an (Nsteps x Nwalkers) array of random walker positions
    X1 = S1.cumsum(axis=0)
    X2 = S2.cumsum(axis=0)


    # Nsteps length arrays empirical means and standard deviations of both
    # populations over time
    mu1 = X1.mean(axis=1)
    sigma1 = X1.std(axis=1)
    mu2 = X2.mean(axis=1)
    sigma2 = X2.std(axis=1)

    # plot it!
    fig, ax = plt.subplots(1)
    ax.plot(t, mu1, lw=2, label='mean population 1')
    ax.plot(t, mu2, lw=2, label='mean population 2')
    ax.fill_between(t, mu1+sigma1, mu1-sigma1, facecolor='C0', alpha=0.4)
    ax.fill_between(t, mu2+sigma2, mu2-sigma2, facecolor='C1', alpha=0.4)
    ax.set_title(r'random walkers empirical $\mu$ and $\pm \sigma$ interval')
    ax.legend(loc='upper left')
    ax.set_xlabel('num steps')
    ax.set_ylabel('position')
    ax.grid()

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
        RandomWalk()


except Exception:
    import traceback
    print(traceback.format_exc())


