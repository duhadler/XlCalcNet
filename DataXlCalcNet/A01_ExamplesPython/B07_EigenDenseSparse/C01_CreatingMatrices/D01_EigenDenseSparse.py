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
#Ctx = iflint
#Ctx = iflintc
#Ctx = aflint
#Ctx = aflintc



def main_tests():
    #DemoAnyMatSpeedCtx()
    #DemoAnyMatSpeedDetCtx()
    #DemoAnyMatCtx()
    #DemoAnyMatSolveCtx()
    #DemoAnyMatLDLTCtx()
    #DemoAnyMatPartialPivLUCtx()
    #DemoAnyMatFullPivLUCtx()
    #DemoAnyMatLLTCtx()
    #DemoAnyMatHouseholderQRCtx()
    #DemoAnyMatColPivHouseholderQRCtx()
    #DemoAnyMatFullPivHouseholderQRCtx()
    DemoAnyMatCODCtx()


def DemoAnyMatSpeedCtx():
    print("DemoAnyMatSpeed: " + Ctx.name);
    m = 10;
    n = 10;
    #start0a = time.time()
    A = Ctx.mat_random(n, m);
    B = Ctx.mat_random(n, m);
    start0a = time.time()
    C = A + B;
    C = A - B;
    C = A * B;
    C = A / B;
    end0a = time.time()
    Elapsed0a = end0a - start0a
    print("Elapsed Time: ", Elapsed0a);


def DemoAnyMatSpeedDetCtx():
    print("DemoAnyMatSpeedDetCtx: " + Ctx.name);
    m = 10;
    n = 10;
    #start0a = time.time()
    A = Ctx.mat_random(n, m);
    b1 = Ctx.mat_random(n, 1);
    start0a = time.time()
    res = A.PartialPivLU("rcond, lu, p, det, x, inverse", b1);  
    end0a = time.time()
    print("det: {0}", res["det"][0, 0]);
    Elapsed0a = end0a - start0a
    print("Elapsed Time: ", Elapsed0a);



def DemoAnyMatCtx():
    print("DemoAnyMatCtx: " + Ctx.name);
    digits = 15;

    x1 = Ctx.mat_random(4, 4);
    x1.Print("x1: ", digits);

    d1 = x1;
    d1.Print("d1: ", digits);

    d2 = Ctx.mat_random(4, 4);
    d2.Print("d2: ", digits);

    x2 = d2;
    x2.Print("x2: ", digits);

    z1 = x1.ConcatHorizontal(x2);
    z1.Print("z1 = x1.ConcatHorizontal(x2): ", digits);

    z2 = x1.ConcatVertical(x2);
    z2.Print("z2 = x1.ConcatVertical(x2): ", digits);

    y1 = x1.Inverse();
    y1.Print("y1: ", digits);

    z1 = x1 * y1;
    z1.Print("z1: ", digits);

    z2 = x1 / x2;
    z2.Print("z2: ", digits);

    Coeff = x1[1, 1];
    print("Coeff: ", Coeff);

    Coeff2 = Ctx.t(1.11111111111);
    print("Coeff2: ", Coeff2);
    y1[1, 1] = Coeff2;
    y1.Print("y1: ", digits);

    print("Rows: ", x1.rows);
    print("Cols: ", x1.cols);
    print("Size: ", x1.size);

    count = y1.GTcount(x1);
    print("GT: ", count);

    z1 = x1.get_Block(0, 0, 1, 1);
    z1.Print("z1= x1.block(0, 0, 1, 1): ", digits);

    A = Ctx.mat_random(3, 5);
    A.Print("A: ", digits);

    A.Resize(2, 4);
    A.Print("A: ", digits);

    x1.ConservativeResize(2, 5);
    x1.Print("x1: ", digits);

# TODO: DemoAnyMatSortCtx()

# TODO: DemoAnyMatSelectCtx()





