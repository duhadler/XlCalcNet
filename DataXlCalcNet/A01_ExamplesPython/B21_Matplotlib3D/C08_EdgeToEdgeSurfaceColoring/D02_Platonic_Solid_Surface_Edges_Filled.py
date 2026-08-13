from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d

# See: https://s3dlib.org/examples/data_surface/inner_platonic.html


def PlatonicSolidSurfaceEdgesFilled(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'PlatonicSolidSurfaceEdgesFilled'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    def radial_Color_cyl(c):
        return s3d.CylindricalSurface.coor_convert(c)[0]

    verts,R,H = [None]*17 , np.cos(np.pi/5),np.sin(np.pi/5)
    for i in range(0,5) :
        verts[i] = [np.cos(2*i*np.pi/5),np.sin(2*i*np.pi/5),0.0]
    for i in range(5,10) :
        verts[i]   = [R*np.cos((1+2*i)*np.pi/5),R*np.sin((1+2*i)*np.pi/5), H]
        verts[i+5] = [R*np.cos((1+2*i)*np.pi/5),R*np.sin((1+2*i)*np.pi/5),-H]
    verts[15] = [0.0,0.0, 1/H]
    verts[16] = [0.0,0.0,-1/H]

    faceIndices_4  = [
        [15, 5, 1, 6], [15, 6, 2, 7], [15, 7, 3, 8], [15, 8, 4, 9], [15, 9, 0, 5],
        [ 5, 0,10, 1], [ 6, 1,11, 2], [ 7, 2,12, 3], [ 8, 3,13, 4], [ 9, 4,14, 0],
        [16,11, 1,10], [16,12, 2,11], [16,13, 3,12], [16,14, 4,13], [16,10, 0,14] ]
    faceIndices_345  = [
        [ 5, 6, 7, 8, 9 ],
        [0, 5, 9], [1, 6, 5], [2, 7, 6], [3, 8, 7], [4, 9, 8],
        [5, 0,10, 1], [6, 1,11, 2], [7, 2,12, 3], [8, 3,13, 4], [9, 4,14, 0],
        [0,14,10], [1,10,11], [2,11,12], [3,12,13], [4,13,14],
        [ 14,13,12,11,10 ]
    ]

    z = np.sqrt(2) - 1
    v_rmb = [
        [ z, z, 1 ], [-z, z, 1 ], [-z,-z, 1 ], [ z,-z, 1 ],
        [ 1, z, z ], [ z, 1, z ], [-z, 1, z ], [-1, z, z ],
        [-1,-z, z ], [-z,-1, z ], [ z,-1, z ], [ 1,-z, z ],
        [ 1, z,-z ], [ z, 1,-z ], [-z, 1,-z ], [-1, z,-z ],
        [-1,-z,-z ], [-z,-1,-z ], [ z,-1,-z ], [ 1,-z,-z ],
        [ z, z,-1 ], [-z, z,-1 ], [-z,-z,-1 ], [ z,-z,-1 ]
    ]
    faceIndices_rmb = [
        [  0, 5, 6, 1 ], [  1, 7, 8, 2 ], [  2, 9,10, 3 ], [  3,11, 4, 0 ],
        [  4,12,13, 5 ], [  6,14,15, 7 ], [  8,16,17, 9 ], [ 10,18,19,11 ],
        [ 13,20,21,14 ], [ 15,21,22,16 ], [ 17,22,23,18 ], [ 19,23,20,12 ],
        [  0, 1, 2, 3 ],
        [  5,13,14, 6 ], [  7,15,16, 8 ], [  9,17,18,10 ], [ 11,19,12, 4 ],
        [ 20,23,22,21 ],
        [  0, 4, 5 ], [  1, 6, 7 ], [  2, 8, 9 ], [  3,10,11 ],
        [  20,13,12], [ 21,15,14 ], [ 22,17,16 ], [23, 19,18 ]
    ]

    surface_4 =   s3d.Surface3DCollection(verts,faceIndices_4)
    line_4 = surface_4.edges.transform(scale=0.75)

    surface_345 = s3d.Surface3DCollection(verts,faceIndices_345)
    line_345 = surface_345.initedges

    surface_rmb = s3d.Surface3DCollection(v_rmb,faceIndices_rmb)
    line_rmb = surface_rmb.initedges

    lines = [ line_4, line_345, line_rmb ]

    fig = plt.figure(figsize=(8,8/3))
    minmax = (-.67,.67)
    for i,line in enumerate(lines) :
        ax =  fig.add_subplot(131+i, projection='3d', aspect='equal')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
        ax.set_axis_off()
        ax.set_proj_type('ortho')
        fsurface = line.shred(4).get_filled_surface(coor='c',dist=0.01, lrez=4 )
        fsurface.map_cmap_from_op( radial_Color_cyl,'rainbow_r' )

        ax.add_collection3d(fsurface.shade(0.4,ax=ax))

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
        PlatonicSolidSurfaceEdgesFilled()



except Exception:
    import traceback
    print(traceback.format_exc())
