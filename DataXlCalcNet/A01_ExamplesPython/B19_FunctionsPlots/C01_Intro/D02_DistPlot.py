from xlcalcnet import gui
from xlcalcnet import sreal, dreal, ereal, qreal, oreal
import os, re
import matplotlib.pyplot as plt
import numpy as np
import math



def DistPlot(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Distribution: pdf'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4.5
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    dlist = kwargs['dlist'] if 'dlist' in kwargs else None
    xlim = kwargs['xlim'] if 'xlim' in kwargs else None
    ylim = kwargs['ylim'] if 'ylim' in kwargs else None
    ltext = kwargs['ltext'] if 'ltext' in kwargs else ''
    target = kwargs['target'] if 'target' in kwargs else 'pdf'
    marker = kwargs['marker'] if 'marker' in kwargs else ''
    lattice = kwargs['lattice'] if 'lattice' in kwargs else False
# End of custom key word arguments


    flen=len(dlist)
    ctx = dreal
    f = []
    title2 = target
    for j in range(flen):
        if target=='pdf':
            f.append(dlist[j].pdf)
        elif target=='pmf':
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
    if lattice:
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
    for j in range(flen):
#        ax.plot(x, flist[j], marker='o')
        ax.plot(x, flist[j], marker=marker)

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





try:
    if __name__ == '__main__':

#        Title = 'Arcsine distribution'
#        target = 'pdf' # pdf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
#        a = [-1.5, 0.0, 1.5]
#        b = [5.1, 6.1, 8.8]
#        xlim = [-2.0, 8.8]
#        ylim = None
#        if target=='hf': ylim=[0, 6]
#
#        dlist = []
#        ltext = []
#        for j in range(len(a)):
#            dlist.append(dreal.dist_arcsine(a[j], b[j]))
#            ltext.append('a=' + str(a[j]) + ', b=' + str(b[j]))
#
#        DistPlot(Title = 'Arcsine distribution', dlist=dlist, xlim = xlim, 
#            ylim = ylim, target = target, ltext = ltext, marker='o')
        
        Title = 'Geometric distribution'
        target = 'isf' # pmf, cdf, 'sf', 'hf', 'chf', 'qtf', 'isf'
        p = [0.1, 0.5, 0.9]
        xlim = [0.0, 9.0]
        ylim = None
        if target=='hf': ylim=[0, 6]

        dlist = []
        ltext = []
        for j in range(len(p)):
            dlist.append(dreal.dist_geometric(p[j]))
            ltext.append('p=' + str(p[j]))
        DistPlot(Title = Title, dlist=dlist, xlim = xlim,  ylim = ylim, 
            target = target, ltext = ltext, lattice=True, marker='o')





except Exception:
    import traceback
    print(traceback.format_exc())


