from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d



def Earth3D(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'Earth3D'
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


    # 2. Setup and map surfaces .........................................
    earth = s3d.SphericalSurface(6)
    earth.map_color_from_image(datapath + r'\earth.png')
    earth.map_geom_from_image(datapath + r'\elevation.png',0.06)
    earth.transform(rotate=s3d.eulerRot(175,0) )

    # 3. Construct figure, add surfaces, and plot ......................

    fig = plt.figure(figsize=plt.figaspect(1) )
    ax = plt.axes(projection='3d', facecolor='k')
    minmax = (-1,1)
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()

    ax.add_collection3d(earth.shade( contrast=1.7, direction=[1,0.8,1] ))

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
        Earth3D()



except Exception:
    import traceback
    print(traceback.format_exc())
