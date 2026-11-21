
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_take_along_axis()



def demo_take_along_axis():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([[10, 30, 20], [60, 40, 50]], dtype=ctx); print('a: ', a)
        print('npm.sort(a, axis=1): \n', npm.sort(a, axis=1)); 

        ai = npm.argsort(a, axis=1)
        print('ai = npm.argsort(a, axis=1): \n', ai); 
        print('npm.take_along_axis(a, ai, axis=1): \n', npm.take_along_axis(a, ai, axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




