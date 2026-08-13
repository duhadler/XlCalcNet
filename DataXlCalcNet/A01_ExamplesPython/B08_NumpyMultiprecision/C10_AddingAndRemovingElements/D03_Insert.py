
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_insert()



def demo_insert():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(6, dtype=ctx).reshape(3, 2); print('x: ', x)
        print('npm.insert(x, obj=1, values=6): ')
        print(npm.insert(x, obj=1, values=6)); 
        print('npm.insert(x, obj=1, values=6, axis=1): ')
        print(npm.insert(x, obj=1, values=6, axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




