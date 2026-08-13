
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
        DemoAnyJacobiSVDFullCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyJacobiSVDFullCtx():
    print('DemoAnyJacobiSVDFullCtx: ' + Ctx.name)
    digits = 15
    m = 16
    n = 16

    A = Ctx.mat_random(n, m)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)
    res = A.JacobiSvdFull('rank, nonzeros, S, U, V, X, PseudoInverse, SPlus', b1)

    # Basic information
    print()
    print()
    print('Basic information')
    print('rank: {0}', res['rank'][0, 0])
    print('nonzeros: {0}', res['nonzeros'][0, 0])

    S0 = res['s']
    U1 = res['u']
    V1 = res['v']
    S0.Print('Singular values (descending): ', digits)


    # Least square solving
    print()
    print()
    print('Least square solving')
    x1 = res['x']
    x1.Print('x: ', digits)
    b2 = A * x1
    b2.Print('b2 = A * x: ', digits)
    Diff = b1 - b2
    Diff.Print('Diff = b2 - b: ', digits)


    # Confirming the validity of the decomposition
    print()
    print()
    print('Confirming the validity of the decomposition')
    U1.Print('Matrix U: ', digits)
    V1.Print('Matrix V: ', digits)
    A1 = U1 * S0.AsDiagonal() * V1.Adjoint()
    A1.Print('A1 = U * S * V^T: ', digits)
    F = A - A1
    F.Print('Diff: A - A1: ', digits)


    # Confirming properties of the pseudoinverse
    print()
    print()
    print('Confirming properties of the pseudoinverse')
    SPlus = +S0
    #for (int i = 0, loopTo = S0.rows - 1 i <= loopTo i++)

    for i in range(S0.rows):
        if (S0[i] != Ctx.zero()):
            SPlus[i] = Ctx.one() / S0[i]
        else:
            SPlus[i] = Ctx.zero()
    Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint()
    Pinv.Print('Pinv = V * SPlus * U^T: ', digits)
    A1 = A - A * Pinv * A
    A1.Print('A1 = A - A * Pinv * A: ', digits)


    # Confirming relationship to eigenvalues
    print()
    print()
    print('Confirming relationship to eigenvalues')
    C = +A
    if (n > m):
        C = A.Adjoint() * A
        C.Print('C = A^H * A : ', digits)
    else:
        C = A * A.Adjoint()
        C.Print('C = A * A^H: ', digits)

    es = C.SelfAdjointEigenSystem('eval')
    D = es['eval']

    D.Print('D = Eigenvalues of A^T * A (ascending): ', digits)
    E = S0.CwiseProduct(S0)
    E = E.ReverseFull()
    E.Print('E = Square of singular values (ascending): ', digits)
    F = D - E
    F.Print('Diff: D - E', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

