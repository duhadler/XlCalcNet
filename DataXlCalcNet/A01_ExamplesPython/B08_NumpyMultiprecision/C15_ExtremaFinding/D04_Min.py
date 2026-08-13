
#Note: Nan and Inf do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_min()



def demo_min():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(4, dtype=ctx).reshape((2,2)); print('x: ', x)
        print('npm.min(x): \n', npm.min(x)); 
        print('npm.min(x, axis=0): \n', npm.min(x, axis=0)); 
        print('npm.min(x, axis=1): \n', npm.min(x, axis=1)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




