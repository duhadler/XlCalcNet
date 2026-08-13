
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_flat()



def demo_flat():
    for ctx in ctx_all: 
        print()
        x = npm.arange(1, 7, dtype=ctx).reshape(2, 3)
        print(ctx.name + ', x: \n', x); 
        print('x.flat[3]: ', x.flat[3]); 
        print('x.T.flat[3]: ', x.T.flat[3]); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




