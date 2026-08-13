
#Note: ipm does not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_mean()



def demo_mean():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[10, 7, 4], [3, 2, 1]], dtype=ctx); print('x: ', x)
        print('npm.mean(x): \n', npm.mean(x)); 
        print('npm.mean(x, axis=0): \n', npm.mean(x, axis=0)); 
        print('npm.mean(x, axis=1): \n', npm.mean(x, axis=1)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




