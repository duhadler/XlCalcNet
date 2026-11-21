
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_all = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_broadcast_arrays()



def demo_broadcast_arrays():
    print('npm.broadcast_arrays(x, y): ')
    for ctx in ctx_all: 
        x = npm.array([[1,2,3]], dtype=ctx)
        y = npm.array([[4],[5]], dtype=ctx)
        print(ctx.name + ': ', npm.broadcast_arrays(x, y)); 



try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




