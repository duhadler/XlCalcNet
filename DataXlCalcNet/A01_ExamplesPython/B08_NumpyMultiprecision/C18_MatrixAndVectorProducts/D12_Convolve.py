
#Note: ipm does not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_convolve()



def demo_convolve():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([1, 2, 3], dtype=ctx); print('a: ', a)
        b = npm.array([0, 1, 0.5], dtype=ctx); print('b: ', b)
        print('npm.convolve(a, b): \n', npm.convolve(a, b)); 
        print('npm.convolve(a, b, mode="same"): \n', npm.convolve(a, b, mode='same')); 
        print('npm.convolve(a, b, mode="valid"): \n', npm.convolve(a, b, mode='valid')); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




