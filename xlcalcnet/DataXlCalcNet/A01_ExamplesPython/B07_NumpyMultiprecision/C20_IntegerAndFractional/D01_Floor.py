
#Note: Not supported by mpm, ipm, apm

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_floor()



def demo_floor():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([-1.7, -1.5, -0.2, 0.2, 1.5, 1.7, 2.0], dtype=ctx); print('x: ', x)
        print('npm.floor(x): \n', npm.floor(x)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




