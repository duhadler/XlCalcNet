
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_concatenate()



def demo_concatenate():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1, 2], [3, 4]], dtype=ctx); print('x: ', x)
        y = npm.array([[5, 6]], dtype=ctx); print('y: ', y)
        print('concatenate((x, y), axis=0): \n', npm.concatenate((x, y), axis=0)); 
        print('concatenate((x, y.T), axis=1): \n', npm.concatenate((x, y.T), axis=1)); 
        print('concatenate((x, y), axis=None): \n', npm.concatenate((x, y), axis=None)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




