
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_reshape()



def demo_reshape():
    print()
    for ctx in ctx_all: 
        a = npm.arange(6, dtype=ctx).reshape((3, 2))
        print(ctx.name + ', a: \n', a); 
        b = npm.reshape(a, (2, 3)) # C-like index ordering
        print('reshape(a, (2, 3)): \n', b); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




