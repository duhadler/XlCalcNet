
# Note: this returns results in double precision

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_sort_complex()



def demo_sort_complex():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([5.1, 3, 6, 2, 1], dtype=ctx); print('a: ', a)
        print('npm.sort_complex(a): \n', npm.sort_complex(a)); 







try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




