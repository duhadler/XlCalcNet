
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_any = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_less_equal()



def demo_less_equal():

    for ctx in ctx_any: 
        print()
        print(ctx.name)
        x = npm.array([4, 2, 1], dtype=ctx); print('x: ', x)
        y = npm.array([2, 2, 2], dtype=ctx); print('y: ', y)
        print('npm.less_equal(x, y): \n', npm.less_equal(x, y)); 
        print('x <= y: \n', x <= y); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




