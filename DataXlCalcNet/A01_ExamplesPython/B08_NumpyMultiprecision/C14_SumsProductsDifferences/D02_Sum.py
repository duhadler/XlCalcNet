
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_sum()



def demo_sum():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1, 2], [3, 4]], dtype=ctx); print('x: ', x)
        print('npm.sum(x): \n', npm.sum(x)); 
        print('npm.sum(x, axis=0): \n', npm.sum(x, axis=0)); 
        print('npm.sum(x, axis=1): \n', npm.sum(x, axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




