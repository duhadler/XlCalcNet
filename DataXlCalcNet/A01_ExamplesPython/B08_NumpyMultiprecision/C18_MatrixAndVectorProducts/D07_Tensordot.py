

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_tensordot()



def demo_tensordot():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.arange(60, dtype=ctx).reshape(3,4,5); print('a: ', a)
        b = npm.arange(24, dtype=ctx).reshape(4,3,2); print('b: ', b)
        print('npm.tensordot(a,b, axes=([1,0],[0,1])): \n', npm.tensordot(a,b, axes=([1,0],[0,1]))); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




