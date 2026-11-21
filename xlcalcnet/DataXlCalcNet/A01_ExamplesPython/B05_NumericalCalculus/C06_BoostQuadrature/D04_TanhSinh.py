
import time
from xlcalcnet import gui, sreal, dreal, ereal, qreal, oreal
if gui.has_xlcalcnet2: from xlcalcnet import mreal


def main_tests():
    if gui.has_xlcalcnet2: mreal.dps = 80
    DemoTanhSinhCtx()


def F16(x):
    Ctx = gui.lastctx
    fx = Ctx.exp(-x * x / 2);
    return fx;


def DemoTanhSinhCtx():
    boost_list = [sreal, dreal, ereal, qreal, oreal]
    if gui.has_xlcalcnet2: boost_list.append(mreal)
    for Ctx in boost_list:
        print('TanhSinh:')
        gui.lastctx = Ctx
        print('Ctx:', gui.lastctx.name)
        a = Ctx.t(-1.0);
        b = Ctx.t(1.0);
        tol= Ctx.zero
        max_refinements = 12
        res = Ctx.TanhSinh(Ctx.cb1SRet1S(F16), a, b, tol, max_refinements)
        print('Ctx.TanhSinh(cb(f16), a, b, tol, max_refinements): ')
        integral = res.Item1
        error = res.Item2
        CondNo = res.Item3
        level = res.Item4
        print('integral:', Ctx.fmt(integral))
        print('error:', Ctx.fmt(error))
        print('CondNo:', Ctx.fmt(CondNo))
        print('level:', level)
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











