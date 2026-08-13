from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def RhombicuboctahedronPlain(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    z = np.sqrt(2) - 1
    v = [
        [ z, z, 1 ], [-z, z, 1 ], [-z,-z, 1 ], [ z,-z, 1 ],
        [ 1, z, z ], [ z, 1, z ], [-z, 1, z ], [-1, z, z ],
        [-1,-z, z ], [-z,-1, z ], [ z,-1, z ], [ 1,-z, z ],
        [ 1, z,-z ], [ z, 1,-z ], [-z, 1,-z ], [-1, z,-z ],
        [-1,-z,-z ], [-z,-1,-z ], [ z,-1,-z ], [ 1,-z,-z ],
        [ z, z,-1 ], [-z, z,-1 ], [-z,-z,-1 ], [ z,-z,-1 ]
    ]

    f4 = [
        [  0, 5, 6, 1 ], [  1, 7, 8, 2 ], [  2, 9,10, 3 ], [  3,11, 4, 0 ],
        [  4,12,13, 5 ], [  6,14,15, 7 ], [  8,16,17, 9 ], [ 10,18,19,11 ],
        [ 13,20,21,14 ], [ 15,21,22,16 ], [ 17,22,23,18 ], [ 19,23,20,12 ],

        [  0, 1, 2, 3 ],
        [  5,13,14, 6 ], [  7,15,16, 8 ], [  9,17,18,10 ], [ 11,19,12, 4 ],
        [ 20,23,22,21 ]
    ]
    f3 = [
        [  0, 4, 5 ], [  1, 6, 7 ], [  2, 8, 9 ], [  3,10,11 ],
        [  20,13,12], [ 21,15,14 ], [ 22,17,16 ], [23, 19,18 ]
    ]

    f = f4 + f3
    colors = ['beige']*12 + ['indianred']*6 + ['darkslategrey']*8

    def XYZtoMap(xyz) :
        r,t,p = s3d.SphericalSurface.coor_convert(xyz,False)
        r = np.ones(len(r))-0.33*r**4
        return s3d.SphericalSurface.coor_convert([r,t,p],True)

    import warnings
    with warnings.catch_warnings():
        warnings.simplefilter("ignore")    
        surface = s3d.Surface3DCollection(v, f, name='rhombicuboctahedron', 
            color=colors)

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.01,0.01,str(surface), ha='left', va='bottom',
        fontsize='smaller', multialignment='left')
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set_title('\n'+surface.name)
    w = 0.8*surface.bounds['rorg'][1]
    minmax = (-w,w)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.set_proj_type('ortho')

    ax.add_collection3d(surface.shade(0.25))

    fig.tight_layout(pad=0)

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
        RhombicuboctahedronPlain()



except Exception:
    import traceback
    print(traceback.format_exc())
