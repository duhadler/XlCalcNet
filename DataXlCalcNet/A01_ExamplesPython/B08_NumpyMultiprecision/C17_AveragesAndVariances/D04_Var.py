
#Note: ipm, apm does not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, dpm, qpm, gpm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_var()



def demo_var():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[10, 7, 4], [3, 2, 1]], dtype=ctx); print('x: ', x)
        print('npm.var(x): \n', npm.var(x)); 
        print('npm.var(x, axis=0): \n', npm.var(x, axis=0)); 
        print('npm.var(x, axis=1): \n', npm.var(x, axis=1)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




