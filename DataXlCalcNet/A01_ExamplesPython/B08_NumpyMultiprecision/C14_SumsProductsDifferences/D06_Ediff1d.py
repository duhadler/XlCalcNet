
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_ediff1d()



def demo_ediff1d():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 4, 7, 0], dtype=ctx); print('x: ', x)
        print('npm.ediff1d(x): \n', npm.ediff1d(x)); 

        x = npm.array([[1, 2, 4], [1, 6, 24]], dtype=ctx); print('x: ', x)
        print('npm.ediff1d(x): \n', npm.ediff1d(x)); 

try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




