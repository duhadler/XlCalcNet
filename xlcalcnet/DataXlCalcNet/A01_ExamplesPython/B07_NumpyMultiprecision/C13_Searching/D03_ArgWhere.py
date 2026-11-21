
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_argwhere()



def demo_argwhere():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.arange(6, dtype=ctx).reshape(2,3); print('x: ', x)
        print('npm.argwhere(x>1)): \n', npm.argwhere(x>1)); 





try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




