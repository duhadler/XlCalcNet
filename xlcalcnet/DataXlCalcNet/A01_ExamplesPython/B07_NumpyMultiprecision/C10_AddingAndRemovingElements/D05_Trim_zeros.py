
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_trim_zeros()



def demo_trim_zeros():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        x = npm.array((0, 0, 0, 1, 2, 3, 0, 2, 1, 0), dtype=ctx); print('x: ', x)
        print('npm.trim_zeros(x): ')
        print(npm.trim_zeros(x)); 
        print('npm.trim_zeros(x, trim="b"): ')
        print(npm.trim_zeros(x, trim='b')); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




