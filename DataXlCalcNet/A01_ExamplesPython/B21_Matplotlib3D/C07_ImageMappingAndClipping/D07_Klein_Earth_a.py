from xlcalcnet import gui
import os, re
import numpy as np
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d



def KleinEarthA(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'KleinEarthA'
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

    # 1. Define function to examine ....................................
    def klein_bottle(rtz) :
        r,t,z = rtz
        u = np.pi*(1-z)/2
        v = -t
        cU, sU = np.cos(u), np.sin(u)
        cV, sV = np.cos(v), np.sin(v)
        x = -(2/15)*cU* \
            (  ( 3 )*cV + \
               ( -30 + 90*np.power(cU,4) - 60*np.power(cU,6) + 5*cU*cV )*sU  )
        y = -(1/15)*sU* \
            (  ( 3 - 3*np.power(cU,2) -48*np.power(cU,4) +48*np.power(cU,6) )*cV + \
               (-60 + ( 5*cU - 5*np.power(cU,3) - 80*np.power(cU,5) + 80*np.power(cU,7) )*cV  )*sU  )
        z = (2/15)*( 3 + 5*cU*sU )*sV
        return x,y,z

    # 2. Setup and map surface .........................................
    img_fname, rez = datapath + r"\earth.png", 7

    surface = s3d.CylindricalSurface(rez, color='w' )
    surface.map_color_from_image(img_fname)
    surface.map_geom_from_op( klein_bottle, returnxyz=True )
    surface.transform(s3d.eulerRot(90,-90),translate=[0,0,2])

    # 3. Construct figure, add surface plot ............................
    minmax = (-1.5,1.5)
    fig = plt.figure(figsize=plt.figaspect(1))
    ax = plt.axes(projection='3d', aspect='equal')
    ax.set(xlim=minmax, ylim=minmax, zlim=minmax)
    ax.set_title(surface.name)
    ax.set_axis_off()
    ax.view_init(elev=20, azim=-125)

    ax.add_collection3d(surface.shade(.5,ax=ax).hilite(ax=ax))

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
        KleinEarthA()



except Exception:
    import traceback
    print(traceback.format_exc())
