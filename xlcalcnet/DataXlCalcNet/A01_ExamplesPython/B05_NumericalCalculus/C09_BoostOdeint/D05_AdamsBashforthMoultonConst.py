
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoAdamsBashforthMoultonConstCtx()


def FmatLorenz(t, x, dxdt):
    Ctx = gui.lastctx
    sigma = Ctx.t(10);
    R = Ctx.t(28);
    b = Ctx.t(8) / 3;
    dxdt[0] = sigma * (x[1] - x[0]);
    dxdt[1] = R * x[0] - x[1] - x[0] * x[2];
    dxdt[2] = -b * x[2] + x[0] * x[1];

def FmatLorenzObserve(t, x):
    Ctx = gui.lastctx
    print('t:' + Ctx.fmt(t) + ', ', end='');
    for i in range(x.Size):
        print(' x[' + str(i) + ']:' + Ctx.fmt(x[i]) + ', ', end='');
    print();


def DemoAdamsBashforthMoultonConstCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    #boost_list = [qreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('AdamsBashforthMoultonConst:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        StartTime = Ctx.t(0.0)
        EndTime = Ctx.t(1.00)
        dt = Ctx.t(0.0078125)
        InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
        Ctx.AdamsBashforthMoultonConst(Ctx.cb1S2V(FmatLorenz),  \
            Ctx.cb1S1V(FmatLorenzObserve), InitialVec, StartTime, EndTime, dt)


try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())











