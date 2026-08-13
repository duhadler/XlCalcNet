
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
        DemoAnySelfAdjointEigenSystemCtx()
    else:
        print('Nothing to do, since Ctx is None.')



def DemoAnySelfAdjointEigenSystemCtx():
    print('DemoAnySelfAdjointEigenSystemCtx: ' + Ctx.name)
    digits = 15
    n = 4
    I_n = Ctx.mat_ones(n, 1)
    A = Ctx.mat_random_selfadjoint(n)
    A.Print('A: ', digits)

    res = A.SelfAdjointEigenSystem('eval, evec')

    Lambda = res['eval']
    V = res['evec']
    Lambda.Print('Lambda: (Eigenvalues)', digits)
    V.Print('V: (Eigenvectors)', digits)

    A1 = V * Lambda.AsDiagonal() * V.Inverse()
    print('')
    print('Check Eigensystem: V * D * V^(-1) = A')
    A1.Print('A1 = V * D * V^(-1): ', digits)

    print('')
    print('Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0')
    X = +A # need a deep copy

    for i in  range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i])
        d = X.Det()
        print('Det(A - lambda{0} * I_n): {1}', i, d)

    print('')
    print('Check per Eigenvector: A * v(i) - lambda * v(i) = 0')

    for i in  range(n):
        # X = A * V.Col(i) - V.Col(i) * Lambda(i)
        X = A * V.get_Col(i) - V.get_Col(i) * Lambda[i]
        X.Print('A * v(i) - lambda * v(i): ', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

