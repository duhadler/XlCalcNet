
import math
from xlcalcnet import math53, FixedPrecNet, sreal, dreal, ereal, qreal, oreal
from FixedPrecNet import cbSingle2M, cbDouble2M, cbExtended2M, \
    cbQuadruple2M, cbOctuple2M

from xlcalcnet import ArbPrecNet, mreal
from ArbPrecNet import ArbPrec, cbMpfr2M
ArbPrec.SetDps(30);

#Ctx = sreal
#cb2M = cbSingle2M

Ctx = dreal
cb2M = cbDouble2M

#Ctx = ereal
#cb2M = cbExtended2M

#Ctx = qreal
#cb2M = cbQuadruple2M

#Ctx = oreal
#cb2M = cbOctuple2M

#Ctx = mreal
#cb2M = cbMpfr2M


def main_tests():
    DemoPowellHybrdClass()
    DemoLevenbergClass()


def XmatHybrd(x, fvec):
    print("in matHybrd")
    n = x.size;
    for k in range(n):
        temp = (3.0 - 2.0 * x[k]) * x[k];
        temp1 = Ctx.t(0.0);
        if (k != 0):
            temp1 = x[k - 1];
        temp2 = Ctx.t(0.0);
        if (k != n - 1):
            temp2 = x[k + 1];
        fvec[k] = temp - temp1 - 2.0 * temp2 + 1.0;

def XmatHybrdJ(x, jacobian):
    print("in matHybrdJ")
    n = x.size;
    for k in range(n):
        for j in range(n):
            jacobian[k, j] = Ctx.t(0.0);
        jacobian[k, k] = 3.0 - 4.0 * x[k];
        if (k != 0):
            jacobian[k, k - 1] = Ctx.t(-1.0);
        if (k != n - 1):
            jacobian[k, k + 1] = Ctx.t(-2.0);


def DemoPowellHybrdClass():
    print("Hello DemoPowellHybrdClass: " + Ctx.name);
    n = 9;
    matInput = Ctx.mat_zeros(n, 1);
    matInput[0] = Ctx.t(1.0);
    matInput[1] = Ctx.t(2.0);  # entries 2 .. 8 are 0.
    matX = Ctx.PowellHybrd(cb2M(XmatHybrd), cb2M(XmatHybrdJ), matInput);
    print("");
    matX.Print("X (solution):", 10);
    matEval = Ctx.mat_zeros(n, 1);
    XmatHybrd(matX, matEval);
    matEval.Print("matEval =  F(X=solution):", 10);




def XmatLM(x, fvec):
    print("in matLM")
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
    print("in matLMJ")
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


def DemoLevenbergClass():
    print("Hello DemoLevenbergClassSReal() ");
    n = 3;
    m = 15;
    matInput = Ctx.mat_zeros(n, 1);
    matInput[0] = Ctx.t(1);
    matInput[1] = Ctx.t(2);
    matInput[2] = Ctx.t(0);

    matX = Ctx.Levenberg(cb2M(XmatLM), cb2M(XmatLMJ), matInput, n, m);
    print("");
    matX.Print("X (solution):", 10);
    matEval = Ctx.mat_zeros(m, 1);
    XmatLM(matX, matEval);
    matEval.Print("matEval =  F(X=solution):", 10);





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











