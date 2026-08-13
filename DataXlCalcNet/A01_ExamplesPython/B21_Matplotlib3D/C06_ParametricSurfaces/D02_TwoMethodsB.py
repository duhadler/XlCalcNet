from xlcalcnet import gui
import os, re
import numpy as np
from scipy import special as sp
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d
import xlcalcnet.s3dlib.cmap_utilities as cmu


def TwoMethodsB(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'TwoMethodsB'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments

    plt.style.use(PlotStyle)



    def sphHar(rtp) :
        r, theta, phi = rtp
        m, L = 2,3
        r = sp.sph_harm(m, L, theta, phi).imag
        return r, theta, phi

    def sphHar_absR(rtp) :
        r, theta, phi = sphHar(rtp)
        return np.abs(r), theta, phi

    # 2. Setup and map surfaces .........................................
    rez = 5
    binmap = cmu.binary_cmap('goldenrod','darkcyan',)

    sph_23 = s3d.SphericalSurface(rez, basetype='octa', cmap='BrBG')
    sph_23.map_cmap_from_op( lambda rtp : sphHar(rtp)[0] ).shade(0.8)

    sph_23_pos = s3d.SphericalSurface(rez, basetype='octa', cmap=binmap)
    sph_23_pos.map_cmap_from_op( lambda rtp : sphHar(rtp)[0] )
    sph_23_pos.map_geom_from_op(sphHar_absR).shade()

    # 3. Construct figure, add surfaces, and plot .....................

    ticks1, ticks2 = [-1,-.5,0,.5,1] , [-.3,-.15,0,.15,.3]
    fig = plt.figure(figsize=plt.figaspect(0.5/1.2))
    ax1 = fig.add_subplot(121, projection='3d', aspect='equal')
    ax2 = fig.add_subplot(122, projection='3d', aspect='equal')
    ax1.set(xlim=(-1,1), ylim=(-1,1), zlim=(-1,1),
            xticks=ticks1, yticks=ticks1, zticks=ticks1 )
    ax2.set(xlim=(-.3,.3), ylim=(-.3,.3), zlim=(-.3,.3),
            xticks=ticks2, yticks=ticks2, zticks=ticks2 )
    ax1.set_title('Color representation\n'+r'rgb=f($\theta$,$\varphi$), r=1', pad=-1)
    ax2.set_title('Geometric representation\n'+r'R=|f($\theta$,$\varphi$)|', pad=-1)
    plt.colorbar(sph_23.cBar_ScalarMappable, ax=ax1,  shrink=0.6 )
    plt.colorbar(sph_23_pos.cBar_ScalarMappable, ax=ax2,  shrink=0.6 )

    ax1.add_collection3d(sph_23)
    ax2.add_collection3d(sph_23_pos)

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
        TwoMethodsB()



except Exception:
    import traceback
    print(traceback.format_exc())
