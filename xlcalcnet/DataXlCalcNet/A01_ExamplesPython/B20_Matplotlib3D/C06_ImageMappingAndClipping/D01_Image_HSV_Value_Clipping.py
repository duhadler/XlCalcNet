from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def ImageHSVValueClipping(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'ImageHSVValueClipping'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)
    #.. Image HSV Value Clipping

    # 2. Setup and map surfaces .........................................
    rez, nlng = 6,18

    MyDocs = gui.get_my_documents()
    datapath = os.sep.join([MyDocs, 'DataXlCalcNet', 'DataExamples', 'MainExamples',
        'Pics'])

    earth = s3d.SphericalSurface(rez)
    earth.map_color_from_image(datapath + r'\elevation.png')
    earth.clip_alpha(.1,useval=True)
    earth.set_color('red')
    earth.transform(rotate=s3d.eulerRot(175,0) )
    earth.shade( direction=[1,0.8,1] ).fade(.3)

    grid = s3d.SphericalSurface.grid(nlng,2*nlng,'r').edges
    grid.set_color('slategrey')
    grid.set_linewidth(0.5)
    grid.fade()

    # 3. Construct figure, add surfaces, and plot ......................

    minmax = (-0.85,0.85)
    text = str(earth) + '\n' + str(grid)
    fig = plt.figure(figsize=plt.figaspect(1), facecolor='black' )
    fig.text(0.975,0.975,text, ha='right', va='top',
            fontsize='smaller', multialignment='right', color='white')
    ax = plt.axes(projection='3d', aspect='equal' ,facecolor='k')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_axis_off()

    ax.add_collection3d(earth)
    ax.add_collection3d(grid)

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
        ImageHSVValueClipping()



except Exception:
    import traceback
    print(traceback.format_exc())
