from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def BoySurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'BoySurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Boy Surface

    # 1. Define function to examine ....................................

    def boy(xyz) :
        x,y,z = xyz
        u = np.pi*x/2
        v = np.pi*(1+y)/2
        X = (np.sqrt(2)*(np.cos(v)*np.cos(v))*np.cos(2*u) + np.cos(u)*np.sin(2*v))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))
        Y = (np.sqrt(2)*(np.cos(v)*np.cos(v))*np.sin(2*u) - np.sin(u)*np.sin(2*v))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))
        Z = (3*(np.cos(v)*np.cos(v)))/(2 - np.sqrt(2)*np.sin(3*u)*np.sin(2*v))
        return X,Y,Z

    def boygrad(xyz) :
        x,y,z = xyz
        Z = z - 1
        return np.sqrt( x*x + y*y + Z*Z )

    # 2. Setup and map surface .........................................
    rez = 7

    surface = s3d.PlanarSurface(rez, basetype='oct1')
    surface.map_geom_from_op(boy)
    surface.map_cmap_from_op( boygrad )
    surface.transform(s3d.eulerRot(90,0))

    # 3. Construct figure, add surface plot ............................

    fig = plt.figure(figsize=plt.figaspect(1), facecolor='k')
    ax = plt.axes(projection='3d', facecolor='k')
    ax.set_title("Boy Surface", fontsize="x-large", color='w')
    rng,zoff = 1.4, 1.0
    ax.set(xlim=(-rng,rng), ylim=(-rng,rng), zlim=(zoff,2*rng+zoff))
    ax.set_axis_off()
    ax.view_init(80, -20)

    ax.add_collection3d(surface.hilite(1,direction=[0.3,-.5,1.3]))

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
        BoySurface()



except Exception:
    import traceback
    print(traceback.format_exc())
