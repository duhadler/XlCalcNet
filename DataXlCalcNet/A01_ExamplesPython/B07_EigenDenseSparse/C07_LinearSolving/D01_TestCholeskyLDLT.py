
''' Set use_xlcalcnet2 = False to exclude code requiring xlcalcnet2 '''
use_xlcalcnet2 = True; use_xlcalcnet = True

if use_xlcalcnet : 
    from xlcalcnet import sreal, scplx, dreal, dcplx, ereal, ecplx, \
        qreal, qcplx, oreal, ocplx

if use_xlcalcnet2: 
    from xlcalcnet import ArbPrec, mreal, mcplx, bflint, bflintc, aflint, \
        aflintc


''' Set use_complex = True to select complex instead of real '''
use_complex = False; Ctx = None

''' Uncomment one of the lines below to select the data type '''
#Ctx = scplx if use_complex else sreal
#Ctx = dcplx if use_complex else dreal
#Ctx = ecplx if use_complex else ereal
#Ctx = qcplx if use_complex else qreal
#Ctx = ocplx if use_complex else oreal
if use_xlcalcnet2: Ctx = mcplx if use_complex else mreal
#if use_xlcalcnet2: Ctx = bflintc if use_complex else bflint
#if use_xlcalcnet2: Ctx = aflintc if use_complex else aflint


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        DemoAnyMatLDLTCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatLDLTCtx():
    print('DemoAnyMatLDLTCtx: ' + Ctx.name)
    digits = 15
    n = 4
    f = n

    A = Ctx.mat_random_selfadjoint(n)
    A.Print('A: ', digits)
    B1 = Ctx.mat_random(n, 1)
    B1.Print('B1: ', digits)

    res = A.LDLT('info, rcond, ispos, isneg, l, u, d, p, x, inverse', B1)

    print('info: {0}', res['info'][0, 0])
    print('rcond: {0}', res['rcond'][0, 0])
    print('ispos: {0}', res['ispos'][0, 0])
    print('isneg: {0}', res['isneg'][0, 0])

    L = res['l']
    U = res['u']
    D = res['d']
    P = res['p']
    P.Transpose().Print('P^T: ', digits)
    L.Print('L: ', digits)
    D.Print('D: ', digits)
    U.Print('U: ', digits)
    P.Print('P: ', digits)
    Diff = A - P.Transpose() * L * D * U * P
    Diff.Print('A - P^T * L * D * U * P: ', digits)

    Inv = res['inverse']
    Inv.Print('A^-1: ', digits)
    Diff = A * Inv
    Diff.Print('A * A^-1: ', digits)

    X = res['x']
    X.Print('x: ', digits)
    B2 = A * X
    B2.Print('B2 = A * x: ', digits)

    Diff = B1 - B2
    Diff.Print('Diff = B1 - B2: ', digits)





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

