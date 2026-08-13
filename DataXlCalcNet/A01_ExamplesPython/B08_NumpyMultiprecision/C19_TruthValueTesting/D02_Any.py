
from xlcalcnet import fpm, mpm, ipm, dpm, qpm, gpm, apm, npm, np

ctx_any = [fpm, mpm, ipm, dpm, qpm, gpm, apm]
np.set_printoptions(linewidth=200)

def main_tests():
    demo_any()



def demo_any():
    print('npm.any([[True,False],[True,True]]): ', npm.any([[True,False],[True,True]]))
    print('npm.any([[True,False],[True,True]], axis=0): ', npm.any([[True,False],[True,True]], axis=0))

    for ctx in ctx_any: 
        print()
        print(ctx.name)
        x = npm.array([-1, 4, 5], dtype=ctx); print('x: ', x)
        print('npm.any(x): \n', npm.any(x)); 


try:
    main_tests()

except Exception:
    import traceback
    print(traceback.format_exc())




