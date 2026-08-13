
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
Ctx = qreal; cb = cb1SQuadruple1S
#Ctx = oreal; cb = cb1SOctuple1S
#if use_xlcalcnet2: Ctx = mreal; cb = cb1SMpfr1S


def main_tests():
    if Ctx is not None:
        if use_xlcalcnet2: ArbPrec.SetDps(40)
        demo_SinhSinh()
    else:
        print('Nothing to do, since Ctx is None.')



def f17(x):
    fx = Ctx.exp(-x * x);
    return fx;


def demo_SinhSinh():
    print('SinhSinh:')
    tol= Ctx.zero()
    max_refinements = 12
    res = Ctx.SinhSinh(cb(f17),tol, max_refinements)
    print('Ctx.SinhSinh(cb(f17),tol, max_refinements): ')
    integral = res.Item1
    error = res.Item2
    CondNo = res.Item3
    level = res.Item4
    print('integral:', integral)
    print('error:', error)
    print('CondNo:', CondNo)
    print('level:', level)
    print()




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())











