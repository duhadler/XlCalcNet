
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
        demo_GaussLegendre()
    else:
        print('Nothing to do, since Ctx is None.')



def f14(x):
    fx = 1 / (5 - 4 * Ctx.cos(x));
    return fx;


def demo_GaussLegendre():
    print('GaussLegendre:')
    a = Ctx.zero()
    b = Ctx.t(1.0);
    max_refinements = 12
    res = Ctx.GaussLegendre(cb(f14), a, b)
    print('Ctx.GaussLegendre(cb(f14), a, b): ')
    integral = res.Item1
    CondNo = res.Item2
    print('integral:', integral)
    print('CondNo:', CondNo)
    print()



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











