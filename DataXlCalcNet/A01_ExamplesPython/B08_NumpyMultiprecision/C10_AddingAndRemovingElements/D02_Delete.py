
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_delete()



def demo_delete():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[1,2,3,4], [5,6,7,8], [9,10,11,12]], dtype=ctx); print('x: ', x)
        print('npm.delete(x, obj=1, axis=0): ')
        print(npm.delete(x, obj=1, axis=0)); 
        print('npm.delete(x, obj=np.s_[::2], axis=1): ')
        print(npm.delete(x, obj=np.s_[::2], axis=1)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




