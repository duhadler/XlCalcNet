from xlcalcnet import gui
import os, re
import matplotlib.pyplot as plt
import matplotlib.collections as mcoll
import numpy as np
from matplotlib import cm
from scipy.integrate import ode as ode
from itertools import product
from matplotlib.patches import Circle

# The following code has been inspired by various sources, including:
# https://pythonmatplotlibtips.blogspot.com/2017/12/draw-electric-field-lines-with-changing-color.html
# https://pythonmatplotlibtips.blogspot.com/2017/12/draw-beautiful-electric-field-lines.html
# https://pythonmatplotlibtips.blogspot.com/2017/12/draw-electric-field-lines-without-mayavi.html
# https://pythonmatplotlibtips.blogspot.com/2017/12/plot-electric-field-lines-around-point.html
# https://stackoverflow.com/questions/69435068/change-colorbar-limit-for-changing-scale-with-matplotlib-3-3


class charge:
    def __init__(self, q, pos):
        self.q=q
        self.pos=pos
 

def colorline(x, y, v, cmap='copper', norm=plt.Normalize(-3.0, 3.0),
        linewidth=0.5, alpha=1.0):
    x,y,v = np.array(x),np.array(y),np.array(v)
    segments = make_segments(x, y)
    lc = mcoll.LineCollection(segments, array=v, cmap=cmap, norm=norm,
                              linewidth=linewidth, alpha=alpha)
    ax = plt.gca()
    ax.add_collection(lc)
    return lc


def make_segments(x, y):
    """
    Create list of line segments from x and y coordinates, in the correct format
    for LineCollection: an array of the form numlines x (points per line) x 2 (x
    and y) array
    """
    points = np.array([x, y]).T.reshape(-1, 1, 2)
    segments = np.concatenate([points[:-1], points[1:]], axis=1)
    return segments


def E_point_charge(q, a, x, y):
    return q*(x-a[0])/((x-a[0])**2+(y-a[1])**2)**(1.5), \
        q*(y-a[1])/((x-a[0])**2+(y-a[1])**2)**(1.5)

 
def E_total(x, y, charges):
    Ex, Ey=0, 0
    for C in charges:
        E=E_point_charge(C.q, C.pos, x, y)
        Ex=Ex+E[0]
        Ey=Ey+E[1]
    return [ Ex, Ey ]


def E_norm(x,y, charges):
    Ex, Ey = E_total(x, y, charges)
    return np.sqrt(Ex**2+Ey*Ey)


def E_dir(t, y, charges):
    Ex, Ey=E_total(y[0], y[1], charges)
    n=np.sqrt(Ex**2+Ey*Ey)
    return [Ex/n, Ey/n]


def V_point_charge(q, a, x, y):
    return q/((x-a[0])**2+(y-a[1])**2)**(0.5)


def V_total(x, y, charges):
    V=0
    for C in charges:
        Vp=V_point_charge(C.q, C.pos, x, y)
        V = V+Vp
    return V


def FieldLinesContours(**kwargs):
    OutputDir = kwargs['OutputDir'] if 'OutputDir' in kwargs else 'OutputMonitor'
    Title = kwargs['Title'] if 'Title' in kwargs else 'FieldLinesContours'
    PlotStyle = kwargs['PlotStyle'] if 'PlotStyle' in kwargs else 'default'
    OutputMode = kwargs['OutputMode'] if 'OutputMode' in kwargs else 'gui'
    FigSizeX = float(kwargs['FigSizeX']) if 'FigSizeX' in kwargs else 9 
    FigSizeY = float(kwargs['FigSizeY']) if 'FigSizeY' in kwargs else 7 
    Resolution = int(kwargs['Resolution']) if 'Resolution' in kwargs else 300
