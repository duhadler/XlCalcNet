
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_flatten()



def demo_flatten():
    for ctx in ctx_all: 
        print()
        x = npm.array([[1,2], [3,4]], dtype=ctx)
        print(ctx.name + ', x: \n', x); 
        print('x.flatten()   : ', x.flatten()); 
        print('x.flatten("F"): ', x.flatten('F')); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




