
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    #demo_tril2D()
    demo_tril3D()


def demo_tril2D():
    print()
    print('demo_tril2D')
    for ctx in ctx_all: 
        print()
        x = npm.tril(npm.t(ctx, [[1,2,3],[4,5,6],[7,8,9],[10,11,12]] ), k=-1); 
        print(x)


def demo_tril3D():
    print()
    print('demo_tril2D')
    for ctx in ctx_all: 
        print()
        x = npm.tril( npm.arange(3*4*5, dtype=ctx).reshape((3,4,5)) ); 
        print(x)



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




