
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


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        DemoAnyPositiveDefiniteSqrtCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyPositiveDefiniteSqrtCtx():
    print('DemoAnyPositiveDefiniteSqrtCtx: ' + Ctx.name)
    digits = 15
    n = 4
    I_n = Ctx.mat_ones(n, 1)

    # To demonstrate sqrt, we need the matrix to be positive semidefinite

    A = Ctx.mat_random_selfadjoint_posdef(n)
    A.Print('A: ', digits)

    # Dim res = FprMat.SelfAdjointEigenSystem('invsqrt, sqrt', A)

    res = A.SelfAdjointEigenSystem('invsqrt, sqrt')

    invsqrtA = res['invsqrt']
    sqrtA = res['sqrt']

    invsqrtA.Print('invsqrtA: ', digits)
    sqrtA.Print('sqrtA: ', digits)

    A1 = sqrtA * sqrtA
    A1.Print('A1 = sqrtA * sqrtA : ', digits)

    I1 = sqrtA * invsqrtA
    I1.Print('I1 = sqrtA * invsqrtA : ', digits)

    print('')
    print('')



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

