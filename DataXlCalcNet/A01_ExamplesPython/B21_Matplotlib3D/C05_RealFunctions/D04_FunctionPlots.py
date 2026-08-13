from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def FunctionPlots(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. Function plots, z = f(x,y)

    # 1. Define functions to examine ....................................
    # all functions normalized into the domain [-1.1]

    def Ackley(xyz) :
        x,y,z = xyz
        X,Y = 5*x, 5*y
        st1 = -0.2*np.sqrt( 0.5*( X*X + Y*Y) )
        Z1 = -20.0*np.exp(st1)
        st2 = 0.5*( np.cos(2*np.pi*X) +  np.cos(2*np.pi*Y) )
        Z2 = -np.exp(st2) + np.e + 20
        Z = Z1 + Z2
        return x,y, Z/8 - 1

    def Himmelblau(xyz) :
        x,y,z = xyz
        X,Y = 5*x, 5*y
        Z1 = np.square( X*X + Y - 11 )
        Z2 = np.square( Y*Y + X - 7  )
        Z = Z1 + Z2
        return x,y, Z/500 - 1

    def Rosenbrock(xyz) :
        x,y,z = xyz
        X,Y = 2*x, 2*y+1
        Z1 = np.square( 1 - X )
        Z2 = 100*np.square( Y - X*X  )
        Z = Z1 + Z2
        return x,y, Z/1000 - 1

    def Rastrigin(xyz) :
        x,y,z = xyz
        X,Y = 5*x, 5*y
        Z = 20 + X*X + Y*Y - 10*np.cos(2*np.pi*X) - 10*np.cos(2*np.pi*Y)
        return x,y, Z/40 - 1

    # ..........................
    def nonlinear_cmap(n) :
        # assume -1 < n < 1, nove to domain of [0,1]
        N = (n+1)/2
        return np.power( N, 0.1 )

    # 2 & 3. Setup surfaces and plot ....................................
    rez=6
    cmap = cmu.hsv_cmap_gradient( 'b' , 'r' , smooth=0.8)
    funcList = [ Ackley, Himmelblau, Rosenbrock, Rastrigin ]

    minmax, ticks = (-1,1), (-1,0,1)
    fig = plt.figure(figsize=(8,6))
    for i in range(4) :
        # setup surfaces .......
        surface = s3d.PlanarSurface(rez,basetype='oct1')
        surface.map_geom_from_op(funcList[i])
        surface.map_cmap_from_op(lambda xyz :  nonlinear_cmap(xyz[2]), cmap )
        # ......................
        ax = fig.add_subplot(2,2,1+i, projection='3d')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
        ax.set_title(surface.name, fontsize='large', horizontalalignment='left')
        ax.set_xticks(ticks)
        ax.set_yticks(ticks)
        ax.set_zticks(ticks)
        ax.set_proj_type('ortho')
        ax.view_init(25)

        ax.add_collection3d(surface.shade(.5))

    fig.tight_layout(pad=1)

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
        FunctionPlots()


except Exception:
    import traceback
    print(traceback.format_exc())
