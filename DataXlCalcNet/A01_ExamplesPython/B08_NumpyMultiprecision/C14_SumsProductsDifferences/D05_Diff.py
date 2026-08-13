
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
#    demo_diff1d()
    demo_diff2d()



def demo_diff1d():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 4, 7, 0], dtype=ctx); print('x: ', x)
        print('npm.diff(x): \n', npm.diff(x)); 
        print('npm.diff(x, n=2): \n', npm.diff(x, n=2)); 


def demo_diff2d():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1, 3, 6, 10], [0, 5, 6, 8]], dtype=ctx); print('x: ', x)
        print('npm.diff(x): \n', npm.diff(x)); 
        print('npm.diff(x, axis=0): \n', npm.diff(x, axis=0)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




