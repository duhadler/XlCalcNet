from xlcalcnet import gui
import os, re
import numpy as np
import mpl_toolkits.mplot3d.axes3d as axes3d
import matplotlib.pyplot as plt


# see: https://stackoverflow.com/questions/12287946/python-3d-plot-of-a-klein-bottle

def KleinBottle(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'KleinBottle'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)

    cos = np.cos
    sin = np.sin
    sqrt = np.sqrt
    pi = np.pi

    def surf(u, v):
        #http://paulbourke.net/geometry/klein/
        half = (0 <= u) & (u < pi)
        r = 4*(1 - cos(u)/2)
        x = 6*cos(u)*(1 + sin(u)) + r*cos(v + pi)
        x[half] = ( (6*cos(u)*(1 + sin(u)) + r*cos(u)*cos(v))[half])
        y = 16 * sin(u)
        y[half] = (16*sin(u) + r*sin(u)*cos(v))[half]
        z = r * sin(v)
        return x, y, z

    u, v = np.linspace(0, 2*pi, 40), np.linspace(0, 2*pi, 40)
    ux, vx =  np.meshgrid(u,v)
    x, y, z = surf(ux, vx)

    fig = plt.figure()
    ax = fig.add_subplot(projection='3d')
    plot = ax.plot_surface(x, y, z, rstride = 1, cstride = 1, cmap = plt.get_cmap('jet'),
                           linewidth = 0, antialiased = False)
    fig.tight_layout()

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
        KleinBottle()

except Exception:
    import traceback
    print(traceback.format_exc())


