
from xlcalcnet import gui
from pathlib import Path
import os, time
import numpy as np
from sklearn.decomposition import PCA


# see https://scikit-learn.org/stable/auto_examples/decomposition/plot_pca_iris.html


def PlotPCA(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'First three principal components'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 8
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 6
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    
    # Choose 'Agg' as backend unless we want to display the graphics
    if (OutputMode != 'gui'):
        import matplotlib
        matplotlib.use('Agg')
    import matplotlib.pyplot as plt

    plt.style.use(PlotStyle)

    from sklearn.datasets import load_iris

    iris = load_iris(as_frame=True)
    #print(iris.keys())

    fig = plt.figure(1, figsize=(FigSizeX, FigSizeY))
    ax = fig.add_subplot(111, projection='3d', elev=-150, azim=110)

    X_reduced = PCA(n_components=3).fit_transform(iris.data)
    scatter = ax.scatter(
        X_reduced[:, 0],
        X_reduced[:, 1],
        X_reduced[:, 2],
        c=iris.target,
        s=40,
    )

    ax.set(
        title=Title,
        xlabel='1st Principal Component',
        ylabel='2nd Principal Component',
        zlabel='3rd Principal Component',
    )
    ax.xaxis.set_ticklabels([])
    ax.yaxis.set_ticklabels([])
    ax.zaxis.set_ticklabels([])

    # Add a legend
    legend1 = ax.legend(
        scatter.legend_elements()[0],
        iris.target_names.tolist(),
        loc='upper right',
        title='Classes',
    )
    ax.add_artist(legend1)


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
        start0 = time.time()
        PlotPCA(OutputMode = 'gui')
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())
