import time
import math
from xlcalcnet import sreal, scplx, dreal, dcplx, ereal, ecplx, qreal, qcplx, \
    oreal, ocplx

from xlcalcnet import ArbPrecNet, mreal, mcplx, bflint, bflintc, iflint, \
    iflintc, aflint, aflintc
from ArbPrecNet import ArbPrec
ArbPrec.SetDps(18);

#Ctx = sreal
#Ctx = scplx
#Ctx = dreal
Ctx = dcplx
#Ctx = ereal
#Ctx = ecplx
#Ctx = qreal
#Ctx = qcplx
#Ctx = oreal
#Ctx = ocplx

#Ctx = mreal
#Ctx = mcplx
#Ctx = bflint
#Ctx = bflintc



def main_tests():
    #DemoAnyJacobiSVDCtx()
    #DemoAnyJacobiSVDCtx()
    #DemoAnyJacobiSVDFullCtx()
    #DemoAnyMatHessenbergDecompositionCtx()
    #DemoAnyMatSchurCtx()
    #DemoAnyMatTridiagonalizationCtx()
    #DemoAnyPositiveDefiniteSqrtCtx()
    #DemoAnySelfAdjointEigenValuesCtx()
    #DemoAnySelfAdjointEigenSystemCtx()
    #DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx()
    #DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx()
    #DemoAnyMatEigenValuesCtx()
    #DemoAnyMatEigenSystemCtx()
    #DemoAnyPolySolveCtx()
     DemoAnyMatFFTCtx()



def DemoAnyJacobiSVDCtx():
    print("DemoAnyMatSpeed: " + Ctx.name);
    digits = 15;
    m = 6;
    n = 12;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.JacobiSVD("rank, nonzeros, s");

    # Basic information
    print();
    print();
    print("Basic information");
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeros: {0}", res["nonzeros"][0, 0]);

    S0 = res["s"];
    S0.Print("Singular values (descending): ", digits);




def DemoAnyJacobiSVDCtx():
    print("DemoAnyMatSpeed: " + Ctx.name);
    digits = 15;
    m = 6;
    n = 12;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.JacobiSvdThin("rank, nonzeros, S, U, V, X, PseudoInverse, SPlus", b1);

    # Basic information
    print();
    print();
    print("Basic information");
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeros: {0}", res["nonzeros"][0, 0]);

    S0 = res["s"];
    U1 = res["u"];
    V1 = res["v"];
    S0.Print("Singular values (descending): ", digits);


    # Least square solving
    print();
    print();
    print("Least square solving");
    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);
    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);


    # Confirming the validity of the decomposition
    print();
    print();
    print("Confirming the validity of the decomposition");
    U1.Print("Matrix U: ", digits);
    V1.Print("Matrix V: ", digits);
    A1 = U1 * S0.AsDiagonal() * V1.Adjoint();
    A1.Print("A1 = U * S * V^T: ", digits);
    F = A - A1;
    F.Print("Diff: A - A1: ", digits);


    # Confirming properties of the pseudoinverse
    print();
    print();
    print("Confirming properties of the pseudoinverse");
    SPlus = +S0;
    #for (int i = 0, loopTo = S0.rows - 1; i <= loopTo; i++)

    for i in range(S0.rows):
        if (S0[i] != Ctx.zero()):
            SPlus[i] = Ctx.one() / S0[i];
        else:
            SPlus[i] = Ctx.zero();
    Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint();
    Pinv.Print("Pinv = V * SPlus * U^T: ", digits);
    A1 = A - A * Pinv * A;
    A1.Print("A1 = A - A * Pinv * A: ", digits);


    # Confirming relationship to eigenvalues
    print();
    print();
    print("Confirming relationship to eigenvalues");
    C = +A;
    if (n > m):
        C = A.Adjoint() * A;
        C.Print("C = A^H * A : ", digits);
    else:
        C = A * A.Adjoint();
        C.Print("C = A * A^H: ", digits);

    es = C.SelfAdjointEigenSystem("eval");
    D = es["eval"];

    D.Print("D = Eigenvalues of A^T * A (ascending): ", digits);
    E = S0.CwiseProduct(S0);
    E = E.ReverseFull();
    E.Print("E = Square of singular values (ascending): ", digits);
    F = D - E;
    F.Print("Diff: D - E", digits);






