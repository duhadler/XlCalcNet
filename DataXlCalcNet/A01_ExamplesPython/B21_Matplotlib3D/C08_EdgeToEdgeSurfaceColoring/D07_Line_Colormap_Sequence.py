from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/lines/loop3d.html


def LineColormapSequence(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'LineColormapSequence'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    # 1. Define function to examine .....................................

    n_mer, n_long = 6, 11

    def sop(t) :
        phi = 2*np.pi*t      # 0 <= phi <= 2pi
        f = np.sin(n_mer * phi)
        return f

    def test_plot3d(t) :
        phi = 2*np.pi*t      # 0 <= phi <= 2pi
        x = np.cos(n_mer * phi) * (1 + np.cos(n_long * phi) * 0.5)
        y = np.sin(n_mer * phi) * (1 + np.cos(n_long * phi) * 0.5)
        z = np.sin(n_long * phi) * 0.5
        return x,y,z

    # 2. Setup and map line .............................................
    rez = 9

    line = s3d.ParametricLine(rez,test_plot3d,lw=5)
    line.map_cmap_from_sequence('Spectral',sop).shade(0.4,[1,1,.5])

    # 3. Construct figure, add surface, and plot ........................

    fig = plt.figure(figsize=plt.figaspect(1))
    linelabel = str(line)+'\n'+line.cname + '() sequential operation'
    fig.text(0.05,0.05,linelabel, ha='left', va='bottom', fontsize='smaller')

    ax = plt.axes(projection='3d',facecolor='w', aspect='equal')
    ax.set_axis_off()
    minmax = (-1,1)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.view_init(35,40)

    ax.add_collection3d(line)

    fig.tight_layout(pad=2)

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
        LineColormapSequence()



except Exception:
    import traceback
    print(traceback.format_exc())
