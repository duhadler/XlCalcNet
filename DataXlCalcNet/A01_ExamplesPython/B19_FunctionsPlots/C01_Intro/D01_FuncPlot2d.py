

from xlcalcnet import gui, math53
from pathlib import Path
import os
import matplotlib.pyplot as plt
from xlcalcnet import mpm


class NoConvergence(Exception):
    pass


def xarange(ctx, a, b, dt):
    a, b, dt = float(a), float(b), float(dt)
    result = []
    i = 0
    t = a
    while 1:
        t = a + dt*i
        i += 1
        if t < b:
            result.append(t)
        else:
            break
    return result



def FuncPlot2d(ctx=None, f=None, xlim=[-5,5], ylim=None, points=200, dpi=None, 
    singularities=[], axes=None, **kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FuncPlot2d'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 5
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    tada = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    plot_ignore = (ValueError, ArithmeticError, ZeroDivisionError, NoConvergence)
    fig = None
    if not axes:
        fig = plt.figure()
        axes = fig.add_subplot(111)
    if not isinstance(f, (tuple, list)):
        f = [f]
    a, b = xlim
    colors = ['b', 'r', 'g', 'm', 'k']
    for n, func in enumerate(f):
        x = xarange(ctx, a, b, (b-a)/float(points))
        segments = []
        segment = []
        in_complex = False
        for i in range(len(x)):
            try:
                if i != 0:
                    for sing in singularities:
                        if x[i-1] <= sing and x[i] >= sing:
                            raise ValueError
                v = func(x[i])
                if ctx.isnan(v) or abs(v) > 1e300:
                    raise ValueError
                if hasattr(v, "imag") and v.imag:
                    re = float(v.real)
                    im = float(v.imag)
                    if not in_complex:
                        in_complex = True
                        segments.append(segment)
                        segment = []
                    segment.append((float(x[i]), re, im))
                else:
                    if in_complex:
                        in_complex = False
                        segments.append(segment)
                        segment = []
                    if hasattr(v, "real"):
                        v = v.real
                    segment.append((float(x[i]), v))
            except plot_ignore:
                if segment:
                    segments.append(segment)
                segment = []
        if segment:
            segments.append(segment)
        for segment in segments:
            x = [s[0] for s in segment]
            y = [s[1] for s in segment]
            if not x:
                continue
            c = colors[n % len(colors)]
            if len(segment[0]) == 3:
                z = [s[2] for s in segment]
                axes.plot(x, y, '--'+c, linewidth=3)
                axes.plot(x, z, ':'+c, linewidth=3)
            else:
                axes.plot(x, y, c, linewidth=3)
    axes.set_xlim([float(_) for _ in xlim])
    if ylim:
        axes.set_ylim([float(_) for _ in ylim])
    axes.set_xlabel('x')
    axes.set_ylabel('f(x)')
    axes.grid(True)
    axes.legend(['First line', 'Second line'], loc='center right', bbox_to_anchor=(1.25, 0.5))

    
    plt.title(Title)

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
        #FuncPlot2d(ctx=mpm, f=[mpm.cos, mpm.sin], xlim=[-4, 4], Title = 'Plot2dCosSin')
        FuncPlot2d(ctx=math53, f=[math53.cos, math53.sin], xlim=[-4, 4], Title = 'Plot2dCosSin')

        #FuncPlot2d(ctx=mpm, f=mpm.cot, xlim=[-5, 5], ylim=[-5, 5], Title = 'Cot Bad, Mpm')   # bad
        #FuncPlot2d(ctx=math53, f=math53.cot, xlim=[-5, 5], ylim=[-5, 5], Title = 'Cot Bad, Math53')   # bad


except Exception:
    import traceback
    print(traceback.format_exc())