def DemoAnyJacobiSVDFullCtx():
    print("DemoAnyJacobiSVDFullCtx: " + Ctx.name);
    digits = 15;
    m = 16;
    n = 16;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);
    res = A.JacobiSvdFull("rank, nonzeros, S, U, V, X, PseudoInverse, SPlus", b1);

    # Basic information
    print();
    print();
    print("Basic information");
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeros: {0}", res["nonzeros"][0, 0]);

    S0 = res["s"];
    U1 = res["u"];
    V1 = res["v"];
    S0.Print("Singular values (descending): ", digits);


    # Least square solving
    print();
    print();
    print("Least square solving");
    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);
    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);


    # Confirming the validity of the decomposition
    print();
    print();
    print("Confirming the validity of the decomposition");
    U1.Print("Matrix U: ", digits);
    V1.Print("Matrix V: ", digits);
    A1 = U1 * S0.AsDiagonal() * V1.Adjoint();
    A1.Print("A1 = U * S * V^T: ", digits);
    F = A - A1;
    F.Print("Diff: A - A1: ", digits);


    # Confirming properties of the pseudoinverse
    print();
    print();
    print("Confirming properties of the pseudoinverse");
    SPlus = +S0;
    #for (int i = 0, loopTo = S0.rows - 1; i <= loopTo; i++)

    for i in range(S0.rows):
        if (S0[i] != Ctx.zero()):
            SPlus[i] = Ctx.one() / S0[i];
        else:
            SPlus[i] = Ctx.zero();
    Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint();
    Pinv.Print("Pinv = V * SPlus * U^T: ", digits);
    A1 = A - A * Pinv * A;
    A1.Print("A1 = A - A * Pinv * A: ", digits);


    # Confirming relationship to eigenvalues
    print();
    print();
    print("Confirming relationship to eigenvalues");
    C = +A;
    if (n > m):
        C = A.Adjoint() * A;
        C.Print("C = A^H * A : ", digits);
    else:
        C = A * A.Adjoint();
        C.Print("C = A * A^H: ", digits);

    es = C.SelfAdjointEigenSystem("eval");
    D = es["eval"];

    D.Print("D = Eigenvalues of A^T * A (ascending): ", digits);
    E = S0.CwiseProduct(S0);
    E = E.ReverseFull();
    E.Print("E = Square of singular values (ascending): ", digits);
    F = D - E;
    F.Print("Diff: D - E", digits);





def DemoAnyMatHessenbergDecompositionCtx():
    print("DemoAnyMatHessenbergDecompositionCtx: " + Ctx.name);
    digits = 15;
    n = 14;
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    res = A.Hessenberg("h, q, hcoeff, packed");

    H1 = res["h"];
    H1.Print("H1: ", digits);
    Q1 = res["q"];
    Q1.Print("Q1: ", digits);
    hcoeff = res["hcoeff"];
    hcoeff.Print("hcoeff: ", digits);
    packed = res["packed"];
    packed.Print("packed: ", digits);





def DemoAnyMatSchurCtx():
    print("DemoAnyMatSchurCtx: " + Ctx.name);
    digits = 15;
    n = 14;
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    res = A.Schur("u, t");

    U1 = res["u"];
    U1.Print("U1: ", digits);
    T1 = res["t"];
    T1.Print("T1: ", digits);