def DemoAnyMatSolveCtx():
    print("DemoAnyMatSolveCtx: " + Ctx.name);
    digits = 15;
    n = 8;

    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);

    b = Ctx.mat_random(n, n);
    b.Print("B: ", digits);

    X = A.Solve(b);
    X.Print("X: ", digits);

    b2 = A * X;
    b2.Print("b2: ", digits);

    Diff = b - b2;
    Diff.Print("Diff: ", digits);





def DemoAnyMatLDLTCtx():
    print("DemoAnyMatLDLTCtx: " + Ctx.name);
    digits = 15;
    n = 4;
    f = n;

    A = Ctx.mat_random_selfadjoint(n);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.LDLT("info, rcond, ispos, isneg, l, u, d, p, x, inverse", b1);

    print("info: {0}", res["info"][0, 0]);
    print("rcond: {0}", res["rcond"][0, 0]);
    print("ispos: {0}", res["ispos"][0, 0]);
    print("isneg: {0}", res["isneg"][0, 0]);

    L1 = res["l"];
    U1 = res["u"];
    D1 = res["d"];
    P1 = res["p"];
    P1.Transpose().Print("P^T: ", digits);
    L1.Print("L: ", digits);
    D1.Print("D: ", digits);
    U1.Print("U: ", digits);
    P1.Print("P: ", digits);
    Diff = A - P1.Transpose() * L1 * D1 * U1 * P1;
    Diff.Print("A - P^T * L * D * U * P: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);




def DemoAnyMatPartialPivLUCtx():
    print("DemoAnyMatPartialPivLUCtx: " + Ctx.name);
    digits = 15;
    m = 5;
    n = 5;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.PartialPivLU("rcond, lu, p, det, x, inverse", b1);

    print("det1: {0}", res["det"][0, 0]);
    #// Console.WriteLine("det2: {0}", A.Det()(0, 0))

    print("rcond1: {0}", res["rcond"][0, 0]);
    #// Console.WriteLine("rcond2: {0}", A.Rcond()(0, 0))

    LU1 = res["lu"];
    P1 = res["p"];
    LU1.Print("LU: ", digits);
    P1.Print("P: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv1: ", digits);

    inv2 = A.Inverse();
    inv2.Print("inv2: ", digits);

    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x1: ", digits);

    x2 = A.Solve(b1);
    x2.Print("x2: ", digits);

    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);



