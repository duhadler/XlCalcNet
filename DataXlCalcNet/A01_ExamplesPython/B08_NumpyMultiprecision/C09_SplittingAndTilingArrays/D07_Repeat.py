
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_repeat()



def demo_repeat():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        print('repeat(ctx.t(3), repeats=4): \n', npm.repeat(ctx.t(3), repeats=4))
        x = npm.array([[1,2],[3,4]], dtype=ctx); print('x: ', x)
        print('repeat(x, repeats=2): \n', npm.repeat(x, repeats=2)); 
        print('repeat(x, repeats=3, axis=1): \n', npm.repeat(x, repeats=3, axis=1)); 
        print('repeat(x, repeats=[1, 2], axis=0): \n', npm.repeat(x, repeats=[1, 2], axis=0)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




