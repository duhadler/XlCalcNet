
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_argsort()



def demo_argsort():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([3, 1, 2], dtype=ctx); print('x: ', x)
        print('npm.argsort(x): \n', npm.argsort(x)); 

        x = npm.array([[0, 3], [2, 2]], dtype=ctx); print('x: ', x)

        # sorts along first axis (down)
        ind = npm.argsort(x, axis=0)
        print('npm.argsort(x, axis=0): \n', ind); 

        # same as np.sort(x, axis=0)
        print('take_along_axis(x, ind, axis=0): \n', npm.take_along_axis(x, ind, axis=0)); 

        # sorts along last axis (across)
        ind = npm.argsort(x, axis=1)
        print('npm.argsort(x, axis=1): \n', ind); 

        # same as np.sort(x, axis=1)
        print('take_along_axis(x, ind, axis=1): \n', npm.take_along_axis(x, ind, axis=1)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




