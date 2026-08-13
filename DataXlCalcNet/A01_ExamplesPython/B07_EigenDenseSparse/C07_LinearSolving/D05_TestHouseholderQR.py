
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
        DemoAnyMatHouseholderQRCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatHouseholderQRCtx():
    print('DemoAnyMatHouseholderQRCtx: ' + Ctx.name)
    digits = 15
    n = 4

    A = Ctx.mat_random(n, n)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)

    res = A.HouseholderQR('qr, absdet, logabsdet, x, inverse', b1)

    print('absdet: {0}', res['absdet'][0, 0])
    print('logabsdet: {0}', res['logabsdet'][0, 0])

    QR1 = res['qr']
    QR1.Print('QR: ', digits)

    inv1 = res['inverse']
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

