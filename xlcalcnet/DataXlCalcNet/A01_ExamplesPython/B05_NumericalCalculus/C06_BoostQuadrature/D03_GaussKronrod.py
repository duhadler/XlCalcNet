
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoGaussKronrodCtx()


def F15(x):
    Ctx = gui.lastctx
    fx = Ctx.exp(-x * x / 2);
    return fx;


def DemoGaussKronrodCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('GaussKronrod:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        a = Ctx.zero
        b = Ctx.inf
        tol= Ctx.zero
        max_depth = 12
        res = Ctx.GaussKronrod(Ctx.cb1SRet1S(F15), a, b, tol, max_depth)
        print('Ctx.GaussKronrod(cb1SRet1S(f15), a, b, tol, max_depth): ')
        integral = res.Item1
        error = res.Item2
        CondNo = res.Item3
        print('integral:', Ctx.fmt(integral))
        print('error:', Ctx.fmt(error))
        print('CondNo:', Ctx.fmt(CondNo))
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











