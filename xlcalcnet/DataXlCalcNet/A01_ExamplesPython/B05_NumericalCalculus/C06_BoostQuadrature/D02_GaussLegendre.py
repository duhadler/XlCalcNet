
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoGaussLegendreCtx()


def F14(x):
    Ctx = gui.lastctx
    fx = 1 / (5 - 4 * Ctx.cos(x));
    return fx;


def DemoGaussLegendreCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('GaussLegendre:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        a = Ctx.zero
        b = Ctx.t(1.0);
        max_refinements = 12
        res = Ctx.GaussLegendre(Ctx.cb1SRet1S(F14), a, b)
        print('Ctx.GaussLegendre(cb(f14), a, b): ')
        integral = res.Item1
        CondNo = res.Item2
        print('integral:', Ctx.fmt(integral))
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











