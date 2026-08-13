
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_block()



def demo_block():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, 2, 3], dtype=ctx); print('x: ', x)
        y = npm.array([4, 5, 6], dtype=ctx); print('y: ', y)
        print('block([x, y, ctx.t(10)]): \n', npm.block([x, y, ctx.t(10)])); 
        print('block([[a], [b]]): \n', npm.block([[x], [y]])); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




