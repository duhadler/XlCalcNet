
''' Set use_xlcalcnet2 = False to exclude code requiring xlcalcnet2 '''
use_xlcalcnet2 = True; use_xlcalcnet = True

if use_xlcalcnet : 
    from xlcalcnet import FixedPrecNet, math53, sreal, dreal, ereal, qreal, \
        oreal
    from FixedPrecNet import cb1SSingle1S, cb1SDouble1S, cb1SExtended1S, \
        cb1SQuadruple1S, cb1SOctuple1S

if use_xlcalcnet2: 
    from xlcalcnet import ArbPrecNet, ArbPrec, mreal
    from ArbPrecNet import cb1SMpfr1S

Ctx = None

''' Uncomment one of the lines below to select the data type '''
#Ctx = sreal; cb = cb1SSingle1S
#Ctx = dreal; cb = cb1SDouble1S
#Ctx = ereal; cb = cb1SExtended1S
Ctx = qreal; cb = cb1SQuadruple1S
#Ctx = oreal; cb = cb1SOctuple1S
#if use_xlcalcnet2: Ctx = mreal; cb = cb1SMpfr1S


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        demo_Brent_Minimum()
    else:
        print('Nothing to do, since Ctx is None.')



def f12(x):
    fx = (x + 3) * (x - 1) * (x - 1);
    return fx;


def demo_Brent_Minimum():
    print('Brent_Minimum:')
    bracket_min = Ctx.t(0.5)
    bracket_max = Ctx.t(1.5)
    bits = Ctx.prec;
    maxit = 50;
    res = Ctx.Brent_Minimum(cb(f12), bracket_min, bracket_max, bits, maxit)
    print('Ctx.Brent_Minimum(cb(f12), bracket_min, bracket_max, bits, maxit): ')
    x0 = res.Item1
    fx0 = res.Item2
    iter1 = res.Item3
    print('x0:', x0)
    print('fx0:', fx0)
    print('iter1:', iter1)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











