from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def Base3DClassSurface2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

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
        [16,11, 1,10], [16,12, 2,11], [16,13, 3,12], [16,14, 4,13], [16,10, 0,14]
    ]

    faceIndices_345  = [
        [ 5, 6, 7, 8, 9 ],
        [0, 5, 9], [1, 6, 5], [2, 7, 6], [3, 8, 7], [4, 9, 8],
        [5, 0,10, 1], [6, 1,11, 2], [7, 2,12, 3], [8, 3,13, 4], [9, 4,14, 0],
        [0,14,10], [1,10,11], [2,11,12], [3,12,13], [4,13,14],
        [ 14,13,12,11,10 ]
    ]

    import warnings
    with warnings.catch_warnings():
        warnings.simplefilter("ignore")    
        surface_4 =   s3d.Surface3DCollection(verts,faceIndices_4,  color='tan')
        surface_345 = s3d.Surface3DCollection(verts,faceIndices_345,color='tan')

    surfaces = [surface_4, surface_345]

    minmax = (-1.0,1.0)
    fig = plt.figure(figsize=(6,3))
    fig.text(0.25,0.95,"face vertices: 4", ha='center', va='top')
    fig.text(0.75,0.95,"initialized\nface vertices: 3, 4 & 5", ha='center', va='top')
    for i in range(len(surfaces)) :
        fig.text(0.25+0.5*i,0.05,str(surfaces[i]), ha='center', va='bottom',fontsize='small')
        ax =fig.add_subplot(121+i, projection='3d', aspect='equal')
        ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
        ax.set_axis_off()
        ax.set_proj_type('ortho')

        ax.add_collection3d(surfaces[i].shade())
        #ax.add_collection3d(surfaces[i].edges.fade(.05))

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
        Base3DClassSurface2()

except Exception:
    import traceback
    print(traceback.format_exc())
