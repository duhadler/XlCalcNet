
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
        DemoAnyMatSchurCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatSchurCtx():
    print('DemoAnyMatSchurCtx: ' + Ctx.name)
    digits = 15
    n = 14
    A = Ctx.mat_random(n, n)
    A.Print('A: ', digits)

    res = A.Schur('u, t')

    U1 = res['u']
    U1.Print('U1: ', digits)
    T1 = res['t']
    T1.Print('T1: ', digits)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

