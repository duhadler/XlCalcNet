
#Note: ipm does not work

from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_matmul()



def demo_matmul():
    for ctx in ctx_all: 
        print()
        print(ctx.name)
        a = npm.array([[1, 0], [0, 1]], dtype=ctx); print('a: ', a)
        b = npm.array([[4, 1], [2, 2]], dtype=ctx); print('b: ', b)
        print('npm.matmul(a, b): \n', npm.matmul(a, b)); 
        print('a @ b: \n', a @ b); 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




