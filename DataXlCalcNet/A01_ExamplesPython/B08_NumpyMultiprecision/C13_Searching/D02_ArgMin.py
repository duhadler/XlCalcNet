
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_argmin()



def demo_argmin():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.arange(6, dtype=ctx).reshape(2,3) + 10; print('a: ', a)
        print('npm.argmin(a, axis=0)): \n', npm.argmin(a, axis=0)); 
        print('npm.argmin(a, axis=1): \n', npm.argmin(a, axis=1)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




