
dps = 40
use_xlcalcnet2 = True
from xlcalcnet import sreal, scplx, dreal, dcplx, ereal, ecplx, qreal, qcplx, \
    oreal, ocplx

if use_xlcalcnet2:
    from xlcalcnet import ArbPrec, mreal, mcplx, bflint, bflintc, aflint, \
        aflintc
    ArbPrec.SetDps(dps);



UsingComplex = False
''' Uncomment one of the lines below to select the data type '''
#Ctx = scplx if UsingComplex else sreal
#Ctx = dcplx if UsingComplex else dreal
#Ctx = ecplx if UsingComplex else ereal
#Ctx = qcplx if UsingComplex else qreal
#Ctx = ocplx if UsingComplex else oreal
#Ctx = mcplx if UsingComplex else mreal # requires use_xlcalcnet2 = True
#Ctx = bflintc if UsingComplex else bflint # requires use_xlcalcnet2 = True
Ctx = aflintc if UsingComplex else aflint # requires use_xlcalcnet2 = True


def main_tests():
    DemoAnyMatLDLTCtx()


def DemoAnyMatLDLTCtx():
    print('DemoAnyMatLDLTCtx: ' + Ctx.name);
    digits = 15;
    n = 4;
    f = n;

    A = Ctx.mat_random_selfadjoint(n);
    A.Print('A: ', digits);
    B1 = Ctx.mat_random(n, 1);
    B1.Print('B1: ', digits);

    res = A.LDLT('info, rcond, ispos, isneg, l, u, d, p, x, inverse', B1);

    print('info: {0}', res['info'][0, 0]);
    print('rcond: {0}', res['rcond'][0, 0]);
    print('ispos: {0}', res['ispos'][0, 0]);
    print('isneg: {0}', res['isneg'][0, 0]);

    L = res['l'];
    U = res['u'];
    D = res['d'];
    P = res['p'];
    P.Transpose().Print('P^T: ', digits);
    L.Print('L: ', digits);
    D.Print('D: ', digits);
    U.Print('U: ', digits);
    P.Print('P: ', digits);
    Diff = A - P.Transpose() * L * D * U * P;
    Diff.Print('A - P^T * L * D * U * P: ', digits);

    Inv = res['inverse'];
    Inv.Print('A^-1: ', digits);
    Diff = A * Inv;
    Diff.Print('A * A^-1: ', digits);

    X = res['x'];
    X.Print('x: ', digits);
    B2 = A * X;
    B2.Print('B2 = A * x: ', digits);

    Diff = B1 - B2;
    Diff.Print('Diff = B1 - B2: ', digits);



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











