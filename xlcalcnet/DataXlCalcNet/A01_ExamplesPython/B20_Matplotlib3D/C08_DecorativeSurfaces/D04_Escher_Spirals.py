from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/showcase/sphericalspirals.html


def EscherSpirals(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EscherSpirals'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. influenced by M.C.Escher - Spirals
    #..  https://mcescher.com/gallery/mathematical/

    # 1. Define function to examine .....................................
    scolor =    [0.859, 0.788, 0.729]
    gbcolor =   [0.506, 0.482, 0.435]
    ttlcolor =  [0.502, 0.200, 0.278, 0.1]
    fgbgcolor = [0.867, 0.800, 0.729]
    elev, azim = 30,30
    illum = [0,-1,1 ]

    def twisted_torus(rtz,rotate) :
        twists, width, radMax, radMin, stretch = 5, 0.125, 0.6, 0.05, 1.4
        r,t,z = rtz
        ratio = radMax - t*(radMax-radMin)/(2.0*np.pi)
        phi =t*twists + rotate*2*np.pi + np.pi/4.0
        z = width*z
        Z = ratio*np.sin(z*np.pi+phi)
        R = r + ratio*np.cos(z*np.pi+phi)
        T = t*stretch
        return R,T,Z

    # 2. Setup and map surfaces .........................................

    surface = None
    rotation = [0.00, 0.25, 0.50, 0.75]
    for i,rot in enumerate(rotation) :
        t = s3d.CylindricalSurface.grid(50,500,'s',color=scolor )
        t.map_geom_from_op( lambda rtz : twisted_torus(rtz,rot) )
        if i == 0 :
             surface = t
        else :
            surface += t

    surface.transform(translate=[.3,0,0])
    # 3. Construct figure, add surface, plot ............................

    fig = plt.figure(figsize=(5,5) , facecolor=fgbgcolor)
    fig.text(0.97, 0.5, 'S3Dlib.org', color=ttlcolor, ha='right',
        va='center', rotation=90, fontsize=45, fontweight='bold'  )
    fig.text(0.11,0.12,str(surface),color=scolor ,fontsize='x-small')
    ax = plt.axes(projection='3d' )
    minmax = ( -1,1 )
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax )
    ax.set_axis_off()
    ax.view_init(elev, azim)
    ax.set_facecolor(gbcolor)

    surface.shade(    direction=illum,ax=ax,rview=True)
    surface.hilite(.5,direction=illum,ax=ax,rview=True)
    ax.add_collection3d(surface)

    fig.tight_layout(pad=3)

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
        EscherSpirals()



except Exception:
    import traceback
    print(traceback.format_exc())
