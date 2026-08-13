
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
        DemoAnyMatFFTCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyMatFFTCtx():
    print('DemoAnyMatFFTCtx: ' + Ctx.name)
    digits = 15
    n = 4

    A = Ctx.mat_zeros(2 * n, 1)

    A_real = Ctx.mat_random(n, 1)
    for i in range(n):
        A[i] = A_real[i]
    A.Print('A: ', 15)

    B = Ctx.mat_zeros(2 * n, 1)
    B_real = Ctx.mat_random(n, 1)
    for i in range(n):
        B[i] = B_real[i]
    B.Print('B: ', 15)

    TA = A.FFTFwd()
    TA.Print('TA: ', 15)

    TB = B.FFTFwd()
    TB.Print('TB: ', 15)

    # Dim TC = Ctx.CplxCtx.Mat.Zeros(2 * n, 1)

    TC = Ctx.mat_cplx_zeros(2 * n, 1)

    for i in range(2 * n):
        TC[i] = TA[i] * TB[i]
    TC.Print('TC: ', 15)

    if (Ctx.iscplxctx):
        C3 = TC.FFTCplxInv()
        C3.Print('C3: ', 15)
    else:
        C2 = TC.FFTRealInv()
        C2.Print('C2: ', 15)

    C_Real = Ctx.mat_zeros(2 * n, 1)
    for i in range(n):
        for j in range(n):
            C_Real[i + j] = C_Real[i + j] + A_real[i] * B_real[j]
    C_Real.Print('C_Real: ', 15)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

