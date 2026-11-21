
#Note: Nan and Inf do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_square()



def demo_square():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([2, -2], dtype=ctx); print('x: ', x)
        print('npm.square(x): \n', npm.square(x)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




