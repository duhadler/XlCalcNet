
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoPowellHybrdCtx()


def XmatHybrd(x, fvec):
    Ctx = gui.lastctx
#    print('in matHybrd')
    n = x.size
    for k in range(n):
        temp = (3.0 - 2.0 * x[k]) * x[k]
        temp1 = Ctx.t(0.0)
        if (k != 0):
            temp1 = x[k - 1]
        temp2 = Ctx.t(0.0)
        if (k != n - 1):
            temp2 = x[k + 1]
        fvec[k] = temp - temp1 - 2.0 * temp2 + 1.0

def XmatHybrdJ(x, jacobian):
    Ctx = gui.lastctx
#    print('in matHybrdJ')
    n = x.size
    for k in range(n):
        for j in range(n):
            jacobian[k, j] = Ctx.t(0.0)
        jacobian[k, k] = 3.0 - 4.0 * x[k]
        if (k != 0):
            jacobian[k, k - 1] = Ctx.t(-1.0)
        if (k != n - 1):
            jacobian[k, k + 1] = Ctx.t(-2.0)


def DemoPowellHybrdCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('PowellHybrd')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        n = 9
        matInput = Ctx.mat_zeros(n, 1)
        matInput[0] = Ctx.t(1.0)
        matInput[1] = Ctx.t(2.0)  # entries 2 .. 8 are 0.
        matX = Ctx.PowellHybrd(Ctx.cb2M(XmatHybrd), Ctx.cb2M(XmatHybrdJ), matInput)
        print('')
        matX.Print('X (solution):' + Ctx.name, 10)
        matEval = Ctx.mat_zeros(n, 1)
        XmatHybrd(matX, matEval)
        matEval.Print('matEval =  F(X=solution):' + Ctx.name, 10)





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











