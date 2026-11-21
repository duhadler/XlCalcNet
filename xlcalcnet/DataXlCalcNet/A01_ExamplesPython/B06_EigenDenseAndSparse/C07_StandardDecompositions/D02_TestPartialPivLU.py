
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
        DemoAnyMatPartialPivLUCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatPartialPivLUCtx():
    print('DemoAnyMatPartialPivLUCtx: ' + Ctx.name)
    digits = 15
    m = 5
    n = 5

    A = Ctx.mat_random(n, m)
    A.Print('A: ', digits)
    b1 = Ctx.mat_random(n, 1)
    b1.Print('B: ', digits)

    res = A.PartialPivLU('rcond, lu, p, det, x, inverse', b1)

    print('det1: {0}', res['det'][0, 0])
    #// Console.WriteLine('det2: {0}', A.Det()(0, 0))

    print('rcond1: {0}', res['rcond'][0, 0])
    #// Console.WriteLine('rcond2: {0}', A.Rcond()(0, 0))

    LU1 = res['lu']
    P1 = res['p']
    LU1.Print('LU: ', digits)
    P1.Print('P: ', digits)

    inv1 = res['inverse']
    inv1.Print('inv1: ', digits)

    inv2 = A.Inverse()
    inv2.Print('inv2: ', digits)

    Diff = A * inv1
    Diff.Print('A * inv: ', digits)

    x1 = res['x']
    x1.Print('x1: ', digits)

    x2 = A.Solve(b1)
    x2.Print('x2: ', digits)

    b2 = A * x1
    b2.Print('b2 = A * x: ', digits)

    Diff = b1 - b2
    Diff.Print('Diff = b2 - b: ', digits)








try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

