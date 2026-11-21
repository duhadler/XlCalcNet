
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoOouraCosCtx()


def F19(x):
    Ctx = gui.lastctx
    fx = Ctx.exp(-3 * x);
    return fx;


def DemoOouraCosCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('OouraCos:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        res = Ctx.Ooura_Cos(Ctx.cb1SRet1S(F19))
        print('Ctx.Ooura_Cos(cb(f19)): ')
        integral = res.Item1
        error = res.Item2
        print('integral:', Ctx.fmt(integral))
        print('error:', Ctx.fmt(error))
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











