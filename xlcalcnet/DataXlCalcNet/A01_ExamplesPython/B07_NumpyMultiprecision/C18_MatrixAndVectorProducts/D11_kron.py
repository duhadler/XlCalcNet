
#Note: ipm does not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_kron()



def demo_kron():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([1,10,100], dtype=ctx); print('a: ', a)
        b = npm.array([5,6,7], dtype=ctx); print('b: ', b)
        print('npm.kron(a, b): \n', npm.kron(a, b)); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




