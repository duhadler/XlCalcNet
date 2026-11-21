from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def TwistSet(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'TwistSet'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    # 1. Define functions to examine ....................................

    def twistFunction(rtz,twists=6) :
        r,t,z = rtz
        phi = twists*t/2
        w = 0.33*z
        R = 1 + w * np.cos(phi)
        Z = w * np.sin(phi)
        return R,t,Z

    # 2 & 3. Construct figure & axes, add surfaces, show ................

    fig = plt.figure(figsize=plt.figaspect(0.6))
    for i in range(1,7) :
        ax = fig.add_subplot(2,3,i, projection='3d')
        ax.set(xlim=(-0.8,0.8), ylim=(-0.8,0.8), zlim=(-0.8,0.8) )
        ax.set_title('twists: '+str(i))
        ax.set_axis_off()

        twist = s3d.CylindricalSurface(5, basetype='squ_s', color=[1,.9,.75])
        twist.map_geom_from_op( lambda rtz : twistFunction(rtz,i) )
        twist.shade(direction=[1,1,1],ax=ax).hilite(direction=[1,1,1],ax=ax)

        ax.add_collection3d(twist)

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
        TwistSet()



except Exception:
    import traceback
    print(traceback.format_exc())
