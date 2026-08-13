

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_einsum()



def demo_einsum():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.arange(25, dtype=ctx).reshape(5,5); print('a: ', a)
        print('npm.einsum("ii", a): \n', npm.einsum(a, [0,0])); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




