
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoLevenbergMarquardtCtx()
 


def XmatLM(x, fvec):
#    print('in matLM')
    y = [ 0.14, 0.18, 0.22, 0.25, 0.29, 0.32, 0.35, 0.39, 0.37, 0.58, 0.73, \
            0.96, 1.34, 2.1, 4.39 ]
    m = 15;
    tmp1 = tmp2 = tmp3 = 0
    for i in range(m):
        tmp1 = i + 1;
        tmp2 = 15 - i;
        tmp3 = tmp1;
        if (i >= 8):
            tmp3 = tmp2;
        fvec[i] = y[i] - (x[0] + tmp1 / (x[1] * tmp2 + x[2] * tmp3));


def XmatLMJ(x, fjac):
    Ctx = gui.lastctx
#    print('in matLMJ')
    m = 15;
    for i in range(m):
        tmp1 = i + 1;
        tmp2 = 15 - i;
        tmp3 = tmp1;
        if (i >= 8):
            tmp3 = tmp2; # else tmp3 = tmp1
        tmp4 = x[1] * tmp2 + x[2] * tmp3;
        tmp4 = tmp4 * tmp4;
        fjac[i, 0] = Ctx.t(-1);
        fjac[i, 1] = tmp1 * tmp2 / tmp4;
        fjac[i, 2] = tmp1 * tmp3 / tmp4;


def DemoLevenbergMarquardtCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('LevenbergMarquardt');
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        n = 3;
        m = 15;
        matInput = Ctx.mat_zeros(n, 1);
        matInput[0] = Ctx.t(1);
        matInput[1] = Ctx.t(2);
        matInput[2] = Ctx.t(0);

        matX = Ctx.LevenbergMarquardt(Ctx.cb2M(XmatLM), Ctx.cb2M(XmatLMJ), matInput, n, m);
        print('');
        matX.Print('X (solution):' + Ctx.name, 10);
        matEval = Ctx.mat_zeros(m, 1);
        XmatLM(matX, matEval);
        matEval.Print('matEval =  F(X=solution):' + Ctx.name, 10);





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