# End of standard key word arguments


    ContourFilled = kwargs['ContourFilled'] if 'ContourFilled' in kwargs else False
    # always True if HasConductingSphere==True

    ChargePositionModel = kwargs['Model'] if 'Model' in kwargs else 1
    #ChargePositionModel: 1, 2, 3, 4, 5

    contourlines = 10
    x0, x1=-2.5, 2.5
    y0, y1=-2.5, 2.5
    clim0,clim1 = -2,2
    R = 0.01
    RFactor = 0.8
    alphares = 32  # 16 for filled contour
    if ContourFilled: alphares = 16
    OnlyPositiveCharges = False
    HasConductingSphere = False


    # charges and positions
    if ChargePositionModel == 1:
        charges = [charge( 1, [-1,  0]), 
                   charge(-1, [ 1,  0]), 
                   charge(-1, [ 0,  1]), 
                   charge( 1, [ 0, -1])]
    if ChargePositionModel == 2:
        charges = [charge(-1, [-1,  0]), 
                   charge( 1, [ 1,  0]), 
                   charge( 1, [ 0,  1]), 
                   charge(-1, [ 0, -1])]
    if ChargePositionModel == 3:
        charges = [charge(-1, [-1,  0]), 
                   charge(-1, [ 1,  0]), 
                   charge( 1, [ 0,  1]), 
                   charge( 1, [ 0, -1])]
    if ChargePositionModel == 4:
        charges = [charge( 1, [0.56, 0.56]),
                   charge(-1, [0.26, 0.76]),
                   charge( 1, [0.66, 0.16]),
                   charge(-1, [0.66, 0.86])]
        x0, x1 = 0, 1
        y0, y1 = 0, 1
        RFactor = 0.5
        alphares = 32 
        OnlyPositiveCharges = True
        contourlines = 20
        clim0,clim1 = -20,20
    if ChargePositionModel == 5:
        a1 = 1
        q1 = 1
        r2 = 0.5
        b2 = (r2**2)/a1
        q2 = -r2/a1*q1
        charges=[ charge(q1, [a1, 0]), charge(q2,[b2,0])]

        x0, x1=-1, 3
        y0, y1=-2, 2
        alphares = 128
        contourlines = 20
        clim0,clim1 = 0,4
        HasConductingSphere = True
        ContourFilled = True

