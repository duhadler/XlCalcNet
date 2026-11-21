from xlcalcnet import gui
from xlcalcnet import sreal, dreal, ereal, qreal, oreal
from pathlib import Path
import os, time
import numpy as np


def step_no_vertical_line(x,y, ax=None, where='post', **kwargs):
    # see also: https://stackoverflow.com/questions/44961184/matplotlib-plot-only-horizontal-lines-in-step-plot
    assert where in ['post', 'pre']
    x = np.array(x)
    y = np.array(y)
    if where=='post': y_slice = y[:-1]
    if where=='pre': y_slice = y[1:]
    X = np.c_[x[:-1],x[1:],x[1:]]
    Y = np.c_[y_slice, y_slice, np.zeros_like(x[:-1])*np.nan]
    if not ax: ax=plt.gca()
    return ax.plot(X.flatten(), Y.flatten(), **kwargs)


def DistPlotDiscrete(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'DistPlotDiscrete'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'svg'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4.5
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    dlist = kwargs['dlist'] if 'dlist' in kwargs else None
    xlim = kwargs['xlim'] if 'xlim' in kwargs else None
    ylim = kwargs['ylim'] if 'ylim' in kwargs else None
    ltext = kwargs['ltext'] if 'ltext' in kwargs else ''
    target = kwargs['target'] if 'target' in kwargs else 'pmf'
    marker = kwargs['marker'] if 'marker' in kwargs else 'o'
    markersize = kwargs['markersize'] if 'markersize' in kwargs else 3
    lattice = kwargs['lattice'] if 'lattice' in kwargs else False
    vertical_lines = kwargs['vertical_lines'] if 'vertical_lines' in kwargs else True
    xoffset = kwargs['xoffset'] if 'xoffset' in kwargs else 0.20
    stemlinewidth = kwargs['stemlinewidth'] if 'stemlinewidth' in kwargs else 0.3
# End of custom key word arguments

    if (OutputMode != 'gui'):
        import matplotlib
        matplotlib.use('Agg')
    import matplotlib.pyplot as plt
    plt.style.use(PlotStyle)


    flen=len(dlist)
    ctx = dreal
    f = []
    title2 = target
    for j in range(flen):
        if target=='pmf':
            f.append(dlist[j].pmf)
        elif target=='cdf':
            f.append(dlist[j].cdf)
        elif target=='sf':
            f.append(dlist[j].sf)
            title2 = 'survival function'
        elif target=='hf':
            f.append(dlist[j].hf)
            title2 = 'hazard function'
        elif target=='chf':
            f.append(dlist[j].chf)
            title2 = 'cumulative hazard function'
        elif target=='qtf':
            f.append(dlist[j].qtf)
            title2 = 'quantile function'
            xlim = [0, 1]
        elif target=='isf':
            f.append(dlist[j].isf)
            title2 = 'inverse survival function'
            xlim = [0, 1]


# Data for plotting
    if (lattice and (target!='qtf') and (target!='isf')):
        Resolution = int(xlim[1] - xlim[0] + 1)
    x = np.linspace(xlim[0], xlim[1], Resolution)
    flist = []
    for j in range(flen):
        flist.append(np.zeros_like(x, dtype=np.float64))

    for j in range(flen):
        for k in range (x.size):
            flist[j][k] = float(f[j](x[k]))

# Format the plot
    plt.style.use(PlotStyle)

    fig, ax = plt.subplots(figsize=(FigSizeX, FigSizeY))
    rlist = []
    for j in range(flen):
        if (target=='pmf') or (target=='hf'):
            if vertical_lines==False: stemlinewidth = 0.0
            c = ['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd', 
                 '#8c564b', '#e377c2', '#7f7f7f', '#bcbd22', '#17becf']
            res = plt.stem(x + j * xoffset, flist[j], linefmt=c[j%10], 
                    markerfmt=marker)
            rlist.append(res)
            plt.setp(rlist[j][0], markersize=markersize) # markerline
            rlist[j][1].set_linewidth(stemlinewidth) # stemlines
            plt.setp(rlist[j][2], color='black', linewidth=1) # baseline
        else:
            if vertical_lines:
                ax.step(x, flist[j], where='post', marker=marker, 
                        markersize=markersize)
            else:
                step_no_vertical_line(x,flist[j], marker=marker, 
                        markersize=markersize)

    ax.set(xlabel='x', ylabel=target + '(x)', title=Title + ': ' + title2)
    plt.legend(ltext)
    if ylim:
        ax.set_ylim([float(_) for _ in ylim])

    ax.grid()
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


def DistPlotPoisson(target, mu, **kwargs):
    xlim = [0.0, 20.0]
    ylim = None
    if target=='qtf': ylim=[0, 20]

    dlist = []
    ltext = []
    for j in range(len(mu)):
        dlist.append(dreal.dist_poisson(mu[j]))
        ltext.append('mu=' + str(mu[j]))
    DistPlotDiscrete(dlist=dlist, xlim = xlim,  ylim = ylim, 
        target = target, ltext = ltext, lattice=True, marker='o', 
        markersize=3, vertical_lines=True, **kwargs)


try:
    if __name__ == '__main__':
        start0 = time.time()
        target = 'pmf' # 'pmf', 'cdf', 'sf', 'hf', 'chf', 'qtf', 'isf'
        mu = [1, 4, 10]
        DistPlotPoisson(target, mu, Title = 'Poisson distribution', OutputMode = 'gui')
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )

except Exception:
    import traceback
    print(traceback.format_exc())


