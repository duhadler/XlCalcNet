from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu

# See also: https://s3dlib.org/tutorials/line_color/cmap_segment_tut.html
# See also: https://s3dlib.org/examples/lines/param_lineset.html


def LineSegment(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'LineSegment'
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

    def parametric_curve(t) :
        #...   0 < t < 1
        sc = (2*t -1 )
        r_0, twists = .25, 4
        z = sc
        r = r_0 + (1-r_0)*z**2
        theta = twists*np.pi*sc
        x = r*np.sin(theta)
        y = r*np.cos(theta)
        return z, x, y
##        return x,y,z

    # 2. Setup and map line .............................................
    rez=8
    line_color = [1,.9,.75]
    try:
        cmu.rgb_cmap_gradient([0.25,0.15,0],line_color,'cardboard')
    except:
        pass

    line_1 = s3d.ParametricLine(rez,parametric_curve,color=line_color,lw=8)
    line_1.shade()

##    line_2 = s3d.ParametricLine(rez,parametric_curve,cmap='cardboard',lw=5)
##    line_2.map_cmap_from_direction(isAbs=True)

    # 3. Construct figure, add line, and plot ...........................

    fig = plt.figure(figsize=(7,7))

    ax1 = fig.add_subplot(111, projection='3d')
    ax1.set(xlim=(-1,1), ylim=(-1,1), zlim=(-1,1) )
    ax1.set_title('shaded')
    ax1.set_aspect('equal')

    ax1.add_collection3d(line_1)
##    # .........
##    ax2 = fig.add_subplot(122, projection='3d')
##    ax2.set(xlim=(-1,1), ylim=(-1,1), zlim=(-1,1) )
##    ax2.set_title('cmap (isAbs=True)')
##    ax2.set_aspect('equal')
##
##    ax2.add_collection3d(line_2)
##    # .........


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
        LineSegment()



except Exception:
    import traceback
    print(traceback.format_exc())
