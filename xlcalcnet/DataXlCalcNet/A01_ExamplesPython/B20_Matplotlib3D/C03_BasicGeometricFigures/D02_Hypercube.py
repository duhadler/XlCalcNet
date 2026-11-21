from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def Hypercube(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CplxSquare'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 6
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 5
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 128
# End of standard key word arguments

    import matplotlib.colors as mc

    innerSize=0.5
    backext = np.array( [ [-1,-1, 1], [-1, 1, 1], [-1, 1,-1], [-1,-1,-1] ] )
    frntext = np.multiply(backext,[-1,1,1])
    backinn = np.multiply(backext,innerSize)
    frntinn = np.multiply(backinn,[-1,1,1])
    temp = np.array([ backext, frntext, backinn, frntinn ])
    v = np.reshape( temp,[-1,3])

    extf = np.array([ [0,1,2,3], [1,2,6,5], [0,3,7,4], [4,7,6,5], [0,4,5,1], [3,2,6,7] ])
    intf = np.add(extf,8)
    edgf = [ [ 0, 8, 9, 1], [ 1, 9,13, 5], [ 5,13,12, 4], [ 4,12, 8, 0],
             [ 3,11,10, 2], [ 2,10,14, 6], [ 6,14,15, 7], [ 7,15,11, 3],
             [ 0, 3,11, 8], [ 1, 9,10, 2], [ 5, 6,14,13], [ 4,12,15, 7] ]
    f = np.concatenate((extf, intf, edgf), axis=0)

    color = mc.to_rgba('C0',0.2)

    surface = s3d.Surface3DCollection(v,f,color=color)

    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    minmax = (-1.2,1.2)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_title('4D-Hypercube\n'+str(surface))
    ax.set_axis_off()
    ax.view_init(20,-60)

    ax.add_collection3d(surface.shade(0.5,direction= [1,1,1], isAbs=True))

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
        Hypercube()



except Exception:
    import traceback
    print(traceback.format_exc())
