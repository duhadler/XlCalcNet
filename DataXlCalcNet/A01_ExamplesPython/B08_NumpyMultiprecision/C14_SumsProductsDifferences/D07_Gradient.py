
# NOTE: not working for Decimal

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_gradient()



def demo_gradient():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 4, 7, 11, 16], dtype=ctx); print('x: ', x)
        print('npm.gradient(x): \n', npm.gradient(x)); 

        x = npm.array([[1, 2, 6], [3, 4, 5]], dtype=ctx); print('x: ', x)
        print('npm.gradient(x): \n', npm.gradient(x)); 

try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




