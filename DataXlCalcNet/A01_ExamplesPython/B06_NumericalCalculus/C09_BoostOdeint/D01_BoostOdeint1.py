
''' Set use_xlcalcnet2 = False to exclude code requiring xlcalcnet2 '''
use_xlcalcnet2 = True; use_xlcalcnet = True

if use_xlcalcnet : 
    from xlcalcnet import FixedPrecNet, math53, sreal, dreal, ereal, qreal, \
        oreal
    from FixedPrecNet import cbSingle1S2V, cbSingle1S1V, cbDouble1S2V, \
        cbDouble1S1V, cbExtended1S2V, cbExtended1S1V, cbQuadruple1S2V, \
        cbQuadruple1S1V, cbOctuple1S2V, cbOctuple1S1V

if use_xlcalcnet2: 
    from xlcalcnet import ArbPrecNet, ArbPrec, mreal
    from ArbPrecNet import cbMpfr1S2M, cbMpfr1S1M

Ctx = None

''' Uncomment one of the lines below to select the data type '''
#Ctx = sreal; cb1S2V = cbSingle1S2V; cb1S1V = cbSingle1S1V
#Ctx = dreal; cb1S2V = cbDouble1S2V; cb1S1V = cbDouble1S1V
#Ctx = ereal; cb1S2V = cbExtended1S2V; cb1S1V = cbExtended1S1V
#Ctx = qreal; cb1S2V = cbQuadruple1S2V; cb1S1V = cbQuadruple1S1V
#Ctx = oreal; cb1S2V = cbOctuple1S2V; cb1S1V = cbOctuple1S1V
if use_xlcalcnet2: Ctx = mreal; cb1S2V = cbMpfr1S2M; cb1S1V = cbMpfr1S1M


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        demo_RungeKutta4Const()
    else:
        print('Nothing to do, since Ctx is None.')


    #demo_RungeKutta4Const()
    #demo_CashKarp54Const()
    #demo_DormandPrince5Const()
    #demo_Fehlberg78Const()
    #demo_AdamsBashforthMoultonConst()

    #demo_DormandPrince5Adaptive()
    #demo_CashKarp54Adaptive()
#    demo_Fehlberg78Adaptive()
#    demo_BulirschStoerAdaptive()


def FmatLorenz(t, x, dxdt):
    sigma = Ctx.t(10);
    R = Ctx.t(28);
    b = Ctx.t(8) / 3;
    dxdt[0] = sigma * (x[1] - x[0]);
    dxdt[1] = R * x[0] - x[1] - x[0] * x[2];
    dxdt[2] = -b * x[2] + x[0] * x[1];

def FmatLorenzObserve(t, x):
    print('t: ', t, ', ', end='');
    for i in range(x.Size):
        print("x[" + str(i) + "]:", x[i], ", ", end='');
    print();


def demo_RungeKutta4Const():
    print();
    print("DemoRungeKutta4Const: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.RungeKutta4Const(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt)




def demo_CashKarp54Const():
    print();
    print("CashKarp54Const: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.CashKarp54Const(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt)


def demo_DormandPrince5Const():
    print();
    print("DormandPrince5Const: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.DormandPrince5Const(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt)


def demo_Fehlberg78Const():
    print();
    print("Fehlberg78Const: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.Fehlberg78Const(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt)


def demo_AdamsBashforthMoultonConst():
    print();
    print("AdamsBashforthMoultonConst: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.AdamsBashforthMoultonConst(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt)


def demo_DormandPrince5Adaptive():
    print();
    print("DormandPrince5Adaptive: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    epsabs = Ctx.t(0.000001);
    epsrel = Ctx.t(epsabs);
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.DormandPrince5Adaptive(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt, epsabs, epsrel)


def demo_CashKarp54Adaptive():
    print();
    print("CashKarp54Adaptive: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    epsabs = Ctx.t(0.000001);
    epsrel = Ctx.t(epsabs);
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.CashKarp54Adaptive(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt, epsabs, epsrel)


def demo_Fehlberg78Adaptive():
    print();
    print("Fehlberg78Adaptive: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    epsabs = Ctx.t(0.000001);
    epsrel = Ctx.t(epsabs);
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.Fehlberg78Adaptive(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt, epsabs, epsrel)


def demo_BulirschStoerAdaptive():
    print();
    print("BulirschStoerAdaptive: " + Ctx.name);
    StartTime = Ctx.t(0.0)
    EndTime = Ctx.t(1.01)
    dt = Ctx.t(0.01)
    epsabs = Ctx.t(0.000001);
    epsrel = Ctx.t(epsabs);
    InitialVec = Ctx.VecParams(10.0, 10.0, 10.0)
    Ctx.BulirschStoerAdaptive(cb1S2V(FmatLorenz), cb1S1V(FmatLorenzObserve), \
        InitialVec, StartTime, EndTime, dt, epsabs, epsrel)








try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











