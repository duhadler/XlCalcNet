
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_rot90()



def demo_rot90():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        m = npm.array([[1,2],[3,4]], dtype=ctx); print('m: ', m)
        print('npm.rot90(m): ')
        print(npm.rot90(m)); 
        
        m = npm.arange(8, dtype=ctx).reshape(2,2,2); print('m: ', m)
        print('npm.rot90(m, k=1, axes=(1,2)): ')
        print(npm.rot90(m, k=1, axes=(1,2))); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




