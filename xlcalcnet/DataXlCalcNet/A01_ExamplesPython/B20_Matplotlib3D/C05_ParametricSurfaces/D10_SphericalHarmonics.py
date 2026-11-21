from xlcalcnet import gui
import os, re
import numpy as np
from scipy import special as sp  
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def SphericalHarmonics(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SphericalHarmonics'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)



    # 1. Define functions to examine ....................................
    def sphHar(rtp, m, n) :
        r, theta, phi = rtp
        R = sp.sph_harm(m, n, theta, phi).real
        return R, theta, phi

    def sphHar_absR(rtp, m, n) :
        r, theta, phi = sphHar(rtp, m, n)
        return np.abs(r), theta, phi

    # 2 & 3. Construct figure & axes, add surfaces, show ................

    fig = plt.figure(figsize=plt.figaspect(1))
    for m in range(3) :
        for n in range(1,4) :
            i = 3*m + n
            if i==7 : continue
            ax = fig.add_subplot(3,3,i, projection='3d')
            ax.set_title('('+str(m)+','+str(n)+')' , fontsize='large')

            surface = s3d.SphericalSurface(5, cmap="RdYlGn")
            surface.map_cmap_from_op( lambda rtp : sphHar(rtp,m,n)[0] )
            surface.map_geom_from_op( lambda rtp : sphHar_absR(rtp,m,n) )
            s3d.auto_scale(ax,surface,rscale=0.6).set_axis_off()

            ax.add_collection3d(surface.shade())

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
        SphericalHarmonics()



except Exception:
    import traceback
    print(traceback.format_exc())
