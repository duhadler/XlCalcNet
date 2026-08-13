
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_flip()



def demo_flip():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(8, dtype=ctx).reshape(2,2,2); print('x: ', x)
        print('npm.flip(x, axis=0): ')
        print(npm.flip(x, axis=0)); 

        print('npm.flip(x, axis=1): ')
        print(npm.flip(x, axis=1)); 

try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




