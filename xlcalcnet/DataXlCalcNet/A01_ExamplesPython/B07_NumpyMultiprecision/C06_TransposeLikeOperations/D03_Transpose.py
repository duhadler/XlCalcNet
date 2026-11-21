
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_transpose2d()
#    demo_transpose3d()



def demo_transpose2d():
    for ctx in ctx_all: 
        print()
        x = npm.array([[1, 2], [3, 4]], dtype=ctx)
        print(ctx.name + ', x: \n', x); 
        print('transpose(x): \n', npm.transpose(x)) 



def demo_transpose3d():
    for ctx in ctx_all: 
        print()
        x = npm.ones(shape=(1, 2, 3), dtype=ctx)
        print('transpose(x, axes=(1, 0, 2)).shape:', npm.transpose(x, axes=(1, 0, 2)).shape) 




try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




