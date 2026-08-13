
#Note: ipm and apm do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, dpm, qpm, gpm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_remainder()



def demo_remainder():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x1 = npm.array([ 4., 7], dtype=ctx); print('x1: ', x1)
        x2 = npm.array([ 2., 3], dtype=ctx); print('x2: ', x2)
        print('npm.remainder(x1, x2): \n', npm.remainder(x1, x2)); 
        print(' x1 % x2: \n', x1 % x2); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




