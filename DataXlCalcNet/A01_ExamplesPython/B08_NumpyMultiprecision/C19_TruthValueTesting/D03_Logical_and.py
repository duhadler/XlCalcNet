
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_any = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_logical_and()



def demo_logical_and():
    print('npm.logical_and([[True,False],[True,True]]): ', npm.logical_and([True,False],[True,True]))

    for ctx in ctx_any: 
        print()
        print(ctx.name)
        x = npm.arange(5, dtype=ctx); print('x: ', x)
        print('npm.logical_and(x>1, x<4): \n', npm.logical_and(x>1, x<4)); 
        print('(x>1) & (x<4): \n', (x>1) & (x<4)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




