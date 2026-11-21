
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
        DemoAnyMatTridiagonalizationCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatTridiagonalizationCtx():
    print('DemoAnyMatTridiagonalizationCtx: ' + Ctx.name)
    digits = 15
    n = 8
    A = Ctx.mat_random_selfadjoint(n)

    A.Print('A: ', digits)

    res = A.Tridiag('q, t, packed, hcoeff, diag, subdiag')

    Q1 = res['q']
    Q1.Print('Q1: ', digits)
    T1 = res['t']
    T1.Print('T1: ', digits)
    packed = res['packed']
    packed.Print('packed: ', digits)
    hcoeff = res['hcoeff']
    hcoeff.Print('hcoeff: ', digits)
    diag = res['diag']
    diag.Print('diag: ', digits)
    subdiag = res['subdiag']
    subdiag.Print('subdiag: ', digits)

    I_n = Ctx.mat_ones(n, 1)

    evaltridiag = diag.SelfAdjointEigenValuesFromTridiag('eval', subdiag)

    Lambda = evaltridiag['eval']
    Lambda.Print('Lambda: (Eigenvalues)', digits)

    print('')
    print('Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0')

    X = +A # need a deep copy
    #for (int i = 0, loopTo = n - 1 i <= loopTo i++)

    for i in range(n):
        # X.Diagonal = A.Diagonal - (I_n * Lambda(i))
        X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i])
        d = X.Det()
        print('Det(A - lambda{0} * I_n): {1}', i, d)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

