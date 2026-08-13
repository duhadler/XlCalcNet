
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_swapaxes2d()
#    demo_swapaxes3d()



def demo_swapaxes2d():
    for ctx in ctx_all: 
        print()
        x = npm.array([[1,2,3]], dtype=ctx)
        print(ctx.name + ', x: \n', x); 
        print('swapaxes(x, axis1=0, axis2=1): \n', npm.swapaxes(x, axis1=0, axis2=1)); 



def demo_swapaxes3d():
    for ctx in ctx_all: 
        print()
        x = npm.array([[[0,1],[2,3]],[[4,5],[6,7]]], dtype=ctx)
        print(ctx.name + ', x: \n', x); 
        print('swapaxes(x, axis1=0, axis2=2): \n', npm.swapaxes(x, axis1=0, axis2=2)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