def DemoAnyMatFullPivLUCtx():
    print("DemoAnyMatFullPivLUCtx: " + Ctx.name);
    digits = 15;
    m = 5;
    n = 5;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.FullPivLU("rcond, lu, p, q, isinjective, isinvertible, issurjective, det, x, inverse", b1);

    print("det: {0}", res["det"][0, 0]);
    print("rcond: {0}", res["rcond"][0, 0]);
    print("isinjective: {0}", res["isinjective"][0, 0]);
    print("isinvertible: {0}", res["isinvertible"][0, 0]);
    print("issurjective: {0}", res["issurjective"][0, 0]);

    LU1 = res["lu"];
    P1 = res["p"];
    Q1 = res["q"];
    LU1.Print("LU: ", digits);
    P1.Print("P: ", digits);
    Q1.Print("Q: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);





def DemoAnyMatLLTCtx():
    print("DemoAnyMatLLTCtx: " + Ctx.name);
    digits = 15;
    n = 4;

    A = Ctx.mat_random_selfadjoint_posdef(n);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.LLT("info, rcond, X, L, U, Inverse", b1);

    print("info: {0}", res["info"][0, 0]);
    print("rcond: {0}", res["rcond"][0, 0]);

    x1 = res["X"];
    x1.Print("X: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);
    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);

    L1 = res["L"];
    U1 = res["U"];
    L1.Print("L: ", digits);
    U1.Print("U: ", digits);
    Diff = A - L1 * U1;
    Diff.Print("A - L * U: ", digits);

    inv1 = res["Inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);





def DemoAnyMatHouseholderQRCtx():
    print("DemoAnyMatHouseholderQRCtx: " + Ctx.name);
    digits = 15;
    n = 4;

    A = Ctx.mat_random(n, n);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.HouseholderQR("qr, absdet, logabsdet, x, inverse", b1);

    print("absdet: {0}", res["absdet"][0, 0]);
    print("logabsdet: {0}", res["logabsdet"][0, 0]);

    QR1 = res["qr"];
    QR1.Print("QR: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);





def DemoAnyMatColPivHouseholderQRCtx():
    print("DemoAnyMatColPivHouseholderQRCtx: " + Ctx.name);
    digits = 15;
    m = 5;
    n = 5;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.ColPivHouseholderQR("info, dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qr, r, householderq, hqnonzeros, permcols, x, inverse", b1);

    print("info: {0}", res["info"][0, 0]);
    print("dimofkernel: {0}", res["dimofkernel"][0, 0]);
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

    print("isinjective: {0}", res["isinjective"][0, 0]);
    print("isinvertible: {0}", res["isinvertible"][0, 0]);
    print("issurjective: {0}", res["issurjective"][0, 0]);

    print("absdet: {0}", res["absdet"][0, 0]);
    print("logabsdet: {0}", res["logabsdet"][0, 0]);
    print("maxpivot: {0}", res["maxpivot"][0, 0]);

    QR1 = res["qr"];
    R1 = res["r"];
    householderq = res["householderq"];
    hqnonzeros = res["hqnonzeros"];
    permcols = res["permcols"];
    QR1.Print("QR1: ", digits);
    R1.Print("R1: ", digits);
    householderq.Print("householderq: ", digits);
    hqnonzeros.Print("hqnonzeros: ", digits);
    permcols.Print("permcols: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);





def DemoAnyMatFullPivHouseholderQRCtx():
    print("DemoAnyMatFullPivHouseholderQRCtx: " + Ctx.name);
    digits = 15;
    m = 5;
    n = 5;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.FullPivHouseholderQR("dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qr, q, permcols, x, inverse", b1);

    print("dimofkernel: {0}", res["dimofkernel"][0, 0]);
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

    print("isinjective: {0}", res["isinjective"][0, 0]);
    print("isinvertible: {0}", res["isinvertible"][0, 0]);
    print("issurjective: {0}", res["issurjective"][0, 0]);

    print("absdet: {0}", res["absdet"][0, 0]);
    print("logabsdet: {0}", res["logabsdet"][0, 0]);
    print("maxpivot: {0}", res["maxpivot"][0, 0]);

    QR1 = res["qr"];
    Q1 = res["q"];
    permcols = res["permcols"];
    QR1.Print("QR1: ", digits);
    Q1.Print("Q1: ", digits);
    permcols.Print("permcols: ", digits);

    inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);





def DemoAnyMatCODCtx():
    print("DemoAnyMatCODCtx: " + Ctx.name);
    digits = 15;
    m = 5;
    n = 5;

    A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    res = A.COD("info, dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qtz, t, z, householderq, hqnonzeros, x, pseudoinverse", b1);

    print("info: {0}", res["info"][0, 0]);
    print("dimofkernel: {0}", res["dimofkernel"][0, 0]);
    print("rank: {0}", res["rank"][0, 0]);
    print("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

    print("isinjective: {0}", res["isinjective"][0, 0]);
    print("isinvertible: {0}", res["isinvertible"][0, 0]);
    print("issurjective: {0}", res["issurjective"][0, 0]);

    print("absdet: {0}", res["absdet"][0, 0]);
    print("logabsdet: {0}", res["logabsdet"][0, 0]);
    print("maxpivot: {0}", res["maxpivot"][0, 0]);

    QTZ1 = res["qtz"];
    T1 = res["t"];
    Z1 = res["z"];
    householderq = res["householderq"];
    hqnonzeros = res["hqnonzeros"];
    QTZ1.Print("QTZ1: ", digits);
    T1.Print("T1: ", digits);
    Z1.Print("Z1: ", digits);
    householderq.Print("householderq: ", digits);
    hqnonzeros.Print("hqnonzeros: ", digits);

    inv1 = res["pseudoinverse"];
    inv1.Print("inv: ", digits);
    Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    x1 = res["x"];
    x1.Print("x: ", digits);
    b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











