
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

    matA = Ctx.mat_random_selfadjoint(n);
    matA.Print('matA: ', digits);
    matB1 = Ctx.mat_random(n, 1);
    matB1.Print('matB1: ', digits);

    res = matA.LDLT('info, rcond, ispos, isneg, l, u, d, p, x, inverse', matB1);

    print('info: {0}', res['info'][0, 0]);
    print('rcond: {0}', res['rcond'][0, 0]);
    print('ispos: {0}', res['ispos'][0, 0]);
    print('isneg: {0}', res['isneg'][0, 0]);

    matL = res['l'];
    matU = res['u'];
    matD = res['d'];
    matP = res['p'];
    matP.Transpose().Print('P^T: ', digits);
    matL.Print('L: ', digits);
    matD.Print('D: ', digits);
    matU.Print('U: ', digits);
    matP.Print('P: ', digits);
    matDiff = matA - matP.Transpose() * matL * matD * matU * matP;
    matDiff.Print('A - P^T * L * D * U * P: ', digits);

    matInv = res['inverse'];
    matInv.Print('A^-1: ', digits);
    matDiff = matA * matInv;
    matDiff.Print('A * A^-1: ', digits);

    matX = res['x'];
    matX.Print('x: ', digits);
    matB2 = matA * matX;
    matB2.Print('matB2 = matA * x: ', digits);

    matDiff = matB1 - matB2;
    matDiff.Print('matDiff = matB1 - matB2: ', digits);



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











