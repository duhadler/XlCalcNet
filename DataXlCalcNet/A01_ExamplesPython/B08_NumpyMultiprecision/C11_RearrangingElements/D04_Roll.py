
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_roll()



def demo_roll():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(10, dtype=ctx); print('x: ', x)
        print('npm.roll(x, shift=2): ')
        print(npm.roll(x, shift=2)); 

        x2 = npm.reshape(x, (2, 5)); print('x2: ', x2)
        print('npm.roll(x2, shift=1): ')
        print(npm.roll(x2, shift=1)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




