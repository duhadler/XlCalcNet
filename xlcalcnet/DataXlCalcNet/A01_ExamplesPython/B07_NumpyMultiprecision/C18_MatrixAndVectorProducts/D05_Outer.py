

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_outer()



def demo_outer():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.ones((5,), dtype=ctx); print('a: ', a)
        b = npm.linspace(-2, 2, 5, dtype=ctx); print('b: ', b)
        print('npm.outer(a, b): \n', npm.outer(a, b)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




