
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_nonzero()



def demo_nonzero():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([[3, 0, 0], [0, 4, 0], [5, 6, 0]], dtype=ctx); print('x: ', x)
        print('npm.nonzero(x): \n', npm.nonzero(x)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




