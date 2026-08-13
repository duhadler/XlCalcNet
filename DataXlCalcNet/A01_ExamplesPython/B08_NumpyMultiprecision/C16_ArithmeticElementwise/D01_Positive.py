
#Note: Nan and Inf do not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_positive()



def demo_positive():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array([1, -1], dtype=ctx); print('x: ', x)
        print('npm.positive(x): \n', npm.positive(x)); 
        print('+x: \n', +x); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




