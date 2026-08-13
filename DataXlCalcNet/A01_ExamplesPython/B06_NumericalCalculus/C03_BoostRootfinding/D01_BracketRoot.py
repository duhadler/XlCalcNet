
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
#Ctx = qreal; cb = cb1SQuadruple1S
#Ctx = oreal; cb = cb1SOctuple1S
if use_xlcalcnet2: Ctx = mreal; cb = cb1SMpfr1S


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        demo_BracketRoot()
    else:
        print('Nothing to do, since Ctx is None.')



def f10(x):
    fx = Ctx.pow(x, 3) - 27
    return fx;


def demo_BracketRoot():
    print('BracketRoot:')
    guess = Ctx.t(2.33);
    factor = Ctx.t(2.0);
    is_rising = True;
    get_digits = Ctx.prec;
    maxit = 50;
    res = Ctx.BracketRoot(cb(f10), guess, factor, is_rising, get_digits, maxit)
    print('Ctx.BracketRoot(f10, guess, factor, is_rising, get_digits, maxit): ')
    x0 = res.Item1
    error = res.Item2
    iter1 = res.Item3
    print('x0:', x0)
    print('error:', error)
    print('iter1:', iter1)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











