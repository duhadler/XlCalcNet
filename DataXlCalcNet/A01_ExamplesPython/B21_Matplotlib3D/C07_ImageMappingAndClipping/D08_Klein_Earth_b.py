from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d



def KleinEarthB(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'KleinEarthB'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples',
        'Pics'])

    # 1. Define functions to examine ....................................
    def planarFunc(xyz) : # Himmelblau
        x,y,z = xyz
        X,Y = 5*x, 5*y
        Z1 = np.square( X*X + Y - 11 )
        Z2 = np.square( Y*Y + X - 7  )
        Z = (Z1 + Z2)/500 - 1
        return x,y,Z

    def screwFunc(rtz) :
        r,t,z = rtz
        T = 2*t
        Z = 0.2*(T - 2*np.pi)
        return r,T,Z

    def knotFunc(rtz) :
        r,t,z = rtz
        rho,zeta,delta,scale = 0.25, 0.25, 0.3, 1.1
        R = (1-rho)*(1-delta*np.sin(3*t)) + rho*np.cos(z*np.pi)
        Z = rho*np.sin(z*np.pi) + zeta*np.cos(3*t)
        return scale*R, 2*t, scale*Z

    def swirlFunc(rtp) :
        r,t,p = rtp
        R = 0.4*(2 + np.sin(5*t + 3*p))
        return R,t,p

    # 2. Setup and map surfaces .........................................
    img_fname =datapath + r'\earth.png'
    rez = 5

    planar = s3d.PlanarSurface(rez,basetype='oct1')
    planar.map_color_from_image(img_fname)
    planar.map_geom_from_op(planarFunc)

    screw = s3d.PolarSurface(rez, basetype='hex_s')
    screw.map_color_from_image(img_fname)
    screw.map_geom_from_op( screwFunc)

    knot = s3d.CylindricalSurface(rez, basetype='squ_s')
    knot.map_color_from_image(img_fname)
    knot.map_geom_from_op( knotFunc )

    swirl = s3d.SphericalSurface(rez)
    swirl.map_color_from_image(img_fname)
    swirl.map_geom_from_op( swirlFunc )

    # 3. Construct figure, add surfaces, and plot ......................
    minmax = (-.9,.9)
    fig = plt.figure(figsize=plt.figaspect(1) )
    for i,surface in enumerate( [planar,screw,knot,swirl] ) :
        ax = fig.add_subplot(221+i, projection='3d', aspect='equal')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
        ax.set_title(surface.name)
        ax.set_axis_off()

        ax.add_collection3d(surface.shade().hilite(.5))

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
        KleinEarthB()



except Exception:
    import traceback
    print(traceback.format_exc())
