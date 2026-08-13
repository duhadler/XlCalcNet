import time
import math
from xlcalcnet import sreal, dreal, ereal, qreal, qcplx, oreal

from xlcalcnet import ArbPrecNet, mreal, bflint
from ArbPrecNet import ArbPrec
ArbPrec.SetDps(18);

#Ctx = sreal
#Ctx = dreal
#Ctx = ereal
Ctx = qreal
#Ctx = oreal

#Ctx = mreal
#Ctx = bflint



def main_tests():
    #DemoAnyMatPseudoEigenSystemCtx()
    #DemoAnyMatRealQZCtx()
    #DemoAnyMatGeneralizedEigenValuesCtx()
    DemoAnyMatGeneralizedEigenSystemCtx()

def DemoAnyMatPseudoEigenSystemCtx():
    print("DemoAnyMatPseudoEigenSystemCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    res = A.PseudoEigenSystem("pseudoeval, pseudoevec");

    D = res["pseudoeval"];
    V = res["pseudoevec"];
    D.Print("D: (PseudoEigenvalueMatrix)", digits);
    V.Print("V: (PseudoEigenvectors)", digits);

    print("");
    print("Check Eigensystem: A * V = V * D");
    AV = A * V;
    AV.Print("AV = A * V : ", digits);
    VD = V * D;
    VD.Print("VD = V * D : ", digits);
    Diff = AV - VD;
    Diff.Print("Diff  = AV - VD : ", digits);





def DemoAnyMatRealQZCtx():
    print("DemoAnyMatRealQZCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);
    B = Ctx.mat_random(n, n);
    B.Print("B: ", digits);

    res = A.RealQZ("s, t, q, z", B);

    S1 = res["s"];
    T1 = res["t"];
    Q1 = res["q"];
    Z1 = res["z"];
    S1.Print("S: ", digits);
    T1.Print("T: ", digits);
    Q1.Print("Q: ", digits);
    Z1.Print("Z: ", digits);





# See also: https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Generalized_eigenvalue_problem

def DemoAnyMatGeneralizedEigenValuesCtx():
    print("DemoAnyMatGeneralizedEigenValuesCtx: " + Ctx.name);
    digits = 15;
    n = 10;

    A = Ctx.mat_random(n, n);
    A.Print("A (real general square): ", digits);
    B = Ctx.mat_random(n, n);
    B.Print("B (real general square): ", digits);

    res = A.GenEigenSystem("eval, evec", B);
    Lambda = res["eval"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * B) = 0");

    for i in range(n):
        X = A - Lambda[i] * B;
        d = X.Det();
        print("Det(A - Lambda(i) * B): ", i, d);





# See also: https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Generalized_eigenvalue_problem

def DemoAnyMatGeneralizedEigenSystemCtx():
    print("DemoAnyMatGeneralizedEigenSystemCtx: " + Ctx.name);
    digits = 15;
    n = 10;

    A = Ctx.mat_random(n, n);
    A.Print("A (real general square): ", digits);
    B = Ctx.mat_random(n, n);
    B.Print("B (real general square): ", digits);

    res = A.GenEigenSystem("eval, evec", B);

    Lambda = res["eval"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * B) = 0");
    for i in range(n):
        X = A - B * Lambda[i];
        d = X.Det();
        print("Det(A - Lambda(i) * B): {1}", i, d);

    print("");
    V = res["evec"];
    V.Print("Eigenvectors: ", digits);
    for i in range(n):
        X = A * V.get_Col(i) - B * Lambda[i] * V.get_Col(i);
        X.Print("A * V(i) - Lambda(i) * B * V(i) ", digits);







try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











