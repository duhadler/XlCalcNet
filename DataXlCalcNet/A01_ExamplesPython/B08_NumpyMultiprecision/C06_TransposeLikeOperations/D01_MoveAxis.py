
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_moveaxis()



def demo_moveaxis():
    for ctx in ctx_all: 
        print()
        x = npm.zeros(shape=(3, 4, 5), dtype=ctx)
        print(ctx.name + ', x = npm.zeros(shape=(3, 4, 5), dtype=ctx)'); 
        print('moveaxis(x, 0, -1).shape: ', npm.moveaxis(x, 0, -1).shape); 
        print('moveaxis(x, -1, 0).shape: ', npm.moveaxis(x, -1, 0).shape); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




