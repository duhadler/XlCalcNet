
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_cumprod()



def demo_cumprod():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1, 2, 3], [4, 5, 6]], dtype=ctx); print('x: ', x)
        print('npm.cumprod(x): \n', npm.cumprod(x)); 
        print('npm.cumprod(x, axis=0): \n', npm.cumprod(x, axis=0)); 
        print('npm.cumprod(x, axis=1): \n', npm.cumprod(x, axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




