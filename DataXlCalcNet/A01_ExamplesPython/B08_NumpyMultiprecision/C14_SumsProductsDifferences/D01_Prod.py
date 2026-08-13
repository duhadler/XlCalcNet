
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_prod()



def demo_prod():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1, 2], [3, 4]], dtype=ctx); print('x: ', x)
        print('npm.prod(x): \n', npm.prod(x)); 
        print('npm.prod(x, axis=0): \n', npm.prod(x, axis=0)); 
        print('npm.prod(x, axis=1): \n', npm.prod(x, axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




