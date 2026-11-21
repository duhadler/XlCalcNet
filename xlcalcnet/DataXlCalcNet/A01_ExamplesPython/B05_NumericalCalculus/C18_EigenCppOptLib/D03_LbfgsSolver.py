
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoLbfgsSolverCtx()


def CtxNormRosenthal(x):
    #print('In CtxNormRosenthal')
    t1 = 1.0 - x[0]
    t2 = x[1] - x[0] * x[0]
    norm = t1 * t1 + 100.0 * t2 * t2
    #print('norm: {0}', norm)
    return norm

def CtxGradRosenthal(x, grad):
    #print('In CtxGradRosenthal')
    grad[0] = -2.0 * (1.0 - x[0]) + 200.0 * (x[1] - x[0] * x[0]) * (-2.0 * x[0])
    grad[1] = 200.0 * (x[1] - x[0] * x[0])



def DemoLbfgsSolverCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        gui.lastctx = Ctx
        print('LbfgsSolver:' + Ctx.name);
        InitialState = Ctx.VecParams(-1.0, 2.0);
        matRes = Ctx.LbfgsSolver(Ctx.cb1VRet1S(CtxNormRosenthal), \
            Ctx.cb2V(CtxGradRosenthal), InitialState);
        print('fx0:', Ctx.fmt(matRes[0]))
        print('fx1:', Ctx.fmt(matRes[1]))
        norm = CtxNormRosenthal(matRes)
        print('Norm:', Ctx.fmt(norm))
        print('');


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











