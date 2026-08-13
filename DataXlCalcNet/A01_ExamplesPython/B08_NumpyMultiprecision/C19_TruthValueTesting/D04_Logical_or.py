
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_any = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_logical_or()



def demo_logical_or():
    print('npm.logical_or([[True,False],[False,False]]): ', npm.logical_or([True,False],[False,False]))

    for ctx in ctx_any: 
        print()
        print(ctx.name)
        x = npm.arange(5, dtype=ctx); print('x: ', x)
        print('npm.logical_or(x < 1, x > 3): \n', npm.logical_or(x < 1, x > 3)); 
        print('(x < 1) | (x > 3): \n', (x < 1) | (x > 3)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




