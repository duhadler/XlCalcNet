from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def Mayavi(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Mayavi'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)


    #.. 3D Surface Plot

    # 1. Define function to examine .....................................

    def mayDemo(rtp) :
        r,theta,phi = rtp
        m0 = 4; m1 = 3; m2 = 2; m3 = 3; m4 = 6; m5 = 2; m6 = 6; m7 = 4
        R = np.sin(m0*phi)**m1 + np.cos(m2*phi)**m3 + np.sin(m4*theta)**m5 + np.cos(m6*theta)**m7
        x = R*np.sin(phi)*np.cos(theta)
        y = R*np.cos(phi)
        z = R*np.sin(phi)*np.sin(theta)
        return [x,y,z]

    def zAxisDir(rtp) : return s3d.SphericalSurface.coor_convert(rtp,True)[2]

    # 2. Setup and map surfaces .........................................
    cmap = cmu.hue_cmap('b','r',2.0,name='BlRd')
    illum = s3d.rtv([1,0,0.75],35,48)

    surface = s3d.SphericalSurface.grid(10*24,10*24)
    surface.map_geom_from_op(mayDemo,True).evert()
    surface.map_cmap_from_op(zAxisDir,cmap)

    # 3. Construct figures, add surface, plot ...........................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975,str(surface), ha='right', va='top',
            fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=(-1.2,1.2), ylim=(-0.8,1.6), zlim=(-1.2,1.2))
    ax.view_init(35,48)
    ax.set_axis_off()

    ax.add_collection3d(surface.shade(0.1,illum).hilite(.7,illum,focus=2))

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
        Mayavi()



except Exception:
    import traceback
    print(traceback.format_exc())
