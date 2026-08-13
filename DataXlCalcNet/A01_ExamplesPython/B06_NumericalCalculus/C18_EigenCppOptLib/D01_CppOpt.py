
import math
from xlcalcnet import FixedPrecNet, sreal, dreal, ereal, qreal, oreal
#from FixedPrecNet import cb1SSingle1V, cbSingle2V, cbSingle1V1M
#from FixedPrecNet import cb1SDouble1V, cbDouble2V, cbDouble1V1M
#from FixedPrecNet import cb1SExtended1V, cbExtended2V, cbExtended1V1M
#from FixedPrecNet import cb1SQuadruple1V, cbQuadruple2V, cbQuadruple1V1M
#from FixedPrecNet import cb1SOctuple1V, cbOctuple2V, cbOctuple1V1M

from xlcalcnet import ArbPrecNet, mreal
from ArbPrecNet import ArbPrec, cb1SMpfr1V, cbMpfr2V, cbMpfr1V1M
ArbPrec.SetDps(30);

#Ctx = sreal
#cb1S1V = cb1SSingle1V
#cb2V = cbSingle2V
#cb1V1M = cbSingle1V1M

Ctx = dreal; 
if Ctx is dreal:
    cb1S1V = FixedPrecNet.cb1SDouble1V; 
    cb2V = FixedPrecNet.cbDouble2V; 
    cb1V1M = FixedPrecNet.cbDouble1V1M

#Ctx = ereal
#cb1S1V = cb1SExtended1V
#cb2V = cbExtended2V
#cb1V1M = cbExtended1V1M

#Ctx = qreal
#cb1S1V = cb1SQuadruple1V
#cb2V = cbQuadruple2V
#cb1V1M = cbQuadruple1V1M

#Ctx = oreal
#cb1S1V = cb1SOctuple1V
#cb2V = cbOctuple2V
#cb1V1M = cbOctuple1V1M

#if use_xlcalcnet2: Ctx=mreal; cb1S1V=cb1SMpfr1V;cb2V=cbMpfr2V;cb1V1M=cbMpfr1V1M


def main_tests():
    DemoNelderMeadCtx()
    DemoCMAesSolver()
    DemoLbfgsSolverCtx()
    DemoBfgsSolverCtx()
    DemoGradientDescentSolverCtx()
    DemoConjugatedGradientDescentSolverCtx()
    DemoNewtonDescentSolver()


def CtxNormRosenthal(x):
    #print("In CtxNormRosenthal")
    t1 = 1.0 - x[0]
    t2 = x[1] - x[0] * x[0]
    norm = t1 * t1 + 100.0 * t2 * t2
    #print("norm: {0}", norm)
    return norm


def CtxGradRosenthal(x, grad):
    #print("In CtxGradRosenthal")
    grad[0] = -2.0 * (1.0 - x[0]) + 200.0 * (x[1] - x[0] * x[0]) * (-2.0 * x[0])
    grad[1] = 200.0 * (x[1] - x[0] * x[0])


def CtxHessianRosenthal(x, hessian):
    #print("In CtxHessianRosenthal")
    hessian[0, 0] = 1200.0 * x[0] * x[0] - 400.0 * x[1] + 1.0
    hessian[0, 1] = -400.0 * x[0]
    hessian[1, 0] = -400.0 * x[0]
    hessian[1, 1] = Ctx.t(200)



def DemoNelderMeadCtx():
    print("NelderMead:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.NelderMeadSolver(cb1S1V(CtxNormRosenthal), InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");



def DemoCMAesSolver():
    print("CMAesSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.CMAesSolver(cb1S1V(CtxNormRosenthal), InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");



def DemoLbfgsSolverCtx():
    print("LbfgsSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.LbfgsSolver(cb1S1V(CtxNormRosenthal), cb2V(CtxGradRosenthal), \
        InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");



def DemoBfgsSolverCtx():
    print("BfgsSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.BfgsSolver(cb1S1V(CtxNormRosenthal), cb2V(CtxGradRosenthal), \
        InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");


def DemoGradientDescentSolverCtx():
    print("GradientDescentSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.GradientDescentSolver(cb1S1V(CtxNormRosenthal), \
        cb2V(CtxGradRosenthal), InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");


def DemoConjugatedGradientDescentSolverCtx():
    print("ConjugatedGradientDescentSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.ConjugatedGradientDescentSolver(cb1S1V(CtxNormRosenthal), \
        cb2V(CtxGradRosenthal), InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");



def DemoNewtonDescentSolver():
    print("NewtonDescentSolver:" + Ctx.name);
    InitialState = Ctx.VecParams(-1.0, 2.0);
    matRes = Ctx.NewtonDescentSolver(cb1S1V(CtxNormRosenthal), \
        cb2V(CtxGradRosenthal), cb1V1M(CtxHessianRosenthal), InitialState);
    print();
    print("fx0: {0}", matRes[0]);
    print("fx1: {0}", matRes[1]);
    norm = CtxNormRosenthal(matRes);
    print("Norm: {0}", norm);
    print("");






try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











