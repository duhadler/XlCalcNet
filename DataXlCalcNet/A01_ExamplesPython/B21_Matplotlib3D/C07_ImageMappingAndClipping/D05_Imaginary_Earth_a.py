from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def ImaginaryEarthA(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ImaginaryEarthA'
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

    real = True
    imaginary =  not real

    def sqrt_Z(rtz, isReal) :
        r,t,z = rtz
        T=2*t
        if isReal :
            Z = np.sqrt(r)*np.cos(T/2)
        else :
            Z = np.sqrt(r)*np.sin(T/2)
        return r,T,Z

    # 2. Setup and map surfaces .........................................

    surface_1 = s3d.PolarSurface(6)
    surface_1.map_color_from_image(datapath + r"\earth.png")
    surface_1.transform(s3d.eulerRot(115,0))
    surface_1.map_geom_from_op( lambda rtz : sqrt_Z(rtz,imaginary) ).shade(.2,direction=[1,1,1])

    # 3. Construct figure, add surfaces, and plot .....................

    minmax = (-.8,.8)
    fig = plt.figure(figsize=plt.figaspect(1), facecolor='k')
    ax1 = fig.add_subplot(111, projection='3d', aspect='equal', facecolor='k')
    ax1.view_init(20, 205)
    ax1.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax1.set_title('Imaginary Earth',color='w')
    ax1.set_axis_off()

    ax1.add_collection3d(surface_1)

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
        ImaginaryEarthA()



except Exception:
    import traceback
    print(traceback.format_exc())
