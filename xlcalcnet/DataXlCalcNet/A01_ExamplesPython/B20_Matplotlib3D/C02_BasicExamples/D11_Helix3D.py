from xlcalcnet import gui
import os, re
import numpy as np
import mpl_toolkits.mplot3d.axes3d as axes3d
import matplotlib.pyplot as plt

    # https://scipython.com/book2/chapter-7-matplotlib/examples/depicting-a-helix/

def Helix3d(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'KleinBottle'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)

    n = 1000
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')

    # Plot a helix along the x-axis
    theta_max = 8 * np.pi
    theta = np.linspace(0, theta_max, n)
    x = theta
    z =  np.sin(theta)
    y =  np.cos(theta)
    ax.plot(x, y, z, 'b', lw=2)

    # An line through the centre of the helix
    ax.plot((-theta_max*0.2, theta_max * 1.2), (0,0), (0,0), color='k', lw=2)
    # sin/cos components of the helix (e.g. electric and magnetic field
    # components of a circularly-polarized electromagnetic wave
    ax.plot(x, y, 0, color='r', lw=1, alpha=0.5)
    ax.plot(x, [0]*n, z, color='m', lw=1, alpha=0.5)

    # Remove axis planes, ticks and labels
    #ax.set_axis_off()
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
        Helix3d()

except Exception:
    import traceback
    print(traceback.format_exc())


