
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoTrapezoidalCtx()


def F13(x):
    Ctx = gui.lastctx
    fx = Ctx.t(1) / (Ctx.t(5) - Ctx.t(4) * Ctx.cos(x));
    return fx;


def DemoTrapezoidalCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('Trapezoidal:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        a = Ctx.zero
        b = 2 * Ctx.pi
        tol= Ctx.zero
        max_refinements = 12
        res = Ctx.Trapezoidal(Ctx.cb1SRet1S(F13), a, b, tol, max_refinements)
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











