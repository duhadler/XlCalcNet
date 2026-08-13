
''' Set use_xlcalcnet2 = False to exclude code requiring xlcalcnet2 '''
use_xlcalcnet2 = True; use_xlcalcnet = True

if use_xlcalcnet : 
    from xlcalcnet import FixedPrecNet, math53, sreal, dreal, ereal, qreal, \
        oreal
    from FixedPrecNet import cb1SSingle1S, cb1SDouble1S, cb1SExtended1S, \
        cb1SQuadruple1S, cb1SOctuple1S
    from FixedPrecNet import Extended, Quadruple, Octuple
if use_xlcalcnet2: 
    from xlcalcnet import ArbPrecNet, ArbPrec, mreal
    from ArbPrecNet import cb1SMpfr1S, Mpfr

def get_cb(Ctx):
    cb = None
    if Ctx is sreal: cb = cb1SSingle1S
    elif Ctx is dreal: cb = cb1SDouble1S
    elif Ctx is ereal: cb = cb1SExtended1S
    elif Ctx is qreal: cb = cb1SQuadruple1S
    elif Ctx is oreal: cb = cb1SOctuple1S
    elif (use_xlcalcnet2 and Ctx is mreal): cb = cb1SMpfr1S
    return cb


def get_ctx_from_scalar(x):
    ctx = None
    if type(x) is float: ctx = dreal
    elif type(x) is FixedPrecNet.Extended: ctx = ereal
    elif type(x) is FixedPrecNet.Quadruple: ctx = qreal
    elif type(x) is FixedPrecNet.Octuple: ctx = oreal
    elif (use_xlcalcnet2 and type(x) is ArbPrecNet.Mpfr): ctx = mreal
    return ctx

#

def main_tests():
    if use_xlcalcnet2: ArbPrec.SetDps(40)
    demo_Trapezoidal_dreal()
    demo_Trapezoidal_Many()


def f13_dreal(x):
    fx = dreal.t(1) / (dreal.t(5) - dreal.t(4) * dreal.cos(x));
    return fx;


def demo_Trapezoidal_dreal():
    print('dreal.Trapezoidal(cb(f13), a, b, tol, max_refinements): ')
    a = dreal.zero()
    b = 2 * dreal.pi()
    tol= dreal.zero()
    max_refinements = 12
    cb = cb1SDouble1S
    res = dreal.Trapezoidal(cb(f13_dreal), a, b, tol, max_refinements)
    integral = res.Item1
    error = res.Item2
    CondNo = res.Item3
    print('integral:', dreal.fmt(integral))
    print('error:', dreal.fmt(error))
    print('CondNo:', dreal.fmt(CondNo))
    print()




def f13_many(x):
#    print(type(x))
    Ctx = get_ctx_from_scalar(x)
    fx = Ctx.t(1) / (Ctx.t(5) - Ctx.t(4) * Ctx.cos(x));
    return fx;


def demo_Trapezoidal_Many():
    print('Ctx.Trapezoidal(cb(f13), a, b, tol, max_refinements): ')
    for Ctx in [sreal, dreal, ereal, qreal, oreal, mreal]:
        a = Ctx.zero()
        b = 2 * Ctx.pi()
        tol= Ctx.zero()
        max_refinements = 12
        cb = get_cb(Ctx)
        res = Ctx.Trapezoidal(cb(f13_many), a, b, tol, max_refinements)
        integral = res.Item1
        error = res.Item2
        CondNo = res.Item3
        print(Ctx.name + ': integral =', Ctx.fmt(integral))
#        print('error:', error)
#        print('CondNo:', CondNo)
#        print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