# End of custom key word arguments

    plt.style.use(PlotStyle)

    # Calculate field lines
    # loop over all charges
    xs,ys = [],[]
    es = []
    vs = []


    if HasConductingSphere:
        C = charges[0]
        # calculate field lines only from point charge outside of the sphere
        dt=0.8*R
        for alpha in np.linspace(0+2*np.pi/256, 2*np.pi*127/128+2*np.pi/256, 128):
            r=ode(E_dir)
            r.set_integrator('vode')
            r.set_f_params(charges)
            x=[ C.pos[0] + np.cos(alpha)*R ]
            y=[ C.pos[1] + np.sin(alpha)*R ]
            r.set_initial_value([x[0], y[0]], 0)
            while r.successful():
                r.integrate(r.t+dt)
                x.append(r.y[0])
                y.append(r.y[1])
                hit_charge=False
                # check if field line left drwaing area or ends in some charge
                for C2 in charges:
                    if np.sqrt((r.y[0]-C2.pos[0])**2+(r.y[1]-C2.pos[1])**2)<R:
                        hit_charge=True
                if hit_charge or (not (5*x0<r.y[0] and r.y[0]<5*x1)) or \
                        (not (5*y0<r.y[1] and r.y[1]<5*y1)):
                    break
            xs.append(x)
            ys.append(y)
    else:
        for C in charges:
            # plot field lines starting in current charge
            dt = RFactor * R
            if C.q<0:
                if OnlyPositiveCharges: 
                    # because the electric field lines start only from positive
                    # charge, skip the process when the current charge is negative.
                    continue
                else: dt=-dt
            # loop over field lines starting in different directions around 
            # current charge
            for alpha in np.linspace(0, 2*np.pi*(alphares-1)/alphares, alphares):
                r=ode(E_dir)
                r.set_integrator('vode')
                r.set_f_params(charges)
                x=[ C.pos[0] + np.cos(alpha)*R ]
                y=[ C.pos[1] + np.sin(alpha)*R ]
                if not ContourFilled:
                    e=[ E_norm(x[0],y[0],charges) ]
                    v=[ V_total(x[0],y[0],charges)]
                r.set_initial_value([x[0], y[0]], 0)
                while r.successful():
                    r.integrate(r.t+dt)
                    x.append(r.y[0])
                    y.append(r.y[1])
                    if not ContourFilled:
                        e.append(E_norm(r.y[0],r.y[1],charges))
                        v.append(V_total(r.y[0],r.y[1],charges))
                    hit_charge=False
                    # check if field line left drawing area or ends in some charge
                    for C2 in charges:
                        if np.sqrt((r.y[0]-C2.pos[0])**2+(r.y[1]-C2.pos[1])**2)<R:
                            hit_charge=True
                    if OnlyPositiveCharges:
                        if hit_charge:
                            break
                    else:
                        if hit_charge or (not (x0<r.y[0] and r.y[0]<x1)) or \
                                (not (y0<r.y[1] and r.y[1]<y1)):
                            break
                xs.append(x)
                ys.append(y)
                if not ContourFilled:
                    es.append(e)
                    vs.append(v)


    # calculate electric potential
    vvs = []
    xxs = []
    yys = []
    numcalcv = Resolution
    for xx,yy in product(np.linspace(x0,x1,numcalcv),np.linspace(y0,y1,numcalcv)):
        xxs.append(xx)
        yys.append(yy)
        vvs.append(V_total(xx,yy,charges))
    xxs = np.array(xxs)
    yys = np.array(yys)
    vvs = np.array(vvs)

    fig, ax = plt.subplots(facecolor="w",figsize=(FigSizeX, FigSizeY))


    # plot electric potential
    vvs[np.where(vvs<clim0)] = clim0*0.999999 # to avoid error
    vvs[np.where(vvs>clim1)] = clim1*0.999999 # to avoid error
    plt.tricontour(xxs,yys,vvs,contourlines,colors="0.3",linewidths=1.0)

    if ContourFilled:
        if HasConductingSphere:
            lw1=0.3
            plt.tricontourf(xxs,yys,vvs,100,cmap=cm.hot_r)
        else:
            lw1=1.0
            plt.tricontourf(xxs,yys,vvs,100,cmap=cm.jet)
        # plot field line        
        for x, y in zip(xs,ys):
            plt.plot(x, y, color="k", lw=lw1)
        # plot point charges
        for C in charges:
            if C.q>0:
                plt.plot(C.pos[0], C.pos[1], 'ro', ms=8*np.sqrt(C.q))
            if C.q<0:
                plt.plot(C.pos[0], C.pos[1], 'bo', ms=8*np.sqrt(-C.q))
        cbar = plt.colorbar()
        cbar.mappable.set_clim(clim0,clim1)
        cbar.set_ticks(np.linspace(clim0,clim1,9))
    else:
        for x,y,v in zip(xs,ys,vs):
            lc = colorline(x, y, v, cmap='jet',linewidth=1.0)
        cbar = plt.colorbar(lc)
    cbar.set_label("Electric Potential")

    if HasConductingSphere:
        # plot grounded sphere
        c = plt.Circle((0, 0), radius=r2, edgecolor="k",facecolor='w', linewidth=1,zorder=10)
        ax.add_patch(c)


    plt.xlim(x0, x1)
    plt.ylim(y0, y1)
    fig.tight_layout()
    ax.set_title(Title)


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
        ContourFilled_ = False
        Model_ = 1  # 1, 2, 3, 4
        FieldLinesContours(ContourFilled=ContourFilled_, Model=Model_)


except Exception:
    import traceback
    print(traceback.format_exc())




