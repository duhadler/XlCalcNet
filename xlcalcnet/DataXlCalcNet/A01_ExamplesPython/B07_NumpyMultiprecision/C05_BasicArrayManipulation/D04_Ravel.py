
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_ravel()



def demo_ravel():
    for ctx in ctx_all: 
        print()
        x = npm.array([[1, 2, 3], [4, 5, 6]], dtype=ctx)
        print(ctx.name + ', x: \n', x); 
        b = npm.ravel(x)
        print('ravel(x): \n', b); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




