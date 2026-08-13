
#Note: Not supported by mpm, ipm, apm

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, dpm, qpm, gpm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_floor_divide()



def demo_floor_divide():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x1 = npm.array([[ 0., 1., 2.], [ 3., 4., 5.], [ 6., 7., 8.]], dtype=ctx); print('x1: ', x1)
        x2 = npm.array([ 0.5, 1., 2.], dtype=ctx); print('x2: ', x2)
        print('npm.floor_divide(x1, x2): \n', npm.floor_divide(x1, x2)); 
        print('x1 // x2: \n', x1 // x2); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




