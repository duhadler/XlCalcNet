
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoBracketRootQreal()
    DemoBracketRootCtx()


def F10Qreal(x):
    fx = qreal.pow(x, 3) - qreal.t(27.1)
    return fx;

def DemoBracketRootQreal():
        print('BracketRootqreal:')
        guess = qreal.t(2.33);
        factor = qreal.t(2.0);
        is_rising = True;
        get_digits = qreal.prec;
        maxit = 50;
        res = qreal.BracketRoot(qreal.cb1SRet1S(F10Qreal), guess, factor, 
            is_rising, get_digits, maxit)
        print('Ctx.BracketRoot(f10, guess, factor, is_rising, get_digits, maxit): ')
        x0 = res.Item1
        error = res.Item2
        iter1 = res.Item3
        print('x0:', qreal.fmt(x0))
        print('error:', qreal.fmt(error))
        print('iter1:', iter1)
        print()



def F10(x):
    Ctx = gui.lastctx
    fx = Ctx.pow(x, 3) - Ctx.t(27.1)
    return fx;

def DemoBracketRootCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('BracketRoot:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        guess = Ctx.t(2.33);
        factor = Ctx.t(2.0);
        is_rising = True;
        get_digits = Ctx.prec;
        maxit = 50;
        res = Ctx.BracketRoot(Ctx.cb1SRet1S(F10), guess, factor, 
            is_rising, get_digits, maxit)
        print('Ctx.BracketRoot(f10, guess, factor, is_rising, get_digits, maxit): ')
        x0 = res.Item1
        error = res.Item2
        iter1 = res.Item3
        print('x0:', Ctx.fmt(x0))
        print('error:', Ctx.fmt(error))
        print('iter1:', iter1)
        print()


try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())











