
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoNewtonRaphsonCtx()


def F10(x):
    Ctx = gui.lastctx
    fx = Ctx.pow(x, 3) - Ctx.t(27.1)
    return fx;


def DF10(x):
    fx = 3 * x * x
    return fx;


def DemoNewtonRaphsonCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('BracketRoot:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        guess = Ctx.t(2.33);
        xmin = Ctx.t(1.0);
        xmax = Ctx.t(4.0);
        get_digits = Ctx.prec;
        maxit = 50;
        res = Ctx.NewtonRaphson(Ctx.cb1SRet1S(F10), Ctx.cb1SRet1S(DF10), 
            guess, xmin, xmax, get_digits, maxit)
        print('Ctx.NewtonRaphson(cb(f10), cb(df10), guess, xmin, xmax, get_digits, maxit): ')
        x0 = res.Item1
        iter1 = res.Item2
        print('x0:', Ctx.fmt(x0))
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











