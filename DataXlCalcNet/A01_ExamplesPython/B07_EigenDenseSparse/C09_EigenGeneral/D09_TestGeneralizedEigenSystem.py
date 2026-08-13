
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
        DemoAnyMatGeneralizedEigenSystemCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatGeneralizedEigenSystemCtx():
    print('DemoAnyMatGeneralizedEigenSystemCtx: ' + Ctx.name)
    digits = 15
    n = 10

    A = Ctx.mat_random(n, n)
    A.Print('A (real general square): ', digits)
    B = Ctx.mat_random(n, n)
    B.Print('B (real general square): ', digits)

    res = A.GenEigenSystem('eval, evec', B)

    Lambda = res['eval']
    Lambda.Print('Lambda: (Eigenvalues)', digits)

    # det(A - lambda * B) = 0
    # see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

    print('')
    print('Check per Eigenvalue: Det(A - lambda{0} * B) = 0')
    for i in range(n):
        X = A - B * Lambda[i]
        d = X.Det()
        print('Det(A - Lambda(i) * B): {1}', i, d)

    print('')
    V = res['evec']
    V.Print('Eigenvectors: ', digits)
    for i in range(n):
        X = A * V.get_Col(i) - B * Lambda[i] * V.get_Col(i)
        X.Print('A * V(i) - Lambda(i) * B * V(i) ', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

