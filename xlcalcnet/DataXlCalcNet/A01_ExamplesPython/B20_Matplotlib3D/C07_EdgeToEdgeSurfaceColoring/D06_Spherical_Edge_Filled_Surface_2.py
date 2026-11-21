from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu

# See: https://s3dlib.org/examples/lines/filled_octa_cont.html


def EdgeToEdgeSurface2(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'EdgeToEdgeSurface2'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)


    import copy

    #.. Truncated Cube Edges to Edges Surface

    # 1. Define Truncated Cube geometry ...........................

    v = [
        [ 1, 0, 1], [ 0, 1, 1], [-1, 0, 1], [ 0,-1, 1],
        [ 1, 1, 0], [-1, 1, 0], [-1,-1, 0], [ 1,-1, 0],
        [ 1, 0,-1] ,[ 0, 1,-1], [-1, 0,-1], [ 0,-1,-1] ]
    f3 = [
        [ 0, 4, 1], [ 1, 5, 2], [ 2, 6, 3], [ 3, 7, 0],
        [ 9, 4, 8], [10, 5, 9], [11, 6,10], [ 8, 7,11] ]
    f4 = [
        [ 0, 1, 2, 3], [ 8,11,10, 9],
        [ 0, 7, 8, 4], [ 1, 4, 9, 5], [ 2, 5,10, 6],  [3, 6,11, 7] ]
    f = f3 + f4

    # 2. Setup and map surface .........................................
    cmA = cmu.hsv_cmap_gradient('darkslategrey','beige',smooth=1)
    cmB = cmu.hsv_cmap_gradient('beige','indianred',smooth=8)
    try:
        cmu.stitch_cmap(cmA,cmB,name='rhom2')
    except:
        pass
    lrez = 5

    surface = s3d.Surface3DCollection(v, f, name='Truncated Cube')
    edge = surface.initedges
    outerEdge = copy.copy(edge).transform(scale=2.0)
    fsurf = outerEdge.get_surface_to_line(edge,lrez=lrez)
    fsurf.map_cmap_from_op( lambda c : s3d.SphericalSurface.coor_convert(c)[0],'rhom2')

    # 3. Construct figure, add surface plot ............................

    fig = plt.figure(figsize=plt.figaspect(1))
    fig.text(0.975,0.975, str(surface)+'\n'+str(edge)+'\n'+str(fsurf),
        ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = plt.axes(projection='3d', aspect='equal')
    w = 0.8*fsurf.bounds['rorg'][1]
    minmax = (-w,w)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.set_proj_type('ortho')

    ax.add_collection3d(fsurf.shade(0.85,isAbs=True))

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
        EdgeToEdgeSurface2()



except Exception:
    import traceback
    print(traceback.format_exc())
