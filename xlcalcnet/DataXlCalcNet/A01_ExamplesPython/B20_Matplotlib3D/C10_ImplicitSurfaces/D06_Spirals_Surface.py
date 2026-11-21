from xlcalcnet import gui
import os, re
import numpy as np
from scipy import special as sp
import matplotlib.pyplot as plt
import xlcalcnet.s3dlib.surface as s3d


def SpiralsSurface(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'SpiralsSurface'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 4
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 4
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments
    a = 1;
# End of custom key word arguments

    plt.style.use(PlotStyle)

    import math
    import matplotlib.patches as mpatches

    # 1. Define function to examine .....................................
    def Exyz(xyz):
        p,l,isCos = 1,2,True
        r, theta, z = s3d.CylindricalSurface.coor_convert(xyz)
        sr2 = math.sqrt(2)
        Em = math.factorial(p)/math.factorial(p+l) # M(-n,a+1,x)
        L = sp.genlaguerre(p,l)
        E = Em*( ((sr2*r)**l) * L(2*r**2) * np.exp(-(r**2)) )
        if isCos:
            E = E* (np.cos(l*theta-z))
        else:
            E = E* (np.sin(l*theta-z))
        return E

    rez,scol = 10,  ['lightsalmon', 'palegoldenrod']  #  for 3-D plot
    dmn = [  [-2,2], [-2,2], [-2*np.pi,2*np.pi] ]     #  evaluation domain
    Eo = 0.142
    Eo0, Eo1 = -Eo, Eo

    # 2. Setup and map surface .........................................
    surf_a = s3d.Surface3DCollection.implsurf( Exyz, rez, dmn, Eo0, color=scol[0]).evert()
    surf_b = s3d.Surface3DCollection.implsurf( Exyz, rez, dmn, Eo1, color=scol[1]).evert()
    surface = (surf_a + surf_b)

    # 3. Construct figure, add surface, and plot ......................
    fig = plt.figure(figsize=(5,5.5))
    fig.text(0.025,0.975,str(surface), ha='left', va='top', fontsize='x-small')
    ax = plt.axes(projection='3d', aspect='equal', focal_length=0.25)
    ax.view_init(20,-60)
    ax.set_title(surface.name)
    s3d.auto_scale(ax,surface)
    ax.set(xlabel='X',ylabel='Y',zlabel='Z')
    E0_patch = mpatches.Patch(label=r'$\ E_o$ =  '+str(Eo0), color=scol[0] )
    E1_patch = mpatches.Patch(label=r'$\ E_o$ = -'+str(Eo1), color=scol[1] )
    ax.legend(handles=[E0_patch,E1_patch])
    ax.add_collection3d( surface.shade(ax=ax).fade())

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
        SpiralsSurface()



except Exception:
    import traceback
    print(traceback.format_exc())
