
#Note: Nan and Inf do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_max()



def demo_max():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(4, dtype=ctx).reshape((2,2)); print('x: ', x)
        print('npm.max(x): \n', npm.max(x)); 
        print('npm.max(x, axis=0): \n', npm.max(x, axis=0)); 
        print('npm.max(x, axis=1): \n', npm.max(x, axis=1)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




