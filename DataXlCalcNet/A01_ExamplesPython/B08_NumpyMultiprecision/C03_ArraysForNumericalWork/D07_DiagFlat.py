
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    #demo_diag0()
    demo_diag1()


def demo_diag0():
    print()
    print('demo_diag')
    for ctx in ctx_all: 
        x = npm.diagflat(npm.t(ctx, [[1,2], [3,4]] )); 
        print(x)


def demo_diag1():
    print()
    print('demo_diag')
    for ctx in ctx_all: 
        x = npm.diagflat(npm.t(ctx, [1,2]), 1 ); 
        print(x)


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




