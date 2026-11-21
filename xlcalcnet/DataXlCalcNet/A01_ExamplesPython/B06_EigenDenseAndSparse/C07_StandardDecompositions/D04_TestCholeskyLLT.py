
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
        DemoAnyMatLLTCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatLLTCtx():
    print('DemoAnyMatLLTCtx: ' + Ctx.name)
    digits = 15
    n = 4

    A = Ctx.mat_random_selfadjoint_posdef(n)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)

    res = A.LLT('info, rcond, X, L, U, Inverse', b1)

    print('info: {0}', res['info'][0, 0])
    print('rcond: {0}', res['rcond'][0, 0])

    x1 = res['X']
    x1.Print('X: ', digits)
    b2 = A * x1
    b2.Print('b2 = A * x: ', digits)
    Diff = b1 - b2
    Diff.Print('Diff = b2 - b: ', digits)

    L1 = res['L']
    U1 = res['U']
    L1.Print('L: ', digits)
    U1.Print('U: ', digits)
    Diff = A - L1 * U1
    Diff.Print('A - L * U: ', digits)

    inv1 = res['Inverse']
    inv1.Print('inv: ', digits)
    Diff = A * inv1
    Diff.Print('A * inv: ', digits)





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