def DemoAnyMatTridiagonalizationCtx():
    print("DemoAnyMatTridiagonalizationCtx: " + Ctx.name);
    digits = 15;
    n = 8;
    A = Ctx.mat_random_selfadjoint(n);

    A.Print("A: ", digits);

    res = A.Tridiag("q, t, packed, hcoeff, diag, subdiag");

    Q1 = res["q"];
    Q1.Print("Q1: ", digits);
    T1 = res["t"];
    T1.Print("T1: ", digits);
    packed = res["packed"];
    packed.Print("packed: ", digits);
    hcoeff = res["hcoeff"];
    hcoeff.Print("hcoeff: ", digits);
    diag = res["diag"];
    diag.Print("diag: ", digits);
    subdiag = res["subdiag"];
    subdiag.Print("subdiag: ", digits);

    I_n = Ctx.mat_ones(n, 1);

    evaltridiag = diag.SelfAdjointEigenValuesFromTridiag("eval", subdiag);

    Lambda = evaltridiag["eval"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

    X = +A; # need a deep copy
    #for (int i = 0, loopTo = n - 1; i <= loopTo; i++)

    for i in range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
        d = X.Det();
        print("Det(A - lambda{0} * I_n): {1}", i, d);





def DemoAnyPositiveDefiniteSqrtCtx():
    print("DemoAnyPositiveDefiniteSqrtCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    I_n = Ctx.mat_ones(n, 1);

    # To demonstrate sqrt, we need the matrix to be positive semidefinite

    A = Ctx.mat_random_selfadjoint_posdef(n);
    A.Print("A: ", digits);

    # Dim res = FprMat.SelfAdjointEigenSystem("invsqrt, sqrt", A)

    res = A.SelfAdjointEigenSystem("invsqrt, sqrt");

    invsqrtA = res["invsqrt"];
    sqrtA = res["sqrt"];

    invsqrtA.Print("invsqrtA: ", digits);
    sqrtA.Print("sqrtA: ", digits);

    A1 = sqrtA * sqrtA;
    A1.Print("A1 = sqrtA * sqrtA : ", digits);

    I1 = sqrtA * invsqrtA;
    I1.Print("I1 = sqrtA * invsqrtA : ", digits);

    print("");
    print("");





def DemoAnySelfAdjointEigenValuesCtx():
    print("DemoAnySelfAdjointEigenValuesCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    I_n = Ctx.mat_ones(n, 1);
    A = Ctx.mat_random_selfadjoint(n);
    A.Print("A: ", digits);

    res = A.SelfAdjointEigenValues("eval");

    Lambda = res["eval"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
    X = +A; # need a deep copy
    #for (int i = 0, loopTo = n - 1; i <= loopTo; i++)

    for i in range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
        d = X.Det();
        print("Det(A - lambda{0} * I_n): {1}", i, d);





def DemoAnySelfAdjointEigenSystemCtx():
    print("DemoAnySelfAdjointEigenSystemCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    I_n = Ctx.mat_ones(n, 1);
    A = Ctx.mat_random_selfadjoint(n);
    A.Print("A: ", digits);

    res = A.SelfAdjointEigenSystem("eval, evec");

    Lambda = res["eval"];
    V = res["evec"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);
    V.Print("V: (Eigenvectors)", digits);

    A1 = V * Lambda.AsDiagonal() * V.Inverse();
    print("");
    print("Check Eigensystem: V * D * V^(-1) = A");
    A1.Print("A1 = V * D * V^(-1): ", digits);

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
    X = +A; # need a deep copy

    for i in  range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
        d = X.Det();
        print("Det(A - lambda{0} * I_n): {1}", i, d);

    print("");
    print("Check per Eigenvector: A * v(i) - lambda * v(i) = 0");

    for i in  range(n):
        # X = A * V.Col(i) - V.Col(i) * Lambda(i)
        X = A * V.get_Col(i) - V.get_Col(i) * Lambda[i];
        X.Print("A * v(i) - lambda * v(i): ", digits);





def DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx():
    print("DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx: " + Ctx.name);
    digits = 15;
    n = 10;

    A = Ctx.mat_random_selfadjoint(n);
    A.Print("A (real symmetric): ", digits);
    B = Ctx.mat_random_selfadjoint_posdef(n);


    B.Print("B (real positive definite): ", digits);

    res = A.GeneralizedSelfAdjointEigenSolver("eval, evec", B);

    Lambda = res["eval"];
    V = res["evec"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print("");
    print("Check per Eigenvalue: Det(A - Lambda(i) * B) = 0");

    for i in range(n):
        X = A - B * Lambda[i];
        d = X.Det();
        print("Det(A - Lambda(i) * B): {1}", i, d);





def DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx():
    print("DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx: " + Ctx.name);
    digits = 15;
    n = 10;

    A = Ctx.mat_random_selfadjoint(n);
    A.Print("A (real symmetric): ", digits);
    B = Ctx.mat_random_selfadjoint_posdef(n);
    B.Print("B (real symmetric positive definite): ", digits);

    res = A.GeneralizedSelfAdjointEigenSolver("eval, evec", B);

    Lambda = res["eval"];
    V = res["evec"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
    #for (int i = 0, loopTo = n - 1; i <= loopTo; i++)

    for i in range(n):
        X = A - B * Lambda[i];
        d = X.Det();
        print("Det(A - Lambda(i) * B): {1}", i, d);

    print("");
    V.Print("Eigenvectors: ", digits);
    #for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)

    for i in range(n):
        X = A * V.get_Col(i) - B * Lambda[i] * V.get_Col(i);
        X.Print("A * V(i) - Lambda(i) * B * V(i) ", digits);





def DemoAnyMatEigenValuesCtx():
    print("DemoAnyMatEigenValuesCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    I_n = Ctx.mat_ones(n, 1);
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    res = A.EigenValues("eval");
    Lambda = res["eval"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

    X = Ctx.mat_cplx_t(A); # X needs to be complex for both real and complex A

    for i in range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
        d = X.Det();
        print("Det(A - lambda{0} * I_n): {1}", i, d);






def DemoAnyMatEigenSystemCtx():
    print("DemoAnyMatEigenSystemCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    I_n = Ctx.mat_ones(n, 1);
    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    res = A.EigenSystem("eval, evec");

    Lambda = res["eval"];
    V = res["evec"];
    Lambda.Print("Lambda: (Eigenvalues)", digits);
    V.Print("V: (Eigenvectors)", digits);

    A1 = V * Lambda.AsDiagonal() * V.Inverse();
    print("");
    A1.Print("Check Eigensystem: A1 = V * D * V^(-1): ", digits);

    print("");
    print("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

    X = Ctx.mat_cplx_t(A); # X needs to be complex for both real and complex A

    for i in range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
        d = X.Det();
        print("Det(A - lambda{0} * I_n): {1}", i, d);

    print("");
    print("Check per Eigenvector: A * v(i) - lambda * v(i) = 0");

    for i in range(n):
        X = A * V.get_Col(i) - V.get_Col(i) * Lambda[i];
        X.Print("A * v(i) - lambda * v(i): ", digits);


# TODO: DemoMatrixFunctions()





def DemoAnyPolySolveCtx():
    print("DemoAnyPolySolveCtx: " + Ctx.name);
    digits = 15;

    roots = Ctx.mat_random(14, 1);
    roots.Print("roots: ", 15);

    polynomial = roots.RootsToMonicPolynomial();
    polynomial.Print("polynomial: ", 15);

    evaluations = polynomial.PolyEval(roots);
    evaluations.Print("evaluations: ", 15);

    cplxroots = polynomial.PolynomialSolver();
    cplxroots.Print("cplxroots: ", 15);

    cplxevaluations = polynomial.PolyEval(cplxroots);
    cplxevaluations.Print("cplxevaluations: ", 15);





def DemoAnyMatFFTCtx():
    print("DemoAnyMatFFTCtx: " + Ctx.name);
    digits = 15;
    n = 4;

    A = Ctx.mat_zeros(2 * n, 1);

    A_real = Ctx.mat_random(n, 1);
    for i in range(n):
        A[i] = A_real[i];
    A.Print("A: ", 15);

    B = Ctx.mat_zeros(2 * n, 1);
    B_real = Ctx.mat_random(n, 1);
    for i in range(n):
        B[i] = B_real[i];
    B.Print("B: ", 15);

    TA = A.FFTFwd();
    TA.Print("TA: ", 15);

    TB = B.FFTFwd();
    TB.Print("TB: ", 15);

    # Dim TC = Ctx.CplxCtx.Mat.Zeros(2 * n, 1)

    TC = Ctx.mat_cplx_zeros(2 * n, 1);

    for i in range(2 * n):
        TC[i] = TA[i] * TB[i];
    TC.Print("TC: ", 15);

    if (Ctx.iscplxctx):
        C3 = TC.FFTCplxInv();
        C3.Print("C3: ", 15);
    else:
        C2 = TC.FFTRealInv();
        C2.Print("C2: ", 15);

    C_Real = Ctx.mat_zeros(2 * n, 1);
    for i in range(n):
        for j in range(n):
            C_Real[i + j] = C_Real[i + j] + A_real[i] * B_real[j];
    C_Real.Print("C_Real: ", 15);





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











