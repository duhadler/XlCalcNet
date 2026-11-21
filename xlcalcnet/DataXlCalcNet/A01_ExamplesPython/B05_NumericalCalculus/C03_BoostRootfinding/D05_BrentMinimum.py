
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoBrentMinimumCtx()


def F12(x):
    fx = (x + 3) * (x - 1) * (x - 1);
    return fx;


def DemoBrentMinimumCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('BrentMinimum:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        bracket_min = Ctx.t(0.5)
        bracket_max = Ctx.t(1.5)
        bits = Ctx.prec;
        maxit = 50;
        res = Ctx.Brent_Minimum(Ctx.cb1SRet1S(F12), bracket_min, bracket_max, bits, maxit)
        print('Ctx.Brent_Minimum(cb(f12), bracket_min, bracket_max, bits, maxit): ')
        x0 = res.Item1
        fx0 = res.Item2
        iter1 = res.Item3
        print('x0:', Ctx.fmt(x0))
        print('fx0:',  Ctx.fmt(fx0))
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











