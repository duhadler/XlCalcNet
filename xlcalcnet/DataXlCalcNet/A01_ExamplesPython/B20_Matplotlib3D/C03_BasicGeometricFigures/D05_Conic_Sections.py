from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/lines/conic.html

def ConicSections(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments


    def cone(rtz) :
        r,t,z = rtz
        R = 0.5*(1.00001-z)
        return R,t,z

    rez=4
    surface = s3d.CylindricalSurface(rez,color='grey',lw=0.0).map_geom_from_op(cone)
    circle =    surface.contourLines( -0.4, direction=[0,0,1],   name='circle',    color='C0', coor='p' )
    ellipse =   surface.contourLines( -0.2, direction=[0.5,0,1], name='ellipse',   color='C1', coor='p' )
    parabola =  surface.contourLines(    0, direction=[1,0,.5],  name='parabola',  color='C2', coor='p' )
    X =         surface.contourLines(    0, direction=[1,0,0],   name='lines',     color='C3', coor='p' )
    hyperbola = surface.contourLines( 0.25, direction=[1,0,0],   name='hyperbola', color='C4', coor='p' )

    surface.shade().set_surface_alpha(.25)

    fval = 0.2
    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-0.8,0.8)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_title('conic sections')
    ax.set_axis_off()

    ax.add_collection3d(circle.fade(fval))
    ax.add_collection3d(ellipse.fade(fval))
    ax.add_collection3d(parabola.fade(fval))
    ax.add_collection3d(X.fade(fval))
    ax.add_collection3d(hyperbola.fade(fval))
    ax.legend()
    ax.add_collection3d(surface)

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
        ConicSections()


except Exception:
    import traceback
    print(traceback.format_exc())
