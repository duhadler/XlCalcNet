
#Note: Nan and Inf do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_minimum()



def demo_minimum():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([2, 3, 4], dtype=ctx); print('x: ', x)
        y = npm.array([1, 5, 2], dtype=ctx); print('y: ', y)
        print('npm.minimum(x, y): \n', npm.minimum(x, y)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




