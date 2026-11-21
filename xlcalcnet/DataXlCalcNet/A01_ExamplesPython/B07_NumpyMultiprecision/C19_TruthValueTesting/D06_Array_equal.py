
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_any = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_array_equal()



def demo_array_equal():

    for ctx in ctx_any: 
        print()
        print(ctx.name)
        x = npm.array([1, 2], dtype=ctx); print('x: ', x)
        y = npm.array([1, 2], dtype=ctx); print('y: ', y)
        z = npm.array([1, 2, 3], dtype=ctx); print('z: ', z)
        print('npm.array_equal(x, y): \n', npm.array_equal(x, y)); 
        print('npm.array_equal(x, z): \n', npm.array_equal(x, z)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




