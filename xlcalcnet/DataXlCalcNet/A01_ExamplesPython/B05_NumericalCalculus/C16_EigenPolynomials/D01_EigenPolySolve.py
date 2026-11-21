
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
        DemoAnyPolySolveCtx()
    else:
        print('Nothing to do, since Ctx is None.')


def DemoAnyPolySolveCtx():
    print('DemoAnyPolySolveCtx: ' + Ctx.name);
    digits = 15;

    roots = Ctx.mat_random(14, 1);
    roots.Print('roots: ', 15);

    polynomial = roots.RootsToMonicPolynomial();
    polynomial.Print('polynomial: ', 15);

    evaluations = polynomial.PolyEval(roots);
    evaluations.Print('evaluations: ', 15);

    cplxroots = polynomial.PolynomialSolver();
    cplxroots.Print('cplxroots: ', 15);

    cplxevaluations = polynomial.PolyEval(cplxroots);
    cplxevaluations.Print('cplxevaluations: ', 15);



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())

