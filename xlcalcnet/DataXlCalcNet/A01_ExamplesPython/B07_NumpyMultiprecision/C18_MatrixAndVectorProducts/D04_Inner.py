

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_inner()



def demo_inner():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.arange(24, dtype=ctx).reshape((2,3,4)); print('a: ', a)
        b = npm.arange(4, dtype=ctx); print('b: ', b)
        print('npm.dot(a, b): \n', npm.inner(a, b)); 

        a = npm.arange(2, dtype=ctx).reshape((1,1,2)); print('a: ', a)
        b = npm.arange(6, dtype=ctx).reshape((3,2)); print('b: ', b)
        print('npm.dot(a, b): \n', npm.inner(a, b)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




