
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
        DemoAnyJacobiSVDCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyJacobiSVDCtx():
    print('DemoAnyJacobiSVDCtx: ' + Ctx.name)
    digits = 15
    m = 6
    n = 12

    A = Ctx.mat_random(n, m)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)

    res = A.JacobiSVD('rank, nonzeros, s')

    # Basic information
    print()
    print()
    print('Basic information')
    print('rank: {0}', res['rank'][0, 0])
    print('nonzeros: {0}', res['nonzeros'][0, 0])

    S0 = res['s']
    S0.Print('Singular values (descending): ', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

