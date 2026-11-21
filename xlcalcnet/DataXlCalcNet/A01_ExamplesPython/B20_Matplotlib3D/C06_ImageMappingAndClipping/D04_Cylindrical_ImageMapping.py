from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def CylindricalImageMapping(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'CylindricalImageMapping'
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


    rez=7

    mars_surface = s3d.CylindricalSurface(rez)
    mars_surface.map_color_from_image(datapath + r'\earth.png')

    top_can = s3d.PolarSurface(rez-2)
    top_can.map_color_from_image(datapath + r'\earth.png')
    top_can.transform(translate=[0,0,1])

    can = (mars_surface + top_can).transform(scale=[1,1,.5]).shade(0.5,direction=[1,-.5,0])

    # 3. Construct figure, add surfaces, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1) )
    info = str(mars_surface) + '\n' + str(top_can) + '\nGreeley_Panorama'
    fig.text(0.975,0.975,info, ha='right', va='top', fontsize='smaller', multialignment='right')
    ax = fig.add_subplot(111, projection='3d', aspect='equal')
    minmax = (-0.8,0.8)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()
    ax.view_init(20,-75)

    ax.add_collection3d(can)

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
        CylindricalImageMapping()



except Exception:
    import traceback
    print(traceback.format_exc())
