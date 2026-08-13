
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_hsplit()



def demo_hsplit():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(16.0, dtype=ctx).reshape(4, 4); print('x: ', x)
        print('hsplit(x, 2): \n', npm.hsplit(x, 2)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




