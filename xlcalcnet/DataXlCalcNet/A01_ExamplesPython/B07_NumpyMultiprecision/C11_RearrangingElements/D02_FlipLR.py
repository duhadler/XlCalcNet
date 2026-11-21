
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_fliplr()



def demo_fliplr():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.diag(npm.array([1.,2.,3.], dtype=ctx)); print('x: ', x)
        print('npm.fliplr(x): ')
        print(npm.fliplr(x)); 

try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




