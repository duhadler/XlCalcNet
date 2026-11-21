
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoCMAesSolverCtx()

def CtxNormRosenthal(x):
    #print('In CtxNormRosenthal')
    t1 = 1.0 - x[0]
    t2 = x[1] - x[0] * x[0]
    norm = t1 * t1 + 100.0 * t2 * t2
    #print('norm: {0}', norm)
    return norm



def DemoCMAesSolverCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('CMAesSolver:' + Ctx.name);
        gui.lastctx = Ctx
        InitialState = Ctx.VecParams(-1.0, 2.0);
        matRes = Ctx.CMAesSolver(Ctx.cb1VRet1S(CtxNormRosenthal), InitialState);
        print('fx0:', Ctx.fmt(matRes[0]));
        print('fx1:', Ctx.fmt(matRes[1]));
        norm = CtxNormRosenthal(matRes);
        print('Norm:', Ctx.fmt(norm));
        print('');


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











