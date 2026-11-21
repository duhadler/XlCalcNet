from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d



def SphericalImageMapping(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SphericalImageMapping'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments


    #.. Spherical Image Mapping

    # 1. Define functions to examine ....................................
    # 2. Setup and map surfaces .........................................
    rez=6

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples',
        'Pics'])


    wmap = s3d.SphericalSurface(rez)
    wmap.map_color_from_image(datapath + r'\earth.png')
    wmap.shade(direction=[0,1,1],contrast=0.5)

    # 3. Construct figure, add surfaces, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1) )
    fig.text(0.975,0.975,str(wmap), ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = fig.add_subplot(111, projection='3d', aspect='equal')
    minmax = (-0.8,0.8)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_title('WMAP sphere')
    ax.set_axis_off()
    ax.view_init(0,90)

    ax.add_collection3d(wmap)

    fig.tight_layout(pad=2.5)

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
        SphericalImageMapping()



except Exception:
    import traceback
    print(traceback.format_exc())
