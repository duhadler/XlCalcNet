from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d



def SphereImplicitB(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SphereImplicitB'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    #.. Supersphere

    def superSphere(xyz,N):
        x,y,z = xyz
        f = np.abs(x)**N + np.abs(y)**N +np.abs(z)**N - 1.0
        return f

    fig = plt.figure(figsize=plt.figaspect(1))
    rez,dmn,mnmx = 5,1.1,(-1,0,1)
    for i in range(1,5) :
        ax = fig.add_subplot(220+i, projection='3d', aspect='equal')
        ax.set_title('n = '+str(i),fontweight='bold',color='tab:brown')
        ax.set(xlabel='X',ylabel='Y',zlabel='Z',xticks=mnmx,yticks=mnmx,zticks=mnmx)
        ax.set_box_aspect((1,1,0.9))

        def sphere(xyz):
            return superSphere(xyz,i )
        surface = s3d.Surface3DCollection.implsurf( sphere,rez,dmn,color='orange')
        ax.add_collection3d(surface.shade().hilite(.95,direction=[1,-0.7,2],focus=2))

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
        SphereImplicitB()



except Exception:
    import traceback
    print(traceback.format_exc())
