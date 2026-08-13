
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
        DemoAnyMatCODCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatCODCtx():
    print('DemoAnyMatCODCtx: ' + Ctx.name)
    digits = 15
    m = 5
    n = 5

    A = Ctx.mat_random(n, m)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)

    res = A.COD('info, dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qtz, t, z, householderq, hqnonzeros, x, pseudoinverse', b1)

    print('info: {0}', res['info'][0, 0])
    print('dimofkernel: {0}', res['dimofkernel'][0, 0])
    print('rank: {0}', res['rank'][0, 0])
    print('nonzeropivots: {0}', res['nonzeropivots'][0, 0])

    print('isinjective: {0}', res['isinjective'][0, 0])
    print('isinvertible: {0}', res['isinvertible'][0, 0])
    print('issurjective: {0}', res['issurjective'][0, 0])

    print('absdet: {0}', res['absdet'][0, 0])
    print('logabsdet: {0}', res['logabsdet'][0, 0])
    print('maxpivot: {0}', res['maxpivot'][0, 0])

    QTZ1 = res['qtz']
    T1 = res['t']
    Z1 = res['z']
    householderq = res['householderq']
    hqnonzeros = res['hqnonzeros']
    QTZ1.Print('QTZ1: ', digits)
    T1.Print('T1: ', digits)
    Z1.Print('Z1: ', digits)
    householderq.Print('householderq: ', digits)
    hqnonzeros.Print('hqnonzeros: ', digits)

    inv1 = res['pseudoinverse']
    inv1.Print('inv: ', digits)
    Diff = A * inv1
    Diff.Print('A * inv: ', digits)

    x1 = res['x']
    x1.Print('x: ', digits)
    b2 = A * x1
    b2.Print('b2 = A * x: ', digits)

    Diff = b1 - b2
    Diff.Print('Diff = b2 - b: ', digits)






try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

