
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
        DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx():
    print('DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx: ' + Ctx.name)
    digits = 15
    n = 10

    A = Ctx.mat_random_selfadjoint(n)
    A.Print('A (real symmetric): ', digits)
    B = Ctx.mat_random_selfadjoint_posdef(n)
    B.Print('B (real symmetric positive definite): ', digits)

    res = A.GeneralizedSelfAdjointEigenSolver('eval, evec', B)

    Lambda = res['eval']
    V = res['evec']
    Lambda.Print('Lambda: (Eigenvalues)', digits)

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print('')
    print('Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0')
    #for (int i = 0, loopTo = n - 1 i <= loopTo i++)

    for i in range(n):
        X = A - B * Lambda[i]
        d = X.Det()
        print('Det(A - Lambda(i) * B): {1}', i, d)

    print('')
    V.Print('Eigenvectors: ', digits)
    #for (int i = 0, loopTo1 = n - 1 i <= loopTo1 i++)

    for i in range(n):
        X = A * V.get_Col(i) - B * Lambda[i] * V.get_Col(i)
        X.Print('A * V(i) - Lambda(i) * B * V(i) ', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

